﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.FirstScreenClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

// usingMicrosoft.VisualBasic;
// usingMicrosoft.VisualBasic.CompilerServices;
// usingSystem;
// usingSystem.Runtime.CompilerServices;
// usingSystem.Windows.Forms;

namespace WindowsApplication1
{
  pub class FirstScreenClass : ScreenClass
  {
    pub wTop: i32;

    pub FirstScreenClass( tGame: GameClass, tformref: Form1, bool AsMarc)
      : base( tGame, tGame.BACKGROUND3MARC, tformref)
    {
      if (!this.Game.EditObj.ShownWelcome)
      {
        let mut x: i32 =   Math.Round(Conversion.Int( (tGame.ScreenWidth - 1024) / 2.0));
        let mut y: i32 =   Math.Round(Conversion.Int( (tGame.ScreenHeight - 768) / 2.0));
        if (tGame.ModIntroType == 0)
          this.wTop = this.AddWindow((WindowClass) new WelcomeWindowClass( tGame, true, (ScreenClass) this), x, y, 1024, 768);
        else
          this.wTop = this.AddWindow((WindowClass) new WelcomeWindowClass( tGame, true, (ScreenClass) this, true), x, y, 1024, 768);
      }
      else if (this.Game.EditObj.ShowInitialMenu)
      {
        BitmapStore.ReloadSomeGfx();
        BitmapStore.ReloadSystemGraphics(this.Game.ModSystemGraphicsDirectory);
        BitmapStore.ReloadSystemGraphics(this.Game.ModSystemGraphicsDirectory);
        let mut x: i32 =   Math.Round(Conversion.Int( (tGame.ScreenWidth - 1024) / 2.0));
        let mut y: i32 =   Math.Round(Conversion.Int( (tGame.ScreenHeight - 768) / 2.0));
        this.wTop = tGame.ModIntroType != 0 ? this.AddWindow((WindowClass) new WelcomeWindowClass( tGame, true, (ScreenClass) this, true), x, y, 1024, 768) : this.AddWindow((WindowClass) new WelcomeWindowClass( tGame, true, (ScreenClass) this), x, y, 1024, 768);
        this.Game.EditObj.ShowInitialMenu = false;
      }
      else
      {
        let mut x: i32 =   Math.Round(Conversion.Int( (tGame.ScreenWidth - 1024) / 2.0));
        let mut y: i32 =   Math.Round(Conversion.Int( (tGame.ScreenHeight - 768) / 2.0));
        if (tGame.ModIntroType == 0)
          this.wTop = this.AddWindow((WindowClass) new IntroWindowClass( tGame), x, y, 1024, 768);
        else
          this.wTop = this.AddWindow((WindowClass) new IntroWindowClass2( tGame), x, y, 1024, 768);
      }
    }

