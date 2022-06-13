// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ATHexSubPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  pub class ATHexSubPartClass : SubPartClass
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

    pub ATHexSubPartClass(int tx, int ty, GameClass tgame, bool tIgnoreAttack = false)
      : base(200, 82)
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
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      int landscapeType = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.x, this.y].LandscapeType;
      int spriteNr = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.x, this.y].SpriteNr;
      if (this.game.Data.Round > 0 && this.game.Data.ShrowdOn & this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.x, this.y].get_SeeNow(this.game.Data.Turn) < 1)
      {
        DrawMod.DrawBlock(ref graphics, 0, 0, 200, 82, 0, 0, 0, (int) byte.MaxValue);
        string str;
        tstring: String = str + "Shrouded (" + Conversion.Str((object) this.x) + "," + Conversion.Str((object) this.y) + ")";
        DrawMod.DrawText(ref graphics, tstring, Font::new("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Pixel), 10, 35);
        return this.OwnBitmap;
      }
      if (landscapeType > -1 & spriteNr > -1)
      {
        Bitmap bitmap;
        if ((double) this.game.Data.RuleVar[869] == 0.0 | (double) this.game.Data.RuleVar[869] == 3.0)
        {
          int nr = this.game.Data.LandscapeTypeObj[landscapeType].BasicPicID[spriteNr];
          ref Graphics local1 = ref graphics;
          bitmap = BitmapStore.GetBitmap(nr);
          ref Bitmap local2 = ref bitmap;
          DrawMod.DrawScaled(ref local1, ref local2, 0, 0, 200, 82);
        }
        else
        {
          if ((double) this.game.Data.RuleVar[869] == 1.0)
          {
            int nr = this.game.Data.LandscapeTypeObj[landscapeType].SidewaysSPriteID1[spriteNr];
            ref Graphics local3 = ref graphics;
            bitmap = BitmapStore.GetBitmap(nr);
            ref Bitmap local4 = ref bitmap;
            DrawMod.DrawScaled(ref local3, ref local4, 0, 0, 200, 82);
          }
          int nr1 = this.game.Data.LandscapeTypeObj[landscapeType].SidewaysSPriteID2[spriteNr];
          ref Graphics local5 = ref graphics;
          bitmap = BitmapStore.GetBitmap(nr1);
          ref Bitmap local6 = ref bitmap;
          DrawMod.DrawScaled(ref local5, ref local6, 0, 0, 200, 82);
          int nr2 = this.game.Data.LandscapeTypeObj[landscapeType].SidewaysSPriteID3[spriteNr];
          ref Graphics local7 = ref graphics;
          bitmap = BitmapStore.GetBitmap(nr2);
          ref Bitmap local8 = ref bitmap;
          DrawMod.DrawScaled(ref local7, ref local8, 0, 0, 200, 82);
        }
        if (this.game.Data.MapObj[0].HexObj[this.x, this.y].Location > -1 && this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.x, this.y].Location].Type].PictureLT > -1)
        {
          if ((double) this.game.Data.RuleVar[869] == 0.0 | (double) this.game.Data.RuleVar[869] == 3.0)
          {
            int nr = this.game.Data.LandscapeTypeObj[this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.x, this.y].Location].Type].PictureLT].BasicPicID[this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.x, this.y].Location].Type].PictureSprite];
            ref Graphics local9 = ref graphics;
            bitmap = BitmapStore.GetBitmap(nr);
            ref Bitmap local10 = ref bitmap;
            DrawMod.DrawScaled(ref local9, ref local10, 0, 0, 200, 82);
          }
          else
          {
            if ((double) this.game.Data.RuleVar[869] == 1.0)
            {
              int nr = this.game.Data.LandscapeTypeObj[this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.x, this.y].Location].Type].PictureLT].SidewaysSPriteID1[this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.x, this.y].Location].Type].PictureSprite];
              ref Graphics local11 = ref graphics;
              bitmap = BitmapStore.GetBitmap(nr);
              ref Bitmap local12 = ref bitmap;
              DrawMod.DrawScaled(ref local11, ref local12, 0, 0, 200, 82);
            }
            int nr3 = this.game.Data.LandscapeTypeObj[this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.x, this.y].Location].Type].PictureLT].SidewaysSPriteID2[this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.x, this.y].Location].Type].PictureSprite];
            ref Graphics local13 = ref graphics;
            bitmap = BitmapStore.GetBitmap(nr3);
            ref Bitmap local14 = ref bitmap;
            DrawMod.DrawScaled(ref local13, ref local14, 0, 0, 200, 82);
            int nr4 = this.game.Data.LandscapeTypeObj[this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.x, this.y].Location].Type].PictureLT].SidewaysSPriteID3[this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.x, this.y].Location].Type].PictureSprite];
            ref Graphics local15 = ref graphics;
            bitmap = BitmapStore.GetBitmap(nr4);
            ref Bitmap local16 = ref bitmap;
            DrawMod.DrawScaled(ref local15, ref local16, 0, 0, 200, 82);
          }
        }
      }
      DrawMod.DrawRectangle(ref graphics, 0, 0, 199, 81, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
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
            int num5 = (int) Math.Round(170.0 / (Conversion.Int((double) num3 / 2.0) + 1.0));
            if (num5 > 37)
              num5 = 37;
            int num6 = (int) Math.Round(Conversion.Int((double) (unitCounter2 + 1) / 2.0));
            if (num6 < 4)
              num6 = 4;
            int ty;
            int tx;
            if (index < num6)
            {
              ty = 2;
              tx = 2 + num4 * num5;
            }
            else
            {
              ty = 41;
              tx = 2 + (num4 - num6) * num5;
            }
            bool forcehighlight = false;
            if (this.game.EditObj.UnitSelected == unit)
              forcehighlight = true;
            this.game.CustomBitmapObj.DrawUnit(unit, forcehighlight, graphics, tx, ty, true);
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
              int ty = 2;
              int num = (int) Math.Round(170.0 / (double) (unitCounter + 1));
              if (num > 39)
                num = 39;
              int tx = 2 + index * num;
              this.game.CustomBitmapObj.DrawUnit(unit, true, graphics, tx, ty);
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
              int ty = 41;
              int num8 = (int) Math.Round(170.0 / (double) (counter + 1));
              if (num8 > 37)
                num8 = 37;
              int tx = 2 + index * num8;
              this.game.CustomBitmapObj.DrawUnit(num7, true, graphics, tx, ty);
              this += 1.mzcount;
              this.mzx[this.mzcount] = tx;
              this.mzy[this.mzcount] = ty;
              this.mznr[this.mzcount] = num7;
            }
          }
        }
      }
      if (!Information.IsNothing((object) graphics))
      {
        graphics.Dispose();
        graphics = (Graphics) null;
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
      ref Graphics local1 = ref graphics;
      Bitmap bitmap = BitmapStore.GetBitmap(Conversions.ToInteger(this.OwnBitmapNr));
      ref Bitmap local2 = ref bitmap;
      DrawMod.Draw(ref local1, ref local2, 0, 0, 0.3f, 0.3f, 0.3f, 1f);
      return this.OwnBitmap;
    }
  }
}
