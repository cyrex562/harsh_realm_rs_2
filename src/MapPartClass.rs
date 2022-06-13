// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.MapPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace WindowsApplication1
{
  pub class MapPartClass : SubPartClass
  {
     GameClass game;
     bool noshader;
     int OffSetX;
     int OffSetY;
     int tZoomLevel;
     int t53;
     int t48;
     int t64;
     int t11;
     bool fromPopupMap;

    pub MapPartClass(
      int width,
      int height,
      GameClass tgame,
      bool tnoshaders = false,
      int ZoomLevel = -2,
      bool tFromPopupMap = false)
      : base(width, height)
    {
      this.game = tgame;
      this.game.EditObj.se1_map_data3cache_set = false;
      this.noshader = tnoshaders;
      this.fromPopupMap = tFromPopupMap;
      switch (ZoomLevel)
      {
        case -2:
          if (this.game.EditObj.Zoom == -1)
          {
            this.tZoomLevel = this.game.EditObj.Zoom;
            this.t53 = 27;
            this.t48 = 24;
            this.t64 = 32;
            this.t11 = 5;
            break;
          }
          if (this.game.EditObj.Zoom == 0)
          {
            this.tZoomLevel = this.game.EditObj.Zoom;
            this.t53 = 53;
            this.t48 = 48;
            this.t64 = 64;
            this.t11 = 11;
            break;
          }
          this.tZoomLevel = this.game.EditObj.Zoom;
          this.t53 = 106;
          this.t48 = 96;
          this.t64 = 128;
          this.t11 = 22;
          break;
        case -1:
          this.tZoomLevel = ZoomLevel;
          this.t53 = 27;
          this.t48 = 24;
          this.t11 = 5;
          break;
        case 0:
          this.tZoomLevel = ZoomLevel;
          this.t53 = 53;
          this.t48 = 48;
          this.t11 = 11;
          break;
        default:
          this.tZoomLevel = ZoomLevel;
          this.t53 = 106;
          this.t48 = 96;
          this.t11 = 22;
          break;
      }
      tgame.CustomBitmapObj.InitializeTextureRelatedStuff();
    }

    pub void ShiftLeft()
    {
      if (this.game.Data.PermanentOverlayUse)
      {
        this.Paint();
      }
      else
      {
        Bitmap bitmap = new Bitmap(this.OwnBitmap.Width - this.t53, this.OwnBitmap.Height, PixelFormat.Format32bppPArgb);
        bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        Graphics objGraphics = Graphics.FromImage((Image) bitmap);
        Rectangle rectangle1 = new Rectangle(this.t53, 0, this.OwnBitmap.Width - this.t53, this.OwnBitmap.Height);
        Rectangle rectangle2 = new Rectangle(0, 0, this.OwnBitmap.Width - this.t53, this.OwnBitmap.Height);
        Rectangle rectangle3 = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
        DrawMod.DrawSimpleFast( objGraphics,  this.OwnBitmap,  bitmap, -this.t53, 0);
        objGraphics.Dispose();
        objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
        this.Cleary(objGraphics, 4);
        DrawMod.DrawSimpleFast( objGraphics,  bitmap,  this.OwnBitmap, rectangle2.Left, rectangle2.Top);
        int num1 =  Math.Round(Conversion.Int((double) this.OwnBitmap.Width / (double) this.t53));
        int num2 =  Math.Round(Conversion.Int((double) this.OwnBitmap.Height / (double) this.t48));
        int num3 = num1 - 2;
        int num4 = num1;
        for (int index1 = num3; index1 <= num4; index1 += 1)
        {
          int num5 = num2;
          for (int index2 = -1; index2 <= num5; index2 += 1)
          {
            int cx = this.game.CornerX + index1;
            int cy = this.game.CornerY + index2;
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop & (double) this.game.Data.RuleVar[329] == 0.0 & this.game.Data.Round > 0 & cx > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
              cx = this.game.CornerX + index1 - (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1);
            if (cx > -1 & cy > -1 & cx <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth & cy <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
            {
              int num6 = this.t53 * index1;
              int num7 = this.t48 * index2;
              if ((this.game.CornerX + index1) % 2 > 0)
                num7 =  Math.Round((double) num7 + (double) this.t48 / 2.0);
              this.game.CustomBitmapObj.DrawHex(cx, cy, this.game.EditObj.MapSelected, tempg: objGraphics, tx: (num6 + this.OffSetX), ty: (num7 + this.OffSetY), Zoom: this.tZoomLevel, UseRegimeColoring: this.game.EditObj.RegimeColoring, gBitmap: ( this.OwnBitmap), tFromMapPopup: ( this.fromPopupMap));
            }
          }
        }
        bitmap.Dispose();
        if (Information.IsNothing((object) objGraphics))
          return;
        objGraphics.Dispose();
        objGraphics = (Graphics) null;
      }
    }

    pub void Cleary(Graphics g, int shift)
    {
      DrawMod.DrawClear(g,  this.OwnBitmap, Color.FromArgb( byte.MaxValue, 60, 60, 60));
      Pen pen = new Pen(Color.FromArgb( byte.MaxValue, 80, 80, 80));
      int num = -this.game.ScreenHeight + this.game.ScreenHeight % 6;
      int screenHeight = this.game.ScreenHeight;
      for (int index = 3; index <= screenHeight; index += 6)
      {
        int x1 = 0;
        int y1 = index;
        int screenWidth = this.game.ScreenWidth;
        int y2 = index;
        g.DrawLine(pen, x1, y1, screenWidth, y2);
      }
    }

    pub void ShiftRight()
    {
      if (this.game.Data.PermanentOverlayUse)
      {
        this.Paint();
      }
      else
      {
        Bitmap bitmap = new Bitmap(this.OwnBitmap.Width - this.t53, this.OwnBitmap.Height, PixelFormat.Format32bppPArgb);
        bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        Graphics objGraphics = Graphics.FromImage((Image) bitmap);
        Rectangle rectangle1 = new Rectangle(0, 0, this.OwnBitmap.Width - this.t53, this.OwnBitmap.Height);
        Rectangle rectangle2 = new Rectangle(this.t53, 0, this.OwnBitmap.Width - this.t53, this.OwnBitmap.Height);
        Rectangle rectangle3 = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
        DrawMod.DrawSimpleFast( objGraphics,  this.OwnBitmap,  bitmap, 0, 0);
        objGraphics.Dispose();
        objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
        this.Cleary(objGraphics, 4);
        DrawMod.DrawSimpleFast( objGraphics,  bitmap,  this.OwnBitmap, rectangle2.Left, rectangle2.Top);
        int num1 =  Math.Round(Conversion.Int((double) this.OwnBitmap.Width / (double) this.t53));
        int num2 =  Math.Round(Conversion.Int((double) this.OwnBitmap.Height / (double) this.t48));
        int num3 = -1;
        do
        {
          int num4 = num2;
          for (int index = -1; index <= num4; index += 1)
          {
            int cx = this.game.CornerX + num3;
            int cy = this.game.CornerY + index;
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop & (double) this.game.Data.RuleVar[329] == 0.0 & this.game.Data.Round > 0 & cx > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
              cx = this.game.CornerX + num3 - (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1);
            if (cx > -1 & cy > -1 & cx <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth & cy <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
            {
              int num5 = this.t53 * num3;
              int num6 = this.t48 * index;
              if ((this.game.CornerX + num3) % 2 > 0)
                num6 =  Math.Round((double) num6 + (double) this.t48 / 2.0);
              this.game.CustomBitmapObj.DrawHex(cx, cy, this.game.EditObj.MapSelected, tempg: objGraphics, tx: (num5 + this.OffSetX), ty: (num6 + this.OffSetY), Zoom: this.tZoomLevel, UseRegimeColoring: this.game.EditObj.RegimeColoring, gBitmap: ( this.OwnBitmap), tFromMapPopup: ( this.fromPopupMap));
            }
          }
          num3 += 1;
        }
        while (num3 <= 1);
        bitmap.Dispose();
        if (Information.IsNothing((object) objGraphics))
          return;
        objGraphics.Dispose();
        objGraphics = (Graphics) null;
      }
    }

    pub void ShiftUp()
    {
      if (this.game.Data.PermanentOverlayUse)
      {
        this.Paint();
      }
      else
      {
        Bitmap bitmap = new Bitmap(this.OwnBitmap.Width, this.OwnBitmap.Height - this.t48, PixelFormat.Format32bppPArgb);
        bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        Graphics objGraphics = Graphics.FromImage((Image) bitmap);
        Rectangle rectangle1 = new Rectangle(0, this.t48, this.OwnBitmap.Width, this.OwnBitmap.Height - this.t48);
        Rectangle rectangle2 = new Rectangle(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height - this.t48);
        Rectangle rectangle3 = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
        DrawMod.DrawSimpleFast( objGraphics,  this.OwnBitmap,  bitmap, 0, -this.t48);
        objGraphics.Dispose();
        objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
        this.Cleary(objGraphics, 0);
        DrawMod.DrawSimpleFast( objGraphics,  bitmap,  this.OwnBitmap, rectangle2.Left, rectangle2.Top);
        int num1 =  Math.Round(Conversion.Int((double) this.OwnBitmap.Width / (double) this.t53));
        int num2 =  Math.Round(Conversion.Int((double) this.OwnBitmap.Height / (double) this.t48));
        int num3 = num1;
        for (int index1 = -1; index1 <= num3; index1 += 1)
        {
          int num4 = num2 - 2;
          int num5 = num2;
          for (int index2 = num4; index2 <= num5; index2 += 1)
          {
            int cx = this.game.CornerX + index1;
            int cy = this.game.CornerY + index2;
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop & (double) this.game.Data.RuleVar[329] == 0.0 & this.game.Data.Round > 0 & cx > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
              cx = this.game.CornerX + index1 - (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1);
            if (cx > -1 & cy > -1 & cx <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth & cy <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
            {
              int num6 = this.t53 * index1;
              int num7 = this.t48 * index2;
              if ((this.game.CornerX + index1) % 2 > 0)
                num7 =  Math.Round((double) num7 + (double) this.t48 / 2.0);
              this.game.CustomBitmapObj.DrawHex(cx, cy, this.game.EditObj.MapSelected, tempg: objGraphics, tx: (num6 + this.OffSetX), ty: (num7 + this.OffSetY), Zoom: this.tZoomLevel, UseRegimeColoring: this.game.EditObj.RegimeColoring, gBitmap: ( this.OwnBitmap), tFromMapPopup: ( this.fromPopupMap));
            }
          }
        }
        bitmap.Dispose();
        if (Information.IsNothing((object) objGraphics))
          return;
        objGraphics.Dispose();
        objGraphics = (Graphics) null;
      }
    }

    pub void ShiftDown()
    {
      if (this.game.Data.PermanentOverlayUse)
      {
        this.Paint();
      }
      else
      {
        Bitmap bitmap = new Bitmap(this.OwnBitmap.Width, this.OwnBitmap.Height - this.t48, PixelFormat.Format32bppPArgb);
        bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        Graphics objGraphics = Graphics.FromImage((Image) bitmap);
        Rectangle rectangle1 = new Rectangle(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height - this.t48);
        Rectangle rectangle2 = new Rectangle(0, this.t48, this.OwnBitmap.Width, this.OwnBitmap.Height - this.t48);
        Rectangle rectangle3 = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
        DrawMod.DrawSimpleFast( objGraphics,  this.OwnBitmap,  bitmap, 0, 0);
        objGraphics.Dispose();
        objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
        this.Cleary(objGraphics, 0);
        DrawMod.DrawSimpleFast( objGraphics,  bitmap,  this.OwnBitmap, rectangle2.Left, rectangle2.Top);
        int num1 =  Math.Round(Conversion.Int((double) this.OwnBitmap.Width / (double) this.t53));
        int num2 =  Math.Round(Conversion.Int((double) this.OwnBitmap.Height / (double) (24 * (this.tZoomLevel + 2))));
        int num3 = num1;
        for (int index = -1; index <= num3; index += 1)
        {
          int num4 = -1;
          do
          {
            int cx = this.game.CornerX + index;
            int cy = this.game.CornerY + num4;
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop & (double) this.game.Data.RuleVar[329] == 0.0 & this.game.Data.Round > 0 & cx > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
              cx = this.game.CornerX + index - (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1);
            if (cx > -1 & cy > -1 & cx <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth & cy <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
            {
              int num5 = this.t53 * index;
              int num6 = this.t48 * num4;
              if ((this.game.CornerX + index) % 2 > 0)
                num6 =  Math.Round((double) num6 + (double) this.t48 / 2.0);
              this.game.CustomBitmapObj.DrawHex(cx, cy, this.game.EditObj.MapSelected, tempg: objGraphics, tx: (num5 + this.OffSetX), ty: (num6 + this.OffSetY), Zoom: this.tZoomLevel, UseRegimeColoring: this.game.EditObj.RegimeColoring, gBitmap: ( this.OwnBitmap), tFromMapPopup: ( this.fromPopupMap));
            }
            num4 += 1;
          }
          while (num4 <= 1);
        }
        bitmap.Dispose();
        if (Information.IsNothing((object) objGraphics))
          return;
        objGraphics.Dispose();
        objGraphics = (Graphics) null;
      }
    }

    pub Bitmap Paint()
    {
      int num1 = this.game.EditObj.OverlayMode;
      if (this.game.Data.Round > 0)
      {
        num1 = 0;
        this.game.EditObj.OverlayMode = 0;
      }
      if (this.game.Data.PermanentOverlayUse)
      {
        this.game.EditObj.TempCoordList = CoordList::new();
        this.game.EditObj.TempCoordList.active = false;
      }
      this.game.HandyFunctionsObj.SetMapLoopOnOrOff();
      int num2 =  Math.Round(Conversion.Int((double) this.OwnBitmap.Width / (double) this.t53));
      int num3 =  Math.Round(Conversion.Int((double) this.OwnBitmap.Height / (double) this.t48));
      int mapWidth = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth;
      int mapHeight = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight;
      this.OffSetX = 0;
      this.OffSetY = 0;
      if (mapWidth < num2 - 1)
        this.OffSetX =  Math.Round(Conversion.Int((double) (this.t53 * (num2 - 1 - mapWidth)) / 2.0));
      if (mapHeight < num3 - 1)
        this.OffSetY =  Math.Round(Conversion.Int((double) (this.t48 * (num3 - 1 - mapHeight)) / 2.0));
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      int num4 =  Math.Round(Conversion.Int((double) this.OwnBitmap.Width / (double) this.t53));
      if (!this.game.EditObj.TempCoordList.active | (double) this.game.EditObj.TempCoordList.counter > (double) ( Math.Round(Conversion.Int((double) this.OwnBitmap.Height / (double) this.t48)) * num4) / 2.0 | this.game.Data.Round == 0)
        this.Cleary(graphics, 0);
      Rectangle rectangle1;
      if (this.game.Data.PermanentOverlayUse & (num1 == 0 | num1 == 1))
      {
        int offSetX = this.OffSetX;
        int offSetY = this.OffSetY;
        if (this.game.CornerX > 0 & this.OffSetX > 0)
          offSetX -= this.game.CornerX * this.t53;
        if (this.game.CornerY > 0 & this.OffSetY > 0)
          offSetY -= this.game.CornerY * this.t53;
        int num5 = this.game.CornerX * this.t53;
        int num6 = this.game.CornerY * this.t48;
        float num7 = (float) this.OwnBitmap.Width / (float) this.t53;
        float num8 = (float) this.OwnBitmap.Height / (float) this.t48;
        if ((double) num7 > (double) (this.game.Data.MapObj[0].MapWidth + 1))
          num7 = (float) (this.game.Data.MapObj[0].MapWidth + 1);
        if ((double) num8 > (double) (this.game.Data.MapObj[0].MapHeight + 1))
          num8 = (float) (this.game.Data.MapObj[0].MapHeight + 1);
        int width1 =  Math.Round((double) num7 * (double) this.t53 + 11.0);
        int height1 =  Math.Round((double) num8 * (double) this.t48 + (double) this.t48 / 2.0);
        if (num6 < 0)
          height1 += Math.Abs(num6);
        int num9 = (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1) * this.t53 + this.t11;
        int num10 =  Math.Round((double) ((this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1) * this.t48) + (double) this.t48 / 2.0);
        int x =  Math.Round((double) num5 / (double) num9 * (double) BitmapStore.GetWidth(this.game.Data.PermanentOverlaySpriteID) + (double) this.game.EditObj.overlayOffsetX);
        int y =  Math.Round((double) num6 / (double) num10 * (double) BitmapStore.Getheight(this.game.Data.PermanentOverlaySpriteID) + (double) this.game.EditObj.overlayOffsetY);
        int width2 =  Math.Round((double) width1 / (double) num9 * (double) BitmapStore.GetWidth(this.game.Data.PermanentOverlaySpriteID));
        int height2 =  Math.Round((double) height1 / (double) num10 * (double) BitmapStore.Getheight(this.game.Data.PermanentOverlaySpriteID));
        if (this.game.CornerX > 0 & this.OffSetX > 0)
          x = 0;
        if (this.game.CornerY > 0 & this.OffSetY > 0)
          y = 0;
        Rectangle rectangle2 = new Rectangle(x, y, width2, height2);
         Graphics local1 =  graphics;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.Data.PermanentOverlaySpriteID);
         Bitmap local2 =  bitmap;
        Rectangle srcrect = rectangle2;
        rectangle1 = new Rectangle(offSetX, offSetY, width1, height1);
        Rectangle destrect = rectangle1;
        DrawMod.DrawSimplePart2( local1,  local2, srcrect, destrect);
      }
      int num11 =  Math.Round(Conversion.Int((double) this.OwnBitmap.Width / (double) this.t53));
      int num12 =  Math.Round(Conversion.Int((double) this.OwnBitmap.Height / (double) this.t48));
      Bitmap bitmap1;
      if (!this.game.EditObj.TempCoordList.active | (double) this.game.EditObj.TempCoordList.counter > (double) (num12 * num11) / 2.0 | this.game.Data.Round == 0)
      {
        int num13 = 0;
        int num14 = num11;
        for (int index1 = -1; index1 <= num14; index1 += 1)
        {
          int num15 = num12;
          for (int index2 = -1; index2 <= num15; index2 += 1)
          {
            int cx = this.game.CornerX + index1;
            int cy = this.game.CornerY + index2;
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop & (double) this.game.Data.RuleVar[329] == 0.0 & this.game.Data.Round > 0 & cx > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
              cx = this.game.CornerX + index1 - (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1);
            int num16;
            if (cx > -1 & cy > -1 & cx <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth & cy <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
            {
              num13 += 1;
              num16 = this.t53 * index1;
              int num17 = this.t48 * index2;
              if ((cx + 10) % 2 > 0)
                num17 =  Math.Round((double) num17 + (double) this.t48 / 2.0);
              this.game.CustomBitmapObj.DrawHex(cx, cy, this.game.EditObj.MapSelected, NoShader: this.noshader, tempg: graphics, tx: (num16 + this.OffSetX), ty: (num17 + this.OffSetY), Zoom: this.tZoomLevel, UseRegimeColoring: this.game.EditObj.RegimeColoring, gBitmap: ( this.OwnBitmap), tFromMapPopup: ( this.fromPopupMap));
            }
            else
              num16 = num16;
          }
        }
        if (this.game.EditObj.OrderType == 0)
          this.game.EditObj.TempCoordList.DeActivate();
      }
      else
      {
        if (this.game.EditObj.TempCoordList.counter > -1)
        {
          if (this.game.EditObj.TempCoordList.counter > 10)
            ;
          int counter = this.game.EditObj.TempCoordList.counter;
          for (int index = 0; index <= counter; index += 1)
          {
            if (this.game.EditObj.TempCoordList.coord[index].onmap & this.game.EditObj.TempCoordList.coord[index].map == this.game.EditObj.MapSelected)
            {
              Graphics g = graphics;
              int x = this.game.EditObj.TempCoordList.coord[index].x;
              int y = this.game.EditObj.TempCoordList.coord[index].y;
              int map = this.game.EditObj.TempCoordList.coord[index].map;
              bitmap1 = (Bitmap) null;
               Bitmap local =  bitmap1;
              this.PaintCoordinate(g, x, y, map,  byte.MaxValue,  local);
            }
          }
        }
        if (this.game.EditObj.OrderType == 0)
          this.game.EditObj.TempCoordList.DeActivate();
      }
      if (this.game.Data.PermanentOverlayUse & this.game.Data.Round == 0 & (num1 == 0 | num1 == 2))
      {
        int offSetX = this.OffSetX;
        int offSetY = this.OffSetY;
        if (this.game.CornerX > 0 & this.OffSetX > 0)
          offSetX -= this.game.CornerX * this.t53;
        if (this.game.CornerY > 0 & this.OffSetY > 0)
          offSetY -= this.game.CornerY * this.t53;
        int num18 = this.game.CornerX * this.t53;
        int num19 = this.game.CornerY * this.t48;
        float num20 = (float) this.OwnBitmap.Width / (float) this.t53;
        float num21 = (float) this.OwnBitmap.Height / (float) this.t48;
        if ((double) num20 > (double) (this.game.Data.MapObj[0].MapWidth + 1))
          num20 = (float) (this.game.Data.MapObj[0].MapWidth + 1);
        if ((double) num21 > (double) (this.game.Data.MapObj[0].MapHeight + 1))
          num21 = (float) (this.game.Data.MapObj[0].MapHeight + 1);
        int width3 =  Math.Round((double) num20 * (double) this.t53 + 11.0);
        int height3 =  Math.Round((double) num21 * (double) this.t48 + (double) this.t48 / 2.0);
        int num22 = (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1) * this.t53 + this.t11;
        int num23 =  Math.Round((double) ((this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1) * this.t48) + (double) this.t48 / 2.0);
        if (num19 < 0)
          height3 += Math.Abs(num19);
        int x =  Math.Round((double) num18 / (double) num22 * (double) BitmapStore.GetWidth(this.game.Data.PermanentOverlaySpriteID) + (double) this.game.EditObj.overlayOffsetX);
        int y =  Math.Round((double) num19 / (double) num23 * (double) BitmapStore.Getheight(this.game.Data.PermanentOverlaySpriteID) + (double) this.game.EditObj.overlayOffsetY);
        int width4 =  Math.Round((double) width3 / (double) num22 * (double) BitmapStore.GetWidth(this.game.Data.PermanentOverlaySpriteID));
        int height4 =  Math.Round((double) height3 / (double) num23 * (double) BitmapStore.Getheight(this.game.Data.PermanentOverlaySpriteID));
        if (this.game.CornerX > 0 & this.OffSetX > 0)
          x = 0;
        if (this.game.CornerY > 0 & this.OffSetY > 0)
          y = 0;
        Rectangle rectangle3 = new Rectangle(x, y, width4, height4);
         Graphics local3 =  graphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.Data.PermanentOverlaySpriteID);
         Bitmap local4 =  bitmap1;
        Rectangle srcrect = rectangle3;
        rectangle1 = new Rectangle(offSetX, offSetY, width3, height3);
        Rectangle destrect = rectangle1;
        DrawMod.DrawSimplePart2Coloured( local3,  local4, srcrect, destrect, 1f, 1f, 1f, 1f);
      }
      if (!Information.IsNothing((object) graphics))
        graphics.Dispose();
      return this.OwnBitmap;
    }

    pub void PaintOverlayHex(Graphics g, int x1, int y1, int screenx, int screeny, int zoomy)
    {
      int num1 = x1 * this.t53;
      int num2 = y1 * this.t48;
      float num3 = 1f;
      float num4 = 1f;
      int width1 =  Math.Round((double) (num3 * (float) this.t53 + (float) this.t11));
      int height1 =  Math.Round((double) (num4 * (float) this.t48));
      int num5 = (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1) * this.t53 + this.t11;
      int num6 =  Math.Round((double) ((this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1) * this.t48) + (double) this.t48 / 2.0);
      int x2 =  Math.Round((double) num1 / (double) num5 * (double) BitmapStore.GetWidth(this.game.Data.PermanentOverlaySpriteID) + (double) this.game.EditObj.overlayOffsetX);
      int y2 =  Math.Round((double) num2 / (double) num6 * (double) BitmapStore.Getheight(this.game.Data.PermanentOverlaySpriteID) + (double) this.game.EditObj.overlayOffsetY);
      int width2 =  Math.Round((double) width1 / (double) num5 * (double) BitmapStore.GetWidth(this.game.Data.PermanentOverlaySpriteID));
      int height2 =  Math.Round((double) height1 / (double) num6 * (double) BitmapStore.Getheight(this.game.Data.PermanentOverlaySpriteID));
      if ((x1 + 20) % 2 != 0)
        y2 =  Math.Round((double) y2 + (double) height2 / 2.0);
      Bitmap bitmap = new Bitmap(width1, height1);
      Rectangle srcRect = new Rectangle(x2, y2, width2, height2);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      graphics.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.PermanentOverlaySpriteID), new Rectangle(0, 0, width1, height1), srcRect, GraphicsUnit.Pixel);
      int num7 = bitmap.Height - 1;
      for (int y3 = 0; y3 <= num7; y3 += 1)
      {
        int num8 = bitmap.Width - 1;
        for (int x3 = 0; x3 <= num8; x3 += 1)
        {
          Color pixel;
          switch (zoomy)
          {
            case -1:
              pixel = BitmapStore.SmallShape.GetPixel(x3, y3);
              break;
            case 0:
              pixel = BitmapStore.MediumShape.GetPixel(x3, y3);
              break;
            default:
              pixel = BitmapStore.BigShape.GetPixel(x3, y3);
              break;
          }
          if (pixel.A < byte.MaxValue)
            bitmap.SetPixel(x3, y3, Color.FromArgb(0, 0, 0, 0));
        }
      }
      graphics.Dispose();
      g.DrawImage((Image) bitmap, screenx, screeny);
      bitmap.Dispose();
    }

    pub void PaintCoordinate(
      Graphics g,
      int x,
      int y,
      int map,
      int counteralpha = 255,
       Bitmap gBitmap = null)
    {
      if (map != this.game.EditObj.MapSelected)
        return;
      int overlayMode = this.game.EditObj.OverlayMode;
      bool flag = false;
      if (Information.IsNothing((object) g))
      {
        g = Graphics.FromImage((Image) this.OwnBitmap);
        flag = true;
      }
      int num1 =  Math.Round(1.0 + Conversion.Int((double) this.OwnBitmap.Width / 42.0));
      int num2 =  Math.Round(1.0 + Conversion.Int((double) this.OwnBitmap.Height / (double) this.t48));
      int num3 = x - this.game.CornerX;
      int num4 = y - this.game.CornerY;
      if (num3 < 0)
        num3 += this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1;
      int num5 = this.game.CornerX + num3;
      int num6 = this.game.CornerY + num4;
      if (this.game.EditObj.MapSelected == map)
      {
        if (this.game.Data.MapObj[map].MapLoop & (double) this.game.Data.RuleVar[329] == 0.0 & this.game.Data.Round > 0 & num5 > this.game.Data.MapObj[map].MapWidth)
          num5 = this.game.CornerX + num3 - (this.game.Data.MapObj[map].MapWidth + 1);
        if (num5 > -1 & num6 > -1 & num5 <= this.game.Data.MapObj[map].MapWidth & num6 <= this.game.Data.MapObj[map].MapHeight)
        {
          if (num5 == x & num6 == y)
          {
            int num7 = this.t53 * num3;
            int num8 = this.t48 * num4;
            if ((num5 + 10) % 2 > 0)
              num8 =  Math.Round((double) num8 + (double) this.t48 / 2.0);
            if (this.game.Data.PermanentOverlayUse & this.game.Data.Round > 0)
              this.PaintOverlayHex(g, num5, num6, num7 + this.OffSetX, num8 + this.OffSetY, this.tZoomLevel);
            this.game.CustomBitmapObj.DrawHex(num5, num6, map, NoShader: this.noshader, tempg: g, tx: (num7 + this.OffSetX), ty: (num8 + this.OffSetY), counteralpha: counteralpha, Zoom: this.tZoomLevel, UseRegimeColoring: this.game.EditObj.RegimeColoring, gBitmap: ( gBitmap), tFromMapPopup: ( this.fromPopupMap));
            if (this.game.EditObj.BattleTimerActive & this.game.EditObj.BattleAnimNr > 0 && num5 == this.game.EditObj.TargetX & num6 == this.game.EditObj.TargetY)
            {
               Graphics local1 =  g;
              Bitmap bitmap = BitmapStore.GetBitmap(this.game.EXPLOSION, this.game.EditObj.Zoom);
               Bitmap local2 =  bitmap;
              Rectangle srcrect = new Rectangle(this.t64 * (this.game.EditObj.BattleAnimNr - 1), 0, this.t64, this.t48);
              Rectangle destrect = new Rectangle(num7 + this.OffSetX, num8 + this.OffSetY, this.t64, this.t48);
              DrawMod.DrawSimplePart2( local1,  local2, srcrect, destrect);
            }
          }
        }
        else
        {
          int num9 = this.t53 * num3;
          int num10 = this.t48 * num4;
          if ((num5 + 10) % 2 > 0)
            num10 =  Math.Round((double) num10 + (double) this.t48 / 2.0);
           Graphics local3 =  g;
          Bitmap bitmap = BitmapStore.GetBitmap(this.game.BLACKHEX, this.tZoomLevel);
           Bitmap local4 =  bitmap;
          int x1 = num9 + this.OffSetX;
          int y1 = num10 + this.OffSetY;
          DrawMod.DrawSimple( local3,  local4, x1, y1);
        }
      }
      if (!flag)
        return;
      g.Dispose();
      g = (Graphics) null;
    }

    pub Coordinate ClickMap(int x, int y)
    {
      int num1 =  Math.Round(1.0 + Conversion.Int((double) this.OwnBitmap.Width / 42.0));
      int num2 =  Math.Round(1.0 + Conversion.Int((double) this.OwnBitmap.Height / (double) (24 * (this.tZoomLevel + 2))));
      x -= this.OffSetX;
      y -= this.OffSetY;
      int num3 =  Math.Round(Conversion.Int((double) x / (double) this.t53));
      int num4 = x % this.t53;
      if (this.tZoomLevel == 1)
      {
        if ((this.game.CornerX + 10) % 2 > 0)
        {
          if ((num3 + 10) % 2 <= 0)
            y -= 48;
        }
        else if ((num3 + 10) % 2 > 0)
          y -= 48;
      }
      else if ((this.game.CornerX + 10) % 2 > 0)
      {
        if ((num3 + 10) % 2 <= 0)
          y -= 12 * (this.tZoomLevel + 2);
      }
      else if ((num3 + 10) % 2 > 0)
        y -= 12 * (this.tZoomLevel + 2);
      int num5 =  Math.Round(Conversion.Int((double) y / (double) this.t48));
      int num6 = y % this.t48;
      int cx = num3 + this.game.CornerX;
      int cy = num5 + this.game.CornerY;
      int num7 = x % this.t53;
      int num8 = y % this.t48;
      Coordinate coordinate;
      coordinate.onmap = true;
      coordinate.data2 = 0;
      if (num7 < 11)
      {
        if ((double) num8 <= (double) this.t48 / 2.0)
        {
          if ((double) (11 - num7) * 2.1 - (double) num8 > 0.0)
          {
            coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, this.game.EditObj.MapSelected, 6) with
            {
              data2 = 1
            };
          }
          else
          {
            coordinate.x = cx;
            coordinate.y = cy;
            coordinate.data2 = 2;
          }
        }
        else if ((double) num7 * 2.1 - ((double) num8 - (double) this.t48 / 2.0) > 0.0)
        {
          coordinate.x = cx;
          coordinate.y = cy;
          coordinate.penalty =  Math.Round((double) this.t48 / 2.0 + 2.0);
          coordinate.data2 = 4;
        }
        else
          coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, this.game.EditObj.MapSelected, 5) with
          {
            data2 = 3
          };
      }
      else
      {
        coordinate.x = cx;
        coordinate.y = cy;
        coordinate.data1 = num4;
        coordinate.penalty = num6;
      }
      if (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop & (double) this.game.Data.RuleVar[329] == 0.0 & this.game.Data.Round > 0)
      {
        if (coordinate.x < 0)
          coordinate.x = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + coordinate.x + 1;
        if (coordinate.x > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
          coordinate.x -= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1;
      }
      if (coordinate.onmap)
        coordinate.onmap = !(coordinate.x < 0 | coordinate.y < 0 | coordinate.x > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth | coordinate.y > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight);
      if (coordinate.x == 0 & coordinate.y == 0)
        ;
      coordinate.map = this.game.EditObj.MapSelected;
      return coordinate;
    }
  }
}
