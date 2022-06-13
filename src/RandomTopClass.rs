// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.RandomTopClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace WindowsApplication1
{
  pub class RandomTopClass : WindowClass
  {
     int w;
     int h;
     int CurrentView;
     int tab1;
     int tab2;
     int tab3;
     string tabname;

    pub RandomTopClass(
       GameClass tGame,
       WindowClass tLowerWindow,
       Rectangle tLowerRect)
      : base( tGame, tGame.ScreenWidth, 75, 8)
    {
      this.NewGfx = true;
      this.w = tGame.ScreenWidth;
      this.h = 75;
      this.LowerWindow = tLowerWindow;
      this.LowerRect = tLowerRect;
      this.CurrentView = 0;
      this.tabname = this.game.HandyFunctionsObj.GetUDSmanagementTabName(1, true);
      this.dostuff();
    }

    pub HandleMouseMove: WindowReturnClass(int x, int y)
    {
      windowReturnClass: WindowReturnClass = base.HandleMouseMove(x, y);
      if (y < 60)
        windowReturnClass.NoMouseClickBelow = true;
      return windowReturnClass;
    }

    pub void DoRefresh() => this.dostuff();

    pub void dostuff()
    {
      if (this.game.EditObj.SetViewMode2 > 0 & this.game.EditObj.SetViewMode2 < 101)
        this.game.EditObj.SetViewMode2 = 0;
      this.CurrentView = this.game.EditObj.SetViewMode2;
      this.ClearMouse();
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      for (let mut index: i32 = 0; index < this.game.ScreenWidth; index += 100)
      {
         Graphics local1 =  graphics;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCTOPBAR);
         Bitmap local2 =  bitmap;
        let mut x: i32 = index;
        DrawMod.DrawSimple( local1,  local2, x, 0);
      }
      this.DrawTabs((object) graphics);
      if (Information.IsNothing((object) graphics))
        return;
      graphics.Dispose();
    }

    pub void DrawTabs(object g)
    {
      this.tab1 = -1;
      this.tab2 = -1;
      this.tab3 = -1;
      Graphics objgraphics;
      Rectangle trect1;
      Rectangle rectangle;
      Bitmap bitmap1;
      if (this.CurrentView > 0)
      {
        Rectangle rectForTab = DrawMod.GetRectForTab(this.CurrentView);
        objgraphics = (Graphics) g;
         Graphics local1 =  objgraphics;
        Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.MARCTAB);
         Bitmap local2 =  bitmap2;
        trect1 = new Rectangle(0, 20, 8, 43);
        Rectangle srcrect1 = trect1;
        rectangle = new Rectangle(rectForTab.X, 32, 8, 43);
        Rectangle destrect1 = rectangle;
        DrawMod.DrawSimplePart2( local1,  local2, srcrect1, destrect1);
        g = (object) objgraphics;
        objgraphics = (Graphics) g;
         Graphics local3 =  objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCTAB);
         Bitmap local4 =  bitmap1;
        rectangle = new Rectangle(170, 20, 16, 43);
        Rectangle srcrect2 = rectangle;
        trect1 = new Rectangle(rectForTab.X + rectForTab.Width - 16, 32, 16, 43);
        Rectangle destrect2 = trect1;
        DrawMod.DrawSimplePart2( local3,  local4, srcrect2, destrect2);
        g = (object) objgraphics;
        let mut x: i32 = rectForTab.X + 8;
        let mut width: i32 = 160;
        for (; x < rectForTab.X + rectForTab.Width; x += 160)
        {
          if (x + width > rectForTab.X + rectForTab.Width - 16)
            width = rectForTab.X + rectForTab.Width - 16 - x;
          objgraphics = (Graphics) g;
           Graphics local5 =  objgraphics;
          bitmap1 = BitmapStore.GetBitmap(this.game.MARCTAB);
           Bitmap local6 =  bitmap1;
          rectangle = new Rectangle(10, 20, width, 43);
          Rectangle srcrect3 = rectangle;
          trect1 = new Rectangle(x, 32, width, 43);
          Rectangle destrect3 = trect1;
          DrawMod.DrawSimplePart2( local5,  local6, srcrect3, destrect3);
          g = (object) objgraphics;
        }
      }
      SizeF sizeF1;
      SizeF sizeF2;
      if (this.tabname.Length > 0 && this.CurrentView != 101)
      {
        let mut x1: i32 = 160;
        objgraphics = (Graphics) g;
         Graphics local7 =  objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCTABBUTTON);
         Bitmap local8 =  bitmap1;
        let mut x2: i32 = x1;
        DrawMod.DrawSimple( local7,  local8, x2, 32);
        g = (object) objgraphics;
        object Instance = g;
        object[] objArray1 = new object[2]
        {
          (object) this.tabname,
          null
        };
        object[] objArray2 = objArray1;
        let mut tgame: GameClass = DrawMod.TGame;
        Font marcFont4 = tgame.MarcFont4;
        objArray2[1] = (object) marcFont4;
        object[] objArray3 = objArray1;
        object[] Arguments = objArray3;
        bool[] flagArray = new bool[2]{ true, true };
        bool[] CopyBack = flagArray;
        object obj = NewLateBinding.LateGet(Instance, (Type) null, "MeasureString", Arguments, (string[]) null, (Type[]) null, CopyBack);
        if (flagArray[0])
          this.tabname = (string) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray3[0]), typeof (string));
        if (flagArray[1])
          tgame.MarcFont4 =  Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray3[1]), typeof );
        sizeF2 = obj != null ? (SizeF) obj : sizeF1;
        objgraphics = (Graphics) g;
        DrawMod.DrawTextColouredMarc( objgraphics, this.tabname, this.game.MarcFont4, x1 +  Math.Round((78.0 - (double) sizeF2.Width) / 2.0), 33, Color.White);
        g = (object) objgraphics;
        rectangle = new Rectangle(x1, 32, 75, 27);
        trect1 = rectangle;
        this.AddMouse( trect1, this.tabname, "Random Screen Tab #1", 1);
        this.tab1 = this.MouseCounter;
      }
      if (this.CurrentView == 107)
        return;
      if (this.game.ScreenWidth <= 1040)
      {
        let mut x: i32 =  Math.Round(Math.Max((double) this.game.ScreenWidth / 2.0 + 158.0 + 300.0, (double) (this.game.ScreenWidth - DrawMod.GetWidthForMiniMap())));
        objgraphics = (Graphics) g;
         Graphics local9 =  objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCTABBUTTON);
         Bitmap local10 =  bitmap1;
        rectangle = new Rectangle(0, 0, 78, 33);
        Rectangle srcrect = rectangle;
        trect1 = new Rectangle(x, 32, 50, 33);
        Rectangle destrect = trect1;
        DrawMod.DrawSimplePart2( local9,  local10, srcrect, destrect);
        g = (object) objgraphics;
        object Instance = g;
        object[] objArray4 = new object[2]
        {
          (object) "MINI",
          null
        };
        object[] objArray5 = objArray4;
        let mut tgame: GameClass = DrawMod.TGame;
        Font marcFont4 = tgame.MarcFont4;
        objArray5[1] = (object) marcFont4;
        object[] objArray6 = objArray4;
        object[] Arguments = objArray6;
        bool[] flagArray = new bool[2]{ false, true };
        bool[] CopyBack = flagArray;
        object obj = NewLateBinding.LateGet(Instance, (Type) null, "MeasureString", Arguments, (string[]) null, (Type[]) null, CopyBack);
        if (flagArray[1])
          tgame.MarcFont4 =  Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray6[1]), typeof );
        sizeF2 = obj != null ? (SizeF) obj : sizeF1;
        objgraphics = (Graphics) g;
        DrawMod.DrawTextColouredMarc( objgraphics, "MINI", this.game.MarcFont4, x +  Math.Round((53.0 - (double) sizeF2.Width) / 2.0), 33, Color.White);
        g = (object) objgraphics;
        rectangle = new Rectangle(x, 32, 50, 27);
        Rectangle trect2 = rectangle;
        this.AddMouse( trect2, "MINIMAP", "View the mini-map. [F8]", 7);
      }
      else
      {
        let mut x3: i32 =  Math.Round(Math.Max((double) this.game.ScreenWidth / 2.0 + 158.0 + 300.0, (double) (this.game.ScreenWidth - DrawMod.GetWidthForMiniMap())));
        objgraphics = (Graphics) g;
         Graphics local11 =  objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCTABBUTTON);
         Bitmap local12 =  bitmap1;
        let mut x4: i32 = x3;
        DrawMod.DrawSimple( local11,  local12, x4, 32);
        g = (object) objgraphics;
        object Instance = g;
        object[] objArray7 = new object[2]
        {
          (object) "MINI",
          null
        };
        object[] objArray8 = objArray7;
        let mut tgame: GameClass = DrawMod.TGame;
        Font marcFont4 = tgame.MarcFont4;
        objArray8[1] = (object) marcFont4;
        object[] objArray9 = objArray7;
        object[] Arguments = objArray9;
        bool[] flagArray = new bool[2]{ false, true };
        bool[] CopyBack = flagArray;
        object obj = NewLateBinding.LateGet(Instance, (Type) null, "MeasureString", Arguments, (string[]) null, (Type[]) null, CopyBack);
        if (flagArray[1])
          tgame.MarcFont4 =  Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray9[1]), typeof );
        sizeF2 = obj != null ? (SizeF) obj : sizeF1;
        objgraphics = (Graphics) g;
        DrawMod.DrawTextColouredMarc( objgraphics, "MINI", this.game.MarcFont4, x3 +  Math.Round((78.0 - (double) sizeF2.Width) / 2.0), 33, Color.White);
        g = (object) objgraphics;
        rectangle = new Rectangle(x3, 32, 75, 27);
        Rectangle trect3 = rectangle;
        this.AddMouse( trect3, "MINIMAP", "View the mini-map. [F8]", 7);
      }
      this.tab2 = this.MouseCounter;
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
        if (this.MouseData[index] > 0 && x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          switch (this.MouseData[index])
          {
            case 1:
              this.game.EditObj.SetViewMode2 = 101;
              this.dostuff();
              windowReturnClass.AddCommand(1, 9);
              windowReturnClass.AddCommand(7, 12);
              windowReturnClass.AddCommand(2, 113);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            case 7:
              this.game.EditObj.SetViewMode2 = 107;
              this.dostuff();
              windowReturnClass.AddCommand(1, 9);
              windowReturnClass.AddCommand(7, 12);
              windowReturnClass.AddCommand(2, 76);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            default:
              continue;
          }
        }
      }
      if (y < 64)
        windowReturnClass.NoMouseClickBelow = true;
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    pub HandleKeyPress: WindowReturnClass(int nr, bool fromTimer = false)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (nr == 77)
        SoundMod.dssEnd( this.game.EditObj);
      return windowReturnClass;
    }
  }
}
