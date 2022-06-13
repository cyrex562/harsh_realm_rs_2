// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.HexInfoSubPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  pub class HexInfoSubPartClass : SubPartClass
  {
     object OwnBitmapNr;
     int x;
     int y;
     GameClass game;
     int[] mzx;
     int[] mzy;
     int[] mznr;
     int mzcount;
     int prod;
     bool IgnoreAttack;

    pub HexInfoSubPartClass(int tx, int ty, GameClass tgame, bool tIgnoreAttack = false)
      : base(210, 85)
    {
      this.mzx = new int[401];
      this.mzy = new int[401];
      this.mznr = new int[401];
      this.x = tx;
      this.y = ty;
      this.game = tgame;
      this.prod = 0;
      this.IgnoreAttack = tIgnoreAttack;
    }

    pub void DescriptInfo(int ix, int iy)
    {
      Coordinate coordinate = Coordinate::new();
      if (this.x == -1 | this.y == -1 || this.game.Data.Round == 0)
        return;
      this.Descript = "";
      if (this.mzcount <= -1)
        return;
      int mzcount = this.mzcount;
      for (int index = 0; index <= mzcount; index += 1)
      {
        if (ix > this.mzx[index] & iy > this.mzy[index] & ix < this.mzx[index] + 31 & iy < this.mzy[index] + 31)
        {
          if (this.game.Data.UnitObj[this.mznr[index]].Regime == this.game.Data.Turn | this.game.Data.Round == 0)
            coordinate.x = 3;
          else
            coordinate = this.game.HandyFunctionsObj.GetReconMinusHide(this.mznr[index], this.game.Data.Turn);
          if (coordinate.x >= 2)
            this.Descript = this.game.Data.UnitObj[this.mznr[index]].Name;
          else
            this.Descript = "Unknown Unit";
        }
      }
    }

    pub Bitmap Paint()
    {
      bool flag;
      if (this.game.EditObj.OrderType == 14)
        flag = true;
      if (this.game.EditObj.OrderType == 15)
        flag = true;
      if (this.game.EditObj.OrderType == 2)
        flag = true;
      if (this.game.EditObj.OrderType == 12)
        flag = true;
      if (this.game.EditObj.OrderType == 11)
        flag = true;
      if (this.game.EditObj.OrderType == 13)
        flag = true;
      if (flag & !this.IgnoreAttack)
      {
        this.x = this.game.EditObj.TargetX;
        this.y = this.game.EditObj.TargetY;
      }
      if (this.x == -1 | this.y == -1 || this.game.SelectX == -1 | this.game.SelectY == -1)
      {
        Bitmap bitmap;
        return bitmap;
      }
      Graphics toG = Graphics.FromImage((Image) this.OwnBitmap);
      int landscapeType = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.x, this.y].LandscapeType;
      int spriteNr = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.x, this.y].SpriteNr;
      if (this.game.Data.Round > 0 && this.game.Data.ShrowdOn & this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.x, this.y].get_SeeNow(this.game.Data.Turn) < 1)
      {
        DrawMod.DrawBlock( toG, 0, 0, 210, 85, 0, 0, 0,  byte.MaxValue);
        string str;
        tstring: String = str + "Shrouded (" + Conversion.Str((object) this.x) + "," + Conversion.Str((object) this.y) + ")";
        DrawMod.DrawText( toG, tstring, Font::new("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Pixel), 10, 35);
        return this.OwnBitmap;
      }
      DrawMod.DrawBoxVic( toG, 0, 0, 210, 85, this.game.VicColor1, this.game.VicColor1Shade);
      if (landscapeType > -1 & spriteNr > -1)
      {
        int nr1 = this.game.Data.LandscapeTypeObj[landscapeType].BasicPicID[spriteNr];
         Graphics local1 =  toG;
        Bitmap bitmap = BitmapStore.GetBitmap(nr1);
         Bitmap local2 =  bitmap;
        DrawMod.DrawScaled( local1,  local2, 3, 3, 205, 80);
        if (this.game.Data.MapObj[0].HexObj[this.x, this.y].Location > -1 && this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.x, this.y].Location].Type].PictureLT > -1)
        {
          int nr2 = this.game.Data.LandscapeTypeObj[this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.x, this.y].Location].Type].PictureLT].BasicPicID[this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.x, this.y].Location].Type].PictureSprite];
           Graphics local3 =  toG;
          bitmap = BitmapStore.GetBitmap(nr2);
           Bitmap local4 =  bitmap;
          DrawMod.DrawScaled( local3,  local4, 3, 3, 205, 80);
        }
      }
      this.mzcount = -1;
      if (!flag | this.IgnoreAttack && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.x, this.y].UnitCounter > -1)
      {
        int num1 = -1;
        int unitCounter1 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.x, this.y].UnitCounter;
        int num2 = unitCounter1;
        for (int index = 0; index <= num2; index += 1)
        {
          if (this.game.HandyFunctionsObj.CanWeSeeUnit(this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.x, this.y].UnitList[index], this.game.Data.Turn) > 0)
            num1 += 1;
        }
        int num3 = num1;
        int num4 = unitCounter1 + 1;
        int unitCounter2 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.x, this.y].UnitCounter;
        for (int index = unitCounter2; index >= 0; index += -1)
        {
          int unit = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.x, this.y].UnitList[index];
          if (this.game.HandyFunctionsObj.CanWeSeeUnit(unit, this.game.Data.Turn) > 0)
          {
            --num4;
            int num5 =  Math.Round(170.0 / (Conversion.Int((double) num3 / 2.0) + 1.0));
            if (num5 > 39)
              num5 = 39;
            int num6 =  Math.Round(Conversion.Int((double) (unitCounter2 + 1) / 2.0));
            if (num6 < 4)
              num6 = 4;
            int ty;
            int tx;
            if (index < num6)
            {
              ty = 4;
              tx = 4 + num4 * num5;
            }
            else
            {
              ty = 44;
              tx = 4 + (num4 - num6) * num5;
            }
            bool forcehighlight = false;
            if (this.game.EditObj.UnitSelected == unit)
              forcehighlight = true;
            this.game.CustomBitmapObj.DrawUnit(unit, forcehighlight, toG, tx, ty, true);
            this += 1.mzcount;
            this.mzx[this.mzcount] = tx;
            this.mzy[this.mzcount] = ty;
            this.mznr[this.mzcount] = unit;
          }
        }
      }
      if (flag & !this.IgnoreAttack)
      {
        if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.x, this.y].UnitCounter > -1)
        {
          int unitCounter = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.x, this.y].UnitCounter;
          for (int index = unitCounter; index >= 0; index += -1)
          {
            int unit = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.x, this.y].UnitList[index];
            if (this.game.HandyFunctionsObj.CanWeSeeUnit(unit, this.game.Data.Turn) > 0)
            {
              int ty = 4;
              int num =  Math.Round(170.0 / (double) (unitCounter + 1));
              if (num > 39)
                num = 39;
              int tx = 4 + index * num;
              this.game.CustomBitmapObj.DrawUnit(unit, true, toG, tx, ty);
              this += 1.mzcount;
              this.mzx[this.mzcount] = tx;
              this.mzy[this.mzcount] = ty;
              this.mznr[this.mzcount] = unit;
            }
          }
        }
        if (this.game.EditObj.TempUnitList.counter > -1)
        {
          int counter = this.game.EditObj.TempUnitList.counter;
          for (int index = counter; index >= 0; index += -1)
          {
            int num7 = this.game.EditObj.TempUnitList.unr[index];
            if (this.game.HandyFunctionsObj.CanWeSeeUnit(num7, this.game.Data.Turn) > 0)
            {
              int ty = 44;
              int num8 =  Math.Round(190.0 / (double) (counter + 1));
              if (num8 > 39)
                num8 = 39;
              int tx = 4 + index * num8;
              this.game.CustomBitmapObj.DrawUnit(num7, true, toG, tx, ty);
              this += 1.mzcount;
              this.mzx[this.mzcount] = tx;
              this.mzy[this.mzcount] = ty;
              this.mznr[this.mzcount] = num7;
            }
          }
        }
      }
      return this.OwnBitmap;
    }

    pub int Click(int x, int y, int b = 1)
    {
      if (this.mzcount <= -1)
        return -1;
      for (int mzcount = this.mzcount; mzcount >= 0; mzcount += -1)
      {
        if (x > this.mzx[mzcount] & y > this.mzy[mzcount] & x < this.mzx[mzcount] + 37 & y < this.mzy[mzcount] + 37)
          return this.mznr[mzcount];
      }
      return -1;
    }

    pub Bitmap PaintOverlay()
    {
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
       Graphics local1 =  graphics;
      Bitmap bitmap = BitmapStore.GetBitmap(Conversions.ToInteger(this.OwnBitmapNr));
       Bitmap local2 =  bitmap;
      DrawMod.Draw( local1,  local2, 0, 0, 0.3f, 0.3f, 0.3f, 1f);
      return this.OwnBitmap;
    }
  }
}
