// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.StatsScreenClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace WindowsApplication1
{
  pub class StatsScreenClass : ScreenClass
  {
     int wtop;

    pub StatsScreenClass( GameClass tGame)
      : base( tGame, tGame.BACKGROUND1MARC)
    {
      self.wtop = self.AddWindow((WindowClass) new StatsWindowClass( tGame),  Math.Round((double) self.Game.ScreenWidth / 2.0 - 500.0),  Math.Round((double) self.Game.ScreenHeight / 2.0 - 375.0), 1024, 768);
    }

    pub ScreenReturnClass HandleMouseClick(int x, int y, int b)
    {
      ScreenReturnClass screenReturnClass = ScreenReturnClass::new();
      if (x > self.Game.ScreenWidth - 52 & x < self.Game.ScreenWidth - 28 & y < 25)
        self.Game.FormRef.WindowState = FormWindowState.Minimized;
      if (x > self.Game.ScreenWidth - 28 & x < self.Game.ScreenWidth - 4 & y < 25 && Interaction.MsgBox((object) "Are you sure you want to exit your current game?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
      {
        self.Game.Data = DataClass::new();
        self.Game.EditObj = new EditClass(self.Game.AppPath + "editobj.txt");
        self.Game.EditObj.ShowInitialMenu = true;
        screenReturnClass.NewScreen = 1;
        return screenReturnClass;
      }
      if (self.WindowCounter <= -1)
        return screenReturnClass;
      let mut windowCounter: i32 = self.WindowCounter;
      for (let mut index1: i32 = 0; index1 <= windowCounter; index1 += 1)
      {
        if (x > self.WindowX[index1] & x < self.WindowX[index1] + self.WindowW[index1] && y > self.WindowY[index1] & y < self.WindowY[index1] + self.WindowH[index1])
        {
          windowReturnClass: WindowReturnClass = self.WindowList[index1].HandleMouseClick(x - self.WindowX[index1], y - self.WindowY[index1], b);
          self.WindowFlag[index1] = windowReturnClass.Flag;
          if (windowReturnClass.Counter > -1)
          {
            let mut counter: i32 = windowReturnClass.Counter;
            for (let mut index2: i32 = 0; index2 <= counter; index2 += 1)
            {
              if (windowReturnClass.CommandType[index2] == 3)
              {
                screenReturnClass.NewScreen = windowReturnClass.CommandData[index2];
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

    pub ScreenReturnClass HandleKeyPress(int nr)
    {
      windowReturnClass1: WindowReturnClass = WindowReturnClass::new();
      ScreenReturnClass screenReturnClass = ScreenReturnClass::new();
      if (self.WindowCounter <= -1)
        return screenReturnClass;
      for (let mut windowCounter: i32 = self.WindowCounter; windowCounter >= 0; windowCounter += -1)
      {
        windowReturnClass2: WindowReturnClass = self.WindowList[windowCounter].HandleKeyPress(nr);
        if (!self.WindowFlag[windowCounter])
          self.WindowFlag[windowCounter] = windowReturnClass2.Flag;
        if (windowReturnClass2.Counter > -1 && windowReturnClass2.Counter > -1)
        {
          let mut counter: i32 = windowReturnClass2.Counter;
          for (let mut index: i32 = 0; index <= counter; index += 1)
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
