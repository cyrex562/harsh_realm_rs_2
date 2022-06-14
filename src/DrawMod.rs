// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.DrawMod
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
using System.Windows.Forms;

namespace WindowsApplication1
{
  [StandardModule]
  pub sealed class DrawMod
  {
    pub const let mut SRCAND: i32 =  8913094;
    pub const let mut SRCINVERT: i32 =  6684742;
    pub const byte AC_SRC_OVER = 0;
    pub const byte AC_SRC_ALPHA = 1;
    pub const byte SW_MINIMIZE = 6;
     static Font ttfont = Font::new("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel);
    pub static Random RandyNumber;
    pub static bool MouseClicked;
    pub static GameClass TGame;
    pub static string ModFile;
    pub static int DPIx;
    pub static int DPIy;
    pub static Bitmap tempBmp128;
    pub static Bitmap tempBmp64;
    pub static Bitmap tempBmp32;
    pub static Bitmap tempBmp32by48;
    pub static Bitmap tempBmp64by64;
    pub static Bitmap tempBmp64by16;
    pub static Bitmap tempBmp16by24;
    pub static Bitmap tempBmp32by12;
    pub static Bitmap tempBmp32by8;
    pub static Bitmap tempBmp8by12;
    pub static Bitmap tempBmp16by6;
    pub static Bitmap tempBmp16by4;

    [DllImport("GDI32.DLL", CharSet = CharSet.Auto, SetLastError = true)]
     static extern bool BitBlt(
      IntPtr hdcDest,
      int nXDest,
      int nYDest,
      int nWidth,
      int nHeight,
      IntPtr hdcSrc,
      int nXSrc,
      int nYSrc,
      int dwRop);

    [DllImport("gdi32.dll", EntryPoint = "GdiAlphaBlend", CharSet = CharSet.Auto, SetLastError = true)]
    pub static extern bool AlphaBlend(
      IntPtr hdcDest,
      int nXOriginDest,
      int nYOriginDest,
      int nWidthDest,
      int nHeightDest,
      IntPtr hdcSrc,
      int nXOriginSrc,
      int nYOriginSrc,
      int nWidthSrc,
      int nHeightSrc,
      BLENDFUNCTION blendFunction);

    [DllImport("GDI32.DLL", CharSet = CharSet.Auto, SetLastError = true)]
     static extern bool StretchBlt(
      IntPtr hdcDest,
      int nXOriginDest,
      int nYOriginDest,
      int nWidthDest,
      int nHeightDest,
      IntPtr hdcSrc,
      int nXOriginSrc,
      int nYOriginSrc,
      int nWidthSrc,
      int nHeightSrc,
      int dwRop);

    [DllImport("gdi32", CharSet = CharSet.Auto, SetLastError = true)]
     static extern long SetStretchBltMode(IntPtr hdc, long nStretchMode);

    [DllImport("GDI32.DLL", CharSet = CharSet.Auto, SetLastError = true)]
    pub static extern IntPtr SelectObject(IntPtr hdc, IntPtr h);

    [DllImport("GDI32.DLL", CharSet = CharSet.Auto, SetLastError = true)]
    pub static extern bool DeleteObject(IntPtr ho);

    static DrawMod()
    {
      VBMath.Randomize();
      DrawMod.RandyNumber = new Random( Math.Round((double) (VBMath.Rnd() * 100000f)) + 1);
      DrawMod.DPIx = 96;
      DrawMod.DPIy = 96;
    }

    pub static void DrawWithArtCode(
      ref Graphics g,
      ref Bitmap tempBmp,
      int slotWidth,
      int slotHeight,
      int sftypenr,
      int ppl,
      int tx,
      int ty,
      int tw,
      int th)
    {
      let mut height: i32 =  tempBmp.Height;
      let mut width: i32 =  tempBmp.Width;
      bool flag = false;
      if (height >= 2 * slotHeight & (double) DrawMod.TGame.Data.RuleVar[492] > 0.0 & DrawMod.TGame.Data.Product >= 6)
        flag = true;
      if (height == width)
        flag = false;
      if (flag)
      {
        if (tw == -1 | th == -1)
        {
          tw = slotWidth;
          th = slotHeight;
        }
        let mut num1: i32 =  0;
        let mut num2: i32 =  0;
        if (DrawMod.TGame.Data.PeopleObj[ppl].artCode > 0)
          num2 = DrawMod.TGame.Data.PeopleObj[ppl].artCode;
        if (num2 > 0)
        {
          let mut index: i32 =  0;
          do
          {
            if (DrawMod.TGame.Data.SFTypeObj[sftypenr].artCode[index] == num2)
              num1 = index;
            index += 1;
          }
          while (index <= 9);
        }
        if (num1 * slotHeight <= height - 1)
        {
          DrawMod.DrawSimplePart2(ref g, ref tempBmp, Rectangle::new(0, num1 * slotHeight, slotWidth, slotHeight), Rectangle::new(tx, ty, tw, th));
        }
        else
        {
          let mut num3: i32 =  0;
          DrawMod.DrawSimplePart2(ref g, ref tempBmp, Rectangle::new(0, num3 * slotHeight, slotWidth, slotHeight), Rectangle::new(tx, ty, tw, th));
        }
      }
      else
      {
        if (tw == -1 | th == -1)
        {
          tw = tempBmp.Width;
          th = tempBmp.Height;
        }
        DrawMod.DrawSimplePart2(ref g, ref tempBmp, Rectangle::new(0, 0, tempBmp.Width, tempBmp.Height), Rectangle::new(tx, ty, tw, th));
      }
    }

    pub static void ModifyColorOfBitmapHighSpeed(
      ref Bitmap bmp,
      int fr,
      int fg,
      int fb,
      int tr,
      int tg,
      int tb)
    {
      Rectangle rect;
      rect.X = 0;
      rect.Y = 0;
      rect.Width = bmp.Width;
      rect.Height = bmp.Height;
      BitmapData bitmapdata = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
      IntPtr scan0 = bitmapdata.Scan0;
      let mut length: i32 =  Math.Abs(bitmapdata.Stride) * bmp.Height;
      byte[] numArray = new byte[length - 1 + 1];
      Marshal.Copy(scan0, numArray, 0, length);
      let mut num1: i32 =  numArray.Length - 1;
      for (let mut index: i32 =  0; index <= num1; index += 4)
      {
        byte num2 = numArray[index];
        byte num3 = numArray[index + 1];
        byte num4 = numArray[index + 2];
        if (numArray[index + 3] > (byte) 0)
        {
          let mut num5: i32 =   num2;
          let mut num6: i32 =   num3;
          let mut num7: i32 =  Math.Min( byte.MaxValue,  Math.Round((double) num4 / (double) fr * (double) tr));
          let mut num8: i32 =  Math.Min( byte.MaxValue,  Math.Round((double) num6 / (double) fg * (double) tg));
          byte num9 = (byte) Math.Min( byte.MaxValue,  Math.Round((double) num5 / (double) fb * (double) tb));
          byte num10 = (byte) num8;
          byte num11 = (byte) num7;
          numArray[index] = num9;
          numArray[index + 1] = num10;
          numArray[index + 2] = num11;
        }
      }
      Marshal.Copy(numArray, 0, scan0, length);
      bmp.UnlockBits(bitmapdata);
    }

    pub static void ModifyColorOfBitmapToGrayHighSpeed(ref Bitmap bmp, int effectStrength)
    {
      Rectangle rect;
      rect.X = 0;
      rect.Y = 0;
      rect.Width = bmp.Width;
      rect.Height = bmp.Height;
      BitmapData bitmapdata = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
      IntPtr scan0 = bitmapdata.Scan0;
      let mut length: i32 =  Math.Abs(bitmapdata.Stride) * bmp.Height;
      byte[] numArray = new byte[length - 1 + 1];
      Marshal.Copy(scan0, numArray, 0, length);
      let mut num1: i32 =   byte.MaxValue - effectStrength;
      if (effectStrength < 1 | effectStrength >=  byte.MaxValue)
      {
        let mut num2: i32 =  numArray.Length - 1;
        for (let mut index: i32 =  0; index <= num2; index += 4)
        {
          byte num3 = numArray[index];
          byte num4 = numArray[index + 1];
          byte num5 = numArray[index + 2];
          if (numArray[index + 3] > (byte) 0)
          {
            let mut num6: i32 =   Math.Round((double) ((float) num3 * 0.21f)) +  Math.Round((double) ((float) num4 * 0.71f)) +  Math.Round((double) ((float) num5 * 0.07f));
            if (num6 >  byte.MaxValue)
              num6 =  byte.MaxValue;
            byte num7 = (byte) num6;
            numArray[index] = num7;
            numArray[index + 1] = num7;
            numArray[index + 2] = num7;
          }
        }
      }
      else
      {
        let mut num8: i32 =  numArray.Length - 1;
        for (let mut index: i32 =  0; index <= num8; index += 4)
        {
          byte num9 = numArray[index];
          byte num10 = numArray[index + 1];
          byte num11 = numArray[index + 2];
          if (numArray[index + 3] > (byte) 0)
          {
            let mut num12: i32 =   Math.Round((double) ((float) num9 * 0.21f)) +  Math.Round((double) ((float) num10 * 0.71f)) +  Math.Round((double) ((float) num11 * 0.07f));
            let mut num13: i32 =   Math.Round((double) (num12 * effectStrength) / (double) byte.MaxValue) +  Math.Round((double) ( num9 * num1) / (double) byte.MaxValue);
            let mut num14: i32 =   Math.Round((double) (num12 * effectStrength) / (double) byte.MaxValue) +  Math.Round((double) ( num10 * num1) / (double) byte.MaxValue);
            let mut num15: i32 =   Math.Round((double) (num12 * effectStrength) / (double) byte.MaxValue) +  Math.Round((double) ( num11 * num1) / (double) byte.MaxValue);
            if (num13 >  byte.MaxValue)
              num13 =  byte.MaxValue;
            if (num15 >  byte.MaxValue)
              num15 =  byte.MaxValue;
            if (num14 >  byte.MaxValue)
              num14 =  byte.MaxValue;
            byte num16 = (byte) num13;
            byte num17 = (byte) num14;
            byte num18 = (byte) num15;
            numArray[index] = num16;
            numArray[index + 1] = num17;
            numArray[index + 2] = num18;
          }
        }
      }
      Marshal.Copy(numArray, 0, scan0, length);
      bmp.UnlockBits(bitmapdata);
    }

    pub static void CopyPerLineAndGrayscale(
      ref Bitmap from,
      ref Bitmap dest,
      int fx,
      int fy,
      int fw,
      int fh,
      int x,
      int y,
      int tr,
      int tg,
      int tb,
      int ta)
    {
      let mut width: i32 =  fw;
      let mut height: i32 =  fh;
      let mut num1: i32 =  fx * 4;
      let mut num2: i32 =  fy;
      let mut num3: i32 =  (fx + fw) * 4 - num1;
      Rectangle rect1 = Rectangle::new(x, y, width, height);
      Rectangle rect2 = Rectangle::new(0, 0, width, height);
      BitmapData bitmapdata1 = dest.LockBits(rect1, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
      BitmapData bitmapdata2 = from.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
      float num4 = (float) tr / (float) byte.MaxValue;
      float num5 = (float) tg / (float) byte.MaxValue;
      float num6 = (float) tb / (float) byte.MaxValue;
      float num7 = (float) ta / (float) byte.MaxValue;
      byte[] numArray1 = new byte[256];
      byte[] numArray2 = new byte[256];
      byte[] numArray3 = new byte[256];
      byte[] numArray4 = new byte[256];
      let mut num8: i32 =  0;
      if ((double) num4 == 1.0 & (double) num5 == 1.0 & (double) num6 == 1.0)
        num8 = 1;
      if ((double) num4 == 0.0 & (double) num5 == 0.0 & (double) num6 == 0.0)
        num8 = 2;
      if (num8 == 2)
      {
        let mut index: i32 =  0;
        do
        {
          numArray4[index] = (byte) Math.Round((double) ((float) index * num7));
          index += 1;
        }
        while (index <=  byte.MaxValue);
      }
      else
      {
        let mut index: i32 =  0;
        do
        {
          numArray1[index] = (byte) Math.Round((double) ((float) index * num6 * num7));
          numArray2[index] = (byte) Math.Round((double) ((float) index * num5 * num7));
          numArray3[index] = (byte) Math.Round((double) ((float) index * num4 * num7));
          numArray4[index] = (byte) Math.Round((double) ((float) index * num7));
          index += 1;
        }
        while (index <=  byte.MaxValue);
      }
      byte[] numArray5 = new byte[num3 - 1 + 1];
      let mut num9: i32 =  bitmapdata2.Height - 1;
      for (let mut index1: i32 =  0; index1 <= num9; index1 += 1)
      {
        IntPtr scan0 = bitmapdata2.Scan0;
        IntPtr source = (IntPtr) (scan0.ToInt64() + (long) ((index1 + num2) * bitmapdata2.Stride) + (long) num1);
        scan0 = bitmapdata1.Scan0;
        IntPtr destination = (IntPtr) (scan0.ToInt64() + (long) (index1 * bitmapdata1.Stride));
        Marshal.Copy(source, numArray5, 0, numArray5.Length);
        let mut num10: i32 =  numArray5.Length - 1;
        switch (num8)
        {
          case 1:
            let mut num11: i32 =  num10 - 1;
            for (let mut index2: i32 =  0; index2 <= num11; index2 += 4)
            {
              numArray5[index2 + 2] = numArray4[ numArray5[index2 + 2]];
              numArray5[index2 + 1] = numArray4[ numArray5[index2 + 1]];
              numArray5[index2] = numArray4[ numArray5[index2]];
              numArray5[index2 + 3] = numArray4[ numArray5[index2 + 3]];
            }
            break;
          case 2:
            let mut num12: i32 =  num10 - 1;
            for (let mut index3: i32 =  0; index3 <= num12; index3 += 4)
            {
              numArray5[index3 + 2] = (byte) 0;
              numArray5[index3 + 1] = (byte) 0;
              numArray5[index3] = (byte) 0;
              numArray5[index3 + 3] = numArray4[ numArray5[index3 + 3]];
            }
            break;
          default:
            let mut num13: i32 =  num10 - 1;
            for (let mut index4: i32 =  0; index4 <= num13; index4 += 4)
            {
              if (numArray5[index4 + 3] > (byte) 0)
              {
                numArray5[index4 + 2] = (byte) Math.Round((double) ((float) numArray5[index4 + 2] * num4));
                numArray5[index4 + 1] = (byte) Math.Round((double) ((float) numArray5[index4 + 2] * num5));
                numArray5[index4] = (byte) Math.Round((double) ((float) numArray5[index4 + 2] * num6));
                numArray5[index4 + 3] = numArray4[ numArray5[index4 + 3]];
              }
            }
            break;
        }
        Marshal.Copy(numArray5, 0, destination, numArray5.Length);
      }
      dest.UnlockBits(bitmapdata1);
      from.UnlockBits(bitmapdata2);
    }

    pub static void ModifyColorOfGrayscaleBitmap(
      ref Bitmap bmp,
      int tr,
      int tg,
      int tb,
      int ta)
    {
      Rectangle rect;
      rect.X = 0;
      rect.Y = 0;
      rect.Width = bmp.Width;
      rect.Height = bmp.Height;
      BitmapData bitmapdata = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
      IntPtr scan0 = bitmapdata.Scan0;
      let mut length: i32 =  Math.Abs(bitmapdata.Stride) * bmp.Height;
      byte[] numArray1 = new byte[length - 1 + 1];
      Marshal.Copy(scan0, numArray1, 0, length);
      float num1 = (float) tr / (float) byte.MaxValue;
      float num2 = (float) tg / (float) byte.MaxValue;
      float num3 = (float) tb / (float) byte.MaxValue;
      float num4 = (float) ta / (float) byte.MaxValue;
      if ((double) num1 == 0.0 & (double) num2 == 0.0 & (double) num3 == 0.0 | (double) num1 == 1.0 & (double) num2 == 1.0 & (double) num3 == 1.0)
      {
        byte[] source = new byte[length - 1 + 1];
        byte[] numArray2 = new byte[256];
        let mut index1: i32 =  0;
        do
        {
          numArray2[index1] = (byte) Math.Round((double) ((float) index1 * num4));
          index1 += 1;
        }
        while (index1 <=  byte.MaxValue);
        let mut num5: i32 =  numArray1.Length - 1;
        for (let mut index2: i32 =  3; index2 <= num5; index2 += 4)
          source[index2] = numArray2[ numArray1[index2]];
        Marshal.Copy(source, 0, scan0, length);
        bmp.UnlockBits(bitmapdata);
      }
      else
      {
        let mut num6: i32 =  numArray1.Length - 1;
        for (let mut index: i32 =  0; index <= num6; index += 4)
        {
          if (numArray1[index + 3] > (byte) 0)
          {
            numArray1[index + 2] = (byte) Math.Round((double) ((float) numArray1[index + 2] * num1));
            numArray1[index + 1] = (byte) Math.Round((double) ((float) numArray1[index + 2] * num2));
            numArray1[index] = (byte) Math.Round((double) ((float) numArray1[index + 2] * num3));
            numArray1[index + 3] = (byte) Math.Round((double) ((float) numArray1[index + 3] * num4));
          }
        }
        Marshal.Copy(numArray1, 0, scan0, length);
        bmp.UnlockBits(bitmapdata);
      }
    }

    pub static void DrawSaturized(
      ref Graphics objGraphics,
      ref Bitmap objBitmap,
      int x,
      int y,
      float saturation)
    {
      float num1 = 0.3086f;
      float num2 = 0.6094f;
      float num3 = 0.082f;
      ColorMatrix newColorMatrix = new ColorMatrix(new float[5][]
      {
        new float[5]
        {
          (1f - saturation) * num1 + saturation,
          (1f - saturation) * num1,
          (1f - saturation) * num1,
          0.0f,
          0.0f
        },
        new float[5]
        {
          (1f - saturation) * num2,
          (1f - saturation) * num2 + saturation,
          (1f - saturation) * num2,
          0.0f,
          0.0f
        },
        new float[5]
        {
          (1f - saturation) * num3,
          (1f - saturation) * num3,
          (1f - saturation) * num3 + saturation,
          0.0f,
          0.0f
        },
        new float[5]{ 0.0f, 0.0f, 0.0f, 1f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1f }
      });
      ImageAttributes imageAttr = ImageAttributes::new();
      Rectangle destRect = Rectangle::new(x, y, objBitmap.Width, objBitmap.Height);
      imageAttr.SetColorMatrix(newColorMatrix);
      objGraphics.DrawImage((Image) objBitmap, destRect, 0, 0, objBitmap.Width, objBitmap.Height, GraphicsUnit.Pixel, imageAttr);
    }

    pub static void Draw(
      ref Graphics objGraphics,
      ref Bitmap objBitmap,
      int x,
      int y,
      float r,
      float g,
      float b,
      float a)
    {
      ColorMatrix newColorMatrix = new ColorMatrix(new float[5][]
      {
        new float[5]{ 1f, 0.0f, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 1f, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 1f, 0.0f, 0.0f },
        new float[5]{ r, g, b, a, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1f }
      });
      ImageAttributes imageAttr = ImageAttributes::new();
      Rectangle destRect = Rectangle::new(x, y, objBitmap.Width, objBitmap.Height);
      imageAttr.SetColorMatrix(newColorMatrix);
      objGraphics.DrawImage((Image) objBitmap, destRect, 0, 0, objBitmap.Width, objBitmap.Height, GraphicsUnit.Pixel, imageAttr);
    }

    pub static void DrawGray(ref Graphics objGraphics, ref Bitmap objBitmap, int x, int y)
    {
      ColorMatrix newColorMatrix = new ColorMatrix(new float[5][]
      {
        new float[5]{ 0.5f, 0.5f, 0.5f, 0.0f, 0.0f },
        new float[5]{ 0.5f, 0.5f, 0.5f, 0.0f, 0.0f },
        new float[5]{ 0.5f, 0.5f, 0.5f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 0.35f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1f }
      });
      ImageAttributes imageAttr = ImageAttributes::new();
      Rectangle destRect = Rectangle::new(x, y, objBitmap.Width, objBitmap.Height);
      imageAttr.SetColorMatrix(newColorMatrix);
      objGraphics.DrawImage((Image) objBitmap, destRect, 0, 0, objBitmap.Width, objBitmap.Height, GraphicsUnit.Pixel, imageAttr);
    }

    pub static void ExpDraw(
      ref Graphics objGraphics,
      ref Bitmap objBitmap,
      int x,
      int y,
      float r,
      float g,
      float b,
      float a)
    {
      ColorMatrix newColorMatrix = new ColorMatrix(new float[5][]
      {
        new float[5]{ 1f, 0.0f, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 1f, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 1f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, a, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1f }
      });
      ImageAttributes imageAttr = ImageAttributes::new();
      Rectangle destRect = Rectangle::new(x, y, objBitmap.Width, objBitmap.Height);
      imageAttr.SetColorMatrix(newColorMatrix);
      objGraphics.DrawImage((Image) objBitmap, destRect, 0, 0, objBitmap.Width, objBitmap.Height, GraphicsUnit.Pixel, imageAttr);
    }

    pub static void Draw2(
      ref Graphics objGraphics,
      ref Bitmap objBitmap,
      int x,
      int y,
      float r,
      float g,
      float b,
      float a)
    {
      ColorMatrix newColorMatrix = new ColorMatrix(new float[5][]
      {
        new float[5]{ r, 0.0f, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, g, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, b, 0.0f, 0.0f },
        new float[5]{ r, g, b, a, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1f }
      });
      ImageAttributes imageAttr = ImageAttributes::new();
      Rectangle destRect = Rectangle::new(x, y, objBitmap.Width, objBitmap.Height);
      imageAttr.SetColorMatrix(newColorMatrix);
      objGraphics.DrawImage((Image) objBitmap, destRect, 0, 0, objBitmap.Width, objBitmap.Height, GraphicsUnit.Pixel, imageAttr);
    }

    pub static void DrawSimplePart2Coloured(
      ref Graphics objGraphics,
      ref Bitmap objBitmap,
      Rectangle srcrect,
      Rectangle destrect,
      float r,
      float g,
      float b,
      float a)
    {
      Bitmap bitmap = new Bitmap(destrect.Width, destrect.Height);
      bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      graphics.DrawImage((Image) objBitmap, Rectangle::new(0, 0, destrect.Width, destrect.Height), Rectangle::new(srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height), GraphicsUnit.Pixel);
      graphics.Dispose();
      ColorMatrix newColorMatrix = new ColorMatrix(new float[5][]
      {
        new float[5]{ 1f, 0.0f, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 1f, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 1f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 0.5f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1f }
      });
      ImageAttributes imageAttr = ImageAttributes::new();
      imageAttr.SetColorMatrix(newColorMatrix, ColorMatrixFlag.Default);
      objGraphics.DrawImage((Image) bitmap, destrect, 0, 0, destrect.Width, destrect.Height, GraphicsUnit.Pixel, imageAttr);
    }

    pub static void DrawSimplePart2ColouredOld(
      ref Graphics objGraphics,
      ref Bitmap objBitmap,
      Rectangle srcrect,
      Rectangle destrect,
      float r,
      float g,
      float b,
      float a)
    {
      Bitmap bitmap = new Bitmap(destrect.Width, destrect.Height);
      bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      graphics.DrawImage((Image) objBitmap, Rectangle::new(0, 0, destrect.Width, destrect.Height), Rectangle::new(srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height), GraphicsUnit.Pixel);
      graphics.Dispose();
      ColorMatrix newColorMatrix = new ColorMatrix(new float[5][]
      {
        new float[5]{ r, 0.0f, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, g, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, b, 0.0f, 0.0f },
        new float[5]{ r, g, b, a, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1f }
      });
      ImageAttributes imageAttr = ImageAttributes::new();
      imageAttr.SetColorMatrix(newColorMatrix, ColorMatrixFlag.Default);
      objGraphics.DrawImage((Image) bitmap, destrect, 0, 0, destrect.Width, destrect.Height, GraphicsUnit.Pixel, imageAttr);
    }

    pub static void DrawSimplePart2ColouredNewFast(
      ref Graphics objGraphics,
      ref Bitmap objBitmap,
      Rectangle srcrect,
      Rectangle destrect,
      float r,
      float g,
      float b,
      float a,
      ref Bitmap destBitmap = null)
    {
      if ((double) a == 0.0)
        return;
      if (!DrawMod.TGame.EditObj.highGfxSpeedOn)
      {
        DrawMod.DrawSimplePart2ColouredNew(ref objGraphics, ref objBitmap, srcrect, destrect, r, g, b, a);
      }
      else
      {
        bool flag = false;
        Bitmap bitmap;
        if (srcrect.Width == 128 & srcrect.Height == 96)
        {
          if (Information.IsNothing((object) DrawMod.tempBmp128))
          {
            bitmap = new Bitmap(srcrect.Width, srcrect.Height, PixelFormat.Format32bppPArgb);
            bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
            DrawMod.tempBmp128 = bitmap;
          }
          else
            bitmap = DrawMod.tempBmp128;
          flag = true;
        }
        else if (srcrect.Width == 64 & srcrect.Height == 32)
        {
          if (Information.IsNothing((object) DrawMod.tempBmp64))
          {
            bitmap = new Bitmap(srcrect.Width, srcrect.Height, PixelFormat.Format32bppPArgb);
            bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
            DrawMod.tempBmp64 = bitmap;
          }
          else
            bitmap = DrawMod.tempBmp64;
          flag = true;
        }
        else if (srcrect.Width == 32 & srcrect.Height == 24)
        {
          if (Information.IsNothing((object) DrawMod.tempBmp32))
          {
            bitmap = new Bitmap(srcrect.Width, srcrect.Height, PixelFormat.Format32bppPArgb);
            bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
            DrawMod.tempBmp32 = bitmap;
          }
          else
            bitmap = DrawMod.tempBmp32;
          flag = true;
        }
        else if (srcrect.Width == 32 & srcrect.Height == 48)
        {
          if (Information.IsNothing((object) DrawMod.tempBmp32by48))
          {
            bitmap = new Bitmap(srcrect.Width, srcrect.Height, PixelFormat.Format32bppPArgb);
            bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
            DrawMod.tempBmp32by48 = bitmap;
          }
          else
            bitmap = DrawMod.tempBmp32by48;
          flag = true;
        }
        else if (srcrect.Width == 64 & srcrect.Height == 64)
        {
          if (Information.IsNothing((object) DrawMod.tempBmp64by64))
          {
            bitmap = new Bitmap(srcrect.Width, srcrect.Height, PixelFormat.Format32bppPArgb);
            bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
            DrawMod.tempBmp64by64 = bitmap;
          }
          else
            bitmap = DrawMod.tempBmp64by64;
          flag = true;
        }
        else if (srcrect.Width == 64 & srcrect.Height == 16)
        {
          if (Information.IsNothing((object) DrawMod.tempBmp64by16))
          {
            bitmap = new Bitmap(srcrect.Width, srcrect.Height, PixelFormat.Format32bppPArgb);
            bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
            DrawMod.tempBmp64by16 = bitmap;
          }
          else
            bitmap = DrawMod.tempBmp64by16;
          flag = true;
        }
        else
        {
          bitmap = new Bitmap(srcrect.Width, srcrect.Height, PixelFormat.Format32bppPArgb);
          bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        }
        DrawMod.CopyPerLineAndGrayscale(ref objBitmap, ref bitmap, srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height, 0, 0,  Math.Round((double) (r * (float) byte.MaxValue)),  Math.Round((double) (g * (float) byte.MaxValue)),  Math.Round((double) (b * (float) byte.MaxValue)),  Math.Round((double) (a * (float) byte.MaxValue)));
        DrawMod.DrawSimple(ref objGraphics, ref bitmap, destrect.X, destrect.Y);
        if (flag)
          return;
        bitmap.Dispose();
      }
    }

    pub static void DrawSimplePart2ColouredNew(
      ref Graphics objGraphics,
      ref Bitmap objBitmap,
      Rectangle srcrect,
      Rectangle destrect,
      float r,
      float g,
      float b,
      float a)
    {
      ColorMatrix newColorMatrix = new ColorMatrix(new float[5][]
      {
        new float[5]{ r, 0.0f, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, g, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, b, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, a, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1f }
      });
      ImageAttributes imageAttr = ImageAttributes::new();
      imageAttr.SetColorMatrix(newColorMatrix, ColorMatrixFlag.Default);
      objGraphics.DrawImage((Image) objBitmap, destrect, srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height, GraphicsUnit.Pixel, imageAttr);
    }

    pub static void DrawSimple(ref Graphics objGraphics, ref Bitmap objBitmap, int x, int y)
    {
      if (Information.IsNothing((object) objBitmap))
        return;
      Rectangle destRect = Rectangle::new(x, y, objBitmap.Width, objBitmap.Height);
      if (!DrawMod.TGame.EmpireStyle | !DrawMod.TGame.EditObj.highGfxSpeedOn)
        objGraphics.DrawImage((Image) objBitmap, destRect, 0, 0, objBitmap.Width, objBitmap.Height, GraphicsUnit.Pixel);
      else
        objGraphics.DrawImageUnscaled((Image) objBitmap, x, y);
    }

    pub static void DrawSimpleFastWithAlpha(
      ref Graphics objGraphics,
      ref Bitmap fromBitmap,
      ref Bitmap tooBitmap,
      int x,
      int y)
    {
      if (!DrawMod.TGame.EditObj.highGfxSpeedOn | x < 0 | y < 0 | x + fromBitmap.Width > tooBitmap.Width | y + fromBitmap.Height > tooBitmap.Height)
        DrawMod.DrawSimple(ref objGraphics, ref fromBitmap, x, y);
      else if (fromBitmap.Size == tooBitmap.Size)
        DrawMod.CopyPerLineWithAlpha(ref fromBitmap, ref tooBitmap, x, y);
      else
        DrawMod.CopyPerLineWithAlpha(ref fromBitmap, ref tooBitmap, x, y);
    }

    pub static void DrawSimpleFast(
      ref Graphics objGraphics,
      ref Bitmap fromBitmap,
      ref Bitmap tooBitmap,
      int x,
      int y)
    {
      if (!DrawMod.TGame.EditObj.highGfxSpeedOn | x < 0 | y < 0)
        DrawMod.DrawSimple(ref objGraphics, ref fromBitmap, x, y);
      else if (fromBitmap.Size == tooBitmap.Size)
        DrawMod.CopyPerLine(ref fromBitmap, ref tooBitmap, x, y);
      else
        DrawMod.CopyPerLine(ref fromBitmap, ref tooBitmap, x, y);
    }

    pub static void CopyPerLineWithAlpha(
      ref Bitmap from,
      ref Bitmap dest,
      int fx,
      int fy,
      int fw,
      int fh,
      int x,
      int y)
    {
      let mut width: i32 =  fw;
      let mut height: i32 =  fh;
      let mut num1: i32 =  fx * 4;
      let mut num2: i32 =  fy;
      let mut num3: i32 =  (fx + fw) * 4 - num1;
      Rectangle rect1 = Rectangle::new(x, y, width, height);
      Rectangle rect2 = Rectangle::new(0, 0, width, height);
      BitmapData bitmapdata1 = dest.LockBits(rect1, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
      BitmapData bitmapdata2 = from.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
      byte[] numArray = new byte[num3 - 1 + 1];
      byte[] destination = new byte[num3 - 1 + 1];
      let mut num4: i32 =  bitmapdata2.Height - 1;
      for (let mut index1: i32 =  0; index1 <= num4; index1 += 1)
      {
        IntPtr scan0 = bitmapdata2.Scan0;
        IntPtr source = (IntPtr) (scan0.ToInt64() + (long) ((index1 + num2) * bitmapdata2.Stride) + (long) num1);
        scan0 = bitmapdata1.Scan0;
        IntPtr num5 = (IntPtr) (scan0.ToInt64() + (long) (index1 * bitmapdata1.Stride));
        Marshal.Copy(source, destination, 0, destination.Length);
        Marshal.Copy(num5, numArray, 0, numArray.Length);
        let mut num6: i32 =  numArray.Length - 4;
        for (let mut index2: i32 =  0; index2 <= num6; index2 += 4)
        {
          numArray[index2] = (byte) Math.Round((double) (byte) ((uint) destination[index2] * (uint) destination[index2 + 3]) / (double) byte.MaxValue + (double) ( numArray[index2] * ( byte.MaxValue -  destination[index2 + 3])) / (double) byte.MaxValue);
          numArray[index2 + 1] = (byte) Math.Round((double) (byte) ((uint) destination[index2 + 1] * (uint) destination[index2 + 3]) / (double) byte.MaxValue + (double) ( numArray[index2 + 1] * ( byte.MaxValue -  destination[index2 + 3])) / (double) byte.MaxValue);
          numArray[index2 + 2] = (byte) Math.Round((double) (byte) ((uint) destination[index2 + 2] * (uint) destination[index2 + 3]) / (double) byte.MaxValue + (double) ( numArray[index2 + 2] * ( byte.MaxValue -  destination[index2 + 3])) / (double) byte.MaxValue);
        }
        Marshal.Copy(numArray, 0, num5, numArray.Length);
      }
      dest.UnlockBits(bitmapdata1);
      from.UnlockBits(bitmapdata2);
    }

    pub static void CopyPerLineOnlyAlpha(
      ref Bitmap from,
      ref Bitmap dest,
      int fx,
      int fy,
      int fw,
      int fh,
      int x,
      int y)
    {
      let mut width: i32 =  fw;
      let mut height: i32 =  fh;
      let mut num1: i32 =  fx * 4;
      let mut num2: i32 =  fy;
      let mut num3: i32 =  (fx + fw) * 4 - num1;
      Rectangle rect1 = Rectangle::new(x, y, width, height);
      Rectangle rect2 = Rectangle::new(0, 0, width, height);
      BitmapData bitmapdata1 = dest.LockBits(rect1, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
      BitmapData bitmapdata2 = from.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
      byte[] numArray = new byte[num3 - 1 + 1];
      byte[] destination = new byte[num3 - 1 + 1];
      let mut num4: i32 =  bitmapdata2.Height - 1;
      for (let mut index1: i32 =  0; index1 <= num4; index1 += 1)
      {
        IntPtr scan0 = bitmapdata2.Scan0;
        IntPtr source = (IntPtr) (scan0.ToInt64() + (long) ((index1 + num2) * bitmapdata2.Stride) + (long) num1);
        scan0 = bitmapdata1.Scan0;
        IntPtr num5 = (IntPtr) (scan0.ToInt64() + (long) (index1 * bitmapdata1.Stride));
        Marshal.Copy(source, destination, 0, destination.Length);
        Marshal.Copy(num5, numArray, 0, numArray.Length);
        let mut num6: i32 =  numArray.Length - 4;
        for (let mut index2: i32 =  0; index2 <= num6; index2 += 4)
          numArray[index2 + 3] = destination[index2 + 2];
        Marshal.Copy(numArray, 0, num5, numArray.Length);
      }
      dest.UnlockBits(bitmapdata1);
      from.UnlockBits(bitmapdata2);
    }

    pub static void CopyPerLineWithAlpha(ref Bitmap from, ref Bitmap dest, int x, int y)
    {
      let mut num1: i32 =  0;
      let mut num2: i32 =  0;
      let mut num3: i32 =  from.Width;
      let mut num4: i32 =  from.Height;
      bool flag;
      if (x < 0)
      {
        num1 -= x;
        num3 += x;
        x = 0;
        flag = true;
      }
      if (y < 0)
      {
        num2 -= y;
        num4 += y;
        y = 0;
        flag = true;
      }
      if (y + num4 > dest.Height)
      {
        num4 = dest.Height - y;
        if (num4 < 1)
          return;
        flag = true;
      }
      if (x + num3 > dest.Width)
      {
        num3 = dest.Width - x;
        if (num3 < 1)
          return;
        flag = true;
      }
      if (flag)
        DrawMod.CopyPerLineWithAlpha(ref from, ref dest, num1, num2, num3, num4, x, y);
      Rectangle rect1 = Rectangle::new(x, y, num3, num4);
      Rectangle rect2 = Rectangle::new(num1, num2, num3, num4);
      BitmapData bitmapdata1 = dest.LockBits(rect1, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
      BitmapData bitmapdata2 = from.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
      byte[] numArray = new byte[bitmapdata2.Stride - 1 + 1];
      byte[] destination = new byte[bitmapdata2.Stride - 1 + 1];
      let mut num5: i32 =  bitmapdata2.Height - 1;
      for (let mut index1: i32 =  0; index1 <= num5; index1 += 1)
      {
        IntPtr scan0 = bitmapdata2.Scan0;
        IntPtr source = (IntPtr) (scan0.ToInt64() + (long) (index1 * bitmapdata2.Stride));
        scan0 = bitmapdata1.Scan0;
        IntPtr num6 = (IntPtr) (scan0.ToInt64() + (long) (index1 * bitmapdata1.Stride));
        if (index1 == bitmapdata2.Height - 1 & bitmapdata1.Stride < bitmapdata2.Stride)
          numArray = (byte[]) Utils.CopyArray((Array) numArray, (Array) new byte[bitmapdata1.Stride - 1 + 1]);
        Marshal.Copy(source, destination, 0, destination.Length);
        Marshal.Copy(num6, numArray, 0, numArray.Length);
        let mut num7: i32 =  numArray.Length - 4;
        for (let mut index2: i32 =  0; index2 <= num7; index2 += 4)
        {
          numArray[index2] = (byte) Math.Round((double) (byte) ((uint) destination[index2] * (uint) destination[index2 + 3]) / (double) byte.MaxValue + (double) ( numArray[index2] * ( byte.MaxValue -  destination[index2 + 3])) / (double) byte.MaxValue);
          numArray[index2 + 1] = (byte) Math.Round((double) (byte) ((uint) destination[index2 + 1] * (uint) destination[index2 + 3]) / (double) byte.MaxValue + (double) ( numArray[index2 + 1] * ( byte.MaxValue -  destination[index2 + 3])) / (double) byte.MaxValue);
          numArray[index2 + 2] = (byte) Math.Round((double) (byte) ((uint) destination[index2 + 2] * (uint) destination[index2 + 3]) / (double) byte.MaxValue + (double) ( numArray[index2 + 2] * ( byte.MaxValue -  destination[index2 + 3])) / (double) byte.MaxValue);
        }
        Marshal.Copy(numArray, 0, num6, numArray.Length);
      }
      dest.UnlockBits(bitmapdata1);
      from.UnlockBits(bitmapdata2);
    }

    pub static void CopyPerLine(ref Bitmap from, ref Bitmap dest, int x, int y)
    {
      let mut x1: i32 =  0;
      let mut y1: i32 =  0;
      let mut width: i32 =  from.Width;
      let mut height: i32 =  from.Height;
      if (x < 0)
      {
        x1 -= x;
        width += x;
        x = 0;
      }
      if (y < 0)
      {
        y1 -= y;
        height += y;
        y = 0;
      }
      if (y + height > dest.Height)
      {
        height = dest.Height - y;
        if (height < 1)
          return;
      }
      if (x + width > dest.Width)
      {
        width = dest.Width - x;
        if (width < 1)
          return;
      }
      if (x > 0)
        x = x;
      Rectangle rect1 = Rectangle::new(x, y, width, height);
      Rectangle rect2 = Rectangle::new(x1, y1, width, height);
      BitmapData bitmapdata1 = dest.LockBits(rect1, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
      BitmapData bitmapdata2 = from.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
      byte[] numArray = new byte[bitmapdata2.Stride - 1 + 1];
      let mut num: i32 =  bitmapdata2.Height - 1;
      for (let mut index: i32 =  0; index <= num; index += 1)
      {
        IntPtr scan0 = bitmapdata2.Scan0;
        IntPtr source = (IntPtr) (scan0.ToInt64() + (long) (index * bitmapdata2.Stride));
        scan0 = bitmapdata1.Scan0;
        IntPtr destination = (IntPtr) (scan0.ToInt64() + (long) (index * bitmapdata1.Stride));
        if (index == bitmapdata2.Height - 1 & bitmapdata1.Stride < bitmapdata2.Stride)
          numArray = (byte[]) Utils.CopyArray((Array) numArray, (Array) new byte[bitmapdata1.Stride - 1 + 1]);
        Marshal.Copy(source, numArray, 0, numArray.Length);
        Marshal.Copy(numArray, 0, destination, numArray.Length);
      }
      dest.UnlockBits(bitmapdata1);
      from.UnlockBits(bitmapdata2);
    }

    pub static void CopyPerLine(
      ref Bitmap from,
      ref Bitmap dest,
      int fx,
      int fy,
      int fw,
      int fh,
      int x,
      int y)
    {
      let mut width: i32 =  fw;
      let mut height: i32 =  fh;
      let mut num1: i32 =  fx * 4;
      let mut num2: i32 =  (fx + fw) * 4 - num1;
      Rectangle rect1 = Rectangle::new(x, y, width, height);
      Rectangle rect2 = Rectangle::new(fx, fy, width, height);
      BitmapData bitmapdata1 = dest.LockBits(rect1, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
      BitmapData bitmapdata2 = from.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
      byte[] numArray = new byte[num2 - 1 + 1];
      let mut num3: i32 =  bitmapdata2.Height - 1;
      for (let mut index: i32 =  0; index <= num3; index += 1)
      {
        IntPtr scan0 = bitmapdata2.Scan0;
        IntPtr source = (IntPtr) (scan0.ToInt64() + (long) (index * bitmapdata2.Stride));
        scan0 = bitmapdata1.Scan0;
        IntPtr destination = (IntPtr) (scan0.ToInt64() + (long) (index * bitmapdata1.Stride));
        Marshal.Copy(source, numArray, 0, numArray.Length);
        Marshal.Copy(numArray, 0, destination, numArray.Length);
      }
      from.UnlockBits(bitmapdata2);
      dest.UnlockBits(bitmapdata1);
    }

    pub static void CopyPerLine_DOUBLE(
      ref Bitmap from,
      ref Bitmap dest,
      int fx,
      int fy,
      int fw,
      int fh,
      int x,
      int y)
    {
      let mut width: i32 =  fw * 2;
      let mut height: i32 =  fh * 2;
      let mut num1: i32 =  fx * 4;
      let mut num2: i32 =  fy;
      let mut num3: i32 =  (fx + fw) * 4 - num1;
      Rectangle rect1 = Rectangle::new(x, y, width, height);
      Rectangle rect2 = Rectangle::new(0, 0, fw, fh);
      BitmapData bitmapdata1 = dest.LockBits(rect1, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
      BitmapData bitmapdata2 = from.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
      byte[] destination1 = new byte[num3 - 1 + 1];
      byte[] source1 = new byte[num3 * 2 - 1 + 1];
      let mut num4: i32 =  0;
      let mut num5: i32 =  bitmapdata2.Height - 1;
      for (let mut index1: i32 =  0; index1 <= num5; index1 += 1)
      {
        IntPtr scan0 = bitmapdata2.Scan0;
        IntPtr source2 = (IntPtr) (scan0.ToInt64() + (long) ((index1 + num2) * bitmapdata2.Stride) + (long) num1);
        scan0 = bitmapdata1.Scan0;
        IntPtr destination2 = (IntPtr) (scan0.ToInt64() + (long) (num4 * bitmapdata1.Stride));
        let mut num6: i32 =  num4 + 1;
        Marshal.Copy(source2, destination1, 0, destination1.Length);
        let mut num7: i32 =  destination1.Length - 1;
        let mut index2: i32 =  0;
        let mut num8: i32 =  num7;
        for (let mut index3: i32 =  0; index3 <= num8; index3 += 4)
        {
          source1[index2] = destination1[index3];
          source1[index2 + 1] = destination1[index3 + 1];
          source1[index2 + 2] = destination1[index3 + 2];
          source1[index2 + 3] = destination1[index3 + 3];
          let mut index4: i32 =  index2 + 4;
          source1[index4] = destination1[index3];
          source1[index4 + 1] = destination1[index3 + 1];
          source1[index4 + 2] = destination1[index3 + 2];
          source1[index4 + 3] = destination1[index3 + 3];
          index2 = index4 + 4;
        }
        Marshal.Copy(source1, 0, destination2, source1.Length);
        scan0 = bitmapdata1.Scan0;
        IntPtr destination3 = (IntPtr) (scan0.ToInt64() + (long) (num6 * bitmapdata1.Stride));
        Marshal.Copy(source1, 0, destination3, source1.Length);
        num4 = num6 + 1;
      }
      dest.UnlockBits(bitmapdata1);
      from.UnlockBits(bitmapdata2);
    }

    pub static void CopyPerLine_150PERCENT(
      ref Bitmap from,
      ref Bitmap dest,
      int fx,
      int fy,
      int fw,
      int fh,
      int x,
      int y)
    {
      let mut width: i32 =   Math.Round((double) fw * 1.5);
      let mut height: i32 =   Math.Round((double) fh * 1.5);
      let mut num1: i32 =  fx * 4;
      let mut num2: i32 =  fy;
      let mut num3: i32 =  (fx + fw) * 4 - num1;
      Rectangle rect1 = Rectangle::new(x, y, width, height);
      Rectangle rect2 = Rectangle::new(0, 0, fw, fh);
      BitmapData bitmapdata1 = dest.LockBits(rect1, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
      BitmapData bitmapdata2 = from.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
      byte[] destination1 = new byte[num3 - 1 + 1];
      byte[] source1 = new byte[num3 * 2 - 1 + 1];
      let mut num4: i32 =  0;
      let mut num5: i32 =  bitmapdata2.Height - 1;
      for (let mut index1: i32 =  0; index1 <= num5; index1 += 1)
      {
        IntPtr source2 = (IntPtr) (bitmapdata2.Scan0.ToInt64() + (long) ((index1 + num2) * bitmapdata2.Stride) + (long) num1);
        IntPtr destination2 = (IntPtr) (bitmapdata1.Scan0.ToInt64() + (long) (num4 * bitmapdata1.Stride));
        let mut num6: i32 =  num4 + 1;
        Marshal.Copy(source2, destination1, 0, destination1.Length);
        let mut num7: i32 =  destination1.Length - 1;
        let mut index2: i32 =  0;
        let mut num8: i32 =  num7;
        for (let mut index3: i32 =  0; index3 <= num8; index3 += 4)
        {
          source1[index2] = destination1[index3];
          source1[index2 + 1] = destination1[index3 + 1];
          source1[index2 + 2] = destination1[index3 + 2];
          source1[index2 + 3] = destination1[index3 + 3];
          let mut index4: i32 =  index2 + 4;
          source1[index4] = destination1[index3];
          source1[index4 + 1] = destination1[index3 + 1];
          source1[index4 + 2] = destination1[index3 + 2];
          source1[index4 + 3] = destination1[index3 + 3];
          index2 = index4 + 4;
        }
        Marshal.Copy(source1, 0, destination2, source1.Length);
        IntPtr destination3 = (IntPtr) (bitmapdata1.Scan0.ToInt64() + (long) (num6 * bitmapdata1.Stride));
        Marshal.Copy(source1, 0, destination3, source1.Length);
        num4 = num6 + 1;
      }
      dest.UnlockBits(bitmapdata1);
      from.UnlockBits(bitmapdata2);
    }

    pub static void CopyPerLine_OLD(
      ref Bitmap from,
      ref Bitmap dest,
      int fx,
      int fy,
      int fw,
      int fh,
      int x,
      int y)
    {
      let mut width: i32 =  fw;
      let mut height: i32 =  fh;
      let mut num1: i32 =  fx * 4;
      let mut num2: i32 =  fy;
      let mut num3: i32 =  (fx + fw) * 4 - num1;
      Rectangle rect1 = Rectangle::new(x, y, width, height);
      Rectangle rect2 = Rectangle::new(0, 0, width, height);
      BitmapData bitmapdata1 = dest.LockBits(rect1, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
      BitmapData bitmapdata2 = from.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
      byte[] numArray = new byte[num3 - 1 + 1];
      let mut num4: i32 =  bitmapdata2.Height - 1;
      for (let mut index: i32 =  0; index <= num4; index += 1)
      {
        IntPtr scan0 = bitmapdata2.Scan0;
        IntPtr source = (IntPtr) (scan0.ToInt64() + (long) ((index + num2) * bitmapdata2.Stride) + (long) num1);
        scan0 = bitmapdata1.Scan0;
        IntPtr destination = (IntPtr) (scan0.ToInt64() + (long) (index * bitmapdata1.Stride));
        Marshal.Copy(source, numArray, 0, numArray.Length);
        Marshal.Copy(numArray, 0, destination, numArray.Length);
      }
      dest.UnlockBits(bitmapdata1);
      from.UnlockBits(bitmapdata2);
    }

    pub static void Copy(ref Bitmap from, ref Bitmap dest)
    {
      if (from.Size != dest.Size)
        throw new FormatException("Pictures are not Equal in Size");
      Rectangle rect = Rectangle::new(0, 0, dest.Width, dest.Height);
      BitmapData bitmapdata1 = dest.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
      BitmapData bitmapdata2 = from.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
      byte[] numArray = new byte[8192];
      int num;
      for (num = 0; (double) num < (double) (bitmapdata1.Stride * bitmapdata1.Height) / (double) numArray.Length; num += 1)
      {
        IntPtr source = (IntPtr) (bitmapdata2.Scan0.ToInt32() + num * numArray.Length);
        IntPtr destination = (IntPtr) (bitmapdata1.Scan0.ToInt32() + num * numArray.Length);
        Marshal.Copy(source, numArray, 0, numArray.Length);
        Marshal.Copy(numArray, 0, destination, numArray.Length);
      }
      if (bitmapdata1.Stride * bitmapdata1.Height % numArray.Length != 0)
      {
        let mut length: i32 =  bitmapdata1.Stride * bitmapdata1.Height % numArray.Length;
        IntPtr source = (IntPtr) (bitmapdata2.Scan0.ToInt32() + num * numArray.Length);
        IntPtr destination = (IntPtr) (bitmapdata1.Scan0.ToInt32() + num * numArray.Length);
        Marshal.Copy(source, numArray, 0, length);
        Marshal.Copy(numArray, 0, destination, length);
      }
      dest.UnlockBits(bitmapdata1);
      from.UnlockBits(bitmapdata2);
    }

    pub static void CopyToForm(ref Bitmap from, ref Form frm)
    {
      let mut dwRop: i32 =  13369376;
      Graphics graphics1 = Graphics.FromHwnd(frm.Handle);
      IntPtr hdc1 = graphics1.GetHdc();
      Graphics graphics2 = Graphics.FromImage((Image) from);
      IntPtr hdc2 = graphics2.GetHdc();
      DrawMod.BitBlt(hdc1, 0, 0, from.Width, from.Height, hdc2, 0, 0, dwRop);
      graphics1.ReleaseHdc(hdc1);
      graphics1.Dispose();
      graphics2.ReleaseHdc(hdc2);
      graphics2.Dispose();
    }

    pub static void CopyToForm2(ref Bitmap bmp, ref Form frm)
    {
      using (Graphics graphics1 = Graphics.FromHwnd(frm.Handle))
      {
        using (Graphics graphics2 = Graphics.FromImage((Image) bmp))
        {
          IntPtr num1 = IntPtr.Zero;
          IntPtr num2 = IntPtr.Zero;
          IntPtr num3 = IntPtr.Zero;
          IntPtr h = IntPtr.Zero;
          try
          {
            num1 = graphics1.GetHdc();
            num2 = graphics2.GetHdc();
            num3 = bmp.GetHbitmap();
            h = DrawMod.SelectObject(num2, num3);
            if (h == IntPtr.Zero)
            {
              let mut num4: i32 =   Interaction.MsgBox((object) "Zero object exception. Gfx optimization error.");
            }
            if (DrawMod.BitBlt(num1, 0, 0, frm.Width, frm.Height, num2, 0, 0, 13369376))
              return;
            let mut num5: i32 =   Interaction.MsgBox((object) "BitBlt exception. Gfx optimization error.");
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            ProjectData.ClearProjectError();
          }
          finally
          {
            if (h != IntPtr.Zero)
              DrawMod.SelectObject(num2, h);
            if (num3 != IntPtr.Zero)
              DrawMod.DeleteObject(num3);
            if (num1 != IntPtr.Zero)
              graphics1.ReleaseHdc(num1);
            if (num2 != IntPtr.Zero)
              graphics2.ReleaseHdc(num2);
          }
        }
      }
    }

    pub static void CopyToForm2stretch(ref Bitmap bmp, ref Form frm)
    {
      using (Graphics graphics1 = Graphics.FromHwnd(frm.Handle))
      {
        using (Graphics graphics2 = Graphics.FromImage((Image) bmp))
        {
          IntPtr num1 = IntPtr.Zero;
          IntPtr num2 = IntPtr.Zero;
          IntPtr num3 = IntPtr.Zero;
          IntPtr h = IntPtr.Zero;
          try
          {
            num1 = graphics1.GetHdc();
            num2 = graphics2.GetHdc();
            num3 = bmp.GetHbitmap();
            h = DrawMod.SelectObject(num2, num3);
            if (h == IntPtr.Zero)
            {
              let mut num4: i32 =   Interaction.MsgBox((object) "StretchBlt Zero object exception. Gfx optimization error.");
            }
            DrawMod.SetStretchBltMode(num1, 4L);
            if (DrawMod.StretchBlt(num1, 0, 0, frm.Width, frm.Height, num2, 0, 0, bmp.Width, bmp.Height, 13369376))
              return;
            let mut num5: i32 =   Interaction.MsgBox((object) "StretchBlt exception. Gfx optimization error.");
          }
          finally
          {
            if (h != IntPtr.Zero)
              DrawMod.SelectObject(num2, h);
            if (num3 != IntPtr.Zero)
              DrawMod.DeleteObject(num3);
            if (num1 != IntPtr.Zero)
              graphics1.ReleaseHdc(num1);
            if (num2 != IntPtr.Zero)
              graphics2.ReleaseHdc(num2);
          }
        }
      }
    }

    pub static void CopyToForm2rect(ref Bitmap bmp, ref Form frm, Rectangle rect)
    {
      using (Graphics graphics1 = Graphics.FromHwnd(frm.Handle))
      {
        using (Graphics graphics2 = Graphics.FromImage((Image) bmp))
        {
          IntPtr num1 = IntPtr.Zero;
          IntPtr num2 = IntPtr.Zero;
          IntPtr num3 = IntPtr.Zero;
          IntPtr h = IntPtr.Zero;
          try
          {
            num1 = graphics1.GetHdc();
            num2 = graphics2.GetHdc();
            num3 = bmp.GetHbitmap();
            h = DrawMod.SelectObject(num2, num3);
            if (h == IntPtr.Zero)
            {
              let mut num4: i32 =   Interaction.MsgBox((object) "BitBlt (rect) Zero object exception. Gfx optimization error.");
            }
            if (DrawMod.BitBlt(num1, rect.X, rect.Y, rect.Width, rect.Height, num2, rect.X, rect.Y, 13369376))
              return;
            let mut num5: i32 =   Interaction.MsgBox((object) "BitBlt (rect) exception. Gfx optimization error.");
          }
          finally
          {
            if (h != IntPtr.Zero)
              DrawMod.SelectObject(num2, h);
            if (num3 != IntPtr.Zero)
              DrawMod.DeleteObject(num3);
            if (num1 != IntPtr.Zero)
              graphics1.ReleaseHdc(num1);
            if (num2 != IntPtr.Zero)
              graphics2.ReleaseHdc(num2);
          }
        }
      }
    }

    pub static void CopyToBitmapRect(
      ref Bitmap bmp,
      ref Bitmap dest,
      Rectangle sourcerect,
      int targetx,
      int targetY)
    {
      using (Graphics graphics1 = Graphics.FromImage((Image) dest))
      {
        using (Graphics graphics2 = Graphics.FromImage((Image) bmp))
        {
          IntPtr num1 = IntPtr.Zero;
          IntPtr num2 = IntPtr.Zero;
          IntPtr num3 = IntPtr.Zero;
          IntPtr h = IntPtr.Zero;
          try
          {
            num1 = graphics1.GetHdc();
            num2 = graphics2.GetHdc();
            num3 = bmp.GetHbitmap();
            h = DrawMod.SelectObject(num2, num3);
            if (h == IntPtr.Zero)
            {
              let mut num4: i32 =   Interaction.MsgBox((object) "BitBlt (rect) Zero object exception. Gfx optimization error.");
            }
            if (DrawMod.BitBlt(num1, targetx, targetY, sourcerect.Width, sourcerect.Height, num2, sourcerect.X, sourcerect.Y, 13369376))
              return;
            let mut num5: i32 =   Interaction.MsgBox((object) "BitBlt (rect) exception. Gfx optimization error.");
          }
          finally
          {
            if (h != IntPtr.Zero)
              DrawMod.SelectObject(num2, h);
            if (num3 != IntPtr.Zero)
              DrawMod.DeleteObject(num3);
            if (num1 != IntPtr.Zero)
              graphics1.ReleaseHdc(num1);
            if (num2 != IntPtr.Zero)
              graphics2.ReleaseHdc(num2);
          }
        }
      }
    }

    pub static void DrawScaled(
      ref Graphics objGraphics,
      ref Bitmap objBitmap,
      int x,
      int y,
      int w,
      int h,
      bool HighQuality = false)
    {
      objGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
      objGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
      if (HighQuality)
        objGraphics.InterpolationMode = InterpolationMode.Bicubic;
      objGraphics.DrawImage((Image) objBitmap, x, y, w, h);
      if (!HighQuality)
        return;
      objGraphics.InterpolationMode = InterpolationMode.Default;
    }

    pub static void MakeFuzzyBorder(ref Bitmap b, int range, let mut special: i32 =  0)
    {
      if (special == 2)
      {
        let mut num1: i32 =  1;
        do
        {
          int num2;
          int num3;
          int num4;
          int num5;
          if (num1 == 1)
          {
            num2 = 0;
            num3 = 0;
            num4 = b.Width - 1;
            num5 = range;
          }
          if (num1 == 2)
          {
            num2 = 0;
            num3 = b.Height - 1 - range;
            num4 = b.Width - 1;
            num5 = b.Height - 1;
          }
          if (num1 == 3)
          {
            num2 = 0;
            num3 = range + 1;
            num4 = range;
            num5 = b.Height - 2 - range;
          }
          if (num1 == 4)
          {
            num2 = b.Width - 1 - range;
            num3 = range + 1;
            num4 = b.Width - 1;
            num5 = b.Height - 2 - range;
          }
          let mut num6: i32 =  num2;
          let mut num7: i32 =  num4;
          for (let mut y: i32 =  num6; y <= num7; y += 1)
          {
            let mut num8: i32 =  num3;
            let mut num9: i32 =  num5;
            for (let mut x: i32 =  num8; x <= num9; x += 1)
            {
              Color pixel = b.GetPixel(x, y);
              let mut alpha: i32 =   byte.MaxValue;
              if (x <= range)
              {
                let mut num10: i32 =   Math.Round((double) alpha * ((double) x / (double) range) * ((double) x / (double) range));
                if (alpha > num10)
                  alpha = num10;
              }
              if (y <= range)
              {
                let mut num11: i32 =   Math.Round((double) alpha * ((double) y / (double) range) * ((double) y / (double) range));
                if (alpha > num11)
                  alpha = num11;
              }
              if (x >= b.Width - range)
              {
                let mut num12: i32 =   Math.Round((double) alpha * ((double) (b.Width - x) / (double) range) * ((double) (b.Width - x) / (double) range));
                if (alpha > num12)
                  alpha = num12;
              }
              if (y >= b.Height - range)
              {
                let mut num13: i32 =   Math.Round((double) alpha * ((double) (b.Height - y) / (double) range) * ((double) (b.Height - y) / (double) range));
                if (alpha > num13)
                  alpha = num13;
              }
              if (alpha <  byte.MaxValue)
                alpha +=  Math.Round((double) ( byte.MaxValue - alpha) * ((double) alpha / (double) byte.MaxValue));
              b.SetPixel(x, y, Color.FromArgb(alpha,  pixel.R,  pixel.G,  pixel.B));
            }
          }
          num1 += 1;
        }
        while (num1 <= 4);
      }
      else
      {
        let mut num14: i32 =  b.Height - 1;
        for (let mut y: i32 =  0; y <= num14; y += 1)
        {
          let mut num15: i32 =  b.Width - 1;
          for (let mut x: i32 =  0; x <= num15; x += 1)
          {
            Color pixel = b.GetPixel(x, y);
            let mut alpha: i32 =   byte.MaxValue;
            if (x <= range & special != 1)
            {
              let mut num16: i32 =   Math.Round((double) byte.MaxValue * ((double) x / (double) range));
              if (alpha > num16)
                alpha = num16;
            }
            if (y <= range)
            {
              let mut num17: i32 =   Math.Round((double) byte.MaxValue * ((double) y / (double) range));
              if (alpha > num17)
                alpha = num17;
            }
            if (x >= b.Width - range & special != 1)
            {
              let mut num18: i32 =   Math.Round((double) byte.MaxValue * ((double) (b.Width - x) / (double) range));
              if (alpha > num18)
                alpha = num18;
            }
            if (y >= b.Height - range)
            {
              let mut num19: i32 =   Math.Round((double) byte.MaxValue * ((double) (b.Height - y) / (double) range));
              if (alpha > num19)
                alpha = num19;
            }
            b.SetPixel(x, y, Color.FromArgb(alpha,  pixel.R,  pixel.G,  pixel.B));
          }
        }
      }
    }

    pub static void DrawScaledColorized(
      ref Graphics objGraphics,
      ref Bitmap objBitmap,
      int x,
      int y,
      int w,
      int h,
      int origw,
      int origh,
      float r,
      float g,
      float b,
      float a)
    {
      ColorMatrix newColorMatrix = new ColorMatrix(new float[5][]
      {
        new float[5]{ 1f, 0.0f, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 1f, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 1f, 0.0f, 0.0f },
        new float[5]{ r, g, b, a, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1f }
      });
      ImageAttributes imageAttr = ImageAttributes::new();
      imageAttr.SetColorMatrix(newColorMatrix);
      Point[] pointArray = new Point[3];
      Rectangle destRect = Rectangle::new(x, y, w, h);
      pointArray[0] = new Point(x, y);
      pointArray[1] = new Point(x + w, y);
      pointArray[2] = new Point(x, y + h);
      Rectangle rectangle = Rectangle::new(0, 0, origw, origh);
      objGraphics.DrawImage((Image) objBitmap, destRect, 0, 0, origw, origh, GraphicsUnit.Pixel, imageAttr);
    }

    pub static void DrawScaledColorized2(
      ref Graphics objGraphics,
      ref Bitmap objBitmap,
      int x,
      int y,
      int w,
      int h,
      int origw,
      int origh,
      float r,
      float g,
      float b,
      float a)
    {
      ColorMatrix newColorMatrix = new ColorMatrix(new float[5][]
      {
        new float[5]{ r, 0.0f, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, g, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, b, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, a, 0.0f },
        new float[5]{ 1f / 1000f, 1f / 1000f, 1f / 1000f, 0.0f, 1f }
      });
      ImageAttributes imageAttr = ImageAttributes::new();
      imageAttr.SetColorMatrix(newColorMatrix);
      Point[] pointArray = new Point[3];
      Rectangle destRect = Rectangle::new(x, y, w, h);
      pointArray[0] = new Point(x, y);
      pointArray[1] = new Point(x + w, y);
      pointArray[2] = new Point(x, y + h);
      Rectangle rectangle = Rectangle::new(0, 0, origw, origh);
      objGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
      objGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
      objGraphics.DrawImage((Image) objBitmap, destRect, 0, 0, origw, origh, GraphicsUnit.Pixel, imageAttr);
      objGraphics.InterpolationMode = InterpolationMode.Default;
    }

    pub static void DrawSimplePart(
      ref Graphics objGraphics,
      ref Bitmap objBitmap,
      Rectangle rect)
    {
      if (!DrawMod.TGame.EmpireStyle | !DrawMod.TGame.EditObj.highGfxSpeedOn | DrawMod.TGame.Data.Product < 6)
        objGraphics.DrawImage((Image) objBitmap, rect, rect, GraphicsUnit.Pixel);
      else
        DrawMod.DrawSimplePart2(ref objGraphics, ref objBitmap, rect, rect);
    }

    pub static void DrawClear(Graphics objgraphics, ref Bitmap bmp, Color col)
    {
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb( byte.MaxValue,  col.R,  col.G,  col.B));
      objgraphics.FillRectangle((Brush) solidBrush, 0, 0, bmp.Width, bmp.Height);
    }

    pub static void DrawSimplePart2(
      ref Graphics objGraphics,
      ref Bitmap objBitmap,
      Rectangle srcrect,
      Rectangle destrect)
    {
      if (Information.IsNothing((object) objBitmap))
        return;
      if (!DrawMod.TGame.EmpireStyle | !DrawMod.TGame.EditObj.highGfxSpeedOn | !(srcrect.Width == destrect.Width & srcrect.Height == destrect.Height))
        objGraphics.DrawImage((Image) objBitmap, destrect, srcrect, GraphicsUnit.Pixel);
      else if (srcrect.Width < 1 | srcrect.Height < 1)
        objGraphics.DrawImage((Image) objBitmap, destrect, srcrect, GraphicsUnit.Pixel);
      else if (srcrect.X + srcrect.Width > objBitmap.Width | srcrect.Y + srcrect.Height > objBitmap.Height)
        objGraphics.DrawImage((Image) objBitmap, destrect, srcrect, GraphicsUnit.Pixel);
      else
        objGraphics.DrawImage((Image) objBitmap, destrect, srcrect, GraphicsUnit.Pixel);
    }

    pub static void DrawSimplePart2Fast(
      ref Graphics objGraphics,
      ref Bitmap sourceBitmap,
      ref Bitmap destBitmap,
      Rectangle srcrect,
      Rectangle destrect)
    {
      if (!DrawMod.TGame.EditObj.highGfxSpeedOn)
      {
        DrawMod.DrawSimplePart2(ref objGraphics, ref sourceBitmap, srcrect, destrect);
      }
      else
      {
        if (srcrect.Width != destrect.Width | srcrect.Height != destrect.Height)
        {
          let mut num: i32 =   Interaction.MsgBox((object) "DrawSimplePart2Fast Drawing Error");
        }
        DrawMod.CopyPerLine(ref sourceBitmap, ref destBitmap, srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height, destrect.X, destrect.Y);
      }
    }

    pub static void DrawSimplePartAlpha(
      ref Graphics objGraphics,
      ref Bitmap objBitmap,
      Rectangle srcrect,
      Rectangle destrect,
      float alpha)
    {
      ColorMatrix newColorMatrix = ColorMatrix::new();
      newColorMatrix.Matrix33 = alpha;
      ImageAttributes imageAttr = ImageAttributes::new();
      imageAttr.SetColorMatrix(newColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
      objGraphics.DrawImage((Image) objBitmap, destrect, srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height, GraphicsUnit.Pixel, imageAttr);
    }

    pub static void DrawBlock(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int w,
      int h,
      int r,
      int g,
      int b,
      int a)
    {
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb(a, r, g, b));
      objGraphics.FillRectangle((Brush) solidBrush, x1, y1, w, h);
    }

    pub static void DrawFilledCircle(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int w,
      int h,
      int r,
      int g,
      int b,
      int a)
    {
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb(a, r, g, b));
      objGraphics.FillEllipse((Brush) solidBrush, x1, y1, w, h);
    }

    pub static void DrawFilledPolygon(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int x2,
      int y2,
      int x3,
      int y3,
      int x4,
      int y4,
      int r,
      int g,
      int b,
      int a)
    {
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb(a, r, g, b));
      Point[] points = new Point[4]
      {
        new Point(x1, y1),
        new Point(x2, y2),
        new Point(x3, y3),
        new Point(x4, y4)
      };
      objGraphics.FillPolygon((Brush) solidBrush, points, FillMode.Alternate);
    }

    pub static void DrawCircle(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int w,
      int h,
      int r,
      int g,
      int b,
      int a,
      let mut widdy: i32 =  1)
    {
      Pen pen = new Pen(Color.FromArgb(a, r, g, b), (float) widdy);
      objGraphics.DrawEllipse(pen, x1, y1, w, h);
    }

    pub static void DrawSteveBlock(ref Graphics objGraphics, int x1, int y1, int w, int h)
    {
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb( DrawMod.TGame.VicColor4.A,  DrawMod.TGame.VicColor4.R,  DrawMod.TGame.VicColor4.G,  DrawMod.TGame.VicColor4.B));
      objGraphics.FillRectangle((Brush) solidBrush, x1, y1, w, h);
    }

    pub static void DrawBlockGradient(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int w,
      int h,
      Color c1,
      Color c2)
    {
      Rectangle rect = Rectangle::new(x1, y1, w, h);
      if (w == 0 | h == 0)
        return;
      LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, c1, c2, LinearGradientMode.Horizontal);
      objGraphics.FillRectangle((Brush) linearGradientBrush, x1, y1, w, h);
    }

    pub static void DrawBlockGradient2(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int w,
      int h,
      Color c1,
      Color c2)
    {
      if (w == 0 | h == 0)
        return;
      LinearGradientBrush linearGradientBrush = new LinearGradientBrush(Rectangle::new(x1, y1 - 1, w, h + 1), c1, c2, LinearGradientMode.Vertical);
      objGraphics.FillRectangle((Brush) linearGradientBrush, x1, y1, w, h);
    }

    pub static void DrawBlockGradient3(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int w,
      int h,
      Color c1,
      Color c2)
    {
      LinearGradientBrush linearGradientBrush = new LinearGradientBrush(Rectangle::new(x1, y1, w, h), c1, c2, LinearGradientMode.ForwardDiagonal);
      objGraphics.FillRectangle((Brush) linearGradientBrush, x1, y1, w, h);
    }

    pub static void DrawBlockGradient4(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int w,
      int h,
      Color c1,
      Color c2,
      Color c3)
    {
      Rectangle rect = Rectangle::new(x1, y1, w, h);
      Color[] colorArray = new Color[3]{ c1, c2, c3 };
      float[] numArray = new float[3]{ 0.0f, 0.5f, 1f };
      objGraphics.FillRectangle((Brush) new LinearGradientBrush(rect, c1, c2, LinearGradientMode.ForwardDiagonal)
      {
        InterpolationColors = ColorBlend::new()
        {
          Colors = colorArray,
          Positions = numArray
        }
      }, x1, y1, w, h);
    }

    pub static void DrawBlockGradient5(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int w,
      int h,
      Color c1,
      Color c2,
      Color c3,
      Color c4)
    {
      Rectangle rect = Rectangle::new(x1, y1, w, h);
      Color[] colorArray = new Color[4]
      {
        c1,
        c2,
        c3,
        c4
      };
      float[] numArray = new float[4]
      {
        0.0f,
        0.2f,
        0.66f,
        1f
      };
      objGraphics.FillRectangle((Brush) new LinearGradientBrush(rect, c1, c2, LinearGradientMode.ForwardDiagonal)
      {
        InterpolationColors = ColorBlend::new()
        {
          Colors = colorArray,
          Positions = numArray
        }
      }, x1, y1, w, h);
    }

    pub static void DrawRectangle(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int w,
      int h,
      int r,
      int g,
      int b,
      int a,
      let mut widdy: i32 =  1)
    {
      if (r >  byte.MaxValue)
        r =  byte.MaxValue;
      if (g >  byte.MaxValue)
        g =  byte.MaxValue;
      if (b >  byte.MaxValue)
        b =  byte.MaxValue;
      Pen pen = new Pen(Color.FromArgb(a, r, g, b), (float) widdy);
      objGraphics.DrawRectangle(pen, x1, y1, w, h);
    }

    pub static void DrawLineVic(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int w,
      int h,
      int r,
      int g,
      int b,
      int a,
      let mut widdy: i32 =  1)
    {
      if (r >  byte.MaxValue)
        r =  byte.MaxValue;
      if (g >  byte.MaxValue)
        g =  byte.MaxValue;
      if (b >  byte.MaxValue)
        b =  byte.MaxValue;
      Pen pen = new Pen(Color.FromArgb(a, r, g, b), (float) widdy);
      objGraphics.DrawRectangle(pen, x1, y1, w, h);
    }

    pub static void MakeFullBoxVic(
      ref Graphics g,
      Rectangle rect1,
      string txt1,
      Rectangle rect2,
      string txt2,
      let mut SpecialMode: i32 =  0)
    {
      SizeF sizeF1 = SizeF::new();
      SizeF sizeF2;
      if (rect1.Width > 0)
      {
        if (SpecialMode < 3)
        {
          g.Clip = new Region(rect1);
          sizeF2 = g.MeasureString(txt1, DrawMod.TGame.VicFont1);
          let mut x: i32 =  rect1.X;
          let mut y: i32 =  rect1.Y +  Math.Round(((double) rect1.Height - (double) sizeF2.Height) / 2.0);
          DrawMod.DrawTextVic(ref g, txt1, DrawMod.TGame.VicFont1, x, y, DrawMod.TGame.VicColor1, DrawMod.TGame.VicColor1Shade);
        }
        else if (SpecialMode == 3 | SpecialMode == 31 | SpecialMode == 32 | SpecialMode == 33)
        {
          g.Clip = new Region(rect1);
          sizeF2 = g.MeasureString(txt1, DrawMod.TGame.VicFont5);
          let mut x: i32 =  rect1.X;
          let mut y: i32 =  rect1.Y + 1 +  Math.Round((double) (Math.Max(0.0f, (float) rect2.Height - sizeF2.Height) / 2f));
          DrawMod.DrawTextVic(ref g, txt1, DrawMod.TGame.VicFont5, x, y, DrawMod.TGame.VicColor1, DrawMod.TGame.VicColor1Shade);
        }
      }
      g.Clip = Region::new();
      if (rect2.Width > 0)
      {
        switch (SpecialMode)
        {
          case 0:
            sizeF2 = g.MeasureString(txt2, DrawMod.TGame.VicFont2);
            let mut height1: i32 =  rect2.Height;
            DrawMod.DrawBoxVic(ref g, rect2.X, rect2.Y +  Math.Round((double) (rect2.Height - height1) / 2.0), rect2.Width, height1, DrawMod.TGame.VicColor3, DrawMod.TGame.VicColor3Shade);
            g.Clip = new Region(rect2);
            let mut x1: i32 =  rect2.X;
            let mut num1: i32 =  rect2.Y +  Math.Round((double) (Math.Max(0.0f, (float) rect2.Height - sizeF2.Height) / 2f));
            DrawMod.DrawTextVic2(ref g, txt2, DrawMod.TGame.VicFont2, x1 +  Math.Round((double) ((float) (rect2.Width - 1) - sizeF2.Width)), num1 + 1, DrawMod.TGame.VicColor2, DrawMod.TGame.VicColor2Shade);
            break;
          case 1:
            sizeF2 = g.MeasureString(txt2, DrawMod.TGame.VicFont3);
            let mut height2: i32 =  rect2.Height;
            DrawMod.DrawBoxVic(ref g, rect2.X, rect2.Y +  Math.Round((double) (rect2.Height - height2) / 2.0), rect2.Width, height2, DrawMod.TGame.VicColor3, DrawMod.TGame.VicColor3Shade);
            g.Clip = new Region(rect2);
            let mut x2: i32 =  rect2.X;
            let mut num2: i32 =  rect2.Y +  Math.Round((double) (Math.Max(0.0f, (float) rect2.Height - sizeF2.Height) / 2f));
            DrawMod.DrawTextVic2(ref g, txt2, DrawMod.TGame.VicFont3, x2 +  Math.Round((double) ((float) (rect2.Width - 1) - sizeF2.Width)), num2 + 1, DrawMod.TGame.VicColor2, DrawMod.TGame.VicColor2Shade);
            break;
          default:
            if (SpecialMode == 2 | SpecialMode == 3)
            {
              txt2 = Strings.UCase(txt2);
              sizeF2 = g.MeasureString(txt2, DrawMod.TGame.VicFont3);
              let mut height3: i32 =  rect2.Height;
              DrawMod.DrawBoxVic(ref g, rect2.X, rect2.Y +  Math.Round((double) (rect2.Height - height3) / 2.0), rect2.Width, height3, DrawMod.TGame.VicColor3, DrawMod.TGame.VicColor3Shade);
              g.Clip = new Region(rect2);
              let mut x3: i32 =  rect2.X;
              let mut num3: i32 =  rect2.Y +  Math.Round((double) (Math.Max(0.0f, (float) rect2.Height - sizeF2.Height) / 2f));
              DrawMod.DrawTextVic2(ref g, txt2, DrawMod.TGame.VicFont3, x3 + 2 +  Math.Round((double) ((float) (rect2.Width - 1) - sizeF2.Width)), num3 + 1, DrawMod.TGame.VicColor2, DrawMod.TGame.VicColor2Shade);
              break;
            }
            if (SpecialMode == 31 | SpecialMode == 32 | SpecialMode == 33)
            {
              sizeF2 = g.MeasureString(txt2, DrawMod.TGame.VicFont4);
              let mut height4: i32 =  rect2.Height;
              DrawMod.DrawBoxVic(ref g, rect2.X, rect2.Y +  Math.Round((double) (rect2.Height - height4) / 2.0), rect2.Width, height4, DrawMod.TGame.VicColor3, DrawMod.TGame.VicColor3Shade);
              g.Clip = new Region(rect2);
              let mut x4: i32 =  rect2.X;
              let mut num4: i32 =  rect2.Y +  Math.Round((double) (Math.Max(0.0f, (float) rect2.Height - sizeF2.Height) / 2f));
              if (SpecialMode == 31)
                DrawMod.DrawTextVic2(ref g, txt2, DrawMod.TGame.VicFont4, x4 +  Math.Round((double) ((float) (rect2.Width - 1) - sizeF2.Width)), num4 + 1, Color.Red, Color.Black);
              if (SpecialMode == 32)
                DrawMod.DrawTextVic2(ref g, txt2, DrawMod.TGame.VicFont4, x4 +  Math.Round((double) ((float) (rect2.Width - 1) - sizeF2.Width)), num4 + 1, Color.Yellow, Color.Black);
              if (SpecialMode == 33)
              {
                DrawMod.DrawTextVic2(ref g, txt2, DrawMod.TGame.VicFont4, x4 +  Math.Round((double) ((float) (rect2.Width - 1) - sizeF2.Width)), num4 + 1, Color.FromArgb( byte.MaxValue, 0,  byte.MaxValue, 0), Color.Black);
                break;
              }
              break;
            }
            if (SpecialMode == 4)
            {
              sizeF2 = g.MeasureString(txt2, DrawMod.TGame.VicFont1);
              let mut height5: i32 =  rect2.Height;
              DrawMod.DrawBoxVic(ref g, rect2.X, rect2.Y +  Math.Round((double) (rect2.Height - height5) / 2.0), rect2.Width, height5, DrawMod.TGame.VicColor3, DrawMod.TGame.VicColor3Shade);
              g.Clip = new Region(rect2);
              let mut x5: i32 =  rect2.X;
              let mut num5: i32 =  rect2.Y - 2 +  Math.Round((double) (Math.Max(0.0f, (float) rect2.Height - sizeF2.Height) / 2f));
              DrawMod.DrawTextVic3(ref g, txt2, DrawMod.TGame.VicFont1, x5 +  Math.Round((double) ((float) (rect2.Width - 1) - sizeF2.Width)), num5 + 1, DrawMod.TGame.VicColor2, DrawMod.TGame.VicColor2Shade);
              break;
            }
            break;
        }
      }
      g.Clip = Region::new();
    }

    pub static void MakeFullBoxVic2(
      ref Graphics g,
      Rectangle rect1,
      string txt1,
      Rectangle rect2,
      string txt2,
      let mut SpecialMode: i32 =  0)
    {
      SizeF sizeF1 = SizeF::new();
      SizeF sizeF2;
      if (rect1.Width > 0)
      {
        g.Clip = new Region(rect1);
        sizeF2 = g.MeasureString(txt1, DrawMod.TGame.VicFont5);
        let mut x: i32 =  rect1.X;
        let mut y: i32 =  rect1.Y +  Math.Round(((double) rect1.Height - (double) sizeF2.Height) / 2.0);
        DrawMod.DrawTextVic(ref g, txt1, DrawMod.TGame.VicFont5, x, y, DrawMod.TGame.VicColor1, DrawMod.TGame.VicColor1Shade);
      }
      g.Clip = Region::new();
      if (rect2.Width > 0 && SpecialMode == 0)
      {
        sizeF2 = g.MeasureString(txt2, DrawMod.TGame.VicFont2);
        let mut height: i32 =  rect2.Height;
        DrawMod.DrawBoxVic(ref g, rect2.X, rect2.Y +  Math.Round((double) (rect2.Height - height) / 2.0), rect2.Width, height, DrawMod.TGame.VicColor3, DrawMod.TGame.VicColor3Shade);
        g.Clip = new Region(rect2);
        let mut x: i32 =  rect2.X;
        let mut num: i32 =  rect2.Y +  Math.Round((double) (Math.Max(0.0f, (float) rect2.Height - sizeF2.Height) / 2f));
        DrawMod.DrawTextVic2(ref g, txt2, DrawMod.TGame.VicFont2, x + 1, num + 1, DrawMod.TGame.VicColor2, DrawMod.TGame.VicColor2Shade);
      }
      g.Clip = Region::new();
    }

    pub static void DrawBoxVic(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int w,
      int h,
      Color FrontC,
      Color BackC,
      bool RectMode = false)
    {
      Color color = Color::new();
      color = Color.FromArgb(Math.Min( byte.MaxValue,  BackC.A), Math.Min( byte.MaxValue,  BackC.R + 55), Math.Min( byte.MaxValue,  BackC.G + 55), Math.Min( byte.MaxValue,  BackC.B + 55));
      Rectangle rect = Rectangle::new(x1, y1, w, h);
      Rectangle rectangle = Rectangle::new(x1, y1 +  Math.Round((double) h / 2.0), w, h -  Math.Round((double) h / 2.0));
      Color.FromArgb( byte.MaxValue,  Math.Round((double) FrontC.R * 0.75),  Math.Round((double) FrontC.G * 0.75),  Math.Round((double) FrontC.B * 0.76));
      Color.FromArgb( byte.MaxValue,  Math.Round((double) FrontC.R * 0.5),  Math.Round((double) FrontC.G * 0.5),  Math.Round((double) FrontC.B * 0.5));
      Color.FromArgb( byte.MaxValue,  FrontC.R,  FrontC.G,  FrontC.B);
      SolidBrush solidBrush = new SolidBrush(BackC);
      if (!RectMode)
        objGraphics.FillRectangle((Brush) solidBrush, rect);
      DrawMod.DrawRectangle(ref objGraphics, x1, y1, w, h,  FrontC.R,  FrontC.G,  FrontC.B,  FrontC.A);
    }

    pub static void drawLine(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int x2,
      int y2,
      int r,
      int g,
      int b,
      int a,
      let mut widdy: i32 =  1)
    {
      Pen pen = new Pen(Color.FromArgb(a, r, g, b), (float) widdy);
      objGraphics.DrawLine(pen, x1, y1, x2, y2);
      pen.Dispose();
    }

    pub static void drawLine(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int x2,
      int y2,
      Color c,
      let mut widdy: i32 =  1)
    {
      Pen pen = new Pen(c, (float) widdy);
      objGraphics.DrawLine(pen, x1, y1, x2, y2);
    }

    pub static void drawLineDot(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int x2,
      int y2,
      Color c,
      let mut widdy: i32 =  1)
    {
      Pen pen = new Pen(c, (float) widdy);
      float[] numArray = new float[2]{ 1f, 2f };
      pen.DashStyle = DashStyle.Dot;
      pen.DashPattern = numArray;
      objGraphics.DrawLine(pen, x1, y1, x2, y2);
    }

    pub static void drawLineDash(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int x2,
      int y2,
      Color c,
      let mut widdy: i32 =  1)
    {
      objGraphics.DrawLine(new Pen(c, (float) widdy)
      {
        DashStyle = DashStyle.Dash
      }, x1, y1, x2, y2);
    }

    pub static void drawLine2(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int x2,
      int y2,
      int r,
      int g,
      int b,
      int a)
    {
      Pen pen = new Pen(Color.FromArgb(a, r, g, b), 6f);
      objGraphics.DrawLine(pen, x1, y1, x2, y2);
    }

    pub static void Clear(ref Graphics objgraphics, int r, int g, int b, let mut a: i32 =  255) => objgraphics.Clear(Color.FromArgb(a, r, g, b));

    pub static void ClearTransparent(ref Graphics objgraphics) => objgraphics.Clear(Color.FromArgb(0, 0, 0, 0));

    pub static void DrawTextVert(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y)
    {
      if (tfont == null)
        tfont = DrawMod.ttfont;
      SizeF sizeF1 = SizeF::new();
      SizeF sizeF2 = objgraphics.MeasureString(tstring, tfont);
      Bitmap bitmap = new Bitmap( Math.Round((double) sizeF2.Width),  Math.Round((double) sizeF2.Height) + 1, PixelFormat.Format32bppPArgb);
      bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      graphics.TextContrast = 4;
      graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
      graphics.DrawString(tstring, tfont, Brushes.White, 0.0f, 0.0f);
      bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
      objgraphics.DrawImageUnscaled((Image) bitmap, x + 2, y);
      bitmap.Dispose();
      graphics.Dispose();
    }

    pub static void DrawTextVertEasier(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y)
    {
      if (tfont == null)
        tfont = DrawMod.ttfont;
      objgraphics.TextContrast = 4;
      objgraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
      StringFormat format = StringFormat::new();
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb(165,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue));
      format.FormatFlags = StringFormatFlags.DirectionVertical;
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush, (float) x, (float) y, format);
    }

    pub static void DrawText(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y)
    {
      if (tfont == null)
        tfont = DrawMod.ttfont;
      objgraphics.TextContrast = 4;
      objgraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
      objgraphics.DrawString(tstring, tfont, Brushes.Black, (float) (x + 1), (float) (y + 1));
      objgraphics.DrawString(tstring, tfont, Brushes.Black, (float) (x + 1), (float) (y - 1));
      objgraphics.DrawString(tstring, tfont, Brushes.Black, (float) (x - 1), (float) (y + 1));
      objgraphics.DrawString(tstring, tfont, Brushes.Black, (float) (x - 1), (float) (y - 1));
      objgraphics.DrawString(tstring, tfont, Brushes.White, (float) x, (float) y);
    }

    pub static void DrawTextOutline(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y)
    {
      if (tfont == null)
        tfont = DrawMod.ttfont;
      objgraphics.TextContrast = 4;
      objgraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
      objgraphics.DrawString(tstring, tfont, Brushes.Black, (float) (x - 1), (float) y);
      objgraphics.DrawString(tstring, tfont, Brushes.Black, (float) x, (float) (y - 1));
      objgraphics.DrawString(tstring, tfont, Brushes.Black, (float) (x + 1), (float) y);
      objgraphics.DrawString(tstring, tfont, Brushes.Black, (float) x, (float) (y + 1));
      objgraphics.DrawString(tstring, tfont, Brushes.White, (float) x, (float) y);
    }

    pub static void DrawTextCenter(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y)
    {
      if (tfont == null)
        tfont = DrawMod.ttfont;
      SizeF sizeF1 = SizeF::new();
      StringFormat stringFormat = StringFormat::new();
      SizeF sizeF2 = objgraphics.MeasureString(tstring, tfont);
      objgraphics.TextContrast = 4;
      objgraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
      objgraphics.DrawString(tstring, tfont, Brushes.Black, (float) (x + 1) - sizeF2.Width / 2f, (float) (y + 1), StringFormat.GenericTypographic);
      objgraphics.DrawString(tstring, tfont, Brushes.White, (float) x - sizeF2.Width / 2f, (float) y, StringFormat.GenericTypographic);
    }

    pub static void DrawTextCenterSmallLabel(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      let mut tcol: i32 =  0)
    {
      if (tfont == null)
        tfont = DrawMod.ttfont;
      SizeF sizeF1 = SizeF::new();
      StringFormat stringFormat = StringFormat::new();
      bool flag = true;
      SizeF sizeF2 = objgraphics.MeasureString(tstring, tfont);
      SolidBrush solidBrush1 = new SolidBrush(Color.Black);
      if (flag)
      {
        objgraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
        objgraphics.SmoothingMode = SmoothingMode.Default;
        objgraphics.TextContrast = 1;
        if (DrawMod.TGame.Data.Product == 7)
        {
          objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
          objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
          objgraphics.TextContrast = 6;
        }
      }
      else
      {
        objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
        objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
        objgraphics.TextContrast = 12;
      }
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush1, (float) (x + 1) - sizeF2.Width / 2f, (float) ((double) y - (double) sizeF2.Height / 2.0 + 1.0));
      SolidBrush solidBrush2 = tcol != 1 ? (tcol != 2 ? (tcol != 3 ? (tcol != 4 ? (tcol != 5 ? (tcol != 11 ? (tcol != 12 ? (tcol != 13 ? (tcol != 13 ? new SolidBrush(Color.White) : new SolidBrush(Color.FromArgb( byte.MaxValue, 150, 150, 0))) : new SolidBrush(Color.FromArgb( byte.MaxValue, 100, 70, 100))) : new SolidBrush(Color.FromArgb( byte.MaxValue, 50, 0, 50))) : new SolidBrush(Color.FromArgb( byte.MaxValue, 150, 150, 150))) : new SolidBrush(Color.LightBlue)) : new SolidBrush(Color.Yellow)) : new SolidBrush(Color.Blue)) : new SolidBrush(Color.Green)) : new SolidBrush(Color.FromArgb( byte.MaxValue,  byte.MaxValue, 100, 100));
      if (flag)
      {
        objgraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
        objgraphics.SmoothingMode = SmoothingMode.Default;
        objgraphics.TextContrast = 1;
        if (DrawMod.TGame.Data.Product == 7)
        {
          objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
          objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
          objgraphics.TextContrast = 6;
        }
      }
      else
      {
        objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
        objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
        objgraphics.TextContrast = 1;
      }
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush2, (float) x - sizeF2.Width / 2f, (float) y - sizeF2.Height / 2f);
    }

    pub static void DrawTextCenterSmallLabelMultiLine(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      let mut tcol: i32 =  0)
    {
      string[] strArray = tstring.Split(' ');
      let mut num: i32 =  10;
      if (!Information.IsNothing((object) tfont))
        num =  Math.Round((double) tfont.Height * 0.75);
      let mut upperBound: i32 =  strArray.GetUpperBound(0);
      for (let mut index: i32 =  0; index <= upperBound; index += 1)
        DrawMod.DrawTextCenterSmallLabel(ref objgraphics, strArray[index], tfont, x, y -  Math.Round((double) (strArray.GetUpperBound(0) * num) / 2.0) + index * num, tcol);
    }

    pub static void DrawText2(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y)
    {
      if (tfont == null)
        tfont = DrawMod.ttfont;
      objgraphics.TextContrast = 4;
      objgraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
      objgraphics.DrawString(tstring, tfont, Brushes.Black, (float) x, (float) y);
    }

    pub static void DrawFrame2(ref Bitmap b, ref Graphics g, int x, int y, int w, int h)
    {
      if (!Information.IsNothing((object) b))
      {
        g.CompositingMode = CompositingMode.SourceCopy;
        let mut num1: i32 =  h - 1;
        for (let mut index1: i32 =  0; index1 <= num1; index1 += 1)
        {
          let mut num2: i32 =  w - 1;
          for (let mut index2: i32 =  0; index2 <= num2; index2 += 1)
          {
            let mut num3: i32 =  0;
            if (index2 < 9 & index1 < 9 && index2 + index1 < 7)
              num3 = 1;
            if (index2 < 9 & index1 > h - 8)
            {
              let mut num4: i32 =  h - index1;
              if (index2 + num4 < 7)
                num3 = 1;
            }
            if (index2 > w - 8 & index1 < 9 && w - index2 + index1 < 7)
              num3 = 1;
            if (index2 > w - 8 & index1 > h - 8 && w - index2 + (h - index1) < 7)
              num3 = 1;
            if (num3 == 1)
              b.SetPixel(index2 + x, index1 + y, Color.FromArgb(0, 0, 0, 0));
          }
        }
        g.CompositingMode = CompositingMode.SourceOver;
      }
      ref Graphics local1 = ref g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local2 = ref bitmap1;
      Rectangle rectangle1 = Rectangle::new(0, 0, 15, 15);
      let mut srcrect1: &Rectangle = &rectangle1
      Rectangle rectangle2 = Rectangle::new(x, y, 15, 15);
      let mut destrect1: &Rectangle = &rectangle2
      DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
      ref Graphics local3 = ref g;
      Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local4 = ref bitmap2;
      rectangle2 = Rectangle::new(15, 0, 10, 15);
      let mut srcrect2: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + 15, y, w - 30, 15);
      let mut destrect2: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
      ref Graphics local5 = ref g;
      Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local6 = ref bitmap3;
      rectangle2 = Rectangle::new(25, 0, 15, 15);
      let mut srcrect3: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + w - 15, y, 15, 15);
      let mut destrect3: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
      ref Graphics local7 = ref g;
      Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local8 = ref bitmap4;
      rectangle2 = Rectangle::new(0, 12, 15, 7);
      let mut srcrect4: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x, y + 15, 15, h - 30);
      let mut destrect4: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
      ref Graphics local9 = ref g;
      bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local10 = ref bitmap4;
      rectangle2 = Rectangle::new(15, 12, 10, 7);
      let mut srcrect5: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + 15, y + 15, w - 30, h - 30);
      let mut destrect5: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
      ref Graphics local11 = ref g;
      bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local12 = ref bitmap4;
      rectangle2 = Rectangle::new(25, 12, 15, 7);
      let mut srcrect6: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + w - 15, y + 15, 15, h - 30);
      let mut destrect6: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
      ref Graphics local13 = ref g;
      bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local14 = ref bitmap4;
      rectangle2 = Rectangle::new(0, 25, 15, 15);
      let mut srcrect7: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x, y + h - 15, 15, 15);
      let mut destrect7: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect7, destrect7);
      ref Graphics local15 = ref g;
      bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local16 = ref bitmap4;
      rectangle2 = Rectangle::new(15, 25, 10, 15);
      let mut srcrect8: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + 15, y + h - 15, w - 30, 15);
      let mut destrect8: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect8, destrect8);
      ref Graphics local17 = ref g;
      bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local18 = ref bitmap4;
      rectangle2 = Rectangle::new(25, 25, 15, 15);
      let mut srcrect9: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + w - 15, y + h - 15, 15, 15);
      let mut destrect9: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect9, destrect9);
    }

    pub static void DrawLeather(Graphics g, int x, int y, int w, int h)
    {
      w -= 11;
      h -= 11;
      let mut num1: i32 =  -192;
      while (num1 < w)
      {
        num1 += 192;
        let mut num2: i32 =  -192;
        while (num2 < h)
        {
          num2 += 192;
          Rectangle rectangle;
          rectangle.X = 0;
          rectangle.Y = 0;
          rectangle.Width = 192;
          rectangle.Height = 192;
          if (num1 + 192 > w)
            rectangle.Width = 192 - (num1 + 192 - w);
          if (num2 + 192 > h)
            rectangle.Height = 192 - (num2 + 192 - h);
          ref Graphics local1 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LEATHER);
          ref Bitmap local2 = ref bitmap;
          let mut srcrect: &Rectangle = &rectangle
          Rectangle destrect = Rectangle::new(x + num1, y + num2, rectangle.Width, rectangle.Height);
          DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
        }
      }
    }

    pub static void DrawMessFrame(
      ref Bitmap b,
      ref Graphics g,
      int x,
      int y,
      int w,
      int h,
      let mut watermark: i32 =  -1)
    {
      Rectangle rectangle1;
      if (!Information.IsNothing((object) b))
      {
        w -= 11;
        h -= 11;
        let mut num1: i32 =  -512;
        while (num1 < w)
        {
          num1 += 512;
          let mut num2: i32 =  -512;
          while (num2 < h)
          {
            num2 += 512;
            Rectangle rectangle2;
            rectangle2.X = 0;
            rectangle2.Y = 0;
            rectangle2.Width = 512;
            rectangle2.Height = 512;
            if (num1 + 512 > w)
              rectangle2.Width = 512 - (num1 + 512 - w);
            if (num2 + 512 > h)
              rectangle2.Height = 512 - (num2 + 512 - h);
            ref Graphics local1 = ref g;
            Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.BACKGROUND3MARC);
            ref Bitmap local2 = ref bitmap;
            let mut srcrect: &Rectangle = &rectangle2
            rectangle1 = Rectangle::new(x + num1, y + num2, rectangle2.Width, rectangle2.Height);
            let mut destrect: &Rectangle = &rectangle1
            DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
          }
        }
        if (watermark > -1)
        {
          ref Graphics local3 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(watermark);
          ref Bitmap local4 = ref bitmap;
          let mut w1: i32 =  w;
          let mut h1: i32 =  h;
          let mut width: i32 =  BitmapStore.GetWidth(watermark);
          let mut origh: i32 =  BitmapStore.Getheight(watermark);
          DrawMod.DrawScaledColorized(ref local3, ref local4, 0, 0, w1, h1, width, origh, -0.4f, -0.4f, -0.4f, 0.15f);
        }
        g.CompositingMode = CompositingMode.SourceCopy;
        let mut num3: i32 =  h - 1;
        for (let mut index1: i32 =  0; index1 <= num3; index1 += 1)
        {
          let mut num4: i32 =  w - 1;
          for (let mut index2: i32 =  0; index2 <= num4; index2 += 1)
          {
            let mut num5: i32 =  0;
            if (index2 < 9 & index1 < 9 && index2 + index1 < 7)
              num5 = 1;
            if (index2 < 9 & index1 > h - 8)
            {
              let mut num6: i32 =  h - index1;
              if (index2 + num6 < 7)
                num5 = 1;
            }
            if (index2 > w - 8 & index1 < 9 && w - index2 + index1 < 7)
              num5 = 1;
            if (index2 > w - 8 & index1 > h - 8 && w - index2 + (h - index1) < 7)
              num5 = 1;
            if (num5 == 1)
              b.SetPixel(index2 + x, index1 + y, Color.FromArgb(0, 0, 0, 0));
          }
        }
        g.CompositingMode = CompositingMode.SourceOver;
      }
      w += 11;
      h += 11;
      ref Graphics local5 = ref g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local6 = ref bitmap1;
      rectangle1 = Rectangle::new(0, 0, 25, 25);
      let mut srcrect1: &Rectangle = &rectangle1
      Rectangle rectangle3 = Rectangle::new(x, y, 25, 25);
      let mut destrect1: &Rectangle = &rectangle3
      DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect1, destrect1);
      ref Graphics local7 = ref g;
      Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local8 = ref bitmap2;
      rectangle3 = Rectangle::new(25, 0, 786, 25);
      let mut srcrect2: &Rectangle = &rectangle3
      rectangle1 = Rectangle::new(x + 25, y, w - 50, 25);
      let mut destrect2: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect2, destrect2);
      ref Graphics local9 = ref g;
      bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local10 = ref bitmap2;
      rectangle3 = Rectangle::new(811, 0, 25, 25);
      let mut srcrect3: &Rectangle = &rectangle3
      rectangle1 = Rectangle::new(x + w - 25, y, 25, 25);
      let mut destrect3: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect3, destrect3);
      ref Graphics local11 = ref g;
      bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local12 = ref bitmap2;
      rectangle3 = Rectangle::new(811, 25, 25, 350);
      let mut srcrect4: &Rectangle = &rectangle3
      rectangle1 = Rectangle::new(x + w - 25, y + 25, 25, h - 50);
      let mut destrect4: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect4, destrect4);
      ref Graphics local13 = ref g;
      bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local14 = ref bitmap2;
      rectangle3 = Rectangle::new(811, 375, 25, 25);
      let mut srcrect5: &Rectangle = &rectangle3
      rectangle1 = Rectangle::new(x + w - 25, y + h - 25, 25, 25);
      let mut destrect5: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect5, destrect5);
      ref Graphics local15 = ref g;
      bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local16 = ref bitmap2;
      rectangle3 = Rectangle::new(25, 375, 786, 25);
      let mut srcrect6: &Rectangle = &rectangle3
      rectangle1 = Rectangle::new(x + 25, y + h - 25, w - 50, 25);
      let mut destrect6: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect6, destrect6);
      ref Graphics local17 = ref g;
      bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local18 = ref bitmap2;
      rectangle3 = Rectangle::new(0, 375, 25, 25);
      let mut srcrect7: &Rectangle = &rectangle3
      rectangle1 = Rectangle::new(x, y + h - 25, 25, 25);
      let mut destrect7: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect7, destrect7);
      ref Graphics local19 = ref g;
      bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local20 = ref bitmap2;
      rectangle3 = Rectangle::new(0, 25, 25, 350);
      let mut srcrect8: &Rectangle = &rectangle3
      rectangle1 = Rectangle::new(x, y + 25, 25, h - 50);
      let mut destrect8: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local19, ref local20, srcrect8, destrect8);
    }

    pub static void DrawMessFrameSimplePopup(
      ref Bitmap b,
      ref Graphics g,
      int x,
      int y,
      int w,
      int h,
      string HeaderString,
      let mut watermark: i32 =  -1)
    {
      if (!Information.IsNothing((object) b))
      {
        Color c1 = Color.FromArgb( byte.MaxValue, 40, 80, 120);
        Color c2 = Color.FromArgb( byte.MaxValue, 100, 140, 180);
        DrawMod.DrawBlockGradient3(ref g, 0, 0, w, h, c1, c2);
        if (watermark > -1)
        {
          ref Graphics local1 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(watermark);
          ref Bitmap local2 = ref bitmap;
          let mut w1: i32 =  w;
          let mut h1: i32 =  h;
          let mut width: i32 =  BitmapStore.GetWidth(watermark);
          let mut origh: i32 =  BitmapStore.Getheight(watermark);
          DrawMod.DrawScaledColorized(ref local1, ref local2, 0, 0, w1, h1, width, origh, -0.4f, -0.4f, -0.4f, 0.15f);
        }
        g.SmoothingMode = SmoothingMode.AntiAlias;
        DrawMod.DrawBlock(ref g, 2, 27, w - 4, 38, 0, 0, 0, 128);
        SizeF sizeF = g.MeasureString(HeaderString, DrawMod.TGame.MarcFont1);
        DrawMod.DrawTextColouredMarc(ref g, HeaderString, DrawMod.TGame.MarcFont1,  Math.Round((double) w / 2.0 - (double) sizeF.Width / 2.0),  Math.Round(47.0 - (double) sizeF.Height / 2.0), Color.FromArgb( byte.MaxValue,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue));
        g.CompositingMode = CompositingMode.SourceCopy;
        let mut num1: i32 =  h - 1;
        for (let mut index1: i32 =  0; index1 <= num1; index1 += 1)
        {
          let mut num2: i32 =  w - 1;
          for (let mut index2: i32 =  0; index2 <= num2; index2 += 1)
          {
            let mut num3: i32 =  0;
            if (index2 < 9 & index1 < 9 && index2 + index1 < 7)
              num3 = 1;
            if (index2 < 9 & index1 > h - 8)
            {
              let mut num4: i32 =  h - index1;
              if (index2 + num4 < 7)
                num3 = 1;
            }
            if (index2 > w - 8 & index1 < 9 && w - index2 + index1 < 7)
              num3 = 1;
            if (index2 > w - 8 & index1 > h - 8 && w - index2 + (h - index1) < 7)
              num3 = 1;
            if (num3 == 1)
              b.SetPixel(index2 + x, index1 + y, Color.FromArgb(0, 0, 0, 0));
          }
        }
        g.CompositingMode = CompositingMode.SourceOver;
      }
      w += 11;
      h += 11;
      ref Graphics local3 = ref g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local4 = ref bitmap1;
      Rectangle rectangle1 = Rectangle::new(0, 0, 25, 25);
      let mut srcrect1: &Rectangle = &rectangle1
      Rectangle rectangle2 = Rectangle::new(x, y, 25, 25);
      let mut destrect1: &Rectangle = &rectangle2
      DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect1, destrect1);
      ref Graphics local5 = ref g;
      Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local6 = ref bitmap2;
      rectangle2 = Rectangle::new(25, 0, 786, 25);
      let mut srcrect2: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + 25, y, w - 50, 25);
      let mut destrect2: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect2, destrect2);
      ref Graphics local7 = ref g;
      Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local8 = ref bitmap3;
      rectangle2 = Rectangle::new(811, 0, 25, 25);
      let mut srcrect3: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + w - 25, y, 25, 25);
      let mut destrect3: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect3, destrect3);
      ref Graphics local9 = ref g;
      Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local10 = ref bitmap4;
      rectangle2 = Rectangle::new(811, 25, 25, 350);
      let mut srcrect4: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + w - 25, y + 25, 25, h - 50);
      let mut destrect4: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect4, destrect4);
      ref Graphics local11 = ref g;
      Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local12 = ref bitmap5;
      rectangle2 = Rectangle::new(811, 375, 25, 25);
      let mut srcrect5: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + w - 25, y + h - 25, 25, 25);
      let mut destrect5: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect5, destrect5);
      ref Graphics local13 = ref g;
      Bitmap bitmap6 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local14 = ref bitmap6;
      rectangle2 = Rectangle::new(25, 375, 786, 25);
      let mut srcrect6: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + 25, y + h - 25, w - 50, 25);
      let mut destrect6: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect6, destrect6);
      ref Graphics local15 = ref g;
      Bitmap bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local16 = ref bitmap7;
      rectangle2 = Rectangle::new(0, 375, 25, 25);
      let mut srcrect7: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x, y + h - 25, 25, 25);
      let mut destrect7: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect7, destrect7);
      ref Graphics local17 = ref g;
      Bitmap bitmap8 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local18 = ref bitmap8;
      rectangle2 = Rectangle::new(0, 25, 25, 350);
      let mut srcrect8: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x, y + 25, 25, h - 50);
      let mut destrect8: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect8, destrect8);
    }

    pub static void DrawFrame(
      ref Bitmap b,
      ref Bitmap backb,
      ref Graphics g,
      int x,
      int y,
      int w,
      int h,
      int sx,
      int sy)
    {
      if (!Information.IsNothing((object) b))
      {
        if (w > b.Width)
          w = b.Width;
        if (h > b.Height)
          h = b.Height;
        if (!Information.IsNothing((object) backb))
        {
          g.CompositingMode = CompositingMode.SourceCopy;
          let mut num1: i32 =  h - 1;
          for (let mut index1: i32 =  0; index1 <= num1; index1 += 1)
          {
            let mut num2: i32 =  w - 1;
            for (let mut index2: i32 =  0; index2 <= num2; index2 += 1)
            {
              if (x + index2 >= 0 & y + index1 >= 0 & x + index2 < w & y + index1 < h)
              {
                let mut num3: i32 =  0;
                if (index2 < 9 & index1 < 9 && index2 + index1 < 7)
                  num3 = 1;
                if (index2 < 9 & index1 > h - 8)
                {
                  let mut num4: i32 =  h - index1;
                  if (index2 + num4 < 7)
                    num3 = 1;
                }
                if (index2 > w - 8 & index1 < 9 && w - index2 + index1 < 7)
                  num3 = 1;
                if (index2 > w - 8 & index1 > h - 8 && w - index2 + (h - index1) < 7)
                  num3 = 1;
                if (num3 == 1)
                  b.SetPixel(index2 + x, index1 + y, backb.GetPixel(x + index2, y + index1));
              }
            }
          }
          g.CompositingMode = CompositingMode.SourceOver;
        }
      }
      ref Graphics local1 = ref g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local2 = ref bitmap1;
      Rectangle rectangle1 = Rectangle::new(0, 0, 15, 15);
      let mut srcrect1: &Rectangle = &rectangle1
      Rectangle rectangle2 = Rectangle::new(x, y, 15, 15);
      let mut destrect1: &Rectangle = &rectangle2
      DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
      ref Graphics local3 = ref g;
      Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local4 = ref bitmap2;
      rectangle2 = Rectangle::new(15, 0, 10, 15);
      let mut srcrect2: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + 15, y, w - 30, 15);
      let mut destrect2: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
      ref Graphics local5 = ref g;
      Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local6 = ref bitmap3;
      rectangle2 = Rectangle::new(25, 0, 15, 15);
      let mut srcrect3: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + w - 15, y, 15, 15);
      let mut destrect3: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
      ref Graphics local7 = ref g;
      Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local8 = ref bitmap4;
      rectangle2 = Rectangle::new(0, 12, 15, 7);
      let mut srcrect4: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x, y + 15, 15, h - 30);
      let mut destrect4: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
      ref Graphics local9 = ref g;
      Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local10 = ref bitmap5;
      rectangle2 = Rectangle::new(15, 12, 10, 7);
      let mut srcrect5: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + 15, y + 15, w - 30, h - 30);
      let mut destrect5: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
      ref Graphics local11 = ref g;
      Bitmap bitmap6 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local12 = ref bitmap6;
      rectangle2 = Rectangle::new(25, 12, 15, 7);
      let mut srcrect6: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + w - 15, y + 15, 15, h - 30);
      let mut destrect6: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
      ref Graphics local13 = ref g;
      Bitmap bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local14 = ref bitmap7;
      rectangle2 = Rectangle::new(0, 25, 15, 15);
      let mut srcrect7: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x, y + h - 15, 15, 15);
      let mut destrect7: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect7, destrect7);
      ref Graphics local15 = ref g;
      Bitmap bitmap8 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local16 = ref bitmap8;
      rectangle2 = Rectangle::new(15, 25, 10, 15);
      let mut srcrect8: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + 15, y + h - 15, w - 30, 15);
      let mut destrect8: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect8, destrect8);
      ref Graphics local17 = ref g;
      bitmap8 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local18 = ref bitmap8;
      rectangle2 = Rectangle::new(25, 25, 15, 15);
      let mut srcrect9: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + w - 15, y + h - 15, 15, 15);
      let mut destrect9: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect9, destrect9);
    }

    pub static void DrawSimpleFrame(
      ref int bitmapNr,
      ref Graphics g,
      int x,
      int y,
      int w,
      int h,
      int xOffset,
      int yOffset,
      int yOffsetBottom)
    {
      let mut width: i32 =  BitmapStore.GetWidth(bitmapNr);
      let mut num: i32 =  BitmapStore.Getheight(bitmapNr);
      ref Graphics local1 = ref g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(bitmapNr);
      ref Bitmap local2 = ref bitmap1;
      Rectangle rectangle1 = Rectangle::new(0, 0, xOffset, yOffset);
      let mut srcrect1: &Rectangle = &rectangle1
      Rectangle rectangle2 = Rectangle::new(x, y, xOffset, yOffset);
      let mut destrect1: &Rectangle = &rectangle2
      DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
      ref Graphics local3 = ref g;
      Bitmap bitmap2 = BitmapStore.GetBitmap(bitmapNr);
      ref Bitmap local4 = ref bitmap2;
      rectangle2 = Rectangle::new(xOffset, 0, xOffset + 10, yOffset);
      let mut srcrect2: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + xOffset, y, w - xOffset * 2, yOffset);
      let mut destrect2: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
      ref Graphics local5 = ref g;
      Bitmap bitmap3 = BitmapStore.GetBitmap(bitmapNr);
      ref Bitmap local6 = ref bitmap3;
      rectangle2 = Rectangle::new(width - xOffset, 0, xOffset, yOffset);
      let mut srcrect3: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + w - xOffset, y, xOffset, yOffset);
      let mut destrect3: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
      ref Graphics local7 = ref g;
      Bitmap bitmap4 = BitmapStore.GetBitmap(bitmapNr);
      ref Bitmap local8 = ref bitmap4;
      rectangle2 = Rectangle::new(0, yOffset, xOffset, 10);
      let mut srcrect4: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x, y + yOffset, xOffset, h - (yOffset + yOffsetBottom));
      let mut destrect4: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
      ref Graphics local9 = ref g;
      Bitmap bitmap5 = BitmapStore.GetBitmap(bitmapNr);
      ref Bitmap local10 = ref bitmap5;
      rectangle2 = Rectangle::new(width - xOffset, yOffset, xOffset, 10);
      let mut srcrect5: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + w - xOffset, y + yOffset, xOffset, h - (yOffset + yOffsetBottom));
      let mut destrect5: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
      ref Graphics local11 = ref g;
      Bitmap bitmap6 = BitmapStore.GetBitmap(bitmapNr);
      ref Bitmap local12 = ref bitmap6;
      rectangle2 = Rectangle::new(0, num - yOffsetBottom, xOffset, yOffsetBottom);
      let mut srcrect6: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x, y + h - yOffsetBottom, xOffset, yOffsetBottom);
      let mut destrect6: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
      ref Graphics local13 = ref g;
      Bitmap bitmap7 = BitmapStore.GetBitmap(bitmapNr);
      ref Bitmap local14 = ref bitmap7;
      rectangle2 = Rectangle::new(xOffset, num - yOffsetBottom, xOffset + 10, yOffsetBottom);
      let mut srcrect7: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + xOffset, y + h - yOffsetBottom, w - xOffset * 2, yOffsetBottom);
      let mut destrect7: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect7, destrect7);
      ref Graphics local15 = ref g;
      Bitmap bitmap8 = BitmapStore.GetBitmap(bitmapNr);
      ref Bitmap local16 = ref bitmap8;
      rectangle2 = Rectangle::new(width - xOffset, num - yOffsetBottom, xOffset, yOffsetBottom);
      let mut srcrect8: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + w - xOffset, y + h - yOffsetBottom, xOffset, yOffsetBottom);
      let mut destrect8: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect8, destrect8);
    }

    pub static void DrawTextColoured(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c)
    {
      SolidBrush solidBrush = new SolidBrush(c);
      objgraphics.TextContrast = 4;
      objgraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush, (float) x, (float) y);
    }

    pub static void DrawTextColouredNicely(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c,
      let mut tTextContrast: i32 =  1)
    {
      SolidBrush solidBrush = new SolidBrush(c);
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextContrast = tTextContrast;
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush, (float) x, (float) y);
    }

    pub static void DrawTextVic(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color frontc,
      Color shadec)
    {
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      SolidBrush solidBrush1 = new SolidBrush(shadec);
      objgraphics.TextContrast = 12;
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush1, (float) (x + 2), (float) (y + 2));
      SolidBrush solidBrush2 = new SolidBrush(frontc);
      objgraphics.TextContrast = 1;
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush2, (float) x, (float) y);
    }

    pub static void DrawTextVic2(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color frontc,
      Color shadec)
    {
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextContrast = 1;
      SolidBrush solidBrush = new SolidBrush(frontc);
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush, (float) x, (float) y);
    }

    pub static void DrawTextVic3(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color frontc,
      Color shadec)
    {
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
      SolidBrush solidBrush1 = new SolidBrush(shadec);
      objgraphics.TextContrast = 1;
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush1, (float) (x + 1), (float) (y + 1));
      objgraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
      SolidBrush solidBrush2 = new SolidBrush(frontc);
      objgraphics.TextContrast = 1;
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush2, (float) x, (float) y);
    }

    pub static void DrawTextColouredMarcCapped(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c,
      bool HardBlack = false,
      let mut maxWidth: i32 =  200)
    {
      if (Information.IsNothing((object) tstring))
        return;
      SizeF sizeF1 = SizeF::new();
      StringFormat stringFormat = StringFormat::new();
      for (SizeF sizeF2 = objgraphics.MeasureString(tstring, tfont); (double) sizeF2.Width > (double) maxWidth & tstring.Length > 3; sizeF2 = objgraphics.MeasureString(tstring, tfont))
      {
        let mut Length: i32 =   Math.Round((double) ((float) tstring.Length * ((float) maxWidth / sizeF2.Width))) - 1;
        if (Length < 1)
          Length = 1;
        tstring = Strings.Left(tstring, Length);
      }
      DrawMod.DrawTextColouredMarc(ref objgraphics, tstring, tfont, x, y, c, HardBlack);
    }

    pub static void DrawTextColouredMarc(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c,
      bool HardBlack = false)
    {
      if (Information.IsNothing((object) tfont))
        tfont = Font::new(DrawMod.TGame.FontCol.Families[1], 12f, FontStyle.Regular);
      if ((double) tfont.Size > 11.0)
      {
        SolidBrush solidBrush1 = new SolidBrush(Color.Black);
        if (HardBlack)
        {
          objgraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
          objgraphics.SmoothingMode = SmoothingMode.Default;
          objgraphics.TextContrast = 1;
        }
        else
        {
          objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
          objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
          objgraphics.TextContrast = 12;
        }
        objgraphics.DrawString(tstring, tfont, (Brush) solidBrush1, (float) x, (float) y);
        objgraphics.DrawString(tstring, tfont, (Brush) solidBrush1, (float) (x + 1), (float) (y + 1));
        objgraphics.DrawString(tstring, tfont, (Brush) solidBrush1, (float) (x + 2), (float) (y + 2));
        SolidBrush solidBrush2 = new SolidBrush(c);
        if (HardBlack)
        {
          objgraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
          objgraphics.SmoothingMode = SmoothingMode.Default;
          objgraphics.TextContrast = 1;
        }
        else
        {
          objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
          objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
          objgraphics.TextContrast = 1;
        }
        objgraphics.DrawString(tstring, tfont, (Brush) solidBrush2, (float) x, (float) y);
      }
      else
      {
        SolidBrush solidBrush3 = new SolidBrush(Color.Black);
        if (HardBlack)
        {
          objgraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
          objgraphics.SmoothingMode = SmoothingMode.Default;
          objgraphics.TextContrast = 1;
        }
        else
        {
          objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
          objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
          objgraphics.TextContrast = 12;
        }
        objgraphics.DrawString(tstring, tfont, (Brush) solidBrush3, (float) (x + 1), (float) (y + 1));
        SolidBrush solidBrush4 = new SolidBrush(c);
        if (HardBlack)
        {
          objgraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
          objgraphics.SmoothingMode = SmoothingMode.Default;
          objgraphics.TextContrast = 1;
        }
        else
        {
          objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
          objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
          objgraphics.TextContrast = 1;
        }
        objgraphics.DrawString(tstring, tfont, (Brush) solidBrush4, (float) x, (float) y);
      }
    }

    pub static void DrawTextColouredConsole(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c)
    {
      if (Information.IsNothing((object) tfont))
        tfont = Font::new(DrawMod.TGame.FontCol.Families[1], 12f, FontStyle.Regular);
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb( c.A,  c.R,  c.G,  c.B));
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextContrast = 1;
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush, (float) x, (float) y);
    }

    pub static void DrawTextColouredConsoleMultiline(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c,
      int w,
      int h,
      bool centerText = false)
    {
      if (Information.IsNothing((object) tfont))
        tfont = Font::new(DrawMod.TGame.FontCol.Families[1], 12f, FontStyle.Regular);
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb( c.A,  c.R,  c.G,  c.B));
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextContrast = 1;
      if (!centerText)
        objgraphics.DrawString(tstring, tfont, (Brush) solidBrush, (RectangleF) Rectangle::new(x, y, w, h));
      else
        objgraphics.DrawString(tstring, tfont, (Brush) solidBrush, (RectangleF) Rectangle::new(x, y, w, h), StringFormat::new()
        {
          Alignment = StringAlignment.Center
        });
    }

    pub static void DrawTextColouredConsoleCenter(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c)
    {
      if (Information.IsNothing((object) tfont))
        tfont = Font::new(DrawMod.TGame.FontCol.Families[1], 12f, FontStyle.Regular);
      SizeF sizeF1 = SizeF::new();
      StringFormat stringFormat = StringFormat::new();
      SizeF sizeF2 = objgraphics.MeasureString(tstring, tfont);
      x =  Math.Round((double) ((float) x - sizeF2.Width / 2f));
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb( c.A,  c.R,  c.G,  c.B));
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextContrast = 1;
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush, (float) x, (float) y);
    }

    pub static void DrawTextColouredConsoleCenterEmbossed(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c)
    {
      if (Information.IsNothing((object) tfont))
        tfont = Font::new(DrawMod.TGame.FontCol.Families[1], 12f, FontStyle.Regular);
      SizeF sizeF1 = SizeF::new();
      StringFormat stringFormat = StringFormat::new();
      SizeF sizeF2 = objgraphics.MeasureString(tstring, tfont);
      Bitmap objBitmap = new Bitmap( Math.Round((double) sizeF2.Width) + 8,  Math.Round((double) sizeF2.Height) + 8, PixelFormat.Format32bppPArgb);
      Graphics graphics = Graphics.FromImage((Image) objBitmap);
      graphics.Clear(Color.Transparent);
      x =  Math.Round((double) ((float) x - sizeF2.Width / 2f));
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb( c.A,  c.R,  c.G,  c.B));
      graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      graphics.TextContrast = 1;
      graphics.DrawString(tstring, tfont, (Brush) solidBrush, 4f, 4f);
      graphics.CompositingMode = CompositingMode.SourceCopy;
      let mut num1: i32 =   Math.Round((double) sizeF2.Width) + 8;
      let mut num2: i32 =   Math.Round((double) sizeF2.Height) + 8;
      let mut alpha: i32 =  200;
      Color color1 = DrawMod.LightenColor(c, 100);
      Color color2 = DrawMod.LightenColor(c, 60);
      Color color3 = DrawMod.LightenColor(c, -100);
      Color color4 = DrawMod.LightenColor(c, -40);
      color1 = Color.FromArgb(alpha,  color1.R,  color1.G,  color1.B);
      color2 = Color.FromArgb(alpha,  color2.R,  color2.G,  color2.B);
      color3 = Color.FromArgb(alpha,  color3.R,  color3.G,  color3.B);
      color4 = Color.FromArgb(alpha,  color4.R,  color4.G,  color4.B);
      Color color5 = DrawMod.LightenColor(c, 40);
      Color color6 = DrawMod.LightenColor(c, -60);
      Color pixel1;
      Color pixel2;
      for (let mut y1: i32 =  num2 - 2; y1 >= 1; y1 += -1)
      {
        for (let mut x1: i32 =  num1 - 2; x1 >= 1; x1 += -1)
        {
          pixel1 = objBitmap.GetPixel(x1, y1);
          if ( pixel1.A >= alpha)
          {
            bool flag = false;
            pixel2 = objBitmap.GetPixel(x1 + 1, y1);
            if ( pixel2.A < alpha)
            {
              objBitmap.SetPixel(x1 + 1, y1, color3);
              flag = true;
            }
            pixel2 = objBitmap.GetPixel(x1, y1 + 1);
            if ( pixel2.A < alpha)
            {
              objBitmap.SetPixel(x1, y1 + 1, color3);
              flag = true;
            }
            pixel2 = objBitmap.GetPixel(x1 + 1, y1 + 1);
            if ( pixel2.A < alpha)
            {
              objBitmap.SetPixel(x1 + 1, y1 + 1, color4);
              flag = true;
            }
            if (flag &  pixel1.G ==  c.G &  pixel1.R ==  c.R &  pixel1.B ==  c.B)
              objBitmap.SetPixel(x1, y1, color6);
          }
        }
      }
      let mut num3: i32 =  num2 - 2;
      for (let mut y2: i32 =  1; y2 <= num3; y2 += 1)
      {
        let mut num4: i32 =  num1 - 2;
        for (let mut x2: i32 =  1; x2 <= num4; x2 += 1)
        {
          pixel1 = objBitmap.GetPixel(x2, y2);
          if ( pixel1.A >= alpha)
          {
            bool flag = false;
            pixel2 = objBitmap.GetPixel(x2 - 1, y2);
            if ( pixel2.A < alpha)
              objBitmap.SetPixel(x2 - 1, y2, color1);
            pixel2 = objBitmap.GetPixel(x2, y2 - 1);
            if ( pixel2.A < alpha)
              objBitmap.SetPixel(x2, y2 - 1, color1);
            pixel2 = objBitmap.GetPixel(x2 - 1, y2 - 1);
            if ( pixel2.A < alpha)
              objBitmap.SetPixel(x2 - 1, y2 - 1, color2);
            if (flag &  pixel1.G ==  c.G &  pixel1.R ==  c.R &  pixel1.B ==  c.B)
              objBitmap.SetPixel(x2, y2, color5);
          }
        }
      }
      graphics.CompositingMode = CompositingMode.SourceOver;
      DrawMod.DrawSimple(ref objgraphics, ref objBitmap, x - 4, y - 4);
      graphics.Dispose();
      objBitmap.Dispose();
    }

    pub static void DrawTextColouredMarcCenter(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c,
      bool HardBlack = false)
    {
      if (Information.IsNothing((object) tfont))
        tfont = Font::new(DrawMod.TGame.FontCol.Families[1], 12f, FontStyle.Regular);
      SizeF sizeF1 = SizeF::new();
      StringFormat stringFormat = StringFormat::new();
      SizeF sizeF2 = objgraphics.MeasureString(tstring, tfont);
      x =  Math.Round((double) ((float) x - sizeF2.Width / 2f));
      SolidBrush solidBrush1 = new SolidBrush(Color.Black);
      if (HardBlack)
      {
        objgraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
        objgraphics.SmoothingMode = SmoothingMode.Default;
        objgraphics.TextContrast = 1;
      }
      else
      {
        objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
        objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
        objgraphics.TextContrast = 12;
      }
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush1, (float) (x + 1), (float) (y + 1));
      SolidBrush solidBrush2 = new SolidBrush(c);
      if (HardBlack)
      {
        objgraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
        objgraphics.SmoothingMode = SmoothingMode.Default;
        objgraphics.TextContrast = 1;
      }
      else
      {
        objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
        objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
        objgraphics.TextContrast = 1;
      }
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush2, (float) x, (float) y);
    }

    pub static void DrawTextColouredMarcCenterCinematic(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c)
    {
      if (Information.IsNothing((object) tfont))
        tfont = Font::new(DrawMod.TGame.FontCol.Families[1], 12f, FontStyle.Regular);
      SizeF sizeF1 = SizeF::new();
      StringFormat stringFormat = StringFormat::new();
      SizeF sizeF2 = objgraphics.MeasureString(tstring, tfont);
      x =  Math.Round((double) ((float) x - sizeF2.Width / 2f));
      SolidBrush solidBrush = new SolidBrush(c);
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush, (float) x, (float) y);
    }

    pub static void DrawTextColouredMarcCounter(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c,
      bool HardBlack = false)
    {
      if (Information.IsNothing((object) c))
        c = Color.White;
      if (c.R > (byte) 128 | c.B > (byte) 128 | c.G > (byte) 128)
      {
        SolidBrush solidBrush = new SolidBrush(Color.Black);
        objgraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
        objgraphics.SmoothingMode = SmoothingMode.None;
        objgraphics.TextContrast = 1;
        objgraphics.DrawString(tstring, tfont, (Brush) solidBrush, (float) (x + 1), (float) (y + 1));
      }
      SolidBrush solidBrush1 = new SolidBrush(c);
      objgraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
      objgraphics.SmoothingMode = SmoothingMode.None;
      objgraphics.TextContrast = 1;
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush1, (float) x, (float) y);
    }

    pub static void DrawTextColouredFuzzy(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c)
    {
      SolidBrush solidBrush = new SolidBrush(c);
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextContrast = 12;
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush, (float) x, (float) y);
    }

    pub static void DrawTextColouredOutline(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c,
      bool AntiA = false)
    {
      SolidBrush solidBrush1 = new SolidBrush(c);
      SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(168, 0, 0, 0));
      if (AntiA)
      {
        objgraphics.TextContrast = 1;
        objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      }
      else
      {
        objgraphics.TextContrast = 4;
        objgraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
      }
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush2, (float) (x + 1), (float) y);
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush2, (float) x, (float) (y + 1));
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush1, (float) x, (float) y);
    }

    pub static void DrawButton(
      ref Graphics g,
      int x,
      int y,
      int width,
      int height,
      bool HighLight,
      string ttext,
      let mut plusy: i32 =  0,
      Font customfont = null,
      bool allblack = false,
      bool inactive = false)
    {
      Color c1;
      Color c2;
      if (!HighLight)
      {
        ref Graphics local1 = ref g;
        Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
        ref Bitmap local2 = ref bitmap1;
        Rectangle rectangle1 = Rectangle::new(7, 0, 220, 35);
        let mut srcrect1: &Rectangle = &rectangle1
        Rectangle rectangle2 = Rectangle::new(x + 7, y + 0, width - 14, height);
        let mut destrect1: &Rectangle = &rectangle2
        DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
        ref Graphics local3 = ref g;
        Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
        ref Bitmap local4 = ref bitmap2;
        rectangle2 = Rectangle::new(0, 0, 7, 35);
        let mut srcrect2: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(x + 0, y + 0, 7, height);
        let mut destrect2: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
        ref Graphics local5 = ref g;
        Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
        ref Bitmap local6 = ref bitmap3;
        rectangle2 = Rectangle::new(228, 0, 7, 35);
        let mut srcrect3: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(x + width - 7, y + 0, 7, height);
        let mut destrect3: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
        c1 = Color.Black;
        c2 = Color.White;
      }
      else
      {
        ref Graphics local7 = ref g;
        Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
        ref Bitmap local8 = ref bitmap4;
        Rectangle rectangle3 = Rectangle::new(7, 0, 220, 35);
        let mut srcrect4: &Rectangle = &rectangle3
        Rectangle rectangle4 = Rectangle::new(x + 7, y + 0, width - 14, height);
        let mut destrect4: &Rectangle = &rectangle4
        DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
        ref Graphics local9 = ref g;
        Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
        ref Bitmap local10 = ref bitmap5;
        rectangle3 = Rectangle::new(0, 0, 7, 35);
        let mut srcrect5: &Rectangle = &rectangle3
        rectangle4 = Rectangle::new(x + 0, y + 0, 7, height);
        let mut destrect5: &Rectangle = &rectangle4
        DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
        ref Graphics local11 = ref g;
        Bitmap bitmap6 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
        ref Bitmap local12 = ref bitmap6;
        rectangle3 = Rectangle::new(228, 0, 7, 35);
        let mut srcrect6: &Rectangle = &rectangle3
        rectangle4 = Rectangle::new(x + width - 7, y + 0, 7, height);
        let mut destrect6: &Rectangle = &rectangle4
        DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
        c1 = Color.White;
        c2 = Color.Black;
      }
      if (allblack)
      {
        c1 = Color.FromArgb(128, 0, 0, 0);
        c2 = Color.Black;
      }
      if (inactive)
      {
        DrawMod.DrawBlock(ref g, x, y, width, height, 0, 0, 0, 128);
        c1 = Color.FromArgb(64, 0, 0, 0);
        c2 = Color.FromArgb( byte.MaxValue, 128, 128, 128);
      }
      SizeF sizeF1 = SizeF::new();
      Font font = DrawMod.TGame.VicFont2;
      str: String = ttext;
      if (!Information.IsNothing((object) customfont))
        font = customfont;
      int num1;
      let mut num2: i32 =  num1 - 2;
      --plusy;
      SizeF sizeF2 = g.MeasureString(str, font);
      let mut x1: i32 =   Math.Round((double) ((float) x + (float) (((double) width - (double) sizeF2.Width) / 2.0) + (float) num2));
      let mut y1: i32 =   Math.Round((double) ((float) ((double) y + ((double) height - (double) sizeF2.Height) / 2.0 - 1.0) + (float) plusy));
      if (width > 50)
        y1 -= 2;
      DrawMod.DrawTextColoured(ref g, str, font, x1, y1, c1);
      sizeF2 = g.MeasureString(str, font);
      let mut x2: i32 =   Math.Round((double) ((float) x + (float) (((double) width - (double) sizeF2.Width) / 2.0) + (float) num2));
      let mut y2: i32 =   Math.Round((double) ((float) ((double) y + ((double) height - (double) sizeF2.Height) / 2.0 + 1.0) + (float) plusy));
      if (width > 50)
        y2 -= 2;
      DrawMod.DrawTextColoured(ref g, str, font, x2, y2, c1);
      sizeF2 = g.MeasureString(str, font);
      let mut x3: i32 =   Math.Round((double) ((float) ((double) x + ((double) width - (double) sizeF2.Width) / 2.0 + 1.0) + (float) num2));
      let mut y3: i32 =   Math.Round((double) ((float) y + (float) (((double) height - (double) sizeF2.Height) / 2.0) + (float) plusy));
      if (width > 50)
        y3 -= 2;
      DrawMod.DrawTextColoured(ref g, str, font, x3, y3, c1);
      sizeF2 = g.MeasureString(str, font);
      let mut x4: i32 =   Math.Round((double) ((float) ((double) x + ((double) width - (double) sizeF2.Width) / 2.0 - 1.0) + (float) num2));
      let mut y4: i32 =   Math.Round((double) ((float) y + (float) (((double) height - (double) sizeF2.Height) / 2.0) + (float) plusy));
      if (width > 50)
        y4 -= 2;
      DrawMod.DrawTextColoured(ref g, str, font, x4, y4, c1);
      sizeF2 = g.MeasureString(str, font);
      let mut x5: i32 =   Math.Round((double) ((float) x + (float) (((double) width - (double) sizeF2.Width) / 2.0) + (float) num2));
      let mut y5: i32 =   Math.Round((double) ((float) y + (float) (((double) height - (double) sizeF2.Height) / 2.0) + (float) plusy));
      if (width > 50)
        y5 -= 2;
      DrawMod.DrawTextColoured(ref g, str, font, x5, y5, c2);
    }

    pub static void DrawFrame(ref Bitmap b, ref Graphics g, int x, int y, int w, int h)
    {
      if (!Information.IsNothing((object) b))
      {
        g.CompositingMode = CompositingMode.SourceCopy;
        let mut num1: i32 =  h - 1;
        for (let mut index1: i32 =  0; index1 <= num1; index1 += 1)
        {
          let mut num2: i32 =  w - 1;
          for (let mut index2: i32 =  0; index2 <= num2; index2 += 1)
          {
            let mut num3: i32 =  0;
            if (index2 < 9 & index1 < 9 && index2 + index1 < 9)
              num3 = 1;
            if (index2 < 9 & index1 > h - 8)
            {
              let mut num4: i32 =  h - index1;
              if (index2 + num4 < 9)
                num3 = 1;
            }
            if (index2 > w - 8 & index1 < 9 && w - index2 + index1 < 9)
              num3 = 1;
            if (index2 > w - 8 & index1 > h - 8 && w - index2 + (h - index1) < 9)
              num3 = 1;
            if (num3 == 1)
              b.SetPixel(index2 + x, index1 + y, Color.FromArgb(0, 0, 0, 0));
          }
        }
        g.CompositingMode = CompositingMode.SourceOver;
      }
      ref Graphics local1 = ref g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local2 = ref bitmap1;
      Rectangle rectangle1 = Rectangle::new(0, 0, 15, 15);
      let mut srcrect1: &Rectangle = &rectangle1
      Rectangle rectangle2 = Rectangle::new(x, y, 15, 15);
      let mut destrect1: &Rectangle = &rectangle2
      DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
      ref Graphics local3 = ref g;
      Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local4 = ref bitmap2;
      rectangle2 = Rectangle::new(15, 0, 310, 15);
      let mut srcrect2: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + 15, y, w - 30, 15);
      let mut destrect2: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
      ref Graphics local5 = ref g;
      Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local6 = ref bitmap3;
      rectangle2 = Rectangle::new(393, 0, 15, 15);
      let mut srcrect3: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + w - 15, y, 15, 15);
      let mut destrect3: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
      ref Graphics local7 = ref g;
      Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local8 = ref bitmap4;
      rectangle2 = Rectangle::new(0, 12, 15, 7);
      let mut srcrect4: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x, y + 15, 15, h - 30);
      let mut destrect4: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
      ref Graphics local9 = ref g;
      bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local10 = ref bitmap4;
      rectangle2 = Rectangle::new(15, 12, 310, 7);
      let mut srcrect5: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + 15, y + 15, w - 30, h - 30);
      let mut destrect5: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
      ref Graphics local11 = ref g;
      bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local12 = ref bitmap4;
      rectangle2 = Rectangle::new(393, 12, 15, 7);
      let mut srcrect6: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + w - 15, y + 15, 15, h - 30);
      let mut destrect6: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
      ref Graphics local13 = ref g;
      bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local14 = ref bitmap4;
      rectangle2 = Rectangle::new(0, 33, 15, 15);
      let mut srcrect7: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x, y + h - 15, 15, 15);
      let mut destrect7: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect7, destrect7);
      ref Graphics local15 = ref g;
      bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local16 = ref bitmap4;
      rectangle2 = Rectangle::new(15, 33, 310, 15);
      let mut srcrect8: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + 15, y + h - 15, w - 30, 15);
      let mut destrect8: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect8, destrect8);
      ref Graphics local17 = ref g;
      bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local18 = ref bitmap4;
      rectangle2 = Rectangle::new(393, 33, 15, 15);
      let mut srcrect9: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + w - 15, y + h - 15, 15, 15);
      let mut destrect9: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect9, destrect9);
    }

    pub static void DrawPaperSheet(ref Graphics g, int x, int y, int w, int h)
    {
      ref Graphics local1 = ref g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
      ref Bitmap local2 = ref bitmap1;
      Rectangle rectangle1 = Rectangle::new(0, 0, 15, 15);
      let mut srcrect1: &Rectangle = &rectangle1
      Rectangle rectangle2 = Rectangle::new(x, y, 15, 15);
      let mut destrect1: &Rectangle = &rectangle2
      DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
      ref Graphics local3 = ref g;
      Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
      ref Bitmap local4 = ref bitmap2;
      rectangle2 = Rectangle::new(15, 0, 310, 15);
      let mut srcrect2: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + 15, y, w - 30, 15);
      let mut destrect2: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
      ref Graphics local5 = ref g;
      Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
      ref Bitmap local6 = ref bitmap3;
      rectangle2 = Rectangle::new(325, 0, 15, 15);
      let mut srcrect3: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + w - 15, y, 15, 15);
      let mut destrect3: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
      int num;
      for (num = 15; num < h - 25; num += 15)
      {
        ref Graphics local7 = ref g;
        Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
        ref Bitmap local8 = ref bitmap4;
        rectangle2 = Rectangle::new(0, 0, 15, 15);
        let mut srcrect4: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(x, num + y, 15, 15);
        let mut destrect4: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
        ref Graphics local9 = ref g;
        Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
        ref Bitmap local10 = ref bitmap5;
        rectangle2 = Rectangle::new(15, 7, 310, 15);
        let mut srcrect5: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(x + 15, num + y, w - 30, 15);
        let mut destrect5: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
        ref Graphics local11 = ref g;
        Bitmap bitmap6 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
        ref Bitmap local12 = ref bitmap6;
        rectangle2 = Rectangle::new(325, 7, 15, 15);
        let mut srcrect6: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(x + w - 15, num + y, 15, 15);
        let mut destrect6: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
      }
      let mut height: i32 =  h - 6 - num;
      if (height > 0)
      {
        ref Graphics local13 = ref g;
        Bitmap bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
        ref Bitmap local14 = ref bitmap7;
        rectangle2 = Rectangle::new(0, 0, 15, 15);
        let mut srcrect7: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(x, num + y, 15, height);
        let mut destrect7: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect7, destrect7);
        ref Graphics local15 = ref g;
        Bitmap bitmap8 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
        ref Bitmap local16 = ref bitmap8;
        rectangle2 = Rectangle::new(15, 7, 310, 15);
        let mut srcrect8: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(x + 15, num + y, w - 30, height);
        let mut destrect8: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect8, destrect8);
        ref Graphics local17 = ref g;
        Bitmap bitmap9 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
        ref Bitmap local18 = ref bitmap9;
        rectangle2 = Rectangle::new(325, 7, 15, 15);
        let mut srcrect9: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(x + w - 15, num + y, 15, height);
        let mut destrect9: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect9, destrect9);
      }
      ref Graphics local19 = ref g;
      Bitmap bitmap10 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
      ref Bitmap local20 = ref bitmap10;
      rectangle2 = Rectangle::new(15, 34, 310, 6);
      let mut srcrect10: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + 15, y + h - 6, w - 30, 6);
      let mut destrect10: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local19, ref local20, srcrect10, destrect10);
      ref Graphics local21 = ref g;
      Bitmap bitmap11 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
      ref Bitmap local22 = ref bitmap11;
      rectangle2 = Rectangle::new(0, 34, 15, 6);
      let mut srcrect11: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x, y + h - 6, 15, 6);
      let mut destrect11: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local21, ref local22, srcrect11, destrect11);
      ref Graphics local23 = ref g;
      Bitmap bitmap12 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
      ref Bitmap local24 = ref bitmap12;
      rectangle2 = Rectangle::new(325, 34, 15, 6);
      let mut srcrect12: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x + w - 15, y + h - 6, 15, 6);
      let mut destrect12: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2(ref local23, ref local24, srcrect12, destrect12);
    }

    pub static void DrawTextColouredB(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c,
      Color bc)
    {
      SolidBrush solidBrush = new SolidBrush(c);
      SizeF sizeF = objgraphics.MeasureString(tstring, tfont);
      DrawMod.DrawBlock(ref objgraphics, x, y,  Math.Round((double) sizeF.Width),  Math.Round((double) sizeF.Height),  bc.R,  bc.G,  bc.B,  bc.A);
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush, (float) x, (float) y);
    }

    pub static int InvColor(int colval)
    {
      if (colval >  sbyte.MaxValue)
        colval -= 64;
      else
        colval += 64;
      return colval;
    }

    pub static int InvColor2(int colval)
    {
      if (colval >  sbyte.MaxValue)
        colval -= 128;
      else
        colval += 128;
      return colval;
    }

    pub static Color LightenColor(Color col, int ammount)
    {
      let mut r: i32 =   col.R;
      let mut g: i32 =   col.G;
      let mut b: i32 =   col.B;
      let mut red: i32 =  r + ammount;
      let mut green: i32 =  g + ammount;
      let mut blue: i32 =  b + ammount;
      if (red >  byte.MaxValue)
        red =  byte.MaxValue;
      if (green >  byte.MaxValue)
        green =  byte.MaxValue;
      if (blue >  byte.MaxValue)
        blue =  byte.MaxValue;
      if (red < 0)
        red = 0;
      if (green < 0)
        green = 0;
      if (blue < 0)
        blue = 0;
      col = Color.FromArgb( col.A, red, green, blue);
      return col;
    }

    pub static Rectangle GetRectForTab(int tabnr, bool returnoffset = false)
    {
      Rectangle rectForTab = Rectangle::new();
      int x;
      int width;
      int height;
      if (tabnr == 8)
      {
        x =  Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 - 158.0) - 300;
        width = 800;
        height = 300;
      }
      if (tabnr == 101)
      {
        x = 0;
        width = 1240;
        height = DrawMod.TGame.ScreenHeight - 135;
      }
      if (tabnr == 11)
      {
        x =  Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 + 158.0) + 75;
        width = 1240;
        height = DrawMod.TGame.ScreenHeight - 388;
        if (DrawMod.TGame.EditObj.GuiDown)
          height += 222;
        if (DrawMod.TGame.EditObj.RightDown)
          width += 185;
      }
      if (tabnr == 12)
      {
        x =  Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 + 158.0) + 150;
        width = 1240;
        height = DrawMod.TGame.ScreenHeight - 388;
        if (DrawMod.TGame.EditObj.GuiDown)
          height += 222;
        if (DrawMod.TGame.EditObj.RightDown)
          width += 185;
      }
      if (tabnr == 13)
      {
        x =  Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 - 158.0) - 300;
        width = 1240;
        height = DrawMod.TGame.ScreenHeight - 388;
        if (DrawMod.TGame.EditObj.GuiDown)
          height += 222;
        if (DrawMod.TGame.EditObj.RightDown)
          width += 185;
      }
      if (tabnr == 9)
      {
        x =  Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 + 158.0) + 225;
        width = 800;
        height = 380;
      }
      if (tabnr == 7 | tabnr == 107)
      {
        width = DrawMod.GetWidthForMiniMap() + 32;
        x = DrawMod.TGame.Data.Product < 7 ? DrawMod.TGame.ScreenWidth - width : DrawMod.TGame.ScreenWidth - (width + 160);
        height = 248;
      }
      if (tabnr == 1)
      {
        x =  Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 - 158.0) - 225;
        width = 680;
        height = 380;
      }
      if (tabnr == 2)
      {
        x =  Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 - 158.0) - 150;
        width = DrawMod.TGame.ScreenWidth - 144;
        if (width > 1600)
          width = 1600;
        height = DrawMod.TGame.ScreenHeight - 388;
      }
      if (tabnr == 3)
      {
        x =  Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 - 158.0) - 75;
        width = DrawMod.TGame.ScreenWidth - 144;
        if (width > 880)
          width = 880;
        height = 380;
        if (DrawMod.TGame.Data.Product >= 6)
        {
          width = DrawMod.TGame.ScreenWidth - 370;
          if (width > 1600)
            width = 1600;
          if (width + 370 > DrawMod.TGame.ScreenWidth)
            x -= DrawMod.TGame.ScreenWidth - (width + 370);
        }
      }
      if (tabnr == 4)
      {
        x =  Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 + 158.0) + 0;
        width = DrawMod.TGame.ScreenWidth - 144;
        if (width > 880)
          width = 880;
        height = DrawMod.TGame.ScreenHeight - 388;
      }
      if (tabnr == 5)
      {
        x = DrawMod.TGame.Data.Product < 7 ?  Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 + 158.0) + 75 :  Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 + 158.0) + 0;
        width = 680;
        height = 380;
        if (DrawMod.TGame.Data.Product >= 6)
        {
          width = DrawMod.TGame.ScreenWidth - 370;
          if (width > 1600)
            width = 1600;
          if (width + 370 > DrawMod.TGame.ScreenWidth)
            x -= DrawMod.TGame.ScreenWidth - (width + 370);
          height = DrawMod.TGame.ScreenHeight - 388;
          if (DrawMod.TGame.EditObj.GuiDown)
            height += 222;
        }
      }
      if (tabnr == 6)
      {
        x = DrawMod.TGame.Data.Product < 6 ?  Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 + 158.0) + 150 :  Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 - 158.0) - 75;
        width = DrawMod.TGame.ScreenWidth - 144;
        height = DrawMod.TGame.ScreenHeight - 388;
        if (DrawMod.TGame.Data.Product < 6)
        {
          if (DrawMod.TGame.Data.MapObj[0].MapHeight <= 30 & height > 380)
            height = 380;
          if (DrawMod.TGame.Data.MapObj[0].MapHeight <= 50 & height > 520)
            height = 520;
          if (DrawMod.TGame.Data.MapObj[0].MapHeight <= 70 & height > 640)
            height = 640;
          if (width > 680 & (double) width / (double) height > 1.8)
            width =  Math.Round((double) height * 1.8);
        }
        else if (DrawMod.TGame.Data.Product >= 6)
        {
          float num1 = (float) ((double) DrawMod.TGame.Data.MapObj[0].MapHeight / (double) DrawMod.TGame.Data.MapObj[0].MapWidth * (53.0 / 64.0));
          float num2 = (float) (height - 40) / (float) (width - 310);
          if ((double) num1 < 1.0 & (double) num1 < (double) num2)
          {
            let mut num3: i32 =   Math.Round((double) ((float) (height - 40) * (num2 - num1)));
            height -= num3;
          }
        }
      }
      if (tabnr == 7 | tabnr == 107)
      {
        width = DrawMod.GetWidthForMiniMap() + 32;
        x = DrawMod.TGame.ScreenWidth - width;
        height = 248;
      }
      if (DrawMod.TGame.Data.Product >= 7)
      {
        if (tabnr != 107 & tabnr != 7)
          x =  Math.Round((double) x - (double) width / 2.0);
      }
      else if (tabnr != 107 & tabnr != 7 & tabnr != 8)
        x =  Math.Round((double) x - (double) width / 2.0);
      let mut num4: i32 =  x;
      let mut num5: i32 =  50;
      let mut num6: i32 =  50;
      let mut num7: i32 =  0;
      if (DrawMod.TGame.Data.Product >= 7)
      {
        num5 = 185;
        num6 = 185;
        num7 = 185;
        if (tabnr > 100 & DrawMod.TGame.ScreenWidth < 1465)
        {
          num5 = 0;
          if (width > DrawMod.TGame.ScreenWidth - 185)
            width = DrawMod.TGame.ScreenWidth - 185;
        }
        else if (DrawMod.TGame.EditObj.RightDown)
        {
          num6 = 0;
          if (width > DrawMod.TGame.ScreenWidth - 185)
            width = DrawMod.TGame.ScreenWidth - 185;
        }
        else
        {
          if (width > DrawMod.TGame.ScreenWidth - 370)
            width = DrawMod.TGame.ScreenWidth - 370;
          if (x + width < DrawMod.TGame.ScreenWidth - 190)
            x += DrawMod.TGame.ScreenWidth - 190 - (x + width);
        }
      }
      if (DrawMod.TGame.Data.Product >= 7)
      {
        if (!(tabnr == 107 | tabnr == 7))
        {
          if (num5 > x)
            x = num5;
          if (x + width + num6 > DrawMod.TGame.ScreenWidth)
            x = DrawMod.TGame.ScreenWidth - (num6 + width);
        }
        else
        {
          if (x + width + num7 > DrawMod.TGame.ScreenWidth)
            x = DrawMod.TGame.ScreenWidth - (num7 + width);
          if (returnoffset)
            x += width - 190;
        }
      }
      else if (tabnr != 8 & !(tabnr == 107 | tabnr == 7))
      {
        if (num5 > x)
          x = num5;
        if (x + width + num6 > DrawMod.TGame.ScreenWidth)
          x = DrawMod.TGame.ScreenWidth - (num6 + width);
      }
      else
      {
        if (x + width + num7 > DrawMod.TGame.ScreenWidth)
          x = DrawMod.TGame.ScreenWidth - (num7 + width);
        if (returnoffset)
          x += width - 190;
      }
      if (returnoffset)
      {
        if (DrawMod.TGame.Data.Product >= 7)
        {
          rectForTab = Rectangle::new(num4 - x, 0, 0, 0);
        }
        else
        {
          rectForTab = Rectangle::new(num4 - x, 0, 0, 0);
          if (tabnr == 8)
            rectForTab.X += 300;
        }
        return rectForTab;
      }
      rectForTab = Rectangle::new(x, 75, width, height);
      return rectForTab;
    }

    pub static Rectangle DrawBackTab(Graphics g, int w, int h, string s, int tabnr)
    {
      Rectangle rectForTab;
      if (tabnr > -1)
      {
        rectForTab = DrawMod.GetRectForTab(tabnr, true);
      }
      else
      {
        rectForTab.X = 0;
        rectForTab.Y = 0;
        rectForTab.Width = w;
        rectForTab.Height = h;
      }
      int y;
      int height;
      Bitmap bitmap;
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (tabnr > -1)
      {
        y = 0;
        height = 100;
      }
      else
      {
        y = 32;
        height = 32;
        ref Graphics local1 = ref g;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
        ref Bitmap local2 = ref bitmap;
        rectangle1 = Rectangle::new(0, 0, 16, 32);
        let mut srcrect1: &Rectangle = &rectangle1
        rectangle2 = Rectangle::new(0, 0, 16, 32);
        let mut destrect1: &Rectangle = &rectangle2
        DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
        ref Graphics local3 = ref g;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
        ref Bitmap local4 = ref bitmap;
        rectangle2 = Rectangle::new(170, 0, 16, 32);
        let mut srcrect2: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(w - 16, 0, 16, 32);
        let mut destrect2: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
        let mut width: i32 =  32;
        for (let mut x: i32 =  16; x < w - 16; x += 32)
        {
          if (x + width > w - 16)
            width = w - 16 - x;
          ref Graphics local5 = ref g;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
          ref Bitmap local6 = ref bitmap;
          rectangle2 = Rectangle::new(16, 0, 32, 32);
          let mut srcrect3: &Rectangle = &rectangle2
          rectangle1 = Rectangle::new(x, 0, width, 32);
          let mut destrect3: &Rectangle = &rectangle1
          DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
        }
      }
      for (; y < h - 32; y += height)
      {
        if (y + height > h - 32)
          height = h - 32 - y;
        ref Graphics local7 = ref g;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
        ref Bitmap local8 = ref bitmap;
        rectangle2 = Rectangle::new(0, 20, 8, height);
        let mut srcrect4: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, y, 8, height);
        let mut destrect4: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
        ref Graphics local9 = ref g;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
        ref Bitmap local10 = ref bitmap;
        rectangle2 = Rectangle::new(170, 20, 16, height);
        let mut srcrect5: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(w - 16, y, 16, height);
        let mut destrect5: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
        let mut width: i32 =  160;
        for (let mut x: i32 =  8; x < w; x += 160)
        {
          if (x + width > w - 16)
            width = w - 16 - x;
          ref Graphics local11 = ref g;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
          ref Bitmap local12 = ref bitmap;
          rectangle2 = Rectangle::new(10, 20, width, height);
          let mut srcrect6: &Rectangle = &rectangle2
          rectangle1 = Rectangle::new(x, y, width, height);
          let mut destrect6: &Rectangle = &rectangle1
          DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
        }
      }
      if (tabnr > -1)
      {
        rectForTab.X +=  Math.Round((double) w / 2.0);
        if (rectForTab.X < 16)
          rectForTab.X = 16;
        rectForTab.Y = h - 32;
        rectForTab.Width = 75;
        rectForTab.Height = 32;
        ref Graphics local13 = ref g;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
        ref Bitmap local14 = ref bitmap;
        rectangle2 = Rectangle::new(55, 122, 75, 32);
        let mut srcrect7: &Rectangle = &rectangle2
        let mut destrect7: &Rectangle = &rectForTab
        DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect7, destrect7);
        ref Graphics local15 = ref g;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
        ref Bitmap local16 = ref bitmap;
        rectangle2 = Rectangle::new(0, 122, 16, 32);
        let mut srcrect8: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, h - 32, 16, 32);
        let mut destrect8: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect8, destrect8);
        ref Graphics local17 = ref g;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
        ref Bitmap local18 = ref bitmap;
        rectangle2 = Rectangle::new(171, 122, 16, 32);
        let mut srcrect9: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(w - 16, h - 32, 16, 32);
        let mut destrect9: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect9, destrect9);
        let mut width1: i32 =  32;
        for (let mut x: i32 =  16; x < rectForTab.X; x += 32)
        {
          if (x + width1 > rectForTab.X)
            width1 = rectForTab.X - x;
          ref Graphics local19 = ref g;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
          ref Bitmap local20 = ref bitmap;
          rectangle2 = Rectangle::new(16, 122, 32, 32);
          let mut srcrect10: &Rectangle = &rectangle2
          rectangle1 = Rectangle::new(x, h - 32, width1, 32);
          let mut destrect10: &Rectangle = &rectangle1
          DrawMod.DrawSimplePart2(ref local19, ref local20, srcrect10, destrect10);
        }
        let mut width2: i32 =  32;
        for (let mut x: i32 =  rectForTab.X + rectForTab.Width; x < w - 16; x += 32)
        {
          if (x + width2 > w - 16)
            width2 = w - 16 - x;
          ref Graphics local21 = ref g;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
          ref Bitmap local22 = ref bitmap;
          rectangle2 = Rectangle::new(16, 122, 32, 32);
          let mut srcrect11: &Rectangle = &rectangle2
          rectangle1 = Rectangle::new(x, h - 32, width2, 32);
          let mut destrect11: &Rectangle = &rectangle1
          DrawMod.DrawSimplePart2(ref local21, ref local22, srcrect11, destrect11);
        }
        SizeF sizeF = g.MeasureString(s, DrawMod.TGame.MarcFont4);
        let mut num: i32 =  3;
        if (DrawMod.TGame.Data.Product == 7)
          num += 7;
        DrawMod.DrawTextColouredMarc(ref g, s, DrawMod.TGame.MarcFont4, rectForTab.X + 15 +  Math.Round(((double) (rectForTab.Width - 30) - (double) sizeF.Width) / 2.0), rectForTab.Y + num, Color.White);
      }
      else
      {
        ref Graphics local23 = ref g;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
        ref Bitmap local24 = ref bitmap;
        rectangle2 = Rectangle::new(0, 122, 16, 32);
        let mut srcrect12: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, h - 32, 16, 32);
        let mut destrect12: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2(ref local23, ref local24, srcrect12, destrect12);
        ref Graphics local25 = ref g;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
        ref Bitmap local26 = ref bitmap;
        rectangle2 = Rectangle::new(171, 122, 16, 32);
        let mut srcrect13: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(w - 16, h - 32, 16, 32);
        let mut destrect13: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2(ref local25, ref local26, srcrect13, destrect13);
        let mut width3: i32 =  32;
        for (let mut x: i32 =  16; (double) x < (double) w / 2.0; x += 32)
        {
          if ((double) (x + width3) > (double) w / 2.0)
            width3 =  Math.Round((double) w / 2.0 - (double) x);
          ref Graphics local27 = ref g;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
          ref Bitmap local28 = ref bitmap;
          rectangle2 = Rectangle::new(16, 122, 32, 32);
          let mut srcrect14: &Rectangle = &rectangle2
          rectangle1 = Rectangle::new(x, h - 32, width3, 32);
          let mut destrect14: &Rectangle = &rectangle1
          DrawMod.DrawSimplePart2(ref local27, ref local28, srcrect14, destrect14);
        }
        let mut width4: i32 =  32;
        for (let mut x: i32 =   Math.Round((double) w / 2.0); x < w - 16; x += 32)
        {
          if (x + width4 > w - 16)
            width4 = w - 16 - x;
          ref Graphics local29 = ref g;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
          ref Bitmap local30 = ref bitmap;
          rectangle2 = Rectangle::new(16, 122, 32, 32);
          let mut srcrect15: &Rectangle = &rectangle2
          rectangle1 = Rectangle::new(x, h - 32, width4, 32);
          let mut destrect15: &Rectangle = &rectangle1
          DrawMod.DrawSimplePart2(ref local29, ref local30, srcrect15, destrect15);
        }
      }
      return rectForTab;
    }

    pub static int GetWidthForMiniMap()
    {
      let mut widthForMiniMap: i32 =  DrawMod.TGame.Data.MapObj[DrawMod.TGame.EditObj.MapSelected].MapWidth <= DrawMod.TGame.Data.MapObj[DrawMod.TGame.EditObj.MapSelected].MapHeight ? 200 :  Math.Round(200.0 * ((double) DrawMod.TGame.Data.MapObj[DrawMod.TGame.EditObj.MapSelected].MapWidth / (double) DrawMod.TGame.Data.MapObj[DrawMod.TGame.EditObj.MapSelected].MapHeight));
      if (widthForMiniMap > 300)
        widthForMiniMap = 300;
      return widthForMiniMap;
    }

    pub static void DrawOfficerATG(Graphics g, int his, int x, int y, int w, int h)
    {
      let mut commanderSpriteId: i32 =  DrawMod.TGame.Data.HistoricalUnitObj[his].CommanderSpriteID;
      if (commanderSpriteId <= -1)
        return;
      let mut hqSpriteNr: i32 =  DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.HistoricalUnitObj[his].TempRegime].HQSpriteNr;
      ref Graphics local1 = ref g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(hqSpriteNr, 1);
      ref Bitmap local2 = ref bitmap1;
      Rectangle srcrect = Rectangle::new(24, 8, 25, 30);
      Rectangle destrect = Rectangle::new(x, y, w, h);
      DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
      let mut red: i32 =  DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.HistoricalUnitObj[his].TempRegime].Red;
      let mut green: i32 =  DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.HistoricalUnitObj[his].TempRegime].Green;
      let mut blue: i32 =  DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.HistoricalUnitObj[his].TempRegime].Blue;
      DrawMod.DrawBlockGradient2(ref g, x, y, w, h, Color.FromArgb(64,  Math.Round((double) red / 2.0),  Math.Round((double) green / 2.0),  Math.Round((double) blue / 2.0)), Color.FromArgb(176,  Math.Round((double) red / 2.0),  Math.Round((double) green / 2.0),  Math.Round((double) blue / 2.0)));
      DrawMod.DrawBlockGradient3(ref g, x, y, w, h, Color.FromArgb(64, 0, 0, 0), Color.FromArgb(176, 0, 0, 0));
      ref Graphics local3 = ref g;
      Bitmap bitmap2 = BitmapStore.GetBitmap(commanderSpriteId);
      ref Bitmap local4 = ref bitmap2;
      let mut x1: i32 =  x;
      let mut y1: i32 =  y;
      let mut w1: i32 =  w;
      let mut h1: i32 =  h;
      let mut width: i32 =  BitmapStore.GetWidth(commanderSpriteId);
      let mut origh: i32 =  BitmapStore.Getheight(commanderSpriteId);
      double r = (double)  Math.Round((double) (red + 80) / 512.0);
      double g1 = (double)  Math.Round((double) (green + 200) / 512.0);
      double b = (double)  Math.Round((double) (blue + 80) / 512.0);
      DrawMod.DrawScaledColorized2(ref local3, ref local4, x1, y1, w1, h1, width, origh, (float) r, (float) g1, (float) b, 1f);
      if (DrawMod.TGame.Data.HistoricalUnitObj[his].OverdrawSpriteID > -1)
      {
        let mut overdrawSpriteId: i32 =  DrawMod.TGame.Data.HistoricalUnitObj[his].OverdrawSpriteID;
        ref Graphics local5 = ref g;
        Bitmap bitmap3 = BitmapStore.GetBitmap(overdrawSpriteId);
        ref Bitmap local6 = ref bitmap3;
        let mut x2: i32 =  x;
        let mut y2: i32 =  y;
        let mut w2: i32 =  w;
        let mut h2: i32 =  h;
        DrawMod.DrawScaled(ref local5, ref local6, x2, y2, w2, h2, true);
      }
      DrawMod.DrawRectangle(ref g, x, y, w, h,  DrawMod.TGame.VicColor3.R,  DrawMod.TGame.VicColor3.G,  DrawMod.TGame.VicColor3.B,  DrawMod.TGame.VicColor3.A);
    }

    pub static void DrawOfficer(Graphics g, int his, int x, int y, int w, int h)
    {
      let mut commanderSpriteId: i32 =  DrawMod.TGame.Data.HistoricalUnitObj[his].CommanderSpriteID;
      if (commanderSpriteId <= -1)
        return;
      if (BitmapStore.GetWidth(commanderSpriteId) > w & w != -1)
      {
        ref Graphics local1 = ref g;
        Bitmap bitmap1 = BitmapStore.GetBitmap(commanderSpriteId);
        ref Bitmap local2 = ref bitmap1;
        let mut x1: i32 =  x;
        let mut y1: i32 =  y;
        let mut w1: i32 =  w;
        let mut h1: i32 =  h;
        DrawMod.DrawScaled(ref local1, ref local2, x1, y1, w1, h1);
        if (DrawMod.TGame.Data.HistoricalUnitObj[his].OverdrawSpriteID <= -1)
          return;
        let mut overdrawSpriteId: i32 =  DrawMod.TGame.Data.HistoricalUnitObj[his].OverdrawSpriteID;
        if ((double) DrawMod.TGame.Data.RuleVar[839] == 1.0)
        {
          ref Graphics local3 = ref g;
          Bitmap bitmap2 = BitmapStore.GetBitmap(overdrawSpriteId);
          ref Bitmap local4 = ref bitmap2;
          Rectangle srcrect = Rectangle::new(0, 0, BitmapStore.GetWidth(overdrawSpriteId), BitmapStore.Getheight(overdrawSpriteId));
          Rectangle destrect = Rectangle::new(x, y, w, h);
          DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect, destrect);
        }
        else
        {
          ref Graphics local5 = ref g;
          Bitmap bitmap3 = BitmapStore.GetBitmap(overdrawSpriteId);
          ref Bitmap local6 = ref bitmap3;
          let mut x2: i32 =  x;
          let mut y2: i32 =  y;
          let mut w2: i32 =  w;
          let mut h2: i32 =  h;
          DrawMod.DrawScaled(ref local5, ref local6, x2, y2, w2, h2);
        }
      }
      else
      {
        ref Graphics local7 = ref g;
        Bitmap bitmap4 = BitmapStore.GetBitmap(commanderSpriteId);
        ref Bitmap local8 = ref bitmap4;
        let mut x3: i32 =  x;
        let mut y3: i32 =  y;
        DrawMod.DrawSimple(ref local7, ref local8, x3, y3);
        if (DrawMod.TGame.Data.HistoricalUnitObj[his].OverdrawSpriteID <= -1)
          return;
        let mut overdrawSpriteId: i32 =  DrawMod.TGame.Data.HistoricalUnitObj[his].OverdrawSpriteID;
        ref Graphics local9 = ref g;
        Bitmap bitmap5 = BitmapStore.GetBitmap(overdrawSpriteId);
        ref Bitmap local10 = ref bitmap5;
        let mut x4: i32 =  x;
        let mut y4: i32 =  y;
        DrawMod.DrawSimple(ref local9, ref local10, x4, y4);
      }
    }

    pub static void DrawTutback(
      Graphics g,
      int x,
      int y,
      int w,
      int h,
      int r,
      int gr,
      int b,
      int a,
      bool HideOff = false)
    {
      let mut backtut: i32 =  DrawMod.TGame.BACKTUT;
      y -= 3;
      h += 3;
      if (!HideOff)
        w += 100;
      if (w > DrawMod.TGame.ScreenWidth - 10)
        w = DrawMod.TGame.ScreenWidth - 10;
      if (!HideOff & h < 130)
        h = 130;
      let mut width1: i32 =  BitmapStore.GetWidth(backtut);
      let mut num1: i32 =  BitmapStore.Getheight(backtut);
      r = 128;
      gr = 128;
      b = 128;
      a =  byte.MaxValue;
      let mut num2: i32 =   Math.Round(Conversion.Int((double) w / (double) width1));
      for (let mut index1: i32 =  0; index1 <= num2; index1 += 1)
      {
        let mut num3: i32 =   Math.Round(Conversion.Int((double) h / (double) num1));
        for (let mut index2: i32 =  0; index2 <= num3; index2 += 1)
        {
          let mut width2: i32 =  index1 * w + width1;
          let mut height: i32 =  index2 * h + num1;
          let mut x1: i32 =  x + index1 * width1;
          let mut y1: i32 =  y + index2 * num1;
          if (x1 + width2 - x > w)
            width2 -= x1 + width2 - x - w;
          if (y1 + height - y > h)
            height -= y1 + height - y - h;
          ref Graphics local1 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(backtut);
          ref Bitmap local2 = ref bitmap;
          Rectangle srcrect = Rectangle::new(0, 0, width2, height);
          Rectangle destrect = Rectangle::new(x1, y1, width2, height);
          DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
        }
      }
      DrawMod.DrawRectangle(ref g, x - 1, y - 1, w + 1, h + 1,  Math.Round((double) r / 2.0),  Math.Round((double) gr / 2.0),  Math.Round((double) b / 2.0),  byte.MaxValue);
      DrawMod.DrawRectangle(ref g, x, y, w - 1, h - 1, Conversion.Int(r * 2), Conversion.Int(gr * 2), Conversion.Int(b * 2),  byte.MaxValue);
      DrawMod.DrawRectangle(ref g, x + 3, y + 3, w - 7, h - 7,  Math.Round((double) r * 0.2),  Math.Round((double) gr * 0.2),  Math.Round((double) b * 0.2),  byte.MaxValue);
      DrawMod.DrawRectangle(ref g, x + 1, y + 1, w - 3, h - 3,  byte.MaxValue, 0, 0,  byte.MaxValue);
      DrawMod.DrawRectangle(ref g, x + 2, y + 2, w - 5, h - 5,  byte.MaxValue, 0, 0,  byte.MaxValue);
      if (HideOff)
        return;
      ref Graphics local3 = ref g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.MARCOFFICER);
      ref Bitmap local4 = ref bitmap1;
      let mut x2: i32 =  x + w - 95;
      let mut y2: i32 =  y + 10;
      DrawMod.DrawScaled(ref local3, ref local4, x2, y2, 90, 98);
      DrawMod.DrawTextColouredMarc(ref g, "VIC", DrawMod.TGame.MarcFont4, x + w - 95 + 30, y + 105, Color.White);
    }

    pub static void DrawRepeatingBackground(
      Graphics g,
      int bitmapNr,
      int x,
      int y,
      int w,
      int h)
    {
      let mut nr: i32 =  bitmapNr;
      let mut width1: i32 =  BitmapStore.GetWidth(nr);
      let mut num1: i32 =  BitmapStore.Getheight(nr);
      let mut num2: i32 =   Math.Round(Conversion.Int((double) w / (double) width1));
      for (let mut index1: i32 =  0; index1 <= num2; index1 += 1)
      {
        let mut num3: i32 =   Math.Round(Conversion.Int((double) h / (double) num1));
        for (let mut index2: i32 =  0; index2 <= num3; index2 += 1)
        {
          let mut width2: i32 =  index1 * w + width1;
          let mut height: i32 =  index2 * h + num1;
          let mut x1: i32 =  x + index1 * width1;
          let mut y1: i32 =  y + index2 * num1;
          if (x1 + width2 - x > w)
            width2 -= x1 + width2 - x - w;
          if (y1 + height - y > h)
            height -= y1 + height - y - h;
          ref Graphics local1 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(nr);
          ref Bitmap local2 = ref bitmap;
          Rectangle srcrect = Rectangle::new(0, 0, width2, height);
          Rectangle destrect = Rectangle::new(x1, y1, width2, height);
          DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
        }
      }
    }

    pub static Rectangle GetPaintedPartRect(Bitmap bmp)
    {
      let mut num1: i32 =  bmp.Width - 1;
      int x1;
      int y1;
      Color pixel;
      for (x1 = 0; x1 <= num1; x1 += 1)
      {
        let mut num2: i32 =  bmp.Height - 1;
        for (y1 = 0; y1 <= num2; y1 += 1)
        {
          pixel = bmp.GetPixel(x1, y1);
          if (pixel.A > (byte) 60)
            break;
        }
        if (pixel.A > (byte) 60)
          break;
      }
      Rectangle paintedPartRect;
      paintedPartRect.X = x1;
      paintedPartRect.Y = y1;
      let mut y2: i32 =  paintedPartRect.Y;
      let mut num3: i32 =  bmp.Height - 1;
      int y3;
      for (y3 = y2; y3 <= num3; y3 += 1)
      {
        pixel = bmp.GetPixel(x1, y3);
        if (pixel.A < (byte) 60)
          break;
      }
      paintedPartRect.Height = y3 - paintedPartRect.Y;
      let mut y4: i32 =  paintedPartRect.Y;
      let mut x2: i32 =  paintedPartRect.X;
      let mut num4: i32 =  bmp.Width - 1;
      int x3;
      for (x3 = x2; x3 <= num4; x3 += 1)
      {
        pixel = bmp.GetPixel(x3, y4);
        if (pixel.A < (byte) 60)
          break;
      }
      paintedPartRect.Width = x3 - paintedPartRect.X;
      return paintedPartRect;
    }
  }
}
