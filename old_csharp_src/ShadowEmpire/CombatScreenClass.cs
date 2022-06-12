// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.CombatScreenClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class CombatScreenClass : ScreenClass
  {
    private int wleft;
    private int wright;

    public CombatScreenClass(ref GameClass tGame)
      : base(ref tGame, tGame.BACKGROUND1MARC)
    {
      this.wright = this.AddWindow((WindowClass) new CombatResultWindowClass(ref tGame), (int) Math.Round((double) this.Game.ScreenWidth / 2.0 - 512.0), (int) Math.Round((double) this.Game.ScreenHeight / 2.0 - 384.0), 1024, 768);
    }

    public override ScreenReturnClass HandleTimer()
    {
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      int windowCounter = this.WindowCounter;
      for (int index1 = 0; index1 <= windowCounter; ++index1)
      {
        WindowReturnClass windowReturnClass = this.WindowList[index1].handleTimer();
        this.WindowFlag[index1] = windowReturnClass.Flag;
        if (windowReturnClass.Flag)
        {
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
      if (x > this.Game.ScreenWidth - 28 & x < this.Game.ScreenWidth - 4 & y < 25 && Interaction.MsgBox((object) "Are you sure you want to exit your current game?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
      {
        this.Game.Data = new DataClass();
        this.Game.EditObj = new EditClass(this.Game.AppPath + "editobj.txt");
        if (this.Game.Data.UseAI == 1)
          this.Game.NewAIObj.LastRegime = -1;
        this.Game.EditObj.ShowInitialMenu = true;
        screenReturnClass.NewScreen = 1;
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
                this.RemoveWindow(this.wright);
                this.wright = 0;
              }
              else if (windowReturnClass.CommandType[index2] == 2)
              {
                if (windowReturnClass.CommandData[index2] == 82)
                  this.wright = this.AddWindow((WindowClass) new ATCombatDetailWindowClass(ref DrawMod.TGame, 768, true), (int) Math.Round((double) this.Game.ScreenWidth / 2.0 - 512.0), (int) Math.Round((double) this.Game.ScreenHeight / 2.0 - 384.0), 1024, 768);
                else if (windowReturnClass.CommandData[index2] == 84)
                  this.wright = this.AddWindow((WindowClass) new CombatResultWindowClass(ref DrawMod.TGame), (int) Math.Round((double) this.Game.ScreenWidth / 2.0 - 512.0), (int) Math.Round((double) this.Game.ScreenHeight / 2.0 - 384.0), 1024, 768);
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
        if (windowReturnClass2.Counter > -1 && windowReturnClass2.Counter > -1)
        {
          int counter = windowReturnClass2.Counter;
          for (int index = 0; index <= counter; ++index)
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
