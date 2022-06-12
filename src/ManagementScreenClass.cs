// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ManagementScreenClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class ManagementScreenClass : ScreenClass
  {
    private int WMap;
    private int WRes;
    private int OffSetX;

    public ManagementScreenClass(ref GameClass tgame, Form1 tformref)
      : base(ref tgame, -3, tformref)
    {
      this.OffSetX = (int) Math.Round((double) (this.Game.ScreenWidth - 1280) / 2.0);
      this.Game.HandyFunctionsObj.SetGameColors();
      Rectangle rectangle1;
      if (this.Game.EditObj.se1_ManagementTab <= 51)
      {
        SpecialWindowClass1 tmpWindow = new SpecialWindowClass1(ref tgame, this.Game.ScreenWidth, this.Game.ScreenHeight);
        int screenWidth = this.Game.ScreenWidth;
        int screenHeight = this.Game.ScreenHeight;
        rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, this.Game.ScreenHeight);
        Rectangle tShowRectangle = rectangle1;
        this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, screenHeight, tShowRectangle);
      }
      if (this.Game.EditObj.se1_ManagementTab == 52)
      {
        SpecialWindowClass2 tmpWindow = new SpecialWindowClass2(ref tgame, this.Game.ScreenWidth, this.Game.ScreenHeight);
        int screenWidth = this.Game.ScreenWidth;
        int screenHeight = this.Game.ScreenHeight;
        rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, this.Game.ScreenHeight);
        Rectangle tShowRectangle = rectangle1;
        this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, screenHeight, tShowRectangle);
      }
      if (this.Game.EditObj.se1_ManagementTab == 53)
      {
        SpecialWindowClass3 tmpWindow = new SpecialWindowClass3(ref tgame, this.Game.ScreenWidth, this.Game.ScreenHeight);
        int screenWidth = this.Game.ScreenWidth;
        int screenHeight = this.Game.ScreenHeight;
        rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, this.Game.ScreenHeight);
        Rectangle tShowRectangle = rectangle1;
        this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, screenHeight, tShowRectangle);
      }
      if (this.Game.EditObj.se1_ManagementTab == 54)
      {
        SpecialWindowClass4 tmpWindow = new SpecialWindowClass4(ref tgame, this.Game.ScreenWidth, this.Game.ScreenHeight);
        int screenWidth = this.Game.ScreenWidth;
        int screenHeight = this.Game.ScreenHeight;
        rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, this.Game.ScreenHeight);
        Rectangle tShowRectangle = rectangle1;
        this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, screenHeight, tShowRectangle);
      }
      if (this.Game.EditObj.se1_ManagementTab == 55)
      {
        SpecialWindowClass5 tmpWindow = new SpecialWindowClass5(ref tgame, this.Game.ScreenWidth, this.Game.ScreenHeight);
        int screenWidth = this.Game.ScreenWidth;
        int screenHeight = this.Game.ScreenHeight;
        rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, this.Game.ScreenHeight);
        Rectangle tShowRectangle = rectangle1;
        this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, screenHeight, tShowRectangle);
      }
      if (this.Game.EditObj.se1_ManagementTab == 56)
      {
        SpecialWindowClass6 tmpWindow = new SpecialWindowClass6(ref tgame, this.Game.ScreenWidth, this.Game.ScreenHeight);
        int screenWidth = this.Game.ScreenWidth;
        int screenHeight = this.Game.ScreenHeight;
        rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, this.Game.ScreenHeight);
        Rectangle tShowRectangle = rectangle1;
        this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, screenHeight, tShowRectangle);
      }
      if (this.Game.EditObj.se1_ManagementTab == 57)
      {
        SpecialWindowClass7 tmpWindow = new SpecialWindowClass7(ref tgame, this.Game.ScreenWidth, this.Game.ScreenHeight);
        int screenWidth = this.Game.ScreenWidth;
        int screenHeight = this.Game.ScreenHeight;
        rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, this.Game.ScreenHeight);
        Rectangle tShowRectangle = rectangle1;
        this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, screenHeight, tShowRectangle);
      }
      ref GameClass local1 = ref tgame;
      ref WindowClass local2 = ref this.WindowList[this.GetNr(this.WMap)];
      rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, 75);
      Rectangle rectangle2 = rectangle1;
      ref Rectangle local3 = ref rectangle2;
      this.WRes = this.AddWindow((WindowClass) new ResourceWindowClass2(ref local1, ref local2, ref local3), 0, 0, this.Game.ScreenWidth, 75);
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
            if (wr.CommandData[index] == 12)
            {
              this.WindowList[this.GetNr(this.WMap)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WMap)] = true;
            }
            if (wr.CommandData[index] == 67)
            {
              this.WindowList[this.GetNr(this.WRes)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WRes)] = true;
            }
          }
          if (wr.CommandType[index] == 7)
          {
            if (wr.CommandData[index] == 12)
              this.WindowFlag[this.GetNr(this.WMap)] = true;
            if (wr.CommandData[index] == 67)
              this.WindowFlag[this.GetNr(this.WRes)] = true;
          }
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
          }
          if (wr.CommandType[index] == 2)
          {
            Rectangle rectangle1;
            if (wr.CommandData[index] == 12)
            {
              if (this.Game.EditObj.se1_ManagementTab <= 51)
              {
                SpecialWindowClass1 tmpWindow = new SpecialWindowClass1(ref DrawMod.TGame, this.Game.ScreenWidth, this.Game.ScreenHeight);
                int screenWidth = this.Game.ScreenWidth;
                int screenHeight = this.Game.ScreenHeight;
                rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, this.Game.ScreenHeight);
                Rectangle tShowRectangle = rectangle1;
                this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, screenHeight, tShowRectangle);
              }
              if (this.Game.EditObj.se1_ManagementTab == 52)
              {
                SpecialWindowClass2 tmpWindow = new SpecialWindowClass2(ref DrawMod.TGame, this.Game.ScreenWidth, this.Game.ScreenHeight);
                int screenWidth = this.Game.ScreenWidth;
                int screenHeight = this.Game.ScreenHeight;
                rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, this.Game.ScreenHeight);
                Rectangle tShowRectangle = rectangle1;
                this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, screenHeight, tShowRectangle);
              }
              if (this.Game.EditObj.se1_ManagementTab == 53)
              {
                SpecialWindowClass3 tmpWindow = new SpecialWindowClass3(ref DrawMod.TGame, this.Game.ScreenWidth, this.Game.ScreenHeight);
                int screenWidth = this.Game.ScreenWidth;
                int screenHeight = this.Game.ScreenHeight;
                rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, this.Game.ScreenHeight);
                Rectangle tShowRectangle = rectangle1;
                this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, screenHeight, tShowRectangle);
              }
              if (this.Game.EditObj.se1_ManagementTab == 54)
              {
                SpecialWindowClass4 tmpWindow = new SpecialWindowClass4(ref DrawMod.TGame, this.Game.ScreenWidth, this.Game.ScreenHeight);
                int screenWidth = this.Game.ScreenWidth;
                int screenHeight = this.Game.ScreenHeight;
                rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, this.Game.ScreenHeight);
                Rectangle tShowRectangle = rectangle1;
                this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, screenHeight, tShowRectangle);
              }
              if (this.Game.EditObj.se1_ManagementTab == 55)
              {
                SpecialWindowClass5 tmpWindow = new SpecialWindowClass5(ref DrawMod.TGame, this.Game.ScreenWidth, this.Game.ScreenHeight);
                int screenWidth = this.Game.ScreenWidth;
                int screenHeight = this.Game.ScreenHeight;
                rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, this.Game.ScreenHeight);
                Rectangle tShowRectangle = rectangle1;
                this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, screenHeight, tShowRectangle);
              }
              if (this.Game.EditObj.se1_ManagementTab == 56)
              {
                SpecialWindowClass6 tmpWindow = new SpecialWindowClass6(ref DrawMod.TGame, this.Game.ScreenWidth, this.Game.ScreenHeight);
                int screenWidth = this.Game.ScreenWidth;
                int screenHeight = this.Game.ScreenHeight;
                rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, this.Game.ScreenHeight);
                Rectangle tShowRectangle = rectangle1;
                this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, screenHeight, tShowRectangle);
              }
              if (this.Game.EditObj.se1_ManagementTab == 57)
              {
                SpecialWindowClass7 tmpWindow = new SpecialWindowClass7(ref DrawMod.TGame, this.Game.ScreenWidth, this.Game.ScreenHeight);
                int screenWidth = this.Game.ScreenWidth;
                int screenHeight = this.Game.ScreenHeight;
                rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, this.Game.ScreenHeight);
                Rectangle tShowRectangle = rectangle1;
                this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, screenHeight, tShowRectangle);
              }
            }
            if (wr.CommandData[index] == 67)
            {
              ref GameClass local1 = ref DrawMod.TGame;
              ref WindowClass local2 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, 75);
              Rectangle rectangle2 = rectangle1;
              ref Rectangle local3 = ref rectangle2;
              this.WRes = this.AddWindow((WindowClass) new ResourceWindowClass2(ref local1, ref local2, ref local3), 0, 0, this.Game.ScreenWidth, 75);
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
      if (this.WindowCounter > -1)
      {
        for (int windowCounter = this.WindowCounter; windowCounter >= 0; windowCounter += -1)
        {
          if (Strings.InStr(this.WindowList[windowCounter].GetType().FullName, "WindowsApplication1.Special") > 0 && x > this.WindowX[windowCounter] & x < this.WindowX[windowCounter] + this.WindowW[windowCounter] && y > this.WindowY[windowCounter] & y < this.WindowY[windowCounter] + this.WindowH[windowCounter])
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
          if (Strings.InStr(this.WindowList[windowCounter].GetType().FullName, "WindowsApplication1.Special") <= 0 && x > this.WindowX[windowCounter] & x < this.WindowX[windowCounter] + this.WindowW[windowCounter] && y > this.WindowY[windowCounter] & y < this.WindowY[windowCounter] + this.WindowH[windowCounter])
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
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      int windowCounter = this.WindowCounter;
      for (int index = 0; index <= windowCounter; ++index)
      {
        this.WindowList[index].MouseInThisWindow = false;
        if (x >= this.WindowX[index] & x < this.WindowX[index] + this.WindowW[index] && y >= this.WindowY[index] & y < this.WindowY[index] + this.WindowH[index])
          this.WindowList[index].MouseInThisWindow = true;
        WindowReturnClass windowReturnClass = this.WindowList[index].HandleMouseMove(x - this.WindowX[index], y - this.WindowY[index]);
        this.WindowFlag[index] = windowReturnClass.Flag;
        if (windowReturnClass.Overlay | this.LastOverlayWindow > 0)
        {
          if (this.LastOverlayWindow > 0 & this.LastOverlayWindow != this.WindowID[index])
            this.ClearOverlaySpecificWindow(this.LastOverlayWindow);
          if (this.LastOverlayWindow > 0 & !windowReturnClass.Overlay)
            this.LastOverlayWindow = 0;
          if (windowReturnClass.Overlay)
            this.LastOverlayWindow = this.WindowID[index];
          screenReturnClass.flag = true;
          return screenReturnClass;
        }
        if (windowReturnClass.Flag)
        {
          screenReturnClass.flag = windowReturnClass.Flag;
          return screenReturnClass;
        }
      }
      if (this.LastOverlayWindow > 0)
      {
        this.ClearOverlaySpecificWindow(this.LastOverlayWindow);
        screenReturnClass.flag = true;
      }
      else
        screenReturnClass.flag = false;
      if (this.Game.Data.Product < 7)
      {
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
      }
      else if (Operators.CompareString(this.GetType().FullName, "WindowsApplication1.RandomScreenClass2", false) == 0 | Operators.CompareString(this.GetType().FullName, "WindowsApplication1.GameLoopMainWindowClass2", false) == 0)
      {
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
      }
      return screenReturnClass;
    }

    public override ScreenReturnClass HandleTimer()
    {
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
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
          this.HandleWR(wr, false, ref screenReturnClass);
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
