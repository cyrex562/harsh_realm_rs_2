// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.BitmapStore
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;

namespace WindowsApplication1
{
  [StandardModule]
  pub sealed class BitmapStore
  {
     static Bitmap[] tmpBitmap;
     static Bitmap[] tmpBigBitmap;
     static Bitmap[] tmpSmallBitmap;
     static int[] tmpWidth;
    pub static string[] tmpFileName;
    pub static int[] tmpOverloadCounter;
    pub static bool[] tmpFlag;
    pub static bool[] tmpKnownTransparent;
    pub static string[] oldFileName;
    pub static bool[] tmpRecolorDone;
    pub static SimpleByteCache[] simpleByteCacheObj;
    pub static bool[] simpleByteCacheSet;
    pub static bool[] tmpIsSystem;
    pub static bool[] tmpIsBig;
    pub static int Counter;
    pub static string GraphicsPath;
    pub static string LastReplace;
    pub static string lastreloadsystemgfx;
    pub static Bitmap SmallShape;
    pub static Bitmap MediumShape;
    pub static Bitmap BigShape;
    pub static int GfxSheetCount;
    pub static GfxSheetClass[] GfxSheetObj = new GfxSheetClass[2];
    pub const bool USEEMBED = false;

    pub static void Dispose(int nr)
    {
      if (!Information.IsNothing((object) BitmapStore.tmpBitmap[nr]))
        BitmapStore.tmpBitmap[nr].Dispose();
      BitmapStore.tmpBitmap[nr] = (Bitmap) null;
      if (!Information.IsNothing((object) BitmapStore.tmpBigBitmap[nr]))
        BitmapStore.tmpBigBitmap[nr].Dispose();
      BitmapStore.tmpBigBitmap[nr] = (Bitmap) null;
      if (!Information.IsNothing((object) BitmapStore.tmpSmallBitmap[nr]))
        BitmapStore.tmpSmallBitmap[nr].Dispose();
      BitmapStore.tmpSmallBitmap[nr] = (Bitmap) null;
    }

    pub static void ReloadAllRecoloredBitmaps()
    {
      int num = num;
      BitmapStore.ReloadSomeGfx();
      int counter = BitmapStore.Counter;
      for (int nr = 0; nr <= counter; nr += 1)
      {
        if (BitmapStore.tmpRecolorDone[nr])
        {
          if (nr == 448)
            nr = nr;
          if (!Information.IsNothing((object) BitmapStore.tmpBitmap[nr]))
            BitmapStore.ReloadFile(nr, BitmapStore.tmpFileName[nr], BitmapStore.tmpIsSystem[nr], BitmapStore.tmpIsBig[nr], forceReload: true);
          else if (BitmapStore.simpleByteCacheSet[nr])
            BitmapStore.ReloadFile(nr, BitmapStore.tmpFileName[nr], BitmapStore.tmpIsSystem[nr], BitmapStore.tmpIsBig[nr], forceReload: true);
          BitmapStore.tmpRecolorDone[nr] = false;
        }
      }
    }

    pub static void ReloadBeforeRecolor(string spart, string newSpart)
    {
      int counter = BitmapStore.Counter;
      for (int nr = 0; nr <= counter; nr += 1)
      {
        str: String = BitmapStore.tmpFileName[nr].Replace("\\", "/").Replace("//", "/");
        if (Strings.InStr(Strings.LCase(str), Strings.LCase(spart)) > 0)
        {
          filename: String = str.Replace(spart, newSpart);
          if (Operators.CompareString(BitmapStore.oldFileName[nr], "", false) == 0)
          {
            if (!Information.IsNothing((object) BitmapStore.tmpBitmap[nr]))
              BitmapStore.ReloadFile(nr, filename, BitmapStore.tmpIsSystem[nr], BitmapStore.tmpIsBig[nr], true, true);
            else if (!Information.IsNothing((object) BitmapStore.simpleByteCacheObj[nr]))
              BitmapStore.ReloadFile(nr, filename, BitmapStore.tmpIsSystem[nr], BitmapStore.tmpIsBig[nr], true, true);
          }
        }
      }
    }

    pub static bool ModifyColorOfNameInstrToGray(string spart, int effectStrength)
    {
      bool gray = false;
      if (Strings.InStr(spart, "sandy") > 0)
      {
        int num = num;
      }
      int counter = BitmapStore.Counter;
      for (int nr = 0; nr <= counter; nr += 1)
      {
        if (Strings.InStr(Strings.LCase(BitmapStore.tmpFileName[nr].Replace("\\", "/").Replace("//", "/")), Strings.LCase(spart)) > 0)
        {
          if (!Information.IsNothing((object) BitmapStore.tmpBitmap[nr]))
          {
            if (!BitmapStore.tmpRecolorDone[nr])
            {
              gray = true;
              DrawMod.ModifyColorOfBitmapToGrayHighSpeed(ref BitmapStore.tmpBitmap[nr], effectStrength);
              if (!Information.IsNothing((object) BitmapStore.tmpBigBitmap[nr]))
                DrawMod.ModifyColorOfBitmapToGrayHighSpeed(ref BitmapStore.tmpBigBitmap[nr], effectStrength);
              if (!Information.IsNothing((object) BitmapStore.tmpSmallBitmap[nr]))
                DrawMod.ModifyColorOfBitmapToGrayHighSpeed(ref BitmapStore.tmpSmallBitmap[nr], effectStrength);
              BitmapStore.tmpRecolorDone[nr] = true;
            }
          }
          else if (!Information.IsNothing((object) BitmapStore.simpleByteCacheObj[nr]) & !BitmapStore.tmpRecolorDone[nr])
          {
            BitmapStore.ReloadFile(nr, BitmapStore.tmpFileName[nr], BitmapStore.tmpIsSystem[nr], BitmapStore.tmpIsBig[nr], forceReload: true);
            DrawMod.ModifyColorOfBitmapToGrayHighSpeed(ref BitmapStore.tmpBitmap[nr], effectStrength);
            if (!Information.IsNothing((object) BitmapStore.tmpBigBitmap[nr]))
              DrawMod.ModifyColorOfBitmapToGrayHighSpeed(ref BitmapStore.tmpBigBitmap[nr], effectStrength);
            if (!Information.IsNothing((object) BitmapStore.tmpSmallBitmap[nr]))
              DrawMod.ModifyColorOfBitmapToGrayHighSpeed(ref BitmapStore.tmpSmallBitmap[nr], effectStrength);
            gray = true;
            BitmapStore.tmpRecolorDone[nr] = true;
          }
        }
      }
      return gray;
    }

    pub static bool ModifyColorOfNameInstr(
      string spart,
      int fr,
      int fg,
      int fb,
      int tr,
      int tg,
      int tb)
    {
      bool flag = false;
      int counter = BitmapStore.Counter;
      for (int index = 0; index <= counter; index += 1)
      {
        if (Strings.InStr(Strings.LCase(BitmapStore.tmpFileName[index].Replace("\\", "/").Replace("//", "/")), Strings.LCase(spart)) > 0)
        {
          if (!Information.IsNothing((object) BitmapStore.tmpBitmap[index]))
          {
            if (!BitmapStore.tmpRecolorDone[index])
            {
              flag = true;
              DrawMod.ModifyColorOfBitmapHighSpeed(ref BitmapStore.tmpBitmap[index], fr, fg, fb, tr, tg, tb);
              if (!Information.IsNothing((object) BitmapStore.tmpBigBitmap[index]))
                DrawMod.ModifyColorOfBitmapHighSpeed(ref BitmapStore.tmpBigBitmap[index], fr, fg, fb, tr, tg, tb);
              if (!Information.IsNothing((object) BitmapStore.tmpSmallBitmap[index]))
                DrawMod.ModifyColorOfBitmapHighSpeed(ref BitmapStore.tmpSmallBitmap[index], fr, fg, fb, tr, tg, tb);
              BitmapStore.tmpRecolorDone[index] = true;
            }
          }
          else if (!Information.IsNothing((object) BitmapStore.simpleByteCacheObj[index]) & !BitmapStore.tmpRecolorDone[index])
          {
            flag = true;
            BitmapStore.tmpRecolorDone[index] = true;
          }
        }
      }
      return flag;
    }

    pub static string FileNameOverride(string filename)
    {
      if (Operators.CompareString(DrawMod.TGame.AlternativeGraphics, "", false) == 0)
        return filename;
      str: String = "";
      str = filename.Replace("/graphics/", "/" + DrawMod.TGame.AlternativeGraphics + "/");
      str = filename.Replace("\\graphics\\", "\\" + DrawMod.TGame.AlternativeGraphics + "\\");
      path: String = filename.Replace("\\graphics/", "\\" + DrawMod.TGame.AlternativeGraphics + "/");
      if (File.Exists(path))
        filename = path;
      return filename;
    }