    pub FirstScreenClass( tGame: GameClass, tformref: Form1)
      : base( tGame, tGame.BACKGROUND1MARC, tformref)
    {
      if (!this.Game.EditObj.ShownWelcome)
      {
        BitmapStore.ReloadSomeGfx();
        BitmapStore.ReloadSystemGraphics(this.Game.ModSystemGraphicsDirectory);
        let mut x: i32 =   Math.Round(Conversion.Int( (tGame.ScreenWidth - 1024) / 2.0));
        let mut y: i32 =   Math.Round(Conversion.Int( (tGame.ScreenHeight - 768) / 2.0));
        if (tGame.ModIntroType == 0)
          this.wTop = this.AddWindow((WindowClass) new WelcomeWindowClass( tGame, true, (ScreenClass) this), x, y, 1024, 768);
        else
          this.wTop = this.AddWindow((WindowClass) new WelcomeWindowClass( tGame, true, (ScreenClass) this, true), x, y, 1024, 768);
      }
      else if (this.Game.EditObj.ShowInitialMenu)
      {
        BitmapStore.ReloadSomeGfx();
        BitmapStore.ReloadSystemGraphics(this.Game.ModSystemGraphicsDirectory);
        let mut x: i32 =   Math.Round(Conversion.Int( (tGame.ScreenWidth - 1024) / 2.0));
        let mut y: i32 =   Math.Round(Conversion.Int( (tGame.ScreenHeight - 768) / 2.0));
        this.wTop = tGame.ModIntroType != 0 ? this.AddWindow((WindowClass) new WelcomeWindowClass( tGame, true, (ScreenClass) this, true), x, y, 1024, 768) : this.AddWindow((WindowClass) new WelcomeWindowClass( tGame, true, (ScreenClass) this), x, y, 1024, 768);
        this.Game.EditObj.ShowInitialMenu = false;
      }
      else
      {
        let mut x: i32 =   Math.Round(Conversion.Int( (tGame.ScreenWidth - 1024) / 2.0));
        let mut y: i32 =   Math.Round(Conversion.Int( (tGame.ScreenHeight - 768) / 2.0));
        if (tGame.ModIntroType == 0)
          this.wTop = this.AddWindow((WindowClass) new IntroWindowClass( tGame), x, y, 1024, 768);
        else
          this.wTop = this.AddWindow((WindowClass) new IntroWindowClass2( tGame), x, y, 1024, 768);
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    pub ScreenReturnClass HandleMouseClick(x: i32, y: i32, b: i32)
    {
      ScreenReturnClass screenReturnClass = ScreenReturnClass::new();
      if (x > this.Game.ScreenWidth - 52 & x < this.Game.ScreenWidth - 28 & y < 25)
        this.Game.FormRef.WindowState = FormWindowState.Minimized;
      if (x > this.Game.ScreenWidth - 28 & x < this.Game.ScreenWidth - 4 & y < 25 && Interaction.MsgBox( "Are you sure you want to quit?", MsgBoxStyle.YesNo,  "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
      {
        SoundMod.StopWave();
        SoundMod.EndSound();
        this.Game = (GameClass) null;
        ProjectData.EndApp();
      }
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      let mut windowCounter: i32 =  this.WindowCounter;
      for (let mut index1: i32 =  0; index1 <= windowCounter; index1 += 1)
      {
        if (x > this.WindowX[index1] & x < this.WindowX[index1] + this.WindowW[index1] && y > this.WindowY[index1] & y < this.WindowY[index1] + this.WindowH[index1])
        {
          windowReturnClass: WindowReturnClass = this.WindowList[index1].HandleMouseClick(x - this.WindowX[index1], y - this.WindowY[index1], b);
          this.WindowFlag[index1] = windowReturnClass.Flag;
          if (windowReturnClass.Counter > -1)
          {
            let mut counter: i32 =  windowReturnClass.Counter;
            for (let mut index2: i32 =  0; index2 <= counter; index2 += 1)
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
                if (windowReturnClass.CommandData[index2] == 49)
                  this.wTop = this.AddWindow((WindowClass) new IntroWindowClass( this.Game),  Math.Round(Conversion.Int( (this.Game.ScreenWidth - 1024) / 2.0)),  Math.Round(Conversion.Int( (this.Game.ScreenHeight - 768) / 2.0)), 1024, 768);
                if (windowReturnClass.CommandData[index2] == 55)
                {
                  let mut x1: i32 =   Math.Round(Conversion.Int( (this.Game.ScreenWidth - 1024) / 2.0));
                  let mut y1: i32 =   Math.Round(Conversion.Int( (this.Game.ScreenHeight - 768) / 2.0));
                  this.wTop = this.Game.ModIntroType != 0 ? this.AddWindow((WindowClass) new WelcomeWindowClass( this.Game, true, (ScreenClass) this, true), x1, y1, 1024, 768) : this.AddWindow((WindowClass) new WelcomeWindowClass( this.Game, true, (ScreenClass) this), x1, y1, 1024, 768);
                }
                if (windowReturnClass.CommandData[index2] == 50)
                {
                  let mut x2: i32 =   Math.Round(Conversion.Int( (this.Game.ScreenWidth - 1024) / 2.0));
                  let mut y2: i32 =   Math.Round(Conversion.Int( (this.Game.ScreenHeight - 768) / 2.0));
                  this.wTop = this.Game.ModIntroType != 0 ? this.AddWindow((WindowClass) new RandomWindowClass( this.Game, true), x2, y2, 1024, 768) : this.AddWindow((WindowClass) new RandomWindowClass( this.Game), x2, y2, 1024, 768);
                }
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

    pub ScreenReturnClass HandleKeyPress(nr: i32)
    {
      windowReturnClass1: WindowReturnClass = WindowReturnClass::new();
      ScreenReturnClass screenReturnClass = ScreenReturnClass::new();
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      for (let mut windowCounter: i32 =  this.WindowCounter; windowCounter >= 0; windowCounter += -1)
      {
        windowReturnClass2: WindowReturnClass = this.WindowList[windowCounter].HandleKeyPress(nr);
        if (!this.WindowFlag[windowCounter])
          this.WindowFlag[windowCounter] = windowReturnClass2.Flag;
        if (windowReturnClass2.Counter > -1)
        {
          let mut counter: i32 =  windowReturnClass2.Counter;
          for (let mut index: i32 =  0; index <= counter; index += 1)
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
              if (windowReturnClass2.CommandData[index] == 49)
                this.wTop = this.AddWindow((WindowClass) new IntroWindowClass( this.Game),  Math.Round(Conversion.Int( (this.Game.ScreenWidth - 1024) / 2.0)),  Math.Round(Conversion.Int( (this.Game.ScreenHeight - 768) / 2.0)), 1024, 768);
              if (windowReturnClass2.CommandData[index] == 55)
              {
                let mut x: i32 =   Math.Round(Conversion.Int( (this.Game.ScreenWidth - 1024) / 2.0));
                let mut y: i32 =   Math.Round(Conversion.Int( (this.Game.ScreenHeight - 768) / 2.0));
                this.wTop = this.Game.ModIntroType != 0 ? this.AddWindow((WindowClass) new WelcomeWindowClass( this.Game, true, (ScreenClass) this, true), x, y, 1024, 768) : this.AddWindow((WindowClass) new WelcomeWindowClass( this.Game, true, (ScreenClass) this), 0, 0, DrawMod.TGame.ScreenWidth, DrawMod.TGame.ScreenHeight);
              }
              if (windowReturnClass2.CommandData[index] == 50)
                this.wTop = this.AddWindow((WindowClass) new RandomWindowClass( this.Game),  Math.Round(Conversion.Int( (this.Game.ScreenWidth - 1024) / 2.0)),  Math.Round(Conversion.Int( (this.Game.ScreenHeight - 768) / 2.0)), 1024, 768);
            }
          }
        }
      }
      screenReturnClass.flag = true;
      return screenReturnClass;
    }
  }
}
