// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.TabHelpWindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsApplication1
{
  public class TabHelpWindowClass2 : WindowClass
  {
    private int Info1Id;
    private int info2id;
    private string ShowString;
    private DateTime ShowTime;
    private int w;
    private int h;
    private int CurrentView;
    private int currentHelp;

    public TabHelpWindowClass2(
      ref GameClass tGame,
      ref WindowClass tLowerWindow,
      ref Rectangle tLowerRect,
      Rectangle trect)
      : base(ref tGame, trect.Width, trect.Height, 8)
    {
      this.w = trect.Width;
      this.h = trect.Height;
      this.LowerWindow = tLowerWindow;
      this.LowerRect = tLowerRect;
      this.currentHelp = 0;
      this.dostuff();
    }

    public override void DoRefresh() => this.dostuff();

    public void dostuff()
    {
      if (this.Info1Id > 0)
        this.RemoveSubPart(this.Info1Id);
      this.ClearMouse();
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
      Rectangle trect1 = DrawMod.DrawBackTab(g, this.w, this.h, "HELP", 1);
      this.AddMouse(ref trect1, "CLOSE TAB", "Click here to close this tab. [ESC/F2]", 999);
      int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[988]));
      if (this.game.Data.StringListObj[stringListById].Length > -1)
      {
        g.SmoothingMode = SmoothingMode.None;
        DrawMod.drawLineDot(ref g, 135, 0, 135, this.h - 40, Color.White);
        DrawMod.drawLineDot(ref g, 15, 8, 135, 8, Color.White);
        int length = this.game.Data.StringListObj[stringListById].Length;
        for (int index = 0; index <= length; ++index)
        {
          g.SmoothingMode = SmoothingMode.AntiAlias;
          if (this.currentHelp == -1)
            this.currentHelp = index;
          if (index == this.currentHelp)
            DrawMod.DrawBlockGradient(ref g, 35, 8 + 24 * index, 100, 24, Color.FromArgb(0, 0, 0, 0), Color.FromArgb(96, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          Rectangle trect2 = new Rectangle(15, 8 + 24 * index, 120, 24);
          this.AddMouse(ref trect2, "", "Click to get more info", 1000 + index);
          int y = 13 + 24 * index + 1;
          DrawMod.DrawTextColouredMarcCenter(ref g, this.game.Data.StringListObj[stringListById].Data[index, 0], this.game.MarcFont5, 75, y, Color.White);
          g.SmoothingMode = SmoothingMode.None;
          DrawMod.drawLineDot(ref g, 15, 8 + index * 24, 135, 8 + index * 24, Color.White);
        }
      }
      g.SmoothingMode = SmoothingMode.AntiAlias;
      string tstring = this.game.Data.StringListObj[stringListById].Data[this.currentHelp, 1];
      string str1 = this.game.Data.StringListObj[stringListById].Data[this.currentHelp, 2];
      int index1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[this.currentHelp, 3]));
      string str2 = this.game.Data.StringListObj[stringListById].Data[this.currentHelp, 4];
      if (index1 > -1)
        index1 = this.game.Data.EventPicNr[index1];
      TextAreaClass2 textAreaClass2 = new TextAreaClass2(this.game, this.w - 190, 17, this.game.MarcFont8, "\r\n\r\n\r\n" + str1, 17, ref this.OwnBitmap, 165, -15, true, tUseEncy: true);
      textAreaClass2.Paint();
      DrawMod.Draw(ref g, ref textAreaClass2.OwnBitmap, 165, -15, 0.0f, 0.0f, 0.0f, 1f);
      int num = textAreaClass2.HeightUsed();
      textAreaClass2.Dispose();
      DrawMod.DrawTextColouredMarc(ref g, tstring, this.game.MarcFont2, 179, 19, Color.White);
      DrawMod.DrawBlock(ref g, 179, 49, 450, 1, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      if (index1 <= -1)
        return;
      SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(index1, tDescript: "Click to start video", tVideoMode: true);
      this.Info1Id = this.AddSubPart(ref tsubpart, 179, num + 24, BitmapStore.GetWidth(index1), BitmapStore.Getheight(index1), 1);
    }

    public override void HandleToolTip(int x, int y)
    {
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = this.MouseTitle[index];
          this.game.EditObj.TipText = this.MouseText[index];
          return;
        }
      }
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
      {
        if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
        {
          this.game.EditObj.TipButton = false;
          this.SubPartList[index].HandleToolTip(x - this.SubPartX[index], y - this.SubPartY[index]);
          if (this.game.EditObj.TipButton)
            break;
          if (this.SubPartID[index] == this.Info1Id)
          {
            this.game.EditObj.TipTitle = "PLAY VIDEO";
            this.game.EditObj.TipText = "Will open a video file in an external video player. You can use alt-TAB to switch between game and video player.";
          }
        }
      }
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (nr == 40)
      {
        this.SubPartList[this.SubpartNr(this.Info1Id)].ShiftDown();
        this.SubPartFlag[this.SubpartNr(this.Info1Id)] = true;
        windowReturnClass.SetFlag(true);
      }
      if (nr == 38)
      {
        this.SubPartList[this.SubpartNr(this.Info1Id)].ShiftUp();
        this.SubPartFlag[this.SubpartNr(this.Info1Id)] = true;
        windowReturnClass.SetFlag(true);
      }
      if (nr == 37)
      {
        this.SubPartList[this.SubpartNr(this.Info1Id)].ShiftLeft();
        this.SubPartFlag[this.SubpartNr(this.Info1Id)] = true;
        windowReturnClass.SetFlag(true);
      }
      if (nr == 39)
      {
        this.SubPartList[this.SubpartNr(this.Info1Id)].ShiftRight();
        this.SubPartFlag[this.SubpartNr(this.Info1Id)] = true;
        windowReturnClass.SetFlag(true);
      }
      return windowReturnClass;
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (this.MouseData[index] > 0 && x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          if (this.MouseData[index] >= 1000)
          {
            this.currentHelp = this.MouseData[index] - 1000;
            this.dostuff();
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
          if (this.MouseData[index] == 999)
          {
            this.game.EditObj.SetViewMode2 = 0;
            windowReturnClass1.AddCommand(1, 9);
            windowReturnClass1.AddCommand(7, 12);
            windowReturnClass1.AddCommand(4, 67);
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
        }
      }
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
      {
        if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index] && this.SubPartID[index] == this.Info1Id)
        {
          string str = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[988]))].Data[this.currentHelp, 4];
          this.SubPartFlag[index] = true;
          windowReturnClass1.SetFlag(true);
          WindowReturnClass windowReturnClass2;
          try
          {
            Process.Start(AppDomain.CurrentDomain.BaseDirectory + str);
            this.game.FormRef.SendToBack();
            SoundMod.STopEventBackground();
            SoundMod.STopEventWave();
            SoundMod.NOSOUND = true;
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            int num = (int) Interaction.MsgBox((object) "PROBLEM", Title: ((object) "Sadly there was a problem trying to let your Windows system run this video. Please check the game forums for possible causes."));
            this.dostuff();
            windowReturnClass2 = windowReturnClass1;
            ProjectData.ClearProjectError();
            goto label_19;
          }
          this.dostuff();
          return windowReturnClass1;
label_19:
          return windowReturnClass2;
        }
      }
      if (x > 8 & x < this.w - 8 && y < this.h - 24)
        windowReturnClass1.NoMouseClickBelow = true;
      windowReturnClass1.SetFlag(false);
      return windowReturnClass1;
    }
  }
}
