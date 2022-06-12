// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleByteCache
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace WindowsApplication1
{
  public class SimpleByteCache
  {
    public byte[,] cacheBig;
    public byte[,] cacheMed;
    public byte[,] cacheSmall;
    public int cacheTotal;
    public byte[] singleCacheBig;
    public byte[] singleCacheMed;
    public byte[] singleCacheSmall;
    public byte[,] singleFredCacheBig;
    public byte[,] singleFredCacheMed;
    public byte[,] singleFredCacheSmall;

    public SimpleByteCache()
    {
      this.cacheBig = new byte[1, 1];
      this.cacheMed = new byte[1, 1];
      this.cacheSmall = new byte[1, 1];
      this.singleFredCacheBig = new byte[65, 1];
      this.singleFredCacheMed = new byte[65, 1];
      this.singleFredCacheSmall = new byte[65, 1];
    }

    public void SetSingleFredAlphaCache(
      ref Bitmap bmp,
      ref Bitmap bmpBig,
      ref Bitmap bmpSmall,
      int bitmapNr)
    {
      string s = BitmapStore.tmpFileName[bitmapNr];
      if (Information.IsNothing((object) bmp))
      {
        bmp = BitmapStore.LoadBitmap(BitmapStore.GraphicsPath + s);
        bmp.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        string str1 = BitmapStore.MakeBigString(s);
        bmpBig = BitmapStore.LoadBitmap(BitmapStore.GraphicsPath + str1);
        bmpBig.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        string str2 = BitmapStore.MakeSmallString(s);
        bmpSmall = BitmapStore.LoadBitmap(BitmapStore.GraphicsPath + str2);
        bmpSmall.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      }
      this.singleFredCacheMed = new byte[65, 3072];
      int index1 = 1;
      IntPtr scan0;
      do
      {
        int x1 = DrawMod.TGame.SHEETX[index1] * 64;
        int y1 = DrawMod.TGame.SHEETY[index1] * 48;
        int index2 = 0;
        if (DrawMod.TGame.Data.Product >= 6)
        {
          int width = 64;
          int height = 48;
          int num1 = x1 * 4;
          int num2 = (x1 + width) * 4 - num1;
          Rectangle rect = new Rectangle(x1, y1, width, height);
          BitmapData bitmapdata = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
          byte[] destination = new byte[num2 - 1 + 1];
          int num3 = bitmapdata.Height - 1;
          for (int index3 = 0; index3 <= num3; ++index3)
          {
            scan0 = bitmapdata.Scan0;
            Marshal.Copy((IntPtr) (scan0.ToInt64() + (long) (index3 * bitmapdata.Stride)), destination, 0, destination.Length);
            int num4 = num2 - 1;
            for (int index4 = 3; index4 <= num4; index4 += 4)
            {
              this.singleFredCacheMed[index1, index2] = destination[index4];
              ++index2;
            }
          }
          bmp.UnlockBits(bitmapdata);
        }
        else
        {
          int num5 = y1;
          int num6 = y1 + 47;
          for (int y2 = num5; y2 <= num6; ++y2)
          {
            int num7 = x1;
            int num8 = x1 + 63;
            for (int x2 = num7; x2 <= num8; ++x2)
            {
              Color pixel = bmp.GetPixel(x2, y2);
              this.singleFredCacheMed[index1, index2] = pixel.A;
              ++index2;
            }
          }
        }
        ++index1;
      }
      while (index1 <= 64);
      this.singleFredCacheBig = new byte[65, 12288];
      int index5 = 1;
      do
      {
        int x3 = DrawMod.TGame.SHEETX[index5] * 128;
        int y3 = DrawMod.TGame.SHEETY[index5] * 96;
        int index6 = 0;
        if (DrawMod.TGame.Data.Product >= 6)
        {
          int width = 128;
          int height = 96;
          int num9 = x3 * 4;
          int num10 = (x3 + width) * 4 - num9;
          Rectangle rect = new Rectangle(x3, y3, width, height);
          BitmapData bitmapdata = bmpBig.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
          byte[] destination = new byte[num10 - 1 + 1];
          int num11 = bitmapdata.Height - 1;
          for (int index7 = 0; index7 <= num11; ++index7)
          {
            scan0 = bitmapdata.Scan0;
            Marshal.Copy((IntPtr) (scan0.ToInt64() + (long) (index7 * bitmapdata.Stride)), destination, 0, destination.Length);
            int num12 = num10 - 1;
            for (int index8 = 3; index8 <= num12; index8 += 4)
            {
              this.singleFredCacheBig[index5, index6] = destination[index8];
              ++index6;
            }
          }
          bmpBig.UnlockBits(bitmapdata);
        }
        else
        {
          int num13 = y3;
          int num14 = y3 + 95;
          for (int y4 = num13; y4 <= num14; ++y4)
          {
            int num15 = x3;
            int num16 = x3 + (int) sbyte.MaxValue;
            for (int x4 = num15; x4 <= num16; ++x4)
            {
              Color pixel = bmpBig.GetPixel(x4, y4);
              this.singleFredCacheBig[index5, index6] = pixel.A;
              ++index6;
            }
          }
        }
        ++index5;
      }
      while (index5 <= 64);
      this.singleFredCacheSmall = new byte[65, 768];
      int index9 = 1;
      do
      {
        int x5 = DrawMod.TGame.SHEETX[index9] * 32;
        int y5 = DrawMod.TGame.SHEETY[index9] * 24;
        int index10 = 0;
        if (DrawMod.TGame.Data.Product >= 6)
        {
          int width = 32;
          int height = 24;
          int num17 = x5 * 4;
          int num18 = (x5 + width) * 4 - num17;
          Rectangle rect = new Rectangle(x5, y5, width, height);
          BitmapData bitmapdata = bmpSmall.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
          byte[] destination = new byte[num18 - 1 + 1];
          int num19 = bitmapdata.Height - 1;
          for (int index11 = 0; index11 <= num19; ++index11)
          {
            scan0 = bitmapdata.Scan0;
            Marshal.Copy((IntPtr) (scan0.ToInt64() + (long) (index11 * bitmapdata.Stride)), destination, 0, destination.Length);
            int num20 = num18 - 1;
            for (int index12 = 3; index12 <= num20; index12 += 4)
            {
              this.singleFredCacheSmall[index9, index10] = destination[index12];
              ++index10;
            }
          }
          bmpSmall.UnlockBits(bitmapdata);
        }
        else
        {
          int num21 = y5;
          int num22 = y5 + 23;
          for (int y6 = num21; y6 <= num22; ++y6)
          {
            int num23 = x5;
            int num24 = x5 + 31;
            for (int x6 = num23; x6 <= num24; ++x6)
            {
              Color pixel = bmpSmall.GetPixel(x6, y6);
              this.singleFredCacheSmall[index9, index10] = pixel.A;
              ++index10;
            }
          }
        }
        ++index9;
      }
      while (index9 <= 64);
      BitmapStore.Dispose(bitmapNr);
    }

    public void SetSingleAlphaCache(ref Bitmap bmp, ref Bitmap bmpBig, ref Bitmap bmpSmall)
    {
      this.singleCacheMed = new byte[bmp.Width * bmp.Height - 1 + 1];
      int index1 = 0;
      int num1 = 0;
      int num2 = 0;
      int num3 = num2;
      int num4 = num2 + 47;
      for (int y = num3; y <= num4; ++y)
      {
        int num5 = num1;
        int num6 = num1 + 63;
        for (int x = num5; x <= num6; ++x)
        {
          Color pixel = bmp.GetPixel(x, y);
          this.singleCacheMed[index1] = pixel.A;
          ++index1;
        }
      }
      this.singleCacheSmall = new byte[bmpSmall.Width * bmpSmall.Height - 1 + 1];
      int index2 = 0;
      int num7 = num2;
      int num8 = num2 + 23;
      for (int y = num7; y <= num8; ++y)
      {
        int num9 = num1;
        int num10 = num1 + 31;
        for (int x = num9; x <= num10; ++x)
        {
          Color pixel = bmpSmall.GetPixel(x, y);
          this.singleCacheSmall[index2] = pixel.A;
          ++index2;
        }
      }
      this.singleCacheBig = new byte[bmpBig.Width * bmpBig.Height - 1 + 1];
      int index3 = 0;
      int num11 = num2;
      int num12 = num2 + 95;
      for (int y = num11; y <= num12; ++y)
      {
        int num13 = num1;
        int num14 = num1 + (int) sbyte.MaxValue;
        for (int x = num13; x <= num14; ++x)
        {
          Color pixel = bmpBig.GetPixel(x, y);
          this.singleCacheBig[index3] = pixel.A;
          ++index3;
        }
      }
    }

    public void SetMultiRGBCache(
      ref Bitmap bmp,
      ref Bitmap bmpBig,
      ref Bitmap bmpSmall,
      int bitmapNr)
    {
      string s = BitmapStore.tmpFileName[bitmapNr];
      int width1;
      try
      {
        width1 = bmp.Width;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        bmp = (Bitmap) null;
        ProjectData.ClearProjectError();
      }
      if (Information.IsNothing((object) bmp))
      {
        bmp = BitmapStore.LoadBitmap(BitmapStore.GraphicsPath + s);
        bmp.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        string str1 = BitmapStore.MakeBigString(s);
        bmpBig = BitmapStore.LoadBitmap(BitmapStore.GraphicsPath + str1);
        bmpBig.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        string str2 = BitmapStore.MakeSmallString(s);
        bmpSmall = BitmapStore.LoadBitmap(BitmapStore.GraphicsPath + str2);
        bmpSmall.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        if ((double) DrawMod.TGame.Data.RuleVar[451] > 0.0 & DrawMod.TGame.Data.Product >= 7)
        {
          int stringListById = DrawMod.TGame.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) DrawMod.TGame.Data.RuleVar[451]));
          int length = DrawMod.TGame.Data.StringListObj[stringListById].Length;
          for (int index = 0; index <= length; ++index)
          {
            if ((int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[stringListById].Data[index, 0])) > 0)
            {
              string String2 = DrawMod.TGame.Data.StringListObj[stringListById].Data[index, 1];
              int fr = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[stringListById].Data[index, 2]));
              int fg = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[stringListById].Data[index, 3]));
              int fb = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[stringListById].Data[index, 4]));
              int tr = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[stringListById].Data[index, 5]));
              int tg = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[stringListById].Data[index, 6]));
              int tb = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[stringListById].Data[index, 7]));
              if (Strings.InStr(Strings.LCase(s.Replace("\\", "/").Replace("//", "/")), String2) > 0)
              {
                DrawMod.ModifyColorOfBitmapHighSpeed(ref bmp, fr, fg, fb, tr, tg, tb);
                DrawMod.ModifyColorOfBitmapHighSpeed(ref bmpBig, fr, fg, fb, tr, tg, tb);
                DrawMod.ModifyColorOfBitmapHighSpeed(ref bmpSmall, fr, fg, fb, tr, tg, tb);
              }
            }
          }
        }
      }
      int width2 = bmp.Width;
      int height1 = bmp.Height;
      int num1;
      if (width2 == 424)
        num1 = 8;
      this.cacheTotal = num1;
      this.cacheMed = new byte[num1 * num1 + 1, 12288];
      int num2 = 0;
      int num3 = num1 - 1;
      Color pixel;
      for (int index1 = 0; index1 <= num3; ++index1)
      {
        int num4 = num1 - 1;
        for (int index2 = 0; index2 <= num4; ++index2)
        {
          int x1 = index1 * 53 - 11;
          int y1 = index2 * 48;
          if ((index1 + 2) % 2 > 0)
            y1 += 24;
          int index3 = 0;
          if (x1 >= 0 & y1 + 48 <= bmp.Height & DrawMod.TGame.Data.Product >= 6)
          {
            int width3 = 64;
            int height2 = 48;
            int num5 = x1 * 4;
            int num6 = (x1 + width3) * 4 - num5;
            Rectangle rect = new Rectangle(x1, y1, width3, height2);
            BitmapData bitmapdata = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
            byte[] destination = new byte[num6 - 1 + 1];
            int num7 = bitmapdata.Height - 1;
            for (int index4 = 0; index4 <= num7; ++index4)
            {
              Marshal.Copy((IntPtr) (bitmapdata.Scan0.ToInt64() + (long) (index4 * bitmapdata.Stride)), destination, 0, destination.Length);
              int num8 = num6 - 1;
              for (int index5 = 0; index5 <= num8; ++index5)
                this.cacheMed[index1 * 8 + index2, index3 + index5] = destination[index5];
              index3 += num6;
            }
            bmp.UnlockBits(bitmapdata);
          }
          else
          {
            int num9 = y1;
            int num10 = y1 + 47;
            for (int index6 = num9; index6 <= num10; ++index6)
            {
              int num11 = x1;
              int num12 = x1 + 63;
              for (int index7 = num11; index7 <= num12; ++index7)
              {
                int x2 = index7;
                int y2 = index6;
                if (x2 < 0)
                  x2 = bmp.Width + index7;
                if (y2 > bmp.Height - 1)
                  y2 -= bmp.Height;
                pixel = bmp.GetPixel(x2, y2);
                this.cacheMed[index1 * 8 + index2, index3] = pixel.B;
                this.cacheMed[index1 * 8 + index2, index3 + 1] = pixel.G;
                this.cacheMed[index1 * 8 + index2, index3 + 2] = pixel.R;
                this.cacheMed[index1 * 8 + index2, index3 + 3] = pixel.A;
                index3 += 4;
              }
            }
          }
        }
      }
      width1 = bmpBig.Width;
      height1 = bmpBig.Height;
      this.cacheBig = new byte[num1 * num1 + 1, 49152];
      num2 = 0;
      int num13 = num1 - 1;
      for (int index8 = 0; index8 <= num13; ++index8)
      {
        int num14 = num1 - 1;
        for (int index9 = 0; index9 <= num14; ++index9)
        {
          int x3 = index8 * 106 - 22;
          int y3 = index9 * 96;
          if ((index8 + 2) % 2 > 0)
            y3 += 48;
          int index10 = 0;
          if (x3 >= 0 & y3 + 96 <= bmpBig.Height & DrawMod.TGame.Data.Product >= 6)
          {
            int width4 = 128;
            int height3 = 96;
            int num15 = x3 * 4;
            int num16 = (x3 + width4) * 4 - num15;
            Rectangle rect = new Rectangle(x3, y3, width4, height3);
            BitmapData bitmapdata = bmpBig.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
            byte[] destination = new byte[num16 - 1 + 1];
            int num17 = bitmapdata.Height - 1;
            for (int index11 = 0; index11 <= num17; ++index11)
            {
              Marshal.Copy((IntPtr) (bitmapdata.Scan0.ToInt64() + (long) (index11 * bitmapdata.Stride)), destination, 0, destination.Length);
              int num18 = num16 - 1;
              for (int index12 = 0; index12 <= num18; ++index12)
                this.cacheBig[index8 * 8 + index9, index10 + index12] = destination[index12];
              index10 += num16;
            }
            bmpBig.UnlockBits(bitmapdata);
          }
          else
          {
            int num19 = y3;
            int num20 = y3 + 95;
            for (int index13 = num19; index13 <= num20; ++index13)
            {
              int num21 = x3;
              int num22 = x3 + (int) sbyte.MaxValue;
              for (int index14 = num21; index14 <= num22; ++index14)
              {
                int x4 = index14;
                int y4 = index13;
                if (x4 < 0)
                  x4 = bmpBig.Width + index14;
                if (y4 > bmpBig.Height - 1)
                  y4 -= bmpBig.Height;
                pixel = bmpBig.GetPixel(x4, y4);
                this.cacheBig[index8 * 8 + index9, index10] = pixel.B;
                this.cacheBig[index8 * 8 + index9, index10 + 1] = pixel.G;
                this.cacheBig[index8 * 8 + index9, index10 + 2] = pixel.R;
                this.cacheBig[index8 * 8 + index9, index10 + 3] = pixel.A;
                index10 += 4;
              }
            }
          }
        }
      }
      width1 = bmpSmall.Width;
      height1 = bmpSmall.Height;
      this.cacheSmall = new byte[num1 * num1 + 1, 3072];
      num2 = 0;
      int num23 = num1 - 1;
      for (int index15 = 0; index15 <= num23; ++index15)
      {
        int num24 = num1 - 1;
        for (int index16 = 0; index16 <= num24; ++index16)
        {
          int x5 = index15 * 27 - 5;
          int y5 = index16 * 24;
          if ((index15 + 2) % 2 > 0)
            y5 += 12;
          int index17 = 0;
          if (x5 >= 0 & y5 + 32 <= bmpSmall.Height & DrawMod.TGame.Data.Product >= 6)
          {
            int width5 = 32;
            int height4 = 24;
            int num25 = x5 * 4;
            int num26 = (x5 + width5) * 4 - num25;
            Rectangle rect = new Rectangle(x5, y5, width5, height4);
            BitmapData bitmapdata = bmpSmall.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
            byte[] destination = new byte[num26 - 1 + 1];
            int num27 = bitmapdata.Height - 1;
            for (int index18 = 0; index18 <= num27; ++index18)
            {
              Marshal.Copy((IntPtr) (bitmapdata.Scan0.ToInt64() + (long) (index18 * bitmapdata.Stride)), destination, 0, destination.Length);
              int num28 = num26 - 1;
              for (int index19 = 0; index19 <= num28; ++index19)
                this.cacheSmall[index15 * 8 + index16, index17 + index19] = destination[index19];
              index17 += num26;
            }
            bmpSmall.UnlockBits(bitmapdata);
          }
          else
          {
            int num29 = y5;
            int num30 = y5 + 23;
            for (int index20 = num29; index20 <= num30; ++index20)
            {
              int num31 = x5;
              int num32 = x5 + 31;
              for (int index21 = num31; index21 <= num32; ++index21)
              {
                int x6 = index21;
                int y6 = index20;
                if (x6 < 0)
                  x6 = bmpSmall.Width + index21;
                if (y6 > bmpSmall.Height - 1)
                  y6 -= bmpSmall.Height;
                pixel = bmpSmall.GetPixel(x6, y6);
                this.cacheSmall[index15 * 8 + index16, index17] = pixel.B;
                this.cacheSmall[index15 * 8 + index16, index17 + 1] = pixel.G;
                this.cacheSmall[index15 * 8 + index16, index17 + 2] = pixel.R;
                this.cacheSmall[index15 * 8 + index16, index17 + 3] = pixel.A;
                index17 += 4;
              }
            }
          }
        }
      }
      BitmapStore.Dispose(bitmapNr);
    }
  }
}
