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
  public class RandomTopClass : WindowClass
  {
    private int w;
    private int h;
    private int CurrentView;
    private int tab1;
    private int tab2;
    private int tab3;
    private string tabname;

    public RandomTopClass(
      ref GameClass tGame,
      ref WindowClass tLowerWindow,
      ref Rectangle tLowerRect)
      : base(ref tGame, tGame.ScreenWidth, 75, 8)
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

    public override WindowReturnClass HandleMouseMove(int x, int y)
    {
      WindowReturnClass windowReturnClass = base.HandleMouseMove(x, y);
      if (y < 60)
        windowReturnClass.NoMouseClickBelow = true;
      return windowReturnClass;
    }

    public override void DoRefresh() => this.dostuff();

    public void dostuff()
    {
      if (this.game.EditObj.SetViewMode2 > 0 & this.game.EditObj.SetViewMode2 < 101)
        this.game.EditObj.SetViewMode2 = 0;
      this.CurrentView = this.game.EditObj.SetViewMode2;
      this.ClearMouse();
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      for (int index = 0; index < this.game.ScreenWidth; index += 100)
      {
        ref Graphics local1 = ref graphics;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCTOPBAR);
        ref Bitmap local2 = ref bitmap;
        int x = index;
        DrawMod.DrawSimple(ref local1, ref local2, x, 0);
      }
      this.DrawTabs((object) graphics);
      if (Information.IsNothing((object) graphics))
        return;
      graphics.Dispose();
    }

    public void DrawTabs(object g)
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
        ref Graphics local1 = ref objgraphics;
        Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.MARCTAB);
        ref Bitmap local2 = ref bitmap2;
        trect1 = new Rectangle(0, 20, 8, 43);
        Rectangle srcrect1 = trect1;
        rectangle = new Rectangle(rectForTab.X, 32, 8, 43);
        Rectangle destrect1 = rectangle;
        DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
        g = (object) objgraphics;
        objgraphics = (Graphics) g;
        ref Graphics local3 = ref objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCTAB);
        ref Bitmap local4 = ref bitmap1;
        rectangle = new Rectangle(170, 20, 16, 43);
        Rectangle srcrect2 = rectangle;
        trect1 = new Rectangle(rectForTab.X + rectForTab.Width - 16, 32, 16, 43);
        Rectangle destrect2 = trect1;
        DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
        g = (object) objgraphics;
        int x = rectForTab.X + 8;
        int width = 160;
        for (; x < rectForTab.X + rectForTab.Width; x += 160)
        {
          if (x + width > rectForTab.X + rectForTab.Width - 16)
            width = rectForTab.X + rectForTab.Width - 16 - x;
          objgraphics = (Graphics) g;
          ref Graphics local5 = ref objgraphics;
          bitmap1 = BitmapStore.GetBitmap(this.game.MARCTAB);
          ref Bitmap local6 = ref bitmap1;
          rectangle = new Rectangle(10, 20, width, 43);
          Rectangle srcrect3 = rectangle;
          trect1 = new Rectangle(x, 32, width, 43);
          Rectangle destrect3 = trect1;
          DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
          g = (object) objgraphics;
        }
      }
      SizeF sizeF1;
      SizeF sizeF2;
      if (this.tabname.Length > 0 && this.CurrentView != 101)
      {
        int x1 = 160;
        objgraphics = (Graphics) g;
        ref Graphics local7 = ref objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCTABBUTTON);
        ref Bitmap local8 = ref bitmap1;
        int x2 = x1;
        DrawMod.DrawSimple(ref local7, ref local8, x2, 32);
        g = (object) objgraphics;
        object Instance = g;
        object[] objArray1 = new object[2]
        {
          (object) this.tabname,
          null
        };
        object[] objArray2 = objArray1;
        GameClass tgame = DrawMod.TGame;
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
          tgame.MarcFont4 = (Font) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray3[1]), typeof (Font));
        sizeF2 = obj != null ? (SizeF) obj : sizeF1;
        objgraphics = (Graphics) g;
        DrawMod.DrawTextColouredMarc(ref objgraphics, this.tabname, this.game.MarcFont4, x1 + (int) Math.Round((78.0 - (double) sizeF2.Width) / 2.0), 33, Color.White);
        g = (object) objgraphics;
        rectangle = new Rectangle(x1, 32, 75, 27);
        trect1 = rectangle;
        this.AddMouse(ref trect1, this.tabname, "Random Screen Tab #1", 1);
        this.tab1 = this.MouseCounter;
      }
      if (this.CurrentView == 107)
        return;
      if (this.game.ScreenWidth <= 1040)
      {
        int x = (int) Math.Round(Math.Max((double) this.game.ScreenWidth / 2.0 + 158.0 + 300.0, (double) (this.game.ScreenWidth - DrawMod.GetWidthForMiniMap())));
        objgraphics = (Graphics) g;
        ref Graphics local9 = ref objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCTABBUTTON);
        ref Bitmap local10 = ref bitmap1;
        rectangle = new Rectangle(0, 0, 78, 33);
        Rectangle srcrect = rectangle;
        trect1 = new Rectangle(x, 32, 50, 33);
        Rectangle destrect = trect1;
        DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect, destrect);
        g = (object) objgraphics;
        object Instance = g;
        object[] objArray4 = new object[2]
        {
          (object) "MINI",
          null
        };
        object[] objArray5 = objArray4;
        GameClass tgame = DrawMod.TGame;
        Font marcFont4 = tgame.MarcFont4;
        objArray5[1] = (object) marcFont4;
        object[] objArray6 = objArray4;
        object[] Arguments = objArray6;
        bool[] flagArray = new bool[2]{ false, true };
        bool[] CopyBack = flagArray;
        object obj = NewLateBinding.LateGet(Instance, (Type) null, "MeasureString", Arguments, (string[]) null, (Type[]) null, CopyBack);
        if (flagArray[1])
          tgame.MarcFont4 = (Font) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray6[1]), typeof (Font));
        sizeF2 = obj != null ? (SizeF) obj : sizeF1;
        objgraphics = (Graphics) g;
        DrawMod.DrawTextColouredMarc(ref objgraphics, "MINI", this.game.MarcFont4, x + (int) Math.Round((53.0 - (double) sizeF2.Width) / 2.0), 33, Color.White);
        g = (object) objgraphics;
        rectangle = new Rectangle(x, 32, 50, 27);
        Rectangle trect2 = rectangle;
        this.AddMouse(ref trect2, "MINIMAP", "View the mini-map. [F8]", 7);
      }
      else
      {
        int x3 = (int) Math.Round(Math.Max((double) this.game.ScreenWidth / 2.0 + 158.0 + 300.0, (double) (this.game.ScreenWidth - DrawMod.GetWidthForMiniMap())));
        objgraphics = (Graphics) g;
        ref Graphics local11 = ref objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCTABBUTTON);
        ref Bitmap local12 = ref bitmap1;
        int x4 = x3;
        DrawMod.DrawSimple(ref local11, ref local12, x4, 32);
        g = (object) objgraphics;
        object Instance = g;
        object[] objArray7 = new object[2]
        {
          (object) "MINI",
          null
        };
        object[] objArray8 = objArray7;
        GameClass tgame = DrawMod.TGame;
        Font marcFont4 = tgame.MarcFont4;
        objArray8[1] = (object) marcFont4;
        object[] objArray9 = objArray7;
        object[] Arguments = objArray9;
        bool[] flagArray = new bool[2]{ false, true };
        bool[] CopyBack = flagArray;
        object obj = NewLateBinding.LateGet(Instance, (Type) null, "MeasureString", Arguments, (string[]) null, (Type[]) null, CopyBack);
        if (flagArray[1])
          tgame.MarcFont4 = (Font) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray9[1]), typeof (Font));
        sizeF2 = obj != null ? (SizeF) obj : sizeF1;
        objgraphics = (Graphics) g;
        DrawMod.DrawTextColouredMarc(ref objgraphics, "MINI", this.game.MarcFont4, x3 + (int) Math.Round((78.0 - (double) sizeF2.Width) / 2.0), 33, Color.White);
        g = (object) objgraphics;
        rectangle = new Rectangle(x3, 32, 75, 27);
        Rectangle trect3 = rectangle;
        this.AddMouse(ref trect3, "MINIMAP", "View the mini-map. [F8]", 7);
      }
      this.tab2 = this.MouseCounter;
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

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (nr == 77)
        SoundMod.dssEnd(ref this.game.EditObj);
      return windowReturnClass;
    }
  }
}
