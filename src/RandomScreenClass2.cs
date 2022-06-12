// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.RandomScreenClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class RandomScreenClass2 : ScreenClass
  {
    private int WMap;
    private int WTop;
    private int WTabs;
    private int WBottom;
    private int OffSetX;

    public RandomScreenClass2(ref GameClass tgame, Form1 tformref)
      : base(ref tgame, -3, tformref)
    {
      this.Game.HandyFunctionsObj.RedimTempValue3(9999);
      if ((double) this.Game.Data.RuleVar[701] > 0.0)
        this.Game.HandyFunctionsObj.RedimTempValue4(9999);
      this.OffSetX = (int) Math.Round((double) (this.Game.ScreenWidth - 1280) / 2.0);
      this.Game.SelectX = -1;
      this.Game.SelectY = -1;
      this.Game.EditObj.interfaceCue = 0;
      if (this.Game.Data.UseAI == 1)
      {
        if (Information.IsNothing((object) this.Game.NewAIObj))
          this.Game.NewAIObj = new NewAIClass(this.Game);
        this.Game.DC2AIObj = (DC2AIClass) null;
        this.Game.AIObj = (AIClass) null;
      }
      else if (this.Game.Data.UseAI == 2)
      {
        if (Information.IsNothing((object) this.Game.DC2AIObj))
          this.Game.DC2AIObj = new DC2AIClass(this.Game);
        this.Game.NewAIObj = (NewAIClass) null;
        this.Game.AIObj = (AIClass) null;
      }
      if ((double) this.Game.Data.RuleVar[442] > 0.0)
        this.Game.EventRelatedObj.DoCheckSpecificEvent((int) Math.Round((double) this.Game.Data.RuleVar[442]));
      this.Game.EditObj.inRandomScreen = true;
      MapWindowClass2 tmpWindow = new MapWindowClass2(ref tgame, 32, 0);
      int screenWidth = this.Game.ScreenWidth;
      int h = this.Game.ScreenHeight - 32;
      Rectangle rectangle1 = new Rectangle(0, 75, this.Game.ScreenWidth, this.Game.ScreenHeight - 107);
      Rectangle tShowRectangle = rectangle1;
      this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, h, tShowRectangle);
      this.WBottom = this.AddWindow((WindowClass) new RandomBottomClass(ref tgame), 0, this.Game.ScreenHeight - 32, this.Game.ScreenWidth, 32);
      this.Game.EditObj.dssLastDominant = 1002;
      this.Game.EditObj.SetViewMode2 = 101;
      Rectangle rectForTab = DrawMod.GetRectForTab(this.Game.EditObj.SetViewMode2);
      ref GameClass local1 = ref tgame;
      ref WindowClass local2 = ref this.WindowList[this.GetNr(this.WMap)];
      rectangle1 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
      Rectangle rectangle2 = rectangle1;
      ref Rectangle local3 = ref rectangle2;
      Rectangle trect = rectForTab;
      this.WTabs = this.AddWindow((WindowClass) new TabManagementWindowClass2(ref local1, ref local2, ref local3, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
      ref GameClass local4 = ref tgame;
      ref WindowClass local5 = ref this.WindowList[this.GetNr(this.WMap)];
      rectangle2 = new Rectangle(0, 0, this.Game.ScreenWidth, 75);
      rectangle1 = rectangle2;
      ref Rectangle local6 = ref rectangle1;
      this.WTop = this.AddWindow((WindowClass) new RandomTopClass(ref local4, ref local5, ref local6), 0, 0, this.Game.ScreenWidth, 75);
    }

    public ScreenReturnClass HandleWR(
      WindowReturnClass wr,
      bool setflag,
      ref ScreenReturnClass obj)
    {
      if (wr.Counter > -1)
      {
        int counter = wr.Counter;
        for (int index = 0; index <= counter; ++index)
        {
          if (wr.CommandType[index] == 3)
          {
            this.Game.EditObj.dssLastDominant = -1;
            obj.NewScreen = wr.CommandData[index];
            return obj;
          }
          if (wr.CommandType[index] == 5)
          {
            obj.OpenPopUp = true;
            obj.NewScreen = wr.CommandData[index];
            return obj;
          }
          if (wr.CommandType[index] == 6)
          {
            obj.ClosePopUp = true;
            obj.NewScreen = 0;
            return obj;
          }
          if (wr.CommandType[index] == 4)
          {
            if ((wr.CommandData[index] == 114 | wr.CommandData[index] == 67) & this.WTop > 0 & !this.WindowFlag[this.GetNr(this.WTop)])
            {
              this.WindowList[this.GetNr(this.WTop)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WTop)] = true;
            }
            if (wr.CommandData[index] == 115 & this.WMap > 0)
            {
              this.WindowList[this.GetNr(this.WMap)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WMap)] = true;
            }
            if (wr.CommandData[index] == 12 & this.WMap > 0)
            {
              this.WindowList[this.GetNr(this.WMap)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WMap)] = true;
            }
            if (wr.CommandData[index] == 9 & this.WTabs > 0)
            {
              this.WindowList[this.GetNr(this.WTabs)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WTabs)] = true;
            }
            if (wr.CommandData[index] == 116 & this.WBottom > 0)
            {
              this.WindowList[this.GetNr(this.WBottom)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WBottom)] = true;
            }
          }
          if (wr.CommandType[index] == 7)
            this.WindowFlag[this.GetNr(this.WMap)] = true;
          if (wr.CommandType[index] == 1)
          {
            if (wr.CommandData[index] == 12)
            {
              this.RemoveWindow(this.WMap);
              this.WMap = 0;
            }
            if (wr.CommandData[index] == 114)
            {
              this.RemoveWindow(this.WTop);
              this.WTop = 0;
            }
            if (wr.CommandData[index] == 116)
            {
              this.RemoveWindow(this.WBottom);
              this.WBottom = 0;
            }
            if (wr.CommandData[index] == 115)
            {
              this.RemoveWindow(this.WMap);
              this.WMap = 0;
            }
            if (wr.CommandData[index] == 9)
            {
              this.RemoveWindow(this.WTabs);
              this.WTabs = 0;
            }
          }
          if (wr.CommandType[index] == 2)
          {
            Rectangle rectangle1;
            if (wr.CommandData[index] == 12)
            {
              MapWindowClass2 tmpWindow = new MapWindowClass2(ref DrawMod.TGame, 32, 0);
              int screenWidth = this.Game.ScreenWidth;
              int h = this.Game.ScreenHeight - 32;
              rectangle1 = new Rectangle(0, 75, this.Game.ScreenWidth, this.Game.ScreenHeight - 107);
              Rectangle tShowRectangle = rectangle1;
              this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, h, tShowRectangle);
              if (this.WTop > 0)
                this.WindowList[this.GetNr(this.WTop)].LowerWindow = this.WindowList[this.GetNr(this.WMap)];
              if (this.WBottom > 0)
                this.WindowList[this.GetNr(this.WBottom)].LowerWindow = this.WindowList[this.GetNr(this.WMap)];
              if (this.WTabs > 0)
                this.WindowList[this.GetNr(this.WTabs)].LowerWindow = this.WindowList[this.GetNr(this.WMap)];
            }
            Rectangle rectangle2;
            if (wr.CommandData[index] == 114)
            {
              ref GameClass local1 = ref DrawMod.TGame;
              ref WindowClass local2 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, 75);
              rectangle2 = rectangle1;
              ref Rectangle local3 = ref rectangle2;
              this.WTop = this.AddWindow((WindowClass) new RandomTopClass(ref local1, ref local2, ref local3), 0, 0, this.Game.ScreenWidth, 75);
            }
            if (wr.CommandData[index] == 116)
              this.WBottom = this.AddWindow((WindowClass) new RandomBottomClass(ref DrawMod.TGame), 0, this.Game.ScreenHeight - 32, this.Game.ScreenWidth, 32);
            Rectangle rectForTab;
            if (wr.CommandData[index] == 113)
            {
              rectForTab = DrawMod.GetRectForTab(this.Game.EditObj.SetViewMode2);
              ref GameClass local4 = ref DrawMod.TGame;
              ref WindowClass local5 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
              rectangle1 = rectangle2;
              ref Rectangle local6 = ref rectangle1;
              Rectangle trect = rectForTab;
              this.WTabs = this.AddWindow((WindowClass) new TabManagementWindowClass2(ref local4, ref local5, ref local6, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
            }
            if (wr.CommandData[index] == 76)
            {
              rectForTab = DrawMod.GetRectForTab(7);
              ref GameClass local7 = ref DrawMod.TGame;
              ref WindowClass local8 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
              rectangle1 = rectangle2;
              ref Rectangle local9 = ref rectangle1;
              Rectangle trect = rectForTab;
              this.WTabs = this.AddWindow((WindowClass) new TabMiniMapWindowClass2(ref local7, ref local8, ref local9, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
            }
          }
        }
      }
      if (setflag)
        obj.flag = wr.Flag;
      else if (wr.Flag)
        obj.flag = wr.Flag;
      ScreenReturnClass screenReturnClass;
      return screenReturnClass;
    }

    public override ScreenReturnClass HandleMouseClick(int x, int y, int b)
    {
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      if (x > this.Game.ScreenWidth - 52 & x < this.Game.ScreenWidth - 28 & y < 25)
        this.Game.FormRef.WindowState = FormWindowState.Minimized;
      if (x > this.Game.ScreenWidth - 28 & x < this.Game.ScreenWidth - 4 & y < 25 && Interaction.MsgBox((object) "Are you sure you want to exit your current game?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
      {
        this.Game.Data = new DataClass();
        this.Game.EditObj = new EditClass(this.Game.AppPath + "editobj.txt");
        if (this.Game.Data.UseAI == 1)
        {
          if (Information.IsNothing((object) this.Game.NewAIObj))
            this.Game.NewAIObj = new NewAIClass(this.Game);
          this.Game.NewAIObj.LastRegime = -1;
        }
        this.Game.EditObj.ShowInitialMenu = true;
        screenReturnClass.NewScreen = 12;
        return screenReturnClass;
      }
      if (this.WindowCounter > -1)
      {
        for (int windowCounter = this.WindowCounter; windowCounter >= 0; windowCounter += -1)
        {
          if (Operators.CompareString(this.WindowList[windowCounter].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) != 0 && x > this.WindowX[windowCounter] & x < this.WindowX[windowCounter] + this.WindowW[windowCounter] && y > this.WindowY[windowCounter] & y < this.WindowY[windowCounter] + this.WindowH[windowCounter])
          {
            WindowReturnClass wr = this.WindowList[windowCounter].HandleMouseClick(x - this.WindowX[windowCounter], y - this.WindowY[windowCounter], b);
            this.WindowFlag[windowCounter] = wr.Flag;
            if (wr.Flag)
            {
              this.HandleWR(wr, true, ref screenReturnClass);
              return screenReturnClass;
            }
            if (wr.NoMouseClickBelow)
            {
              screenReturnClass.flag = false;
              return screenReturnClass;
            }
          }
        }
        for (int windowCounter = this.WindowCounter; windowCounter >= 0; windowCounter += -1)
        {
          if (Operators.CompareString(this.WindowList[windowCounter].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) == 0 && x > this.WindowX[windowCounter] & x < this.WindowX[windowCounter] + this.WindowW[windowCounter] && y > this.WindowY[windowCounter] & y < this.WindowY[windowCounter] + this.WindowH[windowCounter])
          {
            WindowReturnClass wr = this.WindowList[windowCounter].HandleMouseClick(x - this.WindowX[windowCounter], y - this.WindowY[windowCounter], b);
            this.WindowFlag[windowCounter] = wr.Flag;
            if (wr.Flag)
            {
              this.HandleWR(wr, true, ref screenReturnClass);
              return screenReturnClass;
            }
            if (wr.NoMouseClickBelow)
            {
              screenReturnClass.flag = false;
              return screenReturnClass;
            }
          }
        }
        screenReturnClass.flag = false;
        return screenReturnClass;
      }
      screenReturnClass.flag = false;
      return screenReturnClass;
    }

    public override ScreenReturnClass HandleMouseUp(int x, int y, int b)
    {
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      if (this.WindowCounter > -1)
      {
        for (int windowCounter = this.WindowCounter; windowCounter >= 0; windowCounter += -1)
        {
          if (x > this.WindowX[windowCounter] & x < this.WindowX[windowCounter] + this.WindowW[windowCounter] && y > this.WindowY[windowCounter] & y < this.WindowY[windowCounter] + this.WindowH[windowCounter])
          {
            WindowReturnClass wr = this.WindowList[windowCounter].HandleMouseUp(x - this.WindowX[windowCounter], y - this.WindowY[windowCounter], b);
            this.WindowFlag[windowCounter] = wr.Flag;
            if (wr.Flag)
            {
              this.HandleWR(wr, true, ref screenReturnClass);
              return screenReturnClass;
            }
            if (wr.NoMouseClickBelow)
            {
              screenReturnClass.flag = false;
              return screenReturnClass;
            }
          }
        }
        screenReturnClass.flag = false;
        return screenReturnClass;
      }
      screenReturnClass.flag = false;
      return screenReturnClass;
    }

    public override ScreenReturnClass HandleMouseMove(int x, int y)
    {
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      if (x > this.Game.ScreenWidth - 52 & x < this.Game.ScreenWidth - 28 & y < 25)
      {
        if (!this.doMinimize)
        {
          this.doMinimize = true;
          screenReturnClass.flag = true;
        }
      }
      else if (this.doMinimize)
      {
        this.doMinimize = false;
        screenReturnClass.flag = true;
      }
      if (x > this.Game.ScreenWidth - 28 & x < this.Game.ScreenWidth - 4 & y < 25)
      {
        if (!this.doQuit)
        {
          this.doQuit = true;
          screenReturnClass.flag = true;
        }
      }
      else if (this.doQuit)
      {
        this.doQuit = false;
        screenReturnClass.flag = true;
      }
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      int windowCounter1 = this.WindowCounter;
      WindowReturnClass windowReturnClass;
      for (int index = 0; index <= windowCounter1; ++index)
      {
        if (Operators.CompareString(this.WindowList[index].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) != 0 && x >= this.WindowX[index] & x <= this.WindowX[index] + this.WindowW[index] & y >= this.WindowY[index] & y <= this.WindowY[index] + this.WindowH[index])
        {
          windowReturnClass = this.WindowList[index].HandleMouseMove(x - this.WindowX[index], y - this.WindowY[index]);
          this.WindowFlag[index] = windowReturnClass.Flag;
          if (windowReturnClass.Counter > -1)
          {
            this.HandleWR(windowReturnClass, true, ref screenReturnClass);
            windowReturnClass.Flag = true;
          }
          if (windowReturnClass.Overlay | this.LastOverlayWindow > 0)
          {
            if (this.LastOverlayWindow > 0 & this.LastOverlayWindow != this.WindowID[index])
              this.ClearOverlaySpecificWindow(this.LastOverlayWindow);
            if (windowReturnClass.Overlay)
              this.LastOverlayWindow = this.WindowID[index];
          }
          if (!screenReturnClass.flag)
            screenReturnClass.flag = windowReturnClass.Flag;
          if (screenReturnClass.flag | windowReturnClass.Overlay || windowReturnClass.NoMouseClickBelow)
            return screenReturnClass;
        }
      }
      int num;
      if (Information.IsNothing((object) windowReturnClass))
        num = 1;
      else if (!windowReturnClass.NoMouseClickBelow)
        num = 1;
      if (num == 1)
      {
        int windowCounter2 = this.WindowCounter;
        for (int index = 0; index <= windowCounter2; ++index)
        {
          if (Operators.CompareString(this.WindowList[index].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) == 0 && x >= this.WindowX[index] & x <= this.WindowX[index] + this.WindowW[index] & y >= this.WindowY[index] & y <= this.WindowY[index] + this.WindowH[index])
          {
            WindowReturnClass wr = this.WindowList[index].HandleMouseMove(x - this.WindowX[index], y - this.WindowY[index]);
            this.WindowFlag[index] = wr.Flag;
            if (wr.Counter > -1)
            {
              this.HandleWR(wr, true, ref screenReturnClass);
              wr.Flag = true;
            }
            if (wr.Overlay | this.LastOverlayWindow > 0)
            {
              if (this.LastOverlayWindow > 0 & this.LastOverlayWindow != this.WindowID[index])
                this.ClearOverlaySpecificWindow(this.LastOverlayWindow);
              if (wr.Overlay)
                this.LastOverlayWindow = this.WindowID[index];
            }
            if (!screenReturnClass.flag)
              screenReturnClass.flag = wr.Flag;
            if (screenReturnClass.flag)
              return screenReturnClass;
          }
        }
      }
      if (this.LastOverlayWindow > 0)
      {
        this.ClearOverlaySpecificWindow(this.LastOverlayWindow);
        screenReturnClass.flag = true;
      }
      return screenReturnClass;
    }

    public override ScreenReturnClass HandleTimerWheel(int x, int y)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      ScreenReturnClass screenReturnClass1 = new ScreenReturnClass();
      if (this.WindowCounter <= -1)
      {
        ScreenReturnClass screenReturnClass2;
        return screenReturnClass2;
      }
      int num = 1;
      do
      {
        int windowCounter1 = this.WindowCounter;
        for (int index1 = 0; index1 <= windowCounter1; ++index1)
        {
          bool flag;
          if (x > this.WindowX[index1] & y > this.WindowY[index1] & x < this.WindowX[index1] + this.WindowW[index1] & y < this.WindowY[index1] + this.WindowH[index1])
            flag = true;
          if (Operators.CompareString(this.WindowList[index1].GetType().FullName, "WindowsApplication1.RandomBottomClass", false) == 0)
          {
            if (num == 2)
            {
              int windowCounter2 = this.WindowCounter;
              for (int index2 = 0; index2 <= windowCounter2; ++index2)
              {
                if (Operators.CompareString(this.WindowList[index2].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) == 0 && x > this.WindowX[index2] & y > this.WindowY[index2] & x < this.WindowX[index2] + this.WindowW[index2] & y < this.WindowY[index2] + this.WindowH[index2])
                  flag = true;
              }
            }
            else
              flag = false;
          }
          else if (num == 2)
            flag = false;
          if (Operators.CompareString(this.WindowList[index1].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) == 0)
            flag = false;
          if (flag)
          {
            WindowReturnClass wr = this.WindowList[index1].handleTimerWheel(x - this.WindowX[index1], y - this.WindowY[index1]);
            if (wr.Flag)
            {
              screenReturnClass1.flag = true;
              this.WindowFlag[index1] = true;
              if (wr.Counter > -1)
                this.HandleWR(wr, false, ref screenReturnClass1);
              return screenReturnClass1;
            }
            this.Game.EditObj.MouseWheel = 0;
            screenReturnClass1.flag = false;
            return screenReturnClass1;
          }
        }
        ++num;
      }
      while (num <= 2);
      this.Game.EditObj.MouseWheel = 0;
      screenReturnClass1.flag = false;
      return screenReturnClass1;
    }

    public override ScreenReturnClass HandleTimer()
    {
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      bool flag = false;
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      for (int windowCounter = this.WindowCounter; windowCounter >= 0; windowCounter += -1)
      {
        if (Operators.CompareString(this.WindowList[windowCounter].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) != 0)
        {
          WindowReturnClass wr = this.WindowList[windowCounter].handleTimer();
          if (!this.WindowFlag[windowCounter] & wr.Flag)
            this.WindowFlag[windowCounter] = wr.Flag;
          if (wr.Flag)
          {
            if (wr.Counter > -1)
              this.HandleWR(wr, false, ref screenReturnClass);
            if (wr.Flag)
              flag = true;
          }
        }
      }
      for (int windowCounter = this.WindowCounter; windowCounter >= 0; windowCounter += -1)
      {
        if (Operators.CompareString(this.WindowList[windowCounter].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) == 0)
        {
          WindowReturnClass wr = this.WindowList[windowCounter].handleTimer();
          if (!this.WindowFlag[windowCounter] & wr.Flag)
            this.WindowFlag[windowCounter] = wr.Flag;
          if (wr.Flag)
          {
            if (wr.Counter > -1)
              this.HandleWR(wr, false, ref screenReturnClass);
            if (wr.Flag)
              flag = true;
          }
        }
      }
      if (flag)
        screenReturnClass.flag = true;
      return screenReturnClass;
    }

    public override ScreenReturnClass HandleKeyPress(int nr)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      for (int windowCounter = this.WindowCounter; windowCounter >= 0; windowCounter += -1)
      {
        WindowReturnClass wr = this.WindowList[windowCounter].HandleKeyPress(nr);
        if (!this.WindowFlag[windowCounter] & wr.Flag)
          this.WindowFlag[windowCounter] = wr.Flag;
        if (wr.Counter > -1)
          this.HandleWR(wr, false, ref screenReturnClass);
        if (wr.Flag)
        {
          screenReturnClass.flag = true;
          return screenReturnClass;
        }
      }
      screenReturnClass.flag = true;
      return screenReturnClass;
    }
  }
}
