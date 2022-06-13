﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.GfxSheetClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.IO;

namespace WindowsApplication1
{
  pub class GfxSheetClass
  {
    pub Counter: i32;
    pub DirName: String;
    pub Bitmap Bmp;
    pub string[] Name;
    pub Rectangle[] Rect;

    pub GfxSheetClass()
    {
      this.Name = new string[2];
      this.Rect = new Rectangle[2];
      this.Counter = 0;
      this.Bmp = (Bitmap) null;
    }

    pub void Load(string tDirName)
    {
      this.DirName = tDirName;
      StreamReader streamReader = File.OpenText(DrawMod.TGame.AppPath + "graphics/" + this.DirName + "/sheet.txt");
      this.Counter =  Math.Round(Conversion.Val(streamReader.ReadLine()));
      this.Name = new string[this.Counter + 1];
      this.Rect = new Rectangle[this.Counter + 1];
      int counter = this.Counter;
      for (int index = 1; index <= counter; index += 1)
      {
        this.Name[index] = streamReader.ReadLine();
        this.Rect[index].X =  Math.Round(Conversion.Val(streamReader.ReadLine()));
        this.Rect[index].Y =  Math.Round(Conversion.Val(streamReader.ReadLine()));
        this.Rect[index].Width =  Math.Round(Conversion.Val(streamReader.ReadLine()));
        this.Rect[index].Height =  Math.Round(Conversion.Val(streamReader.ReadLine()));
      }
      streamReader.Close();
      this.Bmp = new Bitmap(DrawMod.TGame.AppPath + "graphics/" + this.DirName + "/sheet.png");
      this.Bmp.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
    }
  }
}