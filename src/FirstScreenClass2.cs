﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.FirstScreenClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class FirstScreenClass2 : ScreenClass
  {
    public int wTop;

    public FirstScreenClass2(ref GameClass tGame, Form1 tformref, bool AsMarc)
      : base(ref tGame, tGame.BACKGROUND5MARC, tformref)
    {
      this.Game.HandyFunctionsObj.SetGameColors();
      if (this.Game.EditObj.PbemGameSetup == PbemGameSetupPhase.TurnPlayed)
      {
        BitmapStore.ReloadSomeGfx();
        BitmapStore.ReloadSystemGraphics(this.Game.ModSystemGraphicsDirectory);
        this.RefreshOwnBackground(tGame.BACKGROUND5MARC);
        this.Game.HandyFunctionsObj.SetGameColors();
        this.wTop = this.AddWindow((WindowClass) new CorePbemWindowClass(ref this.Game), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenWidth - 1024) / 2.0)), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenHeight - 768) / 2.0)), 1024, 768);
      }
      else if (!this.Game.EditObj.ShownWelcome)
      {
        int x = (int) Math.Round(Conversion.Int((double) (tGame.ScreenWidth - 1024) / 2.0));
        int y = (int) Math.Round(Conversion.Int((double) (tGame.ScreenHeight - 768) / 2.0));
        this.wTop = this.AddWindow((WindowClass) new WelcomeWindowClass2(ref tGame, true, (ScreenClass) this, true), x, y, 1024, 768);
      }
      else if (this.Game.EditObj.ShowInitialMenu)
      {
        BitmapStore.ReloadSomeGfx();
        BitmapStore.ReloadSystemGraphics(this.Game.ModSystemGraphicsDirectory);
        this.RefreshOwnBackground(tGame.BACKGROUND5MARC);
        this.Game.HandyFunctionsObj.SetGameColors();
        int x = (int) Math.Round(Conversion.Int((double) (tGame.ScreenWidth - 1024) / 2.0));
        int y = (int) Math.Round(Conversion.Int((double) (tGame.ScreenHeight - 768) / 2.0));
        this.wTop = this.AddWindow((WindowClass) new WelcomeWindowClass2(ref tGame, true, (ScreenClass) this, true), x, y, 1024, 768);
        this.Game.EditObj.ShowInitialMenu = false;
      }
      else
      {
        int x = (int) Math.Round(Conversion.Int((double) (tGame.ScreenWidth - 1024) / 2.0));
        int y = (int) Math.Round(Conversion.Int((double) (tGame.ScreenHeight - 768) / 2.0));
        this.wTop = this.AddWindow((WindowClass) new IntroWindowClass2(ref tGame), x, y, 1024, 768);
      }
    }

    public FirstScreenClass2(ref GameClass tGame, Form1 tformref)
      : base(ref tGame, tGame.BACKGROUND5MARC, tformref)
    {
      if (!this.Game.EditObj.ShownWelcome)
      {
        BitmapStore.ReloadSomeGfx();
        BitmapStore.ReloadSystemGraphics(this.Game.ModSystemGraphicsDirectory);
        int x = (int) Math.Round(Conversion.Int((double) (tGame.ScreenWidth - 1024) / 2.0));
        int y = (int) Math.Round(Conversion.Int((double) (tGame.ScreenHeight - 768) / 2.0));
        this.wTop = this.AddWindow((WindowClass) new WelcomeWindowClass2(ref tGame, true, (ScreenClass) this, true), x, y, 1024, 768);
      }
      else if (this.Game.EditObj.ShowInitialMenu)
      {
        BitmapStore.ReloadSomeGfx();
        BitmapStore.ReloadSystemGraphics(this.Game.ModSystemGraphicsDirectory);
        int x = (int) Math.Round(Conversion.Int((double) (tGame.ScreenWidth - 1024) / 2.0));
        int y = (int) Math.Round(Conversion.Int((double) (tGame.ScreenHeight - 768) / 2.0));
        this.wTop = this.AddWindow((WindowClass) new WelcomeWindowClass2(ref tGame, true, (ScreenClass) this, true), x, y, 1024, 768);
        this.Game.EditObj.ShowInitialMenu = false;
      }
      else
      {
        int x = (int) Math.Round(Conversion.Int((double) (tGame.ScreenWidth - 1024) / 2.0));
        int y = (int) Math.Round(Conversion.Int((double) (tGame.ScreenHeight - 768) / 2.0));
        this.wTop = this.AddWindow((WindowClass) new IntroWindowClass2(ref tGame), x, y, 1024, 768);
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
              if (windowReturnClass.CommandType[index] == 3)
              {
                screenReturnClass.NewScreen = windowReturnClass.CommandData[index];
                return screenReturnClass;
              }
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
              if (windowReturnClass.CommandType[index] == 1)
                this.RemoveWindow(this.wTop);
              if (windowReturnClass.CommandType[index] == 2)
              {
                if (windowReturnClass.CommandData[index] == 55)
                  this.wTop = this.AddWindow((WindowClass) new WelcomeWindowClass2(ref this.Game, true, (ScreenClass) this, true), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenWidth - 1024) / 2.0)), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenHeight - 768) / 2.0)), 1024, 768);
                if (windowReturnClass.CommandData[index] == 91)
                  this.wTop = this.AddWindow((WindowClass) new CorePbemWindowClass(ref this.Game), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenWidth - 1024) / 2.0)), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenHeight - 768) / 2.0)), 1024, 768);
                if (windowReturnClass.CommandData[index] == 92)
                  this.wTop = this.AddWindow((WindowClass) new PbemInitializeWindowClass(ref this.Game), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenWidth - 1024) / 2.0)), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenHeight - 768) / 2.0)), 1024, 768);
              }
            }
          }
          screenReturnClass.flag = windowReturnClass.Flag;
          return screenReturnClass;
        }
      }
      return screenReturnClass;
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    public override ScreenReturnClass HandleMouseClick(int x, int y, int b)
    {
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      if (x > this.Game.ScreenWidth - 52 & x < this.Game.ScreenWidth - 28 & y < 25)
        this.Game.FormRef.WindowState = FormWindowState.Minimized;
      if (x > this.Game.ScreenWidth - 28 & x < this.Game.ScreenWidth - 4 & y < 25)
      {
        if (Operators.CompareString(this.WindowList[0].GetType().FullName, "WindowsApplication1.WelcomeWindowClass2", false) == 0)
        {
          if (Interaction.MsgBox((object) "Are you sure you want to quit?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
          {
            SoundMod.StopWave();
            SoundMod.EndSound();
            this.Game = (GameClass) null;
            ProjectData.EndApp();
          }
        }
        else
        {
          this.RemoveWindow(this.wTop);
          this.wTop = this.AddWindow((WindowClass) new WelcomeWindowClass2(ref this.Game, true, (ScreenClass) this, true), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenWidth - 1024) / 2.0)), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenHeight - 768) / 2.0)), 1024, 768);
          screenReturnClass.flag = true;
          return screenReturnClass;
        }
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
                this.RemoveWindow(this.wTop);
              if (windowReturnClass.CommandType[index2] == 2)
              {
                if (windowReturnClass.CommandData[index2] == 55)
                  this.wTop = this.AddWindow((WindowClass) new WelcomeWindowClass2(ref this.Game, true, (ScreenClass) this, true), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenWidth - 1024) / 2.0)), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenHeight - 768) / 2.0)), 1024, 768);
                if (windowReturnClass.CommandData[index2] == 91)
                  this.wTop = this.AddWindow((WindowClass) new CorePbemWindowClass(ref this.Game), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenWidth - 1024) / 2.0)), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenHeight - 768) / 2.0)), 1024, 768);
                if (windowReturnClass.CommandData[index2] == 92)
                  this.wTop = this.AddWindow((WindowClass) new PbemInitializeWindowClass(ref this.Game), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenWidth - 1024) / 2.0)), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenHeight - 768) / 2.0)), 1024, 768);
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
            if (windowReturnClass2.CommandType[index] == 1)
              this.RemoveWindow(this.wTop);
            if (windowReturnClass2.CommandType[index] == 2)
            {
              if (windowReturnClass2.CommandData[index] == 55)
                this.wTop = this.AddWindow((WindowClass) new WelcomeWindowClass2(ref this.Game, true, (ScreenClass) this, true), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenWidth - 1024) / 2.0)), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenHeight - 768) / 2.0)), 1024, 768);
              if (windowReturnClass2.CommandData[index] == 91)
                this.wTop = this.AddWindow((WindowClass) new CorePbemWindowClass(ref this.Game), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenWidth - 1024) / 2.0)), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenHeight - 768) / 2.0)), 1024, 768);
              if (windowReturnClass2.CommandData[index] == 92)
                this.wTop = this.AddWindow((WindowClass) new PbemInitializeWindowClass(ref this.Game), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenWidth - 1024) / 2.0)), (int) Math.Round(Conversion.Int((double) (this.Game.ScreenHeight - 768) / 2.0)), 1024, 768);
            }
          }
        }
      }
      screenReturnClass.flag = true;
      return screenReturnClass;
    }
  }
}