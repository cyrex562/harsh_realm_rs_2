// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.MessagePopUpScreenClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class MessagePopUpScreenClass2 : ScreenClass
  {
    private int wtop;
    private int wup;

    public MessagePopUpScreenClass2(ref GameClass tGame, Form1 tformref)
      : base(ref tGame, -4, tformref)
    {
      if (tGame.EditObj.PopupValue == 1)
        this.wup = this.AddWindow((WindowClass) new MapSelectWindowClass2(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 435.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 350.0), 860, 700);
      else if (tGame.EditObj.PopupValue == 2)
        this.wup = this.AddWindow((WindowClass) new HandCardWindowClass2(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 190.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 190.0), 380, 380);
      else if (tGame.EditObj.PopupValue == 3)
        this.wup = this.AddWindow((WindowClass) new UnitSelectWindowClass2(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 505.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 350.0), 1010, 700);
      else if (tGame.EditObj.PopupValue == 4)
        this.wup = this.AddWindow((WindowClass) new OfficerInfoWindowClass2(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 340.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 340.0), 680, 680);
      else if (tGame.EditObj.PopupValue == 5)
        this.wup = this.AddWindow((WindowClass) new SystemMessageWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 300.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 100.0), 600, 200);
      else if (tGame.EditObj.PopupValue == 6)
      {
        if ((double) this.Game.Data.RuleVar[460] > 0.0)
          this.wup = this.AddWindow((WindowClass) new SFWindowClass3(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 440.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 384.0), 880, 768);
        else
          this.wup = this.AddWindow((WindowClass) new SFWindowClass2(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 440.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 340.0), 880, 580);
      }
      else if (tGame.EditObj.PopupValue == 7)
      {
        int num1 = Math.Max(1280, this.Game.ScreenWidth - 400);
        int num2 = Math.Max(768, this.Game.ScreenHeight - 200);
        this.wup = this.AddWindow((WindowClass) new CombatResultWindowClass2(ref tGame, num1, num2), (int) Math.Round((double) (this.Game.ScreenWidth - num1) / 2.0), (int) Math.Round((double) (this.Game.ScreenHeight - num2) / 2.0), num1, num2);
      }
      else if (tGame.EditObj.PopupValue == 8)
      {
        int num3 = Math.Min(1324, this.Game.ScreenWidth);
        int num4 = Math.Min(968, this.Game.ScreenHeight);
        int x = (int) Math.Round(Conversion.Int((double) (this.Game.ScreenWidth - num3) / 2.0));
        int y = (int) Math.Round(Conversion.Int((double) (this.Game.ScreenHeight - num4) / 2.0));
        this.wup = this.AddWindow((WindowClass) new CombatDetailWindowClass(ref tGame, 0, num3, num4), x, y, num3, num4);
      }
      else if (tGame.EditObj.PopupValue == 9)
        this.wup = this.AddWindow((WindowClass) new CreditsInfoWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 440.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 340.0), 880, 680);
      else if (tGame.EditObj.PopupValue == 10)
        this.wup = this.AddWindow((WindowClass) new FlexMessageWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 300.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 100.0), 600, 200);
      else if (tGame.EditObj.PopupValue == 11)
        this.wup = this.AddWindow((WindowClass) new AirSelectWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 440.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 290.0), 880, 580);
      else if (tGame.EditObj.PopupValue == 12)
        this.wup = this.AddWindow((WindowClass) new ArtSelectWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 340.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 190.0), 680, 380);
      else if (tGame.EditObj.PopupValue == 14)
        this.wup = this.AddWindow((WindowClass) new RegisterPopup(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 300.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 240.0), 600, 480);
      else if (tGame.EditObj.PopupValue == 15)
        this.wup = this.AddWindow((WindowClass) new ServerPopup(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 300.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 200.0), 600, 400);
      else if (tGame.EditObj.PopupValue == 16)
        this.wup = this.AddWindow((WindowClass) new LoginPopup(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 300.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 240.0), 600, 480);
      else if (tGame.EditObj.PopupValue == 17)
        this.wup = this.AddWindow((WindowClass) new LoadWindow(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 200.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 120.0), 400, 240);
      else if (tGame.EditObj.PopupValue == 18)
        this.wup = this.AddWindow((WindowClass) new LandSelectWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 340.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 190.0), 680, 380);
      else if (tGame.EditObj.PopupValue == 19)
        this.wup = this.AddWindow((WindowClass) new BigMessageWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 480.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 375.0), 960, 750);
      else if (tGame.EditObj.PopupValue == 20)
        this.wup = this.AddWindow((WindowClass) new SimplePrefsWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 240.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 125.0), 480, 250);
      else if (tGame.EditObj.PopupValue == 21)
      {
        int extraHeight = (int) Math.Round((double) (this.Game.ScreenHeight - 750) / 2.0);
        if (extraHeight > 120)
          extraHeight = 120;
        if (Strings.InStr(Strings.LCase(this.Game.EditObj.UDSpopupText), "[key]nobackground[/key]") < 1)
          this.wup = this.AddWindow((WindowClass) new UDSMessageWindowClass(ref tGame, extraHeight), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 630.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - (double) (375 + (int) Math.Round((double) extraHeight / 2.0))), 1260, 750 + extraHeight);
        else
          this.wup = this.AddWindow((WindowClass) new UDSMessageWindowClass(ref tGame, true, extraHeight), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 630.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - (double) (375 + (int) Math.Round((double) extraHeight / 2.0))), 1260, 750 + extraHeight);
      }
      else if (tGame.EditObj.PopupValue == 22)
        this.wup = this.AddWindow((WindowClass) new CombatSelectWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 640.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 384.0), 1280, 768);
      else if (tGame.EditObj.PopupValue == 23)
      {
        int num = Math.Max((int) Math.Round((double) this.Game.ScreenHeight * 0.9), 768);
        if (num > 1280)
          num = 1280;
        this.wup = this.AddWindow((WindowClass) new SpecialWindowClass1(ref tGame, 1280, num), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 640.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - (double) (int) Math.Round((double) num / 2.0)), 1280, num);
      }
      else if (tGame.EditObj.PopupValue == 24)
      {
        int num5 = Math.Max((int) Math.Round((double) this.Game.ScreenHeight * 0.9), 768);
        if (num5 > 1280)
          num5 = 1280;
        int num6 = Math.Max((int) Math.Round((double) this.Game.ScreenWidth * 0.9), 1280);
        if (num6 > 1920)
          num6 = 1920;
        this.wup = this.AddWindow((WindowClass) new SpecialWindowClass2(ref tGame, num6, num5), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - (double) (int) Math.Round((double) num6 / 2.0)), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - (double) (int) Math.Round((double) num5 / 2.0)), num6, num5);
      }
      else if (tGame.EditObj.PopupValue == 25)
      {
        int num7 = Math.Max((int) Math.Round((double) this.Game.ScreenHeight * 0.9), 768);
        if (num7 > 1280)
          num7 = 1280;
        int num8 = Math.Max((int) Math.Round((double) this.Game.ScreenWidth * 0.9), 1280);
        if (num8 > 1920)
          num8 = 1920;
        this.wup = this.AddWindow((WindowClass) new SpecialWindowClass3(ref tGame, num8, num7), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - (double) (int) Math.Round((double) num8 / 2.0)), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - (double) (int) Math.Round((double) num7 / 2.0)), num8, num7);
      }
      else if (tGame.EditObj.PopupValue == 26)
        this.wup = this.AddWindow((WindowClass) new TransportWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 500.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 380.0), 1000, 760);
      else if (tGame.EditObj.PopupValue == 27)
        this.wup = this.AddWindow((WindowClass) new BattlegroupWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 500.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 380.0), 1000, 760);
      else if (tGame.EditObj.PopupValue == 28)
        this.wup = this.AddWindow((WindowClass) new LISTrafficWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 600.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 384.0), 1200, 768);
      else if (tGame.EditObj.PopupValue == 29)
        this.wup = this.AddWindow((WindowClass) new FlexCardWindowClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 200.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 200.0), 400, 400);
      else if (tGame.EditObj.PopupValue == 30)
        this.wup = this.AddWindow((WindowClass) new NonCardSelectWindowClass(ref tGame, SelectUsageMode.joinAttack), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 640.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 384.0), 1280, 768);
      else if (tGame.EditObj.PopupValue == 31)
        this.wup = this.AddWindow((WindowClass) new NonCardSelectWindowClass(ref tGame, SelectUsageMode.selectHQ), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 640.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 384.0), 1280, 768);
      else if (tGame.EditObj.PopupValue == 32)
        this.wup = this.AddWindow((WindowClass) new NonCardSelectWindowClass(ref tGame, SelectUsageMode.blowBridge), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 640.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 384.0), 1280, 768);
      else if (tGame.EditObj.PopupValue == 33)
        this.wup = this.AddWindow((WindowClass) new NonCardSelectWindowClass(ref tGame, SelectUsageMode.repairBridge), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 640.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 384.0), 1280, 768);
      else if (tGame.EditObj.PopupValue == 34)
        this.wup = this.AddWindow((WindowClass) new ModLibraryPickerClass(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 500.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 350.0), 1000, 700);
      else if (tGame.EditObj.PopupValue == 35)
      {
        this.wup = this.AddWindow((WindowClass) new NonCardSelectWindowClass(ref tGame, SelectUsageMode.autoMove), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 640.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 384.0), 1280, 768);
      }
      else
      {
        if (tGame.EditObj.PopupValue != 0)
          return;
        this.wup = this.AddWindow((WindowClass) new MessageWindowClass2(ref tGame), (int) Math.Round((double) tGame.ScreenWidth / 2.0 - 340.0), (int) Math.Round((double) tGame.ScreenHeight / 2.0 - 290.0), 680, 480);
      }
    }

    public override ScreenReturnClass HandleMouseClick(int x, int y, int b)
    {
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      bool flag = false;
      if (this.Game.Data.Product == 6)
      {
        if (Operators.CompareString(this.GetType().FullName, "WindowsApplication1.PlayScreenClass2", false) == 0)
          flag = true;
        if (Operators.CompareString(this.GetType().FullName, "WindowsApplication1.MessagePopUpScreenClass2", false) == 0)
          flag = true;
      }
      if (!flag && x > this.Game.ScreenWidth - 52 & x < this.Game.ScreenWidth - 28 & y < 25)
        this.Game.FormRef.WindowState = FormWindowState.Minimized;
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      int windowCounter = this.WindowCounter;
      for (int index1 = 0; index1 <= windowCounter; ++index1)
      {
        if (Conversions.ToBoolean(Operators.OrObject((object) (x > this.WindowX[index1] & x < this.WindowX[index1] + this.WindowW[index1]), Operators.CompareObjectEqual(this.WindowList[index1].allowClickOutsideWindow(), (object) true, false))) && Conversions.ToBoolean(Operators.OrObject((object) (y > this.WindowY[index1] & y < this.WindowY[index1] + this.WindowH[index1]), this.WindowList[index1].allowClickOutsideWindow())))
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
