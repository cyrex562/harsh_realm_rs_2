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
      let mut ZoomLevel: i32 =  -2,
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
        Rectangle rectangle1 = Rectangle::new(this.t53, 0, this.OwnBitmap.Width - this.t53, this.OwnBitmap.Height);
        Rectangle rectangle2 = Rectangle::new(0, 0, this.OwnBitmap.Width - this.t53, this.OwnBitmap.Height);
        Rectangle rectangle3 = Rectangle::new(0, 0, bitmap.Width, bitmap.Height);
        DrawMod.DrawSimpleFast( objGraphics,  this.OwnBitmap,  bitmap, -this.t53, 0);
        objGraphics.Dispose();
        objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
        this.Cleary(objGraphics, 4);
        DrawMod.DrawSimpleFast( objGraphics,  bitmap,  this.OwnBitmap, rectangle2.Left, rectangle2.Top);
        let mut num1: i32 =   Math.Round(Conversion.Int((double) this.OwnBitmap.Width / (double) this.t53));
        let mut num2: i32 =   Math.Round(Conversion.Int((double) this.OwnBitmap.Height / (double) this.t48));
        let mut num3: i32 =  num1 - 2;
        let mut num4: i32 =  num1;
        for (let mut index1: i32 =  num3; index1 <= num4; index1 += 1)
        {
          let mut num5: i32 =  num2;
          for (let mut index2: i32 =  -1; index2 <= num5; index2 += 1)
          {
            let mut cx: i32 =  this.game.CornerX + index1;
            let mut cy: i32 =  this.game.CornerY + index2;
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop & (double) this.game.Data.RuleVar[329] == 0.0 & this.game.Data.Round > 0 & cx > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
              cx = this.game.CornerX + index1 - (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1);
            if (cx > -1 & cy > -1 & cx <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth & cy <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
            {
              let mut num6: i32 =  this.t53 * index1;
              let mut num7: i32 =  this.t48 * index2;
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
      let mut num: i32 =  -this.game.ScreenHeight + this.game.ScreenHeight % 6;
      let mut screenHeight: i32 =  this.game.ScreenHeight;
      for (let mut index: i32 =  3; index <= screenHeight; index += 6)
      {
        let mut x1: i32 =  0;
        let mut y1: i32 =  index;
        let mut screenWidth: i32 =  this.game.ScreenWidth;
        let mut y2: i32 =  index;
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
        Rectangle rectangle1 = Rectangle::new(0, 0, this.OwnBitmap.Width - this.t53, this.OwnBitmap.Height);
        Rectangle rectangle2 = Rectangle::new(this.t53, 0, this.OwnBitmap.Width - this.t53, this.OwnBitmap.Height);
        Rectangle rectangle3 = Rectangle::new(0, 0, bitmap.Width, bitmap.Height);
        DrawMod.DrawSimpleFast( objGraphics,  this.OwnBitmap,  bitmap, 0, 0);
        objGraphics.Dispose();
        objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
        this.Cleary(objGraphics, 4);
        DrawMod.DrawSimpleFast( objGraphics,  bitmap,  this.OwnBitmap, rectangle2.Left, rectangle2.Top);
        let mut num1: i32 =   Math.Round(Conversion.Int((double) this.OwnBitmap.Width / (double) this.t53));
        let mut num2: i32 =   Math.Round(Conversion.Int((double) this.OwnBitmap.Height / (double) this.t48));
        let mut num3: i32 =  -1;
        do
        {
          let mut num4: i32 =  num2;
          for (let mut index: i32 =  -1; index <= num4; index += 1)
          {
            let mut cx: i32 =  this.game.CornerX + num3;
            let mut cy: i32 =  this.game.CornerY + index;
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop & (double) this.game.Data.RuleVar[329] == 0.0 & this.game.Data.Round > 0 & cx > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
              cx = this.game.CornerX + num3 - (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1);
            if (cx > -1 & cy > -1 & cx <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth & cy <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
            {
              let mut num5: i32 =  this.t53 * num3;
              let mut num6: i32 =  this.t48 * index;
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
        Rectangle rectangle1 = Rectangle::new(0, this.t48, this.OwnBitmap.Width, this.OwnBitmap.Height - this.t48);
        Rectangle rectangle2 = Rectangle::new(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height - this.t48);
        Rectangle rectangle3 = Rectangle::new(0, 0, bitmap.Width, bitmap.Height);
        DrawMod.DrawSimpleFast( objGraphics,  this.OwnBitmap,  bitmap, 0, -this.t48);
        objGraphics.Dispose();
        objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
        this.Cleary(objGraphics, 0);
        DrawMod.DrawSimpleFast( objGraphics,  bitmap,  this.OwnBitmap, rectangle2.Left, rectangle2.Top);
        let mut num1: i32 =   Math.Round(Conversion.Int((double) this.OwnBitmap.Width / (double) this.t53));
        let mut num2: i32 =   Math.Round(Conversion.Int((double) this.OwnBitmap.Height / (double) this.t48));
        let mut num3: i32 =  num1;
        for (let mut index1: i32 =  -1; index1 <= num3; index1 += 1)
        {
          let mut num4: i32 =  num2 - 2;
          let mut num5: i32 =  num2;
          for (let mut index2: i32 =  num4; index2 <= num5; index2 += 1)
          {
            let mut cx: i32 =  this.game.CornerX + index1;
            let mut cy: i32 =  this.game.CornerY + index2;
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop & (double) this.game.Data.RuleVar[329] == 0.0 & this.game.Data.Round > 0 & cx > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
              cx = this.game.CornerX + index1 - (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1);
            if (cx > -1 & cy > -1 & cx <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth & cy <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
            {
              let mut num6: i32 =  this.t53 * index1;
              let mut num7: i32 =  this.t48 * index2;
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
        Rectangle rectangle1 = Rectangle::new(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height - this.t48);
        Rectangle rectangle2 = Rectangle::new(0, this.t48, this.OwnBitmap.Width, this.OwnBitmap.Height - this.t48);
        Rectangle rectangle3 = Rectangle::new(0, 0, bitmap.Width, bitmap.Height);
        DrawMod.DrawSimpleFast( objGraphics,  this.OwnBitmap,  bitmap, 0, 0);
        objGraphics.Dispose();
        objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
        this.Cleary(objGraphics, 0);
        DrawMod.DrawSimpleFast( objGraphics,  bitmap,  this.OwnBitmap, rectangle2.Left, rectangle2.Top);
        let mut num1: i32 =   Math.Round(Conversion.Int((double) this.OwnBitmap.Width / (double) this.t53));
        let mut num2: i32 =   Math.Round(Conversion.Int((double) this.OwnBitmap.Height / (double) (24 * (this.tZoomLevel + 2))));
        let mut num3: i32 =  num1;
        for (let mut index: i32 =  -1; index <= num3; index += 1)
        {
          let mut num4: i32 =  -1;
          do
          {
            let mut cx: i32 =  this.game.CornerX + index;
            let mut cy: i32 =  this.game.CornerY + num4;
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop & (double) this.game.Data.RuleVar[329] == 0.0 & this.game.Data.Round > 0 & cx > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
              cx = this.game.CornerX + index - (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1);
            if (cx > -1 & cy > -1 & cx <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth & cy <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
            {
              let mut num5: i32 =  this.t53 * index;
              let mut num6: i32 =  this.t48 * num4;
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
      let mut num1: i32 =  this.game.EditObj.OverlayMode;
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
      let mut num2: i32 =   Math.Round(Conversion.Int((double) this.OwnBitmap.Width / (double) this.t53));
      let mut num3: i32 =   Math.Round(Conversion.Int((double) this.OwnBitmap.Height / (double) this.t48));
      let mut mapWidth: i32 =  this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth;
      let mut mapHeight: i32 =  this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight;
      this.OffSetX = 0;
      this.OffSetY = 0;
      if (mapWidth < num2 - 1)
        this.OffSetX =  Math.Round(Conversion.Int((double) (this.t53 * (num2 - 1 - mapWidth)) / 2.0));
      if (mapHeight < num3 - 1)
        this.OffSetY =  Math.Round(Conversion.Int((double) (this.t48 * (num3 - 1 - mapHeight)) / 2.0));
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      let mut num4: i32 =   Math.Round(Conversion.Int((double) this.OwnBitmap.Width / (double) this.t53));
      if (!this.game.EditObj.TempCoordList.active | (double) this.game.EditObj.TempCoordList.counter > (double) ( Math.Round(Conversion.Int((double) this.OwnBitmap.Height / (double) this.t48)) * num4) / 2.0 | this.game.Data.Round == 0)
        this.Cleary(graphics, 0);
      Rectangle rectangle1;
      if (this.game.Data.PermanentOverlayUse & (num1 == 0 | num1 == 1))
      {
        let mut offSetX: i32 =  this.OffSetX;
        let mut offSetY: i32 =  this.OffSetY;
        if (this.game.CornerX > 0 & this.OffSetX > 0)
          offSetX -= this.game.CornerX * this.t53;
        if (this.game.CornerY > 0 & this.OffSetY > 0)
          offSetY -= this.game.CornerY * this.t53;
        let mut num5: i32 =  this.game.CornerX * this.t53;
        let mut num6: i32 =  this.game.CornerY * this.t48;
        float num7 = (float) this.OwnBitmap.Width / (float) this.t53;
        float num8 = (float) this.OwnBitmap.Height / (float) this.t48;
        if ((double) num7 > (double) (this.game.Data.MapObj[0].MapWidth + 1))
          num7 = (float) (this.game.Data.MapObj[0].MapWidth + 1);
        if ((double) num8 > (double) (this.game.Data.MapObj[0].MapHeight + 1))
          num8 = (float) (this.game.Data.MapObj[0].MapHeight + 1);
        let mut width1: i32 =   Math.Round((double) num7 * (double) this.t53 + 11.0);
        let mut height1: i32 =   Math.Round((double) num8 * (double) this.t48 + (double) this.t48 / 2.0);
        if (num6 < 0)
          height1 += Math.Abs(num6);
        let mut num9: i32 =  (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1) * this.t53 + this.t11;
        let mut num10: i32 =   Math.Round((double) ((this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1) * this.t48) + (double) this.t48 / 2.0);
        let mut x: i32 =   Math.Round((double) num5 / (double) num9 * (double) BitmapStore.GetWidth(this.game.Data.PermanentOverlaySpriteID) + (double) this.game.EditObj.overlayOffsetX);
        let mut y: i32 =   Math.Round((double) num6 / (double) num10 * (double) BitmapStore.Getheight(this.game.Data.PermanentOverlaySpriteID) + (double) this.game.EditObj.overlayOffsetY);
        let mut width2: i32 =   Math.Round((double) width1 / (double) num9 * (double) BitmapStore.GetWidth(this.game.Data.PermanentOverlaySpriteID));
        let mut height2: i32 =   Math.Round((double) height1 / (double) num10 * (double) BitmapStore.Getheight(this.game.Data.PermanentOverlaySpriteID));
        if (this.game.CornerX > 0 & this.OffSetX > 0)
          x = 0;
        if (this.game.CornerY > 0 & this.OffSetY > 0)
          y = 0;
        Rectangle rectangle2 = Rectangle::new(x, y, width2, height2);
         let mut local1: &Graphics = &graphics;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.Data.PermanentOverlaySpriteID);
         let mut local2: &Bitmap = &bitmap;
        let mut srcrect: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(offSetX, offSetY, width1, height1);
        let mut destrect: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2( local1,  local2, srcrect, destrect);
      }
      let mut num11: i32 =   Math.Round(Conversion.Int((double) this.OwnBitmap.Width / (double) this.t53));
      let mut num12: i32 =   Math.Round(Conversion.Int((double) this.OwnBitmap.Height / (double) this.t48));
      Bitmap bitmap1;
      if (!this.game.EditObj.TempCoordList.active | (double) this.game.EditObj.TempCoordList.counter > (double) (num12 * num11) / 2.0 | this.game.Data.Round == 0)
      {
        let mut num13: i32 =  0;
        let mut num14: i32 =  num11;
        for (let mut index1: i32 =  -1; index1 <= num14; index1 += 1)
        {
          let mut num15: i32 =  num12;
          for (let mut index2: i32 =  -1; index2 <= num15; index2 += 1)
          {
            let mut cx: i32 =  this.game.CornerX + index1;
            let mut cy: i32 =  this.game.CornerY + index2;
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop & (double) this.game.Data.RuleVar[329] == 0.0 & this.game.Data.Round > 0 & cx > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
              cx = this.game.CornerX + index1 - (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1);
            int num16;
            if (cx > -1 & cy > -1 & cx <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth & cy <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
            {
              num13 += 1;
              num16 = this.t53 * index1;
              let mut num17: i32 =  this.t48 * index2;
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
          let mut counter: i32 =  this.game.EditObj.TempCoordList.counter;
          for (let mut index: i32 =  0; index <= counter; index += 1)
          {
            if (this.game.EditObj.TempCoordList.coord[index].onmap & this.game.EditObj.TempCoordList.coord[index].map == this.game.EditObj.MapSelected)
            {
              Graphics g = graphics;
              let mut x: i32 =  this.game.EditObj.TempCoordList.coord[index].x;
              let mut y: i32 =  this.game.EditObj.TempCoordList.coord[index].y;
              let mut map: i32 =  this.game.EditObj.TempCoordList.coord[index].map;
              bitmap1 = (Bitmap) null;
               let mut local: &Bitmap = &bitmap1;
              this.PaintCoordinate(g, x, y, map,  byte.MaxValue,  local);
            }
          }
        }
        if (this.game.EditObj.OrderType == 0)
          this.game.EditObj.TempCoordList.DeActivate();
      }
      if (this.game.Data.PermanentOverlayUse & this.game.Data.Round == 0 & (num1 == 0 | num1 == 2))
      {
        let mut offSetX: i32 =  this.OffSetX;
        let mut offSetY: i32 =  this.OffSetY;
        if (this.game.CornerX > 0 & this.OffSetX > 0)
          offSetX -= this.game.CornerX * this.t53;
        if (this.game.CornerY > 0 & this.OffSetY > 0)
          offSetY -= this.game.CornerY * this.t53;
        let mut num18: i32 =  this.game.CornerX * this.t53;
        let mut num19: i32 =  this.game.CornerY * this.t48;
        float num20 = (float) this.OwnBitmap.Width / (float) this.t53;
        float num21 = (float) this.OwnBitmap.Height / (float) this.t48;
        if ((double) num20 > (double) (this.game.Data.MapObj[0].MapWidth + 1))
          num20 = (float) (this.game.Data.MapObj[0].MapWidth + 1);
        if ((double) num21 > (double) (this.game.Data.MapObj[0].MapHeight + 1))
          num21 = (float) (this.game.Data.MapObj[0].MapHeight + 1);
        let mut width3: i32 =   Math.Round((double) num20 * (double) this.t53 + 11.0);
        let mut height3: i32 =   Math.Round((double) num21 * (double) this.t48 + (double) this.t48 / 2.0);
        let mut num22: i32 =  (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1) * this.t53 + this.t11;
        let mut num23: i32 =   Math.Round((double) ((this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1) * this.t48) + (double) this.t48 / 2.0);
        if (num19 < 0)
          height3 += Math.Abs(num19);
        let mut x: i32 =   Math.Round((double) num18 / (double) num22 * (double) BitmapStore.GetWidth(this.game.Data.PermanentOverlaySpriteID) + (double) this.game.EditObj.overlayOffsetX);
        let mut y: i32 =   Math.Round((double) num19 / (double) num23 * (double) BitmapStore.Getheight(this.game.Data.PermanentOverlaySpriteID) + (double) this.game.EditObj.overlayOffsetY);
        let mut width4: i32 =   Math.Round((double) width3 / (double) num22 * (double) BitmapStore.GetWidth(this.game.Data.PermanentOverlaySpriteID));
        let mut height4: i32 =   Math.Round((double) height3 / (double) num23 * (double) BitmapStore.Getheight(this.game.Data.PermanentOverlaySpriteID));
        if (this.game.CornerX > 0 & this.OffSetX > 0)
          x = 0;
        if (this.game.CornerY > 0 & this.OffSetY > 0)
          y = 0;
        Rectangle rectangle3 = Rectangle::new(x, y, width4, height4);
         let mut local3: &Graphics = &graphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.Data.PermanentOverlaySpriteID);
         let mut local4: &Bitmap = &bitmap1;
        let mut srcrect: &Rectangle = &rectangle3
        rectangle1 = Rectangle::new(offSetX, offSetY, width3, height3);
        let mut destrect: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2Coloured( local3,  local4, srcrect, destrect, 1f, 1f, 1f, 1f);
      }
      if (!Information.IsNothing((object) graphics))
        graphics.Dispose();
      return this.OwnBitmap;
    }

    pub void PaintOverlayHex(Graphics g, int x1, int y1, int screenx, int screeny, int zoomy)
    {
      let mut num1: i32 =  x1 * this.t53;
      let mut num2: i32 =  y1 * this.t48;
      float num3 = 1f;
      float num4 = 1f;
      let mut width1: i32 =   Math.Round((double) (num3 * (float) this.t53 + (float) this.t11));
      let mut height1: i32 =   Math.Round((double) (num4 * (float) this.t48));
      let mut num5: i32 =  (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1) * this.t53 + this.t11;
      let mut num6: i32 =   Math.Round((double) ((this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1) * this.t48) + (double) this.t48 / 2.0);
      let mut x2: i32 =   Math.Round((double) num1 / (double) num5 * (double) BitmapStore.GetWidth(this.game.Data.PermanentOverlaySpriteID) + (double) this.game.EditObj.overlayOffsetX);
      let mut y2: i32 =   Math.Round((double) num2 / (double) num6 * (double) BitmapStore.Getheight(this.game.Data.PermanentOverlaySpriteID) + (double) this.game.EditObj.overlayOffsetY);
      let mut width2: i32 =   Math.Round((double) width1 / (double) num5 * (double) BitmapStore.GetWidth(this.game.Data.PermanentOverlaySpriteID));
      let mut height2: i32 =   Math.Round((double) height1 / (double) num6 * (double) BitmapStore.Getheight(this.game.Data.PermanentOverlaySpriteID));
      if ((x1 + 20) % 2 != 0)
        y2 =  Math.Round((double) y2 + (double) height2 / 2.0);
      Bitmap bitmap = new Bitmap(width1, height1);
      Rectangle srcRect = Rectangle::new(x2, y2, width2, height2);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      graphics.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.PermanentOverlaySpriteID), Rectangle::new(0, 0, width1, height1), srcRect, GraphicsUnit.Pixel);
      let mut num7: i32 =  bitmap.Height - 1;
      for (let mut y3: i32 =  0; y3 <= num7; y3 += 1)
      {
        let mut num8: i32 =  bitmap.Width - 1;
        for (let mut x3: i32 =  0; x3 <= num8; x3 += 1)
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
      let mut counteralpha: i32 =  255,
       Bitmap gBitmap = null)
    {
      if (map != this.game.EditObj.MapSelected)
        return;
      let mut overlayMode: i32 =  this.game.EditObj.OverlayMode;
      bool flag = false;
      if (Information.IsNothing((object) g))
      {
        g = Graphics.FromImage((Image) this.OwnBitmap);
        flag = true;
      }
      let mut num1: i32 =   Math.Round(1.0 + Conversion.Int((double) this.OwnBitmap.Width / 42.0));
      let mut num2: i32 =   Math.Round(1.0 + Conversion.Int((double) this.OwnBitmap.Height / (double) this.t48));
      let mut num3: i32 =  x - this.game.CornerX;
      let mut num4: i32 =  y - this.game.CornerY;
      if (num3 < 0)
        num3 += this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1;
      let mut num5: i32 =  this.game.CornerX + num3;
      let mut num6: i32 =  this.game.CornerY + num4;
      if (this.game.EditObj.MapSelected == map)
      {
        if (this.game.Data.MapObj[map].MapLoop & (double) this.game.Data.RuleVar[329] == 0.0 & this.game.Data.Round > 0 & num5 > this.game.Data.MapObj[map].MapWidth)
          num5 = this.game.CornerX + num3 - (this.game.Data.MapObj[map].MapWidth + 1);
        if (num5 > -1 & num6 > -1 & num5 <= this.game.Data.MapObj[map].MapWidth & num6 <= this.game.Data.MapObj[map].MapHeight)
        {
          if (num5 == x & num6 == y)
          {
            let mut num7: i32 =  this.t53 * num3;
            let mut num8: i32 =  this.t48 * num4;
            if ((num5 + 10) % 2 > 0)
              num8 =  Math.Round((double) num8 + (double) this.t48 / 2.0);
            if (this.game.Data.PermanentOverlayUse & this.game.Data.Round > 0)
              this.PaintOverlayHex(g, num5, num6, num7 + this.OffSetX, num8 + this.OffSetY, this.tZoomLevel);
            this.game.CustomBitmapObj.DrawHex(num5, num6, map, NoShader: this.noshader, tempg: g, tx: (num7 + this.OffSetX), ty: (num8 + this.OffSetY), counteralpha: counteralpha, Zoom: this.tZoomLevel, UseRegimeColoring: this.game.EditObj.RegimeColoring, gBitmap: ( gBitmap), tFromMapPopup: ( this.fromPopupMap));
            if (this.game.EditObj.BattleTimerActive & this.game.EditObj.BattleAnimNr > 0 && num5 == this.game.EditObj.TargetX & num6 == this.game.EditObj.TargetY)
            {
               let mut local1: &Graphics = &g;
              Bitmap bitmap = BitmapStore.GetBitmap(this.game.EXPLOSION, this.game.EditObj.Zoom);
               let mut local2: &Bitmap = &bitmap;
              Rectangle srcrect = Rectangle::new(this.t64 * (this.game.EditObj.BattleAnimNr - 1), 0, this.t64, this.t48);
              Rectangle destrect = Rectangle::new(num7 + this.OffSetX, num8 + this.OffSetY, this.t64, this.t48);
              DrawMod.DrawSimplePart2( local1,  local2, srcrect, destrect);
            }
          }
        }
        else
        {
          let mut num9: i32 =  this.t53 * num3;
          let mut num10: i32 =  this.t48 * num4;
          if ((num5 + 10) % 2 > 0)
            num10 =  Math.Round((double) num10 + (double) this.t48 / 2.0);
           let mut local3: &Graphics = &g;
          Bitmap bitmap = BitmapStore.GetBitmap(this.game.BLACKHEX, this.tZoomLevel);
           let mut local4: &Bitmap = &bitmap;
          let mut x1: i32 =  num9 + this.OffSetX;
          let mut y1: i32 =  num10 + this.OffSetY;
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
      let mut num1: i32 =   Math.Round(1.0 + Conversion.Int((double) this.OwnBitmap.Width / 42.0));
      let mut num2: i32 =   Math.Round(1.0 + Conversion.Int((double) this.OwnBitmap.Height / (double) (24 * (this.tZoomLevel + 2))));
      x -= this.OffSetX;
      y -= this.OffSetY;
      let mut num3: i32 =   Math.Round(Conversion.Int((double) x / (double) this.t53));
      let mut num4: i32 =  x % this.t53;
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
      let mut num5: i32 =   Math.Round(Conversion.Int((double) y / (double) this.t48));
      let mut num6: i32 =  y % this.t48;
      let mut cx: i32 =  num3 + this.game.CornerX;
      let mut cy: i32 =  num5 + this.game.CornerY;
      let mut num7: i32 =  x % this.t53;
      let mut num8: i32 =  y % this.t48;
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
