// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleEditScreenClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class SimpleEditScreenClass : ScreenClass
  {
    private int WEditMenu;
    private int Wmiddle;
    private int wdown;
    private int wleft;
    private int worder;
    private int wup;
    private int OffSetX;

    public SimpleEditScreenClass(ref GameClass tgame, Form1 tformref)
      : base(ref tgame, tgame.BACKGROUND3MARC, tformref)
    {
      this.OffSetX = (int) Math.Round((double) (this.Game.ScreenWidth - 1024) / 2.0);
      this.AllowRightMouse = true;
      this.Game.EditObj.SimpleEditWindow = 95;
      this.WEditMenu = this.AddWindow((WindowClass) new SimpleEditOptionsWindowClass(ref tgame, this.OwnBackground, 0, 0), 0, 0, this.Game.ScreenWidth, 50);
      this.Wmiddle = this.AddWindow((WindowClass) new SimpleEditDashboardWindowClass(ref tgame), 0, 50, this.Game.ScreenWidth, this.Game.ScreenHeight - 50);
    }

    public override ScreenReturnClass HandleTimer()
    {
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      for (int windowCounter = this.WindowCounter; windowCounter >= 0; windowCounter += -1)
      {
        WindowReturnClass windowReturnClass = this.WindowList[windowCounter].handleTimer();
        if (!this.WindowFlag[windowCounter] & windowReturnClass.Flag)
          this.WindowFlag[windowCounter] = windowReturnClass.Flag;
        if (windowReturnClass.Flag)
        {
          if (windowReturnClass.Counter > -1)
          {
            int counter = windowReturnClass.Counter;
            for (int index = 0; index <= counter; ++index)
            {
              if (windowReturnClass.CommandType[index] == 5)
              {
                screenReturnClass.OpenPopUp = true;
                screenReturnClass.NewScreen = windowReturnClass.CommandData[index];
                return screenReturnClass;
              }
              if (windowReturnClass.CommandType[index] == 6)
              {
                screenReturnClass.ClosePopUp = true;
                screenReturnClass.NewScreen = 0;
                return screenReturnClass;
              }
            }
          }
          if (windowReturnClass.Flag)
            screenReturnClass.flag = windowReturnClass.Flag;
        }
      }
      return screenReturnClass;
    }

    public override ScreenReturnClass HandleMouseClick(int x, int y, int b)
    {
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      if (x > this.Game.ScreenWidth - 52 & x < this.Game.ScreenWidth - 28 & y < 25)
        this.Game.FormRef.WindowState = FormWindowState.Minimized;
      if (x > this.Game.ScreenWidth - 28 & x < this.Game.ScreenWidth - 4 & y < 25 && Interaction.MsgBox((object) "Are you sure you want to exit the editor?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
      {
        this.Game.Data = new DataClass();
        this.Game.EditObj = new EditClass(this.Game.AppPath + "editobj.txt");
        this.Game.EditObj.ShowInitialMenu = true;
        screenReturnClass.NewScreen = this.Game.ModIntroType != 0 ? 12 : 1;
        return screenReturnClass;
      }
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      int windowCounter = this.WindowCounter;
      for (int index1 = 0; index1 <= windowCounter; ++index1)
      {
        if (x > this.WindowX[index1] & x < this.WindowX[index1] + this.WindowW[index1] && y > this.WindowY[index1] & y < this.WindowY[index1] + this.WindowH[index1])
        {
          WindowReturnClass windowReturnClass = this.WindowList[index1].HandleMouseClick(x - this.WindowX[index1], y - this.WindowY[index1], b);
          this.WindowFlag[index1] = windowReturnClass.Flag;
          if (windowReturnClass.Counter > -1)
          {
            int counter = windowReturnClass.Counter;
            for (int index2 = 0; index2 <= counter; ++index2)
            {
              if (windowReturnClass.CommandType[index2] == 3)
              {
                screenReturnClass.NewScreen = windowReturnClass.CommandData[index2];
                return screenReturnClass;
              }
              if (windowReturnClass.CommandType[index2] == 5)
              {
                screenReturnClass.OpenPopUp = true;
                screenReturnClass.NewScreen = windowReturnClass.CommandData[index2];
                return screenReturnClass;
              }
              if (windowReturnClass.CommandType[index2] == 6)
              {
                screenReturnClass.ClosePopUp = true;
                screenReturnClass.NewScreen = 0;
                return screenReturnClass;
              }
              if (windowReturnClass.CommandType[index2] == 1)
              {
                if (windowReturnClass.CommandData[index2] == 4 | windowReturnClass.CommandData[index2] == 3 && this.Wmiddle > -1)
                {
                  this.RemoveWindow(this.Wmiddle);
                  this.Wmiddle = -1;
                }
                if (windowReturnClass.CommandData[index2] == 2 && this.wleft > -1)
                {
                  this.RemoveWindow(this.wleft);
                  this.wleft = -1;
                }
                if (windowReturnClass.CommandData[index2] == 5 && this.wdown > -1)
                {
                  this.RemoveWindow(this.wdown);
                  this.wdown = -1;
                }
                if (windowReturnClass.CommandData[index2] == 13 && this.WEditMenu > -1)
                {
                  this.RemoveWindow(this.WEditMenu);
                  this.WEditMenu = -1;
                }
                if (windowReturnClass.CommandData[index2] == 7 && this.worder > -1)
                {
                  this.RemoveWindow(this.worder);
                  this.worder = -1;
                }
              }
              if (windowReturnClass.CommandType[index2] == 4)
              {
                if (windowReturnClass.CommandData[index2] == 94 & this.WEditMenu > -1)
                {
                  this.WindowList[this.GetNr(this.WEditMenu)].DoRefresh();
                  this.WindowFlag[this.GetNr(this.WEditMenu)] = true;
                }
                if ((windowReturnClass.CommandData[index2] == 20 | windowReturnClass.CommandData[index2] == 69) & this.Wmiddle > -1)
                {
                  this.WindowList[this.GetNr(this.Wmiddle)].DoRefresh();
                  this.WindowFlag[this.GetNr(this.Wmiddle)] = true;
                }
                if (windowReturnClass.CommandData[index2] == 12 & this.Wmiddle > -1)
                {
                  this.WindowList[this.GetNr(this.wdown)].DoRefresh();
                  this.WindowFlag[this.GetNr(this.wdown)] = true;
                }
              }
              if (windowReturnClass.CommandType[index2] == 2)
              {
                if (windowReturnClass.CommandData[index2] == 94)
                  this.WEditMenu = this.AddWindow((WindowClass) new SimpleEditOptionsWindowClass(ref DrawMod.TGame, this.OwnBackground, 0, 0), 0, 0, this.Game.ScreenWidth, 50);
                if (windowReturnClass.CommandData[index2] == 95)
                  this.Wmiddle = this.AddWindow((WindowClass) new SimpleEditDashboardWindowClass(ref DrawMod.TGame), 0, 50, this.Game.ScreenWidth, this.Game.ScreenHeight - 50);
                if (windowReturnClass.CommandData[index2] == 100)
                  this.Wmiddle = this.AddWindow((WindowClass) new SimpleEditRegimeWindowClass(ref DrawMod.TGame), 0, 50, this.Game.ScreenWidth, this.Game.ScreenHeight - 50);
                if (windowReturnClass.CommandData[index2] == 109)
                  this.Wmiddle = this.AddWindow((WindowClass) new SimpleEditDebugWindowClass(ref DrawMod.TGame), 0, 50, this.Game.ScreenWidth, this.Game.ScreenHeight - 50);
                if (windowReturnClass.CommandData[index2] == 101)
                  this.Wmiddle = this.AddWindow((WindowClass) new SimpleEditTableWindowClass(ref DrawMod.TGame), 0, 50, this.Game.ScreenWidth, this.Game.ScreenHeight - 50);
                if (windowReturnClass.CommandData[index2] == 96)
                  this.Wmiddle = this.AddWindow((WindowClass) new SimpleLibraryWindowClass(ref DrawMod.TGame), 0, 50, this.Game.ScreenWidth, this.Game.ScreenHeight - 50);
                if (windowReturnClass.CommandData[index2] == 98)
                  this.Wmiddle = this.AddWindow((WindowClass) new SimpleEditMapWindowClass(ref DrawMod.TGame), 0, 50, this.Game.ScreenWidth, 300);
                if (windowReturnClass.CommandData[index2] == 99)
                  this.Wmiddle = this.AddWindow((WindowClass) new SimpleEditUnitWindowClass(ref DrawMod.TGame), 0, 50, this.Game.ScreenWidth, 300);
                if (windowReturnClass.CommandData[index2] == 12)
                  this.wdown = this.AddWindow((WindowClass) new MapWindowClass2(ref DrawMod.TGame, 350, 0), 0, 350, this.Game.ScreenWidth, this.Game.ScreenHeight - 350);
              }
            }
          }
          screenReturnClass.flag = windowReturnClass.Flag;
          return screenReturnClass;
        }
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
      int windowCounter = this.WindowCounter;
      for (int index1 = 0; index1 <= windowCounter; ++index1)
      {
        if (x > this.WindowX[index1] & x < this.WindowX[index1] + this.WindowW[index1] & y > this.WindowY[index1] & y < this.WindowY[index1] + this.WindowH[index1])
        {
          WindowReturnClass windowReturnClass = this.WindowList[index1].HandleMouseMove(x - this.WindowX[index1], y - this.WindowY[index1]);
          this.WindowFlag[index1] = windowReturnClass.Flag;
          if (windowReturnClass.Overlay | this.LastOverlayWindow > 0)
          {
            if (this.LastOverlayWindow > 0 & this.LastOverlayWindow != this.WindowID[index1])
              this.ClearOverlaySpecificWindow(this.LastOverlayWindow);
            if (windowReturnClass.Overlay)
              this.LastOverlayWindow = this.WindowID[index1];
          }
          if (windowReturnClass.Counter > -1)
          {
            int counter = windowReturnClass.Counter;
            for (int index2 = 0; index2 <= counter; ++index2)
            {
              if (windowReturnClass.CommandType[index2] == 4 && windowReturnClass.CommandData[index2] == 29)
              {
                this.WindowList[this.GetNr(this.wup)].DoRefresh();
                this.WindowFlag[this.GetNr(this.wup)] = true;
                screenReturnClass.flag = true;
                return screenReturnClass;
              }
            }
          }
          if (!screenReturnClass.flag)
            screenReturnClass.flag = windowReturnClass.Flag;
          return screenReturnClass;
        }
      }
      if (this.LastOverlayWindow > 0)
      {
        this.ClearOverlaySpecificWindow(this.LastOverlayWindow);
        screenReturnClass.flag = true;
      }
      return screenReturnClass;
    }

    public override ScreenReturnClass HandleKeyPress(int nr)
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      if (this.WindowCounter > -1)
      {
        int windowCounter = this.WindowCounter;
        for (int index1 = 0; index1 <= windowCounter; ++index1)
        {
          WindowReturnClass windowReturnClass2 = this.WindowList[index1].HandleKeyPress(nr);
          if (!this.WindowFlag[index1])
            this.WindowFlag[index1] = windowReturnClass2.Flag;
          if (!screenReturnClass.flag)
            screenReturnClass.flag = windowReturnClass2.Flag;
          if (windowReturnClass2.Counter > -1)
          {
            int counter = windowReturnClass2.Counter;
            for (int index2 = 0; index2 <= counter; ++index2)
            {
              if (windowReturnClass2.CommandType[index2] == 3)
              {
                screenReturnClass.NewScreen = windowReturnClass2.CommandData[index2];
                return screenReturnClass;
              }
              if (windowReturnClass2.CommandType[index2] == 5)
              {
                screenReturnClass.OpenPopUp = true;
                screenReturnClass.NewScreen = windowReturnClass2.CommandData[index2];
                return screenReturnClass;
              }
              if (windowReturnClass2.CommandType[index2] == 6)
              {
                screenReturnClass.ClosePopUp = true;
                screenReturnClass.NewScreen = 0;
                return screenReturnClass;
              }
              if (windowReturnClass2.CommandType[index2] == 1)
              {
                if (windowReturnClass2.CommandData[index2] == 4 | windowReturnClass2.CommandData[index2] == 3 && this.Wmiddle > -1)
                {
                  this.RemoveWindow(this.Wmiddle);
                  this.Wmiddle = -1;
                }
                if (windowReturnClass2.CommandData[index2] == 2 && this.wleft > -1)
                {
                  this.RemoveWindow(this.wleft);
                  this.wleft = -1;
                }
                if (windowReturnClass2.CommandData[index2] == 5 && this.wdown > -1)
                {
                  this.RemoveWindow(this.wdown);
                  this.wdown = -1;
                }
                if (windowReturnClass2.CommandData[index2] == 13 && this.WEditMenu > -1)
                {
                  this.RemoveWindow(this.WEditMenu);
                  this.WEditMenu = -1;
                }
                if (windowReturnClass2.CommandData[index2] == 7 && this.worder > -1)
                {
                  this.RemoveWindow(this.worder);
                  this.worder = -1;
                }
              }
              if (windowReturnClass2.CommandType[index2] == 4)
              {
                if (windowReturnClass2.CommandData[index2] == 94 & this.WEditMenu > -1)
                {
                  this.WindowList[this.GetNr(this.WEditMenu)].DoRefresh();
                  this.WindowFlag[this.GetNr(this.WEditMenu)] = true;
                }
                if ((windowReturnClass2.CommandData[index2] == 20 | windowReturnClass2.CommandData[index2] == 69) & this.Wmiddle > -1)
                {
                  this.WindowList[this.GetNr(this.Wmiddle)].DoRefresh();
                  this.WindowFlag[this.GetNr(this.Wmiddle)] = true;
                }
                if (windowReturnClass2.CommandData[index2] == 12 & this.Wmiddle > -1)
                {
                  this.WindowList[this.GetNr(this.wdown)].DoRefresh();
                  this.WindowFlag[this.GetNr(this.wdown)] = true;
                }
              }
              if (windowReturnClass2.CommandType[index2] == 2)
              {
                if (windowReturnClass2.CommandData[index2] == 94)
                  this.WEditMenu = this.AddWindow((WindowClass) new SimpleEditOptionsWindowClass(ref DrawMod.TGame, this.OwnBackground, 0, 0), 0, 0, this.Game.ScreenWidth, 50);
                if (windowReturnClass2.CommandData[index2] == 95)
                  this.Wmiddle = this.AddWindow((WindowClass) new SimpleEditDashboardWindowClass(ref DrawMod.TGame), 0, 50, this.Game.ScreenWidth, this.Game.ScreenHeight - 50);
                if (windowReturnClass2.CommandData[index2] == 100)
                  this.Wmiddle = this.AddWindow((WindowClass) new SimpleEditRegimeWindowClass(ref DrawMod.TGame), 0, 50, this.Game.ScreenWidth, this.Game.ScreenHeight - 50);
                if (windowReturnClass2.CommandData[index2] == 101)
                  this.Wmiddle = this.AddWindow((WindowClass) new SimpleEditTableWindowClass(ref DrawMod.TGame), 0, 50, this.Game.ScreenWidth, this.Game.ScreenHeight - 50);
                if (windowReturnClass2.CommandData[index2] == 96)
                  this.Wmiddle = this.AddWindow((WindowClass) new SimpleLibraryWindowClass(ref DrawMod.TGame), 0, 50, this.Game.ScreenWidth, this.Game.ScreenHeight - 50);
                if (windowReturnClass2.CommandData[index2] == 98)
                  this.Wmiddle = this.AddWindow((WindowClass) new SimpleEditMapWindowClass(ref DrawMod.TGame), 0, 50, this.Game.ScreenWidth, 300);
                if (windowReturnClass2.CommandData[index2] == 12)
                  this.wdown = this.AddWindow((WindowClass) new MapWindowClass2(ref DrawMod.TGame, 350, 0), 0, 350, this.Game.ScreenWidth, this.Game.ScreenHeight - 350);
                if (windowReturnClass2.CommandData[index2] == 99)
                  this.Wmiddle = this.AddWindow((WindowClass) new SimpleEditUnitWindowClass(ref DrawMod.TGame), 0, 50, this.Game.ScreenWidth, 300);
              }
            }
          }
        }
        screenReturnClass.flag = true;
        return screenReturnClass;
      }
      screenReturnClass.flag = false;
      return screenReturnClass;
    }
  }
}
