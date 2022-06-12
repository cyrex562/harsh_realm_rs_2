﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.CustomBitmapClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class CustomBitmapClass
  {
    private GameClass game;
    private Graphics g2;
    private Graphics g3;
    private Bitmap tmpbmp2;
    private Bitmap tmpbmp2b;
    private Bitmap tmpbmp3;
    public Font stdFont1;
    public Font stdFont2;
    public Font Stdfont3;
    public Font Stdfont4;
    public Bitmap tempHex;
    public Bitmap tempHexSmall;
    public Bitmap tempHexMed;
    public Bitmap tempHexBig;
    public int strId123slot;
    public int strId143slot;
    public int strId275slot;
    public int strId288slot;
    public int strId534slot;
    public int cache_t6;
    public int cache_tad;
    public int cache_tat;
    public int cache_rad;
    public int[,] cacheDipClear;
    public int[,] cacheZoneRecon;
    public int slotCulture;
    public int slotAssets;
    public int slotAir;
    public int slotAssetTypes;
    public int slotZones;
    public int slotPaid;
    public int slotAssetLog;
    public int slotConstruction;
    public int slotPerks;
    public int slotHexNames;
    public int slotItemType;
    public int slotAssetPresentation;
    public int slotOrigDetail;
    public int slotDetail;
    public int slotDetailPreview;
    public int slotKeyReplace;
    public Bitmap miniMapPredrawnCache;

    public CustomBitmapClass(GameClass tgame)
    {
      this.cacheDipClear = new int[2, 2];
      this.cacheZoneRecon = new int[2, 2];
      this.slotCulture = -1;
      this.game = tgame;
      this.tmpbmp2 = new Bitmap(38, 38, PixelFormat.Format32bppPArgb);
      this.tmpbmp2.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      this.tmpbmp2b = new Bitmap(76, 76, PixelFormat.Format32bppPArgb);
      this.tmpbmp2b.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      this.g2 = Graphics.FromImage((Image) this.tmpbmp2);
      this.tmpbmp3 = new Bitmap(64, 48, PixelFormat.Format32bppPArgb);
      this.tmpbmp3.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      this.g3 = Graphics.FromImage((Image) this.tmpbmp3);
      this.stdFont1 = !this.game.IsWin10 ? new Font(this.game.FontCol.Families[1], 11f, FontStyle.Bold, GraphicsUnit.Pixel) : new Font(this.game.FontCol.Families[1], 11f, FontStyle.Bold, GraphicsUnit.Pixel);
      this.stdFont2 = new Font(this.game.FontCol.Families[1], 9f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.Stdfont3 = new Font(this.game.FontCol.Families[1], 16f, FontStyle.Bold, GraphicsUnit.Pixel);
      this.Stdfont4 = new Font(this.game.FontCol.Families[1], 14f, FontStyle.Bold, GraphicsUnit.Pixel);
      this.strId123slot = -1;
      this.slotCulture = -1;
    }

    public void DrawHeightMapLate(
      ref Graphics useg,
      int cx,
      int cy,
      int cmap,
      int tx,
      int ty,
      int Zoom)
    {
      if (!this.game.AllowHeightMap)
        return;
      bool flag = false;
      if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType].IsSea)
        flag = true;
      float[] numArray1 = new float[10];
      float[] numArray2 = new float[10];
      float[] numArray3 = new float[10];
      int[] numArray4 = new int[10];
      int width;
      int height;
      switch (Zoom)
      {
        case -1:
          width = 32;
          height = 24;
          break;
        case 0:
          width = 64;
          height = 48;
          break;
        default:
          width = 128;
          height = 96;
          break;
      }
      if (((flag ? 1 : 0) & 0) != 0)
      {
        numArray4[0] = 90;
        numArray4[1] = 80;
        numArray4[2] = 70;
        numArray4[3] = 60;
        numArray4[4] = 50;
        numArray4[5] = 40;
        numArray4[6] = 30;
        numArray4[7] = 20;
        numArray4[8] = 10;
        numArray4[9] = 0;
        int index1 = -1;
        if ((double) this.game.Data.RuleVar[416] > 0.0)
          index1 = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[416]));
        if (index1 > -1)
        {
          int length = this.game.Data.StringListObj[index1].Length;
          for (int index2 = 0; index2 <= length; ++index2)
          {
            int index3 = 9 - index2;
            numArray1[index3] = (float) (Conversion.Val(this.game.Data.StringListObj[index1].Data[index2, 0]) / (double) byte.MaxValue);
            numArray2[index3] = (float) (Conversion.Val(this.game.Data.StringListObj[index1].Data[index2, 1]) / (double) byte.MaxValue);
            numArray3[index3] = (float) (Conversion.Val(this.game.Data.StringListObj[index1].Data[index2, 2]) / (double) byte.MaxValue);
            numArray4[index3] = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[index1].Data[index2, 3]));
          }
        }
        int tfacing = 1;
        do
        {
          Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
          if (coordinate.onmap && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
          {
            int index4 = 9 - this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].HeightLevel;
            if (numArray4[index4] > 0)
            {
              int num1 = tfacing - 1;
              int num2 = 11;
              ref Graphics local1 = ref useg;
              Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_SHADOW1, Zoom);
              ref Bitmap local2 = ref bitmap1;
              Rectangle srcrect = new Rectangle(num1 * width, num2 * height, width, height);
              Rectangle destrect = new Rectangle(tx, ty, width, height);
              double r = (double) numArray1[index4];
              double g = (double) numArray2[index4];
              double b = (double) numArray3[index4];
              double a = (double) ((float) numArray4[index4] / (float) byte.MaxValue);
              Bitmap bitmap2 = (Bitmap) null;
              ref Bitmap local3 = ref bitmap2;
              DrawMod.DrawSimplePart2ColouredNewFast(ref local1, ref local2, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local3);
            }
          }
          ++tfacing;
        }
        while (tfacing <= 6);
      }
      else
      {
        int tfacing = 1;
        do
        {
          Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
          if (coordinate.onmap)
          {
            int num3 = tfacing + 3;
            if (num3 > 6)
              num3 -= 6;
            if (this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RiverType[num3 - 1] == 5)
            {
              int num4 = tfacing - 1;
              int num5 = 11;
              ref Graphics local4 = ref useg;
              Bitmap bitmap3 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_SHADOW1, Zoom);
              ref Bitmap local5 = ref bitmap3;
              Rectangle srcrect = new Rectangle(num4 * width, num5 * height, width, height);
              Rectangle destrect = new Rectangle(tx, ty, width, height);
              Bitmap bitmap4 = (Bitmap) null;
              ref Bitmap local6 = ref bitmap4;
              DrawMod.DrawSimplePart2ColouredNewFast(ref local4, ref local5, srcrect, destrect, 0.0f, 0.0f, 0.0f, 0.25f, ref local6);
            }
          }
          ++tfacing;
        }
        while (tfacing <= 6);
      }
    }

    public void DrawHeightMap(
      ref Graphics useg,
      int cx,
      int cy,
      int cmap,
      int tx,
      int ty,
      int Zoom,
      bool forInteriorSea,
      ref Bitmap gBitmap = null)
    {
      if (!this.game.AllowHeightMap)
        return;
      bool flag1 = true;
      bool flag2 = false;
      if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType].IsSea)
        flag2 = true;
      if (flag2 & forInteriorSea && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType].Interior)
        flag2 = false;
      HexHeightMapData hexHeightMapData = new HexHeightMapData(ref this.game, cx, cy, cmap, forInteriorSea);
      int[] numArray1 = new int[7];
      int[] numArray2 = new int[7];
      int[] numArray3 = new int[7];
      int[] numArray4 = new int[7];
      switch (Zoom)
      {
        case -1:
          numArray1[0] = 8;
          numArray2[0] = 4;
          numArray3[0] = 16;
          numArray4[0] = 16;
          numArray1[1] = 8;
          numArray2[1] = 0;
          numArray3[1] = 16;
          numArray4[1] = 4;
          numArray1[2] = 24;
          numArray2[2] = 0;
          numArray3[2] = 8;
          numArray4[2] = 12;
          numArray1[3] = 24;
          numArray2[3] = 12;
          numArray3[3] = 8;
          numArray4[3] = 12;
          numArray1[4] = 8;
          numArray2[4] = 20;
          numArray3[4] = 16;
          numArray4[4] = 4;
          numArray1[5] = 0;
          numArray2[5] = 12;
          numArray3[5] = 8;
          numArray4[5] = 12;
          numArray1[6] = 0;
          numArray2[6] = 0;
          numArray3[6] = 8;
          numArray4[6] = 12;
          break;
        case 0:
          numArray1[0] = 16;
          numArray2[0] = 8;
          numArray3[0] = 32;
          numArray4[0] = 32;
          numArray1[1] = 16;
          numArray2[1] = 0;
          numArray3[1] = 32;
          numArray4[1] = 8;
          numArray1[2] = 48;
          numArray2[2] = 0;
          numArray3[2] = 16;
          numArray4[2] = 24;
          numArray1[3] = 48;
          numArray2[3] = 24;
          numArray3[3] = 16;
          numArray4[3] = 24;
          numArray1[4] = 16;
          numArray2[4] = 40;
          numArray3[4] = 32;
          numArray4[4] = 8;
          numArray1[5] = 0;
          numArray2[5] = 24;
          numArray3[5] = 16;
          numArray4[5] = 24;
          numArray1[6] = 0;
          numArray2[6] = 0;
          numArray3[6] = 16;
          numArray4[6] = 24;
          break;
        case 1:
          numArray1[0] = 32;
          numArray2[0] = 16;
          numArray3[0] = 64;
          numArray4[0] = 64;
          numArray1[1] = 32;
          numArray2[1] = 0;
          numArray3[1] = 64;
          numArray4[1] = 16;
          numArray1[2] = 96;
          numArray2[2] = 0;
          numArray3[2] = 32;
          numArray4[2] = 48;
          numArray1[3] = 96;
          numArray2[3] = 48;
          numArray3[3] = 32;
          numArray4[3] = 48;
          numArray1[4] = 32;
          numArray2[4] = 80;
          numArray3[4] = 64;
          numArray4[4] = 16;
          numArray1[5] = 0;
          numArray2[5] = 48;
          numArray3[5] = 32;
          numArray4[5] = 48;
          numArray1[6] = 0;
          numArray2[6] = 0;
          numArray3[6] = 32;
          numArray4[6] = 48;
          break;
      }
      float[] numArray5 = new float[10];
      float[] numArray6 = new float[10];
      float[] numArray7 = new float[10];
      float[] numArray8 = new float[10];
      int index1 = 0;
      do
      {
        if (flag2)
        {
          numArray5[index1] = 0.0f;
          numArray6[index1] = 0.0f;
          numArray7[index1] = 0.0f;
          numArray8[index1] = 0.0f;
        }
        else
        {
          numArray5[index1] = 1f;
          numArray6[index1] = 1f;
          numArray7[index1] = 1f;
          numArray8[index1] = 0.25f;
        }
        ++index1;
      }
      while (index1 <= 9);
      float[] numArray9 = new float[10];
      float[] numArray10 = new float[10];
      float[] numArray11 = new float[10];
      int[] numArray12 = new int[10];
      int num1 = 0;
      if (flag2)
      {
        numArray12[0] = 90;
        numArray12[1] = 80;
        numArray12[2] = 70;
        numArray12[3] = 60;
        numArray12[4] = 50;
        numArray12[5] = 40;
        numArray12[6] = 30;
        numArray12[7] = 20;
        numArray12[8] = 10;
        numArray12[9] = 0;
      }
      else
      {
        numArray12[0] = 60;
        numArray12[1] = 50;
        numArray12[2] = 40;
        numArray12[3] = 32;
        numArray12[4] = 25;
        numArray12[5] = 19;
        numArray12[6] = 13;
        numArray12[7] = 7;
        numArray12[8] = 0;
        numArray12[9] = 0;
      }
      int num2 = 0;
      int num3 = 9;
      int index2 = -1;
      if ((double) this.game.Data.RuleVar[415] > 0.0 & !flag2)
      {
        index2 = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[415]));
        if (index2 == -1)
          return;
      }
      if ((double) this.game.Data.RuleVar[416] > 0.0 & flag2)
      {
        index2 = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[416]));
        if (index2 == -1)
          return;
      }
      if (index2 > -1)
      {
        int length = this.game.Data.StringListObj[index2].Length;
        for (int index3 = 0; index3 <= length; ++index3)
        {
          int index4 = index3;
          if (flag2)
            index4 = 9 - index3;
          numArray9[index4] = (float) (Conversion.Val(this.game.Data.StringListObj[index2].Data[index3, 0]) / (double) byte.MaxValue);
          numArray10[index4] = (float) (Conversion.Val(this.game.Data.StringListObj[index2].Data[index3, 1]) / (double) byte.MaxValue);
          numArray11[index4] = (float) (Conversion.Val(this.game.Data.StringListObj[index2].Data[index3, 2]) / (double) byte.MaxValue);
          numArray12[index4] = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[index2].Data[index3, 3]));
          numArray5[index4] = (float) (Conversion.Val(this.game.Data.StringListObj[index2].Data[index3, 4]) / (double) byte.MaxValue);
          numArray6[index4] = (float) (Conversion.Val(this.game.Data.StringListObj[index2].Data[index3, 5]) / (double) byte.MaxValue);
          numArray7[index4] = (float) (Conversion.Val(this.game.Data.StringListObj[index2].Data[index3, 6]) / (double) byte.MaxValue);
          numArray8[index4] = (float) (Conversion.Val(this.game.Data.StringListObj[index2].Data[index3, 7]) / (double) byte.MaxValue);
        }
      }
      int width;
      int height;
      switch (Zoom)
      {
        case -1:
          width = 32;
          height = 24;
          break;
        case 0:
          width = 64;
          height = 48;
          break;
        default:
          width = 128;
          height = 96;
          break;
      }
      if (!(hexHeightMapData.cHeight >= num2 & hexHeightMapData.cHeight <= num3))
        return;
      int num4 = numArray12[hexHeightMapData.cHeight];
      if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType].IsSea & forInteriorSea)
        num4 = numArray12[0];
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (num4 > 0 & num4 < (int) byte.MaxValue)
      {
        ref Graphics local1 = ref useg;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.WHITEHEX, Zoom);
        ref Bitmap local2 = ref bitmap;
        rectangle1 = new Rectangle(0, 0, width, height);
        Rectangle srcrect = rectangle1;
        rectangle2 = new Rectangle(tx, ty, width, height);
        Rectangle destrect = rectangle2;
        double r = (double) numArray9[hexHeightMapData.cHeight];
        double g = (double) numArray10[hexHeightMapData.cHeight];
        double b = (double) numArray11[hexHeightMapData.cHeight];
        double a = (double) ((float) num4 / (float) byte.MaxValue);
        ref Bitmap local3 = ref gBitmap;
        DrawMod.DrawSimplePart2ColouredNewFast(ref local1, ref local2, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local3);
        num1 = num4;
      }
      if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType].IsSea && forInteriorSea)
        return;
      HexHeightMapData[] hexHeightMapDataArray = new HexHeightMapData[7];
      int index5 = 1;
      do
      {
        hexHeightMapDataArray[index5] = new HexHeightMapData(ref this.game, hexHeightMapData.neighbourCoord[index5].x, hexHeightMapData.neighbourCoord[index5].y, hexHeightMapData.neighbourCoord[index5].map, forInteriorSea);
        ++index5;
      }
      while (index5 <= 6);
      int[] numArray13 = new int[7];
      bool flag3;
      if (!flag2 && hexHeightMapData.cHeight > 0)
      {
        int index6 = 1;
        do
        {
          if (hexHeightMapData.neighbourCoord[index6].onmap & hexHeightMapDataArray[index6].cHeight > 0)
          {
            int num5 = index6 + 3;
            if (num5 > 6)
              num5 -= 6;
            int index7 = num5 + 1;
            if (index7 > 6)
              index7 = 1;
            int index8 = index7 + 1;
            if (index8 > 6)
              index8 = 1;
            int index9 = index6 - 1;
            if (index9 < 1)
              index9 = 6;
            int num6 = index9 + 3;
            int index10 = index6 + 1;
            if (index10 > 6)
              index10 = 1;
            if (num6 > 6)
            {
              int num7 = num6 - 6;
            }
            int index11 = index9 - 1;
            if (index11 < 1)
              index11 = 6;
            int index12 = this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[index6 - 1];
            if (index12 > -1 && this.game.Data.RiverTypeObj[index12].GetRiverHeight(this.game, cx, cy, index6 - 1) < 1)
              index12 = -1;
            int index13 = this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[index9 - 1];
            if (index13 > -1 && this.game.Data.RiverTypeObj[index13].GetRiverHeight(this.game, cx, cy, index9 - 1) < 1)
              index13 = -1;
            if (index12 == -1 & index13 == -1)
            {
              if (hexHeightMapDataArray[index6].riverHeightApplied[index7] == 1 && hexHeightMapData.riverHeightApplied[index6] == 0 && hexHeightMapData.riverHeightApplied[index9] == 0)
              {
                bool flag4 = true;
                if (hexHeightMapData.lineHeightLevel[1] <= hexHeightMapDataArray[index9].lineHeightLevel[1] & hexHeightMapDataArray[index9].lineHeightLevel[1] >= 1)
                  flag4 = false;
                if (hexHeightMapData.lineHeightLevel[1] <= hexHeightMapDataArray[index6].lineHeightLevel[1] & hexHeightMapDataArray[index6].lineHeightLevel[1] >= 1)
                  flag4 = false;
                if (!hexHeightMapData.neighbourCoord[index6].onmap)
                  flag4 = false;
                if (!hexHeightMapData.neighbourCoord[index9].onmap)
                  flag4 = false;
                if (!hexHeightMapData.neighbourCoord[index10].onmap)
                  flag4 = false;
                if (flag4)
                {
                  flag3 = true;
                  numArray13[index6] = 1;
                }
              }
            }
            else
            {
              int index14 = this.game.Data.MapObj[0].HexObj[hexHeightMapData.neighbourCoord[index6].x, hexHeightMapData.neighbourCoord[index6].y].RiverType[index7 - 1];
              if (index14 > -1 && this.game.Data.RiverTypeObj[index14].GetRiverHeight(this.game, hexHeightMapData.neighbourCoord[index6].x, hexHeightMapData.neighbourCoord[index6].y, index7 - 1) < 1)
                index14 = -1;
              if (index14 > -1)
              {
                bool flag5 = false;
                if (Math.Max(hexHeightMapDataArray[index9].cHeight, hexHeightMapDataArray[index6].cHeight) == hexHeightMapData.cHeight)
                  flag5 = true;
                if (hexHeightMapDataArray[index10].maxLines == 3)
                  flag5 = true;
                if (hexHeightMapDataArray[index11].maxLines == 3)
                  flag5 = true;
                if (Math.Abs(hexHeightMapDataArray[index9].cHeight - hexHeightMapDataArray[index6].cHeight) != 1)
                  flag5 = false;
                if (hexHeightMapData.cHeight > hexHeightMapDataArray[index6].cHeight + 1 & hexHeightMapData.cHeight <= hexHeightMapDataArray[index9].cHeight)
                  flag5 = true;
                if (index13 > -1 & hexHeightMapData.riverHeightApplied[index9] < 1 | index12 > -1 & hexHeightMapData.riverHeightApplied[index6] < 1 && hexHeightMapDataArray[index6].riverHeightApplied[index7] > 0 | hexHeightMapDataArray[index6].riverHeightApplied[index8] > 0)
                  flag5 = true;
                if (hexHeightMapDataArray[index9].cHeight == 0 | hexHeightMapDataArray[index6].cHeight == 0)
                  flag5 = false;
                if (index13 > -1 && hexHeightMapDataArray[index11].cHeight <= hexHeightMapDataArray[index9].cHeight & hexHeightMapDataArray[index11].cHeight < hexHeightMapData.cHeight)
                  flag5 = false;
                if (hexHeightMapDataArray[index6].cHeight - hexHeightMapData.cHeight == 3)
                  flag5 = false;
                if (hexHeightMapDataArray[index9].cHeight - hexHeightMapData.cHeight == 3)
                  flag5 = false;
                if (hexHeightMapData.maxLines > 0 & hexHeightMapData.lineHeightLevel[1] == 0)
                  flag5 = false;
                if (hexHeightMapData.lineHeightLevel[1] == hexHeightMapDataArray[index9].lineHeightLevel[1] & hexHeightMapDataArray[index9].lineHeightLevel[1] >= 1 && this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[index9 - 1] == -1)
                  flag5 = false;
                if (hexHeightMapData.lineHeightLevel[1] == hexHeightMapDataArray[index6].lineHeightLevel[1] & hexHeightMapDataArray[index6].lineHeightLevel[1] >= 1 && this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[index9 - 1] == -1)
                  flag5 = false;
                if (hexHeightMapData.lineHeightLevel[1] == hexHeightMapDataArray[index9].lineHeightLevel[2] & hexHeightMapDataArray[index9].lineHeightLevel[2] >= 1 && this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[index9 - 1] == -1 & this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[index6 - 1] == -1)
                  flag5 = false;
                if (hexHeightMapData.lineHeightLevel[1] == hexHeightMapDataArray[index6].lineHeightLevel[2] & hexHeightMapDataArray[index6].lineHeightLevel[2] >= 1 && this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[index9 - 1] == -1 & this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[index6 - 1] == -1)
                  flag5 = false;
                if (hexHeightMapData.maxLines == 3)
                  flag5 = false;
                if (!hexHeightMapData.neighbourCoord[index6].onmap)
                  flag5 = false;
                if (flag5)
                {
                  flag3 = true;
                  numArray13[index6] = 1;
                }
              }
            }
          }
          ++index6;
        }
        while (index6 <= 6);
      }
      if (flag1 & !flag2 & !(this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType].IsSea & this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType].Interior))
      {
        int index15 = -1;
        if ((double) this.game.Data.RuleVar[417] > 0.0)
          index15 = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[417]));
        if (index15 > -1)
        {
          int[] numArray14 = new int[7];
          int num8 = 0;
          bool[] flagArray = new bool[7];
          int num9 = 0;
          int index16 = 1;
          do
          {
            numArray14[index16] = 1;
            flagArray[index16] = false;
            if (hexHeightMapData.neighbourCoord[index16].onmap && this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType != 44)
            {
              if (hexHeightMapDataArray[index16].seaHex & hexHeightMapData.cHeight >= 0)
              {
                numArray14[index16] = 0;
                ++num8;
              }
              else
              {
                int num10 = index16 + 3;
                if (num10 > 6)
                  num10 -= 6;
                int index17 = num10 + 1;
                if (index17 > 6)
                  index17 = 1;
                if (hexHeightMapDataArray[index16].neighbourCoord[index17].onmap & hexHeightMapDataArray[index16].cHeight >= 0 && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[hexHeightMapDataArray[index16].neighbourCoord[index17].x, hexHeightMapDataArray[index16].neighbourCoord[index17].y].LandscapeType].IsSea)
                {
                  flagArray[index16] = true;
                  ++num9;
                }
                if (hexHeightMapDataArray[index16].neighbourCoord[index17].onmap & hexHeightMapDataArray[index16].seaHex & hexHeightMapData.cHeight >= 0 && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[hexHeightMapDataArray[index16].neighbourCoord[index17].x, hexHeightMapDataArray[index16].neighbourCoord[index17].y].LandscapeType].IsSea && this.game.Data.MapObj[0].HexObj[hexHeightMapDataArray[index16].neighbourCoord[index17].x, hexHeightMapDataArray[index16].neighbourCoord[index17].y].HeightLevel >= 0)
                {
                  flagArray[index16] = true;
                  ++num9;
                }
              }
            }
            ++index16;
          }
          while (index16 <= 6);
          if (num8 > 0 | num9 > 0)
          {
            float num11 = 0.9f;
            float num12 = 0.8f;
            float num13 = 0.7f;
            int num14 = 175;
            if (index15 > -1)
            {
              int length = this.game.Data.StringListObj[index15].Length;
              for (int index18 = 0; index18 <= length; ++index18)
              {
                int num15 = index18;
                if (flag2)
                  num15 = 9 - index18;
                num11 = (float) (Conversion.Val(this.game.Data.StringListObj[index15].Data[index18, 0]) / (double) byte.MaxValue);
                num12 = (float) (Conversion.Val(this.game.Data.StringListObj[index15].Data[index18, 1]) / (double) byte.MaxValue);
                num13 = (float) (Conversion.Val(this.game.Data.StringListObj[index15].Data[index18, 2]) / (double) byte.MaxValue);
                num14 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[index15].Data[index18, 3]));
              }
            }
            if (num8 > 0)
            {
              int index19 = 1;
              do
              {
                flagArray[index19] = false;
                ++index19;
              }
              while (index19 <= 6);
              int index20 = this.game.SPRITE64[numArray14[1], numArray14[2], numArray14[3], numArray14[4], numArray14[5], numArray14[6]];
              if (num14 > 0)
              {
                ref Graphics local4 = ref useg;
                Bitmap bitmap = BitmapStore.GetBitmap(this.game.HEIGHTMAP_BEACH, Zoom);
                ref Bitmap local5 = ref bitmap;
                rectangle2 = new Rectangle(this.game.SHEETX[index20] * width, this.game.SHEETY[index20] * height, width, height);
                Rectangle srcrect = rectangle2;
                rectangle1 = new Rectangle(tx, ty, width, height);
                Rectangle destrect = rectangle1;
                double r = (double) num11;
                double g = (double) num12;
                double b = (double) num13;
                double a = (double) ((float) num14 / (float) byte.MaxValue);
                DrawMod.DrawSimplePart2ColouredNew(ref local4, ref local5, srcrect, destrect, (float) r, (float) g, (float) b, (float) a);
              }
            }
            int index21 = 1;
            do
            {
              if (flagArray[index21])
              {
                int num16 = index21 - 1;
              }
              ++index21;
            }
            while (index21 <= 6);
          }
        }
      }
      Bitmap bitmap1;
      Bitmap bitmap2;
      for (int maxLines1 = hexHeightMapData.maxLines; maxLines1 >= 1; maxLines1 += -1)
      {
        if (hexHeightMapData.lineHeightLevel[maxLines1] > -999)
        {
          int[] numArray15 = new int[7];
          bool flag6 = false;
          int[] numArray16 = new int[7];
          int[] numArray17 = new int[7];
          int[] numArray18 = new int[7];
          bool[] flagArray = new bool[7];
          int index22 = 1;
          do
          {
            if (hexHeightMapData.neighbourHeight[index22] <= hexHeightMapData.lineHeightLevel[maxLines1])
            {
              numArray15[index22] = 0;
              flag6 = true;
              numArray16[index22] = 0;
            }
            else
            {
              numArray15[index22] = 1;
              numArray16[index22] = 1;
            }
            ++index22;
          }
          while (index22 <= 6);
          int index23 = 1;
          do
          {
            if (numArray15[index23] == 1)
            {
              int index24 = index23 - 1;
              int index25 = index23 + 1;
              if (index24 < 1)
                index24 = 6;
              if (index25 > 6)
                index25 = 1;
              if (numArray15[index24] == 0 & numArray15[index25] == 0 && hexHeightMapDataArray[index23].maxLines > 0 && hexHeightMapDataArray[index23].lineHeightLevel[maxLines1] != hexHeightMapData.lineHeightLevel[maxLines1])
              {
                numArray15[index23] = 0;
                numArray16[index23] = 0;
                flagArray[index23] = true;
              }
              if (((numArray15[index23] == 1 ? 1 : 0) & 1) != 0)
              {
                int num17 = index23 + 3;
                if (num17 > 6)
                  num17 -= 6;
                int index26 = num17 - 1;
                if (index26 < 1)
                  index26 = 6;
                int index27 = num17 + 1;
                if (index27 > 6)
                  index27 = 1;
                if ((numArray15[index25] == 0 | hexHeightMapDataArray[index23].HexRiverHeight[index26] > 0) & (numArray15[index24] == 0 | hexHeightMapDataArray[index23].HexRiverHeight[index27] > 0) && hexHeightMapDataArray[index23].maxLines > 0 & (hexHeightMapDataArray[index23].HexRiverHeight[index26] > 0 | hexHeightMapDataArray[index23].HexRiverHeight[index27] > 0) && hexHeightMapDataArray[index23].cHeight - 2 < hexHeightMapData.lineHeightLevel[maxLines1] && !(maxLines1 == 1 & hexHeightMapDataArray[index23].lineHeightLevel[maxLines1] == hexHeightMapData.lineHeightLevel[maxLines1]))
                {
                  if (hexHeightMapData.lineHeightLevel[maxLines1] == hexHeightMapDataArray[index25].lineHeightLevel[maxLines1])
                  {
                    numArray15[index23] = 0;
                    flagArray[index23] = true;
                    numArray16[index23] = 0;
                  }
                  if (hexHeightMapData.lineHeightLevel[maxLines1] == hexHeightMapDataArray[index24].lineHeightLevel[maxLines1])
                  {
                    numArray15[index23] = 0;
                    flagArray[index23] = true;
                    numArray16[index23] = 0;
                  }
                }
              }
            }
            ++index23;
          }
          while (index23 <= 6);
          int index28 = 1;
          do
          {
            numArray18[index28] = 0;
            if (numArray16[index28] == 1)
            {
              int index29 = index28 - 1;
              int index30 = index28 + 1;
              if (index29 < 1)
                index29 = 6;
              if (index30 > 6)
                index30 = 1;
              if (flag2)
              {
                int num18 = hexHeightMapDataArray[index29].cHeight;
                int num19 = hexHeightMapDataArray[index30].cHeight;
                if (!hexHeightMapDataArray[index29].seaHex)
                  num18 = 9;
                if (!hexHeightMapDataArray[index30].seaHex)
                  num19 = 9;
                if (num18 > num19)
                  numArray18[index28] = 1;
                if (num18 < num19)
                  numArray18[index28] = 2;
              }
              else
              {
                if (hexHeightMapDataArray[index29].cHeight > hexHeightMapDataArray[index30].cHeight)
                  numArray18[index28] = 1;
                if (hexHeightMapDataArray[index29].cHeight < hexHeightMapDataArray[index30].cHeight)
                  numArray18[index28] = 2;
              }
              if (!flag2)
              {
                int index31 = this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[index29 - 1];
                if (index31 > -1 && this.game.Data.RiverTypeObj[index31].GetRiverHeight(this.game, cx, cy, index29 - 1) < 1)
                  index31 = -1;
                int index32 = this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[index30 - 1];
                if (index32 > -1 && this.game.Data.RiverTypeObj[index32].GetRiverHeight(this.game, cx, cy, index30 - 1) < 1)
                  index32 = -1;
                if (index31 > -1)
                {
                  int num20 = 1;
                  if (hexHeightMapData.lineHeightLevel[maxLines1] == hexHeightMapData.cHeight - num20)
                    numArray18[index28] = 2;
                }
                if (index32 > -1)
                {
                  int num21 = 1;
                  if (hexHeightMapData.lineHeightLevel[maxLines1] == hexHeightMapData.cHeight - num21)
                    numArray18[index28] = 1;
                }
              }
              if (numArray15[index29] > 0 & numArray15[index30] > 0)
                numArray16[index28] = 0;
              if (!hexHeightMapData.neighbourCoord[index28].onmap)
                numArray16[index28] = 0;
            }
            ++index28;
          }
          while (index28 <= 6);
          bool flag7 = false;
          int index33 = 1;
          do
          {
            if (numArray16[index33] == 1)
            {
              int num22 = 999;
              int maxLines2 = hexHeightMapDataArray[index33].maxLines;
              for (int index34 = 1; index34 <= maxLines2; ++index34)
              {
                if (hexHeightMapDataArray[index33].lineHeightLevel[index34] == hexHeightMapData.lineHeightLevel[maxLines1])
                {
                  num22 = index34;
                  break;
                }
              }
              if (num22 < 999 & num22 != maxLines1)
              {
                numArray16[index33] = 3;
                numArray17[index33] = num22;
                flag7 = true;
              }
              else
                numArray16[index33] = 2;
            }
            ++index33;
          }
          while (index33 <= 6);
          if (flag6)
          {
            if (!flag7)
            {
              int index35 = this.game.SPRITE64[numArray15[1], numArray15[2], numArray15[3], numArray15[4], numArray15[5], numArray15[6]];
              int num23 = numArray12[hexHeightMapData.lineHeightLevel[maxLines1]];
              int index36 = hexHeightMapData.lineHeightLevel[maxLines1];
              if (num23 > 0 & num23 < (int) byte.MaxValue)
              {
                int num24 = (int) Math.Round((double) ((int) byte.MaxValue * (num23 - num1)) / (double) ((int) byte.MaxValue - num1));
                if (maxLines1 == 1)
                {
                  ref Graphics local6 = ref useg;
                  bitmap1 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_SHADOW1, Zoom);
                  ref Bitmap local7 = ref bitmap1;
                  rectangle2 = new Rectangle(this.game.SHEETX[index35] * width, this.game.SHEETY[index35] * height, width, height);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, width, height);
                  Rectangle destrect = rectangle1;
                  double r = (double) numArray9[index36];
                  double g = (double) numArray10[index36];
                  double b = (double) numArray11[index36];
                  double a = (double) ((float) num24 / (float) byte.MaxValue);
                  bitmap2 = (Bitmap) null;
                  ref Bitmap local8 = ref bitmap2;
                  DrawMod.DrawSimplePart2ColouredNewFast(ref local6, ref local7, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local8);
                }
                if (maxLines1 == 2)
                {
                  ref Graphics local9 = ref useg;
                  bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_SHADOW2, Zoom);
                  ref Bitmap local10 = ref bitmap2;
                  rectangle2 = new Rectangle(this.game.SHEETX[index35] * width, this.game.SHEETY[index35] * height, width, height);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, width, height);
                  Rectangle destrect = rectangle1;
                  double r = (double) numArray9[index36];
                  double g = (double) numArray10[index36];
                  double b = (double) numArray11[index36];
                  double a = (double) ((float) num24 / (float) byte.MaxValue);
                  bitmap1 = (Bitmap) null;
                  ref Bitmap local11 = ref bitmap1;
                  DrawMod.DrawSimplePart2ColouredNewFast(ref local9, ref local10, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local11);
                }
                if (maxLines1 == 3)
                {
                  ref Graphics local12 = ref useg;
                  bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_SHADOW3, Zoom);
                  ref Bitmap local13 = ref bitmap2;
                  rectangle2 = new Rectangle(this.game.SHEETX[index35] * width, this.game.SHEETY[index35] * height, width, height);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, width, height);
                  Rectangle destrect = rectangle1;
                  double r = (double) numArray9[index36];
                  double g = (double) numArray10[index36];
                  double b = (double) numArray11[index36];
                  double a = (double) ((float) num24 / (float) byte.MaxValue);
                  bitmap1 = (Bitmap) null;
                  ref Bitmap local14 = ref bitmap1;
                  DrawMod.DrawSimplePart2ColouredNewFast(ref local12, ref local13, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local14);
                }
                num1 = num23;
              }
              if ((double) numArray8[index36] == 1.0)
              {
                if (maxLines1 == 1)
                {
                  ref Graphics local15 = ref useg;
                  bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_LINE1, Zoom);
                  ref Bitmap local16 = ref bitmap2;
                  rectangle2 = new Rectangle(this.game.SHEETX[index35] * width, this.game.SHEETY[index35] * height, width, height);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, width, height);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect, destrect);
                }
                if (maxLines1 == 2)
                {
                  ref Graphics local17 = ref useg;
                  bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_LINE2, Zoom);
                  ref Bitmap local18 = ref bitmap2;
                  rectangle2 = new Rectangle(this.game.SHEETX[index35] * width, this.game.SHEETY[index35] * height, width, height);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, width, height);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect, destrect);
                }
                if (maxLines1 == 3)
                {
                  ref Graphics local19 = ref useg;
                  bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_LINE3, Zoom);
                  ref Bitmap local20 = ref bitmap2;
                  rectangle2 = new Rectangle(this.game.SHEETX[index35] * width, this.game.SHEETY[index35] * height, width, height);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, width, height);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local19, ref local20, srcrect, destrect);
                }
              }
              else
              {
                if (maxLines1 == 1)
                {
                  ref Graphics local21 = ref useg;
                  bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_LINE1, Zoom);
                  ref Bitmap local22 = ref bitmap2;
                  rectangle2 = new Rectangle(this.game.SHEETX[index35] * width, this.game.SHEETY[index35] * height, width, height);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, width, height);
                  Rectangle destrect = rectangle1;
                  double r = (double) numArray5[index36];
                  double g = (double) numArray6[index36];
                  double b = (double) numArray7[index36];
                  double a = (double) numArray8[index36];
                  bitmap1 = (Bitmap) null;
                  ref Bitmap local23 = ref bitmap1;
                  DrawMod.DrawSimplePart2ColouredNewFast(ref local21, ref local22, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local23);
                }
                if (maxLines1 == 2)
                {
                  ref Graphics local24 = ref useg;
                  bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_LINE2, Zoom);
                  ref Bitmap local25 = ref bitmap2;
                  rectangle2 = new Rectangle(this.game.SHEETX[index35] * width, this.game.SHEETY[index35] * height, width, height);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, width, height);
                  Rectangle destrect = rectangle1;
                  double r = (double) numArray5[index36];
                  double g = (double) numArray6[index36];
                  double b = (double) numArray7[index36];
                  double a = (double) numArray8[index36];
                  bitmap1 = (Bitmap) null;
                  ref Bitmap local26 = ref bitmap1;
                  DrawMod.DrawSimplePart2ColouredNewFast(ref local24, ref local25, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local26);
                }
                if (maxLines1 == 3)
                {
                  ref Graphics local27 = ref useg;
                  bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_LINE3, Zoom);
                  ref Bitmap local28 = ref bitmap2;
                  rectangle2 = new Rectangle(this.game.SHEETX[index35] * width, this.game.SHEETY[index35] * height, width, height);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, width, height);
                  Rectangle destrect = rectangle1;
                  double r = (double) numArray5[index36];
                  double g = (double) numArray6[index36];
                  double b = (double) numArray7[index36];
                  double a = (double) numArray8[index36];
                  bitmap1 = (Bitmap) null;
                  ref Bitmap local29 = ref bitmap1;
                  DrawMod.DrawSimplePart2ColouredNewFast(ref local27, ref local28, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local29);
                }
              }
            }
            else if (flag7)
            {
              int num25 = num1;
              int index37 = 0;
              do
              {
                int num26;
                int num27;
                int num28;
                if (index37 >= 1 & index37 <= 3 & numArray16[index37] == 3 & maxLines1 > 1)
                {
                  num26 = 0;
                  num27 = 0;
                  num28 = 0;
                  int num29 = (index37 - 1) * 2;
                  int num30 = 0;
                  if (numArray18[index37] == 1)
                    ++num29;
                  if (numArray17[index37] == 1 & maxLines1 == 2)
                    num30 = 0;
                  if (numArray17[index37] == 3 & maxLines1 == 2)
                    num30 = 1;
                  if (numArray17[index37] == 1 & maxLines1 == 3)
                    num30 = 2;
                  if (numArray17[index37] == 2 & maxLines1 == 3)
                    num30 = 3;
                  int num31 = numArray12[hexHeightMapData.lineHeightLevel[maxLines1]];
                  int index38 = hexHeightMapData.lineHeightLevel[maxLines1];
                  if (num31 > 0 & num31 < (int) byte.MaxValue)
                  {
                    int num32 = (int) Math.Round((double) ((int) byte.MaxValue * (num31 - num1)) / (double) ((int) byte.MaxValue - num1));
                    ref Graphics local30 = ref useg;
                    bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_TRANS_SHADOW, Zoom);
                    ref Bitmap local31 = ref bitmap2;
                    rectangle2 = new Rectangle(num30 * width + numArray1[index37], num29 * height + numArray2[index37], numArray3[index37], numArray4[index37]);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx + numArray1[index37], ty + numArray2[index37], numArray3[index37], numArray4[index37]);
                    Rectangle destrect = rectangle1;
                    double r = (double) numArray9[index38];
                    double g = (double) numArray10[index38];
                    double b = (double) numArray11[index38];
                    double a = (double) ((float) num32 / (float) byte.MaxValue);
                    bitmap1 = (Bitmap) null;
                    ref Bitmap local32 = ref bitmap1;
                    DrawMod.DrawSimplePart2ColouredNewFast(ref local30, ref local31, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local32);
                    if (num31 > num25)
                      num25 = num31;
                  }
                  if ((double) numArray8[index38] == 1.0)
                  {
                    ref Graphics local33 = ref useg;
                    bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_TRANS_LINE, Zoom);
                    ref Bitmap local34 = ref bitmap2;
                    rectangle2 = new Rectangle(num30 * width + numArray1[index37], num29 * height + numArray2[index37], numArray3[index37], numArray4[index37]);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx + numArray1[index37], ty + numArray2[index37], numArray3[index37], numArray4[index37]);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local33, ref local34, srcrect, destrect);
                  }
                  else
                  {
                    ref Graphics local35 = ref useg;
                    bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_TRANS_LINE, Zoom);
                    ref Bitmap local36 = ref bitmap2;
                    rectangle2 = new Rectangle(num30 * width + numArray1[index37], num29 * height + numArray2[index37], numArray3[index37], numArray4[index37]);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx + numArray1[index37], ty + numArray2[index37], numArray3[index37], numArray4[index37]);
                    Rectangle destrect = rectangle1;
                    double r = (double) numArray5[index38];
                    double g = (double) numArray6[index38];
                    double b = (double) numArray7[index38];
                    double a = (double) numArray8[index38];
                    bitmap1 = (Bitmap) null;
                    ref Bitmap local37 = ref bitmap1;
                    DrawMod.DrawSimplePart2ColouredNewFast(ref local35, ref local36, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local37);
                  }
                }
                else if (index37 >= 4 & index37 <= 6 & numArray16[index37] == 3 & numArray17[index37] == 1)
                {
                  num26 = 0;
                  num27 = 0;
                  num28 = 0;
                  int num33 = (index37 - 1) * 2;
                  int num34 = 0;
                  if (index37 == 5)
                    num33 += 2;
                  if (index37 == 6)
                    num33 -= 2;
                  if (numArray18[index37] == 2)
                    ++num33;
                  if (index37 == 4)
                  {
                    if (numArray17[index37] == 1 & maxLines1 == 2)
                      num34 = 0;
                    if (numArray17[index37] == 3 & maxLines1 == 2)
                      num34 = 1;
                    if (numArray17[index37] == 1 & maxLines1 == 3)
                      num34 = 2;
                    if (numArray17[index37] == 2 & maxLines1 == 3)
                      num34 = 3;
                  }
                  else if (index37 == 5 | index37 == 6)
                  {
                    if (numArray17[index37] == 1 & maxLines1 == 2)
                      num34 = 3;
                    if (numArray17[index37] == 3 & maxLines1 == 2)
                      num34 = 2;
                    if (numArray17[index37] == 1 & maxLines1 == 3)
                      num34 = 1;
                    if (numArray17[index37] == 2 & maxLines1 == 3)
                      num34 = 0;
                  }
                  int num35 = numArray12[hexHeightMapData.lineHeightLevel[maxLines1]];
                  int index39 = hexHeightMapData.lineHeightLevel[maxLines1];
                  if (num35 > 0 & num35 < (int) byte.MaxValue)
                  {
                    int num36 = (int) Math.Round((double) ((int) byte.MaxValue * (num35 - num1)) / (double) ((int) byte.MaxValue - num1));
                    ref Graphics local38 = ref useg;
                    bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_TRANS_SHADOW, Zoom);
                    ref Bitmap local39 = ref bitmap2;
                    rectangle2 = new Rectangle(num34 * width + numArray1[index37], num33 * height + numArray2[index37], numArray3[index37], numArray4[index37]);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx + numArray1[index37], ty + numArray2[index37], numArray3[index37], numArray4[index37]);
                    Rectangle destrect = rectangle1;
                    double r = (double) numArray9[index39];
                    double g = (double) numArray10[index39];
                    double b = (double) numArray11[index39];
                    double a = (double) ((float) num36 / (float) byte.MaxValue);
                    bitmap1 = (Bitmap) null;
                    ref Bitmap local40 = ref bitmap1;
                    DrawMod.DrawSimplePart2ColouredNewFast(ref local38, ref local39, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local40);
                    if (num35 > num25)
                      num25 = num35;
                  }
                  if ((double) numArray8[index39] == 1.0)
                  {
                    ref Graphics local41 = ref useg;
                    bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_TRANS_LINE, Zoom);
                    ref Bitmap local42 = ref bitmap2;
                    rectangle2 = new Rectangle(num34 * width + numArray1[index37], num33 * height + numArray2[index37], numArray3[index37], numArray4[index37]);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx + numArray1[index37], ty + numArray2[index37], numArray3[index37], numArray4[index37]);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local41, ref local42, srcrect, destrect);
                  }
                  else
                  {
                    ref Graphics local43 = ref useg;
                    bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_TRANS_LINE, Zoom);
                    ref Bitmap local44 = ref bitmap2;
                    rectangle2 = new Rectangle(num34 * width + numArray1[index37], num33 * height + numArray2[index37], numArray3[index37], numArray4[index37]);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx + numArray1[index37], ty + numArray2[index37], numArray3[index37], numArray4[index37]);
                    Rectangle destrect = rectangle1;
                    double r = (double) numArray5[index39];
                    double g = (double) numArray6[index39];
                    double b = (double) numArray7[index39];
                    double a = (double) numArray8[index39];
                    bitmap1 = (Bitmap) null;
                    ref Bitmap local45 = ref bitmap1;
                    DrawMod.DrawSimplePart2ColouredNewFast(ref local43, ref local44, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local45);
                  }
                }
                else
                {
                  int index40 = this.game.SPRITE64[numArray15[1], numArray15[2], numArray15[3], numArray15[4], numArray15[5], numArray15[6]];
                  int num37 = numArray12[hexHeightMapData.lineHeightLevel[maxLines1]];
                  int index41 = hexHeightMapData.lineHeightLevel[maxLines1];
                  if (num37 > 0 & num37 < (int) byte.MaxValue)
                  {
                    int num38 = (int) Math.Round((double) ((int) byte.MaxValue * (num37 - num1)) / (double) ((int) byte.MaxValue - num1));
                    if (maxLines1 == 1)
                    {
                      ref Graphics local46 = ref useg;
                      bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_SHADOW1, Zoom);
                      ref Bitmap local47 = ref bitmap2;
                      rectangle2 = new Rectangle(this.game.SHEETX[index40] * width + numArray1[index37], this.game.SHEETY[index40] * height + numArray2[index37], numArray3[index37], numArray4[index37]);
                      Rectangle srcrect = rectangle2;
                      rectangle1 = new Rectangle(tx + numArray1[index37], ty + numArray2[index37], numArray3[index37], numArray4[index37]);
                      Rectangle destrect = rectangle1;
                      double r = (double) numArray9[index41];
                      double g = (double) numArray10[index41];
                      double b = (double) numArray11[index41];
                      double a = (double) ((float) num38 / (float) byte.MaxValue);
                      bitmap1 = (Bitmap) null;
                      ref Bitmap local48 = ref bitmap1;
                      DrawMod.DrawSimplePart2ColouredNewFast(ref local46, ref local47, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local48);
                    }
                    if (maxLines1 == 2)
                    {
                      ref Graphics local49 = ref useg;
                      bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_SHADOW2, Zoom);
                      ref Bitmap local50 = ref bitmap2;
                      rectangle2 = new Rectangle(this.game.SHEETX[index40] * width + numArray1[index37], this.game.SHEETY[index40] * height + numArray2[index37], numArray3[index37], numArray4[index37]);
                      Rectangle srcrect = rectangle2;
                      rectangle1 = new Rectangle(tx + numArray1[index37], ty + numArray2[index37], numArray3[index37], numArray4[index37]);
                      Rectangle destrect = rectangle1;
                      double r = (double) numArray9[index41];
                      double g = (double) numArray10[index41];
                      double b = (double) numArray11[index41];
                      double a = (double) ((float) num38 / (float) byte.MaxValue);
                      bitmap1 = (Bitmap) null;
                      ref Bitmap local51 = ref bitmap1;
                      DrawMod.DrawSimplePart2ColouredNewFast(ref local49, ref local50, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local51);
                    }
                    if (maxLines1 == 3)
                    {
                      ref Graphics local52 = ref useg;
                      bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_SHADOW3, Zoom);
                      ref Bitmap local53 = ref bitmap2;
                      rectangle2 = new Rectangle(this.game.SHEETX[index40] * width + numArray1[index37], this.game.SHEETY[index40] * height + numArray2[index37], numArray3[index37], numArray4[index37]);
                      Rectangle srcrect = rectangle2;
                      rectangle1 = new Rectangle(tx + numArray1[index37], ty + numArray2[index37], numArray3[index37], numArray4[index37]);
                      Rectangle destrect = rectangle1;
                      double r = (double) numArray9[index41];
                      double g = (double) numArray10[index41];
                      double b = (double) numArray11[index41];
                      double a = (double) ((float) num38 / (float) byte.MaxValue);
                      bitmap1 = (Bitmap) null;
                      ref Bitmap local54 = ref bitmap1;
                      DrawMod.DrawSimplePart2ColouredNewFast(ref local52, ref local53, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local54);
                    }
                    if (num37 > num25)
                      num25 = num37;
                  }
                  if ((double) numArray8[index41] == 1.0)
                  {
                    if (maxLines1 == 1)
                    {
                      ref Graphics local55 = ref useg;
                      bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_LINE1, Zoom);
                      ref Bitmap local56 = ref bitmap2;
                      rectangle2 = new Rectangle(this.game.SHEETX[index40] * width + numArray1[index37], this.game.SHEETY[index40] * height + numArray2[index37], numArray3[index37], numArray4[index37]);
                      Rectangle srcrect = rectangle2;
                      rectangle1 = new Rectangle(tx + numArray1[index37], ty + numArray2[index37], numArray3[index37], numArray4[index37]);
                      Rectangle destrect = rectangle1;
                      DrawMod.DrawSimplePart2(ref local55, ref local56, srcrect, destrect);
                    }
                    if (maxLines1 == 2)
                    {
                      ref Graphics local57 = ref useg;
                      bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_LINE2, Zoom);
                      ref Bitmap local58 = ref bitmap2;
                      rectangle2 = new Rectangle(this.game.SHEETX[index40] * width + numArray1[index37], this.game.SHEETY[index40] * height + numArray2[index37], numArray3[index37], numArray4[index37]);
                      Rectangle srcrect = rectangle2;
                      rectangle1 = new Rectangle(tx + numArray1[index37], ty + numArray2[index37], numArray3[index37], numArray4[index37]);
                      Rectangle destrect = rectangle1;
                      DrawMod.DrawSimplePart2(ref local57, ref local58, srcrect, destrect);
                    }
                    if (maxLines1 == 3)
                    {
                      ref Graphics local59 = ref useg;
                      bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_LINE3, Zoom);
                      ref Bitmap local60 = ref bitmap2;
                      rectangle2 = new Rectangle(this.game.SHEETX[index40] * width + numArray1[index37], this.game.SHEETY[index40] * height + numArray2[index37], numArray3[index37], numArray4[index37]);
                      Rectangle srcrect = rectangle2;
                      rectangle1 = new Rectangle(tx + numArray1[index37], ty + numArray2[index37], numArray3[index37], numArray4[index37]);
                      Rectangle destrect = rectangle1;
                      DrawMod.DrawSimplePart2(ref local59, ref local60, srcrect, destrect);
                    }
                  }
                  else
                  {
                    if (maxLines1 == 1)
                    {
                      ref Graphics local61 = ref useg;
                      bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_LINE1, Zoom);
                      ref Bitmap local62 = ref bitmap2;
                      rectangle2 = new Rectangle(this.game.SHEETX[index40] * width + numArray1[index37], this.game.SHEETY[index40] * height + numArray2[index37], numArray3[index37], numArray4[index37]);
                      Rectangle srcrect = rectangle2;
                      rectangle1 = new Rectangle(tx + numArray1[index37], ty + numArray2[index37], numArray3[index37], numArray4[index37]);
                      Rectangle destrect = rectangle1;
                      double r = (double) numArray5[index41];
                      double g = (double) numArray6[index41];
                      double b = (double) numArray7[index41];
                      double a = (double) numArray8[index41];
                      bitmap1 = (Bitmap) null;
                      ref Bitmap local63 = ref bitmap1;
                      DrawMod.DrawSimplePart2ColouredNewFast(ref local61, ref local62, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local63);
                    }
                    if (maxLines1 == 2)
                    {
                      ref Graphics local64 = ref useg;
                      bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_LINE2, Zoom);
                      ref Bitmap local65 = ref bitmap2;
                      rectangle2 = new Rectangle(this.game.SHEETX[index40] * width + numArray1[index37], this.game.SHEETY[index40] * height + numArray2[index37], numArray3[index37], numArray4[index37]);
                      Rectangle srcrect = rectangle2;
                      rectangle1 = new Rectangle(tx + numArray1[index37], ty + numArray2[index37], numArray3[index37], numArray4[index37]);
                      Rectangle destrect = rectangle1;
                      double r = (double) numArray5[index41];
                      double g = (double) numArray6[index41];
                      double b = (double) numArray7[index41];
                      double a = (double) numArray8[index41];
                      bitmap1 = (Bitmap) null;
                      ref Bitmap local66 = ref bitmap1;
                      DrawMod.DrawSimplePart2ColouredNewFast(ref local64, ref local65, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local66);
                    }
                    if (maxLines1 == 3)
                    {
                      ref Graphics local67 = ref useg;
                      bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_LINE3, Zoom);
                      ref Bitmap local68 = ref bitmap2;
                      rectangle2 = new Rectangle(this.game.SHEETX[index40] * width + numArray1[index37], this.game.SHEETY[index40] * height + numArray2[index37], numArray3[index37], numArray4[index37]);
                      Rectangle srcrect = rectangle2;
                      rectangle1 = new Rectangle(tx + numArray1[index37], ty + numArray2[index37], numArray3[index37], numArray4[index37]);
                      Rectangle destrect = rectangle1;
                      double r = (double) numArray5[index41];
                      double g = (double) numArray6[index41];
                      double b = (double) numArray7[index41];
                      double a = (double) numArray8[index41];
                      bitmap1 = (Bitmap) null;
                      ref Bitmap local69 = ref bitmap1;
                      DrawMod.DrawSimplePart2ColouredNewFast(ref local67, ref local68, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local69);
                    }
                  }
                }
                ++index37;
              }
              while (index37 <= 6);
              num1 = num25;
            }
          }
        }
      }
      if (!(flag3 & !flag2))
        return;
      int index42 = 1;
      do
      {
        if (numArray13[index42] == 1 & hexHeightMapData.cHeight > 0)
        {
          int num39 = 4;
          int num40 = index42 - 1;
          int index43 = index42 - 1;
          if (index43 < 1)
            index43 = 6;
          if (hexHeightMapData.cHeight == hexHeightMapDataArray[index42].cHeight & hexHeightMapData.cHeight == hexHeightMapDataArray[index43].cHeight & hexHeightMapDataArray[index42].maxLines > 1 && hexHeightMapDataArray[index42].lineHeightLevel[2] == hexHeightMapData.cHeight - 1)
            num39 = 5;
          int num41 = numArray12[hexHeightMapData.cHeight - 1];
          int index44 = hexHeightMapData.cHeight - 1;
          if (num41 > 0 & num41 < (int) byte.MaxValue)
          {
            int num42 = (int) Math.Round((double) ((int) byte.MaxValue * (num41 - num1)) / (double) ((int) byte.MaxValue - num1));
            if (num42 > 0)
            {
              ref Graphics local70 = ref useg;
              bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_TRANS_SHADOW, Zoom);
              ref Bitmap local71 = ref bitmap2;
              rectangle2 = new Rectangle(num39 * width, num40 * height, width, height);
              Rectangle srcrect = rectangle2;
              rectangle1 = new Rectangle(tx, ty, width, height);
              Rectangle destrect = rectangle1;
              double r = (double) numArray9[index44];
              double g = (double) numArray10[index44];
              double b = (double) numArray11[index44];
              double a = (double) ((float) num42 / (float) byte.MaxValue);
              bitmap1 = (Bitmap) null;
              ref Bitmap local72 = ref bitmap1;
              DrawMod.DrawSimplePart2ColouredNewFast(ref local70, ref local71, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local72);
              num1 = num41;
            }
          }
          if ((double) numArray8[index44] == 1.0)
          {
            ref Graphics local73 = ref useg;
            bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_TRANS_LINE, Zoom);
            ref Bitmap local74 = ref bitmap2;
            rectangle2 = new Rectangle(num39 * width, num40 * height, width, height);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(tx, ty, width, height);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local73, ref local74, srcrect, destrect);
          }
          else if ((double) numArray8[index44] > 0.0)
          {
            ref Graphics local75 = ref useg;
            bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_TRANS_LINE, Zoom);
            ref Bitmap local76 = ref bitmap2;
            rectangle2 = new Rectangle(num39 * width, num40 * height, width, height);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(tx, ty, width, height);
            Rectangle destrect = rectangle1;
            double r = (double) numArray5[index44];
            double g = (double) numArray6[index44];
            double b = (double) numArray7[index44];
            double a = (double) numArray8[index44];
            bitmap1 = (Bitmap) null;
            ref Bitmap local77 = ref bitmap1;
            DrawMod.DrawSimplePart2ColouredNewFast(ref local75, ref local76, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local77);
          }
        }
        ++index42;
      }
      while (index42 <= 6);
    }

    public void DrawCanyon(
      ref Graphics useg,
      int cx,
      int cy,
      int cmap,
      int tx,
      int ty,
      int Zoom,
      ref Bitmap gBitmap = null)
    {
      if (!this.game.AllowHeightMap)
        return;
      int[] numArray1 = new int[7];
      int[] numArray2 = new int[7];
      int[] numArray3 = new int[7];
      int[] numArray4 = new int[7];
      switch (Zoom)
      {
        case -1:
          numArray1[0] = 8;
          numArray2[0] = 4;
          numArray3[0] = 16;
          numArray4[0] = 16;
          numArray1[1] = 8;
          numArray2[1] = 0;
          numArray3[1] = 16;
          numArray4[1] = 4;
          numArray1[2] = 24;
          numArray2[2] = 0;
          numArray3[2] = 8;
          numArray4[2] = 12;
          numArray1[3] = 24;
          numArray2[3] = 12;
          numArray3[3] = 8;
          numArray4[3] = 12;
          numArray1[4] = 8;
          numArray2[4] = 20;
          numArray3[4] = 16;
          numArray4[4] = 4;
          numArray1[5] = 0;
          numArray2[5] = 12;
          numArray3[5] = 8;
          numArray4[5] = 12;
          numArray1[6] = 0;
          numArray2[6] = 0;
          numArray3[6] = 8;
          numArray4[6] = 12;
          break;
        case 0:
          numArray1[0] = 16;
          numArray2[0] = 8;
          numArray3[0] = 32;
          numArray4[0] = 32;
          numArray1[1] = 16;
          numArray2[1] = 0;
          numArray3[1] = 32;
          numArray4[1] = 8;
          numArray1[2] = 48;
          numArray2[2] = 0;
          numArray3[2] = 16;
          numArray4[2] = 24;
          numArray1[3] = 48;
          numArray2[3] = 24;
          numArray3[3] = 16;
          numArray4[3] = 24;
          numArray1[4] = 16;
          numArray2[4] = 40;
          numArray3[4] = 32;
          numArray4[4] = 8;
          numArray1[5] = 0;
          numArray2[5] = 24;
          numArray3[5] = 16;
          numArray4[5] = 24;
          numArray1[6] = 0;
          numArray2[6] = 0;
          numArray3[6] = 16;
          numArray4[6] = 24;
          break;
        case 1:
          numArray1[0] = 32;
          numArray2[0] = 16;
          numArray3[0] = 64;
          numArray4[0] = 64;
          numArray1[1] = 32;
          numArray2[1] = 0;
          numArray3[1] = 64;
          numArray4[1] = 16;
          numArray1[2] = 96;
          numArray2[2] = 0;
          numArray3[2] = 32;
          numArray4[2] = 48;
          numArray1[3] = 96;
          numArray2[3] = 48;
          numArray3[3] = 32;
          numArray4[3] = 48;
          numArray1[4] = 32;
          numArray2[4] = 80;
          numArray3[4] = 64;
          numArray4[4] = 16;
          numArray1[5] = 0;
          numArray2[5] = 48;
          numArray3[5] = 32;
          numArray4[5] = 48;
          numArray1[6] = 0;
          numArray2[6] = 0;
          numArray3[6] = 32;
          numArray4[6] = 48;
          break;
      }
      float[] numArray5 = new float[10];
      float[] numArray6 = new float[10];
      float[] numArray7 = new float[10];
      float[] numArray8 = new float[10];
      int index1 = 0;
      do
      {
        numArray5[index1] = 1f;
        numArray6[index1] = 1f;
        numArray7[index1] = 1f;
        numArray8[index1] = 0.125f;
        if (index1 == 0)
          numArray8[index1] = 0.25f;
        ++index1;
      }
      while (index1 <= 9);
      float[] numArray9 = new float[10];
      float[] numArray10 = new float[10];
      float[] numArray11 = new float[10];
      int[] numArray12 = new int[10];
      int num1 = 0;
      int[] numArray13 = new int[7];
      numArray12[0] = 100;
      numArray12[1] = 40;
      numArray12[2] = 0;
      int width;
      int height;
      switch (Zoom)
      {
        case -1:
          width = 32;
          height = 24;
          break;
        case 0:
          width = 64;
          height = 48;
          break;
        default:
          width = 128;
          height = 96;
          break;
      }
      Coordinate[] coordinateArray = new Coordinate[7];
      int tfacing = 1;
      do
      {
        coordinateArray[tfacing] = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
        numArray13[tfacing] = 0;
        ++tfacing;
      }
      while (tfacing <= 6);
      int num2 = 2;
      do
      {
        int[] numArray14 = new int[7];
        bool flag1 = false;
        int[] numArray15 = new int[7];
        bool flag2 = false;
        int index2 = 1;
        do
        {
          if (coordinateArray[index2].onmap)
          {
            if (this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[index2 - 1] == 4)
            {
              numArray14[index2] = 0;
              flag1 = true;
            }
            else
              numArray14[index2] = 1;
            int num3 = index2 + 4;
            if (num3 > 6)
              num3 -= 6;
            if (this.game.Data.MapObj[0].HexObj[coordinateArray[index2].x, coordinateArray[index2].y].RiverType[num3 - 1] == 4)
            {
              int num4 = index2 - 1;
              if (num4 < 1)
                num4 = 6;
              if (this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[num4 - 1] != 4 && this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[index2 - 1] != 4)
              {
                numArray15[index2] = 1;
                flag2 = true;
              }
            }
          }
          ++index2;
        }
        while (index2 <= 6);
        Bitmap bitmap1;
        Rectangle rectangle1;
        Rectangle rectangle2;
        Bitmap bitmap2;
        if (flag1)
        {
          int index3 = this.game.SPRITE64[numArray14[1], numArray14[2], numArray14[3], numArray14[4], numArray14[5], numArray14[6]];
          int num5 = numArray12[num2 - 1];
          int index4 = num2 - 1;
          if (num5 > 0 & num5 < (int) byte.MaxValue)
          {
            int num6 = (int) Math.Round((double) ((int) byte.MaxValue * (num5 - num1)) / (double) ((int) byte.MaxValue - num1));
            if (num2 == 1)
            {
              ref Graphics local1 = ref useg;
              bitmap1 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_SHADOW1, Zoom);
              ref Bitmap local2 = ref bitmap1;
              rectangle1 = new Rectangle(this.game.SHEETX[index3] * width, this.game.SHEETY[index3] * height, width, height);
              Rectangle srcrect = rectangle1;
              rectangle2 = new Rectangle(tx, ty, width, height);
              Rectangle destrect = rectangle2;
              double r = (double) numArray9[index4];
              double g = (double) numArray10[index4];
              double b = (double) numArray11[index4];
              double a = (double) ((float) num6 / (float) byte.MaxValue);
              bitmap2 = (Bitmap) null;
              ref Bitmap local3 = ref bitmap2;
              DrawMod.DrawSimplePart2ColouredNewFast(ref local1, ref local2, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local3);
            }
            if (num2 == 2)
            {
              ref Graphics local4 = ref useg;
              bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_SHADOW2, Zoom);
              ref Bitmap local5 = ref bitmap2;
              rectangle2 = new Rectangle(this.game.SHEETX[index3] * width, this.game.SHEETY[index3] * height, width, height);
              Rectangle srcrect = rectangle2;
              rectangle1 = new Rectangle(tx, ty, width, height);
              Rectangle destrect = rectangle1;
              double r = (double) numArray9[index4];
              double g = (double) numArray10[index4];
              double b = (double) numArray11[index4];
              double a = (double) ((float) num6 / (float) byte.MaxValue);
              bitmap1 = (Bitmap) null;
              ref Bitmap local6 = ref bitmap1;
              DrawMod.DrawSimplePart2ColouredNewFast(ref local4, ref local5, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local6);
            }
            num1 = num5;
          }
          if ((double) numArray8[index4] == 1.0)
          {
            if (num2 == 1)
            {
              ref Graphics local7 = ref useg;
              bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_LINE1, Zoom);
              ref Bitmap local8 = ref bitmap2;
              rectangle2 = new Rectangle(this.game.SHEETX[index3] * width, this.game.SHEETY[index3] * height, width, height);
              Rectangle srcrect = rectangle2;
              rectangle1 = new Rectangle(tx, ty, width, height);
              Rectangle destrect = rectangle1;
              DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect, destrect);
            }
            if (num2 == 2)
            {
              ref Graphics local9 = ref useg;
              bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_LINE2, Zoom);
              ref Bitmap local10 = ref bitmap2;
              rectangle2 = new Rectangle(this.game.SHEETX[index3] * width, this.game.SHEETY[index3] * height, width, height);
              Rectangle srcrect = rectangle2;
              rectangle1 = new Rectangle(tx, ty, width, height);
              Rectangle destrect = rectangle1;
              DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect, destrect);
            }
            if (num2 == 3)
            {
              ref Graphics local11 = ref useg;
              bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_LINE3, Zoom);
              ref Bitmap local12 = ref bitmap2;
              rectangle2 = new Rectangle(this.game.SHEETX[index3] * width, this.game.SHEETY[index3] * height, width, height);
              Rectangle srcrect = rectangle2;
              rectangle1 = new Rectangle(tx, ty, width, height);
              Rectangle destrect = rectangle1;
              DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect, destrect);
            }
          }
          else
          {
            if (num2 == 1)
            {
              ref Graphics local13 = ref useg;
              bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_LINE1, Zoom);
              ref Bitmap local14 = ref bitmap2;
              rectangle2 = new Rectangle(this.game.SHEETX[index3] * width, this.game.SHEETY[index3] * height, width, height);
              Rectangle srcrect = rectangle2;
              rectangle1 = new Rectangle(tx, ty, width, height);
              Rectangle destrect = rectangle1;
              double r = (double) numArray5[index4];
              double g = (double) numArray6[index4];
              double b = (double) numArray7[index4];
              double a = (double) numArray8[index4];
              bitmap1 = (Bitmap) null;
              ref Bitmap local15 = ref bitmap1;
              DrawMod.DrawSimplePart2ColouredNewFast(ref local13, ref local14, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local15);
            }
            if (num2 == 2)
            {
              ref Graphics local16 = ref useg;
              bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_LINE2, Zoom);
              ref Bitmap local17 = ref bitmap2;
              rectangle2 = new Rectangle(this.game.SHEETX[index3] * width, this.game.SHEETY[index3] * height, width, height);
              Rectangle srcrect = rectangle2;
              rectangle1 = new Rectangle(tx, ty, width, height);
              Rectangle destrect = rectangle1;
              double r = (double) numArray5[index4];
              double g = (double) numArray6[index4];
              double b = (double) numArray7[index4];
              double a = (double) numArray8[index4];
              bitmap1 = (Bitmap) null;
              ref Bitmap local18 = ref bitmap1;
              DrawMod.DrawSimplePart2ColouredNewFast(ref local16, ref local17, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local18);
            }
            if (num2 == 3)
            {
              ref Graphics local19 = ref useg;
              bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_LINE3, Zoom);
              ref Bitmap local20 = ref bitmap2;
              rectangle2 = new Rectangle(this.game.SHEETX[index3] * width, this.game.SHEETY[index3] * height, width, height);
              Rectangle srcrect = rectangle2;
              rectangle1 = new Rectangle(tx, ty, width, height);
              Rectangle destrect = rectangle1;
              double r = (double) numArray5[index4];
              double g = (double) numArray6[index4];
              double b = (double) numArray7[index4];
              double a = (double) numArray8[index4];
              bitmap1 = (Bitmap) null;
              ref Bitmap local21 = ref bitmap1;
              DrawMod.DrawSimplePart2ColouredNewFast(ref local19, ref local20, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local21);
            }
          }
        }
        if (flag2)
        {
          int index5 = 1;
          do
          {
            if (numArray15[index5] == 1)
            {
              int num7 = 4;
              if (num2 == 2)
                num7 = 5;
              int num8 = index5 - 1;
              int num9 = index5 - 1;
              int num10 = numArray12[num2 - 1];
              int index6 = num2 - 1;
              if (num10 > 0 & num10 < (int) byte.MaxValue)
              {
                int num11 = (int) Math.Round((double) ((int) byte.MaxValue * (num10 - numArray13[index5])) / (double) ((int) byte.MaxValue - numArray13[index5]));
                ref Graphics local22 = ref useg;
                bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_TRANS_SHADOW, Zoom);
                ref Bitmap local23 = ref bitmap2;
                rectangle2 = new Rectangle(num7 * width, num8 * height, width, height);
                Rectangle srcrect = rectangle2;
                rectangle1 = new Rectangle(tx, ty, width, height);
                Rectangle destrect = rectangle1;
                double r = (double) numArray9[index6];
                double g = (double) numArray10[index6];
                double b = (double) numArray11[index6];
                double a = (double) ((float) num11 / (float) byte.MaxValue);
                bitmap1 = (Bitmap) null;
                ref Bitmap local24 = ref bitmap1;
                DrawMod.DrawSimplePart2ColouredNewFast(ref local22, ref local23, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local24);
                numArray13[index5] = num10;
              }
              if ((double) numArray8[index6] == 1.0)
              {
                ref Graphics local25 = ref useg;
                bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_TRANS_LINE, Zoom);
                ref Bitmap local26 = ref bitmap2;
                rectangle2 = new Rectangle(num7 * width, num8 * height, width, height);
                Rectangle srcrect = rectangle2;
                rectangle1 = new Rectangle(tx, ty, width, height);
                Rectangle destrect = rectangle1;
                DrawMod.DrawSimplePart2(ref local25, ref local26, srcrect, destrect);
              }
              else
              {
                ref Graphics local27 = ref useg;
                bitmap2 = BitmapStore.GetBitmap(this.game.HEIGHTMAP_TRANS_LINE, Zoom);
                ref Bitmap local28 = ref bitmap2;
                rectangle2 = new Rectangle(num7 * width, num8 * height, width, height);
                Rectangle srcrect = rectangle2;
                rectangle1 = new Rectangle(tx, ty, width, height);
                Rectangle destrect = rectangle1;
                double r = (double) numArray5[index6];
                double g = (double) numArray6[index6];
                double b = (double) numArray7[index6];
                double a = (double) numArray8[index6];
                bitmap1 = (Bitmap) null;
                ref Bitmap local29 = ref bitmap1;
                DrawMod.DrawSimplePart2ColouredNewFast(ref local27, ref local28, srcrect, destrect, (float) r, (float) g, (float) b, (float) a, ref local29);
              }
            }
            ++index5;
          }
          while (index5 <= 6);
        }
        num2 += -1;
      }
      while (num2 >= 1);
    }

    public SimpleStringList DrawStandardShadowEmpireFrame(
      Graphics g,
      int temp1,
      int temp2,
      bool isGameLoop,
      bool isVidCom)
    {
      SimpleStringList simpleStringList = new SimpleStringList();
      int tx1 = 312;
      int screenWidth = this.game.ScreenWidth;
      int screenHeight = this.game.ScreenHeight;
      int tdata5_1 = 101;
      bool grayedOut;
      bool active;
      if (isGameLoop)
      {
        grayedOut = true;
        active = false;
      }
      if (isVidCom)
      {
        grayedOut = false;
        active = false;
      }
      if (this.game.EditObj.TestEarlyCinematics == 1 & isVidCom)
      {
        grayedOut = true;
        active = false;
        tdata5_1 = -1;
      }
      Rectangle rectangle1 = this.DrawOneTab(g, active, tx1, "MAP", -1, grayedOut: grayedOut) with
      {
        Y = 36
      };
      rectangle1.Height -= 36;
      if (isVidCom)
        simpleStringList.Add("Click to go to MAP mode. [Shortkey Escape]", 0, rectangle1.X, rectangle1.Y, rectangle1.Width, rectangle1.Height, tdata5_1, false);
      if (isGameLoop)
        simpleStringList.Add("Inaccesible during the AIs turn.", 0, rectangle1.X, rectangle1.Y, rectangle1.Width, rectangle1.Height, -1, false);
      int tx2 = tx1 + 68;
      int tdata5_2 = 102;
      if (isGameLoop)
      {
        grayedOut = true;
        active = false;
      }
      if (isVidCom)
      {
        grayedOut = false;
        active = false;
      }
      if (this.game.EditObj.TestEarlyCinematics == 1 & isVidCom)
      {
        grayedOut = true;
        active = false;
        tdata5_2 = -1;
      }
      rectangle1 = this.DrawOneTab(g, active, tx2, "HIS", -1, grayedOut: grayedOut) with
      {
        Y = 36
      };
      rectangle1.Height -= 36;
      if (isVidCom)
        simpleStringList.Add("Click to go to HISTORY mode. [Shortkey H]", 0, rectangle1.X, rectangle1.Y, rectangle1.Width, rectangle1.Height, tdata5_2, false);
      if (isGameLoop)
        simpleStringList.Add("Inaccesible during the AIs turn.", 0, rectangle1.X, rectangle1.Y, rectangle1.Width, rectangle1.Height, -1, false);
      int tx3 = tx2 + 68;
      if (isGameLoop)
      {
        grayedOut = true;
        active = false;
      }
      if (isVidCom)
      {
        grayedOut = false;
        active = true;
      }
      if (this.game.EditObj.TestEarlyCinematics == 1 & isVidCom)
      {
        grayedOut = false;
        active = true;
      }
      rectangle1 = this.DrawOneTab(g, active, tx3, "VID", -1, grayedOut: grayedOut) with
      {
        Y = 36
      };
      rectangle1.Height -= 36;
      if (isVidCom)
        simpleStringList.Add("You are currently in VIDCOM mode.", 0, rectangle1.X, rectangle1.Y, rectangle1.Width, rectangle1.Height, -1, false);
      if (isGameLoop)
        simpleStringList.Add("Inaccesible during the AIs turn.", 0, rectangle1.X, rectangle1.Y, rectangle1.Width, rectangle1.Height, -1, false);
      int tx4 = tx3 + 68;
      int tdata5_3 = 104;
      if (isGameLoop)
      {
        grayedOut = true;
        active = false;
      }
      if (isVidCom)
      {
        grayedOut = false;
        active = false;
      }
      if (this.game.EditObj.TestEarlyCinematics == 1 & isVidCom)
      {
        grayedOut = true;
        active = false;
        tdata5_3 = -1;
      }
      rectangle1 = this.DrawOneTab(g, active, tx4, "MNG", -1, grayedOut: grayedOut) with
      {
        Y = 36
      };
      rectangle1.Height -= 36;
      if (isVidCom)
        simpleStringList.Add("Click to go to to MANAGEMENT SCREEN mode. [Shortkey N]", 0, rectangle1.X, rectangle1.Y, rectangle1.Width, rectangle1.Height, tdata5_3, false);
      if (isGameLoop)
        simpleStringList.Add("Inaccesible during the AIs turn.", 0, rectangle1.X, rectangle1.Y, rectangle1.Width, rectangle1.Height, -1, false);
      int num1 = tx4 + 68;
      ref Graphics local1 = ref g;
      Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
      ref Bitmap local2 = ref bitmap;
      Rectangle rectangle2 = new Rectangle(0, 140, 300, 63);
      Rectangle srcrect1 = rectangle2;
      Rectangle rectangle3 = new Rectangle(0, 0, 300, 63);
      Rectangle destrect1 = rectangle3;
      DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
      if (this.game.ScreenWidth > 2600)
      {
        int width = (int) Math.Round((double) this.game.ScreenWidth / 2.0);
        ref Graphics local3 = ref g;
        bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
        ref Bitmap local4 = ref bitmap;
        rectangle3 = new Rectangle(300, 140, width, 32);
        Rectangle srcrect2 = rectangle3;
        rectangle2 = new Rectangle(300, 0, width, 32);
        Rectangle destrect2 = rectangle2;
        DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
        ref Graphics local5 = ref g;
        bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
        ref Bitmap local6 = ref bitmap;
        rectangle3 = new Rectangle(0, 140, width, 32);
        Rectangle srcrect3 = rectangle3;
        rectangle2 = new Rectangle(300 + width, 0, width, 32);
        Rectangle destrect3 = rectangle2;
        DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
        ref Graphics local7 = ref g;
        bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
        ref Bitmap local8 = ref bitmap;
        rectangle3 = new Rectangle(screenWidth - width - 150, 140, 150, 32);
        Rectangle srcrect4 = rectangle3;
        rectangle2 = new Rectangle(screenWidth - 150, 0, 150, 32);
        Rectangle destrect4 = rectangle2;
        DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
      }
      else
      {
        ref Graphics local9 = ref g;
        bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
        ref Bitmap local10 = ref bitmap;
        rectangle3 = new Rectangle(300, 140, screenWidth - 440, 32);
        Rectangle srcrect5 = rectangle3;
        rectangle2 = new Rectangle(300, 0, screenWidth - 440, 32);
        Rectangle destrect5 = rectangle2;
        DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
        ref Graphics local11 = ref g;
        bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
        ref Bitmap local12 = ref bitmap;
        int num2;
        rectangle3 = new Rectangle(screenWidth - num2 - 150, 140, 150, 32);
        Rectangle srcrect6 = rectangle3;
        rectangle2 = new Rectangle(screenWidth - 150, 0, 150, 32);
        Rectangle destrect6 = rectangle2;
        DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
      }
      for (int x = 290; x < this.game.ScreenWidth; x += 50)
      {
        ref Graphics local13 = ref g;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_BOTTOM);
        ref Bitmap local14 = ref bitmap;
        rectangle3 = new Rectangle(15, 22, 50, 20);
        Rectangle srcrect7 = rectangle3;
        rectangle2 = new Rectangle(x, 22, 50, 20);
        Rectangle destrect7 = rectangle2;
        DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect7, destrect7);
      }
      ref Graphics local15 = ref g;
      bitmap = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_LEFT);
      ref Bitmap local16 = ref bitmap;
      DrawMod.DrawSimple(ref local15, ref local16, 0, 0);
      string str = !(this.game.EditObj.RealTurn > -1 & this.game.EditObj.RealTurn <= this.game.Data.RegimeCounter & this.game.EditObj.RealRound > 0) ? "System Calculations" : this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Name;
      g.MeasureString(str, DrawMod.TGame.MarcFont16);
      DrawMod.DrawTextColouredConsoleCenter(ref g, str, this.game.MarcFont16, 193, 15, this.game.seColWhite);
      if (this.game.EditObj.RealRound > 0 && this.game.EditObj.RealTurn > -1 & this.game.EditObj.RealTurn <= this.game.Data.RegimeCounter)
      {
        int red = this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Red;
        int green = this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Green;
        int blue = this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Blue;
        int red2 = this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Red2;
        int green2 = this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Green2;
        int blue2 = this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Blue2;
        int bannerSpriteNr = this.game.Data.RegimeObj[this.game.EditObj.RealTurn].BannerSpriteNr;
        ref Graphics local17 = ref g;
        bitmap = BitmapStore.GetBitmap(bannerSpriteNr);
        ref Bitmap local18 = ref bitmap;
        double r1 = (double) ((float) red / (float) byte.MaxValue);
        double g1 = (double) ((float) green / (float) byte.MaxValue);
        double b1 = (double) ((float) blue / (float) byte.MaxValue);
        DrawMod.DrawScaledColorized2(ref local17, ref local18, 13, 15, 80, 60, 124, 210, (float) r1, (float) g1, (float) b1, 1f);
        int bannerSpriteNr2 = this.game.Data.RegimeObj[this.game.EditObj.RealTurn].BannerSpriteNr2;
        if (bannerSpriteNr2 > 0)
        {
          ref Graphics local19 = ref g;
          bitmap = BitmapStore.GetBitmap(bannerSpriteNr2);
          ref Bitmap local20 = ref bitmap;
          double r2 = (double) ((float) red2 / (float) byte.MaxValue);
          double g2 = (double) ((float) green2 / (float) byte.MaxValue);
          double b2 = (double) ((float) blue2 / (float) byte.MaxValue);
          DrawMod.DrawScaledColorized2(ref local19, ref local20, 13, 15, 80, 60, 124, 210, (float) r2, (float) g2, (float) b2, 1f);
        }
        int hqSpriteNr2 = this.game.Data.RegimeObj[this.game.EditObj.RealTurn].HQSpriteNr2;
        if (hqSpriteNr2 > 0)
        {
          ref Graphics local21 = ref g;
          bitmap = BitmapStore.GetBitmap(hqSpriteNr2);
          ref Bitmap local22 = ref bitmap;
          double r3 = (double) ((float) this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Red3 / (float) byte.MaxValue) - 1.0;
          double g3 = (double) ((float) this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Green3 / (float) byte.MaxValue) - 1.0;
          double b3 = (double) ((float) this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Blue3 / (float) byte.MaxValue) - 1.0;
          DrawMod.Draw(ref local21, ref local22, 30, 27, (float) r3, (float) g3, (float) b3, 0.95f);
        }
      }
      BitmapStore.GetBitmap(this.game.MARCTOPBAR).RotateFlip(RotateFlipType.Rotate180FlipX);
      for (int index = 0; index < this.game.ScreenWidth; index += 100)
      {
        ref Graphics local23 = ref g;
        bitmap = BitmapStore.GetBitmap(this.game.MARCTOPBAR);
        ref Bitmap local24 = ref bitmap;
        int x = index;
        int y = screenHeight - 37;
        DrawMod.DrawSimple(ref local23, ref local24, x, y);
      }
      BitmapStore.GetBitmap(this.game.MARCTOPBAR).RotateFlip(RotateFlipType.Rotate180FlipX);
      return simpleStringList;
    }

    public Rectangle DrawOneTab(
      Graphics g,
      bool active,
      int tx,
      string s,
      int iconSlot,
      int smallNumber = -1,
      bool grayedOut = false,
      bool MousingOverNow = false)
    {
      int y1 = 0;
      if (!active)
        y1 = -12;
      Bitmap bitmap;
      if (MousingOverNow)
      {
        ref Graphics local1 = ref g;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_TAB);
        ref Bitmap local2 = ref bitmap;
        int x = tx;
        int y2 = y1;
        DrawMod.Draw(ref local1, ref local2, x, y2, 0.05f, 0.05f, 0.05f, 1f);
      }
      else
      {
        ref Graphics local3 = ref g;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_TAB);
        ref Bitmap local4 = ref bitmap;
        int x = tx;
        int y3 = y1;
        DrawMod.DrawSimple(ref local3, ref local4, x, y3);
      }
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (iconSlot > -1)
      {
        if (grayedOut)
        {
          ref Graphics local5 = ref g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
          ref Bitmap local6 = ref bitmap;
          rectangle1 = new Rectangle(iconSlot * 42, 0, 42, 32);
          Rectangle srcrect = rectangle1;
          rectangle2 = new Rectangle(tx + 11, y1 + 20, 42, 32);
          Rectangle destrect = rectangle2;
          DrawMod.DrawSimplePart2Coloured(ref local5, ref local6, srcrect, destrect, 0.5f, 0.5f, 0.5f, 1f);
        }
        else if (MousingOverNow & !active)
        {
          ref Graphics local7 = ref g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
          ref Bitmap local8 = ref bitmap;
          rectangle2 = new Rectangle(iconSlot * 42, 32, 42, 32);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(tx + 11, y1 + 20, 42, 32);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect, destrect);
        }
        else
        {
          if (!active)
          {
            ref Graphics local9 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
            ref Bitmap local10 = ref bitmap;
            rectangle2 = new Rectangle(iconSlot * 42, 0, 42, 32);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(tx + 11, y1 + 20, 42, 32);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect, destrect);
          }
          if (active)
          {
            ref Graphics local11 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
            ref Bitmap local12 = ref bitmap;
            rectangle2 = new Rectangle(iconSlot * 42, 32, 42, 32);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(tx + 11, y1 + 20, 42, 32);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect, destrect);
          }
        }
      }
      Color c;
      if (smallNumber > 0)
      {
        if (!active)
        {
          ref Graphics local13 = ref g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONHIGHLIGHT);
          ref Bitmap local14 = ref bitmap;
          rectangle2 = new Rectangle(0, 0, 42, 32);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(tx + 11, y1 + 20, 42, 32);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect, destrect);
          c = Color.FromArgb((int) byte.MaxValue, 225, 215, 215);
        }
        if (active)
        {
          ref Graphics local15 = ref g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONHIGHLIGHT);
          ref Bitmap local16 = ref bitmap;
          rectangle2 = new Rectangle(0, 32, 42, 32);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(tx + 11, y1 + 20, 42, 32);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect, destrect);
          c = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 245, 245);
        }
        string str = smallNumber.ToString();
        if (smallNumber > 9)
          str = "X";
        SizeF sizeF = g.MeasureString(str, DrawMod.TGame.MarcFont5);
        DrawMod.DrawTextColouredConsole(ref g, str, this.game.MarcFont5, tx + (int) Math.Round((68.0 - (double) sizeF.Width) / 2.0) + 11, y1 + 22, c);
      }
      SizeF sizeF1 = g.MeasureString(s, DrawMod.TGame.MarcFont16);
      if (active)
        c = this.game.seColWhite;
      if (!active)
        c = this.game.seColGray;
      if (grayedOut)
        c = Color.FromArgb((int) byte.MaxValue, 128, 128, 128);
      DrawMod.DrawTextColouredConsole(ref g, s, this.game.MarcFont16, tx + (int) Math.Round((68.0 - (double) sizeF1.Width) / 2.0), y1 + 48, c);
      Rectangle rectangle3 = new Rectangle(tx, y1, 68, 75);
      tx += 68;
      return rectangle3;
    }

    public void DrawNumberWithDelta(Graphics g, int x, int y, string texty, int delta)
    {
      int eventPic1 = DrawMod.TGame.Data.FindEventPic("", 8, "SE_Present");
      int eventPic2 = DrawMod.TGame.Data.FindEventPic("", 9, "SE_Present");
      int eventPic3 = DrawMod.TGame.Data.FindEventPic("", 11, "SE_Present");
      bool flag = false;
      SizeF sizeF1 = new SizeF();
      int num = delta;
      if (num < 0)
      {
        num = Math.Abs(num);
        flag = true;
      }
      string tstring = num.ToString();
      SizeF sizeF2 = g.MeasureString(texty, DrawMod.TGame.MarcFont16);
      int index = eventPic3;
      if (flag)
        index = eventPic2;
      else if (delta > 0)
        index = eventPic1;
      DrawMod.DrawTextColouredConsole(ref g, texty, DrawMod.TGame.se1TypeWriterMedium, x, y, DrawMod.TGame.seColTW);
      if (Strings.InStr(texty, "?") > 0 | Strings.InStr(texty.ToLower(), "unknown") > 0 || DrawMod.TGame.Data.Round == 1)
        return;
      x = (int) Math.Round((double) ((float) x + (sizeF2.Width + 8f)));
      ref Graphics local1 = ref g;
      Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.Data.EventPicNr[index]);
      ref Bitmap local2 = ref bitmap;
      int x1 = x;
      int y1 = y + 2;
      DrawMod.DrawSimple(ref local1, ref local2, x1, y1);
      if (delta == 0)
        return;
      if (num >= 100000)
        tstring = Math.Floor((double) num / 1000.0).ToString() + "K";
      DrawMod.DrawTextColouredConsole(ref g, tstring, DrawMod.TGame.se1TypeWriterMedium, x + 16, y, DrawMod.TGame.seColTW);
    }

    public Bitmap DrawLeaderPortrait(
      int charId,
      int w,
      int h,
      bool showRelation = false,
      int relChange = 0,
      int isPeoplePortraitGroup = -1,
      int isPeopleId = -1,
      int isPeopleType = -1,
      int isRegId = -1,
      int isAllowHair = -1,
      int isUniformEventPic = -1,
      int sfNr = -1,
      bool transBG = false)
    {
      string libName = "SE_Data";
      int stringListById1 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 200, 0, 0));
      int stringListById2 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 196, 0, 0));
      DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 437, 0, 0));
      int stringListById3 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 438, 0, 0));
      int stringListById4 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 310, 0, 0));
      int stringListById5 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 306, 0, 0));
      int stringListById6 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 143, 0, 0));
      int num1;
      int idValue1;
      int num2;
      int num3;
      int num4;
      int num5;
      if (isPeoplePortraitGroup < 1)
      {
        num1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, charId, 16)));
        idValue1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, charId, 13)));
        num2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, charId, 5)));
        int num6 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, charId, 6)));
        num3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, charId, 15)));
        num4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, charId, 20)));
        num5 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, charId, 26)));
      }
      if (num2 < 1 & num5 > 0)
        num2 = num5;
      if (isRegId > -1)
        num2 = isRegId;
      int regimeById = this.game.HandyFunctionsObj.GetRegimeByID(num2);
      int idValue2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].GetData(0, num2, 2)));
      int idValue3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData(0, idValue2, 1)));
      int num7 = (int) Math.Round((double) (this.game.Data.Round - num1) / 6.0);
      Random random = new Random(charId);
      int num8 = random.Next(1, 3);
      int num9 = random.Next(30, 60);
      if (random.Next(0, 100) > 60)
        num9 = 0;
      else if (random.Next(0, 100) > 50)
        num9 = 999;
      if (isPeoplePortraitGroup > 0)
      {
        num7 = 30;
        if (isPeopleType == 1)
          num7 = 18;
        if (isPeopleType == 2)
          num7 = 32;
        if (isPeopleType == 3)
          num7 = 50;
        if (isPeopleType == 4)
          num7 = 60;
        if (isPeopleType == 12)
          num7 = 32;
        if (isPeopleType == 13)
          num7 = 50;
        if (isPeopleType == 14)
          num7 = 60;
        num9 = 50;
        if (isAllowHair < 1)
          num9 = 10;
        num8 = 2;
      }
      Bitmap objBitmap1 = new Bitmap(100, 140, PixelFormat.Format32bppPArgb);
      objBitmap1.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics objGraphics1 = Graphics.FromImage((Image) objBitmap1);
      objGraphics1.Clear(Color.Transparent);
      Bitmap objBitmap2 = new Bitmap(100, 140, PixelFormat.Format32bppPArgb);
      objBitmap2.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics objGraphics2 = Graphics.FromImage((Image) objBitmap2);
      if (isUniformEventPic > 0 && isPeoplePortraitGroup < 1)
        isPeoplePortraitGroup = 9999;
      Bitmap bitmap1;
      if (isPeoplePortraitGroup > 0 | transBG)
        objGraphics2.Clear(Color.Transparent);
      else if (relChange == -999)
      {
        DrawMod.DrawBlock(ref objGraphics1, 0, 0, w, h, 0, 0, 0, (int) byte.MaxValue);
        relChange = 0;
      }
      else if (regimeById != this.game.Data.Turn)
      {
        if (regimeById > -1)
        {
          float num10 = (float) this.game.Data.RegimeObj[regimeById].Red / (float) byte.MaxValue;
          float num11 = (float) this.game.Data.RegimeObj[regimeById].Green / (float) byte.MaxValue;
          float num12 = (float) this.game.Data.RegimeObj[regimeById].Blue / (float) byte.MaxValue;
          ref Graphics local1 = ref objGraphics2;
          Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.SE1_PORTRAITBACKGROUND);
          ref Bitmap local2 = ref bitmap2;
          double r = (double) num10 - 1.0;
          double g = (double) num11 - 1.0;
          double b = (double) num12 - 1.0;
          DrawMod.Draw(ref local1, ref local2, 0, 0, (float) r, (float) g, (float) b, 1f);
          ref Graphics local3 = ref objGraphics2;
          bitmap1 = BitmapStore.GetBitmap(this.game.Data.RegimeObj[regimeById].SymbolSpriteNr);
          ref Bitmap local4 = ref bitmap1;
          int width = BitmapStore.GetWidth(this.game.Data.RegimeObj[this.game.Data.Turn].SymbolSpriteNr);
          int origh = BitmapStore.Getheight(this.game.Data.RegimeObj[this.game.Data.Turn].SymbolSpriteNr);
          DrawMod.DrawScaledColorized(ref local3, ref local4, -20, 0, 140, 140, width, origh, 1f, 1f, 1f, 0.12f);
        }
        else
        {
          ref Graphics local5 = ref objGraphics2;
          Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.SE1_PORTRAITBACKGROUND);
          ref Bitmap local6 = ref bitmap3;
          DrawMod.DrawSimple(ref local5, ref local6, 0, 0);
        }
      }
      else if (idValue1 > 0)
      {
        float num13 = (float) (Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, idValue1, 7)) / 512.0) + 0.5f;
        float num14 = (float) (Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, idValue1, 8)) / 512.0) + 0.5f;
        float num15 = (float) (Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, idValue1, 9)) / 512.0) + 0.5f;
        if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, idValue1, 6))) == charId)
        {
          ref Graphics local7 = ref objGraphics2;
          Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.SE1_PORTRAITBACKGROUNDFACTIONLEADER);
          ref Bitmap local8 = ref bitmap4;
          double r = (double) (num13 - 0.75f);
          double g = (double) (num14 - 0.75f);
          double b = (double) (num15 - 0.75f);
          DrawMod.Draw(ref local7, ref local8, 0, 0, (float) r, (float) g, (float) b, 1f);
        }
        else
        {
          ref Graphics local9 = ref objGraphics2;
          Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.SE1_PORTRAITBACKGROUND);
          ref Bitmap local10 = ref bitmap5;
          double r = (double) (num13 - 0.75f);
          double g = (double) (num14 - 0.75f);
          double b = (double) (num15 - 0.75f);
          DrawMod.Draw(ref local9, ref local10, 0, 0, (float) r, (float) g, (float) b, 1f);
        }
      }
      else
      {
        ref Graphics local11 = ref objGraphics2;
        bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.SE1_PORTRAITBACKGROUND);
        ref Bitmap local12 = ref bitmap1;
        DrawMod.DrawSimple(ref local11, ref local12, 0, 0);
      }
      bool flag1 = false;
      int num16 = 1;
      Rectangle rectangle1;
      Rectangle rectangle2;
      do
      {
        int returnCol;
        if (num16 == 1)
          returnCol = 61;
        if (num16 == 2)
          returnCol = 59;
        if (num16 == 3)
          returnCol = 57;
        if (num16 == 4)
          returnCol = 55;
        if (num16 == 5)
          returnCol = 53;
        int idValue4;
        int num17;
        int index1;
        if (isPeoplePortraitGroup < 1)
        {
          idValue4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, charId, returnCol)));
          num17 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, charId, returnCol + 1)));
        }
        else
        {
          SimpleList simpleList = new SimpleList();
          int length = this.game.Data.StringListObj[stringListById3].Length;
          for (int index2 = 0; index2 <= length; ++index2)
          {
            if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index2, 1])) == isPeoplePortraitGroup && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index2, 2])) == num16)
            {
              index1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index2, 3]));
              int num18 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index2, 5]));
              int num19 = (int) Math.Round(Math.Floor((double) BitmapStore.Getheight(this.game.Data.EventPicNr[index1]) / (double) (num18 + 1)));
              for (int tdata2 = 1; tdata2 <= num19; ++tdata2)
                simpleList.Add((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index2, 0])) * 10 + tdata2, 10, (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index2, 0])), tdata2);
            }
          }
          int index3 = num16 != 4 ? simpleList.GetRandomSlotbasedOnWeightWithSeed((object) (isPeopleId + this.game.Data.GameID * num16)) : simpleList.GetRandomSlotbasedOnWeightWithSeed((object) (isRegId + this.game.Data.GameID * num16));
          if (index3 > -1)
          {
            idValue4 = simpleList.Data1[index3];
            num17 = simpleList.Data2[index3] - 1;
          }
        }
        int y;
        int height;
        float num20;
        float num21;
        if (idValue4 > 0)
        {
          int num22 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData(0, idValue4, 1)));
          int num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData(0, idValue4, 2)));
          index1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData(0, idValue4, 3)));
          y = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData(0, idValue4, 4)));
          height = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData(0, idValue4, 5)));
          num20 = 1f;
          num21 = 0.0f;
          if (num7 > 25 & num16 == 2 & num8 == 1)
          {
            num20 = 0.0f;
            num21 = 1f;
          }
          if (num7 > 33 & num16 == 3 & num8 == 1)
          {
            num20 = 0.0f;
            num21 = 1f;
          }
          if (num7 > 25 & num16 == 3 & num8 == 2)
          {
            num20 = 0.0f;
            num21 = 1f;
          }
          if (num7 > 33 & num16 == 2 & num8 == 2)
          {
            num20 = 0.0f;
            num21 = 1f;
          }
          if (num16 == 4 & num7 > 40 & num7 < 65)
            num21 = (float) (num7 - 40) / 25f;
          else if (num16 == 4 & num7 >= 65)
          {
            num21 = 1f;
            num20 = 0.0f;
          }
        }
        if (idValue4 > 0 | num16 == 5 && num16 == 5)
        {
          float saturation = 1f;
          if (num7 >= 15 & num7 < 40)
            saturation = (float) (1.35 - 0.35 * ((double) (num7 - 15) / 25.0));
          else if (num7 >= 50)
          {
            saturation = (float) (1.0 - (double) (num7 - 50) / 200.0);
            if ((double) saturation < 0.9)
              saturation = 0.8f;
          }
          if ((double) saturation != 1.0)
            DrawMod.DrawSaturized(ref objGraphics2, ref objBitmap1, 0, 0, saturation);
          else
            DrawMod.DrawSimple(ref objGraphics2, ref objBitmap1, 0, 0);
          DrawMod.DrawSimple(ref objGraphics1, ref objBitmap2, 0, 0);
        }
        if (idValue4 > 0)
        {
          if (num3 == 1 & num8 == 1 | isPeoplePortraitGroup > 0 & isAllowHair < 1)
          {
            if (num16 == 5 & num7 > num9)
            {
              num21 = 0.0f;
              num20 = 0.0f;
            }
          }
          else if (num16 == 5 & num7 > 50 & num7 < 65)
            num21 = (float) (num7 - 50) / 15f;
          else if (num16 == 5 & num7 >= 65)
          {
            num21 = 1f;
            num20 = 0.0f;
          }
          if (num16 == 1 & num7 < 60)
            num21 = (float) num7 / 60f;
          else if (num16 == 1 & num7 >= 60)
          {
            num21 = 1f;
            num20 = 0.0f;
          }
          if ((double) num20 == 1.0)
          {
            ref Graphics local13 = ref objGraphics1;
            bitmap1 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index1]);
            ref Bitmap local14 = ref bitmap1;
            rectangle1 = new Rectangle(0, (height + 1) * num17, 100, height);
            Rectangle srcrect = rectangle1;
            rectangle2 = new Rectangle(0, y, 100, height);
            Rectangle destrect = rectangle2;
            DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect, destrect);
          }
          else if ((double) num20 > 0.0)
          {
            ref Graphics local15 = ref objGraphics1;
            bitmap1 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index1]);
            ref Bitmap local16 = ref bitmap1;
            rectangle2 = new Rectangle(0, (height + 1) * num17, 100, height);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(0, y, 100, height);
            Rectangle destrect = rectangle1;
            double a = (double) num20;
            DrawMod.DrawSimplePart2Coloured(ref local15, ref local16, srcrect, destrect, 0.0f, 0.0f, 0.0f, (float) a);
          }
          if ((double) num21 == 1.0)
          {
            ref Graphics local17 = ref objGraphics1;
            bitmap1 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index1]);
            ref Bitmap local18 = ref bitmap1;
            rectangle2 = new Rectangle(101, (height + 1) * num17, 100, height);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(0, y, 100, height);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect, destrect);
          }
          else if ((double) num21 > 0.0)
          {
            ref Graphics local19 = ref objGraphics1;
            bitmap1 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index1]);
            ref Bitmap local20 = ref bitmap1;
            rectangle2 = new Rectangle(101, (height + 1) * num17, 100, height);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(0, y, 100, height);
            Rectangle destrect = rectangle1;
            double a = (double) num21;
            DrawMod.DrawSimplePart2Coloured(ref local19, ref local20, srcrect, destrect, 0.0f, 0.0f, 0.0f, (float) a);
          }
          flag1 = true;
        }
        ++num16;
      }
      while (num16 <= 5);
      if (flag1 | isPeoplePortraitGroup == 9999)
      {
        if (isUniformEventPic > -1)
        {
          int num24 = 0;
          if (isPeopleType == 2)
            num24 = 1;
          if (isPeopleType == 3)
            num24 = 2;
          if (isPeopleType == 4)
            num24 = 3;
          if (isPeopleType == 13)
            num24 = 1;
          if (isPeopleType == 14)
            num24 = 2;
          bool flag2 = false;
          int index4 = isUniformEventPic;
          if (BitmapStore.Getheight(this.game.Data.EventPicNr[index4]) >= 280)
            flag2 = true;
          int num25 = (int) Math.Round(Math.Floor((double) BitmapStore.GetWidth(this.game.Data.EventPicNr[index4]) / 100.0));
          int num26 = num24;
          if (BitmapStore.GetWidth(this.game.Data.EventPicNr[index4]) < (num26 + 1) * 100)
            num26 = 0;
          ref Graphics local21 = ref objGraphics1;
          bitmap1 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index4]);
          ref Bitmap local22 = ref bitmap1;
          rectangle2 = new Rectangle(num26 * 100, 0, 100, 140);
          Rectangle srcrect1 = rectangle2;
          rectangle1 = new Rectangle(0, 0, 100, 140);
          Rectangle destrect1 = rectangle1;
          DrawMod.DrawSimplePart2(ref local21, ref local22, srcrect1, destrect1);
          if (flag2 & regimeById > -1)
          {
            float num27 = (float) this.game.Data.RegimeObj[regimeById].Red / (float) byte.MaxValue;
            float num28 = (float) this.game.Data.RegimeObj[regimeById].Green / (float) byte.MaxValue;
            float num29 = (float) this.game.Data.RegimeObj[regimeById].Blue / (float) byte.MaxValue;
            bool flag3 = false;
            if (sfNr > -1)
            {
              if (this.game.Data.SFTypeObj[this.game.Data.SFObj[sfNr].Type].Theater == 2)
                flag3 = true;
              int unitCounter = this.game.Data.UnitCounter;
              for (int index5 = 0; index5 <= unitCounter; ++index5)
              {
                int sfCount = this.game.Data.UnitObj[index5].SFCount;
                for (int index6 = 0; index6 <= sfCount; ++index6)
                {
                  if (this.game.Data.UnitObj[index5].SFList[index6] == sfNr && this.game.Data.UnitObj[index5].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index5].Historical].TempVar1 == 1)
                    flag3 = true;
                }
              }
            }
            if (flag3)
            {
              num27 = (float) this.game.Data.RegimeObj[regimeById].Red2 / (float) byte.MaxValue;
              num28 = (float) this.game.Data.RegimeObj[regimeById].Green2 / (float) byte.MaxValue;
              num29 = (float) this.game.Data.RegimeObj[regimeById].Blue2 / (float) byte.MaxValue;
            }
            ref Graphics local23 = ref objGraphics1;
            bitmap1 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index4]);
            ref Bitmap local24 = ref bitmap1;
            rectangle2 = new Rectangle(num26 * 100, 140, 100, 140);
            Rectangle srcrect2 = rectangle2;
            rectangle1 = new Rectangle(0, 0, 100, 140);
            Rectangle destrect2 = rectangle1;
            double r = (double) (-0.0f + num27);
            double g = (double) (-0.0f + num28);
            double b = (double) (-0.0f + num29);
            DrawMod.DrawSimplePart2ColouredNew(ref local23, ref local24, srcrect2, destrect2, (float) r, (float) g, (float) b, 1f);
          }
        }
        else
        {
          int num30 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, charId, 6)));
          int returnCol = 7;
          if (num30 == 3 | num30 == 4)
            returnCol = 9;
          if (num30 == 5 | num30 == 6 | num30 == 10)
            returnCol = 8;
          int index = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData(0, idValue3, returnCol)));
          if (index > 0)
          {
            bool flag4 = false;
            if (BitmapStore.Getheight(this.game.Data.EventPicNr[index]) >= 280)
              flag4 = true;
            int num31 = (int) Math.Round(Math.Floor((double) BitmapStore.GetWidth(this.game.Data.EventPicNr[index]) / 100.0));
            int num32 = 0;
            if (num31 > 1)
              num32 = new Random(charId).Next(1, num31 + 1) - 1;
            ref Graphics local25 = ref objGraphics1;
            bitmap1 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index]);
            ref Bitmap local26 = ref bitmap1;
            rectangle2 = new Rectangle(num32 * 100, 0, 100, 140);
            Rectangle srcrect3 = rectangle2;
            rectangle1 = new Rectangle(0, 0, 100, 140);
            Rectangle destrect3 = rectangle1;
            DrawMod.DrawSimplePart2(ref local25, ref local26, srcrect3, destrect3);
            if (flag4 & regimeById > -1)
            {
              float num33 = (float) this.game.Data.RegimeObj[regimeById].Red / (float) byte.MaxValue;
              float num34 = (float) this.game.Data.RegimeObj[regimeById].Green / (float) byte.MaxValue;
              float num35 = (float) this.game.Data.RegimeObj[regimeById].Blue / (float) byte.MaxValue;
              bool flag5 = false;
              if (charId > -1)
              {
                num32 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, charId, 6)));
                int id = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, charId, 7)));
                if (num32 == 3 & id > 0)
                {
                  int historicalUnitById = this.game.HandyFunctionsObj.GetHistoricalUnitByID(id);
                  if (historicalUnitById > -1 && this.game.Data.HistoricalUnitObj[historicalUnitById].TempVar1 == 1)
                    flag5 = true;
                }
              }
              if (flag5)
              {
                num33 = (float) this.game.Data.RegimeObj[regimeById].Red2 / (float) byte.MaxValue;
                num34 = (float) this.game.Data.RegimeObj[regimeById].Green2 / (float) byte.MaxValue;
                num35 = (float) this.game.Data.RegimeObj[regimeById].Blue2 / (float) byte.MaxValue;
              }
              ref Graphics local27 = ref objGraphics1;
              bitmap1 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index]);
              ref Bitmap local28 = ref bitmap1;
              rectangle2 = new Rectangle(num32 * 100, 140, 100, 140);
              Rectangle srcrect4 = rectangle2;
              rectangle1 = new Rectangle(0, 0, 100, 140);
              Rectangle destrect4 = rectangle1;
              double r = (double) (-0.0f + num33);
              double g = (double) (-0.0f + num34);
              double b = (double) (-0.0f + num35);
              DrawMod.DrawSimplePart2ColouredNew(ref local27, ref local28, srcrect4, destrect4, (float) r, (float) g, (float) b, 1f);
            }
          }
        }
      }
      objGraphics1.Dispose();
      objGraphics2.Dispose();
      objGraphics2 = (Graphics) null;
      if (isPeoplePortraitGroup < 1)
      {
        if (relChange > 100 | relChange < -100)
          showRelation = false;
        else if (charId < 1)
          showRelation = false;
      }
      else
        showRelation = false;
      if (w == 100 & h == 140 & !showRelation)
        return objBitmap1;
      Bitmap bitmap6 = new Bitmap(w, h, PixelFormat.Format32bppPArgb);
      bitmap6.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics = Graphics.FromImage((Image) bitmap6);
      DrawMod.DrawScaled(ref graphics, ref objBitmap1, 0, 0, w, h, true);
      if (showRelation)
      {
        if (regimeById != this.game.Data.Turn & regimeById != -1)
        {
          num4 = relChange;
          if (relChange == 0)
            num4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 275, 0, 0))].GetData3(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, this.game.Data.RegimeObj[regimeById].id, 2, "relation", 3)));
          relChange = 0;
        }
        Color color1 = num4 < 75 ? (num4 < 50 ? (num4 < 25 ? this.game.seColRed : this.game.seColBlue) : this.game.seColYellow) : this.game.seColGreen;
        Color c1 = DrawMod.LightenColor(color1, -150);
        Color color2 = DrawMod.LightenColor(color1, 75);
        Color c2 = Color.FromArgb((int) byte.MaxValue, (int) Math.Round((double) ((int) byte.MaxValue + (int) this.game.seColGreen.R) / 2.0), (int) Math.Round((double) ((int) byte.MaxValue + (int) this.game.seColGreen.G) / 2.0), (int) Math.Round((double) ((int) byte.MaxValue + (int) this.game.seColGreen.B) / 2.0));
        Color c3 = Color.FromArgb((int) byte.MaxValue, (int) Math.Round((double) ((int) byte.MaxValue + (int) this.game.seColRed.R) / 2.0), (int) Math.Round((double) ((int) byte.MaxValue + (int) this.game.seColRed.G) / 2.0), (int) Math.Round((double) ((int) byte.MaxValue + (int) this.game.seColRed.B) / 2.0));
        Color c4 = Color.FromArgb((int) byte.MaxValue, (int) Math.Round((double) ((int) byte.MaxValue + (int) color2.R) / 2.0), (int) Math.Round((double) ((int) byte.MaxValue + (int) color2.G) / 2.0), (int) Math.Round((double) ((int) byte.MaxValue + (int) color2.B) / 2.0));
        if (h <= 110)
        {
          DrawMod.DrawBlock(ref graphics, 3, h - 12, w - 6, 6, 0, 0, 0, 128);
          DrawMod.DrawBlockGradient(ref graphics, 3, h - 12, (int) Math.Round((double) (w - 6) * ((double) num4 / 100.0)), 6, c1, color1);
          DrawMod.DrawTextColouredConsole(ref graphics, num4.ToString(), this.game.MarcFont7, 7, h - 16, Color.FromArgb(128, 0, 0, 0));
          DrawMod.DrawTextColouredConsole(ref graphics, num4.ToString(), this.game.MarcFont7, 6, h - 17, c4);
        }
        else
        {
          DrawMod.DrawBlock(ref graphics, 4, h - 16, w - 8, 8, 0, 0, 0, 128);
          DrawMod.DrawBlockGradient(ref graphics, 4, h - 16, (int) Math.Round((double) (w - 8) * ((double) num4 / 100.0)), 8, c1, color1);
          DrawMod.DrawTextColouredConsole(ref graphics, num4.ToString(), this.game.MarcFont16, 9, h - 20, Color.FromArgb(128, 0, 0, 0));
          DrawMod.DrawTextColouredConsole(ref graphics, num4.ToString(), this.game.MarcFont16, 8, h - 21, c4);
        }
        if (relChange != 0)
        {
          SizeF sizeF1 = new SizeF();
          if (relChange > 0)
          {
            SizeF sizeF2 = graphics.MeasureString("+" + relChange.ToString(), this.game.MarcFont16);
            DrawMod.DrawBlock(ref graphics, (int) Math.Round((double) w - (3.0 + (double) sizeF2.Width) + 1.0), h - 18, (int) Math.Round((double) (sizeF2.Width + 2f)), 14, 0, 0, 0, 128);
            DrawMod.DrawTextColouredConsole(ref graphics, "+" + relChange.ToString(), this.game.MarcFont16, (int) Math.Round((double) w - (3.0 + (double) sizeF2.Width) + 1.0), h - 17, Color.FromArgb(128, 0, 0, 0));
            DrawMod.DrawTextColouredConsole(ref graphics, "+" + relChange.ToString(), this.game.MarcFont16, (int) Math.Round((double) ((float) w - (3f + sizeF2.Width))), h - 18, c2);
          }
          else if (relChange < 0)
          {
            SizeF sizeF3 = graphics.MeasureString(relChange.ToString(), this.game.MarcFont7);
            DrawMod.DrawBlock(ref graphics, (int) Math.Round((double) w - (3.0 + (double) sizeF3.Width) + 1.0), h - 18, (int) Math.Round((double) (sizeF3.Width + 2f)), 14, 0, 0, 0, 128);
            DrawMod.DrawTextColouredConsole(ref graphics, relChange.ToString(), this.game.MarcFont16, (int) Math.Round((double) w - (3.0 + (double) sizeF3.Width) + 1.0), h - 17, Color.FromArgb(128, 0, 0, 0));
            DrawMod.DrawTextColouredConsole(ref graphics, relChange.ToString(), this.game.MarcFont16, (int) Math.Round((double) ((float) w - (3f + sizeF3.Width))), h - 18, c3);
          }
        }
      }
      if (regimeById != this.game.Data.Turn & isPeopleType == -1 && regimeById > 0)
      {
        int num36 = (int) Math.Round((double) w * 0.4);
        ref Graphics local29 = ref graphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.Data.RegimeObj[regimeById].SymbolSpriteNr);
        ref Bitmap local30 = ref bitmap1;
        int x = w - num36;
        int y = h - num36;
        int w1 = num36;
        int h1 = num36;
        int width = BitmapStore.GetWidth(this.game.Data.RegimeObj[regimeById].SymbolSpriteNr);
        int origh = BitmapStore.Getheight(this.game.Data.RegimeObj[regimeById].SymbolSpriteNr);
        DrawMod.DrawScaledColorized(ref local29, ref local30, x, y, w1, h1, width, origh, 1f, 1f, 1f, 0.6f);
      }
      graphics.Dispose();
      graphics = (Graphics) null;
      objBitmap1.Dispose();
      objBitmap1 = (Bitmap) null;
      return bitmap6;
    }

    public Bitmap DrawActionCard(int nr, int roundnr = -1, bool small = false)
    {
      Bitmap bitmap1 = small ? new Bitmap(40, 60, PixelFormat.Format32bppPArgb) : new Bitmap(300, 450, PixelFormat.Format32bppPArgb);
      bitmap1.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics Expression = Graphics.FromImage((Image) bitmap1);
      if (!small)
      {
        if (this.game.Data.ActionCardObj[nr].ColorScheme <= 0)
          DrawMod.DrawSimple(ref Expression, ref this.game.CARD1, 0, 0);
        else if (this.game.Data.ActionCardObj[nr].ColorScheme == 1)
          DrawMod.DrawSimple(ref Expression, ref this.game.CARD2, 0, 0);
        else if (this.game.Data.ActionCardObj[nr].ColorScheme == 2)
          DrawMod.DrawSimple(ref Expression, ref this.game.CARD3, 0, 0);
        else if (this.game.Data.ActionCardObj[nr].ColorScheme == 3)
          DrawMod.DrawSimple(ref Expression, ref this.game.CARD4, 0, 0);
        else if (this.game.Data.ActionCardObj[nr].ColorScheme == 4)
          DrawMod.DrawSimple(ref Expression, ref this.game.CARD5, 0, 0);
        else
          DrawMod.DrawSimple(ref Expression, ref this.game.CARD5, 0, 0);
      }
      else if (this.game.Data.ActionCardObj[nr].ColorScheme <= 0)
        DrawMod.DrawScaled(ref Expression, ref this.game.CARD1, 0, 0, 40, 60);
      else if (this.game.Data.ActionCardObj[nr].ColorScheme == 1)
        DrawMod.DrawScaled(ref Expression, ref this.game.CARD2, 0, 0, 40, 60);
      else if (this.game.Data.ActionCardObj[nr].ColorScheme == 2)
        DrawMod.DrawScaled(ref Expression, ref this.game.CARD3, 0, 0, 40, 60);
      else if (this.game.Data.ActionCardObj[nr].ColorScheme == 3)
        DrawMod.DrawScaled(ref Expression, ref this.game.CARD4, 0, 0, 40, 60);
      else if (this.game.Data.ActionCardObj[nr].ColorScheme == 4)
        DrawMod.DrawScaled(ref Expression, ref this.game.CARD5, 0, 0, 40, 60);
      else
        DrawMod.DrawScaled(ref Expression, ref this.game.CARD5, 0, 0, 40, 60);
      if (this.game.Data.ActionCardObj[nr].EventPicNr > -1)
      {
        if (!small)
        {
          ref Graphics local1 = ref Expression;
          Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.game.Data.ActionCardObj[nr].EventPicNr]);
          ref Bitmap local2 = ref bitmap2;
          DrawMod.DrawScaled(ref local1, ref local2, 17, 66, 260, 194);
          ref Graphics local3 = ref Expression;
          Bitmap bitmap3 = BitmapStore.GetBitmap(this.game.ACTIONFRAME);
          ref Bitmap local4 = ref bitmap3;
          DrawMod.DrawSimple(ref local3, ref local4, 17, 66);
        }
        else
        {
          if (this.game.Data.ActionCardObj[nr].Nato > -1)
          {
            ref Graphics local5 = ref Expression;
            Bitmap bitmap4 = BitmapStore.GetBitmap(this.game.NATO[this.game.Data.ActionCardObj[nr].Nato]);
            ref Bitmap local6 = ref bitmap4;
            DrawMod.DrawScaled(ref local5, ref local6, 3, 11, 34, 22);
          }
          else
          {
            ref Graphics local7 = ref Expression;
            Bitmap bitmap5 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.game.Data.ActionCardObj[nr].EventPicNr]);
            ref Bitmap local8 = ref bitmap5;
            DrawMod.DrawScaled(ref local7, ref local8, 3, 11, 34, 22);
          }
          DrawMod.DrawRectangle(ref Expression, 4, 4, 12, 1, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          DrawMod.DrawRectangle(ref Expression, 4, 37, 29, 1, 0, 0, 0, (int) byte.MaxValue);
          DrawMod.DrawRectangle(ref Expression, 4, 41, 27, 1, 0, 0, 0, (int) byte.MaxValue);
          DrawMod.DrawRectangle(ref Expression, 4, 45, 14, 1, 0, 0, 0, (int) byte.MaxValue);
        }
      }
      if (!small)
      {
        SizeF sizeF = new SizeF();
        if ((double) Expression.MeasureString(this.game.Data.ActionCardObj[nr].Title, this.game.VicFont1).Width < 200.0)
          DrawMod.DrawTextVic2(ref Expression, this.game.Data.ActionCardObj[nr].Title, this.game.VicFont1, 21, 30, this.game.VicColor2, this.game.VicColor2Shade);
        else if ((double) Expression.MeasureString(this.game.Data.ActionCardObj[nr].Title, this.game.VicFont2).Width < 200.0)
          DrawMod.DrawTextVic2(ref Expression, this.game.Data.ActionCardObj[nr].Title, this.game.VicFont2, 21, 30, this.game.VicColor2, this.game.VicColor2Shade);
        else
          DrawMod.DrawTextVic2(ref Expression, this.game.Data.ActionCardObj[nr].Title, this.game.VicFont3, 21, 30, this.game.VicColor2, this.game.VicColor2Shade);
        string tstring = Strings.Trim(Conversion.Str((object) this.game.Data.ActionCardObj[nr].PPCost));
        if (this.game.Data.ActionCardObj[nr].PPCost == -1)
          tstring = "N/A";
        DrawMod.DrawTextVic2(ref Expression, tstring, this.game.VicFont1, 223, 30, this.game.VicColor2, this.game.VicColor2Shade);
        string str1 = this.game.Data.ActionCardObj[nr].Text;
        int num1 = 1;
        while (num1 == 1)
        {
          num1 = 0;
          int num2 = Strings.InStr(str1, "[gamevar]");
          if (num2 > 0)
          {
            int num3 = Strings.InStr(str1, "[/gamevar]");
            if (num3 > num2 & num3 > 0)
            {
              string str2 = Strings.Trim(Conversion.Str((object) this.game.Data.GameSlot[(int) Math.Round(Conversion.Val(Strings.Mid(str1, num2 + Strings.Len("[gamevar]"), num3 - (num2 + Strings.Len("[gamevar]")))))]));
              str1 = Strings.Left(str1, num2 - 1) + str2 + Strings.Mid(str1, num3 + Strings.Len("[/gamevar]"));
              num1 = 1;
            }
          }
          int num4 = Strings.InStr(str1, "[tempvar]");
          if (num4 > 0)
          {
            int num5 = Strings.InStr(str1, "[/tempvar]");
            if (num5 > num4 & num5 > 0)
            {
              string str3 = Strings.Trim(Conversion.Str((object) this.game.Data.TempVar[(int) Math.Round(Conversion.Val(Strings.Mid(str1, num4 + Strings.Len("[tempvar]"), num5 - (num4 + Strings.Len("[tempvar]")))))]));
              str1 = Strings.Left(str1, num4 - 1) + str3 + Strings.Mid(str1, num5 + Strings.Len("[/tempvar]"));
              num1 = 1;
            }
          }
          int num6 = Strings.InStr(str1, "[regimevar]");
          if (num6 > 0)
          {
            int num7 = Strings.InStr(str1, "[/regimevar]");
            if (num7 > num6 & num7 > 0)
            {
              string str4 = Strings.Mid(str1, num6 + Strings.Len("[regimevar]"), num7 - (num6 + Strings.Len("[regimevar]")));
              int num8 = Strings.InStr(str4, ",");
              if (num8 > 0)
              {
                string str5 = Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[(int) Math.Round(Conversion.Val(Strings.Left(str4, num8 - 1)))].RegimeSlot[(int) Math.Round(Conversion.Val(Strings.Mid(str4, num8 + 1)))]));
                str1 = Strings.Left(str1, num6 - 1) + str5 + Strings.Mid(str1, num7 + Strings.Len("[/regimevar]"));
                num1 = 1;
              }
            }
          }
        }
        int num9 = 1;
        while (num9 == 1)
        {
          num9 = 0;
          int num10 = Strings.InStr(str1, "[regimename]");
          if (num10 > 0)
          {
            int num11 = Strings.InStr(str1, "[/regimename]");
            if (num11 > num10 & num11 > 0)
            {
              string name = this.game.Data.RegimeObj[(int) Math.Round(Conversion.Val(Strings.Mid(str1, num10 + Strings.Len("[regimename]"), num11 - (num10 + Strings.Len("[regimename]")))))].Name;
              str1 = Strings.Left(str1, num10 - 1) + name + Strings.Mid(str1, num11 + Strings.Len("[/regimename]"));
              num9 = 1;
            }
          }
          int num12 = Strings.InStr(str1, "[unitname]");
          if (num12 > 0)
          {
            int num13 = Strings.InStr(str1, "[/unitname]");
            if (num13 > num12 & num13 > 0)
            {
              string name = this.game.Data.UnitObj[(int) Math.Round(Conversion.Val(Strings.Mid(str1, num12 + Strings.Len("[unitname]"), num13 - (num12 + Strings.Len("[unitname]")))))].Name;
              str1 = Strings.Left(str1, num12 - 1) + name + Strings.Mid(str1, num13 + Strings.Len("[/unitname]"));
              num9 = 1;
            }
          }
          int num14 = Strings.InStr(str1, "[hexname]");
          if (num14 > 0)
          {
            int num15 = Strings.InStr(str1, "[/hexname]");
            if (num15 > num14 & num15 > 0)
            {
              string str6 = Strings.Mid(str1, num14 + Strings.Len("[hexname]"), num15 - (num14 + Strings.Len("[hexname]")));
              int num16 = Strings.InStr(str6, ",");
              if (num16 > 0)
              {
                string hexName = this.game.HandyFunctionsObj.GetHexName((int) Math.Round(Conversion.Val(Strings.Left(str6, num16 - 1))), (int) Math.Round(Conversion.Val(Strings.Mid(str6, num16 + 1))), 0);
                str1 = Strings.Left(str1, num14 - 1) + hexName + Strings.Mid(str1, num15 + Strings.Len("[/hexname]"));
                num9 = 1;
              }
            }
          }
        }
        string str7 = str1;
        TextAreaClass textAreaClass = Strings.Len(str7) >= 75 ? (Strings.Len(str7) >= 125 ? (Strings.Len(str7) >= 200 ? new TextAreaClass(this.game, 282, 10, this.game.VicFont3, "", false, str7, Color.Black, tbackbitmap: (ref bitmap1), bbx: 15, bby: 275, tHideShade: true) : new TextAreaClass(this.game, 282, 10, this.game.VicFont2, "", false, str7, Color.Black, tItemSize: 20, tbackbitmap: (ref bitmap1), bbx: 15, bby: 275, tHideShade: true)) : new TextAreaClass(this.game, 282, 10, this.game.VicFont2, "", false, str7, Color.Black, tItemSize: 20, tbackbitmap: (ref bitmap1), bbx: 15, bby: 275, tHideShade: true)) : new TextAreaClass(this.game, 282, 10, this.game.VicFont2, "", false, str7, Color.Black, tItemSize: 20, tbackbitmap: (ref bitmap1), bbx: 15, bby: 275, tHideShade: true);
        ref Graphics local9 = ref Expression;
        Bitmap bitmap6 = textAreaClass.Paint();
        ref Bitmap local10 = ref bitmap6;
        DrawMod.DrawSimple(ref local9, ref local10, 15, 275);
      }
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return bitmap1;
    }

    public Bitmap DrawActionCardMarc(
      int nr,
      int roundnr = -1,
      int size = 1,
      bool Shaded = false,
      int Percent = 0)
    {
      Bitmap bitmap1;
      switch (size)
      {
        case 1:
          bitmap1 = new Bitmap(190, 266, PixelFormat.Format32bppPArgb);
          break;
        case 2:
          bitmap1 = new Bitmap(105, 147, PixelFormat.Format32bppPArgb);
          break;
        default:
          bitmap1 = new Bitmap(33, 46, PixelFormat.Format32bppPArgb);
          break;
      }
      bitmap1.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics Expression = Graphics.FromImage((Image) bitmap1);
      Color c = this.game.Data.ActionCardObj[nr].ColorScheme > 0 ? (this.game.Data.ActionCardObj[nr].ColorScheme != 1 ? (this.game.Data.ActionCardObj[nr].ColorScheme != 2 ? (this.game.Data.ActionCardObj[nr].ColorScheme != 3 ? (this.game.Data.ActionCardObj[nr].ColorScheme != 4 ? Color.White : Color.White) : Color.White) : Color.White) : Color.White) : Color.White;
      Bitmap bitmap2;
      switch (size)
      {
        case 1:
          if (this.game.Data.ActionCardObj[nr].ColorScheme <= 0)
          {
            ref Graphics local1 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD1A);
            ref Bitmap local2 = ref bitmap2;
            DrawMod.DrawSimple(ref local1, ref local2, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 1)
          {
            ref Graphics local3 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD2A);
            ref Bitmap local4 = ref bitmap2;
            DrawMod.DrawSimple(ref local3, ref local4, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 2)
          {
            ref Graphics local5 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD3A);
            ref Bitmap local6 = ref bitmap2;
            DrawMod.DrawSimple(ref local5, ref local6, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 3)
          {
            ref Graphics local7 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD4A);
            ref Bitmap local8 = ref bitmap2;
            DrawMod.DrawSimple(ref local7, ref local8, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 4)
          {
            ref Graphics local9 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD5A);
            ref Bitmap local10 = ref bitmap2;
            DrawMod.DrawSimple(ref local9, ref local10, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 5)
          {
            ref Graphics local11 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD6A);
            ref Bitmap local12 = ref bitmap2;
            DrawMod.DrawSimple(ref local11, ref local12, 0, 0);
            break;
          }
          ref Graphics local13 = ref Expression;
          bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD5A);
          ref Bitmap local14 = ref bitmap2;
          DrawMod.DrawSimple(ref local13, ref local14, 0, 0);
          break;
        case 2:
          if (this.game.Data.ActionCardObj[nr].ColorScheme <= 0)
          {
            ref Graphics local15 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD1B);
            ref Bitmap local16 = ref bitmap2;
            DrawMod.DrawSimple(ref local15, ref local16, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 1)
          {
            ref Graphics local17 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD2B);
            ref Bitmap local18 = ref bitmap2;
            DrawMod.DrawSimple(ref local17, ref local18, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 2)
          {
            ref Graphics local19 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD3B);
            ref Bitmap local20 = ref bitmap2;
            DrawMod.DrawSimple(ref local19, ref local20, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 3)
          {
            ref Graphics local21 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD4B);
            ref Bitmap local22 = ref bitmap2;
            DrawMod.DrawSimple(ref local21, ref local22, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 4)
          {
            ref Graphics local23 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD5B);
            ref Bitmap local24 = ref bitmap2;
            DrawMod.DrawSimple(ref local23, ref local24, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 5)
          {
            ref Graphics local25 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD6B);
            ref Bitmap local26 = ref bitmap2;
            DrawMod.DrawSimple(ref local25, ref local26, 0, 0);
            break;
          }
          ref Graphics local27 = ref Expression;
          bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD5B);
          ref Bitmap local28 = ref bitmap2;
          DrawMod.DrawSimple(ref local27, ref local28, 0, 0);
          break;
        default:
          if (this.game.Data.ActionCardObj[nr].ColorScheme <= 0)
          {
            ref Graphics local29 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD1C);
            ref Bitmap local30 = ref bitmap2;
            DrawMod.DrawSimple(ref local29, ref local30, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 1)
          {
            ref Graphics local31 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD2C);
            ref Bitmap local32 = ref bitmap2;
            DrawMod.DrawSimple(ref local31, ref local32, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 2)
          {
            ref Graphics local33 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD3C);
            ref Bitmap local34 = ref bitmap2;
            DrawMod.DrawSimple(ref local33, ref local34, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 3)
          {
            ref Graphics local35 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD4C);
            ref Bitmap local36 = ref bitmap2;
            DrawMod.DrawSimple(ref local35, ref local36, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 4)
          {
            ref Graphics local37 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD5C);
            ref Bitmap local38 = ref bitmap2;
            DrawMod.DrawSimple(ref local37, ref local38, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 5)
          {
            ref Graphics local39 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD6C);
            ref Bitmap local40 = ref bitmap2;
            DrawMod.DrawSimple(ref local39, ref local40, 0, 0);
            break;
          }
          ref Graphics local41 = ref Expression;
          bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD5C);
          ref Bitmap local42 = ref bitmap2;
          DrawMod.DrawSimple(ref local41, ref local42, 0, 0);
          break;
      }
      if (this.game.Data.ActionCardObj[nr].EventPicNr > -1)
      {
        switch (size)
        {
          case 1:
            ref Graphics local43 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.game.Data.ActionCardObj[nr].EventPicNr]);
            ref Bitmap local44 = ref bitmap2;
            DrawMod.DrawScaled(ref local43, ref local44, 8, 37, 165, 76);
            break;
          case 2:
            ref Graphics local45 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.game.Data.ActionCardObj[nr].EventPicNr]);
            ref Bitmap local46 = ref bitmap2;
            DrawMod.DrawScaled(ref local45, ref local46, 4, 21, 92, 41);
            break;
          default:
            if (this.game.Data.ActionCardObj[nr].SmallGfx > -1)
            {
              ref Graphics local47 = ref Expression;
              bitmap2 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[this.game.Data.ActionCardObj[nr].SmallGfx]);
              ref Bitmap local48 = ref bitmap2;
              DrawMod.DrawScaled(ref local47, ref local48, 1, 6, 29, 14);
              break;
            }
            if (this.game.Data.ActionCardObj[nr].Nato > -1)
            {
              ref Graphics local49 = ref Expression;
              bitmap2 = BitmapStore.GetBitmap(this.game.NATO[this.game.Data.ActionCardObj[nr].Nato]);
              ref Bitmap local50 = ref bitmap2;
              DrawMod.DrawScaled(ref local49, ref local50, 1, 6, 29, 14);
              break;
            }
            ref Graphics local51 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.game.Data.ActionCardObj[nr].EventPicNr]);
            ref Bitmap local52 = ref bitmap2;
            DrawMod.DrawScaled(ref local51, ref local52, 1, 6, 29, 14);
            break;
        }
      }
      string str1 = this.game.Data.ActionCardObj[nr].Text;
      int num1 = 1;
      while (num1 == 1)
      {
        num1 = 0;
        int num2 = Strings.InStr(str1, "[gamevar]");
        if (num2 > 0)
        {
          int num3 = Strings.InStr(str1, "[/gamevar]");
          if (num3 > num2 & num3 > 0)
          {
            string str2 = Strings.Trim(Conversion.Str((object) this.game.Data.GameSlot[(int) Math.Round(Conversion.Val(Strings.Mid(str1, num2 + Strings.Len("[gamevar]"), num3 - (num2 + Strings.Len("[gamevar]")))))]));
            str1 = Strings.Left(str1, num2 - 1) + str2 + Strings.Mid(str1, num3 + Strings.Len("[/gamevar]"));
            num1 = 1;
          }
        }
        int num4 = Strings.InStr(str1, "[tempvar]");
        if (num4 > 0)
        {
          int num5 = Strings.InStr(str1, "[/tempvar]");
          if (num5 > num4 & num5 > 0)
          {
            string str3 = Strings.Trim(Conversion.Str((object) this.game.Data.TempVar[(int) Math.Round(Conversion.Val(Strings.Mid(str1, num4 + Strings.Len("[tempvar]"), num5 - (num4 + Strings.Len("[tempvar]")))))]));
            str1 = Strings.Left(str1, num4 - 1) + str3 + Strings.Mid(str1, num5 + Strings.Len("[/tempvar]"));
            num1 = 1;
          }
        }
        int num6 = Strings.InStr(str1, "[regimevar]");
        if (num6 > 0)
        {
          int num7 = Strings.InStr(str1, "[/regimevar]");
          if (num7 > num6 & num7 > 0)
          {
            string str4 = Strings.Mid(str1, num6 + Strings.Len("[regimevar]"), num7 - (num6 + Strings.Len("[regimevar]")));
            int num8 = Strings.InStr(str4, ",");
            if (num8 > 0)
            {
              string str5 = Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[(int) Math.Round(Conversion.Val(Strings.Left(str4, num8 - 1)))].RegimeSlot[(int) Math.Round(Conversion.Val(Strings.Mid(str4, num8 + 1)))]));
              str1 = Strings.Left(str1, num6 - 1) + str5 + Strings.Mid(str1, num7 + Strings.Len("[/regimevar]"));
              num1 = 1;
            }
          }
        }
      }
      int num9 = 1;
      while (num9 == 1)
      {
        num9 = 0;
        int num10 = Strings.InStr(str1, "[regimename]");
        if (num10 > 0)
        {
          int num11 = Strings.InStr(str1, "[/regimename]");
          if (num11 > num10 & num11 > 0)
          {
            string name = this.game.Data.RegimeObj[(int) Math.Round(Conversion.Val(Strings.Mid(str1, num10 + Strings.Len("[regimename]"), num11 - (num10 + Strings.Len("[regimename]")))))].Name;
            str1 = Strings.Left(str1, num10 - 1) + name + Strings.Mid(str1, num11 + Strings.Len("[/regimename]"));
            num9 = 1;
          }
        }
        int num12 = Strings.InStr(str1, "[unitname]");
        if (num12 > 0)
        {
          int num13 = Strings.InStr(str1, "[/unitname]");
          if (num13 > num12 & num13 > 0)
          {
            string name = this.game.Data.UnitObj[(int) Math.Round(Conversion.Val(Strings.Mid(str1, num12 + Strings.Len("[unitname]"), num13 - (num12 + Strings.Len("[unitname]")))))].Name;
            str1 = Strings.Left(str1, num12 - 1) + name + Strings.Mid(str1, num13 + Strings.Len("[/unitname]"));
            num9 = 1;
          }
        }
        int num14 = Strings.InStr(str1, "[hexname]");
        if (num14 > 0)
        {
          int num15 = Strings.InStr(str1, "[/hexname]");
          if (num15 > num14 & num15 > 0)
          {
            string str6 = Strings.Mid(str1, num14 + Strings.Len("[hexname]"), num15 - (num14 + Strings.Len("[hexname]")));
            int num16 = Strings.InStr(str6, ",");
            if (num16 > 0)
            {
              string hexName = this.game.HandyFunctionsObj.GetHexName((int) Math.Round(Conversion.Val(Strings.Left(str6, num16 - 1))), (int) Math.Round(Conversion.Val(Strings.Mid(str6, num16 + 1))), 0);
              str1 = Strings.Left(str1, num14 - 1) + hexName + Strings.Mid(str1, num15 + Strings.Len("[/hexname]"));
              num9 = 1;
            }
          }
        }
      }
      switch (size)
      {
        case 1:
          SizeF sizeF1 = new SizeF();
          string str7 = Strings.UCase(this.game.Data.ActionCardObj[nr].Title);
          int x1 = (int) Math.Round(4.0 + (88.0 - (double) Expression.MeasureString(str7, this.game.MarcFont16).Width / 2.0));
          DrawMod.DrawTextColouredMarc(ref Expression, str7, this.game.MarcFont16, x1, 13, c);
          string str8 = Strings.Trim(Conversion.Str((object) this.game.Data.ActionCardObj[nr].PPCost));
          if (this.game.Data.ActionCardObj[nr].PPCost == -1)
            str8 = "N/A";
          if (this.game.Data.ActionCardObj[nr].PPCost == 0)
          {
            str8 = "FREE";
            if (this.game.Data.ActionCardObj[nr].HisVarCostType > -1)
              str8 = this.game.Data.ActionCardObj[nr].HisVarCostQty.ToString();
          }
          int x2 = (int) Math.Round(72.0 + (19.0 - (double) Expression.MeasureString(str8, this.game.MarcFont7).Width / 2.0));
          DrawMod.DrawTextColoured(ref Expression, str8, this.game.MarcFont7, x2, 109, Color.White);
          TextAreaClass textAreaClass1 = new TextAreaClass(this.game, 200, 8, this.game.MarcFont8c, "", false, str1, Color.Black, tItemSize: 13, tbackbitmap: (ref bitmap1), bbx: -5, bby: 130, tcenterit: true, tHideShade: true, tBlockScroller: true);
          ref Graphics local53 = ref Expression;
          bitmap2 = textAreaClass1.Paint();
          ref Bitmap local54 = ref bitmap2;
          DrawMod.DrawSimple(ref local53, ref local54, -5, 130);
          break;
        case 2:
          string tText = Strings.UCase(str1);
          SizeF sizeF2 = new SizeF();
          string str9 = Strings.UCase(this.game.Data.ActionCardObj[nr].Title);
          int x3 = (int) Math.Round(3.0 + (46.0 - (double) Expression.MeasureString(str9, this.game.MarcFont5).Width / 2.0));
          DrawMod.DrawTextColouredMarc(ref Expression, str9, this.game.MarcFont5, x3, 6, c);
          string str10 = Strings.Trim(Conversion.Str((object) this.game.Data.ActionCardObj[nr].PPCost));
          if (this.game.Data.ActionCardObj[nr].PPCost == -1)
            str10 = "N/A";
          if (this.game.Data.ActionCardObj[nr].PPCost == 0)
          {
            str10 = "FREE";
            if (this.game.Data.ActionCardObj[nr].HisVarCostType > -1)
              str10 = this.game.Data.ActionCardObj[nr].HisVarCostQty.ToString();
          }
          int x4 = (int) Math.Round(39.0 + (11.0 - (double) Expression.MeasureString(str10, this.game.MarcFont10).Width / 2.0));
          DrawMod.DrawTextColoured(ref Expression, str10, this.game.MarcFont10, x4, 58, Color.White);
          TextAreaClass textAreaClass2 = new TextAreaClass(this.game, 136, 6, this.game.MarcFont11, "", false, tText, Color.Black, tItemSize: 10, tbackbitmap: (ref bitmap1), bbx: -13, bby: 68, tcenterit: true, tHideShade: true, tBlockScroller: true);
          ref Graphics local55 = ref Expression;
          bitmap2 = textAreaClass2.Paint();
          ref Bitmap local56 = ref bitmap2;
          DrawMod.DrawSimple(ref local55, ref local56, -13, 68);
          if (Shaded)
          {
            DrawMod.DrawBlockGradient2(ref Expression, 0, 0, 100, 145, Color.FromArgb(100, 0, 0, 0), Color.FromArgb(200, 0, 0, 0));
            break;
          }
          break;
        case 3:
          DrawMod.DrawBlock(ref Expression, 3, 25, 25, 1, 0, 0, 0, 195);
          DrawMod.DrawBlock(ref Expression, 3, 29, 18, 1, 0, 0, 0, 185);
          DrawMod.DrawBlock(ref Expression, 3, 3, 16, 1, (int) c.R, (int) c.G, (int) c.B, 200);
          if (Percent > 0)
            DrawMod.DrawTextColoured(ref Expression, Strings.Trim(Conversion.Str((object) Percent)) + "%", this.game.MarcFont9, 3, 31, Color.Black);
          if (Shaded)
          {
            DrawMod.DrawBlockGradient2(ref Expression, 0, 0, 33, 46, Color.FromArgb(100, 0, 0, 0), Color.FromArgb(200, 0, 0, 0));
            break;
          }
          break;
      }
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return bitmap1;
    }

    public Bitmap DrawActionCardMarc2(
      int regnr,
      int nr,
      int roundnr = -1,
      int size = 1,
      bool Shaded = false,
      int Percent = 0)
    {
      Bitmap bitmap1;
      switch (size)
      {
        case 1:
          bitmap1 = new Bitmap(190, 266, PixelFormat.Format32bppPArgb);
          break;
        case 2:
          bitmap1 = new Bitmap(105, 147, PixelFormat.Format32bppPArgb);
          break;
        default:
          bitmap1 = new Bitmap(33, 46, PixelFormat.Format32bppPArgb);
          break;
      }
      bitmap1.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics Expression = Graphics.FromImage((Image) bitmap1);
      Color c = this.game.Data.ActionCardObj[nr].ColorScheme > 0 ? (this.game.Data.ActionCardObj[nr].ColorScheme != 1 ? (this.game.Data.ActionCardObj[nr].ColorScheme != 2 ? (this.game.Data.ActionCardObj[nr].ColorScheme != 3 ? (this.game.Data.ActionCardObj[nr].ColorScheme != 4 ? Color.White : Color.White) : Color.White) : Color.White) : Color.White) : Color.White;
      Bitmap bitmap2;
      switch (size)
      {
        case 1:
          if (this.game.Data.ActionCardObj[nr].ColorScheme <= 0)
          {
            ref Graphics local1 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD1A);
            ref Bitmap local2 = ref bitmap2;
            DrawMod.DrawSimple(ref local1, ref local2, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 1)
          {
            ref Graphics local3 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD2A);
            ref Bitmap local4 = ref bitmap2;
            DrawMod.DrawSimple(ref local3, ref local4, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 2)
          {
            ref Graphics local5 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD3A);
            ref Bitmap local6 = ref bitmap2;
            DrawMod.DrawSimple(ref local5, ref local6, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 3)
          {
            ref Graphics local7 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD4A);
            ref Bitmap local8 = ref bitmap2;
            DrawMod.DrawSimple(ref local7, ref local8, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 4)
          {
            ref Graphics local9 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD5A);
            ref Bitmap local10 = ref bitmap2;
            DrawMod.DrawSimple(ref local9, ref local10, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 5)
          {
            ref Graphics local11 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD6A);
            ref Bitmap local12 = ref bitmap2;
            DrawMod.DrawSimple(ref local11, ref local12, 0, 0);
            break;
          }
          ref Graphics local13 = ref Expression;
          bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD5A);
          ref Bitmap local14 = ref bitmap2;
          DrawMod.DrawSimple(ref local13, ref local14, 0, 0);
          break;
        case 2:
          if (this.game.Data.ActionCardObj[nr].ColorScheme <= 0)
          {
            ref Graphics local15 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD1B);
            ref Bitmap local16 = ref bitmap2;
            DrawMod.DrawSimple(ref local15, ref local16, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 1)
          {
            ref Graphics local17 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD2B);
            ref Bitmap local18 = ref bitmap2;
            DrawMod.DrawSimple(ref local17, ref local18, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 2)
          {
            ref Graphics local19 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD3B);
            ref Bitmap local20 = ref bitmap2;
            DrawMod.DrawSimple(ref local19, ref local20, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 3)
          {
            ref Graphics local21 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD4B);
            ref Bitmap local22 = ref bitmap2;
            DrawMod.DrawSimple(ref local21, ref local22, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 4)
          {
            ref Graphics local23 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD5B);
            ref Bitmap local24 = ref bitmap2;
            DrawMod.DrawSimple(ref local23, ref local24, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 5)
          {
            ref Graphics local25 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD6B);
            ref Bitmap local26 = ref bitmap2;
            DrawMod.DrawSimple(ref local25, ref local26, 0, 0);
            break;
          }
          ref Graphics local27 = ref Expression;
          bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD5B);
          ref Bitmap local28 = ref bitmap2;
          DrawMod.DrawSimple(ref local27, ref local28, 0, 0);
          break;
        default:
          if (this.game.Data.ActionCardObj[nr].ColorScheme <= 0)
          {
            ref Graphics local29 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD1C);
            ref Bitmap local30 = ref bitmap2;
            DrawMod.DrawSimple(ref local29, ref local30, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 1)
          {
            ref Graphics local31 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD2C);
            ref Bitmap local32 = ref bitmap2;
            DrawMod.DrawSimple(ref local31, ref local32, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 2)
          {
            ref Graphics local33 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD3C);
            ref Bitmap local34 = ref bitmap2;
            DrawMod.DrawSimple(ref local33, ref local34, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 3)
          {
            ref Graphics local35 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD4C);
            ref Bitmap local36 = ref bitmap2;
            DrawMod.DrawSimple(ref local35, ref local36, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 4)
          {
            ref Graphics local37 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD5C);
            ref Bitmap local38 = ref bitmap2;
            DrawMod.DrawSimple(ref local37, ref local38, 0, 0);
            break;
          }
          if (this.game.Data.ActionCardObj[nr].ColorScheme == 5)
          {
            ref Graphics local39 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD6C);
            ref Bitmap local40 = ref bitmap2;
            DrawMod.DrawSimple(ref local39, ref local40, 0, 0);
            break;
          }
          ref Graphics local41 = ref Expression;
          bitmap2 = BitmapStore.GetBitmap(this.game.MARCCARD5C);
          ref Bitmap local42 = ref bitmap2;
          DrawMod.DrawSimple(ref local41, ref local42, 0, 0);
          break;
      }
      if (regnr == -1)
        regnr = 0;
      bool flag = false;
      if (this.game.Data.ActionCardObj[nr].EventPicNr > -1 && this.game.Data.Round > 0 && !this.game.Data.RegimeObj[regnr].UseAlternateActionCardPics)
      {
        flag = true;
        switch (size)
        {
          case 1:
            ref Graphics local43 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.game.Data.ActionCardObj[nr].EventPicNr]);
            ref Bitmap local44 = ref bitmap2;
            DrawMod.DrawScaled(ref local43, ref local44, 8, 37, 165, 76);
            break;
          case 2:
            ref Graphics local45 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.game.Data.ActionCardObj[nr].EventPicNr]);
            ref Bitmap local46 = ref bitmap2;
            DrawMod.DrawScaled(ref local45, ref local46, 4, 21, 92, 41);
            break;
          default:
            if (this.game.Data.ActionCardObj[nr].SmallGfx > -1)
            {
              ref Graphics local47 = ref Expression;
              bitmap2 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[this.game.Data.ActionCardObj[nr].SmallGfx]);
              ref Bitmap local48 = ref bitmap2;
              DrawMod.DrawScaled(ref local47, ref local48, 1, 6, 29, 14);
              break;
            }
            if (this.game.Data.ActionCardObj[nr].Nato > -1)
            {
              ref Graphics local49 = ref Expression;
              bitmap2 = BitmapStore.GetBitmap(this.game.NATO[this.game.Data.ActionCardObj[nr].Nato]);
              ref Bitmap local50 = ref bitmap2;
              DrawMod.DrawScaled(ref local49, ref local50, 1, 6, 29, 14);
              break;
            }
            ref Graphics local51 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.game.Data.ActionCardObj[nr].EventPicNr]);
            ref Bitmap local52 = ref bitmap2;
            DrawMod.DrawScaled(ref local51, ref local52, 1, 6, 29, 14);
            break;
        }
      }
      if (this.game.Data.Round > 0 && !flag & this.game.Data.ActionCardObj[nr].AlternateEventPicNr > -1 & this.game.Data.RegimeObj[regnr].UseAlternateActionCardPics)
      {
        switch (size)
        {
          case 1:
            ref Graphics local53 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.game.Data.ActionCardObj[nr].AlternateEventPicNr]);
            ref Bitmap local54 = ref bitmap2;
            DrawMod.DrawScaled(ref local53, ref local54, 8, 37, 165, 76);
            break;
          case 2:
            ref Graphics local55 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.game.Data.ActionCardObj[nr].AlternateEventPicNr]);
            ref Bitmap local56 = ref bitmap2;
            DrawMod.DrawScaled(ref local55, ref local56, 4, 21, 92, 41);
            break;
          default:
            if (this.game.Data.ActionCardObj[nr].SmallGfx > -1)
            {
              ref Graphics local57 = ref Expression;
              bitmap2 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[this.game.Data.ActionCardObj[nr].SmallGfx]);
              ref Bitmap local58 = ref bitmap2;
              DrawMod.DrawScaled(ref local57, ref local58, 1, 6, 29, 14);
              break;
            }
            if (this.game.Data.ActionCardObj[nr].Nato > -1)
            {
              ref Graphics local59 = ref Expression;
              bitmap2 = BitmapStore.GetBitmap(this.game.NATO[this.game.Data.ActionCardObj[nr].Nato]);
              ref Bitmap local60 = ref bitmap2;
              DrawMod.DrawScaled(ref local59, ref local60, 1, 6, 29, 14);
              break;
            }
            ref Graphics local61 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.game.Data.ActionCardObj[nr].AlternateEventPicNr]);
            ref Bitmap local62 = ref bitmap2;
            DrawMod.DrawScaled(ref local61, ref local62, 1, 6, 29, 14);
            break;
        }
      }
      if (!flag & this.game.Data.ActionCardObj[nr].EventPicNr > -1)
      {
        switch (size)
        {
          case 1:
            ref Graphics local63 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.game.Data.ActionCardObj[nr].EventPicNr]);
            ref Bitmap local64 = ref bitmap2;
            DrawMod.DrawScaled(ref local63, ref local64, 8, 37, 165, 76);
            break;
          case 2:
            ref Graphics local65 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.game.Data.ActionCardObj[nr].EventPicNr]);
            ref Bitmap local66 = ref bitmap2;
            DrawMod.DrawScaled(ref local65, ref local66, 4, 21, 92, 41);
            break;
          default:
            if (this.game.Data.ActionCardObj[nr].SmallGfx > -1)
            {
              ref Graphics local67 = ref Expression;
              bitmap2 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[this.game.Data.ActionCardObj[nr].SmallGfx]);
              ref Bitmap local68 = ref bitmap2;
              DrawMod.DrawScaled(ref local67, ref local68, 1, 6, 29, 14);
              break;
            }
            if (this.game.Data.ActionCardObj[nr].Nato > -1)
            {
              ref Graphics local69 = ref Expression;
              bitmap2 = BitmapStore.GetBitmap(this.game.NATO[this.game.Data.ActionCardObj[nr].Nato]);
              ref Bitmap local70 = ref bitmap2;
              DrawMod.DrawScaled(ref local69, ref local70, 1, 6, 29, 14);
              break;
            }
            ref Graphics local71 = ref Expression;
            bitmap2 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.game.Data.ActionCardObj[nr].EventPicNr]);
            ref Bitmap local72 = ref bitmap2;
            DrawMod.DrawScaled(ref local71, ref local72, 1, 6, 29, 14);
            break;
        }
      }
      string str1 = this.game.Data.ActionCardObj[nr].Text;
      int num1 = 1;
      while (num1 == 1)
      {
        num1 = 0;
        int num2 = Strings.InStr(str1, "[gamevar]");
        if (num2 > 0)
        {
          int num3 = Strings.InStr(str1, "[/gamevar]");
          if (num3 > num2 & num3 > 0)
          {
            string str2 = Strings.Trim(Conversion.Str((object) this.game.Data.GameSlot[(int) Math.Round(Conversion.Val(Strings.Mid(str1, num2 + Strings.Len("[gamevar]"), num3 - (num2 + Strings.Len("[gamevar]")))))]));
            str1 = Strings.Left(str1, num2 - 1) + str2 + Strings.Mid(str1, num3 + Strings.Len("[/gamevar]"));
            num1 = 1;
          }
        }
        int num4 = Strings.InStr(str1, "[tempvar]");
        if (num4 > 0)
        {
          int num5 = Strings.InStr(str1, "[/tempvar]");
          if (num5 > num4 & num5 > 0)
          {
            string str3 = Strings.Trim(Conversion.Str((object) this.game.Data.TempVar[(int) Math.Round(Conversion.Val(Strings.Mid(str1, num4 + Strings.Len("[tempvar]"), num5 - (num4 + Strings.Len("[tempvar]")))))]));
            str1 = Strings.Left(str1, num4 - 1) + str3 + Strings.Mid(str1, num5 + Strings.Len("[/tempvar]"));
            num1 = 1;
          }
        }
        int num6 = Strings.InStr(str1, "[regimevar]");
        if (num6 > 0)
        {
          int num7 = Strings.InStr(str1, "[/regimevar]");
          if (num7 > num6 & num7 > 0)
          {
            string str4 = Strings.Mid(str1, num6 + Strings.Len("[regimevar]"), num7 - (num6 + Strings.Len("[regimevar]")));
            int num8 = Strings.InStr(str4, ",");
            if (num8 > 0)
            {
              string str5 = Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[(int) Math.Round(Conversion.Val(Strings.Left(str4, num8 - 1)))].RegimeSlot[(int) Math.Round(Conversion.Val(Strings.Mid(str4, num8 + 1)))]));
              str1 = Strings.Left(str1, num6 - 1) + str5 + Strings.Mid(str1, num7 + Strings.Len("[/regimevar]"));
              num1 = 1;
            }
          }
        }
      }
      int num9 = 1;
      while (num9 == 1)
      {
        num9 = 0;
        int num10 = Strings.InStr(str1, "[regimename]");
        if (num10 > 0)
        {
          int num11 = Strings.InStr(str1, "[/regimename]");
          if (num11 > num10 & num11 > 0)
          {
            string name = this.game.Data.RegimeObj[(int) Math.Round(Conversion.Val(Strings.Mid(str1, num10 + Strings.Len("[regimename]"), num11 - (num10 + Strings.Len("[regimename]")))))].Name;
            str1 = Strings.Left(str1, num10 - 1) + name + Strings.Mid(str1, num11 + Strings.Len("[/regimename]"));
            num9 = 1;
          }
        }
        int num12 = Strings.InStr(str1, "[unitname]");
        if (num12 > 0)
        {
          int num13 = Strings.InStr(str1, "[/unitname]");
          if (num13 > num12 & num13 > 0)
          {
            string name = this.game.Data.UnitObj[(int) Math.Round(Conversion.Val(Strings.Mid(str1, num12 + Strings.Len("[unitname]"), num13 - (num12 + Strings.Len("[unitname]")))))].Name;
            str1 = Strings.Left(str1, num12 - 1) + name + Strings.Mid(str1, num13 + Strings.Len("[/unitname]"));
            num9 = 1;
          }
        }
        int num14 = Strings.InStr(str1, "[hexname]");
        if (num14 > 0)
        {
          int num15 = Strings.InStr(str1, "[/hexname]");
          if (num15 > num14 & num15 > 0)
          {
            string str6 = Strings.Mid(str1, num14 + Strings.Len("[hexname]"), num15 - (num14 + Strings.Len("[hexname]")));
            int num16 = Strings.InStr(str6, ",");
            if (num16 > 0)
            {
              string hexName = this.game.HandyFunctionsObj.GetHexName((int) Math.Round(Conversion.Val(Strings.Left(str6, num16 - 1))), (int) Math.Round(Conversion.Val(Strings.Mid(str6, num16 + 1))), 0);
              str1 = Strings.Left(str1, num14 - 1) + hexName + Strings.Mid(str1, num15 + Strings.Len("[/hexname]"));
              num9 = 1;
            }
          }
        }
      }
      switch (size)
      {
        case 1:
          SizeF sizeF1 = new SizeF();
          string str7 = Strings.UCase(this.game.Data.ActionCardObj[nr].Title);
          SizeF sizeF2 = Expression.MeasureString(str7, this.game.MarcFont16);
          int num17 = 0;
          while ((double) sizeF2.Width > 160.0)
          {
            sizeF2 = Expression.MeasureString(str7, this.game.MarcFont16);
            str7 = Strings.Left(str7, Strings.Len(str7) - 1);
            num17 = 1;
          }
          if (num17 == 1)
            str7 += "...";
          int x1 = (int) Math.Round(4.0 + (88.0 - (double) sizeF2.Width / 2.0));
          DrawMod.DrawTextColouredMarc(ref Expression, str7, this.game.MarcFont16, x1, 13, c);
          string str8 = Strings.Trim(Conversion.Str((object) this.game.Data.ActionCardObj[nr].PPCost));
          if (this.game.Data.ActionCardObj[nr].PPCost == -1)
            str8 = "N/A";
          if (this.game.Data.ActionCardObj[nr].PPCost == 0)
          {
            str8 = "FREE";
            if (this.game.Data.ActionCardObj[nr].HisVarCostType > -1)
              str8 = this.game.Data.ActionCardObj[nr].HisVarCostQty.ToString();
          }
          sizeF2 = Expression.MeasureString(str8, this.game.MarcFont7);
          int x2 = (int) Math.Round(72.0 + (19.0 - (double) sizeF2.Width / 2.0));
          DrawMod.DrawTextColoured(ref Expression, str8, this.game.MarcFont7, x2, 109, Color.White);
          TextAreaClass textAreaClass1 = new TextAreaClass(this.game, 200, 8, this.game.MarcFont8c, "", false, str1, Color.Black, tItemSize: 13, tbackbitmap: (ref bitmap1), bbx: -5, bby: 130, tcenterit: true, tHideShade: true, tBlockScroller: true);
          ref Graphics local73 = ref Expression;
          bitmap2 = textAreaClass1.Paint();
          ref Bitmap local74 = ref bitmap2;
          DrawMod.DrawSimple(ref local73, ref local74, -5, 130);
          break;
        case 2:
          string tText = Strings.UCase(str1);
          SizeF sizeF3 = new SizeF();
          string str9 = Strings.UCase(this.game.Data.ActionCardObj[nr].Title);
          int num18 = 0;
          SizeF sizeF4 = Expression.MeasureString(str9, this.game.MarcFont16);
          while ((double) sizeF4.Width > 122.0)
          {
            sizeF4 = Expression.MeasureString(str9, this.game.MarcFont16);
            str9 = Strings.Left(str9, Strings.Len(str9) - 1);
            num18 = 1;
          }
          if (num18 == 1)
            str9 += "...";
          int x3 = (int) Math.Round(3.0 + (46.0 - (double) Expression.MeasureString(str9, this.game.MarcFont5).Width / 2.0));
          DrawMod.DrawTextColouredMarc(ref Expression, str9, this.game.MarcFont5, x3, 6, c);
          string str10 = Strings.Trim(Conversion.Str((object) this.game.Data.ActionCardObj[nr].PPCost));
          if (this.game.Data.ActionCardObj[nr].PPCost == -1)
            str10 = "N/A";
          if (this.game.Data.ActionCardObj[nr].PPCost == 0)
          {
            str10 = "FREE";
            if (this.game.Data.ActionCardObj[nr].HisVarCostType > -1)
              str10 = this.game.Data.ActionCardObj[nr].HisVarCostQty.ToString();
          }
          int x4 = (int) Math.Round(39.0 + (11.0 - (double) Expression.MeasureString(str10, this.game.MarcFont10).Width / 2.0));
          DrawMod.DrawTextColoured(ref Expression, str10, this.game.MarcFont10, x4, 58, Color.White);
          TextAreaClass textAreaClass2 = new TextAreaClass(this.game, 136, 6, this.game.MarcFont11, "", false, tText, Color.Black, tItemSize: 10, tbackbitmap: (ref bitmap1), bbx: -13, bby: 68, tcenterit: true, tHideShade: true, tBlockScroller: true);
          ref Graphics local75 = ref Expression;
          bitmap2 = textAreaClass2.Paint();
          ref Bitmap local76 = ref bitmap2;
          DrawMod.DrawSimple(ref local75, ref local76, -13, 68);
          if (Shaded)
          {
            DrawMod.DrawBlockGradient2(ref Expression, 0, 0, 100, 145, Color.FromArgb(100, 0, 0, 0), Color.FromArgb(200, 0, 0, 0));
            break;
          }
          break;
        case 3:
          DrawMod.DrawBlock(ref Expression, 3, 25, 25, 1, 0, 0, 0, 195);
          DrawMod.DrawBlock(ref Expression, 3, 29, 18, 1, 0, 0, 0, 185);
          DrawMod.DrawBlock(ref Expression, 3, 3, 16, 1, (int) c.R, (int) c.G, (int) c.B, 200);
          if (Percent > 0)
            DrawMod.DrawTextColoured(ref Expression, Strings.Trim(Conversion.Str((object) Percent)) + "%", this.game.MarcFont9, 3, 31, Color.Black);
          if (Shaded)
          {
            DrawMod.DrawBlockGradient2(ref Expression, 0, 0, 33, 46, Color.FromArgb(100, 0, 0, 0), Color.FromArgb(200, 0, 0, 0));
            break;
          }
          break;
      }
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return bitmap1;
    }

    public Bitmap DrawActionCardSe1(
      int regnr,
      int nr,
      int roundnr = -1,
      int size = 1,
      bool Shaded = false,
      int Percent = 0,
      int tCardId = -1)
    {
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 277, 0, 0));
      Bitmap bitmap1;
      switch (size)
      {
        case 1:
          bitmap1 = new Bitmap(190, 266, PixelFormat.Format32bppPArgb);
          break;
        case 2:
          bitmap1 = new Bitmap(105, 147, PixelFormat.Format32bppPArgb);
          break;
        default:
          bitmap1 = new Bitmap(33, 46, PixelFormat.Format32bppPArgb);
          break;
      }
      bitmap1.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics Expression = Graphics.FromImage((Image) bitmap1);
      Color color = Color.FromArgb((int) byte.MaxValue, 0, (int) byte.MaxValue, 0);
      if (regnr == -1)
        regnr = 0;
      bool flag = false;
      int idValue = tCardId <= 0 ? this.game.Data.ActionCardObj[nr].TempVar0 : tCardId;
      int index1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, idValue, 17)));
      int index2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, idValue, 18)));
      int num1 = 0;
      int index3 = 0;
      int index4 = 0;
      int num2 = 0;
      int num3 = 0;
      if ((int) Math.Round(Conversion.Val(this.game.Data.Designer)) >= 94)
      {
        num1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, idValue, 20)));
        index3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, idValue, 21)));
        index4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, idValue, 22)));
        num2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, idValue, 23)));
        num3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, idValue, 24)));
      }
      if (tCardId > 0)
      {
        int index5 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, idValue, 3)));
        flag = true;
        switch (size)
        {
          case 1:
            ref Graphics local1 = ref Expression;
            Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index5]);
            ref Bitmap local2 = ref bitmap2;
            DrawMod.DrawSimple(ref local1, ref local2, 0, 0);
            break;
          case 2:
            ref Graphics local3 = ref Expression;
            Bitmap bitmap3 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index5]);
            ref Bitmap local4 = ref bitmap3;
            DrawMod.DrawScaled(ref local3, ref local4, 0, 0, 105, 147, true);
            break;
        }
      }
      else if (this.game.Data.ActionCardObj[nr].EventPicNr > -1)
      {
        flag = true;
        switch (size)
        {
          case 1:
            ref Graphics local5 = ref Expression;
            Bitmap bitmap4 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.game.Data.ActionCardObj[nr].EventPicNr]);
            ref Bitmap local6 = ref bitmap4;
            DrawMod.DrawSimple(ref local5, ref local6, 0, 0);
            break;
          case 2:
            ref Graphics local7 = ref Expression;
            Bitmap bitmap5 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.game.Data.ActionCardObj[nr].EventPicNr]);
            ref Bitmap local8 = ref bitmap5;
            DrawMod.DrawScaled(ref local7, ref local8, 0, 0, 105, 147, true);
            break;
        }
      }
      Bitmap from;
      if (num1 > 0 && index3 > 0 & index4 > 0)
      {
        Bitmap bitmap6;
        if (num2 == 1)
        {
          bitmap6 = new Bitmap(190, 266, PixelFormat.Format32bppPArgb);
          bitmap6.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
          from = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index3]);
          DrawMod.CopyPerLine(ref from, ref bitmap6, 0, 0);
          Bitmap bitmap7 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index4]);
          DrawMod.CopyPerLineOnlyAlpha(ref bitmap7, ref bitmap6, 0, 0, 190, 266, 0, 0);
          Expression.CompositingMode = CompositingMode.SourceOver;
          Expression.CompositingQuality = CompositingQuality.HighQuality;
          if (num3 < 1 | num3 % 2 == 0)
          {
            switch (size)
            {
              case 1:
                DrawMod.DrawSimple(ref Expression, ref bitmap6, 0, 0);
                break;
              case 2:
                DrawMod.DrawScaled(ref Expression, ref bitmap6, 0, 0, 105, 147, true);
                break;
            }
          }
          else
          {
            int num4 = num3 % (int) byte.MaxValue;
            switch (size)
            {
              case 1:
                DrawMod.Draw(ref Expression, ref bitmap6, 0, 0, 1f, 1f, 1f, (float) num4 / (float) byte.MaxValue);
                break;
              case 2:
                DrawMod.DrawScaledColorized(ref Expression, ref bitmap6, 0, 0, 105, 147, 190, 266, 1f, 1f, 1f, (float) num4 / (float) byte.MaxValue);
                break;
            }
          }
          bitmap6.Dispose();
        }
        if (num2 == 3)
        {
          bitmap6 = new Bitmap(190, 266, PixelFormat.Format32bppPArgb);
          bitmap6.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
          from = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index3]);
          DrawMod.CopyPerLine(ref from, ref bitmap6, 0, 0);
          Bitmap bitmap8 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index4]);
          DrawMod.CopyPerLineOnlyAlpha(ref bitmap8, ref bitmap6, 0, 0, 190, 266, 0, 0);
          Expression.CompositingMode = CompositingMode.SourceOver;
          Expression.CompositingQuality = CompositingQuality.HighQuality;
          int maxValue = (int) byte.MaxValue;
          switch (size)
          {
            case 1:
              DrawMod.DrawSimple(ref Expression, ref bitmap6, 0, 0);
              break;
            case 2:
              DrawMod.DrawScaledColorized(ref Expression, ref bitmap6, 0, 0, 105, 147, 190, 266, 1f, 1f, 1f, (float) maxValue / (float) byte.MaxValue);
              break;
          }
          bitmap6.Dispose();
        }
        if (num2 == 1)
        {
          bitmap6 = this.game.CustomBitmapObj.DrawLeaderPortrait(this.game.EventRelatedObj.Helper_RollCharacter(-1, this.game.Data.Turn, "SE_Data", fixedRandySeed: num3, justForTempGfxUse: true), 100, 140, transBG: true);
          int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 196, 0, 0));
          this.game.Data.StringListObj[stringListById2].RemoveRow(this.game.Data.StringListObj[stringListById2].Length);
          switch (size)
          {
            case 1:
              DrawMod.DrawScaled(ref Expression, ref bitmap6, 30, 30, 120, 168, true);
              break;
            case 2:
              DrawMod.DrawScaled(ref Expression, ref bitmap6, 15, 17, 60, 84, true);
              break;
          }
          bitmap6.Dispose();
        }
        if (num2 == 3)
        {
          if (size == 1)
          {
            int integer = Conversions.ToInteger(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 144, 0, 0))].GetData(0, num3, 8));
            if (integer > 0)
            {
              int num5 = 0;
              if (BitmapStore.GetWidth(this.game.Data.EventPicNr[integer]) > 190)
                num5 = 1;
              if (BitmapStore.GetWidth(this.game.Data.EventPicNr[integer]) > 360)
                num5 = 2;
              ref Graphics local9 = ref Expression;
              from = BitmapStore.GetBitmap(this.game.Data.EventPicNr[integer]);
              ref Bitmap local10 = ref from;
              Rectangle srcrect = new Rectangle(num5 * 135, 11, 133, 93);
              Rectangle destrect = new Rectangle(20, 50, 150, 105);
              DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect, destrect);
            }
          }
          else if (size != 2)
            ;
        }
      }
      if (size == 1)
      {
        if (index1 > 0)
        {
          ref Graphics local11 = ref Expression;
          from = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index1]);
          ref Bitmap local12 = ref from;
          DrawMod.DrawSimple(ref local11, ref local12, 0, 0);
        }
        else if (this.game.Data.ActionCardObj[nr].ColorScheme <= 0)
        {
          ref Graphics local13 = ref Expression;
          from = BitmapStore.GetBitmap(this.game.MARCCARD1A);
          ref Bitmap local14 = ref from;
          DrawMod.DrawSimple(ref local13, ref local14, 0, 0);
        }
        else if (this.game.Data.ActionCardObj[nr].ColorScheme == 1)
        {
          ref Graphics local15 = ref Expression;
          from = BitmapStore.GetBitmap(this.game.MARCCARD5A);
          ref Bitmap local16 = ref from;
          DrawMod.DrawSimple(ref local15, ref local16, 0, 0);
        }
        else if (this.game.Data.ActionCardObj[nr].ColorScheme == 2)
        {
          ref Graphics local17 = ref Expression;
          from = BitmapStore.GetBitmap(this.game.MARCCARD4A);
          ref Bitmap local18 = ref from;
          DrawMod.DrawSimple(ref local17, ref local18, 0, 0);
        }
        else if (this.game.Data.ActionCardObj[nr].ColorScheme == 3)
        {
          ref Graphics local19 = ref Expression;
          from = BitmapStore.GetBitmap(this.game.MARCCARD6A);
          ref Bitmap local20 = ref from;
          DrawMod.DrawSimple(ref local19, ref local20, 0, 0);
        }
        else if (this.game.Data.ActionCardObj[nr].ColorScheme == 4)
        {
          ref Graphics local21 = ref Expression;
          from = BitmapStore.GetBitmap(this.game.MARCCARD3A);
          ref Bitmap local22 = ref from;
          DrawMod.DrawSimple(ref local21, ref local22, 0, 0);
        }
      }
      else if (size == 2)
      {
        if (index1 > 0)
        {
          ref Graphics local23 = ref Expression;
          from = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index2]);
          ref Bitmap local24 = ref from;
          DrawMod.DrawSimple(ref local23, ref local24, 0, 0);
        }
        else if (this.game.Data.ActionCardObj[nr].ColorScheme <= 0)
        {
          ref Graphics local25 = ref Expression;
          from = BitmapStore.GetBitmap(this.game.MARCCARD1B);
          ref Bitmap local26 = ref from;
          DrawMod.DrawSimple(ref local25, ref local26, 0, 0);
        }
        else if (this.game.Data.ActionCardObj[nr].ColorScheme == 1)
        {
          ref Graphics local27 = ref Expression;
          from = BitmapStore.GetBitmap(this.game.MARCCARD5B);
          ref Bitmap local28 = ref from;
          DrawMod.DrawSimple(ref local27, ref local28, 0, 0);
        }
        else if (this.game.Data.ActionCardObj[nr].ColorScheme == 2)
        {
          ref Graphics local29 = ref Expression;
          from = BitmapStore.GetBitmap(this.game.MARCCARD4B);
          ref Bitmap local30 = ref from;
          DrawMod.DrawSimple(ref local29, ref local30, 0, 0);
        }
        else if (this.game.Data.ActionCardObj[nr].ColorScheme == 3)
        {
          ref Graphics local31 = ref Expression;
          from = BitmapStore.GetBitmap(this.game.MARCCARD6B);
          ref Bitmap local32 = ref from;
          DrawMod.DrawSimple(ref local31, ref local32, 0, 0);
        }
        else if (this.game.Data.ActionCardObj[nr].ColorScheme == 4)
        {
          ref Graphics local33 = ref Expression;
          from = BitmapStore.GetBitmap(this.game.MARCCARD3B);
          ref Bitmap local34 = ref from;
          DrawMod.DrawSimple(ref local33, ref local34, 0, 0);
        }
      }
      else if (this.game.Data.ActionCardObj[nr].ColorScheme <= 0)
      {
        ref Graphics local35 = ref Expression;
        from = BitmapStore.GetBitmap(this.game.MARCCARD1C);
        ref Bitmap local36 = ref from;
        DrawMod.DrawSimple(ref local35, ref local36, 0, 0);
      }
      else if (this.game.Data.ActionCardObj[nr].ColorScheme == 1)
      {
        ref Graphics local37 = ref Expression;
        from = BitmapStore.GetBitmap(this.game.MARCCARD5C);
        ref Bitmap local38 = ref from;
        DrawMod.DrawSimple(ref local37, ref local38, 0, 0);
      }
      else if (this.game.Data.ActionCardObj[nr].ColorScheme == 2)
      {
        ref Graphics local39 = ref Expression;
        from = BitmapStore.GetBitmap(this.game.MARCCARD4C);
        ref Bitmap local40 = ref from;
        DrawMod.DrawSimple(ref local39, ref local40, 0, 0);
      }
      else if (this.game.Data.ActionCardObj[nr].ColorScheme == 3)
      {
        ref Graphics local41 = ref Expression;
        from = BitmapStore.GetBitmap(this.game.MARCCARD6C);
        ref Bitmap local42 = ref from;
        DrawMod.DrawSimple(ref local41, ref local42, 0, 0);
      }
      else if (this.game.Data.ActionCardObj[nr].ColorScheme == 4)
      {
        ref Graphics local43 = ref Expression;
        from = BitmapStore.GetBitmap(this.game.MARCCARD3C);
        ref Bitmap local44 = ref from;
        DrawMod.DrawSimple(ref local43, ref local44, 0, 0);
      }
      string str1 = tCardId <= 0 ? this.game.Data.ActionCardObj[nr].Text : this.game.Data.StringListObj[stringListById1].GetData(0, idValue, 4);
      Color c = Color.FromArgb((int) byte.MaxValue, 180, (int) byte.MaxValue, 180);
      Color tfontcol = Color.FromArgb((int) byte.MaxValue, 225, (int) byte.MaxValue, 225);
      if (tCardId < 1)
      {
        if (this.game.Data.ActionCardObj[nr].ColorScheme == 1)
        {
          c = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 180);
          tfontcol = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 225);
        }
        if (this.game.Data.ActionCardObj[nr].ColorScheme == 2)
        {
          c = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 180, 180);
          tfontcol = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 225, 225);
        }
        if (this.game.Data.ActionCardObj[nr].ColorScheme == 4)
        {
          c = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 240, 225);
          tfontcol = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 250, 245);
        }
        if (this.game.Data.ActionCardObj[nr].ColorScheme == 3)
        {
          c = Color.FromArgb((int) byte.MaxValue, 215, (int) byte.MaxValue, (int) byte.MaxValue);
          tfontcol = Color.FromArgb((int) byte.MaxValue, 240, (int) byte.MaxValue, (int) byte.MaxValue);
        }
      }
      if (index1 > 0)
      {
        c = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        tfontcol = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
      }
      int num6;
      int num7;
      switch (size)
      {
        case 1:
          SizeF sizeF1 = new SizeF();
          string str2 = tCardId <= 0 ? this.game.Data.ActionCardObj[nr].Title : this.game.Data.StringListObj[stringListById1].GetData(0, idValue, 1);
          SizeF sizeF2 = Expression.MeasureString(str2, this.game.se1TypeWriterBig2);
          num6 = 0;
          num7 = 0;
          SizeF sizeF3;
          if ((double) sizeF2.Width > 170.0)
          {
            string[] strArray = str2.Split(new char[1]
            {
              ' '
            }, StringSplitOptions.RemoveEmptyEntries);
            string str3 = strArray[0];
            sizeF3 = Expression.MeasureString(str3, this.game.se1TypeWriterBig2);
            num6 = (int) Math.Round(6.0 + (88.0 - (double) sizeF3.Width / 2.0));
            int num8 = 0;
            if (strArray.GetUpperBound(0) > 1)
            {
              str3 = strArray[0] + " " + strArray[1];
              sizeF3 = Expression.MeasureString(str3, this.game.se1TypeWriterBig2);
              num8 = (int) Math.Round(6.0 + (88.0 - (double) sizeF3.Width / 2.0));
            }
            int x1;
            if (num8 > 0 & (double) sizeF3.Width < 170.0)
            {
              x1 = num8;
            }
            else
            {
              num8 = 0;
              str3 = strArray[0];
              sizeF3 = Expression.MeasureString(str3, this.game.se1TypeWriterBig2);
              x1 = (int) Math.Round(6.0 + (88.0 - (double) sizeF3.Width / 2.0));
            }
            if (num8 > 0)
              num8 = 1;
            DrawMod.DrawTextColouredConsole(ref Expression, str3, this.game.se1TypeWriterBig2, x1, 0, c);
            string str4 = "";
            int num9 = 1 + num8;
            int upperBound = strArray.GetUpperBound(0);
            for (int index6 = num9; index6 <= upperBound; ++index6)
            {
              if (index6 > 1)
                str4 += " ";
              str4 += strArray[index6];
            }
            if (str4.Length > 0)
            {
              num7 = 1;
              sizeF3 = Expression.MeasureString(str4, this.game.se1TypeWriterBig2);
              int x2 = (int) Math.Round(6.0 + (88.0 - (double) sizeF3.Width / 2.0));
              DrawMod.DrawTextColouredConsole(ref Expression, str4, this.game.se1TypeWriterBig2, x2, 13, c);
            }
          }
          else
          {
            int num10 = (int) Math.Round((double) sizeF2.Width);
            sizeF2 = Expression.MeasureString(str2, this.game.se1TypeWriterBig);
            if ((double) sizeF2.Width < 170.0)
            {
              int x = (int) Math.Round(6.0 + (88.0 - (double) sizeF2.Width / 2.0));
              DrawMod.DrawTextColouredConsole(ref Expression, str2, this.game.se1TypeWriterBig, x, 4, c);
            }
            else
            {
              int x = (int) Math.Round(6.0 + (88.0 - (double) num10 / 2.0));
              DrawMod.DrawTextColouredConsole(ref Expression, str2, this.game.se1TypeWriterBig2, x, 6, c);
            }
          }
          if (tCardId < 1)
          {
            string str5 = this.game.Data.ActionCardObj[nr].PPCost.ToString();
            if (this.game.Data.ActionCardObj[nr].PPCost == -1)
              str5 = "N/A";
            if (this.game.Data.ActionCardObj[nr].PPCost == 0)
            {
              str5 = "FREE";
              if (this.game.Data.ActionCardObj[nr].customCostType > -1 & this.game.Data.ActionCardObj[nr].customCostQty > 0)
                str5 = this.game.Data.ActionCardObj[nr].customCostQty.ToString();
            }
            sizeF3 = Expression.MeasureString(str5, this.game.shadowFontConsole2);
            int x3 = (int) Math.Round(122.0 + (29.0 - ((double) sizeF3.Width + 16.0) / 2.0) + 8.0);
            if (this.game.Data.ActionCardObj[nr].PPCost > 0 | this.game.Data.ActionCardObj[nr].customCostQty > 0)
              x3 -= 8;
            DrawMod.DrawTextColouredConsole(ref Expression, str5, this.game.shadowFontConsole2, x3, 160, c);
            int num11 = (int) Math.Round((double) x3 + (double) sizeF3.Width - 8.0);
            if (this.game.Data.ActionCardObj[nr].PPCost > 0 | this.game.Data.ActionCardObj[nr].customCostQty > 0)
            {
              if (this.game.Data.ActionCardObj[nr].customCostType == 1)
              {
                int eventPicSlotFor = this.game.EventRelatedObj.GetEventPicSlotFor(0, "", "fp");
                ref Graphics local45 = ref Expression;
                from = BitmapStore.GetBitmap(this.game.Data.EventPicNr[eventPicSlotFor]);
                ref Bitmap local46 = ref from;
                int x4 = num11;
                DrawMod.DrawSimple(ref local45, ref local46, x4, 164);
              }
              else
              {
                int eventPicSlotFor = this.game.EventRelatedObj.GetEventPicSlotFor(0, "", "pp");
                ref Graphics local47 = ref Expression;
                from = BitmapStore.GetBitmap(this.game.Data.EventPicNr[eventPicSlotFor]);
                ref Bitmap local48 = ref from;
                int x5 = num11;
                DrawMod.DrawSimple(ref local47, ref local48, x5, 164);
              }
            }
          }
          string tText1 = str1;
          int num12 = (int) Math.Round((double) (75 - new TextAreaClass(this.game, 230, 4, this.game.se1TypeWriterSmall, "", false, tText1, tfontcol, tItemSize: 13, tbackbitmap: (ref bitmap1), bbx: -20, bby: 189, tcenterit: true, tHideShade: true, tBlockScroller: true).HeightUsed()) / 2.0);
          TextAreaClass textAreaClass1 = new TextAreaClass(this.game, 230, 4, this.game.se1TypeWriterSmall, "", false, tText1, tfontcol, tItemSize: 13, tbackbitmap: (ref bitmap1), bbx: -16, bby: (179 + num12), tcenterit: true, tHideShade: true, tBlockScroller: true);
          ref Graphics local49 = ref Expression;
          from = textAreaClass1.Paint();
          ref Bitmap local50 = ref from;
          int y1 = 179 + num12;
          DrawMod.DrawSimple(ref local49, ref local50, -16, y1);
          break;
        case 2:
          SizeF sizeF4 = new SizeF();
          string str6 = tCardId <= 0 ? this.game.Data.ActionCardObj[nr].Title : this.game.Data.StringListObj[stringListById1].GetData(0, idValue, 1);
          num6 = 0;
          SizeF sizeF5 = Expression.MeasureString(str6, this.game.se1TypeWriterBig3);
          num7 = 0;
          SizeF sizeF6;
          if ((double) sizeF5.Width > 100.0)
          {
            string[] strArray = str6.Split(new char[1]
            {
              ' '
            }, StringSplitOptions.RemoveEmptyEntries);
            string str7 = strArray[0];
            sizeF6 = Expression.MeasureString(str7, this.game.se1TypeWriterBig3);
            num6 = (int) Math.Round(6.0 + (44.0 - (double) sizeF6.Width / 2.0));
            int num13 = 0;
            if (strArray.GetUpperBound(0) > 1)
            {
              str7 = strArray[0] + " " + strArray[1];
              sizeF6 = Expression.MeasureString(str7, this.game.se1TypeWriterBig3);
              num13 = (int) Math.Round(6.0 + (88.0 - (double) sizeF6.Width / 2.0));
            }
            if (num13 > 0 & (double) sizeF6.Width < 80.0)
            {
              num6 = num13;
            }
            else
            {
              num13 = 0;
              str7 = strArray[0];
              sizeF6 = Expression.MeasureString(str7, this.game.se1TypeWriterBig3);
              num6 = (int) Math.Round(6.0 + (44.0 - (double) sizeF6.Width / 2.0));
            }
            if (num13 > 0)
              num13 = 1;
            int x6 = (int) Math.Round(6.0 + (46.0 - (double) sizeF6.Width / 2.0));
            DrawMod.DrawTextColouredConsole(ref Expression, str7, this.game.se1TypeWriterBig3, x6, -2, c);
            string str8 = "";
            int num14 = 1 + num13;
            int upperBound = strArray.GetUpperBound(0);
            for (int index7 = num14; index7 <= upperBound; ++index7)
            {
              if (index7 > 1)
                str8 += " ";
              str8 += strArray[index7];
            }
            if (str8.Length > 0)
            {
              num7 = 1;
              sizeF6 = Expression.MeasureString(str8, this.game.se1TypeWriterBig3);
              int x7 = (int) Math.Round(6.0 + (46.0 - (double) sizeF6.Width / 2.0));
              DrawMod.DrawTextColouredConsole(ref Expression, str8, this.game.se1TypeWriterBig3, x7, 8, c);
            }
          }
          else
          {
            int x = (int) Math.Round(6.0 + (46.0 - (double) sizeF5.Width / 2.0));
            DrawMod.DrawTextColouredConsole(ref Expression, str6, this.game.se1TypeWriterBig3, x, 3, c);
          }
          int eventPicSlotFor1;
          if (tCardId < 1)
          {
            string str9 = this.game.Data.ActionCardObj[nr].PPCost.ToString();
            if (this.game.Data.ActionCardObj[nr].PPCost == -1)
              str9 = "N/A";
            if (this.game.Data.ActionCardObj[nr].PPCost == 0)
            {
              str9 = "FREE";
              if (this.game.Data.ActionCardObj[nr].customCostType > -1 & this.game.Data.ActionCardObj[nr].customCostQty > 0)
                str9 = this.game.Data.ActionCardObj[nr].customCostQty.ToString();
            }
            sizeF6 = Expression.MeasureString(str9, this.game.shadowFontConsole);
            int x8 = (int) Math.Round(58.0 + (25.0 - (double) sizeF6.Width / 2.0) - 3.0);
            if (this.game.Data.ActionCardObj[nr].PPCost > 0 | this.game.Data.ActionCardObj[nr].customCostQty > 0)
              x8 -= 5;
            DrawMod.DrawTextColouredConsole(ref Expression, str9, this.game.shadowFontConsole, x8, 87, c);
            int num15 = (int) Math.Round((double) x8 + (double) sizeF6.Width - 10.0);
            if (this.game.Data.ActionCardObj[nr].PPCost > 0 | this.game.Data.ActionCardObj[nr].customCostQty > 0)
            {
              if (this.game.Data.ActionCardObj[nr].customCostType == 1)
              {
                eventPicSlotFor1 = this.game.EventRelatedObj.GetEventPicSlotFor(0, "", "fp");
                ref Graphics local51 = ref Expression;
                from = BitmapStore.GetBitmap(this.game.Data.EventPicNr[eventPicSlotFor1]);
                ref Bitmap local52 = ref from;
                int x9 = num15 + 1;
                DrawMod.DrawSimple(ref local51, ref local52, x9, 85);
              }
              else
              {
                eventPicSlotFor1 = this.game.EventRelatedObj.GetEventPicSlotFor(0, "", "pp");
                ref Graphics local53 = ref Expression;
                from = BitmapStore.GetBitmap(this.game.Data.EventPicNr[eventPicSlotFor1]);
                ref Bitmap local54 = ref from;
                int x10 = num15 + 1;
                DrawMod.DrawSimple(ref local53, ref local54, x10, 85);
              }
            }
          }
          string tText2 = str1;
          int num16 = (int) Math.Round(Math.Max(0.0, (double) (27 - new TextAreaClass(this.game, 150, 3, this.game.shadowFontConsole3, "", false, tText2, tfontcol, tItemSize: 8, tbackbitmap: (ref bitmap1), bbx: -18, bby: (103 + eventPicSlotFor1), tcenterit: true, tHideShade: true, tBlockScroller: true).HeightUsed()) / 2.0));
          TextAreaClass textAreaClass2 = new TextAreaClass(this.game, 150, 3, this.game.shadowFontConsole3, "", false, tText2, tfontcol, tItemSize: 8, tbackbitmap: (ref bitmap1), bbx: -18, bby: (103 + num16), tcenterit: true, tHideShade: true, tBlockScroller: true);
          ref Graphics local55 = ref Expression;
          from = textAreaClass2.Paint();
          ref Bitmap local56 = ref from;
          int y2 = 103 + num16;
          DrawMod.DrawSimple(ref local55, ref local56, -18, y2);
          if (!Shaded)
            break;
          break;
        case 3:
          DrawMod.DrawBlock(ref Expression, 3, 25, 25, 1, 0, 0, 0, 195);
          DrawMod.DrawBlock(ref Expression, 3, 29, 18, 1, 0, 0, 0, 185);
          DrawMod.DrawBlock(ref Expression, 3, 3, 16, 1, (int) color.R, (int) color.G, (int) color.B, 200);
          break;
      }
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return bitmap1;
    }

    public void InitializeTextureRelatedStuff()
    {
      if ((double) this.game.Data.RuleVar[451] > 0.0 & this.game.Data.Product >= 7)
      {
        int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[451]));
        int length = this.game.Data.StringListObj[stringListById].Length;
        for (int index1 = 0; index1 <= length; ++index1)
        {
          if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index1, 0])) > 0)
          {
            string str = this.game.Data.StringListObj[stringListById].Data[index1, 1];
            int fr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index1, 2]));
            int num = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index1, 3]));
            int fb = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index1, 4]));
            int tr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index1, 5]));
            int tg = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index1, 6]));
            int tb = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index1, 7]));
            bool flag = false;
            if (Strings.InStr(str, "Forests") > 0)
              str = str;
            if (Operators.CompareString(Strings.Trim(Strings.LCase(this.game.Data.StringListObj[stringListById].Data[index1, 2])), "reload", false) == 0)
              BitmapStore.ReloadBeforeRecolor(str, this.game.Data.StringListObj[stringListById].Data[index1, 3]);
            else
              flag = Operators.CompareString(Strings.Trim(Strings.LCase(this.game.Data.StringListObj[stringListById].Data[index1, 2])), "gray", false) == 0 ? BitmapStore.ModifyColorOfNameInstrToGray(str, num) : BitmapStore.ModifyColorOfNameInstr(str, fr, num, fb, tr, tg, tb);
            if ((double) this.game.Data.RuleVar[998] == 1.0 & flag)
            {
              int landscapeTypeCounter = this.game.Data.LandscapeTypeCounter;
              for (int index2 = 0; index2 <= landscapeTypeCounter; ++index2)
              {
                this.game.Data.LandscapeTypeObj[index2].TempHexBitmap = (Bitmap) null;
                if (this.game.Data.LandscapeTypeObj[index2].UsePreHexTexture && Strings.InStr(Strings.LCase(this.game.Data.LandscapeTypeObj[index2].PreHexTextureFileName).Replace("\\", "/").Replace("//", "/"), Strings.Trim(Strings.LCase(str))) > 0)
                {
                  int preHexTextureId = this.game.Data.LandscapeTypeObj[index2].PreHexTextureID;
                  if (preHexTextureId > -1 & BitmapStore.simpleByteCacheSet[preHexTextureId])
                    BitmapStore.simpleByteCacheSet[preHexTextureId] = false;
                }
              }
            }
          }
        }
      }
      if ((double) this.game.Data.RuleVar[998] == 1.0)
      {
        try
        {
          DrawMod.TGame.FormRef.Cursor = Cursors.WaitCursor;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
        if (Information.IsNothing((object) this.game.CustomBitmapObj.tempHexSmall))
        {
          this.game.CustomBitmapObj.tempHexSmall = new Bitmap(32, 24, PixelFormat.Format32bppPArgb);
          this.game.CustomBitmapObj.tempHexSmall.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
          this.game.CustomBitmapObj.tempHexMed = new Bitmap(64, 48, PixelFormat.Format32bppPArgb);
          this.game.CustomBitmapObj.tempHexMed.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
          this.game.CustomBitmapObj.tempHexBig = new Bitmap(128, 96, PixelFormat.Format32bppPArgb);
          this.game.CustomBitmapObj.tempHexBig.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        }
      }
      if ((double) this.game.Data.RuleVar[998] != 1.0)
        return;
      int landscapeTypeCounter1 = this.game.Data.LandscapeTypeCounter;
      Bitmap bitmap1;
      for (int index = 0; index <= landscapeTypeCounter1; ++index)
      {
        if (this.game.Data.LandscapeTypeObj[index].UsePreHexTexture | this.game.Data.LandscapeTypeObj[index].UsePreHexBorderTexture)
        {
          int preHexTextureId = this.game.Data.LandscapeTypeObj[index].PreHexTextureID;
          int sheetSpriteId1 = this.game.Data.LandscapeTypeObj[index].SheetSpriteID;
          if (!BitmapStore.simpleByteCacheSet[preHexTextureId])
          {
            if (this.game.Data.LandscapeTypeObj[index].UsePreHexTexture)
            {
              BitmapStore.simpleByteCacheObj[preHexTextureId] = new SimpleByteCache();
              SimpleByteCache simpleByteCache = BitmapStore.simpleByteCacheObj[preHexTextureId];
              Bitmap bitmap2 = BitmapStore.GetBitmap(preHexTextureId);
              ref Bitmap local1 = ref bitmap2;
              Bitmap bitmap3 = BitmapStore.GetBitmap(preHexTextureId, 1);
              ref Bitmap local2 = ref bitmap3;
              bitmap1 = BitmapStore.GetBitmap(preHexTextureId, -1);
              ref Bitmap local3 = ref bitmap1;
              int bitmapNr = preHexTextureId;
              simpleByteCache.SetMultiRGBCache(ref local1, ref local2, ref local3, bitmapNr);
            }
            BitmapStore.simpleByteCacheSet[preHexTextureId] = true;
          }
          if (!BitmapStore.simpleByteCacheSet[sheetSpriteId1])
          {
            if (this.game.Data.LandscapeTypeObj[index].UseSheet & this.game.Data.LandscapeTypeObj[index].UsePreHexBorderTexture)
            {
              BitmapStore.simpleByteCacheObj[sheetSpriteId1] = new SimpleByteCache();
              SimpleByteCache simpleByteCache = BitmapStore.simpleByteCacheObj[sheetSpriteId1];
              bitmap1 = BitmapStore.GetBitmap(this.game.Data.LandscapeTypeObj[index].SheetSpriteID);
              ref Bitmap local4 = ref bitmap1;
              Bitmap bitmap4 = BitmapStore.GetBitmap(this.game.Data.LandscapeTypeObj[index].SheetSpriteID, 1);
              ref Bitmap local5 = ref bitmap4;
              Bitmap bitmap5 = BitmapStore.GetBitmap(this.game.Data.LandscapeTypeObj[index].SheetSpriteID, -1);
              ref Bitmap local6 = ref bitmap5;
              int sheetSpriteId2 = this.game.Data.LandscapeTypeObj[index].SheetSpriteID;
              simpleByteCache.SetSingleFredAlphaCache(ref local4, ref local5, ref local6, sheetSpriteId2);
            }
            BitmapStore.simpleByteCacheSet[sheetSpriteId1] = true;
          }
        }
      }
      if (!BitmapStore.simpleByteCacheSet[this.game.WHITEHEX])
      {
        BitmapStore.simpleByteCacheObj[this.game.WHITEHEX] = new SimpleByteCache();
        SimpleByteCache simpleByteCache = BitmapStore.simpleByteCacheObj[this.game.WHITEHEX];
        bitmap1 = BitmapStore.GetBitmap(this.game.WHITEHEX);
        ref Bitmap local7 = ref bitmap1;
        Bitmap bitmap6 = BitmapStore.GetBitmap(this.game.WHITEHEX, 1);
        ref Bitmap local8 = ref bitmap6;
        Bitmap bitmap7 = BitmapStore.GetBitmap(this.game.WHITEHEX, -1);
        ref Bitmap local9 = ref bitmap7;
        simpleByteCache.SetSingleAlphaCache(ref local7, ref local8, ref local9);
        BitmapStore.simpleByteCacheSet[this.game.WHITEHEX] = true;
      }
      try
      {
        DrawMod.TGame.FormRef.Cursor = Cursors.Default;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public void MakeMiniMap(
      Bitmap tempBmp,
      int bwidth,
      int bheight,
      bool alsounits,
      bool realhex = false,
      bool alsoshading = true,
      bool predrawn = false,
      int humanplayer = -1,
      bool showflag = false,
      bool alsoHQ = false,
      int highlightTempvar4 = -1,
      bool useTempVar3asAlpha = false,
      bool useTempAi2 = false,
      bool useTempZones = false,
      int specialMode1 = -1)
    {
      SizeF sizeF = new SizeF();
      bool[] flagArray = new bool[this.game.Data.RegimeCounter + 99 + 1];
      int[] numArray1 = new int[this.game.Data.RegimeCounter + 99 + 1];
      int[] numArray2 = new int[this.game.Data.RegimeCounter + 99 + 1];
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 275, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 288, 0, 0));
      int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 143, 0, 0));
      int stringListById4 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Random", 86, 0, 0));
      int stringListById5 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 148, 0, 0));
      int num1 = 0;
      if (stringListById4 > 0)
        num1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData(0, 84, 2)));
      int libVar1;
      int libVar2;
      int libVar3;
      int libVar4;
      int libVar5;
      int libVar6;
      int libVar7;
      string str1;
      int libVar8;
      if (specialMode1 > 0)
      {
        DataClass data1 = this.game.Data;
        string str2 = "MiningType";
        ref string local1 = ref str2;
        libVar1 = data1.FindLibVar(ref local1, "SE_Data");
        DataClass data2 = this.game.Data;
        string str3 = "MiningDiscovery";
        ref string local2 = ref str3;
        libVar2 = data2.FindLibVar(ref local2, "SE_Data");
        DataClass data3 = this.game.Data;
        string str4 = "MiningReserve";
        ref string local3 = ref str4;
        libVar3 = data3.FindLibVar(ref local3, "SE_Data");
        DataClass data4 = this.game.Data;
        str4 = "Rain";
        ref string local4 = ref str4;
        libVar4 = data4.FindLibVar(ref local4, "SE_Data");
        DataClass data5 = this.game.Data;
        str4 = "Temperature";
        ref string local5 = ref str4;
        libVar5 = data5.FindLibVar(ref local5, "SE_Data");
        DataClass data6 = this.game.Data;
        string str5 = "rad";
        ref string local6 = ref str5;
        libVar6 = data6.FindLibVar(ref local6, "SE_Data");
        DataClass data7 = this.game.Data;
        string str6 = "HeightMap";
        ref string local7 = ref str6;
        data7.FindLibVar(ref local7, "SE_Random");
        DataClass data8 = this.game.Data;
        str6 = "TectonicPlates";
        ref string local8 = ref str6;
        libVar7 = data8.FindLibVar(ref local8, "SE_Random");
        DataClass data9 = this.game.Data;
        str1 = "Scavenge";
        ref string local9 = ref str1;
        libVar8 = data9.FindLibVar(ref local9, "SE_Data");
      }
      flagArray[0] = true;
      flagArray[1] = true;
      int Index = this.game.Data.Turn;
      if (this.game.EditObj.AIMoving && this.game.EditObj.HumanPlayer > -1)
        Index = this.game.EditObj.HumanPlayer;
      int regimeCounter1 = this.game.Data.RegimeCounter;
      for (int index = 2; index <= regimeCounter1; ++index)
      {
        int num2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData(0, this.game.Data.RegimeObj[index].id, 1)));
        if ((num2 == 2 | num2 == 3) & this.game.Data.Round > 0 && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData3(0, this.game.Data.RegimeObj[index].id, 1, this.game.Data.RegimeObj[Index].id, 2, "dipClear", 3))) < 1)
          flagArray[index] = true;
        if (Index > -1)
        {
          int num3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData3(0, this.game.Data.RegimeObj[index].id, 1, this.game.Data.RegimeObj[Index].id, 2, "relation", 3)));
          numArray1[index] = num3;
          int num4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData(0, this.game.Data.RegimeObj[index].id, 1)));
          numArray2[index] = num4;
        }
      }
      DataClass data = this.game.Data;
      str1 = "zones";
      ref string local10 = ref str1;
      int libVar9 = data.FindLibVar(ref local10, "SE_Data");
      DrawMod.TGame.CustomBitmapObj.InitializeTextureRelatedStuff();
      Graphics Expression = Graphics.FromImage((Image) tempBmp);
      if (!predrawn | Information.IsNothing((object) this.miniMapPredrawnCache) && !predrawn)
      {
        DrawMod.Clear(ref Expression, 0, 0, 0);
        DrawMod.Clear(ref Expression, 60, 60, 60);
        Pen pen = new Pen(Color.FromArgb((int) byte.MaxValue, 80, 80, 80));
        int num5 = -this.game.ScreenHeight + this.game.ScreenHeight % 6;
        int screenHeight = this.game.ScreenHeight;
        for (int index = 3; index <= screenHeight; index += 6)
        {
          int x1 = 0;
          int y1 = index;
          int screenWidth = this.game.ScreenWidth;
          int y2 = index;
          Expression.DrawLine(pen, x1, y1, screenWidth, y2);
        }
      }
      if (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth == -1 | this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight == -1)
        return;
      float d1 = (float) bwidth / (float) (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1);
      float d2 = (float) bheight / (float) (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1);
      if (bwidth > 310)
      {
        d1 = (float) Math.Floor((double) d1);
        d2 = (float) Math.Floor((double) d2);
      }
      int num6;
      if ((double) d1 > (double) d2)
      {
        num6 = (int) Math.Round((double) bwidth / 2.0 - (double) d2 / (double) d1 * ((double) bwidth / 2.0));
        d1 = d2;
      }
      int num7;
      if ((double) d2 > (double) d1)
      {
        num7 = (int) Math.Round((double) bheight / 2.0 - (double) d1 / (double) d2 * ((double) bheight / 2.0));
        d2 = d1;
      }
      if (bwidth > 310)
      {
        int num8 = (int) Math.Round((double) ((float) bwidth - (float) (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1) * d1));
        if (num8 > 0)
        {
          int num9 = (int) Math.Round((double) num8 / 2.0);
          if (num9 > num6)
            num6 = num9;
        }
      }
      if (bheight > 220)
      {
        int num10 = (int) Math.Round((double) ((float) bheight - (float) (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1) * d2));
        if (num10 > 0)
        {
          int num11 = (int) Math.Round((double) num10 / 2.0);
          if (num11 > num7)
            num7 = num11;
        }
      }
      float num12 = d1;
      float num13 = d2;
      int index1 = Index;
      if (humanplayer > -1 & this.game.EditObj.AIMoving)
        index1 = humanplayer;
      bool flag1;
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (realhex & Information.IsNothing((object) this.miniMapPredrawnCache))
      {
        this.miniMapPredrawnCache = (Bitmap) tempBmp.Clone();
        Graphics graphics = Graphics.FromImage((Image) this.miniMapPredrawnCache);
        int mapWidth = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth;
        for (int index2 = 0; index2 <= mapWidth; ++index2)
        {
          int mapHeight = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight;
          for (int index3 = 0; index3 <= mapHeight; ++index3)
          {
            int index4 = index2;
            int index5 = index3;
            if (this.game.EditObj.MiniMapOffset > 0)
            {
              index4 += this.game.EditObj.MiniMapOffset;
              if (index4 > this.game.Data.MapObj[0].MapWidth)
                index4 -= this.game.Data.MapObj[0].MapWidth + 1;
            }
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index4, index5].LandscapeType > -1)
            {
              int x = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num12) * (double) index2 + (double) num6)));
              int y = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num13) * (double) index3) - Math.Floor((double) d2 / 2.0) + (double) num7));
              if ((index2 + 10) % 2 > 0)
                y = (int) Math.Round((double) y + Math.Floor((double) d2 / 2.0));
              int width = (int) Math.Round(Math.Floor((double) num12));
              int height = (int) Math.Round(Math.Floor((double) num13));
              flag1 = false;
              int num14 = (int) Math.Round((double) this.game.Data.RuleVar[330]);
              this.game.Data.RuleVar[330] = 0.0f;
              bool fowOn = this.game.Data.FOWOn;
              this.game.Data.FOWOn = false;
              ref Graphics local11 = ref graphics;
              int cx = index4;
              int cy = index5;
              int mapSelected = this.game.EditObj.MapSelected;
              Bitmap bitmap1 = (Bitmap) null;
              ref Bitmap local12 = ref bitmap1;
              bool flag2 = false;
              ref bool local13 = ref flag2;
              Bitmap bitmap2 = this.DrawHex(cx, cy, mapSelected, true, true, true, Zoom: -1, gBitmap: (ref local12), tFromMapPopup: (ref local13));
              ref Bitmap local14 = ref bitmap2;
              rectangle1 = new Rectangle(6, 0, 20, 24);
              Rectangle srcrect = rectangle1;
              rectangle2 = new Rectangle(x, y, width, height);
              Rectangle destrect = rectangle2;
              DrawMod.DrawSimplePart2(ref local11, ref local14, srcrect, destrect);
              this.game.Data.FOWOn = fowOn;
              this.game.Data.RuleVar[330] = (float) num14;
            }
          }
        }
        graphics.Dispose();
        Expression.DrawImageUnscaled((Image) this.miniMapPredrawnCache, 0, 0);
      }
      else if (!predrawn & !Information.IsNothing((object) this.miniMapPredrawnCache) & realhex)
        Expression.DrawImageUnscaled((Image) this.miniMapPredrawnCache, 0, 0);
      int mapWidth1 = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth;
      bool flag3;
      Bitmap bitmap;
      Coordinate coordinate;
      for (int index6 = 0; index6 <= mapWidth1; ++index6)
      {
        int mapHeight = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight;
        for (int index7 = 0; index7 <= mapHeight; ++index7)
        {
          int cx = index6;
          int cy = index7;
          if (this.game.EditObj.MiniMapOffset > 0)
          {
            cx += this.game.EditObj.MiniMapOffset;
            if (cx > this.game.Data.MapObj[0].MapWidth)
              cx -= this.game.Data.MapObj[0].MapWidth + 1;
          }
          if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].LandscapeType > -1)
          {
            int num15;
            int num16;
            int num17;
            int num18;
            if (!realhex)
            {
              num15 = (int) Math.Round((double) (Conversion.Int(num12 * (float) index6) + (float) num6));
              num16 = (int) Math.Round((double) (Conversion.Int(num13 * (float) index7) - d2 / 2f + (float) num7));
              if ((index6 + 10) % 2 > 0)
                num16 = (int) Math.Round((double) ((float) num16 + d2 / 2f));
              num17 = (int) Math.Round((double) (num12 + 1f));
              num18 = (int) Math.Round((double) (num13 + 1f));
            }
            else
            {
              num15 = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num12) * (double) index6 + (double) num6)));
              num16 = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num13) * (double) index7) - Math.Floor((double) d2 / 2.0) + (double) num7));
              int num19 = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num13) * (double) (index7 + 1)) - Math.Floor((double) d2 / 2.0) + (double) num7));
              if ((index6 + 10) % 2 > 0)
                num16 = (int) Math.Round((double) num16 + Math.Floor((double) d2 / 2.0));
              if ((index6 + 10) % 2 > 0)
                num19 = (int) Math.Round((double) num19 + Math.Floor((double) d2 / 2.0));
              num17 = (int) Math.Round(Math.Floor((double) num12));
              num18 = num19 - num16;
              if ((double) num18 != Math.Floor((double) num13))
                num18 = num18;
            }
            bool flag4 = false;
            bool flag5 = false;
            Color color;
            int index8;
            if (!this.game.Data.ShrowdOn)
            {
              if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].LandscapeType].Red == -1)
              {
                if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].LandscapeType].IsSea)
                {
                  color = Color.FromArgb((int) byte.MaxValue, 0, 0, 150);
                }
                else
                {
                  index8 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].Regime;
                  if (index8 == -1)
                  {
                    color = Color.FromArgb((int) byte.MaxValue, 40, 200, 60);
                  }
                  else
                  {
                    if (flagArray[index8])
                      index8 = 1;
                    color = Color.FromArgb((int) byte.MaxValue, this.game.Data.RegimeObj[index8].Red, this.game.Data.RegimeObj[index8].Green, this.game.Data.RegimeObj[index8].Blue);
                  }
                  if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].Location > -1 & num17 >= 4 & num18 >= 4 && this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].Location].Type].MaxProd > 0)
                    color = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
                  if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].VP > 0 & num17 >= 4 & num18 >= 4)
                    color = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
                }
              }
              else
              {
                color = Color.FromArgb((int) byte.MaxValue, this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].LandscapeType].Red, this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].LandscapeType].Green, this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].LandscapeType].Blue);
                index8 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].Regime;
                if (index8 > -1 & !predrawn)
                {
                  if (flagArray[index8])
                    index8 = 1;
                  color = Color.FromArgb((int) byte.MaxValue, (int) Math.Round((double) color.R * 0.8 + 0.2 * (double) this.game.Data.RegimeObj[index8].Red), (int) Math.Round((double) color.G * 0.8 + 0.2 * (double) this.game.Data.RegimeObj[index8].Green), (int) Math.Round((double) color.B * 0.8 + 0.2 * (double) this.game.Data.RegimeObj[index8].Blue));
                }
              }
            }
            if (this.game.Data.ShrowdOn)
              flag3 = true;
            bool flag6 = false;
            if (this.game.Data.ShrowdOn & this.game.Data.Round != 0)
            {
              if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].get_SeeNow(Index) > 0 | this.game.Data.Turn == Index & (this.game.Data.MapObj[0].HexObj[cx, cy].MaxRecon > 0 | !this.game.Data.ShrowdOn))
              {
                flag5 = true;
                flag3 = false;
                if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].get_LastLT(index1) == -1)
                {
                  color = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
                  flag4 = true;
                  flag3 = true;
                }
                else if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].LandscapeType].IsSea)
                {
                  if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].get_LastReg(index1) > -1)
                  {
                    index8 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].get_LastReg(index1);
                    color = Color.FromArgb((int) byte.MaxValue, this.game.Data.RegimeObj[index8].Red, this.game.Data.RegimeObj[index8].Green, this.game.Data.RegimeObj[index8].Blue);
                  }
                  else
                    color = Color.FromArgb((int) byte.MaxValue, 40, 200, 60);
                  if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].Location > -1 && this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].Location].Type].MaxProd > 0)
                    color = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
                  if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].VP > 0)
                    color = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
                }
                else
                {
                  int landscapeType = this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType;
                  color = Color.FromArgb((int) byte.MaxValue, this.game.Data.LandscapeTypeObj[landscapeType].Red, this.game.Data.LandscapeTypeObj[landscapeType].Green, this.game.Data.LandscapeTypeObj[landscapeType].Blue);
                }
              }
              else
              {
                if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].get_LastLT(index1) > -1)
                {
                  if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].LandscapeType].IsSea)
                  {
                    if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].get_LastReg(index1) > -1)
                    {
                      flag5 = true;
                      index8 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].get_LastReg(index1);
                      if (index8 <= this.game.Data.RegimeCounter)
                      {
                        color = Color.FromArgb((int) byte.MaxValue, this.game.Data.RegimeObj[index8].Red, this.game.Data.RegimeObj[index8].Green, this.game.Data.RegimeObj[index8].Blue);
                      }
                      else
                      {
                        color = Color.FromArgb((int) byte.MaxValue, 200, 200, 200);
                        flag6 = true;
                      }
                    }
                    else
                    {
                      color = Color.FromArgb((int) byte.MaxValue, 200, 200, 200);
                      flag6 = true;
                    }
                  }
                  else
                  {
                    int landscapeType = this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType;
                    color = Color.FromArgb((int) byte.MaxValue, this.game.Data.LandscapeTypeObj[landscapeType].Red, this.game.Data.LandscapeTypeObj[landscapeType].Green, (int) byte.MaxValue);
                    flag6 = true;
                  }
                }
                else
                {
                  color = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
                  flag6 = true;
                  flag4 = true;
                }
                if (flag6 & useTempVar3asAlpha && this.game.EditObj.TempValue3[0].Value[cx, cy] > 0)
                {
                  if (this.game.EditObj.TempAI[cx, cy] > -1)
                  {
                    index8 = this.game.EditObj.TempAI[cx, cy];
                    if (index8 > -1)
                    {
                      flag5 = true;
                      color = Color.FromArgb((int) byte.MaxValue, this.game.Data.RegimeObj[index8].Red, this.game.Data.RegimeObj[index8].Green, this.game.Data.RegimeObj[index8].Blue);
                    }
                    else
                      color = Color.White;
                  }
                  else
                    color = Color.White;
                }
              }
            }
            if (index1 > -1 & !realhex)
            {
              if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].get_LastReg(index1) == index1 | this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].Regime == index1)
              {
                int landscapeType = this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType;
                color = Color.FromArgb((int) byte.MaxValue, this.game.Data.LandscapeTypeObj[landscapeType].Red, this.game.Data.LandscapeTypeObj[landscapeType].Green, this.game.Data.LandscapeTypeObj[landscapeType].Blue);
              }
              else if (useTempAi2)
              {
                int index9 = this.game.EditObj.TempAI2[cx, cy];
                if (index9 > -1)
                  color = Color.FromArgb((int) byte.MaxValue, Math.Min((int) byte.MaxValue, (int) Math.Round((double) this.game.Data.LandscapeTypeObj[index9].Red * 0.5 + (double) color.R / 2.0)), Math.Min((int) byte.MaxValue, (int) Math.Round((double) this.game.Data.LandscapeTypeObj[index9].Green * 0.5 + (double) color.G / 2.0)), Math.Min((int) byte.MaxValue, (int) Math.Round((double) this.game.Data.LandscapeTypeObj[index9].Blue * 0.5 + (double) color.B / 2.0)));
              }
            }
            if (Index > -1 && useTempAi2 & (this.game.Data.MapObj[0].HexObj[cx, cy].get_SeeNow(Index) < 1 | this.game.Data.Turn == Index & this.game.Data.MapObj[0].HexObj[cx, cy].MaxRecon < 1 & this.game.Data.ShrowdOn) && this.game.EditObj.TempAI2[cx, cy] > -1 && this.game.Data.LandscapeTypeObj[this.game.EditObj.TempAI2[cx, cy]].IsSea)
            {
              int index10 = this.game.EditObj.TempAI2[cx, cy];
              color = Color.FromArgb((int) byte.MaxValue, this.game.Data.LandscapeTypeObj[index10].Red, this.game.Data.LandscapeTypeObj[index10].Green, this.game.Data.LandscapeTypeObj[index10].Blue);
            }
            if (highlightTempvar4 > 0 & (!flag4 | flag6) && this.game.EditObj.TempValue4[0].Value[cx, cy] == highlightTempvar4)
            {
              int red = Math.Min((int) byte.MaxValue, (int) color.R + 50);
              int green = Math.Min((int) byte.MaxValue, (int) color.G + 50);
              int blue = Math.Min((int) byte.MaxValue, (int) color.B + 50);
              color = Color.FromArgb((int) color.A, red, green, blue);
            }
            if (useTempVar3asAlpha && this.game.EditObj.TempValue3[0].Value[cx, cy] < (int) byte.MaxValue)
            {
              int red = (int) Math.Round((double) color.R * ((Math.Sqrt((double) this.game.EditObj.TempValue3[0].Value[cx, cy]) - 1.0) / 32.0));
              int green = (int) Math.Round((double) color.G * (Math.Sqrt((double) this.game.EditObj.TempValue3[0].Value[cx, cy]) / 32.0));
              int blue = (int) Math.Round((double) color.B * (Math.Sqrt((double) this.game.EditObj.TempValue3[0].Value[cx, cy]) / 32.0));
              if (red < 0)
                red = 0;
              if (green < 0)
                green = 0;
              if (blue < 0)
                blue = 0;
              color = Color.FromArgb((int) color.A, red, green, blue);
            }
            if (index1 > -1 && this.game.Data.MapObj[0].HexObj[cx, cy].get_LastLT(index1) > -1 & !useTempAi2)
            {
              int red = (int) Math.Round(Math.Floor((double) ((int) color.R * 2 + this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[cx, cy].get_LastLT(index1)].Red) / 3.0));
              int green = (int) Math.Round(Math.Floor((double) ((int) color.G * 2 + this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[cx, cy].get_LastLT(index1)].Green) / 3.0));
              int blue = (int) Math.Round(Math.Floor((double) ((int) color.B * 2 + this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[cx, cy].get_LastLT(index1)].Blue) / 3.0));
              color = Color.FromArgb((int) color.A, red, green, blue);
            }
            if (!this.game.Data.ShrowdOn)
              flag5 = true;
            if (!realhex)
            {
              DrawMod.DrawBlock(ref Expression, num15, num16, num17, num18, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
            }
            else
            {
              int num20 = predrawn ? 1 : 0;
              if ((alsoshading & predrawn | !predrawn & alsoshading) & specialMode1 == -1)
              {
                if (this.game.EditObj.se1_StrategySpecial2 == 1 & this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].Regime != index1 & flag5)
                {
                  int val1_1 = 0;
                  int val1_2 = 0;
                  int val1_3 = 0;
                  index8 = -1;
                  if (this.game.EditObj.TempAI[cx, cy] > -1)
                    index8 = this.game.EditObj.TempAI[cx, cy];
                  if (index8 > -1)
                  {
                    int alpha = 75;
                    if (flagArray[index8])
                    {
                      if (numArray1[index8] >= 30)
                      {
                        val1_1 = 128 - Math.Min(128, (int) Math.Round(128.0 * ((double) (numArray1[index8] - 30) / 30.0)));
                        val1_2 = 128 + Math.Min(128, (int) Math.Round(128.0 * ((double) (numArray1[index8] - 30) / 30.0)));
                      }
                      else
                      {
                        val1_1 = (int) byte.MaxValue - Math.Min(128, (int) Math.Round(128.0 * ((double) numArray1[index8] / 30.0)));
                        val1_2 = 128;
                      }
                    }
                    else
                    {
                      if (numArray2[index8] == 1)
                        alpha = 150;
                      if (this.game.Data.RegimeObj[index1].RegimeRel[index8] >= 1)
                        val1_2 = (int) byte.MaxValue - Math.Min(128, (int) Math.Round(128.0 * ((double) numArray1[index8] / 60.0)));
                      else if (this.game.Data.RegimeObj[index1].RegimeRel[index8] == 0)
                        val1_1 = (int) byte.MaxValue - Math.Min(128, (int) Math.Round(128.0 * ((double) numArray1[index8] / 60.0)));
                    }
                    if (index8 < 2)
                    {
                      val1_1 = 0;
                      val1_2 = 0;
                      val1_3 = 0;
                    }
                    int red1 = Math.Max(0, Math.Min(val1_1, (int) byte.MaxValue));
                    int green1 = Math.Max(0, Math.Min(val1_2, (int) byte.MaxValue));
                    int blue1 = Math.Max(0, Math.Min(val1_3, (int) byte.MaxValue));
                    color = Color.FromArgb(alpha, red1, green1, blue1);
                    if (useTempVar3asAlpha && this.game.EditObj.TempValue3[0].Value[cx, cy] < (int) byte.MaxValue)
                    {
                      int red2 = (int) Math.Round((double) color.R * ((Math.Sqrt((double) this.game.EditObj.TempValue3[0].Value[cx, cy]) - 1.0) / 32.0));
                      int green2 = (int) Math.Round((double) color.G * (Math.Sqrt((double) this.game.EditObj.TempValue3[0].Value[cx, cy]) / 32.0));
                      int blue2 = (int) Math.Round((double) color.B * (Math.Sqrt((double) this.game.EditObj.TempValue3[0].Value[cx, cy]) / 32.0));
                      if (red2 < 0)
                        red2 = 0;
                      if (green2 < 0)
                        green2 = 0;
                      if (blue2 < 0)
                        blue2 = 0;
                      color = Color.FromArgb((int) color.A, red2, green2, blue2);
                    }
                    if (this.game.Data.MapObj[0].HexObj[cx, cy].MaxRecon < 1 & this.game.Data.ShrowdOn & this.game.Data.MapObj[0].HexObj[cx, cy].get_LastLT(index1) == -1 & this.game.Data.ShrowdOn)
                      DrawMod.DrawBlock(ref Expression, num15, num16, num17, num18, (int) color.R, (int) color.G, (int) color.B, (int) byte.MaxValue);
                    DrawMod.DrawBlock(ref Expression, num15, num16, num17, num18, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
                  }
                  else
                    DrawMod.DrawBlock(ref Expression, num15, num16, num17, num18, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
                }
                else if (flag4)
                {
                  DrawMod.DrawBlock(ref Expression, num15, num16, num17, num18, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
                }
                else
                {
                  index8 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].Regime;
                  if (index1 != index8)
                  {
                    if (this.game.Data.MapObj[0].HexObj[cx, cy].get_ReconPts(Index) < 1 & this.game.Data.MapObj[0].HexObj[cx, cy].get_LastReg(Index) == -1 & this.game.Data.ShrowdOn)
                      DrawMod.DrawBlock(ref Expression, num15, num16, num17, num18, (int) color.R, (int) color.G, (int) color.B, (int) Math.Round((double) color.A * 0.5));
                    else if (index8 > -1)
                    {
                      if (flagArray[index8])
                        index8 = 1;
                      color = Color.FromArgb((int) byte.MaxValue, (int) Math.Round((double) color.R * 0.5 + 0.5 * (double) this.game.Data.RegimeObj[index8].Red), (int) Math.Round((double) color.G * 0.5 + 0.5 * (double) this.game.Data.RegimeObj[index8].Green), (int) Math.Round((double) color.B * 0.5 + 0.5 * (double) this.game.Data.RegimeObj[index8].Blue));
                      if (this.game.Data.RegimeObj[index8].Red == 0 & this.game.Data.RegimeObj[index8].Blue == 0 & this.game.Data.RegimeObj[index8].Green == 0)
                        DrawMod.DrawBlock(ref Expression, num15, num16, num17, num18, 0, 0, 0, 0);
                      else
                        DrawMod.DrawBlock(ref Expression, num15, num16, num17, num18, (int) color.R, (int) color.G, (int) color.B, (int) Math.Round((double) color.A * 0.5));
                    }
                    else
                      DrawMod.DrawBlock(ref Expression, num15, num16, num17, num18, (int) color.R, (int) color.G, (int) color.B, (int) Math.Round((double) color.A * 0.5));
                  }
                  else if (highlightTempvar4 > 0 && this.game.EditObj.TempValue4[0].Value[cx, cy] == highlightTempvar4)
                    DrawMod.DrawBlock(ref Expression, num15, num16, num17, num18, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 60);
                }
                if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].get_SeeNow(Index) > 0 | this.game.Data.Turn == Index & (this.game.Data.MapObj[0].HexObj[cx, cy].MaxRecon > 0 | !this.game.Data.ShrowdOn) && !flag4 & index8 > -1 & showflag & this.game.Data.MapObj[0].HexObj[cx, cy].VP > 0 & this.game.Data.MapObj[0].HexObj[cx, cy].Regime > -1)
                {
                  ref Graphics local15 = ref Expression;
                  bitmap = BitmapStore.GetBitmap(this.game.Data.RegimeObj[this.game.Data.MapObj[0].HexObj[cx, cy].Regime].HQSpriteNr, -1);
                  ref Bitmap local16 = ref bitmap;
                  rectangle2 = new Rectangle(4, 0, 12, 12);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(num15, num16, num17, num18);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect, destrect);
                }
              }
            }
            int num21 = 0;
            int num22 = 0;
            if (this.game.Data.Round > 0)
            {
              if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].get_LastLT(index1) > -1)
                num21 = 1;
              if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].get_SeeNow(Index) > 0)
                num22 = 1;
              if (this.game.Data.Turn == Index & (this.game.Data.MapObj[0].HexObj[cx, cy].MaxRecon > 0 | !this.game.Data.ShrowdOn))
                num22 = 1;
              if (useTempVar3asAlpha && this.game.EditObj.TempValue3[0].Value[cx, cy] > 0)
                num22 = 1;
            }
            if (!flag3 | num21 == 1 && num17 >= 3 & num18 >= 3 & !predrawn)
            {
              Color c = Color.FromArgb(105, 90, 90, 150);
              if (num1 > 0)
                c = Color.FromArgb(105, 150, 90, 70);
              int index11 = 0;
              do
              {
                if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].RiverType[index11] > -1 && !this.game.Data.RiverTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].RiverType[index11]].snakeMode)
                {
                  if (index11 == 0)
                    DrawMod.drawLine(ref Expression, num15, num16, num15 + num17, num16, c, 2);
                  if (index11 == 1)
                    DrawMod.drawLine(ref Expression, num15 + num17, num16, num15 + num17, (int) Math.Round((double) num16 + (double) num18 / 2.0), c, 2);
                  if (index11 == 2)
                    DrawMod.drawLine(ref Expression, num15 + num17, (int) Math.Round((double) num16 + (double) num18 / 2.0), num15 + num17, num16 + num18, c, 2);
                  if (index11 == 3)
                    DrawMod.drawLine(ref Expression, num15, num16 + num18, num15 + num17, num16 + num18, c, 2);
                  if (index11 == 4)
                    DrawMod.drawLine(ref Expression, num15, (int) Math.Round((double) num16 + (double) num18 / 2.0), num15, num16 + num18, c, 2);
                  if (index11 == 5)
                    DrawMod.drawLine(ref Expression, num15, num16, num15, (int) Math.Round((double) num16 + (double) num18 / 2.0), c, 2);
                }
                ++index11;
              }
              while (index11 <= 5);
            }
            if (!flag3 | num22 == 1 && num17 >= 2 & num18 >= 2 & !predrawn)
            {
              Color c1 = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
              Color c2 = Color.FromArgb((int) byte.MaxValue, 200, 0, 0);
              if (useTempVar3asAlpha)
              {
                if (this.game.EditObj.TempValue3[0].Value[cx, cy] < 999)
                {
                  int red3 = (int) Math.Round((double) c1.R * (((double) this.game.EditObj.TempValue3[0].Value[cx, cy] + (double) ((int) byte.MaxValue - this.game.EditObj.TempValue3[0].Value[cx, cy]) / 2.0) / (double) byte.MaxValue));
                  if (red3 > 528)
                    red3 = red3;
                  int green3 = (int) Math.Round((double) c1.G * (((double) this.game.EditObj.TempValue3[0].Value[cx, cy] + (double) ((int) byte.MaxValue - this.game.EditObj.TempValue3[0].Value[cx, cy]) / 2.0) / (double) byte.MaxValue));
                  int blue3 = (int) Math.Round((double) c1.B * (((double) this.game.EditObj.TempValue3[0].Value[cx, cy] + (double) ((int) byte.MaxValue - this.game.EditObj.TempValue3[0].Value[cx, cy]) / 2.0) / (double) byte.MaxValue));
                  c1 = Color.FromArgb((int) c1.A, red3, green3, blue3);
                  int red4 = (int) Math.Round((double) c2.R * ((double) this.game.EditObj.TempValue3[0].Value[cx, cy] / (double) byte.MaxValue));
                  int green4 = (int) Math.Round((double) c2.G * ((double) this.game.EditObj.TempValue3[0].Value[cx, cy] / (double) byte.MaxValue));
                  int blue4 = (int) Math.Round((double) c2.B * ((double) this.game.EditObj.TempValue3[0].Value[cx, cy] / (double) byte.MaxValue));
                  c2 = Color.FromArgb((int) c2.A, red4, green4, blue4);
                }
                else
                  c2 = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
              }
              int tfacing = 1;
              do
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                if (coordinate.onmap)
                {
                  int num23 = this.game.Data.MapObj[0].HexObj[cx, cy].Regime;
                  int regime = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime;
                  if (useTempVar3asAlpha)
                  {
                    num23 = this.game.EditObj.TempAI[cx, cy];
                    regime = this.game.EditObj.TempAI[coordinate.x, coordinate.y];
                    if (this.game.Data.MapObj[0].HexObj[cx, cy].get_SeeNow(Index) > 0 | this.game.Data.Turn == Index & (this.game.Data.MapObj[0].HexObj[cx, cy].MaxRecon > 0 | !this.game.Data.ShrowdOn))
                    {
                      if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType].IsSea)
                        num23 = -1;
                    }
                    else if (this.game.Data.MapObj[0].HexObj[cx, cy].get_LastLT(index1) > -1)
                    {
                      if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[cx, cy].get_LastLT(index1)].IsSea)
                        num23 = -1;
                    }
                    else if (useTempAi2 && this.game.EditObj.TempAI2[cx, cy] > -1 && this.game.Data.LandscapeTypeObj[this.game.EditObj.TempAI2[cx, cy]].IsSea)
                      num23 = -1;
                  }
                  if (cx == 48 & cy == 34)
                    cx = cx;
                  if (num23 > -1 & regime > -1)
                  {
                    if (num23 != regime)
                    {
                      if (highlightTempvar4 > 0)
                      {
                        if (highlightTempvar4 > 0 & (this.game.EditObj.TempValue4[0].Value[cx, cy] == highlightTempvar4 | this.game.EditObj.TempValue4[0].Value[coordinate.x, coordinate.y] == highlightTempvar4))
                        {
                          if (tfacing == 1)
                            DrawMod.drawLine(ref Expression, num15, num16, num15 + num17, num16, c1, 3);
                          if (tfacing == 2)
                            DrawMod.drawLine(ref Expression, num15 + num17, num16, num15 + num17, (int) Math.Round((double) num16 + (double) num18 / 2.0), c1, 3);
                          if (tfacing == 3)
                            DrawMod.drawLine(ref Expression, num15 + num17, (int) Math.Round((double) num16 + (double) num18 / 2.0), num15 + num17, num16 + num18, c1, 3);
                          if (tfacing == 4)
                            DrawMod.drawLine(ref Expression, num15, num16 + num18, num15 + num17, num16 + num18, c1, 3);
                          if (tfacing == 5)
                            DrawMod.drawLine(ref Expression, num15, (int) Math.Round((double) num16 + (double) num18 / 2.0), num15, num16 + num18, c1, 3);
                          if (tfacing == 6)
                            DrawMod.drawLine(ref Expression, num15, num16, num15, (int) Math.Round((double) num16 + (double) num18 / 2.0), c1, 3);
                        }
                        else
                        {
                          if (tfacing == 1)
                            DrawMod.drawLine(ref Expression, num15, num16, num15 + num17, num16, c2, 2);
                          if (tfacing == 2)
                            DrawMod.drawLine(ref Expression, num15 + num17, num16, num15 + num17, (int) Math.Round((double) num16 + (double) num18 / 2.0), c2, 2);
                          if (tfacing == 3)
                            DrawMod.drawLine(ref Expression, num15 + num17, (int) Math.Round((double) num16 + (double) num18 / 2.0), num15 + num17, num16 + num18, c2, 2);
                          if (tfacing == 4)
                            DrawMod.drawLine(ref Expression, num15, num16 + num18, num15 + num17, num16 + num18, c2, 2);
                          if (tfacing == 5)
                            DrawMod.drawLine(ref Expression, num15, (int) Math.Round((double) num16 + (double) num18 / 2.0), num15, num16 + num18, c2, 2);
                          if (tfacing == 6)
                            DrawMod.drawLine(ref Expression, num15, num16, num15, (int) Math.Round((double) num16 + (double) num18 / 2.0), c2, 2);
                        }
                      }
                      else
                      {
                        int widdy = 2;
                        if (specialMode1 > -1)
                          widdy = 1;
                        if (tfacing == 1)
                          DrawMod.drawLine(ref Expression, num15, num16, num15 + num17, num16, c2, widdy);
                        if (tfacing == 2)
                          DrawMod.drawLine(ref Expression, num15 + num17, num16, num15 + num17, (int) Math.Round((double) num16 + (double) num18 / 2.0), c2, widdy);
                        if (tfacing == 3)
                          DrawMod.drawLine(ref Expression, num15 + num17, (int) Math.Round((double) num16 + (double) num18 / 2.0), num15 + num17, num16 + num18, c2, widdy);
                        if (tfacing == 4)
                          DrawMod.drawLine(ref Expression, num15, num16 + num18, num15 + num17, num16 + num18, c2, widdy);
                        if (tfacing == 5)
                          DrawMod.drawLine(ref Expression, num15, (int) Math.Round((double) num16 + (double) num18 / 2.0), num15, num16 + num18, c2, widdy);
                        if (tfacing == 6)
                          DrawMod.drawLine(ref Expression, num15, num16, num15, (int) Math.Round((double) num16 + (double) num18 / 2.0), c2, widdy);
                      }
                    }
                    else if (specialMode1 == -1)
                    {
                      int num24 = this.game.Data.MapObj[0].HexObj[cx, cy].GetHexLibVarValue(libVar9);
                      int num25 = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].GetHexLibVarValue(libVar9);
                      if (useTempZones)
                      {
                        if (useTempVar3asAlpha)
                        {
                          num24 = this.game.EditObj.TempValue4[0].Value[cx, cy];
                          num25 = this.game.EditObj.TempValue4[0].Value[coordinate.x, coordinate.y];
                        }
                      }
                      else if (this.game.Data.MapObj[0].HexObj[cx, cy].MaxRecon < 1 | this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].MaxRecon < 1 | !this.game.Data.ShrowdOn)
                      {
                        num24 = -1;
                        num25 = -1;
                      }
                      if (num24 != num25 & num24 > 0 & num25 > 0)
                      {
                        int num26 = 0;
                        int num27 = 0;
                        if (index1 > -1)
                        {
                          if (this.game.Data.MapObj[0].HexObj[cx, cy].GetHexLibVarValue(libVar9) > 0)
                            num26 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData3(0, this.game.Data.RegimeObj[index1].id, 1, this.game.Data.MapObj[0].HexObj[cx, cy].GetHexLibVarValue(libVar9), 2, "recon", 3)));
                          if (this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].GetHexLibVarValue(libVar9) > 0)
                            num27 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData3(0, this.game.Data.RegimeObj[index1].id, 1, this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].GetHexLibVarValue(libVar9), 2, "recon", 3)));
                          if (useTempZones)
                          {
                            num26 = 0;
                            num27 = 0;
                            if (this.game.EditObj.TempValue4[0].Value[cx, cy] > 0)
                              num26 = this.game.EditObj.TempValue3[0].Value[cx, cy];
                            if (this.game.EditObj.TempValue4[0].Value[coordinate.x, coordinate.y] > 0)
                              num27 = this.game.EditObj.TempValue3[0].Value[coordinate.x, coordinate.y];
                          }
                          bool flag7 = false;
                          if (this.game.Data.MapObj[0].HexObj[cx, cy].get_SeeNow(Index) > 0 | this.game.Data.Turn == Index & (this.game.Data.MapObj[0].HexObj[cx, cy].MaxRecon > 0 | !this.game.Data.ShrowdOn))
                          {
                            if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType].IsSea)
                              flag7 = true;
                          }
                          else if (this.game.Data.MapObj[0].HexObj[cx, cy].get_LastLT(index1) > -1)
                          {
                            if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[cx, cy].get_LastLT(index1)].IsSea)
                              flag7 = true;
                          }
                          else if (useTempAi2 && this.game.EditObj.TempAI2[cx, cy] > -1 && this.game.Data.LandscapeTypeObj[this.game.EditObj.TempAI2[cx, cy]].IsSea)
                            flag7 = true;
                          if (this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].get_SeeNow(Index) > 0 | this.game.Data.Turn == Index & (this.game.Data.MapObj[0].HexObj[cx, cy].MaxRecon > 0 | !this.game.Data.ShrowdOn))
                          {
                            if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                              flag7 = true;
                          }
                          else if (this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].get_LastLT(index1) > -1)
                          {
                            if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].get_LastLT(index1)].IsSea)
                              flag7 = true;
                          }
                          else if (useTempAi2 && this.game.EditObj.TempAI2[coordinate.x, coordinate.y] > -1 && this.game.Data.LandscapeTypeObj[this.game.EditObj.TempAI2[coordinate.x, coordinate.y]].IsSea)
                            flag7 = true;
                          if (!flag7 & (!this.game.Data.FOWOn | num26 > 0 | num27 > 0 | this.game.Data.MapObj[0].HexObj[cx, cy].Regime == index1 | this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime == index1))
                          {
                            bool flag8 = false;
                            if (highlightTempvar4 > 0 && (this.game.EditObj.TempValue4[0].Value[cx, cy] == highlightTempvar4 | this.game.EditObj.TempValue4[0].Value[coordinate.x, coordinate.y] == highlightTempvar4) & useTempZones)
                            {
                              if (tfacing == 1)
                                DrawMod.drawLine(ref Expression, num15, num16, num15 + num17, num16, c1, 3);
                              if (tfacing == 2)
                                DrawMod.drawLine(ref Expression, num15 + num17, num16, num15 + num17, (int) Math.Round((double) num16 + (double) num18 / 2.0), c1, 3);
                              if (tfacing == 3)
                                DrawMod.drawLine(ref Expression, num15 + num17, (int) Math.Round((double) num16 + (double) num18 / 2.0), num15 + num17, num16 + num18, c1, 3);
                              if (tfacing == 4)
                                DrawMod.drawLine(ref Expression, num15, num16 + num18, num15 + num17, num16 + num18, c1, 3);
                              if (tfacing == 5)
                                DrawMod.drawLine(ref Expression, num15, (int) Math.Round((double) num16 + (double) num18 / 2.0), num15, num16 + num18, c1, 3);
                              if (tfacing == 6)
                                DrawMod.drawLine(ref Expression, num15, num16, num15, (int) Math.Round((double) num16 + (double) num18 / 2.0), c1, 3);
                              flag8 = true;
                            }
                            if (!flag8)
                            {
                              if (tfacing == 1)
                                DrawMod.drawLine(ref Expression, num15, num16, num15 + num17, num16, c2);
                              if (tfacing == 2)
                                DrawMod.drawLine(ref Expression, num15 + num17, num16, num15 + num17, (int) Math.Round((double) num16 + (double) num18 / 2.0), c2);
                              if (tfacing == 3)
                                DrawMod.drawLine(ref Expression, num15 + num17, (int) Math.Round((double) num16 + (double) num18 / 2.0), num15 + num17, num16 + num18, c2);
                              if (tfacing == 4)
                                DrawMod.drawLine(ref Expression, num15, num16 + num18, num15 + num17, num16 + num18, c2);
                              if (tfacing == 5)
                                DrawMod.drawLine(ref Expression, num15, (int) Math.Round((double) num16 + (double) num18 / 2.0), num15, num16 + num18, c2);
                              if (tfacing == 6)
                                DrawMod.drawLine(ref Expression, num15, num16, num15, (int) Math.Round((double) num16 + (double) num18 / 2.0), c2);
                            }
                          }
                        }
                      }
                    }
                  }
                }
                ++tfacing;
              }
              while (tfacing <= 6);
            }
            if (!flag3 && num17 >= 8 & num18 >= 8 & !predrawn)
            {
              int index12 = 0;
              do
              {
                if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].RoadType[index12] > -1)
                {
                  int widdy = this.game.Data.RoadTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[cx, cy].RoadType[index12]].Thickness;
                  if (widdy < 1)
                    widdy = 1;
                  if (index12 == 0)
                    DrawMod.drawLine(ref Expression, (int) Math.Round((double) num15 + (double) num17 / 2.0), (int) Math.Round((double) num16 + (double) num18 / 2.0), (int) Math.Round((double) num15 + (double) num17 / 2.0), num16, 0, 0, 0, 105, widdy);
                  if (index12 == 1)
                    DrawMod.drawLine(ref Expression, (int) Math.Round((double) num15 + (double) num17 / 2.0), (int) Math.Round((double) num16 + (double) num18 / 2.0), num15 + num17, (int) Math.Round((double) num16 + (double) num18 * 0.25), 0, 0, 0, 105, widdy);
                  if (index12 == 2)
                    DrawMod.drawLine(ref Expression, (int) Math.Round((double) num15 + (double) num17 / 2.0), (int) Math.Round((double) num16 + (double) num18 / 2.0), num15 + num17, (int) Math.Round((double) num16 + (double) num18 * 0.75), 0, 0, 0, 105, widdy);
                  if (index12 == 3)
                    DrawMod.drawLine(ref Expression, (int) Math.Round((double) num15 + (double) num17 / 2.0), (int) Math.Round((double) num16 + (double) num18 / 2.0), (int) Math.Round((double) num15 + (double) num17 / 2.0), num16 + num18, 0, 0, 0, 105, widdy);
                  if (index12 == 4)
                    DrawMod.drawLine(ref Expression, (int) Math.Round((double) num15 + (double) num17 / 2.0), (int) Math.Round((double) num16 + (double) num18 / 2.0), num15, (int) Math.Round((double) num16 + (double) num18 * 0.75), 0, 0, 0, 105, widdy);
                  if (index12 == 5)
                    DrawMod.drawLine(ref Expression, (int) Math.Round((double) num15 + (double) num17 / 2.0), (int) Math.Round((double) num16 + (double) num18 / 2.0), num15, (int) Math.Round((double) num16 + (double) num18 * 0.25), 0, 0, 0, 105, widdy);
                }
                ++index12;
              }
              while (index12 <= 5);
            }
          }
        }
      }
      int mapWidth2 = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth;
      for (int index13 = 0; index13 <= mapWidth2; ++index13)
      {
        int mapHeight = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight;
        for (int index14 = 0; index14 <= mapHeight; ++index14)
        {
          int index15 = index13;
          int index16 = index14;
          if (this.game.EditObj.MiniMapOffset > 0)
          {
            index15 += this.game.EditObj.MiniMapOffset;
            if (index15 > this.game.Data.MapObj[0].MapWidth)
              index15 -= this.game.Data.MapObj[0].MapWidth + 1;
          }
          if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index15, index16].LandscapeType > -1)
          {
            int num28;
            int num29;
            int num30;
            int num31;
            if (!realhex)
            {
              num28 = (int) Math.Round((double) (Conversion.Int(num12 * (float) index13) + (float) num6));
              num29 = (int) Math.Round((double) (Conversion.Int(num13 * (float) index14) - d2 / 2f + (float) num7));
              if ((index13 + 10) % 2 > 0)
                num29 = (int) Math.Round((double) ((float) num29 + d2 / 2f));
              num30 = (int) Math.Round((double) num12);
              num31 = (int) Math.Round((double) num13);
            }
            else
            {
              num28 = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num12) * (double) index13 + (double) num6)));
              num29 = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num13) * (double) index14) - Math.Floor((double) d2 / 2.0) + (double) num7));
              if ((index13 + 10) % 2 > 0)
                num29 = (int) Math.Round((double) num29 + Math.Floor((double) d2 / 2.0));
              num30 = (int) Math.Round(Math.Floor((double) num12));
              num31 = (int) Math.Round(Math.Floor((double) num13));
            }
            flag1 = false;
            if (!this.game.Data.ShrowdOn && !flag3 && alsounits & specialMode1 == -1)
            {
              int num32 = 0;
              int unitCounter = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index15, index16].UnitCounter;
              int index17;
              for (index17 = 0; index17 <= unitCounter; ++index17)
              {
                if (this.game.HandyFunctionsObj.CanWeSeeUnit(this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index15, index16].UnitList[index17], index1) > 0)
                {
                  num32 = 1;
                  break;
                }
              }
              if (num32 == 1)
              {
                int index18 = this.game.Data.UnitObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index15, index16].UnitList[index17]].Regime;
                if (Operators.ConditionalCompareObjectGreater(this.game.HandyFunctionsObj.GetUnitPeople(this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index15, index16].UnitList[index17]), (object) -1, false) && this.game.Data.PeopleObj[Conversions.ToInteger(this.game.HandyFunctionsObj.GetUnitPeople(this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index15, index16].UnitList[index17]))].RegCol > -1)
                  index18 = this.game.Data.PeopleObj[Conversions.ToInteger(this.game.HandyFunctionsObj.GetUnitPeople(this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index15, index16].UnitList[index17]))].RegCol;
                int r = this.game.Data.RegimeObj[index18].Red - 50;
                int g = this.game.Data.RegimeObj[index18].Green - 50;
                int b = this.game.Data.RegimeObj[index18].Blue - 50;
                if (r < 0)
                  r = 0;
                if (g < 0)
                  g = 0;
                if (b < 0)
                  b = 0;
                DrawMod.DrawBlock(ref Expression, (int) Math.Round((double) num28 + (double) num30 * 0.25), (int) Math.Round((double) num29 + (double) num31 * 0.25), (int) Math.Round((double) num30 * 0.5), (int) Math.Round((double) num31 * 0.5), r, g, b, (int) byte.MaxValue);
                DrawMod.DrawRectangle(ref Expression, (int) Math.Round((double) num28 + (double) num30 * 0.25), (int) Math.Round((double) num29 + (double) num31 * 0.25), (int) Math.Round((double) num30 * 0.5), (int) Math.Round((double) num31 * 0.5), this.game.Data.RegimeObj[index18].Red * 2, this.game.Data.RegimeObj[index18].Green * 2, this.game.Data.RegimeObj[index18].Blue * 2, (int) byte.MaxValue);
              }
            }
          }
        }
      }
      if (specialMode1 > 0)
      {
        int mapWidth3 = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth;
        for (int index19 = 0; index19 <= mapWidth3; ++index19)
        {
          int mapHeight = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight;
          for (int index20 = 0; index20 <= mapHeight; ++index20)
          {
            int index21 = index19;
            int index22 = index20;
            if (this.game.EditObj.MiniMapOffset > 0)
            {
              index21 += this.game.EditObj.MiniMapOffset;
              if (index21 > this.game.Data.MapObj[0].MapWidth)
                index21 -= this.game.Data.MapObj[0].MapWidth + 1;
            }
            int num33 = 1;
            if (this.game.Data.ShrowdOn & !this.game.Data.ShrowdPeek)
            {
              num33 = 0;
              if (this.game.Data.Round > 0 && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index21, index22].get_SeeNow(Index) > 0 | this.game.Data.Turn == Index & (this.game.Data.MapObj[0].HexObj[index21, index22].MaxRecon > 0 | !this.game.Data.ShrowdOn))
                num33 = 1;
            }
            if (this.game.Data.Round > 0 && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index21, index22].get_SeeNow(Index) < 1 | this.game.Data.Turn == Index & this.game.Data.MapObj[0].HexObj[index21, index22].MaxRecon < 1 & this.game.Data.ShrowdOn && this.game.Data.ShrowdPeek)
              num33 = 0;
            int num34;
            int num35;
            if (num33 == 1)
            {
              bool flag9 = false;
              bool flag10 = false;
              int index23;
              if (specialMode1 >= 1 & specialMode1 <= 6)
              {
                int hexLibVarValue1 = this.game.Data.MapObj[0].HexObj[index21, index22].GetHexLibVarValue(libVar2);
                int hexLibVarValue2 = this.game.Data.MapObj[0].HexObj[index21, index22].GetHexLibVarValue(libVar1);
                int hexLibVarValue3 = this.game.Data.MapObj[0].HexObj[index21, index22].GetHexLibVarValue(libVar3);
                if (hexLibVarValue1 <= 0 & hexLibVarValue3 > 0 && hexLibVarValue2 == specialMode1 | hexLibVarValue2 > 0 & specialMode1 == 6)
                {
                  flag9 = true;
                  index23 = -1;
                  bool flag11 = false;
                  if (this.game.Data.MapObj[0].HexObj[index21, index22].Regime == this.game.Data.Turn | this.game.Data.MapObj[0].HexObj[index21, index22].MaxRecon > 0 | !this.game.Data.ShrowdOn)
                  {
                    int length = this.game.Data.StringListObj[stringListById5].Length;
                    for (int index24 = 0; index24 <= length; ++index24)
                    {
                      if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].Data[index24, 3])) == index21 && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].Data[index24, 4])) == index22)
                      {
                        int idValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].Data[index24, 1]));
                        if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 4))) == 2 & (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 9))) == hexLibVarValue2)
                          flag11 = true;
                      }
                    }
                  }
                  if (!flag11)
                  {
                    if (hexLibVarValue2 == 2)
                      index23 = this.game.Data.FindSmallPic(112, "SE_Graphics");
                    if (hexLibVarValue2 == 3)
                      index23 = this.game.Data.FindSmallPic(147, "SE_Graphics");
                    if (hexLibVarValue2 == 5)
                      index23 = this.game.Data.FindSmallPic(113, "SE_Graphics");
                    if (hexLibVarValue2 == 4)
                      index23 = this.game.Data.FindSmallPic(163, "SE_Graphics");
                    if (hexLibVarValue2 == 1)
                      index23 = this.game.Data.FindSmallPic(152, "SE_Graphics");
                  }
                  else
                  {
                    if (hexLibVarValue2 == 2)
                      index23 = this.game.Data.FindSmallPic(114, "SE_Graphics");
                    if (hexLibVarValue2 == 3)
                      index23 = this.game.Data.FindSmallPic(148, "SE_Graphics");
                    if (hexLibVarValue2 == 5)
                      index23 = this.game.Data.FindSmallPic(115, "SE_Graphics");
                    if (hexLibVarValue2 == 4)
                      index23 = this.game.Data.FindSmallPic(164, "SE_Graphics");
                    if (hexLibVarValue2 == 1)
                      index23 = this.game.Data.FindSmallPic(154, "SE_Graphics");
                  }
                }
              }
              int num36;
              int num37;
              int num38;
              int num39;
              Color color;
              if (specialMode1 == 7)
              {
                int hexLibVarValue = this.game.Data.MapObj[0].HexObj[index21, index22].GetHexLibVarValue(libVar4);
                if (hexLibVarValue > 0)
                {
                  if (hexLibVarValue < 500)
                  {
                    num36 = (int) Math.Round((double) byte.MaxValue * ((double) (500 - hexLibVarValue) / 500.0));
                    num37 = (int) byte.MaxValue;
                    num38 = (int) byte.MaxValue;
                    num39 = (int) Math.Round(128.0 - 128.0 * ((double) (500 - hexLibVarValue) / 500.0));
                  }
                  else if (hexLibVarValue >= 500 & hexLibVarValue < 1000)
                  {
                    num36 = 0;
                    num37 = (int) byte.MaxValue - (int) Math.Round((double) byte.MaxValue * ((double) (hexLibVarValue - 500) / 500.0));
                    num38 = (int) byte.MaxValue;
                    num39 = 128;
                  }
                  else if (hexLibVarValue >= 1000)
                  {
                    num36 = 0;
                    num37 = 0;
                    num38 = (int) byte.MaxValue - (int) Math.Round((double) byte.MaxValue * ((double) (hexLibVarValue - 1000) / 6000.0));
                    num39 = 128;
                  }
                  num36 = Math.Min((int) byte.MaxValue, Math.Max(num36, 0));
                  num37 = Math.Min((int) byte.MaxValue, Math.Max(num37, 0));
                  num38 = Math.Min((int) byte.MaxValue, Math.Max(num38, 0));
                  num39 = Math.Min((int) byte.MaxValue, Math.Max(num39, 0));
                  flag10 = true;
                  color = Color.FromArgb(num39, num36, num37, num38);
                  if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index21, index22].LandscapeType].IsSea)
                    flag10 = false;
                }
              }
              if (specialMode1 == 8)
              {
                int num40 = this.game.Data.MapObj[0].HexObj[index21, index22].GetHexLibVarValue(libVar5) + 273;
                if (num40 > 0)
                {
                  if (num40 < 173)
                  {
                    num36 = 0;
                    num37 = 0;
                    num38 = (int) byte.MaxValue;
                    num39 = 128;
                  }
                  else if (num40 < 273)
                  {
                    num36 = 0;
                    num37 = (int) Math.Round((double) byte.MaxValue * ((double) (num40 - 173) / 100.0));
                    num38 = (int) byte.MaxValue;
                    num39 = 128;
                  }
                  else if (num40 < 283)
                  {
                    num36 = (int) Math.Round((double) byte.MaxValue * ((double) (num40 - 273) / 10.0));
                    num37 = (int) byte.MaxValue;
                    num38 = (int) byte.MaxValue - (int) Math.Round((double) byte.MaxValue * ((double) (num40 - 273) / 10.0));
                    num39 = 128;
                  }
                  else if (num40 < 323)
                  {
                    num36 = (int) byte.MaxValue;
                    num37 = (int) byte.MaxValue - (int) Math.Round((double) byte.MaxValue * ((double) (num40 - 283) / 40.0));
                    num38 = 0;
                    num39 = 128;
                  }
                  else if (num40 >= 323)
                  {
                    num36 = (int) byte.MaxValue - (int) Math.Round((double) byte.MaxValue * ((double) (num40 - 323) / 50.0));
                    num37 = 0;
                    num38 = 0;
                    num39 = 128;
                  }
                  num36 = Math.Min((int) byte.MaxValue, Math.Max(num36, 0));
                  num37 = Math.Min((int) byte.MaxValue, Math.Max(num37, 0));
                  num38 = Math.Min((int) byte.MaxValue, Math.Max(num38, 0));
                  num39 = Math.Min((int) byte.MaxValue, Math.Max(num39, 0));
                  flag10 = true;
                  color = Color.FromArgb(num39, num36, num37, num38);
                  if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index21, index22].LandscapeType].IsSea)
                    flag10 = false;
                }
              }
              if (specialMode1 == 9)
              {
                int hexLibVarValue = this.game.Data.MapObj[0].HexObj[index21, index22].GetHexLibVarValue(libVar6);
                if (hexLibVarValue > 0)
                {
                  if (hexLibVarValue < 500)
                  {
                    num36 = (int) byte.MaxValue;
                    num37 = 128;
                    num38 = 0;
                    num39 = (int) Math.Round(128.0 - 128.0 * ((double) (500 - hexLibVarValue) / 500.0));
                  }
                  else if (hexLibVarValue >= 500 & hexLibVarValue < 2000)
                  {
                    num36 = (int) byte.MaxValue - (int) Math.Round(128.0 * ((double) (hexLibVarValue - 500) / 1500.0));
                    num37 = 128 - (int) Math.Round(64.0 * ((double) (hexLibVarValue - 500) / 1500.0));
                    num38 = 0;
                    num39 = 128;
                  }
                  else if (hexLibVarValue >= 2000)
                  {
                    num36 = 128;
                    num37 = 64;
                    num38 = 0;
                    num39 = 128 + (int) Math.Round((double) (64 * (hexLibVarValue - 2000)) / 2000.0);
                  }
                  num36 = Math.Min((int) byte.MaxValue, Math.Max(num36, 0));
                  num37 = Math.Min((int) byte.MaxValue, Math.Max(num37, 0));
                  num38 = Math.Min((int) byte.MaxValue, Math.Max(num38, 0));
                  num39 = Math.Min((int) byte.MaxValue, Math.Max(num39, 0));
                  flag10 = true;
                  color = Color.FromArgb(num39, num36, num37, num38);
                  if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index21, index22].LandscapeType].IsSea)
                    flag10 = false;
                }
              }
              if (specialMode1 == 10)
              {
                int heightLevel = this.game.Data.MapObj[0].HexObj[index21, index22].HeightLevel;
                if (heightLevel < 1)
                {
                  num36 = 20;
                  num37 = 10;
                  num38 = 0;
                  num39 = 150;
                }
                else if (heightLevel >= 1 & heightLevel < 9)
                {
                  num36 = (int) Math.Round((double) byte.MaxValue * ((double) heightLevel / 8.0));
                  num37 = (int) Math.Round(150.0 * ((double) heightLevel / 8.0));
                  num38 = (int) Math.Round(50.0 * ((double) heightLevel / 8.0));
                  num39 = 150 - (int) Math.Round(100.0 * ((double) heightLevel / 8.0));
                }
                else if (heightLevel >= 9)
                {
                  num36 = (int) byte.MaxValue;
                  num37 = 200;
                  num38 = 150;
                  num39 = 50;
                }
                num36 = Math.Min((int) byte.MaxValue, Math.Max(num36, 0));
                num37 = Math.Min((int) byte.MaxValue, Math.Max(num37, 0));
                num38 = Math.Min((int) byte.MaxValue, Math.Max(num38, 0));
                num39 = (int) Math.Round((double) Math.Min((int) byte.MaxValue, Math.Max(num39, 0)) * 0.75);
                flag10 = true;
                color = Color.FromArgb(num39, num36, num37, num38);
                if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index21, index22].LandscapeType].IsSea)
                  flag10 = false;
              }
              if (specialMode1 == 11)
              {
                int hexLibVarValue = this.game.Data.MapObj[0].HexObj[index21, index22].GetHexLibVarValue(libVar7);
                if (hexLibVarValue > 0)
                {
                  Random random = new Random(hexLibVarValue);
                  num36 = random.Next(50, (int) byte.MaxValue);
                  num37 = random.Next(50, (int) byte.MaxValue);
                  num38 = random.Next(50, (int) byte.MaxValue);
                  num39 = 150;
                  flag10 = true;
                  color = Color.FromArgb(num39, num36, num37, num38);
                }
              }
              if (specialMode1 == 12)
              {
                int hexLibVarValue = this.game.Data.MapObj[0].HexObj[index21, index22].GetHexLibVarValue(libVar8);
                if (hexLibVarValue > 0)
                {
                  int val1_4 = 200 - (int) Math.Round(100.0 * ((double) hexLibVarValue / 20000.0));
                  int val1_5 = 0;
                  int val1_6 = 200 - (int) Math.Round(100.0 * ((double) hexLibVarValue / 20000.0));
                  int val1_7 = 64 + Math.Min(64, (int) Math.Round(64.0 * ((double) hexLibVarValue / 20000.0)));
                  num36 = Math.Min((int) byte.MaxValue, Math.Max(val1_4, 0));
                  num37 = Math.Min((int) byte.MaxValue, Math.Max(val1_5, 0));
                  num38 = Math.Min((int) byte.MaxValue, Math.Max(val1_6, 0));
                  num39 = Math.Min((int) byte.MaxValue, Math.Max(val1_7, 0));
                  flag10 = true;
                  color = Color.FromArgb(num39, num36, num37, num38);
                  if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index21, index22].LandscapeType].IsSea)
                    flag10 = false;
                }
              }
              if (flag9 | flag10)
              {
                int num41 = index19;
                num34 = index20;
                if (this.game.EditObj.MiniMapOffset > 0)
                {
                  int num42 = num41 + this.game.EditObj.MiniMapOffset;
                  if (num42 > this.game.Data.MapObj[0].MapWidth)
                    num35 = num42 - (this.game.Data.MapObj[0].MapWidth + 1);
                }
                int x1;
                int y1;
                int w;
                int h;
                if (!realhex)
                {
                  x1 = (int) Math.Round((double) (Conversion.Int(num12 * (float) index19) + (float) num6));
                  y1 = (int) Math.Round((double) (Conversion.Int(num13 * (float) index20) - d2 / 2f + (float) num7));
                  if ((index19 + 10) % 2 > 0)
                    y1 = (int) Math.Round((double) ((float) y1 + d2 / 2f));
                  w = (int) Math.Round((double) (num12 + 1f));
                  h = (int) Math.Round((double) (num13 + 1f));
                }
                else
                {
                  x1 = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num12) * (double) index19 + (double) num6)));
                  y1 = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num13) * (double) index20) - Math.Floor((double) d2 / 2.0) + (double) num7));
                  if ((index19 + 10) % 2 > 0)
                    y1 = (int) Math.Round((double) y1 + Math.Floor((double) d2 / 2.0));
                  w = (int) Math.Round(Math.Floor((double) num12));
                  h = (int) Math.Round(Math.Floor((double) num13));
                }
                if (flag10)
                  DrawMod.DrawBlock(ref Expression, x1, y1, w, h, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
                else if (flag9 && index23 > -1)
                {
                  ref Graphics local17 = ref Expression;
                  bitmap = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[index23]);
                  ref Bitmap local18 = ref bitmap;
                  int x = x1 - 36;
                  int y = y1 - 20;
                  DrawMod.DrawSimple(ref local17, ref local18, x, y);
                }
              }
            }
            else if (this.game.Data.MapObj[0].HexObj[index21, index22].get_LastLT(Index) > -1)
            {
              int num43 = index19;
              num34 = index20;
              if (this.game.EditObj.MiniMapOffset > 0)
              {
                int num44 = num43 + this.game.EditObj.MiniMapOffset;
                if (num44 > this.game.Data.MapObj[0].MapWidth)
                  num35 = num44 - (this.game.Data.MapObj[0].MapWidth + 1);
              }
              int x1;
              int y1;
              int w;
              int h;
              if (!realhex)
              {
                x1 = (int) Math.Round((double) (Conversion.Int(num12 * (float) index19) + (float) num6));
                y1 = (int) Math.Round((double) (Conversion.Int(num13 * (float) index20) - d2 / 2f + (float) num7));
                if ((index19 + 10) % 2 > 0)
                  y1 = (int) Math.Round((double) ((float) y1 + d2 / 2f));
                w = (int) Math.Round((double) (num12 + 1f));
                h = (int) Math.Round((double) (num13 + 1f));
              }
              else
              {
                x1 = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num12) * (double) index19 + (double) num6)));
                y1 = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num13) * (double) index20) - Math.Floor((double) d2 / 2.0) + (double) num7));
                if ((index19 + 10) % 2 > 0)
                  y1 = (int) Math.Round((double) y1 + Math.Floor((double) d2 / 2.0));
                w = (int) Math.Round(Math.Floor((double) num12));
                h = (int) Math.Round(Math.Floor((double) num13));
              }
              DrawMod.DrawBlock(ref Expression, x1, y1, w, h, 0, 0, 0, 100);
            }
          }
        }
      }
      if (((!realhex ? 1 : 0) | 1) != 0)
      {
        int mapWidth4 = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth;
        for (int index25 = 0; index25 <= mapWidth4; ++index25)
        {
          int mapHeight = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight;
          for (int index26 = 0; index26 <= mapHeight; ++index26)
          {
            int index27 = index25;
            int index28 = index26;
            if (this.game.EditObj.MiniMapOffset > 0)
            {
              index27 += this.game.EditObj.MiniMapOffset;
              if (index27 > this.game.Data.MapObj[0].MapWidth)
                index27 -= this.game.Data.MapObj[0].MapWidth + 1;
            }
            int num45 = 1;
            if (this.game.Data.ShrowdOn & !this.game.Data.ShrowdPeek)
            {
              num45 = 0;
              if (this.game.Data.Round > 0 && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index27, index28].get_SeeNow(Index) > 0 | this.game.Data.Turn == Index & (this.game.Data.MapObj[0].HexObj[index27, index28].MaxRecon > 0 | !this.game.Data.ShrowdOn))
                num45 = 1;
            }
            if (this.game.Data.Round > 0 && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index27, index28].get_SeeNow(Index) < 1 | this.game.Data.Turn == Index & this.game.Data.MapObj[0].HexObj[index27, index28].MaxRecon < 1 & this.game.Data.ShrowdOn && this.game.Data.ShrowdPeek)
              num45 = 0;
            int num46;
            int num47;
            if (num45 == 1)
            {
              if ((double) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index27, index28].VP >= (double) this.game.Data.RuleVar[148] & (double) this.game.Data.RuleVar[148] != 0.0)
              {
                int num48;
                int num49;
                if (!realhex)
                {
                  num46 = (int) Math.Round((double) (Conversion.Int(num12 * (float) index25) + (float) num6));
                  int num50 = (int) Math.Round((double) (Conversion.Int(num13 * (float) index26) - d2 / 2f + (float) num7));
                  if ((index25 + 10) % 2 > 0)
                    num47 = (int) Math.Round((double) ((float) num50 + d2 / 2f));
                  num48 = (int) Math.Round((double) num12);
                  num49 = (int) Math.Round((double) num13);
                }
                else
                {
                  num46 = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num12) * (double) index25 + (double) num6)));
                  int num51 = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num13) * (double) index26) - Math.Floor((double) d2 / 2.0) + (double) num7));
                  if ((index25 + 10) % 2 > 0)
                    num47 = (int) Math.Round((double) num51 + Math.Floor((double) d2 / 2.0));
                  num48 = (int) Math.Round(Math.Floor((double) num12));
                  num49 = (int) Math.Round(Math.Floor((double) num13));
                }
                int w = num48 * 1;
                int h = num49 * 1;
                if (w < 8)
                  w = 8;
                if (h < 8)
                  h = 8;
                int x1;
                int y1;
                if (realhex)
                {
                  x1 = (int) Math.Round(Conversion.Int(Math.Floor((double) num12) * (double) index25) + (double) num6 + (double) (int) Math.Round(Math.Floor(((double) num12 - (double) w) / 2.0)));
                  y1 = (int) Math.Round(Conversion.Int(Math.Floor((double) num13) * (double) index26) - Math.Floor((double) d2 / 2.0) + (double) num7 + (double) (int) Math.Round(Math.Floor(((double) num13 - (double) h) / 2.0)));
                }
                else
                {
                  x1 = (int) Math.Round((double) (Conversion.Int(num12 * (float) index25) + (float) num6 + (float) (int) Math.Round(((double) num12 - (double) w) / 2.0)));
                  y1 = (int) Math.Round((double) (Conversion.Int(num13 * (float) index26) - d2 / 2f + (float) num7 + (float) (int) Math.Round(((double) num13 - (double) h) / 2.0)));
                }
                if ((index25 + 10) % 2 > 0)
                  y1 = (int) Math.Round((double) ((float) y1 + d2 / 2f));
                DrawMod.DrawBlock(ref Expression, x1, y1, w, h, 0, 0, 0, (int) byte.MaxValue);
                DrawMod.DrawRectangle(ref Expression, x1, y1, w, h, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
              }
              else if ((double) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index27, index28].VP >= (double) this.game.Data.RuleVar[149] & (double) this.game.Data.RuleVar[149] != 0.0)
              {
                int num52;
                int num53;
                if (!realhex)
                {
                  num46 = (int) Math.Round((double) (Conversion.Int(num12 * (float) index25) + (float) num6));
                  int num54 = (int) Math.Round((double) (Conversion.Int(num13 * (float) index26) - d2 / 2f + (float) num7));
                  if ((index25 + 10) % 2 > 0)
                    num47 = (int) Math.Round((double) ((float) num54 + d2 / 2f));
                  num52 = (int) Math.Round((double) num12);
                  num53 = (int) Math.Round((double) num13);
                }
                else
                {
                  num46 = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num12) * (double) index25 + (double) num6)));
                  int num55 = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num13) * (double) index26) - Math.Floor((double) d2 / 2.0) + (double) num7));
                  if ((index25 + 10) % 2 > 0)
                    num47 = (int) Math.Round((double) num55 + Math.Floor((double) d2 / 2.0));
                  num52 = (int) Math.Round(Math.Floor((double) num12));
                  num53 = (int) Math.Round(Math.Floor((double) num13));
                }
                int w = (int) Math.Round((double) num52 * 0.5);
                int h = (int) Math.Round((double) num53 * 0.5);
                if (w < 4)
                  w = 4;
                if (h < 4)
                  h = 4;
                int x1;
                int y1;
                if (realhex)
                {
                  x1 = (int) Math.Round(Conversion.Int(Math.Floor((double) num12) * (double) index25) + (double) num6 + (double) (int) Math.Round(Math.Floor(((double) num12 - (double) w) / 2.0)));
                  y1 = (int) Math.Round(Conversion.Int(Math.Floor((double) num13) * (double) index26) - Math.Floor((double) d2 / 2.0) + (double) num7 + (double) (int) Math.Round(Math.Floor(((double) num13 - (double) h) / 2.0)));
                }
                else
                {
                  x1 = (int) Math.Round((double) (Conversion.Int(num12 * (float) index25) + (float) num6 + (float) (int) Math.Round(((double) num12 - (double) w) / 2.0)));
                  y1 = (int) Math.Round((double) (Conversion.Int(num13 * (float) index26) - d2 / 2f + (float) num7 + (float) (int) Math.Round(((double) num13 - (double) h) / 2.0)));
                }
                if ((index25 + 10) % 2 > 0)
                  y1 = (int) Math.Round((double) ((float) y1 + d2 / 2f));
                DrawMod.DrawBlock(ref Expression, x1, y1, w, h, 0, 0, 0, (int) byte.MaxValue);
                DrawMod.DrawRectangle(ref Expression, x1, y1, w, h, 220, 220, 220, (int) byte.MaxValue);
              }
              else if (this.game.Data.MapObj[0].HexObj[index27, index28].Location > -1 & tempBmp.Width > 300)
              {
                int num56;
                int num57;
                if (!realhex)
                {
                  num46 = (int) Math.Round((double) (Conversion.Int(num12 * (float) index25) + (float) num6));
                  int num58 = (int) Math.Round((double) (Conversion.Int(num13 * (float) index26) - d2 / 2f + (float) num7));
                  if ((index25 + 10) % 2 > 0)
                    num47 = (int) Math.Round((double) ((float) num58 + d2 / 2f));
                  num56 = (int) Math.Round((double) num12);
                  num57 = (int) Math.Round((double) num13);
                }
                else
                {
                  num46 = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num12) * (double) index25 + (double) num6)));
                  int num59 = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num13) * (double) index26) - Math.Floor((double) d2 / 2.0) + (double) num7));
                  if ((index25 + 10) % 2 > 0)
                    num47 = (int) Math.Round((double) num59 + Math.Floor((double) d2 / 2.0));
                  num56 = (int) Math.Round(Math.Floor((double) num12));
                  num57 = (int) Math.Round(Math.Floor((double) num13));
                }
                int w = (int) Math.Round((double) num56 * 0.33);
                int h = (int) Math.Round((double) num57 * 0.33);
                if (w < 3)
                  w = 3;
                if (h < 3)
                  h = 3;
                int x1;
                int y1;
                if (realhex)
                {
                  x1 = (int) Math.Round(Conversion.Int(Math.Floor((double) num12) * (double) index25) + (double) num6 + (double) (int) Math.Round(Math.Floor(((double) num12 - (double) w) / 2.0)));
                  y1 = (int) Math.Round(Conversion.Int(Math.Floor((double) num13) * (double) index26) - Math.Floor((double) d2 / 2.0) + (double) num7 + (double) (int) Math.Round(Math.Floor(((double) num13 - (double) h) / 2.0)));
                }
                else
                {
                  x1 = (int) Math.Round((double) (Conversion.Int(num12 * (float) index25) + (float) num6 + (float) (int) Math.Round(((double) num12 - (double) w) / 2.0)));
                  y1 = (int) Math.Round((double) (Conversion.Int(num13 * (float) index26) - d2 / 2f + (float) num7 + (float) (int) Math.Round(((double) num13 - (double) h) / 2.0)));
                }
                if ((index25 + 10) % 2 > 0)
                  y1 = (int) Math.Round((double) ((float) y1 + d2 / 2f));
                DrawMod.DrawBlock(ref Expression, x1, y1, w, h, 0, 0, 0, (int) byte.MaxValue);
                DrawMod.DrawRectangle(ref Expression, x1, y1, w, h, 220, 220, 220, (int) byte.MaxValue);
              }
            }
          }
        }
      }
      if ((double) this.game.Data.RuleVar[148] > 0.0 | (double) this.game.Data.RuleVar[149] > 0.0 && realhex | alsounits && predrawn | alsounits)
      {
        int mapWidth5 = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth;
        int num60;
        for (int index29 = 0; index29 <= mapWidth5; ++index29)
        {
          int mapHeight = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight;
          for (int index30 = 0; index30 <= mapHeight; ++index30)
          {
            int x = index29;
            int y = index30;
            if (this.game.EditObj.MiniMapOffset > 0)
            {
              x += this.game.EditObj.MiniMapOffset;
              if (x > this.game.Data.MapObj[0].MapWidth)
                x -= this.game.Data.MapObj[0].MapWidth + 1;
            }
            int num61 = 1;
            if (this.game.Data.ShrowdOn & !this.game.Data.ShrowdPeek)
            {
              num61 = 0;
              if (this.game.Data.Round > 0 && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[x, y].get_SeeNow(Index) > 0 | this.game.Data.Turn == Index & (this.game.Data.MapObj[0].HexObj[x, y].MaxRecon > 0 | !this.game.Data.ShrowdOn))
                num61 = 1;
            }
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[x, y].get_SeeNow(Index) < 1 | this.game.Data.Turn == Index & this.game.Data.MapObj[0].HexObj[x, y].MaxRecon < 1 & this.game.Data.ShrowdOn && this.game.Data.ShrowdPeek & (double) this.game.Data.RuleVar[874] == 1.0)
              num61 = 0;
            if (!realhex & alsounits)
              num61 = 0;
            if (this.game.Data.MapObj[0].HexObj[x, y].MaxRecon < 1 & this.game.Data.ShrowdOn)
              num61 = 0;
            if (num61 == 1 && !((double) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[x, y].VP >= (double) this.game.Data.RuleVar[148] & (double) this.game.Data.RuleVar[148] != 0.0) && (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[x, y].VP >= (double) this.game.Data.RuleVar[149] & (double) this.game.Data.RuleVar[149] != 0.0)
            {
              int num62;
              int num63;
              int num64;
              int num65;
              if (!realhex)
              {
                num62 = (int) Math.Round((double) (Conversion.Int(num12 * (float) index29) + (float) num6));
                num63 = (int) Math.Round((double) (Conversion.Int(num13 * (float) index30) - d2 / 2f + (float) num7));
                if ((index29 + 10) % 2 > 0)
                  num63 = (int) Math.Round((double) ((float) num63 + d2 / 2f));
                num64 = (int) Math.Round((double) num12);
                num65 = (int) Math.Round((double) num13);
              }
              else
              {
                num62 = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num12) * (double) index29 + (double) num6)));
                num63 = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num13) * (double) index30) - Math.Floor((double) d2 / 2.0) + (double) num7));
                if ((index29 + 10) % 2 > 0)
                  num63 = (int) Math.Round((double) num63 + Math.Floor((double) d2 / 2.0));
                num64 = (int) Math.Round(Math.Floor((double) num12));
                num65 = (int) Math.Round(Math.Floor((double) num13));
              }
              int num66 = (int) Math.Round((double) num62 - (double) num64 / 2.0);
              int num67 = (int) Math.Round((double) num63 - (double) num65 / 2.0);
              num60 = num64 * 2;
              int num68 = num65 * 2;
              if (num67 < 1)
                num67 = 1;
              if ((double) num66 - (double) sizeF.Width / 2.0 < 2.0)
                num66 = (int) Math.Round((double) ((float) num66 + sizeF.Width / 2f));
              if ((double) num66 + (double) sizeF.Width / 2.0 > (double) bwidth)
                num66 = (int) Math.Round((double) ((float) num66 - sizeF.Width / 2f));
              string str7 = Strings.UCase(this.game.HandyFunctionsObj.GetHexName(x, y, this.game.EditObj.MapSelected));
              sizeF = (double) this.game.Data.RuleVar[839] >= 1.0 ? Expression.MeasureString(str7, this.game.MarcFont10) : Expression.MeasureString(str7, this.game.VicFont4);
              int num69 = (int) Math.Round((double) ((float) num66 - sizeF.Width / 2f));
              if ((double) num69 + (double) sizeF.Width > (double) tempBmp.Width)
                num69 = (int) Math.Round((double) ((float) num69 - ((float) num69 + sizeF.Width - (float) tempBmp.Width)));
              if (num69 < 0)
                num69 += -num69;
              if ((double) this.game.Data.RuleVar[839] < 1.0)
              {
                DrawMod.DrawBlock(ref Expression, num69, (int) Math.Round((double) num67 + (double) num68 / 2.0), (int) Math.Round((double) sizeF.Width), (int) Math.Round((double) sizeF.Height), 0, 0, 0, 196);
                DrawMod.DrawTextColouredMarc(ref Expression, str7, this.game.VicFont4, num69, (int) Math.Round((double) num67 + (double) num68 / 2.0), Color.White);
              }
              else
              {
                DrawMod.DrawBlock(ref Expression, num69, (int) Math.Round((double) num67 + (double) num68 / 2.0), (int) Math.Round((double) sizeF.Width), (int) Math.Round((double) sizeF.Height), 0, 0, 0, 128);
                DrawMod.DrawTextColouredMarc(ref Expression, str7, this.game.MarcFont10, num69, (int) Math.Round((double) num67 + (double) num68 / 2.0), Color.White);
              }
            }
          }
        }
        int mapWidth6 = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth;
        for (int index31 = 0; index31 <= mapWidth6; ++index31)
        {
          int mapHeight = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight;
          for (int index32 = 0; index32 <= mapHeight; ++index32)
          {
            int x = index31;
            int y = index32;
            if (this.game.EditObj.MiniMapOffset > 0)
            {
              x += this.game.EditObj.MiniMapOffset;
              if (x > this.game.Data.MapObj[0].MapWidth)
                x -= this.game.Data.MapObj[0].MapWidth + 1;
            }
            int num70 = 1;
            if (this.game.Data.ShrowdOn & !this.game.Data.ShrowdPeek)
            {
              num70 = 0;
              if (this.game.Data.Round > 0 && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[x, y].get_SeeNow(Index) > 0 | this.game.Data.Turn == Index & (this.game.Data.MapObj[0].HexObj[x, y].MaxRecon > 0 | !this.game.Data.ShrowdOn))
                num70 = 1;
            }
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[x, y].get_SeeNow(Index) < 1 | this.game.Data.Turn == Index & this.game.Data.MapObj[0].HexObj[x, y].MaxRecon < 1 & this.game.Data.ShrowdOn && this.game.Data.ShrowdPeek & (double) this.game.Data.RuleVar[874] == 1.0)
              num70 = 0;
            if (this.game.Data.MapObj[0].HexObj[x, y].MaxRecon < 1 & this.game.Data.ShrowdOn)
              num70 = 0;
            if (num70 == 1)
            {
              if ((double) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[x, y].VP >= (double) this.game.Data.RuleVar[149] & (double) this.game.Data.RuleVar[149] != 0.0)
              {
                int num71;
                int num72;
                int num73;
                int num74;
                if (!realhex)
                {
                  num71 = (int) Math.Round((double) (Conversion.Int(num12 * (float) index31) + (float) num6));
                  num72 = (int) Math.Round((double) (Conversion.Int(num13 * (float) index32) - d2 / 2f + (float) num7));
                  if ((index31 + 10) % 2 > 0)
                    num72 = (int) Math.Round((double) ((float) num72 + d2 / 2f));
                  num73 = (int) Math.Round((double) num12);
                  num74 = (int) Math.Round((double) num13);
                }
                else
                {
                  num71 = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num12) * (double) index31 + (double) num6)));
                  num72 = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num13) * (double) index32) - Math.Floor((double) d2 / 2.0) + (double) num7));
                  if ((index31 + 10) % 2 > 0)
                    num72 = (int) Math.Round((double) num72 + Math.Floor((double) d2 / 2.0));
                  num73 = (int) Math.Round(Math.Floor((double) num12));
                  num74 = (int) Math.Round(Math.Floor((double) num13));
                }
                int num75 = (int) Math.Round((double) num71 - (double) num73 / 2.0);
                int num76 = (int) Math.Round((double) num72 - (double) num74 / 2.0);
                num60 = num73 * 2;
                int num77 = num74 * 2;
                if (num76 < 1)
                  num76 = 1;
                if ((double) num75 - (double) sizeF.Width / 2.0 < 2.0)
                  num75 = (int) Math.Round((double) ((float) num75 + sizeF.Width / 2f));
                if ((double) num75 + (double) sizeF.Width / 2.0 > (double) bwidth)
                  num75 = (int) Math.Round((double) ((float) num75 - sizeF.Width / 2f));
                string str8 = Strings.UCase(this.game.HandyFunctionsObj.GetHexName(x, y, this.game.EditObj.MapSelected));
                sizeF = (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[x, y].VP < (double) this.game.Data.RuleVar[148] ? Expression.MeasureString(str8, this.game.MarcFont11b) : Expression.MeasureString(str8, this.game.MarcFont7);
                int num78 = (int) Math.Round((double) ((float) num75 - sizeF.Width / 2f));
                if ((double) num78 + (double) sizeF.Width > (double) tempBmp.Width)
                  num78 = (int) Math.Round((double) ((float) num78 - ((float) num78 + sizeF.Width - (float) tempBmp.Width)));
                if (num78 < 0)
                  num78 += -num78;
                if ((double) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[x, y].VP >= (double) this.game.Data.RuleVar[148])
                {
                  DrawMod.DrawBlock(ref Expression, num78, (int) Math.Round((double) num76 + (double) num77 / 2.0), (int) Math.Round((double) sizeF.Width), (int) Math.Round((double) sizeF.Height), 0, 0, 0, 128);
                  DrawMod.DrawTextColouredMarc(ref Expression, str8, this.game.MarcFont7, num78, (int) Math.Round((double) num76 + (double) num77 / 2.0), Color.White);
                }
                else
                {
                  DrawMod.DrawBlock(ref Expression, num78, (int) Math.Round((double) num76 + (double) num77 / 2.0), (int) Math.Round((double) sizeF.Width), (int) Math.Round((double) sizeF.Height), 0, 0, 0, 128);
                  DrawMod.DrawTextColouredMarc(ref Expression, str8, this.game.MarcFont11b, num78, (int) Math.Round((double) num76 + (double) num77 / 2.0), Color.White);
                }
              }
              else
              {
                int num79 = (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[x, y].VP >= (double) this.game.Data.RuleVar[149] & (double) this.game.Data.RuleVar[149] != 0.0 ? 1 : 0;
              }
            }
          }
        }
        Rectangle[] rectangleArray = new Rectangle[10000];
        int index33 = -1;
        int num80 = (int) Math.Round((double) num6 / 2.0);
        if (alsoHQ)
        {
          int num81 = 1;
          do
          {
            int regimeCounter2 = this.game.Data.RegimeCounter;
            for (int nr = 0; nr <= regimeCounter2; ++nr)
            {
              if (num81 == 1 & this.game.HandyFunctionsObj.GetRegime(nr) == this.game.HandyFunctionsObj.GetRegime(index1) | num81 == 2 & this.game.HandyFunctionsObj.GetRegime(nr) != this.game.HandyFunctionsObj.GetRegime(index1))
              {
                int num82 = 5;
                do
                {
                  int unitCounter = this.game.Data.UnitCounter;
                  for (int index34 = 0; index34 <= unitCounter; ++index34)
                  {
                    if (this.game.Data.UnitObj[index34].Historical > -1 & this.game.Data.UnitObj[index34].Regime == nr && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index34].Historical].Type == num82 && this.game.Data.UnitObj[index34].IsHQ)
                    {
                      coordinate = this.game.HandyFunctionsObj.GetAverageHQCoordinate(index34);
                      if (coordinate.onmap)
                      {
                        int x = coordinate.x;
                        int y = coordinate.y;
                        int num83 = x;
                        int num84 = y;
                        if (this.game.EditObj.MiniMapOffset > 0)
                        {
                          num83 -= this.game.EditObj.MiniMapOffset;
                          if (num83 < 0)
                            num83 += this.game.Data.MapObj[0].MapWidth;
                        }
                        int num85;
                        int num86;
                        int num87;
                        int num88;
                        if (!realhex)
                        {
                          num85 = (int) Math.Round((double) (Conversion.Int(num12 * (float) num83) + (float) num6));
                          num86 = (int) Math.Round((double) (Conversion.Int(num13 * (float) num84) - d2 / 2f + (float) num7));
                          if ((num83 + 10) % 2 > 0)
                            num86 = (int) Math.Round((double) ((float) num86 + d2 / 2f));
                          num87 = (int) Math.Round((double) num12);
                          num88 = (int) Math.Round((double) num13);
                        }
                        else
                        {
                          num85 = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num12) * (double) num83 + (double) num6)));
                          num86 = (int) Math.Round(Conversion.Int(Math.Floor(Math.Floor((double) num13) * (double) num84) - Math.Floor((double) d2 / 2.0) + (double) num7));
                          if ((num83 + 10) % 2 > 0)
                            num86 = (int) Math.Round((double) num86 + Math.Floor((double) d2 / 2.0));
                          num87 = (int) Math.Round(Math.Floor((double) num12));
                          num88 = (int) Math.Round(Math.Floor((double) num13));
                        }
                        string str9 = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index34].Historical].CounterString;
                        if (str9.Length > 6)
                          str9 = Strings.Left(str9, 6);
                        sizeF = this.game.ScreenHeight <= 800 ? (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index34].Historical].Type > 5 ? Expression.MeasureString(str9, this.game.MarcFont4) : Expression.MeasureString(str9, this.game.MarcFont10)) : (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index34].Historical].Type > 5 ? Expression.MeasureString(str9, this.game.MarcFont3) : Expression.MeasureString(str9, this.game.MarcFont4));
                        int num89 = 0;
                        int num90 = 0;
                        int num91 = 1;
                        int num92 = num85;
                        int num93 = num86;
                        int num94 = 0;
                        int num95 = 0;
                        int num96 = 0;
                        int num97 = 0;
                        int index35 = index33 + 1;
                        rectangleArray[index35] = new Rectangle(-100, -100, this.game.EditObj.MiniMap.Width + 200, 100);
                        int index36 = index35 + 1;
                        rectangleArray[index36] = new Rectangle(-100, this.game.EditObj.MiniMap.Height, this.game.EditObj.MiniMap.Width + 200 + num80, 100);
                        int index37 = index36 + 1;
                        rectangleArray[index37] = new Rectangle(-100, -100, 100, this.game.EditObj.MiniMap.Height + 100);
                        int index38 = index37 + 1;
                        rectangleArray[index38] = new Rectangle(this.game.EditObj.MiniMap.Width - num80, -100, 100 + num80, this.game.EditObj.MiniMap.Height + 100);
                        index33 = index38 + 1;
                        while (num89 == 0)
                        {
                          rectangleArray[index33] = new Rectangle((int) Math.Round((double) num85 + (double) num87 / 2.0 + 1.0 - (double) sizeF.Width / 2.0), num86 - 2 - 0, (int) Math.Round((double) (sizeF.Width - 2f)), (int) Math.Round((double) (sizeF.Height - 2f)));
                          num89 = -1;
                          int num98 = index33 - 1;
                          for (int index39 = 0; index39 <= num98; ++index39)
                          {
                            if (rectangleArray[index39].IntersectsWith(rectangleArray[index33]))
                            {
                              num89 = 0;
                              ++num90;
                              if (num90 > 4)
                              {
                                num90 = 1;
                                ++num91;
                              }
                              if (num90 == 1)
                              {
                                if (num94 == 0 & this.game.HandyFunctionsObj.GetRegime(this.game.Data.MapObj[0].HexObj[Math.Max(0, this.game.Data.UnitObj[index34].X - num91 * 4), this.game.Data.UnitObj[index34].Y].Regime) == this.game.HandyFunctionsObj.GetRegime(this.game.Data.UnitObj[index34].Regime) | this.game.Data.MapObj[0].HexObj[Math.Max(0, this.game.Data.UnitObj[index34].X - num91 * 4), this.game.Data.UnitObj[index34].Y].Regime == -1)
                                {
                                  num85 = num92 - 4 * num91;
                                }
                                else
                                {
                                  num85 = num92 - (int) Math.Round(0.5 * (double) num91);
                                  num94 = 1;
                                }
                              }
                              if (num90 == 2)
                              {
                                if (num95 == 0 & this.game.HandyFunctionsObj.GetRegime(this.game.Data.MapObj[0].HexObj[Math.Min(this.game.Data.MapObj[0].MapWidth, this.game.Data.UnitObj[index34].X + num91 * 4), this.game.Data.UnitObj[index34].Y].Regime) == this.game.HandyFunctionsObj.GetRegime(this.game.Data.UnitObj[index34].Regime) | this.game.Data.MapObj[0].HexObj[Math.Min(this.game.Data.MapObj[0].MapWidth, this.game.Data.UnitObj[index34].X + num91 * 4), this.game.Data.UnitObj[index34].Y].Regime == -1)
                                {
                                  num85 = num92 + 4 * num91;
                                }
                                else
                                {
                                  num85 = num92 + (int) Math.Round(0.5 * (double) num91);
                                  num95 = 1;
                                }
                              }
                              if (num90 == 3)
                              {
                                if (num96 == 0 & this.game.HandyFunctionsObj.GetRegime(this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index34].X, Math.Min(this.game.Data.MapObj[0].MapHeight, this.game.Data.UnitObj[index34].Y + num91 * 4)].Regime) == this.game.HandyFunctionsObj.GetRegime(this.game.Data.UnitObj[index34].Regime) | this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index34].X, Math.Min(this.game.Data.MapObj[0].MapHeight, this.game.Data.UnitObj[index34].Y + num91 * 4)].Regime == -1)
                                {
                                  num86 = num93 + 4 * num91;
                                }
                                else
                                {
                                  num86 = num93 + (int) Math.Round(0.5 * (double) num91);
                                  num96 = 1;
                                }
                              }
                              if (num90 == 4)
                              {
                                if (num97 == 0 & this.game.HandyFunctionsObj.GetRegime(this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index34].X, Math.Max(0, this.game.Data.UnitObj[index34].Y - num91 * 4)].Regime) == this.game.HandyFunctionsObj.GetRegime(this.game.Data.UnitObj[index34].Regime) | this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index34].X, Math.Max(0, this.game.Data.UnitObj[index34].Y - num91 * 4)].Regime == -1)
                                {
                                  num86 = num93 - 4 * num91;
                                  break;
                                }
                                num86 = num93 - (int) Math.Round(0.5 * (double) num91);
                                num97 = 1;
                                break;
                              }
                              break;
                            }
                          }
                          if (num91 > 49)
                            goto label_724;
                        }
                        int num99 = 0;
                        int num100 = 0;
                        int num101 = 0;
                        if (this.game.Data.UnitObj[index34].Historical > -1 & (double) this.game.Data.RuleVar[344] == 1.0)
                        {
                          num99 = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index34].Historical].Red;
                          num100 = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index34].Historical].Green;
                          num101 = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index34].Historical].Blue;
                        }
                        int num102 = num99 + this.game.Data.RegimeObj[nr].Red;
                        int num103 = num100 + this.game.Data.RegimeObj[nr].Green;
                        int num104 = num101 + this.game.Data.RegimeObj[nr].Blue;
                        int integer = Conversions.ToInteger(this.game.HandyFunctionsObj.GetUnitPeople(index34));
                        if (this.game.Data.PeopleObj[integer].Red > -1)
                        {
                          num102 = this.game.Data.PeopleObj[integer].Red;
                          num103 = this.game.Data.PeopleObj[integer].Green;
                          num104 = this.game.Data.PeopleObj[integer].Blue;
                        }
                        int a = (int) byte.MaxValue;
                        if (this.game.HandyFunctionsObj.GetRegime(this.game.Data.UnitObj[index34].Regime) != this.game.HandyFunctionsObj.GetRegime(index1))
                          a = 128;
                        DrawMod.DrawBlock(ref Expression, (int) Math.Round((double) num85 + (double) num87 / 2.0 - 0.0 - (double) sizeF.Width / 2.0), num86 - 3 - 0, (int) Math.Round((double) (sizeF.Width + 0.0f)), (int) Math.Round((double) (sizeF.Height + 0.0f)), (int) Math.Round((double) num102 / 2.5), (int) Math.Round((double) num103 / 2.5), (int) Math.Round((double) num104 / 2.5), a);
                        if (this.game.ScreenHeight > 800)
                        {
                          if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index34].Historical].Type <= 5)
                            DrawMod.DrawTextColouredMarc(ref Expression, str9, this.game.MarcFont4, (int) Math.Round((double) num85 + (double) num87 / 2.0 - (double) sizeF.Width / 2.0), num86 - 2, Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
                          else
                            DrawMod.DrawTextColouredMarc(ref Expression, str9, this.game.MarcFont3, (int) Math.Round((double) num85 + (double) num87 / 2.0 - (double) sizeF.Width / 2.0), num86 - 2, Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
                        }
                        else if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index34].Historical].Type <= 5)
                          DrawMod.DrawTextColouredMarc(ref Expression, str9, this.game.MarcFont10, (int) Math.Round((double) num85 + (double) num87 / 2.0 - (double) sizeF.Width / 2.0), num86 - 2, Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
                        else
                          DrawMod.DrawTextColouredMarc(ref Expression, str9, this.game.MarcFont4, (int) Math.Round((double) num85 + (double) num87 / 2.0 - (double) sizeF.Width / 2.0), num86 - 2, Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
                        DrawMod.DrawRectangle(ref Expression, (int) Math.Round((double) num85 + (double) num87 / 2.0 - (double) sizeF.Width / 2.0 - 0.0), num86 - 3 - 0, (int) Math.Round((double) (sizeF.Width + 0.0f)), (int) Math.Round((double) (sizeF.Height + 0.0f)), (int) Math.Round((double) num102 / 1.5), (int) Math.Round((double) num103 / 1.5), (int) Math.Round((double) num104 / 1.5), a);
                        ++index33;
                      }
                    }
                  }
label_724:
                  ++num82;
                }
                while (num82 <= 8);
              }
            }
            ++num81;
          }
          while (num81 <= 1);
        }
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
    }

    public Bitmap DrawSFTypeGraphic(
      int sfTypeNr,
      bool isMilitia,
      int cultureGroupId,
      int regimeNr,
      int fromUnr)
    {
      bool flag1 = false;
      if (fromUnr > -1 & fromUnr <= this.game.Data.UnitCounter && this.game.Data.UnitObj[fromUnr].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[fromUnr].Historical].TempVar1 == 1)
        flag1 = true;
      if (this.game.Data.SFTypeObj[sfTypeNr].Theater == 2)
        flag1 = true;
      int stringListById = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 441, 0, 0));
      int num1 = this.game.Data.SFTypeObj[sfTypeNr].SFTypeVar[89];
      int num2 = 0;
      int num3 = 0;
      if (this.game.Data.SFTypeObj[sfTypeNr].SFTypeVar[61] < 1 && this.game.Data.SFTypeObj[sfTypeNr].SFTypeVar[81] > 0)
        cultureGroupId = 105;
      int num4 = Math.Min((int) byte.MaxValue, this.game.Data.RegimeObj[regimeNr].Red + 30);
      int num5 = Math.Min((int) byte.MaxValue, this.game.Data.RegimeObj[regimeNr].Green + 30);
      int num6 = Math.Min((int) byte.MaxValue, this.game.Data.RegimeObj[regimeNr].Blue + 30);
      int num7 = (int) Math.Round((double) (num4 + num4 + 180) / 3.0);
      int num8 = (int) Math.Round((double) (num5 + num5 + 180) / 3.0);
      int num9 = (int) Math.Round((double) (num6 + num6 + 180) / 3.0);
      if (flag1)
      {
        num4 = Math.Min((int) byte.MaxValue, this.game.Data.RegimeObj[regimeNr].Red2 + 30);
        num5 = Math.Min((int) byte.MaxValue, this.game.Data.RegimeObj[regimeNr].Green2 + 30);
        num6 = Math.Min((int) byte.MaxValue, this.game.Data.RegimeObj[regimeNr].Blue2 + 30);
        num7 = (int) Math.Round((double) (num4 + 180 + 180) / 3.0);
        num8 = (int) Math.Round((double) (num5 + 180 + 180) / 3.0);
        num9 = (int) Math.Round((double) (num6 + 180 + 180) / 3.0);
      }
      int num10 = 99;
      int num11 = 99;
      int length1 = this.game.Data.StringListObj[stringListById].Length;
      for (int index1 = 0; index1 <= length1; ++index1)
      {
        if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index1, 0])) == num1 && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index1, 10])) > -1)
        {
          bool flag2 = true;
          int num12 = 0;
          do
          {
            int num13 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index1, 3 + num12 * 4]));
            if (num13 > 0)
            {
              int index2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index1, 2 + num12 * 4]));
              int num14 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index1, 4 + num12 * 4]));
              int num15 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index1, 5 + num12 * 4]));
              switch (num13)
              {
                case 1:
                  if (this.game.Data.SFTypeObj[sfTypeNr].SFTypeVar[index2] != num14)
                  {
                    flag2 = false;
                    break;
                  }
                  break;
                case 2:
                  if (this.game.Data.SFTypeObj[sfTypeNr].SFTypeVar[index2] < num14 | this.game.Data.SFTypeObj[sfTypeNr].SFTypeVar[index2] > num15)
                  {
                    flag2 = false;
                    break;
                  }
                  break;
                case 3:
                  if (cultureGroupId != num14)
                  {
                    flag2 = false;
                    break;
                  }
                  break;
              }
            }
            if (flag2)
              ++num12;
            else
              break;
          }
          while (num12 <= 1);
          if (flag2)
          {
            int num16 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index1, 13]));
            int num17 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index1, 14]));
            int num18 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index1, 16]));
            int num19 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index1, 17]));
            if (num16 > 0 & num17 > 0)
            {
              if (num16 > num2)
                num2 = num16;
              if (num17 > num3)
                num3 = num17;
              if (num18 + num19 < num10 + num11)
              {
                num10 = num18;
                num11 = num19;
              }
            }
          }
        }
      }
      if (!(num2 > 0 & num3 > 0))
        return (Bitmap) null;
      int width = num2 - (num10 + num11);
      int height = num3;
      Bitmap bitmap1 = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
      Graphics graphics = Graphics.FromImage((Image) bitmap1);
      graphics.Clear(Color.Transparent);
      int length2 = this.game.Data.StringListObj[stringListById].Length;
      for (int index3 = 0; index3 <= length2; ++index3)
      {
        if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index3, 0])) == num1)
        {
          bool flag3 = true;
          int num20 = 0;
          do
          {
            int num21 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index3, 3 + num20 * 4]));
            if (num21 > 0)
            {
              int index4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index3, 2 + num20 * 4]));
              int num22 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index3, 4 + num20 * 4]));
              int num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index3, 5 + num20 * 4]));
              switch (num21)
              {
                case 1:
                  if (this.game.Data.SFTypeObj[sfTypeNr].SFTypeVar[index4] != num22)
                  {
                    flag3 = false;
                    break;
                  }
                  break;
                case 2:
                  if (this.game.Data.SFTypeObj[sfTypeNr].SFTypeVar[index4] < num22 | this.game.Data.SFTypeObj[sfTypeNr].SFTypeVar[index4] > num23)
                  {
                    flag3 = false;
                    break;
                  }
                  break;
                case 3:
                  if (cultureGroupId != num22)
                  {
                    flag3 = false;
                    break;
                  }
                  break;
                case 4:
                  if (this.game.Data.SFTypeObj[sfTypeNr].SFTypeVar[index4] < num22)
                  {
                    flag3 = false;
                    break;
                  }
                  break;
                case 5:
                  if (this.game.Data.SFTypeObj[sfTypeNr].SFTypeVar[index4] > num22)
                  {
                    flag3 = false;
                    break;
                  }
                  break;
              }
            }
            if (flag3)
              ++num20;
            else
              break;
          }
          while (num20 <= 1);
          if (flag3)
          {
            int index5 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index3, 10]));
            int num24 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index3, 11]));
            int num25 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index3, 12]));
            int num26 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index3, 15]));
            int num27 = 1 + num24 * (num2 + 1);
            int y = 1 + num25 * (num3 + 1);
            Rectangle rectangle1;
            Rectangle rectangle2;
            switch (num26)
            {
              case 1:
                if (isMilitia)
                {
                  ref Graphics local1 = ref graphics;
                  Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.Data.EventPicNr[index5]);
                  ref Bitmap local2 = ref bitmap2;
                  rectangle2 = new Rectangle(num27 + num10, y, width, height);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(0, 0, width, height);
                  Rectangle destrect = rectangle1;
                  double r = (double) ((float) num7 / 256f);
                  double g = (double) ((float) num8 / 256f);
                  double b = (double) ((float) num9 / 256f);
                  DrawMod.DrawSimplePart2ColouredNew(ref local1, ref local2, srcrect, destrect, (float) r, (float) g, (float) b, 0.25f);
                  continue;
                }
                ref Graphics local3 = ref graphics;
                Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.Data.EventPicNr[index5]);
                ref Bitmap local4 = ref bitmap3;
                rectangle2 = new Rectangle(num27 + num10, y, width, height);
                Rectangle srcrect1 = rectangle2;
                rectangle1 = new Rectangle(0, 0, width, height);
                Rectangle destrect1 = rectangle1;
                double r1 = (double) ((float) num7 / 256f);
                double g1 = (double) ((float) num8 / 256f);
                double b1 = (double) ((float) num9 / 256f);
                DrawMod.DrawSimplePart2ColouredNew(ref local3, ref local4, srcrect1, destrect1, (float) r1, (float) g1, (float) b1, 1f);
                continue;
              case 2:
                if (isMilitia)
                {
                  ref Graphics local5 = ref graphics;
                  Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.Data.EventPicNr[index5]);
                  ref Bitmap local6 = ref bitmap4;
                  rectangle1 = new Rectangle(num27 + num10, y, width, height);
                  Rectangle srcrect2 = rectangle1;
                  rectangle2 = new Rectangle(0, 0, width, height);
                  Rectangle destrect2 = rectangle2;
                  double r2 = (double) ((float) num4 / 256f);
                  double g2 = (double) ((float) num5 / 256f);
                  double b2 = (double) ((float) num6 / 256f);
                  DrawMod.DrawSimplePart2ColouredNew(ref local5, ref local6, srcrect2, destrect2, (float) r2, (float) g2, (float) b2, 0.25f);
                  continue;
                }
                ref Graphics local7 = ref graphics;
                Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.Data.EventPicNr[index5]);
                ref Bitmap local8 = ref bitmap5;
                rectangle2 = new Rectangle(num27 + num10, y, width, height);
                Rectangle srcrect3 = rectangle2;
                rectangle1 = new Rectangle(0, 0, width, height);
                Rectangle destrect3 = rectangle1;
                double r3 = (double) ((float) num4 / 256f);
                double g3 = (double) ((float) num5 / 256f);
                double b3 = (double) ((float) num6 / 256f);
                DrawMod.DrawSimplePart2ColouredNew(ref local7, ref local8, srcrect3, destrect3, (float) r3, (float) g3, (float) b3, 1f);
                continue;
              default:
                ref Graphics local9 = ref graphics;
                Bitmap bitmap6 = BitmapStore.GetBitmap(DrawMod.TGame.Data.EventPicNr[index5]);
                ref Bitmap local10 = ref bitmap6;
                rectangle2 = new Rectangle(num27 + num10, y, width, height);
                Rectangle srcrect4 = rectangle2;
                rectangle1 = new Rectangle(0, 0, width, height);
                Rectangle destrect4 = rectangle1;
                DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect4, destrect4);
                continue;
            }
          }
        }
      }
      graphics.Dispose();
      return bitmap1;
    }

    public Bitmap DrawUnitSmall(
      int nr,
      bool forcehighlight = false,
      Graphics toG = null,
      int tx = 0,
      int ty = 0,
      bool ShowAttacker = false,
      int OverruleHis = -1,
      int OverrulePower = -1,
      int OverruleRegime = -1,
      bool FullRecon = false)
    {
      Coordinate coordinate = new Coordinate();
      SizeF sizeF1 = new SizeF();
      SizeF sizeF2 = new SizeF();
      int[] numArray1 = new int[1];
      int[] numArray2 = this.game.Data.SFTypeCounter >= 101 ? new int[this.game.Data.SFTypeCounter + 1] : new int[101];
      if ((double) this.game.Data.RuleVar[344] == 1.0 & this.game.EditObj.HideUnit == 0)
        this.game.EditObj.HideUnit = 2;
      if (!Information.IsNothing((object) toG))
      {
        this.g2 = toG;
      }
      else
      {
        this.g2 = Graphics.FromImage((Image) this.tmpbmp2b);
        this.g2.Clear(Color.FromArgb(0, 0, 0, 0));
      }
      bool isMilitia = OverruleHis != -1 ? this.game.Data.HistoricalUnitObj[OverruleHis].GiveHisVarValue(11) > 0 : this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].GiveHisVarValue(11) > 0;
      int index1;
      bool flag1;
      int regime1;
      int integer1;
      int index2;
      Bitmap bitmap1;
      float num1;
      float num2;
      float num3;
      if (OverruleHis == -1)
      {
        if (this.game.Data.UnitObj[nr].Regime == this.game.Data.Turn | this.game.Data.Round < 1 | !this.game.Data.FOWOn)
          coordinate.x = 3;
        else
          coordinate = this.game.HandyFunctionsObj.GetReconMinusHide(nr, this.game.Data.Turn);
        index1 = !this.game.Data.UnitObj[nr].IsHQ ? this.game.Data.UnitObj[nr].HQ : nr;
        flag1 = !(this.game.Data.UnitObj[nr].Regime == this.game.Data.Turn & this.game.Data.Round > 0) || this.game.Data.UnitObj[nr].X > -1 && this.game.HandyFunctionsObj.CanUnitMove2(nr);
        bool flag2 = false;
        if (Information.IsNothing((object) this.game.EditObj.TempUnitList))
          this.game.EditObj.TempUnitList = new UnitList();
        bool flag3;
        if (this.game.EditObj.OrderType == 2 && this.game.EditObj.TempUnitList.CheckIfPresent(nr))
        {
          flag2 = false;
          flag3 = true;
        }
        if (this.game.EditObj.OrderType == 12 && this.game.EditObj.TempUnitList.CheckIfPresent(nr))
        {
          flag2 = false;
          flag3 = true;
        }
        if (this.game.EditObj.OrderType == 11 && this.game.EditObj.TempUnitList.CheckIfPresent(nr))
        {
          flag2 = false;
          flag3 = true;
        }
        if (this.game.EditObj.OrderType == 13 && this.game.EditObj.TempUnitList.CheckIfPresent(nr))
        {
          flag2 = false;
          flag3 = true;
        }
        if (this.game.EditObj.OrderType == 14 && this.game.EditObj.TempUnitList.CheckIfPresent(nr))
        {
          flag2 = false;
          flag3 = true;
        }
        if (this.game.EditObj.OrderType == 15 && this.game.EditObj.TempUnitList.CheckIfPresent(nr))
        {
          flag2 = false;
          flag3 = true;
        }
        if (this.game.EditObj.OrderType == 9)
        {
          if (this.game.EditObj.OrderUnit == nr)
            flag2 = true;
          if (this.game.EditObj.OrderTarget == nr)
            flag2 = true;
        }
        if (this.game.EditObj.OrderType == 3 && this.game.EditObj.OrderUnit == nr)
          flag2 = true;
        if (this.game.EditObj.OrderType == 19)
        {
          if (this.game.EditObj.OrderUnit == nr)
            flag2 = true;
          if (this.game.EditObj.OrderTarget == nr)
            flag2 = true;
        }
        if (this.game.EditObj.OrderType == 33 && this.game.EditObj.OrderUnit == nr)
          flag2 = true;
        if (forcehighlight && this.game.EditObj.UnitSelected == nr)
          flag2 = true;
        if (this.game.EditObj.LayerSupplyOn && this.game.EditObj.LayerSupplyHQ == this.game.Data.UnitObj[nr].HQ)
          flag2 = true;
        regime1 = this.game.Data.UnitObj[nr].Regime;
        integer1 = Conversions.ToInteger(this.game.HandyFunctionsObj.GetUnitPeople(nr));
        index2 = regime1;
        if (this.game.Data.PeopleObj[integer1].RegCol > -1)
          index2 = this.game.Data.PeopleObj[integer1].RegCol;
        if (Information.IsNothing((object) this.game.Data.RegimeObj[index2].TempCountersmall))
          this.game.Data.RegimeObj[index2].DoTempCounterSmall();
        if (OverruleRegime > -1 && Information.IsNothing((object) this.game.Data.RegimeObj[OverruleRegime].TempCountersmall))
          this.game.Data.RegimeObj[OverruleRegime].DoTempCounterSmall();
        if (this.game.Data.UnitObj[nr].Regime == -1)
        {
          ref Graphics local1 = ref this.g2;
          bitmap1 = BitmapStore.GetBitmap(this.game.DEFAULTCOUNTER);
          ref Bitmap local2 = ref bitmap1;
          int x = tx;
          int y = ty;
          DrawMod.DrawSimple(ref local1, ref local2, x, y);
        }
        else
        {
          int landscapeType = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[nr].X, this.game.Data.UnitObj[nr].Y].LandscapeType;
          int red;
          int green;
          int blue;
          if (this.game.Data.UnitObj[nr].Historical > -1 & (double) this.game.Data.RuleVar[344] == 1.0)
          {
            red = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Red;
            green = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Green;
            blue = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Blue;
          }
          if (red != 0 | green != 0 | blue != 0 | isMilitia)
          {
            if (!flag2)
            {
              float num4 = (float) ((int) byte.MaxValue + red) / 256f;
              float num5 = (float) ((int) byte.MaxValue + green) / 256f;
              float num6 = (float) ((int) byte.MaxValue + blue) / 256f;
              if ((double) num4 > 1.0)
                num4 = 1f;
              if ((double) num5 > 1.0)
                num5 = 1f;
              if ((double) num6 > 1.0)
                num6 = 1f;
              if (0.0 > (double) num4)
                num1 = 0.0f;
              if (0.0 > (double) num5)
                num2 = 0.0f;
              if (0.0 > (double) num6)
                num3 = 0.0f;
              if (isMilitia)
                DrawMod.DrawSimplePart2(ref this.g2, ref this.game.Data.RegimeObj[regime1].TempCountersmallHigh, new Rectangle(19 * landscapeType, 0, 19, 19), new Rectangle(tx, ty, 19, 19));
              else
                DrawMod.DrawSimplePart2(ref this.g2, ref this.game.Data.RegimeObj[regime1].TempCountersmall, new Rectangle(19 * landscapeType, 0, 19, 19), new Rectangle(tx, ty, 19, 19));
              if (flag3 & ShowAttacker)
                DrawMod.DrawRectangle(ref this.g2, tx, ty, 19, 19, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
              if (flag3 & ShowAttacker)
                DrawMod.DrawRectangle(ref this.g2, tx + 1, ty + 1, 18, 18, 0, 0, 0, (int) byte.MaxValue);
            }
            else
            {
              float num7 = (float) ((int) byte.MaxValue + red) / 256f;
              float num8 = (float) ((int) byte.MaxValue + green) / 256f;
              float num9 = (float) ((int) byte.MaxValue + blue) / 256f;
              if ((double) num7 > 1.0)
                num7 = 1f;
              if ((double) num8 > 1.0)
                num8 = 1f;
              if ((double) num9 > 1.0)
                num9 = 1f;
              if (0.0 > (double) num7)
                num1 = 0.0f;
              if (0.0 > (double) num8)
                num2 = 0.0f;
              if (0.0 > (double) num9)
                num3 = 0.0f;
              if (isMilitia)
                DrawMod.DrawSimplePart2(ref this.g2, ref this.game.Data.RegimeObj[regime1].TempCountersmallHigh, new Rectangle(19 * landscapeType, 0, 19, 19), new Rectangle(tx, ty, 19, 19));
              else
                DrawMod.DrawSimplePart2(ref this.g2, ref this.game.Data.RegimeObj[regime1].TempCountersmall, new Rectangle(19 * landscapeType, 0, 19, 19), new Rectangle(tx, ty, 19, 19));
              if (flag3 & ShowAttacker)
                DrawMod.DrawRectangle(ref this.g2, tx, ty, 19, 19, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
              if (flag3 & ShowAttacker)
                DrawMod.DrawRectangle(ref this.g2, tx + 1, ty + 1, 18, 18, 0, 0, 0, (int) byte.MaxValue);
            }
          }
          else if (!flag2)
          {
            DrawMod.DrawSimplePart2(ref this.g2, ref this.game.Data.RegimeObj[regime1].TempCountersmall, new Rectangle(19 * landscapeType, 0, 19, 19), new Rectangle(tx, ty, 19, 19));
            if (flag3 & ShowAttacker)
              DrawMod.DrawRectangle(ref this.g2, tx, ty, 19, 19, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
            if (flag3 & ShowAttacker)
              DrawMod.DrawRectangle(ref this.g2, tx + 1, ty + 1, 18, 18, 0, 0, 0, (int) byte.MaxValue);
          }
          else
          {
            DrawMod.DrawSimplePart2(ref this.g2, ref this.game.Data.RegimeObj[regime1].TempCountersmallHigh, new Rectangle(19 * landscapeType, 0, 19, 19), new Rectangle(tx, ty, 19, 19));
            if (flag3 & ShowAttacker)
              DrawMod.DrawRectangle(ref this.g2, tx, ty, 19, 19, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
            if (flag3 & ShowAttacker)
              DrawMod.DrawRectangle(ref this.g2, tx + 1, ty + 1, 18, 18, 0, 0, 0, (int) byte.MaxValue);
          }
        }
      }
      else
      {
        int num10 = OverruleHis > -1 & OverruleRegime > -1 ? 1 : 0;
      }
      if (index1 > -1 & !this.game.Data.UnitObj[nr].IsHQ)
      {
        if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index1].Historical].Type < 8)
        {
          int red = this.game.Data.UnitObj[index1].Red;
          int green = this.game.Data.UnitObj[index1].Green;
          int blue = this.game.Data.UnitObj[index1].Blue;
          DrawMod.DrawBlockGradient2(ref this.g2, tx, ty + 12, 18, 6, Color.FromArgb(0, red, green, blue), Color.FromArgb(235, red, green, blue));
        }
      }
      else if (this.game.Data.UnitObj[nr].IsHQ & this.game.Data.UnitObj[nr].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Type < 8)
      {
        int red = this.game.Data.UnitObj[nr].Red;
        int green = this.game.Data.UnitObj[nr].Green;
        int blue = this.game.Data.UnitObj[nr].Blue;
        DrawMod.DrawBlockGradient2(ref this.g2, tx, ty + 1, 18, 17, Color.FromArgb(0, red, green, blue), Color.FromArgb(205, red, green, blue));
      }
      if (OverruleHis == -1)
      {
        int num11 = 0;
        if (this.game.Data.UnitObj[nr].HQ == -1 & !this.game.Data.UnitObj[nr].IsHQ)
          num11 = 0;
        if (!this.game.EditObj.PrefMinimalistCounter && (double) this.game.Data.RuleVar[847] == 1.0)
        {
          ref Graphics local3 = ref this.g2;
          bitmap1 = BitmapStore.GetBitmap(this.game.Data.RegimeObj[index2].NationalIconSprite);
          ref Bitmap local4 = ref bitmap1;
          int x = tx;
          int y = ty;
          DrawMod.DrawScaled(ref local3, ref local4, x, y, 4, 4);
        }
        int num12 = -1;
        int num13 = -1;
        int sfTypeNr;
        int num14;
        if (coordinate.x > 1)
        {
          if (!this.game.Data.UnitObj[nr].IsHQ)
          {
            int sfCount1 = this.game.Data.UnitObj[nr].SFCount;
            int nr1;
            for (int index3 = 0; index3 <= sfCount1; ++index3)
            {
              nr1 = this.game.Data.UnitObj[nr].SFList[index3];
              int index4 = this.game.Data.SFObj[nr1].Type;
              int qty = this.game.Data.SFObj[nr1].Qty;
              if (this.game.Data.UnitObj[nr].X > -1 && index4 > -1 && this.game.Data.SFTypeObj[index4].Theater != 1 & this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.UnitObj[nr].X, this.game.Data.UnitObj[nr].Y].LandscapeType].IsSea)
                index4 = -1;
              if (index4 > -1)
              {
                int symbolGroup = this.game.Data.SFTypeObj[index4].SymbolGroup;
                int symbolWeight = this.game.Data.SFTypeObj[index4].SymbolWeight;
                if (symbolGroup > -1)
                {
                  numArray2[symbolGroup] = numArray2[symbolGroup] + symbolWeight * qty * 10;
                  if (this.game.Data.SFTypeObj[index4].CarryCap > 0)
                    numArray2[symbolGroup] = numArray2[symbolGroup] + 1;
                  if (numArray2[symbolGroup] > num13)
                  {
                    num13 = numArray2[symbolGroup];
                    sfTypeNr = symbolGroup;
                  }
                }
              }
            }
            if (sfTypeNr > -1 | this.game.Data.UnitObj[nr].Historical > -1 & this.game.EditObj.HideUnit == 2 | (double) this.game.Data.RuleVar[344] == 0.0)
            {
              int num15 = sfTypeNr;
              sfTypeNr = -1;
              int index5 = -1;
              int num16 = 0;
              int sfTypeCounter = this.game.Data.SFTypeCounter;
              for (int index6 = 0; index6 <= sfTypeCounter; ++index6)
                numArray2[index6] = 0;
              int sfCount2 = this.game.Data.UnitObj[nr].SFCount;
              for (int index7 = 0; index7 <= sfCount2; ++index7)
              {
                nr1 = this.game.Data.UnitObj[nr].SFList[index7];
                int type = this.game.Data.SFObj[nr1].Type;
                int qty = this.game.Data.SFObj[nr1].Qty;
                int symbolGroup = this.game.Data.SFTypeObj[type].SymbolGroup;
                int symbolWeight = this.game.Data.SFTypeObj[type].SymbolWeight;
                if (symbolGroup == num15)
                {
                  numArray2[type] = numArray2[type] + symbolWeight * qty * 10;
                  if (this.game.Data.SFTypeObj[type].CarryCap > 0)
                    numArray2[type] = numArray2[type] + 1;
                  if (numArray2[type] > num16)
                  {
                    num16 = numArray2[type];
                    sfTypeNr = type;
                    index5 = nr1;
                  }
                }
              }
              if (sfTypeNr > -1)
              {
                if ((0 & (this.game.Data.UnitObj[nr].Historical > -1 ? 1 : 0) & (this.game.Data.SFTypeObj[sfTypeNr].SFTypeVar[89] > 0 ? 1 : 0)) != 0)
                {
                  int tv0 = this.game.Data.PeopleObj[this.game.Data.SFObj[index5].People].tv0;
                  if (this.slotCulture < 0)
                    this.slotCulture = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 306, 0, 0));
                  int integer2 = Conversions.ToInteger(this.game.Data.StringListObj[this.slotCulture].GetData(0, tv0, 1));
                  Bitmap objBitmap = this.DrawSFTypeGraphic(sfTypeNr, isMilitia, integer2, regime1, nr);
                  if (!Information.IsNothing((object) objBitmap))
                  {
                    int num17 = 0;
                    int num18 = 0;
                    int w = 18;
                    int h = 18;
                    int width = objBitmap.Width;
                    int height = objBitmap.Height;
                    if (width > w | height > h)
                    {
                      if ((double) width / (double) w > (double) height / (double) h)
                      {
                        float num19 = (float) w / (float) width;
                        int num20 = (int) Math.Round((double) ((float) h - (float) height * num19));
                        num18 += (int) Math.Round((double) num20 / 2.0);
                        h -= num20;
                      }
                      else
                      {
                        float num21 = (float) h / (float) height;
                        int num22 = (int) Math.Round((double) ((float) w - (float) width * num21));
                        num17 += (int) Math.Round((double) num22 / 2.0);
                        w -= num22;
                      }
                      DrawMod.DrawScaled(ref this.g2, ref objBitmap, tx + num17, ty + num18, w, h);
                    }
                    else
                      DrawMod.DrawSimple(ref this.g2, ref objBitmap, tx + num17 + (int) Math.Round((double) (w - width) / 2.0), ty + num18 + (int) Math.Round((double) (h - height) / 2.0));
                    objBitmap.Dispose();
                  }
                }
                else if (sfTypeNr > -1)
                {
                  if (sfTypeNr > -1)
                    nr1 = this.game.Data.SFTypeObj[sfTypeNr].SymbolSpriteID;
                  int nr2 = -1;
                  if (regime1 > -1 & sfTypeNr > -1)
                  {
                    if (this.game.Data.RegimeObj[regime1].ExtraGraphicUse > -1)
                    {
                      int extraCounter = this.game.Data.SFTypeObj[sfTypeNr].ExtraCounter;
                      for (int index8 = 0; index8 <= extraCounter; ++index8)
                      {
                        if (this.game.Data.SFTypeObj[sfTypeNr].ExtraCode[index8] == this.game.Data.RegimeObj[regime1].ExtraGraphicUse)
                          nr1 = this.game.Data.SFTypeObj[sfTypeNr].ExtraSymbolSpriteID[index8];
                      }
                    }
                    else if (this.game.Data.PeopleObj[integer1].ExtraGraphicUse > -1)
                    {
                      int extraCounter = this.game.Data.SFTypeObj[sfTypeNr].ExtraCounter;
                      for (int index9 = 0; index9 <= extraCounter; ++index9)
                      {
                        if (this.game.Data.SFTypeObj[sfTypeNr].ExtraCode[index9] == this.game.Data.PeopleObj[integer1].ExtraGraphicUse)
                          nr1 = this.game.Data.SFTypeObj[sfTypeNr].ExtraSymbolSpriteID[index9];
                      }
                    }
                  }
                  bool flag4;
                  if (this.game.Data.UnitObj[nr].Historical > -1 & (double) this.game.Data.RuleVar[344] == 1.0)
                  {
                    nr1 = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].SmallGfx <= -1 ? -1 : this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].SmallGfx];
                    if (nr1 == -1 & this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Counter > 0 & this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Counter <= this.game.NATO.GetUpperBound(0))
                      nr1 = this.game.NATO[this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Counter];
                    flag4 = true;
                    if (this.game.Data.UnitObj[nr].HistoricalSubPart > -1)
                    {
                      if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].DesignationSmall[this.game.Data.UnitObj[nr].HistoricalSubPart] > 0)
                        nr2 = this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].DesignationSmall[this.game.Data.UnitObj[nr].HistoricalSubPart]];
                      else if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Designation[this.game.Data.UnitObj[nr].HistoricalSubPart] > 0)
                        nr2 = this.game.NATO[this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Designation[this.game.Data.UnitObj[nr].HistoricalSubPart]];
                    }
                  }
                  num12 = nr1;
                  if (this.game.Data.UnitObj[nr].Regime > -1 & sfTypeNr > -1)
                  {
                    if (this.game.Data.SFTypeObj[sfTypeNr].SymbolOverrule)
                    {
                      num1 = 1f;
                      num2 = 1f;
                      num3 = 1f;
                    }
                    else
                    {
                      num1 = (float) this.game.Data.RegimeObj[index2].Red3 / (float) byte.MaxValue;
                      num2 = (float) this.game.Data.RegimeObj[index2].Green3 / (float) byte.MaxValue;
                      num3 = (float) this.game.Data.RegimeObj[index2].Blue3 / (float) byte.MaxValue;
                    }
                    if (flag4)
                    {
                      num1 = 1f;
                      num2 = 1f;
                      num3 = 1f;
                    }
                    int num23;
                    if (this.game.EditObj.HideUnit == 2)
                    {
                      num11 = -1;
                      num23 = num14 + 1;
                    }
                    else
                      num23 = -2;
                    --tx;
                    ty += 2;
                    if (nr1 > 0)
                    {
                      ref Graphics local5 = ref this.g2;
                      bitmap1 = BitmapStore.GetBitmap(nr1, -1);
                      ref Bitmap local6 = ref bitmap1;
                      int x = num11 + tx;
                      int y = ty + 2 + num23;
                      DrawMod.DrawSimple(ref local5, ref local6, x, y);
                    }
                    this.g2.ResetTransform();
                    if (nr2 > -1)
                    {
                      ref Graphics local7 = ref this.g2;
                      bitmap1 = BitmapStore.GetBitmap(nr2, -1);
                      ref Bitmap local8 = ref bitmap1;
                      int x = num11 + tx;
                      int y = ty + num23 + 2;
                      DrawMod.DrawSimple(ref local7, ref local8, x, y);
                    }
                  }
                  else
                  {
                    if (nr1 > 0)
                    {
                      ref Graphics local9 = ref this.g2;
                      bitmap1 = BitmapStore.GetBitmap(nr1, -1);
                      ref Bitmap local10 = ref bitmap1;
                      int x = num11 + tx;
                      int y = ty + 2 + num14;
                      DrawMod.DrawSimple(ref local9, ref local10, x, y);
                    }
                    this.g2.ResetTransform();
                    if (nr2 > -1)
                    {
                      ref Graphics local11 = ref this.g2;
                      bitmap1 = BitmapStore.GetBitmap(nr2, -1);
                      ref Bitmap local12 = ref bitmap1;
                      int x = num11 + tx;
                      int y = ty + num14 + 2;
                      DrawMod.DrawSimple(ref local11, ref local12, x, y);
                    }
                  }
                }
              }
            }
          }
          else
          {
            if (this.game.EditObj.HideUnit == 2 && this.game.Data.UnitObj[nr].Historical > -1 & (double) this.game.Data.RuleVar[344] == 1.0)
              num14 = 8;
            if (this.game.Data.UnitObj[nr].IsHQ)
              num14 = 0;
            sfTypeNr = -1;
            int regime2 = this.game.Data.UnitObj[nr].Regime;
            if (this.game.Data.UnitObj[nr].Regime > -1)
            {
              int hqSpriteNr = this.game.Data.RegimeObj[index2].HQSpriteNr;
              float num24 = (float) this.game.Data.RegimeObj[index2].Red / 256f;
              float num25 = (float) this.game.Data.RegimeObj[index2].Green / 256f;
              float num26 = (float) this.game.Data.RegimeObj[index2].Blue / 256f;
              ref Graphics local13 = ref this.g2;
              bitmap1 = BitmapStore.GetBitmap(hqSpriteNr, -1);
              ref Bitmap local14 = ref bitmap1;
              int x1 = tx - 2;
              int y1 = ty + 3;
              double r1 = (double) num24 - 1.0;
              double g1 = (double) num25 - 1.0;
              double b1 = (double) num26 - 1.0;
              DrawMod.Draw(ref local13, ref local14, x1, y1, (float) r1, (float) g1, (float) b1, 1f);
              int hqSpriteNr2 = this.game.Data.RegimeObj[index2].HQSpriteNr2;
              if (this.game.Data.UnitObj[nr].Historical <= -1 || this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].SmallGfx > -1 || this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Counter <= 0)
                ;
              float num27;
              float num28;
              float num29;
              if (!this.game.Data.RegimeObj[index2].HQSpriteOverrule)
              {
                num27 = (float) this.game.Data.RegimeObj[index2].Red3 / 256f;
                num28 = (float) this.game.Data.RegimeObj[index2].Green3 / 256f;
                num29 = (float) this.game.Data.RegimeObj[index2].Blue3 / 256f;
              }
              else
              {
                num27 = 1f;
                num28 = 1f;
                num29 = 1f;
              }
              ref Graphics local15 = ref this.g2;
              bitmap1 = BitmapStore.GetBitmap(hqSpriteNr2, -1);
              ref Bitmap local16 = ref bitmap1;
              int x2 = tx - 2;
              int y2 = ty + 3;
              double r2 = (double) num27 - 1.0;
              double g2 = (double) num28 - 1.0;
              double b2 = (double) num29 - 1.0;
              DrawMod.Draw(ref local15, ref local16, x2, y2, (float) r2, (float) g2, (float) b2, 1f);
            }
          }
        }
        else if (this.game.Data.UnitObj[nr].Regime > -1)
        {
          if (this.game.Data.UnitObj[nr].IsHQ)
          {
            if (!this.game.Data.RegimeObj[index2].HQSpriteOverrule)
            {
              num1 = (float) this.game.Data.RegimeObj[index2].Red3 / 256f;
              num2 = (float) this.game.Data.RegimeObj[index2].Green3 / 256f;
              num3 = (float) this.game.Data.RegimeObj[index2].Blue3 / 256f;
            }
            else
            {
              num1 = 1f;
              num2 = 1f;
              num3 = 1f;
            }
          }
          else
          {
            int index10;
            if (this.game.Data.SFTypeObj[index10].SymbolOverrule)
            {
              num1 = 1f;
              num2 = 1f;
              num3 = 1f;
            }
            else
            {
              num1 = (float) this.game.Data.RegimeObj[index2].Red3 / (float) byte.MaxValue;
              num2 = (float) this.game.Data.RegimeObj[index2].Green3 / (float) byte.MaxValue;
              num3 = (float) this.game.Data.RegimeObj[index2].Blue3 / (float) byte.MaxValue;
            }
          }
        }
        if ((double) this.game.Data.RuleVar[847] < 1.0)
        {
          float num30;
          float num31;
          float num32;
          if (this.game.Data.UnitObj[nr].IsHQ)
          {
            if (!this.game.Data.RegimeObj[index2].HQSpriteOverrule)
            {
              num30 = (float) this.game.Data.RegimeObj[index2].Red3 / 256f;
              num31 = (float) this.game.Data.RegimeObj[index2].Green3 / 256f;
              num32 = (float) this.game.Data.RegimeObj[index2].Blue3 / 256f;
            }
            else
            {
              num30 = 1f;
              num31 = 1f;
              num32 = 1f;
            }
          }
          else if (sfTypeNr > -1)
          {
            if (this.game.Data.SFTypeObj[sfTypeNr].SymbolOverrule)
            {
              num30 = 1f;
              num31 = 1f;
              num32 = 1f;
            }
            else
            {
              num30 = (float) this.game.Data.RegimeObj[index2].Red2 / (float) byte.MaxValue;
              num31 = (float) this.game.Data.RegimeObj[index2].Green2 / (float) byte.MaxValue;
              num32 = (float) this.game.Data.RegimeObj[index2].Blue2 / (float) byte.MaxValue;
            }
          }
          else
          {
            num30 = (float) this.game.Data.RegimeObj[index2].Red2 / (float) byte.MaxValue;
            num31 = (float) this.game.Data.RegimeObj[index2].Green2 / (float) byte.MaxValue;
            num32 = (float) this.game.Data.RegimeObj[index2].Blue2 / (float) byte.MaxValue;
          }
          int Number = coordinate.x != 2 ? ((double) this.game.Data.RuleVar[847] != 1.0 ? this.game.HandyFunctionsObj.GetPower(nr, this.game.Data.Turn, FullRecon: FullRecon) : this.game.HandyFunctionsObj.GetPower(nr, this.game.Data.Turn, FullRecon: FullRecon, AbsPower: true)) : ((double) this.game.Data.RuleVar[847] != 1.0 ? this.game.HandyFunctionsObj.GetPower(nr, this.game.Data.Turn, randomelement: coordinate.y) : this.game.HandyFunctionsObj.GetPower(nr, this.game.Data.Turn, randomelement: coordinate.y, AbsPower: true));
          string str = Strings.Trim(Conversion.Str((object) Number));
          if (coordinate.x < 2 | Number < 0)
            str = "?";
          SizeF sizeF3 = this.g2.MeasureString(str, this.game.VicFont6);
          int num33 = str.Length > 1 ? (str.Length > 2 ? (int) Math.Round(2.0 + (8.0 - (double) sizeF3.Width / 2.0)) : 4) : 7;
          if ((double) num30 > 1.0)
            num30 = 1f;
          if ((double) num31 > 1.0)
            num31 = 1f;
          if ((double) num32 > 1.0)
            num32 = 1f;
          if (flag1)
            DrawMod.DrawTextVic3(ref this.g2, str, this.game.VicFont6, tx + num33, ty + 9, Color.FromArgb((int) byte.MaxValue, (int) Math.Round((double) (num30 * (float) byte.MaxValue)), (int) Math.Round((double) (num31 * (float) byte.MaxValue)), (int) Math.Round((double) (num32 * (float) byte.MaxValue))), Color.FromArgb(196, 0, 0, 0));
          else
            DrawMod.DrawTextVic3(ref this.g2, str, this.game.VicFont6, tx + num33, ty + 9, Color.FromArgb(128, (int) Math.Round((double) (num30 * (float) byte.MaxValue)), (int) Math.Round((double) (num31 * (float) byte.MaxValue)), (int) Math.Round((double) (num32 * (float) byte.MaxValue))), Color.FromArgb(196, 0, 0, 0));
        }
      }
      else
      {
        int num34 = OverruleHis > -1 & OverrulePower != -9999 & (double) this.game.Data.RuleVar[344] == 1.0 ? 1 : 0;
      }
      if (OverruleHis == -1 & (double) this.game.Data.RuleVar[334] == 0.0 && this.game.Data.Turn == this.game.Data.UnitObj[nr].Regime)
      {
        if (OverruleHis == -1 && this.game.Data.Turn == this.game.Data.UnitObj[nr].Regime)
        {
          if (this.game.EditObj.ShowSameHistorical && this.game.EditObj.UnitSelected > -1 && this.game.Data.UnitObj[nr].HQ > -1 & this.game.Data.UnitObj[nr].HQ == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ & !this.game.Data.UnitObj[nr].IsHQ | nr == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ && this.game.Data.UnitObj[index1].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index1].Historical].Type < 8)
          {
            float red = (float) this.game.Data.UnitObj[index1].Red;
            float green = (float) this.game.Data.UnitObj[index1].Green;
            float blue = (float) this.game.Data.UnitObj[index1].Blue;
            DrawMod.DrawRectangle(ref this.g2, tx, ty, 17, 17, (int) Math.Round((double) red), (int) Math.Round((double) green), (int) Math.Round((double) blue), 112, 2);
          }
          if (this.game.EditObj.ShowUnderHQ && this.game.EditObj.UnitSelected > -1 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ && this.game.Data.UnitObj[nr].HQ == this.game.EditObj.UnitSelected && this.game.Data.UnitObj[index1].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index1].Historical].Type < 8)
          {
            float red = (float) this.game.Data.UnitObj[this.game.Data.UnitObj[nr].HQ].Red;
            float green = (float) this.game.Data.UnitObj[this.game.Data.UnitObj[nr].HQ].Green;
            float blue = (float) this.game.Data.UnitObj[this.game.Data.UnitObj[nr].HQ].Blue;
            DrawMod.DrawRectangle(ref this.g2, tx, ty, 17, 17, (int) Math.Round((double) red), (int) Math.Round((double) green), (int) Math.Round((double) blue), 112, 2);
          }
        }
      }
      if (this.game.EditObj.UnitSelected == nr)
      {
        DrawMod.DrawRectangle(ref this.g2, tx + 0, ty + 0, 17, 17, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        DrawMod.DrawRectangle(ref this.g2, tx - 1, ty - 1, 19, 19, 0, 0, 0, (int) byte.MaxValue);
      }
      if (OverruleHis == -1 && (double) this.game.Data.RuleVar[983] > 0.0 && this.game.Data.Turn == this.game.Data.UnitObj[nr].Regime && !this.game.HandyFunctionsObj.CheckIfInCorrectFrontzone(nr, this.game.Data.UnitObj[nr].RealX(ref this.game), this.game.Data.UnitObj[nr].RealY(ref this.game)))
        DrawMod.DrawRectangle(ref this.g2, tx + 1, ty + 1, 16, 16, (int) byte.MaxValue, 0, 0, 172);
      Bitmap bitmap2;
      return Information.IsNothing((object) toG) ? this.tmpbmp2 : bitmap2;
    }

    public Bitmap DrawUnitBig(
      int nr,
      bool forcehighlight = false,
      Graphics toG = null,
      int tx = 0,
      int ty = 0,
      bool ShowAttacker = false,
      int OverruleHis = -1,
      int OverrulePower = -1,
      int OverruleRegime = -1,
      bool FullRecon = false,
      bool mostlyHidden = false)
    {
      Coordinate coordinate = new Coordinate();
      SizeF sizeF1 = new SizeF();
      SizeF sizeF2 = new SizeF();
      int[] numArray1 = new int[1];
      int[] numArray2 = this.game.Data.SFTypeCounter >= 101 ? new int[this.game.Data.SFTypeCounter + 1] : new int[101];
      if (!Information.IsNothing((object) toG))
      {
        this.g2 = toG;
      }
      else
      {
        this.g2 = Graphics.FromImage((Image) this.tmpbmp2b);
        this.g2.Clear(Color.FromArgb(0, 0, 0, 0));
      }
      if (this.game.Data.Product >= 7)
        this.g2.CompositingQuality = CompositingQuality.HighSpeed;
      bool isMilitia = OverruleHis != -1 ? this.game.Data.HistoricalUnitObj[OverruleHis].GiveHisVarValue(11) > 0 : this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].GiveHisVarValue(11) > 0;
      int index1;
      int regime1;
      int integer1;
      int index2;
      Bitmap bitmap1;
      float num1;
      float num2;
      float num3;
      Rectangle rectangle1;
      Rectangle rectangle2;
      int regime2;
      if (OverruleHis == -1)
      {
        if (nr != -1)
        {
          if (this.game.Data.UnitObj[nr].Regime == this.game.Data.Turn | this.game.Data.Round < 1 | !this.game.Data.FOWOn)
            coordinate.x = 3;
          else
            coordinate = this.game.HandyFunctionsObj.GetReconMinusHide(nr, this.game.Data.Turn);
          index1 = !this.game.Data.UnitObj[nr].IsHQ ? this.game.Data.UnitObj[nr].HQ : nr;
          bool flag1 = !(this.game.Data.UnitObj[nr].Regime == this.game.Data.Turn & this.game.Data.Round > 0) || this.game.Data.UnitObj[nr].X > -1 && this.game.HandyFunctionsObj.CanUnitMove2(nr);
          bool flag2 = false;
          if (Information.IsNothing((object) this.game.EditObj.TempUnitList))
            this.game.EditObj.TempUnitList = new UnitList();
          bool flag3;
          if (this.game.EditObj.OrderType == 2 && this.game.EditObj.TempUnitList.CheckIfPresent(nr))
          {
            flag2 = false;
            flag3 = true;
          }
          if (this.game.EditObj.OrderType == 12 && this.game.EditObj.TempUnitList.CheckIfPresent(nr))
          {
            flag2 = false;
            flag3 = true;
          }
          if (this.game.EditObj.OrderType == 11 && this.game.EditObj.TempUnitList.CheckIfPresent(nr))
          {
            flag2 = false;
            flag3 = true;
          }
          if (this.game.EditObj.OrderType == 13 && this.game.EditObj.TempUnitList.CheckIfPresent(nr))
          {
            flag2 = false;
            flag3 = true;
          }
          if (this.game.EditObj.OrderType == 14 && this.game.EditObj.TempUnitList.CheckIfPresent(nr))
          {
            flag2 = false;
            flag3 = true;
          }
          if (this.game.EditObj.OrderType == 15 && this.game.EditObj.TempUnitList.CheckIfPresent(nr))
          {
            flag2 = false;
            flag3 = true;
          }
          if (this.game.EditObj.OrderType == 9)
          {
            if (this.game.EditObj.OrderUnit == nr)
              flag2 = true;
            if (this.game.EditObj.OrderTarget == nr)
              flag2 = true;
          }
          if (this.game.EditObj.OrderType == 3 && this.game.EditObj.OrderUnit == nr)
            flag2 = true;
          if (this.game.EditObj.OrderType == 19)
          {
            if (this.game.EditObj.OrderUnit == nr)
              flag2 = true;
            if (this.game.EditObj.OrderTarget == nr)
              flag2 = true;
          }
          if (this.game.EditObj.OrderType == 33 && this.game.EditObj.OrderUnit == nr)
            flag2 = true;
          if (forcehighlight && this.game.EditObj.UnitSelected == nr)
            flag2 = true;
          if (this.game.EditObj.LayerSupplyOn && this.game.EditObj.LayerSupplyHQ == this.game.Data.UnitObj[nr].HQ)
            flag2 = true;
          regime1 = this.game.Data.UnitObj[nr].Regime;
          integer1 = Conversions.ToInteger(this.game.HandyFunctionsObj.GetUnitPeople(nr));
          index2 = regime1;
          if (this.game.Data.PeopleObj[integer1].RegCol > -1)
            index2 = this.game.Data.PeopleObj[integer1].RegCol;
          if (Information.IsNothing((object) this.game.Data.RegimeObj[index2].TempCounterBig))
            this.game.Data.RegimeObj[index2].DoTempCounterBig();
          if (OverruleRegime > -1 && Information.IsNothing((object) this.game.Data.RegimeObj[OverruleRegime].TempCounterBig))
            this.game.Data.RegimeObj[OverruleRegime].DoTempCounterBig();
          if (this.game.Data.UnitObj[nr].Regime == -1)
          {
            ref Graphics local1 = ref this.g2;
            bitmap1 = BitmapStore.GetBitmap(this.game.DEFAULTCOUNTERBIG);
            ref Bitmap local2 = ref bitmap1;
            int x = tx;
            int y = ty;
            DrawMod.DrawSimple(ref local1, ref local2, x, y);
          }
          else
          {
            int landscapeType = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[nr].X, this.game.Data.UnitObj[nr].Y].LandscapeType;
            int red;
            int green;
            int blue;
            if (this.game.Data.UnitObj[nr].Historical > -1 & (double) this.game.Data.RuleVar[344] == 1.0)
            {
              red = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Red;
              green = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Green;
              blue = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Blue;
            }
            if (red != 0 | green != 0 | blue != 0 | isMilitia)
            {
              if (!flag2)
              {
                float num4 = (float) ((int) byte.MaxValue + red) / 256f;
                float num5 = (float) ((int) byte.MaxValue + green) / 256f;
                float num6 = (float) ((int) byte.MaxValue + blue) / 256f;
                if ((double) num4 > 1.0)
                  num4 = 1f;
                if ((double) num5 > 1.0)
                  num5 = 1f;
                if ((double) num6 > 1.0)
                  num6 = 1f;
                if (0.0 > (double) num4)
                  num1 = 0.0f;
                if (0.0 > (double) num5)
                  num2 = 0.0f;
                if (0.0 > (double) num6)
                  num3 = 0.0f;
                if (isMilitia)
                {
                  ref Graphics local3 = ref this.g2;
                  ref Bitmap local4 = ref this.game.Data.RegimeObj[regime1].TempCounterBigHigh;
                  rectangle1 = new Rectangle(76 * landscapeType, 0, 76, 76);
                  Rectangle srcrect = rectangle1;
                  rectangle2 = new Rectangle(tx, ty, 76, 76);
                  Rectangle destrect = rectangle2;
                  DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect, destrect);
                }
                else
                {
                  ref Graphics local5 = ref this.g2;
                  ref Bitmap local6 = ref this.game.Data.RegimeObj[regime1].TempCounterBig;
                  rectangle2 = new Rectangle(76 * landscapeType, 0, 76, 76);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, 76, 76);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect, destrect);
                }
                if (flag3 & ShowAttacker)
                  DrawMod.DrawRectangle(ref this.g2, tx, ty, 74, 74, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
                if (flag3 & ShowAttacker)
                  DrawMod.DrawRectangle(ref this.g2, tx + 1, ty + 1, 72, 72, 0, 0, 0, (int) byte.MaxValue);
              }
              else
              {
                float num7 = (float) ((int) byte.MaxValue + red) / 256f;
                float num8 = (float) ((int) byte.MaxValue + green) / 256f;
                float num9 = (float) ((int) byte.MaxValue + blue) / 256f;
                if ((double) num7 > 1.0)
                  num7 = 1f;
                if ((double) num8 > 1.0)
                  num8 = 1f;
                if ((double) num9 > 1.0)
                  num9 = 1f;
                if (0.0 > (double) num7)
                  num1 = 0.0f;
                if (0.0 > (double) num8)
                  num2 = 0.0f;
                if (0.0 > (double) num9)
                  num3 = 0.0f;
                if (isMilitia)
                {
                  ref Graphics local7 = ref this.g2;
                  ref Bitmap local8 = ref this.game.Data.RegimeObj[regime1].TempCounterBigHigh;
                  rectangle2 = new Rectangle(76 * landscapeType, 0, 76, 76);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, 76, 76);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect, destrect);
                }
                else
                {
                  ref Graphics local9 = ref this.g2;
                  ref Bitmap local10 = ref this.game.Data.RegimeObj[regime1].TempCounterBig;
                  rectangle2 = new Rectangle(76 * landscapeType, 0, 76, 76);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, 76, 76);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect, destrect);
                }
                if (flag3 & ShowAttacker)
                  DrawMod.DrawRectangle(ref this.g2, tx, ty, 74, 74, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
                if (flag3 & ShowAttacker)
                  DrawMod.DrawRectangle(ref this.g2, tx + 1, ty + 1, 72, 72, 0, 0, 0, (int) byte.MaxValue);
              }
            }
            else if (!flag2)
            {
              ref Graphics local11 = ref this.g2;
              ref Bitmap local12 = ref this.game.Data.RegimeObj[regime1].TempCounterBig;
              rectangle2 = new Rectangle(76 * landscapeType, 0, 76, 76);
              Rectangle srcrect = rectangle2;
              rectangle1 = new Rectangle(tx, ty, 76, 76);
              Rectangle destrect = rectangle1;
              DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect, destrect);
              if (flag3 & ShowAttacker)
                DrawMod.DrawRectangle(ref this.g2, tx, ty, 74, 74, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
              if (flag3 & ShowAttacker)
                DrawMod.DrawRectangle(ref this.g2, tx + 1, ty + 1, 72, 72, 0, 0, 0, (int) byte.MaxValue);
            }
            else
            {
              ref Graphics local13 = ref this.g2;
              ref Bitmap local14 = ref this.game.Data.RegimeObj[regime1].TempCounterBig;
              rectangle2 = new Rectangle(76 * landscapeType, 0, 76, 76);
              Rectangle srcrect = rectangle2;
              rectangle1 = new Rectangle(tx, ty, 76, 76);
              Rectangle destrect = rectangle1;
              DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect, destrect);
              if (flag3 & ShowAttacker)
                DrawMod.DrawRectangle(ref this.g2, tx, ty, 74, 74, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
              if (flag3 & ShowAttacker)
                DrawMod.DrawRectangle(ref this.g2, tx + 1, ty + 1, 72, 72, 0, 0, 0, (int) byte.MaxValue);
            }
          }
        }
        else
          goto label_403;
      }
      else if (OverruleHis > -1 & OverruleRegime > -1)
      {
        if (OverruleRegime > -1 && Information.IsNothing((object) this.game.Data.RegimeObj[OverruleRegime].TempCounterBig))
          this.game.Data.RegimeObj[OverruleRegime].DoTempCounterBig();
        int landscapeType = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[nr].X, this.game.Data.UnitObj[nr].Y].LandscapeType;
        if (isMilitia)
        {
          ref Graphics local15 = ref this.g2;
          ref Bitmap local16 = ref this.game.Data.RegimeObj[regime2].TempCounterBigHigh;
          rectangle2 = new Rectangle(76 * landscapeType, 0, 76, 76);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(tx, ty, 76, 76);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect, destrect);
        }
        else
        {
          ref Graphics local17 = ref this.g2;
          ref Bitmap local18 = ref this.game.Data.RegimeObj[regime2].TempCounterBig;
          rectangle2 = new Rectangle(76 * landscapeType, 0, 76, 76);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(tx, ty, 76, 76);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect, destrect);
        }
      }
      int num10 = 0;
      if (isMilitia & this.game.Data.Turn == regime1 & OverruleHis == -1)
        DrawMod.DrawTextColouredConsoleCenter(ref this.g2, "M", this.game.MarcFont4, tx + 66, ty + 2, Color.FromArgb(228, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
      else if (!isMilitia & this.game.Data.Turn == regime1 & OverruleHis == -1)
      {
        string counterString = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].CounterString;
        if (Operators.CompareString(Strings.Trim(counterString), Strings.Trim(Conversion.Val(counterString).ToString()), false) == 0)
        {
          int num11 = (int) Math.Round((double) this.g2.MeasureString(counterString, DrawMod.TGame.MarcFont4).Width);
          num10 = num11;
          DrawMod.DrawTextColouredConsole(ref this.g2, counterString, this.game.MarcFont4, tx + 72 - num11, ty + 2, Color.FromArgb(228, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        }
      }
      if (coordinate.x >= 2)
      {
        if (index1 > -1 & !this.game.Data.UnitObj[nr].IsHQ)
        {
          if (this.game.Data.UnitObj[index1].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index1].Historical].Type < 8)
          {
            int red = this.game.Data.UnitObj[index1].Red;
            int green = this.game.Data.UnitObj[index1].Green;
            int blue = this.game.Data.UnitObj[index1].Blue;
            DrawMod.DrawBlock(ref this.g2, tx, ty + 53, 75, 21, red, green, blue, 158);
          }
        }
        else if (this.game.Data.UnitObj[nr].IsHQ & this.game.Data.UnitObj[nr].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Type < 8)
        {
          int red = this.game.Data.UnitObj[nr].Red;
          int green = this.game.Data.UnitObj[nr].Green;
          int blue = this.game.Data.UnitObj[nr].Blue;
          DrawMod.DrawBlockGradient2(ref this.g2, tx, ty + 1, 75, 73, Color.FromArgb(0, red, green, blue), Color.FromArgb(155, red, green, blue));
        }
      }
      int index3;
      int historical;
      if (!mostlyHidden)
      {
        if (OverruleHis == -1)
        {
          int num12 = 0;
          if (this.game.Data.UnitObj[nr].HQ == -1 & !this.game.Data.UnitObj[nr].IsHQ)
            num12 = 0;
          int num13 = -1;
          int num14 = -1;
          if (coordinate.x > 1)
          {
            if (!this.game.Data.UnitObj[nr].IsHQ)
            {
              int sfCount1 = this.game.Data.UnitObj[nr].SFCount;
              int num15;
              for (index3 = 0; index3 <= sfCount1; ++index3)
              {
                int sf = this.game.Data.UnitObj[nr].SFList[index3];
                int index4 = this.game.Data.SFObj[sf].Type;
                int qty = this.game.Data.SFObj[sf].Qty;
                if (this.game.Data.UnitObj[nr].X > -1 && index4 > -1 && this.game.Data.SFTypeObj[index4].Theater != 1 & this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.UnitObj[nr].X, this.game.Data.UnitObj[nr].Y].LandscapeType].IsSea)
                  index4 = -1;
                if (index4 > -1)
                {
                  int symbolGroup = this.game.Data.SFTypeObj[index4].SymbolGroup;
                  int symbolWeight = this.game.Data.SFTypeObj[index4].SymbolWeight;
                  if (symbolGroup > -1)
                  {
                    numArray2[symbolGroup] = numArray2[symbolGroup] + symbolWeight * qty * 10;
                    if (this.game.Data.SFTypeObj[index4].CarryCap > 0)
                      numArray2[symbolGroup] = numArray2[symbolGroup] + 1;
                    if (numArray2[symbolGroup] > num14)
                    {
                      num14 = numArray2[symbolGroup];
                      num15 = symbolGroup;
                    }
                  }
                }
              }
              if (((num15 > -1 ? 1 : 0) | (this.game.Data.UnitObj[nr].Historical > -1 ? 1 : 0) & 0 | ((double) this.game.Data.RuleVar[344] == 0.0 ? 1 : 0)) != 0)
              {
                int num16 = num15;
                int sfTypeNr = -1;
                int num17 = 0;
                int index5 = -1;
                int sfTypeCounter = this.game.Data.SFTypeCounter;
                for (int index6 = 0; index6 <= sfTypeCounter; ++index6)
                  numArray2[index6] = 0;
                int sfCount2 = this.game.Data.UnitObj[nr].SFCount;
                for (int index7 = 0; index7 <= sfCount2; ++index7)
                {
                  int sf = this.game.Data.UnitObj[nr].SFList[index7];
                  int type = this.game.Data.SFObj[sf].Type;
                  int qty = this.game.Data.SFObj[sf].Qty;
                  int symbolGroup = this.game.Data.SFTypeObj[type].SymbolGroup;
                  int symbolWeight = this.game.Data.SFTypeObj[type].SymbolWeight;
                  if (symbolGroup == num16)
                  {
                    numArray2[type] = numArray2[type] + symbolWeight * qty * 10;
                    if (this.game.Data.SFTypeObj[type].CarryCap > 0)
                      numArray2[type] = numArray2[type] + 1;
                    if (numArray2[type] > num17)
                    {
                      num17 = numArray2[type];
                      sfTypeNr = type;
                      index5 = sf;
                    }
                  }
                }
                if (sfTypeNr > -1)
                {
                  if (this.game.EditObj.HideUnit != 2 & sfTypeNr > -1 & this.game.Data.UnitObj[nr].Historical > -1 & this.game.Data.SFTypeObj[sfTypeNr].SFTypeVar[89] > 0)
                  {
                    int tv0 = this.game.Data.PeopleObj[this.game.Data.SFObj[index5].People].tv0;
                    if (this.slotCulture < 0)
                      this.slotCulture = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 306, 0, 0));
                    int integer2 = Conversions.ToInteger(this.game.Data.StringListObj[this.slotCulture].GetData(0, tv0, 1));
                    Bitmap objBitmap;
                    if (!Information.IsNothing((object) this.game.Data.UnitObj[nr].tempSFTypeBitmap))
                    {
                      objBitmap = this.game.Data.UnitObj[nr].tempSFTypeBitmap;
                    }
                    else
                    {
                      objBitmap = this.DrawSFTypeGraphic(sfTypeNr, isMilitia, integer2, regime1, nr);
                      this.game.Data.UnitObj[nr].tempSFTypeBitmap = objBitmap;
                    }
                    if (!Information.IsNothing((object) objBitmap))
                    {
                      int num18 = 0;
                      int num19 = 2;
                      int w = 76;
                      int h = 64;
                      int width = objBitmap.Width;
                      int height = objBitmap.Height;
                      if (width > w | height > h)
                      {
                        if ((double) width / (double) w > (double) height / (double) h)
                        {
                          float num20 = (float) w / (float) width;
                          int num21 = (int) Math.Round((double) ((float) h - (float) height * num20));
                          num19 += (int) Math.Round((double) num21 / 2.0);
                          h -= num21;
                        }
                        else
                        {
                          float num22 = (float) h / (float) height;
                          int num23 = (int) Math.Round((double) ((float) w - (float) width * num22));
                          num18 += (int) Math.Round((double) num23 / 2.0);
                          w -= num23;
                        }
                        if (this.game.Data.RegimeObj[this.game.Data.UnitObj[nr].Regime].Mirror)
                        {
                          Matrix matrix = new Matrix();
                          matrix.Scale(-1f, 1f);
                          if (Information.IsNothing((object) toG))
                            matrix.Translate((float) -(w + 0), 0.0f);
                          else
                            matrix.Translate((float) -(2 * (tx + num18) + (w + 0)), 0.0f);
                          this.g2.Transform = matrix;
                        }
                        DrawMod.DrawScaled(ref this.g2, ref objBitmap, tx + num18, ty + num19, w, h, true);
                      }
                      else
                      {
                        if (this.game.Data.RegimeObj[this.game.Data.UnitObj[nr].Regime].Mirror)
                        {
                          Matrix matrix = new Matrix();
                          matrix.Scale(-1f, 1f);
                          if (Information.IsNothing((object) toG))
                            matrix.Translate((float) -(w + 0), 0.0f);
                          else
                            matrix.Translate((float) -(2 * tx + (w + 0)), 0.0f);
                          this.g2.Transform = matrix;
                        }
                        DrawMod.DrawSimple(ref this.g2, ref objBitmap, tx + num18 + (int) Math.Round((double) (w - width) / 2.0), ty + num19 + (int) Math.Round((double) (h - height) / 2.0));
                      }
                      this.g2.ResetTransform();
                    }
                  }
                  else if (((sfTypeNr > -1 ? 1 : 0) | (this.game.Data.UnitObj[nr].Historical > -1 ? 1 : 0) & 0) != 0)
                  {
                    int nr1 = -1;
                    int nr2 = -1;
                    if ((double) this.game.Data.RuleVar[871] > 0.0 & sfTypeNr > -1)
                    {
                      if (this.game.Data.RegimeObj[this.game.Data.UnitObj[nr].Regime].Mirror)
                      {
                        Matrix matrix = new Matrix();
                        matrix.Scale(-1f, 1f);
                        if (Information.IsNothing((object) toG))
                          matrix.Translate(-90f, 0.0f);
                        else
                          matrix.Translate((float) -(2 * tx + 90), 0.0f);
                        this.g2.Transform = matrix;
                      }
                      nr1 = -1;
                      if (sfTypeNr > -1)
                        nr1 = this.game.Data.SFTypeObj[sfTypeNr].SymbolColBigSpriteID;
                      if (Operators.CompareString(this.game.Data.SFTypeObj[sfTypeNr].SymbolColBigFileName, "systemgraphics/trans.bmp", false) == 0)
                        nr1 = -1;
                      if (regime1 > -1 & sfTypeNr > -1)
                      {
                        if (this.game.Data.RegimeObj[regime1].ExtraGraphicUse > -1)
                        {
                          int extraCounter = this.game.Data.SFTypeObj[sfTypeNr].ExtraCounter;
                          for (int index8 = 0; index8 <= extraCounter; ++index8)
                          {
                            if (this.game.Data.SFTypeObj[sfTypeNr].ExtraCode[index8] == this.game.Data.RegimeObj[regime1].ExtraGraphicUse)
                            {
                              nr1 = this.game.Data.SFTypeObj[sfTypeNr].ExtraSymbolColBigSpriteID[index8];
                              if (Operators.CompareString(this.game.Data.SFTypeObj[sfTypeNr].ExtraSymbolColBigFileName[index8], "systemgraphics/trans.bmp", false) == 0)
                                nr1 = -1;
                            }
                          }
                        }
                        else if (this.game.Data.PeopleObj[integer1].ExtraGraphicUse > -1)
                        {
                          int extraCounter = this.game.Data.SFTypeObj[sfTypeNr].ExtraCounter;
                          for (int index9 = 0; index9 <= extraCounter; ++index9)
                          {
                            if (this.game.Data.SFTypeObj[sfTypeNr].ExtraCode[index9] == this.game.Data.PeopleObj[integer1].ExtraGraphicUse)
                            {
                              nr1 = this.game.Data.SFTypeObj[sfTypeNr].ExtraSymbolColBigSpriteID[index9];
                              if (Operators.CompareString(this.game.Data.SFTypeObj[sfTypeNr].ExtraSymbolColBigFileName[index9], "systemgraphics/trans.bmp", false) == 0)
                                nr1 = -1;
                            }
                          }
                        }
                      }
                      if (nr1 > -1)
                      {
                        int num24 = 0;
                        int num25 = 0;
                        int width = BitmapStore.GetWidth(nr1);
                        int num26 = BitmapStore.Getheight(nr1);
                        if (width < 70)
                        {
                          num24 = 74 - width;
                          num25 = 4;
                        }
                        int baseColor = this.game.Data.SFTypeObj[sfTypeNr].BaseColor;
                        float red = (float) this.game.Data.RegimeObj[this.game.Data.UnitObj[nr].Regime].Red;
                        float green = (float) this.game.Data.RegimeObj[this.game.Data.UnitObj[nr].Regime].Green;
                        float blue = (float) this.game.Data.RegimeObj[this.game.Data.UnitObj[nr].Regime].Blue;
                        switch (baseColor)
                        {
                          case 0:
                            ref Graphics local19 = ref this.g2;
                            bitmap1 = BitmapStore.GetBitmap(nr1);
                            ref Bitmap local20 = ref bitmap1;
                            int x1 = tx + num24;
                            int y1 = ty + num25;
                            int w1 = width;
                            int h1 = num26;
                            DrawMod.DrawScaled(ref local19, ref local20, x1, y1, w1, h1);
                            break;
                          case 1:
                            ref Graphics local21 = ref this.g2;
                            bitmap1 = BitmapStore.GetBitmap(nr1);
                            ref Bitmap local22 = ref bitmap1;
                            int x2 = tx + num24;
                            int y2 = ty + num25;
                            int w2 = width;
                            int h2 = num26;
                            int origw1 = width;
                            int origh1 = num26;
                            double r1 = (double) red / 256.0;
                            double g1 = (double) green / 256.0;
                            double b1 = (double) blue / 256.0;
                            DrawMod.DrawScaledColorized2(ref local21, ref local22, x2, y2, w2, h2, origw1, origh1, (float) r1, (float) g1, (float) b1, 1f);
                            break;
                          case 2:
                            float red2 = (float) this.game.Data.RegimeObj[this.game.Data.UnitObj[nr].Regime].Red2;
                            float green2 = (float) this.game.Data.RegimeObj[this.game.Data.UnitObj[nr].Regime].Green2;
                            float blue2 = (float) this.game.Data.RegimeObj[this.game.Data.UnitObj[nr].Regime].Blue2;
                            ref Graphics local23 = ref this.g2;
                            bitmap1 = BitmapStore.GetBitmap(nr1);
                            ref Bitmap local24 = ref bitmap1;
                            int x3 = tx + num24;
                            int y3 = ty + num25;
                            int w3 = width;
                            int h3 = num26;
                            int origw2 = width;
                            int origh2 = num26;
                            double r2 = (double) red2 / 256.0;
                            double g2 = (double) green2 / 256.0;
                            double b2 = (double) blue2 / 256.0;
                            DrawMod.DrawScaledColorized2(ref local23, ref local24, x3, y3, w3, h3, origw2, origh2, (float) r2, (float) g2, (float) b2, 1f);
                            break;
                          case 3:
                            float red3 = (float) this.game.Data.RegimeObj[this.game.Data.UnitObj[nr].Regime].Red3;
                            float green3 = (float) this.game.Data.RegimeObj[this.game.Data.UnitObj[nr].Regime].Green3;
                            float blue3 = (float) this.game.Data.RegimeObj[this.game.Data.UnitObj[nr].Regime].Blue3;
                            ref Graphics local25 = ref this.g2;
                            bitmap1 = BitmapStore.GetBitmap(nr1);
                            ref Bitmap local26 = ref bitmap1;
                            int x4 = tx + num24;
                            int y4 = ty + num25;
                            int w4 = width;
                            int h4 = num26;
                            int origw3 = width;
                            int origh3 = num26;
                            double r3 = (double) red3 / 256.0;
                            double g3 = (double) green3 / 256.0;
                            double b3 = (double) blue3 / 256.0;
                            DrawMod.DrawScaledColorized2(ref local25, ref local26, x4, y4, w4, h4, origw3, origh3, (float) r3, (float) g3, (float) b3, 1f);
                            break;
                          case 4:
                            float red4 = (float) this.game.Data.RegimeObj[this.game.Data.UnitObj[nr].Regime].Red4;
                            float green4 = (float) this.game.Data.RegimeObj[this.game.Data.UnitObj[nr].Regime].Green4;
                            float blue4 = (float) this.game.Data.RegimeObj[this.game.Data.UnitObj[nr].Regime].Blue4;
                            ref Graphics local27 = ref this.g2;
                            bitmap1 = BitmapStore.GetBitmap(nr1);
                            ref Bitmap local28 = ref bitmap1;
                            int x5 = tx + num24;
                            int y5 = ty + num25;
                            int w5 = width;
                            int h5 = num26;
                            int origw4 = width;
                            int origh4 = num26;
                            double r4 = (double) red4 / 256.0;
                            double g4 = (double) green4 / 256.0;
                            double b4 = (double) blue4 / 256.0;
                            DrawMod.DrawScaledColorized2(ref local27, ref local28, x5, y5, w5, h5, origw4, origh4, (float) r4, (float) g4, (float) b4, 1f);
                            break;
                          case 5:
                            ref Graphics local29 = ref this.g2;
                            bitmap1 = BitmapStore.GetBitmap(nr1);
                            ref Bitmap local30 = ref bitmap1;
                            int x6 = tx + num24;
                            int y6 = ty + num25;
                            int w6 = width;
                            int h6 = num26;
                            int origw5 = width;
                            int origh5 = num26;
                            double r5 = ((double) red + 392.0) / 1024.0;
                            double g5 = ((double) green + 392.0) / 1024.0;
                            double b5 = ((double) blue + 392.0) / 1024.0;
                            DrawMod.DrawScaledColorized2(ref local29, ref local30, x6, y6, w6, h6, origw5, origh5, (float) r5, (float) g5, (float) b5, 1f);
                            break;
                          case 6:
                            ref Graphics local31 = ref this.g2;
                            bitmap1 = BitmapStore.GetBitmap(nr1);
                            ref Bitmap local32 = ref bitmap1;
                            int x7 = tx + num24;
                            int y7 = ty + num25;
                            int w7 = width;
                            int h7 = num26;
                            int origw6 = width;
                            int origh6 = num26;
                            double r6 = ((double) red + 80.0) / 512.0;
                            double g6 = ((double) green + 200.0) / 512.0;
                            double b6 = ((double) blue + 80.0) / 512.0;
                            DrawMod.DrawScaledColorized2(ref local31, ref local32, x7, y7, w7, h7, origw6, origh6, (float) r6, (float) g6, (float) b6, 1f);
                            break;
                        }
                      }
                      nr2 = -1;
                      if (sfTypeNr > -1)
                        nr2 = this.game.Data.SFTypeObj[sfTypeNr].SymbolColBigSprite2ID;
                      if (Operators.CompareString(this.game.Data.SFTypeObj[sfTypeNr].SymbolColBigFileName2, "systemgraphics/trans.bmp", false) == 0)
                        nr2 = -1;
                      if (regime1 > -1 & sfTypeNr > -1)
                      {
                        if (this.game.Data.RegimeObj[regime1].ExtraGraphicUse > -1)
                        {
                          int extraCounter = this.game.Data.SFTypeObj[sfTypeNr].ExtraCounter;
                          for (int index10 = 0; index10 <= extraCounter; ++index10)
                          {
                            if (this.game.Data.SFTypeObj[sfTypeNr].ExtraCode[index10] == this.game.Data.RegimeObj[regime1].ExtraGraphicUse)
                            {
                              nr2 = this.game.Data.SFTypeObj[sfTypeNr].ExtraSymbolColBigSprite2ID[index10];
                              if (Operators.CompareString(this.game.Data.SFTypeObj[sfTypeNr].ExtraSymbolColBigFileName2[index10], "systemgraphics/trans.bmp", false) == 0)
                                nr2 = -1;
                            }
                          }
                        }
                        else if (this.game.Data.PeopleObj[integer1].ExtraGraphicUse > -1)
                        {
                          int extraCounter = this.game.Data.SFTypeObj[sfTypeNr].ExtraCounter;
                          for (int index11 = 0; index11 <= extraCounter; ++index11)
                          {
                            if (this.game.Data.SFTypeObj[sfTypeNr].ExtraCode[index11] == this.game.Data.PeopleObj[integer1].ExtraGraphicUse)
                            {
                              nr2 = this.game.Data.SFTypeObj[sfTypeNr].ExtraSymbolColBigSprite2ID[index11];
                              if (Operators.CompareString(this.game.Data.SFTypeObj[sfTypeNr].ExtraSymbolColBigFileName2[index11], "systemgraphics/trans.bmp", false) == 0)
                                nr2 = -1;
                            }
                          }
                        }
                      }
                      if (nr2 > -1)
                      {
                        int num27 = 0;
                        int num28 = 0;
                        if (BitmapStore.GetWidth(nr2) < 70)
                        {
                          num27 = 74 - BitmapStore.GetWidth(nr2);
                          num28 = 4;
                        }
                        ref Graphics local33 = ref this.g2;
                        bitmap1 = BitmapStore.GetBitmap(nr2);
                        ref Bitmap local34 = ref bitmap1;
                        int x = tx + num27;
                        int y = ty + num28;
                        DrawMod.DrawSimple(ref local33, ref local34, x, y);
                      }
                      this.g2.ResetTransform();
                    }
                    if ((double) this.game.Data.RuleVar[871] <= 0.0 | nr2 == -1 & nr1 == -1)
                    {
                      if (sfTypeNr > -1)
                        nr1 = this.game.Data.SFTypeObj[sfTypeNr].SymbolSpriteID;
                      int nr3 = -1;
                      if (regime1 > -1 & sfTypeNr > -1)
                      {
                        if (this.game.Data.RegimeObj[regime1].ExtraGraphicUse > -1)
                        {
                          int extraCounter = this.game.Data.SFTypeObj[sfTypeNr].ExtraCounter;
                          for (int index12 = 0; index12 <= extraCounter; ++index12)
                          {
                            if (this.game.Data.SFTypeObj[sfTypeNr].ExtraCode[index12] == this.game.Data.RegimeObj[regime1].ExtraGraphicUse)
                              nr1 = this.game.Data.SFTypeObj[sfTypeNr].ExtraSymbolSpriteID[index12];
                          }
                        }
                        else if (this.game.Data.PeopleObj[integer1].ExtraGraphicUse > -1)
                        {
                          int extraCounter = this.game.Data.SFTypeObj[sfTypeNr].ExtraCounter;
                          for (int index13 = 0; index13 <= extraCounter; ++index13)
                          {
                            if (this.game.Data.SFTypeObj[sfTypeNr].ExtraCode[index13] == this.game.Data.PeopleObj[integer1].ExtraGraphicUse)
                              nr1 = this.game.Data.SFTypeObj[sfTypeNr].ExtraSymbolSpriteID[index13];
                          }
                        }
                      }
                      int num29;
                      if (this.game.EditObj.HideUnit == 2 && this.game.Data.UnitObj[nr].Historical > -1 & (double) this.game.Data.RuleVar[344] == 1.0)
                      {
                        nr1 = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].SmallGfx <= -1 ? -1 : this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].SmallGfx];
                        if (nr1 == -1 & this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Counter > 0 & this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Counter <= this.game.NATO.GetUpperBound(0))
                          nr1 = this.game.NATO[this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Counter];
                        num29 = 12;
                        if (this.game.Data.UnitObj[nr].HistoricalSubPart > -1)
                        {
                          if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].DesignationSmall[this.game.Data.UnitObj[nr].HistoricalSubPart] > 0)
                            nr3 = this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].DesignationSmall[this.game.Data.UnitObj[nr].HistoricalSubPart]];
                          else if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Designation[this.game.Data.UnitObj[nr].HistoricalSubPart] > 0)
                            nr3 = this.game.NATO[this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Designation[this.game.Data.UnitObj[nr].HistoricalSubPart]];
                        }
                      }
                      num13 = nr1;
                      int regime3 = this.game.Data.UnitObj[nr].Regime;
                      if (this.game.EditObj.PrefMinimalistCounter && this.game.Data.Product < 6)
                        num12 -= 7;
                      if (((this.game.EditObj.PrefMinimalistCounter & (double) this.game.Data.RuleVar[999] == 1.0 ? 1 : 0) & 1 & (!this.game.Data.UnitObj[nr].IsHQ ? 1 : 0)) != 0 && this.game.Data.Product < 6)
                        num29 += 6;
                      if ((((double) this.game.Data.RuleVar[847] == 1.0 ? 1 : 0) & 0) != 0)
                        num29 -= 6;
                      if ((((double) this.game.Data.RuleVar[847] == 1.0 ? 1 : 0) & 1) != 0)
                        num29 += 5;
                      int num30 = num29 + 2;
                      if (regime3 > -1 & sfTypeNr > -1)
                      {
                        float num31;
                        float num32;
                        float num33;
                        if (this.game.Data.SFTypeObj[sfTypeNr].SymbolOverrule)
                        {
                          num31 = 1f;
                          num32 = 1f;
                          num33 = 1f;
                        }
                        else
                        {
                          num31 = 1f;
                          num32 = 1f;
                          num33 = 1f;
                        }
                        if (this.game.EditObj.HideUnit != 2 & this.game.Data.RegimeObj[regime3].Mirror & (0 & (this.game.Data.UnitObj[nr].Historical > -1 ? 1 : 0)) == 0)
                        {
                          Matrix matrix = new Matrix();
                          matrix.Scale(-1f, 1f);
                          if (Information.IsNothing((object) toG))
                            matrix.Translate(-90f, 0.0f);
                          else
                            matrix.Translate((float) -(2 * tx + 90), 0.0f);
                          this.g2.Transform = matrix;
                          if (this.game.EditObj.PrefMinimalistCounter && this.game.Data.Product < 6)
                            num12 = 9;
                          if (this.game.Data.Product == 7)
                            num12 += 10;
                        }
                        if (this.game.EditObj.HideUnit == 2)
                          num12 -= 7;
                        if (this.game.Data.SFTypeObj[sfTypeNr].SFTypeVar[82] > 0 & this.game.EditObj.HideUnit != 2)
                        {
                          num30 = -2;
                          num12 += 3;
                        }
                        if ((double) num31 == 1.0 & (double) num32 == 1.0 & (double) num33 == 1.0)
                        {
                          if (this.game.Data.SFTypeObj[sfTypeNr].SFTypeVar[82] > 0 & nr1 > 0)
                          {
                            if (this.game.Data.SFTypeObj[sfTypeNr].artCode[0] < 1 | this.game.EditObj.HideUnit == 2)
                            {
                              ref Graphics local35 = ref this.g2;
                              bitmap1 = BitmapStore.GetBitmap(nr1, 1);
                              ref Bitmap local36 = ref bitmap1;
                              int x = num12 + tx;
                              int y = ty + num30;
                              DrawMod.DrawSimple(ref local35, ref local36, x, y);
                            }
                            else
                            {
                              ref Graphics local37 = ref this.g2;
                              bitmap1 = BitmapStore.GetBitmap(nr1, 1);
                              ref Bitmap local38 = ref bitmap1;
                              rectangle2 = new Rectangle(0, 0, 76, 76);
                              Rectangle srcrect = rectangle2;
                              rectangle1 = new Rectangle(num12 + tx, ty + num30, 76, 76);
                              Rectangle destrect = rectangle1;
                              double r = (double) ((float) this.game.Data.SFTypeObj[sfTypeNr].artCode[1] / (float) byte.MaxValue);
                              double g = (double) ((float) this.game.Data.SFTypeObj[sfTypeNr].artCode[2] / (float) byte.MaxValue);
                              double b = (double) ((float) this.game.Data.SFTypeObj[sfTypeNr].artCode[3] / (float) byte.MaxValue);
                              DrawMod.DrawSimplePart2ColouredNew(ref local37, ref local38, srcrect, destrect, (float) r, (float) g, (float) b, 1f);
                            }
                            if (this.game.Data.SFTypeObj[sfTypeNr].artCode[5] == 1 & this.game.EditObj.HideUnit != 2)
                            {
                              ref Graphics local39 = ref this.g2;
                              bitmap1 = BitmapStore.GetBitmap(this.game.Data.SFTypeObj[sfTypeNr].SymbolColBigSprite2ID);
                              ref Bitmap local40 = ref bitmap1;
                              rectangle2 = new Rectangle(0, 0, 76, 76);
                              Rectangle srcrect = rectangle2;
                              rectangle1 = new Rectangle(num12 + tx, ty + num30, 76, 76);
                              Rectangle destrect = rectangle1;
                              double r = (double) ((float) this.game.Data.SFTypeObj[sfTypeNr].artCode[6] / (float) byte.MaxValue);
                              double g = (double) ((float) this.game.Data.SFTypeObj[sfTypeNr].artCode[7] / (float) byte.MaxValue);
                              double b = (double) ((float) this.game.Data.SFTypeObj[sfTypeNr].artCode[8] / (float) byte.MaxValue);
                              double a = (double) ((float) this.game.Data.SFTypeObj[sfTypeNr].artCode[9] / (float) byte.MaxValue);
                              DrawMod.DrawSimplePart2ColouredNew(ref local39, ref local40, srcrect, destrect, (float) r, (float) g, (float) b, (float) a);
                            }
                          }
                          else if (nr1 > 0)
                          {
                            ref Graphics local41 = ref this.g2;
                            bitmap1 = BitmapStore.GetBitmap(nr1, 1);
                            ref Bitmap local42 = ref bitmap1;
                            int x = num12 + tx;
                            int y = ty + num30;
                            DrawMod.DrawSimple(ref local41, ref local42, x, y);
                          }
                          this.g2.ResetTransform();
                          if (nr3 > 0)
                          {
                            ref Graphics local43 = ref this.g2;
                            bitmap1 = BitmapStore.GetBitmap(nr3, 1);
                            ref Bitmap local44 = ref bitmap1;
                            int x = num12 + tx;
                            int y = ty + num30;
                            DrawMod.DrawSimple(ref local43, ref local44, x, y);
                          }
                        }
                        else
                        {
                          if (nr1 > 0)
                          {
                            ref Graphics local45 = ref this.g2;
                            bitmap1 = BitmapStore.GetBitmap(nr1, 1);
                            ref Bitmap local46 = ref bitmap1;
                            int x = num12 + tx;
                            int y = ty + num30;
                            double r = (double) num31 - 1.0;
                            double g = (double) num32 - 1.0;
                            double b = (double) num33 - 1.0;
                            DrawMod.Draw(ref local45, ref local46, x, y, (float) r, (float) g, (float) b, 1f);
                          }
                          this.g2.ResetTransform();
                          if (nr3 > 0)
                          {
                            ref Graphics local47 = ref this.g2;
                            bitmap1 = BitmapStore.GetBitmap(nr3, 1);
                            ref Bitmap local48 = ref bitmap1;
                            int x = num12 + tx;
                            int y = ty + num30;
                            double r = (double) num31 - 1.0;
                            double g = (double) num32 - 1.0;
                            double b = (double) num33 - 1.0;
                            DrawMod.Draw(ref local47, ref local48, x, y, (float) r, (float) g, (float) b, 1f);
                          }
                        }
                      }
                      else
                      {
                        if (nr1 > 0)
                        {
                          ref Graphics local49 = ref this.g2;
                          bitmap1 = BitmapStore.GetBitmap(nr1, 1);
                          ref Bitmap local50 = ref bitmap1;
                          int x = num12 + tx;
                          int y = ty + num30;
                          DrawMod.DrawSimple(ref local49, ref local50, x, y);
                        }
                        this.g2.ResetTransform();
                        if (nr3 > 0)
                        {
                          ref Graphics local51 = ref this.g2;
                          bitmap1 = BitmapStore.GetBitmap(nr3, 1);
                          ref Bitmap local52 = ref bitmap1;
                          int x = num12 + tx;
                          int y = ty + num30;
                          DrawMod.DrawSimple(ref local51, ref local52, x, y);
                        }
                      }
                      if (this.game.EditObj.HideUnit == 2)
                      {
                        historical = this.game.Data.UnitObj[nr].Historical;
                        string counterString = this.game.Data.HistoricalUnitObj[historical].CounterString;
                        string str1 = Strings.UCase(Strings.Left(counterString, 1)) + Strings.Mid(counterString, 2);
                        string str2 = Conversion.Str((object) Conversion.Val(str1));
                        string str3;
                        if (Operators.CompareString(Strings.Trim(str1), Strings.Trim(str2), false) == 0)
                        {
                          int num34 = (int) Math.Round(Conversion.Val(str1));
                          str3 = !((num34 + 10) % 10 == 1 & (num34 + 100) % 100 != 11) ? (!((num34 + 10) % 10 == 2 & (num34 + 100) % 100 != 12) ? (!((num34 + 10) % 10 == 3 & (num34 + 100) % 100 != 13) ? str2 + "th" : str2 + "rd") : str2 + "nd") : str2 + "st";
                        }
                        else
                          str3 = str1;
                        int num35 = (int) Math.Round(38.0 - (double) (int) Math.Round((double) this.g2.MeasureString(str3, DrawMod.TGame.MarcFont16).Width) / 2.0);
                        DrawMod.DrawTextColouredMarc(ref this.g2, Strings.Trim(str3), DrawMod.TGame.MarcFont16, tx + num35, ty + 8, Color.White);
                      }
                    }
                  }
                }
              }
            }
            else if (this.game.Data.UnitObj[nr].Regime > -1)
            {
              int hqSpriteNr = this.game.Data.RegimeObj[index2].HQSpriteNr;
              float num36 = (float) this.game.Data.RegimeObj[index2].Red / 256f;
              float num37 = (float) this.game.Data.RegimeObj[index2].Green / 256f;
              float num38 = (float) this.game.Data.RegimeObj[index2].Blue / 256f;
              ref Graphics local53 = ref this.g2;
              bitmap1 = BitmapStore.GetBitmap(hqSpriteNr, 1);
              ref Bitmap local54 = ref bitmap1;
              int x8 = tx - 8;
              int y8 = ty + 4;
              double r7 = (double) num36 - 1.0;
              double g7 = (double) num37 - 1.0;
              double b7 = (double) num38 - 1.0;
              DrawMod.Draw(ref local53, ref local54, x8, y8, (float) r7, (float) g7, (float) b7, 1f);
              int hqSpriteNr2 = this.game.Data.RegimeObj[index2].HQSpriteNr2;
              if (this.game.Data.UnitObj[nr].Historical <= -1 || this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].SmallGfx > -1 || this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Counter <= 0)
                ;
              float num39;
              float num40;
              float num41;
              if (!this.game.Data.RegimeObj[index2].HQSpriteOverrule)
              {
                num39 = (float) this.game.Data.RegimeObj[index2].Red3 / 256f;
                num40 = (float) this.game.Data.RegimeObj[index2].Green3 / 256f;
                num41 = (float) this.game.Data.RegimeObj[index2].Blue3 / 256f;
              }
              else
              {
                num39 = 1f;
                num40 = 1f;
                num41 = 1f;
              }
              ref Graphics local55 = ref this.g2;
              bitmap1 = BitmapStore.GetBitmap(hqSpriteNr2, 1);
              ref Bitmap local56 = ref bitmap1;
              int x9 = tx - 8;
              int y9 = ty + 4;
              double r8 = (double) num39 - 1.0;
              double g8 = (double) num40 - 1.0;
              double b8 = (double) num41 - 1.0;
              DrawMod.Draw(ref local55, ref local56, x9, y9, (float) r8, (float) g8, (float) b8, 1f);
              historical = this.game.Data.UnitObj[nr].Historical;
              string counterString = this.game.Data.HistoricalUnitObj[historical].CounterString;
              string str = Strings.UCase(Strings.Left(counterString, 1)) + Strings.Mid(counterString, 2);
              Conversion.Str((object) Conversion.Val(str));
              int num42 = (int) Math.Round(38.0 - (double) (int) Math.Round((double) this.g2.MeasureString(str, DrawMod.TGame.MarcFont16).Width) / 2.0);
              DrawMod.DrawTextColouredMarc(ref this.g2, Strings.Trim(str), DrawMod.TGame.MarcFont16, tx + num42, ty + 47, Color.White);
            }
          }
        }
        else
        {
          int num43 = OverruleHis > -1 & OverrulePower != -9999 & (double) this.game.Data.RuleVar[344] == 1.0 ? 1 : 0;
        }
      }
      if (OverruleHis == -1 & !mostlyHidden)
      {
        regime2 = this.game.Data.UnitObj[nr].Regime;
        float red2 = (float) this.game.Data.RegimeObj[index2].Red2;
        float green2 = (float) this.game.Data.RegimeObj[index2].Green2;
        float blue2 = (float) this.game.Data.RegimeObj[index2].Blue2;
        float num44 = 0.0f;
        float num45 = 0.0f;
        float num46 = 0.0f;
        if ((double) red2 < 128.0 & (double) green2 < 128.0 & (double) blue2 < 128.0)
        {
          num44 = (float) byte.MaxValue;
          num45 = (float) byte.MaxValue;
          num46 = (float) byte.MaxValue;
        }
        index3 = coordinate.x != 2 ? ((double) this.game.Data.RuleVar[847] != 1.0 ? this.game.HandyFunctionsObj.GetPower(nr, this.game.Data.Turn, FullRecon: FullRecon) : this.game.HandyFunctionsObj.GetPower(nr, this.game.Data.Turn, FullRecon: FullRecon, AbsPower: true)) : ((double) this.game.Data.RuleVar[847] != 1.0 ? this.game.HandyFunctionsObj.GetPower(nr, this.game.Data.Turn, randomelement: coordinate.y) : this.game.HandyFunctionsObj.GetPower(nr, this.game.Data.Turn, randomelement: coordinate.y, AbsPower: true));
      }
      if (index3 > 999)
        index3 = 999;
      if (OverrulePower > -1)
        index3 = OverrulePower;
      else if (OverrulePower == -9999)
        index3 = -9999;
      int Number = index3;
      if (Number > 99)
        Number = 99;
      if (OverruleHis > -1)
      {
        num1 = (float) this.game.Data.RegimeObj[OverruleRegime].Red2;
        num2 = (float) this.game.Data.RegimeObj[OverruleRegime].Green2;
        num3 = (float) this.game.Data.RegimeObj[OverruleRegime].Blue2;
      }
      if ((coordinate.x > 1 | OverruleHis > -1) & !mostlyHidden)
      {
        historical = this.game.Data.UnitObj[nr].Historical;
        if (!this.game.Data.UnitObj[nr].IsHQ && (((double) this.game.Data.RuleVar[999] == 1.0 ? 1 : 0) & 1 & (!this.game.Data.UnitObj[nr].IsHQ ? 1 : 0)) != 0 && !this.game.EditObj.PrefMinimalistCounter)
        {
          int num47 = 4;
          if (this.game.Data.Turn == this.game.Data.UnitObj[nr].Regime)
          {
            int averageRdn = this.game.HandyFunctionsObj.GetAverageRdn(nr);
            int num48 = Number;
            this.game.HandyFunctionsObj.GetBreakPercent(nr);
            int num49 = (int) Math.Round((double) this.game.Data.RuleVar[307]);
            int num50 = this.game.HandyFunctionsObj.GetStartPower(nr);
            if (num50 == 0)
              num50 = num48;
            int num51 = (int) Math.Round(Conversion.Int((double) num48 / (double) num50 * 100.0));
            if ((this.game.EditObj.HideUnit != 2 ? (int) Math.Round(34.0 - Conversion.Int((double) num48 / (double) num50 * 34.0)) : (int) Math.Round(62.0 - Conversion.Int((double) num48 / (double) num50 * 62.0))) < 0)
              ;
            if (num48 > 0)
            {
              float a1;
              float a2;
              float a3;
              if (averageRdn >= 75)
              {
                a1 = 0.0f;
                a2 = (float) byte.MaxValue;
                a3 = 0.0f;
              }
              else if (averageRdn >= 50)
              {
                a1 = (float) byte.MaxValue;
                a2 = (float) byte.MaxValue;
                a3 = 0.0f;
              }
              else if (averageRdn >= 25)
              {
                a1 = 0.0f;
                a2 = 170f;
                a3 = (float) byte.MaxValue;
              }
              else
              {
                a1 = (float) byte.MaxValue;
                a2 = 0.0f;
                a3 = 0.0f;
              }
              int num52 = num51;
              if (num52 > 100)
                num52 = 100;
              if (this.game.EditObj.HideUnit == 2)
              {
                DrawMod.DrawBlock(ref this.g2, tx + 6 + num47, ty + 60, 63, 11, 0, 0, 0, 98);
                DrawMod.DrawBlock(ref this.g2, tx + 6 + num47, ty + 61, (int) Math.Round(62.0 * ((double) num52 / 100.0)), 9, (int) Math.Round((double) a1), (int) Math.Round((double) a2), (int) Math.Round((double) a3), 150);
              }
              else
              {
                DrawMod.DrawBlock(ref this.g2, tx + 31 + num47, ty + 60, 35, 11, 0, 0, 0, 98);
                DrawMod.DrawBlock(ref this.g2, tx + 31 + num47, ty + 61, (int) Math.Round(34.0 * ((double) num52 / 100.0)), 9, (int) Math.Round((double) a1), (int) Math.Round((double) a2), (int) Math.Round((double) a3), 150);
              }
            }
          }
          if (this.game.EditObj.HideUnit != 2)
          {
            if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].SmallGfx > -1)
            {
              int nr4 = this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].SmallGfx];
              ref Graphics local57 = ref this.g2;
              bitmap1 = BitmapStore.GetBitmap(nr4);
              ref Bitmap local58 = ref bitmap1;
              int x = tx - 2 + num47;
              int y = ty + 41;
              DrawMod.DrawSimple(ref local57, ref local58, x, y);
            }
            if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].DesignationSmall[this.game.Data.UnitObj[nr].HistoricalSubPart] > -1)
            {
              int nr5 = this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].DesignationSmall[this.game.Data.UnitObj[nr].HistoricalSubPart]];
              if (nr5 > -1)
              {
                ref Graphics local59 = ref this.g2;
                bitmap1 = BitmapStore.GetBitmap(nr5);
                ref Bitmap local60 = ref bitmap1;
                int x = tx - 2 + num47;
                int y = ty + 41;
                DrawMod.DrawSimple(ref local59, ref local60, x, y);
              }
            }
          }
          string str = Strings.Trim(Conversion.Str((object) Number));
          int num53 = (int) Math.Round(38.0 - (double) this.g2.MeasureString(str, DrawMod.TGame.MarcFont16).Width / 2.0);
          DrawMod.DrawTextColouredMarc(ref this.g2, str, DrawMod.TGame.MarcFont16, tx + num53 + num47, ty + 56, Color.White);
        }
      }
      if (OverruleHis == -1 && this.game.Data.Turn == this.game.Data.UnitObj[nr].Regime)
      {
        float maxValue1 = (float) byte.MaxValue;
        float maxValue2 = (float) byte.MaxValue;
        float maxValue3 = (float) byte.MaxValue;
        int a4 = 196;
        int a5 = 92;
        float a6 = maxValue1 + (float) (int) Math.Round(((double) byte.MaxValue - (double) maxValue1) / 2.0);
        float a7 = maxValue2 + (float) (int) Math.Round(((double) byte.MaxValue - (double) maxValue2) / 2.0);
        float a8 = maxValue3 + (float) (int) Math.Round(((double) byte.MaxValue - (double) maxValue3) / 2.0);
        int num54 = (int) Math.Round(Math.Floor((double) this.game.HandyFunctionsObj.GetLowestAp(nr) / 10.0));
        if (num54 > 10)
          num54 = 10;
        if (isMilitia & num54 > 9)
          num54 = 9;
        if ((int) Math.Round(10.0 - (double) num10 / 6.0) < num54)
          num54 = (int) Math.Round(10.0 - (double) num10 / 6.0);
        if (!this.game.Data.UnitObj[nr].DidAttack & !this.game.Data.UnitObj[nr].DidMove)
        {
          a4 = (int) byte.MaxValue;
          a5 = (int) byte.MaxValue;
          a7 = (float) byte.MaxValue;
          a6 = 0.0f;
          a8 = 0.0f;
        }
        int num55 = num54;
        for (int index14 = 1; index14 <= num55; ++index14)
        {
          DrawMod.DrawBlock(ref this.g2, tx + 6 + (index14 - 1) * 6, ty + 5, 3, 3, (int) Math.Round((double) a6), (int) Math.Round((double) a7), (int) Math.Round((double) a8), a4);
          DrawMod.DrawRectangle(ref this.g2, tx + 6 + (index14 - 1) * 6 - 1, ty + 5 - 1, 4, 4, 0, 0, 0, a5);
        }
        if (this.game.Data.UnitObj[nr].cycleOrder < 0L & this.game.Data.UnitObj[nr].Regime == this.game.EditObj.RealTurn)
        {
          DrawMod.DrawBlock(ref this.g2, tx + 5, ty + 10, 13, 14, 0, 0, 0, 200);
          DrawMod.DrawTextColouredMarcCenter(ref this.g2, "G", this.game.MarcFont4, tx + 12, ty + 8, Color.White);
        }
        if (this.game.EventRelatedObj.Helper_AirEnabled() & !this.game.EditObj.AIMoving && this.game.EditObj.Zoom >= 0 & OverruleHis == -1)
        {
          this.slotAir = this.strId534slot;
          int num56 = this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(55);
          int num57 = this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(56);
          int num58 = this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(57);
          int numy = -1;
          int num59 = -1;
          if (this.slotAir > -1 & num56 > 0)
          {
            int airRowNr = -1;
            int length = this.game.Data.StringListObj[this.slotAir].Length;
            for (int index15 = 0; index15 <= length; ++index15)
            {
              if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[index15, 0])) == this.game.Data.RegimeObj[this.game.Data.Turn].id && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[index15, 1])) == this.game.Data.UnitObj[nr].X && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[index15, 2])) == this.game.Data.UnitObj[nr].Y && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[index15, 3])) == num57 && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[index15, 4])) == num58 && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[index15, 9])) >= 0)
              {
                numy = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[index15, 8]));
                num59 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[index15, 9]));
                airRowNr = index15;
                break;
              }
            }
            if (numy > -1)
            {
              string letter = this.game.HandyFunctionsObj.CovertNumberToLetter(numy);
              Color color = this.game.HandyFunctionsObj.Air_GetColor(airRowNr);
              int tcol = 0;
              int num60 = 1;
              DrawMod.DrawBlock(ref this.g2, tx + num60, ty + 44, 18, 14, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextCenterSmallLabel(ref this.g2, letter, this.game.MarcFont4, tx - 1 + num60 + 10, ty + 52, tcol);
            }
          }
        }
        float a9;
        float a10;
        float a11;
        if (this.game.Data.UnitObj[nr].SupplyInReq > 0)
        {
          int num61 = (int) Math.Round(Conversion.Int((double) (this.game.Data.UnitObj[nr].SupplyIn * 100) / (double) this.game.Data.UnitObj[nr].SupplyInReq));
          if (num61 >= 100)
          {
            a9 = 0.0f;
            a10 = (float) byte.MaxValue;
            a11 = 0.0f;
          }
          else if (num61 >= 66)
          {
            a9 = (float) byte.MaxValue;
            a10 = (float) byte.MaxValue;
            a11 = 0.0f;
          }
          else if (num61 >= 44)
          {
            a9 = 0.0f;
            a10 = 170f;
            a11 = (float) byte.MaxValue;
          }
          else if (num61 >= 22)
          {
            a9 = (float) byte.MaxValue;
            a10 = 0.0f;
            a11 = 0.0f;
          }
          else
          {
            a9 = 0.0f;
            a10 = 0.0f;
            a11 = 0.0f;
          }
        }
        else if (this.game.Data.UnitObj[nr].HQ == -1 | this.game.Data.UnitObj[nr].SupplyInReq == 0)
        {
          a9 = 0.0f;
          a10 = (float) byte.MaxValue;
          a11 = 0.0f;
        }
        else
        {
          a9 = 0.0f;
          a10 = 0.0f;
          a11 = 0.0f;
        }
        if (this.game.Data.UnitObj[nr].IsHQ)
        {
          DrawMod.DrawBlock(ref this.g2, tx + 32, ty + 66, 12, 6, (int) Math.Round((double) a9), (int) Math.Round((double) a10), (int) Math.Round((double) a11), (int) byte.MaxValue);
          DrawMod.DrawRectangle(ref this.g2, tx + 32, ty + 66, 12, 6, 0, 0, 0, 120);
        }
        else
        {
          DrawMod.DrawBlock(ref this.g2, tx + 4, ty + 63, 6, 6, (int) Math.Round((double) a9), (int) Math.Round((double) a10), (int) Math.Round((double) a11), (int) byte.MaxValue);
          DrawMod.DrawRectangle(ref this.g2, tx + 4, ty + 63, 6, 6, 0, 0, 0, 120);
        }
      }
      if (OverruleHis == -1 && this.game.Data.Turn == this.game.Data.UnitObj[nr].Regime)
      {
        if (this.game.EditObj.ShowSameHistorical && this.game.EditObj.UnitSelected > -1 && this.game.Data.UnitObj[nr].HQ > -1 & this.game.Data.UnitObj[nr].HQ == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ & !this.game.Data.UnitObj[nr].IsHQ | nr == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ && this.game.Data.UnitObj[index1].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index1].Historical].Type < 8)
        {
          float red = (float) this.game.Data.UnitObj[index1].Red;
          float green = (float) this.game.Data.UnitObj[index1].Green;
          float blue = (float) this.game.Data.UnitObj[index1].Blue;
          DrawMod.DrawRectangle(ref this.g2, tx + 2, ty + 2, 70, 70, (int) Math.Round((double) red), (int) Math.Round((double) green), (int) Math.Round((double) blue), 112, 5);
        }
        if (this.game.EditObj.ShowUnderHQ && this.game.EditObj.UnitSelected > -1 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ && this.game.Data.UnitObj[nr].HQ == this.game.EditObj.UnitSelected && this.game.Data.UnitObj[index1].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index1].Historical].Type < 8)
        {
          float red = (float) this.game.Data.UnitObj[this.game.Data.UnitObj[nr].HQ].Red;
          float green = (float) this.game.Data.UnitObj[this.game.Data.UnitObj[nr].HQ].Green;
          float blue = (float) this.game.Data.UnitObj[this.game.Data.UnitObj[nr].HQ].Blue;
          DrawMod.DrawRectangle(ref this.g2, tx + 2, ty + 2, 70, 70, (int) Math.Round((double) red), (int) Math.Round((double) green), (int) Math.Round((double) blue), 112, 5);
        }
        if ((double) this.game.Data.RuleVar[983] > 0.0 && !this.game.HandyFunctionsObj.CheckIfInCorrectFrontzone(nr, this.game.Data.UnitObj[nr].RealX(ref this.game), this.game.Data.UnitObj[nr].RealY(ref this.game)))
          DrawMod.DrawRectangle(ref this.g2, tx, ty, 77, 77, (int) byte.MaxValue, 0, 0, 172, 2);
      }
      if (this.game.EditObj.UnitSelected == nr & ShowAttacker)
      {
        DrawMod.DrawRectangle(ref this.g2, tx + 0, ty + 0, 74, 74, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 3);
        DrawMod.DrawRectangle(ref this.g2, tx - 1, ty - 1, 76, 76, 0, 0, 0, (int) byte.MaxValue);
        DrawMod.DrawRectangle(ref this.g2, tx + 2, ty + 2, 70, 70, 128, 128, 128, (int) byte.MaxValue);
      }
      if (Information.IsNothing((object) toG))
        return this.tmpbmp2;
label_403:
      Bitmap bitmap2;
      return bitmap2;
    }

    public Bitmap DrawUnit(
      int nr,
      bool forcehighlight = false,
      Graphics toG = null,
      int tx = 0,
      int ty = 0,
      bool ShowAttacker = false,
      int OverruleHis = -1,
      int OverrulePower = -1,
      int OverruleRegime = -1,
      bool FullRecon = false,
      int ForceHideUnitMode = -1,
      bool mostlyHidden = false)
    {
      Coordinate coordinate = new Coordinate();
      SizeF sizeF1 = new SizeF();
      SizeF sizeF2 = new SizeF();
      int[] numArray1 = new int[1];
      int hideUnit = this.game.EditObj.HideUnit;
      if (ForceHideUnitMode > -1)
        this.game.EditObj.HideUnit = ForceHideUnitMode;
      int[] numArray2 = this.game.Data.SFTypeCounter >= 101 ? new int[this.game.Data.SFTypeCounter + 1] : new int[101];
      if ((double) this.game.Data.RuleVar[344] == 0.0 && this.game.EditObj.HideUnit == 2)
        this.game.EditObj.HideUnit = 1;
      if (!Information.IsNothing((object) toG))
      {
        this.g2 = toG;
      }
      else
      {
        this.g2 = Graphics.FromImage((Image) this.tmpbmp2);
        this.g2.Clear(Color.FromArgb(0, 0, 0, 0));
      }
      if (!this.game.Data.FOWOn)
        FullRecon = true;
      int regime1;
      if (nr == -1 & OverruleHis == -1)
      {
        int num = 1;
        DrawMod.DrawSimplePart2(ref this.g2, ref this.game.Data.RegimeObj[regime1].TempCounter, new Rectangle(38 * num, 0, 38, 38), new Rectangle(tx, ty, 38, 38));
      }
      else
      {
        bool isMilitia;
        if (OverruleHis == -1)
          isMilitia = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].GiveHisVarValue(11) > 0;
        else if (OverruleHis <= this.game.Data.HistoricalUnitCounter)
          isMilitia = this.game.Data.HistoricalUnitObj[OverruleHis].GiveHisVarValue(11) > 0;
        int index1;
        int regimeNr;
        int integer1;
        int index2;
        Bitmap bitmap;
        float num1;
        float num2;
        float num3;
        Rectangle rectangle1;
        Rectangle rectangle2;
        int num4;
        if (OverruleHis == -1)
        {
          if (this.game.Data.UnitObj[nr].Historical != -1)
          {
            if (this.game.Data.UnitObj[nr].Regime == this.game.Data.Turn | this.game.Data.Round < 1 | !this.game.Data.FOWOn)
              coordinate.x = 3;
            else
              coordinate = this.game.HandyFunctionsObj.GetReconMinusHide(nr, this.game.Data.Turn);
            if (FullRecon)
            {
              coordinate.x = 3;
              coordinate.y = 0;
            }
            index1 = !this.game.Data.UnitObj[nr].IsHQ ? this.game.Data.UnitObj[nr].HQ : nr;
            bool flag1 = !(this.game.Data.UnitObj[nr].Regime == this.game.Data.Turn & this.game.Data.Round > 0) || this.game.Data.UnitObj[nr].X > -1 && this.game.HandyFunctionsObj.CanUnitMove2(nr);
            bool flag2 = false;
            if (Information.IsNothing((object) this.game.EditObj.TempUnitList))
              this.game.EditObj.TempUnitList = new UnitList();
            bool flag3;
            if (this.game.EditObj.OrderType == 2 && this.game.EditObj.TempUnitList.CheckIfPresent(nr))
            {
              flag2 = false;
              flag3 = true;
            }
            if (this.game.EditObj.OrderType == 12 && this.game.EditObj.TempUnitList.CheckIfPresent(nr))
            {
              flag2 = false;
              flag3 = true;
            }
            if (this.game.EditObj.OrderType == 11 && this.game.EditObj.TempUnitList.CheckIfPresent(nr))
            {
              flag2 = false;
              flag3 = true;
            }
            if (this.game.EditObj.OrderType == 13 && this.game.EditObj.TempUnitList.CheckIfPresent(nr))
            {
              flag2 = false;
              flag3 = true;
            }
            if (this.game.EditObj.OrderType == 14 && this.game.EditObj.TempUnitList.CheckIfPresent(nr))
            {
              flag2 = false;
              flag3 = true;
            }
            if (this.game.EditObj.OrderType == 15 && this.game.EditObj.TempUnitList.CheckIfPresent(nr))
            {
              flag2 = false;
              flag3 = true;
            }
            if (this.game.EditObj.OrderType == 9)
            {
              if (this.game.EditObj.OrderUnit == nr)
                flag2 = true;
              if (this.game.EditObj.OrderTarget == nr)
                flag2 = true;
            }
            if (this.game.EditObj.OrderType == 3 && this.game.EditObj.OrderUnit == nr)
              flag2 = true;
            if (this.game.EditObj.OrderType == 19)
            {
              if (this.game.EditObj.OrderUnit == nr)
                flag2 = true;
              if (this.game.EditObj.OrderTarget == nr)
                flag2 = true;
            }
            if (this.game.EditObj.OrderType == 33 && this.game.EditObj.OrderUnit == nr)
              flag2 = true;
            if (forcehighlight)
              flag2 = true;
            if (this.game.EditObj.LayerSupplyOn && this.game.EditObj.LayerSupplyHQ == this.game.Data.UnitObj[nr].HQ)
              flag2 = true;
            if (this.game.Data.UnitObj[nr].TempUnitSelectable)
              flag2 = true;
            regimeNr = this.game.Data.UnitObj[nr].Regime;
            if (regimeNr == -1)
              regimeNr = 0;
            if (regimeNr == 0)
              regimeNr = regimeNr;
            integer1 = Conversions.ToInteger(this.game.HandyFunctionsObj.GetUnitPeople(nr));
            index2 = regimeNr;
            if (this.game.Data.PeopleObj[integer1].RegCol > -1)
              index2 = this.game.Data.PeopleObj[integer1].RegCol;
            if (Information.IsNothing((object) this.game.Data.RegimeObj[index2].TempCounter))
              this.game.Data.RegimeObj[index2].DoTempCounter();
            if (OverruleRegime > -1 && Information.IsNothing((object) this.game.Data.RegimeObj[OverruleRegime].TempCounter))
              this.game.Data.RegimeObj[OverruleRegime].DoTempCounter();
            if (this.game.Data.UnitObj[nr].Regime == -1)
            {
              ref Graphics local1 = ref this.g2;
              bitmap = BitmapStore.GetBitmap(this.game.DEFAULTCOUNTER);
              ref Bitmap local2 = ref bitmap;
              int x = tx;
              int y = ty;
              DrawMod.DrawSimple(ref local1, ref local2, x, y);
            }
            else
            {
              int landscapeType = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[nr].X, this.game.Data.UnitObj[nr].Y].LandscapeType;
              int red;
              int green;
              int blue;
              if (this.game.Data.UnitObj[nr].Historical > -1 & (double) this.game.Data.RuleVar[344] == 1.0)
              {
                red = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Red;
                green = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Green;
                blue = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Blue;
              }
              if (red != 0 | green != 0 | blue != 0 | isMilitia)
              {
                if (!flag2)
                {
                  float num5 = (float) ((int) byte.MaxValue + red) / 256f;
                  float num6 = (float) ((int) byte.MaxValue + green) / 256f;
                  float num7 = (float) ((int) byte.MaxValue + blue) / 256f;
                  if ((double) num5 > 1.0)
                    num5 = 1f;
                  if ((double) num6 > 1.0)
                    num6 = 1f;
                  if ((double) num7 > 1.0)
                    num7 = 1f;
                  if (0.0 > (double) num5)
                    num1 = 0.0f;
                  if (0.0 > (double) num6)
                    num2 = 0.0f;
                  if (0.0 > (double) num7)
                    num3 = 0.0f;
                  if (isMilitia)
                  {
                    ref Graphics local3 = ref this.g2;
                    ref Bitmap local4 = ref this.game.Data.RegimeObj[regimeNr].TempCounterHigh;
                    rectangle1 = new Rectangle(38 * landscapeType, 0, 38, 38);
                    Rectangle srcrect = rectangle1;
                    rectangle2 = new Rectangle(tx, ty, 38, 38);
                    Rectangle destrect = rectangle2;
                    DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect, destrect);
                  }
                  else
                  {
                    ref Graphics local5 = ref this.g2;
                    ref Bitmap local6 = ref this.game.Data.RegimeObj[regimeNr].TempCounter;
                    rectangle1 = new Rectangle(38 * landscapeType, 0, 38, 38);
                    Rectangle srcrect = rectangle1;
                    rectangle2 = new Rectangle(tx, ty, 38, 38);
                    Rectangle destrect = rectangle2;
                    DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect, destrect);
                  }
                  if (flag3 & ShowAttacker)
                    DrawMod.DrawRectangle(ref this.g2, tx, ty, 38, 38, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
                  if (flag3 & ShowAttacker)
                    DrawMod.DrawRectangle(ref this.g2, tx + 1, ty + 1, 37, 37, 0, 0, 0, (int) byte.MaxValue);
                }
                else
                {
                  float num8 = (float) ((int) byte.MaxValue + red) / 256f;
                  float num9 = (float) ((int) byte.MaxValue + green) / 256f;
                  float num10 = (float) ((int) byte.MaxValue + blue) / 256f;
                  if ((double) num8 > 1.0)
                    num8 = 1f;
                  if ((double) num9 > 1.0)
                    num9 = 1f;
                  if ((double) num10 > 1.0)
                    num10 = 1f;
                  if (0.0 > (double) num8)
                    num1 = 0.0f;
                  if (0.0 > (double) num9)
                    num2 = 0.0f;
                  if (0.0 > (double) num10)
                    num3 = 0.0f;
                  if (isMilitia)
                  {
                    ref Graphics local7 = ref this.g2;
                    ref Bitmap local8 = ref this.game.Data.RegimeObj[regimeNr].TempCounterHigh;
                    rectangle1 = new Rectangle(38 * landscapeType, 0, 38, 38);
                    Rectangle srcrect = rectangle1;
                    rectangle2 = new Rectangle(tx, ty, 38, 38);
                    Rectangle destrect = rectangle2;
                    DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect, destrect);
                  }
                  else
                  {
                    ref Graphics local9 = ref this.g2;
                    ref Bitmap local10 = ref this.game.Data.RegimeObj[regimeNr].TempCounterHigh;
                    rectangle1 = new Rectangle(38 * landscapeType, 0, 38, 38);
                    Rectangle srcrect = rectangle1;
                    rectangle2 = new Rectangle(tx, ty, 38, 38);
                    Rectangle destrect = rectangle2;
                    DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect, destrect);
                  }
                  if (flag3 & ShowAttacker)
                    DrawMod.DrawRectangle(ref this.g2, tx, ty, 38, 38, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
                  if (flag3 & ShowAttacker)
                    DrawMod.DrawRectangle(ref this.g2, tx + 1, ty + 1, 37, 37, 0, 0, 0, (int) byte.MaxValue);
                }
              }
              else if (!flag2)
              {
                ref Graphics local11 = ref this.g2;
                ref Bitmap local12 = ref this.game.Data.RegimeObj[regimeNr].TempCounter;
                rectangle1 = new Rectangle(38 * landscapeType, 0, 38, 38);
                Rectangle srcrect = rectangle1;
                rectangle2 = new Rectangle(tx, ty, 38, 38);
                Rectangle destrect = rectangle2;
                DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect, destrect);
                if (flag3 & ShowAttacker)
                  DrawMod.DrawRectangle(ref this.g2, tx, ty, 38, 38, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
                if (flag3 & ShowAttacker)
                  DrawMod.DrawRectangle(ref this.g2, tx + 1, ty + 1, 37, 37, 0, 0, 0, (int) byte.MaxValue);
              }
              else
              {
                ref Graphics local13 = ref this.g2;
                ref Bitmap local14 = ref this.game.Data.RegimeObj[regimeNr].TempCounterHigh;
                rectangle1 = new Rectangle(38 * landscapeType, 0, 38, 38);
                Rectangle srcrect = rectangle1;
                rectangle2 = new Rectangle(tx, ty, 38, 38);
                Rectangle destrect = rectangle2;
                DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect, destrect);
                if (flag3 & ShowAttacker)
                  DrawMod.DrawRectangle(ref this.g2, tx, ty, 38, 38, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
                if (flag3 & ShowAttacker)
                  DrawMod.DrawRectangle(ref this.g2, tx + 1, ty + 1, 37, 37, 0, 0, 0, (int) byte.MaxValue);
              }
            }
          }
          else
            goto label_382;
        }
        else if (OverruleHis > -1 & OverruleRegime > -1)
        {
          if (OverruleRegime > -1 && Information.IsNothing((object) this.game.Data.RegimeObj[OverruleRegime].TempCounter))
            this.game.Data.RegimeObj[OverruleRegime].DoTempCounter();
          if (OverruleRegime == 0)
            num4 = num4;
          int num11 = 0;
          if (nr > -1)
            num11 = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[nr].X, this.game.Data.UnitObj[nr].Y].LandscapeType;
          ref Graphics local15 = ref this.g2;
          ref Bitmap local16 = ref this.game.Data.RegimeObj[OverruleRegime].TempCounter;
          rectangle1 = new Rectangle(38 * num11, 0, 38, 38);
          Rectangle srcrect = rectangle1;
          rectangle2 = new Rectangle(tx, ty, 38, 38);
          Rectangle destrect = rectangle2;
          DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect, destrect);
        }
        int num12 = 0;
        if (isMilitia & this.game.Data.Turn == regimeNr & OverruleHis == -1)
          DrawMod.DrawTextColouredConsoleCenter(ref this.g2, "M", this.game.MarcFont5, tx + 32, ty + 1, Color.FromArgb(228, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        else if (!isMilitia & this.game.Data.Turn == regimeNr & OverruleHis == -1)
        {
          string counterString = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].CounterString;
          if (Operators.CompareString(Strings.Trim(counterString), Strings.Trim(Conversion.Val(counterString).ToString()), false) == 0)
          {
            int num13 = (int) Math.Round((double) this.g2.MeasureString(counterString, DrawMod.TGame.MarcFont5).Width);
            num12 = num13;
            DrawMod.DrawTextColouredConsoleCenter(ref this.g2, counterString, this.game.MarcFont5, tx + 41 - num13, ty + 1, Color.FromArgb(228, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          }
        }
        if (nr > -1)
        {
          if (index1 > -1 & !this.game.Data.UnitObj[nr].IsHQ)
          {
            if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index1].Historical].Type < 8)
            {
              int red = this.game.Data.UnitObj[index1].Red;
              int green = this.game.Data.UnitObj[index1].Green;
              int blue = this.game.Data.UnitObj[index1].Blue;
              DrawMod.DrawBlockGradient2(ref this.g2, tx, ty + 25, 37, 12, Color.FromArgb(0, red, green, blue), Color.FromArgb(235, red, green, blue));
            }
          }
          else if (this.game.Data.UnitObj[nr].IsHQ & this.game.Data.UnitObj[nr].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Type < 8)
          {
            int red = this.game.Data.UnitObj[nr].Red;
            int green = this.game.Data.UnitObj[nr].Green;
            int blue = this.game.Data.UnitObj[nr].Blue;
            DrawMod.DrawBlockGradient2(ref this.g2, tx, ty + 1, 37, 35, Color.FromArgb(0, red, green, blue), Color.FromArgb(205, red, green, blue));
          }
        }
        else
          nr = nr;
        int num14;
        int index3;
        SizeF sizeF3;
        int num15;
        if (!mostlyHidden)
        {
          if (OverruleHis == -1)
          {
            int num16 = 0;
            if (this.game.Data.UnitObj[nr].HQ == -1 & !this.game.Data.UnitObj[nr].IsHQ)
              num16 = 0;
            int num17 = -1;
            int num18 = -1;
            if (coordinate.x > 1)
            {
              if (!this.game.Data.UnitObj[nr].IsHQ)
              {
                int sfCount1 = this.game.Data.UnitObj[nr].SFCount;
                int num19;
                for (int index4 = 0; index4 <= sfCount1; ++index4)
                {
                  int sf = this.game.Data.UnitObj[nr].SFList[index4];
                  int index5 = this.game.Data.SFObj[sf].Type;
                  int qty = this.game.Data.SFObj[sf].Qty;
                  if (this.game.Data.UnitObj[nr].X > -1 && index5 > -1 && this.game.Data.SFTypeObj[index5].Theater != 1 & this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.UnitObj[nr].X, this.game.Data.UnitObj[nr].Y].LandscapeType].IsSea)
                    index5 = -1;
                  if (index5 > -1)
                  {
                    int symbolGroup = this.game.Data.SFTypeObj[index5].SymbolGroup;
                    int symbolWeight = this.game.Data.SFTypeObj[index5].SymbolWeight;
                    if (symbolGroup > -1)
                    {
                      numArray2[symbolGroup] = numArray2[symbolGroup] + symbolWeight * qty * 10;
                      if (this.game.Data.SFTypeObj[index5].CarryCap > 0)
                        numArray2[symbolGroup] = numArray2[symbolGroup] + 1;
                      if (numArray2[symbolGroup] > num18)
                      {
                        num18 = numArray2[symbolGroup];
                        num19 = symbolGroup;
                      }
                    }
                  }
                }
                if (num19 > -1 | this.game.Data.UnitObj[nr].Historical > -1 & this.game.EditObj.HideUnit == 2)
                {
                  int num20 = num19;
                  int sfTypeNr = -1;
                  int num21 = 0;
                  int index6 = -1;
                  int sfTypeCounter = this.game.Data.SFTypeCounter;
                  for (int index7 = 0; index7 <= sfTypeCounter; ++index7)
                    numArray2[index7] = 0;
                  int sfCount2 = this.game.Data.UnitObj[nr].SFCount;
                  for (int index8 = 0; index8 <= sfCount2; ++index8)
                  {
                    int sf = this.game.Data.UnitObj[nr].SFList[index8];
                    int type = this.game.Data.SFObj[sf].Type;
                    int qty = this.game.Data.SFObj[sf].Qty;
                    int symbolGroup = this.game.Data.SFTypeObj[type].SymbolGroup;
                    int symbolWeight = this.game.Data.SFTypeObj[type].SymbolWeight;
                    if (symbolGroup == num20)
                    {
                      numArray2[type] = numArray2[type] + symbolWeight * qty * 10;
                      if (this.game.Data.SFTypeObj[type].CarryCap > 0)
                        numArray2[type] = numArray2[type] + 1;
                      if (numArray2[type] > num21)
                      {
                        num21 = numArray2[type];
                        sfTypeNr = type;
                        index6 = sf;
                      }
                    }
                  }
                  if (sfTypeNr > -1)
                  {
                    if (this.game.EditObj.HideUnit != 2 & sfTypeNr > -1 & this.game.Data.UnitObj[nr].Historical > -1 & this.game.Data.SFTypeObj[sfTypeNr].SFTypeVar[89] > 0)
                    {
                      int tv0 = this.game.Data.PeopleObj[this.game.Data.SFObj[index6].People].tv0;
                      if (this.slotCulture < 0)
                        this.slotCulture = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 306, 0, 0));
                      int integer2 = Conversions.ToInteger(this.game.Data.StringListObj[this.slotCulture].GetData(0, tv0, 1));
                      Bitmap objBitmap;
                      if (!Information.IsNothing((object) this.game.Data.UnitObj[nr].tempSFTypeBitmap))
                      {
                        objBitmap = this.game.Data.UnitObj[nr].tempSFTypeBitmap;
                      }
                      else
                      {
                        objBitmap = this.DrawSFTypeGraphic(sfTypeNr, isMilitia, integer2, regimeNr, nr);
                        this.game.Data.UnitObj[nr].tempSFTypeBitmap = objBitmap;
                      }
                      if (!Information.IsNothing((object) objBitmap))
                      {
                        int num22 = 0;
                        int num23 = 0;
                        int w = 38;
                        int h = 32;
                        int width = objBitmap.Width;
                        int height = objBitmap.Height;
                        if (width > w | height > h)
                        {
                          if ((double) width / (double) w > (double) height / (double) h)
                          {
                            float num24 = (float) w / (float) width;
                            int num25 = (int) Math.Round((double) ((float) h - (float) height * num24));
                            num23 += (int) Math.Round((double) num25 / 2.0);
                            h -= num25;
                          }
                          else
                          {
                            float num26 = (float) h / (float) height;
                            int num27 = (int) Math.Round((double) ((float) w - (float) width * num26));
                            num22 += (int) Math.Round((double) num27 / 2.0);
                            w -= num27;
                          }
                          if (this.game.Data.RegimeObj[this.game.Data.UnitObj[nr].Regime].Mirror)
                          {
                            Matrix matrix = new Matrix();
                            matrix.Scale(-1f, 1f);
                            if (Information.IsNothing((object) toG))
                              matrix.Translate((float) -(w + 0), 0.0f);
                            else
                              matrix.Translate((float) -(2 * (num22 + tx) + (w + 0)), 0.0f);
                            this.g2.Transform = matrix;
                          }
                          DrawMod.DrawScaled(ref this.g2, ref objBitmap, tx + num22, ty + num23, w, h);
                        }
                        else
                        {
                          if (this.game.Data.RegimeObj[this.game.Data.UnitObj[nr].Regime].Mirror)
                          {
                            Matrix matrix = new Matrix();
                            matrix.Scale(-1f, 1f);
                            if (Information.IsNothing((object) toG))
                              matrix.Translate((float) -(w + 0), 0.0f);
                            else
                              matrix.Translate((float) -(2 * tx + (w + 0)), 0.0f);
                            this.g2.Transform = matrix;
                          }
                          DrawMod.DrawSimple(ref this.g2, ref objBitmap, tx + num22 + (int) Math.Round((double) (w - width) / 2.0), ty + num23 + (int) Math.Round((double) (h - height) / 2.0));
                        }
                        this.g2.ResetTransform();
                      }
                    }
                    else if (sfTypeNr > -1 | this.game.Data.UnitObj[nr].Historical > -1 & this.game.EditObj.HideUnit == 2 | (double) this.game.Data.RuleVar[344] == 0.0)
                    {
                      int nr1 = -1;
                      if (sfTypeNr > -1)
                        nr1 = this.game.Data.SFTypeObj[sfTypeNr].SymbolSpriteID;
                      int nr2 = -1;
                      if (regimeNr > -1 & sfTypeNr > -1)
                      {
                        if (this.game.Data.RegimeObj[regimeNr].ExtraGraphicUse > -1)
                        {
                          int extraCounter = this.game.Data.SFTypeObj[sfTypeNr].ExtraCounter;
                          for (int index9 = 0; index9 <= extraCounter; ++index9)
                          {
                            if (this.game.Data.SFTypeObj[sfTypeNr].ExtraCode[index9] == this.game.Data.RegimeObj[regimeNr].ExtraGraphicUse)
                              nr1 = this.game.Data.SFTypeObj[sfTypeNr].ExtraSymbolSpriteID[index9];
                          }
                        }
                        else if (this.game.Data.PeopleObj[integer1].ExtraGraphicUse > -1)
                        {
                          int extraCounter = this.game.Data.SFTypeObj[sfTypeNr].ExtraCounter;
                          for (int index10 = 0; index10 <= extraCounter; ++index10)
                          {
                            if (this.game.Data.SFTypeObj[sfTypeNr].ExtraCode[index10] == this.game.Data.PeopleObj[integer1].ExtraGraphicUse)
                              nr1 = this.game.Data.SFTypeObj[sfTypeNr].ExtraSymbolSpriteID[index10];
                          }
                        }
                      }
                      int num28;
                      if (this.game.EditObj.HideUnit == 2 && this.game.Data.UnitObj[nr].Historical > -1 & (double) this.game.Data.RuleVar[344] == 1.0)
                      {
                        nr1 = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].SmallGfx <= -1 ? -1 : this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].SmallGfx];
                        if (nr1 == -1 & this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Counter > 0 & this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Counter <= this.game.NATO.GetUpperBound(0))
                          nr1 = this.game.NATO[this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Counter];
                        if (nr1 > -1)
                        {
                          num28 = 8;
                          if (this.game.Data.UnitObj[nr].HistoricalSubPart > -1)
                          {
                            if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].DesignationSmall[this.game.Data.UnitObj[nr].HistoricalSubPart] > 0)
                              nr2 = this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].DesignationSmall[this.game.Data.UnitObj[nr].HistoricalSubPart]];
                            else if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Designation[this.game.Data.UnitObj[nr].HistoricalSubPart] > 0)
                              nr2 = this.game.NATO[this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Designation[this.game.Data.UnitObj[nr].HistoricalSubPart]];
                          }
                        }
                      }
                      num17 = nr1;
                      int regime2 = this.game.Data.UnitObj[nr].Regime;
                      if (regime2 > -1 & sfTypeNr > -1)
                      {
                        float num29 = 1f;
                        float num30 = 1f;
                        float num31 = 1f;
                        if (this.game.EditObj.HideUnit == 2)
                        {
                          num16 -= 3;
                          num28 -= 15;
                        }
                        if (this.game.Data.RegimeObj[regime2].Mirror & !(this.game.EditObj.HideUnit == 2 & this.game.Data.UnitObj[nr].Historical > -1))
                        {
                          Matrix matrix = new Matrix();
                          matrix.Scale(-1f, 1f);
                          if (Information.IsNothing((object) toG))
                            matrix.Translate(-45f, 0.0f);
                          else
                            matrix.Translate((float) -(2 * tx + 45), 0.0f);
                          this.g2.Transform = matrix;
                          if (this.game.EditObj.PrefMinimalistCounter && this.game.Data.Product < 6)
                            num16 = 3;
                          if (this.game.Data.Product == 7)
                            num16 += 6;
                        }
                        if (this.game.Data.SFTypeObj[sfTypeNr].SFTypeVar[82] > 0 & this.game.EditObj.HideUnit != 2)
                          num28 = -2;
                        if ((double) num29 == 1.0 & (double) num30 == 1.0 & (double) num31 == 1.0)
                        {
                          if (this.game.Data.SFTypeObj[sfTypeNr].SFTypeVar[82] > 0 & nr1 > 0)
                          {
                            if (this.game.Data.SFTypeObj[sfTypeNr].artCode[0] < 1 | this.game.EditObj.HideUnit == 2)
                            {
                              ref Graphics local17 = ref this.g2;
                              bitmap = BitmapStore.GetBitmap(nr1);
                              ref Bitmap local18 = ref bitmap;
                              int x = num16 + tx;
                              int y = ty + num28;
                              DrawMod.DrawSimple(ref local17, ref local18, x, y);
                            }
                            else
                            {
                              ref Graphics local19 = ref this.g2;
                              bitmap = BitmapStore.GetBitmap(nr1);
                              ref Bitmap local20 = ref bitmap;
                              rectangle1 = new Rectangle(0, 0, 38, 38);
                              Rectangle srcrect = rectangle1;
                              rectangle2 = new Rectangle(num16 + tx, ty + num28, 38, 38);
                              Rectangle destrect = rectangle2;
                              double r = (double) ((float) this.game.Data.SFTypeObj[sfTypeNr].artCode[1] / (float) byte.MaxValue);
                              double g = (double) ((float) this.game.Data.SFTypeObj[sfTypeNr].artCode[2] / (float) byte.MaxValue);
                              double b = (double) ((float) this.game.Data.SFTypeObj[sfTypeNr].artCode[3] / (float) byte.MaxValue);
                              DrawMod.DrawSimplePart2ColouredNew(ref local19, ref local20, srcrect, destrect, (float) r, (float) g, (float) b, 1f);
                            }
                            if (this.game.Data.SFTypeObj[sfTypeNr].artCode[5] == 1 & this.game.EditObj.HideUnit != 2)
                            {
                              ref Graphics local21 = ref this.g2;
                              bitmap = BitmapStore.GetBitmap(this.game.Data.SFTypeObj[sfTypeNr].SymbolColBigSpriteID);
                              ref Bitmap local22 = ref bitmap;
                              rectangle1 = new Rectangle(0, 0, 38, 38);
                              Rectangle srcrect = rectangle1;
                              rectangle2 = new Rectangle(num16 + tx, ty + num28, 38, 38);
                              Rectangle destrect = rectangle2;
                              double r = (double) ((float) this.game.Data.SFTypeObj[sfTypeNr].artCode[6] / (float) byte.MaxValue);
                              double g = (double) ((float) this.game.Data.SFTypeObj[sfTypeNr].artCode[7] / (float) byte.MaxValue);
                              double b = (double) ((float) this.game.Data.SFTypeObj[sfTypeNr].artCode[8] / (float) byte.MaxValue);
                              double a = (double) ((float) this.game.Data.SFTypeObj[sfTypeNr].artCode[9] / (float) byte.MaxValue);
                              DrawMod.DrawSimplePart2ColouredNew(ref local21, ref local22, srcrect, destrect, (float) r, (float) g, (float) b, (float) a);
                            }
                          }
                          else if (nr1 > 0)
                          {
                            ref Graphics local23 = ref this.g2;
                            bitmap = BitmapStore.GetBitmap(nr1);
                            ref Bitmap local24 = ref bitmap;
                            int x = num16 + tx;
                            int y = ty + num28;
                            DrawMod.DrawSimple(ref local23, ref local24, x, y);
                          }
                          this.g2.ResetTransform();
                          if (nr2 > 0)
                          {
                            ref Graphics local25 = ref this.g2;
                            bitmap = BitmapStore.GetBitmap(nr2);
                            ref Bitmap local26 = ref bitmap;
                            int x = num16 + tx;
                            int y = ty + num28;
                            DrawMod.DrawSimple(ref local25, ref local26, x, y);
                          }
                        }
                        else
                        {
                          if (nr1 > 0)
                          {
                            ref Graphics local27 = ref this.g2;
                            bitmap = BitmapStore.GetBitmap(nr1);
                            ref Bitmap local28 = ref bitmap;
                            int x = num16 + tx;
                            int y = ty + num28;
                            double r = (double) num29 - 1.0;
                            double g = (double) num30 - 1.0;
                            double b = (double) num31 - 1.0;
                            DrawMod.Draw(ref local27, ref local28, x, y, (float) r, (float) g, (float) b, 1f);
                          }
                          this.g2.ResetTransform();
                          if (nr2 > 0)
                          {
                            ref Graphics local29 = ref this.g2;
                            bitmap = BitmapStore.GetBitmap(nr2);
                            ref Bitmap local30 = ref bitmap;
                            int x = num16 + tx;
                            int y = ty + num28;
                            double r = (double) num29 - 1.0;
                            double g = (double) num30 - 1.0;
                            double b = (double) num31 - 1.0;
                            DrawMod.Draw(ref local29, ref local30, x, y, (float) r, (float) g, (float) b, 1f);
                          }
                        }
                      }
                      else
                      {
                        if ((double) this.game.Data.RuleVar[847] == 1.0 & this.game.EditObj.HideUnit == 2 & this.game.Data.UnitObj[nr].Historical > -1)
                          num28 -= 8;
                        if (nr1 > 0)
                        {
                          ref Graphics local31 = ref this.g2;
                          bitmap = BitmapStore.GetBitmap(nr1);
                          ref Bitmap local32 = ref bitmap;
                          int x = num16 + tx;
                          int y = ty + num28;
                          DrawMod.DrawSimple(ref local31, ref local32, x, y);
                        }
                        this.g2.ResetTransform();
                        if (nr2 > 0)
                        {
                          ref Graphics local33 = ref this.g2;
                          bitmap = BitmapStore.GetBitmap(nr2);
                          ref Bitmap local34 = ref bitmap;
                          int x = num16 + tx;
                          int y = ty + num28;
                          DrawMod.DrawSimple(ref local33, ref local34, x, y);
                        }
                      }
                    }
                  }
                }
              }
              else
              {
                if (this.game.EditObj.HideUnit == 2 && this.game.Data.UnitObj[nr].Historical > -1 & (double) this.game.Data.RuleVar[344] == 1.0)
                  num14 = 8;
                if (this.game.Data.UnitObj[nr].IsHQ)
                  num14 = 0;
                index3 = -1;
                regime1 = this.game.Data.UnitObj[nr].Regime;
                if (this.game.Data.UnitObj[nr].Regime > -1)
                {
                  int hqSpriteNr = this.game.Data.RegimeObj[index2].HQSpriteNr;
                  float num32 = (float) this.game.Data.RegimeObj[index2].Red / 256f;
                  float num33 = (float) this.game.Data.RegimeObj[index2].Green / 256f;
                  float num34 = (float) this.game.Data.RegimeObj[index2].Blue / 256f;
                  ref Graphics local35 = ref this.g2;
                  bitmap = BitmapStore.GetBitmap(hqSpriteNr);
                  ref Bitmap local36 = ref bitmap;
                  int x1 = tx - 4;
                  int y1 = ty + 2;
                  double r1 = (double) num32 - 1.0;
                  double g1 = (double) num33 - 1.0;
                  double b1 = (double) num34 - 1.0;
                  DrawMod.Draw(ref local35, ref local36, x1, y1, (float) r1, (float) g1, (float) b1, 1f);
                  int hqSpriteNr2 = this.game.Data.RegimeObj[index2].HQSpriteNr2;
                  if (this.game.Data.UnitObj[nr].Historical <= -1 || this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].SmallGfx > -1 || this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].Counter <= 0)
                    ;
                  float num35;
                  float num36;
                  float num37;
                  if (!this.game.Data.RegimeObj[index2].HQSpriteOverrule)
                  {
                    num35 = (float) this.game.Data.RegimeObj[index2].Red3 / 256f;
                    num36 = (float) this.game.Data.RegimeObj[index2].Green3 / 256f;
                    num37 = (float) this.game.Data.RegimeObj[index2].Blue3 / 256f;
                  }
                  else
                  {
                    num35 = 1f;
                    num36 = 1f;
                    num37 = 1f;
                  }
                  ref Graphics local37 = ref this.g2;
                  bitmap = BitmapStore.GetBitmap(hqSpriteNr2);
                  ref Bitmap local38 = ref bitmap;
                  int x2 = tx - 4;
                  int y2 = ty + 2;
                  double r2 = (double) num35 - 1.0;
                  double g2 = (double) num36 - 1.0;
                  double b2 = (double) num37 - 1.0;
                  DrawMod.Draw(ref local37, ref local38, x2, y2, (float) r2, (float) g2, (float) b2, 1f);
                  string counterString = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[nr].Historical].CounterString;
                  string str = Strings.UCase(Strings.Left(counterString, 1)) + Strings.Mid(counterString, 2);
                  Conversion.Str((object) Conversion.Val(str));
                  sizeF3 = this.g2.MeasureString(str, this.stdFont1);
                  int num38 = (int) Math.Round(20.0 - (double) (int) Math.Round((double) sizeF3.Width) / 2.0);
                  DrawMod.DrawTextColouredMarcCounter(ref this.g2, Strings.Trim(str), this.stdFont1, tx + num38, ty + 23, Color.White);
                }
              }
            }
          }
          else if (OverruleRegime > -1 & OverruleHis > -1 & OverrulePower == -9999 & (double) this.game.Data.RuleVar[344] == 1.0 & OverruleHis <= this.game.Data.HistoricalUnitObj.GetUpperBound(0))
          {
            int num39 = 12;
            float a1;
            float a2;
            float a3;
            if (OverruleRegime > -1)
            {
              a1 = (float) this.game.Data.RegimeObj[OverruleRegime].Red3;
              a2 = (float) this.game.Data.RegimeObj[OverruleRegime].Green3;
              a3 = (float) this.game.Data.RegimeObj[OverruleRegime].Blue3;
            }
            else
            {
              a1 = 128f;
              a2 = 128f;
              a3 = 128f;
            }
            sizeF3 = this.g2.MeasureString("?", this.stdFont1);
            int num40 = (int) Math.Round(19.0 - (double) sizeF3.Width / 2.0);
            DrawMod.DrawTextColouredMarcCounter(ref this.g2, "?", this.stdFont1, tx + num40, ty + num39, Color.FromArgb((int) byte.MaxValue, (int) Math.Round((double) a1), (int) Math.Round((double) a2), (int) Math.Round((double) a3)));
          }
          else if (OverruleRegime > -1 & OverruleHis > -1 & OverrulePower != -9999 & (double) this.game.Data.RuleVar[344] == 1.0 & OverruleHis <= this.game.Data.HistoricalUnitObj.GetUpperBound(0))
          {
            int num41 = -11;
            bool flag = false;
            int hqSpriteNr;
            float num42;
            float num43;
            float num44;
            if (this.game.Data.HistoricalUnitObj[OverruleHis].Type < 5)
            {
              if (this.game.Data.HistoricalUnitObj[OverruleHis].SmallGfx > -1)
                hqSpriteNr = this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[OverruleHis].SmallGfx];
              else if (this.game.Data.HistoricalUnitObj[OverruleHis].Counter > -1)
                hqSpriteNr = this.game.NATO[this.game.Data.HistoricalUnitObj[OverruleHis].Counter];
              if (this.game.Data.SFTypeObj[index3].SymbolOverrule)
              {
                num42 = 1f;
                num43 = 1f;
                num44 = 1f;
              }
              else
              {
                num42 = 1f;
                num43 = 1f;
                num44 = 1f;
              }
            }
            else
            {
              if (this.game.Data.HistoricalUnitObj[OverruleHis].SmallGfx > -1)
              {
                hqSpriteNr = this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[OverruleHis].SmallGfx];
              }
              else
              {
                hqSpriteNr = this.game.Data.RegimeObj[OverruleRegime].HQSpriteNr;
                num41 = 2;
                flag = true;
              }
              if (!this.game.Data.RegimeObj[OverruleRegime].HQSpriteOverrule)
              {
                num42 = (float) this.game.Data.RegimeObj[OverruleRegime].Red3 / 256f;
                num43 = (float) this.game.Data.RegimeObj[OverruleRegime].Green3 / 256f;
                num44 = (float) this.game.Data.RegimeObj[OverruleRegime].Blue3 / 256f;
              }
              else
              {
                num42 = 1f;
                num43 = 1f;
                num44 = 1f;
              }
            }
            int nr3 = -1;
            int num45;
            int num46 = num45 - 3;
            if ((double) num42 == 1.0 & (double) num43 == 1.0 & (double) num44 == 1.0)
            {
              if (flag)
              {
                float num47 = (float) this.game.Data.RegimeObj[OverruleRegime].Red / 256f;
                float num48 = (float) this.game.Data.RegimeObj[OverruleRegime].Green / 256f;
                float num49 = (float) this.game.Data.RegimeObj[OverruleRegime].Blue / 256f;
                ref Graphics local39 = ref this.g2;
                bitmap = BitmapStore.GetBitmap(hqSpriteNr);
                ref Bitmap local40 = ref bitmap;
                int x3 = num46 + tx;
                int y3 = ty + num41;
                double r = (double) num47 - 1.0;
                double g = (double) num48 - 1.0;
                double b = (double) num49 - 1.0;
                DrawMod.Draw(ref local39, ref local40, x3, y3, (float) r, (float) g, (float) b, 1f);
                int hqSpriteNr2 = this.game.Data.RegimeObj[OverruleRegime].HQSpriteNr2;
                num1 = (float) this.game.Data.RegimeObj[OverruleRegime].Red3 / 256f;
                num2 = (float) this.game.Data.RegimeObj[OverruleRegime].Green3 / 256f;
                num3 = (float) this.game.Data.RegimeObj[OverruleRegime].Blue3 / 256f;
                if (hqSpriteNr2 > -1)
                {
                  ref Graphics local41 = ref this.g2;
                  bitmap = BitmapStore.GetBitmap(hqSpriteNr2);
                  ref Bitmap local42 = ref bitmap;
                  int x4 = num46 + tx;
                  int y4 = ty + num41;
                  DrawMod.DrawSimple(ref local41, ref local42, x4, y4);
                }
              }
              else
              {
                ref Graphics local43 = ref this.g2;
                bitmap = BitmapStore.GetBitmap(hqSpriteNr);
                ref Bitmap local44 = ref bitmap;
                int x = num46 + tx;
                int y = ty + num41;
                DrawMod.DrawSimple(ref local43, ref local44, x, y);
              }
              this.g2.ResetTransform();
              if (nr3 > -1)
              {
                ref Graphics local45 = ref this.g2;
                bitmap = BitmapStore.GetBitmap(nr3);
                ref Bitmap local46 = ref bitmap;
                int x = num46 + tx;
                int y = ty + num41;
                DrawMod.DrawSimple(ref local45, ref local46, x, y);
              }
            }
            else
            {
              if (flag)
              {
                float num50 = (float) this.game.Data.RegimeObj[OverruleRegime].Red / 256f;
                float num51 = (float) this.game.Data.RegimeObj[OverruleRegime].Green / 256f;
                float num52 = (float) this.game.Data.RegimeObj[OverruleRegime].Blue / 256f;
                ref Graphics local47 = ref this.g2;
                bitmap = BitmapStore.GetBitmap(hqSpriteNr);
                ref Bitmap local48 = ref bitmap;
                int x5 = num46 + tx;
                int y5 = ty + num41;
                double r = (double) num50 - 1.0;
                double g = (double) num51 - 1.0;
                double b = (double) num52 - 1.0;
                DrawMod.Draw(ref local47, ref local48, x5, y5, (float) r, (float) g, (float) b, 1f);
                int hqSpriteNr2 = this.game.Data.RegimeObj[OverruleRegime].HQSpriteNr2;
                num42 = (float) this.game.Data.RegimeObj[OverruleRegime].Red3 / 256f;
                num43 = (float) this.game.Data.RegimeObj[OverruleRegime].Green3 / 256f;
                num44 = (float) this.game.Data.RegimeObj[OverruleRegime].Blue3 / 256f;
                if (hqSpriteNr2 > -1)
                {
                  ref Graphics local49 = ref this.g2;
                  bitmap = BitmapStore.GetBitmap(hqSpriteNr2);
                  ref Bitmap local50 = ref bitmap;
                  int x6 = num46 + tx;
                  int y6 = ty + num41;
                  DrawMod.DrawSimple(ref local49, ref local50, x6, y6);
                }
              }
              else
              {
                ref Graphics local51 = ref this.g2;
                bitmap = BitmapStore.GetBitmap(hqSpriteNr);
                ref Bitmap local52 = ref bitmap;
                int x = num46 + tx;
                int y = ty + num41;
                double r = (double) num42 - 1.0;
                double g = (double) num43 - 1.0;
                double b = (double) num44 - 1.0;
                DrawMod.Draw(ref local51, ref local52, x, y, (float) r, (float) g, (float) b, 1f);
              }
              this.g2.ResetTransform();
              if (nr3 > -1)
              {
                ref Graphics local53 = ref this.g2;
                bitmap = BitmapStore.GetBitmap(nr3);
                ref Bitmap local54 = ref bitmap;
                int x = num46 + tx;
                int y = ty + num41;
                double r = (double) num42 - 1.0;
                double g = (double) num43 - 1.0;
                double b = (double) num44 - 1.0;
                DrawMod.Draw(ref local53, ref local54, x, y, (float) r, (float) g, (float) b, 1f);
              }
            }
            if (OverrulePower > -1 & OverruleRegime > -1)
            {
              float red3 = (float) this.game.Data.RegimeObj[OverruleRegime].Red3;
              float green3 = (float) this.game.Data.RegimeObj[OverruleRegime].Green3;
              float blue3 = (float) this.game.Data.RegimeObj[OverruleRegime].Blue3;
              int num53 = (int) Math.Round(19.0 - (double) this.g2.MeasureString(Strings.Trim(Conversion.Str((object) OverrulePower)), this.stdFont1).Width / 2.0);
              DrawMod.DrawTextColouredMarcCounter(ref this.g2, Strings.Trim(Conversion.Str((object) OverrulePower)), this.stdFont1, tx + num53, ty + 16 + 5, Color.FromArgb((int) byte.MaxValue, (int) Math.Round((double) red3), (int) Math.Round((double) green3), (int) Math.Round((double) blue3)));
            }
          }
          else if (nr > -1)
          {
            num14 = 0;
            if (OverruleRegime == -1)
              OverruleRegime = this.game.Data.UnitObj[nr].Regime;
            num15 = this.game.Data.RegimeObj[OverruleRegime].HQSpriteNr;
            if (!this.game.Data.RegimeObj[OverruleRegime].HQSpriteOverrule)
            {
              num1 = (float) this.game.Data.RegimeObj[OverruleRegime].Red3 / 256f;
              num2 = (float) this.game.Data.RegimeObj[OverruleRegime].Green3 / 256f;
              num3 = (float) this.game.Data.RegimeObj[OverruleRegime].Blue3 / 256f;
            }
            else
            {
              num1 = 1f;
              num2 = 1f;
              num3 = 1f;
            }
            this.g2.ResetTransform();
          }
        }
        if (OverruleHis == -1 & !mostlyHidden)
        {
          if (!this.game.Data.UnitObj[nr].IsHQ)
          {
            regime1 = this.game.Data.UnitObj[nr].Regime;
            int num54 = coordinate.x != 2 ? ((double) this.game.Data.RuleVar[847] != 1.0 ? this.game.HandyFunctionsObj.GetPower(nr, this.game.Data.Turn, FullRecon: FullRecon) : this.game.HandyFunctionsObj.GetPower(nr, this.game.Data.Turn, FullRecon: FullRecon, AbsPower: true)) : ((double) this.game.Data.RuleVar[847] != 1.0 ? this.game.HandyFunctionsObj.GetPower(nr, this.game.Data.Turn, randomelement: coordinate.y) : this.game.HandyFunctionsObj.GetPower(nr, this.game.Data.Turn, randomelement: coordinate.y, AbsPower: true));
            if (num54 > 999)
              num54 = 999;
            if (OverrulePower > -1)
              num54 = OverrulePower;
            else if (OverrulePower == -9999)
              num54 = -9999;
            int num55 = num54;
            if (OverruleHis == -1 & this.game.Data.Turn == this.game.Data.UnitObj[nr].Regime)
            {
              float a4 = (float) byte.MaxValue;
              float maxValue = (float) byte.MaxValue;
              float a5 = (float) byte.MaxValue;
              int a6 = 196;
              int a7 = 92;
              int num56 = (int) Math.Round(Math.Floor((double) this.game.HandyFunctionsObj.GetLowestAp(nr) / 10.0));
              if (num56 > 10)
                num56 = 8;
              if (isMilitia & num56 > 5)
                num56 = 5;
              if ((int) Math.Round(10.0 - (double) num12 / 3.0) < num56)
                num56 = (int) Math.Round(10.0 - (double) num12 / 3.0);
              if (!this.game.Data.UnitObj[nr].DidAttack & !this.game.Data.UnitObj[nr].DidMove)
              {
                a6 = (int) byte.MaxValue;
                a7 = (int) byte.MaxValue;
                maxValue = (float) byte.MaxValue;
                a4 = 0.0f;
                a5 = 0.0f;
              }
              int num57 = num56;
              for (int index11 = 1; index11 <= num57; ++index11)
              {
                DrawMod.DrawBlock(ref this.g2, tx + 10 + (index11 - 1) * 3, ty + 4, 2, 2, (int) Math.Round((double) a4), (int) Math.Round((double) maxValue), (int) Math.Round((double) a5), a6);
                DrawMod.DrawRectangle(ref this.g2, tx + 10 + (index11 - 1) * 3 - 1, ty + 4 - 1, 3, 3, 0, 0, 0, a7);
              }
              int averageRdn = this.game.HandyFunctionsObj.GetAverageRdn(nr);
              int num58 = num55;
              this.game.HandyFunctionsObj.GetBreakPercent(nr);
              int num59 = (int) Math.Round((double) this.game.Data.RuleVar[307]);
              int num60 = this.game.HandyFunctionsObj.GetStartPower(nr);
              if (num60 == 0)
                num60 = num58;
              int num61 = (int) Math.Round(Conversion.Int((double) num58 / (double) num60 * 100.0));
              if ((int) Math.Round(34.0 - Conversion.Int((double) num58 / (double) num60 * 34.0)) < 0)
                num4 = 0;
              if (num58 > 0)
              {
                float a8;
                float a9;
                float a10;
                if (averageRdn >= 75)
                {
                  a8 = 0.0f;
                  a9 = (float) byte.MaxValue;
                  a10 = 0.0f;
                }
                else if (averageRdn >= 50)
                {
                  a8 = (float) byte.MaxValue;
                  a9 = (float) byte.MaxValue;
                  a10 = 0.0f;
                }
                else if (averageRdn >= 25)
                {
                  a8 = 0.0f;
                  a9 = 170f;
                  a10 = (float) byte.MaxValue;
                }
                else
                {
                  a8 = (float) byte.MaxValue;
                  a9 = 0.0f;
                  a10 = 0.0f;
                }
                int num62 = num61;
                if (num62 > 100)
                  num62 = 100;
                DrawMod.DrawBlock(ref this.g2, tx + 5, ty + 28, 28, 7, 0, 0, 0, 98);
                DrawMod.DrawBlock(ref this.g2, tx + 6, ty + 29, (int) Math.Round(26.0 * ((double) num62 / 100.0)), 5, (int) Math.Round((double) a8), (int) Math.Round((double) a9), (int) Math.Round((double) a10), 150);
              }
            }
            int Number = num55;
            float red3 = (float) this.game.Data.RegimeObj[index2].Red3;
            float green3 = (float) this.game.Data.RegimeObj[index2].Green3;
            float blue3 = (float) this.game.Data.RegimeObj[index2].Blue3;
            if (OverruleHis > -1)
            {
              red3 = (float) this.game.Data.RegimeObj[OverruleRegime].Red3;
              green3 = (float) this.game.Data.RegimeObj[OverruleRegime].Green3;
              blue3 = (float) this.game.Data.RegimeObj[OverruleRegime].Blue3;
            }
            if (coordinate.x > 1 | OverruleHis > -1)
            {
              int num63 = OverruleHis != -1 ? OverruleHis : this.game.Data.UnitObj[nr].Historical;
              sizeF3 = this.g2.MeasureString(Strings.Trim(Conversion.Str((object) Number)), this.stdFont1);
              int num64 = (int) Math.Round(19.0 - (double) sizeF3.Width / 2.0);
              DrawMod.DrawTextColouredMarcCounter(ref this.g2, Strings.Trim(Conversion.Str((object) Number)), this.stdFont1, tx + num64, ty + 16 + 8, Color.FromArgb((int) byte.MaxValue, (int) Math.Round((double) red3), (int) Math.Round((double) green3), (int) Math.Round((double) blue3)));
            }
            else
            {
              sizeF3 = this.g2.MeasureString("?", this.stdFont1);
              int num65 = (int) Math.Round(19.0 - (double) sizeF3.Width / 2.0);
              DrawMod.DrawTextColouredMarcCounter(ref this.g2, "?", this.stdFont1, tx + num65, ty + 16 + 8, Color.FromArgb((int) byte.MaxValue, (int) Math.Round((double) red3), (int) Math.Round((double) green3), (int) Math.Round((double) blue3)));
            }
          }
          if (this.game.Data.UnitObj[nr].cycleOrder < 0L & this.game.Data.UnitObj[nr].Regime == this.game.EditObj.RealTurn)
          {
            DrawMod.DrawBlock(ref this.g2, tx + 2, ty + 8, 9, 9, 0, 0, 0, 200);
            DrawMod.DrawTextColouredMarcCenter(ref this.g2, "G", this.game.MarcFont5, tx + 7, ty + 7, Color.White);
          }
        }
        if (OverruleHis == -1 && this.game.Data.Turn == this.game.Data.UnitObj[nr].Regime)
        {
          num15 = 0;
          if (this.game.EventRelatedObj.Helper_AirEnabled() & !this.game.EditObj.AIMoving && this.game.EditObj.Zoom >= 0 & OverruleHis == -1)
          {
            int historical = this.game.Data.UnitObj[nr].Historical;
            this.slotAir = this.strId534slot;
            int num66 = this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(55);
            int num67 = this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(56);
            int num68 = this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(57);
            int numy = -1;
            int num69 = -1;
            if (this.slotAir > -1 & num66 > 0)
            {
              int length = this.game.Data.StringListObj[this.slotAir].Length;
              int airRowNr;
              for (int index12 = 0; index12 <= length; ++index12)
              {
                if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[index12, 0])) == this.game.Data.RegimeObj[this.game.Data.Turn].id && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[index12, 1])) == this.game.Data.UnitObj[nr].X && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[index12, 2])) == this.game.Data.UnitObj[nr].Y && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[index12, 3])) == num67 && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[index12, 4])) == num68 && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[index12, 9])) >= 0)
                {
                  numy = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[index12, 8]));
                  num69 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[index12, 9]));
                  airRowNr = index12;
                  break;
                }
              }
              if (numy > -1)
              {
                string letter = this.game.HandyFunctionsObj.CovertNumberToLetter(numy);
                Color color = this.game.HandyFunctionsObj.Air_GetColor(airRowNr);
                int tcol = 0;
                int num70 = 6;
                DrawMod.DrawBlock(ref this.g2, tx + num70, ty + 17, 11, 10, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
                DrawMod.DrawTextCenterSmallLabel(ref this.g2, letter, this.game.MarcFont13, tx + num70 + 5, ty + 22, tcol);
              }
            }
          }
          float a11;
          float a12;
          float a13;
          if (this.game.Data.UnitObj[nr].SupplyInReq > 0)
          {
            int num71 = (int) Math.Round(Conversion.Int((double) (this.game.Data.UnitObj[nr].SupplyIn * 100) / (double) this.game.Data.UnitObj[nr].SupplyInReq));
            if (num71 >= 100)
            {
              a11 = 0.0f;
              a12 = (float) byte.MaxValue;
              a13 = 0.0f;
            }
            else if (num71 >= 66)
            {
              a11 = (float) byte.MaxValue;
              a12 = (float) byte.MaxValue;
              a13 = 0.0f;
            }
            else if (num71 >= 44)
            {
              a11 = 0.0f;
              a12 = 170f;
              a13 = (float) byte.MaxValue;
            }
            else if (num71 >= 22)
            {
              a11 = (float) byte.MaxValue;
              a12 = 0.0f;
              a13 = 0.0f;
            }
            else
            {
              a11 = 0.0f;
              a12 = 0.0f;
              a13 = 0.0f;
            }
          }
          else if (this.game.Data.UnitObj[nr].HQ == -1 | this.game.Data.UnitObj[nr].SupplyInReq == 0)
          {
            a11 = 0.0f;
            a12 = (float) byte.MaxValue;
            a13 = 0.0f;
          }
          else
          {
            a11 = 0.0f;
            a12 = 0.0f;
            a13 = 0.0f;
          }
          DrawMod.DrawBlock(ref this.g2, tx + 3, ty + 2, 4, 4, (int) Math.Round((double) a11), (int) Math.Round((double) a12), (int) Math.Round((double) a13), (int) byte.MaxValue);
          DrawMod.DrawRectangle(ref this.g2, tx + 3, ty + 3, 4, 4, 0, 0, 0, 180);
        }
        if (OverruleHis == -1 & (double) this.game.Data.RuleVar[334] == 0.0 & !mostlyHidden && this.game.Data.Turn == this.game.Data.UnitObj[nr].Regime)
        {
          if (OverruleHis == -1 && this.game.Data.Turn == this.game.Data.UnitObj[nr].Regime)
          {
            if (this.game.EditObj.ShowSameHistorical && this.game.EditObj.UnitSelected > -1 && this.game.Data.UnitObj[nr].HQ > -1 & this.game.Data.UnitObj[nr].HQ == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ & !this.game.Data.UnitObj[nr].IsHQ | nr == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ && this.game.Data.UnitObj[index1].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index1].Historical].Type < 8)
            {
              float red = (float) this.game.Data.UnitObj[index1].Red;
              float green = (float) this.game.Data.UnitObj[index1].Green;
              float blue = (float) this.game.Data.UnitObj[index1].Blue;
              DrawMod.DrawRectangle(ref this.g2, tx + 1, ty + 1, 35, 35, (int) Math.Round((double) red), (int) Math.Round((double) green), (int) Math.Round((double) blue), 112, 3);
            }
            if (this.game.EditObj.ShowUnderHQ && this.game.EditObj.UnitSelected > -1 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ && this.game.Data.UnitObj[nr].HQ == this.game.EditObj.UnitSelected && this.game.Data.UnitObj[index1].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index1].Historical].Type < 8)
            {
              float red = (float) this.game.Data.UnitObj[this.game.Data.UnitObj[nr].HQ].Red;
              float green = (float) this.game.Data.UnitObj[this.game.Data.UnitObj[nr].HQ].Green;
              float blue = (float) this.game.Data.UnitObj[this.game.Data.UnitObj[nr].HQ].Blue;
              DrawMod.DrawRectangle(ref this.g2, tx + 1, ty + 1, 35, 35, (int) Math.Round((double) red), (int) Math.Round((double) green), (int) Math.Round((double) blue), 112, 3);
            }
          }
        }
        if (this.game.EditObj.UnitSelected == nr & this.game.EditObj.UnitSelected > -1)
        {
          DrawMod.DrawRectangle(ref this.g2, tx + 0, ty + 0, 38, 38, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          DrawMod.DrawRectangle(ref this.g2, tx - 1, ty - 1, 40, 40, 0, 0, 0, (int) byte.MaxValue);
          DrawMod.DrawRectangle(ref this.g2, tx + 2, ty + 2, 34, 34, 128, 128, 128, (int) byte.MaxValue);
        }
        if (OverruleHis == -1 && (double) this.game.Data.RuleVar[983] > 0.0 && this.game.Data.Turn == this.game.Data.UnitObj[nr].Regime && !this.game.HandyFunctionsObj.CheckIfInCorrectFrontzone(nr, this.game.Data.UnitObj[nr].RealX(ref this.game), this.game.Data.UnitObj[nr].RealY(ref this.game)))
          DrawMod.DrawRectangle(ref this.g2, tx, ty - 1, 38, 39, (int) byte.MaxValue, 0, 0, 172, 2);
        this.game.EditObj.HideUnit = hideUnit;
        if (Information.IsNothing((object) toG))
          return this.tmpbmp2;
      }
label_382:
      Bitmap bitmap1;
      return bitmap1;
    }

    public Bitmap DrawHistoryForce(int regnr, int force, int sftype)
    {
      SizeF sizeF = new SizeF();
      int[] numArray = new int[1];
      numArray = this.game.Data.SFTypeCounter >= 101 ? new int[this.game.Data.SFTypeCounter + 1] : new int[101];
      this.g2 = Graphics.FromImage((Image) this.tmpbmp2);
      if (regnr <= -1)
      {
        ref Graphics local1 = ref this.g2;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.DEFAULTCOUNTER);
        ref Bitmap local2 = ref bitmap;
        DrawMod.DrawSimple(ref local1, ref local2, 0, 0);
      }
      else
      {
        if (Information.IsNothing((object) this.game.Data.RegimeObj[regnr].TempCounter))
          this.game.Data.RegimeObj[regnr].DoTempCounter();
        bool flag;
        if (!flag)
          DrawMod.DrawSimple(ref this.g2, ref this.game.Data.RegimeObj[regnr].TempCounter, 0, 0);
        else
          DrawMod.DrawSimple(ref this.g2, ref this.game.Data.RegimeObj[regnr].TempCounterHigh, 0, 0);
      }
      if (force != -9999)
      {
        if (sftype > -1)
        {
          int symbolSpriteId = this.game.Data.SFTypeObj[sftype].SymbolSpriteID;
          if (regnr > -1 && this.game.Data.RegimeObj[regnr].ExtraGraphicUse > -1)
          {
            int extraCounter = this.game.Data.SFTypeObj[sftype].ExtraCounter;
            for (int index = 0; index <= extraCounter; ++index)
            {
              if (this.game.Data.SFTypeObj[sftype].ExtraCode[index] == this.game.Data.RegimeObj[regnr].ExtraGraphicUse)
                symbolSpriteId = this.game.Data.SFTypeObj[sftype].ExtraSymbolSpriteID[index];
            }
          }
          if (regnr > -1)
          {
            if (this.game.Data.RegimeObj[regnr].Mirror)
            {
              Matrix matrix = new Matrix();
              matrix.Scale(-1f, 1f);
              matrix.Translate(-38f, 0.0f);
              this.g2.Transform = matrix;
            }
            float num1;
            float num2;
            float num3;
            if (this.game.Data.SFTypeObj[sftype].SymbolOverrule)
            {
              num1 = 1f;
              num2 = 1f;
              num3 = 1f;
            }
            else
            {
              num1 = 1f;
              num2 = 1f;
              num3 = 1f;
            }
            ref Graphics local3 = ref this.g2;
            Bitmap bitmap = BitmapStore.GetBitmap(symbolSpriteId);
            ref Bitmap local4 = ref bitmap;
            double r = (double) num1 - 1.0;
            double g = (double) num2 - 1.0;
            double b = (double) num3 - 1.0;
            DrawMod.Draw(ref local3, ref local4, -3, 0, (float) r, (float) g, (float) b, 1f);
            this.g2.ResetTransform();
          }
          else
          {
            ref Graphics local5 = ref this.g2;
            Bitmap bitmap = BitmapStore.GetBitmap(symbolSpriteId);
            ref Bitmap local6 = ref bitmap;
            DrawMod.DrawSimple(ref local5, ref local6, -3, 0);
          }
        }
        if (force > -1 & regnr > -1)
        {
          float red2 = (float) this.game.Data.RegimeObj[regnr].Red2;
          float green2 = (float) this.game.Data.RegimeObj[regnr].Green2;
          float blue2 = (float) this.game.Data.RegimeObj[regnr].Blue2;
          int red = 0;
          int blue = 0;
          int green = 0;
          if ((double) red2 < 128.0 & (double) green2 < 128.0 & (double) blue2 < 128.0)
          {
            red = (int) byte.MaxValue;
            blue = (int) byte.MaxValue;
            green = (int) byte.MaxValue;
          }
          if (force > 9999)
            force = 9999;
          int Number = force;
          int x = (int) Math.Round(18.0 - (double) this.g2.MeasureString(Strings.Trim(Conversion.Str((object) Number)), new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel)).Width / 2.0);
          DrawMod.DrawTextColoured(ref this.g2, Strings.Trim(Conversion.Str((object) Number)), new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), x - 1, 23, Color.FromArgb((int) byte.MaxValue, red, green, blue));
          DrawMod.DrawTextColoured(ref this.g2, Strings.Trim(Conversion.Str((object) Number)), new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), x + 1, 23, Color.FromArgb((int) byte.MaxValue, red, green, blue));
          DrawMod.DrawTextColoured(ref this.g2, Strings.Trim(Conversion.Str((object) Number)), new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), x, 22, Color.FromArgb((int) byte.MaxValue, red, green, blue));
          DrawMod.DrawTextColoured(ref this.g2, Strings.Trim(Conversion.Str((object) Number)), new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), x, 24, Color.FromArgb((int) byte.MaxValue, red, green, blue));
          DrawMod.DrawTextColoured(ref this.g2, Strings.Trim(Conversion.Str((object) Number)), new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), x, 23, Color.FromArgb((int) byte.MaxValue, (int) Math.Round((double) red2), (int) Math.Round((double) green2), (int) Math.Round((double) blue2)));
        }
      }
      return this.tmpbmp2;
    }

    public Bitmap DrawBigCounter(int regnr)
    {
      SizeF sizeF = new SizeF();
      int[] numArray = new int[1];
      Bitmap bitmap1 = new Bitmap(80, 80, PixelFormat.Format32bppPArgb);
      this.g2 = Graphics.FromImage((Image) bitmap1);
      this.g2.Clear(Color.Transparent);
      if (regnr == -1)
      {
        ref Graphics local1 = ref this.g2;
        Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.DEFAULTCOUNTERBIG);
        ref Bitmap local2 = ref bitmap2;
        DrawMod.DrawSimple(ref local1, ref local2, 0, 0);
      }
      else
      {
        if (Information.IsNothing((object) this.game.Data.RegimeObj[regnr].TempCounterBig))
          this.game.Data.RegimeObj[regnr].DoTempCounterBig();
        DrawMod.DrawSimple(ref this.g2, ref this.game.Data.RegimeObj[regnr].TempCounterBig, 0, 0);
      }
      this.g2.Dispose();
      return bitmap1;
    }

    public void ThreadBlock()
    {
      if (!DrawMod.TGame.se1ThreadBlock)
        return;
      while (DrawMod.TGame.se1ThreadBlock)
        Thread.Sleep(1);
      DrawMod.TGame.se1ThreadBlock = true;
    }

    public void ThreadRelease() => DrawMod.TGame.se1ThreadBlock = false;

    public Bitmap DrawHex(
      int cx,
      int cy,
      int cmap,
      bool InfoMode = false,
      bool NoShader = false,
      bool ispredrawing = false,
      Graphics tempg = null,
      int tx = 0,
      int ty = 0,
      int counteralpha = 255,
      int Zoom = 0,
      bool UseRegimeColoring = false,
      bool neverusehistory = false,
      bool combatSetup = false,
      ref Bitmap gBitmap = null,
      ref bool tFromMapPopup = false)
    {
      this.ThreadBlock();
      int[] numArray1 = new int[7];
      int[] numArray2 = new int[7];
      Coordinate[] coordinateArray = new Coordinate[7];
      int[] numArray3 = new int[7];
      int[] numArray4 = new int[7];
      int[] numArray5 = new int[7];
      int[] numArray6 = new int[7];
      int[] numArray7 = new int[100];
      int[] numArray8 = new int[100];
      int[] numArray9 = new int[100];
      bool[] flagArray1 = new bool[100];
      bool[] flagArray2 = new bool[100];
      int[] numArray10 = new int[100];
      int[] numArray11 = new int[100];
      int[,] numArray12 = new int[100, 6];
      SizeF sizeF1 = new SizeF();
      double a1 = (double) (cy * this.game.Data.MapObj[cmap].MapWidth + cx) * 100.423 + (double) cx;
      double a2 = (double) ((cy + 1) * this.game.Data.MapObj[cmap].MapWidth + cx) * 100.423 * ((double) cx / (double) Math.Max(1, cy + 1));
      int[] numArray13 = new int[7];
      int[] numArray14 = new int[7];
      int[] numArray15 = new int[7];
      int[] numArray16 = new int[7];
      switch (Zoom)
      {
        case -1:
          numArray13[0] = 8;
          numArray14[0] = 4;
          numArray15[0] = 16;
          numArray16[0] = 16;
          numArray13[1] = 4;
          numArray14[1] = 0;
          numArray15[1] = 20;
          numArray16[1] = 4;
          numArray13[2] = 24;
          numArray14[2] = 0;
          numArray15[2] = 8;
          numArray16[2] = 12;
          numArray13[3] = 24;
          numArray14[3] = 12;
          numArray15[3] = 8;
          numArray16[3] = 12;
          numArray13[4] = 4;
          numArray14[4] = 22;
          numArray15[4] = 20;
          numArray16[4] = 2;
          numArray13[5] = 0;
          numArray14[5] = 12;
          numArray15[5] = 8;
          numArray16[5] = 12;
          numArray13[6] = 0;
          numArray14[6] = 0;
          numArray15[6] = 8;
          numArray16[6] = 12;
          break;
        case 0:
          numArray13[0] = 16;
          numArray14[0] = 8;
          numArray15[0] = 32;
          numArray16[0] = 32;
          numArray13[1] = 8;
          numArray14[1] = 0;
          numArray15[1] = 40;
          numArray16[1] = 4;
          numArray13[2] = 48;
          numArray14[2] = 0;
          numArray15[2] = 16;
          numArray16[2] = 24;
          numArray13[3] = 48;
          numArray14[3] = 24;
          numArray15[3] = 16;
          numArray16[3] = 24;
          numArray13[4] = 8;
          numArray14[4] = 44;
          numArray15[4] = 40;
          numArray16[4] = 4;
          numArray13[5] = 0;
          numArray14[5] = 24;
          numArray15[5] = 16;
          numArray16[5] = 24;
          numArray13[6] = 0;
          numArray14[6] = 0;
          numArray15[6] = 16;
          numArray16[6] = 24;
          break;
        case 1:
          numArray13[0] = 32;
          numArray14[0] = 16;
          numArray15[0] = 64;
          numArray16[0] = 64;
          numArray13[1] = 16;
          numArray14[1] = 0;
          numArray15[1] = 96;
          numArray16[1] = 8;
          numArray13[2] = 96;
          numArray14[2] = 0;
          numArray15[2] = 32;
          numArray16[2] = 48;
          numArray13[3] = 96;
          numArray14[3] = 48;
          numArray15[3] = 32;
          numArray16[3] = 48;
          numArray13[4] = 16;
          numArray14[4] = 88;
          numArray15[4] = 96;
          numArray16[4] = 8;
          numArray13[5] = 0;
          numArray14[5] = 48;
          numArray15[5] = 32;
          numArray16[5] = 48;
          numArray13[6] = 0;
          numArray14[6] = 0;
          numArray15[6] = 32;
          numArray16[6] = 48;
          break;
      }
      if (this.strId123slot < 1 | this.strId534slot < 1 | this.strId143slot < 1 | this.strId275slot < 1 | this.strId288slot < 1)
      {
        this.strId123slot = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0));
        this.strId534slot = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 534, 0, 0));
        this.strId143slot = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 143, 0, 0));
        this.strId275slot = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 275, 0, 0));
        this.strId288slot = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 288, 0, 0));
      }
      int index1;
      int index2;
      if (!this.game.EditObj.se1_map_data3cache_set)
      {
        try
        {
          this.game.EditObj.se1_map_data3cache_set = true;
          DataClass data1 = this.game.Data;
          string str1 = "HeightMap";
          ref string local1 = ref str1;
          this.cache_t6 = data1.FindLibVar(ref local1, "SE_Random");
          DataClass data2 = this.game.Data;
          string str2 = "artifactDiscovered";
          ref string local2 = ref str2;
          this.cache_tad = data2.FindLibVar(ref local2, "SE_Data");
          DataClass data3 = this.game.Data;
          string str3 = "artifactType";
          ref string local3 = ref str3;
          this.cache_tat = data3.FindLibVar(ref local3, "SE_Data");
          DataClass data4 = this.game.Data;
          str3 = "rad";
          ref string local4 = ref str3;
          this.cache_rad = data4.FindLibVar(ref local4, "SE_Data");
          int num1 = Math.Max(0, this.game.Data.StringListObj[this.strId143slot].GetHighestValue(0)) + 20;
          int regimeCounter = this.game.Data.RegimeCounter;
          for (index1 = 0; index1 <= regimeCounter; ++index1)
          {
            if (this.game.Data.RegimeObj[index1].id > num1)
              num1 = this.game.Data.RegimeObj[index1].id;
          }
          int num2 = Math.Max(0, this.game.Data.StringListObj[this.strId123slot].GetHighestValue(0)) + 20;
          this.cacheDipClear = new int[num1 + 1, num1 + 1];
          this.cacheZoneRecon = new int[num1 + 1, num2 + 1];
          int length1 = this.game.Data.StringListObj[this.strId275slot].Length;
          for (index1 = 0; index1 <= length1; ++index1)
          {
            if (Operators.CompareString(this.game.Data.StringListObj[this.strId275slot].Data[index1, 2].ToLower(), "dipclear", false) == 0)
            {
              index2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.strId275slot].Data[index1, 0]));
              int index3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.strId275slot].Data[index1, 1]));
              int num3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.strId275slot].Data[index1, 3]));
              if (index2 <= num1 & index3 <= num1)
                this.cacheDipClear[index2, index3] = num3;
            }
          }
          int length2 = this.game.Data.StringListObj[this.strId288slot].Length;
          for (index1 = 0; index1 <= length2; ++index1)
          {
            if (Operators.CompareString(this.game.Data.StringListObj[this.strId288slot].Data[index1, 2].ToLower(), "recon", false) == 0)
            {
              index2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.strId288slot].Data[index1, 0]));
              int index4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.strId288slot].Data[index1, 1]));
              int num4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.strId288slot].Data[index1, 3]));
              if (index2 <= num1 & index4 <= num2)
                this.cacheZoneRecon[index2, index4] = num4;
            }
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.game.EditObj.se1_map_data3cache_set = false;
          ProjectData.ClearProjectError();
        }
      }
      int num5 = this.cache_t6;
      if (!this.game.EditObj.AIMoving && this.game.Data.Turn > -1 && !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
      {
        this.game.EditObj.RealRound = this.game.Data.Round;
        this.game.EditObj.RealTurn = this.game.Data.Turn;
      }
      if (Information.IsNothing((object) this.tmpbmp3))
      {
        this.tmpbmp3 = new Bitmap(64, 48, PixelFormat.Format32bppPArgb);
        this.tmpbmp3.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      }
      int num6;
      int num7;
      switch (Zoom)
      {
        case -1:
          num6 = 32;
          num7 = 24;
          break;
        case 0:
          num6 = 64;
          num7 = 48;
          break;
        default:
          num6 = 128;
          num7 = 96;
          break;
      }
      Graphics toG;
      if (Information.IsNothing((object) tempg) | Information.IsNothing((object) this.g3))
      {
        Graphics g3 = this.g3;
        toG = Graphics.FromImage((Image) this.tmpbmp3);
        toG.Clear(Color.FromArgb(0, 0, 0, 0));
      }
      else
        toG = tempg;
      if (this.game.Data.Product >= 7)
      {
        toG.InterpolationMode = InterpolationMode.NearestNeighbor;
        toG.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
        toG.PixelOffsetMode = PixelOffsetMode.None;
      }
      if (this.game.Data.Product >= 7)
        toG.CompositingQuality = CompositingQuality.HighSpeed;
      int num8 = 0;
      int index5 = this.game.EditObj.RealTurn;
      if (this.game.Data.Round == 0)
        index5 = -1;
      bool flag1;
      if (this.game.EditObj.OrderType == 26)
      {
        num8 = 1;
        flag1 = true;
      }
      if (this.game.EditObj.AIMoving)
      {
        flag1 = true;
        num8 = 1;
        if (this.game.EditObj.HumanPlayer > -1 & this.game.EditObj.AIMoving)
          index5 = this.game.EditObj.HumanPlayer;
      }
      if (this.game.EditObj.RealRound == 0 & !this.game.EditObj.inRandomScreen)
        num8 = 1;
      else if (index5 > -1 && this.game.Data.MapObj[cmap].HexObj[cx, cy].get_SeeNow(index5) == 1 | this.game.Data.MapObj[cmap].HexObj[cx, cy].get_LastLT(index5) > -1)
        num8 = 1;
      if (this.game.EditObj.OrderType == 38)
        num8 = 1;
      if (index5 != 2)
        index5 = index5;
      int num9 = 0;
      if (this.game.EditObj.RealRound > 0 | this.game.EditObj.inRandomScreen)
      {
        if (index5 > -1)
        {
          if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_SeeNow(index5) > 0)
            num9 = 1;
        }
        else
          num9 = 0;
      }
      if (!this.game.Data.ShrowdOn | num9 == 1)
        num8 = 1;
      bool flag2 = false;
      int num10 = 0;
      bool flag3;
      if (this.game.EditObj.OrderType == 1)
      {
        num10 = 1;
        flag3 = true;
      }
      if (this.game.EditObj.OrderType == 48)
        num10 = 1;
      if (this.game.EditObj.OrderType == 18)
        num10 = 1;
      if (this.game.EditObj.OrderType == 36)
        num10 = 1;
      if (this.game.EditObj.OrderType == 11)
        num10 = 1;
      if (this.game.EditObj.OrderType == 14)
        num10 = 1;
      if (this.game.EditObj.OrderType == 33)
        num10 = 1;
      if (this.game.EditObj.OrderType == 55)
        num10 = 1;
      if (this.game.EditObj.RealRound > 0 & this.game.EditObj.RealTurn > -1 & !this.game.EditObj.AIMoving && !this.game.Data.RegimeObj[this.game.EditObj.RealTurn].AI && this.game.EditObj.OrderType == 0 & this.game.EditObj.ShowAirRange & this.game.EditObj.UnitSelected > -1)
      {
        if (this.game.HandyFunctionsObj.HasUnitAirSF(this.game.EditObj.UnitSelected))
          num10 = 1;
        else if (this.game.HandyFunctionsObj.HasUnitArtSF(this.game.EditObj.UnitSelected, this.game.Data))
          num10 = 1;
      }
      if (this.game.Data.Product >= 7 && Information.IsNothing((object) this.game.EditObj.TempValueSpecial))
        this.game.HandyFunctionsObj.RedimTempValueSpecial(0);
      bool flag4;
      if (num10 == 1 & !this.game.EditObj.AIMoving)
      {
        if ((this.game.EditObj.OrderType == 1 | this.game.EditObj.OrderType == 48) & this.game.EditObj.TempValue[cmap].Value[cx, cy] < 9999)
        {
          flag2 = true;
          if (this.game.EditObj.OrderUnit > -1 & (double) this.game.Data.RuleVar[983] > 0.0)
            flag4 = !this.game.HandyFunctionsObj.CheckIfInCorrectFrontzone(this.game.EditObj.OrderUnit, cx, cy);
          if (this.game.Data.Product >= 7)
          {
            if (Information.IsNothing((object) this.game.EditObj.TempValueSpecial))
              this.game.HandyFunctionsObj.RedimTempValueSpecial(0);
            if (this.game.EditObj.TempValueSpecial[cmap].Value[cx, cy] == 2)
              flag4 = true;
          }
        }
        if (this.game.EditObj.OrderType == 18)
        {
          if (this.game.EditObj.OrderUnit > -1)
          {
            int unitWeight = this.game.HandyFunctionsObj.GetUnitWeight(this.game.EditObj.OrderUnit);
            if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical].Type == 8)
            {
              int counter = this.game.Data.UnitObj[this.game.EditObj.OrderUnit].items.list.Counter;
              for (index1 = 0; index1 <= counter; ++index1)
              {
                index2 = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[404]));
                int integer = Conversions.ToInteger(this.game.Data.StringListObj[index2].GetData(0, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].items.list.Id[index1], 3));
                unitWeight += integer * this.game.Data.UnitObj[this.game.EditObj.OrderUnit].items.list.Weight[index1];
              }
            }
            if (this.game.EditObj.TempValue[cmap].Value[cx, cy] >= unitWeight)
              flag2 = true;
          }
          else if (this.game.EditObj.TempValue[cmap].Value[cx, cy] <= 0)
            ;
        }
        if (this.game.EditObj.OrderType == 36 && this.game.EditObj.TempValue[cmap].Value[cx, cy] < 9999)
          flag2 = true;
        if (this.game.EditObj.OrderType == 11 && this.game.EditObj.OrderUnit > -1 && this.game.EditObj.TempValue[cmap].Value[cx, cy] > 0 & this.game.EditObj.TempValue[cmap].Value[cx, cy] < 9999)
          flag2 = true;
        if (this.game.EditObj.OrderType == 14 && this.game.EditObj.OrderUnit > -1 && this.game.EditObj.TempValue[cmap].Value[cx, cy] > 0 & this.game.EditObj.TempValue[cmap].Value[cx, cy] < 9999)
          flag2 = true;
        if (this.game.EditObj.OrderType == 33 && this.game.EditObj.OrderUnit > -1 && this.game.EditObj.TempValue[cmap].Value[cx, cy] > 0 & this.game.EditObj.TempValue[cmap].Value[cx, cy] < 9999)
          flag2 = true;
        if (this.game.EditObj.OrderType == 55 && this.game.EditObj.OrderUnit > -1 && this.game.EditObj.TempValue[cmap].Value[cx, cy] > 0 & this.game.EditObj.TempValue[cmap].Value[cx, cy] < 9999)
          flag2 = true;
      }
      if (this.game.EditObj.AreaSlot > -1 && this.game.Data.MapObj[cmap].HexObj[cx, cy].AreaCode[this.game.EditObj.AreaSlot] == this.game.EditObj.AreaValue)
        flag2 = true;
      if (neverusehistory)
        flag1 = false;
      if (flag1)
        flag2 = false;
      Bitmap bitmap1;
      int index6;
      int index7;
      int nr1;
      float a3;
      float a4;
      float a5;
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (num8 == 1 && ((!flag1 ? 1 : 0) | 1) == 0 && this.game.EditObj.HisOwner[cmap].Value[cx, cy] < -1 && this.game.EditObj.HisOwner[cmap].Value[cx, cy] == -2)
      {
        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_LastLT(index5) == -1)
        {
          ref Graphics local5 = ref toG;
          bitmap1 = BitmapStore.GetBitmap(this.game.NOHEX, Zoom);
          ref Bitmap local6 = ref bitmap1;
          int x = tx;
          int y = ty;
          DrawMod.DrawSimple(ref local5, ref local6, x, y);
          num8 = 0;
        }
        else
        {
          index6 = this.game.Data.MapObj[cmap].HexObj[cx, cy].get_LastLT(index5);
          index7 = this.game.Data.MapObj[cmap].HexObj[cx, cy].get_LastSpr(index5);
          if (!this.game.Data.LandscapeTypeObj[index6].Transparent)
          {
            if (index6 > -1)
              nr1 = this.game.Data.LandscapeTypeObj[index6].PreHexPicID;
            int num11 = (int) Math.Round((double) BitmapStore.GetWidth(nr1, Zoom) / (double) num6);
            int num12 = 0;
            if (num11 > 1)
              num12 = new Random((int) Math.Round(a1)).Next(0, num11 - 1);
            if ((0 & (UseRegimeColoring ? 1 : 0) & (this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime > -1 ? 1 : 0) & (this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime != index5 ? 1 : 0)) != 0)
            {
              int regime = this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime;
              a3 = (float) (0.3 + (double) this.game.Data.RegimeObj[regime].Red / 1024.0);
              a4 = (float) (0.3 + (double) this.game.Data.RegimeObj[regime].Green / 1024.0);
              a5 = (float) (0.3 + (double) this.game.Data.RegimeObj[regime].Blue / 1024.0);
              float num13 = 1f;
              ref Graphics local7 = ref toG;
              Bitmap bitmap2 = BitmapStore.GetBitmap(nr1, Zoom);
              ref Bitmap local8 = ref bitmap2;
              rectangle1 = new Rectangle(num12 * num6, 0, num6, num7);
              Rectangle srcrect = rectangle1;
              rectangle2 = new Rectangle(tx, ty, num6, num7);
              Rectangle destrect = rectangle2;
              double r = (double) a3;
              double g = (double) a4;
              double b = (double) a5;
              double a6 = (double) num13;
              DrawMod.DrawSimplePart2ColouredOld(ref local7, ref local8, srcrect, destrect, (float) r, (float) g, (float) b, (float) a6);
            }
            else
            {
              ref Graphics local9 = ref toG;
              Bitmap bitmap3 = BitmapStore.GetBitmap(nr1, Zoom);
              ref Bitmap local10 = ref bitmap3;
              rectangle2 = new Rectangle(num12 * num6, 0, num6, num7);
              Rectangle srcrect = rectangle2;
              rectangle1 = new Rectangle(tx, ty, num6, num7);
              Rectangle destrect = rectangle1;
              DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect, destrect);
            }
            index2 = (int) Math.Round((double) BitmapStore.GetWidth(this.game.Data.LandscapeTypeObj[index6].BasicSpriteID[index7], Zoom) / (double) num6);
            int num14 = 0;
            if (index2 > 1)
              num14 = new Random((int) Math.Round(a1)).Next(0, index2 - 1);
            ref Graphics local11 = ref toG;
            bitmap1 = BitmapStore.GetBitmap(this.game.Data.LandscapeTypeObj[index6].BasicSpriteID[index7], Zoom);
            ref Bitmap local12 = ref bitmap1;
            rectangle2 = new Rectangle(num14 * num6, 0, num6, num7);
            Rectangle srcrect1 = rectangle2;
            rectangle1 = new Rectangle(tx, ty, num6, num7);
            Rectangle destrect1 = rectangle1;
            DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect1, destrect1);
            if (this.game.Data.LandscapeTypeObj[index6].BasicSpriteID2[index7] > 0 & this.game.Data.LandscapeTypeObj[index6].PlotLast[index7])
            {
              ref Graphics local13 = ref toG;
              bitmap1 = BitmapStore.GetBitmap(this.game.Data.LandscapeTypeObj[index6].BasicSpriteID2[index7], Zoom);
              ref Bitmap local14 = ref bitmap1;
              rectangle2 = new Rectangle(num14 * num6, 0, num6, num7);
              Rectangle srcrect2 = rectangle2;
              rectangle1 = new Rectangle(tx, ty, num6, num7);
              Rectangle destrect2 = rectangle1;
              DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect2, destrect2);
            }
            ref Graphics local15 = ref toG;
            bitmap1 = BitmapStore.GetBitmap(this.game.SHADEDHEX, Zoom);
            ref Bitmap local16 = ref bitmap1;
            int x = tx;
            int y = ty;
            DrawMod.DrawSimple(ref local15, ref local16, x, y);
          }
          num8 = 0;
        }
      }
      int index8;
      Coordinate coordinate1;
      int num15;
      Coordinate coordinate2;
      Bitmap bitmap4;
      int num16;
      int index9;
      int index10;
      if (num8 == 1)
      {
        int lt1 = this.game.Data.MapObj[cmap].HexObj[cx, cy].LandscapeType;
        if (index5 > -1 && this.game.Data.MapObj[cmap].HexObj[cx, cy].get_SeeNow(index5) == 0)
          lt1 = this.game.Data.MapObj[cmap].HexObj[cx, cy].get_LastLT(index5);
        if (lt1 > -1)
        {
          nr1 = this.game.Data.LandscapeTypeObj[lt1].PreHexPicID;
          if ((double) this.game.Data.RuleVar[998] == 1.0 & this.game.Data.LandscapeTypeObj[lt1].UsePreHexTexture)
          {
            int preHexTextureId = this.game.Data.LandscapeTypeObj[lt1].PreHexTextureID;
            if (Zoom == 0)
            {
              BitmapData bitmapdata = this.tempHexMed.LockBits(new Rectangle(0, 0, 64, 48), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
              IntPtr scan0 = bitmapdata.Scan0;
              int num17 = Math.Abs(bitmapdata.Stride) * this.tempHexMed.Height;
              byte[] numArray17 = new byte[num17 - 1 + 1];
              Marshal.Copy(scan0, numArray17, 0, num17);
              int num18 = (cx + BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal) % BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal * 8 + (cy + BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal) % BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal;
              Buffer.BlockCopy((Array) BitmapStore.simpleByteCacheObj[preHexTextureId].cacheMed, num18 * num17, (Array) numArray17, 0, num17);
              int index11 = 0;
              int num19 = numArray17.Length - 1;
              for (int index12 = 3; index12 <= num19; index12 += 4)
              {
                numArray17[index12] = BitmapStore.simpleByteCacheObj[this.game.WHITEHEX].singleCacheMed[index11];
                ++index11;
              }
              Marshal.Copy(numArray17, 0, scan0, num17);
              this.tempHexMed.UnlockBits(bitmapdata);
              DrawMod.DrawSimple(ref toG, ref this.tempHexMed, tx, ty);
            }
            if (Zoom == 1)
            {
              BitmapData bitmapdata = this.tempHexBig.LockBits(new Rectangle(0, 0, 128, 96), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
              IntPtr scan0 = bitmapdata.Scan0;
              int num20 = Math.Abs(bitmapdata.Stride) * this.tempHexBig.Height;
              byte[] numArray18 = new byte[num20 - 1 + 1];
              Marshal.Copy(scan0, numArray18, 0, num20);
              int num21 = (cx + BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal) % BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal * 8 + (cy + BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal) % BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal;
              Buffer.BlockCopy((Array) BitmapStore.simpleByteCacheObj[preHexTextureId].cacheBig, num21 * num20, (Array) numArray18, 0, num20);
              int index13 = 0;
              int num22 = numArray18.Length - 1;
              for (int index14 = 3; index14 <= num22; index14 += 4)
              {
                numArray18[index14] = BitmapStore.simpleByteCacheObj[this.game.WHITEHEX].singleCacheBig[index13];
                ++index13;
              }
              Marshal.Copy(numArray18, 0, scan0, num20);
              this.tempHexBig.UnlockBits(bitmapdata);
              DrawMod.DrawSimple(ref toG, ref this.tempHexBig, tx, ty);
            }
            if (Zoom == -1)
            {
              BitmapData bitmapdata = this.tempHexSmall.LockBits(new Rectangle(0, 0, 32, 24), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
              IntPtr scan0 = bitmapdata.Scan0;
              int num23 = Math.Abs(bitmapdata.Stride) * this.tempHexSmall.Height;
              byte[] numArray19 = new byte[num23 - 1 + 1];
              Marshal.Copy(scan0, numArray19, 0, num23);
              int num24 = (cx + BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal) % BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal * 8 + (cy + BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal) % BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal;
              Buffer.BlockCopy((Array) BitmapStore.simpleByteCacheObj[preHexTextureId].cacheSmall, num24 * num23, (Array) numArray19, 0, num23);
              int index15 = 0;
              int num25 = numArray19.Length - 1;
              for (int index16 = 3; index16 <= num25; index16 += 4)
              {
                numArray19[index16] = BitmapStore.simpleByteCacheObj[this.game.WHITEHEX].singleCacheSmall[index15];
                ++index15;
              }
              Marshal.Copy(numArray19, 0, scan0, num23);
              this.tempHexSmall.UnlockBits(bitmapdata);
              DrawMod.DrawSimple(ref toG, ref this.tempHexSmall, tx, ty);
            }
          }
          if ((double) this.game.Data.RuleVar[998] < 1.0 | this.game.Data.LandscapeTypeObj[lt1].OverridesZ < 899 & !this.game.Data.LandscapeTypeObj[lt1].UsePreHexTexture & !this.game.Data.LandscapeTypeObj[lt1].UsePreHexTextureAndRegularPreHex && !this.game.Data.LandscapeTypeObj[lt1].Transparent)
          {
            index2 = (int) Math.Round((double) BitmapStore.GetBitmap(nr1, Zoom).Width / (double) num6);
            int num26 = 0;
            if (index2 > 1)
              num26 = new Random((int) Math.Round(a1)).Next(0, index2 - 1);
            ref Graphics local17 = ref toG;
            bitmap1 = BitmapStore.GetBitmap(nr1, Zoom);
            ref Bitmap local18 = ref bitmap1;
            rectangle2 = new Rectangle(num26 * num6, 0, num6, num7);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(tx, ty, num6, num7);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect, destrect);
          }
          int[] numArray20 = new int[7];
          int[] numArray21 = new int[7];
          int tfacing1 = 1;
          int index17;
          do
          {
            coordinateArray[tfacing1] = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, tfacing1);
            numArray1[tfacing1] = -1;
            if (coordinateArray[tfacing1].onmap)
            {
              index2 = this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing1].x, coordinateArray[tfacing1].y].LandscapeType;
              if (index5 > -1)
              {
                if (this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing1].x, coordinateArray[tfacing1].y].get_SeeNow(index5) == 0)
                  index2 = this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing1].x, coordinateArray[tfacing1].y].get_LastLT(index5);
                if (index2 == -1)
                  index2 = lt1;
              }
              if (this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[tfacing1 - 1] == 5)
                index2 = lt1;
              int num27 = tfacing1 + 3;
              if (num27 > 6)
                num27 -= 6;
              if (this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing1].x, coordinateArray[tfacing1].y].RiverType[num27 - 1] == 5)
                index2 = lt1;
              int preHexBorder = this.game.Data.LandscapeTypeObj[index2].PreHexBorder;
              if (cx == 15 & cy == 6)
                index2 = index2;
              if (preHexBorder > -1 & preHexBorder != this.game.Data.LandscapeTypeObj[lt1].PreHexBorder && !this.game.Data.LandscapeTypeObj[preHexBorder].Transparent)
              {
                if (this.game.Data.LandscapeTypeObj[lt1].PreHexBorder > -1 | this.game.Data.LandscapeTypeObj[index2].PreHexBorder > -1)
                {
                  int num28 = 0;
                  int num29 = 0;
                  if (!this.game.Data.LandscapeTypeObj[index2].usePreHexBorderOwnZ | this.game.Data.LandscapeTypeObj[index2].OverridesZ > this.game.Data.LandscapeTypeObj[lt1].OverridesZ)
                    num28 = 1;
                  if (this.game.Data.LandscapeTypeObj[lt1].PreHexBorder > -1 && this.game.Data.LandscapeTypeObj[preHexBorder].OverridesZ > this.game.Data.LandscapeTypeObj[this.game.Data.LandscapeTypeObj[lt1].PreHexBorder].OverridesZ && this.game.Data.LandscapeTypeObj[index2].CheckOverride(lt1))
                    num28 = 1;
                  if (num28 == 1)
                  {
                    if (this.game.Data.LandscapeTypeObj[lt1].PreHexBorder > -1)
                    {
                      if (this.game.Data.LandscapeTypeObj[preHexBorder].OverridesZ > this.game.Data.LandscapeTypeObj[this.game.Data.LandscapeTypeObj[lt1].PreHexBorder].OverridesZ)
                        num29 = 1;
                    }
                    else
                      num29 = 1;
                    if (num29 == 1)
                    {
                      numArray1[tfacing1] = preHexBorder;
                      ++index17;
                      numArray20[index17] = tfacing1;
                      numArray21[index17] = this.game.Data.LandscapeTypeObj[preHexBorder].OverridesZ;
                    }
                  }
                }
                else if (!(this.game.Data.LandscapeTypeObj[lt1].IsSea & !this.game.Data.LandscapeTypeObj[lt1].Interior) && this.game.Data.LandscapeTypeObj[preHexBorder].OverridesZ > this.game.Data.LandscapeTypeObj[lt1].OverridesZ | !this.game.Data.LandscapeTypeObj[preHexBorder].IsSea & this.game.Data.LandscapeTypeObj[lt1].IsSea & this.game.Data.LandscapeTypeObj[lt1].Interior)
                {
                  numArray1[tfacing1] = preHexBorder;
                  ++index17;
                  numArray20[index17] = tfacing1;
                  numArray21[index17] = this.game.Data.LandscapeTypeObj[preHexBorder].OverridesZ;
                }
              }
            }
            ++tfacing1;
          }
          while (tfacing1 <= 6);
          int num30 = 1;
          while (num30 == 1)
          {
            num30 = 0;
            int num31 = index17 - 1;
            for (int index18 = 1; index18 <= num31; ++index18)
            {
              if (numArray21[index18] > numArray21[index18 + 1])
              {
                index2 = numArray21[index18];
                int num32 = numArray20[index18];
                numArray21[index18] = numArray21[index18 + 1];
                numArray20[index18] = numArray20[index18 + 1];
                numArray21[index18 + 1] = index2;
                numArray20[index18 + 1] = num32;
                num30 = 1;
              }
            }
          }
          int num33 = index17;
          int index19;
          int num34;
          for (index19 = 1; index19 <= num33; ++index19)
          {
            int index20 = numArray20[index19];
            if (numArray1[index20] > -1)
            {
              index2 = numArray1[index20];
              num34 = -1;
              int[] numArray22 = new int[7];
              int index21 = 1;
              do
              {
                if (numArray1[index21] == index2 & numArray1[index21] > -1)
                {
                  numArray22[index21] = 1;
                  numArray1[index21] = -1;
                }
                ++index21;
              }
              while (index21 <= 6);
              int nr2 = this.game.Data.LandscapeTypeObj[index2].LayerSpriteID[this.game.SPRITE64[numArray22[1], numArray22[2], numArray22[3], numArray22[4], numArray22[5], numArray22[6]]];
              int nr3;
              int index22;
              if (this.game.Data.LandscapeTypeObj[index2].UseSheet)
              {
                nr3 = this.game.Data.LandscapeTypeObj[index2].SheetSpriteID;
                index22 = this.game.SPRITE64[numArray22[1], numArray22[2], numArray22[3], numArray22[4], numArray22[5], numArray22[6]];
              }
              else
              {
                nr3 = -1;
                index22 = -1;
              }
              if (nr2 > -1)
              {
                if (nr3 == -1)
                {
                  index2 = (int) Math.Round((double) BitmapStore.GetWidth(nr2) / (double) num6);
                  int num35 = 0;
                  if (index2 > 1)
                    num35 = new Random((int) Math.Round(a1)).Next(0, index2 - 1);
                  ref Graphics local19 = ref toG;
                  bitmap1 = BitmapStore.GetBitmap(nr2, Zoom);
                  ref Bitmap local20 = ref bitmap1;
                  rectangle2 = new Rectangle(num35 * num6, 0, num6, num7);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, num6, num7);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local19, ref local20, srcrect, destrect);
                }
                else if ((double) this.game.Data.RuleVar[998] == 1.0 & this.game.Data.LandscapeTypeObj[index2].UsePreHexBorderTexture)
                {
                  int preHexTextureId = this.game.Data.LandscapeTypeObj[index2].PreHexTextureID;
                  int sheetSpriteId = this.game.Data.LandscapeTypeObj[index2].SheetSpriteID;
                  if (Zoom == 0)
                  {
                    BitmapData bitmapdata = this.tempHexMed.LockBits(new Rectangle(0, 0, 64, 48), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                    IntPtr scan0 = bitmapdata.Scan0;
                    int num36 = Math.Abs(bitmapdata.Stride) * this.tempHexMed.Height;
                    byte[] numArray23 = new byte[num36 - 1 + 1];
                    Marshal.Copy(scan0, numArray23, 0, num36);
                    int num37 = (cx + BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal) % BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal * 8 + (cy + BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal) % BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal;
                    Buffer.BlockCopy((Array) BitmapStore.simpleByteCacheObj[preHexTextureId].cacheMed, num37 * num36, (Array) numArray23, 0, num36);
                    int index23 = 0;
                    int num38 = numArray23.Length - 1;
                    for (int index24 = 3; index24 <= num38; index24 += 4)
                    {
                      numArray23[index24] = BitmapStore.simpleByteCacheObj[sheetSpriteId].singleFredCacheMed[index22, index23];
                      ++index23;
                    }
                    Marshal.Copy(numArray23, 0, scan0, num36);
                    this.tempHexMed.UnlockBits(bitmapdata);
                    DrawMod.DrawSimple(ref toG, ref this.tempHexMed, tx, ty);
                  }
                  if (Zoom == 1)
                  {
                    BitmapData bitmapdata = this.tempHexBig.LockBits(new Rectangle(0, 0, 128, 96), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                    IntPtr scan0 = bitmapdata.Scan0;
                    int num39 = Math.Abs(bitmapdata.Stride) * this.tempHexBig.Height;
                    byte[] numArray24 = new byte[num39 - 1 + 1];
                    Marshal.Copy(scan0, numArray24, 0, num39);
                    int num40 = (cx + BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal) % BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal * 8 + (cy + BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal) % BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal;
                    Buffer.BlockCopy((Array) BitmapStore.simpleByteCacheObj[preHexTextureId].cacheBig, num40 * num39, (Array) numArray24, 0, num39);
                    int index25 = 0;
                    int num41 = numArray24.Length - 1;
                    for (int index26 = 3; index26 <= num41; index26 += 4)
                    {
                      numArray24[index26] = BitmapStore.simpleByteCacheObj[sheetSpriteId].singleFredCacheBig[index22, index25];
                      ++index25;
                    }
                    Marshal.Copy(numArray24, 0, scan0, num39);
                    this.tempHexBig.UnlockBits(bitmapdata);
                    DrawMod.DrawSimple(ref toG, ref this.tempHexBig, tx, ty);
                  }
                  if (Zoom == -1)
                  {
                    BitmapData bitmapdata = this.tempHexSmall.LockBits(new Rectangle(0, 0, 32, 24), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                    IntPtr scan0 = bitmapdata.Scan0;
                    int num42 = Math.Abs(bitmapdata.Stride) * this.tempHexSmall.Height;
                    byte[] numArray25 = new byte[num42 - 1 + 1];
                    Marshal.Copy(scan0, numArray25, 0, num42);
                    int num43 = 0;
                    Buffer.BlockCopy((Array) BitmapStore.simpleByteCacheObj[preHexTextureId].cacheSmall, num43 * num42, (Array) numArray25, 0, num42);
                    int index27 = 0;
                    int num44 = numArray25.Length - 1;
                    for (int index28 = 3; index28 <= num44; index28 += 4)
                    {
                      numArray25[index28] = BitmapStore.simpleByteCacheObj[sheetSpriteId].singleFredCacheSmall[index22, index27];
                      ++index27;
                    }
                    Marshal.Copy(numArray25, 0, scan0, num42);
                    this.tempHexSmall.UnlockBits(bitmapdata);
                    DrawMod.DrawSimple(ref toG, ref this.tempHexSmall, tx, ty);
                  }
                }
                else
                {
                  ref Graphics local21 = ref toG;
                  bitmap1 = BitmapStore.GetBitmap(nr3, Zoom);
                  ref Bitmap local22 = ref bitmap1;
                  rectangle2 = new Rectangle(this.game.SHEETX[index22] * num6, this.game.SHEETY[index22] * num7, num6, num7);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, num6, num7);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local21, ref local22, srcrect, destrect);
                }
              }
            }
          }
          if ((double) this.game.Data.RuleVar[998] == 1.0 & (this.game.Data.LandscapeTypeObj[lt1].UsePreHexTextureAndRegularPreHex | this.game.Data.LandscapeTypeObj[lt1].OverridesZ >= 899) && !this.game.Data.LandscapeTypeObj[lt1].Transparent)
          {
            index2 = (int) Math.Round((double) BitmapStore.GetBitmap(nr1, Zoom).Width / (double) num6);
            int num45 = 0;
            if (index2 > 1)
              num45 = new Random((int) Math.Round(a1)).Next(0, index2 - 1);
            ref Graphics local23 = ref toG;
            bitmap1 = BitmapStore.GetBitmap(nr1, Zoom);
            ref Bitmap local24 = ref bitmap1;
            rectangle2 = new Rectangle(num45 * num6, 0, num6, num7);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(tx, ty, num6, num7);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local23, ref local24, srcrect, destrect);
          }
          int[] numArray26 = new int[7];
          int[] numArray27 = new int[7];
          int[] numArray28 = new int[7];
          int index29 = -1;
          int tfacing2 = 1;
          do
          {
            coordinateArray[tfacing2] = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, tfacing2);
            numArray26[tfacing2] = -1;
            numArray27[tfacing2] = -1;
            if (coordinateArray[tfacing2].onmap)
            {
              numArray26[tfacing2] = this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing2].x, coordinateArray[tfacing2].y].LandscapeType;
              if (index5 > -1)
              {
                if (this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing2].x, coordinateArray[tfacing2].y].get_SeeNow(index5) == 0)
                  numArray26[tfacing2] = this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing2].x, coordinateArray[tfacing2].y].get_LastLT(index5);
                if (numArray26[tfacing2] == -1)
                  numArray26[tfacing2] = lt1;
              }
              numArray27[tfacing2] = numArray26[tfacing2];
              numArray28[tfacing2] = this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing2].x, coordinateArray[tfacing2].y].SpriteNr;
              if (index5 > -1)
              {
                if (this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing2].x, coordinateArray[tfacing2].y].get_SeeNow(index5) == 0)
                  numArray28[tfacing2] = this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing2].x, coordinateArray[tfacing2].y].get_LastSpr(index5);
                if (numArray28[tfacing2] == -1)
                  numArray28[tfacing2] = index7;
              }
              if (this.game.Data.LandscapeTypeObj[numArray26[tfacing2]].Interior | this.game.Data.LandscapeTypeObj[numArray26[tfacing2]].ExtraExterior > -1)
              {
                if (!this.game.Data.LandscapeTypeObj[numArray26[tfacing2]].Transparent)
                  numArray26[tfacing2] = !this.game.Data.LandscapeTypeObj[lt1].ExtraExteriorSame ? (!(this.game.Data.LandscapeTypeObj[numArray26[tfacing2]].ExtraExterior > -1 & this.game.Data.LandscapeTypeObj[lt1].CheckOverride2(numArray26[tfacing2])) ? -1 : numArray26[tfacing2]) : (!this.game.Data.LandscapeTypeObj[lt1].CheckOverride2(numArray26[tfacing2]) ? -1 : numArray26[tfacing2]);
              }
              else
                numArray26[tfacing2] = -1;
            }
            if (coordinateArray[tfacing2].onmap && this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing2].x, coordinateArray[tfacing2].y].SpriteNr <= this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing2].x, coordinateArray[tfacing2].y].LandscapeType].BasicSpriteCounter && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing2].x, coordinateArray[tfacing2].y].LandscapeType].OverIsTop[this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing2].x, coordinateArray[tfacing2].y].SpriteNr] && tfacing2 != 4)
              numArray26[tfacing2] = -1;
            numArray3[tfacing2] = 0;
            ++tfacing2;
          }
          while (tfacing2 <= 6);
          int index30 = 1;
          do
          {
            if (coordinateArray[index30].onmap & numArray26[index30] > -1 && this.game.Data.LandscapeTypeObj[numArray26[index30]].SpecialLayer | this.game.Data.LandscapeTypeObj[numArray26[index30]].ExtraExterior > -1 | this.game.Data.LandscapeTypeObj[numArray26[index30]].OverIsTop[numArray28[index30]] && numArray3[index30] == 0)
            {
              int extraExterior = numArray26[index30];
              int index31 = 1;
              do
              {
                if (numArray26[index31] == extraExterior)
                {
                  numArray4[index31] = 1;
                  numArray3[index31] = 1;
                }
                else
                  numArray4[index31] = numArray27[index31] <= -1 ? 0 : (!(this.game.Data.LandscapeTypeObj[numArray27[index31]].CheckOverride2(extraExterior) & numArray27[index31] == extraExterior) ? 0 : 1);
                ++index31;
              }
              while (index31 <= 6);
              ++index29;
              numArray10[index29] = -1;
              index2 = numArray28[index30];
              if (this.game.Data.LandscapeTypeObj[extraExterior].ExtraExterior > -1)
              {
                extraExterior = this.game.Data.LandscapeTypeObj[extraExterior].ExtraExterior;
                index2 = 0;
              }
              if (!this.game.Data.LandscapeTypeObj[extraExterior].OverIsTop[index2])
              {
                if (this.game.Data.LandscapeTypeObj[numArray26[index30]].SpecialLayer6)
                {
                  flagArray1[index29] = true;
                  if (numArray4[1] > 0)
                    numArray12[index29, 0] = this.game.Data.LandscapeTypeObj[extraExterior].LayerSpriteID[this.game.SPRITE64[1, 0, 0, 0, 0, 0]];
                  if (numArray4[2] > 0)
                    numArray12[index29, 1] = this.game.Data.LandscapeTypeObj[extraExterior].LayerSpriteID[this.game.SPRITE64[0, 1, 0, 0, 0, 0]];
                  if (numArray4[3] > 0)
                    numArray12[index29, 2] = this.game.Data.LandscapeTypeObj[extraExterior].LayerSpriteID[this.game.SPRITE64[0, 0, 1, 0, 0, 0]];
                  if (numArray4[4] > 0)
                    numArray12[index29, 3] = this.game.Data.LandscapeTypeObj[extraExterior].LayerSpriteID[this.game.SPRITE64[0, 0, 0, 1, 0, 0]];
                  if (numArray4[5] > 0)
                    numArray12[index29, 4] = this.game.Data.LandscapeTypeObj[extraExterior].LayerSpriteID[this.game.SPRITE64[0, 0, 0, 0, 1, 0]];
                  if (numArray4[6] > 0)
                    numArray12[index29, 5] = this.game.Data.LandscapeTypeObj[extraExterior].LayerSpriteID[this.game.SPRITE64[0, 0, 0, 0, 0, 1]];
                }
                else if (!this.game.Data.LandscapeTypeObj[extraExterior].UseSheet)
                {
                  numArray10[index29] = -1;
                  numArray7[index29] = this.game.Data.LandscapeTypeObj[extraExterior].LayerSpriteID[this.game.SPRITE64[numArray4[1], numArray4[2], numArray4[3], numArray4[4], numArray4[5], numArray4[6]]];
                }
                else
                {
                  numArray10[index29] = this.game.Data.LandscapeTypeObj[extraExterior].SheetSpriteID;
                  numArray11[index29] = this.game.SPRITE64[numArray4[1], numArray4[2], numArray4[3], numArray4[4], numArray4[5], numArray4[6]];
                }
              }
              else
              {
                numArray7[index29] = this.game.Data.LandscapeTypeObj[extraExterior].BasicSpriteID3[index2];
                flagArray2[index29] = true;
                numArray10[index29] = -1;
              }
              numArray9[index29] = this.game.Data.LandscapeTypeObj[extraExterior].OverridesZ;
            }
            ++index30;
          }
          while (index30 <= 6);
          if (index29 > 0)
          {
            int num46 = index29;
            for (int index32 = 0; index32 <= num46; ++index32)
            {
              int num47 = index29 - 1;
              for (int index33 = 0; index33 <= num47; ++index33)
              {
                if (numArray9[index33] > numArray9[index33 + 1])
                {
                  index2 = numArray9[index33 + 1];
                  int num48 = numArray7[index33 + 1];
                  int num49 = numArray8[index33 + 1];
                  bool flag5 = flagArray1[index33 + 1];
                  int num50 = numArray10[index33 + 1];
                  int num51 = numArray11[index33 + 1];
                  bool flag6 = flagArray2[index33 + 1];
                  int index34 = 0;
                  do
                  {
                    numArray4[index34] = numArray12[index33 + 1, index34];
                    ++index34;
                  }
                  while (index34 <= 5);
                  numArray9[index33 + 1] = numArray9[index33];
                  numArray7[index33 + 1] = numArray7[index33];
                  numArray8[index33 + 1] = numArray8[index33];
                  flagArray1[index33 + 1] = flagArray1[index33];
                  flagArray2[index33 + 1] = flagArray2[index33];
                  numArray10[index33 + 1] = numArray10[index33];
                  numArray11[index33 + 1] = numArray11[index33];
                  int index35 = 0;
                  do
                  {
                    numArray12[index33 + 1, index35] = numArray12[index33, index35];
                    ++index35;
                  }
                  while (index35 <= 5);
                  numArray9[index33] = index2;
                  numArray7[index33] = num48;
                  numArray8[index33] = num49;
                  flagArray1[index33] = flag5;
                  flagArray2[index33] = flag6;
                  numArray10[index33] = num50;
                  numArray11[index33] = num51;
                  int index36 = 0;
                  do
                  {
                    numArray12[index33, index36] = numArray4[index36];
                    ++index36;
                  }
                  while (index36 <= 5);
                }
              }
            }
          }
          if (index29 > -1)
          {
            int num52 = index29;
            for (int index37 = 0; index37 <= num52; ++index37)
            {
              if (flagArray1[index37])
              {
                int index38 = 0;
                do
                {
                  if (numArray12[index37, index38] > 0 && numArray9[index37] <= 900)
                  {
                    index2 = (int) Math.Round((double) BitmapStore.GetWidth(numArray12[index37, index38], Zoom) / (double) num6);
                    int num53 = 0;
                    if (index2 > 1)
                    {
                      Random random = new Random((int) Math.Round(a1));
                      if (flagArray2[index37])
                        random = new Random((int) Math.Round(a2));
                      num53 = random.Next(0, index2 - 1);
                    }
                    ref Graphics local25 = ref toG;
                    bitmap1 = BitmapStore.GetBitmap(numArray12[index37, index38], Zoom);
                    ref Bitmap local26 = ref bitmap1;
                    rectangle2 = new Rectangle(num53 * num6, 0, num6, num7);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx, ty, num6, num7);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local25, ref local26, srcrect, destrect);
                  }
                  ++index38;
                }
                while (index38 <= 5);
              }
              else if (numArray9[index37] <= 900)
              {
                if (numArray10[index37] > -1)
                {
                  ref Graphics local27 = ref toG;
                  bitmap1 = BitmapStore.GetBitmap(numArray10[index37], Zoom);
                  ref Bitmap local28 = ref bitmap1;
                  rectangle2 = new Rectangle(this.game.SHEETX[numArray11[index37]] * num6, this.game.SHEETY[numArray11[index37]] * num7, num6, num7);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, num6, num7);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local27, ref local28, srcrect, destrect);
                }
                else
                {
                  index2 = (int) Math.Round((double) BitmapStore.GetWidth(numArray7[index37], Zoom) / (double) num6);
                  int num54 = 0;
                  if (index2 > 1)
                  {
                    Random random = new Random((int) Math.Round(a1));
                    if (flagArray2[index37])
                      random = new Random((int) Math.Round(a2));
                    num54 = random.Next(0, index2 - 1);
                  }
                  ref Graphics local29 = ref toG;
                  bitmap1 = BitmapStore.GetBitmap(numArray7[index37], Zoom);
                  ref Bitmap local30 = ref bitmap1;
                  rectangle2 = new Rectangle(num54 * num6, 0, num6, num7);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, num6, num7);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local29, ref local30, srcrect, destrect);
                }
              }
            }
          }
          int lt2 = this.game.Data.MapObj[cmap].HexObj[cx, cy].LandscapeType;
          int index39 = this.game.Data.MapObj[cmap].HexObj[cx, cy].SpriteNr;
          if (index39 == 2)
            cx = cx;
          if (index5 > -1)
          {
            if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_SeeNow(index5) == 0)
              lt2 = this.game.Data.MapObj[cmap].HexObj[cx, cy].get_LastLT(index5);
            if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_SeeNow(index5) == 0)
              index39 = this.game.Data.MapObj[cmap].HexObj[cx, cy].get_LastSpr(index5);
          }
          int[] numArray29 = new int[7];
          if (lt2 > -1)
          {
            if (this.game.Data.LandscapeTypeObj[lt2].OverridesZ != 899 && !this.game.Data.LandscapeTypeObj[lt2].Transparent)
            {
              nr1 = lt2 <= -1 ? this.game.NOHEX : (!(index39 > -1 & index39 <= this.game.Data.LandscapeTypeObj[lt2].BasicSpriteCounter) ? this.game.NOHEX : this.game.Data.LandscapeTypeObj[lt2].BasicSpriteID[index39]);
              int nr4 = -1;
              int index40 = -1;
              if (this.game.Data.LandscapeTypeObj[lt2].Interior)
              {
                int tfacing3 = 1;
                do
                {
                  coordinateArray[tfacing3] = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, tfacing3);
                  numArray29[tfacing3] = 0;
                  if (coordinateArray[tfacing3].onmap)
                  {
                    int num55 = this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing3].x, coordinateArray[tfacing3].y].LandscapeType;
                    if (index5 > -1)
                    {
                      if (this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing3].x, coordinateArray[tfacing3].y].get_SeeNow(index5) == 0)
                        num55 = this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing3].x, coordinateArray[tfacing3].y].get_LastLT(index5);
                      if (num55 == -1)
                        num55 = lt2;
                    }
                    if (num55 == lt2)
                    {
                      numArray29[tfacing3] = 1;
                    }
                    else
                    {
                      int overridesCount = this.game.Data.LandscapeTypeObj[lt2].OverridesCount;
                      for (int index41 = 0; index41 <= overridesCount; ++index41)
                      {
                        if (this.game.Data.LandscapeTypeObj[lt2].OverridesType[index41] == num55)
                        {
                          numArray29[tfacing3] = 1;
                          if (this.game.Data.LandscapeTypeObj[lt2].ExtraExterior > -1 & !this.game.Data.LandscapeTypeObj[lt2].ExtraExteriorSame)
                            numArray29[tfacing3] = 0;
                        }
                      }
                    }
                  }
                  else
                    numArray29[tfacing3] = 1;
                  ++tfacing3;
                }
                while (tfacing3 <= 6);
                nr1 = this.game.Data.LandscapeTypeObj[lt2].LayerSpriteID[this.game.SPRITE64[numArray29[1], numArray29[2], numArray29[3], numArray29[4], numArray29[5], numArray29[6]]];
                if (this.game.Data.LandscapeTypeObj[lt2].UseSheet)
                {
                  nr4 = this.game.Data.LandscapeTypeObj[lt2].SheetSpriteID;
                  index40 = this.game.SPRITE64[numArray29[1], numArray29[2], numArray29[3], numArray29[4], numArray29[5], numArray29[6]];
                }
                else
                {
                  nr4 = -1;
                  index40 = -1;
                }
              }
              if (flag2 & this.game.Data.LandscapeTypeObj[lt2].IsSea)
              {
                if (!BitmapStore.IsKnownTransBitmap(nr1))
                {
                  if (nr4 == -1)
                  {
                    index2 = (int) Math.Round((double) BitmapStore.GetWidth(nr1, Zoom) / (double) num6);
                    int num56 = 0;
                    if (index2 > 1)
                      num56 = new Random((int) Math.Round(a1)).Next(0, index2 - 1);
                    ref Graphics local31 = ref toG;
                    bitmap1 = BitmapStore.GetBitmap(nr1, Zoom);
                    ref Bitmap local32 = ref bitmap1;
                    rectangle2 = new Rectangle(num56 * num6, 0, num6, num7);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx, ty, num6, num7);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local31, ref local32, srcrect, destrect);
                  }
                  else
                  {
                    ref Graphics local33 = ref toG;
                    bitmap1 = BitmapStore.GetBitmap(nr4, Zoom);
                    ref Bitmap local34 = ref bitmap1;
                    rectangle2 = new Rectangle(this.game.SHEETX[index40] * num6, this.game.SHEETY[index40] * num7, num6, num7);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx, ty, num6, num7);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local33, ref local34, srcrect, destrect);
                  }
                }
                ref Graphics local35 = ref toG;
                bitmap1 = BitmapStore.GetBitmap(this.game.ROUNDBALL, Zoom);
                ref Bitmap local36 = ref bitmap1;
                int x = tx;
                int y = ty;
                DrawMod.DrawSimple(ref local35, ref local36, x, y);
              }
              else if (!BitmapStore.IsKnownTransBitmap(nr1))
              {
                if (nr4 == -1)
                {
                  index2 = (int) Math.Round((double) BitmapStore.GetWidth(nr1, Zoom) / (double) num6);
                  int num57 = 0;
                  if (index2 > 1)
                    num57 = new Random((int) Math.Round(a1)).Next(0, index2 - 1);
                  ref Graphics local37 = ref toG;
                  bitmap1 = BitmapStore.GetBitmap(nr1, Zoom);
                  ref Bitmap local38 = ref bitmap1;
                  rectangle2 = new Rectangle(num57 * num6, 0, num6, num7);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, num6, num7);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local37, ref local38, srcrect, destrect);
                }
                else
                {
                  ref Graphics local39 = ref toG;
                  bitmap1 = BitmapStore.GetBitmap(nr4, Zoom);
                  ref Bitmap local40 = ref bitmap1;
                  rectangle2 = new Rectangle(this.game.SHEETX[index40] * num6, this.game.SHEETY[index40] * num7, num6, num7);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, num6, num7);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local39, ref local40, srcrect, destrect);
                }
              }
            }
          }
          else
          {
            nr1 = this.game.NOHEX;
            ref Graphics local41 = ref toG;
            bitmap1 = BitmapStore.GetBitmap(nr1, Zoom);
            ref Bitmap local42 = ref bitmap1;
            int x = tx;
            int y = ty;
            DrawMod.DrawSimple(ref local41, ref local42, x, y);
          }
          int index42 = -1;
          int tfacing4 = 1;
          do
          {
            coordinateArray[tfacing4] = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, tfacing4);
            numArray26[tfacing4] = -1;
            numArray2[tfacing4] = 0;
            if (coordinateArray[tfacing4].onmap)
            {
              numArray26[tfacing4] = this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing4].x, coordinateArray[tfacing4].y].LandscapeType;
              if (index5 > -1)
              {
                if (this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing4].x, coordinateArray[tfacing4].y].get_SeeNow(index5) == 0)
                  numArray26[tfacing4] = this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing4].x, coordinateArray[tfacing4].y].get_LastLT(index5);
                if (numArray26[tfacing4] == -1)
                  numArray26[tfacing4] = lt2;
              }
              numArray2[tfacing4] = this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing4].x, coordinateArray[tfacing4].y].SpriteNr;
              if (index5 > -1)
              {
                if (this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing4].x, coordinateArray[tfacing4].y].get_SeeNow(index5) == 0)
                  numArray28[tfacing4] = this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing4].x, coordinateArray[tfacing4].y].get_LastSpr(index5);
                if (numArray28[tfacing4] == -1)
                  numArray28[tfacing4] = index39;
              }
              if (this.game.Data.LandscapeTypeObj[numArray26[tfacing4]].Transparent)
                numArray26[tfacing4] = -1;
              else if (this.game.Data.LandscapeTypeObj[numArray26[tfacing4]].Interior)
                numArray26[tfacing4] = -1;
              else if (this.game.Data.LandscapeTypeObj[numArray26[tfacing4]].UsePreHexTexture & !this.game.Data.LandscapeTypeObj[numArray26[tfacing4]].UsePreHexTextureAndRegularPreHex)
                numArray26[tfacing4] = -1;
              else if (!this.game.Data.LandscapeTypeObj[numArray26[tfacing4]].CheckOverride(lt2))
                numArray26[tfacing4] = -1;
            }
            if (this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing4].x, coordinateArray[tfacing4].y].SpriteNr <= this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing4].x, coordinateArray[tfacing4].y].LandscapeType].BasicSpriteCounter && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing4].x, coordinateArray[tfacing4].y].LandscapeType].OverIsTop[this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing4].x, coordinateArray[tfacing4].y].SpriteNr] && tfacing4 != 4)
              numArray26[tfacing4] = -1;
            numArray3[tfacing4] = 0;
            ++tfacing4;
          }
          while (tfacing4 <= 6);
          int index43 = 1;
          do
          {
            int index44 = 1;
            do
            {
              if (numArray26[index43] > -1 & numArray26[index44] > -1 & numArray26[index43] != numArray26[index44] && this.game.Data.LandscapeTypeObj[numArray26[index43]].CheckOverride2(numArray26[index44]) && this.game.Data.LandscapeTypeObj[numArray26[index44]].CheckOverride2(numArray26[index43]))
              {
                if (numArray26[index43] > numArray26[index44])
                  numArray26[index44] = numArray26[index43];
                else
                  numArray26[index43] = numArray26[index44];
              }
              ++index44;
            }
            while (index44 <= 6);
            ++index43;
          }
          while (index43 <= 6);
          if (cx == 4 & cy == 7)
            cx = cx;
          int index45 = 1;
          do
          {
            if (coordinateArray[index45].onmap & numArray26[index45] > -1 && numArray2[index45] <= this.game.Data.LandscapeTypeObj[numArray26[index45]].BasicSpriteCounter && this.game.Data.LandscapeTypeObj[numArray26[index45]].SpecialLayer | this.game.Data.LandscapeTypeObj[numArray26[index45]].OverIsTop[numArray2[index45]] && numArray3[index45] == 0)
            {
              int index46 = numArray26[index45];
              int index47 = 1;
              do
              {
                if (numArray26[index47] == index46)
                {
                  numArray29[index47] = 1;
                  numArray3[index47] = 1;
                }
                else
                  numArray29[index47] = 0;
                ++index47;
              }
              while (index47 <= 6);
              ++index42;
              numArray10[index42] = -1;
              if (!this.game.Data.LandscapeTypeObj[index46].OverIsTop[numArray2[index45]])
              {
                if (this.game.Data.LandscapeTypeObj[index46].SpecialLayer6)
                {
                  flagArray1[index42] = true;
                  numArray10[index42] = -1;
                  if (numArray29[1] > 0)
                    numArray12[index42, 0] = this.game.Data.LandscapeTypeObj[index46].LayerSpriteID[this.game.SPRITE64[1, 0, 0, 0, 0, 0]];
                  if (numArray29[2] > 0)
                    numArray12[index42, 1] = this.game.Data.LandscapeTypeObj[index46].LayerSpriteID[this.game.SPRITE64[0, 1, 0, 0, 0, 0]];
                  if (numArray29[3] > 0)
                    numArray12[index42, 2] = this.game.Data.LandscapeTypeObj[index46].LayerSpriteID[this.game.SPRITE64[0, 0, 1, 0, 0, 0]];
                  if (numArray29[4] > 0)
                    numArray12[index42, 3] = this.game.Data.LandscapeTypeObj[index46].LayerSpriteID[this.game.SPRITE64[0, 0, 0, 1, 0, 0]];
                  if (numArray29[5] > 0)
                    numArray12[index42, 4] = this.game.Data.LandscapeTypeObj[index46].LayerSpriteID[this.game.SPRITE64[0, 0, 0, 0, 1, 0]];
                  if (numArray29[6] > 0)
                    numArray12[index42, 5] = this.game.Data.LandscapeTypeObj[index46].LayerSpriteID[this.game.SPRITE64[0, 0, 0, 0, 0, 1]];
                }
                else if (this.game.Data.LandscapeTypeObj[index46].UseSheet)
                {
                  numArray10[index42] = this.game.Data.LandscapeTypeObj[index46].SheetSpriteID;
                  numArray11[index42] = this.game.SPRITE64[numArray29[1], numArray29[2], numArray29[3], numArray29[4], numArray29[5], numArray29[6]];
                }
                else
                {
                  numArray10[index42] = -1;
                  numArray7[index42] = this.game.Data.LandscapeTypeObj[index46].LayerSpriteID[this.game.SPRITE64[numArray29[1], numArray29[2], numArray29[3], numArray29[4], numArray29[5], numArray29[6]]];
                }
              }
              else
              {
                numArray10[index42] = -1;
                numArray7[index42] = this.game.Data.LandscapeTypeObj[index46].BasicSpriteID3[numArray2[index45]];
                flagArray2[index42] = true;
              }
              numArray9[index42] = this.game.Data.LandscapeTypeObj[index46].OverridesZ;
              numArray8[index42] = !this.game.Data.LandscapeTypeObj[numArray26[index45]].IsSea ? 0 : 1;
            }
            ++index45;
          }
          while (index45 <= 6);
          if (index42 > 0)
          {
            int num58 = index42;
            for (int index48 = 0; index48 <= num58; ++index48)
            {
              int num59 = index42 - 1;
              for (int index49 = 0; index49 <= num59; ++index49)
              {
                if (numArray9[index49] > numArray9[index49 + 1])
                {
                  index2 = numArray9[index49 + 1];
                  int num60 = numArray7[index49 + 1];
                  int num61 = numArray8[index49 + 1];
                  bool flag7 = flagArray1[index49 + 1];
                  bool flag8 = flagArray2[index49 + 1];
                  int num62 = numArray10[index49 + 1];
                  int num63 = numArray11[index49 + 1];
                  int index50 = 0;
                  do
                  {
                    numArray29[index50] = numArray12[index49 + 1, index50];
                    ++index50;
                  }
                  while (index50 <= 5);
                  numArray9[index49 + 1] = numArray9[index49];
                  numArray7[index49 + 1] = numArray7[index49];
                  numArray8[index49 + 1] = numArray8[index49];
                  flagArray1[index49 + 1] = flagArray1[index49];
                  flagArray2[index49 + 1] = flagArray2[index49];
                  numArray10[index49 + 1] = numArray10[index49];
                  numArray11[index49 + 1] = numArray11[index49];
                  int index51 = 0;
                  do
                  {
                    numArray12[index49 + 1, index51] = numArray12[index49, index51];
                    ++index51;
                  }
                  while (index51 <= 5);
                  numArray9[index49] = index2;
                  numArray7[index49] = num60;
                  numArray8[index49] = num61;
                  flagArray1[index49] = flag7;
                  flagArray2[index49] = flag8;
                  numArray10[index49] = num62;
                  numArray11[index49] = num63;
                  int index52 = 0;
                  do
                  {
                    numArray12[index49, index52] = numArray29[index52];
                    ++index52;
                  }
                  while (index52 <= 5);
                }
              }
            }
          }
          if (index42 > -1)
          {
            int num64 = index42;
            for (int index53 = 0; index53 <= num64; ++index53)
            {
              if (numArray8[index53] == 0 & numArray9[index53] <= 898)
              {
                if (flagArray1[index53])
                {
                  int index54 = 0;
                  do
                  {
                    if (numArray12[index53, index54] > 0 && numArray9[index53] <= 900)
                    {
                      index2 = (int) Math.Round((double) BitmapStore.GetWidth(numArray12[index53, index54], Zoom) / (double) num6);
                      int num65 = 0;
                      if (index2 > 1)
                      {
                        Random random = new Random((int) Math.Round(a1));
                        if (flagArray2[index53])
                          random = new Random((int) Math.Round(a2));
                        num65 = random.Next(0, index2 - 1);
                      }
                      ref Graphics local43 = ref toG;
                      bitmap1 = BitmapStore.GetBitmap(numArray12[index53, index54], Zoom);
                      ref Bitmap local44 = ref bitmap1;
                      rectangle2 = new Rectangle(num65 * num6, 0, num6, num7);
                      Rectangle srcrect = rectangle2;
                      rectangle1 = new Rectangle(tx, ty, num6, num7);
                      Rectangle destrect = rectangle1;
                      DrawMod.DrawSimplePart2(ref local43, ref local44, srcrect, destrect);
                    }
                    ++index54;
                  }
                  while (index54 <= 5);
                }
                else if (numArray9[index53] <= 900)
                {
                  if (numArray10[index53] == -1)
                  {
                    index2 = (int) Math.Round((double) BitmapStore.GetWidth(numArray7[index53], Zoom) / (double) num6);
                    int num66 = 0;
                    if (index2 > 1)
                    {
                      Random random = new Random((int) Math.Round(a1));
                      if (flagArray2[index53])
                        random = new Random((int) Math.Round(a2));
                      num66 = random.Next(0, index2 - 1);
                    }
                    ref Graphics local45 = ref toG;
                    bitmap1 = BitmapStore.GetBitmap(numArray7[index53], Zoom);
                    ref Bitmap local46 = ref bitmap1;
                    rectangle2 = new Rectangle(num66 * num6, 0, num6, num7);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx, ty, num6, num7);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local45, ref local46, srcrect, destrect);
                  }
                  else
                  {
                    ref Graphics local47 = ref toG;
                    bitmap1 = BitmapStore.GetBitmap(numArray10[index53], Zoom);
                    ref Bitmap local48 = ref bitmap1;
                    rectangle2 = new Rectangle(this.game.SHEETX[numArray11[index53]] * num6, this.game.SHEETY[numArray11[index53]] * num7, num6, num7);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx, ty, num6, num7);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local47, ref local48, srcrect, destrect);
                  }
                }
              }
            }
          }
          int index55 = -1;
          int num67 = -1;
          if ((this.game.Data.MapObj[0].HexObj[cx, cy].MaxRecon > 0 | !this.game.Data.ShrowdOn) & !flag1)
            num67 = this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime;
          else if (index5 > -1)
            num67 = this.game.Data.MapObj[0].HexObj[cx, cy].get_LastReg(index5);
          if (this.game.EditObj.RealRound > 0)
          {
            if (UseRegimeColoring & num67 > -1 & num67 != index5 | flag1)
            {
              index55 = num67;
              if (flag1)
                index55 = this.game.EditObj.HisOwner[cmap].Value[cx, cy];
              if (flag1 && index55 == index5)
                index55 = -1;
              if (index55 == -2)
                index55 = this.game.Data.MapObj[0].HexObj[cx, cy].get_LastReg(index5);
            }
            else if (this.game.Data.LandscapeTypeObj[lt2].Interior & UseRegimeColoring & this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime == -1 & (index5 == -1 | num67 != index5))
            {
              int[] numArray30 = new int[7];
              int num68 = 0;
              int tfacing5 = 1;
              do
              {
                numArray30[tfacing5] = -1;
                coordinateArray[tfacing5] = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, tfacing5);
                if (coordinateArray[tfacing5].onmap && this.game.Data.MapObj[0].HexObj[coordinateArray[tfacing5].x, coordinateArray[tfacing5].y].Regime > -1)
                {
                  numArray30[tfacing5] = this.game.Data.MapObj[0].HexObj[coordinateArray[tfacing5].x, coordinateArray[tfacing5].y].Regime;
                  ++num68;
                }
                ++tfacing5;
              }
              while (tfacing5 <= 6);
              if (num68 > 0)
              {
                int index56 = 1;
                int num69;
                int num70;
                do
                {
                  int num71 = 0;
                  if (numArray30[index56] > -1)
                  {
                    int index57 = 1;
                    do
                    {
                      if (numArray30[index56] == numArray30[index57])
                        ++num71;
                      ++index57;
                    }
                    while (index57 <= 6);
                  }
                  if (num71 > num69)
                  {
                    num69 = num71;
                    num70 = numArray30[index56];
                  }
                  ++index56;
                }
                while (index56 <= 6);
                if (num69 > 0)
                  index55 = num70;
              }
            }
            if (index55 > -1 & index55 <= this.game.Data.RegimeCounter)
            {
              if (index5 > -1 && index55 > -1 && this.game.Data.RegimeObj[index5].RegimeRel[index55] == 0)
              {
                index2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.strId143slot].GetData(0, this.game.Data.RegimeObj[index55].id, 1)));
                if (index2 == 2)
                {
                  int strId275slot = this.strId275slot;
                  if (this.cacheDipClear[this.game.Data.RegimeObj[index5].id, this.game.Data.RegimeObj[index55].id] == 0)
                    index55 = 1;
                }
              }
              if (index55 > -1 & index55 != index5 && this.game.Data.LandscapeTypeObj[lt2].OverridesZ < 899)
              {
                if (Information.IsNothing((object) this.game.Data.RegimeObj[index55].TempRegimeColor))
                  this.game.Data.RegimeObj[index55].doTempRegimeHighlight();
                if (Zoom == -1)
                  DrawMod.DrawSimple(ref toG, ref this.game.Data.RegimeObj[index55].TempRegimeColorSmall, tx, ty);
                if (Zoom == 0)
                  DrawMod.DrawSimple(ref toG, ref this.game.Data.RegimeObj[index55].TempRegimeColor, tx, ty);
                if (Zoom == 1)
                  DrawMod.DrawSimple(ref toG, ref this.game.Data.RegimeObj[index55].TempRegimeColorBig, tx, ty);
              }
            }
          }
          int landscapeType1 = this.game.Data.MapObj[cmap].HexObj[cx, cy].LandscapeType;
          if (!this.game.EditObj.skipGfxDetail && this.game.AllowHeightMap & this.game.Data.LandscapeTypeObj[landscapeType1].IsSea & this.game.Data.LandscapeTypeObj[landscapeType1].Interior)
            this.DrawHeightMap(ref toG, cx, cy, cmap, tx, ty, Zoom, true, ref gBitmap);
          if (this.game.Data.LandscapeTypeObj[landscapeType1].IsSea & this.game.Data.LandscapeTypeObj[landscapeType1].Interior & this.game.Data.LandscapeTypeObj[landscapeType1].OverridesZ == 899)
          {
            int num72 = 0;
            do
            {
              int num73;
              if (num72 == 0)
              {
                index2 = 2;
                index19 = (int) Math.Round((double) -num6 / 6.0);
                index55 = (int) Math.Round(-((double) num7 / 2.0) - 1.0);
                num5 = 5;
                index8 = (int) Math.Round((double) (num6 * 2) / 3.0 - 1.0);
                num73 = -1;
              }
              if (num72 == 1)
              {
                index2 = 3;
                index19 = (int) Math.Round((double) num6 / 6.0 + 1.0);
                index55 = (int) Math.Round(-((double) num7 / 2.0));
                num5 = 0;
                index8 = (int) Math.Round((double) num6 / 6.0 + 1.0);
                num73 = (int) Math.Round((double) num7 / 2.0);
              }
              if (num72 == 2)
              {
                index2 = 4;
                index19 = (int) Math.Round((double) (num6 * 2) / 3.0);
                index55 = 0;
                num5 = 1;
                index8 = (int) Math.Round(-((double) num6 / 6.0) + 1.0);
                num73 = (int) Math.Round((double) num7 / 2.0);
              }
              if (num72 == 3)
              {
                index2 = 5;
                index19 = (int) Math.Round((double) num6 / 6.0);
                index55 = (int) Math.Round((double) num7 / 2.0);
                num5 = 2;
                index8 = (int) Math.Round(-((double) (num6 * 2) / 3.0) + 1.0);
                num73 = 0;
              }
              if (num72 == 4)
              {
                index2 = 0;
                index19 = (int) Math.Round(-((double) num6 / 6.0) - 1.0);
                index55 = (int) Math.Round((double) num7 / 2.0);
                num5 = 3;
                index8 = (int) Math.Round(-((double) num6 / 6.0) - 1.0);
                num73 = (int) Math.Round(-((double) num7 / 2.0));
              }
              if (num72 == 5)
              {
                index2 = 1;
                index19 = (int) Math.Round(-((double) (num6 * 2) / 3.0));
                index55 = 0;
                num5 = 4;
                index8 = (int) Math.Round((double) num6 / 6.0 - 1.0);
                num73 = (int) Math.Round(-((double) num7 / 2.0));
              }
              coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, num72 + 1);
              if (coordinate1.onmap)
              {
                int index58 = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RiverType[index2];
                if (index58 > -1 && !this.game.Data.RiverTypeObj[index58].snakeMode)
                {
                  int index59 = 0;
                  do
                  {
                    numArray29[index59] = 0;
                    if (index59 == index2)
                      numArray29[index59] = 1;
                    ++index59;
                  }
                  while (index59 <= 5);
                  num34 = this.game.Data.RiverTypeObj[index58].LayerSpriteID[this.game.SPRITE64[numArray29[0], numArray29[1], numArray29[2], numArray29[3], numArray29[4], numArray29[5]]];
                  int sheetSpriteId1 = this.game.Data.RiverTypeObj[index58].SheetSpriteID;
                  if (sheetSpriteId1 > 0)
                  {
                    int index60 = this.game.SPRITE64[numArray29[0], numArray29[1], numArray29[2], numArray29[3], numArray29[4], numArray29[5]];
                    ref Graphics local49 = ref toG;
                    bitmap1 = BitmapStore.GetBitmap(sheetSpriteId1, Zoom);
                    ref Bitmap local50 = ref bitmap1;
                    rectangle2 = new Rectangle(this.game.SHEETX[index60] * num6, this.game.SHEETY[index60] * num7, num6, num7);
                    Rectangle srcrect3 = rectangle2;
                    rectangle1 = new Rectangle(tx + index19, ty + index55, num6, num7);
                    Rectangle destrect3 = rectangle1;
                    DrawMod.DrawSimplePart2(ref local49, ref local50, srcrect3, destrect3);
                    int index61 = 0;
                    do
                    {
                      numArray29[index61] = 0;
                      if (index61 == num5)
                        numArray29[index61] = 1;
                      ++index61;
                    }
                    while (index61 <= 5);
                    num34 = this.game.Data.RiverTypeObj[index58].LayerSpriteID[this.game.SPRITE64[numArray29[0], numArray29[1], numArray29[2], numArray29[3], numArray29[4], numArray29[5]]];
                    int sheetSpriteId2 = this.game.Data.RiverTypeObj[index58].SheetSpriteID;
                    if (sheetSpriteId2 > 0)
                    {
                      int index62 = this.game.SPRITE64[numArray29[0], numArray29[1], numArray29[2], numArray29[3], numArray29[4], numArray29[5]];
                      ref Graphics local51 = ref toG;
                      bitmap1 = BitmapStore.GetBitmap(sheetSpriteId2, Zoom);
                      ref Bitmap local52 = ref bitmap1;
                      rectangle2 = new Rectangle(this.game.SHEETX[index62] * num6, this.game.SHEETY[index62] * num7, num6, num7);
                      Rectangle srcrect4 = rectangle2;
                      rectangle1 = new Rectangle(tx + index8, ty + num73, num6, num7);
                      Rectangle destrect4 = rectangle1;
                      DrawMod.DrawSimplePart2(ref local51, ref local52, srcrect4, destrect4);
                    }
                  }
                }
              }
              ++num72;
            }
            while (num72 <= 5);
          }
          int index63 = this.game.Data.MapObj[cmap].HexObj[cx, cy].LandscapeType;
          int index64 = this.game.Data.MapObj[cmap].HexObj[cx, cy].SpriteNr;
          if (index5 > -1)
          {
            if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_SeeNow(index5) == 0)
              index63 = this.game.Data.MapObj[cmap].HexObj[cx, cy].get_LastLT(index5);
            if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_SeeNow(index5) == 0)
              index64 = this.game.Data.MapObj[cmap].HexObj[cx, cy].get_LastSpr(index5);
          }
          int[] numArray31 = new int[7];
          if (index63 > -1 && this.game.Data.LandscapeTypeObj[index63].OverridesZ == 899 && !this.game.Data.LandscapeTypeObj[index63].Transparent)
          {
            nr1 = index63 <= -1 ? this.game.NOHEX : (index64 <= -1 ? this.game.NOHEX : this.game.Data.LandscapeTypeObj[index63].BasicSpriteID[index64]);
            int nr5 = -1;
            int index65 = -1;
            if (this.game.Data.LandscapeTypeObj[index63].Interior)
            {
              int tfacing6 = 1;
              do
              {
                coordinateArray[tfacing6] = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, tfacing6);
                numArray31[tfacing6] = 0;
                if (coordinateArray[tfacing6].onmap)
                {
                  int num74 = this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing6].x, coordinateArray[tfacing6].y].LandscapeType;
                  if (index5 > -1)
                  {
                    if (this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing6].x, coordinateArray[tfacing6].y].get_SeeNow(index5) == 0)
                      num74 = this.game.Data.MapObj[cmap].HexObj[coordinateArray[tfacing6].x, coordinateArray[tfacing6].y].get_LastLT(index5);
                    if (num74 == -1)
                      num74 = index63;
                  }
                  if (num74 == index63)
                  {
                    numArray31[tfacing6] = 1;
                  }
                  else
                  {
                    int overridesCount = this.game.Data.LandscapeTypeObj[index63].OverridesCount;
                    for (int index66 = 0; index66 <= overridesCount; ++index66)
                    {
                      if (this.game.Data.LandscapeTypeObj[index63].OverridesType[index66] == num74)
                      {
                        numArray31[tfacing6] = 1;
                        if (this.game.Data.LandscapeTypeObj[index63].ExtraExterior > -1 & !this.game.Data.LandscapeTypeObj[index63].ExtraExteriorSame)
                          numArray31[tfacing6] = 0;
                      }
                    }
                  }
                }
                else
                  numArray31[tfacing6] = 1;
                ++tfacing6;
              }
              while (tfacing6 <= 6);
              nr1 = this.game.Data.LandscapeTypeObj[index63].LayerSpriteID[this.game.SPRITE64[numArray31[1], numArray31[2], numArray31[3], numArray31[4], numArray31[5], numArray31[6]]];
              if (this.game.Data.LandscapeTypeObj[index63].UseSheet)
              {
                nr5 = this.game.Data.LandscapeTypeObj[index63].SheetSpriteID;
                index65 = this.game.SPRITE64[numArray31[1], numArray31[2], numArray31[3], numArray31[4], numArray31[5], numArray31[6]];
              }
              else
              {
                nr5 = -1;
                index65 = -1;
              }
            }
            if (flag2 & this.game.Data.LandscapeTypeObj[index63].IsSea)
            {
              if (!BitmapStore.IsKnownTransBitmap(nr1))
              {
                int num75 = (int) Math.Round((double) BitmapStore.GetWidth(nr1, Zoom) / (double) num6);
                int num76 = 0;
                if (num75 > 1)
                  num76 = new Random((int) Math.Round(a1)).Next(0, num75 - 1);
                if (nr5 == -1)
                {
                  ref Graphics local53 = ref toG;
                  bitmap1 = BitmapStore.GetBitmap(nr1, Zoom);
                  ref Bitmap local54 = ref bitmap1;
                  rectangle2 = new Rectangle(num76 * num6, 0, num6, num7);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, num6, num7);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local53, ref local54, srcrect, destrect);
                }
                else
                {
                  ref Graphics local55 = ref toG;
                  bitmap1 = BitmapStore.GetBitmap(nr5, Zoom);
                  ref Bitmap local56 = ref bitmap1;
                  rectangle2 = new Rectangle(this.game.SHEETX[index65] * num6, this.game.SHEETY[index65] * num7, num6, num7);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, num6, num7);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local55, ref local56, srcrect, destrect);
                }
              }
              ref Graphics local57 = ref toG;
              bitmap1 = BitmapStore.GetBitmap(this.game.ROUNDBALL, Zoom);
              ref Bitmap local58 = ref bitmap1;
              int x = tx;
              int y = ty;
              DrawMod.DrawSimple(ref local57, ref local58, x, y);
            }
            else if (!BitmapStore.IsKnownTransBitmap(nr1))
            {
              int num77 = (int) Math.Round((double) BitmapStore.GetWidth(nr1, Zoom) / (double) num6);
              int num78 = 0;
              if (num77 > 1)
                num78 = new Random((int) Math.Round(a1)).Next(0, num77 - 1);
              if (nr5 == -1)
              {
                ref Graphics local59 = ref toG;
                bitmap1 = BitmapStore.GetBitmap(nr1, Zoom);
                ref Bitmap local60 = ref bitmap1;
                rectangle2 = new Rectangle(num78 * num6, 0, num6, num7);
                Rectangle srcrect = rectangle2;
                rectangle1 = new Rectangle(tx, ty, num6, num7);
                Rectangle destrect = rectangle1;
                DrawMod.DrawSimplePart2(ref local59, ref local60, srcrect, destrect);
              }
              else
              {
                ref Graphics local61 = ref toG;
                bitmap1 = BitmapStore.GetBitmap(nr5, Zoom);
                ref Bitmap local62 = ref bitmap1;
                rectangle2 = new Rectangle(this.game.SHEETX[index65] * num6, this.game.SHEETY[index65] * num7, num6, num7);
                Rectangle srcrect = rectangle2;
                rectangle1 = new Rectangle(tx, ty, num6, num7);
                Rectangle destrect = rectangle1;
                DrawMod.DrawSimplePart2(ref local61, ref local62, srcrect, destrect);
              }
            }
          }
          if (num15 == 0 & index63 > -1)
          {
            if ((flag4 | flag2) & !this.game.Data.LandscapeTypeObj[index63].IsSea)
            {
              if (this.game.EditObj.RegimeColoring)
              {
                if (flag4)
                {
                  ref Graphics local63 = ref toG;
                  bitmap1 = BitmapStore.GetBitmap(this.game.WHITEHEXTRANS3, Zoom);
                  ref Bitmap local64 = ref bitmap1;
                  int x = tx;
                  int y = ty;
                  DrawMod.DrawSimple(ref local63, ref local64, x, y);
                }
                else if (this.game.Data.MapObj[0].HexObj[cx, cy].Regime == index5 | this.game.Data.Round == 0)
                {
                  ref Graphics local65 = ref toG;
                  bitmap1 = BitmapStore.GetBitmap(this.game.WHITEHEXTRANS, Zoom);
                  ref Bitmap local66 = ref bitmap1;
                  int x = tx;
                  int y = ty;
                  DrawMod.DrawSimple(ref local65, ref local66, x, y);
                }
                else
                {
                  ref Graphics local67 = ref toG;
                  bitmap1 = BitmapStore.GetBitmap(this.game.WHITEHEXTRANS2, Zoom);
                  ref Bitmap local68 = ref bitmap1;
                  int x = tx;
                  int y = ty;
                  DrawMod.DrawSimple(ref local67, ref local68, x, y);
                }
              }
              else if (flag4)
              {
                ref Graphics local69 = ref toG;
                bitmap1 = BitmapStore.GetBitmap(this.game.WHITEHEXTRANS3, Zoom);
                ref Bitmap local70 = ref bitmap1;
                int x = tx;
                int y = ty;
                DrawMod.DrawSimple(ref local69, ref local70, x, y);
              }
              else
              {
                ref Graphics local71 = ref toG;
                bitmap1 = BitmapStore.GetBitmap(this.game.WHITEHEXTRANS, Zoom);
                ref Bitmap local72 = ref bitmap1;
                int x = tx;
                int y = ty;
                DrawMod.DrawSimple(ref local71, ref local72, x, y);
              }
              num15 = 1;
            }
            else if (cx == 13 & cy == 4)
              cx = cx;
          }
          int[] numArray32 = new int[7];
          if ((double) this.game.Data.RuleVar[32] == -1.0)
          {
            if ((double) this.game.Data.RuleVar[908] < 1.0)
            {
              bool flag9 = false;
              int index67 = 0;
              do
              {
                int index68 = this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index67];
                if (index68 > -1 & numArray32[index67] == 0)
                {
                  if (index68 == 4 & !flag9)
                  {
                    flag9 = true;
                    this.DrawCanyon(ref toG, cx, cy, cmap, tx, ty, Zoom, ref gBitmap);
                  }
                  if (!this.game.Data.RiverTypeObj[index68].Transparent && this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index67] > -1 & !this.game.Data.RiverTypeObj[index68].SpecialLayer | this.game.Data.RiverTypeObj[index68].SpecialLayer)
                  {
                    int nr6;
                    if (!this.game.Data.RiverTypeObj[index68].SpecialLayer)
                    {
                      nr6 = this.game.Data.RiverTypeObj[index68].BasicSpriteID[index67];
                    }
                    else
                    {
                      int index69 = 0;
                      do
                      {
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index69] == this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index67])
                        {
                          numArray31[index69] = 1;
                          numArray32[index69] = 1;
                        }
                        else
                          numArray31[index69] = 0;
                        ++index69;
                      }
                      while (index69 <= 5);
                      nr6 = this.game.Data.RiverTypeObj[index68].LayerSpriteID[this.game.SPRITE64[numArray31[0], numArray31[1], numArray31[2], numArray31[3], numArray31[4], numArray31[5]]];
                    }
                    if (this.game.Data.RiverTypeObj[index68].UseSheet)
                    {
                      int sheetSpriteId = this.game.Data.RiverTypeObj[index68].SheetSpriteID;
                      int index70 = this.game.SPRITE64[numArray31[0], numArray31[1], numArray31[2], numArray31[3], numArray31[4], numArray31[5]];
                      ref Graphics local73 = ref toG;
                      bitmap1 = BitmapStore.GetBitmap(sheetSpriteId, Zoom);
                      ref Bitmap local74 = ref bitmap1;
                      rectangle2 = new Rectangle(this.game.SHEETX[index70] * num6, this.game.SHEETY[index70] * num7, num6, num7);
                      Rectangle srcrect = rectangle2;
                      rectangle1 = new Rectangle(tx, ty, num6, num7);
                      Rectangle destrect = rectangle1;
                      DrawMod.DrawSimplePart2(ref local73, ref local74, srcrect, destrect);
                    }
                    else
                    {
                      int num79 = (int) Math.Round((double) BitmapStore.GetWidth(nr6, Zoom) / (double) num6);
                      int num80 = 0;
                      if (!this.game.Data.RiverTypeObj[index68].snakeMode)
                      {
                        coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, index67 + 1);
                        if (num79 > 1)
                          num80 = !coordinate1.onmap ? new Random((int) Math.Round(a1)).Next(0, num79 - 1) : new Random((int) Math.Round(a1)).Next(0, num79 - 1);
                      }
                      else
                      {
                        index55 = index67 - 1;
                        int index71 = index67 + 1;
                        if (index55 < 0)
                          index55 = 5;
                        if (index71 > 5)
                          index71 = 0;
                        index8 = this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index55];
                        int num81 = this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index71];
                        if (index8 == index68 & num81 == index68)
                          num80 = 0;
                        if (index8 == index68 & num81 != index68)
                          num80 = 1;
                        if (index8 != index68 & num81 == index68)
                          num80 = 2;
                        if (index8 != index68 & num81 != index68)
                          num80 = 3;
                      }
                      ref Graphics local75 = ref toG;
                      bitmap1 = BitmapStore.GetBitmap(nr6, Zoom);
                      ref Bitmap local76 = ref bitmap1;
                      rectangle2 = new Rectangle(num80 * num6, 0, num6, num7);
                      Rectangle srcrect = rectangle2;
                      rectangle1 = new Rectangle(tx, ty, num6, num7);
                      Rectangle destrect = rectangle1;
                      DrawMod.DrawSimplePart2(ref local75, ref local76, srcrect, destrect);
                    }
                  }
                }
                ++index67;
              }
              while (index67 <= 5);
            }
            numArray32 = new int[7];
            numArray31 = new int[7];
            bool flag10 = false;
            if (index5 > -1)
            {
              if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_SeeNow(index5) > 0)
                flag10 = true;
            }
            else
              flag10 = true;
            if (!this.game.Data.FOWOn)
              flag10 = true;
            if (InfoMode)
              flag10 = false;
            if (flag10)
            {
              bool flag11 = false;
              int index72 = 0;
              do
              {
                if (this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index72] > -1 & numArray32[index72] == 0)
                {
                  int index73 = this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index72];
                  if (!this.game.Data.RoadTypeObj[index73].Transparent && !this.game.Data.RoadTypeObj[index73].SpecialLayer && this.game.Data.RoadTypeObj[index73].useCenter6 & !flag11)
                  {
                    flag11 = true;
                    int center6spriteId = this.game.Data.RoadTypeObj[index73].center6spriteId;
                    ref Graphics local77 = ref toG;
                    bitmap1 = BitmapStore.GetBitmap(center6spriteId, Zoom);
                    ref Bitmap local78 = ref bitmap1;
                    rectangle2 = new Rectangle(0, 0, num6, num7);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx, ty, num6, num7);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local77, ref local78, srcrect, destrect);
                  }
                }
                ++index72;
              }
              while (index72 <= 5);
              int index74 = 0;
              do
              {
                if (this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index74] > -1)
                {
                  int index75 = this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index74];
                  if (!this.game.Data.RoadTypeObj[index75].Transparent)
                  {
                    if (!this.game.Data.RoadTypeObj[index75].SpecialLayer)
                    {
                      int nr7 = this.game.Data.RoadTypeObj[index75].BasicSpriteID[index74];
                      int num82 = (int) Math.Round((double) BitmapStore.GetWidth(nr7, Zoom) / (double) num6);
                      int num83 = 0;
                      coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, index74 + 1);
                      if (num82 > 1)
                        num83 = !coordinate1.onmap ? new Random((int) Math.Round(a1)).Next(0, num82 - 1) : new Random((int) Math.Round(a1)).Next(0, num82 - 1);
                      ref Graphics local79 = ref toG;
                      bitmap1 = BitmapStore.GetBitmap(nr7, Zoom);
                      ref Bitmap local80 = ref bitmap1;
                      rectangle2 = new Rectangle(num83 * num6, 0, num6, num7);
                      Rectangle srcrect = rectangle2;
                      rectangle1 = new Rectangle(tx, ty, num6, num7);
                      Rectangle destrect = rectangle1;
                      DrawMod.DrawSimplePart2(ref local79, ref local80, srcrect, destrect);
                    }
                    else
                    {
                      if (this.game.Data.RoadTypeObj[index75].FirstDrawOther > -1)
                      {
                        int index76 = 0;
                        do
                        {
                          if (this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index76] == this.game.Data.RoadTypeObj[index75].FirstDrawOther)
                          {
                            numArray31[index76] = 1;
                            numArray32[index76] = 1;
                          }
                          else
                            numArray31[index76] = this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index76] <= -1 ? 0 : (!(this.game.Data.RoadTypeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index76]].Category == this.game.Data.RoadTypeObj[this.game.Data.RoadTypeObj[index75].FirstDrawOther].Category & this.game.Data.RoadTypeObj[this.game.Data.RoadTypeObj[index75].FirstDrawOther].Category > -1) ? 0 : 1);
                          ++index76;
                        }
                        while (index76 <= 5);
                        if (this.game.Data.RoadTypeObj[this.game.Data.RoadTypeObj[index75].FirstDrawOther].UseSheet)
                        {
                          int sheetSpriteId = this.game.Data.RoadTypeObj[this.game.Data.RoadTypeObj[index75].FirstDrawOther].SheetSpriteID;
                          int index77 = this.game.SPRITE64[numArray31[0], numArray31[1], numArray31[2], numArray31[3], numArray31[4], numArray31[5]];
                          ref Graphics local81 = ref toG;
                          bitmap1 = BitmapStore.GetBitmap(sheetSpriteId, Zoom);
                          ref Bitmap local82 = ref bitmap1;
                          rectangle2 = new Rectangle(this.game.SHEETX[index77] * num6, this.game.SHEETY[index77] * num7, num6, num7);
                          Rectangle srcrect = rectangle2;
                          rectangle1 = new Rectangle(tx, ty, num6, num7);
                          Rectangle destrect = rectangle1;
                          DrawMod.DrawSimplePart2(ref local81, ref local82, srcrect, destrect);
                        }
                        else
                        {
                          int nr8 = this.game.Data.RoadTypeObj[this.game.Data.RoadTypeObj[index75].FirstDrawOther].LayerSpriteID[this.game.SPRITE64[numArray31[0], numArray31[1], numArray31[2], numArray31[3], numArray31[4], numArray31[5]]];
                          int num84 = (int) Math.Round((double) BitmapStore.GetWidth(nr8, Zoom) / (double) num6);
                          int num85 = 0;
                          coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, index74 + 1);
                          if (num84 > 1)
                            num85 = !coordinate1.onmap ? new Random((int) Math.Round(a1)).Next(0, num84 - 1) : new Random((int) Math.Round(a1)).Next(0, num84 - 1);
                          ref Graphics local83 = ref toG;
                          bitmap1 = BitmapStore.GetBitmap(nr8, Zoom);
                          ref Bitmap local84 = ref bitmap1;
                          rectangle2 = new Rectangle(num85 * num6, 0, num6, num7);
                          Rectangle srcrect = rectangle2;
                          rectangle1 = new Rectangle(tx, ty, num6, num7);
                          Rectangle destrect = rectangle1;
                          DrawMod.DrawSimplePart2(ref local83, ref local84, srcrect, destrect);
                          numArray31 = new int[6];
                        }
                      }
                      int index78 = 0;
                      do
                      {
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index78] == this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index74])
                        {
                          numArray31[index78] = 1;
                          numArray32[index78] = 1;
                        }
                        else if (this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index78] > -1)
                        {
                          if (this.game.Data.RoadTypeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index78]].Category == this.game.Data.RoadTypeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index74]].Category & this.game.Data.RoadTypeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index74]].Category > -1)
                          {
                            numArray31[index78] = 1;
                            numArray32[index78] = 1;
                          }
                          else
                            numArray31[index78] = 0;
                        }
                        else
                          numArray31[index78] = 0;
                        ++index78;
                      }
                      while (index78 <= 5);
                      if (this.game.Data.RoadTypeObj[index75].UseSheet)
                      {
                        int sheetSpriteId = this.game.Data.RoadTypeObj[index75].SheetSpriteID;
                        int index79 = this.game.SPRITE64[numArray31[0], numArray31[1], numArray31[2], numArray31[3], numArray31[4], numArray31[5]];
                        ref Graphics local85 = ref toG;
                        bitmap1 = BitmapStore.GetBitmap(sheetSpriteId, Zoom);
                        ref Bitmap local86 = ref bitmap1;
                        rectangle2 = new Rectangle(this.game.SHEETX[index79] * num6, this.game.SHEETY[index79] * num7, num6, num7);
                        Rectangle srcrect = rectangle2;
                        rectangle1 = new Rectangle(tx, ty, num6, num7);
                        Rectangle destrect = rectangle1;
                        DrawMod.DrawSimplePart2(ref local85, ref local86, srcrect, destrect);
                      }
                      else
                      {
                        int nr9 = this.game.Data.RoadTypeObj[index75].LayerSpriteID[this.game.SPRITE64[numArray31[0], numArray31[1], numArray31[2], numArray31[3], numArray31[4], numArray31[5]]];
                        int num86 = (int) Math.Round((double) BitmapStore.GetWidth(nr9, Zoom) / (double) num6);
                        int num87 = 0;
                        coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, index74 + 1);
                        if (num86 > 1)
                          num87 = !coordinate1.onmap ? new Random((int) Math.Round(a1)).Next(0, num86 - 1) : new Random((int) Math.Round(a1)).Next(0, num86 - 1);
                        ref Graphics local87 = ref toG;
                        bitmap1 = BitmapStore.GetBitmap(nr9, Zoom);
                        ref Bitmap local88 = ref bitmap1;
                        rectangle2 = new Rectangle(num87 * num6, 0, num6, num7);
                        Rectangle srcrect = rectangle2;
                        rectangle1 = new Rectangle(tx, ty, num6, num7);
                        Rectangle destrect = rectangle1;
                        DrawMod.DrawSimplePart2(ref local87, ref local88, srcrect, destrect);
                      }
                    }
                  }
                }
                ++index74;
              }
              while (index74 <= 5);
            }
          }
          if ((double) this.game.Data.RuleVar[908] <= 0.0)
          {
            index63 = this.game.Data.MapObj[cmap].HexObj[cx, cy].LandscapeType;
            if (!this.game.EditObj.skipGfxDetail && this.game.AllowHeightMap & !(this.game.Data.LandscapeTypeObj[index63].IsSea & this.game.Data.LandscapeTypeObj[index63].Interior))
              this.DrawHeightMap(ref toG, cx, cy, cmap, tx, ty, Zoom, false, ref gBitmap);
          }
          if ((double) this.game.Data.RuleVar[32] > -1.0 & (double) this.game.Data.RuleVar[908] < 1.0)
          {
            numArray32 = new int[7];
            numArray31 = new int[7];
            bool flag12 = false;
            int index80 = 0;
            do
            {
              int index81 = this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index80];
              if (index81 > -1 & numArray32[index80] == 0 && !this.game.Data.RiverTypeObj[index81].Transparent)
              {
                if (index81 == 4 & !flag12)
                {
                  flag12 = true;
                  this.DrawCanyon(ref toG, cx, cy, cmap, tx, ty, Zoom, ref gBitmap);
                }
                if (this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index80] > -1 & !this.game.Data.RiverTypeObj[index81].SpecialLayer | this.game.Data.RiverTypeObj[index81].SpecialLayer)
                {
                  int nr10;
                  if (!this.game.Data.RiverTypeObj[index81].SpecialLayer)
                  {
                    nr10 = this.game.Data.RiverTypeObj[index81].BasicSpriteID[index80];
                  }
                  else
                  {
                    int index82 = 0;
                    do
                    {
                      if (this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index82] == this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index80])
                      {
                        numArray31[index82] = 1;
                        numArray32[index82] = 1;
                      }
                      else
                        numArray31[index82] = 0;
                      ++index82;
                    }
                    while (index82 <= 5);
                    nr10 = this.game.Data.RiverTypeObj[index81].LayerSpriteID[this.game.SPRITE64[numArray31[0], numArray31[1], numArray31[2], numArray31[3], numArray31[4], numArray31[5]]];
                  }
                  if (this.game.Data.RiverTypeObj[index81].UseSheet)
                  {
                    int sheetSpriteId = this.game.Data.RiverTypeObj[index81].SheetSpriteID;
                    int index83 = this.game.SPRITE64[numArray31[0], numArray31[1], numArray31[2], numArray31[3], numArray31[4], numArray31[5]];
                    ref Graphics local89 = ref toG;
                    bitmap1 = BitmapStore.GetBitmap(sheetSpriteId, Zoom);
                    ref Bitmap local90 = ref bitmap1;
                    rectangle2 = new Rectangle(this.game.SHEETX[index83] * num6, this.game.SHEETY[index83] * num7, num6, num7);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx, ty, num6, num7);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local89, ref local90, srcrect, destrect);
                  }
                  else
                  {
                    int num88 = (int) Math.Round((double) BitmapStore.GetWidth(nr10, Zoom) / (double) num6);
                    int num89 = 0;
                    if (!this.game.Data.RiverTypeObj[index81].snakeMode)
                    {
                      coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, index80 + 1);
                      if (num88 > 1)
                        num89 = !coordinate1.onmap ? new Random((int) Math.Round(a1)).Next(0, num88 - 1) : new Random((int) Math.Round(a1)).Next(0, num88 - 1);
                    }
                    else
                    {
                      index55 = index80 - 1;
                      int index84 = index80 + 1;
                      if (index55 < 0)
                        index55 = 5;
                      if (index84 > 5)
                        index84 = 0;
                      index8 = this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index55];
                      int num90 = this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index84];
                      if (index8 == index81 & num90 == index81)
                        num89 = 0;
                      if (index8 == index81 & num90 != index81)
                        num89 = 1;
                      if (index8 != index81 & num90 == index81)
                        num89 = 2;
                      if (index8 != index81 & num90 != index81)
                        num89 = 3;
                    }
                    ref Graphics local91 = ref toG;
                    bitmap1 = BitmapStore.GetBitmap(nr10, Zoom);
                    ref Bitmap local92 = ref bitmap1;
                    rectangle2 = new Rectangle(num89 * num6, 0, num6, num7);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx, ty, num6, num7);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local91, ref local92, srcrect, destrect);
                  }
                }
              }
              ++index80;
            }
            while (index80 <= 5);
          }
          if (index42 > -1)
          {
            int num91 = index42;
            for (int index85 = 0; index85 <= num91; ++index85)
            {
              if (numArray8[index85] < 1 & numArray9[index85] >= 899)
              {
                if (flagArray1[index85])
                {
                  int index86 = 0;
                  do
                  {
                    if (numArray12[index85, index86] > 0 && numArray9[index85] <= 900)
                    {
                      int num92 = (int) Math.Round((double) BitmapStore.GetWidth(numArray12[index85, index86], Zoom) / (double) num6);
                      int num93 = 0;
                      if (num92 > 1)
                      {
                        Random random = new Random((int) Math.Round(a1));
                        if (flagArray2[index85])
                          random = new Random((int) Math.Round(a2));
                        num93 = random.Next(0, num92 - 1);
                      }
                      ref Graphics local93 = ref toG;
                      bitmap1 = BitmapStore.GetBitmap(numArray12[index85, index86], Zoom);
                      ref Bitmap local94 = ref bitmap1;
                      rectangle2 = new Rectangle(num93 * num6, 0, num6, num7);
                      Rectangle srcrect = rectangle2;
                      rectangle1 = new Rectangle(tx, ty, num6, num7);
                      Rectangle destrect = rectangle1;
                      DrawMod.DrawSimplePart2(ref local93, ref local94, srcrect, destrect);
                    }
                    ++index86;
                  }
                  while (index86 <= 5);
                }
                else if (numArray9[index85] <= 900)
                {
                  if (numArray10[index85] > -1)
                  {
                    int nr11 = numArray10[index85];
                    int index87 = numArray11[index85];
                    ref Graphics local95 = ref toG;
                    bitmap1 = BitmapStore.GetBitmap(nr11, Zoom);
                    ref Bitmap local96 = ref bitmap1;
                    rectangle2 = new Rectangle(this.game.SHEETX[index87] * num6, this.game.SHEETY[index87] * num7, num6, num7);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx, ty, num6, num7);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local95, ref local96, srcrect, destrect);
                  }
                  else
                  {
                    int maxValue = (int) Math.Round((double) BitmapStore.GetWidth(numArray7[index85], Zoom) / (double) num6);
                    int num94 = 0;
                    if (maxValue > 1)
                    {
                      Random random = new Random((int) Math.Round(a1));
                      if (flagArray2[index85])
                        random = new Random((int) Math.Round(a2));
                      num94 = random.Next(0, maxValue);
                    }
                    if (this.game.Data.MapObj[cmap].HexObj[cx, cy].randomOverrule > 0)
                    {
                      if (this.game.Data.MapObj[cmap].HexObj[cx, cy].randomOverrule <= maxValue)
                      {
                        num94 = this.game.Data.MapObj[cmap].HexObj[cx, cy].randomOverrule - 1;
                      }
                      else
                      {
                        this.game.Data.MapObj[cmap].HexObj[cx, cy].randomOverrule = 1;
                        num94 = this.game.Data.MapObj[cmap].HexObj[cx, cy].randomOverrule - 1;
                      }
                    }
                    ref Graphics local97 = ref toG;
                    bitmap1 = BitmapStore.GetBitmap(numArray7[index85], Zoom);
                    ref Bitmap local98 = ref bitmap1;
                    rectangle2 = new Rectangle(num94 * num6, 0, num6, num7);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx, ty, num6, num7);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local97, ref local98, srcrect, destrect);
                  }
                }
              }
            }
          }
          if (index63 > -1 && this.game.Data.LandscapeTypeObj[index63].BasicSpriteCounter >= index64 && this.game.Data.LandscapeTypeObj[index63].PlotBeforeRiver[index64] && index64 > -1)
          {
            nr1 = this.game.Data.LandscapeTypeObj[index63].BasicSpriteID2[index64];
            int num95 = (int) Math.Round((double) BitmapStore.GetWidth(nr1, Zoom) / (double) num6);
            int num96 = 0;
            if (num95 > 1)
              num96 = new Random((int) Math.Round(a1)).Next(0, num95 - 1);
            ref Graphics local99 = ref toG;
            bitmap1 = BitmapStore.GetBitmap(nr1, Zoom);
            ref Bitmap local100 = ref bitmap1;
            rectangle2 = new Rectangle(num96 * num6, 0, num6, num7);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(tx, ty, num6, num7);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local99, ref local100, srcrect, destrect);
          }
          if ((double) this.game.Data.RuleVar[908] > 0.0)
          {
            int landscapeType2 = this.game.Data.MapObj[cmap].HexObj[cx, cy].LandscapeType;
            if (!this.game.EditObj.skipGfxDetail && this.game.AllowHeightMap)
              this.DrawHeightMap(ref toG, cx, cy, cmap, tx, ty, Zoom, false, ref gBitmap);
          }
          if (index42 > -1)
          {
            int num97 = index42;
            for (int index88 = 0; index88 <= num97; ++index88)
            {
              if (numArray8[index88] > 0)
              {
                if (flagArray1[index88])
                {
                  int index89 = 0;
                  do
                  {
                    if (numArray12[index88, index89] > 0 && numArray9[index88] <= 900)
                    {
                      int num98 = (int) Math.Round((double) BitmapStore.GetWidth(numArray12[index88, index89], Zoom) / (double) num6);
                      int num99 = 0;
                      if (num98 > 1)
                      {
                        Random random = new Random((int) Math.Round(a1));
                        if (flagArray2[index88])
                          random = new Random((int) Math.Round(a2));
                        num99 = random.Next(0, num98 - 1);
                      }
                      ref Graphics local101 = ref toG;
                      bitmap1 = BitmapStore.GetBitmap(numArray12[index88, index89], Zoom);
                      ref Bitmap local102 = ref bitmap1;
                      rectangle2 = new Rectangle(num99 * num6, 0, num6, num7);
                      Rectangle srcrect = rectangle2;
                      rectangle1 = new Rectangle(tx, ty, num6, num7);
                      Rectangle destrect = rectangle1;
                      DrawMod.DrawSimplePart2(ref local101, ref local102, srcrect, destrect);
                    }
                    ++index89;
                  }
                  while (index89 <= 5);
                }
                else if (numArray9[index88] <= 900)
                {
                  if (numArray10[index88] > -1)
                  {
                    int nr12 = numArray10[index88];
                    int index90 = numArray11[index88];
                    ref Graphics local103 = ref toG;
                    bitmap1 = BitmapStore.GetBitmap(nr12, Zoom);
                    ref Bitmap local104 = ref bitmap1;
                    rectangle2 = new Rectangle(this.game.SHEETX[index90] * num6, this.game.SHEETY[index90] * num7, num6, num7);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx, ty, num6, num7);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local103, ref local104, srcrect, destrect);
                  }
                  else
                  {
                    int maxValue = (int) Math.Round((double) BitmapStore.GetWidth(numArray7[index88], Zoom) / (double) num6);
                    int num100 = 0;
                    if (maxValue > 1)
                    {
                      Random random = new Random((int) Math.Round(a1));
                      if (flagArray2[index88])
                        random = new Random((int) Math.Round(a2));
                      num100 = random.Next(0, maxValue);
                    }
                    if (this.game.Data.MapObj[cmap].HexObj[cx, cy].randomOverrule > 0)
                    {
                      if (this.game.Data.MapObj[cmap].HexObj[cx, cy].randomOverrule <= maxValue)
                      {
                        num100 = this.game.Data.MapObj[cmap].HexObj[cx, cy].randomOverrule - 1;
                      }
                      else
                      {
                        this.game.Data.MapObj[cmap].HexObj[cx, cy].randomOverrule = 1;
                        num100 = this.game.Data.MapObj[cmap].HexObj[cx, cy].randomOverrule - 1;
                      }
                    }
                    ref Graphics local105 = ref toG;
                    bitmap1 = BitmapStore.GetBitmap(numArray7[index88], Zoom);
                    ref Bitmap local106 = ref bitmap1;
                    rectangle2 = new Rectangle(num100 * num6, 0, num6, num7);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx, ty, num6, num7);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local105, ref local106, srcrect, destrect);
                  }
                }
              }
            }
          }
          if ((double) this.game.Data.RuleVar[908] > 0.0)
          {
            numArray32 = new int[7];
            numArray31 = new int[7];
            bool flag13 = false;
            bool flag14 = false;
            int index91 = 0;
            do
            {
              int index92 = this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index91];
              if (index92 == -1)
              {
                int index93 = index91 + 1;
                if (index93 > 5)
                  index93 = 0;
                if (this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index93] == -1)
                {
                  if (index91 == 0)
                  {
                    index55 = 0;
                    index93 = 2;
                  }
                  if (index91 == 1)
                  {
                    index55 = 1;
                    index93 = 3;
                  }
                  if (index91 == 2)
                  {
                    index55 = 2;
                    index93 = 4;
                  }
                  if (index91 == 3)
                  {
                    index55 = 3;
                    index93 = 5;
                  }
                  if (index91 == 4)
                  {
                    index55 = 4;
                    index93 = 0;
                  }
                  if (index91 == 5)
                  {
                    index55 = 5;
                    index93 = 1;
                  }
                  coordinate1 = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, cmap, index55 + 1);
                  if (coordinate1.onmap)
                  {
                    index8 = this.game.Data.MapObj[cmap].HexObj[coordinate1.x, coordinate1.y].RiverType[index93];
                    if (index8 > -1)
                    {
                      if (!flag13)
                      {
                        flag13 = true;
                        this.DrawCanyon(ref toG, cx, cy, cmap, tx, ty, Zoom, ref gBitmap);
                      }
                      if (this.game.Data.RiverTypeObj[index8].snakeMode)
                      {
                        int nr13 = this.game.Data.RiverTypeObj[index8].BasicSpriteID[index91];
                        int num101 = 4;
                        ref Graphics local107 = ref toG;
                        bitmap1 = BitmapStore.GetBitmap(nr13, Zoom);
                        ref Bitmap local108 = ref bitmap1;
                        rectangle2 = new Rectangle(num101 * num6, 0, num6, num7);
                        Rectangle srcrect = rectangle2;
                        rectangle1 = new Rectangle(tx, ty, num6, num7);
                        Rectangle destrect = rectangle1;
                        DrawMod.DrawSimplePart2(ref local107, ref local108, srcrect, destrect);
                      }
                    }
                  }
                }
              }
              if (index92 > -1 & numArray32[index91] == 0 && !this.game.Data.RiverTypeObj[index92].Transparent)
              {
                if (index92 == 4 & !flag14)
                {
                  flag14 = true;
                  this.DrawCanyon(ref toG, cx, cy, cmap, tx, ty, Zoom, ref gBitmap);
                }
                if (this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index91] > -1 & !this.game.Data.RiverTypeObj[index92].SpecialLayer | this.game.Data.RiverTypeObj[index92].SpecialLayer)
                {
                  int nr14;
                  if (!this.game.Data.RiverTypeObj[index92].SpecialLayer)
                  {
                    nr14 = this.game.Data.RiverTypeObj[index92].BasicSpriteID[index91];
                  }
                  else
                  {
                    int index94 = 0;
                    do
                    {
                      if (this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index94] == this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index91])
                      {
                        numArray31[index94] = 1;
                        numArray32[index94] = 1;
                      }
                      else
                        numArray31[index94] = 0;
                      ++index94;
                    }
                    while (index94 <= 5);
                    nr14 = this.game.Data.RiverTypeObj[index92].LayerSpriteID[this.game.SPRITE64[numArray31[0], numArray31[1], numArray31[2], numArray31[3], numArray31[4], numArray31[5]]];
                  }
                  if (this.game.Data.RiverTypeObj[index92].UseSheet)
                  {
                    int sheetSpriteId = this.game.Data.RiverTypeObj[index92].SheetSpriteID;
                    int index95 = this.game.SPRITE64[numArray31[0], numArray31[1], numArray31[2], numArray31[3], numArray31[4], numArray31[5]];
                    ref Graphics local109 = ref toG;
                    bitmap1 = BitmapStore.GetBitmap(sheetSpriteId, Zoom);
                    ref Bitmap local110 = ref bitmap1;
                    rectangle2 = new Rectangle(this.game.SHEETX[index95] * num6, this.game.SHEETY[index95] * num7, num6, num7);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx, ty, num6, num7);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local109, ref local110, srcrect, destrect);
                  }
                  else
                  {
                    int num102 = (int) Math.Round((double) BitmapStore.GetWidth(nr14, Zoom) / (double) num6);
                    int num103 = 0;
                    if (!this.game.Data.RiverTypeObj[index92].snakeMode)
                    {
                      coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, index91 + 1);
                      if (num102 > 1)
                        num103 = !coordinate1.onmap ? new Random((int) Math.Round(a1)).Next(0, num102 - 1) : new Random((int) Math.Round(a1)).Next(0, num102 - 1);
                    }
                    else
                    {
                      index55 = index91 - 1;
                      int index96 = index91 + 1;
                      if (index55 < 0)
                        index55 = 5;
                      if (index96 > 5)
                        index96 = 0;
                      index8 = this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index55];
                      int num104 = this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index96];
                      if (index8 == index92 & num104 == index92)
                        num103 = 0;
                      if (index8 == index92 & num104 != index92)
                        num103 = 1;
                      if (index8 != index92 & num104 == index92)
                        num103 = 2;
                      if (index8 != index92 & num104 != index92)
                        num103 = 3;
                    }
                    ref Graphics local111 = ref toG;
                    bitmap1 = BitmapStore.GetBitmap(nr14, Zoom);
                    ref Bitmap local112 = ref bitmap1;
                    rectangle2 = new Rectangle(num103 * num6, 0, num6, num7);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx, ty, num6, num7);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local111, ref local112, srcrect, destrect);
                  }
                }
              }
              ++index91;
            }
            while (index91 <= 5);
          }
          if ((double) this.game.Data.RuleVar[32] > -1.0)
          {
            bool flag15 = false;
            if (index5 > -1)
            {
              if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_SeeNow(index5) > 0)
                flag15 = true;
              if (this.game.Data.MapObj[cmap].HexObj[cx, cy].MaxRecon > 0 & index5 == this.game.Data.Turn)
                flag15 = true;
            }
            else
              flag15 = true;
            if (!this.game.Data.FOWOn)
              flag15 = true;
            if (InfoMode)
              flag15 = false;
            if (flag15)
            {
              numArray32 = new int[7];
              numArray31 = new int[7];
              bool flag16 = false;
              int index97 = 0;
              do
              {
                if (this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index97] > -1 & numArray32[index97] == 0)
                {
                  int index98 = this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index97];
                  if (!this.game.Data.RoadTypeObj[index98].Transparent && !this.game.Data.RoadTypeObj[index98].SpecialLayer && this.game.Data.RoadTypeObj[index98].useCenter6 & !flag16)
                  {
                    flag16 = true;
                    int center6spriteId = this.game.Data.RoadTypeObj[index98].center6spriteId;
                    ref Graphics local113 = ref toG;
                    bitmap1 = BitmapStore.GetBitmap(center6spriteId, Zoom);
                    ref Bitmap local114 = ref bitmap1;
                    rectangle2 = new Rectangle(0, 0, num6, num7);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx, ty, num6, num7);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local113, ref local114, srcrect, destrect);
                  }
                }
                ++index97;
              }
              while (index97 <= 5);
              int index99 = 0;
              do
              {
                if (this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index99] > -1 & numArray32[index99] == 0)
                {
                  int index100 = this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index99];
                  if (!this.game.Data.RoadTypeObj[index100].Transparent)
                  {
                    if (!this.game.Data.RoadTypeObj[index100].SpecialLayer)
                    {
                      int nr15 = this.game.Data.RoadTypeObj[index100].BasicSpriteID[index99];
                      int num105 = (int) Math.Round((double) BitmapStore.GetWidth(nr15, Zoom) / (double) num6);
                      int num106 = 0;
                      coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, index99 + 1);
                      if (num105 > 1)
                        num106 = !coordinate1.onmap ? new Random((int) Math.Round(a1)).Next(0, num105 - 1) : new Random((int) Math.Round(a1)).Next(0, num105 - 1);
                      ref Graphics local115 = ref toG;
                      bitmap1 = BitmapStore.GetBitmap(nr15, Zoom);
                      ref Bitmap local116 = ref bitmap1;
                      rectangle2 = new Rectangle(num106 * num6, 0, num6, num7);
                      Rectangle srcrect = rectangle2;
                      rectangle1 = new Rectangle(tx, ty, num6, num7);
                      Rectangle destrect = rectangle1;
                      DrawMod.DrawSimplePart2(ref local115, ref local116, srcrect, destrect);
                    }
                    else
                    {
                      if (this.game.Data.RoadTypeObj[index100].FirstDrawOther > -1)
                      {
                        int index101 = 0;
                        do
                        {
                          numArray31[index101] = this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index101] != this.game.Data.RoadTypeObj[index100].FirstDrawOther ? (this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index101] != this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index99] ? (this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index101] <= -1 ? 0 : (!(this.game.Data.RoadTypeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index101]].Category == this.game.Data.RoadTypeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index99]].Category & this.game.Data.RoadTypeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index99]].Category > -1) ? (!(this.game.Data.RoadTypeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index101]].Category == this.game.Data.RoadTypeObj[this.game.Data.RoadTypeObj[index100].FirstDrawOther].Category & this.game.Data.RoadTypeObj[this.game.Data.RoadTypeObj[index100].FirstDrawOther].Category > -1) ? 0 : 1) : 1)) : 1) : 1;
                          ++index101;
                        }
                        while (index101 <= 5);
                        if (this.game.Data.RoadTypeObj[this.game.Data.RoadTypeObj[index100].FirstDrawOther].UseSheet)
                        {
                          int sheetSpriteId = this.game.Data.RoadTypeObj[this.game.Data.RoadTypeObj[index100].FirstDrawOther].SheetSpriteID;
                          int index102 = this.game.SPRITE64[numArray31[0], numArray31[1], numArray31[2], numArray31[3], numArray31[4], numArray31[5]];
                          ref Graphics local117 = ref toG;
                          bitmap1 = BitmapStore.GetBitmap(sheetSpriteId, Zoom);
                          ref Bitmap local118 = ref bitmap1;
                          rectangle2 = new Rectangle(this.game.SHEETX[index102] * num6, this.game.SHEETY[index102] * num7, num6, num7);
                          Rectangle srcrect = rectangle2;
                          rectangle1 = new Rectangle(tx, ty, num6, num7);
                          Rectangle destrect = rectangle1;
                          DrawMod.DrawSimplePart2(ref local117, ref local118, srcrect, destrect);
                        }
                        else
                        {
                          int nr16 = this.game.Data.RoadTypeObj[this.game.Data.RoadTypeObj[index100].FirstDrawOther].LayerSpriteID[this.game.SPRITE64[numArray31[0], numArray31[1], numArray31[2], numArray31[3], numArray31[4], numArray31[5]]];
                          int num107 = (int) Math.Round((double) BitmapStore.GetWidth(nr16, Zoom) / (double) num6);
                          int num108 = 0;
                          coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, index99 + 1);
                          if (num107 > 1)
                            num108 = !coordinate1.onmap ? new Random((int) Math.Round(a1)).Next(0, num107 - 1) : new Random((int) Math.Round(a1)).Next(0, num107 - 1);
                          ref Graphics local119 = ref toG;
                          bitmap1 = BitmapStore.GetBitmap(nr16, Zoom);
                          ref Bitmap local120 = ref bitmap1;
                          rectangle2 = new Rectangle(num108 * num6, 0, num6, num7);
                          Rectangle srcrect = rectangle2;
                          rectangle1 = new Rectangle(tx, ty, num6, num7);
                          Rectangle destrect = rectangle1;
                          DrawMod.DrawSimplePart2(ref local119, ref local120, srcrect, destrect);
                          numArray31 = new int[6];
                        }
                      }
                      int index103 = 0;
                      do
                      {
                        int index104 = this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index103];
                        if (index104 == this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index99])
                        {
                          numArray31[index103] = 1;
                          numArray32[index103] = 1;
                        }
                        else if (index104 == -1)
                          numArray31[index103] = 0;
                        else if (this.game.Data.RoadTypeObj[index104].FirstDrawOther == this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index99] & index99 > index103)
                        {
                          numArray31[index103] = 1;
                          numArray32[index103] = 1;
                        }
                        else if (index104 > -1)
                        {
                          if (this.game.Data.RoadTypeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index99]].Category == this.game.Data.RoadTypeObj[index104].Category & this.game.Data.RoadTypeObj[index104].Category > -1)
                          {
                            numArray31[index103] = 1;
                            numArray32[index103] = 1;
                          }
                          else
                            numArray31[index103] = 0;
                        }
                        else
                          numArray31[index103] = 0;
                        ++index103;
                      }
                      while (index103 <= 5);
                      if (this.game.Data.RoadTypeObj[index100].UseSheet)
                      {
                        int sheetSpriteId = this.game.Data.RoadTypeObj[index100].SheetSpriteID;
                        int index105 = this.game.SPRITE64[numArray31[0], numArray31[1], numArray31[2], numArray31[3], numArray31[4], numArray31[5]];
                        ref Graphics local121 = ref toG;
                        bitmap1 = BitmapStore.GetBitmap(sheetSpriteId, Zoom);
                        ref Bitmap local122 = ref bitmap1;
                        rectangle2 = new Rectangle(this.game.SHEETX[index105] * num6, this.game.SHEETY[index105] * num7, num6, num7);
                        Rectangle srcrect = rectangle2;
                        rectangle1 = new Rectangle(tx, ty, num6, num7);
                        Rectangle destrect = rectangle1;
                        DrawMod.DrawSimplePart2(ref local121, ref local122, srcrect, destrect);
                      }
                      else
                      {
                        int nr17 = this.game.Data.RoadTypeObj[index100].LayerSpriteID[this.game.SPRITE64[numArray31[0], numArray31[1], numArray31[2], numArray31[3], numArray31[4], numArray31[5]]];
                        int num109 = (int) Math.Round((double) BitmapStore.GetWidth(nr17, Zoom) / (double) num6);
                        int num110 = 0;
                        coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, index99 + 1);
                        if (num109 > 1)
                          num110 = !coordinate1.onmap ? new Random((int) Math.Round(a1)).Next(0, num109 - 1) : new Random((int) Math.Round(a1)).Next(0, num109 - 1);
                        ref Graphics local123 = ref toG;
                        bitmap1 = BitmapStore.GetBitmap(nr17, Zoom);
                        ref Bitmap local124 = ref bitmap1;
                        rectangle2 = new Rectangle(num110 * num6, 0, num6, num7);
                        Rectangle srcrect = rectangle2;
                        rectangle1 = new Rectangle(tx, ty, num6, num7);
                        Rectangle destrect = rectangle1;
                        DrawMod.DrawSimplePart2(ref local123, ref local124, srcrect, destrect);
                      }
                    }
                  }
                }
                ++index99;
              }
              while (index99 <= 5);
            }
          }
          index1 = 0;
          do
          {
            int index106 = index1 + 3;
            if (index106 > 5)
              index106 -= 6;
            coordinate1 = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, cmap, index1 + 1);
            bool flag17 = false;
            if (index5 > -1 && (double) this.game.Data.MapObj[cmap].HexObj[cx, cy].get_ReconPts(index5) >= (double) this.game.Data.RuleVar[8] | !this.game.Data.FOWOn)
              flag17 = true;
            if (this.game.EditObj.RealRound == 0 | !this.game.Data.FOWOn)
              flag17 = true;
            if (flag17 & !InfoMode)
            {
              bool flag18 = false;
              if (this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index1] > -1 && (double) this.game.Data.RiverTypeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index1]].BridgeCostModifier < 0.0)
                flag18 = true;
              if (!flag18)
              {
                if (this.game.Data.MapObj[cmap].HexObj[cx, cy].Bridge[index1])
                {
                  if (cx == 6 & cy == 11)
                    cx = cx;
                  int index107 = -1;
                  if (this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index1] > -1 && this.game.Data.RoadTypeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index1]].BridgeOverrule)
                    index107 = this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index1];
                  if (index107 > -1)
                  {
                    ref Graphics local125 = ref toG;
                    bitmap1 = BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[index107].BridgeOverruleSpriteID[index1], Zoom);
                    ref Bitmap local126 = ref bitmap1;
                    int x = tx;
                    int y = ty;
                    DrawMod.DrawSimple(ref local125, ref local126, x, y);
                    index1 = index1;
                  }
                  else
                  {
                    ref Graphics local127 = ref toG;
                    bitmap1 = BitmapStore.GetBitmap(this.game.Data.BridgeObj[0].BasicSpriteID[index1], Zoom);
                    ref Bitmap local128 = ref bitmap1;
                    int x1 = tx;
                    int y1 = ty;
                    DrawMod.DrawSimple(ref local127, ref local128, x1, y1);
                    if (coordinate1.onmap)
                    {
                      if (this.game.Data.BridgeObj[0].AlternateIfRoadType > -1 & this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index1] == this.game.Data.BridgeObj[0].AlternateIfRoadType)
                      {
                        if (this.game.Data.MapObj[coordinate1.map].HexObj[coordinate1.x, coordinate1.y].RoadType[index106] == this.game.Data.BridgeObj[0].AlternateIfRoadType)
                        {
                          ref Graphics local129 = ref toG;
                          bitmap1 = BitmapStore.GetBitmap(this.game.Data.BridgeObj[0].AlternateSpriteID[index1], Zoom);
                          ref Bitmap local130 = ref bitmap1;
                          int x2 = tx;
                          int y2 = ty;
                          DrawMod.DrawSimple(ref local129, ref local130, x2, y2);
                        }
                      }
                      else if (this.game.Data.BridgeObj[0].AlternateIfRoadType2 > -1 & this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index1] == this.game.Data.BridgeObj[0].AlternateIfRoadType2 && this.game.Data.MapObj[coordinate1.map].HexObj[coordinate1.x, coordinate1.y].RoadType[index106] == this.game.Data.BridgeObj[0].AlternateIfRoadType2)
                      {
                        ref Graphics local131 = ref toG;
                        bitmap1 = BitmapStore.GetBitmap(this.game.Data.BridgeObj[0].AlternateSpriteID[index1], Zoom);
                        ref Bitmap local132 = ref bitmap1;
                        int x3 = tx;
                        int y3 = ty;
                        DrawMod.DrawSimple(ref local131, ref local132, x3, y3);
                      }
                    }
                  }
                }
                if (this.game.Data.MapObj[cmap].HexObj[cx, cy].RoadType[index1] > -1 & this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index1] > -1 & !this.game.Data.MapObj[cmap].HexObj[cx, cy].Bridge[index1] && (double) this.game.Data.RuleVar[308] < 1.0)
                {
                  coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, index1 + 1);
                  if (coordinate1.onmap && this.game.Data.MapObj[cmap].HexObj[coordinate1.x, coordinate1.y].RoadType[this.game.HandyFunctionsObj.HexFacing(coordinate1.x, coordinate1.y, coordinate1.map, cx, cy, cmap) - 1] > -1 && (double) this.game.Data.RuleVar[32] > -1.0)
                  {
                    ref Graphics local133 = ref toG;
                    bitmap1 = BitmapStore.GetBitmap(this.game.NOBRIDGE[index1], Zoom);
                    ref Bitmap local134 = ref bitmap1;
                    int x = tx;
                    int y = ty;
                    DrawMod.DrawSimple(ref local133, ref local134, x, y);
                  }
                }
              }
            }
            ++index1;
          }
          while (index1 <= 5);
          index6 = this.game.Data.MapObj[cmap].HexObj[cx, cy].LandscapeType;
          int index108 = this.game.Data.MapObj[cmap].HexObj[cx, cy].SpriteNr;
          if (index5 > -1)
          {
            if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_SeeNow(index5) == 0)
              index6 = this.game.Data.MapObj[cmap].HexObj[cx, cy].get_LastLT(index5);
            if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_SeeNow(index5) == 0)
              index108 = this.game.Data.MapObj[cmap].HexObj[cx, cy].get_LastSpr(index5);
          }
          if (index6 > -1)
          {
            if (this.game.Data.LandscapeTypeObj[index6].BasicSpriteCounter >= index108)
            {
              if (this.game.Data.LandscapeTypeObj[index6].PlotLast[index108])
              {
                if (index108 > -1)
                {
                  nr1 = this.game.Data.LandscapeTypeObj[index6].BasicSpriteID2[index108];
                  int num111 = (int) Math.Round((double) BitmapStore.GetWidth(nr1, Zoom) / (double) num6);
                  int num112 = 0;
                  if (num111 > 1)
                    num112 = new Random((int) Math.Round(a1)).Next(0, num111 - 1);
                  ref Graphics local135 = ref toG;
                  bitmap1 = BitmapStore.GetBitmap(nr1, Zoom);
                  ref Bitmap local136 = ref bitmap1;
                  rectangle2 = new Rectangle(num112 * num6, 0, num6, num7);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, num6, num7);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local135, ref local136, srcrect, destrect);
                }
                else
                  nr1 = this.game.NOHEX;
              }
            }
            else
              nr1 = this.game.NOHEX;
          }
          else
            nr1 = this.game.NOHEX;
          if (this.game.AllowHeightMap && !this.game.EditObj.skipGfxDetail)
            this.DrawHeightMapLate(ref toG, cx, cy, cmap, tx, ty, Zoom);
          if (this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime == index5 & this.game.EditObj.RealRound > 0 & !flag1 && this.game.Data.MapObj[cmap].HexObj[cx, cy].Location > -1)
          {
            int hq1 = this.game.Data.LocObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].Location].HQ;
          }
          if ((double) this.game.Data.RuleVar[401] > 0.0 & this.game.Data.Round > 0 & !flag1 & !InfoMode)
          {
            int strId123slot = this.strId123slot;
            int strId143slot = this.strId143slot;
            int strId288slot = this.strId288slot;
            if (this.game.Data.TempString[742].Length > 0 & this.game.Data.TempString[743].Length > 0)
            {
              int idValue1 = (int) Math.Round(Conversion.Val(this.game.EventRelatedObj.CheckLibVarHex(cx, cy, this.game.Data.TempString[742], this.game.Data.TempString[743])));
              if (idValue1 > 0)
              {
                int num113 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[strId123slot].GetData(0, idValue1, 8)));
                index1 = 1;
                do
                {
                  coordinate2 = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, index1);
                  if (coordinate2.onmap)
                  {
                    bool flag19 = false;
                    if (index5 > -1)
                    {
                      if (this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].get_SeeNow(index5) > 0 | this.game.Data.MapObj[cmap].HexObj[cx, cy].get_SeeNow(index5) > 0 | !this.game.Data.FOWOn)
                        flag19 = true;
                    }
                    else if (!this.game.Data.FOWOn)
                      flag19 = true;
                    if (!flag19)
                    {
                      int index109 = (int) Math.Round(Conversion.Val(this.game.EventRelatedObj.CheckLibVarHex(coordinate2.x, coordinate2.y, this.game.Data.TempString[742], this.game.Data.TempString[743])));
                      if (index109 > 0 & index5 > -1)
                      {
                        index8 = this.cacheZoneRecon[this.game.Data.RegimeObj[index5].id, idValue1];
                        int num114 = this.cacheZoneRecon[this.game.Data.RegimeObj[index5].id, index109];
                        if (index8 > 0 | num114 > 0)
                          flag19 = true;
                      }
                    }
                    if (flag19)
                    {
                      if (this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime == this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime)
                      {
                        if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[coordinate2.map].HexObj[coordinate2.x, coordinate2.y].LandscapeType].BlackedOut && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].LandscapeType].IsSea == this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].LandscapeType].IsSea)
                        {
                          int idValue2 = (int) Math.Round(Conversion.Val(this.game.EventRelatedObj.CheckLibVarHex(coordinate2.x, coordinate2.y, this.game.Data.TempString[742], this.game.Data.TempString[743])));
                          int num115 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[strId123slot].GetData(0, idValue2, 8)));
                          if (idValue1 != idValue2)
                          {
                            if (this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime == index5)
                            {
                              ref Graphics local137 = ref toG;
                              bitmap1 = BitmapStore.GetBitmap(this.game.LIGHTZONEBORDER[index1 - 1], Zoom);
                              ref Bitmap local138 = ref bitmap1;
                              rectangle2 = new Rectangle(numArray13[index1], numArray14[index1], numArray15[index1], numArray16[index1]);
                              Rectangle srcrect = rectangle2;
                              rectangle1 = new Rectangle(tx + numArray13[index1], ty + numArray14[index1], numArray15[index1], numArray16[index1]);
                              Rectangle destrect = rectangle1;
                              DrawMod.DrawSimplePart2(ref local137, ref local138, srcrect, destrect);
                            }
                            else
                            {
                              ref Graphics local139 = ref toG;
                              bitmap1 = BitmapStore.GetBitmap(this.game.LIGHTZONEBORDER[index1 - 1], Zoom);
                              ref Bitmap local140 = ref bitmap1;
                              rectangle2 = new Rectangle(numArray13[index1], numArray14[index1], numArray15[index1], numArray16[index1]);
                              Rectangle srcrect = rectangle2;
                              rectangle1 = new Rectangle(tx + numArray13[index1], ty + numArray14[index1], numArray15[index1], numArray16[index1]);
                              Rectangle destrect = rectangle1;
                              DrawMod.DrawSimplePart2(ref local139, ref local140, srcrect, destrect);
                            }
                          }
                        }
                      }
                      else if (this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime > -1 & this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime > -1 && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[coordinate2.map].HexObj[coordinate2.x, coordinate2.y].LandscapeType].BlackedOut && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].LandscapeType].IsSea == this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].LandscapeType].IsSea)
                      {
                        int idValue3 = (int) Math.Round(Conversion.Val(this.game.EventRelatedObj.CheckLibVarHex(coordinate2.x, coordinate2.y, this.game.Data.TempString[742], this.game.Data.TempString[743])));
                        int num116 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[strId123slot].GetData(0, idValue3, 8)));
                        if (num113 == num116 & idValue1 != idValue3 && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[strId143slot].GetData(0, this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime].id, 1))) > 1 & (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[strId143slot].GetData(0, this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime].id, 1))) > 1)
                        {
                          ref Graphics local141 = ref toG;
                          bitmap1 = BitmapStore.GetBitmap(this.game.LIGHTZONEBORDER[index1 - 1], Zoom);
                          ref Bitmap local142 = ref bitmap1;
                          rectangle2 = new Rectangle(numArray13[index1], numArray14[index1], numArray15[index1], numArray16[index1]);
                          Rectangle srcrect = rectangle2;
                          rectangle1 = new Rectangle(tx + numArray13[index1], ty + numArray14[index1], numArray15[index1], numArray16[index1]);
                          Rectangle destrect = rectangle1;
                          DrawMod.DrawSimplePart2(ref local141, ref local142, srcrect, destrect);
                        }
                      }
                    }
                  }
                  ++index1;
                }
                while (index1 <= 6);
              }
            }
          }
          int num117 = 0;
          if (!InfoMode & index6 > -1)
          {
            if (!flag1)
            {
              if (!ispredrawing && !this.game.Data.LandscapeTypeObj[index6].IsSea)
              {
                index1 = 1;
                do
                {
                  coordinate2 = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, index1);
                  if (coordinate2.onmap && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].LandscapeType].IsSea)
                  {
                    if (this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime != this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime)
                      num117 = 1;
                    if (this.game.Data.ShrowdOn & this.game.EditObj.RealRound > 0 && this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].get_LastReg(index5) != this.game.Data.MapObj[cmap].HexObj[cx, cy].get_LastReg(index5))
                      num117 = 1;
                  }
                  ++index1;
                }
                while (index1 <= 6);
              }
            }
            else if (!this.game.Data.LandscapeTypeObj[index6].IsSea)
            {
              index1 = 1;
              do
              {
                coordinate2 = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, index1);
                if (coordinate2.onmap && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].LandscapeType].IsSea && this.game.EditObj.HisOwner[coordinate2.map].Value[coordinate2.x, coordinate2.y] != this.game.EditObj.HisOwner[cmap].Value[cx, cy])
                  num117 = 1;
                ++index1;
              }
              while (index1 <= 6);
            }
          }
          if (num117 == 1 & !InfoMode)
          {
            if (!flag1)
            {
              if (!this.game.Data.LandscapeTypeObj[index6].IsSea & !this.game.Data.LandscapeTypeObj[index6].BlackedOut)
              {
                int strId143slot = this.strId143slot;
                int strId275slot = this.strId275slot;
                int strId288slot = this.strId288slot;
                index1 = 1;
                do
                {
                  coordinate2 = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, index1);
                  if (coordinate2.onmap && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[coordinate2.map].HexObj[coordinate2.x, coordinate2.y].LandscapeType].BlackedOut && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].LandscapeType].IsSea)
                  {
                    bool flag20 = false;
                    if (index5 > -1)
                    {
                      if (this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].get_SeeNow(index5) > 0 | this.game.Data.MapObj[cmap].HexObj[cx, cy].get_SeeNow(index5) > 0 | !this.game.Data.FOWOn)
                        flag20 = true;
                    }
                    else if (!this.game.Data.FOWOn)
                      flag20 = true;
                    if (!flag20)
                    {
                      int index110 = (int) Math.Round(Conversion.Val(this.game.EventRelatedObj.CheckLibVarHex(cx, cy, this.game.Data.TempString[742], this.game.Data.TempString[743])));
                      int index111 = (int) Math.Round(Conversion.Val(this.game.EventRelatedObj.CheckLibVarHex(coordinate2.x, coordinate2.y, this.game.Data.TempString[742], this.game.Data.TempString[743])));
                      if (index111 > 0 & index5 > -1)
                      {
                        index8 = this.cacheZoneRecon[this.game.Data.RegimeObj[index5].id, index110];
                        int num118 = this.cacheZoneRecon[this.game.Data.RegimeObj[index5].id, index111];
                        if (index8 > 0 | num118 > 0)
                          flag20 = true;
                      }
                    }
                    if (flag20 && this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime != this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime && !(this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime == -1 | this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime == -1))
                    {
                      int regime1 = this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime;
                      int regime2 = this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime;
                      int num119 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[strId143slot].GetData(0, this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime].id, 1)));
                      int num120 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[strId143slot].GetData(0, this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime].id, 1)));
                      int num121 = this.cacheDipClear[this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime].id, this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime].id];
                      int num122 = this.cacheDipClear[this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime].id, this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime].id];
                      bool flag21 = true;
                      if (num119 == 1 & num120 == 1)
                        flag21 = false;
                      if (num119 > 1 & num121 > 0 | num121 > 1 & num122 > 0)
                        flag21 = false;
                      if (num120 > 1 & num119 == 1 & num121 > 0)
                        flag21 = false;
                      if (this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime == -1 | this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime == -1)
                      {
                        ref Graphics local143 = ref toG;
                        bitmap1 = BitmapStore.GetBitmap(this.game.BORDER[index1 - 1], Zoom);
                        ref Bitmap local144 = ref bitmap1;
                        int x = tx;
                        int y = ty;
                        DrawMod.DrawSimple(ref local143, ref local144, x, y);
                      }
                      else if (flag21 & index5 > -1 & (this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime == index5 | this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime == index5))
                      {
                        ref Graphics local145 = ref toG;
                        bitmap1 = BitmapStore.GetBitmap(this.game.BORDER[index1 - 1], Zoom);
                        ref Bitmap local146 = ref bitmap1;
                        rectangle2 = new Rectangle(numArray13[index1], numArray14[index1], numArray15[index1], numArray16[index1]);
                        Rectangle srcrect = rectangle2;
                        rectangle1 = new Rectangle(tx + numArray13[index1], ty + numArray14[index1], numArray15[index1], numArray16[index1]);
                        Rectangle destrect = rectangle1;
                        DrawMod.DrawSimplePart2(ref local145, ref local146, srcrect, destrect);
                      }
                      else
                      {
                        if (num119 == 4)
                          num121 = 0;
                        if (num120 == 4)
                          num122 = 0;
                        if (num119 > 1 & num121 < 1 & num120 > 1 & num122 < 1)
                        {
                          ref Graphics local147 = ref toG;
                          bitmap1 = BitmapStore.GetBitmap(this.game.LIGHTZONEBORDER[index1 - 1], Zoom);
                          ref Bitmap local148 = ref bitmap1;
                          rectangle2 = new Rectangle(numArray13[index1], numArray14[index1], numArray15[index1], numArray16[index1]);
                          Rectangle srcrect = rectangle2;
                          rectangle1 = new Rectangle(tx + numArray13[index1], ty + numArray14[index1], numArray15[index1], numArray16[index1]);
                          Rectangle destrect = rectangle1;
                          DrawMod.DrawSimplePart2(ref local147, ref local148, srcrect, destrect);
                        }
                        else if (index5 == -1)
                        {
                          ref Graphics local149 = ref toG;
                          bitmap1 = BitmapStore.GetBitmap(this.game.BORDER[index1 - 1], Zoom);
                          ref Bitmap local150 = ref bitmap1;
                          rectangle2 = new Rectangle(numArray13[index1], numArray14[index1], numArray15[index1], numArray16[index1]);
                          Rectangle srcrect = rectangle2;
                          rectangle1 = new Rectangle(tx + numArray13[index1], ty + numArray14[index1], numArray15[index1], numArray16[index1]);
                          Rectangle destrect = rectangle1;
                          DrawMod.DrawSimplePart2(ref local149, ref local150, srcrect, destrect);
                        }
                        else if (num119 > 1 & num121 < 1)
                        {
                          a3 = (float) ((double) this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime].Red / 512.0 - 0.9);
                          a4 = (float) ((double) this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime].Green / 512.0 - 0.9);
                          a5 = (float) ((double) this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime].Blue / 512.0 - 0.9);
                          ref Graphics local151 = ref toG;
                          bitmap1 = BitmapStore.GetBitmap(this.game.BORDER[index1 - 1], Zoom);
                          ref Bitmap local152 = ref bitmap1;
                          rectangle2 = new Rectangle(numArray13[index1], numArray14[index1], numArray15[index1], numArray16[index1]);
                          Rectangle srcrect = rectangle2;
                          rectangle1 = new Rectangle(tx + numArray13[index1], ty + numArray14[index1], numArray15[index1], numArray16[index1]);
                          Rectangle destrect = rectangle1;
                          double r = 1.0 + (double) a3;
                          double g = 1.0 + (double) a4;
                          double b = 1.0 + (double) a5;
                          bitmap4 = (Bitmap) null;
                          ref Bitmap local153 = ref bitmap4;
                          DrawMod.DrawSimplePart2ColouredNewFast(ref local151, ref local152, srcrect, destrect, (float) r, (float) g, (float) b, 0.45f, ref local153);
                        }
                        else if (num120 > 1 & num122 < 1)
                        {
                          a3 = (float) ((double) this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime].Red / 512.0 - 0.9);
                          a4 = (float) ((double) this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime].Green / 512.0 - 0.9);
                          a5 = (float) ((double) this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime].Blue / 512.0 - 0.9);
                          ref Graphics local154 = ref toG;
                          bitmap4 = BitmapStore.GetBitmap(this.game.BORDER[index1 - 1], Zoom);
                          ref Bitmap local155 = ref bitmap4;
                          rectangle2 = new Rectangle(numArray13[index1], numArray14[index1], numArray15[index1], numArray16[index1]);
                          Rectangle srcrect = rectangle2;
                          rectangle1 = new Rectangle(tx + numArray13[index1], ty + numArray14[index1], numArray15[index1], numArray16[index1]);
                          Rectangle destrect = rectangle1;
                          double r = 1.0 + (double) a3;
                          double g = 1.0 + (double) a4;
                          double b = 1.0 + (double) a5;
                          bitmap1 = (Bitmap) null;
                          ref Bitmap local156 = ref bitmap1;
                          DrawMod.DrawSimplePart2ColouredNewFast(ref local154, ref local155, srcrect, destrect, (float) r, (float) g, (float) b, 0.45f, ref local156);
                        }
                        else if (num119 == 1 & num120 > 1)
                        {
                          a3 = (float) ((double) this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime].Red / 512.0 - 0.9);
                          a4 = (float) ((double) this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime].Green / 512.0 - 0.9);
                          a5 = (float) ((double) this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime].Blue / 512.0 - 0.9);
                          ref Graphics local157 = ref toG;
                          bitmap4 = BitmapStore.GetBitmap(this.game.BORDER[index1 - 1], Zoom);
                          ref Bitmap local158 = ref bitmap4;
                          rectangle2 = new Rectangle(numArray13[index1], numArray14[index1], numArray15[index1], numArray16[index1]);
                          Rectangle srcrect = rectangle2;
                          rectangle1 = new Rectangle(tx + numArray13[index1], ty + numArray14[index1], numArray15[index1], numArray16[index1]);
                          Rectangle destrect = rectangle1;
                          double r = 1.0 + (double) a3;
                          double g = 1.0 + (double) a4;
                          double b = 1.0 + (double) a5;
                          bitmap1 = (Bitmap) null;
                          ref Bitmap local159 = ref bitmap1;
                          DrawMod.DrawSimplePart2ColouredNewFast(ref local157, ref local158, srcrect, destrect, (float) r, (float) g, (float) b, 0.45f, ref local159);
                        }
                        else if (num120 == 1 & num119 > 1)
                        {
                          a3 = (float) ((double) this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime].Red / 512.0 - 0.9);
                          a4 = (float) ((double) this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime].Green / 512.0 - 0.9);
                          a5 = (float) ((double) this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime].Blue / 512.0 - 0.9);
                          ref Graphics local160 = ref toG;
                          bitmap4 = BitmapStore.GetBitmap(this.game.BORDER[index1 - 1], Zoom);
                          ref Bitmap local161 = ref bitmap4;
                          rectangle2 = new Rectangle(numArray13[index1], numArray14[index1], numArray15[index1], numArray16[index1]);
                          Rectangle srcrect = rectangle2;
                          rectangle1 = new Rectangle(tx + numArray13[index1], ty + numArray14[index1], numArray15[index1], numArray16[index1]);
                          Rectangle destrect = rectangle1;
                          double r = 1.0 + (double) a3;
                          double g = 1.0 + (double) a4;
                          double b = 1.0 + (double) a5;
                          bitmap1 = (Bitmap) null;
                          ref Bitmap local162 = ref bitmap1;
                          DrawMod.DrawSimplePart2ColouredNewFast(ref local160, ref local161, srcrect, destrect, (float) r, (float) g, (float) b, 0.45f, ref local162);
                        }
                        else if (regime2 == index5 | regime1 < regime2 & regime1 != index5)
                        {
                          a3 = (float) ((double) this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime].Red / 512.0 - 0.9);
                          a4 = (float) ((double) this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime].Green / 512.0 - 0.9);
                          a5 = (float) ((double) this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].Regime].Blue / 512.0 - 0.9);
                          ref Graphics local163 = ref toG;
                          bitmap4 = BitmapStore.GetBitmap(this.game.BORDER[index1 - 1], Zoom);
                          ref Bitmap local164 = ref bitmap4;
                          rectangle2 = new Rectangle(numArray13[index1], numArray14[index1], numArray15[index1], numArray16[index1]);
                          Rectangle srcrect = rectangle2;
                          rectangle1 = new Rectangle(tx + numArray13[index1], ty + numArray14[index1], numArray15[index1], numArray16[index1]);
                          Rectangle destrect = rectangle1;
                          double r = 1.0 + (double) a3;
                          double g = 1.0 + (double) a4;
                          double b = 1.0 + (double) a5;
                          bitmap1 = (Bitmap) null;
                          ref Bitmap local165 = ref bitmap1;
                          DrawMod.DrawSimplePart2ColouredNewFast(ref local163, ref local164, srcrect, destrect, (float) r, (float) g, (float) b, 0.45f, ref local165);
                        }
                        else
                        {
                          a3 = (float) ((double) this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime].Red / 512.0 - 0.9);
                          a4 = (float) ((double) this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime].Green / 512.0 - 0.9);
                          a5 = (float) ((double) this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime].Blue / 512.0 - 0.9);
                          ref Graphics local166 = ref toG;
                          bitmap4 = BitmapStore.GetBitmap(this.game.BORDER[index1 - 1], Zoom);
                          ref Bitmap local167 = ref bitmap4;
                          rectangle2 = new Rectangle(numArray13[index1], numArray14[index1], numArray15[index1], numArray16[index1]);
                          Rectangle srcrect = rectangle2;
                          rectangle1 = new Rectangle(tx + numArray13[index1], ty + numArray14[index1], numArray15[index1], numArray16[index1]);
                          Rectangle destrect = rectangle1;
                          double r = 1.0 + (double) a3;
                          double g = 1.0 + (double) a4;
                          double b = 1.0 + (double) a5;
                          bitmap1 = (Bitmap) null;
                          ref Bitmap local168 = ref bitmap1;
                          DrawMod.DrawSimplePart2ColouredNewFast(ref local166, ref local167, srcrect, destrect, (float) r, (float) g, (float) b, 0.45f, ref local168);
                        }
                      }
                    }
                  }
                  ++index1;
                }
                while (index1 <= 6);
              }
            }
            else if (!this.game.Data.LandscapeTypeObj[index6].IsSea & !this.game.Data.LandscapeTypeObj[index6].BlackedOut)
            {
              index1 = 1;
              do
              {
                coordinate2 = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, index1);
                if (coordinate2.onmap && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[coordinate2.map].HexObj[coordinate2.x, coordinate2.y].LandscapeType].BlackedOut && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[cmap].HexObj[coordinate2.x, coordinate2.y].LandscapeType].IsSea && !this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.EditObj.HisOwner[cmap].Value[coordinate2.x, coordinate2.y], this.game.EditObj.HisOwner[cmap].Value[cx, cy]) && !(this.game.EditObj.HisOwner[cmap].Value[coordinate2.x, coordinate2.y] <= -1 & this.game.EditObj.HisOwner[cmap].Value[cx, cy] <= -1) && !(this.game.EditObj.HisOwner[cmap].Value[coordinate2.x, coordinate2.y] == -2 | this.game.EditObj.HisOwner[cmap].Value[cx, cy] == -2))
                {
                  ref Graphics local169 = ref toG;
                  Bitmap bitmap5 = BitmapStore.GetBitmap(this.game.BORDER[index1 - 1], Zoom);
                  ref Bitmap local170 = ref bitmap5;
                  int x = tx;
                  int y = ty;
                  DrawMod.DrawSimple(ref local169, ref local170, x, y);
                }
                ++index1;
              }
              while (index1 <= 6);
            }
          }
          if (index42 > -1)
          {
            int num123 = index42;
            for (index1 = 0; index1 <= num123; ++index1)
            {
              if (numArray9[index1] > 900)
              {
                int num124 = (int) Math.Round((double) BitmapStore.GetWidth(numArray7[index1], Zoom) / (double) num6);
                int num125 = 0;
                if (num124 > 1)
                {
                  Random random = new Random((int) Math.Round(a1));
                  if (flagArray2[index1])
                    random = new Random((int) Math.Round(a2));
                  num125 = random.Next(0, num124 - 1);
                }
                ref Graphics local171 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(numArray7[index1], Zoom);
                ref Bitmap local172 = ref bitmap4;
                rectangle2 = new Rectangle(num125 * num6, 0, num6, num7);
                Rectangle srcrect = rectangle2;
                rectangle1 = new Rectangle(tx, ty, num6, num7);
                Rectangle destrect = rectangle1;
                DrawMod.DrawSimplePart2(ref local171, ref local172, srcrect, destrect);
              }
            }
          }
          if (this.game.Data.MapObj[cmap].HexObj[cx, cy].Location > -1 & !InfoMode)
          {
            bool flag22 = false;
            if (index5 > -1)
            {
              if (!this.game.Data.FOWOn | this.game.Data.Turn == index5 & this.game.Data.MapObj[0].HexObj[cx, cy].MaxRecon > 0 & !flag1 | this.game.EditObj.RealRound < 1 | this.game.Data.MapObj[cmap].HexObj[cx, cy].get_SeeNow(index5) > 0)
                flag22 = true;
            }
            else
              flag22 = true;
            if (flag22)
            {
              int type = this.game.Data.LocObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].Location].Type;
              if (this.game.Data.MapObj[0].HexObj[cx, cy].Regime > -1 & this.game.Data.LocTypeObj[type].SmallGraphicSpecialMode == 1)
              {
                Color color = Color.FromArgb((int) byte.MaxValue, this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime].Red, this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime].Green, this.game.Data.RegimeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime].Blue);
                a3 = (float) ((int) color.R + 128) / 384f;
                a4 = (float) ((int) color.G + 128) / 384f;
                a5 = (float) ((int) color.B + 128) / 384f;
                int nr18 = this.game.Data.SmallPicNr[this.game.Data.LocTypeObj[type].SmallGraphic];
                if (nr18 > -1)
                {
                  ref Graphics local173 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(nr18, Zoom);
                  ref Bitmap local174 = ref bitmap4;
                  rectangle2 = new Rectangle(0, Math.Max(0, this.game.Data.LocTypeObj[type].SmallGraphicSpecialData) * num7, num6, num7);
                  Rectangle srcrect5 = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, num6, num7);
                  Rectangle destrect5 = rectangle1;
                  DrawMod.DrawSimplePart2(ref local173, ref local174, srcrect5, destrect5);
                  ref Graphics local175 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(nr18, Zoom);
                  ref Bitmap local176 = ref bitmap4;
                  rectangle2 = new Rectangle(num6, Math.Max(0, this.game.Data.LocTypeObj[type].SmallGraphicSpecialData) * num7, num6, num7);
                  Rectangle srcrect6 = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, num6, num7);
                  Rectangle destrect6 = rectangle1;
                  double r = (double) a3;
                  double g = (double) a4;
                  double b = (double) a5;
                  DrawMod.DrawSimplePart2ColouredNew(ref local175, ref local176, srcrect6, destrect6, (float) r, (float) g, (float) b, 1f);
                }
              }
              else if (this.game.Data.LocTypeObj[type].SmallGraphicSpecialMode == 1)
              {
                int nr19 = this.game.Data.SmallPicNr[this.game.Data.LocTypeObj[type].SmallGraphic];
                if (nr19 > -1)
                {
                  ref Graphics local177 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(nr19, Zoom);
                  ref Bitmap local178 = ref bitmap4;
                  rectangle2 = new Rectangle(0, Math.Max(0, this.game.Data.LocTypeObj[type].SmallGraphicSpecialData) * num7, num6, num7);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, num6, num7);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local177, ref local178, srcrect, destrect);
                }
              }
              else if (this.game.Data.LocTypeObj[type].SmallGraphic > -1)
              {
                int nr20 = this.game.Data.SmallPicNr[this.game.Data.LocTypeObj[type].SmallGraphic];
                if (nr20 > -1)
                {
                  ref Graphics local179 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(nr20, Zoom);
                  ref Bitmap local180 = ref bitmap4;
                  rectangle2 = new Rectangle(0, 0, num6, num7);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, num6, num7);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local179, ref local180, srcrect, destrect);
                }
              }
              else if (this.game.Data.LocTypeObj[type].ExtraGraphic > -1)
              {
                int extraGraphic = this.game.Data.LocTypeObj[type].ExtraGraphic;
                if (extraGraphic > -1)
                {
                  nr1 = this.game.NATO[extraGraphic];
                  ref Graphics local181 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(nr1, Zoom);
                  ref Bitmap local182 = ref bitmap4;
                  rectangle2 = new Rectangle(0, 0, num6, num7);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, num6, num7);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local181, ref local182, srcrect, destrect);
                }
              }
            }
          }
          bool flag23 = false;
          if (index5 > -1)
          {
            if (this.game.Data.MapObj[0].HexObj[cx, cy].get_SeeNow(index5) > 0 | !this.game.Data.FOWOn | this.game.Data.Turn == index5 & this.game.Data.MapObj[0].HexObj[cx, cy].MaxRecon > 0 & !flag1)
              flag23 = true;
          }
          else
            flag23 = true;
          if (InfoMode)
            flag23 = false;
          if (flag23)
          {
            int regime = this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime;
            if (regime > -1)
            {
              Color color = DrawMod.LightenColor(Color.FromArgb((int) byte.MaxValue, this.game.Data.RegimeObj[regime].Red, this.game.Data.RegimeObj[regime].Green, this.game.Data.RegimeObj[regime].Blue), 50);
              a3 = (float) ((int) color.R + 511) / 767f;
              a4 = (float) ((int) color.G + 511) / 767f;
              a5 = (float) ((int) color.B + 511) / 767f;
            }
            if (this.game.Data.MapObj[cmap].HexObj[cx, cy].SpecialType2 <= -1 && this.game.Data.MapObj[cmap].HexObj[cx, cy].SpecialSprite2 > -1)
            {
              nr1 = this.game.Data.SmallPicNr[this.game.Data.MapObj[cmap].HexObj[cx, cy].SpecialSprite2];
              int num126 = (int) Math.Round((double) BitmapStore.GetWidth(nr1, Zoom) / (double) num6);
              int num127 = 0;
              if (num126 > 1)
                num127 = new Random((int) Math.Round(a1)).Next(0, num126 - 1);
              if (BitmapStore.Getheight(nr1, Zoom) > num7)
              {
                if (this.game.Data.MapObj[0].HexObj[cx, cy].Location == -1)
                {
                  ref Graphics local183 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(nr1, Zoom);
                  ref Bitmap local184 = ref bitmap4;
                  rectangle2 = new Rectangle(num127 * num6, 0, num6, num7);
                  Rectangle srcrect7 = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, num6, num7);
                  Rectangle destrect7 = rectangle1;
                  DrawMod.DrawSimplePart2(ref local183, ref local184, srcrect7, destrect7);
                  ref Graphics local185 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(nr1, Zoom);
                  ref Bitmap local186 = ref bitmap4;
                  rectangle2 = new Rectangle(num127 * num6, num7, num6, num7);
                  Rectangle srcrect8 = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, num6, num7);
                  Rectangle destrect8 = rectangle1;
                  double r = (double) a3;
                  double g = (double) a4;
                  double b = (double) a5;
                  DrawMod.DrawSimplePart2ColouredNew(ref local185, ref local186, srcrect8, destrect8, (float) r, (float) g, (float) b, 1f);
                }
              }
              else
              {
                ref Graphics local187 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(nr1, Zoom);
                ref Bitmap local188 = ref bitmap4;
                rectangle2 = new Rectangle(num127 * num6, 0, num6, num7);
                Rectangle srcrect = rectangle2;
                rectangle1 = new Rectangle(tx, ty, num6, num7);
                Rectangle destrect = rectangle1;
                DrawMod.DrawSimplePart2(ref local187, ref local188, srcrect, destrect);
              }
            }
            if (this.game.Data.MapObj[cmap].HexObj[cx, cy].SpecialType3 <= -1 && this.game.Data.MapObj[cmap].HexObj[cx, cy].SpecialSprite3 > -1)
            {
              nr1 = this.game.Data.SmallPicNr[this.game.Data.MapObj[cmap].HexObj[cx, cy].SpecialSprite3];
              int num128 = (int) Math.Round((double) BitmapStore.GetWidth(nr1, Zoom) / (double) num6);
              int num129 = 0;
              if (num128 > 1)
                num129 = new Random((int) Math.Round(a1)).Next(0, num128 - 1);
              if (BitmapStore.Getheight(nr1, Zoom) > num7)
              {
                if (this.game.Data.MapObj[0].HexObj[cx, cy].Location == -1)
                {
                  ref Graphics local189 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(nr1, Zoom);
                  ref Bitmap local190 = ref bitmap4;
                  rectangle2 = new Rectangle(num129 * num6, 0, num6, num7);
                  Rectangle srcrect9 = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, num6, num7);
                  Rectangle destrect9 = rectangle1;
                  DrawMod.DrawSimplePart2(ref local189, ref local190, srcrect9, destrect9);
                  ref Graphics local191 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(nr1, Zoom);
                  ref Bitmap local192 = ref bitmap4;
                  rectangle2 = new Rectangle(num129 * num6, num7, num6, num7);
                  Rectangle srcrect10 = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, num6, num7);
                  Rectangle destrect10 = rectangle1;
                  double r = (double) a3;
                  double g = (double) a4;
                  double b = (double) a5;
                  DrawMod.DrawSimplePart2ColouredNew(ref local191, ref local192, srcrect10, destrect10, (float) r, (float) g, (float) b, 1f);
                }
              }
              else
              {
                ref Graphics local193 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(nr1, Zoom);
                ref Bitmap local194 = ref bitmap4;
                rectangle2 = new Rectangle(num129 * num6, 0, num6, num7);
                Rectangle srcrect = rectangle2;
                rectangle1 = new Rectangle(tx, ty, num6, num7);
                Rectangle destrect = rectangle1;
                DrawMod.DrawSimplePart2(ref local193, ref local194, srcrect, destrect);
              }
            }
            if (this.game.Data.MapObj[cmap].HexObj[cx, cy].SpecialType > -1)
            {
              if (this.game.Data.MapObj[cmap].HexObj[cx, cy].SpecialSprite > -1 && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].SpecialType].BasicSpriteCounter >= this.game.Data.MapObj[cmap].HexObj[cx, cy].SpecialSprite)
              {
                nr1 = this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].SpecialType].BasicSpriteID[this.game.Data.MapObj[cmap].HexObj[cx, cy].SpecialSprite];
                int num130 = (int) Math.Round((double) BitmapStore.GetWidth(nr1, Zoom) / (double) num6);
                int num131 = 0;
                if (num130 > 1)
                  num131 = new Random((int) Math.Round(a1)).Next(0, num130 - 1);
                if (BitmapStore.Getheight(nr1, Zoom) > num7)
                {
                  if (this.game.Data.MapObj[0].HexObj[cx, cy].Location == -1)
                  {
                    ref Graphics local195 = ref toG;
                    bitmap4 = BitmapStore.GetBitmap(nr1, Zoom);
                    ref Bitmap local196 = ref bitmap4;
                    rectangle2 = new Rectangle(num131 * num6, 0, num6, num7);
                    Rectangle srcrect11 = rectangle2;
                    rectangle1 = new Rectangle(tx, ty, num6, num7);
                    Rectangle destrect11 = rectangle1;
                    DrawMod.DrawSimplePart2(ref local195, ref local196, srcrect11, destrect11);
                    ref Graphics local197 = ref toG;
                    bitmap4 = BitmapStore.GetBitmap(nr1, Zoom);
                    ref Bitmap local198 = ref bitmap4;
                    rectangle2 = new Rectangle(num131 * num6, num7, num6, num7);
                    Rectangle srcrect12 = rectangle2;
                    rectangle1 = new Rectangle(tx, ty, num6, num7);
                    Rectangle destrect12 = rectangle1;
                    double r = (double) a3;
                    double g = (double) a4;
                    double b = (double) a5;
                    DrawMod.DrawSimplePart2ColouredNew(ref local197, ref local198, srcrect12, destrect12, (float) r, (float) g, (float) b, 1f);
                  }
                }
                else
                {
                  ref Graphics local199 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(nr1, Zoom);
                  ref Bitmap local200 = ref bitmap4;
                  rectangle2 = new Rectangle(num131 * num6, 0, num6, num7);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, num6, num7);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local199, ref local200, srcrect, destrect);
                }
              }
            }
            else if (this.game.Data.MapObj[cmap].HexObj[cx, cy].SpecialSprite > -1)
            {
              nr1 = this.game.Data.SmallPicNr[this.game.Data.MapObj[cmap].HexObj[cx, cy].SpecialSprite];
              int num132 = (int) Math.Round((double) BitmapStore.GetWidth(nr1, Zoom) / (double) num6);
              int num133 = 0;
              if (num132 > 1)
                num133 = new Random((int) Math.Round(a1)).Next(0, num132 - 1);
              if (BitmapStore.Getheight(nr1, Zoom) > num7)
              {
                ref Graphics local201 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(nr1, Zoom);
                ref Bitmap local202 = ref bitmap4;
                rectangle2 = new Rectangle(num133 * num6, 0, num6, num7);
                Rectangle srcrect13 = rectangle2;
                rectangle1 = new Rectangle(tx, ty, num6, num7);
                Rectangle destrect13 = rectangle1;
                DrawMod.DrawSimplePart2(ref local201, ref local202, srcrect13, destrect13);
                ref Graphics local203 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(nr1, Zoom);
                ref Bitmap local204 = ref bitmap4;
                rectangle2 = new Rectangle(num133 * num6, num7, num6, num7);
                Rectangle srcrect14 = rectangle2;
                rectangle1 = new Rectangle(tx, ty, num6, num7);
                Rectangle destrect14 = rectangle1;
                double r = (double) a3;
                double g = (double) a4;
                double b = (double) a5;
                DrawMod.DrawSimplePart2ColouredNew(ref local203, ref local204, srcrect14, destrect14, (float) r, (float) g, (float) b, 1f);
              }
              else
              {
                ref Graphics local205 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(nr1, Zoom);
                ref Bitmap local206 = ref bitmap4;
                rectangle2 = new Rectangle(num133 * num6, 0, num6, num7);
                Rectangle srcrect = rectangle2;
                rectangle1 = new Rectangle(tx, ty, num6, num7);
                Rectangle destrect = rectangle1;
                DrawMod.DrawSimplePart2(ref local205, ref local206, srcrect, destrect);
              }
            }
          }
          if (index5 > -1 & !InfoMode && this.game.Data.MapObj[0].HexObj[cx, cy].get_SeeNow(index5) > 0)
          {
            int cacheTad = this.cache_tad;
            if (this.game.Data.MapObj[cmap].HexObj[cx, cy].GetHexLibVarValue(cacheTad) > 0)
            {
              int cacheTat = this.cache_tat;
              int smallPic = this.game.Data.FindSmallPic(this.game.Data.MapObj[cmap].HexObj[cx, cy].GetHexLibVarValue(cacheTat) + 157, "SE_Graphics");
              ref Graphics local207 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[smallPic], Zoom);
              ref Bitmap local208 = ref bitmap4;
              int x = tx;
              int y = ty;
              DrawMod.DrawSimple(ref local207, ref local208, x, y);
            }
          }
          if (index5 > -1 && this.game.Data.MapObj[0].HexObj[cx, cy].get_SeeNow(index5) > 0 | index5 == this.game.Data.Turn & this.game.Data.MapObj[0].HexObj[cx, cy].MaxRecon > 0 & !flag1 && index5 > -1 & !InfoMode && this.game.Data.SmallPicNr[72] > 0 && this.game.Data.MapObj[0].HexObj[cx, cy].Location > -1 && this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[cx, cy].Location].tempAirfieldLevel > 0)
          {
            ref Graphics local209 = ref toG;
            bitmap4 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[72], Zoom);
            ref Bitmap local210 = ref bitmap4;
            int x = tx;
            int y = ty;
            DrawMod.DrawSimple(ref local209, ref local210, x, y);
          }
          if (!flag1 & !InfoMode)
          {
            int cacheRad = this.cache_rad;
            int hexLibVarValue = this.game.Data.MapObj[cmap].HexObj[cx, cy].GetHexLibVarValue(cacheRad);
            if (hexLibVarValue > 50 & (this.game.Data.MapObj[0].HexObj[cx, cy].MaxRecon > 0 | !this.game.Data.FOWOn))
            {
              int num134 = hexLibVarValue;
              int num135 = 0;
              if (num134 > 12800)
                num135 = 9;
              else if (num134 > 6400)
                num135 = 8;
              else if (num134 > 3200)
                num135 = 7;
              else if (num134 > 1600)
                num135 = 6;
              else if (num134 > 800)
                num135 = 5;
              else if (num134 > 400)
                num135 = 4;
              else if (num134 > 200)
                num135 = 3;
              else if (num134 > 100)
                num135 = 2;
              else if (num134 > 50)
                num135 = 1;
              int smallPic = this.game.Data.FindSmallPic(162, "SE_Graphics");
              int num136 = (int) Math.Round((double) num6 / 2.0 * (Math.Sqrt((double) hexLibVarValue / 2.0) / 40.0));
              if ((double) num136 > (double) num6 / 2.0)
                num136 = (int) Math.Round((double) num6 / 2.0);
              if ((double) num136 < (double) num6 / 8.0)
                num136 = (int) Math.Round((double) num6 / 8.0);
              int num137 = (int) Math.Round(((double) num6 / 2.0 - (double) num136) / 2.0);
              int num138 = (int) Math.Round((double) num6 / 2.0);
              int num139 = num138;
              if (num135 <= 2)
              {
                ref Graphics local211 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[smallPic], Zoom);
                ref Bitmap local212 = ref bitmap4;
                int x = tx + num137 + (int) Math.Round((double) num6 / 16.0);
                int y = ty + num137;
                int w = num136;
                int h = num136;
                int origw = num138;
                int origh = num139;
                DrawMod.DrawScaledColorized2(ref local211, ref local212, x, y, w, h, origw, origh, 0.5f, 1f, 0.5f, 1f);
              }
              else if (num135 == 3)
              {
                ref Graphics local213 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[smallPic], Zoom);
                ref Bitmap local214 = ref bitmap4;
                int x = tx + num137 + (int) Math.Round((double) num6 / 16.0);
                int y = ty + num137;
                int w = num136;
                int h = num136;
                int origw = num138;
                int origh = num139;
                DrawMod.DrawScaledColorized2(ref local213, ref local214, x, y, w, h, origw, origh, 1f, 1f, 0.5f, 1f);
              }
              else if (num135 == 4)
              {
                ref Graphics local215 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[smallPic], Zoom);
                ref Bitmap local216 = ref bitmap4;
                int x = tx + num137 + (int) Math.Round((double) num6 / 16.0);
                int y = ty + num137;
                int w = num136;
                int h = num136;
                int origw = num138;
                int origh = num139;
                DrawMod.DrawScaledColorized2(ref local215, ref local216, x, y, w, h, origw, origh, 0.5f, 1f, 1f, 1f);
              }
              else if (num135 == 5)
              {
                ref Graphics local217 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[smallPic], Zoom);
                ref Bitmap local218 = ref bitmap4;
                int x = tx + num137 + (int) Math.Round((double) num6 / 16.0);
                int y = ty + num137;
                int w = num136;
                int h = num136;
                int origw = num138;
                int origh = num139;
                DrawMod.DrawScaledColorized2(ref local217, ref local218, x, y, w, h, origw, origh, 1f, 0.5f, 1f, 1f);
              }
              else if (num135 == 6)
              {
                ref Graphics local219 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[smallPic], Zoom);
                ref Bitmap local220 = ref bitmap4;
                int x = tx + num137 + (int) Math.Round((double) num6 / 16.0);
                int y = ty + num137;
                int w = num136;
                int h = num136;
                int origw = num138;
                int origh = num139;
                DrawMod.DrawScaledColorized2(ref local219, ref local220, x, y, w, h, origw, origh, 1f, 0.35f, 0.35f, 1f);
              }
              else if (num135 >= 7)
              {
                ref Graphics local221 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[smallPic], Zoom);
                ref Bitmap local222 = ref bitmap4;
                int x = tx + num137 + (int) Math.Round((double) num6 / 16.0);
                int y = ty + num137;
                int w = num136;
                int h = num136;
                int origw = num138;
                int origh = num139;
                DrawMod.DrawScaledColorized2(ref local221, ref local222, x, y, w, h, origw, origh, 1.5f, 0.0f, 0.0f, 1f);
              }
              else if (num135 >= 99)
              {
                ref Graphics local223 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[smallPic], Zoom);
                ref Bitmap local224 = ref bitmap4;
                int x = tx + num137 + (int) Math.Round((double) num6 / 16.0);
                int y = ty + num137;
                int w = num136;
                int h = num136;
                DrawMod.DrawScaled(ref local223, ref local224, x, y, w, h, true);
              }
            }
          }
          if (!InfoMode)
          {
            if (this.game.EditObj.LayerSupplyOn & !this.game.EditObj.AIMoving)
            {
              if (this.game.EditObj.TempSup[cmap].Value[cx, cy] < 9999)
              {
                if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].LandscapeType].IsSea)
                {
                  if ((double) this.game.EditObj.TempSup[cmap].Value[cx, cy] > (double) this.game.Data.RuleVar[3])
                  {
                    ref Graphics local225 = ref toG;
                    bitmap4 = BitmapStore.GetBitmap(this.game.WHITEHEX, Zoom);
                    ref Bitmap local226 = ref bitmap4;
                    int x = tx;
                    int y = ty;
                    DrawMod.Draw(ref local225, ref local226, x, y, -1f, -1f, -1f, 0.2f);
                  }
                  else if (this.game.EditObj.TempSup[cmap].Value[cx, cy] != 0)
                  {
                    if ((double) this.game.EditObj.TempSup[cmap].Value[cx, cy] > (double) this.game.Data.RuleVar[53])
                    {
                      ref Graphics local227 = ref toG;
                      bitmap4 = BitmapStore.GetBitmap(this.game.WHITEHEX, Zoom);
                      ref Bitmap local228 = ref bitmap4;
                      int x = tx;
                      int y = ty;
                      double r = -0.5 * ((double) this.game.EditObj.TempSup[cmap].Value[cx, cy] / (double) this.game.Data.RuleVar[3]);
                      DrawMod.Draw(ref local227, ref local228, x, y, (float) r, -1f, -1f, 0.2f);
                    }
                    else if ((double) this.game.EditObj.TempSup[cmap].Value[cx, cy] > (double) this.game.Data.RuleVar[52])
                    {
                      ref Graphics local229 = ref toG;
                      bitmap4 = BitmapStore.GetBitmap(this.game.WHITEHEX, Zoom);
                      ref Bitmap local230 = ref bitmap4;
                      int x = tx;
                      int y = ty;
                      double g = -0.75 * ((double) this.game.EditObj.TempSup[cmap].Value[cx, cy] / (double) this.game.Data.RuleVar[3]);
                      double b = -0.75 * ((double) this.game.EditObj.TempSup[cmap].Value[cx, cy] / (double) this.game.Data.RuleVar[3]);
                      DrawMod.Draw(ref local229, ref local230, x, y, -1f, (float) g, (float) b, 0.2f);
                    }
                    else if ((double) this.game.EditObj.TempSup[cmap].Value[cx, cy] > (double) this.game.Data.RuleVar[51])
                    {
                      ref Graphics local231 = ref toG;
                      bitmap4 = BitmapStore.GetBitmap(this.game.WHITEHEX, Zoom);
                      ref Bitmap local232 = ref bitmap4;
                      int x = tx;
                      int y = ty;
                      double r = -0.75 * ((double) this.game.EditObj.TempSup[cmap].Value[cx, cy] / (double) this.game.Data.RuleVar[3]);
                      double g = -0.75 * ((double) this.game.EditObj.TempSup[cmap].Value[cx, cy] / (double) this.game.Data.RuleVar[3]);
                      DrawMod.Draw(ref local231, ref local232, x, y, (float) r, (float) g, -1f, 0.2f);
                    }
                    else
                    {
                      ref Graphics local233 = ref toG;
                      bitmap4 = BitmapStore.GetBitmap(this.game.WHITEHEX, Zoom);
                      ref Bitmap local234 = ref bitmap4;
                      int x = tx;
                      int y = ty;
                      double g = -0.75 * ((double) this.game.EditObj.TempSup[cmap].Value[cx, cy] / (double) this.game.Data.RuleVar[3]);
                      DrawMod.Draw(ref local233, ref local234, x, y, -1f, (float) g, -1f, 0.2f);
                    }
                  }
                  else
                  {
                    ref Graphics local235 = ref toG;
                    bitmap4 = BitmapStore.GetBitmap(this.game.WHITEHEX, Zoom);
                    ref Bitmap local236 = ref bitmap4;
                    int x = tx;
                    int y = ty;
                    DrawMod.Draw(ref local235, ref local236, x, y, 0.0f, 0.0f, 0.0f, 0.2f);
                  }
                }
                int num140;
                if (Information.IsNothing((object) this.game.EditObj.SupplyPath))
                  num140 = 0;
                else if (this.game.EditObj.SupplyPath.Exists(cx, cy, cmap))
                  num140 = 1;
                if (num140 == 1)
                {
                  coordinate1 = this.game.EditObj.TempSupCameFrom[cmap].Value[cx, cy];
                  switch (this.game.HandyFunctionsObj.HexFacing(cx, cy, cmap, coordinate1.x, coordinate1.y, coordinate1.map))
                  {
                    case 1:
                      ref Graphics local237 = ref toG;
                      bitmap4 = BitmapStore.GetBitmap(this.game.ATTACK0, Zoom);
                      ref Bitmap local238 = ref bitmap4;
                      int x4 = tx;
                      int y4 = ty;
                      DrawMod.DrawSimple(ref local237, ref local238, x4, y4);
                      break;
                    case 2:
                      ref Graphics local239 = ref toG;
                      bitmap4 = BitmapStore.GetBitmap(this.game.ATTACK1, Zoom);
                      ref Bitmap local240 = ref bitmap4;
                      int x5 = tx;
                      int y5 = ty;
                      DrawMod.DrawSimple(ref local239, ref local240, x5, y5);
                      break;
                    case 3:
                      ref Graphics local241 = ref toG;
                      bitmap4 = BitmapStore.GetBitmap(this.game.ATTACK2, Zoom);
                      ref Bitmap local242 = ref bitmap4;
                      int x6 = tx;
                      int y6 = ty;
                      DrawMod.DrawSimple(ref local241, ref local242, x6, y6);
                      break;
                    case 4:
                      ref Graphics local243 = ref toG;
                      bitmap4 = BitmapStore.GetBitmap(this.game.ATTACK3, Zoom);
                      ref Bitmap local244 = ref bitmap4;
                      int x7 = tx;
                      int y7 = ty;
                      DrawMod.DrawSimple(ref local243, ref local244, x7, y7);
                      break;
                    case 5:
                      ref Graphics local245 = ref toG;
                      bitmap4 = BitmapStore.GetBitmap(this.game.ATTACK4, Zoom);
                      ref Bitmap local246 = ref bitmap4;
                      int x8 = tx;
                      int y8 = ty;
                      DrawMod.DrawSimple(ref local245, ref local246, x8, y8);
                      break;
                    case 6:
                      ref Graphics local247 = ref toG;
                      bitmap4 = BitmapStore.GetBitmap(this.game.ATTACK5, Zoom);
                      ref Bitmap local248 = ref bitmap4;
                      int x9 = tx;
                      int y9 = ty;
                      DrawMod.DrawSimple(ref local247, ref local248, x9, y9);
                      break;
                  }
                }
              }
            }
            else if (this.game.EditObj.ShowTransfer & !this.game.EditObj.AIMoving)
            {
              if (this.game.EditObj.TempValue[cmap].Value[cx, cy] < 9999 & !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].LandscapeType].IsSea)
              {
                float num141 = this.game.Data.RuleVar[78] / this.game.Data.RuleVar[3];
                if (this.game.EditObj.TempValue[cmap].Value[cx, cy] > 0)
                {
                  if ((double) this.game.EditObj.TempValue[cmap].Value[cx, cy] > (double) this.game.Data.RuleVar[53] * (double) num141)
                  {
                    ref Graphics local249 = ref toG;
                    bitmap4 = BitmapStore.GetBitmap(this.game.WHITEHEX, Zoom);
                    ref Bitmap local250 = ref bitmap4;
                    int x = tx;
                    int y = ty;
                    double r = -0.5 * ((double) this.game.EditObj.TempValue[cmap].Value[cx, cy] / (double) this.game.Data.RuleVar[78]);
                    DrawMod.Draw(ref local249, ref local250, x, y, (float) r, -1f, -1f, 0.2f);
                  }
                  else if ((double) this.game.EditObj.TempValue[cmap].Value[cx, cy] > (double) this.game.Data.RuleVar[52] * (double) num141)
                  {
                    ref Graphics local251 = ref toG;
                    bitmap4 = BitmapStore.GetBitmap(this.game.WHITEHEX, Zoom);
                    ref Bitmap local252 = ref bitmap4;
                    int x = tx;
                    int y = ty;
                    double g = -0.75 * ((double) this.game.EditObj.TempValue[cmap].Value[cx, cy] / (double) this.game.Data.RuleVar[78]);
                    double b = -0.75 * ((double) this.game.EditObj.TempValue[cmap].Value[cx, cy] / (double) this.game.Data.RuleVar[78]);
                    DrawMod.Draw(ref local251, ref local252, x, y, -1f, (float) g, (float) b, 0.2f);
                  }
                  else if ((double) this.game.EditObj.TempValue[cmap].Value[cx, cy] > (double) this.game.Data.RuleVar[51] * (double) num141)
                  {
                    ref Graphics local253 = ref toG;
                    bitmap4 = BitmapStore.GetBitmap(this.game.WHITEHEX, Zoom);
                    ref Bitmap local254 = ref bitmap4;
                    int x = tx;
                    int y = ty;
                    double r = -0.75 * ((double) this.game.EditObj.TempValue[cmap].Value[cx, cy] / (double) this.game.Data.RuleVar[78]);
                    double g = -0.75 * ((double) this.game.EditObj.TempValue[cmap].Value[cx, cy] / (double) this.game.Data.RuleVar[78]);
                    DrawMod.Draw(ref local253, ref local254, x, y, (float) r, (float) g, -1f, 0.2f);
                  }
                  else
                  {
                    ref Graphics local255 = ref toG;
                    bitmap4 = BitmapStore.GetBitmap(this.game.WHITEHEX, Zoom);
                    ref Bitmap local256 = ref bitmap4;
                    int x = tx;
                    int y = ty;
                    double g = -0.75 * ((double) this.game.EditObj.TempValue[cmap].Value[cx, cy] / (double) this.game.Data.RuleVar[78]);
                    DrawMod.Draw(ref local255, ref local256, x, y, -1f, (float) g, -1f, 0.2f);
                  }
                }
                else
                {
                  ref Graphics local257 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(this.game.WHITEHEX, Zoom);
                  ref Bitmap local258 = ref bitmap4;
                  int x = tx;
                  int y = ty;
                  DrawMod.Draw(ref local257, ref local258, x, y, 0.0f, 0.0f, 0.0f, 0.2f);
                }
              }
            }
            else if (this.game.EditObj.ShowLISRange & !this.game.EditObj.AIMoving & !Information.IsNothing((object) this.game.EditObj.TempSup[0]))
            {
              if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[cx, cy].Regime))
              {
                int num142 = this.game.EditObj.TempSup[0].Value[cx, cy];
                int num143 = 50;
                if (num142 <= num143 * 1)
                {
                  ref Graphics local259 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(this.game.WHITEHEX, Zoom);
                  ref Bitmap local260 = ref bitmap4;
                  int x = tx;
                  int y = ty;
                  DrawMod.Draw(ref local259, ref local260, x, y, -1f, -0.0f, -1f, 0.1f);
                }
                else if ((double) num142 <= (double) num143 * 1.33)
                {
                  ref Graphics local261 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(this.game.WHITEHEX, Zoom);
                  ref Bitmap local262 = ref bitmap4;
                  int x = tx;
                  int y = ty;
                  DrawMod.Draw(ref local261, ref local262, x, y, -0.0f, -0.0f, -1f, 0.1f);
                }
                else if ((double) num142 <= (double) num143 * 1.66)
                {
                  ref Graphics local263 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(this.game.WHITEHEX, Zoom);
                  ref Bitmap local264 = ref bitmap4;
                  int x = tx;
                  int y = ty;
                  DrawMod.Draw(ref local263, ref local264, x, y, -1f, -0.0f, -0.0f, 0.1f);
                }
                else if (num142 <= num143 * 2)
                {
                  ref Graphics local265 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(this.game.WHITEHEX, Zoom);
                  ref Bitmap local266 = ref bitmap4;
                  int x = tx;
                  int y = ty;
                  DrawMod.Draw(ref local265, ref local266, x, y, 0.0f, -1f, -1f, 0.1f);
                }
                else
                {
                  ref Graphics local267 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(this.game.WHITEHEX, Zoom);
                  ref Bitmap local268 = ref bitmap4;
                  int x = tx;
                  int y = ty;
                  DrawMod.Draw(ref local267, ref local268, x, y, -1f, -1f, -1f, 0.1f);
                }
              }
            }
            else if (this.game.EditObj.UnitSelected > -1 & this.game.EditObj.ShowHQPower & !this.game.EditObj.AIMoving && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ & this.game.Data.Turn == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime && this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[cx, cy].Regime))
            {
              int num144 = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, 0, cx, cy, 0, (int) Math.Round((double) (this.game.Data.RuleVar[73] + (float) (int) Math.Round((double) (100f / this.game.Data.RuleVar[74])))));
              int num145;
              if ((double) num144 <= (double) this.game.Data.RuleVar[73])
              {
                num145 = 100;
              }
              else
              {
                num145 = (int) Math.Round(100.0 - (double) this.game.Data.RuleVar[74] * ((double) num144 - (double) this.game.Data.RuleVar[73]));
                if (0 > num145)
                  num145 = 0;
              }
              if (num145 >= 100)
              {
                ref Graphics local269 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.WHITEHEX, Zoom);
                ref Bitmap local270 = ref bitmap4;
                int x = tx;
                int y = ty;
                DrawMod.Draw(ref local269, ref local270, x, y, -1f, -0.0f, -1f, 0.2f);
              }
              else if (num145 >= 75)
              {
                ref Graphics local271 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.WHITEHEX, Zoom);
                ref Bitmap local272 = ref bitmap4;
                int x = tx;
                int y = ty;
                DrawMod.Draw(ref local271, ref local272, x, y, -0.0f, -0.0f, -1f, 0.2f);
              }
              else if (num145 >= 50)
              {
                ref Graphics local273 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.WHITEHEX, Zoom);
                ref Bitmap local274 = ref bitmap4;
                int x = tx;
                int y = ty;
                DrawMod.Draw(ref local273, ref local274, x, y, -1f, -0.0f, -0.0f, 0.2f);
              }
              else if (num145 >= 1)
              {
                ref Graphics local275 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.WHITEHEX, Zoom);
                ref Bitmap local276 = ref bitmap4;
                int x = tx;
                int y = ty;
                DrawMod.Draw(ref local275, ref local276, x, y, 0.0f, -1f, -1f, 0.2f);
              }
            }
          }
          int num146;
          if (!this.game.EditObj.AIMoving & !InfoMode && this.game.EditObj.LayerSupplyOn | !this.game.EditObj.LayerSupplyOn & !this.game.EditObj.HideAS && !flag1 & !ispredrawing & this.game.Data.Round > 0 && this.game.EditObj.Zoom > -1)
          {
            if ((double) this.game.Data.MapObj[cmap].HexObj[cx, cy].get_ReconPts(index5) >= (double) this.game.Data.RuleVar[8] | !this.game.Data.FOWOn && this.game.Data.MapObj[cmap].HexObj[cx, cy].DammageVisible > 0 && this.game.Data.MapObj[cmap].HexObj[cx, cy].DammageVisible > 999)
              num146 = 999;
            if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_SupplyLost(index5) > 0)
            {
              int Number = this.game.Data.MapObj[cmap].HexObj[cx, cy].get_SupplyLost(index5);
              if (Number > 999)
                Number = 999;
              if (Zoom == 0)
              {
                ref Graphics local277 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.REDOVAL);
                ref Bitmap local278 = ref bitmap4;
                int x = tx + 7;
                int y = ty + 3;
                DrawMod.Draw(ref local277, ref local278, x, y, 0.0f, 0.0f, 0.0f, 0.5f);
                DrawMod.DrawTextColouredMarc(ref toG, Conversion.Str((object) Number), new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 5, ty + 6, Color.White);
              }
              else
              {
                ref Graphics local279 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.REDOVAL);
                ref Bitmap local280 = ref bitmap4;
                int x = tx + 23;
                int y = ty + 3;
                DrawMod.Draw(ref local279, ref local280, x, y, 0.0f, 0.0f, 0.0f, 0.5f);
                DrawMod.DrawTextColouredMarc(ref toG, Conversion.Str((object) Number), new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 23, ty + 6, Color.White);
              }
            }
            if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_PowerPointsLost(index5) > 0)
            {
              int Number = this.game.Data.MapObj[cmap].HexObj[cx, cy].get_PowerPointsLost(index5);
              if (Number > 999)
                Number = 999;
              if (Zoom == 0)
              {
                ref Graphics local281 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.REDOVAL);
                ref Bitmap local282 = ref bitmap4;
                int x = tx + 35;
                int y = ty + 3;
                DrawMod.Draw(ref local281, ref local282, x, y, 0.0f, 0.0f, 0.0f, 0.5f);
                DrawMod.DrawTextColouredMarc(ref toG, Conversion.Str((object) Number), new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 33, ty + 6, Color.White);
              }
              else
              {
                ref Graphics local283 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.REDOVAL);
                ref Bitmap local284 = ref bitmap4;
                int x = tx + 82;
                int y = ty + 3;
                DrawMod.Draw(ref local283, ref local284, x, y, 0.0f, 0.0f, 0.0f, 0.5f);
                DrawMod.DrawTextColouredMarc(ref toG, Conversion.Str((object) Number), new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 80, ty + 6, Color.White);
              }
            }
            if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_SupplyKilled(index5) > 0)
            {
              int Number = this.game.Data.MapObj[cmap].HexObj[cx, cy].get_SupplyKilled(index5);
              if (Number > 999)
                Number = 999;
              if (Zoom == 0)
              {
                ref Graphics local285 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.BLUEOVAL);
                ref Bitmap local286 = ref bitmap4;
                int x = tx + 7;
                int y = ty + 23;
                DrawMod.Draw(ref local285, ref local286, x, y, 0.0f, 0.0f, 0.0f, 0.5f);
                DrawMod.DrawTextColouredMarc(ref toG, Conversion.Str((object) Number), new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 5, ty + 26, Color.White);
              }
              else
              {
                ref Graphics local287 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.BLUEOVAL);
                ref Bitmap local288 = ref bitmap4;
                int x = tx + 23;
                int y = ty + 70;
                DrawMod.Draw(ref local287, ref local288, x, y, 0.0f, 0.0f, 0.0f, 0.5f);
                DrawMod.DrawTextColouredMarc(ref toG, Conversion.Str((object) Number), new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 21, ty + 73, Color.White);
              }
            }
            if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_PowerPointsKilled(index5) > 0)
            {
              int Number = this.game.Data.MapObj[cmap].HexObj[cx, cy].get_PowerPointsKilled(index5);
              if (Number > 999)
                Number = 999;
              if (Zoom == 0)
              {
                ref Graphics local289 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.BROWNOVAL);
                ref Bitmap local290 = ref bitmap4;
                int x = tx + 35;
                int y = ty + 23;
                DrawMod.Draw(ref local289, ref local290, x, y, 0.0f, 0.0f, 0.0f, 0.5f);
                DrawMod.DrawTextColouredMarc(ref toG, Conversion.Str((object) Number), new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 33, ty + 24, Color.White);
              }
              else
              {
                ref Graphics local291 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.BROWNOVAL);
                ref Bitmap local292 = ref bitmap4;
                int x = tx + 82;
                int y = ty + 70;
                DrawMod.Draw(ref local291, ref local292, x, y, 0.0f, 0.0f, 0.0f, 0.5f);
                DrawMod.DrawTextColouredMarc(ref toG, Conversion.Str((object) Number), new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 80, ty + 71, Color.White);
              }
            }
            if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime, this.game.Data.Turn))
            {
              if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_BattlePenalty(index5) > 0)
              {
                if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_BattlePenalty(index5) > 999)
                  num146 = 999;
                if (Zoom == 0)
                  ;
              }
            }
            else if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_BattleStack(index5) > 0)
            {
              if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_BattleStack(index5) > 999)
                num146 = 999;
              if (Zoom == 0)
                ;
            }
          }
          if (this.game.Data.FOWOn & this.game.EditObj.RealRound > 0 & !InfoMode)
          {
            if (!flag1)
            {
              if (this.game.EditObj.PrefShowFOW)
              {
                if (this.game.Data.MapObj[cmap].HexObj[cx, cy].MaxRecon < 1)
                {
                  if (!NoShader)
                  {
                    ref Graphics local293 = ref toG;
                    bitmap4 = BitmapStore.GetBitmap(this.game.SHADEDHEX, Zoom);
                    ref Bitmap local294 = ref bitmap4;
                    int x = tx;
                    int y = ty;
                    DrawMod.DrawSimple(ref local293, ref local294, x, y);
                  }
                  num146 = 0;
                  int num147 = 0;
                  index1 = 0;
                  do
                  {
                    coordinate1 = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, cmap, index1 + 1);
                    if (!coordinate1.onmap)
                      numArray32[index1] = 0;
                    else if (this.game.Data.MapObj[coordinate1.map].HexObj[coordinate1.x, coordinate1.y].get_LastLT(this.game.Data.Turn) == -1)
                    {
                      numArray32[index1] = 1;
                      num147 = 1;
                    }
                    else
                      numArray32[index1] = 0;
                    ++index1;
                  }
                  while (index1 <= 5);
                  if (num147 == 1 & this.game.Data.ShrowdOn)
                  {
                    int shrowdsheet = this.game.SHROWDSHEET;
                    int index112 = this.game.SPRITE64[numArray32[0], numArray32[1], numArray32[2], numArray32[3], numArray32[4], numArray32[5]];
                    ref Graphics local295 = ref toG;
                    bitmap4 = BitmapStore.GetBitmap(shrowdsheet, Zoom);
                    ref Bitmap local296 = ref bitmap4;
                    rectangle2 = new Rectangle(this.game.SHEETX[index112] * num6, this.game.SHEETY[index112] * num7, num6, num7);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx, ty, num6, num7);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local295, ref local296, srcrect, destrect);
                  }
                }
                else
                {
                  int num148 = 0;
                  int num149 = 0;
                  index1 = 0;
                  do
                  {
                    coordinate1 = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, cmap, index1 + 1);
                    if (!coordinate1.onmap)
                    {
                      numArray31[index1] = 0;
                      numArray32[index1] = 0;
                    }
                    else
                    {
                      if (this.game.Data.MapObj[coordinate1.map].HexObj[coordinate1.x, coordinate1.y].MaxRecon < 1)
                      {
                        numArray31[index1] = 1;
                        num148 = 1;
                      }
                      else
                        numArray31[index1] = 0;
                      if (this.game.Data.MapObj[coordinate1.map].HexObj[coordinate1.x, coordinate1.y].get_LastLT(this.game.Data.Turn) == -1)
                      {
                        numArray32[index1] = 1;
                        num149 = 1;
                      }
                      else
                        numArray32[index1] = 0;
                    }
                    ++index1;
                  }
                  while (index1 <= 5);
                  if (num148 == 1 && !NoShader)
                  {
                    int fogsheet = this.game.FOGSHEET;
                    int index113 = this.game.SPRITE64[numArray31[0], numArray31[1], numArray31[2], numArray31[3], numArray31[4], numArray31[5]];
                    ref Graphics local297 = ref toG;
                    bitmap4 = BitmapStore.GetBitmap(fogsheet, Zoom);
                    ref Bitmap local298 = ref bitmap4;
                    rectangle2 = new Rectangle(this.game.SHEETX[index113] * num6, this.game.SHEETY[index113] * num7, num6, num7);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx, ty, num6, num7);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local297, ref local298, srcrect, destrect);
                  }
                  if (num149 == 1 & this.game.Data.ShrowdOn)
                  {
                    int shrowdsheet = this.game.SHROWDSHEET;
                    int index114 = this.game.SPRITE64[numArray32[0], numArray32[1], numArray32[2], numArray32[3], numArray32[4], numArray32[5]];
                    ref Graphics local299 = ref toG;
                    bitmap4 = BitmapStore.GetBitmap(shrowdsheet, Zoom);
                    ref Bitmap local300 = ref bitmap4;
                    rectangle2 = new Rectangle(this.game.SHEETX[index114] * num6, this.game.SHEETY[index114] * num7, num6, num7);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx, ty, num6, num7);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local299, ref local300, srcrect, destrect);
                  }
                }
              }
            }
            else if (flag1 && this.game.Data.ShrowdOn && this.game.Data.MapObj[0].HexObj[cx, cy].get_LastLT(index5) > -1)
            {
              int num150 = 0;
              index1 = 0;
              do
              {
                coordinate1 = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, cmap, index1 + 1);
                if (!coordinate1.onmap)
                  numArray32[index1] = 0;
                else if (this.game.Data.MapObj[coordinate1.map].HexObj[coordinate1.x, coordinate1.y].get_LastLT(index5) == -1)
                {
                  numArray32[index1] = 1;
                  num150 = 1;
                }
                else
                  numArray32[index1] = 0;
                ++index1;
              }
              while (index1 <= 5);
              if (num150 == 1 & this.game.Data.ShrowdOn)
              {
                int shrowdsheet = this.game.SHROWDSHEET;
                int index115 = this.game.SPRITE64[numArray32[0], numArray32[1], numArray32[2], numArray32[3], numArray32[4], numArray32[5]];
                ref Graphics local301 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(shrowdsheet, Zoom);
                ref Bitmap local302 = ref bitmap4;
                rectangle2 = new Rectangle(this.game.SHEETX[index115] * num6, this.game.SHEETY[index115] * num7, num6, num7);
                Rectangle srcrect = rectangle2;
                rectangle1 = new Rectangle(tx, ty, num6, num7);
                Rectangle destrect = rectangle1;
                DrawMod.DrawSimplePart2(ref local301, ref local302, srcrect, destrect);
              }
            }
          }
          string str;
          if (!ispredrawing & !InfoMode & this.game.EditObj.ShowLabel)
          {
            int num151 = 0;
            if (index5 > -1)
            {
              if (this.game.Data.MapObj[coordinate1.map].HexObj[cx, cy].Regime == index5)
                num151 = 1;
              if (this.game.Data.MapObj[coordinate1.map].HexObj[cx, cy].get_ReconPts(this.game.EditObj.RealTurn) >= 1)
                num151 = 1;
              if (this.game.Data.MapObj[coordinate1.map].HexObj[cx, cy].MaxRecon >= 1 & !flag1 & index5 == this.game.EditObj.RealTurn)
                num151 = 1;
            }
            else
              num151 = 1;
            if (!this.game.Data.ShrowdOn)
              num151 = 1;
            if (num151 == 1)
            {
              if (Strings.Len(this.game.Data.MapObj[cmap].HexObj[cx, cy].SmallLabel) > 0 & Zoom >= 0)
              {
                int num152 = (int) Math.Round(Math.Floor((double) this.game.Data.MapObj[cmap].HexObj[cx, cy].SmallLabelType / 10.0));
                int tcol = this.game.Data.MapObj[cmap].HexObj[cx, cy].SmallLabelType - num152 * 10;
                string[] strArray = this.game.Data.MapObj[cmap].HexObj[cx, cy].SmallLabel.ToUpper().Split(' ');
                str = "";
                int upperBound = strArray.GetUpperBound(0);
                for (int index116 = 0; index116 <= upperBound; ++index116)
                {
                  if (Zoom < 1 & strArray[index116].Length > 9)
                    strArray[index116] = Strings.Left(strArray[index116], 9);
                  if (Zoom == 1 & strArray[index116].Length > 11)
                    strArray[index116] = Strings.Left(strArray[index116], 11);
                  if ((num152 == 1 | num152 == 2) & Zoom < 1 & strArray[index116].Length > 7)
                    strArray[index116] = Strings.Left(strArray[index116], 7);
                  if (index116 > 0)
                    str += " ";
                  str += strArray[index116];
                }
                switch (num152)
                {
                  case 0:
                    switch (Zoom)
                    {
                      case 0:
                        DrawMod.DrawTextCenterSmallLabelMultiLine(ref toG, str, this.game.MarcFont11, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0), tcol);
                        break;
                      case 1:
                        DrawMod.DrawTextCenterSmallLabelMultiLine(ref toG, str, this.game.MarcFont7, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0), tcol);
                        break;
                    }
                    break;
                  case 1:
                    switch (Zoom)
                    {
                      case 0:
                        DrawMod.DrawTextCenterSmallLabelMultiLine(ref toG, str, this.game.MarcFont11, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 4.0), tcol);
                        break;
                      case 1:
                        DrawMod.DrawTextCenterSmallLabelMultiLine(ref toG, str, this.game.MarcFont7, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 4.0), tcol);
                        break;
                    }
                    break;
                  case 2:
                    switch (Zoom)
                    {
                      case 0:
                        DrawMod.DrawTextCenterSmallLabelMultiLine(ref toG, str, this.game.MarcFont11, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 * 0.75), tcol);
                        break;
                      case 1:
                        DrawMod.DrawTextCenterSmallLabelMultiLine(ref toG, str, this.game.MarcFont7, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 * 0.75), tcol);
                        break;
                    }
                    break;
                }
              }
              if (Strings.Len(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText1) > 0)
              {
                if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 <= 5)
                {
                  Color c = Color.Transparent;
                  if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 1)
                    c = Color.White;
                  if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 2)
                    c = Color.FromArgb((int) byte.MaxValue, 150, 200, (int) byte.MaxValue);
                  if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 3)
                    c = Color.Black;
                  if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 4)
                    c = Color.Red;
                  if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 5)
                    c = Color.Yellow;
                  if (Zoom == 0)
                  {
                    str = Strings.UCase(Strings.Left(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText1, 5));
                    if (Strings.Len(str) >= 1)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 1, 1), new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 7, ty + 6, c, true);
                    if (Strings.Len(str) >= 2)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 2, 1), new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 17, ty + 6, c, true);
                    if (Strings.Len(str) >= 3)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 3, 1), new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 27, ty + 6, c, true);
                    if (Strings.Len(str) >= 4)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 4, 1), new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 37, ty + 6, c, true);
                    if (Strings.Len(str) >= 5)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 5, 1), new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 48, ty + 6, c, true);
                  }
                  else if ((double) this.game.Data.RuleVar[352] == 0.0 & Zoom == 1)
                  {
                    index1 = 1;
                    do
                    {
                      str = Strings.UCase(Strings.Mid(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText1, index1, 1));
                      if (Strings.Len(str) >= 1)
                        DrawMod.DrawTextColouredConsoleCenter(ref toG, str, this.game.MarcFont1, tx + 13 + 10 + 21 * (index1 - 1), ty + 13, Color.Black);
                      if (Strings.Len(str) >= 1)
                        DrawMod.DrawTextColouredConsoleCenter(ref toG, str, this.game.MarcFont1, tx + 12 + 10 + 21 * (index1 - 1), ty + 12, c);
                      ++index1;
                    }
                    while (index1 <= 5);
                  }
                  else if (Zoom == -1)
                  {
                    str = Strings.UCase(Strings.Left(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText1, 5));
                    if (Strings.Len(str) >= 1)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 1, 1), new Font("Courier New", 9f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 2, ty + 0, c);
                    if (Strings.Len(str) >= 2)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 2, 1), new Font("Courier New", 9f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 7, ty + 0, c);
                    if (Strings.Len(str) >= 3)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 3, 1), new Font("Courier New", 9f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 12, ty + 0, c);
                    if (Strings.Len(str) >= 4)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 4, 1), new Font("Courier New", 9f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 17, ty + 0, c);
                    if (Strings.Len(str) >= 5)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 5, 1), new Font("Courier New", 9f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 22, ty + 0, c);
                  }
                }
                else
                {
                  switch (Zoom)
                  {
                    case -1:
                      if (Strings.Len(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText1) > 0)
                      {
                        str = Strings.UCase(Strings.Left(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText1, 1));
                        SizeF sizeF2 = toG.MeasureString(Strings.Left(str, 1), new Font("Arial Black", 12f, FontStyle.Bold, GraphicsUnit.Pixel));
                        Color c = Color.Transparent;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 6)
                          c = Color.White;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 7)
                          c = Color.FromArgb((int) byte.MaxValue, 150, 200, (int) byte.MaxValue);
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 8)
                          c = Color.Black;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 9)
                          c = Color.Red;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 10)
                          c = Color.Yellow;
                        if (Strings.Len(str) >= 1)
                        {
                          DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 1, 1), new Font("Arial Black", 12f, FontStyle.Bold, GraphicsUnit.Pixel), (int) Math.Round((double) ((float) (tx + 16) - sizeF2.Width / 2f)), ty - 3, c, true);
                          break;
                        }
                        break;
                      }
                      break;
                    case 0:
                      if (Strings.Len(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText1) > 0)
                      {
                        str = Strings.UCase(Strings.Left(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText1, 1));
                        SizeF sizeF3 = toG.MeasureString(Strings.Left(str, 1), new Font("Arial Black", 16f, FontStyle.Bold, GraphicsUnit.Pixel));
                        Color c = Color.Transparent;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 6)
                          c = Color.White;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 7)
                          c = Color.FromArgb((int) byte.MaxValue, 150, 200, (int) byte.MaxValue);
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 8)
                          c = Color.Black;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 9)
                          c = Color.Red;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 10)
                          c = Color.Yellow;
                        if (Strings.Len(str) >= 1)
                        {
                          DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 1, 1), new Font("Arial Black", 16f, FontStyle.Bold, GraphicsUnit.Pixel), (int) Math.Round((double) ((float) (tx + 32) - sizeF3.Width / 2f)), ty + 4, c, true);
                          break;
                        }
                        break;
                      }
                      break;
                    case 1:
                      if (Strings.Len(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText1) > 0)
                      {
                        str = Strings.UCase(Strings.Left(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText1, 1));
                        SizeF sizeF4 = toG.MeasureString(Strings.Left(str, 1), new Font("Arial Black", 32f, FontStyle.Bold, GraphicsUnit.Pixel));
                        Color c = Color.Transparent;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 6)
                          c = Color.White;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 7)
                          c = Color.FromArgb((int) byte.MaxValue, 150, 200, (int) byte.MaxValue);
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 8)
                          c = Color.Black;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 9)
                          c = Color.Red;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 10)
                          c = Color.Yellow;
                        if (Strings.Len(str) >= 1)
                        {
                          DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 1, 1), new Font("Arial Black", 32f, FontStyle.Bold, GraphicsUnit.Pixel), (int) Math.Round((double) ((float) (tx + 64) - sizeF4.Width / 2f)), ty + 8, c, true);
                          break;
                        }
                        break;
                      }
                      break;
                  }
                }
              }
              if (Strings.Len(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText2) > 0)
              {
                if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 <= 5)
                {
                  Color c = Color.Transparent;
                  if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 1)
                    c = Color.White;
                  if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 2)
                    c = Color.FromArgb((int) byte.MaxValue, 150, 200, (int) byte.MaxValue);
                  if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 3)
                    c = Color.Black;
                  if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 4)
                    c = Color.Red;
                  if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 5)
                    c = Color.Yellow;
                  if (Zoom == 0)
                  {
                    str = Strings.UCase(Strings.Left(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText2, 5));
                    if (Strings.Len(str) >= 1)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 1, 1), new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 7, ty + 30, c, true);
                    if (Strings.Len(str) >= 2)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 2, 1), new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 17, ty + 30, c, true);
                    if (Strings.Len(str) >= 3)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 3, 1), new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 27, ty + 30, c, true);
                    if (Strings.Len(str) >= 4)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 4, 1), new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 37, ty + 30, c, true);
                    if (Strings.Len(str) >= 5)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 5, 1), new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 48, ty + 30, c, true);
                  }
                  else if ((double) this.game.Data.RuleVar[352] == 0.0 & Zoom == 1)
                  {
                    index1 = 1;
                    do
                    {
                      str = Strings.UCase(Strings.Mid(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText2, index1, 1));
                      if (Strings.Len(str) >= 1)
                        DrawMod.DrawTextColouredConsoleCenter(ref toG, str, this.game.MarcFont1, tx + 14 + 20 * (index1 - 1) + 13, ty + 13 + 48, Color.Black);
                      if (Strings.Len(str) >= 1)
                        DrawMod.DrawTextColouredConsoleCenter(ref toG, str, this.game.MarcFont1, tx + 13 + 20 * (index1 - 1) + 13, ty + 12 + 48, c);
                      ++index1;
                    }
                    while (index1 <= 5);
                  }
                  else if (Zoom == -1)
                  {
                    str = Strings.UCase(Strings.Left(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText2, 5));
                    if (Strings.Len(str) >= 1)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 1, 1), new Font("Courier New", 9f, FontStyle.Regular, GraphicsUnit.Pixel), tx + 1, ty + 12, c);
                    if (Strings.Len(str) >= 2)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 2, 1), new Font("Courier New", 9f, FontStyle.Regular, GraphicsUnit.Pixel), tx + 6, ty + 12, c);
                    if (Strings.Len(str) >= 3)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 3, 1), new Font("Courier New", 9f, FontStyle.Regular, GraphicsUnit.Pixel), tx + 11, ty + 12, c);
                    if (Strings.Len(str) >= 4)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 4, 1), new Font("Courier New", 9f, FontStyle.Regular, GraphicsUnit.Pixel), tx + 16, ty + 12, c);
                    if (Strings.Len(str) >= 5)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 5, 1), new Font("Courier New", 9f, FontStyle.Regular, GraphicsUnit.Pixel), tx + 21, ty + 12, c);
                  }
                }
                else
                {
                  switch (Zoom)
                  {
                    case -1:
                      if (Strings.Len(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText2) > 0)
                      {
                        str = Strings.UCase(Strings.Left(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText2, 1));
                        SizeF sizeF5 = toG.MeasureString(Strings.Left(str, 1), new Font("Arial Black", 12f, FontStyle.Bold, GraphicsUnit.Pixel));
                        Color c = Color.Transparent;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 6)
                          c = Color.White;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 7)
                          c = Color.Blue;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 8)
                          c = Color.Black;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 9)
                          c = Color.Red;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 10)
                          c = Color.Yellow;
                        if (Strings.Len(str) >= 1)
                        {
                          DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 1, 1), new Font("Arial Black", 12f, FontStyle.Bold, GraphicsUnit.Pixel), (int) Math.Round((double) ((float) (tx + 16) - sizeF5.Width / 2f)), ty + 9, c, true);
                          break;
                        }
                        break;
                      }
                      break;
                    case 0:
                      if (Strings.Len(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText2) > 0)
                      {
                        str = Strings.UCase(Strings.Left(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText2, 1));
                        SizeF sizeF6 = toG.MeasureString(Strings.Left(str, 1), new Font("Arial Black", 16f, FontStyle.Bold, GraphicsUnit.Pixel));
                        Color c = Color.Transparent;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 6)
                          c = Color.White;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 7)
                          c = Color.Blue;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 8)
                          c = Color.Black;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 9)
                          c = Color.Red;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 10)
                          c = Color.Yellow;
                        if (Strings.Len(str) >= 1)
                        {
                          DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 1, 1), new Font("Arial Black", 16f, FontStyle.Bold, GraphicsUnit.Pixel), (int) Math.Round((double) ((float) (tx + 32) - sizeF6.Width / 2f)), ty + 28, c, true);
                          break;
                        }
                        break;
                      }
                      break;
                    case 1:
                      if (Strings.Len(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText2) > 0)
                      {
                        str = Strings.UCase(Strings.Left(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText2, 1));
                        SizeF sizeF7 = toG.MeasureString(Strings.Left(str, 1), new Font("Arial Black", 32f, FontStyle.Bold, GraphicsUnit.Pixel));
                        Color c = Color.Transparent;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 6)
                          c = Color.White;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 7)
                          c = Color.Blue;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 8)
                          c = Color.Black;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 9)
                          c = Color.Red;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 10)
                          c = Color.Yellow;
                        if (Strings.Len(str) >= 1)
                        {
                          DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 1, 1), new Font("Arial Black", 32f, FontStyle.Bold, GraphicsUnit.Pixel), (int) Math.Round((double) ((float) (tx + 64) - sizeF7.Width / 2f)), ty + 56, c, true);
                          break;
                        }
                        break;
                      }
                      break;
                  }
                }
              }
            }
          }
          if (!this.game.EditObj.AIMoving & !InfoMode && this.game.EditObj.LayerSupplyOn | !this.game.EditObj.LayerSupplyOn & !this.game.EditObj.HideAS && !flag1 & !ispredrawing & this.game.EditObj.RealRound > 0 & this.game.EditObj.Zoom > -1)
          {
            if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime, this.game.Data.Turn))
            {
              int num153 = 0;
              int regimeCounter = this.game.Data.RegimeCounter;
              for (int index117 = 0; index117 <= regimeCounter; ++index117)
              {
                int num154 = 0;
                if (this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, index117) && this.game.Data.MapObj[0].HexObj[cx, cy].get_ZocPts(index117) > 0 && this.game.HandyFunctionsObj.VisibleEnemyUnitsInOrAroundHEx(cx, cy, 0, this.game.Data.Turn))
                  num154 = (int) Math.Round((double) ((float) num154 + this.game.Data.RuleVar[323]));
                if (num154 > num153)
                  num153 = num154;
              }
              if (num153 > 0 | this.game.Data.MapObj[cmap].HexObj[cx, cy].get_BattlePenalty(index5) > 0 | this.game.Data.MapObj[cmap].HexObj[cx, cy].get_APPenalty(index5) > 0)
              {
                int Number = this.game.Data.MapObj[cmap].HexObj[cx, cy].get_BattlePenalty(index5) + this.game.Data.MapObj[cmap].HexObj[cx, cy].get_APPenalty(index5) + num153;
                if (Number > 999)
                  Number = 999;
                if (Zoom == 0)
                {
                  ref Graphics local303 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(this.game.BLACKBOX);
                  ref Bitmap local304 = ref bitmap4;
                  int x = tx + 22;
                  int y = ty + 23;
                  DrawMod.Draw(ref local303, ref local304, x, y, 0.0f, 0.0f, 0.0f, 0.3f);
                  DrawMod.DrawTextColouredMarc(ref toG, Conversion.Str((object) Number), new Font(this.game.FontCol.Families[1], 11f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 20, ty + 26, Color.FromArgb(180, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
                }
                else
                {
                  ref Graphics local305 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(this.game.BLACKBOX);
                  ref Bitmap local306 = ref bitmap4;
                  int x = tx + 54;
                  int y = ty + 70;
                  DrawMod.Draw(ref local305, ref local306, x, y, 0.0f, 0.0f, 0.0f, 0.3f);
                  DrawMod.DrawTextColouredMarc(ref toG, Conversion.Str((object) Number), new Font(this.game.FontCol.Families[1], 11f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 51, ty + 73, Color.FromArgb(180, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
                }
              }
            }
            else
            {
              if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_BattleStackArt(index5) > 0)
              {
                if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_BattleStackArt(index5) > 999)
                  num146 = 999;
                if (Zoom == 0)
                {
                  ref Graphics local307 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(this.game.BLACKOVAL);
                  ref Bitmap local308 = ref bitmap4;
                  int x = tx + 9;
                  int y = ty + 23;
                  DrawMod.Draw(ref local307, ref local308, x, y, 0.0f, 0.0f, 0.0f, 0.5f);
                  DrawMod.DrawTextColouredMarc(ref toG, "art", new Font(this.game.FontCol.Families[1], 11f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 11, ty + 26, Color.White);
                }
                else
                {
                  ref Graphics local309 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(this.game.BLACKOVAL);
                  ref Bitmap local310 = ref bitmap4;
                  int x = tx + 26;
                  int y = ty + 70;
                  DrawMod.Draw(ref local309, ref local310, x, y, 0.0f, 0.0f, 0.0f, 0.5f);
                  DrawMod.DrawTextColouredMarc(ref toG, "art", new Font(this.game.FontCol.Families[1], 11f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 28, ty + 73, Color.White);
                }
              }
              if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_BattleStackAir(index5) > 0)
              {
                if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_BattleStackAir(index5) > 999)
                  num146 = 999;
                if (Zoom == 0)
                {
                  ref Graphics local311 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(this.game.BLACKOVAL);
                  ref Bitmap local312 = ref bitmap4;
                  int x = tx + 29;
                  int y = ty + 23;
                  DrawMod.Draw(ref local311, ref local312, x, y, 0.0f, 0.0f, 0.0f, 0.5f);
                  DrawMod.DrawTextColouredMarc(ref toG, "air", new Font(this.game.FontCol.Families[1], 11f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 31, ty + 26, Color.White);
                }
                else
                {
                  ref Graphics local313 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(this.game.BLACKOVAL);
                  ref Bitmap local314 = ref bitmap4;
                  int x = tx + 82;
                  int y = ty + 70;
                  DrawMod.Draw(ref local313, ref local314, x, y, 0.0f, 0.0f, 0.0f, 0.5f);
                  DrawMod.DrawTextColouredMarc(ref toG, "air", new Font(this.game.FontCol.Families[1], 11f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 84, ty + 73, Color.White);
                }
              }
              if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_BattleStack(index5) > 0)
              {
                int Number = this.game.Data.MapObj[cmap].HexObj[cx, cy].get_BattleStack(index5);
                if (Number > 999)
                  Number = 999;
                if (Zoom == 0)
                {
                  ref Graphics local315 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(this.game.BLACKOVAL);
                  ref Bitmap local316 = ref bitmap4;
                  int x = tx + 22;
                  int y = ty + 23;
                  DrawMod.Draw(ref local315, ref local316, x, y, 0.0f, 0.0f, 0.0f, 0.5f);
                  DrawMod.DrawTextColouredMarc(ref toG, Conversion.Str((object) Number), new Font(this.game.FontCol.Families[1], 11f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 21, ty + 26, Color.White);
                }
                else
                {
                  ref Graphics local317 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(this.game.BLACKOVAL);
                  ref Bitmap local318 = ref bitmap4;
                  int x = tx + 54;
                  int y = ty + 70;
                  DrawMod.Draw(ref local317, ref local318, x, y, 0.0f, 0.0f, 0.0f, 0.5f);
                  DrawMod.DrawTextColouredMarc(ref toG, Conversion.Str((object) Number), new Font(this.game.FontCol.Families[1], 11f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 52, ty + 73, Color.White);
                }
              }
            }
          }
          int num155;
          if (!InfoMode && (double) this.game.Data.RuleVar[403] > 0.0 & !this.game.EditObj.AIMoving)
          {
            int num156 = 0;
            if (this.game.EditObj.layerLisAvailable)
              num156 = 1;
            if (this.game.EditObj.layerLisUsed)
              num156 = 2;
            if (this.game.EditObj.layerLisTotal)
              num156 = 3;
            if (this.game.EditObj.layerLisBottlenecks)
              num156 = 4;
            if (this.game.EditObj.layerLisPreview)
              num156 = 5;
            if (cx == 54 & cy == 36)
              cx = cx;
            if (num156 > 0)
            {
              int val1_1 = 0;
              int val1_2 = 0;
              int index118 = 0;
              do
              {
                int widdy1 = 0;
                int num157 = this.game.Data.MapObj[0].HexObj[cx, cy].LIStotalHistory[index118];
                num16 = 0;
                int widdy2 = 0;
                index9 = 0;
                index10 = 0;
                int widdy3 = 0;
                switch (num156)
                {
                  case 1:
                    int liSpoint = this.game.Data.MapObj[0].HexObj[cx, cy].LISpoints[index118];
                    if (index118 < 6)
                    {
                      if (this.game.Data.MapObj[0].HexObj[cx, cy].LISpoints[6] < liSpoint)
                        liSpoint = this.game.Data.MapObj[0].HexObj[cx, cy].LISpoints[6];
                      coordinate1 = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, index118 + 1);
                      if (coordinate1.onmap && this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[6] < liSpoint)
                        liSpoint = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[6];
                    }
                    if (num157 > 0)
                      val1_1 = Math.Max(val1_1, liSpoint);
                    if (index118 == 6 & liSpoint >= 0)
                      val1_1 = Math.Min(val1_1, liSpoint);
                    widdy1 = (int) Math.Round(Math.Sqrt(Math.Sqrt((double) liSpoint)));
                    break;
                  case 2:
                    int num158 = this.game.Data.MapObj[0].HexObj[cx, cy].LIShistory[index118];
                    if (num157 > 0)
                      val1_1 = Math.Max(val1_1, num158);
                    widdy1 = (int) Math.Round(Math.Sqrt(Math.Sqrt((double) num158)));
                    int d1 = this.game.Data.MapObj[0].HexObj[cx, cy].LISorganic[index118];
                    index10 = d1;
                    index9 = this.game.Data.MapObj[0].HexObj[cx, cy].LISorganicPercentage[index118];
                    widdy2 = (int) Math.Round(Math.Sqrt(Math.Sqrt((double) d1)));
                    break;
                  case 3:
                    int num159 = this.game.Data.MapObj[0].HexObj[cx, cy].LIStotalHistory[index118];
                    if (num157 > 0)
                      val1_1 = Math.Max(val1_1, num159);
                    widdy1 = (int) Math.Round(Math.Sqrt(Math.Sqrt((double) num159)));
                    break;
                  case 4:
                    int num160 = this.game.Data.MapObj[0].HexObj[cx, cy].LIStotalHistory[index118] - this.game.Data.MapObj[0].HexObj[cx, cy].LIShistory[index118];
                    if (index118 < 6)
                    {
                      int num161 = this.game.Data.MapObj[0].HexObj[cx, cy].LIStotalHistory[6] - this.game.Data.MapObj[0].HexObj[cx, cy].LIShistory[6];
                      if (num161 < num160)
                        num160 = num161;
                      coordinate1 = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, index118 + 1);
                      if (coordinate1.onmap)
                      {
                        int num162 = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LIStotalHistory[6] - this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LIShistory[6];
                        if (num162 < num160)
                          num160 = num162;
                      }
                    }
                    num16 = num157 <= 0 ? 0 : (int) Math.Round((double) (100 * num160) / (double) num157);
                    int num163 = this.game.Data.MapObj[0].HexObj[cx, cy].LIStotalHistory[index118];
                    if (num157 > 0)
                      val1_1 = Math.Max(val1_1, num163);
                    widdy1 = (int) Math.Round(Math.Sqrt(Math.Sqrt((double) num163)));
                    int d2 = this.game.Data.MapObj[0].HexObj[cx, cy].LISorganic[index118];
                    index9 = this.game.Data.MapObj[0].HexObj[cx, cy].LISorganicPercentage[6];
                    widdy2 = (int) Math.Round(Math.Sqrt(Math.Sqrt((double) d2)));
                    break;
                  case 5:
                    int val1_3 = this.game.Data.MapObj[0].HexObj[cx, cy].tempPreviewLIS[index118];
                    int val2 = val1_3;
                    if (index118 < 6)
                    {
                      if (this.game.Data.MapObj[0].HexObj[cx, cy].tempPreviewLIS[6] < val1_3)
                        val1_3 = this.game.Data.MapObj[0].HexObj[cx, cy].tempPreviewLIS[6];
                      coordinate1 = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, index118 + 1);
                      if (coordinate1.onmap)
                      {
                        if (this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].tempPreviewLIS[6] < val1_3)
                          val1_3 = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].tempPreviewLIS[6];
                        int index119 = index118 + 3;
                        if (index119 > 5)
                          index119 -= 6;
                        val2 = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].tempPreviewLIS[index119];
                      }
                    }
                    int num164 = Math.Min(val1_3, val2);
                    int num165 = num164;
                    if (num164 > 0)
                      val1_1 = Math.Max(val1_1, num165);
                    if (index118 == 6 & num165 >= 0)
                      val1_1 = Math.Min(val1_1, num165);
                    widdy1 = (int) Math.Round(Math.Sqrt(Math.Sqrt((double) num165)));
                    if (this.game.EditObj.layerLisOnlyAssetId > 0)
                    {
                      int num166 = this.game.Data.MapObj[0].HexObj[cx, cy].tempPreviewAssetLIS[index118];
                      if (index118 < 6 & !this.game.EditObj.layerLisOnlyAssetId_isSupplyBase)
                      {
                        if (this.game.Data.MapObj[0].HexObj[cx, cy].tempPreviewAssetLIS[6] < num166)
                          num166 = this.game.Data.MapObj[0].HexObj[cx, cy].tempPreviewAssetLIS[6];
                        coordinate1 = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, index118 + 1);
                        if (coordinate1.onmap && this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].tempPreviewAssetLIS[6] < num166)
                          num166 = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].tempPreviewAssetLIS[6];
                      }
                      if (num166 > 0)
                        val1_2 = Math.Max(val1_2, num166);
                      if (index118 == 6 & num166 >= 0)
                        val1_2 = Math.Min(val1_2, num166);
                      widdy3 = (int) Math.Round(Math.Sqrt(Math.Sqrt((double) num166)));
                      break;
                    }
                    break;
                }
                int num167;
                int num168;
                if (widdy1 > 0 | widdy2 > 0)
                {
                  if (this.game.EditObj.Zoom == 1)
                  {
                    widdy1 *= 2;
                    widdy2 *= 2;
                  }
                  if (this.game.EditObj.Zoom == -1)
                  {
                    widdy1 = (int) Math.Round(Math.Max(1.0, (double) widdy1 / 2.0));
                    widdy2 = (int) Math.Round(Math.Max(1.0, (double) widdy2 / 2.0));
                  }
                  int num169;
                  int num170;
                  int num171;
                  if ((num156 == 2 | num156 == 4) & widdy2 > 0)
                  {
                    if (index9 >= 100)
                    {
                      num169 = 0;
                      num170 = (int) byte.MaxValue;
                      num171 = 0;
                    }
                    else if (index9 >= 76)
                    {
                      num169 = 225;
                      num170 = 225;
                      num171 = 0;
                    }
                    else if (index9 >= 51)
                    {
                      num169 = 0;
                      num170 = 200;
                      num171 = (int) byte.MaxValue;
                    }
                    else if (index9 >= 26)
                    {
                      num169 = (int) byte.MaxValue;
                      num170 = 0;
                      num171 = 0;
                    }
                    else
                    {
                      num169 = 0;
                      num170 = 0;
                      num171 = 0;
                    }
                  }
                  if (num156 == 4)
                  {
                    if (num16 >= 76)
                    {
                      a3 = 0.0f;
                      a4 = (float) byte.MaxValue;
                      a5 = 0.0f;
                    }
                    if (num16 < 76 & num16 >= 51)
                    {
                      a3 = 225f;
                      a4 = 225f;
                      a5 = 0.0f;
                    }
                    if (num16 <= 50 & num16 >= 26)
                    {
                      a3 = 0.0f;
                      a4 = 200f;
                      a5 = (float) byte.MaxValue;
                    }
                    if (num16 <= 25 & num16 >= 1)
                    {
                      a3 = (float) byte.MaxValue;
                      a4 = 0.0f;
                      a5 = 0.0f;
                    }
                    if (num16 <= 0)
                    {
                      a3 = 0.0f;
                      a4 = 0.0f;
                      a5 = 0.0f;
                    }
                    widdy2 = 2;
                  }
                  if (num156 == 1)
                  {
                    a3 = 0.0f;
                    a4 = 200f;
                    a5 = 0.0f;
                    if (index118 < 6 && val1_1 < this.game.Data.MapObj[0].HexObj[cx, cy].LISpoints[6])
                    {
                      coordinate1 = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, index118 + 1);
                      if (val1_1 < this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[6])
                      {
                        a3 = 180f;
                        a4 = 180f;
                        a5 = 0.0f;
                        if (Zoom == 1)
                        {
                          if (index118 == 0)
                            DrawMod.DrawTextCenterSmallLabel(ref toG, val1_1.ToString(), this.game.MarcFont4, tx + (int) Math.Round((double) num6 / 2.0), ty + 14, 4);
                          if (index118 == 1)
                            DrawMod.DrawTextCenterSmallLabel(ref toG, val1_1.ToString(), this.game.MarcFont4, tx + (int) Math.Round((double) (num6 * 2) / 3.0), ty + 24, 4);
                          if (index118 == 2)
                            DrawMod.DrawTextCenterSmallLabel(ref toG, val1_1.ToString(), this.game.MarcFont4, tx + (int) Math.Round((double) (num6 * 3) / 4.0) + 4, ty + 50, 4);
                          if (index118 == 3)
                            DrawMod.DrawTextCenterSmallLabel(ref toG, val1_1.ToString(), this.game.MarcFont4, tx + (int) Math.Round((double) num6 / 2.0), ty + 82, 4);
                          if (index118 == 4)
                            DrawMod.DrawTextCenterSmallLabel(ref toG, val1_1.ToString(), this.game.MarcFont4, tx + (int) Math.Round((double) num6 / 4.0) - 4, ty + 50, 4);
                          if (index118 == 5)
                            DrawMod.DrawTextCenterSmallLabel(ref toG, val1_1.ToString(), this.game.MarcFont4, tx + (int) Math.Round((double) num6 / 3.0), ty + 24, 4);
                        }
                      }
                    }
                  }
                  if (num156 == 3)
                  {
                    a3 = 50f;
                    a4 = 50f;
                    a5 = 50f;
                    if (index118 < 6 && val1_1 < this.game.Data.MapObj[0].HexObj[cx, cy].LIStotalHistory[6])
                    {
                      coordinate1 = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, index118 + 1);
                      if (val1_1 < this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LIStotalHistory[6])
                      {
                        a3 = 100f;
                        a4 = 100f;
                        a5 = 0.0f;
                        if (Zoom == 1)
                        {
                          if (index118 == 0)
                            DrawMod.DrawTextCenterSmallLabel(ref toG, val1_1.ToString(), this.game.MarcFont4, tx + (int) Math.Round((double) num6 / 2.0), ty + 14, 4);
                          if (index118 == 1)
                            DrawMod.DrawTextCenterSmallLabel(ref toG, val1_1.ToString(), this.game.MarcFont4, tx + (int) Math.Round((double) (num6 * 2) / 3.0), ty + 24, 4);
                          if (index118 == 2)
                            DrawMod.DrawTextCenterSmallLabel(ref toG, val1_1.ToString(), this.game.MarcFont4, tx + (int) Math.Round((double) (num6 * 3) / 4.0) + 4, ty + 50, 4);
                          if (index118 == 3)
                            DrawMod.DrawTextCenterSmallLabel(ref toG, val1_1.ToString(), this.game.MarcFont4, tx + (int) Math.Round((double) num6 / 2.0), ty + 82, 4);
                          if (index118 == 4)
                            DrawMod.DrawTextCenterSmallLabel(ref toG, val1_1.ToString(), this.game.MarcFont4, tx + (int) Math.Round((double) num6 / 4.0) - 4, ty + 50, 4);
                          if (index118 == 5)
                            DrawMod.DrawTextCenterSmallLabel(ref toG, val1_1.ToString(), this.game.MarcFont4, tx + (int) Math.Round((double) num6 / 3.0), ty + 24, 4);
                        }
                      }
                    }
                  }
                  if (index118 == 6)
                  {
                    num167 = (int) Math.Round((double) tx + (double) num6 / 2.0);
                    num168 = (int) Math.Round((double) ty + (double) num7 / 2.0);
                    if ((num156 == 2 | num156 == 4) & widdy2 > 0)
                      DrawMod.DrawBlock(ref toG, num167 - widdy2, num168 - widdy2, widdy2 * 2, widdy2 * 2, num169, num170, num171, (int) byte.MaxValue);
                    if (widdy1 > 0)
                    {
                      if (num156 == 5)
                        DrawMod.DrawBlock(ref toG, num167 - widdy1, num168 - widdy1, widdy1 * 2, widdy1 * 2, 140, 100, 140, 160);
                      if (num156 == 3)
                        DrawMod.DrawBlock(ref toG, num167 - widdy1, num168 - widdy1, widdy1 * 2, widdy1 * 2, (int) Math.Round((double) a3), (int) Math.Round((double) a4), (int) Math.Round((double) a5), 100);
                      if (num156 == 1)
                        DrawMod.DrawBlock(ref toG, num167 - widdy1, num168 - widdy1, widdy1 * 2, widdy1 * 2, (int) Math.Round((double) a3), (int) Math.Round((double) a4), (int) Math.Round((double) a5), 155);
                      if (num156 == 2)
                        DrawMod.DrawBlock(ref toG, num167 - widdy1, num168 - widdy1, widdy1 * 2, widdy1 * 2, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 155);
                      if (num156 == 4)
                        DrawMod.DrawBlock(ref toG, num167 - widdy1, num168 - widdy1, widdy1 * 2, widdy1 * 2, (int) Math.Round((double) a3), (int) Math.Round((double) a4), (int) Math.Round((double) a5), (int) byte.MaxValue);
                    }
                  }
                  else if (index118 < 6)
                  {
                    if (index118 == 0)
                    {
                      num167 = 0;
                      num168 = (int) Math.Round(-((double) num7 / 2.0));
                    }
                    if (index118 == 1)
                    {
                      num167 = (int) Math.Round((double) num6 * 0.4);
                      num168 = (int) Math.Round(-((double) num7 * 0.25));
                    }
                    if (index118 == 2)
                    {
                      num167 = (int) Math.Round((double) num6 * 0.4);
                      num168 = (int) Math.Round((double) num7 * 0.25);
                    }
                    if (index118 == 3)
                    {
                      num167 = 0;
                      num168 = (int) Math.Round((double) num7 / 2.0);
                    }
                    if (index118 == 4)
                    {
                      num167 = (int) Math.Round(-((double) num6 * 0.4));
                      num168 = (int) Math.Round((double) num7 * 0.25);
                    }
                    if (index118 == 5)
                    {
                      num167 = (int) Math.Round(-((double) num6 * 0.4));
                      num168 = (int) Math.Round(-((double) num7 * 0.25));
                    }
                    if ((num156 == 2 | num156 == 4) & widdy2 > 0)
                      DrawMod.drawLineDot(ref toG, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0), (int) Math.Round((double) tx + (double) num6 / 2.0 + (double) num167), (int) Math.Round((double) ty + (double) num7 / 2.0 + (double) num168), Color.FromArgb((int) byte.MaxValue, num169, num170, num171), widdy2);
                    if (widdy1 > 0)
                    {
                      if (num156 == 5)
                        DrawMod.drawLine(ref toG, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0), (int) Math.Round((double) tx + (double) num6 / 2.0 + (double) num167), (int) Math.Round((double) ty + (double) num7 / 2.0 + (double) num168), 140, 100, 140, 160, widdy1);
                      if (num156 == 3)
                        DrawMod.drawLine(ref toG, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0), (int) Math.Round((double) tx + (double) num6 / 2.0 + (double) num167), (int) Math.Round((double) ty + (double) num7 / 2.0 + (double) num168), (int) Math.Round((double) a3), (int) Math.Round((double) a4), (int) Math.Round((double) a5), 100, widdy1);
                      if (num156 == 1)
                        DrawMod.drawLine(ref toG, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0), (int) Math.Round((double) tx + (double) num6 / 2.0 + (double) num167), (int) Math.Round((double) ty + (double) num7 / 2.0 + (double) num168), (int) Math.Round((double) a3), (int) Math.Round((double) a4), (int) Math.Round((double) a5), 155, widdy1);
                      if (num156 == 2)
                        DrawMod.drawLine(ref toG, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0), (int) Math.Round((double) tx + (double) num6 / 2.0 + (double) num167), (int) Math.Round((double) ty + (double) num7 / 2.0 + (double) num168), (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 155, widdy1);
                      if (num156 == 4)
                        DrawMod.drawLine(ref toG, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0), (int) Math.Round((double) tx + (double) num6 / 2.0 + (double) num167), (int) Math.Round((double) ty + (double) num7 / 2.0 + (double) num168), (int) Math.Round((double) a3), (int) Math.Round((double) a4), (int) Math.Round((double) a5), (int) byte.MaxValue, widdy1);
                    }
                  }
                }
                if (widdy3 > 0 & num156 == 5)
                {
                  if (this.game.EditObj.Zoom == 1)
                    widdy3 *= 2;
                  if (this.game.EditObj.Zoom == -1)
                    widdy3 = (int) Math.Round(Math.Max(1.0, (double) widdy3 / 2.0));
                  if (index118 == 6)
                  {
                    num167 = (int) Math.Round((double) tx + (double) num6 / 2.0);
                    num168 = (int) Math.Round((double) ty + (double) num7 / 2.0);
                    if (widdy3 > 0 && num156 == 5)
                      DrawMod.DrawBlock(ref toG, num167 - widdy3, num168 - widdy3, widdy3 * 2, widdy3 * 2, 225, 130, 225, (int) byte.MaxValue);
                  }
                  else if (index118 < 6)
                  {
                    if (index118 == 0)
                    {
                      num167 = 0;
                      num168 = (int) Math.Round(-((double) num7 / 2.0));
                    }
                    if (index118 == 1)
                    {
                      num167 = (int) Math.Round((double) num6 * 0.4);
                      num168 = (int) Math.Round(-((double) num7 * 0.25));
                    }
                    if (index118 == 2)
                    {
                      num167 = (int) Math.Round((double) num6 * 0.4);
                      num168 = (int) Math.Round((double) num7 * 0.25);
                    }
                    if (index118 == 3)
                    {
                      num167 = 0;
                      num168 = (int) Math.Round((double) num7 / 2.0);
                    }
                    if (index118 == 4)
                    {
                      num167 = (int) Math.Round(-((double) num6 * 0.4));
                      num168 = (int) Math.Round((double) num7 * 0.25);
                    }
                    if (index118 == 5)
                    {
                      num167 = (int) Math.Round(-((double) num6 * 0.4));
                      num168 = (int) Math.Round(-((double) num7 * 0.25));
                    }
                    if (widdy3 > 0 && num156 == 5)
                      DrawMod.drawLine(ref toG, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0), (int) Math.Round((double) tx + (double) num6 / 2.0 + (double) num167), (int) Math.Round((double) ty + (double) num7 / 2.0 + (double) num168), 225, 130, 225, (int) byte.MaxValue, widdy3);
                  }
                }
                ++index118;
              }
              while (index118 <= 6);
              if (Zoom == 0)
              {
                if (num156 == 4 & index9 > 0 & val1_1 < 1)
                  DrawMod.DrawTextCenterSmallLabel(ref toG, index9.ToString() + "%", this.game.MarcFont13, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 + 16.0), 11);
                if (num156 == 4 & index9 > 0 & val1_1 > 0)
                  DrawMod.DrawTextCenterSmallLabel(ref toG, "(" + index9.ToString() + "%)", this.game.MarcFont13, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 - 16.0), 11);
                if (num156 == 2 & index10 > 0 & val1_1 < 1)
                  DrawMod.DrawTextCenterSmallLabel(ref toG, index10.ToString(), this.game.MarcFont13, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 + 16.0), 11);
                if (num156 == 2 & val1_1 > 0)
                  DrawMod.DrawTextCenterSmallLabel(ref toG, val1_1.ToString(), this.game.MarcFont13, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 + 16.0), 11);
                if (num156 == 1 & val1_1 > 0 & val1_1 < 9999999)
                  DrawMod.DrawTextCenterSmallLabel(ref toG, val1_1.ToString(), this.game.MarcFont13, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 + 16.0), 2);
                if (num156 == 3 & val1_1 > 0)
                  DrawMod.DrawTextCenterSmallLabel(ref toG, val1_1.ToString(), this.game.MarcFont13, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 + 16.0), 11);
                if (num156 == 4 & val1_1 > 0)
                  DrawMod.DrawTextCenterSmallLabel(ref toG, num16.ToString() + "%", this.game.MarcFont13, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 + 16.0), 11);
                if (num156 == 5 & val1_1 > 0)
                  DrawMod.DrawTextCenterSmallLabel(ref toG, val1_1.ToString(), this.game.MarcFont13, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 + 16.0), 13);
                if (num156 == 5 & val1_2 > 0)
                {
                  if (this.game.EditObj.layerLisOnlyAssetId_isSupplyBase)
                    DrawMod.DrawTextCenterSmallLabel(ref toG, "+" + val1_2.ToString(), this.game.MarcFont13, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 - 2.0), 12);
                  else
                    DrawMod.DrawTextCenterSmallLabel(ref toG, val1_2.ToString(), this.game.MarcFont13, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 - 2.0), 12);
                }
              }
              if (Zoom == 1)
              {
                if (num156 == 4 & index9 > 0 & val1_1 < 1)
                  DrawMod.DrawTextCenterSmallLabel(ref toG, index9.ToString() + "%", this.game.MarcFont4, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 + 16.0), 11);
                if (num156 == 4 & index9 > 0 & val1_1 > 0)
                  DrawMod.DrawTextCenterSmallLabel(ref toG, "(" + index9.ToString() + "%)", this.game.MarcFont4, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 - 16.0), 11);
                if (num156 == 2 & index10 > 0 & val1_1 < 1)
                  DrawMod.DrawTextCenterSmallLabel(ref toG, index10.ToString(), this.game.MarcFont4, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 + 16.0), 99);
                if (num156 == 2 & val1_1 > 0)
                  DrawMod.DrawTextCenterSmallLabel(ref toG, val1_1.ToString(), this.game.MarcFont4, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 + 16.0), 99);
                if (num156 == 1 & val1_1 > 0 & val1_1 < 9999999)
                  DrawMod.DrawTextCenterSmallLabel(ref toG, val1_1.ToString(), this.game.MarcFont4, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 + 16.0), 2);
                if (num156 == 3 & val1_1 > 0)
                  DrawMod.DrawTextCenterSmallLabel(ref toG, val1_1.ToString(), this.game.MarcFont4, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 + 16.0), 11);
                if (num156 == 4 & val1_1 > 0)
                  DrawMod.DrawTextCenterSmallLabel(ref toG, num16.ToString() + "%", this.game.MarcFont4, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 + 16.0), 11);
                if (num156 == 5 & val1_1 > 0)
                  DrawMod.DrawTextCenterSmallLabel(ref toG, val1_1.ToString(), this.game.MarcFont4, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 + 16.0), 13);
                if (num156 == 5 & val1_2 > 0)
                {
                  if (this.game.EditObj.layerLisOnlyAssetId_isSupplyBase)
                    DrawMod.DrawTextCenterSmallLabel(ref toG, "+" + val1_2.ToString(), this.game.MarcFont4, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 - 2.0), 12);
                  else
                    DrawMod.DrawTextCenterSmallLabel(ref toG, val1_2.ToString(), this.game.MarcFont4, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 - 2.0), 12);
                }
              }
            }
            if (!this.game.EditObj.AIMoving && num156 > 0 | this.game.EditObj.udsUnitOrderMode == 53)
            {
              NeighboursExtra lisTraffic = this.game.HandyFunctionsObj.GetLisTraffic(cx, cy);
              int index120 = 0;
              do
              {
                if (lisTraffic.data[index120] > 0)
                {
                  Color color;
                  if (lisTraffic.data[index120] == 1)
                    color = Color.FromArgb((int) byte.MaxValue, 125, (int) byte.MaxValue, 125);
                  if (lisTraffic.data[index120] == 2)
                    color = Color.FromArgb((int) byte.MaxValue, 0, (int) byte.MaxValue, 0);
                  if (lisTraffic.data[index120] == 3)
                    color = Color.FromArgb((int) byte.MaxValue, 64, 152, 0);
                  if (lisTraffic.data[index120] == 4)
                    color = Color.FromArgb((int) byte.MaxValue, 152, 152, 0);
                  if (lisTraffic.data[index120] == 5)
                    color = Color.FromArgb((int) byte.MaxValue, 192, 128, 0);
                  if (lisTraffic.data[index120] == 6)
                    color = Color.FromArgb((int) byte.MaxValue, 192, 64, 0);
                  if (lisTraffic.data[index120] == 7)
                    color = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, 100);
                  if (index120 == 0)
                    DrawMod.DrawBlock(ref toG, (int) Math.Round((double) tx + (double) num6 / 2.0 - (double) num6 / 8.0), (int) Math.Round((double) ty + (double) num7 / 8.0), (int) Math.Round((double) num6 / 4.0), (int) Math.Round((double) num7 / 16.0), (int) color.R, (int) color.G, (int) color.B, (int) byte.MaxValue);
                  if (index120 == 1)
                    DrawMod.DrawBlock(ref toG, (int) Math.Round((double) (tx + num6) - (double) num6 / 4.0 - (double) num6 / 16.0), (int) Math.Round((double) ty + (double) num7 / 4.0), (int) Math.Round((double) num6 / 16.0), (int) Math.Round((double) num7 / 4.0), (int) color.R, (int) color.G, (int) color.B, (int) byte.MaxValue);
                  if (index120 == 2)
                    DrawMod.DrawBlock(ref toG, (int) Math.Round((double) (tx + num6) - (double) num6 / 4.0 - (double) num6 / 16.0), (int) Math.Round((double) (ty + num7) - (double) num7 / 4.0 - (double) num7 / 4.0), (int) Math.Round((double) num6 / 16.0), (int) Math.Round((double) num7 / 4.0), (int) color.R, (int) color.G, (int) color.B, (int) byte.MaxValue);
                  if (index120 == 3)
                    DrawMod.DrawBlock(ref toG, (int) Math.Round((double) tx + (double) num6 / 2.0 - (double) num6 / 8.0), (int) Math.Round((double) (ty + num7) - (double) num7 / 8.0 - (double) num7 / 16.0), (int) Math.Round((double) num6 / 4.0), (int) Math.Round((double) num7 / 16.0), (int) color.R, (int) color.G, (int) color.B, (int) byte.MaxValue);
                  if (index120 == 4)
                    DrawMod.DrawBlock(ref toG, (int) Math.Round((double) tx + (double) num6 / 4.0), (int) Math.Round((double) (ty + num7) - (double) num7 / 4.0 - (double) num7 / 4.0), (int) Math.Round((double) num6 / 16.0), (int) Math.Round((double) num7 / 4.0), (int) color.R, (int) color.G, (int) color.B, (int) byte.MaxValue);
                  if (index120 == 5)
                    DrawMod.DrawBlock(ref toG, (int) Math.Round((double) tx + (double) num6 / 4.0), (int) Math.Round((double) ty + (double) num7 / 4.0), (int) Math.Round((double) num6 / 16.0), (int) Math.Round((double) num7 / 4.0), (int) color.R, (int) color.G, (int) color.B, (int) byte.MaxValue);
                  color = Color.FromArgb(200, (int) Math.Round((double) color.R / 2.0), (int) Math.Round((double) color.G / 2.0), (int) Math.Round((double) color.B / 2.0));
                  if (index120 == 0)
                    DrawMod.DrawRectangle(ref toG, (int) Math.Round((double) tx + (double) num6 / 2.0 - (double) num6 / 8.0), (int) Math.Round((double) ty + (double) num7 / 8.0), (int) Math.Round((double) num6 / 4.0), (int) Math.Round((double) num7 / 16.0), (int) color.R, (int) color.G, (int) color.B, (int) byte.MaxValue);
                  if (index120 == 1)
                    DrawMod.DrawRectangle(ref toG, (int) Math.Round((double) (tx + num6) - (double) num6 / 4.0 - (double) num6 / 16.0), (int) Math.Round((double) ty + (double) num7 / 4.0), (int) Math.Round((double) num6 / 16.0), (int) Math.Round((double) num7 / 4.0), (int) color.R, (int) color.G, (int) color.B, (int) byte.MaxValue);
                  if (index120 == 2)
                    DrawMod.DrawRectangle(ref toG, (int) Math.Round((double) (tx + num6) - (double) num6 / 4.0 - (double) num6 / 16.0), (int) Math.Round((double) (ty + num7) - (double) num7 / 4.0 - (double) num7 / 4.0), (int) Math.Round((double) num6 / 16.0), (int) Math.Round((double) num7 / 4.0), (int) color.R, (int) color.G, (int) color.B, (int) byte.MaxValue);
                  if (index120 == 3)
                    DrawMod.DrawRectangle(ref toG, (int) Math.Round((double) tx + (double) num6 / 2.0 - (double) num6 / 8.0), (int) Math.Round((double) (ty + num7) - (double) num7 / 8.0 - (double) num7 / 16.0), (int) Math.Round((double) num6 / 4.0), (int) Math.Round((double) num7 / 16.0), (int) color.R, (int) color.G, (int) color.B, (int) byte.MaxValue);
                  if (index120 == 4)
                    DrawMod.DrawRectangle(ref toG, (int) Math.Round((double) tx + (double) num6 / 4.0), (int) Math.Round((double) (ty + num7) - (double) num7 / 4.0 - (double) num7 / 4.0), (int) Math.Round((double) num6 / 16.0), (int) Math.Round((double) num7 / 4.0), (int) color.R, (int) color.G, (int) color.B, (int) byte.MaxValue);
                  if (index120 == 5)
                    DrawMod.DrawRectangle(ref toG, (int) Math.Round((double) tx + (double) num6 / 4.0), (int) Math.Round((double) ty + (double) num7 / 4.0), (int) Math.Round((double) num6 / 16.0), (int) Math.Round((double) num7 / 4.0), (int) color.R, (int) color.G, (int) color.B, (int) byte.MaxValue);
                }
                ++index120;
              }
              while (index120 <= 5);
            }
            if (!this.game.EditObj.AIMoving && num156 > 0 | this.game.EditObj.udsUnitOrderMode == 53 && (int) Math.Round(Conversion.Val(this.game.Data.Designer)) >= 42 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI & !this.game.Data.RegimeObj[this.game.Data.Turn].minimumDataUsage)
            {
              int num172 = 0;
              int num173 = 0;
              num16 = 0;
              int num174 = 0;
              index9 = 0;
              bool flag24 = false;
              bool flag25 = false;
              bool flag26 = false;
              if (this.game.EditObj.layerLis_TraficWindowOpen == 1 & this.game.EditObj.layerLisPreview_LogMode == 0)
              {
                num172 = this.game.Data.RegimeObj[this.game.Data.Turn].Trafic2[0].Value[cx, cy];
                flag25 = true;
              }
              else if (num156 == 3 | num156 == 2)
              {
                num172 = this.game.Data.MapObj[0].HexObj[cx, cy].LISpull[0];
                num173 = this.game.Data.MapObj[0].HexObj[cx, cy].LISpull[1];
                num16 = this.game.Data.MapObj[0].HexObj[cx, cy].LISpull[2];
                num174 = this.game.Data.MapObj[0].HexObj[cx, cy].LISpull[3];
                index9 = this.game.Data.MapObj[0].HexObj[cx, cy].LISpull[4];
                if (this.game.Data.MapObj[0].HexObj[cx, cy].LISpull[4] < -1)
                  index9 = Math.Abs(this.game.Data.MapObj[0].HexObj[cx, cy].LISpull[4]);
                flag24 = true;
              }
              else if (num156 == 5 | this.game.EditObj.layerLis_TraficWindowOpen == 1 & this.game.EditObj.layerLisPreview_LogMode == 1)
              {
                num172 = this.game.Data.MapObj[0].HexObj[cx, cy].tempPreviewPull[0];
                num173 = this.game.Data.MapObj[0].HexObj[cx, cy].tempPreviewPull[1];
                num16 = this.game.Data.MapObj[0].HexObj[cx, cy].tempPreviewPull[2];
                num174 = this.game.Data.MapObj[0].HexObj[cx, cy].tempPreviewPull[3];
                index9 = this.game.Data.MapObj[0].HexObj[cx, cy].tempPreviewPull[4];
                if (this.game.Data.MapObj[0].HexObj[cx, cy].tempPreviewPull[4] < -1)
                  index9 = Math.Abs(this.game.Data.MapObj[0].HexObj[cx, cy].tempPreviewPull[4]);
                flag26 = true;
              }
              else if (num156 == 1)
              {
                num172 = this.game.Data.RegimeObj[this.game.Data.Turn].Trafic2[0].Value[cx, cy];
                flag25 = true;
              }
              switch (num172)
              {
                case -1:
                  str = "BLOCK";
                  break;
                case 0:
                  goto label_1808;
                default:
                  if (num172 > 0 & num172 < 1000)
                  {
                    str = num172.ToString();
                    break;
                  }
                  if (num172 >= 1000)
                  {
                    num155 = (int) Math.Round((double) num172 / 1000.0);
                    str = num155.ToString() + "K";
                    break;
                  }
                  if (num172 < -1 & num172 > -1000)
                  {
                    str = Math.Abs(num172).ToString() + "*";
                    break;
                  }
                  if (num172 <= -1000)
                  {
                    str = ((int) Math.Round((double) Math.Abs(num172) / 1000.0)).ToString() + "K" + "*";
                    break;
                  }
                  break;
              }
              Color color;
              if (flag24)
                color = Color.Gray;
              else if (flag25)
                color = Color.FromArgb((int) byte.MaxValue, 100, 200, 100);
              else if (flag26)
                color = Color.FromArgb((int) byte.MaxValue, 180, 140, 180);
              if (Zoom == 0)
              {
                if (num173 > 0)
                  DrawMod.DrawBlock(ref toG, (int) Math.Round((double) tx + (double) num6 / 4.0 + (double) num6 / 8.0 * 0.0), (int) Math.Round((double) ty + (double) num7 / 2.0 - 21.0), (int) Math.Round((double) num6 / 8.0), 2, (int) byte.MaxValue, 0, 0, (int) byte.MaxValue);
                if (num16 > 0)
                  DrawMod.DrawBlock(ref toG, (int) Math.Round((double) tx + (double) num6 / 4.0 + (double) num6 / 8.0 * 1.0), (int) Math.Round((double) ty + (double) num7 / 2.0 - 21.0), (int) Math.Round((double) num6 / 8.0), 2, 0, (int) byte.MaxValue, 0, (int) byte.MaxValue);
                if (num174 > 0)
                  DrawMod.DrawBlock(ref toG, (int) Math.Round((double) tx + (double) num6 / 4.0 + (double) num6 / 8.0 * 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 - 21.0), (int) Math.Round((double) num6 / 8.0), 2, 0, 0, (int) byte.MaxValue, (int) byte.MaxValue);
                if (index9 > 0)
                  DrawMod.DrawBlock(ref toG, (int) Math.Round((double) tx + (double) num6 / 4.0 + (double) num6 / 8.0 * 3.0), (int) Math.Round((double) ty + (double) num7 / 2.0 - 21.0), (int) Math.Round((double) num6 / 8.0), 2, 0, 0, 0, (int) byte.MaxValue);
                DrawMod.DrawBlock(ref toG, (int) Math.Round((double) tx + (double) num6 / 4.0), (int) Math.Round((double) ty + (double) num7 / 2.0 - 19.0), (int) Math.Round((double) num6 / 2.0), 11, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
                DrawMod.DrawRectangle(ref toG, (int) Math.Round((double) tx + (double) num6 / 4.0), (int) Math.Round((double) ty + (double) num7 / 2.0 - 19.0), (int) Math.Round((double) num6 / 2.0), 11, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
                DrawMod.DrawTextCenterSmallLabel(ref toG, str, this.game.MarcFont13, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 - 14.0));
              }
              if (Zoom == 1)
              {
                if (num173 > 0)
                  DrawMod.DrawBlock(ref toG, (int) Math.Round((double) tx + (double) num6 / 4.0 + (double) num6 / 8.0 * 0.0), (int) Math.Round((double) ty + (double) num7 / 2.0 - 39.0), (int) Math.Round((double) num6 / 8.0), 4, (int) byte.MaxValue, 0, 0, (int) byte.MaxValue);
                if (num16 > 0)
                  DrawMod.DrawBlock(ref toG, (int) Math.Round((double) tx + (double) num6 / 4.0 + (double) num6 / 8.0 * 1.0), (int) Math.Round((double) ty + (double) num7 / 2.0 - 39.0), (int) Math.Round((double) num6 / 8.0), 4, 0, (int) byte.MaxValue, 0, (int) byte.MaxValue);
                if (num174 > 0)
                  DrawMod.DrawBlock(ref toG, (int) Math.Round((double) tx + (double) num6 / 4.0 + (double) num6 / 8.0 * 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 - 39.0), (int) Math.Round((double) num6 / 8.0), 4, 0, 0, (int) byte.MaxValue, (int) byte.MaxValue);
                if (index9 > 0)
                  DrawMod.DrawBlock(ref toG, (int) Math.Round((double) tx + (double) num6 / 4.0 + (double) num6 / 8.0 * 3.0), (int) Math.Round((double) ty + (double) num7 / 2.0 - 39.0), (int) Math.Round((double) num6 / 8.0), 4, 0, 0, 0, (int) byte.MaxValue);
                DrawMod.DrawBlock(ref toG, (int) Math.Round((double) tx + (double) num6 / 4.0), (int) Math.Round((double) ty + (double) num7 / 2.0 - 35.0), (int) Math.Round((double) num6 / 2.0), 21, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
                DrawMod.DrawRectangle(ref toG, (int) Math.Round((double) tx + (double) num6 / 4.0), (int) Math.Round((double) ty + (double) num7 / 2.0 - 35.0), (int) Math.Round((double) num6 / 2.0), 21, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
                DrawMod.DrawTextCenterSmallLabel(ref toG, str, this.game.MarcFont4, (int) Math.Round((double) tx + (double) num6 / 2.0), (int) Math.Round((double) ty + (double) num7 / 2.0 - 24.0));
              }
            }
          }
label_1808:
          if (this.game.EventRelatedObj.Helper_AirEnabled() & !flag1 && this.game.EditObj.Zoom >= 0)
          {
            this.slotAir = this.strId534slot;
            if (this.slotAir > -1)
            {
              int length = this.game.Data.StringListObj[this.slotAir].Length;
              SimpleList Expression;
              for (int tdata2 = 0; tdata2 <= length; ++tdata2)
              {
                if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[tdata2, 0])) == this.game.Data.RegimeObj[this.game.Data.Turn].id)
                {
                  if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[tdata2, 1])) == cx && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[tdata2, 2])) == cy && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[tdata2, 9])) >= 0)
                  {
                    if (Information.IsNothing((object) Expression))
                      Expression = new SimpleList();
                    Expression.Add((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[tdata2, 8])), (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[tdata2, 6])), (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[tdata2, 9])), tdata2);
                  }
                  if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[tdata2, 3])) == cx && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[tdata2, 4])) == cy && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[tdata2, 9])) >= 0)
                  {
                    if (Information.IsNothing((object) Expression))
                      Expression = new SimpleList();
                    Expression.Add((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[tdata2, 8])), (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[tdata2, 6])), (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAir].Data[tdata2, 9])), tdata2);
                  }
                }
              }
              if (!Information.IsNothing((object) Expression))
              {
                Expression.ReverseSortHighSpeed();
                int num175 = 0;
                int counter = Expression.Counter;
                for (int index121 = 0; index121 <= counter; ++index121)
                {
                  string tstring = this.game.HandyFunctionsObj.CovertNumberToLetter(Expression.Id[index121]);
                  Color color = this.game.HandyFunctionsObj.Air_GetColor(Expression.Data2[index121]);
                  int tcol = 0;
                  if (index121 == 3 & Expression.Counter > 3)
                  {
                    num155 = Expression.Counter - 2;
                    tstring = "+" + num155.ToString();
                    color = Color.FromArgb(150, 0, 0, 0);
                  }
                  if (this.game.EditObj.Zoom == 1)
                  {
                    num175 += 22;
                    DrawMod.DrawBlock(ref toG, tx + num175, ty + 3, 18, 14, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
                    DrawMod.DrawTextCenterSmallLabel(ref toG, tstring, this.game.MarcFont4, tx - 1 + num175 + 10, ty + 11, tcol);
                  }
                  else
                  {
                    num175 += 11;
                    DrawMod.DrawBlock(ref toG, tx + num175, ty + 1, 11, 10, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
                    DrawMod.DrawTextCenterSmallLabel(ref toG, tstring, this.game.MarcFont13, tx + num175 + 5, ty + 6, tcol);
                  }
                  if (index121 >= 3)
                    break;
                }
              }
            }
          }
          if (!flag1 & !InfoMode)
          {
            if (this.game.EditObj.HideUnit > 0 & this.game.EditObj.layerUnits && this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitCounter > -1 & !InfoMode)
            {
              int unitCounter = this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitCounter;
              int num176 = -1;
              num16 = -1;
              int num177 = 0;
              index9 = -1;
              for (int index122 = unitCounter; index122 >= 0; index122 += -1)
              {
                if (this.game.HandyFunctionsObj.CanWeSeeUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index122], index5) > 0)
                  ++num16;
              }
              if (Zoom == 0 | !this.game.EditObj.SpreadUnit)
              {
                if (num16 > 3)
                {
                  num177 = num16 - 3;
                  num16 = 3;
                }
              }
              else if (Zoom == 1 && num16 > 13)
              {
                num177 = num16 - 13;
                num16 = 13;
              }
              if (0 > num177)
                num177 = 0;
              for (index1 = unitCounter; index1 >= 0; index1 += -1)
              {
                if (this.game.HandyFunctionsObj.CanWeSeeUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], index5) > 0)
                {
                  ++num176;
                  if (num176 >= num177)
                  {
                    ++index9;
                    bool forcehighlight = false;
                    if (this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1] == this.game.EditObj.UnitSelected)
                      forcehighlight = true;
                    switch (Zoom)
                    {
                      case -1:
                        this.DrawUnitSmall(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 0 + 7 - (int) Math.Round((double) num16 * 0.5) + index9 * 1, ty + 0 + 3 - (int) Math.Round((double) num16 * 0.5) + index9 * 1, true);
                        continue;
                      case 0:
                        this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx - 1 + 14 - num16 + index9 * 2, ty + 1 + 4 - num16 + index9 * 2, true, mostlyHidden: (index1 > 0));
                        continue;
                      default:
                        if (this.game.EditObj.SpreadUnit)
                        {
                          if (num177 == 0 & num16 == 0)
                          {
                            this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 45, ty + 30, true);
                            continue;
                          }
                          if (num177 == 0 & num16 == 1)
                          {
                            if (index9 == 0)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 30, true);
                            if (index9 == 1)
                            {
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 30, true);
                              continue;
                            }
                            continue;
                          }
                          if (num177 == 0 & num16 == 2)
                          {
                            if (index9 == 0)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 45, ty + 8, true);
                            if (index9 == 1)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 51, true);
                            if (index9 == 2)
                            {
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 51, true);
                              continue;
                            }
                            continue;
                          }
                          if (num177 == 0 & num16 == 3)
                          {
                            if (index9 == 0)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 8, true);
                            if (index9 == 1)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 8, true);
                            if (index9 == 2)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 51, true);
                            if (index9 == 3)
                            {
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 51, true);
                              continue;
                            }
                            continue;
                          }
                          if (num177 == 0 & num16 == 4)
                          {
                            if (index9 == 0)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 8, true);
                            if (index9 == 1)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 8, true);
                            if (index9 == 2)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 51, true);
                            if (index9 == 3)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 51, true);
                            if (index9 == 4)
                            {
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 45, ty + 30, true);
                              continue;
                            }
                            continue;
                          }
                          if (num177 == 0 & num16 == 5)
                          {
                            if (index9 == 0)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 8, true);
                            if (index9 == 1)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 30, true);
                            if (index9 == 2)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 51, true);
                            if (index9 == 3)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 8, true);
                            if (index9 == 4)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 30, true);
                            if (index9 == 5)
                            {
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 51, true);
                              continue;
                            }
                            continue;
                          }
                          if (num177 == 0 & num16 == 6)
                          {
                            if (index9 == 0)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 8, true);
                            if (index9 == 1)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 30, true);
                            if (index9 == 2)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 51, true);
                            if (index9 == 3)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 8, true);
                            if (index9 == 4)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 30, true);
                            if (index9 == 5)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 51, true);
                            if (index9 == 6)
                            {
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 45, ty + 30, true);
                              continue;
                            }
                            continue;
                          }
                          if (num177 == 0 & num16 == 7)
                          {
                            if (index9 == 0)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 8, true);
                            if (index9 == 1)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 30, true);
                            if (index9 == 2)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 51, true);
                            if (index9 == 3)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 8, true);
                            if (index9 == 4)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 30, true);
                            if (index9 == 5)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 51, true);
                            if (index9 == 6)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 45, ty + 19, true);
                            if (index9 == 7)
                            {
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 45, ty + 40, true);
                              continue;
                            }
                            continue;
                          }
                          if (num177 == 0 & num16 == 8)
                          {
                            if (index9 == 0)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 8, true);
                            if (index9 == 1)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 30, true);
                            if (index9 == 2)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 51, true);
                            if (index9 == 3)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 8, true);
                            if (index9 == 4)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 30, true);
                            if (index9 == 5)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 51, true);
                            if (index9 == 6)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 45, ty + 8, true);
                            if (index9 == 7)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 45, ty + 30, true);
                            if (index9 == 8)
                            {
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 45, ty + 51, true);
                              continue;
                            }
                            continue;
                          }
                          if (num177 == 0 & num16 == 9)
                          {
                            if (index9 == 0)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 8, true);
                            if (index9 == 1)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 30, true);
                            if (index9 == 2)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 51, true);
                            if (index9 == 3)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 8, true);
                            if (index9 == 4)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 30, true);
                            if (index9 == 5)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 51, true);
                            if (index9 == 6)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 45, ty + 8, true);
                            if (index9 == 7)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 45, ty + 51, true);
                            if (index9 == 8)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 35, ty + 19, true);
                            if (index9 == 9)
                            {
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 56, ty + 19, true);
                              continue;
                            }
                            continue;
                          }
                          if (num177 == 0 & num16 == 10)
                          {
                            if (index9 == 0)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 8, true);
                            if (index9 == 1)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 30, true);
                            if (index9 == 2)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 51, true);
                            if (index9 == 3)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 8, true);
                            if (index9 == 4)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 30, true);
                            if (index9 == 5)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 51, true);
                            if (index9 == 6)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 45, ty + 8, true);
                            if (index9 == 7)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 45, ty + 51, true);
                            if (index9 == 8)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 35, ty + 19, true);
                            if (index9 == 9)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 56, ty + 19, true);
                            if (index9 == 10)
                            {
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 35, ty + 40, true);
                              continue;
                            }
                            continue;
                          }
                          if (num177 == 0 & num16 == 11)
                          {
                            if (index9 == 0)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 8, true);
                            if (index9 == 1)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 30, true);
                            if (index9 == 2)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 51, true);
                            if (index9 == 3)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 8, true);
                            if (index9 == 4)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 30, true);
                            if (index9 == 5)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 51, true);
                            if (index9 == 6)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 45, ty + 8, true);
                            if (index9 == 7)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 45, ty + 51, true);
                            if (index9 == 8)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 35, ty + 19, true);
                            if (index9 == 9)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 56, ty + 19, true);
                            if (index9 == 10)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 35, ty + 40, true);
                            if (index9 == 11)
                            {
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 56, ty + 40, true);
                              continue;
                            }
                            continue;
                          }
                          if (num177 == 0 & num16 == 12)
                          {
                            if (index9 == 0)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 8, true);
                            if (index9 == 1)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 30, true);
                            if (index9 == 2)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 24, ty + 51, true);
                            if (index9 == 3)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 8, true);
                            if (index9 == 4)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 30, true);
                            if (index9 == 5)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 67, ty + 51, true);
                            if (index9 == 6)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 45, ty + 8, true);
                            if (index9 == 7)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 45, ty + 51, true);
                            if (index9 == 8)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 35, ty + 19, true);
                            if (index9 == 9)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 56, ty + 19, true);
                            if (index9 == 10)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 35, ty + 40, true);
                            if (index9 == 11)
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 56, ty + 40, true);
                            if (index9 == 12)
                            {
                              this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 45, ty + 30, true);
                              continue;
                            }
                            continue;
                          }
                          this.DrawUnit(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 0 + 14 - num16 * 2 + index9 * 4 + 26, ty + 0 + 5 - num16 * 2 + index9 * 4 + 24, true, mostlyHidden: (index1 > 0));
                          continue;
                        }
                        this.DrawUnitBig(this.game.Data.MapObj[cmap].HexObj[cx, cy].UnitList[index1], forcehighlight, toG, tx + 0 + 28 - num16 * 1 + index9 * 2 + 0, ty + 0 + 10 - num16 * 2 + index9 * 4 + 0, true, mostlyHidden: (index1 > 0));
                        continue;
                    }
                  }
                }
              }
            }
          }
          else if (!InfoMode)
          {
            if (cx == 104 & cy == 28)
              cx = cx;
            if (this.game.EditObj.HisForce[cmap].Value[cx, cy] > -1 | this.game.EditObj.HisForce[cmap].Value[cx, cy] == -9999 | this.game.EditObj.HisForce[cmap].Value[cx, cy] > 0)
            {
              int num178 = this.game.EditObj.HisDepth[cmap].Value[cx, cy] - 1;
              int num179 = -1;
              num16 = this.game.EditObj.HisDepth[cmap].Value[cx, cy] - 1;
              int num180 = 0;
              index9 = -1;
              if (num16 > 3)
              {
                num180 = num16 - 3;
                num16 = 3;
              }
              if (0 > num180)
                num180 = 0;
              for (index1 = num178; index1 >= 0; index1 += -1)
              {
                ++num179;
                if (num179 >= num180)
                {
                  ++index9;
                  if (this.game.EditObj.HisHis[cmap].Value[cx, cy] > -1 | this.game.EditObj.HisForce[cmap].Value[cx, cy] == -9999)
                  {
                    this.DrawUnit(-1, toG: toG, tx: (tx + 0 + 14 - num16 + index9 * 2), ty: (ty + 0 + 5 - num16 + index9 * 2), OverruleHis: this.game.EditObj.HisHis[cmap].Value[cx, cy], OverrulePower: this.game.EditObj.HisForce[cmap].Value[cx, cy], OverruleRegime: this.game.EditObj.HisOwner[cmap].Value[cx, cy]);
                  }
                  else
                  {
                    ref Graphics local319 = ref toG;
                    bitmap4 = this.DrawHistoryForce(this.game.EditObj.HisOwner[cmap].Value[cx, cy], this.game.EditObj.HisForce[cmap].Value[cx, cy], this.game.EditObj.HisSFType[cmap].Value[cx, cy]);
                    ref Bitmap local320 = ref bitmap4;
                    int x = tx + 14;
                    int y = ty + 5;
                    DrawMod.DrawSimple(ref local319, ref local320, x, y);
                  }
                }
              }
            }
          }
          if (!flag1 & this.game.EditObj.TownInfo & (double) this.game.Data.RuleVar[860] > 0.0 & this.game.Data.Turn > -1)
          {
            Color color1 = new Color();
            Color color2 = new Color();
            if (!InfoMode & this.game.Data.MapObj[cmap].HexObj[cx, cy].Location > -1)
            {
              if (this.game.Data.MapObj[0].HexObj[cx, cy].get_ReconPts(this.game.Data.Turn) > 0 | !this.game.Data.FOWOn)
              {
                int structuralPts = this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].Location].Type].StructuralPts;
                if (structuralPts > 0)
                {
                  float num181 = (float) this.game.Data.LocObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].Location].StructuralPts / (float) structuralPts;
                  Color c1 = Color.Green;
                  Color c2 = Color.DarkGreen;
                  if ((double) num181 < 1.0)
                  {
                    c1 = Color.Green;
                    c2 = Color.Yellow;
                  }
                  if ((double) num181 < 0.75)
                  {
                    c1 = Color.Yellow;
                    c2 = Color.Blue;
                  }
                  if ((double) num181 < 0.5)
                  {
                    c1 = Color.Blue;
                    c2 = Color.Red;
                  }
                  if ((double) num181 < 0.25)
                  {
                    c1 = Color.Red;
                    c2 = Color.DarkRed;
                  }
                  switch (Zoom)
                  {
                    case -1:
                      DrawMod.DrawBlock(ref toG, tx + num6 - 6, ty + 8, 3, 8, 0, 0, 0, 100);
                      DrawMod.DrawBlockGradient2(ref toG, tx + num6 - 6, (int) Math.Round((double) ((float) (ty + 8) + (float) (8.0 - (double) num181 * 8.0))), 3, (int) Math.Round((double) (8f * num181)), c1, c2);
                      DrawMod.DrawRectangle(ref toG, tx + num6 - 6, ty + 8, 3, 8, 0, 0, 0, (int) byte.MaxValue);
                      break;
                    case 0:
                      DrawMod.DrawBlock(ref toG, tx + num6 - 12, ty + 17, 5, 18, 0, 0, 0, 100);
                      DrawMod.DrawBlockGradient2(ref toG, tx + num6 - 12, (int) Math.Round((double) ((float) (ty + 17) + (float) (18.0 - (double) num181 * 18.0))), 5, (int) Math.Round((double) (18f * num181)), c1, c2);
                      DrawMod.DrawRectangle(ref toG, tx + num6 - 12, ty + 17, 5, 18, 0, 0, 0, (int) byte.MaxValue);
                      break;
                    case 1:
                      DrawMod.DrawBlock(ref toG, tx + num6 - 21, ty + 36, 8, 36, 0, 0, 0, 100);
                      DrawMod.DrawBlockGradient2(ref toG, tx + num6 - 21, (int) Math.Round((double) ((float) (ty + 36) + (float) (36.0 - (double) num181 * 36.0))), 8, (int) Math.Round((double) (36f * num181)), c1, c2);
                      DrawMod.DrawRectangle(ref toG, tx + num6 - 21, ty + 36, 8, 36, 0, 0, 0, (int) byte.MaxValue);
                      break;
                  }
                }
              }
              if (!this.game.Data.FOWOn | this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime, this.game.Data.Turn))
              {
                int hq2 = this.game.Data.LocObj[this.game.Data.MapObj[cmap].HexObj[cx, cy].Location].HQ;
                if (hq2 > -1)
                {
                  Color c1 = Color.FromArgb((int) byte.MaxValue, this.game.Data.UnitObj[hq2].Red, this.game.Data.UnitObj[hq2].Green, this.game.Data.UnitObj[hq2].Blue);
                  Color c2 = Color.FromArgb((int) byte.MaxValue, (int) Math.Round((double) this.game.Data.UnitObj[hq2].Red / 2.0), (int) Math.Round((double) this.game.Data.UnitObj[hq2].Green / 2.0), (int) Math.Round((double) this.game.Data.UnitObj[hq2].Blue / 2.0));
                  switch (Zoom)
                  {
                    case -1:
                      DrawMod.DrawBlockGradient2(ref toG, tx + 2, (int) Math.Round((double) ty + (double) num7 * 0.375), (int) Math.Round((double) num6 / 8.0), (int) Math.Round((double) num7 / 4.0), c1, c2);
                      DrawMod.DrawRectangle(ref toG, tx + 2, (int) Math.Round((double) ty + (double) num7 * 0.375), (int) Math.Round((double) num6 / 8.0), (int) Math.Round((double) num7 / 4.0), 0, 0, 0, (int) byte.MaxValue);
                      break;
                    case 0:
                      DrawMod.DrawBlockGradient2(ref toG, tx + 4, (int) Math.Round((double) (ty + 1) + (double) num7 * 0.375), (int) Math.Round((double) num6 / 8.0 - 2.0), (int) Math.Round((double) num7 / 4.0 - 2.0), c1, c2);
                      DrawMod.DrawRectangle(ref toG, tx + 4, (int) Math.Round((double) (ty + 1) + (double) num7 * 0.375), (int) Math.Round((double) num6 / 8.0 - 2.0), (int) Math.Round((double) num7 / 4.0 - 2.0), 0, 0, 0, (int) byte.MaxValue);
                      break;
                    case 1:
                      DrawMod.DrawBlockGradient2(ref toG, tx + 8, (int) Math.Round((double) (ty + 1) + (double) num7 * 0.375), (int) Math.Round((double) num6 / 8.0 - 2.0), (int) Math.Round((double) num7 / 4.0 - 2.0), c1, c2);
                      DrawMod.DrawRectangle(ref toG, tx + 8, (int) Math.Round((double) (ty + 1) + (double) num7 * 0.375), (int) Math.Round((double) num6 / 8.0 - 2.0), (int) Math.Round((double) num7 / 4.0 - 2.0), 0, 0, 0, (int) byte.MaxValue);
                      break;
                  }
                }
              }
            }
          }
        }
        else
        {
          if (flag1)
          {
            ref Graphics local321 = ref toG;
            bitmap1 = BitmapStore.GetBitmap(this.game.NOHEX, Zoom);
            ref Bitmap local322 = ref bitmap1;
            int x10 = tx;
            int y10 = ty;
            DrawMod.DrawSimple(ref local321, ref local322, x10, y10);
            if (this.game.EditObj.HexRasterOn & !ispredrawing)
            {
              ref Graphics local323 = ref toG;
              bitmap1 = BitmapStore.GetBitmap(this.game.HEXRASTER, Zoom);
              ref Bitmap local324 = ref bitmap1;
              int x11 = tx;
              int y11 = ty;
              DrawMod.DrawSimple(ref local323, ref local324, x11, y11);
            }
            return this.tmpbmp3;
          }
          if (Information.IsNothing((object) tempg))
            return this.tmpbmp3;
          this.ThreadRelease();
          goto label_2498;
        }
      }
      if (num8 == 0 & this.game.Data.ShrowdOn & this.game.EditObj.RealRound == 0 & !flag1 & !InfoMode)
      {
        ref Graphics local325 = ref toG;
        bitmap4 = BitmapStore.GetBitmap(this.game.NOHEX, Zoom);
        ref Bitmap local326 = ref bitmap4;
        int x = tx;
        int y = ty;
        DrawMod.DrawSimple(ref local325, ref local326, x, y);
      }
      else if (num8 == 0 & this.game.Data.ShrowdOn & this.game.EditObj.RealRound > 0 & !flag1 & !InfoMode)
      {
        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_SeeNow(index5) < 1)
        {
          int num182 = 0;
          if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_LastLT(index5) == -1)
          {
            ref Graphics local327 = ref toG;
            bitmap4 = BitmapStore.GetBitmap(this.game.NOHEX, Zoom);
            ref Bitmap local328 = ref bitmap4;
            int x = tx;
            int y = ty;
            DrawMod.DrawSimple(ref local327, ref local328, x, y);
          }
          else
          {
            num182 = 1;
            index6 = this.game.Data.MapObj[cmap].HexObj[cx, cy].get_LastLT(index5);
            int index123 = this.game.Data.MapObj[cmap].HexObj[cx, cy].get_LastSpr(index5);
            if (!this.game.Data.LandscapeTypeObj[index6].Transparent)
            {
              if (index6 > -1)
                nr1 = this.game.Data.LandscapeTypeObj[index6].PreHexPicID;
              int num183 = (int) Math.Round((double) BitmapStore.GetBitmap(nr1, Zoom).Width / (double) num6);
              int num184 = 0;
              if (num183 > 1)
                num184 = new Random((int) Math.Round(a1)).Next(0, num183 - 1);
              ref Graphics local329 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(nr1, Zoom);
              ref Bitmap local330 = ref bitmap4;
              rectangle2 = new Rectangle(num184 * num6, 0, num6, num7);
              Rectangle srcrect15 = rectangle2;
              rectangle1 = new Rectangle(tx, ty, num6, num7);
              Rectangle destrect15 = rectangle1;
              DrawMod.DrawSimplePart2(ref local329, ref local330, srcrect15, destrect15);
              int num185 = (int) Math.Round((double) BitmapStore.GetWidth(this.game.Data.LandscapeTypeObj[index6].BasicSpriteID[index123], Zoom) / (double) num6);
              int num186 = 0;
              if (num185 > 1)
                num186 = new Random((int) Math.Round(a1)).Next(0, num185 - 1);
              ref Graphics local331 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(this.game.Data.LandscapeTypeObj[index6].BasicSpriteID[index123], Zoom);
              ref Bitmap local332 = ref bitmap4;
              rectangle2 = new Rectangle(num186 * num6, 0, num6, num7);
              Rectangle srcrect16 = rectangle2;
              rectangle1 = new Rectangle(tx, ty, num6, num7);
              Rectangle destrect16 = rectangle1;
              DrawMod.DrawSimplePart2(ref local331, ref local332, srcrect16, destrect16);
              if (this.game.Data.LandscapeTypeObj[index6].BasicSpriteID2[index123] > 0 & this.game.Data.LandscapeTypeObj[index6].PlotLast[index123])
              {
                ref Graphics local333 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.Data.LandscapeTypeObj[index6].BasicSpriteID2[index123], Zoom);
                ref Bitmap local334 = ref bitmap4;
                rectangle2 = new Rectangle(num186 * num6, 0, num6, num7);
                Rectangle srcrect17 = rectangle2;
                rectangle1 = new Rectangle(tx, ty, num6, num7);
                Rectangle destrect17 = rectangle1;
                DrawMod.DrawSimplePart2(ref local333, ref local334, srcrect17, destrect17);
              }
            }
          }
          if (num182 == 1)
          {
            index1 = 0;
            do
            {
              if (this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index1] > -1)
              {
                int index124 = this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index1];
                if (!this.game.Data.RiverTypeObj[index124].Transparent)
                {
                  int num187 = (int) Math.Round((double) BitmapStore.GetWidth(this.game.Data.RiverTypeObj[index124].BasicSpriteID[index1], Zoom) / (double) num6);
                  num16 = 0;
                  if (!this.game.Data.RiverTypeObj[index124].snakeMode)
                  {
                    coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, index1);
                    if (num187 > 1)
                      num16 = !coordinate1.onmap ? new Random((int) Math.Round(a1)).Next(0, num187 - 1) : new Random((int) Math.Round(a1)).Next(0, num187 - 1);
                  }
                  else
                  {
                    index9 = index1 - 1;
                    index10 = index1 + 1;
                    if (index9 < 0)
                      index9 = 5;
                    if (index10 > 5)
                      index10 = 0;
                    index8 = this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index9];
                    int num188 = this.game.Data.MapObj[cmap].HexObj[cx, cy].RiverType[index10];
                    if (index8 == index124 & num188 == index124)
                      num16 = 0;
                    if (index8 == index124 & num188 != index124)
                      num16 = 1;
                    if (index8 != index124 & num188 == index124)
                      num16 = 2;
                    if (index8 != index124 & num188 != index124)
                      num16 = 3;
                  }
                  ref Graphics local335 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(this.game.Data.RiverTypeObj[index124].BasicSpriteID[index1], Zoom);
                  ref Bitmap local336 = ref bitmap4;
                  rectangle2 = new Rectangle(num16 * num6, 0, num6, num7);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, num6, num7);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local335, ref local336, srcrect, destrect);
                }
              }
              ++index1;
            }
            while (index1 <= 5);
          }
          if (flag2 & !this.game.Data.LandscapeTypeObj[index6].IsSea | num182 == 0 & flag2)
          {
            ref Graphics local337 = ref toG;
            bitmap4 = BitmapStore.GetBitmap(this.game.WHITEHEXTRANS, Zoom);
            ref Bitmap local338 = ref bitmap4;
            int x = tx;
            int y = ty;
            DrawMod.DrawSimple(ref local337, ref local338, x, y);
            num15 = 1;
          }
          else if (num182 == 1 & flag2 & this.game.Data.LandscapeTypeObj[index6].IsSea)
          {
            ref Graphics local339 = ref toG;
            bitmap4 = BitmapStore.GetBitmap(this.game.ROUNDBALL, Zoom);
            ref Bitmap local340 = ref bitmap4;
            int x = tx;
            int y = ty;
            DrawMod.DrawSimple(ref local339, ref local340, x, y);
          }
          if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_LastLT(index5) != -1 & this.game.EditObj.ShowLabel)
          {
            int num189 = 0;
            if (this.game.Data.Turn > -1)
            {
              if (this.game.Data.MapObj[coordinate1.map].HexObj[cx, cy].Regime == index5)
                num189 = 1;
              if (this.game.Data.MapObj[coordinate1.map].HexObj[cx, cy].get_ReconPts(this.game.EditObj.RealTurn) >= 1)
                num189 = 1;
              if (this.game.Data.MapObj[coordinate1.map].HexObj[cx, cy].MaxRecon >= 1 & !flag1)
                num189 = 1;
            }
            else
              num189 = 1;
            if (!this.game.Data.ShrowdOn)
              num189 = 1;
            if (num189 == 1 && !ispredrawing && !ispredrawing)
            {
              if (Strings.Len(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText1) > 0)
              {
                if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 <= 5)
                {
                  Color c = Color.Transparent;
                  if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 1)
                    c = Color.White;
                  if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 2)
                    c = Color.Blue;
                  if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 3)
                    c = Color.Black;
                  if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 4)
                    c = Color.Red;
                  if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 5)
                    c = Color.Yellow;
                  if (Zoom == 0)
                  {
                    string str = Strings.UCase(Strings.Left(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText1, 5));
                    if (Strings.Len(str) >= 1)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 1, 1), new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 7, ty + 6, c, true);
                    if (Strings.Len(str) >= 2)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 2, 1), new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 17, ty + 6, c, true);
                    if (Strings.Len(str) >= 3)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 3, 1), new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 27, ty + 6, c, true);
                    if (Strings.Len(str) >= 4)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 4, 1), new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 37, ty + 6, c, true);
                    if (Strings.Len(str) >= 5)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 5, 1), new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 48, ty + 6, c, true);
                  }
                  else if ((double) this.game.Data.RuleVar[352] == 0.0 & Zoom == 1)
                  {
                    index1 = 1;
                    do
                    {
                      string str = Strings.UCase(Strings.Mid(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText1, index1, 1));
                      if (Strings.Len(str) >= 1)
                        DrawMod.DrawTextColouredOutline(ref toG, str, new Font("Arial Black", 16f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 16 + 20 * (index1 - 1), ty + 12, c, true);
                      ++index1;
                    }
                    while (index1 <= 5);
                  }
                  else if (Zoom == -1)
                  {
                    string str = Strings.UCase(Strings.Left(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText1, 5));
                    if (Strings.Len(str) >= 1)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 1, 1), new Font("Courier New", 9f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 2, ty + 0, c);
                    if (Strings.Len(str) >= 2)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 2, 1), new Font("Courier New", 9f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 7, ty + 0, c);
                    if (Strings.Len(str) >= 3)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 3, 1), new Font("Courier New", 9f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 12, ty + 0, c);
                    if (Strings.Len(str) >= 4)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 4, 1), new Font("Courier New", 9f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 17, ty + 0, c);
                    if (Strings.Len(str) >= 5)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 5, 1), new Font("Courier New", 9f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 22, ty + 0, c);
                  }
                }
                else
                {
                  switch (Zoom)
                  {
                    case -1:
                      if (Strings.Len(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText1) > 0)
                      {
                        string str = Strings.UCase(Strings.Left(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText1, 1));
                        SizeF sizeF8 = toG.MeasureString(Strings.Left(str, 1), new Font("Arial Black", 12f, FontStyle.Bold, GraphicsUnit.Pixel));
                        Color c = Color.Transparent;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 6)
                          c = Color.White;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 7)
                          c = Color.Blue;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 8)
                          c = Color.Black;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 9)
                          c = Color.Red;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 10)
                          c = Color.Yellow;
                        if (Strings.Len(str) >= 1)
                        {
                          DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 1, 1), new Font("Arial Black", 12f, FontStyle.Bold, GraphicsUnit.Pixel), (int) Math.Round((double) ((float) (tx + 16) - sizeF8.Width / 2f)), ty - 3, c, true);
                          break;
                        }
                        break;
                      }
                      break;
                    case 0:
                      if (Strings.Len(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText1) > 0)
                      {
                        string str = Strings.UCase(Strings.Left(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText1, 1));
                        SizeF sizeF9 = toG.MeasureString(Strings.Left(str, 1), new Font("Arial Black", 16f, FontStyle.Bold, GraphicsUnit.Pixel));
                        Color c = Color.Transparent;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 6)
                          c = Color.White;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 7)
                          c = Color.Blue;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 8)
                          c = Color.Black;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 9)
                          c = Color.Red;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType1 == 10)
                          c = Color.Yellow;
                        if (Strings.Len(str) >= 1)
                        {
                          DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 1, 1), new Font("Arial Black", 16f, FontStyle.Bold, GraphicsUnit.Pixel), (int) Math.Round((double) ((float) (tx + 32) - sizeF9.Width / 2f)), ty + 4, c, true);
                          break;
                        }
                        break;
                      }
                      break;
                  }
                }
              }
              if (Strings.Len(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText2) > 0)
              {
                if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 <= 5)
                {
                  Color c = Color.Transparent;
                  if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 1)
                    c = Color.White;
                  if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 2)
                    c = Color.Blue;
                  if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 3)
                    c = Color.Black;
                  if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 4)
                    c = Color.Red;
                  if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 5)
                    c = Color.Yellow;
                  if (Zoom == 0)
                  {
                    string str = Strings.UCase(Strings.Left(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText2, 5));
                    if (Strings.Len(str) >= 1)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 1, 1), new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 7, ty + 30, c, true);
                    if (Strings.Len(str) >= 2)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 2, 1), new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 17, ty + 30, c, true);
                    if (Strings.Len(str) >= 3)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 3, 1), new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 27, ty + 30, c, true);
                    if (Strings.Len(str) >= 4)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 4, 1), new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 37, ty + 30, c, true);
                    if (Strings.Len(str) >= 5)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 5, 1), new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 48, ty + 30, c, true);
                  }
                  else if ((double) this.game.Data.RuleVar[352] == 0.0 & Zoom == 1)
                  {
                    index1 = 1;
                    do
                    {
                      string str = Strings.UCase(Strings.Mid(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText2, index1, 1));
                      if (Strings.Len(str) >= 1)
                        DrawMod.DrawTextColouredOutline(ref toG, str, new Font("Arial Black", 16f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 16 + 20 * (index1 - 1), ty + 12 + 48, c, true);
                      ++index1;
                    }
                    while (index1 <= 5);
                  }
                  else if (Zoom == -1)
                  {
                    string str = Strings.UCase(Strings.Left(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText2, 5));
                    if (Strings.Len(str) >= 1)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 1, 1), new Font("Courier New", 9f, FontStyle.Regular, GraphicsUnit.Pixel), tx + 1, ty + 12, c);
                    if (Strings.Len(str) >= 2)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 2, 1), new Font("Courier New", 9f, FontStyle.Regular, GraphicsUnit.Pixel), tx + 6, ty + 12, c);
                    if (Strings.Len(str) >= 3)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 3, 1), new Font("Courier New", 9f, FontStyle.Regular, GraphicsUnit.Pixel), tx + 11, ty + 12, c);
                    if (Strings.Len(str) >= 4)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 4, 1), new Font("Courier New", 9f, FontStyle.Regular, GraphicsUnit.Pixel), tx + 16, ty + 12, c);
                    if (Strings.Len(str) >= 5)
                      DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 5, 1), new Font("Courier New", 9f, FontStyle.Regular, GraphicsUnit.Pixel), tx + 21, ty + 12, c);
                  }
                }
                else
                {
                  switch (Zoom)
                  {
                    case -1:
                      if (Strings.Len(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText2) > 0)
                      {
                        string str = Strings.UCase(Strings.Left(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText2, 1));
                        SizeF sizeF10 = toG.MeasureString(Strings.Left(str, 1), new Font("Arial Black", 12f, FontStyle.Bold, GraphicsUnit.Pixel));
                        Color c = Color.Transparent;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 6)
                          c = Color.White;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 7)
                          c = Color.Blue;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 8)
                          c = Color.Black;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 9)
                          c = Color.Red;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 10)
                          c = Color.Yellow;
                        if (Strings.Len(str) >= 1)
                        {
                          DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 1, 1), new Font("Arial Black", 12f, FontStyle.Bold, GraphicsUnit.Pixel), (int) Math.Round((double) ((float) (tx + 16) - sizeF10.Width / 2f)), ty + 9, c, true);
                          break;
                        }
                        break;
                      }
                      break;
                    case 0:
                      if (Strings.Len(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText2) > 0)
                      {
                        string str = Strings.UCase(Strings.Left(this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelText2, 1));
                        SizeF sizeF11 = toG.MeasureString(Strings.Left(str, 1), new Font("Arial Black", 16f, FontStyle.Bold, GraphicsUnit.Pixel));
                        Color c = Color.Transparent;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 6)
                          c = Color.White;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 7)
                          c = Color.Blue;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 8)
                          c = Color.Black;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 9)
                          c = Color.Red;
                        if (this.game.Data.MapObj[cmap].HexObj[cx, cy].LabelType2 == 10)
                          c = Color.Yellow;
                        if (Strings.Len(str) >= 1)
                        {
                          DrawMod.DrawTextColouredOutline(ref toG, Strings.Mid(str, 1, 1), new Font("Arial Black", 16f, FontStyle.Bold, GraphicsUnit.Pixel), (int) Math.Round((double) ((float) (tx + 32) - sizeF11.Width / 2f)), ty + 28, c, true);
                          break;
                        }
                        break;
                      }
                      break;
                  }
                }
              }
            }
          }
          if (num182 == 1 & !NoShader)
          {
            ref Graphics local341 = ref toG;
            bitmap4 = BitmapStore.GetBitmap(this.game.SHADEDHEX, Zoom);
            ref Bitmap local342 = ref bitmap4;
            int x = tx;
            int y = ty;
            DrawMod.DrawSimple(ref local341, ref local342, x, y);
          }
        }
        else
        {
          ref Graphics local343 = ref toG;
          bitmap4 = BitmapStore.GetBitmap(this.game.NOHEX, Zoom);
          ref Bitmap local344 = ref bitmap4;
          int x = tx;
          int y = ty;
          DrawMod.DrawSimple(ref local343, ref local344, x, y);
        }
      }
      if (!this.game.EditObj.AIMoving & !InfoMode && this.game.EditObj.OrderType == 25 & this.game.EditObj.OrderSubType == 1)
      {
        if (this.game.EditObj.TempCoordList.counter > 0)
        {
          int counter = this.game.EditObj.TempCoordList.counter;
          for (index1 = 0; index1 <= counter; ++index1)
          {
            coordinate2 = this.game.EditObj.TempCoordList.coord[index1];
            Coordinate coordinate3;
            if (coordinate2.x == cx & coordinate2.y == cy & index1 < this.game.EditObj.TempCoordList.counter)
            {
              coordinate3 = this.game.EditObj.TempCoordList.coord[index1 + 1];
              int index125 = this.game.HandyFunctionsObj.HexFacing(coordinate2.x, coordinate2.y, coordinate2.map, coordinate3.x, coordinate3.y, coordinate3.map) - 1;
              int index126 = (int) Math.Round((double) this.game.Data.RuleVar[32]);
              ref Graphics local345 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[index126].BasicSpriteID[index125], Zoom);
              ref Bitmap local346 = ref bitmap4;
              int x = tx;
              int y = ty;
              DrawMod.Draw(ref local345, ref local346, x, y, 0.6f, 0.2f, 0.6f, 0.6f);
            }
            if (coordinate2.x == cx & coordinate2.y == cy & index1 > 0)
            {
              coordinate3 = this.game.EditObj.TempCoordList.coord[index1 - 1];
              int index127 = this.game.HandyFunctionsObj.HexFacing(coordinate2.x, coordinate2.y, coordinate2.map, coordinate3.x, coordinate3.y, coordinate3.map) - 1;
              int index128 = (int) Math.Round((double) this.game.Data.RuleVar[32]);
              ref Graphics local347 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[index128].BasicSpriteID[index127], Zoom);
              ref Bitmap local348 = ref bitmap4;
              int x = tx;
              int y = ty;
              DrawMod.Draw(ref local347, ref local348, x, y, 0.6f, 0.2f, 0.6f, 0.6f);
            }
          }
        }
        else if (this.game.EditObj.TempCoordList.counter == 0)
        {
          coordinate2 = this.game.EditObj.TempCoordList.coord[this.game.EditObj.TempCoordList.counter];
          if (coordinate2.x == cx & coordinate2.y == cy)
          {
            int index129 = (int) Math.Round((double) this.game.Data.RuleVar[32]);
            ref Graphics local349 = ref toG;
            bitmap4 = BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[index129].BasicSpriteID[0], Zoom);
            ref Bitmap local350 = ref bitmap4;
            int x = tx;
            int y = ty;
            DrawMod.Draw(ref local349, ref local350, x, y, 0.6f, 0.2f, 0.6f, 0.6f);
          }
        }
      }
      if (!this.game.EditObj.AIMoving & !InfoMode && flag3)
      {
        if (Information.IsNothing((object) this.game.EditObj.TempValueSpecial))
          this.game.HandyFunctionsObj.RedimTempValueSpecial(0);
        if (this.game.EditObj.TempValueSpecial[cmap].Value[cx, cy] == 1 | this.game.EditObj.TempValueSpecial[cmap].Value[cx, cy] == 3)
        {
          switch (Zoom)
          {
            case -1:
              ref Graphics local351 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(this.game.SUPPLIESSYMBOL);
              ref Bitmap local352 = ref bitmap4;
              int x12 = tx - 10;
              int y12 = ty;
              DrawMod.DrawSimple(ref local351, ref local352, x12, y12);
              break;
            case 0:
              ref Graphics local353 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(this.game.SUPPLIESSYMBOL);
              ref Bitmap local354 = ref bitmap4;
              int x13 = (int) Math.Round((double) (tx - 5) + (double) num6 / 4.0);
              int y13 = (int) Math.Round((double) ty + (double) num7 / 4.0);
              DrawMod.DrawSimple(ref local353, ref local354, x13, y13);
              break;
            default:
              ref Graphics local355 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(this.game.SUPPLIESSYMBOL);
              ref Bitmap local356 = ref bitmap4;
              int x14 = (int) Math.Round((double) tx + (double) num6 / 4.0 + 10.0);
              int y14 = (int) Math.Round((double) ty + (double) num7 / 4.0 + 8.0);
              DrawMod.DrawSimple(ref local355, ref local356, x14, y14);
              break;
          }
        }
      }
      if (flag1 & !InfoMode)
      {
        index1 = 0;
        do
        {
          if (this.game.EditObj.HisHotX == cx & this.game.EditObj.HisHotY == cy & this.game.EditObj.HisHotMap == cmap)
          {
            if (this.game.EditObj.HisAttackType == 2 | this.game.EditObj.HisAttackType == 12)
            {
              if (this.game.EditObj.HisNeighbour.data[0] > 0)
              {
                ref Graphics local357 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.ATTACK0, Zoom);
                ref Bitmap local358 = ref bitmap4;
                int x = tx;
                int y = ty;
                DrawMod.DrawSimple(ref local357, ref local358, x, y);
              }
              if (this.game.EditObj.HisNeighbour.data[1] > 0)
              {
                ref Graphics local359 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.ATTACK1, Zoom);
                ref Bitmap local360 = ref bitmap4;
                int x = tx;
                int y = ty;
                DrawMod.DrawSimple(ref local359, ref local360, x, y);
              }
              if (this.game.EditObj.HisNeighbour.data[2] > 0)
              {
                ref Graphics local361 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.ATTACK2, Zoom);
                ref Bitmap local362 = ref bitmap4;
                int x = tx;
                int y = ty;
                DrawMod.DrawSimple(ref local361, ref local362, x, y);
              }
              if (this.game.EditObj.HisNeighbour.data[3] > 0)
              {
                ref Graphics local363 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.ATTACK3, Zoom);
                ref Bitmap local364 = ref bitmap4;
                int x = tx;
                int y = ty;
                DrawMod.DrawSimple(ref local363, ref local364, x, y);
              }
              if (this.game.EditObj.HisNeighbour.data[4] > 0)
              {
                ref Graphics local365 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.ATTACK4, Zoom);
                ref Bitmap local366 = ref bitmap4;
                int x = tx;
                int y = ty;
                DrawMod.DrawSimple(ref local365, ref local366, x, y);
              }
              if (this.game.EditObj.HisNeighbour.data[5] > 0)
              {
                ref Graphics local367 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.ATTACK5, Zoom);
                ref Bitmap local368 = ref bitmap4;
                int x = tx;
                int y = ty;
                DrawMod.DrawSimple(ref local367, ref local368, x, y);
              }
            }
            if (this.game.EditObj.HisAttackType == 21)
            {
              ref Graphics local369 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(this.game.ATTACKAMPH, Zoom);
              ref Bitmap local370 = ref bitmap4;
              int x = tx;
              int y = ty;
              DrawMod.DrawSimple(ref local369, ref local370, x, y);
            }
            if (this.game.EditObj.HisAttackType == 19)
            {
              ref Graphics local371 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(this.game.ATTACKPARADROP, Zoom);
              ref Bitmap local372 = ref bitmap4;
              int x = tx;
              int y = ty;
              DrawMod.DrawSimple(ref local371, ref local372, x, y);
            }
            if (this.game.EditObj.HisAttackType == 11 | this.game.EditObj.HisAttackType == 13)
            {
              ref Graphics local373 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(this.game.ATTACKART, Zoom);
              ref Bitmap local374 = ref bitmap4;
              int x = tx;
              int y = ty;
              DrawMod.DrawSimple(ref local373, ref local374, x, y);
            }
            if (this.game.EditObj.HisAttackType == 55 | this.game.EditObj.HisAttackType == 14 | this.game.EditObj.HisAttackType == 15 | this.game.EditObj.HisAttackType == 17)
            {
              ref Graphics local375 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(this.game.ATTACKAIR, Zoom);
              ref Bitmap local376 = ref bitmap4;
              int x = tx;
              int y = ty;
              DrawMod.DrawSimple(ref local375, ref local376, x, y);
            }
            if (this.game.EditObj.HisAttackType == 31)
            {
              ref Graphics local377 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(this.game.TARGETHEX, Zoom);
              ref Bitmap local378 = ref bitmap4;
              int x = tx;
              int y = ty;
              DrawMod.DrawSimple(ref local377, ref local378, x, y);
            }
            if (this.game.EditObj.HisAttackType == 18)
            {
              ref Graphics local379 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(this.game.ATTACKAIR, Zoom);
              ref Bitmap local380 = ref bitmap4;
              int x = tx;
              int y = ty;
              DrawMod.DrawSimple(ref local379, ref local380, x, y);
            }
            if (this.game.EditObj.HisAttackType < 1)
            {
              ref Graphics local381 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(this.game.SELECTEDHEX, Zoom);
              ref Bitmap local382 = ref bitmap4;
              int x = tx;
              int y = ty;
              DrawMod.DrawSimple(ref local381, ref local382, x, y);
            }
          }
          ++index1;
        }
        while (index1 <= 5);
      }
      if (!this.game.EditObj.AIMoving & !InfoMode && this.game.EditObj.OrderType == 40 && (double) this.game.Data.RuleVar[858] >= (double) this.game.EditObj.TempValue3[0].Value[cx, cy])
      {
        switch (Zoom)
        {
          case -1:
            ref Graphics local383 = ref toG;
            bitmap4 = BitmapStore.GetBitmap(this.game.SUPPLIESSYMBOL);
            ref Bitmap local384 = ref bitmap4;
            int x15 = tx - 10;
            int y15 = ty;
            DrawMod.DrawSimple(ref local383, ref local384, x15, y15);
            break;
          case 0:
            ref Graphics local385 = ref toG;
            bitmap4 = BitmapStore.GetBitmap(this.game.SUPPLIESSYMBOL);
            ref Bitmap local386 = ref bitmap4;
            int x16 = (int) Math.Round((double) (tx - 5) + (double) num6 / 4.0);
            int y16 = (int) Math.Round((double) ty + (double) num7 / 4.0);
            DrawMod.DrawSimple(ref local385, ref local386, x16, y16);
            break;
          default:
            ref Graphics local387 = ref toG;
            bitmap4 = BitmapStore.GetBitmap(this.game.SUPPLIESSYMBOL);
            ref Bitmap local388 = ref bitmap4;
            int x17 = (int) Math.Round((double) tx + (double) num6 / 4.0 + 10.0);
            int y17 = (int) Math.Round((double) ty + (double) num7 / 4.0 + 8.0);
            DrawMod.DrawSimple(ref local387, ref local388, x17, y17);
            break;
        }
      }
      if (!this.game.EditObj.AIMoving & !InfoMode && (this.game.EditObj.OrderType == 1 | this.game.EditObj.OrderType == 48) & this.game.Data.Round > 0)
      {
        index1 = 0;
        do
        {
          if (this.game.EditObj.TempAttack[cmap].Value[cx, cy, index1])
          {
            if (index1 == 0)
            {
              ref Graphics local389 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(this.game.ATTACK0, Zoom);
              ref Bitmap local390 = ref bitmap4;
              int x18 = tx;
              int y18 = ty;
              DrawMod.DrawSimple(ref local389, ref local390, x18, y18);
            }
            if (index1 == 1)
            {
              ref Graphics local391 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(this.game.ATTACK1, Zoom);
              ref Bitmap local392 = ref bitmap4;
              int x19 = tx;
              int y19 = ty;
              DrawMod.DrawSimple(ref local391, ref local392, x19, y19);
            }
            if (index1 == 2)
            {
              ref Graphics local393 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(this.game.ATTACK2, Zoom);
              ref Bitmap local394 = ref bitmap4;
              int x20 = tx;
              int y20 = ty;
              DrawMod.DrawSimple(ref local393, ref local394, x20, y20);
            }
            if (index1 == 3)
            {
              ref Graphics local395 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(this.game.ATTACK3, Zoom);
              ref Bitmap local396 = ref bitmap4;
              int x21 = tx;
              int y21 = ty;
              DrawMod.DrawSimple(ref local395, ref local396, x21, y21);
            }
            if (index1 == 4)
            {
              ref Graphics local397 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(this.game.ATTACK4, Zoom);
              ref Bitmap local398 = ref bitmap4;
              int x22 = tx;
              int y22 = ty;
              DrawMod.DrawSimple(ref local397, ref local398, x22, y22);
            }
            if (index1 == 5)
            {
              ref Graphics local399 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(this.game.ATTACK5, Zoom);
              ref Bitmap local400 = ref bitmap4;
              int x23 = tx;
              int y23 = ty;
              DrawMod.DrawSimple(ref local399, ref local400, x23, y23);
            }
          }
          ++index1;
        }
        while (index1 <= 5);
      }
      if (this.game.EditObj.HexRasterOn & !ispredrawing)
      {
        ref Graphics local401 = ref toG;
        bitmap4 = BitmapStore.GetBitmap(this.game.HEXRASTER, Zoom);
        ref Bitmap local402 = ref bitmap4;
        int x24 = tx;
        int y24 = ty;
        DrawMod.DrawSimple(ref local401, ref local402, x24, y24);
      }
      if (index6 > -1 && (double) this.game.Data.RuleVar[330] == 1.0 & !this.game.Data.LandscapeTypeObj[index6].BlackedOut & !InfoMode)
      {
        int num190 = 1;
        do
        {
          if (num190 == 1)
            index1 = 2;
          if (num190 == 2)
            index1 = 3;
          if (num190 == 3)
            index1 = 6;
          if (num190 == 4)
            index1 = 5;
          if (num190 == 5)
            index1 = 4;
          if (num190 == 6)
            index1 = 1;
          coordinate1 = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, cmap, index1);
          if (!coordinate1.onmap && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[coordinate1.map].HexObj[coordinate1.x, coordinate1.y].LandscapeType].BlackedOut)
          {
            if (cx % 2 > 0 & index1 == 1)
              index1 = 7;
            if (cx != 0 & cx % 2 == 0 & index1 == 4)
              index1 = 8;
            if (cy == 0 & cx != 0 & cx % 2 == 0 & index1 == 6)
              index1 = 11;
            if (cx != this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth & cy == this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight & index1 == 3)
              index1 = 9;
            if (cx != 0 & cy == this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight & index1 == 5)
              index1 = 10;
            ref Graphics local403 = ref toG;
            bitmap4 = BitmapStore.GetBitmap(this.game.MAPBORDER[index1 - 1], Zoom);
            ref Bitmap local404 = ref bitmap4;
            int x25 = tx;
            int y25 = ty;
            DrawMod.DrawSimple(ref local403, ref local404, x25, y25);
          }
          ++num190;
        }
        while (num190 <= 6);
      }
      if (!InfoMode & !this.game.EditObj.AIMoving & !flag1)
      {
        if (this.game.SelectX == cx & this.game.SelectY == cy)
        {
          ref Graphics local405 = ref toG;
          bitmap4 = BitmapStore.GetBitmap(this.game.SELECTEDHEX, Zoom);
          ref Bitmap local406 = ref bitmap4;
          int x26 = tx;
          int y26 = ty;
          DrawMod.DrawSimple(ref local405, ref local406, x26, y26);
        }
        if (this.game.EditObj.TargetX == cx & this.game.EditObj.TargetY == cy & (this.game.EditObj.OrderType == 2 | this.game.EditObj.OrderType == 11 | this.game.EditObj.OrderType == 13 | this.game.EditObj.OrderType == 12))
        {
          ref Graphics local407 = ref toG;
          bitmap4 = BitmapStore.GetBitmap(this.game.TARGETHEX, Zoom);
          ref Bitmap local408 = ref bitmap4;
          int x27 = tx;
          int y27 = ty;
          DrawMod.DrawSimple(ref local407, ref local408, x27, y27);
        }
        if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(this.game.EditObj.TutX, (object) cx, false), Operators.CompareObjectEqual(this.game.EditObj.TutY, (object) cy, false))))
        {
          ref Graphics local409 = ref toG;
          bitmap4 = BitmapStore.GetBitmap(this.game.TUTHEX, Zoom);
          ref Bitmap local410 = ref bitmap4;
          int x28 = tx;
          int y28 = ty;
          DrawMod.DrawSimple(ref local409, ref local410, x28, y28);
        }
      }
      if (!this.game.EditObj.AIMoving & !InfoMode && (double) this.game.Data.RuleVar[540] == 1.0 & this.game.EditObj.mouseOverActive)
      {
        int[] numArray33 = new int[7];
        if (this.game.EditObj.OrderType == 48 & this.game.Data.Product >= 6 & flag2 && this.game.EditObj.tempGroupMoveCounter > -1)
        {
          int groupMoveCounter = this.game.EditObj.tempGroupMoveCounter;
          for (int index130 = 0; index130 <= groupMoveCounter; ++index130)
          {
            if (!Information.IsNothing((object) this.game.EditObj.tempGroupMovePath[index130]))
            {
              int slot = this.game.EditObj.tempGroupMovePath[index130].FindSlot(cx, cy, 0);
              if (slot > -1 & slot < this.game.EditObj.tempGroupMovePath[index130].counter)
              {
                int num191 = -1;
                int num192 = -1;
                if (slot > 0 && this.game.EditObj.TempValue[0].Value[this.game.EditObj.tempGroupMovePath[index130].coord[slot - 1].x, this.game.EditObj.tempGroupMovePath[index130].coord[slot - 1].y] < 9999)
                  num192 = this.game.HandyFunctionsObj.HexFacing(cx, cy, 0, this.game.EditObj.tempGroupMovePath[index130].coord[slot - 1].x, this.game.EditObj.tempGroupMovePath[index130].coord[slot - 1].y, 0);
                if (slot < this.game.EditObj.tempGroupMovePath[index130].counter)
                  num191 = this.game.HandyFunctionsObj.HexFacing(cx, cy, 0, this.game.EditObj.tempGroupMovePath[index130].coord[slot + 1].x, this.game.EditObj.tempGroupMovePath[index130].coord[slot + 1].y, 0);
                numArray33[0] = 0;
                numArray33[1] = 0;
                numArray33[2] = 0;
                numArray33[3] = 0;
                numArray33[4] = 0;
                numArray33[5] = 0;
                if (num191 > -1)
                  numArray33[num191 - 1] = 1;
                if (num192 > -1)
                  numArray33[num192 - 1] = 2;
                int num193 = this.game.ARROW64[numArray33[0], numArray33[1], numArray33[2], numArray33[3], numArray33[4], numArray33[5]];
                if (num193 > 0)
                {
                  num16 = (int) Math.Round(Math.Floor((double) (num193 - 1) / 6.0));
                  int num194 = num193 - num16 * 6 - 1;
                  ref Graphics local411 = ref toG;
                  bitmap4 = BitmapStore.GetBitmap(this.game.ARROWSHEET, Zoom);
                  ref Bitmap local412 = ref bitmap4;
                  rectangle2 = new Rectangle(num194 * num6, num16 * num7, num6, num7);
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(tx, ty, num6, num7);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2ColouredNew(ref local411, ref local412, srcrect, destrect, 1f, 1f, 1f, 0.6f);
                }
              }
            }
          }
        }
        if (!Information.IsNothing((object) this.game.EditObj.TempMovePathList) & this.game.EditObj.OrderType != 48)
        {
          int slot = this.game.EditObj.TempMovePathList.FindSlot(cx, cy, 0);
          if (slot > -1 & slot <= this.game.EditObj.TempMovePathList.counter & this.game.EditObj.MouseOverX > -1 & this.game.EditObj.MouseOverY > -1 && this.game.EditObj.TempValue[0].Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY] < 9999)
          {
            int num195 = -1;
            int num196 = -1;
            if (slot > 0)
              num196 = this.game.HandyFunctionsObj.HexFacing(cx, cy, 0, this.game.EditObj.TempMovePathList.coord[slot - 1].x, this.game.EditObj.TempMovePathList.coord[slot - 1].y, 0);
            if (slot < this.game.EditObj.TempMovePathList.counter)
              num195 = this.game.HandyFunctionsObj.HexFacing(cx, cy, 0, this.game.EditObj.TempMovePathList.coord[slot + 1].x, this.game.EditObj.TempMovePathList.coord[slot + 1].y, 0);
            if (num195 > -1)
              numArray33[num195 - 1] = 1;
            if (num196 > -1)
              numArray33[num196 - 1] = 2;
            int num197 = this.game.ARROW64[numArray33[0], numArray33[1], numArray33[2], numArray33[3], numArray33[4], numArray33[5]];
            if (num196 > -1)
              numArray33[num196 - 1] = 2;
            if (cx == 31 & cy == 17)
              cx = cx;
            bool flag27 = false;
            bool flag28 = false;
            if (this.game.EditObj.OrderType == 18 && (int) Math.Round(Conversion.Val(this.game.Data.Designer)) >= 82)
            {
              if (!flag27 & slot > 0 & num196 > 0)
              {
                int x29 = this.game.EditObj.TempMovePathList.coord[slot - 1].x;
                int y29 = this.game.EditObj.TempMovePathList.coord[slot - 1].y;
                if (this.game.EditObj.TempCameFrom[0].Value[x29, y29].onmap & this.game.EditObj.TempCameFrom[0].Value[x29, y29].data1 > 0)
                {
                  if (this.game.EditObj.TempCameFrom[0].Value[x29, y29].data1 != this.game.EditObj.TempCameFrom[0].Value[cx, cy].data1)
                  {
                    numArray33[num196 - 1] = 0;
                    num197 = this.game.ARROW64[numArray33[0], numArray33[1], numArray33[2], numArray33[3], numArray33[4], numArray33[5]];
                    flag28 = true;
                  }
                  else if (this.game.EditObj.TempCameFrom[0].Value[x29, y29].data1 > 0 & !this.game.EditObj.TempCameFrom[0].Value[cx, cy].onmap)
                  {
                    numArray33[num196 - 1] = 0;
                    num197 = this.game.ARROW64[numArray33[0], numArray33[1], numArray33[2], numArray33[3], numArray33[4], numArray33[5]];
                    flag28 = true;
                  }
                }
                else if (this.game.EditObj.TempCameFrom[0].Value[x29, y29].data1 > 0 & !this.game.EditObj.TempCameFrom[0].Value[x29, y29].onmap)
                {
                  numArray33[num196 - 1] = 0;
                  num197 = this.game.ARROW64[numArray33[0], numArray33[1], numArray33[2], numArray33[3], numArray33[4], numArray33[5]];
                  flag28 = true;
                }
              }
              if (!flag27 & slot < this.game.EditObj.TempMovePathList.counter & num195 > 0)
              {
                int x30 = this.game.EditObj.TempMovePathList.coord[slot + 1].x;
                int y30 = this.game.EditObj.TempMovePathList.coord[slot + 1].y;
                if (this.game.EditObj.TempCameFrom[0].Value[cx, cy].onmap & this.game.EditObj.TempCameFrom[0].Value[cx, cy].data1 > 0)
                {
                  if (this.game.EditObj.TempCameFrom[0].Value[cx, cy].data1 != this.game.EditObj.TempCameFrom[0].Value[x30, y30].data1)
                  {
                    numArray33[num195 - 1] = 0;
                    num197 = this.game.ARROW64[numArray33[0], numArray33[1], numArray33[2], numArray33[3], numArray33[4], numArray33[5]];
                    flag28 = true;
                  }
                  else if (this.game.EditObj.TempCameFrom[0].Value[cx, cy].data1 > 0 & !this.game.EditObj.TempCameFrom[0].Value[x30, y30].onmap)
                  {
                    numArray33[num195 - 1] = 0;
                    num197 = this.game.ARROW64[numArray33[0], numArray33[1], numArray33[2], numArray33[3], numArray33[4], numArray33[5]];
                    flag28 = true;
                  }
                }
                else if (this.game.EditObj.TempCameFrom[0].Value[cx, cy].data1 > 0 & !this.game.EditObj.TempCameFrom[0].Value[x30, y30].onmap)
                {
                  numArray33[num195 - 1] = 0;
                  num197 = this.game.ARROW64[numArray33[0], numArray33[1], numArray33[2], numArray33[3], numArray33[4], numArray33[5]];
                  flag28 = true;
                }
              }
              if (num197 == 0 & num195 == -1 & num196 == -1 && this.game.EditObj.TempCameFrom[0].Value[cx, cy].data2 > 0 & this.game.EditObj.TempCameFrom[0].Value[cx, cy].data1 > 0)
                flag28 = true;
              if (num197 > 0 & (num195 == -1 | num196 == -1) & (num195 > -1 | num196 > -1) && slot > 0 && this.game.EditObj.TempCameFrom[0].Value[this.game.EditObj.TempMovePathList.coord[slot - 1].x, this.game.EditObj.TempMovePathList.coord[slot - 1].y].data2 > 0)
                flag28 = true;
            }
            if (flag28)
            {
              ref Graphics local413 = ref toG;
              bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
              ref Bitmap local414 = ref bitmap4;
              rectangle2 = new Rectangle(2604, 0, 42, 32);
              Rectangle srcrect = rectangle2;
              rectangle1 = new Rectangle(tx + (int) Math.Round((double) num6 * 0.125), ty + (int) Math.Round((double) num7 * 0.166), (int) Math.Round((double) num6 * 0.75), (int) Math.Round((double) num7 * 0.66));
              Rectangle destrect = rectangle1;
              DrawMod.DrawSimplePart2ColouredOld(ref local413, ref local414, srcrect, destrect, 1f, 1f, 1f, 1f);
            }
            if (num197 > 0)
            {
              num16 = (int) Math.Round(Math.Floor((double) (num197 - 1) / 6.0));
              int num198 = num197 - num16 * 6 - 1;
              if (!flag27 & num197 > 0)
              {
                ref Graphics local415 = ref toG;
                bitmap4 = BitmapStore.GetBitmap(this.game.ARROWSHEET, Zoom);
                ref Bitmap local416 = ref bitmap4;
                rectangle2 = new Rectangle(num198 * num6, num16 * num7, num6, num7);
                Rectangle srcrect = rectangle2;
                rectangle1 = new Rectangle(tx, ty, num6, num7);
                Rectangle destrect = rectangle1;
                DrawMod.DrawSimplePart2(ref local415, ref local416, srcrect, destrect);
              }
              if (this.game.EditObj.OrderType == 36)
              {
                if (this.game.EditObj.OrderSubType == 8)
                {
                  int num199 = 0;
                  int index131 = 0;
                  do
                  {
                    if (numArray33[index131] > 0)
                    {
                      int nr21 = this.game.Data.RoadTypeObj[0].BasicSpriteID[index131];
                      index10 = (int) Math.Round((double) BitmapStore.GetWidth(nr21, Zoom) / (double) num6);
                      index8 = 0;
                      ++num199;
                      coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, index131 + 1);
                      if (index10 > 1)
                        index8 = !coordinate1.onmap ? new Random((int) Math.Round(a1)).Next(0, num198 - 1) : new Random((int) Math.Round(a1)).Next(0, num198 - 1);
                      ref Graphics local417 = ref toG;
                      bitmap4 = BitmapStore.GetBitmap(nr21, Zoom);
                      ref Bitmap local418 = ref bitmap4;
                      rectangle2 = new Rectangle(index8 * num6, 0, num6, num7);
                      Rectangle srcrect = rectangle2;
                      rectangle1 = new Rectangle(tx, ty, num6, num7);
                      Rectangle destrect = rectangle1;
                      DrawMod.DrawSimplePart2ColouredNew(ref local417, ref local418, srcrect, destrect, 1f, 0.0f, 0.0f, 1f);
                    }
                    ++index131;
                  }
                  while (index131 <= 5);
                  if (num199 > 1)
                  {
                    int center6spriteId = this.game.Data.RoadTypeObj[0].center6spriteId;
                    if (center6spriteId > -1)
                    {
                      ref Graphics local419 = ref toG;
                      bitmap4 = BitmapStore.GetBitmap(center6spriteId, Zoom);
                      ref Bitmap local420 = ref bitmap4;
                      rectangle2 = new Rectangle(index8 * num6, 0, num6, num7);
                      Rectangle srcrect = rectangle2;
                      rectangle1 = new Rectangle(tx, ty, num6, num7);
                      Rectangle destrect = rectangle1;
                      DrawMod.DrawSimplePart2ColouredNew(ref local419, ref local420, srcrect, destrect, 1f, 0.0f, 0.0f, 1f);
                    }
                  }
                }
                else if (this.game.Data.RoadTypeObj[this.game.EditObj.OrderSubType].UseSheet)
                {
                  int[] numArray34 = new int[7];
                  index9 = 0;
                  int index132 = 0;
                  do
                  {
                    if (numArray33[index132] > 0)
                    {
                      if (this.game.Data.MapObj[0].HexObj[cx, cy].RoadType[index132] < this.game.EditObj.OrderSubType)
                      {
                        numArray34[index132] = 1;
                        index9 = 1;
                      }
                      else if (this.game.Data.MapObj[0].HexObj[cx, cy].RoadType[index132] == 2 & this.game.EditObj.OrderSubType == 0)
                      {
                        numArray34[index132] = 1;
                        index9 = 1;
                      }
                      else if (this.game.Data.MapObj[0].HexObj[cx, cy].RoadType[index132] == 2 & this.game.EditObj.OrderSubType == 1)
                      {
                        numArray34[index132] = 1;
                        index9 = 1;
                      }
                      else if (this.game.Data.MapObj[0].HexObj[cx, cy].RoadType[index132] == 3 & this.game.EditObj.OrderSubType == 1)
                      {
                        numArray34[index132] = 1;
                        index9 = 1;
                      }
                    }
                    ++index132;
                  }
                  while (index132 <= 5);
                  if (index9 == 1)
                  {
                    int sheetSpriteId = this.game.Data.RoadTypeObj[this.game.EditObj.OrderSubType].SheetSpriteID;
                    int index133 = this.game.SPRITE64[numArray34[0], numArray34[1], numArray34[2], numArray34[3], numArray34[4], numArray34[5]];
                    ref Graphics local421 = ref toG;
                    bitmap4 = BitmapStore.GetBitmap(sheetSpriteId, Zoom);
                    ref Bitmap local422 = ref bitmap4;
                    rectangle2 = new Rectangle(this.game.SHEETX[index133] * num6, this.game.SHEETY[index133] * num7, num6, num7);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(tx, ty, num6, num7);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local421, ref local422, srcrect, destrect);
                  }
                }
                else if (!this.game.Data.RoadTypeObj[this.game.EditObj.OrderSubType].SpecialLayer)
                {
                  int num200 = 0;
                  int index134 = 0;
                  do
                  {
                    if (numArray33[index134] > 0)
                    {
                      int nr22 = this.game.Data.RoadTypeObj[this.game.EditObj.OrderSubType].BasicSpriteID[index134];
                      index10 = (int) Math.Round((double) BitmapStore.GetWidth(nr22, Zoom) / (double) num6);
                      index8 = 0;
                      ++num200;
                      coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, index134 + 1);
                      if (index10 > 1)
                        index8 = !coordinate1.onmap ? new Random((int) Math.Round(a1)).Next(0, num198 - 1) : new Random((int) Math.Round(a1)).Next(0, num198 - 1);
                      ref Graphics local423 = ref toG;
                      bitmap4 = BitmapStore.GetBitmap(nr22, Zoom);
                      ref Bitmap local424 = ref bitmap4;
                      rectangle2 = new Rectangle(index8 * num6, 0, num6, num7);
                      Rectangle srcrect = rectangle2;
                      rectangle1 = new Rectangle(tx, ty, num6, num7);
                      Rectangle destrect = rectangle1;
                      DrawMod.DrawSimplePart2(ref local423, ref local424, srcrect, destrect);
                    }
                    ++index134;
                  }
                  while (index134 <= 5);
                  if (num200 > 1)
                  {
                    int center6spriteId = this.game.Data.RoadTypeObj[this.game.EditObj.OrderSubType].center6spriteId;
                    if (center6spriteId > -1)
                    {
                      ref Graphics local425 = ref toG;
                      bitmap4 = BitmapStore.GetBitmap(center6spriteId, Zoom);
                      ref Bitmap local426 = ref bitmap4;
                      rectangle2 = new Rectangle(index8 * num6, 0, num6, num7);
                      Rectangle srcrect = rectangle2;
                      rectangle1 = new Rectangle(tx, ty, num6, num7);
                      Rectangle destrect = rectangle1;
                      DrawMod.DrawSimplePart2(ref local425, ref local426, srcrect, destrect);
                    }
                  }
                }
              }
            }
          }
        }
      }
      if (this.game.EditObj.RealRound == 0)
      {
        if (this.game.EditObj.PencilType == 9)
        {
          if (Zoom == -1)
          {
            DrawMod.DrawText(ref toG, Conversion.Str((object) this.game.Data.MapObj[cmap].HexObj[cx, cy].AreaCode[this.game.EditObj.PencilData1]), new Font("Times New Roman", 10f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 8, ty + 3);
            string str = this.game.HandyFunctionsObj.GetAreaName(this.game.EditObj.PencilData1, this.game.Data.MapObj[cmap].HexObj[cx, cy].AreaCode[this.game.EditObj.PencilData1]);
            if (Strings.Len(str) > 0)
            {
              if (Strings.Len(str) > 10)
                str = Strings.Left(str, 9) + ".";
              DrawMod.DrawText(ref toG, str, new Font(this.game.FontCol.Families[1], 8f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 3, ty + 10);
            }
          }
          else
          {
            DrawMod.DrawText(ref toG, Conversion.Str((object) this.game.Data.MapObj[cmap].HexObj[cx, cy].AreaCode[this.game.EditObj.PencilData1]), new Font("Times New Roman", 16f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 16, ty + 7);
            string str = this.game.HandyFunctionsObj.GetAreaName(this.game.EditObj.PencilData1, this.game.Data.MapObj[cmap].HexObj[cx, cy].AreaCode[this.game.EditObj.PencilData1]);
            if (Strings.Len(str) > 0)
            {
              if (Strings.Len(str) > 10)
                str = Strings.Left(str, 9) + ".";
              DrawMod.DrawText(ref toG, str, new Font(this.game.FontCol.Families[1], 10f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 6, ty + 22);
            }
          }
        }
        if (this.game.EditObj.PencilType == 11)
        {
          if (Zoom == -1)
            DrawMod.DrawText(ref toG, Conversion.Str((object) this.game.Data.MapObj[cmap].HexObj[cx, cy].GetHexLibVarValue(this.game.EditObj.PencilData1)), new Font("Times New Roman", 10f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 8, ty + 3);
          else
            DrawMod.DrawText(ref toG, Conversion.Str((object) this.game.Data.MapObj[cmap].HexObj[cx, cy].GetHexLibVarValue(this.game.EditObj.PencilData1)), new Font("Times New Roman", 16f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 16, ty + 7);
        }
        if (this.game.EditObj.PencilType == 12)
        {
          if (Zoom == -1)
            DrawMod.DrawText(ref toG, Conversion.Str((object) this.game.Data.MapObj[cmap].HexObj[cx, cy].HeightLevel), new Font("Times New Roman", 10f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 8, ty + 3);
          else
            DrawMod.DrawText(ref toG, Conversion.Str((object) this.game.Data.MapObj[cmap].HexObj[cx, cy].HeightLevel), new Font("Times New Roman", 16f, FontStyle.Bold, GraphicsUnit.Pixel), tx + 16, ty + 7);
        }
      }
      this.ThreadRelease();
      if (Information.IsNothing((object) tempg))
        return this.tmpbmp3;
label_2498:
      Bitmap bitmap6;
      return bitmap6;
    }

    public void Se1_DrawAssetBlock(
      ref Graphics g,
      int tx,
      int ty,
      ref WindowClass tWindow,
      int curAssetId,
      int assetRowOrSpecialCode,
      int specialOnX,
      int specialOnY,
      int specialType,
      int zoneNr,
      int zoneRegNr,
      bool usePreviewMode = false)
    {
      string libName1 = "SE_Data";
      if (this.slotAssets < 1)
      {
        this.slotPaid = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 500, 0, 0));
        this.slotKeyReplace = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 515, 0, 0));
        this.slotHexNames = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 382, 0, 0));
        this.slotPerks = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 381, 0, 0));
        this.slotZones = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 123, 0, 0));
        this.slotAssets = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 148, 0, 0));
        this.slotAssetLog = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 241, 0, 0));
        this.slotAssetTypes = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 144, 0, 0));
        this.slotItemType = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 149, 0, 0));
        this.slotAssetPresentation = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 166, 0, 0));
        this.slotZones = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 123, 0, 0));
        this.slotDetailPreview = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 513, 0, 0));
        this.slotDetail = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 361, 0, 0));
        this.slotOrigDetail = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 361, 0, 0));
        this.slotConstruction = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 150, 0, 0));
      }
      this.slotDetail = !usePreviewMode ? this.slotOrigDetail : (this.slotDetailPreview <= -1 ? this.slotOrigDetail : this.slotDetailPreview);
      if (this.slotDetailPreview > this.game.Data.StringListObj.GetUpperBound(0))
        this.slotDetail = this.slotOrigDetail;
      int index1 = assetRowOrSpecialCode;
      int index2 = zoneRegNr;
      int id1 = this.game.Data.RegimeObj[index2].id;
      DataClass data1 = this.game.Data;
      string str1 = "perk";
      ref string local1 = ref str1;
      string libName2 = libName1;
      data1.FindLibVar(ref local1, libName2);
      DataClass data2 = this.game.Data;
      str1 = "hexname";
      ref string local2 = ref str1;
      string libName3 = libName1;
      int libVar = data2.FindLibVar(ref local2, libName3);
      int idValue1 = -1;
      int num1 = 0;
      int x1;
      int y1;
      int idValue2;
      int idValue3;
      int num2;
      int idValue4;
      int num3;
      int regime1;
      int num4;
      if (index1 >= 9000000 & index1 < 15000000)
      {
        idValue1 = specialType;
        x1 = specialOnX;
        y1 = specialOnY;
        idValue2 = -1;
        idValue3 = 9000000 + x1 * 1000 + y1;
        num2 = zoneNr;
        idValue4 = zoneNr;
        num3 = 0;
        regime1 = this.game.Data.MapObj[0].HexObj[x1, y1].Regime;
      }
      else if (index1 >= 15000000 & index1 < 16000000)
      {
        num1 = specialType;
        x1 = specialOnX;
        y1 = specialOnY;
        idValue2 = -1;
        idValue3 = 15000000 + x1 * 1000 + y1;
        num2 = zoneNr;
        idValue4 = zoneNr;
        num3 = 0;
        regime1 = this.game.Data.MapObj[0].HexObj[x1, y1].Regime;
      }
      else
      {
        idValue1 = -1;
        idValue3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index1, 9]));
        idValue2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index1, 1]));
        num4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue2, 3)));
        x1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index1, 3]));
        y1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index1, 4]));
        num3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue2, 5)));
        idValue4 = Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(x1, y1, libName1, "Zones"));
        regime1 = this.game.Data.MapObj[0].HexObj[x1, y1].Regime;
        num2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index1, 0]));
      }
      int regime2 = this.game.Data.MapObj[0].HexObj[x1, y1].Regime;
      int id2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotZones].GetData(0, zoneNr, 6)));
      int index3 = -1;
      int num5 = -1;
      int num6 = -1;
      if (id2 > 0)
      {
        index3 = this.game.HandyFunctionsObj.GetLocationByID(id2);
        if (index3 > -1)
        {
          num5 = this.game.Data.LocObj[index3].X;
          num6 = this.game.Data.LocObj[index3].Y;
        }
      }
      int num7 = 0;
      int num8 = 0;
      int num9 = 0;
      int num10 = 0;
      int val2_1 = 0;
      int num11 = 0;
      string str2 = "";
      string str3 = "";
      int num12;
      int nr1;
      string str4;
      string str5;
      int num13;
      string str6;
      int index4;
      string str7;
      string str8;
      if (idValue2 > 0)
      {
        num7 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue2, 25)));
        num8 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue2, 5)));
        num9 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index1, 13]));
        num10 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index1, 11]));
        val2_1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index1, 6]));
        num11 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index1, 15]));
        num12 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index1, 8]));
        nr1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue2, 2)));
        str4 = this.game.Data.StringListObj[this.slotAssets].Data[index1, 10];
        if (this.game.Data.MapObj[0].HexObj[x1, y1].Location > -1 & idValue4 > 0 && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotZones].GetData(0, idValue4, 6))) != this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x1, y1].Location].ID)
        {
          str4 = this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x1, y1].Location].Name;
          this.game.Data.StringListObj[this.slotAssets].Data[index1, 10] = str4;
        }
        string data3 = this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue2, 1);
        str5 = this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue2, 12);
        num13 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index1, 5]));
        str6 = num3 != 1 ? "Private Asset\r\n" : "Public Asset\r\n";
        int idValue5 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index1, 0]));
        if (idValue5 != zoneNr)
          str6 = regime2 == this.game.Data.Turn ? str6 + "Belongs to zone: " + this.game.Data.StringListObj[this.slotZones].GetData(0, idValue5, 7) + ".\r\n" : str6 + "Is an evacuated asset. Cannot be used.\r\n";
        else if (index2 != this.game.Data.Turn & regime2 == this.game.Data.Turn)
          str6 += "Is an evacuated asset. Cannot be used.\r\n";
        if (num12 > 0)
          ;
        int num14 = 0;
        if (!usePreviewMode)
        {
          int length = this.game.Data.StringListObj[this.slotAssetLog].Length;
          for (int index5 = 0; index5 <= length; ++index5)
          {
            if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetLog].Data[index5, 0])) == idValue3 && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetLog].Data[index5, 1])) == 2 | (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetLog].Data[index5, 1])) == 1)
            {
              if (num14 == 0)
                str6 += "\r\nProblems or Special Modifiers:";
              ++num14;
              str6 = str6 + "\r\n• " + this.game.Data.StringListObj[this.slotAssetLog].Data[index5, 2];
            }
          }
        }
        if (!usePreviewMode && num12 > 0)
        {
          str6 += "\r\n\r\nConstruction costs paid so far:\r\n";
          int num15 = 0;
          int length = this.game.Data.StringListObj[this.slotPaid].Length;
          for (int index6 = 0; index6 <= length; ++index6)
          {
            if (idValue3 == (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotPaid].Data[index6, 0])))
            {
              int num16 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotPaid].Data[index6, 1]));
              int num17 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotPaid].Data[index6, 3]));
              if (num17 > 0)
              {
                ++num15;
                int num18;
                switch (num16)
                {
                  case 1:
                    int num19 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotPaid].Data[index6, 2]));
                    num18 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotConstruction].GetData3(0, idValue2, 1, 2, 2, num19, 3)));
                    int num20 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue2, 13)));
                    num18 *= num20;
                    str6 = str6 + "• " + num17.ToString() + " of " + num18.ToString() + " " + this.game.Data.StringListObj[this.slotItemType].GetData(0, num19, 1) + "\r\n";
                    continue;
                  case 2:
                    num18 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotConstruction].GetData3(0, idValue2, 1, 3, 2, this.game.Data.StringListObj[this.slotPaid].Data[index6, 2], 3)));
                    int num21 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue2, 13)));
                    num18 *= num21;
                    if (Strings.InStr(this.game.Data.StringListObj[this.slotPaid].Data[index6, 2].ToLower(), "poppoints") > 0)
                    {
                      num17 *= 100;
                      num18 *= 100;
                    }
                    if (Strings.InStr(this.game.Data.StringListObj[this.slotPaid].Data[index6, 2].ToLower(), "workerpoints") > 0)
                    {
                      num17 *= 100;
                      num18 *= 100;
                    }
                    str6 = str6 + "• " + num17.ToString() + " of " + num18.ToString() + " " + this.game.Data.StringListObj[this.slotPaid].Data[index6, 2] + "\r\n";
                    continue;
                  default:
                    continue;
                }
              }
            }
          }
          if (num15 == 0)
            str6 += "• Nothing has been paid yet\r\n";
        }
        if (regime1 != this.game.Data.Turn)
          str6 = data3;
        index4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue2, 8)));
        str2 = data3;
        str3 = str6;
      }
      else if (idValue1 > 0)
      {
        index4 = Conversions.ToInteger(this.game.Data.StringListObj[this.slotPerks].GetData(0, idValue1, 13));
        nr1 = 0;
        str6 = "";
        str7 = "";
        str4 = "";
        str5 = this.game.Data.StringListObj[this.slotPerks].GetData(0, idValue1, 1);
        str2 = str5;
        str3 = this.game.Data.StringListObj[this.slotPerks].GetData(0, idValue1, 7) + "\r\n\r\n" + "A Hex Perk is completely independent from your Public and Private Economy and delivers as long as it is connected to the Zone City.";
      }
      else if (num1 > 0)
      {
        index4 = this.game.Data.FindEventPic(77, "SE_Asset");
        nr1 = num1 > 99 ? (num1 > 299 ? 3 : 2) : 1;
        str6 = "";
        str7 = "";
        str8 = "";
        string str9 = Conversions.ToString(num1 * 100);
        if (num1 * 100 >= 1000)
          str9 = Strings.Left(str9, str9.Length - 3) + "." + Strings.Right(str9, 3);
        str5 = str9 + " Free Folk";
        str2 = str5;
        str4 = this.game.Data.MapObj[0].HexObj[x1, y1].SmallLabel;
        str3 = "There is a settlement of " + (num1 * 100).ToString() + " Free Folk in Hex " + x1.ToString() + "," + y1.ToString() + ". Free Folk can reinforce your Population if Happiness is good.";
      }
      Color c2;
      Bitmap bitmap1;
      if (this.game.EditObj.se1_SelectAssetButton == idValue3)
      {
        if (num2 != zoneNr & idValue4 == zoneNr)
        {
          c2 = Color.FromArgb((int) byte.MaxValue, 195, 195, 225);
          ref Graphics local3 = ref g;
          Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.SE1_ASSETBACKGROUND);
          ref Bitmap local4 = ref bitmap2;
          int x2 = tx;
          int y2 = ty;
          double r = (double) ((float) c2.R / (float) byte.MaxValue) - 1.0;
          double g1 = (double) ((float) c2.G / (float) byte.MaxValue) - 1.0;
          double b = (double) ((float) c2.B / (float) byte.MaxValue) - 1.0;
          DrawMod.Draw(ref local3, ref local4, x2, y2, (float) r, (float) g1, (float) b, 1f);
        }
        else if (num2 == zoneNr & idValue4 != zoneNr)
        {
          c2 = Color.FromArgb((int) byte.MaxValue, 235, 215, 235);
          ref Graphics local5 = ref g;
          Bitmap bitmap3 = BitmapStore.GetBitmap(this.game.SE1_ASSETBACKGROUND);
          ref Bitmap local6 = ref bitmap3;
          int x3 = tx;
          int y3 = ty;
          double r = (double) ((float) c2.R / (float) byte.MaxValue) - 1.0;
          double g2 = (double) ((float) c2.G / (float) byte.MaxValue) - 1.0;
          double b = (double) ((float) c2.B / (float) byte.MaxValue) - 1.0;
          DrawMod.Draw(ref local5, ref local6, x3, y3, (float) r, (float) g2, (float) b, 1f);
        }
        else if (idValue1 > 0)
        {
          c2 = Color.FromArgb((int) byte.MaxValue, 235, 235, 195);
          ref Graphics local7 = ref g;
          Bitmap bitmap4 = BitmapStore.GetBitmap(this.game.SE1_ASSETBACKGROUND);
          ref Bitmap local8 = ref bitmap4;
          int x4 = tx;
          int y4 = ty;
          double r = (double) ((float) c2.R / (float) byte.MaxValue) - 1.0;
          double g3 = (double) ((float) c2.G / (float) byte.MaxValue) - 1.0;
          double b = (double) ((float) c2.B / (float) byte.MaxValue) - 1.0;
          DrawMod.Draw(ref local7, ref local8, x4, y4, (float) r, (float) g3, (float) b, 1f);
        }
        else if (num1 > 0)
        {
          c2 = Color.FromArgb((int) byte.MaxValue, 215, 215, 175);
          ref Graphics local9 = ref g;
          Bitmap bitmap5 = BitmapStore.GetBitmap(this.game.SE1_ASSETBACKGROUND);
          ref Bitmap local10 = ref bitmap5;
          int x5 = tx;
          int y5 = ty;
          double r = (double) ((float) c2.R / (float) byte.MaxValue) - 1.0;
          double g4 = (double) ((float) c2.G / (float) byte.MaxValue) - 1.0;
          double b = (double) ((float) c2.B / (float) byte.MaxValue) - 1.0;
          DrawMod.Draw(ref local9, ref local10, x5, y5, (float) r, (float) g4, (float) b, 1f);
        }
        else if (num3 == 1)
        {
          ref Graphics local11 = ref g;
          bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ASSETBACKGROUND);
          ref Bitmap local12 = ref bitmap1;
          int x6 = tx;
          int y6 = ty;
          DrawMod.DrawSimple(ref local11, ref local12, x6, y6);
        }
        else
        {
          this.game.seColBrown = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 235, 215);
          ref Graphics local13 = ref g;
          Bitmap bitmap6 = BitmapStore.GetBitmap(this.game.SE1_ASSETBACKGROUND);
          ref Bitmap local14 = ref bitmap6;
          int x7 = tx;
          int y7 = ty;
          double r = (double) ((float) this.game.seColBrown.R / (float) byte.MaxValue) - 1.0;
          double g5 = (double) ((float) this.game.seColBrown.G / (float) byte.MaxValue) - 1.0;
          double b = (double) ((float) this.game.seColBrown.B / (float) byte.MaxValue) - 1.0;
          DrawMod.Draw(ref local13, ref local14, x7, y7, (float) r, (float) g5, (float) b, 1f);
        }
      }
      else if (num2 != zoneNr & idValue4 == zoneNr)
      {
        Color color = Color.FromArgb((int) byte.MaxValue, 195, 195, 225);
        ref Graphics local15 = ref g;
        Bitmap bitmap7 = BitmapStore.GetBitmap(this.game.SE1_ASSETBACKGROUND);
        ref Bitmap local16 = ref bitmap7;
        int x8 = tx;
        int y8 = ty;
        double r = (double) ((float) color.R / (float) byte.MaxValue - 1.1f);
        double g6 = (double) ((float) color.G / (float) byte.MaxValue - 1.1f);
        double b = (double) ((float) color.B / (float) byte.MaxValue - 1.1f);
        DrawMod.Draw(ref local15, ref local16, x8, y8, (float) r, (float) g6, (float) b, 1f);
      }
      else if (num2 == zoneNr & idValue4 != zoneNr)
      {
        Color color = Color.FromArgb((int) byte.MaxValue, 235, 215, 235);
        ref Graphics local17 = ref g;
        Bitmap bitmap8 = BitmapStore.GetBitmap(this.game.SE1_ASSETBACKGROUND);
        ref Bitmap local18 = ref bitmap8;
        int x9 = tx;
        int y9 = ty;
        double r = (double) ((float) color.R / (float) byte.MaxValue - 1.1f);
        double g7 = (double) ((float) color.G / (float) byte.MaxValue - 1.1f);
        double b = (double) ((float) color.B / (float) byte.MaxValue - 1.1f);
        DrawMod.Draw(ref local17, ref local18, x9, y9, (float) r, (float) g7, (float) b, 1f);
      }
      else if (idValue1 > 0)
      {
        c2 = Color.FromArgb((int) byte.MaxValue, 235, 235, 195);
        ref Graphics local19 = ref g;
        Bitmap bitmap9 = BitmapStore.GetBitmap(this.game.SE1_ASSETBACKGROUND);
        ref Bitmap local20 = ref bitmap9;
        int x10 = tx;
        int y10 = ty;
        double r = (double) ((float) c2.R / (float) byte.MaxValue) - 1.0;
        double g8 = (double) ((float) c2.G / (float) byte.MaxValue) - 1.0;
        double b = (double) ((float) c2.B / (float) byte.MaxValue) - 1.0;
        DrawMod.Draw(ref local19, ref local20, x10, y10, (float) r, (float) g8, (float) b, 1f);
      }
      else if (num1 > 0)
      {
        c2 = Color.FromArgb((int) byte.MaxValue, 215, 215, 175);
        ref Graphics local21 = ref g;
        Bitmap bitmap10 = BitmapStore.GetBitmap(this.game.SE1_ASSETBACKGROUND);
        ref Bitmap local22 = ref bitmap10;
        int x11 = tx;
        int y11 = ty;
        double r = (double) ((float) c2.R / (float) byte.MaxValue) - 1.0;
        double g9 = (double) ((float) c2.G / (float) byte.MaxValue) - 1.0;
        double b = (double) ((float) c2.B / (float) byte.MaxValue) - 1.0;
        DrawMod.Draw(ref local21, ref local22, x11, y11, (float) r, (float) g9, (float) b, 1f);
      }
      else if (num3 == 1)
      {
        ref Graphics local23 = ref g;
        bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ASSETBACKGROUND);
        ref Bitmap local24 = ref bitmap1;
        int x12 = tx;
        int y12 = ty;
        DrawMod.Draw(ref local23, ref local24, x12, y12, -0.1f, -0.1f, -0.1f, 1f);
      }
      else
      {
        this.game.seColBrown = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 235, 215);
        ref Graphics local25 = ref g;
        Bitmap bitmap11 = BitmapStore.GetBitmap(this.game.SE1_ASSETBACKGROUND);
        ref Bitmap local26 = ref bitmap11;
        int x13 = tx;
        int y13 = ty;
        double r = (double) ((float) this.game.seColBrown.R / (float) byte.MaxValue - 1.1f);
        double g10 = (double) ((float) this.game.seColBrown.G / (float) byte.MaxValue - 1.1f);
        double b = (double) ((float) this.game.seColBrown.B / (float) byte.MaxValue - 1.1f);
        DrawMod.Draw(ref local25, ref local26, x13, y13, (float) r, (float) g10, (float) b, 1f);
      }
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (index4 > 0)
      {
        int num22 = nr1;
        if (num22 > 5)
          num22 = 5;
        if (num22 < 1)
          num22 = 1;
        int x14 = 2 + (num22 - 1) * 134;
        ref Graphics local27 = ref g;
        bitmap1 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index4]);
        ref Bitmap local28 = ref bitmap1;
        rectangle1 = new Rectangle(x14, 2, 131, 111);
        Rectangle srcrect = rectangle1;
        rectangle2 = new Rectangle(tx + 12, ty + 40, 131, 111);
        Rectangle destrect = rectangle2;
        DrawMod.DrawSimplePart2(ref local27, ref local28, srcrect, destrect);
      }
      if (this.game.EditObj.se1_SelectAssetButton != idValue3)
      {
        if (num2 != zoneNr & idValue4 == zoneNr)
        {
          Color color = Color.FromArgb((int) byte.MaxValue, 195, 195, 225);
          ref Graphics local29 = ref g;
          bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ASSETBORDER);
          ref Bitmap local30 = ref bitmap1;
          int x15 = tx;
          int y14 = ty;
          double r = (double) ((float) color.R / (float) byte.MaxValue) - 1.0;
          double g11 = (double) ((float) color.G / (float) byte.MaxValue) - 1.0;
          double b = (double) ((float) color.B / (float) byte.MaxValue) - 1.0;
          DrawMod.Draw(ref local29, ref local30, x15, y14, (float) r, (float) g11, (float) b, 1f);
        }
        else if (num2 == zoneNr & idValue4 != zoneNr)
        {
          Color color = Color.FromArgb((int) byte.MaxValue, 235, 215, 235);
          ref Graphics local31 = ref g;
          bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ASSETBORDER);
          ref Bitmap local32 = ref bitmap1;
          int x16 = tx;
          int y15 = ty;
          double r = (double) ((float) color.R / (float) byte.MaxValue) - 1.0;
          double g12 = (double) ((float) color.G / (float) byte.MaxValue) - 1.0;
          double b = (double) ((float) color.B / (float) byte.MaxValue) - 1.0;
          DrawMod.Draw(ref local31, ref local32, x16, y15, (float) r, (float) g12, (float) b, 1f);
        }
        else if (num3 == 1)
        {
          ref Graphics local33 = ref g;
          bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ASSETBORDER);
          ref Bitmap local34 = ref bitmap1;
          int x17 = tx;
          int y16 = ty;
          DrawMod.DrawSimple(ref local33, ref local34, x17, y16);
        }
        else if (idValue1 > 0)
        {
          Color color = Color.FromArgb((int) byte.MaxValue, 235, 235, 195);
          ref Graphics local35 = ref g;
          bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ASSETBORDER);
          ref Bitmap local36 = ref bitmap1;
          int x18 = tx;
          int y17 = ty;
          double r = (double) ((float) color.R / (float) byte.MaxValue) - 1.0;
          double g13 = (double) ((float) color.G / (float) byte.MaxValue) - 1.0;
          double b = (double) ((float) color.B / (float) byte.MaxValue) - 1.0;
          DrawMod.Draw(ref local35, ref local36, x18, y17, (float) r, (float) g13, (float) b, 1f);
        }
        else if (num1 > 0)
        {
          Color color = Color.FromArgb((int) byte.MaxValue, 215, 215, 175);
          ref Graphics local37 = ref g;
          bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ASSETBORDER);
          ref Bitmap local38 = ref bitmap1;
          int x19 = tx;
          int y18 = ty;
          double r = (double) ((float) color.R / (float) byte.MaxValue) - 1.0;
          double g14 = (double) ((float) color.G / (float) byte.MaxValue) - 1.0;
          double b = (double) ((float) color.B / (float) byte.MaxValue) - 1.0;
          DrawMod.Draw(ref local37, ref local38, x19, y18, (float) r, (float) g14, (float) b, 1f);
        }
        else
        {
          this.game.seColBrown = Color.FromArgb((int) byte.MaxValue, 245, 225, 205);
          ref Graphics local39 = ref g;
          bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ASSETBORDER);
          ref Bitmap local40 = ref bitmap1;
          int x20 = tx;
          int y19 = ty;
          double r = (double) ((float) this.game.seColBrown.R / (float) byte.MaxValue) - 1.0;
          double g15 = (double) ((float) this.game.seColBrown.G / (float) byte.MaxValue) - 1.0;
          double b = (double) ((float) this.game.seColBrown.B / (float) byte.MaxValue) - 1.0;
          DrawMod.Draw(ref local39, ref local40, x20, y19, (float) r, (float) g15, (float) b, 1f);
        }
      }
      else if (num2 != zoneNr & idValue4 == zoneNr)
      {
        Color color = Color.FromArgb((int) byte.MaxValue, 215, 215, 235);
        ref Graphics local41 = ref g;
        bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ASSETBORDERHIGH);
        ref Bitmap local42 = ref bitmap1;
        int x21 = tx;
        int y20 = ty;
        double r = (double) ((float) color.R / (float) byte.MaxValue) - 1.0;
        double g16 = (double) ((float) color.G / (float) byte.MaxValue) - 1.0;
        double b = (double) ((float) color.B / (float) byte.MaxValue) - 1.0;
        DrawMod.Draw(ref local41, ref local42, x21, y20, (float) r, (float) g16, (float) b, 1f);
      }
      else if (num2 == zoneNr & idValue4 != zoneNr)
      {
        Color color = Color.FromArgb((int) byte.MaxValue, 235, 215, 235);
        ref Graphics local43 = ref g;
        bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ASSETBORDERHIGH);
        ref Bitmap local44 = ref bitmap1;
        int x22 = tx;
        int y21 = ty;
        double r = (double) ((float) color.R / (float) byte.MaxValue) - 1.0;
        double g17 = (double) ((float) color.G / (float) byte.MaxValue) - 1.0;
        double b = (double) ((float) color.B / (float) byte.MaxValue) - 1.0;
        DrawMod.Draw(ref local43, ref local44, x22, y21, (float) r, (float) g17, (float) b, 1f);
      }
      else if (idValue1 > 0)
      {
        Color color = Color.FromArgb((int) byte.MaxValue, 235, 235, 195);
        ref Graphics local45 = ref g;
        bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ASSETBORDERHIGH);
        ref Bitmap local46 = ref bitmap1;
        int x23 = tx;
        int y22 = ty;
        double r = (double) ((float) color.R / (float) byte.MaxValue) - 1.0;
        double g18 = (double) ((float) color.G / (float) byte.MaxValue) - 1.0;
        double b = (double) ((float) color.B / (float) byte.MaxValue) - 1.0;
        DrawMod.Draw(ref local45, ref local46, x23, y22, (float) r, (float) g18, (float) b, 1f);
      }
      else if (num1 > 0)
      {
        Color color = Color.FromArgb((int) byte.MaxValue, 215, 215, 175);
        ref Graphics local47 = ref g;
        bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ASSETBORDERHIGH);
        ref Bitmap local48 = ref bitmap1;
        int x24 = tx;
        int y23 = ty;
        double r = (double) ((float) color.R / (float) byte.MaxValue) - 1.0;
        double g19 = (double) ((float) color.G / (float) byte.MaxValue) - 1.0;
        double b = (double) ((float) color.B / (float) byte.MaxValue) - 1.0;
        DrawMod.Draw(ref local47, ref local48, x24, y23, (float) r, (float) g19, (float) b, 1f);
      }
      else if (num3 == 1)
      {
        ref Graphics local49 = ref g;
        bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ASSETBORDERHIGH);
        ref Bitmap local50 = ref bitmap1;
        int x25 = tx;
        int y24 = ty;
        DrawMod.DrawSimple(ref local49, ref local50, x25, y24);
      }
      else
      {
        this.game.seColBrown = Color.FromArgb((int) byte.MaxValue, 245, 225, 205);
        ref Graphics local51 = ref g;
        bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ASSETBORDERHIGH);
        ref Bitmap local52 = ref bitmap1;
        int x26 = tx;
        int y25 = ty;
        double r = (double) ((float) this.game.seColBrown.R / (float) byte.MaxValue) - 1.0;
        double g20 = (double) ((float) this.game.seColBrown.G / (float) byte.MaxValue) - 1.0;
        double b = (double) ((float) this.game.seColBrown.B / (float) byte.MaxValue) - 1.0;
        DrawMod.Draw(ref local51, ref local52, x26, y25, (float) r, (float) g20, (float) b, 1f);
      }
      if (!usePreviewMode && idValue2 > 0)
      {
        if (num9 > 0 & index2 == this.game.Data.Turn)
        {
          int h = (int) Math.Round((double) (63 * num9) / 100.0);
          Color color = DrawMod.LightenColor(this.game.seColYellow, num9 - 100);
          c2 = DrawMod.LightenColor(color, -100);
          DrawMod.DrawBlockGradient2(ref g, tx + 147, ty + 107 + (63 - h), 3, h, color, c2);
        }
        WindowClass windowClass1 = tWindow;
        rectangle2 = new Rectangle(tx + 145, ty + 107, 7, 63);
        Rectangle rectangle3 = rectangle2;
        ref Rectangle local53 = ref rectangle3;
        string ttitle1 = "Upkeep: " + num9.ToString() + "%";
        windowClass1.AddMouse(ref local53, ttitle1, "...");
        if (num12 > 0)
        {
          if (num10 > 0 & index2 == this.game.Data.Turn)
          {
            int h = (int) Math.Round((double) (63 * num10) / 100.0);
            Color color = DrawMod.LightenColor(this.game.seColBlue, num10 - 100);
            c2 = DrawMod.LightenColor(color, -100);
            DrawMod.DrawBlockGradient2(ref g, tx + 147, ty + 34 + (63 - h), 3, h, color, c2);
          }
          WindowClass windowClass2 = tWindow;
          rectangle2 = new Rectangle(tx + 145, ty + 34, 7, 63);
          Rectangle rectangle4 = rectangle2;
          ref Rectangle local54 = ref rectangle4;
          string ttitle2 = "Construction: " + num10.ToString() + "%";
          windowClass2.AddMouse(ref local54, ttitle2, "...");
        }
        else
        {
          if (num10 > 0 & index2 == this.game.Data.Turn)
          {
            int h = (int) Math.Round((double) (63 * num10) / 100.0);
            if (num11 > 0)
              h = (int) Math.Round(63.0 * ((double) (num10 * num11) / 100.0) / 100.0);
            Color color = DrawMod.LightenColor(this.game.seColGreen, num10 - 100);
            c2 = DrawMod.LightenColor(color, -100);
            DrawMod.DrawBlockGradient2(ref g, tx + 147, ty + 34 + (63 - h), 3, h, color, c2);
          }
          WindowClass windowClass3 = tWindow;
          rectangle2 = new Rectangle(tx + 145, ty + 34, 7, 63);
          Rectangle rectangle5 = rectangle2;
          ref Rectangle local55 = ref rectangle5;
          string ttitle3 = "Production: " + num10.ToString() + "%";
          windowClass3.AddMouse(ref local55, ttitle3, "...");
        }
        if (val2_1 > 0)
        {
          int h = (int) Math.Round((double) (137 * Math.Min(200 * nr1, val2_1)) / (double) (200 * nr1));
          Color color = DrawMod.LightenColor(this.game.seColRed, -(int) Math.Round((double) Math.Min(200 * nr1, val2_1) / (double) (200 * nr1)));
          c2 = DrawMod.LightenColor(color, -100);
          DrawMod.DrawBlockGradient2(ref g, tx + 4, ty + 34 + (137 - h), 3, h, color, c2);
        }
        WindowClass windowClass4 = tWindow;
        rectangle2 = new Rectangle(tx + 2, ty + 34, 7, 137);
        rectangle1 = rectangle2;
        ref Rectangle local56 = ref rectangle1;
        string ttext = "Damage: " + val2_1.ToString() + " pts\r\nCompletely inoperable at " + (200 * nr1).ToString() + " points.\r\n100% certain loss of Asset at " + (1000 + 200 * nr1).ToString() + " points.";
        windowClass4.AddMouse(ref local56, "Damage to Asset", ttext);
      }
      string str10 = str5;
      if (str10.Length > 18)
        str10 = Strings.Left(str10, 18) + ".";
      if (idValue2 > 0 & nr1 > 0)
      {
        string str11 = str5;
        str10 = (str11.Length <= 16 ? str11 + " " : Strings.Left(str11, 16) + ".") + this.game.HandyFunctionsObj.GetRomanNumerical(nr1);
      }
      DrawMod.DrawTextColouredConsoleCenter(ref g, str10, DrawMod.TGame.MarcFont7, tx + 78, ty + 174, DrawMod.TGame.seColGray);
      if (num12 == 0 & idValue2 > 0 & (!this.game.Data.FOWOn | index2 == this.game.Data.Turn))
      {
        str7 = "";
        ref Graphics local57 = ref g;
        bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ASSETBORDERCORNER);
        ref Bitmap local58 = ref bitmap1;
        rectangle2 = new Rectangle(0, 0, 28, 27);
        Rectangle srcrect1 = rectangle2;
        rectangle1 = new Rectangle(tx + 131, ty + 0, 28, 27);
        Rectangle destrect1 = rectangle1;
        double r = (double) ((float) this.game.seColBrown.R / (float) byte.MaxValue) - 1.0;
        double g21 = (double) ((float) this.game.seColBrown.G / (float) byte.MaxValue) - 1.0;
        double b = (double) ((float) this.game.seColBrown.B / (float) byte.MaxValue) - 1.0;
        DrawMod.DrawSimplePart2Coloured(ref local57, ref local58, srcrect1, destrect1, (float) r, (float) g21, (float) b, 1f);
        switch (num13)
        {
          case -2:
            str6 = "Mode: Closed";
            ref Graphics local59 = ref g;
            bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ASSETBORDERCORNER);
            ref Bitmap local60 = ref bitmap1;
            rectangle2 = new Rectangle(84, 0, 28, 27);
            Rectangle srcrect2 = rectangle2;
            rectangle1 = new Rectangle(tx + 131, ty + 0, 28, 27);
            Rectangle destrect2 = rectangle1;
            DrawMod.DrawSimplePart2(ref local59, ref local60, srcrect2, destrect2);
            break;
          case -1:
            str6 = "Mode: Mothballed";
            ref Graphics local61 = ref g;
            bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ASSETBORDERCORNER);
            ref Bitmap local62 = ref bitmap1;
            rectangle2 = new Rectangle(56, 0, 28, 27);
            Rectangle srcrect3 = rectangle2;
            rectangle1 = new Rectangle(tx + 131, ty + 0, 28, 27);
            Rectangle destrect3 = rectangle1;
            DrawMod.DrawSimplePart2(ref local61, ref local62, srcrect3, destrect3);
            break;
          default:
            str6 = "Mode: Active";
            ref Graphics local63 = ref g;
            bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ASSETBORDERCORNER);
            ref Bitmap local64 = ref bitmap1;
            rectangle2 = new Rectangle(28, 0, 28, 27);
            Rectangle srcrect4 = rectangle2;
            rectangle1 = new Rectangle(tx + 131, ty + 0, 28, 27);
            Rectangle destrect4 = rectangle1;
            DrawMod.DrawSimplePart2(ref local63, ref local64, srcrect4, destrect4);
            break;
        }
        WindowClass windowClass = tWindow;
        rectangle2 = new Rectangle(tx + 131, ty + 0, 28, 27);
        rectangle1 = rectangle2;
        ref Rectangle local65 = ref rectangle1;
        string ttext = str6;
        windowClass.AddMouse(ref local65, "", ttext);
      }
      else if (idValue1 <= 0)
        ;
      string str12 = "";
      if (index3 > -1)
      {
        if (this.game.Data.LocObj[index3].X == x1 & this.game.Data.LocObj[index3].Y == y1)
          str12 = "City";
        else if (num4 >= 1 & str4.Length > 1)
          str12 = str4;
      }
      else if (num4 >= 1 & str4.Length > 1)
        str12 = str4;
      if (num2 != idValue4 & zoneNr == idValue4)
      {
        str12 = "DELEGATED";
        int smallPic = this.game.Data.FindSmallPic(165, "SE_Graphics");
        if (smallPic > -1)
        {
          ref Graphics local66 = ref g;
          bitmap1 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[smallPic], 1);
          ref Bitmap local67 = ref bitmap1;
          int x27 = tx - 35;
          int y26 = ty - 3;
          DrawMod.DrawSimple(ref local66, ref local67, x27, y26);
        }
      }
      if (num2 != idValue4 & zoneNr == num2)
      {
        str12 = this.game.Data.StringListObj[this.slotZones].GetData(0, idValue4, 7);
        int smallPic = this.game.Data.FindSmallPic(165, "SE_Graphics");
        if (smallPic > -1)
        {
          ref Graphics local68 = ref g;
          bitmap1 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[smallPic], 1);
          ref Bitmap local69 = ref bitmap1;
          int x28 = tx - 35;
          int y27 = ty - 3;
          DrawMod.DrawSimple(ref local68, ref local69, x28, y27);
        }
      }
      if (idValue1 > 0)
      {
        str12 = "HEX PERK";
        int hexLibVarValue = this.game.Data.MapObj[0].HexObj[x1, y1].GetHexLibVarValue(libVar);
        if (hexLibVarValue > 0)
        {
          str4 = this.game.Data.StringListObj[this.slotHexNames].GetData(0, hexLibVarValue, 1);
          if (str4.Length > 0)
            str12 = str4;
        }
      }
      if (num1 > 0 && num1 > 0)
        str12 = str4;
      if (str12.Length > 0)
      {
        string upper = str12.ToUpper();
        if (num3 == 1)
          DrawMod.DrawTextColouredConsoleCenterEmbossed(ref g, upper, DrawMod.TGame.MarcFont7, tx + 78, ty + 2, Color.Gray);
        else
          DrawMod.DrawTextColouredConsoleCenterEmbossed(ref g, upper, DrawMod.TGame.MarcFont7, tx + 78, ty + 2, Color.FromArgb((int) byte.MaxValue, (int) Math.Round((double) this.game.seColBrown.R / 2.0), (int) Math.Round((double) this.game.seColBrown.G / 2.0), (int) Math.Round((double) this.game.seColBrown.B / 2.0)));
      }
      SimpleStringList simpleStringList1 = new SimpleStringList();
      SimpleStringList simpleStringList2 = new SimpleStringList();
      SimpleStringList simpleStringList3 = new SimpleStringList();
      SimpleStringList simpleStringList4 = new SimpleStringList();
      SimpleStringList simpleStringList5 = new SimpleStringList();
      SimpleStringList simpleStringList6 = new SimpleStringList();
      SimpleStringList simpleStringList7 = new SimpleStringList();
      SimpleStringList simpleStringList8 = new SimpleStringList();
      int num23 = tx;
      bool flag = false;
      int tweight1;
      if (idValue1 > 0 & (!this.game.Data.FOWOn | index2 == this.game.Data.Turn))
      {
        int num24 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotPerks].GetData(0, idValue1, 2)));
        string data4 = this.game.Data.StringListObj[this.slotPerks].GetData(0, idValue1, 3);
        int num25 = (int) Math.Round(Conversion.Val(data4));
        string data5 = this.game.Data.StringListObj[this.slotPerks].GetData(0, idValue1, 5);
        tweight1 = (int) Math.Round(Conversion.Val(data5));
        if (Operators.CompareString(tweight1.ToString(), data5, false) != 0)
          tweight1 = 0;
        int tdata1;
        if (num24 == 1)
        {
          str6 = data4;
          tdata1 = 3;
        }
        if (num24 == 3)
        {
          str6 = this.game.Data.StringListObj[this.slotItemType].GetData(0, num25, 1);
          tdata1 = 2;
        }
        if (num24 == 2)
        {
          str6 = data4;
          tdata1 = 1;
        }
        if (num24 >= 1 & num24 <= 3)
          simpleStringList6.AddWeight(str6, tweight1, tdata1, num25);
      }
      if (idValue2 > 0 & (!this.game.Data.FOWOn | index2 == this.game.Data.Turn))
      {
        int length1 = this.game.Data.StringListObj[this.slotDetail].Length;
        for (int index7 = 0; index7 <= length1; ++index7)
        {
          if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index7, 0])) == idValue3)
          {
            int num26 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index7, 1]));
            int num27 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index7, 2]));
            int num28 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index7, 3]));
            str8 = this.game.Data.StringListObj[this.slotDetail].Data[index7, 3];
            int num29 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index7, 4]));
            if (num27 == 5)
              flag = true;
          }
        }
        int length2 = this.game.Data.StringListObj[this.slotDetail].Length;
        for (int index8 = 0; index8 <= length2; ++index8)
        {
          if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index8, 0])) == idValue3)
          {
            int tdata1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index8, 1]));
            int num30 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index8, 2]));
            int num31 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index8, 3]));
            string str13 = this.game.Data.StringListObj[this.slotDetail].Data[index8, 3];
            int tweight2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index8, 4]));
            str6 = "";
            if (tdata1 == 1)
              str6 = str13;
            if (tdata1 == 2)
              str6 = this.game.Data.StringListObj[this.slotItemType].GetData(0, num31, 1);
            if (tdata1 == 3)
              str6 = str13;
            if (tdata1 == 4)
              str6 = "Construction";
            if (tdata1 == 6 | tdata1 == 5)
              str6 = str13;
            if (Operators.CompareString(str6, "", false) == 0)
              str6 = str6;
            if (str6.Length > 0)
              str6 = Strings.Left(str6, 1).ToUpper() + Strings.Mid(str6, 2);
            if (num30 == 1 & (num31 > 0 | str13.Length > 0))
            {
              simpleStringList3.AddWeight(str6, tweight2, tdata1, num31);
              simpleStringList1.AddWeight(str6, tweight2, tdata1, num31);
            }
            if ((num30 == 3 | num30 == 5) & tweight2 > 0)
            {
              simpleStringList2.AddWeight(str6, tweight2, tdata1);
              simpleStringList1.AddWeight(str6, tweight2, tdata1, num31);
            }
            if (num30 == 21)
            {
              int nr2 = simpleStringList8.FindNr(str6);
              if (tweight2 > 100)
                tweight2 = 100;
              if (nr2 < 0)
                simpleStringList8.AddWeight(str6, tweight2, tdata1, num31);
              else if (tweight2 < simpleStringList8.Weight[nr2])
                simpleStringList8.Weight[nr2] = tweight2;
            }
            if (num30 == 23 | num30 == 25)
            {
              int nr3 = simpleStringList7.FindNr(str6);
              if (tweight2 > 100)
                tweight2 = 100;
              if (nr3 < 0)
                simpleStringList7.AddWeight(str6, tweight2, tdata1, num31);
              else if (tweight2 < simpleStringList8.Weight[nr3])
                simpleStringList7.Weight[nr3] = tweight2;
            }
            if (num30 == 2)
              simpleStringList5.AddWeight(str6, tweight2, tdata1, num31);
            if (num30 == 4 | num30 == 6)
              simpleStringList4.AddWeight(str6, tweight2, tdata1, num31);
            if (num30 == 14 | num30 == 16)
              simpleStringList6.AddWeight(str6, tweight2, tdata1, num31);
          }
        }
        simpleStringList2.ReverseSort();
        simpleStringList4.ReverseSort();
        simpleStringList6.ReverseSort();
      }
      int num32 = ty;
      int num33;
      int val2_2;
      string str14;
      double num34;
      if (simpleStringList1.Counter > -1)
      {
        int counter = simpleStringList1.Counter;
        for (int index9 = 0; index9 <= counter; ++index9)
        {
          if (index9 <= 3)
          {
            string str15 = simpleStringList1.Id[index9];
            num33 = simpleStringList2.FindWeightById(str15) + Math.Max(0, simpleStringList3.FindWeightById(str15));
            val2_2 = Math.Max(0, simpleStringList4.FindWeightById(simpleStringList1.Id[index9])) + simpleStringList5.FindWeightById(str15);
            int val1 = (int) Math.Round(Math.Floor((double) Math.Max(0, simpleStringList2.FindWeightById(str15)) * ((double) simpleStringList7.FindWeightById(str15) / 100.0))) + (int) Math.Round(Math.Floor((double) Math.Max(0, simpleStringList3.FindWeightById(str15)) * ((double) simpleStringList8.FindWeightById(str15) / 100.0)));
            if (val2_2 < 0)
              val2_2 = 0;
            if (val1 < 0)
              val1 = 0;
            if (val1 > num33)
              val1 = num33;
            if (val2_2 > 0 & val1 > 0 & Math.Abs(val2_2 - val1) <= 1)
              val1 = val2_2;
            str7 = val2_2.ToString() + "/" + num33.ToString();
            if (val1 > val2_2)
              str7 = val2_2.ToString() + "(" + val1.ToString() + ")/" + num33.ToString();
            if (str15.Length > 15)
              str14 = Strings.Left(str15, 15);
            Color.FromArgb((int) byte.MaxValue, 90, 90, 90);
            if (num33 < 1)
              num33 = 1;
            int num35 = (int) Math.Round((double) (100 * val1) / (double) num33);
            int num36 = (int) Math.Round((double) (100 * val2_2) / (double) num33);
            if (num36 > num10)
              num36 = num10;
            int num37;
            if (num35 > num36)
              num37 = (int) Math.Round((double) (188 * val1) / (double) num33);
            num37 = (int) Math.Round((double) (188 * Math.Max(val1, val2_2)) / (double) num33);
            int num38 = (int) Math.Round((double) (100 * Math.Max(val1, val2_2)) / (double) num33);
            Color c = this.game.seColGray;
            if (num38 >= 100)
              c = this.game.seColGray;
            if (num38 >= 75 & num38 <= 99)
              c = this.game.seColYellow;
            if (num38 >= 50 & num38 <= 74)
              c = this.game.seColYellow;
            if (num38 <= 49)
              c = this.game.seColRed;
            int x29 = tx + 20;
            int y28 = ty + 25;
            if (index9 == 1 | index9 == 3)
              x29 = tx + 80;
            if (index9 >= 2)
              y28 = ty + 45;
            if (index9 == 0 & simpleStringList1.Counter == 0)
              x29 += 40;
            if (index9 == 2 & simpleStringList1.Counter == 2)
              x29 += 40;
            if (index9 == 4 & simpleStringList1.Counter == 4)
              x29 += 40;
            if (index9 <= 1 & simpleStringList1.Counter <= 1)
              y28 += 10;
            int index10 = -1;
            if (simpleStringList1.Data1[index9] == 1)
              index10 = this.game.EventRelatedObj.GetEventPicSlotFor(-1, "", simpleStringList1.Id[index9]);
            if (simpleStringList1.Data1[index9] == 2)
              index10 = this.game.EventRelatedObj.GetEventPicSlotFor((int) Math.Round(Conversion.Val((object) simpleStringList1.Data2[index9])), "", "");
            if (simpleStringList1.Data1[index9] == 3)
              index10 = this.game.EventRelatedObj.GetEventPicSlotFor(-1, simpleStringList1.Id[index9], "");
            string str16 = simpleStringList1.Id[index9];
            if (Operators.CompareString(str16.ToLower(), "poppoints", false) == 0)
            {
              str16 = "Population Points";
              num33 *= 100;
              val2_2 *= 100;
              val1 *= 100;
            }
            if (Operators.CompareString(str16.ToLower(), "workerpoints", false) == 0)
            {
              str16 = "Worker Points";
              num33 *= 100;
              val2_2 *= 100;
              val1 *= 100;
            }
            string str17 = "Needed " + num33.ToString() + " " + str16 + " and used " + val2_2.ToString() + " " + str16 + " of the " + val1.ToString() + " alloted to the Asset at start of turn.";
            WindowClass windowClass = tWindow;
            rectangle2 = new Rectangle(x29, y28 - 3, 60, 20);
            rectangle1 = rectangle2;
            ref Rectangle local70 = ref rectangle1;
            string ttitle = str16;
            string ttext = str17;
            windowClass.AddMouse(ref local70, ttitle, ttext);
            if (index10 > -1)
            {
              ref Graphics local71 = ref g;
              bitmap1 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index10]);
              ref Bitmap local72 = ref bitmap1;
              int x30 = x29;
              int y29 = y28;
              DrawMod.DrawSimple(ref local71, ref local72, x30, y29);
              x29 += 30;
            }
            if (val2_2 >= 1000)
            {
              num34 = Math.Round((double) val2_2 / 1000.0, 1);
              str6 = num34.ToString() + "K";
            }
            else
              str6 = val2_2.ToString();
            DrawMod.DrawTextColouredConsole(ref g, str6, this.game.MarcFont7, x29, y28, c);
          }
        }
      }
      if (simpleStringList6.Counter > -1)
      {
        ty = num32;
        int counter = simpleStringList6.Counter;
        for (int index11 = 0; index11 <= counter; ++index11)
        {
          if (index11 <= 4)
          {
            string str18 = simpleStringList6.Id[index11];
            if (str18.Length > 17)
              str14 = Strings.Left(str18, 17);
            num33 = simpleStringList6.Weight[index11];
            str7 = num33.ToString();
            int x31 = tx + 20;
            if (index11 == 1 | index11 == 3)
              x31 = tx + 80;
            int y30;
            if (simpleStringList6.Counter >= 4)
            {
              y30 = ty + 121;
              if (index11 == 2 | index11 == 3)
                y30 = ty + 137;
              if (index11 == 4 | index11 == 5)
                y30 = ty + 155;
            }
            else
            {
              y30 = ty + 130;
              if (index11 == 2 | index11 == 3)
                y30 = ty + 150;
            }
            if (index11 == 0 & simpleStringList6.Counter == 0)
              x31 += 40;
            if (index11 == 2 & simpleStringList6.Counter == 2)
              x31 += 40;
            if (index11 == 4 & simpleStringList6.Counter == 4)
              x31 += 40;
            if (index11 <= 1 & simpleStringList6.Counter <= 1)
              y30 += 10;
            if (index11 <= 1 & simpleStringList6.Counter <= 1 & idValue1 > 0)
              y30 += 5;
            int index12 = -1;
            Color seColGray = this.game.seColGray;
            if (simpleStringList6.Data1[index11] == 1)
              index12 = this.game.EventRelatedObj.GetEventPicSlotFor(-1, "", simpleStringList6.Id[index11]);
            if (simpleStringList6.Data1[index11] == 2)
              index12 = this.game.EventRelatedObj.GetEventPicSlotFor((int) Math.Round(Conversion.Val((object) simpleStringList6.Data2[index11])), "", "");
            if (simpleStringList6.Data1[index11] == 3)
              index12 = this.game.EventRelatedObj.GetEventPicSlotFor(-1, simpleStringList6.Id[index11], "");
            if (simpleStringList6.Data1[index11] == 5)
              index12 = this.game.EventRelatedObj.GetEventPicSlotFor(-1, simpleStringList6.Id[index11], "");
            if (simpleStringList6.Data1[index11] == 6)
              index12 = this.game.EventRelatedObj.GetEventPicSlotFor(-1, simpleStringList6.Id[index11], "");
            if (Operators.CompareString(simpleStringList6.Id[index11].ToLower(), "pop", false) == 0)
              num33 *= 100;
            if (Operators.CompareString(simpleStringList6.Id[index11].ToLower(), "worker", false) == 0)
              num33 *= 100;
            if (simpleStringList6.Data2[index11] == 9 | simpleStringList6.Data2[index11] == 12)
              num33 *= 100;
            if (Operators.CompareString(simpleStringList6.Id[index11].ToLower(), "construction", false) == 0)
            {
              if (simpleStringList6.Counter == 0)
              {
                if (usePreviewMode)
                {
                  DrawMod.DrawTextColouredConsoleCenter(ref g, "Under Construction", this.game.MarcFont7, tx + 80, y30 + 8, this.game.seColBlue);
                }
                else
                {
                  str6 = simpleStringList6.Id[index11];
                  string Left = ((float) Math.Round((double) ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index1, 7])) * 100 - (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index1, 12]))) / 100.0, 1)).ToString();
                  if (Operators.CompareString(Left, "0", false) == 0 & num12 > 0)
                    Left = "0.1";
                  string[] strArray1 = new string[5]
                  {
                    "Did ",
                    null,
                    null,
                    null,
                    null
                  };
                  string[] strArray2 = strArray1;
                  num34 = Math.Round((double) num33 / 100.0, 2);
                  string str19 = num34.ToString();
                  strArray2[1] = str19;
                  strArray1[2] = " turn of construction at start of turn.\r\nStill to do: ";
                  strArray1[3] = Left;
                  strArray1[4] = " turns.";
                  string str20 = string.Concat(strArray1);
                  WindowClass windowClass = tWindow;
                  rectangle2 = new Rectangle(x31, y30 - 11, 60, 40);
                  rectangle1 = rectangle2;
                  ref Rectangle local73 = ref rectangle1;
                  string ttitle = str6;
                  string ttext = str20;
                  windowClass.AddMouse(ref local73, ttitle, ttext);
                  if (index12 > -1)
                  {
                    ref Graphics local74 = ref g;
                    bitmap1 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index12]);
                    ref Bitmap local75 = ref bitmap1;
                    int x32 = x31;
                    int y31 = y30;
                    DrawMod.DrawSimple(ref local74, ref local75, x32, y31);
                    num23 = x31 + 30;
                  }
                  ref Graphics local76 = ref g;
                  num34 = Math.Round((double) num33 / 100.0, 2);
                  string tstring = num34.ToString() + "t";
                  Font marcFont7 = this.game.MarcFont7;
                  int x33 = tx + 80;
                  int y32 = y30 - 8;
                  Color c = seColGray;
                  DrawMod.DrawTextColouredConsoleCenter(ref local76, tstring, marcFont7, x33, y32, c);
                  if (Operators.CompareString(Left, "0", false) == 0 & num12 < 1)
                    DrawMod.DrawTextColouredConsoleCenter(ref g, "(constr finished)", this.game.MarcFont7, tx + 80, y30 + 8, this.game.seColBlue);
                  else
                    DrawMod.DrawTextColouredConsoleCenter(ref g, "(" + Left + "t left)", this.game.MarcFont7, tx + 80, y30 + 8, this.game.seColBlue);
                }
              }
            }
            else
            {
              str6 = simpleStringList6.Id[index11];
              if (this.slotKeyReplace > -1)
              {
                int row = this.game.Data.StringListObj[this.slotKeyReplace].FindRow(0, str6);
                if (row > -1)
                  str6 = this.game.Data.StringListObj[this.slotKeyReplace].Data[row, 1];
              }
              string str21 = "Produced " + num33.ToString() + " " + str6 + " at start of turn.";
              WindowClass windowClass = tWindow;
              rectangle2 = new Rectangle(x31, y30 - 3, 60, 20);
              rectangle1 = rectangle2;
              ref Rectangle local77 = ref rectangle1;
              string ttitle = str6;
              string ttext = str21;
              windowClass.AddMouse(ref local77, ttitle, ttext);
              if (index12 > -1)
              {
                ref Graphics local78 = ref g;
                bitmap1 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index12]);
                ref Bitmap local79 = ref bitmap1;
                int x34 = x31;
                int y33 = y30;
                DrawMod.DrawSimple(ref local78, ref local79, x34, y33);
                x31 += 30;
              }
              DrawMod.DrawTextColouredConsole(ref g, num33.ToString(), this.game.MarcFont7, x31, y30, seColGray);
            }
          }
        }
        if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue2, 4))) == 5)
        {
          val2_2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].GetData(9, idValue3, 3)));
          int index13 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].GetData(9, idValue3, 4)));
          tweight1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].GetData(9, idValue3, 11)));
          num33 = (int) Math.Round((double) (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[val2_2, index13].Location].Type].Logistical * tweight1) / 100.0);
          if (num33 > 0)
          {
            str14 = "Log. Extension";
            str7 = num33.ToString();
          }
        }
      }
      else if (num12 > 0 & index1 < 9000000 & (simpleStringList6.Counter > -1 | simpleStringList1.Counter > -1))
      {
        int num39 = ty + 121;
        string Left = ((float) Math.Round((double) ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index1, 7])) * 100 - (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index1, 12]))) / 100.0, 1)).ToString();
        if (Operators.CompareString(Left, "0", false) == 0 & num12 < 1)
          DrawMod.DrawTextColouredConsoleCenter(ref g, "(constr finished)", this.game.MarcFont7, tx + 80, num39 + 8, this.game.seColBlue);
        else if (usePreviewMode)
          DrawMod.DrawTextColouredConsoleCenter(ref g, "Under Construction", this.game.MarcFont7, tx + 80, num39 + 8, this.game.seColBlue);
        else
          DrawMod.DrawTextColouredConsoleCenter(ref g, "(" + Left + "t left)", this.game.MarcFont7, tx + 80, num39 + 8, this.game.seColBlue);
      }
      if (index1 < 9000000 && simpleStringList6.Counter == -1 & simpleStringList1.Counter == -1 & num12 == 1)
      {
        int x35 = tx + 20;
        int y34 = ty + 134;
        string Left = ((float) Math.Round((double) ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index1, 7])) * 100 - (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index1, 12]))) / 100.0, 1)).ToString();
        if (Operators.CompareString(Left, "0", false) == 0 & num12 > 0)
          Left = "0.1";
        string str22 = "Under Construction. Still to do: " + Left + " turns.";
        WindowClass windowClass = tWindow;
        rectangle2 = new Rectangle(x35, y34 - 11, 60, 40);
        rectangle1 = rectangle2;
        ref Rectangle local80 = ref rectangle1;
        string ttitle = str6;
        string ttext = str22;
        windowClass.AddMouse(ref local80, ttitle, ttext);
        DrawMod.DrawTextColouredConsoleCenter(ref g, "Under Construction", this.game.MarcFont7, tx + 80, y34, this.game.seColBlue);
        DrawMod.DrawTextColouredConsoleCenter(ref g, Left + "t left", this.game.MarcFont7, tx + 80, y34 + 16, this.game.seColBlue);
      }
      if (curAssetId == idValue3)
      {
        if (idValue2 > 0)
        {
          WindowClass windowClass = tWindow;
          rectangle2 = new Rectangle(tx, ty, 156, 208);
          rectangle1 = rectangle2;
          ref Rectangle local81 = ref rectangle1;
          string ttitle = str2;
          string ttext = str3 + "\r\nClick to for more information on this Asset Type.";
          int tdata2 = idValue3;
          windowClass.AddMouse(ref local81, ttitle, ttext, 121, tdata2);
        }
        else if (idValue1 > 0)
        {
          WindowClass windowClass = tWindow;
          rectangle2 = new Rectangle(tx, ty, 156, 208);
          rectangle1 = rectangle2;
          ref Rectangle local82 = ref rectangle1;
          string ttitle = str2;
          string ttext = str3 + "\r\nClick to for more information on this Hex Perk.";
          int tdata2 = idValue3;
          windowClass.AddMouse(ref local82, ttitle, ttext, 121, tdata2);
        }
        else if (num1 > 0)
        {
          WindowClass windowClass = tWindow;
          rectangle2 = new Rectangle(tx, ty, 156, 208);
          rectangle1 = rectangle2;
          ref Rectangle local83 = ref rectangle1;
          string ttitle = str2;
          string ttext = str3 + "\r\nClick to for more information on this Free Folk settlement.";
          int tdata2 = idValue3;
          windowClass.AddMouse(ref local83, ttitle, ttext, 121, tdata2);
        }
        else
        {
          WindowClass windowClass = tWindow;
          rectangle2 = new Rectangle(tx, ty, 156, 208);
          rectangle1 = rectangle2;
          ref Rectangle local84 = ref rectangle1;
          string ttitle = str2;
          string ttext = str3 + "\r\nClick to for more information on this Asset Type.";
          int tdata2 = idValue3;
          windowClass.AddMouse(ref local84, ttitle, ttext, 121, tdata2);
        }
      }
      else
      {
        WindowClass windowClass = tWindow;
        rectangle2 = new Rectangle(tx, ty, 156, 208);
        rectangle1 = rectangle2;
        ref Rectangle local85 = ref rectangle1;
        string ttitle = str2;
        string ttext = str3 + "\r\nClick to select.";
        int tdata2 = idValue3;
        windowClass.AddMouse(ref local85, ttitle, ttext, 121, tdata2);
      }
    }
  }
}