    pub static Bitmap LoadBitmap(string filename)
    {
      filename = BitmapStore.FileNameOverride(filename);
      FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
      Bitmap bitmap1 = (Bitmap) Image.FromStream((Stream) fileStream);
      Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height, PixelFormat.Format32bppPArgb);
      Graphics graphics = Graphics.FromImage((Image) bitmap2);
      graphics.DrawImage((Image) bitmap1, new Rectangle(0, 0, bitmap1.Width, bitmap1.Height));
      graphics.Dispose();
      bitmap2.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      if (bitmap2.GetPixel(0, 0) == Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue))
        bitmap2.MakeTransparent(Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue));
      else if (Strings.InStr(filename, ".png") <= 0)
        bitmap2.MakeTransparent(Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue));
      fileStream.Close();
      fileStream.Dispose();
      bitmap1.Dispose();
      return bitmap2;
    }

    static BitmapStore() => BitmapStore.Counter = -1;

    pub static int GetMemorySize()
    {
      int counter = BitmapStore.Counter;
      int memorySize;
      for (int index = 0; index <= counter; index += 1)
      {
        if (!Information.IsNothing((object) BitmapStore.tmpBitmap[index]))
          memorySize += (int) Math.Round((double) (32 * BitmapStore.tmpBitmap[index].Width * BitmapStore.tmpBitmap[index].Height) / 8000.0);
      }
      return memorySize;
    }

    pub static int GetMemorySize(int nr, int zoomnr, int mode)
    {
      switch (mode)
      {
        case 1:
          switch (zoomnr)
          {
            case -1:
              return !Information.IsNothing((object) BitmapStore.tmpSmallBitmap[nr]) ? (int) Math.Round((double) (4 * BitmapStore.tmpSmallBitmap[nr].Width * BitmapStore.tmpSmallBitmap[nr].Height) / 1024.0) : 0;
            case 0:
              return !Information.IsNothing((object) BitmapStore.tmpBitmap[nr]) ? (int) Math.Round((double) (4 * BitmapStore.tmpBitmap[nr].Width * BitmapStore.tmpBitmap[nr].Height) / 1024.0) : 0;
            case 1:
              return !Information.IsNothing((object) BitmapStore.tmpBigBitmap[nr]) ? (int) Math.Round((double) (4 * BitmapStore.tmpBigBitmap[nr].Width * BitmapStore.tmpBigBitmap[nr].Height) / 1024.0) : 0;
          }
          break;
        case 2:
          if (Information.IsNothing((object) BitmapStore.simpleByteCacheObj[nr]))
            return 0;
          int num1;
          if (!Information.IsNothing((object) BitmapStore.simpleByteCacheObj[nr].cacheBig))
          {
            int num2;
            num1 = num2 + BitmapStore.simpleByteCacheObj[nr].cacheBig.Length;
          }
          if (!Information.IsNothing((object) BitmapStore.simpleByteCacheObj[nr].singleCacheBig))
            num1 += BitmapStore.simpleByteCacheObj[nr].singleCacheBig.Length;
          if (!Information.IsNothing((object) BitmapStore.simpleByteCacheObj[nr].singleFredCacheBig))
            num1 += BitmapStore.simpleByteCacheObj[nr].singleFredCacheBig.Length;
          if (!Information.IsNothing((object) BitmapStore.simpleByteCacheObj[nr].cacheMed))
            num1 += BitmapStore.simpleByteCacheObj[nr].cacheMed.Length;
          if (!Information.IsNothing((object) BitmapStore.simpleByteCacheObj[nr].singleCacheMed))
            num1 += BitmapStore.simpleByteCacheObj[nr].singleCacheMed.Length;
          if (!Information.IsNothing((object) BitmapStore.simpleByteCacheObj[nr].singleFredCacheMed))
            num1 += BitmapStore.simpleByteCacheObj[nr].singleFredCacheMed.Length;
          if (!Information.IsNothing((object) BitmapStore.simpleByteCacheObj[nr].cacheSmall))
            num1 += BitmapStore.simpleByteCacheObj[nr].cacheSmall.Length;
          if (!Information.IsNothing((object) BitmapStore.simpleByteCacheObj[nr].singleCacheSmall))
            num1 += BitmapStore.simpleByteCacheObj[nr].singleCacheSmall.Length;
          if (!Information.IsNothing((object) BitmapStore.simpleByteCacheObj[nr].singleFredCacheSmall))
            num1 += BitmapStore.simpleByteCacheObj[nr].singleFredCacheSmall.Length;
          return (int) Math.Round((double) num1 / 1024.0);
      }
      int memorySize;
      return memorySize;
    }

    pub static void GiveGraphicsPath(string s)
    {
      BitmapStore.GraphicsPath = s;
      BitmapStore.SmallShape = BitmapStore.LoadBitmap(BitmapStore.GraphicsPath + "systemgraphics/smallshape.png");
      BitmapStore.SmallShape.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      BitmapStore.MediumShape = BitmapStore.LoadBitmap(BitmapStore.GraphicsPath + "systemgraphics/mediumshape.png");
      BitmapStore.MediumShape.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      BitmapStore.BigShape = BitmapStore.LoadBitmap(BitmapStore.GraphicsPath + "systemgraphics/bigshape.png");
      BitmapStore.BigShape.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
    }

    pub static void RemoveBitmapNr(int nr)
    {
      if (BitmapStore.tmpOverloadCounter[nr] == 1)
      {
        BitmapStore.tmpBitmap[nr] = (Bitmap) null;
        BitmapStore.tmpSmallBitmap[nr] = (Bitmap) null;
        BitmapStore.tmpBigBitmap[nr] = (Bitmap) null;
        BitmapStore.tmpFileName[nr] = "";
        BitmapStore.tmpOverloadCounter[nr] = 0;
        BitmapStore.tmpIsSystem[nr] = false;
        BitmapStore.simpleByteCacheObj[nr] = (SimpleByteCache) null;
        BitmapStore.simpleByteCacheSet[nr] = false;
        if (nr != BitmapStore.Counter)
          return;
        --BitmapStore.Counter;
        BitmapStore.tmpBitmap = (Bitmap[]) Utils.CopyArray((Array) BitmapStore.tmpBitmap, (Array) new Bitmap[BitmapStore.Counter + 1]);
        BitmapStore.tmpFileName = (string[]) Utils.CopyArray((Array) BitmapStore.tmpFileName, (Array) new string[BitmapStore.Counter + 1]);
        BitmapStore.oldFileName = (string[]) Utils.CopyArray((Array) BitmapStore.oldFileName, (Array) new string[BitmapStore.Counter + 1]);
        BitmapStore.tmpIsSystem = (bool[]) Utils.CopyArray((Array) BitmapStore.tmpIsSystem, (Array) new bool[BitmapStore.Counter + 1]);
        BitmapStore.tmpOverloadCounter = (int[]) Utils.CopyArray((Array) BitmapStore.tmpOverloadCounter, (Array) new int[BitmapStore.Counter + 1]);
        BitmapStore.tmpWidth = (int[]) Utils.CopyArray((Array) BitmapStore.tmpWidth, (Array) new int[BitmapStore.Counter + 1]);
        BitmapStore.tmpRecolorDone = (bool[]) Utils.CopyArray((Array) BitmapStore.tmpRecolorDone, (Array) new bool[BitmapStore.Counter + 1]);
        BitmapStore.tmpIsBig = (bool[]) Utils.CopyArray((Array) BitmapStore.tmpIsBig, (Array) new bool[BitmapStore.Counter + 1]);
        BitmapStore.tmpFlag = (bool[]) Utils.CopyArray((Array) BitmapStore.tmpFlag, (Array) new bool[BitmapStore.Counter + 1]);
        BitmapStore.tmpBigBitmap = (Bitmap[]) Utils.CopyArray((Array) BitmapStore.tmpBigBitmap, (Array) new Bitmap[BitmapStore.Counter + 1]);
        BitmapStore.simpleByteCacheObj = (SimpleByteCache[]) Utils.CopyArray((Array) BitmapStore.simpleByteCacheObj, (Array) new SimpleByteCache[BitmapStore.Counter + 1]);
        BitmapStore.simpleByteCacheSet = (bool[]) Utils.CopyArray((Array) BitmapStore.simpleByteCacheSet, (Array) new bool[BitmapStore.Counter + 1]);
      }
      else
      {
        if (BitmapStore.tmpOverloadCounter[nr] <= 1)
          return;
        BitmapStore.tmpOverloadCounter[nr] = BitmapStore.tmpOverloadCounter[nr] - 1;
      }
    }

    pub static void ReloadSomeGfx()
    {
      int counter = BitmapStore.Counter;
      for (int nr = 0; nr <= counter; nr += 1)
      {
        if (!Information.IsNothing((object) BitmapStore.oldFileName[nr]) && BitmapStore.oldFileName[nr].Length > 1)
        {
          BitmapStore.ReloadFile(nr, BitmapStore.oldFileName[nr], BitmapStore.tmpIsSystem[nr], BitmapStore.tmpIsBig[nr]);
          BitmapStore.oldFileName[nr] = "";
          BitmapStore.tmpRecolorDone[nr] = false;
        }
      }
    }

    pub static bool IsKnownTransBitmap(int nr)
    {
      if (Information.IsNothing((object) BitmapStore.tmpKnownTransparent))
        BitmapStore.SetKnownTransparents();
      if (BitmapStore.tmpKnownTransparent.GetUpperBound(0) < BitmapStore.Counter)
        BitmapStore.SetKnownTransparents();
      return BitmapStore.tmpKnownTransparent[nr];
    }

    pub static object ReloadSystemGraphics(string ns, bool AlwaysReload = false)
    {
      if (Operators.CompareString(ns, "", false) == 0)
        ns = DrawMod.TGame.ModSystemGraphicsDirectory;
      if (AlwaysReload || !(Operators.CompareString(ns, BitmapStore.lastreloadsystemgfx, false) == 0 | Operators.CompareString(ns, "systemgraphics", false) == 0 & Operators.CompareString(BitmapStore.lastreloadsystemgfx, "", false) == 0))
      {
        BitmapStore.lastreloadsystemgfx = ns;
        BitmapStore.FlagForDelete();
        int upperBound = DrawMod.TGame.NATO.GetUpperBound(0);
        for (int index = 1; index <= upperBound; index += 1)
        {
          if (DrawMod.TGame.NATO[index] <= BitmapStore.Counter & DrawMod.TGame.NATO[index] > 0)
            BitmapStore.RemoveBitmapNr(DrawMod.TGame.NATO[index]);
        }
        DrawMod.TGame.NATO = new int[1];
        int counter = BitmapStore.Counter;
        for (int nr = 0; nr <= counter; nr += 1)
        {
          if (BitmapStore.tmpIsSystem[nr])
          {
            if (nr == 224)
              nr = nr;
            if (Strings.Len(ns) > 0)
            {
              if (nr == 147)
                nr = nr;
              if (Strings.InStr(BitmapStore.tmpFileName[nr], "systemgraphics") > 0)
              {
                filename1: String = BitmapStore.tmpFileName[nr].Replace("systemgraphics", ns);
                if (File.Exists(DrawMod.TGame.AppPath + "graphics/" + filename1))
                  BitmapStore.ReloadFile(nr, filename1, true, BitmapStore.tmpIsBig[nr]);
                else if (Strings.InStr(BitmapStore.tmpFileName[nr], "systemgraphics") <= 0 && Strings.InStr(BitmapStore.tmpFileName[nr], BitmapStore.LastReplace) > 0 & Strings.Len(BitmapStore.LastReplace) > 0)
                {
                  filename2: String = BitmapStore.tmpFileName[nr].Replace(BitmapStore.LastReplace, "systemgraphics");
                  try
                  {
                    BitmapStore.ReloadFile(nr, filename2, true, BitmapStore.tmpIsBig[nr]);
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    ProjectData.ClearProjectError();
                  }
                }
              }
              else if (Strings.InStr(BitmapStore.tmpFileName[nr], BitmapStore.LastReplace) > 0 & Strings.Len(BitmapStore.LastReplace) > 0)
              {
                filename3: String = BitmapStore.tmpFileName[nr].Replace(BitmapStore.LastReplace, ns);
                if (!File.Exists(BitmapStore.GraphicsPath + filename3))
                  filename3 = BitmapStore.tmpFileName[nr].Replace(BitmapStore.LastReplace, "systemgraphics");
                try
                {
                  BitmapStore.ReloadFile(nr, filename3, true, BitmapStore.tmpIsBig[nr]);
                }
                catch (Exception ex1)
                {
                  ProjectData.SetProjectError(ex1);
                  if (Strings.InStr(BitmapStore.tmpFileName[nr], "systemgraphics") <= 0 && Strings.InStr(BitmapStore.tmpFileName[nr], BitmapStore.LastReplace) > 0 & Strings.Len(BitmapStore.LastReplace) > 0)
                  {
                    filename4: String = BitmapStore.tmpFileName[nr].Replace(BitmapStore.LastReplace, "systemgraphics");
                    try
                    {
                      BitmapStore.ReloadFile(nr, filename4, true, BitmapStore.tmpIsBig[nr]);
                    }
                    catch (Exception ex2)
                    {
                      ProjectData.SetProjectError(ex2);
                      ProjectData.ClearProjectError();
                    }
                  }
                  ProjectData.ClearProjectError();
                }
              }
            }
            else if (Strings.InStr(BitmapStore.tmpFileName[nr], "systemgraphics") <= 0 && Strings.InStr(BitmapStore.tmpFileName[nr], BitmapStore.LastReplace) > 0 & Strings.Len(BitmapStore.LastReplace) > 0)
            {
              filename: String = BitmapStore.tmpFileName[nr].Replace(BitmapStore.LastReplace, "systemgraphics");
              try
              {
                BitmapStore.ReloadFile(nr, filename, true, BitmapStore.tmpIsBig[nr]);
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
              }
            }
          }
        }
        int num;
        do
        {
          num = 0;
          int Number;
          Number += 1;
          if (Number == 183)
            Number = Number;
          string path;
          if (Operators.CompareString(ns, "", false) == 0)
            path = DrawMod.TGame.AppPath + "graphics/systemgraphics/" + DrawMod.TGame.ModNatoCounters + "/" + Strings.Trim(Conversion.Str((object) Number)) + ".png";
          else
            path = DrawMod.TGame.AppPath + "graphics/" + ns + "/" + DrawMod.TGame.ModNatoCounters + "/" + Strings.Trim(Conversion.Str((object) Number)) + ".png";
          int gfxReplaceCounter = DrawMod.TGame.ModGfxReplaceCounter;
          for (int index = 1; index <= gfxReplaceCounter; index += 1)
          {
            str: String = path;
            path = path.Replace(DrawMod.TGame.ModGfxReplaceS1[index], DrawMod.TGame.ModGfxReplaceS2[index]);
            if (!File.Exists(path))
              path = str;
            else
              break;
          }
          if (File.Exists(path))
          {
            DrawMod.TGame.NATO = (int[]) Utils.CopyArray((Array) DrawMod.TGame.NATO, (Array) new int[Number + 1]);
            num = 1;
            if (Operators.CompareString(ns, "", false) == 0)
              DrawMod.TGame.NATO[Number] = BitmapStore.AddFile("systemgraphics/" + DrawMod.TGame.ModNatoCounters + "/" + Strings.Trim(Conversion.Str((object) Number)) + ".png", true, true);
            else
              DrawMod.TGame.NATO[Number] = BitmapStore.AddFile(ns + "/" + DrawMod.TGame.ModNatoCounters + "/" + Strings.Trim(Conversion.Str((object) Number)) + ".png", true, true);
          }
          else if (Operators.CompareString(ns, "", false) != 0)
          {
            if (File.Exists(DrawMod.TGame.AppPath + "graphics/systemgraphics/" + DrawMod.TGame.ModNatoCounters + "/" + Strings.Trim(Conversion.Str((object) Number)) + ".png"))
            {
              DrawMod.TGame.NATO = (int[]) Utils.CopyArray((Array) DrawMod.TGame.NATO, (Array) new int[Number + 1]);
              num = 1;
              DrawMod.TGame.NATO[Number] = BitmapStore.AddFile("systemgraphics/" + DrawMod.TGame.ModNatoCounters + "/" + Strings.Trim(Conversion.Str((object) Number)) + ".png", true, true);
            }
          }
        }
        while (num == 1);
        if (Strings.Len(ns) > 0)
          BitmapStore.LastReplace = ns;
        BitmapStore.DeleteFlaggedBitmaps();
      }
      object obj;
      return obj;
    }

    pub static string MakeBigString(string s)
    {
      int num1 = 0;
      int num2 = num1;
      int Start = Strings.InStr(num1 + 1, s, "\\");
      if (Start == 0)
      {
        int num3 = 0;
        num2 = num3;
        Start = Strings.InStr(num3 + 1, s, "/");
      }
      return Strings.Left(s, Start - 1) + "BIG" + Strings.Mid(s, Start);
    }

    pub static string MakeSmallString(string s)
    {
      int num1 = 0;
      int num2 = num1;
      int Start = Strings.InStr(num1 + 1, s, "\\");
      if (Start == 0)
      {
        int num3 = 0;
        num2 = num3;
        Start = Strings.InStr(num3 + 1, s, "/");
      }
      return Strings.Left(s, Start - 1) + "SMALL" + Strings.Mid(s, Start);
    }

    pub static int ReloadFile(
      int nr,
      string filename,
      bool IsSystem = false,
      bool IsBig = false,
      bool EventDriven = false,
      bool forceReload = false)
    {
      int gfxReplaceCounter = DrawMod.TGame.ModGfxReplaceCounter;
      for (int index = 1; index <= gfxReplaceCounter; index += 1)
      {
        str: String = filename;
        filename = filename.Replace(DrawMod.TGame.ModGfxReplaceS1[index], DrawMod.TGame.ModGfxReplaceS2[index]);
        if (!File.Exists(BitmapStore.GraphicsPath + filename))
          filename = str;
      }
      if (!(!File.Exists(BitmapStore.GraphicsPath + filename) & EventDriven))
      {
        Graphics Expression;
        if (BitmapStore.tmpOverloadCounter[nr] == 1 | EventDriven)
        {
          if (Information.IsNothing((object) BitmapStore.oldFileName[nr]))
          {
            if (EventDriven)
              BitmapStore.oldFileName[nr] = BitmapStore.tmpFileName[nr];
          }
          else if (Operators.CompareString(BitmapStore.oldFileName[nr], "", false) == 0 && EventDriven)
            BitmapStore.oldFileName[nr] = BitmapStore.tmpFileName[nr];
          BitmapStore.tmpFileName[nr] = filename;
          BitmapStore.tmpIsSystem[nr] = IsSystem;
          Bitmap bitmap = BitmapStore.LoadBitmap(BitmapStore.GraphicsPath + filename);
          BitmapStore.tmpBitmap[nr] = bitmap;
          BitmapStore.simpleByteCacheSet[nr] = false;
          BitmapStore.tmpOverloadCounter[nr] = 1;
          BitmapStore.tmpWidth[nr] = BitmapStore.tmpBitmap[nr].Width;
          BitmapStore.tmpRecolorDone[nr] = false;
          BitmapStore.tmpIsBig[nr] = IsBig;
          if (BitmapStore.tmpIsBig[nr])
          {
            String1_1: String = BitmapStore.MakeBigString(filename);
            Bitmap tmpbmp1;
            try
            {
              tmpbmp1 = BitmapStore.LoadBitmap(BitmapStore.GraphicsPath + String1_1);
              tmpbmp1.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              tmpbmp1 = new Bitmap(BitmapStore.tmpBitmap[nr].Width * 2, BitmapStore.tmpBitmap[nr].Height * 2, PixelFormat.Format32bppPArgb);
              tmpbmp1.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
              int num1 = BitmapStore.tmpBitmap[nr].Height - 1;
              for (int y = 0; y <= num1; y += 1)
              {
                int num2 = BitmapStore.tmpBitmap[nr].Width - 1;
                for (int x = 0; x <= num2; x += 1)
                {
                  Color color = BitmapStore.tmpBitmap[nr].GetPixel(x, y);
                  if (Strings.InStr(String1_1, ".bmp") > 0 & color.A == (byte) 0)
                    color = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue);
                  tmpbmp1.SetPixel(x * 2, y * 2, color);
                  tmpbmp1.SetPixel(x * 2 + 1, y * 2, color);
                  tmpbmp1.SetPixel(x * 2, y * 2 + 1, color);
                  tmpbmp1.SetPixel(x * 2 + 1, y * 2 + 1, color);
                }
              }
              if (tmpbmp1.GetPixel(0, 0) == Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue))
                tmpbmp1.MakeTransparent(Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue));
              if (Strings.InStr(String1_1, ".bmp") > 0)
                DrawMod.TGame.HandyFunctionsObj.SaveBitmapAsBmp(tmpbmp1, BitmapStore.GraphicsPath + String1_1);
              else if (Strings.InStr(String1_1, ".jpg") > 0)
                DrawMod.TGame.HandyFunctionsObj.SaveBitmapAsJpeg(tmpbmp1, BitmapStore.GraphicsPath + String1_1);
              else
                DrawMod.TGame.HandyFunctionsObj.SaveBitmapAsPing(tmpbmp1, BitmapStore.GraphicsPath + String1_1);
              ProjectData.ClearProjectError();
            }
            BitmapStore.tmpBigBitmap[nr] = tmpbmp1;
            String1_2: String = BitmapStore.MakeSmallString(filename);
            Bitmap tmpbmp2;
            try
            {
              tmpbmp2 = BitmapStore.LoadBitmap(BitmapStore.GraphicsPath + String1_2);
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              tmpbmp2 = new Bitmap((int) Math.Round(Conversion.Int((double) BitmapStore.tmpBitmap[nr].Width / 2.0)), (int) Math.Round(Conversion.Int((double) BitmapStore.tmpBitmap[nr].Height / 2.0)), PixelFormat.Format32bppPArgb);
              tmpbmp2.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
              if (tmpbmp2.Height == 24 | tmpbmp2.Height == 264 & tmpbmp2.Width == 192)
              {
                int num3 = tmpbmp2.Height - 1;
                for (int y = 0; y <= num3; y += 1)
                {
                  int num4 = tmpbmp2.Width - 1;
                  for (int x = 0; x <= num4; x += 1)
                  {
                    if (BitmapStore.SmallShape.GetPixel(x % 32, y % 24).A == byte.MaxValue)
                    {
                      int num5 = 0;
                      int num6 = 0;
                      int num7 = 0;
                      int num8 = 0;
                      int num9 = 0;
                      Color pixel = BitmapStore.tmpBitmap[nr].GetPixel(x * 2, y * 2);
                      if (pixel.A > (byte) 0)
                      {
                        num5 += (int) pixel.R;
                        num6 += (int) pixel.G;
                        num7 += (int) pixel.B;
                        num8 += (int) pixel.A;
                        num9 += 1;
                      }
                      if (x < tmpbmp2.Width - 1)
                      {
                        pixel = BitmapStore.tmpBitmap[nr].GetPixel(x * 2 + 1, y * 2);
                        if (pixel.A > (byte) 0)
                        {
                          num5 += (int) pixel.R;
                          num6 += (int) pixel.G;
                          num7 += (int) pixel.B;
                          num8 += (int) pixel.A;
                          num9 += 1;
                        }
                      }
                      if (y < tmpbmp2.Height - 1)
                      {
                        pixel = BitmapStore.tmpBitmap[nr].GetPixel(x * 2, y * 2 + 1);
                        if (pixel.A > (byte) 0)
                        {
                          num5 += (int) pixel.R;
                          num6 += (int) pixel.G;
                          num7 += (int) pixel.B;
                          num8 += (int) pixel.A;
                          num9 += 1;
                        }
                      }
                      if (x < tmpbmp2.Width - 1 & y < tmpbmp2.Height - 1)
                      {
                        pixel = BitmapStore.tmpBitmap[nr].GetPixel(x * 2 + 1, y * 2 + 1);
                        if (pixel.A > (byte) 0)
                        {
                          num5 += (int) pixel.R;
                          num6 += (int) pixel.G;
                          num7 += (int) pixel.B;
                          num8 += (int) pixel.A;
                          num9 += 1;
                        }
                      }
                      if (num9 > 0)
                      {
                        int red = (int) Math.Round((double) num5 / (double) num9);
                        int green = (int) Math.Round((double) num6 / (double) num9);
                        int blue = (int) Math.Round((double) num7 / (double) num9);
                        int alpha = (int) Math.Round((double) num8 / (double) num9);
                        if (Strings.InStr(String1_2, ".bmp") > 0 & alpha == 0)
                        {
                          alpha = (int) byte.MaxValue;
                          red = (int) byte.MaxValue;
                          green = 0;
                          blue = (int) byte.MaxValue;
                        }
                        tmpbmp2.SetPixel(x, y, Color.FromArgb(alpha, red, green, blue));
                      }
                      else if (Strings.InStr(String1_2, ".bmp") > 0)
                      {
                        int maxValue1 = (int) byte.MaxValue;
                        int maxValue2 = (int) byte.MaxValue;
                        int green = 0;
                        int maxValue3 = (int) byte.MaxValue;
                        tmpbmp2.SetPixel(x, y, Color.FromArgb(maxValue1, maxValue2, green, maxValue3));
                      }
                    }
                    else if (Strings.InStr(String1_2, ".bmp") > 0)
                      tmpbmp2.SetPixel(x, y, Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue));
                  }
                }
              }
              else
              {
                int num10 = tmpbmp2.Height - 1;
                for (int y = 0; y <= num10; y += 1)
                {
                  int num11 = tmpbmp2.Width - 1;
                  for (int x = 0; x <= num11; x += 1)
                  {
                    int num12 = 0;
                    int num13 = 0;
                    int num14 = 0;
                    int num15 = 0;
                    int num16 = 0;
                    Color pixel = BitmapStore.tmpBitmap[nr].GetPixel(x * 2, y * 2);
                    if (pixel.A > (byte) 0)
                    {
                      num12 += (int) pixel.R;
                      num13 += (int) pixel.G;
                      num14 += (int) pixel.B;
                      num15 += (int) pixel.A;
                      num16 += 1;
                    }
                    if (x < tmpbmp2.Width - 1)
                    {
                      pixel = BitmapStore.tmpBitmap[nr].GetPixel(x * 2 + 1, y * 2);
                      if (pixel.A > (byte) 0)
                      {
                        num12 += (int) pixel.R;
                        num13 += (int) pixel.G;
                        num14 += (int) pixel.B;
                        num15 += (int) pixel.A;
                        num16 += 1;
                      }
                    }
                    if (y < tmpbmp2.Height - 1)
                    {
                      pixel = BitmapStore.tmpBitmap[nr].GetPixel(x * 2, y * 2 + 1);
                      if (pixel.A > (byte) 0)
                      {
                        num12 += (int) pixel.R;
                        num13 += (int) pixel.G;
                        num14 += (int) pixel.B;
                        num15 += (int) pixel.A;
                        num16 += 1;
                      }
                    }
                    if (x > 0)
                    {
                      pixel = BitmapStore.tmpBitmap[nr].GetPixel(x * 2 - 1, y * 2);
                      if (pixel.A > (byte) 0)
                      {
                        num12 += (int) pixel.R;
                        num13 += (int) pixel.G;
                        num14 += (int) pixel.B;
                        num15 += (int) pixel.A;
                        num16 += 1;
                      }
                    }
                    if (y > 0)
                    {
                      pixel = BitmapStore.tmpBitmap[nr].GetPixel(x * 2, y * 2 - 1);
                      if (pixel.A > (byte) 0)
                      {
                        num12 += (int) pixel.R;
                        num13 += (int) pixel.G;
                        num14 += (int) pixel.B;
                        num15 += (int) pixel.A;
                        num16 += 1;
                      }
                    }
                    if (num16 > 0)
                    {
                      int red = (int) Math.Round((double) num12 / (double) num16);
                      int green = (int) Math.Round((double) num13 / (double) num16);
                      int blue = (int) Math.Round((double) num14 / (double) num16);
                      int alpha = (int) Math.Round((double) num15 / (double) num16);
                      if (Strings.InStr(String1_2, ".bmp") > 0 & alpha == 0)
                      {
                        alpha = (int) byte.MaxValue;
                        red = (int) byte.MaxValue;
                        green = 0;
                        blue = (int) byte.MaxValue;
                      }
                      tmpbmp2.SetPixel(x, y, Color.FromArgb(alpha, red, green, blue));
                    }
                  }
                }
              }
              if (tmpbmp2.GetPixel(0, 0) == Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue))
                tmpbmp2.MakeTransparent(Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue));
              if (Strings.InStr(String1_2, ".bmp") > 0)
                DrawMod.TGame.HandyFunctionsObj.SaveBitmapAsBmp(tmpbmp2, BitmapStore.GraphicsPath + String1_2);
              else if (Strings.InStr(String1_2, ".jpg") > 0)
                DrawMod.TGame.HandyFunctionsObj.SaveBitmapAsJpeg(tmpbmp2, BitmapStore.GraphicsPath + String1_2);
              else
                DrawMod.TGame.HandyFunctionsObj.SaveBitmapAsPing(tmpbmp2, BitmapStore.GraphicsPath + String1_2);
              ProjectData.ClearProjectError();
            }
            BitmapStore.tmpSmallBitmap[nr] = tmpbmp2;
          }
          if (!Information.IsNothing((object) Expression))
          {
            Expression.Dispose();
            Expression = (Graphics) null;
          }
          return nr;
        }
        if (BitmapStore.tmpOverloadCounter[nr] > 1)
        {
          BitmapStore.simpleByteCacheSet[nr] = false;
          BitmapStore.tmpRecolorDone[nr] = false;
          BitmapStore.tmpOverloadCounter[nr] = BitmapStore.tmpOverloadCounter[nr] - 1;
          if (EventDriven)
            BitmapStore.oldFileName[nr] = BitmapStore.tmpFileName[nr];
          if (!Information.IsNothing((object) Expression))
          {
            Expression.Dispose();
            Expression = (Graphics) null;
          }
          return BitmapStore.AddFile(filename, IsSystem, IsBig, forceReload);
        }
      }
      int num;
      return num;
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    pub static int AddFile(string filename, bool IsSystem, bool IsBig = false, bool forceReload = false)
    {
      if (Strings.InStr(filename, "defaultcounterbig") > 0)
      {
        str1: String = str1;
      }
      int gfxReplaceCounter = DrawMod.TGame.ModGfxReplaceCounter;
      for (int index = 1; index <= gfxReplaceCounter; index += 1)
      {
        str2: String = filename;
        filename = filename.Replace(DrawMod.TGame.ModGfxReplaceS1[index], DrawMod.TGame.ModGfxReplaceS2[index]);
        if (!File.Exists(BitmapStore.GraphicsPath + filename))
          filename = str2;
      }
      int index1 = -1;
      if (BitmapStore.Counter > -1)
      {
        int counter = BitmapStore.Counter;
        for (int index2 = 0; index2 <= counter; index2 += 1)
        {
          if (Operators.CompareString(BitmapStore.tmpFileName[index2], filename, false) == 0 & BitmapStore.tmpIsBig[index2] == IsBig)
          {
            index1 = index2;
            break;
          }
        }
      }
      Graphics Expression;
      if (index1 > -1 & !forceReload)
      {
        BitmapStore.tmpOverloadCounter[index1] = BitmapStore.tmpOverloadCounter[index1] + 1;
        if (!Information.IsNothing((object) Expression))
        {
          Expression.Dispose();
          Expression = (Graphics) null;
        }
        return index1;
      }
      if (!(index1 > -1 & forceReload))
      {
        forceReload = false;
        index1 = -1;
        int counter = BitmapStore.Counter;
        for (int index3 = 0; index3 <= counter; index3 += 1)
        {
          if (BitmapStore.tmpOverloadCounter[index3] == 0 & Operators.CompareString(BitmapStore.tmpFileName[index3], "", false) == 0)
          {
            index1 = index3;
            break;
          }
        }
      }
      if (index1 == -1)
      {
        BitmapStore += 1.Counter;
        if (BitmapStore.Counter == 357)
          ;
        BitmapStore.tmpBitmap = (Bitmap[]) Utils.CopyArray((Array) BitmapStore.tmpBitmap, (Array) new Bitmap[BitmapStore.Counter + 1]);
        BitmapStore.tmpFileName = (string[]) Utils.CopyArray((Array) BitmapStore.tmpFileName, (Array) new string[BitmapStore.Counter + 1]);
        BitmapStore.oldFileName = (string[]) Utils.CopyArray((Array) BitmapStore.oldFileName, (Array) new string[BitmapStore.Counter + 1]);
        BitmapStore.tmpIsSystem = (bool[]) Utils.CopyArray((Array) BitmapStore.tmpIsSystem, (Array) new bool[BitmapStore.Counter + 1]);
        BitmapStore.tmpOverloadCounter = (int[]) Utils.CopyArray((Array) BitmapStore.tmpOverloadCounter, (Array) new int[BitmapStore.Counter + 1]);
        BitmapStore.tmpWidth = (int[]) Utils.CopyArray((Array) BitmapStore.tmpWidth, (Array) new int[BitmapStore.Counter + 1]);
        BitmapStore.tmpRecolorDone = (bool[]) Utils.CopyArray((Array) BitmapStore.tmpRecolorDone, (Array) new bool[BitmapStore.Counter + 1]);
        BitmapStore.tmpIsBig = (bool[]) Utils.CopyArray((Array) BitmapStore.tmpIsBig, (Array) new bool[BitmapStore.Counter + 1]);
        BitmapStore.tmpFlag = (bool[]) Utils.CopyArray((Array) BitmapStore.tmpFlag, (Array) new bool[BitmapStore.Counter + 1]);
        BitmapStore.tmpBigBitmap = (Bitmap[]) Utils.CopyArray((Array) BitmapStore.tmpBigBitmap, (Array) new Bitmap[BitmapStore.Counter + 1]);
        BitmapStore.tmpSmallBitmap = (Bitmap[]) Utils.CopyArray((Array) BitmapStore.tmpSmallBitmap, (Array) new Bitmap[BitmapStore.Counter + 1]);
        BitmapStore.simpleByteCacheObj = (SimpleByteCache[]) Utils.CopyArray((Array) BitmapStore.simpleByteCacheObj, (Array) new SimpleByteCache[BitmapStore.Counter + 1]);
        BitmapStore.simpleByteCacheSet = (bool[]) Utils.CopyArray((Array) BitmapStore.simpleByteCacheSet, (Array) new bool[BitmapStore.Counter + 1]);
        BitmapStore.tmpFileName[BitmapStore.Counter] = filename;
        BitmapStore.tmpIsSystem[BitmapStore.Counter] = IsSystem;
        BitmapStore.tmpIsBig[BitmapStore.Counter] = IsBig;
        Coordinate coordinate;
        coordinate.x = -1;
        Bitmap tmpbmp;
        bool flag;
        if (coordinate.x == -1)
        {
          try
          {
            tmpbmp = BitmapStore.LoadBitmap(BitmapStore.GraphicsPath + filename);
            tmpbmp.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            if (!IsSystem)
            {
              if (Strings.InStr(filename.ToLower(), "air") > 0)
              {
                tmpbmp = new Bitmap(64, 48, PixelFormat.Format32bppPArgb);
                tmpbmp.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
              }
              else if (Interaction.MsgBox((object) ("Did not find: " + BitmapStore.GraphicsPath + filename + "  Do you want to continue?"), MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
              {
                tmpbmp = new Bitmap(64, 48, PixelFormat.Format32bppPArgb);
                tmpbmp.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
              }
              else
                ProjectData.EndApp();
            }
            else
            {
              tmpbmp = new Bitmap(1, 1);
              tmpbmp.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
              flag = true;
            }
            ProjectData.ClearProjectError();
          }
        }
        else
          BitmapStore.tmpBitmap[BitmapStore.Counter] = BitmapStore.GfxSheetObj[coordinate.x].Bmp.Clone(BitmapStore.GfxSheetObj[coordinate.x].Rect[coordinate.y], PixelFormat.Format32bppPArgb);
        BitmapStore.tmpBitmap[BitmapStore.Counter] = tmpbmp;
        BitmapStore.tmpWidth[BitmapStore.Counter] = BitmapStore.tmpBitmap[BitmapStore.Counter].Width;
        BitmapStore.tmpRecolorDone[BitmapStore.Counter] = false;
        BitmapStore.tmpOverloadCounter[BitmapStore.Counter] = 1;
        if (!flag & BitmapStore.tmpIsBig[BitmapStore.Counter])
        {
          String1_1: String = BitmapStore.MakeBigString(filename);
          coordinate.x = -1;
          if (coordinate.x > -1 | File.Exists(BitmapStore.GraphicsPath + String1_1))
          {
            if (coordinate.x == -1)
            {
              try
              {
                tmpbmp = BitmapStore.LoadBitmap(BitmapStore.GraphicsPath + String1_1);
                tmpbmp.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                int num = (int) Interaction.MsgBox((object) ("Faulty File " + String1_1));
                ProjectData.ClearProjectError();
              }
            }
            else
              BitmapStore.tmpBigBitmap[BitmapStore.Counter] = BitmapStore.GfxSheetObj[coordinate.x].Bmp.Clone(BitmapStore.GfxSheetObj[coordinate.x].Rect[coordinate.y], PixelFormat.Format32bppPArgb);
          }
          else
          {
            tmpbmp = new Bitmap(BitmapStore.tmpBitmap[BitmapStore.Counter].Width * 2, BitmapStore.tmpBitmap[BitmapStore.Counter].Height * 2, PixelFormat.Format32bppPArgb);
            tmpbmp.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
            int num1 = BitmapStore.tmpBitmap[BitmapStore.Counter].Height - 1;
            for (int y = 0; y <= num1; y += 1)
            {
              int num2 = BitmapStore.tmpBitmap[BitmapStore.Counter].Width - 1;
              for (int x = 0; x <= num2; x += 1)
              {
                Color color = BitmapStore.tmpBitmap[BitmapStore.Counter].GetPixel(x, y);
                if (Strings.InStr(String1_1, ".bmp") > 0 & color.A == (byte) 0)
                  color = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue);
                tmpbmp.SetPixel(x * 2, y * 2, color);
                tmpbmp.SetPixel(x * 2 + 1, y * 2, color);
                tmpbmp.SetPixel(x * 2, y * 2 + 1, color);
                tmpbmp.SetPixel(x * 2 + 1, y * 2 + 1, color);
              }
            }
            if (tmpbmp.GetPixel(0, 0) == Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue))
              tmpbmp.MakeTransparent(Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue));
            if (Strings.InStr(String1_1, ".bmp") > 0)
              DrawMod.TGame.HandyFunctionsObj.SaveBitmapAsBmp(tmpbmp, BitmapStore.GraphicsPath + String1_1);
            else if (Strings.InStr(String1_1, ".jpg") > 0)
              DrawMod.TGame.HandyFunctionsObj.SaveBitmapAsJpeg(tmpbmp, BitmapStore.GraphicsPath + String1_1);
            else
              DrawMod.TGame.HandyFunctionsObj.SaveBitmapAsPing(tmpbmp, BitmapStore.GraphicsPath + String1_1);
          }
          if (coordinate.x == -1)
            BitmapStore.tmpBigBitmap[BitmapStore.Counter] = tmpbmp;
          coordinate.x = -1;
          String1_2: String = BitmapStore.MakeSmallString(filename);
          if (coordinate.x > -1 | File.Exists(BitmapStore.GraphicsPath + String1_2))
          {
            if (coordinate.x == -1)
            {
              try
              {
                tmpbmp = BitmapStore.LoadBitmap(BitmapStore.GraphicsPath + String1_2);
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                int num = (int) Interaction.MsgBox((object) ("Faulty File " + String1_2));
                ProjectData.ClearProjectError();
              }
            }
            else
              BitmapStore.tmpSmallBitmap[BitmapStore.Counter] = BitmapStore.GfxSheetObj[coordinate.x].Bmp.Clone(BitmapStore.GfxSheetObj[coordinate.x].Rect[coordinate.y], PixelFormat.Format32bppPArgb);
          }
          else
          {
            tmpbmp = new Bitmap((int) Math.Round(Conversion.Int((double) BitmapStore.tmpBitmap[BitmapStore.Counter].Width / 2.0)), (int) Math.Round(Conversion.Int((double) BitmapStore.tmpBitmap[BitmapStore.Counter].Height / 2.0)), PixelFormat.Format32bppPArgb);
            tmpbmp.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
            if (tmpbmp.Height == 24 | tmpbmp.Height == 264 & tmpbmp.Width == 192)
            {
              int num3 = tmpbmp.Height - 1;
              for (int y = 0; y <= num3; y += 1)
              {
                int num4 = tmpbmp.Width - 1;
                for (int x = 0; x <= num4; x += 1)
                {
                  if (BitmapStore.SmallShape.GetPixel(x % 32, y % 24).A == byte.MaxValue)
                  {
                    int num5 = 0;
                    int num6 = 0;
                    int num7 = 0;
                    int num8 = 0;
                    int num9 = 0;
                    Color pixel = BitmapStore.tmpBitmap[BitmapStore.Counter].GetPixel(x * 2, y * 2);
                    if (pixel.A > (byte) 0)
                    {
                      num5 += (int) pixel.R;
                      num6 += (int) pixel.G;
                      num7 += (int) pixel.B;
                      num8 += (int) pixel.A;
                      num9 += 1;
                    }
                    if (x < tmpbmp.Width - 1)
                    {
                      pixel = BitmapStore.tmpBitmap[BitmapStore.Counter].GetPixel(x * 2 + 1, y * 2);
                      if (pixel.A > (byte) 0)
                      {
                        num5 += (int) pixel.R;
                        num6 += (int) pixel.G;
                        num7 += (int) pixel.B;
                        num8 += (int) pixel.A;
                        num9 += 1;
                      }
                    }
                    if (y < tmpbmp.Height - 1)
                    {
                      pixel = BitmapStore.tmpBitmap[BitmapStore.Counter].GetPixel(x * 2, y * 2 + 1);
                      if (pixel.A > (byte) 0)
                      {
                        num5 += (int) pixel.R;
                        num6 += (int) pixel.G;
                        num7 += (int) pixel.B;
                        num8 += (int) pixel.A;
                        num9 += 1;
                      }
                    }
                    if (x < tmpbmp.Width - 1 & y < tmpbmp.Height - 1)
                    {
                      pixel = BitmapStore.tmpBitmap[BitmapStore.Counter].GetPixel(x * 2 + 1, y * 2 + 1);
                      if (pixel.A > (byte) 0)
                      {
                        num5 += (int) pixel.R;
                        num6 += (int) pixel.G;
                        num7 += (int) pixel.B;
                        num8 += (int) pixel.A;
                        num9 += 1;
                      }
                    }
                    if (num9 > 0)
                    {
                      int red = (int) Math.Round((double) num5 / (double) num9);
                      int green = (int) Math.Round((double) num6 / (double) num9);
                      int blue = (int) Math.Round((double) num7 / (double) num9);
                      int alpha = (int) Math.Round((double) num8 / (double) num9);
                      if (Strings.InStr(String1_2, ".bmp") > 0 & alpha == 0)
                      {
                        alpha = (int) byte.MaxValue;
                        red = (int) byte.MaxValue;
                        green = 0;
                        blue = (int) byte.MaxValue;
                      }
                      tmpbmp.SetPixel(x, y, Color.FromArgb(alpha, red, green, blue));
                    }
                    else if (Strings.InStr(String1_2, ".bmp") > 0)
                    {
                      int maxValue1 = (int) byte.MaxValue;
                      int maxValue2 = (int) byte.MaxValue;
                      int green = 0;
                      int maxValue3 = (int) byte.MaxValue;
                      tmpbmp.SetPixel(x, y, Color.FromArgb(maxValue1, maxValue2, green, maxValue3));
                    }
                  }
                  else if (Strings.InStr(String1_2, ".bmp") > 0)
                    tmpbmp.SetPixel(x, y, Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue));
                }
              }
            }
            else
            {
              int num10 = tmpbmp.Height - 1;
              for (int y = 0; y <= num10; y += 1)
              {
                int num11 = tmpbmp.Width - 1;
                for (int x = 0; x <= num11; x += 1)
                {
                  int num12 = 0;
                  int num13 = 0;
                  int num14 = 0;
                  int num15 = 0;
                  int num16 = 0;
                  Color pixel = BitmapStore.tmpBitmap[BitmapStore.Counter].GetPixel(x * 2, y * 2);
                  if (pixel.A > (byte) 0)
                  {
                    num12 += (int) pixel.R;
                    num13 += (int) pixel.G;
                    num14 += (int) pixel.B;
                    num15 += (int) pixel.A;
                    num16 += 1;
                  }
                  if (x < tmpbmp.Width - 1)
                  {
                    pixel = BitmapStore.tmpBitmap[BitmapStore.Counter].GetPixel(x * 2 + 1, y * 2);
                    if (pixel.A > (byte) 0)
                    {
                      num12 += (int) pixel.R;
                      num13 += (int) pixel.G;
                      num14 += (int) pixel.B;
                      num15 += (int) pixel.A;
                      num16 += 1;
                    }
                  }
                  if (y < tmpbmp.Height - 1)
                  {
                    pixel = BitmapStore.tmpBitmap[BitmapStore.Counter].GetPixel(x * 2, y * 2 + 1);
                    if (pixel.A > (byte) 0)
                    {
                      num12 += (int) pixel.R;
                      num13 += (int) pixel.G;
                      num14 += (int) pixel.B;
                      num15 += (int) pixel.A;
                      num16 += 1;
                    }
                  }
                  if (x > 0)
                  {
                    pixel = BitmapStore.tmpBitmap[BitmapStore.Counter].GetPixel(x * 2 - 1, y * 2);
                    if (pixel.A > (byte) 0)
                    {
                      num12 += (int) pixel.R;
                      num13 += (int) pixel.G;
                      num14 += (int) pixel.B;
                      num15 += (int) pixel.A;
                      num16 += 1;
                    }
                  }
                  if (y > 0)
                  {
                    pixel = BitmapStore.tmpBitmap[BitmapStore.Counter].GetPixel(x * 2, y * 2 - 1);
                    if (pixel.A > (byte) 0)
                    {
                      num12 += (int) pixel.R;
                      num13 += (int) pixel.G;
                      num14 += (int) pixel.B;
                      num15 += (int) pixel.A;
                      num16 += 1;
                    }
                  }
                  if (num16 > 0)
                  {
                    int red = (int) Math.Round((double) num12 / (double) num16);
                    int green = (int) Math.Round((double) num13 / (double) num16);
                    int blue = (int) Math.Round((double) num14 / (double) num16);
                    int alpha = (int) Math.Round((double) num15 / (double) num16);
                    if (Strings.InStr(String1_2, ".bmp") > 0 & alpha == 0)
                    {
                      alpha = (int) byte.MaxValue;
                      red = (int) byte.MaxValue;
                      green = 0;
                      blue = (int) byte.MaxValue;
                    }
                    tmpbmp.SetPixel(x, y, Color.FromArgb(alpha, red, green, blue));
                  }
                  else if (Strings.InStr(String1_2, ".bmp") > 0)
                  {
                    int maxValue4 = (int) byte.MaxValue;
                    int maxValue5 = (int) byte.MaxValue;
                    int green = 0;
                    int maxValue6 = (int) byte.MaxValue;
                    tmpbmp.SetPixel(x, y, Color.FromArgb(maxValue4, maxValue5, green, maxValue6));
                  }
                }
              }
            }
            if (tmpbmp.GetPixel(0, 0) == Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue))
              tmpbmp.MakeTransparent(Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue));
            if (Strings.InStr(String1_2, ".bmp") > 0)
              DrawMod.TGame.HandyFunctionsObj.SaveBitmapAsBmp(tmpbmp, BitmapStore.GraphicsPath + String1_2);
            else if (Strings.InStr(String1_2, ".jpg") > 0)
              DrawMod.TGame.HandyFunctionsObj.SaveBitmapAsJpeg(tmpbmp, BitmapStore.GraphicsPath + String1_2);
            else
              DrawMod.TGame.HandyFunctionsObj.SaveBitmapAsPing(tmpbmp, BitmapStore.GraphicsPath + String1_2);
          }
          if (coordinate.x == -1)
            BitmapStore.tmpSmallBitmap[BitmapStore.Counter] = tmpbmp;
        }
        if (!Information.IsNothing((object) Expression))
        {
          Expression.Dispose();
          Expression = (Graphics) null;
        }
        return BitmapStore.Counter;
      }
      BitmapStore.tmpFileName[index1] = filename;
      BitmapStore.tmpIsSystem[index1] = IsSystem;
      BitmapStore.tmpIsBig[index1] = IsBig;
      Bitmap bitmap;
      try
      {
        bitmap = BitmapStore.LoadBitmap(BitmapStore.GraphicsPath + filename);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        if (Strings.InStr(filename.ToLower(), "air") > 0)
        {
          bitmap = new Bitmap(64, 48, PixelFormat.Format32bppPArgb);
          bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        }
        else if (Interaction.MsgBox((object) ("Did not find: " + BitmapStore.GraphicsPath + filename + "  Do you want to continue?"), MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
        {
          bitmap = new Bitmap(64, 48, PixelFormat.Format32bppPArgb);
          bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        }
        else
          ProjectData.EndApp();
        ProjectData.ClearProjectError();
      }
      BitmapStore.tmpBitmap[index1] = bitmap;
      BitmapStore.tmpWidth[index1] = BitmapStore.tmpBitmap[index1].Width;
      BitmapStore.tmpRecolorDone[index1] = false;
      if (!forceReload)
        BitmapStore.tmpOverloadCounter[index1] = 1;
      if (BitmapStore.tmpIsBig[index1])
      {
        String1_3: String = BitmapStore.MakeBigString(filename);
        Bitmap tmpbmp1;
        try
        {
          tmpbmp1 = BitmapStore.LoadBitmap(BitmapStore.GraphicsPath + String1_3);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          tmpbmp1 = new Bitmap(BitmapStore.tmpBitmap[index1].Width * 2, BitmapStore.tmpBitmap[index1].Height * 2, PixelFormat.Format32bppPArgb);
          tmpbmp1.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
          int num17 = BitmapStore.tmpBitmap[index1].Height - 1;
          for (int y = 0; y <= num17; y += 1)
          {
            int num18 = BitmapStore.tmpBitmap[index1].Width - 1;
            for (int x = 0; x <= num18; x += 1)
            {
              Color color = BitmapStore.tmpBitmap[index1].GetPixel(x, y);
              if (Strings.InStr(String1_3, ".bmp") > 0 & color.A == (byte) 0)
                color = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue);
              tmpbmp1.SetPixel(x * 2, y * 2, color);
              tmpbmp1.SetPixel(x * 2 + 1, y * 2, color);
              tmpbmp1.SetPixel(x * 2, y * 2 + 1, color);
              tmpbmp1.SetPixel(x * 2 + 1, y * 2 + 1, color);
            }
          }
          if (tmpbmp1.GetPixel(0, 0) == Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue))
            tmpbmp1.MakeTransparent(Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue));
          if (Strings.InStr(String1_3, ".bmp") > 0)
            DrawMod.TGame.HandyFunctionsObj.SaveBitmapAsPing(tmpbmp1, BitmapStore.GraphicsPath + String1_3);
          else if (Strings.InStr(String1_3, ".jpg") > 0)
            DrawMod.TGame.HandyFunctionsObj.SaveBitmapAsJpeg(tmpbmp1, BitmapStore.GraphicsPath + String1_3);
          else
            DrawMod.TGame.HandyFunctionsObj.SaveBitmapAsPing(tmpbmp1, BitmapStore.GraphicsPath + String1_3);
          if (tmpbmp1.GetPixel(0, 0) == Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue))
            tmpbmp1.MakeTransparent(Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue));
          ProjectData.ClearProjectError();
        }
        BitmapStore.tmpBigBitmap[index1] = tmpbmp1;
        String1_4: String = BitmapStore.MakeSmallString(filename);
        Bitmap tmpbmp2;
        try
        {
          tmpbmp2 = BitmapStore.LoadBitmap(BitmapStore.GraphicsPath + String1_4);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          tmpbmp2 = new Bitmap((int) Math.Round(Conversion.Int((double) BitmapStore.tmpBitmap[index1].Width / 2.0)), (int) Math.Round(Conversion.Int((double) BitmapStore.tmpBitmap[index1].Height / 2.0)), PixelFormat.Format32bppPArgb);
          tmpbmp2.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
          if (tmpbmp2.Height == 24 | tmpbmp2.Height == 264 & tmpbmp2.Width == 192)
          {
            int num19 = tmpbmp2.Height - 1;
            for (int y = 0; y <= num19; y += 1)
            {
              int num20 = tmpbmp2.Width - 1;
              for (int x = 0; x <= num20; x += 1)
              {
                if (BitmapStore.SmallShape.GetPixel(x % 32, y % 24).A == byte.MaxValue)
                {
                  int num21 = 0;
                  int num22 = 0;
                  int num23 = 0;
                  int num24 = 0;
                  int num25 = 0;
                  Color pixel = BitmapStore.tmpBitmap[index1].GetPixel(x * 2, y * 2);
                  if (pixel.A > (byte) 0)
                  {
                    num21 += (int) pixel.R;
                    num22 += (int) pixel.G;
                    num23 += (int) pixel.B;
                    num24 += (int) pixel.A;
                    num25 += 1;
                  }
                  if (x < tmpbmp2.Width - 1)
                  {
                    pixel = BitmapStore.tmpBitmap[index1].GetPixel(x * 2 + 1, y * 2);
                    if (pixel.A > (byte) 0)
                    {
                      num21 += (int) pixel.R;
                      num22 += (int) pixel.G;
                      num23 += (int) pixel.B;
                      num24 += (int) pixel.A;
                      num25 += 1;
                    }
                  }
                  if (y < tmpbmp2.Height - 1)
                  {
                    pixel = BitmapStore.tmpBitmap[index1].GetPixel(x * 2, y * 2 + 1);
                    if (pixel.A > (byte) 0)
                    {
                      num21 += (int) pixel.R;
                      num22 += (int) pixel.G;
                      num23 += (int) pixel.B;
                      num24 += (int) pixel.A;
                      num25 += 1;
                    }
                  }
                  if (x < tmpbmp2.Width - 1 & y < tmpbmp2.Height - 1)
                  {
                    pixel = BitmapStore.tmpBitmap[index1].GetPixel(x * 2 + 1, y * 2 + 1);
                    if (pixel.A > (byte) 0)
                    {
                      num21 += (int) pixel.R;
                      num22 += (int) pixel.G;
                      num23 += (int) pixel.B;
                      num24 += (int) pixel.A;
                      num25 += 1;
                    }
                  }
                  if (num25 > 0)
                  {
                    int red = (int) Math.Round((double) num21 / (double) num25);
                    int green = (int) Math.Round((double) num22 / (double) num25);
                    int blue = (int) Math.Round((double) num23 / (double) num25);
                    int alpha = (int) Math.Round((double) num24 / (double) num25);
                    if (Strings.InStr(String1_4, ".bmp") > 0 & alpha == 0)
                    {
                      alpha = (int) byte.MaxValue;
                      red = (int) byte.MaxValue;
                      green = 0;
                      blue = (int) byte.MaxValue;
                    }
                    tmpbmp2.SetPixel(x, y, Color.FromArgb(alpha, red, green, blue));
                  }
                  else if (Strings.InStr(String1_4, ".bmp") > 0)
                  {
                    int maxValue7 = (int) byte.MaxValue;
                    int maxValue8 = (int) byte.MaxValue;
                    int green = 0;
                    int maxValue9 = (int) byte.MaxValue;
                    tmpbmp2.SetPixel(x, y, Color.FromArgb(maxValue7, maxValue8, green, maxValue9));
                  }
                }
                else if (Strings.InStr(String1_4, ".bmp") > 0)
                  tmpbmp2.SetPixel(x, y, Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue));
              }
            }
          }
          else
          {
            int num26 = tmpbmp2.Height - 1;
            for (int y = 0; y <= num26; y += 1)
            {
              int num27 = tmpbmp2.Width - 1;
              for (int x = 0; x <= num27; x += 1)
              {
                int num28 = 0;
                int num29 = 0;
                int num30 = 0;
                int num31 = 0;
                int num32 = 0;
                Color pixel = BitmapStore.tmpBitmap[index1].GetPixel(x * 2, y * 2);
                if (pixel.A > (byte) 0)
                {
                  num28 += (int) pixel.R;
                  num29 += (int) pixel.G;
                  num30 += (int) pixel.B;
                  num31 += (int) pixel.A;
                  num32 += 1;
                }
                if (x < tmpbmp2.Width - 1)
                {
                  pixel = BitmapStore.tmpBitmap[index1].GetPixel(x * 2 + 1, y * 2);
                  if (pixel.A > (byte) 0)
                  {
                    num28 += (int) pixel.R;
                    num29 += (int) pixel.G;
                    num30 += (int) pixel.B;
                    num31 += (int) pixel.A;
                    num32 += 1;
                  }
                }
                if (y < tmpbmp2.Height - 1)
                {
                  pixel = BitmapStore.tmpBitmap[index1].GetPixel(x * 2, y * 2 + 1);
                  if (pixel.A > (byte) 0)
                  {
                    num28 += (int) pixel.R;
                    num29 += (int) pixel.G;
                    num30 += (int) pixel.B;
                    num31 += (int) pixel.A;
                    num32 += 1;
                  }
                }
                if (x > 0)
                {
                  pixel = BitmapStore.tmpBitmap[index1].GetPixel(x * 2 - 1, y * 2);
                  if (pixel.A > (byte) 0)
                  {
                    num28 += (int) pixel.R;
                    num29 += (int) pixel.G;
                    num30 += (int) pixel.B;
                    num31 += (int) pixel.A;
                    num32 += 1;
                  }
                }
                if (y > 0)
                {
                  pixel = BitmapStore.tmpBitmap[index1].GetPixel(x * 2, y * 2 - 1);
                  if (pixel.A > (byte) 0)
                  {
                    num28 += (int) pixel.R;
                    num29 += (int) pixel.G;
                    num30 += (int) pixel.B;
                    num31 += (int) pixel.A;
                    num32 += 1;
                  }
                }
                if (num32 > 0)
                {
                  int red = (int) Math.Round((double) num28 / (double) num32);
                  int green = (int) Math.Round((double) num29 / (double) num32);
                  int blue = (int) Math.Round((double) num30 / (double) num32);
                  int alpha = (int) Math.Round((double) num31 / (double) num32);
                  if (Strings.InStr(String1_4, ".bmp") > 0 & alpha == 0)
                  {
                    alpha = (int) byte.MaxValue;
                    red = (int) byte.MaxValue;
                    green = 0;
                    blue = (int) byte.MaxValue;
                  }
                  tmpbmp2.SetPixel(x, y, Color.FromArgb(alpha, red, green, blue));
                }
                else if (Strings.InStr(String1_4, ".bmp") > 0)
                {
                  int maxValue10 = (int) byte.MaxValue;
                  int maxValue11 = (int) byte.MaxValue;
                  int green = 0;
                  int maxValue12 = (int) byte.MaxValue;
                  tmpbmp2.SetPixel(x, y, Color.FromArgb(maxValue10, maxValue11, green, maxValue12));
                }
              }
            }
          }
          if (tmpbmp2.GetPixel(0, 0) == Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue))
            tmpbmp2.MakeTransparent(Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue));
          if (Strings.InStr(String1_4, ".bmp") > 0)
            DrawMod.TGame.HandyFunctionsObj.SaveBitmapAsBmp(tmpbmp2, BitmapStore.GraphicsPath + String1_4);
          else if (Strings.InStr(String1_4, ".jpg") > 0)
            DrawMod.TGame.HandyFunctionsObj.SaveBitmapAsJpeg(tmpbmp2, BitmapStore.GraphicsPath + String1_4);
          else
            DrawMod.TGame.HandyFunctionsObj.SaveBitmapAsPing(tmpbmp2, BitmapStore.GraphicsPath + String1_4);
          ProjectData.ClearProjectError();
        }
        BitmapStore.tmpSmallBitmap[index1] = tmpbmp2;
      }
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return index1;
    }

    pub static void SetKnownTransparents()
    {
      BitmapStore.tmpKnownTransparent = new bool[BitmapStore.Counter + 1];
      int counter = BitmapStore.Counter;
      for (int index = 0; index <= counter; index += 1)
      {
        if (Strings.InStr(BitmapStore.tmpFileName[index], "/trans.png") > 0)
          BitmapStore.tmpKnownTransparent[index] = true;
        if (Strings.InStr(BitmapStore.tmpFileName[index], "/trans.bmp") > 0)
          BitmapStore.tmpKnownTransparent[index] = true;
      }
    }

    pub static Coordinate GetSheetPos(string s)
    {
      Coordinate sheetPos;
      sheetPos.x = -1;
      int gfxSheetCount1 = BitmapStore.GfxSheetCount;
      for (int index1 = 1; index1 <= gfxSheetCount1; index1 += 1)
      {
        if (Strings.InStr(s, BitmapStore.GfxSheetObj[index1].DirName) == 0 & index1 == BitmapStore.GfxSheetCount)
        {
          int gfxSheetCount2 = BitmapStore.GfxSheetCount;
          BitmapStore.CheckLoadSheet(s);
          if (gfxSheetCount2 < BitmapStore.GfxSheetCount)
            index1 += 1;
        }
        if (Strings.InStr(s, BitmapStore.GfxSheetObj[index1].DirName) > 0)
        {
          str: String = Strings.Right(s, Strings.Len(s) - (Strings.InStr(s, BitmapStore.GfxSheetObj[index1].DirName) - 1)).Replace("/", "\\").Replace("\\\\", "\\");
          int counter = BitmapStore.GfxSheetObj[index1].Counter;
          for (int index2 = 1; index2 <= counter; index2 += 1)
          {
            if (Operators.CompareString(Strings.LCase(BitmapStore.GfxSheetObj[index1].Name[index2]), Strings.LCase(str), false) == 0)
            {
              sheetPos.x = index1;
              sheetPos.y = index2;
              return sheetPos;
            }
          }
        }
        if (index1 >= BitmapStore.GfxSheetCount)
          break;
      }
      return sheetPos;
    }

    pub static void CheckLoadSheet(string s)
    {
      str: String = Strings.Right(s, Strings.Len(s) - Strings.Len(DrawMod.TGame.AppPath + "graphics/"));
      if (Strings.InStr(str, "/") > 0)
        str = Strings.Left(str, Strings.InStr(str, "/") - 1);
      else if ((uint) Strings.InStr(str, "\\") > 0U)
        str = Strings.Left(str, Strings.InStr(str, "\\") - 1);
      int gfxSheetCount = BitmapStore.GfxSheetCount;
      for (int index = 1; index <= gfxSheetCount; index += 1)
      {
        if (Operators.CompareString(BitmapStore.GfxSheetObj[index].DirName, str, false) == 0)
          return;
      }
      BitmapStore += 1.GfxSheetCount;
      BitmapStore.GfxSheetObj = (GfxSheetClass[]) Utils.CopyArray((Array) BitmapStore.GfxSheetObj, (Array) new GfxSheetClass[BitmapStore.GfxSheetCount + 1]);
      BitmapStore.GfxSheetObj[BitmapStore.GfxSheetCount] = GfxSheetClass::new();
      if (File.Exists(BitmapStore.GraphicsPath + str + "/sheet.txt"))
        BitmapStore.GfxSheetObj[BitmapStore.GfxSheetCount].Load(str);
      BitmapStore.GfxSheetObj[BitmapStore.GfxSheetCount].DirName = str;
    }

    pub static Bitmap GetBitmap(int nr, int Zoom = 0)
    {
      switch (Zoom)
      {
        case -1:
          return BitmapStore.tmpSmallBitmap[nr];
        case 0:
          return BitmapStore.tmpBitmap[nr];
        case 1:
          return BitmapStore.tmpBigBitmap[nr];
        default:
          Bitmap bitmap;
          return bitmap;
      }
    }

    pub static string GetFileName(int nr) => BitmapStore.tmpFileName[nr];

    pub static int GetWidth(int nr, int zoom = 0)
    {
      if (zoom != -1)
        return BitmapStore.tmpWidth[nr] * (zoom + 1);
      return Information.IsNothing((object) BitmapStore.tmpSmallBitmap[nr]) ? 0 : BitmapStore.tmpSmallBitmap[nr].Width;
    }

    pub static int Getheight(int nr, int zoom = 0) => zoom == -1 ? BitmapStore.tmpSmallBitmap[nr].Height : BitmapStore.tmpBitmap[nr].Height * (zoom + 1);

    pub static void DeleteAllBitmaps()
    {
      int num = -1;
      if (BitmapStore.Counter > -1)
      {
        int counter = BitmapStore.Counter;
        for (int index = 0; index <= counter; index += 1)
        {
          if (!BitmapStore.tmpIsSystem[index])
          {
            if (num == -1)
              num = index;
            BitmapStore.tmpBitmap[index] = (Bitmap) null;
            BitmapStore.tmpBigBitmap[index] = (Bitmap) null;
            BitmapStore.tmpFileName[index] = "";
            BitmapStore.simpleByteCacheObj[index] = (SimpleByteCache) null;
            BitmapStore.simpleByteCacheSet[index] = false;
          }
        }
        if (num > -1)
        {
          BitmapStore.Counter = num - 1;
          BitmapStore.tmpBitmap = (Bitmap[]) Utils.CopyArray((Array) BitmapStore.tmpBitmap, (Array) new Bitmap[BitmapStore.Counter + 1]);
          BitmapStore.tmpFileName = (string[]) Utils.CopyArray((Array) BitmapStore.tmpFileName, (Array) new string[BitmapStore.Counter + 1]);
          BitmapStore.oldFileName = (string[]) Utils.CopyArray((Array) BitmapStore.oldFileName, (Array) new string[BitmapStore.Counter + 1]);
          BitmapStore.tmpFlag = (bool[]) Utils.CopyArray((Array) BitmapStore.tmpFlag, (Array) new bool[BitmapStore.Counter + 1]);
          BitmapStore.tmpIsSystem = (bool[]) Utils.CopyArray((Array) BitmapStore.tmpIsSystem, (Array) new bool[BitmapStore.Counter + 1]);
          BitmapStore.tmpOverloadCounter = (int[]) Utils.CopyArray((Array) BitmapStore.tmpOverloadCounter, (Array) new int[BitmapStore.Counter + 1]);
          BitmapStore.tmpWidth = (int[]) Utils.CopyArray((Array) BitmapStore.tmpWidth, (Array) new int[BitmapStore.Counter + 1]);
          BitmapStore.tmpRecolorDone = (bool[]) Utils.CopyArray((Array) BitmapStore.tmpRecolorDone, (Array) new bool[BitmapStore.Counter + 1]);
          BitmapStore.tmpBigBitmap = (Bitmap[]) Utils.CopyArray((Array) BitmapStore.tmpBigBitmap, (Array) new Bitmap[BitmapStore.Counter + 1]);
          BitmapStore.tmpIsBig = (bool[]) Utils.CopyArray((Array) BitmapStore.tmpIsBig, (Array) new bool[BitmapStore.Counter + 1]);
          BitmapStore.simpleByteCacheObj = (SimpleByteCache[]) Utils.CopyArray((Array) BitmapStore.simpleByteCacheObj, (Array) new SimpleByteCache[BitmapStore.Counter + 1]);
          BitmapStore.simpleByteCacheSet = (bool[]) Utils.CopyArray((Array) BitmapStore.simpleByteCacheSet, (Array) new bool[BitmapStore.Counter + 1]);
        }
      }
      BitmapStore.DeleteGfxSheets();
    }

    pub static void DeleteFlaggedBitmaps()
    {
      int num = -1;
      if (BitmapStore.Counter <= -1)
        return;
      int counter = BitmapStore.Counter;
      for (int index = 0; index <= counter; index += 1)
      {
        if (!BitmapStore.tmpIsSystem[index] & BitmapStore.tmpFlag[index] & BitmapStore.tmpOverloadCounter[index] == 0)
        {
          if (num == -1)
            num = index;
          if (!Information.IsNothing((object) BitmapStore.tmpBitmap[index]))
            BitmapStore.tmpBitmap[index].Dispose();
          if (!Information.IsNothing((object) BitmapStore.tmpBigBitmap[index]))
            BitmapStore.tmpBigBitmap[index].Dispose();
          if (!Information.IsNothing((object) BitmapStore.tmpSmallBitmap[index]))
            BitmapStore.tmpSmallBitmap[index].Dispose();
          BitmapStore.tmpBitmap[index] = (Bitmap) null;
          BitmapStore.tmpBigBitmap[index] = (Bitmap) null;
          BitmapStore.tmpSmallBitmap[index] = (Bitmap) null;
          BitmapStore.tmpFileName[index] = "";
          BitmapStore.tmpFlag[index] = false;
          BitmapStore.simpleByteCacheObj[index] = (SimpleByteCache) null;
          BitmapStore.simpleByteCacheSet[index] = false;
        }
      }
    }

    pub static void FlagForDelete()
    {
      if (BitmapStore.Counter <= -1)
        return;
      BitmapStore.tmpFlag = new bool[BitmapStore.Counter + 1];
      int counter = BitmapStore.Counter;
      for (int index = 0; index <= counter; index += 1)
      {
        BitmapStore.tmpFlag[index] = false;
        if (!BitmapStore.tmpIsSystem[index])
        {
          BitmapStore.tmpFlag[index] = true;
          BitmapStore.tmpOverloadCounter[index] = 0;
        }
      }
    }

    pub static void DeleteGfxSheets()
    {
      int gfxSheetCount = BitmapStore.GfxSheetCount;
      for (int index = 1; index <= gfxSheetCount; index += 1)
      {
        if (!Information.IsNothing((object) BitmapStore.GfxSheetObj[index].Bmp))
          BitmapStore.GfxSheetObj[index].Bmp.Dispose();
      }
      BitmapStore.GfxSheetObj = new GfxSheetClass[1];
      BitmapStore.GfxSheetCount = 0;
    }
  }
}
