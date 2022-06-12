// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.MainEditScreenClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class MainEditScreenClass : ScreenClass
  {
    private int WEditMenu;
    private int Wmiddle;
    private int wdown;
    private int wleft;
    private int worder;
    private int wup;
    private int OffSetX;

    public MainEditScreenClass(ref GameClass tgame, Form1 tformref)
      : base(ref tgame, tgame.BACKGROUND3MARC, tformref)
    {
      this.OffSetX = (int) Math.Round((double) (this.Game.ScreenWidth - 1024) / 2.0);
      this.AllowRightMouse = true;
      if ((double) tgame.Data.RuleVar[839] == 1.0)
      {
        this.wdown = this.AddWindow((WindowClass) new PlayExtraWindowClass2(ref tgame, this.OwnBackground, 0, this.Game.ScreenHeight - 210), 0, this.Game.ScreenHeight - 210, this.Game.ScreenWidth, 222);
        this.wleft = this.AddWindow((WindowClass) new PlayMainWindowClass(ref tgame, 125), this.Game.ScreenWidth - 220, 120, 220, this.Game.ScreenHeight - 370);
        this.WEditMenu = this.AddWindow((WindowClass) new EditOptionsWindowClass(ref tgame, this.OwnBackground, 0, 0), 0, 0, this.Game.ScreenWidth - 220, 100);
        this.Wmiddle = this.AddWindow((WindowClass) new MapWindowClass(ref tgame, 370, 220), 0, 120, this.Game.ScreenWidth - 220, this.Game.ScreenHeight - 370);
        this.worder = this.AddWindow((WindowClass) new OrderWindowClass(ref tgame), 0, this.Game.ScreenHeight - 250, this.Game.ScreenWidth, 40);
        this.wup = this.AddWindow((WindowClass) new InfoWindowClass(ref tgame), 0, 100, this.Game.ScreenWidth, 20);
      }
      else
      {
        this.wdown = this.AddWindow((WindowClass) new PlayExtraWindowClass(ref tgame, this.OwnBackground, 0, this.Game.ScreenHeight - 210), 0, this.Game.ScreenHeight - 210, this.Game.ScreenWidth, 210);
        this.wleft = this.AddWindow((WindowClass) new PlayMainWindowClass(ref tgame, 125), this.Game.ScreenWidth - 220, 120, 220, this.Game.ScreenHeight - 370);
        this.WEditMenu = this.AddWindow((WindowClass) new EditOptionsWindowClass(ref tgame, this.OwnBackground, 0, 0), 0, 0, this.Game.ScreenWidth - 220, 100);
        this.Wmiddle = this.AddWindow((WindowClass) new MapWindowClass(ref tgame, 370, 220), 0, 120, this.Game.ScreenWidth - 220, this.Game.ScreenHeight - 370);
        this.worder = this.AddWindow((WindowClass) new OrderWindowClass(ref tgame), 0, this.Game.ScreenHeight - 250, this.Game.ScreenWidth, 40);
        this.wup = this.AddWindow((WindowClass) new InfoWindowClass(ref tgame), 0, 100, this.Game.ScreenWidth, 20);
      }
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
                if (windowReturnClass.CommandData[index2] == 13)
                {
                  this.RemoveWindow(this.WEditMenu);
                  this.WEditMenu = this.AddWindow((WindowClass) new EditOptionsWindowClass(ref this.Game), 0, 0, this.Game.ScreenWidth, 100);
                }
                if (windowReturnClass.CommandData[index2] == 18 && this.wleft > -1)
                {
                  this.WindowList[this.GetNr(this.wleft)].DoRefresh();
                  this.WindowFlag[this.GetNr(this.wleft)] = true;
                }
                if (windowReturnClass.CommandData[index2] == 20 && this.wdown > -1)
                {
                  this.WindowList[this.GetNr(this.wdown)].DoRefresh();
                  this.WindowFlag[this.GetNr(this.wdown)] = true;
                }
                if (windowReturnClass.CommandData[index2] == 12 && this.Wmiddle > -1)
                {
                  this.WindowList[this.GetNr(this.Wmiddle)].DoRefresh();
                  this.WindowFlag[this.GetNr(this.Wmiddle)] = true;
                }
                if (windowReturnClass.CommandData[index2] == 44 && this.worder > -1)
                {
                  this.WindowList[this.GetNr(this.worder)].DoRefresh();
                  this.WindowFlag[this.GetNr(this.worder)] = true;
                }
              }
              if (windowReturnClass.CommandType[index2] == 2)
              {
                if (windowReturnClass.CommandData[index2] == 11)
                  this.Wmiddle = this.AddWindow((WindowClass) new LandscapeTypeWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass.CommandData[index2] == 12)
                  this.Wmiddle = this.AddWindow((WindowClass) new MapWindowClass(ref this.Game, 370, 220), 0, 120, this.Game.ScreenWidth - 220, this.Game.ScreenHeight - 370);
                if (windowReturnClass.CommandData[index2] == 13)
                  this.WEditMenu = this.AddWindow((WindowClass) new EditOptionsWindowClass(ref this.Game), 0, 0, this.Game.ScreenWidth - 220, 100);
                if (windowReturnClass.CommandData[index2] == 14)
                  this.Wmiddle = this.AddWindow((WindowClass) new RoadTypeWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass.CommandData[index2] == 93)
                  this.Wmiddle = this.AddWindow((WindowClass) new LibraryWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass.CommandData[index2] == 60)
                  this.Wmiddle = this.AddWindow((WindowClass) new StringListWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass.CommandData[index2] == 44)
                  this.worder = this.AddWindow((WindowClass) new OrderWindowClass(ref this.Game), 0, this.Game.ScreenHeight - 250, this.Game.ScreenWidth, 40);
                if (windowReturnClass.CommandData[index2] == 15)
                  this.Wmiddle = this.AddWindow((WindowClass) new RegimeWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass.CommandData[index2] == 16)
                  this.Wmiddle = this.AddWindow((WindowClass) new SFTypeWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass.CommandData[index2] == 17)
                  this.Wmiddle = this.AddWindow((WindowClass) new EditUnitWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass.CommandData[index2] == 86)
                  this.Wmiddle = this.AddWindow((WindowClass) new EditHisWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass.CommandData[index2] == 21)
                  this.Wmiddle = this.AddWindow((WindowClass) new LocTypeWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass.CommandData[index2] == 58)
                  this.Wmiddle = this.AddWindow((WindowClass) new ConnectionWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass.CommandData[index2] == 33)
                  this.Wmiddle = this.AddWindow((WindowClass) new RiverTypeWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass.CommandData[index2] == 57)
                  this.Wmiddle = this.AddWindow((WindowClass) new ActionCardWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass.CommandData[index2] == 34)
                  this.Wmiddle = this.AddWindow((WindowClass) new BridgeWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass.CommandData[index2] == 20)
                  this.wdown = (double) this.Game.Data.RuleVar[839] != 1.0 ? this.AddWindow((WindowClass) new PlayExtraWindowClass(ref DrawMod.TGame, this.OwnBackground, 0, this.Game.ScreenHeight - 210), 0, this.Game.ScreenHeight - 210, this.Game.ScreenWidth, 210) : this.AddWindow((WindowClass) new PlayExtraWindowClass2(ref DrawMod.TGame, this.OwnBackground, 0, this.Game.ScreenHeight - 210), 0, this.Game.ScreenHeight - 210, this.Game.ScreenWidth, 222);
                if (windowReturnClass.CommandData[index2] == 22)
                  this.Wmiddle = this.AddWindow((WindowClass) new PeopleWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass.CommandData[index2] == 18)
                  this.wleft = this.AddWindow((WindowClass) new PlayMainWindowClass(ref this.Game, 125), this.Game.ScreenWidth - 220, 120, 220, this.Game.ScreenHeight - 370);
                if (windowReturnClass.CommandData[index2] == 23)
                  this.Wmiddle = this.AddWindow((WindowClass) new GeneralWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass.CommandData[index2] == 24)
                  this.Wmiddle = this.AddWindow((WindowClass) new ItemTypeWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass.CommandData[index2] == 37)
                  this.Wmiddle = this.AddWindow((WindowClass) new ResearchWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass.CommandData[index2] == 61)
                  this.wdown = this.AddWindow((WindowClass) new OfficerPoolWindowClass(ref this.Game, this.OwnBackground, this.OffSetX, this.Game.ScreenHeight - 200), this.OffSetX, this.Game.ScreenHeight - 200, 1024, 200);
                if (windowReturnClass.CommandData[index2] == 25)
                  this.wdown = this.AddWindow((WindowClass) new ProdWindowClass(ref this.Game, this.OwnBackground, this.OffSetX, this.Game.ScreenHeight - 200), this.OffSetX, this.Game.ScreenHeight - 200, 1000, 200);
                if (windowReturnClass.CommandData[index2] == 45)
                  this.wdown = this.AddWindow((WindowClass) new PrefsWindowClass(ref this.Game, this.OwnBackground, this.OffSetX, this.Game.ScreenHeight - 200), this.OffSetX, this.Game.ScreenHeight - 200, 1000, 200);
                if (windowReturnClass.CommandData[index2] == 28)
                  this.wdown = this.AddWindow((WindowClass) new NewUnitWindowClass(ref this.Game, this.OwnBackground, this.OffSetX, this.Game.ScreenHeight - 200), this.OffSetX, this.Game.ScreenHeight - 200, 1000, 200);
                if (windowReturnClass.CommandData[index2] == 26)
                  this.Wmiddle = this.AddWindow((WindowClass) new LocWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass.CommandData[index2] == 30)
                  this.wdown = this.AddWindow((WindowClass) new TransferWindowClass(ref this.Game), this.OffSetX, this.Game.ScreenHeight - 200, 1000, 200);
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
                if (windowReturnClass2.CommandData[index2] == 13)
                {
                  this.RemoveWindow(this.WEditMenu);
                  this.WEditMenu = this.AddWindow((WindowClass) new EditOptionsWindowClass(ref this.Game), 0, 0, this.Game.ScreenWidth, 100);
                }
                if (windowReturnClass2.CommandData[index2] == 18 && this.wleft > -1)
                {
                  this.WindowList[this.GetNr(this.wleft)].DoRefresh();
                  this.WindowFlag[this.GetNr(this.wleft)] = true;
                }
                if (windowReturnClass2.CommandData[index2] == 20 && this.wdown > -1)
                {
                  this.WindowList[this.GetNr(this.wdown)].DoRefresh();
                  this.WindowFlag[this.GetNr(this.wdown)] = true;
                }
                if (windowReturnClass2.CommandData[index2] == 12 && this.Wmiddle > -1)
                {
                  this.WindowList[this.GetNr(this.Wmiddle)].DoRefresh();
                  this.WindowFlag[this.GetNr(this.Wmiddle)] = true;
                }
                if (windowReturnClass2.CommandData[index2] == 44 && this.worder > -1)
                {
                  this.WindowList[this.GetNr(this.worder)].DoRefresh();
                  this.WindowFlag[this.GetNr(this.worder)] = true;
                }
              }
              if (windowReturnClass2.CommandType[index2] == 2)
              {
                if (windowReturnClass2.CommandData[index2] == 11)
                  this.Wmiddle = this.AddWindow((WindowClass) new LandscapeTypeWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass2.CommandData[index2] == 12)
                  this.Wmiddle = this.AddWindow((WindowClass) new MapWindowClass(ref this.Game, 370, 220), 0, 120, this.Game.ScreenWidth - 220, this.Game.ScreenHeight - 370);
                if (windowReturnClass2.CommandData[index2] == 13)
                  this.WEditMenu = this.AddWindow((WindowClass) new EditOptionsWindowClass(ref this.Game), 0, 0, this.Game.ScreenWidth - 220, 100);
                if (windowReturnClass2.CommandData[index2] == 14)
                  this.Wmiddle = this.AddWindow((WindowClass) new RoadTypeWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass2.CommandData[index2] == 93)
                  this.Wmiddle = this.AddWindow((WindowClass) new LibraryWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass2.CommandData[index2] == 60)
                  this.Wmiddle = this.AddWindow((WindowClass) new StringListWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass2.CommandData[index2] == 44)
                  this.worder = this.AddWindow((WindowClass) new OrderWindowClass(ref this.Game), 0, this.Game.ScreenHeight - 250, this.Game.ScreenWidth, 40);
                if (windowReturnClass2.CommandData[index2] == 15)
                  this.Wmiddle = this.AddWindow((WindowClass) new RegimeWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass2.CommandData[index2] == 16)
                  this.Wmiddle = this.AddWindow((WindowClass) new SFTypeWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass2.CommandData[index2] == 17)
                  this.Wmiddle = this.AddWindow((WindowClass) new EditUnitWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass2.CommandData[index2] == 21)
                  this.Wmiddle = this.AddWindow((WindowClass) new LocTypeWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass2.CommandData[index2] == 58)
                  this.Wmiddle = this.AddWindow((WindowClass) new ConnectionWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass2.CommandData[index2] == 33)
                  this.Wmiddle = this.AddWindow((WindowClass) new RiverTypeWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass2.CommandData[index2] == 57)
                  this.Wmiddle = this.AddWindow((WindowClass) new ActionCardWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass2.CommandData[index2] == 34)
                  this.Wmiddle = this.AddWindow((WindowClass) new BridgeWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass2.CommandData[index2] == 20)
                  this.wdown = (double) this.Game.Data.RuleVar[839] != 1.0 ? this.AddWindow((WindowClass) new PlayExtraWindowClass(ref DrawMod.TGame, this.OwnBackground, 0, this.Game.ScreenHeight - 210), 0, this.Game.ScreenHeight - 210, this.Game.ScreenWidth, 210) : this.AddWindow((WindowClass) new PlayExtraWindowClass2(ref DrawMod.TGame, this.OwnBackground, 0, this.Game.ScreenHeight - 210), 0, this.Game.ScreenHeight - 210, this.Game.ScreenWidth, 222);
                if (windowReturnClass2.CommandData[index2] == 22)
                  this.Wmiddle = this.AddWindow((WindowClass) new PeopleWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass2.CommandData[index2] == 18)
                  this.wleft = this.AddWindow((WindowClass) new PlayMainWindowClass(ref this.Game, 125), this.Game.ScreenWidth - 220, 120, 220, this.Game.ScreenHeight - 370);
                if (windowReturnClass2.CommandData[index2] == 23)
                  this.Wmiddle = this.AddWindow((WindowClass) new GeneralWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass2.CommandData[index2] == 24)
                  this.Wmiddle = this.AddWindow((WindowClass) new ItemTypeWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass2.CommandData[index2] == 37)
                  this.Wmiddle = this.AddWindow((WindowClass) new ResearchWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass2.CommandData[index2] == 61)
                  this.wdown = this.AddWindow((WindowClass) new OfficerPoolWindowClass(ref this.Game, this.OwnBackground, this.OffSetX, this.Game.ScreenHeight - 200), this.OffSetX, this.Game.ScreenHeight - 200, 1024, 200);
                if (windowReturnClass2.CommandData[index2] == 25)
                  this.wdown = this.AddWindow((WindowClass) new ProdWindowClass(ref this.Game, this.OwnBackground, this.OffSetX, this.Game.ScreenHeight - 200), this.OffSetX, this.Game.ScreenHeight - 200, 1000, 200);
                if (windowReturnClass2.CommandData[index2] == 45)
                  this.wdown = this.AddWindow((WindowClass) new PrefsWindowClass(ref this.Game, this.OwnBackground, this.OffSetX, this.Game.ScreenHeight - 200), this.OffSetX, this.Game.ScreenHeight - 200, 1000, 200);
                if (windowReturnClass2.CommandData[index2] == 28)
                  this.wdown = this.AddWindow((WindowClass) new NewUnitWindowClass(ref this.Game, this.OwnBackground, this.OffSetX, this.Game.ScreenHeight - 200), this.OffSetX, this.Game.ScreenHeight - 200, 1000, 200);
                if (windowReturnClass2.CommandData[index2] == 26)
                  this.Wmiddle = this.AddWindow((WindowClass) new LocWindowClass(ref this.Game), 0, 120, this.Game.ScreenWidth, this.Game.ScreenHeight - 120);
                if (windowReturnClass2.CommandData[index2] == 30)
                  this.wdown = this.AddWindow((WindowClass) new TransferWindowClass(ref this.Game), this.OffSetX, this.Game.ScreenHeight - 200, 1000, 200);
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
