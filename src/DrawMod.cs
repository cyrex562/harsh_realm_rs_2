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
  public sealed class DrawMod
  {
    public const int SRCAND = 8913094;
    public const int SRCINVERT = 6684742;
    public const byte AC_SRC_OVER = 0;
    public const byte AC_SRC_ALPHA = 1;
    public const byte SW_MINIMIZE = 6;
    private static Font ttfont = new Font("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel);
    public static Random RandyNumber;
    public static bool MouseClicked;
    public static GameClass TGame;
    public static string ModFile;
    public static int DPIx;
    public static int DPIy;
    public static Bitmap tempBmp128;
    public static Bitmap tempBmp64;
    public static Bitmap tempBmp32;
    public static Bitmap tempBmp32by48;
    public static Bitmap tempBmp64by64;
    public static Bitmap tempBmp64by16;
    public static Bitmap tempBmp16by24;
    public static Bitmap tempBmp32by12;
    public static Bitmap tempBmp32by8;
    public static Bitmap tempBmp8by12;
    public static Bitmap tempBmp16by6;
    public static Bitmap tempBmp16by4;

    [DllImport("GDI32.DLL", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool BitBlt(
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
    public static extern bool AlphaBlend(
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
    private static extern bool StretchBlt(
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
    private static extern long SetStretchBltMode(IntPtr hdc, long nStretchMode);

    [DllImport("GDI32.DLL", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SelectObject(IntPtr hdc, IntPtr h);

    [DllImport("GDI32.DLL", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool DeleteObject(IntPtr ho);

    static DrawMod()
    {
      VBMath.Randomize();
      DrawMod.RandyNumber = new Random((int) Math.Round((double) (VBMath.Rnd() * 100000f)) + 1);
      DrawMod.DPIx = 96;
      DrawMod.DPIy = 96;
    }

    public static void DrawWithArtCode(
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
      int height = tempBmp.Height;
      int width = tempBmp.Width;
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
        int num1 = 0;
        int num2 = 0;
        if (DrawMod.TGame.Data.PeopleObj[ppl].artCode > 0)
          num2 = DrawMod.TGame.Data.PeopleObj[ppl].artCode;
        if (num2 > 0)
        {
          int index = 0;
          do
          {
            if (DrawMod.TGame.Data.SFTypeObj[sftypenr].artCode[index] == num2)
              num1 = index;
            ++index;
          }
          while (index <= 9);
        }
        if (num1 * slotHeight <= height - 1)
        {
          DrawMod.DrawSimplePart2(ref g, ref tempBmp, new Rectangle(0, num1 * slotHeight, slotWidth, slotHeight), new Rectangle(tx, ty, tw, th));
        }
        else
        {
          int num3 = 0;
          DrawMod.DrawSimplePart2(ref g, ref tempBmp, new Rectangle(0, num3 * slotHeight, slotWidth, slotHeight), new Rectangle(tx, ty, tw, th));
        }
      }
      else
      {
        if (tw == -1 | th == -1)
        {
          tw = tempBmp.Width;
          th = tempBmp.Height;
        }
        DrawMod.DrawSimplePart2(ref g, ref tempBmp, new Rectangle(0, 0, tempBmp.Width, tempBmp.Height), new Rectangle(tx, ty, tw, th));
      }
    }

    public static void ModifyColorOfBitmapHighSpeed(
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
      int length = Math.Abs(bitmapdata.Stride) * bmp.Height;
      byte[] numArray = new byte[length - 1 + 1];
      Marshal.Copy(scan0, numArray, 0, length);
      int num1 = numArray.Length - 1;
      for (int index = 0; index <= num1; index += 4)
      {
        byte num2 = numArray[index];
        byte num3 = numArray[index + 1];
        byte num4 = numArray[index + 2];
        if (numArray[index + 3] > (byte) 0)
        {
          int num5 = (int) num2;
          int num6 = (int) num3;
          int num7 = Math.Min((int) byte.MaxValue, (int) Math.Round((double) num4 / (double) fr * (double) tr));
          int num8 = Math.Min((int) byte.MaxValue, (int) Math.Round((double) num6 / (double) fg * (double) tg));
          byte num9 = (byte) Math.Min((int) byte.MaxValue, (int) Math.Round((double) num5 / (double) fb * (double) tb));
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

    public static void ModifyColorOfBitmapToGrayHighSpeed(ref Bitmap bmp, int effectStrength)
    {
      Rectangle rect;
      rect.X = 0;
      rect.Y = 0;
      rect.Width = bmp.Width;
      rect.Height = bmp.Height;
      BitmapData bitmapdata = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
      IntPtr scan0 = bitmapdata.Scan0;
      int length = Math.Abs(bitmapdata.Stride) * bmp.Height;
      byte[] numArray = new byte[length - 1 + 1];
      Marshal.Copy(scan0, numArray, 0, length);
      int num1 = (int) byte.MaxValue - effectStrength;
      if (effectStrength < 1 | effectStrength >= (int) byte.MaxValue)
      {
        int num2 = numArray.Length - 1;
        for (int index = 0; index <= num2; index += 4)
        {
          byte num3 = numArray[index];
          byte num4 = numArray[index + 1];
          byte num5 = numArray[index + 2];
          if (numArray[index + 3] > (byte) 0)
          {
            int num6 = (int) Math.Round((double) ((float) num3 * 0.21f)) + (int) Math.Round((double) ((float) num4 * 0.71f)) + (int) Math.Round((double) ((float) num5 * 0.07f));
            if (num6 > (int) byte.MaxValue)
              num6 = (int) byte.MaxValue;
            byte num7 = (byte) num6;
            numArray[index] = num7;
            numArray[index + 1] = num7;
            numArray[index + 2] = num7;
          }
        }
      }
      else
      {
        int num8 = numArray.Length - 1;
        for (int index = 0; index <= num8; index += 4)
        {
          byte num9 = numArray[index];
          byte num10 = numArray[index + 1];
          byte num11 = numArray[index + 2];
          if (numArray[index + 3] > (byte) 0)
          {
            int num12 = (int) Math.Round((double) ((float) num9 * 0.21f)) + (int) Math.Round((double) ((float) num10 * 0.71f)) + (int) Math.Round((double) ((float) num11 * 0.07f));
            int num13 = (int) Math.Round((double) (num12 * effectStrength) / (double) byte.MaxValue) + (int) Math.Round((double) ((int) num9 * num1) / (double) byte.MaxValue);
            int num14 = (int) Math.Round((double) (num12 * effectStrength) / (double) byte.MaxValue) + (int) Math.Round((double) ((int) num10 * num1) / (double) byte.MaxValue);
            int num15 = (int) Math.Round((double) (num12 * effectStrength) / (double) byte.MaxValue) + (int) Math.Round((double) ((int) num11 * num1) / (double) byte.MaxValue);
            if (num13 > (int) byte.MaxValue)
              num13 = (int) byte.MaxValue;
            if (num15 > (int) byte.MaxValue)
              num15 = (int) byte.MaxValue;
            if (num14 > (int) byte.MaxValue)
              num14 = (int) byte.MaxValue;
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

    public static void CopyPerLineAndGrayscale(
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
      int width = fw;
      int height = fh;
      int num1 = fx * 4;
      int num2 = fy;
      int num3 = (fx + fw) * 4 - num1;
      Rectangle rect1 = new Rectangle(x, y, width, height);
      Rectangle rect2 = new Rectangle(0, 0, width, height);
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
      int num8 = 0;
      if ((double) num4 == 1.0 & (double) num5 == 1.0 & (double) num6 == 1.0)
        num8 = 1;
      if ((double) num4 == 0.0 & (double) num5 == 0.0 & (double) num6 == 0.0)
        num8 = 2;
      if (num8 == 2)
      {
        int index = 0;
        do
        {
          numArray4[index] = (byte) Math.Round((double) ((float) index * num7));
          ++index;
        }
        while (index <= (int) byte.MaxValue);
      }
      else
      {
        int index = 0;
        do
        {
          numArray1[index] = (byte) Math.Round((double) ((float) index * num6 * num7));
          numArray2[index] = (byte) Math.Round((double) ((float) index * num5 * num7));
          numArray3[index] = (byte) Math.Round((double) ((float) index * num4 * num7));
          numArray4[index] = (byte) Math.Round((double) ((float) index * num7));
          ++index;
        }
        while (index <= (int) byte.MaxValue);
      }
      byte[] numArray5 = new byte[num3 - 1 + 1];
      int num9 = bitmapdata2.Height - 1;
      for (int index1 = 0; index1 <= num9; ++index1)
      {
        IntPtr scan0 = bitmapdata2.Scan0;
        IntPtr source = (IntPtr) (scan0.ToInt64() + (long) ((index1 + num2) * bitmapdata2.Stride) + (long) num1);
        scan0 = bitmapdata1.Scan0;
        IntPtr destination = (IntPtr) (scan0.ToInt64() + (long) (index1 * bitmapdata1.Stride));
        Marshal.Copy(source, numArray5, 0, numArray5.Length);
        int num10 = numArray5.Length - 1;
        switch (num8)
        {
          case 1:
            int num11 = num10 - 1;
            for (int index2 = 0; index2 <= num11; index2 += 4)
            {
              numArray5[index2 + 2] = numArray4[(int) numArray5[index2 + 2]];
              numArray5[index2 + 1] = numArray4[(int) numArray5[index2 + 1]];
              numArray5[index2] = numArray4[(int) numArray5[index2]];
              numArray5[index2 + 3] = numArray4[(int) numArray5[index2 + 3]];
            }
            break;
          case 2:
            int num12 = num10 - 1;
            for (int index3 = 0; index3 <= num12; index3 += 4)
            {
              numArray5[index3 + 2] = (byte) 0;
              numArray5[index3 + 1] = (byte) 0;
              numArray5[index3] = (byte) 0;
              numArray5[index3 + 3] = numArray4[(int) numArray5[index3 + 3]];
            }
            break;
          default:
            int num13 = num10 - 1;
            for (int index4 = 0; index4 <= num13; index4 += 4)
            {
              if (numArray5[index4 + 3] > (byte) 0)
              {
                numArray5[index4 + 2] = (byte) Math.Round((double) ((float) numArray5[index4 + 2] * num4));
                numArray5[index4 + 1] = (byte) Math.Round((double) ((float) numArray5[index4 + 2] * num5));
                numArray5[index4] = (byte) Math.Round((double) ((float) numArray5[index4 + 2] * num6));
                numArray5[index4 + 3] = numArray4[(int) numArray5[index4 + 3]];
              }
            }
            break;
        }
        Marshal.Copy(numArray5, 0, destination, numArray5.Length);
      }
      dest.UnlockBits(bitmapdata1);
      from.UnlockBits(bitmapdata2);
    }

    public static void ModifyColorOfGrayscaleBitmap(
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
      int length = Math.Abs(bitmapdata.Stride) * bmp.Height;
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
        int index1 = 0;
        do
        {
          numArray2[index1] = (byte) Math.Round((double) ((float) index1 * num4));
          ++index1;
        }
        while (index1 <= (int) byte.MaxValue);
        int num5 = numArray1.Length - 1;
        for (int index2 = 3; index2 <= num5; index2 += 4)
          source[index2] = numArray2[(int) numArray1[index2]];
        Marshal.Copy(source, 0, scan0, length);
        bmp.UnlockBits(bitmapdata);
      }
      else
      {
        int num6 = numArray1.Length - 1;
        for (int index = 0; index <= num6; index += 4)
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

    public static void DrawSaturized(
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
      ImageAttributes imageAttr = new ImageAttributes();
      Rectangle destRect = new Rectangle(x, y, objBitmap.Width, objBitmap.Height);
      imageAttr.SetColorMatrix(newColorMatrix);
      objGraphics.DrawImage((Image) objBitmap, destRect, 0, 0, objBitmap.Width, objBitmap.Height, GraphicsUnit.Pixel, imageAttr);
    }

    public static void Draw(
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
      ImageAttributes imageAttr = new ImageAttributes();
      Rectangle destRect = new Rectangle(x, y, objBitmap.Width, objBitmap.Height);
      imageAttr.SetColorMatrix(newColorMatrix);
      objGraphics.DrawImage((Image) objBitmap, destRect, 0, 0, objBitmap.Width, objBitmap.Height, GraphicsUnit.Pixel, imageAttr);
    }

    public static void DrawGray(ref Graphics objGraphics, ref Bitmap objBitmap, int x, int y)
    {
      ColorMatrix newColorMatrix = new ColorMatrix(new float[5][]
      {
        new float[5]{ 0.5f, 0.5f, 0.5f, 0.0f, 0.0f },
        new float[5]{ 0.5f, 0.5f, 0.5f, 0.0f, 0.0f },
        new float[5]{ 0.5f, 0.5f, 0.5f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 0.35f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1f }
      });
      ImageAttributes imageAttr = new ImageAttributes();
      Rectangle destRect = new Rectangle(x, y, objBitmap.Width, objBitmap.Height);
      imageAttr.SetColorMatrix(newColorMatrix);
      objGraphics.DrawImage((Image) objBitmap, destRect, 0, 0, objBitmap.Width, objBitmap.Height, GraphicsUnit.Pixel, imageAttr);
    }

    public static void ExpDraw(
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
      ImageAttributes imageAttr = new ImageAttributes();
      Rectangle destRect = new Rectangle(x, y, objBitmap.Width, objBitmap.Height);
      imageAttr.SetColorMatrix(newColorMatrix);
      objGraphics.DrawImage((Image) objBitmap, destRect, 0, 0, objBitmap.Width, objBitmap.Height, GraphicsUnit.Pixel, imageAttr);
    }

    public static void Draw2(
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
      ImageAttributes imageAttr = new ImageAttributes();
      Rectangle destRect = new Rectangle(x, y, objBitmap.Width, objBitmap.Height);
      imageAttr.SetColorMatrix(newColorMatrix);
      objGraphics.DrawImage((Image) objBitmap, destRect, 0, 0, objBitmap.Width, objBitmap.Height, GraphicsUnit.Pixel, imageAttr);
    }

    public static void DrawSimplePart2Coloured(
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
      graphics.DrawImage((Image) objBitmap, new Rectangle(0, 0, destrect.Width, destrect.Height), new Rectangle(srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height), GraphicsUnit.Pixel);
      graphics.Dispose();
      ColorMatrix newColorMatrix = new ColorMatrix(new float[5][]
      {
        new float[5]{ 1f, 0.0f, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 1f, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 1f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 0.5f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1f }
      });
      ImageAttributes imageAttr = new ImageAttributes();
      imageAttr.SetColorMatrix(newColorMatrix, ColorMatrixFlag.Default);
      objGraphics.DrawImage((Image) bitmap, destrect, 0, 0, destrect.Width, destrect.Height, GraphicsUnit.Pixel, imageAttr);
    }

    public static void DrawSimplePart2ColouredOld(
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
      graphics.DrawImage((Image) objBitmap, new Rectangle(0, 0, destrect.Width, destrect.Height), new Rectangle(srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height), GraphicsUnit.Pixel);
      graphics.Dispose();
      ColorMatrix newColorMatrix = new ColorMatrix(new float[5][]
      {
        new float[5]{ r, 0.0f, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, g, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, b, 0.0f, 0.0f },
        new float[5]{ r, g, b, a, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1f }
      });
      ImageAttributes imageAttr = new ImageAttributes();
      imageAttr.SetColorMatrix(newColorMatrix, ColorMatrixFlag.Default);
      objGraphics.DrawImage((Image) bitmap, destrect, 0, 0, destrect.Width, destrect.Height, GraphicsUnit.Pixel, imageAttr);
    }

    public static void DrawSimplePart2ColouredNewFast(
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
        DrawMod.CopyPerLineAndGrayscale(ref objBitmap, ref bitmap, srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height, 0, 0, (int) Math.Round((double) (r * (float) byte.MaxValue)), (int) Math.Round((double) (g * (float) byte.MaxValue)), (int) Math.Round((double) (b * (float) byte.MaxValue)), (int) Math.Round((double) (a * (float) byte.MaxValue)));
        DrawMod.DrawSimple(ref objGraphics, ref bitmap, destrect.X, destrect.Y);
        if (flag)
          return;
        bitmap.Dispose();
      }
    }

    public static void DrawSimplePart2ColouredNew(
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
      ImageAttributes imageAttr = new ImageAttributes();
      imageAttr.SetColorMatrix(newColorMatrix, ColorMatrixFlag.Default);
      objGraphics.DrawImage((Image) objBitmap, destrect, srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height, GraphicsUnit.Pixel, imageAttr);
    }

    public static void DrawSimple(ref Graphics objGraphics, ref Bitmap objBitmap, int x, int y)
    {
      if (Information.IsNothing((object) objBitmap))
        return;
      Rectangle destRect = new Rectangle(x, y, objBitmap.Width, objBitmap.Height);
      if (!DrawMod.TGame.EmpireStyle | !DrawMod.TGame.EditObj.highGfxSpeedOn)
        objGraphics.DrawImage((Image) objBitmap, destRect, 0, 0, objBitmap.Width, objBitmap.Height, GraphicsUnit.Pixel);
      else
        objGraphics.DrawImageUnscaled((Image) objBitmap, x, y);
    }

    public static void DrawSimpleFastWithAlpha(
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

    public static void DrawSimpleFast(
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

    public static void CopyPerLineWithAlpha(
      ref Bitmap from,
      ref Bitmap dest,
      int fx,
      int fy,
      int fw,
      int fh,
      int x,
      int y)
    {
      int width = fw;
      int height = fh;
      int num1 = fx * 4;
      int num2 = fy;
      int num3 = (fx + fw) * 4 - num1;
      Rectangle rect1 = new Rectangle(x, y, width, height);
      Rectangle rect2 = new Rectangle(0, 0, width, height);
      BitmapData bitmapdata1 = dest.LockBits(rect1, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
      BitmapData bitmapdata2 = from.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
      byte[] numArray = new byte[num3 - 1 + 1];
      byte[] destination = new byte[num3 - 1 + 1];
      int num4 = bitmapdata2.Height - 1;
      for (int index1 = 0; index1 <= num4; ++index1)
      {
        IntPtr scan0 = bitmapdata2.Scan0;
        IntPtr source = (IntPtr) (scan0.ToInt64() + (long) ((index1 + num2) * bitmapdata2.Stride) + (long) num1);
        scan0 = bitmapdata1.Scan0;
        IntPtr num5 = (IntPtr) (scan0.ToInt64() + (long) (index1 * bitmapdata1.Stride));
        Marshal.Copy(source, destination, 0, destination.Length);
        Marshal.Copy(num5, numArray, 0, numArray.Length);
        int num6 = numArray.Length - 4;
        for (int index2 = 0; index2 <= num6; index2 += 4)
        {
          numArray[index2] = (byte) Math.Round((double) (byte) ((uint) destination[index2] * (uint) destination[index2 + 3]) / (double) byte.MaxValue + (double) ((int) numArray[index2] * ((int) byte.MaxValue - (int) destination[index2 + 3])) / (double) byte.MaxValue);
          numArray[index2 + 1] = (byte) Math.Round((double) (byte) ((uint) destination[index2 + 1] * (uint) destination[index2 + 3]) / (double) byte.MaxValue + (double) ((int) numArray[index2 + 1] * ((int) byte.MaxValue - (int) destination[index2 + 3])) / (double) byte.MaxValue);
          numArray[index2 + 2] = (byte) Math.Round((double) (byte) ((uint) destination[index2 + 2] * (uint) destination[index2 + 3]) / (double) byte.MaxValue + (double) ((int) numArray[index2 + 2] * ((int) byte.MaxValue - (int) destination[index2 + 3])) / (double) byte.MaxValue);
        }
        Marshal.Copy(numArray, 0, num5, numArray.Length);
      }
      dest.UnlockBits(bitmapdata1);
      from.UnlockBits(bitmapdata2);
    }

    public static void CopyPerLineOnlyAlpha(
      ref Bitmap from,
      ref Bitmap dest,
      int fx,
      int fy,
      int fw,
      int fh,
      int x,
      int y)
    {
      int width = fw;
      int height = fh;
      int num1 = fx * 4;
      int num2 = fy;
      int num3 = (fx + fw) * 4 - num1;
      Rectangle rect1 = new Rectangle(x, y, width, height);
      Rectangle rect2 = new Rectangle(0, 0, width, height);
      BitmapData bitmapdata1 = dest.LockBits(rect1, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
      BitmapData bitmapdata2 = from.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
      byte[] numArray = new byte[num3 - 1 + 1];
      byte[] destination = new byte[num3 - 1 + 1];
      int num4 = bitmapdata2.Height - 1;
      for (int index1 = 0; index1 <= num4; ++index1)
      {
        IntPtr scan0 = bitmapdata2.Scan0;
        IntPtr source = (IntPtr) (scan0.ToInt64() + (long) ((index1 + num2) * bitmapdata2.Stride) + (long) num1);
        scan0 = bitmapdata1.Scan0;
        IntPtr num5 = (IntPtr) (scan0.ToInt64() + (long) (index1 * bitmapdata1.Stride));
        Marshal.Copy(source, destination, 0, destination.Length);
        Marshal.Copy(num5, numArray, 0, numArray.Length);
        int num6 = numArray.Length - 4;
        for (int index2 = 0; index2 <= num6; index2 += 4)
          numArray[index2 + 3] = destination[index2 + 2];
        Marshal.Copy(numArray, 0, num5, numArray.Length);
      }
      dest.UnlockBits(bitmapdata1);
      from.UnlockBits(bitmapdata2);
    }

    public static void CopyPerLineWithAlpha(ref Bitmap from, ref Bitmap dest, int x, int y)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = from.Width;
      int num4 = from.Height;
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
      Rectangle rect1 = new Rectangle(x, y, num3, num4);
      Rectangle rect2 = new Rectangle(num1, num2, num3, num4);
      BitmapData bitmapdata1 = dest.LockBits(rect1, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
      BitmapData bitmapdata2 = from.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
      byte[] numArray = new byte[bitmapdata2.Stride - 1 + 1];
      byte[] destination = new byte[bitmapdata2.Stride - 1 + 1];
      int num5 = bitmapdata2.Height - 1;
      for (int index1 = 0; index1 <= num5; ++index1)
      {
        IntPtr scan0 = bitmapdata2.Scan0;
        IntPtr source = (IntPtr) (scan0.ToInt64() + (long) (index1 * bitmapdata2.Stride));
        scan0 = bitmapdata1.Scan0;
        IntPtr num6 = (IntPtr) (scan0.ToInt64() + (long) (index1 * bitmapdata1.Stride));
        if (index1 == bitmapdata2.Height - 1 & bitmapdata1.Stride < bitmapdata2.Stride)
          numArray = (byte[]) Utils.CopyArray((Array) numArray, (Array) new byte[bitmapdata1.Stride - 1 + 1]);
        Marshal.Copy(source, destination, 0, destination.Length);
        Marshal.Copy(num6, numArray, 0, numArray.Length);
        int num7 = numArray.Length - 4;
        for (int index2 = 0; index2 <= num7; index2 += 4)
        {
          numArray[index2] = (byte) Math.Round((double) (byte) ((uint) destination[index2] * (uint) destination[index2 + 3]) / (double) byte.MaxValue + (double) ((int) numArray[index2] * ((int) byte.MaxValue - (int) destination[index2 + 3])) / (double) byte.MaxValue);
          numArray[index2 + 1] = (byte) Math.Round((double) (byte) ((uint) destination[index2 + 1] * (uint) destination[index2 + 3]) / (double) byte.MaxValue + (double) ((int) numArray[index2 + 1] * ((int) byte.MaxValue - (int) destination[index2 + 3])) / (double) byte.MaxValue);
          numArray[index2 + 2] = (byte) Math.Round((double) (byte) ((uint) destination[index2 + 2] * (uint) destination[index2 + 3]) / (double) byte.MaxValue + (double) ((int) numArray[index2 + 2] * ((int) byte.MaxValue - (int) destination[index2 + 3])) / (double) byte.MaxValue);
        }
        Marshal.Copy(numArray, 0, num6, numArray.Length);
      }
      dest.UnlockBits(bitmapdata1);
      from.UnlockBits(bitmapdata2);
    }

    public static void CopyPerLine(ref Bitmap from, ref Bitmap dest, int x, int y)
    {
      int x1 = 0;
      int y1 = 0;
      int width = from.Width;
      int height = from.Height;
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
      Rectangle rect1 = new Rectangle(x, y, width, height);
      Rectangle rect2 = new Rectangle(x1, y1, width, height);
      BitmapData bitmapdata1 = dest.LockBits(rect1, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
      BitmapData bitmapdata2 = from.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
      byte[] numArray = new byte[bitmapdata2.Stride - 1 + 1];
      int num = bitmapdata2.Height - 1;
      for (int index = 0; index <= num; ++index)
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

    public static void CopyPerLine(
      ref Bitmap from,
      ref Bitmap dest,
      int fx,
      int fy,
      int fw,
      int fh,
      int x,
      int y)
    {
      int width = fw;
      int height = fh;
      int num1 = fx * 4;
      int num2 = (fx + fw) * 4 - num1;
      Rectangle rect1 = new Rectangle(x, y, width, height);
      Rectangle rect2 = new Rectangle(fx, fy, width, height);
      BitmapData bitmapdata1 = dest.LockBits(rect1, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
      BitmapData bitmapdata2 = from.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
      byte[] numArray = new byte[num2 - 1 + 1];
      int num3 = bitmapdata2.Height - 1;
      for (int index = 0; index <= num3; ++index)
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

    public static void CopyPerLine_DOUBLE(
      ref Bitmap from,
      ref Bitmap dest,
      int fx,
      int fy,
      int fw,
      int fh,
      int x,
      int y)
    {
      int width = fw * 2;
      int height = fh * 2;
      int num1 = fx * 4;
      int num2 = fy;
      int num3 = (fx + fw) * 4 - num1;
      Rectangle rect1 = new Rectangle(x, y, width, height);
      Rectangle rect2 = new Rectangle(0, 0, fw, fh);
      BitmapData bitmapdata1 = dest.LockBits(rect1, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
      BitmapData bitmapdata2 = from.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
      byte[] destination1 = new byte[num3 - 1 + 1];
      byte[] source1 = new byte[num3 * 2 - 1 + 1];
      int num4 = 0;
      int num5 = bitmapdata2.Height - 1;
      for (int index1 = 0; index1 <= num5; ++index1)
      {
        IntPtr scan0 = bitmapdata2.Scan0;
        IntPtr source2 = (IntPtr) (scan0.ToInt64() + (long) ((index1 + num2) * bitmapdata2.Stride) + (long) num1);
        scan0 = bitmapdata1.Scan0;
        IntPtr destination2 = (IntPtr) (scan0.ToInt64() + (long) (num4 * bitmapdata1.Stride));
        int num6 = num4 + 1;
        Marshal.Copy(source2, destination1, 0, destination1.Length);
        int num7 = destination1.Length - 1;
        int index2 = 0;
        int num8 = num7;
        for (int index3 = 0; index3 <= num8; index3 += 4)
        {
          source1[index2] = destination1[index3];
          source1[index2 + 1] = destination1[index3 + 1];
          source1[index2 + 2] = destination1[index3 + 2];
          source1[index2 + 3] = destination1[index3 + 3];
          int index4 = index2 + 4;
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

    public static void CopyPerLine_150PERCENT(
      ref Bitmap from,
      ref Bitmap dest,
      int fx,
      int fy,
      int fw,
      int fh,
      int x,
      int y)
    {
      int width = (int) Math.Round((double) fw * 1.5);
      int height = (int) Math.Round((double) fh * 1.5);
      int num1 = fx * 4;
      int num2 = fy;
      int num3 = (fx + fw) * 4 - num1;
      Rectangle rect1 = new Rectangle(x, y, width, height);
      Rectangle rect2 = new Rectangle(0, 0, fw, fh);
      BitmapData bitmapdata1 = dest.LockBits(rect1, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
      BitmapData bitmapdata2 = from.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
      byte[] destination1 = new byte[num3 - 1 + 1];
      byte[] source1 = new byte[num3 * 2 - 1 + 1];
      int num4 = 0;
      int num5 = bitmapdata2.Height - 1;
      for (int index1 = 0; index1 <= num5; ++index1)
      {
        IntPtr source2 = (IntPtr) (bitmapdata2.Scan0.ToInt64() + (long) ((index1 + num2) * bitmapdata2.Stride) + (long) num1);
        IntPtr destination2 = (IntPtr) (bitmapdata1.Scan0.ToInt64() + (long) (num4 * bitmapdata1.Stride));
        int num6 = num4 + 1;
        Marshal.Copy(source2, destination1, 0, destination1.Length);
        int num7 = destination1.Length - 1;
        int index2 = 0;
        int num8 = num7;
        for (int index3 = 0; index3 <= num8; index3 += 4)
        {
          source1[index2] = destination1[index3];
          source1[index2 + 1] = destination1[index3 + 1];
          source1[index2 + 2] = destination1[index3 + 2];
          source1[index2 + 3] = destination1[index3 + 3];
          int index4 = index2 + 4;
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

    public static void CopyPerLine_OLD(
      ref Bitmap from,
      ref Bitmap dest,
      int fx,
      int fy,
      int fw,
      int fh,
      int x,
      int y)
    {
      int width = fw;
      int height = fh;
      int num1 = fx * 4;
      int num2 = fy;
      int num3 = (fx + fw) * 4 - num1;
      Rectangle rect1 = new Rectangle(x, y, width, height);
      Rectangle rect2 = new Rectangle(0, 0, width, height);
      BitmapData bitmapdata1 = dest.LockBits(rect1, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
      BitmapData bitmapdata2 = from.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
      byte[] numArray = new byte[num3 - 1 + 1];
      int num4 = bitmapdata2.Height - 1;
      for (int index = 0; index <= num4; ++index)
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

    public static void Copy(ref Bitmap from, ref Bitmap dest)
    {
      if (from.Size != dest.Size)
        throw new FormatException("Pictures are not Equal in Size");
      Rectangle rect = new Rectangle(0, 0, dest.Width, dest.Height);
      BitmapData bitmapdata1 = dest.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
      BitmapData bitmapdata2 = from.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
      byte[] numArray = new byte[8192];
      int num;
      for (num = 0; (double) num < (double) (bitmapdata1.Stride * bitmapdata1.Height) / (double) numArray.Length; ++num)
      {
        IntPtr source = (IntPtr) (bitmapdata2.Scan0.ToInt32() + num * numArray.Length);
        IntPtr destination = (IntPtr) (bitmapdata1.Scan0.ToInt32() + num * numArray.Length);
        Marshal.Copy(source, numArray, 0, numArray.Length);
        Marshal.Copy(numArray, 0, destination, numArray.Length);
      }
      if (bitmapdata1.Stride * bitmapdata1.Height % numArray.Length != 0)
      {
        int length = bitmapdata1.Stride * bitmapdata1.Height % numArray.Length;
        IntPtr source = (IntPtr) (bitmapdata2.Scan0.ToInt32() + num * numArray.Length);
        IntPtr destination = (IntPtr) (bitmapdata1.Scan0.ToInt32() + num * numArray.Length);
        Marshal.Copy(source, numArray, 0, length);
        Marshal.Copy(numArray, 0, destination, length);
      }
      dest.UnlockBits(bitmapdata1);
      from.UnlockBits(bitmapdata2);
    }

    public static void CopyToForm(ref Bitmap from, ref Form frm)
    {
      int dwRop = 13369376;
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

    public static void CopyToForm2(ref Bitmap bmp, ref Form frm)
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
              int num4 = (int) Interaction.MsgBox((object) "Zero object exception. Gfx optimization error.");
            }
            if (DrawMod.BitBlt(num1, 0, 0, frm.Width, frm.Height, num2, 0, 0, 13369376))
              return;
            int num5 = (int) Interaction.MsgBox((object) "BitBlt exception. Gfx optimization error.");
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

    public static void CopyToForm2stretch(ref Bitmap bmp, ref Form frm)
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
              int num4 = (int) Interaction.MsgBox((object) "StretchBlt Zero object exception. Gfx optimization error.");
            }
            DrawMod.SetStretchBltMode(num1, 4L);
            if (DrawMod.StretchBlt(num1, 0, 0, frm.Width, frm.Height, num2, 0, 0, bmp.Width, bmp.Height, 13369376))
              return;
            int num5 = (int) Interaction.MsgBox((object) "StretchBlt exception. Gfx optimization error.");
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

    public static void CopyToForm2rect(ref Bitmap bmp, ref Form frm, Rectangle rect)
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
              int num4 = (int) Interaction.MsgBox((object) "BitBlt (rect) Zero object exception. Gfx optimization error.");
            }
            if (DrawMod.BitBlt(num1, rect.X, rect.Y, rect.Width, rect.Height, num2, rect.X, rect.Y, 13369376))
              return;
            int num5 = (int) Interaction.MsgBox((object) "BitBlt (rect) exception. Gfx optimization error.");
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

    public static void CopyToBitmapRect(
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
              int num4 = (int) Interaction.MsgBox((object) "BitBlt (rect) Zero object exception. Gfx optimization error.");
            }
            if (DrawMod.BitBlt(num1, targetx, targetY, sourcerect.Width, sourcerect.Height, num2, sourcerect.X, sourcerect.Y, 13369376))
              return;
            int num5 = (int) Interaction.MsgBox((object) "BitBlt (rect) exception. Gfx optimization error.");
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

    public static void DrawScaled(
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

    public static void MakeFuzzyBorder(ref Bitmap b, int range, int special = 0)
    {
      if (special == 2)
      {
        int num1 = 1;
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
          int num6 = num2;
          int num7 = num4;
          for (int y = num6; y <= num7; ++y)
          {
            int num8 = num3;
            int num9 = num5;
            for (int x = num8; x <= num9; ++x)
            {
              Color pixel = b.GetPixel(x, y);
              int alpha = (int) byte.MaxValue;
              if (x <= range)
              {
                int num10 = (int) Math.Round((double) alpha * ((double) x / (double) range) * ((double) x / (double) range));
                if (alpha > num10)
                  alpha = num10;
              }
              if (y <= range)
              {
                int num11 = (int) Math.Round((double) alpha * ((double) y / (double) range) * ((double) y / (double) range));
                if (alpha > num11)
                  alpha = num11;
              }
              if (x >= b.Width - range)
              {
                int num12 = (int) Math.Round((double) alpha * ((double) (b.Width - x) / (double) range) * ((double) (b.Width - x) / (double) range));
                if (alpha > num12)
                  alpha = num12;
              }
              if (y >= b.Height - range)
              {
                int num13 = (int) Math.Round((double) alpha * ((double) (b.Height - y) / (double) range) * ((double) (b.Height - y) / (double) range));
                if (alpha > num13)
                  alpha = num13;
              }
              if (alpha < (int) byte.MaxValue)
                alpha += (int) Math.Round((double) ((int) byte.MaxValue - alpha) * ((double) alpha / (double) byte.MaxValue));
              b.SetPixel(x, y, Color.FromArgb(alpha, (int) pixel.R, (int) pixel.G, (int) pixel.B));
            }
          }
          ++num1;
        }
        while (num1 <= 4);
      }
      else
      {
        int num14 = b.Height - 1;
        for (int y = 0; y <= num14; ++y)
        {
          int num15 = b.Width - 1;
          for (int x = 0; x <= num15; ++x)
          {
            Color pixel = b.GetPixel(x, y);
            int alpha = (int) byte.MaxValue;
            if (x <= range & special != 1)
            {
              int num16 = (int) Math.Round((double) byte.MaxValue * ((double) x / (double) range));
              if (alpha > num16)
                alpha = num16;
            }
            if (y <= range)
            {
              int num17 = (int) Math.Round((double) byte.MaxValue * ((double) y / (double) range));
              if (alpha > num17)
                alpha = num17;
            }
            if (x >= b.Width - range & special != 1)
            {
              int num18 = (int) Math.Round((double) byte.MaxValue * ((double) (b.Width - x) / (double) range));
              if (alpha > num18)
                alpha = num18;
            }
            if (y >= b.Height - range)
            {
              int num19 = (int) Math.Round((double) byte.MaxValue * ((double) (b.Height - y) / (double) range));
              if (alpha > num19)
                alpha = num19;
            }
            b.SetPixel(x, y, Color.FromArgb(alpha, (int) pixel.R, (int) pixel.G, (int) pixel.B));
          }
        }
      }
    }

    public static void DrawScaledColorized(
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
      ImageAttributes imageAttr = new ImageAttributes();
      imageAttr.SetColorMatrix(newColorMatrix);
      Point[] pointArray = new Point[3];
      Rectangle destRect = new Rectangle(x, y, w, h);
      pointArray[0] = new Point(x, y);
      pointArray[1] = new Point(x + w, y);
      pointArray[2] = new Point(x, y + h);
      Rectangle rectangle = new Rectangle(0, 0, origw, origh);
      objGraphics.DrawImage((Image) objBitmap, destRect, 0, 0, origw, origh, GraphicsUnit.Pixel, imageAttr);
    }

    public static void DrawScaledColorized2(
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
      ImageAttributes imageAttr = new ImageAttributes();
      imageAttr.SetColorMatrix(newColorMatrix);
      Point[] pointArray = new Point[3];
      Rectangle destRect = new Rectangle(x, y, w, h);
      pointArray[0] = new Point(x, y);
      pointArray[1] = new Point(x + w, y);
      pointArray[2] = new Point(x, y + h);
      Rectangle rectangle = new Rectangle(0, 0, origw, origh);
      objGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
      objGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
      objGraphics.DrawImage((Image) objBitmap, destRect, 0, 0, origw, origh, GraphicsUnit.Pixel, imageAttr);
      objGraphics.InterpolationMode = InterpolationMode.Default;
    }

    public static void DrawSimplePart(
      ref Graphics objGraphics,
      ref Bitmap objBitmap,
      Rectangle rect)
    {
      if (!DrawMod.TGame.EmpireStyle | !DrawMod.TGame.EditObj.highGfxSpeedOn | DrawMod.TGame.Data.Product < 6)
        objGraphics.DrawImage((Image) objBitmap, rect, rect, GraphicsUnit.Pixel);
      else
        DrawMod.DrawSimplePart2(ref objGraphics, ref objBitmap, rect, rect);
    }

    public static void DrawClear(Graphics objgraphics, ref Bitmap bmp, Color col)
    {
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb((int) byte.MaxValue, (int) col.R, (int) col.G, (int) col.B));
      objgraphics.FillRectangle((Brush) solidBrush, 0, 0, bmp.Width, bmp.Height);
    }

    public static void DrawSimplePart2(
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

    public static void DrawSimplePart2Fast(
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
          int num = (int) Interaction.MsgBox((object) "DrawSimplePart2Fast Drawing Error");
        }
        DrawMod.CopyPerLine(ref sourceBitmap, ref destBitmap, srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height, destrect.X, destrect.Y);
      }
    }

    public static void DrawSimplePartAlpha(
      ref Graphics objGraphics,
      ref Bitmap objBitmap,
      Rectangle srcrect,
      Rectangle destrect,
      float alpha)
    {
      ColorMatrix newColorMatrix = new ColorMatrix();
      newColorMatrix.Matrix33 = alpha;
      ImageAttributes imageAttr = new ImageAttributes();
      imageAttr.SetColorMatrix(newColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
      objGraphics.DrawImage((Image) objBitmap, destrect, srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height, GraphicsUnit.Pixel, imageAttr);
    }

    public static void DrawBlock(
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

    public static void DrawFilledCircle(
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

    public static void DrawFilledPolygon(
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

    public static void DrawCircle(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int w,
      int h,
      int r,
      int g,
      int b,
      int a,
      int widdy = 1)
    {
      Pen pen = new Pen(Color.FromArgb(a, r, g, b), (float) widdy);
      objGraphics.DrawEllipse(pen, x1, y1, w, h);
    }

    public static void DrawSteveBlock(ref Graphics objGraphics, int x1, int y1, int w, int h)
    {
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb((int) DrawMod.TGame.VicColor4.A, (int) DrawMod.TGame.VicColor4.R, (int) DrawMod.TGame.VicColor4.G, (int) DrawMod.TGame.VicColor4.B));
      objGraphics.FillRectangle((Brush) solidBrush, x1, y1, w, h);
    }

    public static void DrawBlockGradient(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int w,
      int h,
      Color c1,
      Color c2)
    {
      Rectangle rect = new Rectangle(x1, y1, w, h);
      if (w == 0 | h == 0)
        return;
      LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, c1, c2, LinearGradientMode.Horizontal);
      objGraphics.FillRectangle((Brush) linearGradientBrush, x1, y1, w, h);
    }

    public static void DrawBlockGradient2(
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
      LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Rectangle(x1, y1 - 1, w, h + 1), c1, c2, LinearGradientMode.Vertical);
      objGraphics.FillRectangle((Brush) linearGradientBrush, x1, y1, w, h);
    }

    public static void DrawBlockGradient3(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int w,
      int h,
      Color c1,
      Color c2)
    {
      LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Rectangle(x1, y1, w, h), c1, c2, LinearGradientMode.ForwardDiagonal);
      objGraphics.FillRectangle((Brush) linearGradientBrush, x1, y1, w, h);
    }

    public static void DrawBlockGradient4(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int w,
      int h,
      Color c1,
      Color c2,
      Color c3)
    {
      Rectangle rect = new Rectangle(x1, y1, w, h);
      Color[] colorArray = new Color[3]{ c1, c2, c3 };
      float[] numArray = new float[3]{ 0.0f, 0.5f, 1f };
      objGraphics.FillRectangle((Brush) new LinearGradientBrush(rect, c1, c2, LinearGradientMode.ForwardDiagonal)
      {
        InterpolationColors = new ColorBlend()
        {
          Colors = colorArray,
          Positions = numArray
        }
      }, x1, y1, w, h);
    }

    public static void DrawBlockGradient5(
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
      Rectangle rect = new Rectangle(x1, y1, w, h);
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
        InterpolationColors = new ColorBlend()
        {
          Colors = colorArray,
          Positions = numArray
        }
      }, x1, y1, w, h);
    }

    public static void DrawRectangle(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int w,
      int h,
      int r,
      int g,
      int b,
      int a,
      int widdy = 1)
    {
      if (r > (int) byte.MaxValue)
        r = (int) byte.MaxValue;
      if (g > (int) byte.MaxValue)
        g = (int) byte.MaxValue;
      if (b > (int) byte.MaxValue)
        b = (int) byte.MaxValue;
      Pen pen = new Pen(Color.FromArgb(a, r, g, b), (float) widdy);
      objGraphics.DrawRectangle(pen, x1, y1, w, h);
    }

    public static void DrawLineVic(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int w,
      int h,
      int r,
      int g,
      int b,
      int a,
      int widdy = 1)
    {
      if (r > (int) byte.MaxValue)
        r = (int) byte.MaxValue;
      if (g > (int) byte.MaxValue)
        g = (int) byte.MaxValue;
      if (b > (int) byte.MaxValue)
        b = (int) byte.MaxValue;
      Pen pen = new Pen(Color.FromArgb(a, r, g, b), (float) widdy);
      objGraphics.DrawRectangle(pen, x1, y1, w, h);
    }

    public static void MakeFullBoxVic(
      ref Graphics g,
      Rectangle rect1,
      string txt1,
      Rectangle rect2,
      string txt2,
      int SpecialMode = 0)
    {
      SizeF sizeF1 = new SizeF();
      SizeF sizeF2;
      if (rect1.Width > 0)
      {
        if (SpecialMode < 3)
        {
          g.Clip = new Region(rect1);
          sizeF2 = g.MeasureString(txt1, DrawMod.TGame.VicFont1);
          int x = rect1.X;
          int y = rect1.Y + (int) Math.Round(((double) rect1.Height - (double) sizeF2.Height) / 2.0);
          DrawMod.DrawTextVic(ref g, txt1, DrawMod.TGame.VicFont1, x, y, DrawMod.TGame.VicColor1, DrawMod.TGame.VicColor1Shade);
        }
        else if (SpecialMode == 3 | SpecialMode == 31 | SpecialMode == 32 | SpecialMode == 33)
        {
          g.Clip = new Region(rect1);
          sizeF2 = g.MeasureString(txt1, DrawMod.TGame.VicFont5);
          int x = rect1.X;
          int y = rect1.Y + 1 + (int) Math.Round((double) (Math.Max(0.0f, (float) rect2.Height - sizeF2.Height) / 2f));
          DrawMod.DrawTextVic(ref g, txt1, DrawMod.TGame.VicFont5, x, y, DrawMod.TGame.VicColor1, DrawMod.TGame.VicColor1Shade);
        }
      }
      g.Clip = new Region();
      if (rect2.Width > 0)
      {
        switch (SpecialMode)
        {
          case 0:
            sizeF2 = g.MeasureString(txt2, DrawMod.TGame.VicFont2);
            int height1 = rect2.Height;
            DrawMod.DrawBoxVic(ref g, rect2.X, rect2.Y + (int) Math.Round((double) (rect2.Height - height1) / 2.0), rect2.Width, height1, DrawMod.TGame.VicColor3, DrawMod.TGame.VicColor3Shade);
            g.Clip = new Region(rect2);
            int x1 = rect2.X;
            int num1 = rect2.Y + (int) Math.Round((double) (Math.Max(0.0f, (float) rect2.Height - sizeF2.Height) / 2f));
            DrawMod.DrawTextVic2(ref g, txt2, DrawMod.TGame.VicFont2, x1 + (int) Math.Round((double) ((float) (rect2.Width - 1) - sizeF2.Width)), num1 + 1, DrawMod.TGame.VicColor2, DrawMod.TGame.VicColor2Shade);
            break;
          case 1:
            sizeF2 = g.MeasureString(txt2, DrawMod.TGame.VicFont3);
            int height2 = rect2.Height;
            DrawMod.DrawBoxVic(ref g, rect2.X, rect2.Y + (int) Math.Round((double) (rect2.Height - height2) / 2.0), rect2.Width, height2, DrawMod.TGame.VicColor3, DrawMod.TGame.VicColor3Shade);
            g.Clip = new Region(rect2);
            int x2 = rect2.X;
            int num2 = rect2.Y + (int) Math.Round((double) (Math.Max(0.0f, (float) rect2.Height - sizeF2.Height) / 2f));
            DrawMod.DrawTextVic2(ref g, txt2, DrawMod.TGame.VicFont3, x2 + (int) Math.Round((double) ((float) (rect2.Width - 1) - sizeF2.Width)), num2 + 1, DrawMod.TGame.VicColor2, DrawMod.TGame.VicColor2Shade);
            break;
          default:
            if (SpecialMode == 2 | SpecialMode == 3)
            {
              txt2 = Strings.UCase(txt2);
              sizeF2 = g.MeasureString(txt2, DrawMod.TGame.VicFont3);
              int height3 = rect2.Height;
              DrawMod.DrawBoxVic(ref g, rect2.X, rect2.Y + (int) Math.Round((double) (rect2.Height - height3) / 2.0), rect2.Width, height3, DrawMod.TGame.VicColor3, DrawMod.TGame.VicColor3Shade);
              g.Clip = new Region(rect2);
              int x3 = rect2.X;
              int num3 = rect2.Y + (int) Math.Round((double) (Math.Max(0.0f, (float) rect2.Height - sizeF2.Height) / 2f));
              DrawMod.DrawTextVic2(ref g, txt2, DrawMod.TGame.VicFont3, x3 + 2 + (int) Math.Round((double) ((float) (rect2.Width - 1) - sizeF2.Width)), num3 + 1, DrawMod.TGame.VicColor2, DrawMod.TGame.VicColor2Shade);
              break;
            }
            if (SpecialMode == 31 | SpecialMode == 32 | SpecialMode == 33)
            {
              sizeF2 = g.MeasureString(txt2, DrawMod.TGame.VicFont4);
              int height4 = rect2.Height;
              DrawMod.DrawBoxVic(ref g, rect2.X, rect2.Y + (int) Math.Round((double) (rect2.Height - height4) / 2.0), rect2.Width, height4, DrawMod.TGame.VicColor3, DrawMod.TGame.VicColor3Shade);
              g.Clip = new Region(rect2);
              int x4 = rect2.X;
              int num4 = rect2.Y + (int) Math.Round((double) (Math.Max(0.0f, (float) rect2.Height - sizeF2.Height) / 2f));
              if (SpecialMode == 31)
                DrawMod.DrawTextVic2(ref g, txt2, DrawMod.TGame.VicFont4, x4 + (int) Math.Round((double) ((float) (rect2.Width - 1) - sizeF2.Width)), num4 + 1, Color.Red, Color.Black);
              if (SpecialMode == 32)
                DrawMod.DrawTextVic2(ref g, txt2, DrawMod.TGame.VicFont4, x4 + (int) Math.Round((double) ((float) (rect2.Width - 1) - sizeF2.Width)), num4 + 1, Color.Yellow, Color.Black);
              if (SpecialMode == 33)
              {
                DrawMod.DrawTextVic2(ref g, txt2, DrawMod.TGame.VicFont4, x4 + (int) Math.Round((double) ((float) (rect2.Width - 1) - sizeF2.Width)), num4 + 1, Color.FromArgb((int) byte.MaxValue, 0, (int) byte.MaxValue, 0), Color.Black);
                break;
              }
              break;
            }
            if (SpecialMode == 4)
            {
              sizeF2 = g.MeasureString(txt2, DrawMod.TGame.VicFont1);
              int height5 = rect2.Height;
              DrawMod.DrawBoxVic(ref g, rect2.X, rect2.Y + (int) Math.Round((double) (rect2.Height - height5) / 2.0), rect2.Width, height5, DrawMod.TGame.VicColor3, DrawMod.TGame.VicColor3Shade);
              g.Clip = new Region(rect2);
              int x5 = rect2.X;
              int num5 = rect2.Y - 2 + (int) Math.Round((double) (Math.Max(0.0f, (float) rect2.Height - sizeF2.Height) / 2f));
              DrawMod.DrawTextVic3(ref g, txt2, DrawMod.TGame.VicFont1, x5 + (int) Math.Round((double) ((float) (rect2.Width - 1) - sizeF2.Width)), num5 + 1, DrawMod.TGame.VicColor2, DrawMod.TGame.VicColor2Shade);
              break;
            }
            break;
        }
      }
      g.Clip = new Region();
    }

    public static void MakeFullBoxVic2(
      ref Graphics g,
      Rectangle rect1,
      string txt1,
      Rectangle rect2,
      string txt2,
      int SpecialMode = 0)
    {
      SizeF sizeF1 = new SizeF();
      SizeF sizeF2;
      if (rect1.Width > 0)
      {
        g.Clip = new Region(rect1);
        sizeF2 = g.MeasureString(txt1, DrawMod.TGame.VicFont5);
        int x = rect1.X;
        int y = rect1.Y + (int) Math.Round(((double) rect1.Height - (double) sizeF2.Height) / 2.0);
        DrawMod.DrawTextVic(ref g, txt1, DrawMod.TGame.VicFont5, x, y, DrawMod.TGame.VicColor1, DrawMod.TGame.VicColor1Shade);
      }
      g.Clip = new Region();
      if (rect2.Width > 0 && SpecialMode == 0)
      {
        sizeF2 = g.MeasureString(txt2, DrawMod.TGame.VicFont2);
        int height = rect2.Height;
        DrawMod.DrawBoxVic(ref g, rect2.X, rect2.Y + (int) Math.Round((double) (rect2.Height - height) / 2.0), rect2.Width, height, DrawMod.TGame.VicColor3, DrawMod.TGame.VicColor3Shade);
        g.Clip = new Region(rect2);
        int x = rect2.X;
        int num = rect2.Y + (int) Math.Round((double) (Math.Max(0.0f, (float) rect2.Height - sizeF2.Height) / 2f));
        DrawMod.DrawTextVic2(ref g, txt2, DrawMod.TGame.VicFont2, x + 1, num + 1, DrawMod.TGame.VicColor2, DrawMod.TGame.VicColor2Shade);
      }
      g.Clip = new Region();
    }

    public static void DrawBoxVic(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int w,
      int h,
      Color FrontC,
      Color BackC,
      bool RectMode = false)
    {
      Color color = new Color();
      color = Color.FromArgb(Math.Min((int) byte.MaxValue, (int) BackC.A), Math.Min((int) byte.MaxValue, (int) BackC.R + 55), Math.Min((int) byte.MaxValue, (int) BackC.G + 55), Math.Min((int) byte.MaxValue, (int) BackC.B + 55));
      Rectangle rect = new Rectangle(x1, y1, w, h);
      Rectangle rectangle = new Rectangle(x1, y1 + (int) Math.Round((double) h / 2.0), w, h - (int) Math.Round((double) h / 2.0));
      Color.FromArgb((int) byte.MaxValue, (int) Math.Round((double) FrontC.R * 0.75), (int) Math.Round((double) FrontC.G * 0.75), (int) Math.Round((double) FrontC.B * 0.76));
      Color.FromArgb((int) byte.MaxValue, (int) Math.Round((double) FrontC.R * 0.5), (int) Math.Round((double) FrontC.G * 0.5), (int) Math.Round((double) FrontC.B * 0.5));
      Color.FromArgb((int) byte.MaxValue, (int) FrontC.R, (int) FrontC.G, (int) FrontC.B);
      SolidBrush solidBrush = new SolidBrush(BackC);
      if (!RectMode)
        objGraphics.FillRectangle((Brush) solidBrush, rect);
      DrawMod.DrawRectangle(ref objGraphics, x1, y1, w, h, (int) FrontC.R, (int) FrontC.G, (int) FrontC.B, (int) FrontC.A);
    }

    public static void drawLine(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int x2,
      int y2,
      int r,
      int g,
      int b,
      int a,
      int widdy = 1)
    {
      Pen pen = new Pen(Color.FromArgb(a, r, g, b), (float) widdy);
      objGraphics.DrawLine(pen, x1, y1, x2, y2);
      pen.Dispose();
    }

    public static void drawLine(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int x2,
      int y2,
      Color c,
      int widdy = 1)
    {
      Pen pen = new Pen(c, (float) widdy);
      objGraphics.DrawLine(pen, x1, y1, x2, y2);
    }

    public static void drawLineDot(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int x2,
      int y2,
      Color c,
      int widdy = 1)
    {
      Pen pen = new Pen(c, (float) widdy);
      float[] numArray = new float[2]{ 1f, 2f };
      pen.DashStyle = DashStyle.Dot;
      pen.DashPattern = numArray;
      objGraphics.DrawLine(pen, x1, y1, x2, y2);
    }

    public static void drawLineDash(
      ref Graphics objGraphics,
      int x1,
      int y1,
      int x2,
      int y2,
      Color c,
      int widdy = 1)
    {
      objGraphics.DrawLine(new Pen(c, (float) widdy)
      {
        DashStyle = DashStyle.Dash
      }, x1, y1, x2, y2);
    }

    public static void drawLine2(
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

    public static void Clear(ref Graphics objgraphics, int r, int g, int b, int a = 255) => objgraphics.Clear(Color.FromArgb(a, r, g, b));

    public static void ClearTransparent(ref Graphics objgraphics) => objgraphics.Clear(Color.FromArgb(0, 0, 0, 0));

    public static void DrawTextVert(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y)
    {
      if (tfont == null)
        tfont = DrawMod.ttfont;
      SizeF sizeF1 = new SizeF();
      SizeF sizeF2 = objgraphics.MeasureString(tstring, tfont);
      Bitmap bitmap = new Bitmap((int) Math.Round((double) sizeF2.Width), (int) Math.Round((double) sizeF2.Height) + 1, PixelFormat.Format32bppPArgb);
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

    public static void DrawTextVertEasier(
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
      StringFormat format = new StringFormat();
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb(165, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
      format.FormatFlags = StringFormatFlags.DirectionVertical;
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush, (float) x, (float) y, format);
    }

    public static void DrawText(
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

    public static void DrawTextOutline(
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

    public static void DrawTextCenter(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y)
    {
      if (tfont == null)
        tfont = DrawMod.ttfont;
      SizeF sizeF1 = new SizeF();
      StringFormat stringFormat = new StringFormat();
      SizeF sizeF2 = objgraphics.MeasureString(tstring, tfont);
      objgraphics.TextContrast = 4;
      objgraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
      objgraphics.DrawString(tstring, tfont, Brushes.Black, (float) (x + 1) - sizeF2.Width / 2f, (float) (y + 1), StringFormat.GenericTypographic);
      objgraphics.DrawString(tstring, tfont, Brushes.White, (float) x - sizeF2.Width / 2f, (float) y, StringFormat.GenericTypographic);
    }

    public static void DrawTextCenterSmallLabel(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      int tcol = 0)
    {
      if (tfont == null)
        tfont = DrawMod.ttfont;
      SizeF sizeF1 = new SizeF();
      StringFormat stringFormat = new StringFormat();
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
      SolidBrush solidBrush2 = tcol != 1 ? (tcol != 2 ? (tcol != 3 ? (tcol != 4 ? (tcol != 5 ? (tcol != 11 ? (tcol != 12 ? (tcol != 13 ? (tcol != 13 ? new SolidBrush(Color.White) : new SolidBrush(Color.FromArgb((int) byte.MaxValue, 150, 150, 0))) : new SolidBrush(Color.FromArgb((int) byte.MaxValue, 100, 70, 100))) : new SolidBrush(Color.FromArgb((int) byte.MaxValue, 50, 0, 50))) : new SolidBrush(Color.FromArgb((int) byte.MaxValue, 150, 150, 150))) : new SolidBrush(Color.LightBlue)) : new SolidBrush(Color.Yellow)) : new SolidBrush(Color.Blue)) : new SolidBrush(Color.Green)) : new SolidBrush(Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 100, 100));
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

    public static void DrawTextCenterSmallLabelMultiLine(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      int tcol = 0)
    {
      string[] strArray = tstring.Split(' ');
      int num = 10;
      if (!Information.IsNothing((object) tfont))
        num = (int) Math.Round((double) tfont.Height * 0.75);
      int upperBound = strArray.GetUpperBound(0);
      for (int index = 0; index <= upperBound; ++index)
        DrawMod.DrawTextCenterSmallLabel(ref objgraphics, strArray[index], tfont, x, y - (int) Math.Round((double) (strArray.GetUpperBound(0) * num) / 2.0) + index * num, tcol);
    }

    public static void DrawText2(
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

    public static void DrawFrame2(ref Bitmap b, ref Graphics g, int x, int y, int w, int h)
    {
      if (!Information.IsNothing((object) b))
      {
        g.CompositingMode = CompositingMode.SourceCopy;
        int num1 = h - 1;
        for (int index1 = 0; index1 <= num1; ++index1)
        {
          int num2 = w - 1;
          for (int index2 = 0; index2 <= num2; ++index2)
          {
            int num3 = 0;
            if (index2 < 9 & index1 < 9 && index2 + index1 < 7)
              num3 = 1;
            if (index2 < 9 & index1 > h - 8)
            {
              int num4 = h - index1;
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
      Rectangle rectangle1 = new Rectangle(0, 0, 15, 15);
      Rectangle srcrect1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(x, y, 15, 15);
      Rectangle destrect1 = rectangle2;
      DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
      ref Graphics local3 = ref g;
      Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local4 = ref bitmap2;
      rectangle2 = new Rectangle(15, 0, 10, 15);
      Rectangle srcrect2 = rectangle2;
      rectangle1 = new Rectangle(x + 15, y, w - 30, 15);
      Rectangle destrect2 = rectangle1;
      DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
      ref Graphics local5 = ref g;
      Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local6 = ref bitmap3;
      rectangle2 = new Rectangle(25, 0, 15, 15);
      Rectangle srcrect3 = rectangle2;
      rectangle1 = new Rectangle(x + w - 15, y, 15, 15);
      Rectangle destrect3 = rectangle1;
      DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
      ref Graphics local7 = ref g;
      Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local8 = ref bitmap4;
      rectangle2 = new Rectangle(0, 12, 15, 7);
      Rectangle srcrect4 = rectangle2;
      rectangle1 = new Rectangle(x, y + 15, 15, h - 30);
      Rectangle destrect4 = rectangle1;
      DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
      ref Graphics local9 = ref g;
      bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local10 = ref bitmap4;
      rectangle2 = new Rectangle(15, 12, 10, 7);
      Rectangle srcrect5 = rectangle2;
      rectangle1 = new Rectangle(x + 15, y + 15, w - 30, h - 30);
      Rectangle destrect5 = rectangle1;
      DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
      ref Graphics local11 = ref g;
      bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local12 = ref bitmap4;
      rectangle2 = new Rectangle(25, 12, 15, 7);
      Rectangle srcrect6 = rectangle2;
      rectangle1 = new Rectangle(x + w - 15, y + 15, 15, h - 30);
      Rectangle destrect6 = rectangle1;
      DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
      ref Graphics local13 = ref g;
      bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local14 = ref bitmap4;
      rectangle2 = new Rectangle(0, 25, 15, 15);
      Rectangle srcrect7 = rectangle2;
      rectangle1 = new Rectangle(x, y + h - 15, 15, 15);
      Rectangle destrect7 = rectangle1;
      DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect7, destrect7);
      ref Graphics local15 = ref g;
      bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local16 = ref bitmap4;
      rectangle2 = new Rectangle(15, 25, 10, 15);
      Rectangle srcrect8 = rectangle2;
      rectangle1 = new Rectangle(x + 15, y + h - 15, w - 30, 15);
      Rectangle destrect8 = rectangle1;
      DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect8, destrect8);
      ref Graphics local17 = ref g;
      bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local18 = ref bitmap4;
      rectangle2 = new Rectangle(25, 25, 15, 15);
      Rectangle srcrect9 = rectangle2;
      rectangle1 = new Rectangle(x + w - 15, y + h - 15, 15, 15);
      Rectangle destrect9 = rectangle1;
      DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect9, destrect9);
    }

    public static void DrawLeather(Graphics g, int x, int y, int w, int h)
    {
      w -= 11;
      h -= 11;
      int num1 = -192;
      while (num1 < w)
      {
        num1 += 192;
        int num2 = -192;
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
          Rectangle srcrect = rectangle;
          Rectangle destrect = new Rectangle(x + num1, y + num2, rectangle.Width, rectangle.Height);
          DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
        }
      }
    }

    public static void DrawMessFrame(
      ref Bitmap b,
      ref Graphics g,
      int x,
      int y,
      int w,
      int h,
      int watermark = -1)
    {
      Rectangle rectangle1;
      if (!Information.IsNothing((object) b))
      {
        w -= 11;
        h -= 11;
        int num1 = -512;
        while (num1 < w)
        {
          num1 += 512;
          int num2 = -512;
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
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(x + num1, y + num2, rectangle2.Width, rectangle2.Height);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
          }
        }
        if (watermark > -1)
        {
          ref Graphics local3 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(watermark);
          ref Bitmap local4 = ref bitmap;
          int w1 = w;
          int h1 = h;
          int width = BitmapStore.GetWidth(watermark);
          int origh = BitmapStore.Getheight(watermark);
          DrawMod.DrawScaledColorized(ref local3, ref local4, 0, 0, w1, h1, width, origh, -0.4f, -0.4f, -0.4f, 0.15f);
        }
        g.CompositingMode = CompositingMode.SourceCopy;
        int num3 = h - 1;
        for (int index1 = 0; index1 <= num3; ++index1)
        {
          int num4 = w - 1;
          for (int index2 = 0; index2 <= num4; ++index2)
          {
            int num5 = 0;
            if (index2 < 9 & index1 < 9 && index2 + index1 < 7)
              num5 = 1;
            if (index2 < 9 & index1 > h - 8)
            {
              int num6 = h - index1;
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
      rectangle1 = new Rectangle(0, 0, 25, 25);
      Rectangle srcrect1 = rectangle1;
      Rectangle rectangle3 = new Rectangle(x, y, 25, 25);
      Rectangle destrect1 = rectangle3;
      DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect1, destrect1);
      ref Graphics local7 = ref g;
      Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local8 = ref bitmap2;
      rectangle3 = new Rectangle(25, 0, 786, 25);
      Rectangle srcrect2 = rectangle3;
      rectangle1 = new Rectangle(x + 25, y, w - 50, 25);
      Rectangle destrect2 = rectangle1;
      DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect2, destrect2);
      ref Graphics local9 = ref g;
      bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local10 = ref bitmap2;
      rectangle3 = new Rectangle(811, 0, 25, 25);
      Rectangle srcrect3 = rectangle3;
      rectangle1 = new Rectangle(x + w - 25, y, 25, 25);
      Rectangle destrect3 = rectangle1;
      DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect3, destrect3);
      ref Graphics local11 = ref g;
      bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local12 = ref bitmap2;
      rectangle3 = new Rectangle(811, 25, 25, 350);
      Rectangle srcrect4 = rectangle3;
      rectangle1 = new Rectangle(x + w - 25, y + 25, 25, h - 50);
      Rectangle destrect4 = rectangle1;
      DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect4, destrect4);
      ref Graphics local13 = ref g;
      bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local14 = ref bitmap2;
      rectangle3 = new Rectangle(811, 375, 25, 25);
      Rectangle srcrect5 = rectangle3;
      rectangle1 = new Rectangle(x + w - 25, y + h - 25, 25, 25);
      Rectangle destrect5 = rectangle1;
      DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect5, destrect5);
      ref Graphics local15 = ref g;
      bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local16 = ref bitmap2;
      rectangle3 = new Rectangle(25, 375, 786, 25);
      Rectangle srcrect6 = rectangle3;
      rectangle1 = new Rectangle(x + 25, y + h - 25, w - 50, 25);
      Rectangle destrect6 = rectangle1;
      DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect6, destrect6);
      ref Graphics local17 = ref g;
      bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local18 = ref bitmap2;
      rectangle3 = new Rectangle(0, 375, 25, 25);
      Rectangle srcrect7 = rectangle3;
      rectangle1 = new Rectangle(x, y + h - 25, 25, 25);
      Rectangle destrect7 = rectangle1;
      DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect7, destrect7);
      ref Graphics local19 = ref g;
      bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local20 = ref bitmap2;
      rectangle3 = new Rectangle(0, 25, 25, 350);
      Rectangle srcrect8 = rectangle3;
      rectangle1 = new Rectangle(x, y + 25, 25, h - 50);
      Rectangle destrect8 = rectangle1;
      DrawMod.DrawSimplePart2(ref local19, ref local20, srcrect8, destrect8);
    }

    public static void DrawMessFrameSimplePopup(
      ref Bitmap b,
      ref Graphics g,
      int x,
      int y,
      int w,
      int h,
      string HeaderString,
      int watermark = -1)
    {
      if (!Information.IsNothing((object) b))
      {
        Color c1 = Color.FromArgb((int) byte.MaxValue, 40, 80, 120);
        Color c2 = Color.FromArgb((int) byte.MaxValue, 100, 140, 180);
        DrawMod.DrawBlockGradient3(ref g, 0, 0, w, h, c1, c2);
        if (watermark > -1)
        {
          ref Graphics local1 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(watermark);
          ref Bitmap local2 = ref bitmap;
          int w1 = w;
          int h1 = h;
          int width = BitmapStore.GetWidth(watermark);
          int origh = BitmapStore.Getheight(watermark);
          DrawMod.DrawScaledColorized(ref local1, ref local2, 0, 0, w1, h1, width, origh, -0.4f, -0.4f, -0.4f, 0.15f);
        }
        g.SmoothingMode = SmoothingMode.AntiAlias;
        DrawMod.DrawBlock(ref g, 2, 27, w - 4, 38, 0, 0, 0, 128);
        SizeF sizeF = g.MeasureString(HeaderString, DrawMod.TGame.MarcFont1);
        DrawMod.DrawTextColouredMarc(ref g, HeaderString, DrawMod.TGame.MarcFont1, (int) Math.Round((double) w / 2.0 - (double) sizeF.Width / 2.0), (int) Math.Round(47.0 - (double) sizeF.Height / 2.0), Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        g.CompositingMode = CompositingMode.SourceCopy;
        int num1 = h - 1;
        for (int index1 = 0; index1 <= num1; ++index1)
        {
          int num2 = w - 1;
          for (int index2 = 0; index2 <= num2; ++index2)
          {
            int num3 = 0;
            if (index2 < 9 & index1 < 9 && index2 + index1 < 7)
              num3 = 1;
            if (index2 < 9 & index1 > h - 8)
            {
              int num4 = h - index1;
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
      Rectangle rectangle1 = new Rectangle(0, 0, 25, 25);
      Rectangle srcrect1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(x, y, 25, 25);
      Rectangle destrect1 = rectangle2;
      DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect1, destrect1);
      ref Graphics local5 = ref g;
      Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local6 = ref bitmap2;
      rectangle2 = new Rectangle(25, 0, 786, 25);
      Rectangle srcrect2 = rectangle2;
      rectangle1 = new Rectangle(x + 25, y, w - 50, 25);
      Rectangle destrect2 = rectangle1;
      DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect2, destrect2);
      ref Graphics local7 = ref g;
      Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local8 = ref bitmap3;
      rectangle2 = new Rectangle(811, 0, 25, 25);
      Rectangle srcrect3 = rectangle2;
      rectangle1 = new Rectangle(x + w - 25, y, 25, 25);
      Rectangle destrect3 = rectangle1;
      DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect3, destrect3);
      ref Graphics local9 = ref g;
      Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local10 = ref bitmap4;
      rectangle2 = new Rectangle(811, 25, 25, 350);
      Rectangle srcrect4 = rectangle2;
      rectangle1 = new Rectangle(x + w - 25, y + 25, 25, h - 50);
      Rectangle destrect4 = rectangle1;
      DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect4, destrect4);
      ref Graphics local11 = ref g;
      Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local12 = ref bitmap5;
      rectangle2 = new Rectangle(811, 375, 25, 25);
      Rectangle srcrect5 = rectangle2;
      rectangle1 = new Rectangle(x + w - 25, y + h - 25, 25, 25);
      Rectangle destrect5 = rectangle1;
      DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect5, destrect5);
      ref Graphics local13 = ref g;
      Bitmap bitmap6 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local14 = ref bitmap6;
      rectangle2 = new Rectangle(25, 375, 786, 25);
      Rectangle srcrect6 = rectangle2;
      rectangle1 = new Rectangle(x + 25, y + h - 25, w - 50, 25);
      Rectangle destrect6 = rectangle1;
      DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect6, destrect6);
      ref Graphics local15 = ref g;
      Bitmap bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local16 = ref bitmap7;
      rectangle2 = new Rectangle(0, 375, 25, 25);
      Rectangle srcrect7 = rectangle2;
      rectangle1 = new Rectangle(x, y + h - 25, 25, 25);
      Rectangle destrect7 = rectangle1;
      DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect7, destrect7);
      ref Graphics local17 = ref g;
      Bitmap bitmap8 = BitmapStore.GetBitmap(DrawMod.TGame.MARCMESFRAME);
      ref Bitmap local18 = ref bitmap8;
      rectangle2 = new Rectangle(0, 25, 25, 350);
      Rectangle srcrect8 = rectangle2;
      rectangle1 = new Rectangle(x, y + 25, 25, h - 50);
      Rectangle destrect8 = rectangle1;
      DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect8, destrect8);
    }

    public static void DrawFrame(
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
          int num1 = h - 1;
          for (int index1 = 0; index1 <= num1; ++index1)
          {
            int num2 = w - 1;
            for (int index2 = 0; index2 <= num2; ++index2)
            {
              if (x + index2 >= 0 & y + index1 >= 0 & x + index2 < w & y + index1 < h)
              {
                int num3 = 0;
                if (index2 < 9 & index1 < 9 && index2 + index1 < 7)
                  num3 = 1;
                if (index2 < 9 & index1 > h - 8)
                {
                  int num4 = h - index1;
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
      Rectangle rectangle1 = new Rectangle(0, 0, 15, 15);
      Rectangle srcrect1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(x, y, 15, 15);
      Rectangle destrect1 = rectangle2;
      DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
      ref Graphics local3 = ref g;
      Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local4 = ref bitmap2;
      rectangle2 = new Rectangle(15, 0, 10, 15);
      Rectangle srcrect2 = rectangle2;
      rectangle1 = new Rectangle(x + 15, y, w - 30, 15);
      Rectangle destrect2 = rectangle1;
      DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
      ref Graphics local5 = ref g;
      Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local6 = ref bitmap3;
      rectangle2 = new Rectangle(25, 0, 15, 15);
      Rectangle srcrect3 = rectangle2;
      rectangle1 = new Rectangle(x + w - 15, y, 15, 15);
      Rectangle destrect3 = rectangle1;
      DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
      ref Graphics local7 = ref g;
      Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local8 = ref bitmap4;
      rectangle2 = new Rectangle(0, 12, 15, 7);
      Rectangle srcrect4 = rectangle2;
      rectangle1 = new Rectangle(x, y + 15, 15, h - 30);
      Rectangle destrect4 = rectangle1;
      DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
      ref Graphics local9 = ref g;
      Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local10 = ref bitmap5;
      rectangle2 = new Rectangle(15, 12, 10, 7);
      Rectangle srcrect5 = rectangle2;
      rectangle1 = new Rectangle(x + 15, y + 15, w - 30, h - 30);
      Rectangle destrect5 = rectangle1;
      DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
      ref Graphics local11 = ref g;
      Bitmap bitmap6 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local12 = ref bitmap6;
      rectangle2 = new Rectangle(25, 12, 15, 7);
      Rectangle srcrect6 = rectangle2;
      rectangle1 = new Rectangle(x + w - 15, y + 15, 15, h - 30);
      Rectangle destrect6 = rectangle1;
      DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
      ref Graphics local13 = ref g;
      Bitmap bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local14 = ref bitmap7;
      rectangle2 = new Rectangle(0, 25, 15, 15);
      Rectangle srcrect7 = rectangle2;
      rectangle1 = new Rectangle(x, y + h - 15, 15, 15);
      Rectangle destrect7 = rectangle1;
      DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect7, destrect7);
      ref Graphics local15 = ref g;
      Bitmap bitmap8 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local16 = ref bitmap8;
      rectangle2 = new Rectangle(15, 25, 10, 15);
      Rectangle srcrect8 = rectangle2;
      rectangle1 = new Rectangle(x + 15, y + h - 15, w - 30, 15);
      Rectangle destrect8 = rectangle1;
      DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect8, destrect8);
      ref Graphics local17 = ref g;
      bitmap8 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local18 = ref bitmap8;
      rectangle2 = new Rectangle(25, 25, 15, 15);
      Rectangle srcrect9 = rectangle2;
      rectangle1 = new Rectangle(x + w - 15, y + h - 15, 15, 15);
      Rectangle destrect9 = rectangle1;
      DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect9, destrect9);
    }

    public static void DrawSimpleFrame(
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
      int width = BitmapStore.GetWidth(bitmapNr);
      int num = BitmapStore.Getheight(bitmapNr);
      ref Graphics local1 = ref g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(bitmapNr);
      ref Bitmap local2 = ref bitmap1;
      Rectangle rectangle1 = new Rectangle(0, 0, xOffset, yOffset);
      Rectangle srcrect1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(x, y, xOffset, yOffset);
      Rectangle destrect1 = rectangle2;
      DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
      ref Graphics local3 = ref g;
      Bitmap bitmap2 = BitmapStore.GetBitmap(bitmapNr);
      ref Bitmap local4 = ref bitmap2;
      rectangle2 = new Rectangle(xOffset, 0, xOffset + 10, yOffset);
      Rectangle srcrect2 = rectangle2;
      rectangle1 = new Rectangle(x + xOffset, y, w - xOffset * 2, yOffset);
      Rectangle destrect2 = rectangle1;
      DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
      ref Graphics local5 = ref g;
      Bitmap bitmap3 = BitmapStore.GetBitmap(bitmapNr);
      ref Bitmap local6 = ref bitmap3;
      rectangle2 = new Rectangle(width - xOffset, 0, xOffset, yOffset);
      Rectangle srcrect3 = rectangle2;
      rectangle1 = new Rectangle(x + w - xOffset, y, xOffset, yOffset);
      Rectangle destrect3 = rectangle1;
      DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
      ref Graphics local7 = ref g;
      Bitmap bitmap4 = BitmapStore.GetBitmap(bitmapNr);
      ref Bitmap local8 = ref bitmap4;
      rectangle2 = new Rectangle(0, yOffset, xOffset, 10);
      Rectangle srcrect4 = rectangle2;
      rectangle1 = new Rectangle(x, y + yOffset, xOffset, h - (yOffset + yOffsetBottom));
      Rectangle destrect4 = rectangle1;
      DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
      ref Graphics local9 = ref g;
      Bitmap bitmap5 = BitmapStore.GetBitmap(bitmapNr);
      ref Bitmap local10 = ref bitmap5;
      rectangle2 = new Rectangle(width - xOffset, yOffset, xOffset, 10);
      Rectangle srcrect5 = rectangle2;
      rectangle1 = new Rectangle(x + w - xOffset, y + yOffset, xOffset, h - (yOffset + yOffsetBottom));
      Rectangle destrect5 = rectangle1;
      DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
      ref Graphics local11 = ref g;
      Bitmap bitmap6 = BitmapStore.GetBitmap(bitmapNr);
      ref Bitmap local12 = ref bitmap6;
      rectangle2 = new Rectangle(0, num - yOffsetBottom, xOffset, yOffsetBottom);
      Rectangle srcrect6 = rectangle2;
      rectangle1 = new Rectangle(x, y + h - yOffsetBottom, xOffset, yOffsetBottom);
      Rectangle destrect6 = rectangle1;
      DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
      ref Graphics local13 = ref g;
      Bitmap bitmap7 = BitmapStore.GetBitmap(bitmapNr);
      ref Bitmap local14 = ref bitmap7;
      rectangle2 = new Rectangle(xOffset, num - yOffsetBottom, xOffset + 10, yOffsetBottom);
      Rectangle srcrect7 = rectangle2;
      rectangle1 = new Rectangle(x + xOffset, y + h - yOffsetBottom, w - xOffset * 2, yOffsetBottom);
      Rectangle destrect7 = rectangle1;
      DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect7, destrect7);
      ref Graphics local15 = ref g;
      Bitmap bitmap8 = BitmapStore.GetBitmap(bitmapNr);
      ref Bitmap local16 = ref bitmap8;
      rectangle2 = new Rectangle(width - xOffset, num - yOffsetBottom, xOffset, yOffsetBottom);
      Rectangle srcrect8 = rectangle2;
      rectangle1 = new Rectangle(x + w - xOffset, y + h - yOffsetBottom, xOffset, yOffsetBottom);
      Rectangle destrect8 = rectangle1;
      DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect8, destrect8);
    }

    public static void DrawTextColoured(
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

    public static void DrawTextColouredNicely(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c,
      int tTextContrast = 1)
    {
      SolidBrush solidBrush = new SolidBrush(c);
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextContrast = tTextContrast;
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush, (float) x, (float) y);
    }

    public static void DrawTextVic(
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

    public static void DrawTextVic2(
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

    public static void DrawTextVic3(
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

    public static void DrawTextColouredMarcCapped(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c,
      bool HardBlack = false,
      int maxWidth = 200)
    {
      if (Information.IsNothing((object) tstring))
        return;
      SizeF sizeF1 = new SizeF();
      StringFormat stringFormat = new StringFormat();
      for (SizeF sizeF2 = objgraphics.MeasureString(tstring, tfont); (double) sizeF2.Width > (double) maxWidth & tstring.Length > 3; sizeF2 = objgraphics.MeasureString(tstring, tfont))
      {
        int Length = (int) Math.Round((double) ((float) tstring.Length * ((float) maxWidth / sizeF2.Width))) - 1;
        if (Length < 1)
          Length = 1;
        tstring = Strings.Left(tstring, Length);
      }
      DrawMod.DrawTextColouredMarc(ref objgraphics, tstring, tfont, x, y, c, HardBlack);
    }

    public static void DrawTextColouredMarc(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c,
      bool HardBlack = false)
    {
      if (Information.IsNothing((object) tfont))
        tfont = new Font(DrawMod.TGame.FontCol.Families[1], 12f, FontStyle.Regular);
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

    public static void DrawTextColouredConsole(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c)
    {
      if (Information.IsNothing((object) tfont))
        tfont = new Font(DrawMod.TGame.FontCol.Families[1], 12f, FontStyle.Regular);
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb((int) c.A, (int) c.R, (int) c.G, (int) c.B));
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextContrast = 1;
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush, (float) x, (float) y);
    }

    public static void DrawTextColouredConsoleMultiline(
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
        tfont = new Font(DrawMod.TGame.FontCol.Families[1], 12f, FontStyle.Regular);
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb((int) c.A, (int) c.R, (int) c.G, (int) c.B));
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextContrast = 1;
      if (!centerText)
        objgraphics.DrawString(tstring, tfont, (Brush) solidBrush, (RectangleF) new Rectangle(x, y, w, h));
      else
        objgraphics.DrawString(tstring, tfont, (Brush) solidBrush, (RectangleF) new Rectangle(x, y, w, h), new StringFormat()
        {
          Alignment = StringAlignment.Center
        });
    }

    public static void DrawTextColouredConsoleCenter(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c)
    {
      if (Information.IsNothing((object) tfont))
        tfont = new Font(DrawMod.TGame.FontCol.Families[1], 12f, FontStyle.Regular);
      SizeF sizeF1 = new SizeF();
      StringFormat stringFormat = new StringFormat();
      SizeF sizeF2 = objgraphics.MeasureString(tstring, tfont);
      x = (int) Math.Round((double) ((float) x - sizeF2.Width / 2f));
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb((int) c.A, (int) c.R, (int) c.G, (int) c.B));
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextContrast = 1;
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush, (float) x, (float) y);
    }

    public static void DrawTextColouredConsoleCenterEmbossed(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c)
    {
      if (Information.IsNothing((object) tfont))
        tfont = new Font(DrawMod.TGame.FontCol.Families[1], 12f, FontStyle.Regular);
      SizeF sizeF1 = new SizeF();
      StringFormat stringFormat = new StringFormat();
      SizeF sizeF2 = objgraphics.MeasureString(tstring, tfont);
      Bitmap objBitmap = new Bitmap((int) Math.Round((double) sizeF2.Width) + 8, (int) Math.Round((double) sizeF2.Height) + 8, PixelFormat.Format32bppPArgb);
      Graphics graphics = Graphics.FromImage((Image) objBitmap);
      graphics.Clear(Color.Transparent);
      x = (int) Math.Round((double) ((float) x - sizeF2.Width / 2f));
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb((int) c.A, (int) c.R, (int) c.G, (int) c.B));
      graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      graphics.TextContrast = 1;
      graphics.DrawString(tstring, tfont, (Brush) solidBrush, 4f, 4f);
      graphics.CompositingMode = CompositingMode.SourceCopy;
      int num1 = (int) Math.Round((double) sizeF2.Width) + 8;
      int num2 = (int) Math.Round((double) sizeF2.Height) + 8;
      int alpha = 200;
      Color color1 = DrawMod.LightenColor(c, 100);
      Color color2 = DrawMod.LightenColor(c, 60);
      Color color3 = DrawMod.LightenColor(c, -100);
      Color color4 = DrawMod.LightenColor(c, -40);
      color1 = Color.FromArgb(alpha, (int) color1.R, (int) color1.G, (int) color1.B);
      color2 = Color.FromArgb(alpha, (int) color2.R, (int) color2.G, (int) color2.B);
      color3 = Color.FromArgb(alpha, (int) color3.R, (int) color3.G, (int) color3.B);
      color4 = Color.FromArgb(alpha, (int) color4.R, (int) color4.G, (int) color4.B);
      Color color5 = DrawMod.LightenColor(c, 40);
      Color color6 = DrawMod.LightenColor(c, -60);
      Color pixel1;
      Color pixel2;
      for (int y1 = num2 - 2; y1 >= 1; y1 += -1)
      {
        for (int x1 = num1 - 2; x1 >= 1; x1 += -1)
        {
          pixel1 = objBitmap.GetPixel(x1, y1);
          if ((int) pixel1.A >= alpha)
          {
            bool flag = false;
            pixel2 = objBitmap.GetPixel(x1 + 1, y1);
            if ((int) pixel2.A < alpha)
            {
              objBitmap.SetPixel(x1 + 1, y1, color3);
              flag = true;
            }
            pixel2 = objBitmap.GetPixel(x1, y1 + 1);
            if ((int) pixel2.A < alpha)
            {
              objBitmap.SetPixel(x1, y1 + 1, color3);
              flag = true;
            }
            pixel2 = objBitmap.GetPixel(x1 + 1, y1 + 1);
            if ((int) pixel2.A < alpha)
            {
              objBitmap.SetPixel(x1 + 1, y1 + 1, color4);
              flag = true;
            }
            if (flag & (int) pixel1.G == (int) c.G & (int) pixel1.R == (int) c.R & (int) pixel1.B == (int) c.B)
              objBitmap.SetPixel(x1, y1, color6);
          }
        }
      }
      int num3 = num2 - 2;
      for (int y2 = 1; y2 <= num3; ++y2)
      {
        int num4 = num1 - 2;
        for (int x2 = 1; x2 <= num4; ++x2)
        {
          pixel1 = objBitmap.GetPixel(x2, y2);
          if ((int) pixel1.A >= alpha)
          {
            bool flag = false;
            pixel2 = objBitmap.GetPixel(x2 - 1, y2);
            if ((int) pixel2.A < alpha)
              objBitmap.SetPixel(x2 - 1, y2, color1);
            pixel2 = objBitmap.GetPixel(x2, y2 - 1);
            if ((int) pixel2.A < alpha)
              objBitmap.SetPixel(x2, y2 - 1, color1);
            pixel2 = objBitmap.GetPixel(x2 - 1, y2 - 1);
            if ((int) pixel2.A < alpha)
              objBitmap.SetPixel(x2 - 1, y2 - 1, color2);
            if (flag & (int) pixel1.G == (int) c.G & (int) pixel1.R == (int) c.R & (int) pixel1.B == (int) c.B)
              objBitmap.SetPixel(x2, y2, color5);
          }
        }
      }
      graphics.CompositingMode = CompositingMode.SourceOver;
      DrawMod.DrawSimple(ref objgraphics, ref objBitmap, x - 4, y - 4);
      graphics.Dispose();
      objBitmap.Dispose();
    }

    public static void DrawTextColouredMarcCenter(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c,
      bool HardBlack = false)
    {
      if (Information.IsNothing((object) tfont))
        tfont = new Font(DrawMod.TGame.FontCol.Families[1], 12f, FontStyle.Regular);
      SizeF sizeF1 = new SizeF();
      StringFormat stringFormat = new StringFormat();
      SizeF sizeF2 = objgraphics.MeasureString(tstring, tfont);
      x = (int) Math.Round((double) ((float) x - sizeF2.Width / 2f));
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

    public static void DrawTextColouredMarcCenterCinematic(
      ref Graphics objgraphics,
      string tstring,
      Font tfont,
      int x,
      int y,
      Color c)
    {
      if (Information.IsNothing((object) tfont))
        tfont = new Font(DrawMod.TGame.FontCol.Families[1], 12f, FontStyle.Regular);
      SizeF sizeF1 = new SizeF();
      StringFormat stringFormat = new StringFormat();
      SizeF sizeF2 = objgraphics.MeasureString(tstring, tfont);
      x = (int) Math.Round((double) ((float) x - sizeF2.Width / 2f));
      SolidBrush solidBrush = new SolidBrush(c);
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush, (float) x, (float) y);
    }

    public static void DrawTextColouredMarcCounter(
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

    public static void DrawTextColouredFuzzy(
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

    public static void DrawTextColouredOutline(
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

    public static void DrawButton(
      ref Graphics g,
      int x,
      int y,
      int width,
      int height,
      bool HighLight,
      string ttext,
      int plusy = 0,
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
        Rectangle rectangle1 = new Rectangle(7, 0, 220, 35);
        Rectangle srcrect1 = rectangle1;
        Rectangle rectangle2 = new Rectangle(x + 7, y + 0, width - 14, height);
        Rectangle destrect1 = rectangle2;
        DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
        ref Graphics local3 = ref g;
        Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
        ref Bitmap local4 = ref bitmap2;
        rectangle2 = new Rectangle(0, 0, 7, 35);
        Rectangle srcrect2 = rectangle2;
        rectangle1 = new Rectangle(x + 0, y + 0, 7, height);
        Rectangle destrect2 = rectangle1;
        DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
        ref Graphics local5 = ref g;
        Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
        ref Bitmap local6 = ref bitmap3;
        rectangle2 = new Rectangle(228, 0, 7, 35);
        Rectangle srcrect3 = rectangle2;
        rectangle1 = new Rectangle(x + width - 7, y + 0, 7, height);
        Rectangle destrect3 = rectangle1;
        DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
        c1 = Color.Black;
        c2 = Color.White;
      }
      else
      {
        ref Graphics local7 = ref g;
        Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
        ref Bitmap local8 = ref bitmap4;
        Rectangle rectangle3 = new Rectangle(7, 0, 220, 35);
        Rectangle srcrect4 = rectangle3;
        Rectangle rectangle4 = new Rectangle(x + 7, y + 0, width - 14, height);
        Rectangle destrect4 = rectangle4;
        DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
        ref Graphics local9 = ref g;
        Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
        ref Bitmap local10 = ref bitmap5;
        rectangle3 = new Rectangle(0, 0, 7, 35);
        Rectangle srcrect5 = rectangle3;
        rectangle4 = new Rectangle(x + 0, y + 0, 7, height);
        Rectangle destrect5 = rectangle4;
        DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
        ref Graphics local11 = ref g;
        Bitmap bitmap6 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
        ref Bitmap local12 = ref bitmap6;
        rectangle3 = new Rectangle(228, 0, 7, 35);
        Rectangle srcrect6 = rectangle3;
        rectangle4 = new Rectangle(x + width - 7, y + 0, 7, height);
        Rectangle destrect6 = rectangle4;
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
        c2 = Color.FromArgb((int) byte.MaxValue, 128, 128, 128);
      }
      SizeF sizeF1 = new SizeF();
      Font font = DrawMod.TGame.VicFont2;
      string str = ttext;
      if (!Information.IsNothing((object) customfont))
        font = customfont;
      int num1;
      int num2 = num1 - 2;
      --plusy;
      SizeF sizeF2 = g.MeasureString(str, font);
      int x1 = (int) Math.Round((double) ((float) x + (float) (((double) width - (double) sizeF2.Width) / 2.0) + (float) num2));
      int y1 = (int) Math.Round((double) ((float) ((double) y + ((double) height - (double) sizeF2.Height) / 2.0 - 1.0) + (float) plusy));
      if (width > 50)
        y1 -= 2;
      DrawMod.DrawTextColoured(ref g, str, font, x1, y1, c1);
      sizeF2 = g.MeasureString(str, font);
      int x2 = (int) Math.Round((double) ((float) x + (float) (((double) width - (double) sizeF2.Width) / 2.0) + (float) num2));
      int y2 = (int) Math.Round((double) ((float) ((double) y + ((double) height - (double) sizeF2.Height) / 2.0 + 1.0) + (float) plusy));
      if (width > 50)
        y2 -= 2;
      DrawMod.DrawTextColoured(ref g, str, font, x2, y2, c1);
      sizeF2 = g.MeasureString(str, font);
      int x3 = (int) Math.Round((double) ((float) ((double) x + ((double) width - (double) sizeF2.Width) / 2.0 + 1.0) + (float) num2));
      int y3 = (int) Math.Round((double) ((float) y + (float) (((double) height - (double) sizeF2.Height) / 2.0) + (float) plusy));
      if (width > 50)
        y3 -= 2;
      DrawMod.DrawTextColoured(ref g, str, font, x3, y3, c1);
      sizeF2 = g.MeasureString(str, font);
      int x4 = (int) Math.Round((double) ((float) ((double) x + ((double) width - (double) sizeF2.Width) / 2.0 - 1.0) + (float) num2));
      int y4 = (int) Math.Round((double) ((float) y + (float) (((double) height - (double) sizeF2.Height) / 2.0) + (float) plusy));
      if (width > 50)
        y4 -= 2;
      DrawMod.DrawTextColoured(ref g, str, font, x4, y4, c1);
      sizeF2 = g.MeasureString(str, font);
      int x5 = (int) Math.Round((double) ((float) x + (float) (((double) width - (double) sizeF2.Width) / 2.0) + (float) num2));
      int y5 = (int) Math.Round((double) ((float) y + (float) (((double) height - (double) sizeF2.Height) / 2.0) + (float) plusy));
      if (width > 50)
        y5 -= 2;
      DrawMod.DrawTextColoured(ref g, str, font, x5, y5, c2);
    }

    public static void DrawFrame(ref Bitmap b, ref Graphics g, int x, int y, int w, int h)
    {
      if (!Information.IsNothing((object) b))
      {
        g.CompositingMode = CompositingMode.SourceCopy;
        int num1 = h - 1;
        for (int index1 = 0; index1 <= num1; ++index1)
        {
          int num2 = w - 1;
          for (int index2 = 0; index2 <= num2; ++index2)
          {
            int num3 = 0;
            if (index2 < 9 & index1 < 9 && index2 + index1 < 9)
              num3 = 1;
            if (index2 < 9 & index1 > h - 8)
            {
              int num4 = h - index1;
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
      Rectangle rectangle1 = new Rectangle(0, 0, 15, 15);
      Rectangle srcrect1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(x, y, 15, 15);
      Rectangle destrect1 = rectangle2;
      DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
      ref Graphics local3 = ref g;
      Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local4 = ref bitmap2;
      rectangle2 = new Rectangle(15, 0, 310, 15);
      Rectangle srcrect2 = rectangle2;
      rectangle1 = new Rectangle(x + 15, y, w - 30, 15);
      Rectangle destrect2 = rectangle1;
      DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
      ref Graphics local5 = ref g;
      Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local6 = ref bitmap3;
      rectangle2 = new Rectangle(393, 0, 15, 15);
      Rectangle srcrect3 = rectangle2;
      rectangle1 = new Rectangle(x + w - 15, y, 15, 15);
      Rectangle destrect3 = rectangle1;
      DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
      ref Graphics local7 = ref g;
      Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local8 = ref bitmap4;
      rectangle2 = new Rectangle(0, 12, 15, 7);
      Rectangle srcrect4 = rectangle2;
      rectangle1 = new Rectangle(x, y + 15, 15, h - 30);
      Rectangle destrect4 = rectangle1;
      DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
      ref Graphics local9 = ref g;
      bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local10 = ref bitmap4;
      rectangle2 = new Rectangle(15, 12, 310, 7);
      Rectangle srcrect5 = rectangle2;
      rectangle1 = new Rectangle(x + 15, y + 15, w - 30, h - 30);
      Rectangle destrect5 = rectangle1;
      DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
      ref Graphics local11 = ref g;
      bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local12 = ref bitmap4;
      rectangle2 = new Rectangle(393, 12, 15, 7);
      Rectangle srcrect6 = rectangle2;
      rectangle1 = new Rectangle(x + w - 15, y + 15, 15, h - 30);
      Rectangle destrect6 = rectangle1;
      DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
      ref Graphics local13 = ref g;
      bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local14 = ref bitmap4;
      rectangle2 = new Rectangle(0, 33, 15, 15);
      Rectangle srcrect7 = rectangle2;
      rectangle1 = new Rectangle(x, y + h - 15, 15, 15);
      Rectangle destrect7 = rectangle1;
      DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect7, destrect7);
      ref Graphics local15 = ref g;
      bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local16 = ref bitmap4;
      rectangle2 = new Rectangle(15, 33, 310, 15);
      Rectangle srcrect8 = rectangle2;
      rectangle1 = new Rectangle(x + 15, y + h - 15, w - 30, 15);
      Rectangle destrect8 = rectangle1;
      DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect8, destrect8);
      ref Graphics local17 = ref g;
      bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.FRAME1);
      ref Bitmap local18 = ref bitmap4;
      rectangle2 = new Rectangle(393, 33, 15, 15);
      Rectangle srcrect9 = rectangle2;
      rectangle1 = new Rectangle(x + w - 15, y + h - 15, 15, 15);
      Rectangle destrect9 = rectangle1;
      DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect9, destrect9);
    }

    public static void DrawPaperSheet(ref Graphics g, int x, int y, int w, int h)
    {
      ref Graphics local1 = ref g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
      ref Bitmap local2 = ref bitmap1;
      Rectangle rectangle1 = new Rectangle(0, 0, 15, 15);
      Rectangle srcrect1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(x, y, 15, 15);
      Rectangle destrect1 = rectangle2;
      DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
      ref Graphics local3 = ref g;
      Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
      ref Bitmap local4 = ref bitmap2;
      rectangle2 = new Rectangle(15, 0, 310, 15);
      Rectangle srcrect2 = rectangle2;
      rectangle1 = new Rectangle(x + 15, y, w - 30, 15);
      Rectangle destrect2 = rectangle1;
      DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
      ref Graphics local5 = ref g;
      Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
      ref Bitmap local6 = ref bitmap3;
      rectangle2 = new Rectangle(325, 0, 15, 15);
      Rectangle srcrect3 = rectangle2;
      rectangle1 = new Rectangle(x + w - 15, y, 15, 15);
      Rectangle destrect3 = rectangle1;
      DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
      int num;
      for (num = 15; num < h - 25; num += 15)
      {
        ref Graphics local7 = ref g;
        Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
        ref Bitmap local8 = ref bitmap4;
        rectangle2 = new Rectangle(0, 0, 15, 15);
        Rectangle srcrect4 = rectangle2;
        rectangle1 = new Rectangle(x, num + y, 15, 15);
        Rectangle destrect4 = rectangle1;
        DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
        ref Graphics local9 = ref g;
        Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
        ref Bitmap local10 = ref bitmap5;
        rectangle2 = new Rectangle(15, 7, 310, 15);
        Rectangle srcrect5 = rectangle2;
        rectangle1 = new Rectangle(x + 15, num + y, w - 30, 15);
        Rectangle destrect5 = rectangle1;
        DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
        ref Graphics local11 = ref g;
        Bitmap bitmap6 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
        ref Bitmap local12 = ref bitmap6;
        rectangle2 = new Rectangle(325, 7, 15, 15);
        Rectangle srcrect6 = rectangle2;
        rectangle1 = new Rectangle(x + w - 15, num + y, 15, 15);
        Rectangle destrect6 = rectangle1;
        DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
      }
      int height = h - 6 - num;
      if (height > 0)
      {
        ref Graphics local13 = ref g;
        Bitmap bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
        ref Bitmap local14 = ref bitmap7;
        rectangle2 = new Rectangle(0, 0, 15, 15);
        Rectangle srcrect7 = rectangle2;
        rectangle1 = new Rectangle(x, num + y, 15, height);
        Rectangle destrect7 = rectangle1;
        DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect7, destrect7);
        ref Graphics local15 = ref g;
        Bitmap bitmap8 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
        ref Bitmap local16 = ref bitmap8;
        rectangle2 = new Rectangle(15, 7, 310, 15);
        Rectangle srcrect8 = rectangle2;
        rectangle1 = new Rectangle(x + 15, num + y, w - 30, height);
        Rectangle destrect8 = rectangle1;
        DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect8, destrect8);
        ref Graphics local17 = ref g;
        Bitmap bitmap9 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
        ref Bitmap local18 = ref bitmap9;
        rectangle2 = new Rectangle(325, 7, 15, 15);
        Rectangle srcrect9 = rectangle2;
        rectangle1 = new Rectangle(x + w - 15, num + y, 15, height);
        Rectangle destrect9 = rectangle1;
        DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect9, destrect9);
      }
      ref Graphics local19 = ref g;
      Bitmap bitmap10 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
      ref Bitmap local20 = ref bitmap10;
      rectangle2 = new Rectangle(15, 34, 310, 6);
      Rectangle srcrect10 = rectangle2;
      rectangle1 = new Rectangle(x + 15, y + h - 6, w - 30, 6);
      Rectangle destrect10 = rectangle1;
      DrawMod.DrawSimplePart2(ref local19, ref local20, srcrect10, destrect10);
      ref Graphics local21 = ref g;
      Bitmap bitmap11 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
      ref Bitmap local22 = ref bitmap11;
      rectangle2 = new Rectangle(0, 34, 15, 6);
      Rectangle srcrect11 = rectangle2;
      rectangle1 = new Rectangle(x, y + h - 6, 15, 6);
      Rectangle destrect11 = rectangle1;
      DrawMod.DrawSimplePart2(ref local21, ref local22, srcrect11, destrect11);
      ref Graphics local23 = ref g;
      Bitmap bitmap12 = BitmapStore.GetBitmap(DrawMod.TGame.PAPER1);
      ref Bitmap local24 = ref bitmap12;
      rectangle2 = new Rectangle(325, 34, 15, 6);
      Rectangle srcrect12 = rectangle2;
      rectangle1 = new Rectangle(x + w - 15, y + h - 6, 15, 6);
      Rectangle destrect12 = rectangle1;
      DrawMod.DrawSimplePart2(ref local23, ref local24, srcrect12, destrect12);
    }

    public static void DrawTextColouredB(
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
      DrawMod.DrawBlock(ref objgraphics, x, y, (int) Math.Round((double) sizeF.Width), (int) Math.Round((double) sizeF.Height), (int) bc.R, (int) bc.G, (int) bc.B, (int) bc.A);
      objgraphics.DrawString(tstring, tfont, (Brush) solidBrush, (float) x, (float) y);
    }

    public static int InvColor(int colval)
    {
      if (colval > (int) sbyte.MaxValue)
        colval -= 64;
      else
        colval += 64;
      return colval;
    }

    public static int InvColor2(int colval)
    {
      if (colval > (int) sbyte.MaxValue)
        colval -= 128;
      else
        colval += 128;
      return colval;
    }

    public static Color LightenColor(Color col, int ammount)
    {
      int r = (int) col.R;
      int g = (int) col.G;
      int b = (int) col.B;
      int red = r + ammount;
      int green = g + ammount;
      int blue = b + ammount;
      if (red > (int) byte.MaxValue)
        red = (int) byte.MaxValue;
      if (green > (int) byte.MaxValue)
        green = (int) byte.MaxValue;
      if (blue > (int) byte.MaxValue)
        blue = (int) byte.MaxValue;
      if (red < 0)
        red = 0;
      if (green < 0)
        green = 0;
      if (blue < 0)
        blue = 0;
      col = Color.FromArgb((int) col.A, red, green, blue);
      return col;
    }

    public static Rectangle GetRectForTab(int tabnr, bool returnoffset = false)
    {
      Rectangle rectForTab = new Rectangle();
      int x;
      int width;
      int height;
      if (tabnr == 8)
      {
        x = (int) Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 - 158.0) - 300;
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
        x = (int) Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 + 158.0) + 75;
        width = 1240;
        height = DrawMod.TGame.ScreenHeight - 388;
        if (DrawMod.TGame.EditObj.GuiDown)
          height += 222;
        if (DrawMod.TGame.EditObj.RightDown)
          width += 185;
      }
      if (tabnr == 12)
      {
        x = (int) Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 + 158.0) + 150;
        width = 1240;
        height = DrawMod.TGame.ScreenHeight - 388;
        if (DrawMod.TGame.EditObj.GuiDown)
          height += 222;
        if (DrawMod.TGame.EditObj.RightDown)
          width += 185;
      }
      if (tabnr == 13)
      {
        x = (int) Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 - 158.0) - 300;
        width = 1240;
        height = DrawMod.TGame.ScreenHeight - 388;
        if (DrawMod.TGame.EditObj.GuiDown)
          height += 222;
        if (DrawMod.TGame.EditObj.RightDown)
          width += 185;
      }
      if (tabnr == 9)
      {
        x = (int) Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 + 158.0) + 225;
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
        x = (int) Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 - 158.0) - 225;
        width = 680;
        height = 380;
      }
      if (tabnr == 2)
      {
        x = (int) Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 - 158.0) - 150;
        width = DrawMod.TGame.ScreenWidth - 144;
        if (width > 1600)
          width = 1600;
        height = DrawMod.TGame.ScreenHeight - 388;
      }
      if (tabnr == 3)
      {
        x = (int) Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 - 158.0) - 75;
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
        x = (int) Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 + 158.0) + 0;
        width = DrawMod.TGame.ScreenWidth - 144;
        if (width > 880)
          width = 880;
        height = DrawMod.TGame.ScreenHeight - 388;
      }
      if (tabnr == 5)
      {
        x = DrawMod.TGame.Data.Product < 7 ? (int) Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 + 158.0) + 75 : (int) Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 + 158.0) + 0;
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
        x = DrawMod.TGame.Data.Product < 6 ? (int) Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 + 158.0) + 150 : (int) Math.Round((double) DrawMod.TGame.ScreenWidth / 2.0 - 158.0) - 75;
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
            width = (int) Math.Round((double) height * 1.8);
        }
        else if (DrawMod.TGame.Data.Product >= 6)
        {
          float num1 = (float) ((double) DrawMod.TGame.Data.MapObj[0].MapHeight / (double) DrawMod.TGame.Data.MapObj[0].MapWidth * (53.0 / 64.0));
          float num2 = (float) (height - 40) / (float) (width - 310);
          if ((double) num1 < 1.0 & (double) num1 < (double) num2)
          {
            int num3 = (int) Math.Round((double) ((float) (height - 40) * (num2 - num1)));
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
          x = (int) Math.Round((double) x - (double) width / 2.0);
      }
      else if (tabnr != 107 & tabnr != 7 & tabnr != 8)
        x = (int) Math.Round((double) x - (double) width / 2.0);
      int num4 = x;
      int num5 = 50;
      int num6 = 50;
      int num7 = 0;
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
          rectForTab = new Rectangle(num4 - x, 0, 0, 0);
        }
        else
        {
          rectForTab = new Rectangle(num4 - x, 0, 0, 0);
          if (tabnr == 8)
            rectForTab.X += 300;
        }
        return rectForTab;
      }
      rectForTab = new Rectangle(x, 75, width, height);
      return rectForTab;
    }

    public static Rectangle DrawBackTab(Graphics g, int w, int h, string s, int tabnr)
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
        rectangle1 = new Rectangle(0, 0, 16, 32);
        Rectangle srcrect1 = rectangle1;
        rectangle2 = new Rectangle(0, 0, 16, 32);
        Rectangle destrect1 = rectangle2;
        DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
        ref Graphics local3 = ref g;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
        ref Bitmap local4 = ref bitmap;
        rectangle2 = new Rectangle(170, 0, 16, 32);
        Rectangle srcrect2 = rectangle2;
        rectangle1 = new Rectangle(w - 16, 0, 16, 32);
        Rectangle destrect2 = rectangle1;
        DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
        int width = 32;
        for (int x = 16; x < w - 16; x += 32)
        {
          if (x + width > w - 16)
            width = w - 16 - x;
          ref Graphics local5 = ref g;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
          ref Bitmap local6 = ref bitmap;
          rectangle2 = new Rectangle(16, 0, 32, 32);
          Rectangle srcrect3 = rectangle2;
          rectangle1 = new Rectangle(x, 0, width, 32);
          Rectangle destrect3 = rectangle1;
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
        rectangle2 = new Rectangle(0, 20, 8, height);
        Rectangle srcrect4 = rectangle2;
        rectangle1 = new Rectangle(0, y, 8, height);
        Rectangle destrect4 = rectangle1;
        DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
        ref Graphics local9 = ref g;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
        ref Bitmap local10 = ref bitmap;
        rectangle2 = new Rectangle(170, 20, 16, height);
        Rectangle srcrect5 = rectangle2;
        rectangle1 = new Rectangle(w - 16, y, 16, height);
        Rectangle destrect5 = rectangle1;
        DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
        int width = 160;
        for (int x = 8; x < w; x += 160)
        {
          if (x + width > w - 16)
            width = w - 16 - x;
          ref Graphics local11 = ref g;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
          ref Bitmap local12 = ref bitmap;
          rectangle2 = new Rectangle(10, 20, width, height);
          Rectangle srcrect6 = rectangle2;
          rectangle1 = new Rectangle(x, y, width, height);
          Rectangle destrect6 = rectangle1;
          DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
        }
      }
      if (tabnr > -1)
      {
        rectForTab.X += (int) Math.Round((double) w / 2.0);
        if (rectForTab.X < 16)
          rectForTab.X = 16;
        rectForTab.Y = h - 32;
        rectForTab.Width = 75;
        rectForTab.Height = 32;
        ref Graphics local13 = ref g;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
        ref Bitmap local14 = ref bitmap;
        rectangle2 = new Rectangle(55, 122, 75, 32);
        Rectangle srcrect7 = rectangle2;
        Rectangle destrect7 = rectForTab;
        DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect7, destrect7);
        ref Graphics local15 = ref g;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
        ref Bitmap local16 = ref bitmap;
        rectangle2 = new Rectangle(0, 122, 16, 32);
        Rectangle srcrect8 = rectangle2;
        rectangle1 = new Rectangle(0, h - 32, 16, 32);
        Rectangle destrect8 = rectangle1;
        DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect8, destrect8);
        ref Graphics local17 = ref g;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
        ref Bitmap local18 = ref bitmap;
        rectangle2 = new Rectangle(171, 122, 16, 32);
        Rectangle srcrect9 = rectangle2;
        rectangle1 = new Rectangle(w - 16, h - 32, 16, 32);
        Rectangle destrect9 = rectangle1;
        DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect9, destrect9);
        int width1 = 32;
        for (int x = 16; x < rectForTab.X; x += 32)
        {
          if (x + width1 > rectForTab.X)
            width1 = rectForTab.X - x;
          ref Graphics local19 = ref g;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
          ref Bitmap local20 = ref bitmap;
          rectangle2 = new Rectangle(16, 122, 32, 32);
          Rectangle srcrect10 = rectangle2;
          rectangle1 = new Rectangle(x, h - 32, width1, 32);
          Rectangle destrect10 = rectangle1;
          DrawMod.DrawSimplePart2(ref local19, ref local20, srcrect10, destrect10);
        }
        int width2 = 32;
        for (int x = rectForTab.X + rectForTab.Width; x < w - 16; x += 32)
        {
          if (x + width2 > w - 16)
            width2 = w - 16 - x;
          ref Graphics local21 = ref g;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
          ref Bitmap local22 = ref bitmap;
          rectangle2 = new Rectangle(16, 122, 32, 32);
          Rectangle srcrect11 = rectangle2;
          rectangle1 = new Rectangle(x, h - 32, width2, 32);
          Rectangle destrect11 = rectangle1;
          DrawMod.DrawSimplePart2(ref local21, ref local22, srcrect11, destrect11);
        }
        SizeF sizeF = g.MeasureString(s, DrawMod.TGame.MarcFont4);
        int num = 3;
        if (DrawMod.TGame.Data.Product == 7)
          num += 7;
        DrawMod.DrawTextColouredMarc(ref g, s, DrawMod.TGame.MarcFont4, rectForTab.X + 15 + (int) Math.Round(((double) (rectForTab.Width - 30) - (double) sizeF.Width) / 2.0), rectForTab.Y + num, Color.White);
      }
      else
      {
        ref Graphics local23 = ref g;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
        ref Bitmap local24 = ref bitmap;
        rectangle2 = new Rectangle(0, 122, 16, 32);
        Rectangle srcrect12 = rectangle2;
        rectangle1 = new Rectangle(0, h - 32, 16, 32);
        Rectangle destrect12 = rectangle1;
        DrawMod.DrawSimplePart2(ref local23, ref local24, srcrect12, destrect12);
        ref Graphics local25 = ref g;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
        ref Bitmap local26 = ref bitmap;
        rectangle2 = new Rectangle(171, 122, 16, 32);
        Rectangle srcrect13 = rectangle2;
        rectangle1 = new Rectangle(w - 16, h - 32, 16, 32);
        Rectangle destrect13 = rectangle1;
        DrawMod.DrawSimplePart2(ref local25, ref local26, srcrect13, destrect13);
        int width3 = 32;
        for (int x = 16; (double) x < (double) w / 2.0; x += 32)
        {
          if ((double) (x + width3) > (double) w / 2.0)
            width3 = (int) Math.Round((double) w / 2.0 - (double) x);
          ref Graphics local27 = ref g;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
          ref Bitmap local28 = ref bitmap;
          rectangle2 = new Rectangle(16, 122, 32, 32);
          Rectangle srcrect14 = rectangle2;
          rectangle1 = new Rectangle(x, h - 32, width3, 32);
          Rectangle destrect14 = rectangle1;
          DrawMod.DrawSimplePart2(ref local27, ref local28, srcrect14, destrect14);
        }
        int width4 = 32;
        for (int x = (int) Math.Round((double) w / 2.0); x < w - 16; x += 32)
        {
          if (x + width4 > w - 16)
            width4 = w - 16 - x;
          ref Graphics local29 = ref g;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.MARCTAB);
          ref Bitmap local30 = ref bitmap;
          rectangle2 = new Rectangle(16, 122, 32, 32);
          Rectangle srcrect15 = rectangle2;
          rectangle1 = new Rectangle(x, h - 32, width4, 32);
          Rectangle destrect15 = rectangle1;
          DrawMod.DrawSimplePart2(ref local29, ref local30, srcrect15, destrect15);
        }
      }
      return rectForTab;
    }

    public static int GetWidthForMiniMap()
    {
      int widthForMiniMap = DrawMod.TGame.Data.MapObj[DrawMod.TGame.EditObj.MapSelected].MapWidth <= DrawMod.TGame.Data.MapObj[DrawMod.TGame.EditObj.MapSelected].MapHeight ? 200 : (int) Math.Round(200.0 * ((double) DrawMod.TGame.Data.MapObj[DrawMod.TGame.EditObj.MapSelected].MapWidth / (double) DrawMod.TGame.Data.MapObj[DrawMod.TGame.EditObj.MapSelected].MapHeight));
      if (widthForMiniMap > 300)
        widthForMiniMap = 300;
      return widthForMiniMap;
    }

    public static void DrawOfficerATG(Graphics g, int his, int x, int y, int w, int h)
    {
      int commanderSpriteId = DrawMod.TGame.Data.HistoricalUnitObj[his].CommanderSpriteID;
      if (commanderSpriteId <= -1)
        return;
      int hqSpriteNr = DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.HistoricalUnitObj[his].TempRegime].HQSpriteNr;
      ref Graphics local1 = ref g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(hqSpriteNr, 1);
      ref Bitmap local2 = ref bitmap1;
      Rectangle srcrect = new Rectangle(24, 8, 25, 30);
      Rectangle destrect = new Rectangle(x, y, w, h);
      DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
      int red = DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.HistoricalUnitObj[his].TempRegime].Red;
      int green = DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.HistoricalUnitObj[his].TempRegime].Green;
      int blue = DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.HistoricalUnitObj[his].TempRegime].Blue;
      DrawMod.DrawBlockGradient2(ref g, x, y, w, h, Color.FromArgb(64, (int) Math.Round((double) red / 2.0), (int) Math.Round((double) green / 2.0), (int) Math.Round((double) blue / 2.0)), Color.FromArgb(176, (int) Math.Round((double) red / 2.0), (int) Math.Round((double) green / 2.0), (int) Math.Round((double) blue / 2.0)));
      DrawMod.DrawBlockGradient3(ref g, x, y, w, h, Color.FromArgb(64, 0, 0, 0), Color.FromArgb(176, 0, 0, 0));
      ref Graphics local3 = ref g;
      Bitmap bitmap2 = BitmapStore.GetBitmap(commanderSpriteId);
      ref Bitmap local4 = ref bitmap2;
      int x1 = x;
      int y1 = y;
      int w1 = w;
      int h1 = h;
      int width = BitmapStore.GetWidth(commanderSpriteId);
      int origh = BitmapStore.Getheight(commanderSpriteId);
      double r = (double) (int) Math.Round((double) (red + 80) / 512.0);
      double g1 = (double) (int) Math.Round((double) (green + 200) / 512.0);
      double b = (double) (int) Math.Round((double) (blue + 80) / 512.0);
      DrawMod.DrawScaledColorized2(ref local3, ref local4, x1, y1, w1, h1, width, origh, (float) r, (float) g1, (float) b, 1f);
      if (DrawMod.TGame.Data.HistoricalUnitObj[his].OverdrawSpriteID > -1)
      {
        int overdrawSpriteId = DrawMod.TGame.Data.HistoricalUnitObj[his].OverdrawSpriteID;
        ref Graphics local5 = ref g;
        Bitmap bitmap3 = BitmapStore.GetBitmap(overdrawSpriteId);
        ref Bitmap local6 = ref bitmap3;
        int x2 = x;
        int y2 = y;
        int w2 = w;
        int h2 = h;
        DrawMod.DrawScaled(ref local5, ref local6, x2, y2, w2, h2, true);
      }
      DrawMod.DrawRectangle(ref g, x, y, w, h, (int) DrawMod.TGame.VicColor3.R, (int) DrawMod.TGame.VicColor3.G, (int) DrawMod.TGame.VicColor3.B, (int) DrawMod.TGame.VicColor3.A);
    }

    public static void DrawOfficer(Graphics g, int his, int x, int y, int w, int h)
    {
      int commanderSpriteId = DrawMod.TGame.Data.HistoricalUnitObj[his].CommanderSpriteID;
      if (commanderSpriteId <= -1)
        return;
      if (BitmapStore.GetWidth(commanderSpriteId) > w & w != -1)
      {
        ref Graphics local1 = ref g;
        Bitmap bitmap1 = BitmapStore.GetBitmap(commanderSpriteId);
        ref Bitmap local2 = ref bitmap1;
        int x1 = x;
        int y1 = y;
        int w1 = w;
        int h1 = h;
        DrawMod.DrawScaled(ref local1, ref local2, x1, y1, w1, h1);
        if (DrawMod.TGame.Data.HistoricalUnitObj[his].OverdrawSpriteID <= -1)
          return;
        int overdrawSpriteId = DrawMod.TGame.Data.HistoricalUnitObj[his].OverdrawSpriteID;
        if ((double) DrawMod.TGame.Data.RuleVar[839] == 1.0)
        {
          ref Graphics local3 = ref g;
          Bitmap bitmap2 = BitmapStore.GetBitmap(overdrawSpriteId);
          ref Bitmap local4 = ref bitmap2;
          Rectangle srcrect = new Rectangle(0, 0, BitmapStore.GetWidth(overdrawSpriteId), BitmapStore.Getheight(overdrawSpriteId));
          Rectangle destrect = new Rectangle(x, y, w, h);
          DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect, destrect);
        }
        else
        {
          ref Graphics local5 = ref g;
          Bitmap bitmap3 = BitmapStore.GetBitmap(overdrawSpriteId);
          ref Bitmap local6 = ref bitmap3;
          int x2 = x;
          int y2 = y;
          int w2 = w;
          int h2 = h;
          DrawMod.DrawScaled(ref local5, ref local6, x2, y2, w2, h2);
        }
      }
      else
      {
        ref Graphics local7 = ref g;
        Bitmap bitmap4 = BitmapStore.GetBitmap(commanderSpriteId);
        ref Bitmap local8 = ref bitmap4;
        int x3 = x;
        int y3 = y;
        DrawMod.DrawSimple(ref local7, ref local8, x3, y3);
        if (DrawMod.TGame.Data.HistoricalUnitObj[his].OverdrawSpriteID <= -1)
          return;
        int overdrawSpriteId = DrawMod.TGame.Data.HistoricalUnitObj[his].OverdrawSpriteID;
        ref Graphics local9 = ref g;
        Bitmap bitmap5 = BitmapStore.GetBitmap(overdrawSpriteId);
        ref Bitmap local10 = ref bitmap5;
        int x4 = x;
        int y4 = y;
        DrawMod.DrawSimple(ref local9, ref local10, x4, y4);
      }
    }

    public static void DrawTutback(
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
      int backtut = DrawMod.TGame.BACKTUT;
      y -= 3;
      h += 3;
      if (!HideOff)
        w += 100;
      if (w > DrawMod.TGame.ScreenWidth - 10)
        w = DrawMod.TGame.ScreenWidth - 10;
      if (!HideOff & h < 130)
        h = 130;
      int width1 = BitmapStore.GetWidth(backtut);
      int num1 = BitmapStore.Getheight(backtut);
      r = 128;
      gr = 128;
      b = 128;
      a = (int) byte.MaxValue;
      int num2 = (int) Math.Round(Conversion.Int((double) w / (double) width1));
      for (int index1 = 0; index1 <= num2; ++index1)
      {
        int num3 = (int) Math.Round(Conversion.Int((double) h / (double) num1));
        for (int index2 = 0; index2 <= num3; ++index2)
        {
          int width2 = index1 * w + width1;
          int height = index2 * h + num1;
          int x1 = x + index1 * width1;
          int y1 = y + index2 * num1;
          if (x1 + width2 - x > w)
            width2 -= x1 + width2 - x - w;
          if (y1 + height - y > h)
            height -= y1 + height - y - h;
          ref Graphics local1 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(backtut);
          ref Bitmap local2 = ref bitmap;
          Rectangle srcrect = new Rectangle(0, 0, width2, height);
          Rectangle destrect = new Rectangle(x1, y1, width2, height);
          DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
        }
      }
      DrawMod.DrawRectangle(ref g, x - 1, y - 1, w + 1, h + 1, (int) Math.Round((double) r / 2.0), (int) Math.Round((double) gr / 2.0), (int) Math.Round((double) b / 2.0), (int) byte.MaxValue);
      DrawMod.DrawRectangle(ref g, x, y, w - 1, h - 1, Conversion.Int(r * 2), Conversion.Int(gr * 2), Conversion.Int(b * 2), (int) byte.MaxValue);
      DrawMod.DrawRectangle(ref g, x + 3, y + 3, w - 7, h - 7, (int) Math.Round((double) r * 0.2), (int) Math.Round((double) gr * 0.2), (int) Math.Round((double) b * 0.2), (int) byte.MaxValue);
      DrawMod.DrawRectangle(ref g, x + 1, y + 1, w - 3, h - 3, (int) byte.MaxValue, 0, 0, (int) byte.MaxValue);
      DrawMod.DrawRectangle(ref g, x + 2, y + 2, w - 5, h - 5, (int) byte.MaxValue, 0, 0, (int) byte.MaxValue);
      if (HideOff)
        return;
      ref Graphics local3 = ref g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.MARCOFFICER);
      ref Bitmap local4 = ref bitmap1;
      int x2 = x + w - 95;
      int y2 = y + 10;
      DrawMod.DrawScaled(ref local3, ref local4, x2, y2, 90, 98);
      DrawMod.DrawTextColouredMarc(ref g, "VIC", DrawMod.TGame.MarcFont4, x + w - 95 + 30, y + 105, Color.White);
    }

    public static void DrawRepeatingBackground(
      Graphics g,
      int bitmapNr,
      int x,
      int y,
      int w,
      int h)
    {
      int nr = bitmapNr;
      int width1 = BitmapStore.GetWidth(nr);
      int num1 = BitmapStore.Getheight(nr);
      int num2 = (int) Math.Round(Conversion.Int((double) w / (double) width1));
      for (int index1 = 0; index1 <= num2; ++index1)
      {
        int num3 = (int) Math.Round(Conversion.Int((double) h / (double) num1));
        for (int index2 = 0; index2 <= num3; ++index2)
        {
          int width2 = index1 * w + width1;
          int height = index2 * h + num1;
          int x1 = x + index1 * width1;
          int y1 = y + index2 * num1;
          if (x1 + width2 - x > w)
            width2 -= x1 + width2 - x - w;
          if (y1 + height - y > h)
            height -= y1 + height - y - h;
          ref Graphics local1 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(nr);
          ref Bitmap local2 = ref bitmap;
          Rectangle srcrect = new Rectangle(0, 0, width2, height);
          Rectangle destrect = new Rectangle(x1, y1, width2, height);
          DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
        }
      }
    }

    public static Rectangle GetPaintedPartRect(Bitmap bmp)
    {
      int num1 = bmp.Width - 1;
      int x1;
      int y1;
      Color pixel;
      for (x1 = 0; x1 <= num1; ++x1)
      {
        int num2 = bmp.Height - 1;
        for (y1 = 0; y1 <= num2; ++y1)
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
      int y2 = paintedPartRect.Y;
      int num3 = bmp.Height - 1;
      int y3;
      for (y3 = y2; y3 <= num3; ++y3)
      {
        pixel = bmp.GetPixel(x1, y3);
        if (pixel.A < (byte) 60)
          break;
      }
      paintedPartRect.Height = y3 - paintedPartRect.Y;
      int y4 = paintedPartRect.Y;
      int x2 = paintedPartRect.X;
      int num4 = bmp.Width - 1;
      int x3;
      for (x3 = x2; x3 <= num4; ++x3)
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
