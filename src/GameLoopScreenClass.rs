// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.GameLoopScreenClass
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
  pub class GameLoopScreenClass : ScreenClass
  {
    pub GameLoopScreenClass( GameClass tGame, Form1 tformref)
      : base( tGame, tGame.BACKGROUND1MARC, tformref)
    {
      int x =  Math.Round(Conversion.Int((double) (tGame.ScreenWidth - 1024) / 2.0));
      int y =  Math.Round(Conversion.Int((double) (tGame.ScreenHeight - 768) / 2.0));
      this.AddWindow((WindowClass) new GameLoopMainWindowClass( tGame), x, y, 1024, 768);
    }

    pub GameLoopScreenClass( GameClass tGame, Form1 tformref, bool NewGfx)
      : base( tGame, tGame.BACKGROUND1MARC, tformref)
    {
      int x =  Math.Round(Conversion.Int((double) (tGame.ScreenWidth - 1024) / 2.0));
      int y =  Math.Round(Conversion.Int((double) (tGame.ScreenHeight - 768) / 2.0));
      this.AddWindow((WindowClass) new GameLoopMainWindowClass( tGame, true), x, y, 1024, 768);
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    pub ScreenReturnClass HandleMouseClick(int x, int y, int b)
    {
      ScreenReturnClass screenReturnClass1 = ScreenReturnClass::new();
      if (x > this.Game.ScreenWidth - 52 & x < this.Game.ScreenWidth - 28 & y < 25)
        this.Game.FormRef.WindowState = FormWindowState.Minimized;
      if (x > this.Game.ScreenWidth - 28 & x < this.Game.ScreenWidth - 4 & y < 25 && Interaction.MsgBox((object) "Are you sure you want quit?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
      {
        if (this.Game.Data.Turn > -1)
        {
          if (this.Game.Data.RegimeObj[this.Game.Data.Turn].AI)
          {
            this.Game = (GameClass) null;
            ProjectData.EndApp();
          }
          else
          {
            this.Game.Data = DataClass::new();
            this.Game.EditObj = new EditClass(this.Game.AppPath + "editobj.txt");
            if (this.Game.Data.UseAI == 1)
              this.Game.NewAIObj.LastRegime = -1;
            this.Game.EditObj.ShowInitialMenu = true;
            screenReturnClass1.NewScreen = 1;
            return screenReturnClass1;
          }
        }
        else
        {
          this.Game = (GameClass) null;
          ProjectData.EndApp();
        }
        ScreenReturnClass screenReturnClass2;
        return screenReturnClass2;
      }
      if (this.WindowCounter <= -1)
        return screenReturnClass1;
      int windowCounter = this.WindowCounter;
      for (int index1 = 0; index1 <= windowCounter; index1 += 1)
      {
        if (x > this.WindowX[index1] & x < this.WindowX[index1] + this.WindowW[index1] && y > this.WindowY[index1] & y < this.WindowY[index1] + this.WindowH[index1])
        {
          windowReturnClass: WindowReturnClass = this.WindowList[index1].HandleMouseClick(x - this.WindowX[index1], y - this.WindowY[index1], b);
          this.WindowFlag[index1] = windowReturnClass.Flag;
          if (windowReturnClass.Counter > -1)
          {
            int counter = windowReturnClass.Counter;
            for (int index2 = 0; index2 <= counter; index2 += 1)
            {
              if (windowReturnClass.CommandType[index2] == 3)
              {
                screenReturnClass1.NewScreen = windowReturnClass.CommandData[index2];
                return screenReturnClass1;
              }
            }
          }
          screenReturnClass1.flag = windowReturnClass.Flag;
          return screenReturnClass1;
        }
      }
      screenReturnClass1.flag = false;
      return screenReturnClass1;
    }

    pub ScreenReturnClass HandleKeyPress(int nr)
    {
      windowReturnClass1: WindowReturnClass = WindowReturnClass::new();
      ScreenReturnClass screenReturnClass = ScreenReturnClass::new();
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      for (int windowCounter = this.WindowCounter; windowCounter >= 0; windowCounter += -1)
      {
        windowReturnClass2: WindowReturnClass = this.WindowList[windowCounter].HandleKeyPress(nr);
        if (!this.WindowFlag[windowCounter])
          this.WindowFlag[windowCounter] = windowReturnClass2.Flag;
        if (windowReturnClass2.Counter > -1 && windowReturnClass2.Counter > -1)
        {
          int counter = windowReturnClass2.Counter;
          for (int index = 0; index <= counter; index += 1)
          {
            if (windowReturnClass2.CommandType[index] == 3)
            {
              screenReturnClass.NewScreen = windowReturnClass2.CommandData[index];
              return screenReturnClass;
            }
          }
        }
      }
      screenReturnClass.flag = true;
      return screenReturnClass;
    }
  }
}
