// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.HistoryScreenClass2
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
  public class HistoryScreenClass2 : ScreenClass
  {
    private int WMap;
    private int WPlay;
    private int WOrder;
    private int WRes;
    private int WTabs;
    private int OffSetX;

    public HistoryScreenClass2(ref GameClass tgame, Form1 tformref)
      : base(ref tgame, -3, tformref)
    {
      this.OffSetX = (int) Math.Round((double) (this.Game.ScreenWidth - 1024) / 2.0);
      this.Game.HandyFunctionsObj.SetGameColors();
      this.WPlay = this.AddWindow((WindowClass) new HistoryWindowClass2(ref tgame), 0, this.Game.ScreenHeight - 222, this.Game.ScreenWidth, 222);
      Rectangle rectangle1;
      if (this.Game.Data.Product == 6)
      {
        MapWindowClass2 tmpWindow = new MapWindowClass2(ref tgame, 222, 0, this.Game.EditObj.Zoom);
        int screenWidth = this.Game.ScreenWidth;
        int h = this.Game.ScreenHeight - 222;
        rectangle1 = new Rectangle(0, 75, this.Game.ScreenWidth, this.Game.ScreenHeight - 387);
        Rectangle tShowRectangle = rectangle1;
        this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, h, tShowRectangle);
      }
      else
      {
        MapWindowClass2 tmpWindow = new MapWindowClass2(ref tgame, 222, 0, 0);
        int screenWidth = this.Game.ScreenWidth;
        int h = this.Game.ScreenHeight - 222;
        rectangle1 = new Rectangle(0, 75, this.Game.ScreenWidth, this.Game.ScreenHeight - 387);
        Rectangle tShowRectangle = rectangle1;
        this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, h, tShowRectangle);
      }
      ref GameClass local1 = ref tgame;
      ref WindowClass local2 = ref this.WindowList[this.GetNr(this.WMap)];
      rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, 75);
      Rectangle rectangle2 = rectangle1;
      ref Rectangle local3 = ref rectangle2;
      this.WRes = this.AddWindow((WindowClass) new ResourceWindowClass2(ref local1, ref local2, ref local3), 0, 0, this.Game.ScreenWidth, 75);
      ref GameClass local4 = ref tgame;
      ref WindowClass local5 = ref this.WindowList[this.GetNr(this.WMap)];
      rectangle2 = new Rectangle(0, this.Game.ScreenHeight - 312, this.Game.ScreenWidth, 90);
      Rectangle rectangle3 = rectangle2;
      ref Rectangle local6 = ref rectangle3;
      WindowClass[] windowList = this.WindowList;
      WindowClass[] windowClassArray = windowList;
      int nr = this.GetNr(this.WPlay);
      int index = nr;
      HistoryWindowClass2 historyWindowClass2 = (HistoryWindowClass2) windowClassArray[index];
      ref HistoryWindowClass2 local7 = ref historyWindowClass2;
      HistoryOrderWindowClass tmpWindow1 = new HistoryOrderWindowClass(ref local4, ref local5, ref local6, ref local7);
      windowList[nr] = (WindowClass) historyWindowClass2;
      int y = this.Game.ScreenHeight - 312;
      int screenWidth1 = this.Game.ScreenWidth;
      this.WOrder = this.AddWindow((WindowClass) tmpWindow1, 0, y, screenWidth1, 90);
      Rectangle rectForTab;
      if (this.Game.EditObj.SetViewMode2 == 1)
      {
        rectForTab = DrawMod.GetRectForTab(1);
        ref GameClass local8 = ref tgame;
        ref WindowClass local9 = ref this.WindowList[this.GetNr(this.WMap)];
        rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
        Rectangle rectangle4 = rectangle2;
        ref Rectangle local10 = ref rectangle4;
        Rectangle trect = rectForTab;
        this.WTabs = this.AddWindow((WindowClass) new TabBriefingWindowClass2(ref local8, ref local9, ref local10, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
      }
      if (this.Game.EditObj.SetViewMode2 == 2)
      {
        rectForTab = DrawMod.GetRectForTab(2);
        ref GameClass local11 = ref tgame;
        ref WindowClass local12 = ref this.WindowList[this.GetNr(this.WMap)];
        rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
        Rectangle rectangle5 = rectangle2;
        ref Rectangle local13 = ref rectangle5;
        Rectangle trect = rectForTab;
        this.WTabs = this.AddWindow((WindowClass) new TabStatsWindowClass2(ref local11, ref local12, ref local13, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
      }
      if (this.Game.EditObj.SetViewMode2 == 3)
      {
        rectForTab = DrawMod.GetRectForTab(3);
        ref GameClass local14 = ref tgame;
        ref WindowClass local15 = ref this.WindowList[this.GetNr(this.WMap)];
        rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
        Rectangle rectangle6 = rectangle2;
        ref Rectangle local16 = ref rectangle6;
        Rectangle trect = rectForTab;
        this.WTabs = this.AddWindow((WindowClass) new TabOOBWindowClass2(ref local14, ref local15, ref local16, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
      }
      if (this.Game.EditObj.SetViewMode2 == 4)
      {
        rectForTab = DrawMod.GetRectForTab(4);
        ref GameClass local17 = ref tgame;
        ref WindowClass local18 = ref this.WindowList[this.GetNr(this.WMap)];
        rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
        Rectangle rectangle7 = rectangle2;
        ref Rectangle local19 = ref rectangle7;
        Rectangle trect = rectForTab;
        this.WTabs = this.AddWindow((WindowClass) new TabReportsWindowClass2(ref local17, ref local18, ref local19, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
      }
      if (this.Game.EditObj.SetViewMode2 == 5)
      {
        rectForTab = DrawMod.GetRectForTab(5);
        ref GameClass local20 = ref tgame;
        ref WindowClass local21 = ref this.WindowList[this.GetNr(this.WMap)];
        rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
        Rectangle rectangle8 = rectangle2;
        ref Rectangle local22 = ref rectangle8;
        Rectangle trect = rectForTab;
        this.WTabs = this.AddWindow((WindowClass) new TabCardsWindowClass2(ref local20, ref local21, ref local22, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
      }
      if (this.Game.EditObj.SetViewMode2 == 6)
      {
        rectForTab = DrawMod.GetRectForTab(6);
        ref GameClass local23 = ref tgame;
        ref WindowClass local24 = ref this.WindowList[this.GetNr(this.WMap)];
        rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
        Rectangle rectangle9 = rectangle2;
        ref Rectangle local25 = ref rectangle9;
        Rectangle trect = rectForTab;
        this.WTabs = this.AddWindow((WindowClass) new TabSMapWindowClass2(ref local23, ref local24, ref local25, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
      }
      if (this.Game.EditObj.SetViewMode2 == 7)
      {
        rectForTab = DrawMod.GetRectForTab(7);
        ref GameClass local26 = ref tgame;
        ref WindowClass local27 = ref this.WindowList[this.GetNr(this.WMap)];
        rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
        Rectangle rectangle10 = rectangle2;
        ref Rectangle local28 = ref rectangle10;
        Rectangle trect = rectForTab;
        this.WTabs = this.AddWindow((WindowClass) new TabMiniMapWindowClass2(ref local26, ref local27, ref local28, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
      }
      if (this.Game.EditObj.SetViewMode2 != 8)
        return;
      rectForTab = DrawMod.GetRectForTab(8);
      ref GameClass local29 = ref tgame;
      ref WindowClass local30 = ref this.WindowList[this.GetNr(this.WMap)];
      rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
      Rectangle rectangle11 = rectangle2;
      ref Rectangle local31 = ref rectangle11;
      Rectangle trect1 = rectForTab;
      this.WTabs = this.AddWindow((WindowClass) new TabPrefsWindowClass2(ref local29, ref local30, ref local31, trect1), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
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
            if (wr.CommandData[index] == 80)
            {
              this.WindowList[this.GetNr(this.WPlay)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WPlay)] = true;
            }
            if (wr.CommandData[index] == 12)
            {
              this.WindowList[this.GetNr(this.WMap)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WMap)] = true;
            }
            if (wr.CommandData[index] == 81 | wr.CommandData[index] == 68 | wr.CommandData[index] == 44)
            {
              this.WindowList[this.GetNr(this.WOrder)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WOrder)] = true;
            }
            if (wr.CommandData[index] == 67)
            {
              this.WindowList[this.GetNr(this.WRes)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WRes)] = true;
            }
            if (wr.CommandData[index] == 9 & this.WTabs > 0)
            {
              this.WindowList[this.GetNr(this.WTabs)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WTabs)] = true;
            }
            if (wr.CommandData[index] == 35)
            {
              this.WindowList[this.GetNr(this.WPlay)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WPlay)] = true;
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
            if (wr.CommandData[index] == 67)
            {
              this.RemoveWindow(this.WRes);
              this.WRes = 0;
            }
            if (wr.CommandData[index] == 69 | wr.CommandData[index] == 5)
            {
              this.RemoveWindow(this.WPlay);
              this.WPlay = 0;
            }
            if (wr.CommandData[index] == 68)
            {
              this.RemoveWindow(this.WOrder);
              this.WOrder = 0;
            }
            if (wr.CommandData[index] == 9)
            {
              this.RemoveWindow(this.WTabs);
              this.WTabs = 0;
              this.WTabs = 0;
            }
          }
          if (wr.CommandType[index] == 2)
          {
            Rectangle rectangle1;
            if (wr.CommandData[index] == 12)
            {
              MapWindowClass2 tmpWindow = new MapWindowClass2(ref DrawMod.TGame, 222, 0);
              int screenWidth = this.Game.ScreenWidth;
              int h = this.Game.ScreenHeight - 222;
              rectangle1 = new Rectangle(0, 75, this.Game.ScreenWidth, this.Game.ScreenHeight - 387);
              Rectangle tShowRectangle = rectangle1;
              this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, h, tShowRectangle);
              if (this.WRes > 0)
                this.WindowList[this.GetNr(this.WRes)].LowerWindow = this.WindowList[this.GetNr(this.WMap)];
              if (this.WOrder > 0)
                this.WindowList[this.GetNr(this.WOrder)].LowerWindow = this.WindowList[this.GetNr(this.WMap)];
              if (this.WTabs > 0)
                this.WindowList[this.GetNr(this.WTabs)].LowerWindow = this.WindowList[this.GetNr(this.WMap)];
            }
            Rectangle rectangle2;
            if (wr.CommandData[index] == 67)
            {
              ref GameClass local1 = ref DrawMod.TGame;
              ref WindowClass local2 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, 75);
              rectangle2 = rectangle1;
              ref Rectangle local3 = ref rectangle2;
              this.WRes = this.AddWindow((WindowClass) new ResourceWindowClass2(ref local1, ref local2, ref local3), 0, 0, this.Game.ScreenWidth, 75);
            }
            Rectangle rectForTab;
            if (wr.CommandData[index] == 70)
            {
              rectForTab = DrawMod.GetRectForTab(1);
              ref GameClass local4 = ref DrawMod.TGame;
              ref WindowClass local5 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
              rectangle1 = rectangle2;
              ref Rectangle local6 = ref rectangle1;
              Rectangle trect = rectForTab;
              this.WTabs = this.AddWindow((WindowClass) new TabBriefingWindowClass2(ref local4, ref local5, ref local6, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
            }
            if (wr.CommandData[index] == 71)
            {
              rectForTab = DrawMod.GetRectForTab(2);
              ref GameClass local7 = ref DrawMod.TGame;
              ref WindowClass local8 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
              rectangle1 = rectangle2;
              ref Rectangle local9 = ref rectangle1;
              Rectangle trect = rectForTab;
              this.WTabs = this.AddWindow((WindowClass) new TabStatsWindowClass2(ref local7, ref local8, ref local9, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
            }
            if (wr.CommandData[index] == 72)
            {
              rectForTab = DrawMod.GetRectForTab(3);
              ref GameClass local10 = ref DrawMod.TGame;
              ref WindowClass local11 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
              rectangle1 = rectangle2;
              ref Rectangle local12 = ref rectangle1;
              Rectangle trect = rectForTab;
              this.WTabs = this.AddWindow((WindowClass) new TabOOBWindowClass2(ref local10, ref local11, ref local12, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
            }
            if (wr.CommandData[index] == 73)
            {
              rectForTab = DrawMod.GetRectForTab(4);
              ref GameClass local13 = ref DrawMod.TGame;
              ref WindowClass local14 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
              rectangle1 = rectangle2;
              ref Rectangle local15 = ref rectangle1;
              Rectangle trect = rectForTab;
              this.WTabs = this.AddWindow((WindowClass) new TabReportsWindowClass2(ref local13, ref local14, ref local15, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
            }
            if (wr.CommandData[index] == 74)
            {
              rectForTab = DrawMod.GetRectForTab(5);
              ref GameClass local16 = ref DrawMod.TGame;
              ref WindowClass local17 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
              rectangle1 = rectangle2;
              ref Rectangle local18 = ref rectangle1;
              Rectangle trect = rectForTab;
              this.WTabs = this.AddWindow((WindowClass) new TabCardsWindowClass2(ref local16, ref local17, ref local18, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
            }
            if (wr.CommandData[index] == 75)
            {
              rectForTab = DrawMod.GetRectForTab(6);
              ref GameClass local19 = ref DrawMod.TGame;
              ref WindowClass local20 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
              rectangle1 = rectangle2;
              ref Rectangle local21 = ref rectangle1;
              Rectangle trect = rectForTab;
              this.WTabs = this.AddWindow((WindowClass) new TabSMapWindowClass2(ref local19, ref local20, ref local21, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
            }
            if (wr.CommandData[index] == 76)
            {
              rectForTab = DrawMod.GetRectForTab(7);
              ref GameClass local22 = ref DrawMod.TGame;
              ref WindowClass local23 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
              rectangle1 = rectangle2;
              ref Rectangle local24 = ref rectangle1;
              Rectangle trect = rectForTab;
              this.WTabs = this.AddWindow((WindowClass) new TabMiniMapWindowClass2(ref local22, ref local23, ref local24, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
            }
            if (wr.CommandData[index] == 77)
            {
              rectForTab = DrawMod.GetRectForTab(8);
              ref GameClass local25 = ref DrawMod.TGame;
              ref WindowClass local26 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
              rectangle1 = rectangle2;
              ref Rectangle local27 = ref rectangle1;
              Rectangle trect = rectForTab;
              this.WTabs = this.AddWindow((WindowClass) new TabPrefsWindowClass2(ref local25, ref local26, ref local27, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
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
      if (this.Game.Data.Product != 7)
      {
        if (x > this.Game.ScreenWidth - 52 & x < this.Game.ScreenWidth - 28 & y < 25)
          this.Game.FormRef.WindowState = FormWindowState.Minimized;
        if (x > this.Game.ScreenWidth - 28 & x < this.Game.ScreenWidth - 4 & y < 25 && Interaction.MsgBox((object) "Are you sure you want to exit your current game?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
        {
          if (this.Game.AIRunning | this.Game.AIThreadRunning)
            this.Game.AIThread.Abort();
          this.Game.Data = new DataClass();
          this.Game.EditObj = new EditClass(this.Game.AppPath + "editobj.txt");
          if (this.Game.Data.UseAI == 1 & Information.IsNothing((object) this.Game.NewAIObj))
            this.Game.NewAIObj = new NewAIClass(this.Game);
          if (this.Game.Data.UseAI == 1)
            this.Game.NewAIObj.LastRegime = -1;
          this.Game.EditObj.ShowInitialMenu = true;
          screenReturnClass.NewScreen = 12;
          this.Game.AIThreadRunning = false;
          this.Game.AIRunning = false;
          return screenReturnClass;
        }
      }
      if (this.WindowCounter > -1)
      {
        for (int windowCounter = this.WindowCounter; windowCounter >= 0; windowCounter += -1)
        {
          if (Operators.CompareString(this.WindowList[windowCounter].GetType().FullName, "WindowsApplication1.MapWindowClass", false) != 0 && x > this.WindowX[windowCounter] & x < this.WindowX[windowCounter] + this.WindowW[windowCounter] && y > this.WindowY[windowCounter] & y < this.WindowY[windowCounter] + this.WindowH[windowCounter])
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
          if (Operators.CompareString(this.WindowList[windowCounter].GetType().FullName, "WindowsApplication1.MapWindowClass", false) == 0 && x > this.WindowX[windowCounter] & x < this.WindowX[windowCounter] + this.WindowW[windowCounter] && y > this.WindowY[windowCounter] & y < this.WindowY[windowCounter] + this.WindowH[windowCounter])
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
        if (Operators.CompareString(this.WindowList[index].GetType().FullName, "WindowsApplication1.MapWindowClass", false) != 0 & Operators.CompareString(this.WindowList[index].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) != 0 && x >= this.WindowX[index] & x <= this.WindowX[index] + this.WindowW[index] & y >= this.WindowY[index] & y <= this.WindowY[index] + this.WindowH[index])
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
          if (Operators.CompareString(this.WindowList[index].GetType().FullName, "WindowsApplication1.MapWindowClass", false) == 0 | Operators.CompareString(this.WindowList[index].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) == 0 && x >= this.WindowX[index] & x <= this.WindowX[index] + this.WindowW[index] & y >= this.WindowY[index] & y <= this.WindowY[index] + this.WindowH[index])
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

    public override ScreenReturnClass HandleTimer()
    {
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      this.Game.FormRef.debugPoint4 = 1;
      if (this.Game.Data.Product == 6 && this.Game.EditObj.OrderType > 0 & this.Game.EditObj.OrderType != 26 && !this.Game.AIThreadRunning & !this.Game.EditObj.AIMoving)
        return screenReturnClass;
      this.Game.FormRef.debugPoint4 = 2;
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      for (int windowCounter = this.WindowCounter; windowCounter >= 0; windowCounter += -1)
      {
        WindowReturnClass wr = this.WindowList[windowCounter].handleTimer();
        if (!this.WindowFlag[windowCounter] & wr.Flag)
        {
          this.WindowFlag[windowCounter] = wr.Flag;
          screenReturnClass.flag = true;
        }
        if (wr.Flag && wr.Counter > -1)
        {
          this.HandleWR(wr, false, ref screenReturnClass);
          this.Game.FormRef.debugPoint4 = 20 + windowCounter;
        }
      }
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
