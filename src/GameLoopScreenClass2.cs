// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.GameLoopScreenClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class GameLoopScreenClass2 : ScreenClass
  {
    private int lastRegime;

    public GameLoopScreenClass2(ref GameClass tGame, Form1 tformref, bool NewGfx)
      : base(ref tGame, tGame.BACKGROUND5MARC, tformref)
    {
      this.lastRegime = -1;
      int x = (int) Math.Round(Conversion.Int((double) (tGame.ScreenWidth - 1024) / 2.0));
      int y = (int) Math.Round(Conversion.Int((double) (tGame.ScreenHeight - 236) / 2.0));
      this.DoStuff();
      this.AddWindow((WindowClass) new GameLoopMainWindowClass2(ref tGame, true), x, y, 1024, 236);
      this.Game.HandyFunctionsObj.SetGameColors();
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    public override ScreenReturnClass HandleMouseClick(int x, int y, int b)
    {
      ScreenReturnClass screenReturnClass1 = new ScreenReturnClass();
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
            this.Game.Data = new DataClass();
            this.Game.EditObj = new EditClass(this.Game.AppPath + "editobj.txt");
            if (this.Game.Data.UseAI == 1)
            {
              if (Information.IsNothing((object) this.Game.NewAIObj))
                this.Game.NewAIObj = new NewAIClass(this.Game);
              this.Game.NewAIObj.LastRegime = -1;
            }
            this.Game.EditObj.ShowInitialMenu = true;
            screenReturnClass1.NewScreen = 12;
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

    public void DoStuff()
    {
      Graphics objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
      objGraphics.CompositingMode = CompositingMode.SourceCopy;
      DrawMod.DrawSimple(ref objGraphics, ref this.OwnBackground, 0, 0);
      objGraphics.CompositingMode = CompositingMode.SourceOver;
      this.Game.CustomBitmapObj.DrawStandardShadowEmpireFrame(objGraphics, 0, 0, true, false);
      objGraphics.Dispose();
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

    public override ScreenReturnClass HandleTimer()
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      bool flag = false;
      if (this.Game.EditObj.RealTurn != this.lastRegime)
      {
        this.lastRegime = this.Game.EditObj.RealTurn;
        this.DoStuff();
        flag = true;
      }
      if (this.WindowCounter > -1)
      {
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
            }
          }
        }
        screenReturnClass.flag = flag;
        return screenReturnClass;
      }
      screenReturnClass.flag = flag;
      return screenReturnClass;
    }
  }
}
