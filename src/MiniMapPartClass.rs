// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.MiniMapPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace WindowsApplication1
{
  pub class MiniMapPartClass : SubPartClass
  {
     GameClass game;
     bool paintview;
     bool alsounits;
     bool realhex;
     int specialMode1;
     int minix;
     int miniy;
     int minimap;
     int MapWidth;
     int MapHeight;
    pub tZoomLevel: i32;
    pub tempAi2Use: bool;
    pub tempValue4mustBe: i32;
    pub tempValue3usedForAlpha: bool;
    pub tempZones: bool;
    pub blockMapMove: bool;

    pub MiniMapPartClass(
      GameClass tgame,
      bool tpaintview = true,
      int tx = 200,
      int ty = 150,
      bool talsounits = false,
      bool trealhex = false,
      int tMapWidth = -1,
      int tMapHeight = -1,
      int ZoomLevel = -1,
      int humanplayer = -1,
      bool alsoHQ = false,
      int ttempValue4mustBe = -1,
      bool tblockMapMove = false,
      bool tTempValue3usedForAlpha = false,
      bool tTempAi2use = false,
      bool tTempZones = false,
      int tspecialMode1 = -1)
      : base(tx, ty)
    {
      this.minix = tx;
      this.miniy = ty;
      this.alsounits = talsounits;
      this.game = tgame;
      this.realhex = trealhex;
      this.tempAi2Use = tTempAi2use;
      this.tempZones = tTempZones;
      this.paintview = tpaintview;
      this.specialMode1 = tspecialMode1;
      this.MapWidth = tMapWidth;
      this.MapHeight = tMapHeight;
      this.tempValue4mustBe = ttempValue4mustBe;
      this.tempValue3usedForAlpha = tTempValue3usedForAlpha;
      this.blockMapMove = tblockMapMove;
      this.tZoomLevel = ZoomLevel != -1 ? ZoomLevel : this.game.EditObj.Zoom;
      if (this.game.Data.MapCounter > 0)
        this.game.EditObj.StratMap = (Bitmap) null;
      if (Information.IsNothing((object) this.game.EditObj.MiniMap))
      {
        this.game.EditObj.MiniMap = new Bitmap(205, 110, PixelFormat.Format32bppPArgb);
        this.game.EditObj.MiniMap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, 205, 110, false);
      }
      if (!(this.game.EditObj.MiniMap.Width == this.minix & this.game.EditObj.MiniMap.Height == this.miniy) | humanplayer > -1)
      {
        if (tx == this.game.ScreenWidth & !Information.IsNothing((object) this.game.EditObj.StratMap))
        {
          if (!Information.IsNothing((object) this.game.CustomBitmapObj.miniMapPredrawnCache))
          {
            this.game.CustomBitmapObj.miniMapPredrawnCache.Dispose();
            this.game.CustomBitmapObj.miniMapPredrawnCache = (Bitmap) null;
          }
          this.game.EditObj.MiniMap = (Bitmap) this.game.EditObj.StratMap.Clone();
          if ((double) this.game.Data.RuleVar[839] < 1.0)
            this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, this.minix, this.miniy, this.alsounits, this.realhex, predrawn: true, humanplayer: humanplayer, showflag: true, alsoHQ: alsoHQ, highlightTempvar4: this.tempValue4mustBe, useTempVar3asAlpha: this.tempValue3usedForAlpha, useTempAi2: this.tempAi2Use, useTempZones: this.tempZones, specialMode1: this.specialMode1);
          else
            this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, this.minix, this.miniy, this.alsounits, this.realhex, predrawn: true, humanplayer: humanplayer, alsoHQ: alsoHQ, highlightTempvar4: this.tempValue4mustBe, useTempVar3asAlpha: this.tempValue3usedForAlpha, useTempAi2: this.tempAi2Use, useTempZones: this.tempZones, specialMode1: this.specialMode1);
        }
        else
        {
          if (!Information.IsNothing((object) this.game.CustomBitmapObj.miniMapPredrawnCache))
          {
            this.game.CustomBitmapObj.miniMapPredrawnCache.Dispose();
            this.game.CustomBitmapObj.miniMapPredrawnCache = (Bitmap) null;
          }
          this.game.EditObj.MiniMap = new Bitmap(this.minix, this.miniy, PixelFormat.Format32bppPArgb);
          this.game.EditObj.MiniMap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
          if ((double) this.game.Data.RuleVar[839] < 1.0)
            this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, this.minix, this.miniy, this.alsounits, this.realhex, humanplayer: humanplayer, showflag: true, alsoHQ: alsoHQ, highlightTempvar4: this.tempValue4mustBe, useTempVar3asAlpha: this.tempValue3usedForAlpha, useTempAi2: this.tempAi2Use, useTempZones: this.tempZones, specialMode1: this.specialMode1);
          else
            this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, this.minix, this.miniy, this.alsounits, this.realhex, humanplayer: humanplayer, alsoHQ: alsoHQ, highlightTempvar4: this.tempValue4mustBe, useTempVar3asAlpha: this.tempValue3usedForAlpha, useTempAi2: this.tempAi2Use, useTempZones: this.tempZones, specialMode1: this.specialMode1);
        }
      }
      else
      {
        if (Information.IsNothing((object) this.game.EditObj.StratMap))
          return;
        this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, this.minix, this.miniy, this.alsounits, this.realhex, humanplayer: humanplayer, alsoHQ: alsoHQ, highlightTempvar4: this.tempValue4mustBe, useTempVar3asAlpha: this.tempValue3usedForAlpha, useTempAi2: this.tempAi2Use, useTempZones: this.tempZones, specialMode1: this.specialMode1);
      }
    }

    pub Bitmap Paint()
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawSimpleFast( Expression,  this.game.EditObj.MiniMap,  this.OwnBitmap, 0, 0);
      if (this.game.EditObj.MiniMap.Width < 310 | this.specialMode1 > -1)
      {
        Coordinate realCoord1 = this.GetRealCoord(this.game.CornerX, this.game.CornerY);
        int num1 = realCoord1.x;
        int num2 = realCoord1.y;
        int num3;
        int num4;
        if (this.tZoomLevel == -1)
        {
          num3 = 27;
          num4 = 24;
        }
        else if (this.tZoomLevel == 0)
        {
          num3 = 52;
          num4 = 48;
        }
        else if (this.tZoomLevel == 1)
        {
          num3 = 104;
          num4 = 96;
        }
        int num5;
        int num6;
        if (this.game.EditObj.OrderType == 24)
        {
          num5 =  Math.Round((double) (this.game.ScreenWidth - 0) / (double) num3);
          num6 =  Math.Round((double) (this.game.ScreenHeight - 305) / (double) num4);
        }
        else
        {
          num5 = (double) this.game.Data.RuleVar[839] != 0.0 ?  Math.Round((double) (this.game.ScreenWidth - 0 - 106) / (double) num3) : (this.game.EditObj.Layout != 1 ?  Math.Round((double) (this.game.ScreenWidth - 220 - 106) / (double) num3) :  Math.Round((double) (this.game.ScreenWidth - 440 - 106) / (double) num3));
          num6 = this.game.Data.Product != 7 ?  Math.Round((double) (this.game.ScreenHeight - 265) / (double) num4) : (!(Operators.CompareString(this.game.FormRef.Screeny.GetType().FullName, "WindowsApplication1.RandomScreenClass2", false) == 0 | this.game.EditObj.GuiDown) ?  Math.Round((double) (this.game.ScreenHeight - 265) / (double) num4) :  Math.Round((double) (this.game.ScreenHeight - 45) / (double) num4));
        }
        if (this.MapWidth > -1)
        {
          num5 =  Math.Round((double) this.MapWidth / (double) num3);
          num6 =  Math.Round((double) this.MapHeight / (double) num4);
        }
        Coordinate realCoord2 = this.GetRealCoord(this.game.CornerX + (num5 + 1) + 1, this.game.CornerY + num6 + 1);
        int w = realCoord2.x - num1;
        int h = realCoord2.y - num2;
        int x1 = this.game.EditObj.MiniMapOffset - 1;
        if (x1 < 0)
          x1 = this.game.Data.MapObj[0].MapWidth + x1 + 1;
        realCoord2 = this.GetRealCoord(x1, this.game.CornerY + h + 1);
        int x2 = realCoord2.x;
        realCoord2 = this.GetRealCoord(this.game.EditObj.MiniMapOffset, this.game.CornerY + h + 1);
        int x3 = realCoord2.x;
        if (w < 0)
          w = x2 + w;
        if (0 > num1)
          num1 = 0;
        if (0 > num2)
          num2 = 0;
        if (!this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop | (double) this.game.Data.RuleVar[329] == 1.0)
        {
          if (num1 + w > this.OwnBitmap.Width)
            num1 = this.OwnBitmap.Width - w;
          if (num2 + h > this.OwnBitmap.Height - 3)
            num2 = this.OwnBitmap.Height - 3 - h;
        }
        if (this.game.Data.Round == 0 & this.game.Data.ShrowdOn)
        {
          Expression.Clear(Color.Black);
          DrawMod.DrawText( Expression, "Shrouded Map", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 60, 68);
        }
        DrawMod.DrawRectangle( Expression, 0, 0, this.OwnBitmap.Width - 1, this.OwnBitmap.Height - 1, 0, 0, 0,  byte.MaxValue);
        if (this.paintview)
        {
          if (!this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop | (double) this.game.Data.RuleVar[329] == 1.0 | this.game.Data.Round == 0 | num1 + w <= x2)
          {
            DrawMod.DrawRectangle( Expression, num1, num2, w, h,  byte.MaxValue, 0, 0,  byte.MaxValue);
            DrawMod.DrawRectangle( Expression, num1 + 1, num2 + 1, w - 2, h - 2, 0, 0, 0,  byte.MaxValue);
          }
          else
          {
            DrawMod.drawLine( Expression, num1, num2, num1 + w - (num1 + w - x2), num2,  byte.MaxValue, 0, 0,  byte.MaxValue);
            DrawMod.drawLine( Expression, num1, num2 + h, num1 + w - (num1 + w - x2), num2 + h,  byte.MaxValue, 0, 0,  byte.MaxValue);
            DrawMod.drawLine( Expression, num1, num2, num1, num2 + h,  byte.MaxValue, 0, 0,  byte.MaxValue);
            DrawMod.drawLine( Expression, num1 + 1, num2 + 1, num1 + w - (num1 + w - x2), num2 + 1, 0, 0, 0,  byte.MaxValue);
            DrawMod.drawLine( Expression, num1 + 1, num2 + h - 1, num1 + w - (num1 + w - x2), num2 + h - 1, 0, 0, 0,  byte.MaxValue);
            DrawMod.drawLine( Expression, num1 + 1, num2 + 1, num1 + 1, num2 + h - 1, 0, 0, 0,  byte.MaxValue);
            DrawMod.drawLine( Expression, x3, num2, x3 + (num1 + w - x2), num2,  byte.MaxValue, 0, 0,  byte.MaxValue);
            DrawMod.drawLine( Expression, x3, num2 + h, x3 + (num1 + w - x2), num2 + h,  byte.MaxValue, 0, 0,  byte.MaxValue);
            DrawMod.drawLine( Expression, x3 + (num1 + w - x2), num2, x3 + (num1 + w - x2), num2 + h,  byte.MaxValue, 0, 0,  byte.MaxValue);
            DrawMod.drawLine( Expression, x3 + 1, num2 + 1, x3 + (num1 + w - x2), num2 + 1, 0, 0, 0,  byte.MaxValue);
            DrawMod.drawLine( Expression, x3 + 1, num2 + h - 1, x3 + (num1 + w - x2), num2 + h - 1, 0, 0, 0,  byte.MaxValue);
            DrawMod.drawLine( Expression, x3 + 1 + (num1 + w - x2), num2 + 1, x3 + (num1 + w - x2) + 1, num2 + h - 1, 0, 0, 0,  byte.MaxValue);
          }
        }
      }
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return this.OwnBitmap;
    }

    pub Coordinate GetRealCoord(int x, int y)
    {
      if (this.game.EditObj.MiniMapOffset > 0)
      {
        x -= this.game.EditObj.MiniMapOffset;
        if (x < 0)
          x = this.game.Data.MapObj[0].MapWidth + 1 + x;
      }
      float d1 = (float) this.minix / (float) (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1);
      float d2 = (float) this.miniy / (float) (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1);
      if (this.MapWidth > 310)
      {
        d1 = (float) Math.Floor((double) d1);
        d2 = (float) Math.Floor((double) d2);
      }
      float num1;
      if ((double) d1 > (double) d2)
      {
        num1 = (float) ((double) this.minix / 2.0 - (double) d2 / (double) d1 * ((double) this.minix / 2.0));
        d1 = d2;
      }
      float num2;
      if ((double) d2 > (double) d1)
      {
        num2 = (float) ((double) this.miniy / 2.0 - (double) d1 / (double) d2 * ((double) this.miniy / 2.0));
        d2 = d1;
      }
      if (this.minix > 310)
      {
        float num3 = (float) this.minix - (float) (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1) * d1;
        if ((double) num3 > 0.0)
        {
          float num4 = (float)  Math.Round((double) (num3 / 2f));
          if ((double) num4 > (double) num1)
            num1 = num4;
        }
      }
      if (this.miniy > 220)
      {
        float num5 = (float) this.miniy - (float) (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1) * d2;
        if ((double) num5 > 0.0)
        {
          float num6 = (float)  Math.Round((double) (num5 / 2f));
          if ((double) num6 > (double) num2)
            num2 = num6;
        }
      }
      float a1 = Conversion.Int(d1 * (float) x) + num1;
      float a2 = Conversion.Int(d2 * (float) y) - d2 / 2f + num2;
      Coordinate realCoord;
      realCoord.x =  Math.Round((double) a1);
      realCoord.y =  Math.Round((double) a2);
      return realCoord;
    }

    pub Coordinate GetHexCoord(int x, int y)
    {
      float d1 = (float) this.minix / (float) (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1);
      float d2 = (float) this.miniy / (float) (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1);
      float num1;
      if ((double) d1 > (double) d2)
      {
        num1 = (float) ((double) this.minix / 2.0 - (double) d2 / (double) d1 * ((double) this.minix / 2.0));
        d1 = d2;
      }
      float num2;
      if ((double) d2 > (double) d1)
      {
        num2 = (float) ((double) this.miniy / 2.0 - (double) d1 / (double) d2 * ((double) this.miniy / 2.0));
        d2 = d1;
      }
      if (this.MapWidth > 310)
      {
        d1 = (float) Math.Floor((double) d1);
        d2 = (float) Math.Floor((double) d2);
      }
      if (this.minix > 310)
      {
        float num3 = (float) this.minix - (float) (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1) * d1;
        if ((double) num3 > 0.0)
        {
          float num4 = (float)  Math.Round((double) (num3 / 2f));
          if ((double) num4 > (double) num1)
            num1 = num4;
        }
      }
      if (this.miniy > 220)
      {
        float num5 = (float) this.miniy - (float) (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1) * d2;
        if ((double) num5 > 0.0)
        {
          float num6 = (float)  Math.Round((double) (num5 / 2f));
          if ((double) num6 > (double) num2)
            num2 = num6;
        }
      }
      float a1 = (float)  Math.Round(Math.Floor(((double) x - (double) num1) / (double) d1));
      if (((double) a1 + 10.0) % 2.0 > 0.0)
        y =  Math.Round((double) ((float) y - d2 / 2f));
      float a2 = (float)  Math.Round(Math.Floor(((double) y - (double) num2 + (double)  Math.Round((double) (d2 / 2f))) / (double) d2));
      if (this.game.EditObj.MiniMapOffset > 0)
      {
        a1 += (float) this.game.EditObj.MiniMapOffset;
        if ((double) a1 > (double) this.game.Data.MapObj[0].MapWidth)
          a1 -= (float) (this.game.Data.MapObj[0].MapWidth + 1);
      }
      Coordinate hexCoord;
      hexCoord.x =  Math.Round((double) a1);
      hexCoord.y =  Math.Round((double) a2);
      hexCoord.onmap = true;
      if (hexCoord.x < 0 | hexCoord.y < 0)
        hexCoord.onmap = false;
      if (hexCoord.x > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
        hexCoord.onmap = false;
      if (hexCoord.y > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
        hexCoord.onmap = false;
      return hexCoord;
    }

    pub bool HandleTimerWheel(int x, int y,  WindowClass tWindow)
    {
      if (this.game.Data.MapObj[0].MapLoop)
      {
        int num =  Math.Round(Math.Ceiling((double) this.game.Data.MapObj[0].MapWidth / 20.0));
        if (this.game.EditObj.MouseWheel > 0)
        {
          this.game.EditObj.MiniMapOffset -= num;
          if (this.game.EditObj.MiniMapOffset < 0)
            this.game.EditObj.MiniMapOffset = this.game.Data.MapObj[0].MapWidth + this.game.EditObj.MiniMapOffset;
          if ((this.game.EditObj.MiniMapOffset + 2) % 2 > 0)
            --this.game.EditObj.MiniMapOffset;
          this.game.EditObj.MouseWheel = 0;
          this.game.EditObj.MouseWheelWait = 4;
          this.game.EditObj.TempCoordList = CoordList::new();
          this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, this.minix, this.miniy, this.alsounits, this.realhex);
          this.Paint();
          return true;
        }
        if (this.game.EditObj.MouseWheel < 0)
        {
          this.game.EditObj.MiniMapOffset += num;
          if (this.game.EditObj.MiniMapOffset >= this.game.Data.MapObj[0].MapWidth)
            this.game.EditObj.MiniMapOffset -= this.game.Data.MapObj[0].MapWidth;
          if ((this.game.EditObj.MiniMapOffset + 2) % 2 > 0)
            --this.game.EditObj.MiniMapOffset;
          this.game.EditObj.MouseWheel = 0;
          this.game.EditObj.MouseWheelWait = 4;
          this.game.EditObj.TempCoordList = CoordList::new();
          this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, this.minix, this.miniy, this.alsounits, this.realhex);
          this.Paint();
          return true;
        }
      }
      return false;
    }

    pub int Click(int x, int y, int b = 1)
    {
      int cornerX = this.game.CornerX;
      int cornerY = this.game.CornerY;
      float d1 = (float) this.minix / (float) (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1);
      float d2 = (float) this.miniy / (float) (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1);
      float num1;
      if ((double) d1 > (double) d2)
      {
        num1 = (float) ((double) this.minix / 2.0 - (double) d2 / (double) d1 * ((double) this.minix / 2.0));
        d1 = d2;
      }
      float num2;
      if ((double) d2 > (double) d1)
      {
        num2 = (float) ((double) this.miniy / 2.0 - (double) d1 / (double) d2 * ((double) this.miniy / 2.0));
        d2 = d1;
      }
      float num3 = (float) Math.Floor((double) d1);
      float num4 = (float) Math.Floor((double) d2);
      if (this.minix > 310)
      {
        int num5 =  Math.Round((double) ((float) this.minix - (float) (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1) * num3));
        if (num5 > 0)
        {
          int num6 =  Math.Round((double) num5 / 2.0);
          if ((double) num6 > (double) num1)
            num1 = (float) num6;
        }
      }
      if (this.miniy > 220)
      {
        int num7 =  Math.Round((double) ((float) this.miniy - (float) (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1) * num4));
        if (num7 > 0)
        {
          int num8 =  Math.Round((double) num7 / 2.0);
          if ((double) num8 > (double) num2)
            num2 = (float) num8;
        }
      }
      int Number1;
      int Number2;
      if (this.MapWidth < 310)
      {
        Number1 =  Math.Round((double) ((float) (((double) x - (double) num1) / ((double) this.minix - (double) num1 * 2.0)) * (float) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth));
        Number2 =  Math.Round((double) ((float) (((double) y - (double) num2) / ((double) this.miniy - (double) num2 * 2.0)) * (float) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight));
      }
      else
      {
        Number1 =  Math.Round((double) (Math.Max(0.0f, (float) x - num1 - num3) / num3));
        if ((Number1 + 2) % 2 == 1)
        {
          int num9;
          num9 -=  Math.Round((double) (num4 / 2f));
        }
        Number2 =  Math.Round((double) (((float) y - num2) / num4));
      }
      this.game.EditObj.CurrentMiniX = Conversion.Int(Number1);
      this.game.EditObj.CurrentMiniY = Conversion.Int(Number2);
      if (this.tZoomLevel == 1)
        Number2 += 3;
      if (this.tZoomLevel == 0)
        Number2 += 3;
      if (this.tZoomLevel == -1)
        Number2 += 6;
      int num10 = (double) this.game.Data.RuleVar[839] != 0.0 ? this.game.ScreenWidth - 0 : (this.game.EditObj.Layout != 1 ? this.game.ScreenWidth - 220 : this.game.ScreenWidth - 440);
      int num11 = this.game.ScreenHeight - 280;
      int num12 = (double) this.game.Data.RuleVar[839] != 1.0 ? (this.tZoomLevel != -1 ? (this.tZoomLevel != 0 ? 128 : 64) : 32) : (this.tZoomLevel != -1 ? (this.tZoomLevel != 0 ? 106 : 53) : 27);
      int num13;
      int num14;
      int num15;
      int num16;
      if (this.MapWidth > -1)
      {
        int num17 =  Math.Round((double) this.MapWidth / (double) num12);
        int num18 =  Math.Round((double) this.MapHeight / (double) (24 * (this.tZoomLevel + 2)));
        num13 = Number1 -  Math.Round((double) num17 / 2.0);
        num14 = Number2 -  Math.Round((double) num18 / 2.0);
        num15 = num17;
        num16 = num18;
      }
      else
      {
        num13 = this.game.EditObj.Layout != 0 ?  Math.Round((double) Number1 - (double) (num10 - 0) / (double) num12 / 2.0) :  Math.Round((double) Number1 - (double) (num10 - 0) / (double) num12 / 2.0);
        num14 =  Math.Round((double) Number2 - (double) num11 / (double) (24 * (this.tZoomLevel + 2)) / 2.0);
        int num19 = 265;
        if ((double) this.game.Data.RuleVar[839] == 0.0)
          num19 = 305;
        if (this.game.Data.Round == 0)
          num19 += 100;
        num15 =  Math.Round((double) num10 / (double) num12);
        num16 =  Math.Round((double) (num11 - num19) / (double) (24 * (this.tZoomLevel + 2)));
      }
      if (0 > num14)
        num14 = 0;
      int num20 = num14 - 1;
      if (this.game.EditObj.MiniMapOffset > 0)
      {
        num13 += this.game.EditObj.MiniMapOffset;
        if (num13 > this.game.Data.MapObj[0].MapWidth)
          num13 -= this.game.Data.MapObj[0].MapWidth + 1;
      }
      this.game.CornerX = num13;
      this.game.CornerY = num20;
      int num21 = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth - this.game.CornerX + 2;
      int num22 = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight - this.game.CornerY + 3;
      if (num15 > num21 & (!this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop | (double) this.game.Data.RuleVar[329] == 1.0 | this.game.Data.Round == 0))
        this.game.CornerX -= num15 - num21;
      if (num16 > num22)
        this.game.CornerY -= num16 - num22;
      if (0 > this.game.CornerX & (!this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop | (double) this.game.Data.RuleVar[329] == 1.0 | this.game.Data.Round == 0))
        this.game.CornerX = 0;
      if (-1 > this.game.CornerY)
        this.game.CornerY = -1;
      if (0 > this.game.CornerX & this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop & (double) this.game.Data.RuleVar[329] == 0.0 & this.game.Data.Round > 0)
        this.game.CornerX = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + this.game.CornerX + 1;
      if (!this.realhex)
        this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, this.minix, this.miniy, this.alsounits, this.realhex);
      this.game.EditObj.TempCoordList = CoordList::new();
      this.Paint();
      if (b == 3)
      {
        this.game.CornerX = cornerX;
        this.game.CornerY = cornerY;
      }
      return 0;
    }
  }
}
