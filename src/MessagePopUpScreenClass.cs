// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.MessagePopUpScreenClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class MessagePopUpScreenClass : ScreenClass
  {
    private int wtop;
    private int wup;

    public MessagePopUpScreenClass(ref GameClass tGame, Form1 tformref)
      : base(ref tGame, -4, tformref)
    {
      if ((double) this.Game.Data.RuleVar[839] == 1.0 | Operators.CompareString(tformref.Screeny.GetType().ToString(), "WindowsApplication1.FirstScreenClass", false) == 0 & this.Game.ModIntroType == 1)
      {
        if (tGame.EditObj.PopupValue == 1)
          this.wup = this.AddWindow((WindowClass) new MapSelectWindowClass2(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 435.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 350.0), 860, 700);
        else if (tGame.EditObj.PopupValue == 2)
          this.wup = this.AddWindow((WindowClass) new HandCardWindowClass2(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 190.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 190.0), 380, 380);
        else if (tGame.EditObj.PopupValue == 3)
          this.wup = this.AddWindow((WindowClass) new UnitSelectWindowClass2(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 435.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 350.0), 860, 700);
        else if (tGame.EditObj.PopupValue == 4)
          this.wup = this.AddWindow((WindowClass) new OfficerInfoWindowClass2(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 340.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 190.0), 680, 380);
        else if (tGame.EditObj.PopupValue == 5)
          this.wup = this.AddWindow((WindowClass) new SystemMessageWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 300.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 100.0), 600, 200);
        else if (tGame.EditObj.PopupValue == 6)
          this.wup = this.AddWindow((WindowClass) new SFWindowClass2(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 440.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 340.0), 880, 580);
        else if (tGame.EditObj.PopupValue == 7)
        {
          int ucounter = tGame.TempCombat.UCounter;
          int val1;
          int val2;
          for (int index = 0; index <= ucounter; ++index)
          {
            if (this.Game.TempCombat.UList[index].Uattacker == 1)
              ++val1;
            if (this.Game.TempCombat.UList[index].Uattacker == 0)
              ++val2;
          }
          int num = 180 + Math.Max(val1, val2) * 37 + 10;
          this.wup = this.AddWindow((WindowClass) new CombatResultWindowClass2(ref tGame, num), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 505.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - (double) num / 2.0), 1010, num);
        }
        else if (tGame.EditObj.PopupValue == 8)
        {
          int num1 = (int) Math.Round(Conversion.Int((double) this.Game.ScreenWidth / 2.0));
          int num2 = (int) Math.Round(Conversion.Int((double) this.Game.ScreenHeight / 2.0));
          this.wup = this.AddWindow((WindowClass) new CombatDetailWindowClass(ref tGame, 0, this.Game.ScreenWidth, this.Game.ScreenHeight), 0, 0, this.Game.ScreenWidth, this.Game.ScreenHeight);
        }
        else if (tGame.EditObj.PopupValue == 9)
          this.wup = this.AddWindow((WindowClass) new CreditsInfoWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 440.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 340.0), 880, 680);
        else if (tGame.EditObj.PopupValue == 10)
          this.wup = this.AddWindow((WindowClass) new FlexMessageWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 300.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 100.0), 600, 200);
        else if (tGame.EditObj.PopupValue == 11)
          this.wup = this.AddWindow((WindowClass) new AirSelectWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 340.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 190.0), 680, 380);
        else if (tGame.EditObj.PopupValue == 16)
          this.wup = this.AddWindow((WindowClass) new EditorPaintWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 512.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 384.0), 1024, 768);
        else if (tGame.EditObj.PopupValue == 17)
          this.wup = this.AddWindow((WindowClass) new SimpleLibImportWindow(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 512.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 384.0), 1024, 768);
        else if (tGame.EditObj.PopupValue == 18)
          this.wup = this.AddWindow((WindowClass) new SimpleMapImportWindow(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 512.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 384.0), 1024, 768);
        else if (tGame.EditObj.PopupValue == 19)
        {
          this.wup = this.AddWindow((WindowClass) new LoadWindow(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 200.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 120.0), 400, 240);
        }
        else
        {
          if (tGame.EditObj.PopupValue != 0)
            return;
          this.wup = this.AddWindow((WindowClass) new MessageWindowClass2(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 340.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 290.0), 680, 480);
        }
      }
      else if (tGame.EditObj.PopupValue == 1)
        this.wup = this.AddWindow((WindowClass) new MapSelectWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 512.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 384.0), 1024, 768);
      else if (tGame.EditObj.PopupValue == 2)
        this.wup = this.AddWindow((WindowClass) new HandCardWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 405.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 305.0), 810, 610);
      else if (tGame.EditObj.PopupValue == 3)
        this.wup = this.AddWindow((WindowClass) new UnitSelectWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 512.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 384.0), 1024, 768);
      else if (tGame.EditObj.PopupValue == 4)
        this.wup = this.AddWindow((WindowClass) new OfficerInfoWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 405.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 305.0), 810, 610);
      else if (tGame.EditObj.PopupValue == 6)
        this.wup = this.AddWindow((WindowClass) new SFWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 512.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 384.0), 1024, 768);
      else if (tGame.EditObj.PopupValue == 9)
        this.wup = this.AddWindow((WindowClass) new ATCreditsInfoWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 440.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 340.0), 880, 680);
      else if (tGame.EditObj.PopupValue == 10)
        this.wup = this.AddWindow((WindowClass) new ATFlexMessageWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 400.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 100.0), 800, 200);
      else if (tGame.EditObj.PopupValue == 12)
        this.wup = this.AddWindow((WindowClass) new LTWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 512.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 384.0), 1024, 768);
      else if (tGame.EditObj.PopupValue == 13)
        this.wup = this.AddWindow((WindowClass) new PPLWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 512.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 384.0), 1024, 768);
      else if (tGame.EditObj.PopupValue == 14)
        this.wup = this.AddWindow((WindowClass) new OldResearchWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 512.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 384.0), 1024, 768);
      else if (tGame.EditObj.PopupValue == 15)
        this.wup = this.AddWindow((WindowClass) new StatsWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 512.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 384.0), 1024, 768);
      else if (tGame.EditObj.PopupValue == 16)
        this.wup = this.AddWindow((WindowClass) new EditorPaintWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 512.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 384.0), 1024, 768);
      else if (tGame.EditObj.PopupValue == 17)
        this.wup = this.AddWindow((WindowClass) new SimpleLibImportWindow(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 512.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 384.0), 1024, 768);
      else if (tGame.EditObj.PopupValue == 18)
        this.wup = this.AddWindow((WindowClass) new SimpleMapImportWindow(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 512.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 384.0), 1024, 768);
      else if (tGame.EditObj.PopupValue == 19)
      {
        this.wup = this.AddWindow((WindowClass) new LoadWindow(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 200.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 120.0), 400, 240);
      }
      else
      {
        if (this.Game.Data.Turn <= -1)
          return;
        if (tGame.Data.RegimeObj[tGame.Data.Turn].MesStyle[tGame.EditObj.FromMessage] == 0)
        {
          if (tGame.EditObj.PopupValue != 0)
            return;
          this.wup = this.AddWindow((WindowClass) new MessageWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 405.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 305.0), 810, 610);
        }
        else
        {
          if (tGame.EditObj.PopupValue != 0)
            return;
          this.wup = this.AddWindow((WindowClass) new MessageWindowClass(ref tGame, 1), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 405.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 305.0), 810, 610);
        }
      }
    }

    public override ScreenReturnClass HandleTimer()
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      bool flag = false;
      int windowCounter = this.WindowCounter;
      for (int index1 = 0; index1 <= windowCounter; ++index1)
      {
        WindowReturnClass windowReturnClass2 = this.WindowList[index1].handleTimer();
        this.WindowFlag[index1] = windowReturnClass2.Flag;
        if (this.WindowFlag[index1])
          flag = true;
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
            if (windowReturnClass2.CommandType[index2] == 6)
            {
              screenReturnClass.NewScreen = windowReturnClass2.CommandData[index2];
              screenReturnClass.ClosePopUp = true;
              return screenReturnClass;
            }
            if (windowReturnClass2.CommandType[index2] == 5)
            {
              screenReturnClass.NewScreen = windowReturnClass2.CommandData[index2];
              screenReturnClass.OpenPopUp = true;
              return screenReturnClass;
            }
          }
        }
      }
      screenReturnClass.flag = flag;
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
        this.Game.EditObj.ShowInitialMenu = true;
        screenReturnClass.NewScreen = 1;
        screenReturnClass.ClosePopUp = true;
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
              if (windowReturnClass.CommandType[index2] == 6)
              {
                screenReturnClass.NewScreen = windowReturnClass.CommandData[index2];
                screenReturnClass.ClosePopUp = true;
                return screenReturnClass;
              }
              if (windowReturnClass.CommandType[index2] == 5)
              {
                screenReturnClass.NewScreen = windowReturnClass.CommandData[index2];
                screenReturnClass.OpenPopUp = true;
                return screenReturnClass;
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

    public override ScreenReturnClass HandleKeyPress(int nr)
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      for (int windowCounter = this.WindowCounter; windowCounter >= 0; windowCounter += -1)
      {
        WindowReturnClass windowReturnClass2 = this.WindowList[windowCounter].HandleKeyPress(nr);
        if (!this.WindowFlag[windowCounter])
          this.WindowFlag[windowCounter] = windowReturnClass2.Flag;
        if (windowReturnClass2.Counter > -1)
        {
          int counter = windowReturnClass2.Counter;
          for (int index = 0; index <= counter; ++index)
          {
            if (windowReturnClass2.CommandType[index] == 3)
            {
              screenReturnClass.NewScreen = windowReturnClass2.CommandData[index];
              return screenReturnClass;
            }
            if (windowReturnClass2.CommandType[index] == 6)
            {
              screenReturnClass.NewScreen = windowReturnClass2.CommandData[index];
              screenReturnClass.ClosePopUp = true;
              return screenReturnClass;
            }
            if (windowReturnClass2.CommandType[index] == 5)
            {
              screenReturnClass.NewScreen = windowReturnClass2.CommandData[index];
              screenReturnClass.OpenPopUp = true;
              return screenReturnClass;
            }
          }
        }
      }
      screenReturnClass.flag = true;
      return screenReturnClass;
    }

    public override ScreenReturnClass HandleKeyup(int nr)
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      for (int windowCounter = this.WindowCounter; windowCounter >= 0; windowCounter += -1)
      {
        WindowReturnClass windowReturnClass2 = this.WindowList[windowCounter].HandleKeyup(nr);
        if (!this.WindowFlag[windowCounter])
          this.WindowFlag[windowCounter] = windowReturnClass2.Flag;
        if (windowReturnClass2.Counter > -1)
        {
          int counter = windowReturnClass2.Counter;
          for (int index = 0; index <= counter; ++index)
          {
            if (windowReturnClass2.CommandType[index] == 3)
            {
              screenReturnClass.NewScreen = windowReturnClass2.CommandData[index];
              return screenReturnClass;
            }
            if (windowReturnClass2.CommandType[index] == 6)
            {
              screenReturnClass.NewScreen = windowReturnClass2.CommandData[index];
              screenReturnClass.ClosePopUp = true;
              return screenReturnClass;
            }
            if (windowReturnClass2.CommandType[index] == 5)
            {
              screenReturnClass.NewScreen = windowReturnClass2.CommandData[index];
              screenReturnClass.OpenPopUp = true;
              return screenReturnClass;
            }
          }
        }
      }
      screenReturnClass.flag = true;
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
        if (x > this.WindowX[index1] & x < this.WindowX[index1] + this.WindowW[index1] && y > this.WindowY[index1] & y < this.WindowY[index1] + this.WindowH[index1])
        {
          WindowReturnClass windowReturnClass = this.WindowList[index1].HandleMouseMove(x - this.WindowX[index1], y - this.WindowY[index1]);
          this.WindowFlag[index1] = windowReturnClass.Flag;
          if (windowReturnClass.Overlay)
          {
            if (this.LastOverlayWindow > 0 & this.LastOverlayWindow != this.WindowID[index1])
              this.ClearOverlaySpecificWindow(this.LastOverlayWindow);
            this.LastOverlayWindow = this.WindowID[index1];
          }
          if (windowReturnClass.Counter > -1)
          {
            int counter = windowReturnClass.Counter;
            for (int index2 = 0; index2 <= counter; ++index2)
            {
              if (windowReturnClass.CommandType[index2] != 4 || windowReturnClass.CommandData[index2] != 29)
                ;
            }
          }
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
  }
}
