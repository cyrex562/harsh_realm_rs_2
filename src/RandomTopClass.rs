// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.RandomTopClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

// usingMicrosoft.VisualBasic;
// usingMicrosoft.VisualBasic.CompilerServices;
// usingSystem;
// usingSystem.Drawing;
// usingSystem.Runtime.CompilerServices;

namespace WindowsApplication1
{
  pub class RandomTopClass : WindowClass
  {
     w: i32;
     h: i32;
     CurrentView: i32;
     tab1: i32;
     tab2: i32;
     tab3: i32;
     string tabname;

    pub RandomTopClass(
       tGame: GameClass,
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

    pub HandleMouseMove: WindowReturnClass(x: i32, y: i32)
    {
      windowReturnClass: WindowReturnClass = base.HandleMouseMove(x, y);
      if (y < 60)
        windowReturnClass.NoMouseClickBelow = true;
      return windowReturnClass;
    }

    pub fn DoRefresh() => this.dostuff();

    pub fn dostuff()
    {
      if (this.game.EditObj.SetViewMode2 > 0 & this.game.EditObj.SetViewMode2 < 101)
        this.game.EditObj.SetViewMode2 = 0;
      this.CurrentView = this.game.EditObj.SetViewMode2;
      this.ClearMouse();
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      for (let mut index: i32 = 0; index < this.game.ScreenWidth; index += 100)
      {
         let mut local1: &Graphics = &graphics;
        bitmap: Bitmap = BitmapStore.GetBitmap(this.game.MARCTOPBAR);
         let mut local2: &Bitmap = &bitmap;
        let mut x: i32 = index;
        DrawMod.DrawSimple( local1,  local2, x, 0);
      }
      this.DrawTabs( graphics);
      if (Information.IsNothing( graphics))
        return;
      graphics.Dispose();
    }

    pub fn DrawTabs(object g)
    {
      this.tab1 = -1;
      this.tab2 = -1;
      this.tab3 = -1;
      Graphics objgraphics;
      Rectangle trect1;
      Rectangle rectangle;
      bitmap1: Bitmap;
      if (this.CurrentView > 0)
      {
        Rectangle rectForTab = DrawMod.GetRectForTab(this.CurrentView);
        objgraphics = (Graphics) g;
         let mut local1: &Graphics = &objgraphics;
        bitmap2: Bitmap = BitmapStore.GetBitmap(this.game.MARCTAB);
         let mut local2: &Bitmap = &bitmap2;
        trect1 = Rectangle::new(0, 20, 8, 43);
        let mut srcrect1: &Rectangle = &trect1
        rectangle = Rectangle::new(rectForTab.X, 32, 8, 43);
        let mut destrect1: &Rectangle = &rectangle
        DrawMod.DrawSimplePart2( local1,  local2, srcrect1, destrect1);
        g =  objgraphics;
        objgraphics = (Graphics) g;
         let mut local3: &Graphics = &objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCTAB);
         let mut local4: &Bitmap = &bitmap1;
        rectangle = Rectangle::new(170, 20, 16, 43);
        let mut srcrect2: &Rectangle = &rectangle
        trect1 = Rectangle::new(rectForTab.X + rectForTab.Width - 16, 32, 16, 43);
        let mut destrect2: &Rectangle = &trect1
        DrawMod.DrawSimplePart2( local3,  local4, srcrect2, destrect2);
        g =  objgraphics;
        let mut x: i32 = rectForTab.X + 8;
        let mut width: i32 = 160;
        for (; x < rectForTab.X + rectForTab.Width; x += 160)
        {
          if (x + width > rectForTab.X + rectForTab.Width - 16)
            width = rectForTab.X + rectForTab.Width - 16 - x;
          objgraphics = (Graphics) g;
           let mut local5: &Graphics = &objgraphics;
          bitmap1 = BitmapStore.GetBitmap(this.game.MARCTAB);
           let mut local6: &Bitmap = &bitmap1;
          rectangle = Rectangle::new(10, 20, width, 43);
          let mut srcrect3: &Rectangle = &rectangle
          trect1 = Rectangle::new(x, 32, width, 43);
          let mut destrect3: &Rectangle = &trect1
          DrawMod.DrawSimplePart2( local5,  local6, srcrect3, destrect3);
          g =  objgraphics;
        }
      }
      SizeF sizeF1;
      SizeF sizeF2;
      if (this.tabname.Length > 0 && this.CurrentView != 101)
      {
        let mut x1: i32 = 160;
        objgraphics = (Graphics) g;
         let mut local7: &Graphics = &objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCTABBUTTON);
         let mut local8: &Bitmap = &bitmap1;
        let mut x2: i32 = x1;
        DrawMod.DrawSimple( local7,  local8, x2, 32);
        g =  objgraphics;
        object Instance = g;
        object[] objArray1 = new object[2]
        {
           this.tabname,
          null
        };
        object[] objArray2 = objArray1;
        let mut tgame: GameClass = DrawMod.TGame;
        marcFont4: Font = tgame.MarcFont4;
        objArray2[1] =  marcFont4;
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
        DrawMod.DrawTextColouredMarc( objgraphics, this.tabname, this.game.MarcFont4, x1 +  Math.Round((78.0 -  sizeF2.Width) / 2.0), 33, Color.White);
        g =  objgraphics;
        rectangle = Rectangle::new(x1, 32, 75, 27);
        trect1 = rectangle;
        this.AddMouse( trect1, this.tabname, "Random Screen Tab #1", 1);
        this.tab1 = this.MouseCounter;
      }
      if (this.CurrentView == 107)
        return;
      if (this.game.ScreenWidth <= 1040)
      {
        let mut x: i32 =  Math.Round(Math.Max( this.game.ScreenWidth / 2.0 + 158.0 + 300.0,  (this.game.ScreenWidth - DrawMod.GetWidthForMiniMap())));
        objgraphics = (Graphics) g;
         let mut local9: &Graphics = &objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCTABBUTTON);
         let mut local10: &Bitmap = &bitmap1;
        rectangle = Rectangle::new(0, 0, 78, 33);
        let mut srcrect: &Rectangle = &rectangle
        trect1 = Rectangle::new(x, 32, 50, 33);
        let mut destrect: &Rectangle = &trect1
        DrawMod.DrawSimplePart2( local9,  local10, srcrect, destrect);
        g =  objgraphics;
        object Instance = g;
        object[] objArray4 = new object[2]
        {
           "MINI",
          null
        };
        object[] objArray5 = objArray4;
        let mut tgame: GameClass = DrawMod.TGame;
        marcFont4: Font = tgame.MarcFont4;
        objArray5[1] =  marcFont4;
        object[] objArray6 = objArray4;
        object[] Arguments = objArray6;
        bool[] flagArray = new bool[2]{ false, true };
        bool[] CopyBack = flagArray;
        object obj = NewLateBinding.LateGet(Instance, (Type) null, "MeasureString", Arguments, (string[]) null, (Type[]) null, CopyBack);
        if (flagArray[1])
          tgame.MarcFont4 =  Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray6[1]), typeof );
        sizeF2 = obj != null ? (SizeF) obj : sizeF1;
        objgraphics = (Graphics) g;
        DrawMod.DrawTextColouredMarc( objgraphics, "MINI", this.game.MarcFont4, x +  Math.Round((53.0 -  sizeF2.Width) / 2.0), 33, Color.White);
        g =  objgraphics;
        rectangle = Rectangle::new(x, 32, 50, 27);
        let mut trect2: &Rectangle = &rectangle
        this.AddMouse( trect2, "MINIMAP", "View the mini-map. [F8]", 7);
      }
      else
      {
        let mut x3: i32 =  Math.Round(Math.Max( this.game.ScreenWidth / 2.0 + 158.0 + 300.0,  (this.game.ScreenWidth - DrawMod.GetWidthForMiniMap())));
        objgraphics = (Graphics) g;
         let mut local11: &Graphics = &objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCTABBUTTON);
         let mut local12: &Bitmap = &bitmap1;
        let mut x4: i32 = x3;
        DrawMod.DrawSimple( local11,  local12, x4, 32);
        g =  objgraphics;
        object Instance = g;
        object[] objArray7 = new object[2]
        {
           "MINI",
          null
        };
        object[] objArray8 = objArray7;
        let mut tgame: GameClass = DrawMod.TGame;
        marcFont4: Font = tgame.MarcFont4;
        objArray8[1] =  marcFont4;
        object[] objArray9 = objArray7;
        object[] Arguments = objArray9;
        bool[] flagArray = new bool[2]{ false, true };
        bool[] CopyBack = flagArray;
        object obj = NewLateBinding.LateGet(Instance, (Type) null, "MeasureString", Arguments, (string[]) null, (Type[]) null, CopyBack);
        if (flagArray[1])
          tgame.MarcFont4 =  Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray9[1]), typeof );
        sizeF2 = obj != null ? (SizeF) obj : sizeF1;
        objgraphics = (Graphics) g;
        DrawMod.DrawTextColouredMarc( objgraphics, "MINI", this.game.MarcFont4, x3 +  Math.Round((78.0 -  sizeF2.Width) / 2.0), 33, Color.White);
        g =  objgraphics;
        rectangle = Rectangle::new(x3, 32, 75, 27);
        let mut trect3: &Rectangle = &rectangle
        this.AddMouse( trect3, "MINIMAP", "View the mini-map. [F8]", 7);
      }
      this.tab2 = this.MouseCounter;
    }

    pub fn HandleToolTip(x: i32, y: i32)
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

    pub HandleMouseClick: WindowReturnClass(x: i32, y: i32, b: i32)
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

    pub HandleKeyPress: WindowReturnClass(nr: i32, bool fromTimer = false)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (nr == 77)
        SoundMod.dssEnd( this.game.EditObj);
      return windowReturnClass;
    }
  }
}
