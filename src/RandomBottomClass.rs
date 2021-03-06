// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.RandomBottomClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  pub class RandomBottomClass : WindowClass
  {
     int w;
     int h;
     int CurrentView;

    pub RandomBottomClass( GameClass tGame)
      : base( tGame, tGame.ScreenWidth, 32, 8)
    {
      this.NewGfx = true;
      this.w = tGame.ScreenWidth;
      this.h = 32;
      this.CurrentView = 0;
      this.dostuff();
    }

    pub HandleMouseMove: WindowReturnClass(int x, int y) => base.HandleMouseMove(x, y);

    pub handleTimerWheel: WindowReturnClass(int x, int y)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      windowReturnClass.Flag = false;
      if (this.game.EditObj.MouseWheel > 0 & this.game.EditObj.Zoom < 1 & this.game.EditObj.TutOrder == -1)
      {
        if (this.game.EditObj.MouseOverX > -1 & this.game.EditObj.MouseOverY > -1)
          this.game.HandyFunctionsObj.CenterOnXY(this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY, true);
        this.game.EditObj.MouseWheel = 0;
        this.game.EditObj.MouseWheelWait = 4;
        return this.actionZoomIn();
      }
      if (this.game.EditObj.MouseWheel < 0 & this.game.EditObj.Zoom > -1 & this.game.EditObj.TutOrder == -1)
      {
        let mut num: i32 = this.game.EditObj.MouseOverX > -1 & this.game.EditObj.MouseOverY > -1 & this.game.Data.Product <= 5 ? 1 : 0;
        this.game.EditObj.MouseWheel = 0;
        this.game.EditObj.MouseWheelWait = 4;
        return this.actionZoomOut();
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    pub actionZoomOut: WindowReturnClass()
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      let mut num1: i32 = 0;
      if (this.game.EditObj.GuiDown)
        num1 = 222;
      let mut num2: i32 =  Math.Round(Conversion.Int((double) this.game.ScreenWidth / 53.0));
      let mut num3: i32 =  Math.Round(Conversion.Int((double) this.game.ScreenWidth / 106.0));
      let mut num4: i32 =  Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 53.0));
      let mut num5: i32 =  Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 106.0));
      int num6;
      int num7;
      if (this.game.EditObj.Zoom == 0)
      {
        this.game.EditObj.Zoom = -1;
        this.game.CornerX -=  Math.Round(Conversion.Int((double) num2 / 2.0));
        this.game.CornerY -=  Math.Round(Conversion.Int((double) num4 / 2.0));
        num6 = 27;
        num7 = 24;
      }
      else
      {
        this.game.EditObj.Zoom = 0;
        this.game.CornerX -=  Math.Round(Conversion.Int((double) num3 / 2.0));
        this.game.CornerY -=  Math.Round(Conversion.Int((double) num5 / 2.0));
        num6 = 53;
        num7 = 48;
      }
      if (((!this.game.Data.MapObj[0].MapLoop ? 1 : 0) | 1) != 0)
      {
        if ((double) this.game.CornerX + (double) this.game.ScreenWidth / (double) num6 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
          this.game.CornerX =  Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth) - (double) (this.game.ScreenWidth - 200) / (double) num6);
        if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
          this.game.CornerY =  Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7);
        if (this.game.CornerX < 0)
          this.game.CornerX = 0;
        if (this.game.CornerY < 0)
          this.game.CornerY = 0;
      }
      else
      {
        if (this.game.CornerX > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
        {
          this.game.CornerX =  Math.Round((double) this.game.CornerX + (double) this.game.ScreenWidth / (double) num6);
          this.game.CornerX -= this.game.Data.MapObj[0].MapWidth;
        }
        if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
          this.game.CornerY =  Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7);
        if (this.game.CornerX < 0)
          this.game.CornerX = this.game.Data.MapObj[0].MapWidth + this.game.CornerX;
        if (this.game.CornerY < 0)
          this.game.CornerY = 0;
      }
      this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
      this.game.EditObj.TempCoordList = CoordList::new();
      windowReturnClass.AddCommand(1, 12);
      windowReturnClass.AddCommand(2, 12);
      windowReturnClass.AddCommand(4, 114);
      windowReturnClass.AddCommand(4, 9);
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
    }

    pub actionZoomIn: WindowReturnClass()
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      let mut num1: i32 = 0;
      if (this.game.EditObj.GuiDown)
        num1 = 222;
      let mut num2: i32 =  Math.Round(Conversion.Int((double) this.game.ScreenWidth / 53.0));
      let mut num3: i32 =  Math.Round(Conversion.Int((double) this.game.ScreenWidth / 106.0));
      let mut num4: i32 =  Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 53.0));
      let mut num5: i32 =  Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 106.0));
      int num6;
      int num7;
      if (this.game.EditObj.Zoom == 0)
      {
        this.game.EditObj.Zoom = 1;
        this.game.CornerX +=  Math.Round(Conversion.Int((double) num3 / 2.0));
        this.game.CornerY +=  Math.Round(Conversion.Int((double) num5 / 2.0));
        num6 = 106;
        num7 = 96;
      }
      else
      {
        this.game.EditObj.Zoom = 0;
        this.game.CornerX +=  Math.Round(Conversion.Int((double) num2 / 2.0));
        this.game.CornerY +=  Math.Round(Conversion.Int((double) num4 / 2.0));
        num6 = 53;
        num7 = 48;
      }
      if (((!this.game.Data.MapObj[0].MapLoop ? 1 : 0) | 1) != 0)
      {
        if ((double) this.game.CornerX + (double) this.game.ScreenWidth / (double) num6 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
          this.game.CornerX =  Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth) - (double) (this.game.ScreenWidth - 200) / (double) num6);
        if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
          this.game.CornerY =  Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7);
        if (this.game.CornerX < 0)
          this.game.CornerX = 0;
        if (this.game.CornerY < 0)
          this.game.CornerY = 0;
      }
      else
      {
        if (this.game.CornerX > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
          this.game.CornerX -= this.game.Data.MapObj[0].MapWidth;
        if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
          this.game.CornerY =  Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7);
        if (this.game.CornerX < 0)
          this.game.CornerX = this.game.Data.MapObj[0].MapWidth + this.game.CornerX;
        if (this.game.CornerY < 0)
          this.game.CornerY = 0;
      }
      this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
      this.game.EditObj.TempCoordList = CoordList::new();
      windowReturnClass.AddCommand(1, 12);
      windowReturnClass.AddCommand(2, 12);
      windowReturnClass.AddCommand(4, 114);
      windowReturnClass.AddCommand(4, 9);
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
    }

    pub void DoRefresh()
    {
      this.game.EditObj.se1_map_data3cache_set = false;
      this.dostuff();
    }

    pub void dostuff()
    {
      this.CurrentView = this.game.EditObj.SetViewMode2;
      this.ClearMouse();
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      let mut num: i32 = 0;
      BitmapStore.GetBitmap(this.game.MARCTOPBAR).RotateFlip(RotateFlipType.Rotate180FlipX);
      for (; num < this.game.ScreenWidth; num += 100)
      {
         let mut local1: &Graphics = &Expression;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCTOPBAR);
         let mut local2: &Bitmap = &bitmap;
        let mut x: i32 = num;
        DrawMod.DrawSimple( local1,  local2, x, -4);
      }
      BitmapStore.GetBitmap(this.game.MARCTOPBAR).RotateFlip(RotateFlipType.Rotate180FlipX);
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
    }

    pub void HandleToolTip(int x, int y)
    {
      let mut mouseCounter: i32 = this.MouseCounter;
      for (let mut index: i32 = 0; index <= mouseCounter; index += 1)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          if (this.MouseData[index] > 0)
            this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = this.MouseTitle[index];
          this.game.EditObj.TipText = this.MouseText[index];
          break;
        }
      }
    }

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (this.game.EditObj.TutOrder > -1)
        return windowReturnClass;
      let mut mouseCounter: i32 = this.MouseCounter;
      for (let mut index: i32 = 0; index <= mouseCounter; index += 1)
      {
        if (this.MouseData[index] > 0 && x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width)
        {
          let mut num: i32 = y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height ? 1 : 0;
        }
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    pub HandleKeyPress: WindowReturnClass(int nr, bool fromTimer = false)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      let mut num1: i32 = 262;
      if ((nr == 187 | nr == 191 | nr == 107) & this.game.EditObj.Zoom < 1 & this.game.EditObj.TutOrder == -1)
      {
        let mut num2: i32 =  Math.Round(Conversion.Int((double) this.game.ScreenWidth / 53.0));
        let mut num3: i32 =  Math.Round(Conversion.Int((double) this.game.ScreenWidth / 106.0));
        let mut num4: i32 =  Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 53.0));
        let mut num5: i32 =  Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 106.0));
        int num6;
        int num7;
        if (this.game.EditObj.Zoom == 0)
        {
          this.game.EditObj.Zoom = 1;
          this.game.CornerX +=  Math.Round(Conversion.Int((double) num3 / 2.0));
          this.game.CornerY +=  Math.Round(Conversion.Int((double) num5 / 2.0));
          num6 = 106;
          num7 = 96;
        }
        else
        {
          this.game.EditObj.Zoom = 0;
          this.game.CornerX +=  Math.Round(Conversion.Int((double) num2 / 2.0));
          this.game.CornerY +=  Math.Round(Conversion.Int((double) num4 / 2.0));
          num6 = 53;
          num7 = 48;
        }
        if ((double) this.game.CornerX + (double) this.game.ScreenWidth / (double) num6 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
          this.game.CornerX =  Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth) - (double) (this.game.ScreenWidth - 200) / (double) num6);
        if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
          this.game.CornerY =  Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7);
        if (this.game.CornerX < 0)
          this.game.CornerX = 0;
        if (this.game.CornerY < 0)
          this.game.CornerY = 0;
        this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
        this.game.EditObj.TempCoordList = CoordList::new();
        windowReturnClass.AddCommand(1, 12);
        windowReturnClass.AddCommand(2, 12);
        windowReturnClass.AddCommand(4, 114);
        windowReturnClass.AddCommand(4, 9);
        this.dostuff();
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      if (!((nr == 189 | nr == 219 | nr == 109) & this.game.EditObj.Zoom > -1 & this.game.EditObj.TutOrder == -1))
        return windowReturnClass;
      let mut num8: i32 =  Math.Round(Conversion.Int((double) this.game.ScreenWidth / 53.0));
      let mut num9: i32 =  Math.Round(Conversion.Int((double) this.game.ScreenWidth / 106.0));
      let mut num10: i32 =  Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 53.0));
      let mut num11: i32 =  Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 106.0));
      int num12;
      int num13;
      if (this.game.EditObj.Zoom == 0)
      {
        this.game.EditObj.Zoom = -1;
        this.game.CornerX -=  Math.Round(Conversion.Int((double) num8 / 2.0));
        this.game.CornerY -=  Math.Round(Conversion.Int((double) num10 / 2.0));
        num12 = 27;
        num13 = 24;
      }
      else
      {
        this.game.EditObj.Zoom = 0;
        this.game.CornerX -=  Math.Round(Conversion.Int((double) num9 / 2.0));
        this.game.CornerY -=  Math.Round(Conversion.Int((double) num11 / 2.0));
        num12 = 53;
        num13 = 48;
      }
      if ((double) this.game.CornerX + (double) this.game.ScreenWidth / (double) num12 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
        this.game.CornerX =  Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth) - (double) (this.game.ScreenWidth - 200) / (double) num12);
      if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num1)) / (double) num13 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
        this.game.CornerY =  Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num1)) / (double) num13);
      if (this.game.CornerX < 0)
        this.game.CornerX = 0;
      if (this.game.CornerY < 0)
        this.game.CornerY = 0;
      this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
      this.game.EditObj.TempCoordList = CoordList::new();
      windowReturnClass.AddCommand(1, 12);
      windowReturnClass.AddCommand(2, 12);
      windowReturnClass.AddCommand(4, 114);
      windowReturnClass.AddCommand(4, 9);
      this.dostuff();
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
    }
  }
}
