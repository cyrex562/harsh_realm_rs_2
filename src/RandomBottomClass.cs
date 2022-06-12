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
  public class RandomBottomClass : WindowClass
  {
    private int w;
    private int h;
    private int CurrentView;

    public RandomBottomClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, 32, 8)
    {
      this.NewGfx = true;
      this.w = tGame.ScreenWidth;
      this.h = 32;
      this.CurrentView = 0;
      this.dostuff();
    }

    public override WindowReturnClass HandleMouseMove(int x, int y) => base.HandleMouseMove(x, y);

    public override WindowReturnClass handleTimerWheel(int x, int y)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
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
        int num = this.game.EditObj.MouseOverX > -1 & this.game.EditObj.MouseOverY > -1 & this.game.Data.Product <= 5 ? 1 : 0;
        this.game.EditObj.MouseWheel = 0;
        this.game.EditObj.MouseWheelWait = 4;
        return this.actionZoomOut();
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    public WindowReturnClass actionZoomOut()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      int num1 = 0;
      if (this.game.EditObj.GuiDown)
        num1 = 222;
      int num2 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 53.0));
      int num3 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 106.0));
      int num4 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 53.0));
      int num5 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 106.0));
      int num6;
      int num7;
      if (this.game.EditObj.Zoom == 0)
      {
        this.game.EditObj.Zoom = -1;
        this.game.CornerX -= (int) Math.Round(Conversion.Int((double) num2 / 2.0));
        this.game.CornerY -= (int) Math.Round(Conversion.Int((double) num4 / 2.0));
        num6 = 27;
        num7 = 24;
      }
      else
      {
        this.game.EditObj.Zoom = 0;
        this.game.CornerX -= (int) Math.Round(Conversion.Int((double) num3 / 2.0));
        this.game.CornerY -= (int) Math.Round(Conversion.Int((double) num5 / 2.0));
        num6 = 53;
        num7 = 48;
      }
      if (((!this.game.Data.MapObj[0].MapLoop ? 1 : 0) | 1) != 0)
      {
        if ((double) this.game.CornerX + (double) this.game.ScreenWidth / (double) num6 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
          this.game.CornerX = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth) - (double) (this.game.ScreenWidth - 200) / (double) num6);
        if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
          this.game.CornerY = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7);
        if (this.game.CornerX < 0)
          this.game.CornerX = 0;
        if (this.game.CornerY < 0)
          this.game.CornerY = 0;
      }
      else
      {
        if (this.game.CornerX > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
        {
          this.game.CornerX = (int) Math.Round((double) this.game.CornerX + (double) this.game.ScreenWidth / (double) num6);
          this.game.CornerX -= this.game.Data.MapObj[0].MapWidth;
        }
        if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
          this.game.CornerY = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7);
        if (this.game.CornerX < 0)
          this.game.CornerX = this.game.Data.MapObj[0].MapWidth + this.game.CornerX;
        if (this.game.CornerY < 0)
          this.game.CornerY = 0;
      }
      this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
      this.game.EditObj.TempCoordList = new CoordList();
      windowReturnClass.AddCommand(1, 12);
      windowReturnClass.AddCommand(2, 12);
      windowReturnClass.AddCommand(4, 114);
      windowReturnClass.AddCommand(4, 9);
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
    }

    public WindowReturnClass actionZoomIn()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      int num1 = 0;
      if (this.game.EditObj.GuiDown)
        num1 = 222;
      int num2 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 53.0));
      int num3 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 106.0));
      int num4 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 53.0));
      int num5 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 106.0));
      int num6;
      int num7;
      if (this.game.EditObj.Zoom == 0)
      {
        this.game.EditObj.Zoom = 1;
        this.game.CornerX += (int) Math.Round(Conversion.Int((double) num3 / 2.0));
        this.game.CornerY += (int) Math.Round(Conversion.Int((double) num5 / 2.0));
        num6 = 106;
        num7 = 96;
      }
      else
      {
        this.game.EditObj.Zoom = 0;
        this.game.CornerX += (int) Math.Round(Conversion.Int((double) num2 / 2.0));
        this.game.CornerY += (int) Math.Round(Conversion.Int((double) num4 / 2.0));
        num6 = 53;
        num7 = 48;
      }
      if (((!this.game.Data.MapObj[0].MapLoop ? 1 : 0) | 1) != 0)
      {
        if ((double) this.game.CornerX + (double) this.game.ScreenWidth / (double) num6 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
          this.game.CornerX = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth) - (double) (this.game.ScreenWidth - 200) / (double) num6);
        if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
          this.game.CornerY = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7);
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
          this.game.CornerY = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7);
        if (this.game.CornerX < 0)
          this.game.CornerX = this.game.Data.MapObj[0].MapWidth + this.game.CornerX;
        if (this.game.CornerY < 0)
          this.game.CornerY = 0;
      }
      this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
      this.game.EditObj.TempCoordList = new CoordList();
      windowReturnClass.AddCommand(1, 12);
      windowReturnClass.AddCommand(2, 12);
      windowReturnClass.AddCommand(4, 114);
      windowReturnClass.AddCommand(4, 9);
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
    }

    public override void DoRefresh()
    {
      this.game.EditObj.se1_map_data3cache_set = false;
      this.dostuff();
    }

    public void dostuff()
    {
      this.CurrentView = this.game.EditObj.SetViewMode2;
      this.ClearMouse();
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      int num = 0;
      BitmapStore.GetBitmap(this.game.MARCTOPBAR).RotateFlip(RotateFlipType.Rotate180FlipX);
      for (; num < this.game.ScreenWidth; num += 100)
      {
        ref Graphics local1 = ref Expression;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCTOPBAR);
        ref Bitmap local2 = ref bitmap;
        int x = num;
        DrawMod.DrawSimple(ref local1, ref local2, x, -4);
      }
      BitmapStore.GetBitmap(this.game.MARCTOPBAR).RotateFlip(RotateFlipType.Rotate180FlipX);
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
    }

    public override void HandleToolTip(int x, int y)
    {
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
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

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.game.EditObj.TutOrder > -1)
        return windowReturnClass;
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (this.MouseData[index] > 0 && x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width)
        {
          int num = y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height ? 1 : 0;
        }
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      int num1 = 262;
      if ((nr == 187 | nr == 191 | nr == 107) & this.game.EditObj.Zoom < 1 & this.game.EditObj.TutOrder == -1)
      {
        int num2 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 53.0));
        int num3 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 106.0));
        int num4 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 53.0));
        int num5 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 106.0));
        int num6;
        int num7;
        if (this.game.EditObj.Zoom == 0)
        {
          this.game.EditObj.Zoom = 1;
          this.game.CornerX += (int) Math.Round(Conversion.Int((double) num3 / 2.0));
          this.game.CornerY += (int) Math.Round(Conversion.Int((double) num5 / 2.0));
          num6 = 106;
          num7 = 96;
        }
        else
        {
          this.game.EditObj.Zoom = 0;
          this.game.CornerX += (int) Math.Round(Conversion.Int((double) num2 / 2.0));
          this.game.CornerY += (int) Math.Round(Conversion.Int((double) num4 / 2.0));
          num6 = 53;
          num7 = 48;
        }
        if ((double) this.game.CornerX + (double) this.game.ScreenWidth / (double) num6 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
          this.game.CornerX = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth) - (double) (this.game.ScreenWidth - 200) / (double) num6);
        if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
          this.game.CornerY = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7);
        if (this.game.CornerX < 0)
          this.game.CornerX = 0;
        if (this.game.CornerY < 0)
          this.game.CornerY = 0;
        this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
        this.game.EditObj.TempCoordList = new CoordList();
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
      int num8 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 53.0));
      int num9 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 106.0));
      int num10 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 53.0));
      int num11 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 106.0));
      int num12;
      int num13;
      if (this.game.EditObj.Zoom == 0)
      {
        this.game.EditObj.Zoom = -1;
        this.game.CornerX -= (int) Math.Round(Conversion.Int((double) num8 / 2.0));
        this.game.CornerY -= (int) Math.Round(Conversion.Int((double) num10 / 2.0));
        num12 = 27;
        num13 = 24;
      }
      else
      {
        this.game.EditObj.Zoom = 0;
        this.game.CornerX -= (int) Math.Round(Conversion.Int((double) num9 / 2.0));
        this.game.CornerY -= (int) Math.Round(Conversion.Int((double) num11 / 2.0));
        num12 = 53;
        num13 = 48;
      }
      if ((double) this.game.CornerX + (double) this.game.ScreenWidth / (double) num12 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
        this.game.CornerX = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth) - (double) (this.game.ScreenWidth - 200) / (double) num12);
      if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num1)) / (double) num13 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
        this.game.CornerY = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num1)) / (double) num13);
      if (this.game.CornerX < 0)
        this.game.CornerX = 0;
      if (this.game.CornerY < 0)
        this.game.CornerY = 0;
      this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
      this.game.EditObj.TempCoordList = new CoordList();
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
