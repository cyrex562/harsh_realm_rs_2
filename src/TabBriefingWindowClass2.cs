// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.TabBriefingWindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class TabBriefingWindowClass2 : WindowClass
  {
    private int Info1Id;
    private int info2id;
    private string ShowString;
    private DateTime ShowTime;
    private int w;
    private int h;
    private int CurrentView;

    public TabBriefingWindowClass2(
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
      this.dostuff();
    }

    public override void DoRefresh() => this.dostuff();

    public void dostuff()
    {
      this.ClearMouse();
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Rectangle trect = DrawMod.DrawBackTab(Graphics.FromImage((Image) this.OwnBitmap), this.w, this.h, "BRIEF", 1);
      this.AddMouse(ref trect, "CLOSE TAB", "Click here to close this tab. [ESC/F2]", 999);
      string String1_1 = this.game.Data.Description;
      if (this.game.Data.Product >= 6)
      {
        if (Strings.InStr(String1_1, "[tab]") <= 0)
          String1_1 = "[tab]Scenario description," + String1_1 + "[/tab]";
        string str1 = String1_1 + "[tab]Version info," + "Game version: " + "v " + Strings.Trim(Conversion.Str((object) Math.Floor(1.1))) + "." + Strings.Trim(Conversion.Str((object) 10)) + " " + Strings.Trim(".04b") + " Shadow Empire : Planetary Conquest. " + "\r\n" + "Scenario name: " + this.game.Data.Name + "\r\n";
        if (this.game.Data.scenarioVersion.Length >= 2)
          str1 = str1 + "Scenario version: " + this.game.Data.scenarioVersion + "\r\n";
        else if (this.game.Data.RegimeObj[this.game.Data.Turn].Version > 0)
        {
          string str2 = str1 + "Last turn game version: ";
          string str3;
          if ((this.game.Data.RegimeObj[this.game.Data.Turn].Version - 314) % 100 >= 10)
            str3 = str2 + "v " + Strings.Trim(Conversion.Str((object) Math.Floor((double) (this.game.Data.RegimeObj[this.game.Data.Turn].Version - 314) / 100.0))) + "." + Strings.Trim(Conversion.Str((object) 10));
          else
            str3 = str2 + "v " + Strings.Trim(Conversion.Str((object) Math.Floor((double) (this.game.Data.RegimeObj[this.game.Data.Turn].Version - 314) / 100.0))) + ".0" + Strings.Trim(Conversion.Str((object) 10));
          if (!Information.IsNothing((object) this.game.Data.RegimeObj[this.game.Data.Turn].subVersion))
            str3 += this.game.Data.RegimeObj[this.game.Data.Turn].subVersion;
          str1 = str3 + "\r\n";
        }
        String1_1 = str1 + "Scenario master version: " + this.game.Data.scenarioVersionMaster + "\r\n" + "[/tab]";
      }
      string str4 = String1_1 + "[tab]Config," + "This game was started with the following variants configuration: \r\n\r\n";
      int num = 0;
      int index1 = 0;
      do
      {
        if (this.game.Data.Variants[index1] > -1)
        {
          string String1_2 = this.game.Data.GameSlotName[this.game.Data.Variants[index1]];
          if (Strings.InStr(String1_2, ",") > 0)
            String1_2 = String1_2.Split(',')[0];
          string str5 = (this.game.Data.GameSlot[this.game.Data.Variants[index1]] <= 0 ? String1_2 + " is off." : String1_2 + " is ON.") + "\r\n";
          str4 += str5;
          ++num;
        }
        ++index1;
      }
      while (index1 <= 11);
      if (num == 0)
        str4 += "No variants selected.";
      int index2 = -1;
      int regimeCounter = this.game.Data.RegimeCounter;
      for (int index3 = 0; index3 <= regimeCounter; ++index3)
      {
        if (this.game.Data.RegimeObj[index3].AI & !this.game.Data.RegimeObj[index3].Sleep)
          index2 = index3;
      }
      if (index2 > -1)
      {
        string str6 = str4 + "\r\n" + "The AI is set to speed level ";
        string str7 = (this.game.Data.RegimeObj[index2].ProdBonus < 250 ? (this.game.Data.RegimeObj[index2].ProdBonus < 100 ? str6 + "FAST" : str6 + "NORMAL") : str6 + "SLOW") + ".\r\n" + "The AI difficulty is set to level ";
        str4 = (this.game.Data.Product != 6 ? (this.game.Data.RegimeObj[index2].AIHelpMove < 50 ? (this.game.Data.RegimeObj[index2].AIHelpMove < 40 ? (this.game.Data.RegimeObj[index2].AIHelpMove < 30 ? (this.game.Data.RegimeObj[index2].AIHelpMove < 20 ? str7 + "NORMAL" : str7 + "CHALLENGING") : str7 + "HARD") : str7 + "VERY HARD") : str7 + "SUPER HARD") : (this.game.Data.RegimeObj[index2].AIHelpCombat < 55 ? (this.game.Data.RegimeObj[index2].AIHelpCombat < 40 ? (this.game.Data.RegimeObj[index2].AIHelpCombat < 25 ? (this.game.Data.RegimeObj[index2].AIHelpCombat < 15 ? str7 + "NORMAL" : str7 + "CHALLENGING") : str7 + "HARD") : str7 + "VERY HARD") : str7 + "SUPER HARD")) + ".\r\n";
      }
      string tText = str4 + "[/tab]";
      if (this.Info1Id == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new TextAreaClass2(this.game, this.w - 40, 16, this.game.MarcFont8, tText, 17, ref this.OwnBitmap, 20, 0, tUseEncy: true);
        this.Info1Id = this.AddSubPart(ref tsubpart, 20, 0, this.w - 14, 306, 0);
      }
      else
        this.SubPartFlag[this.SubpartNr(this.Info1Id)] = true;
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
          if (this.SubPartID[index] != this.Info1Id)
            ;
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
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (this.MouseData[index] > 0 && x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height && this.MouseData[index] == 999)
        {
          this.game.EditObj.SetViewMode2 = 0;
          windowReturnClass.AddCommand(1, 9);
          windowReturnClass.AddCommand(7, 12);
          windowReturnClass.AddCommand(4, 67);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
      {
        if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index] && this.SubPartID[index] == this.Info1Id)
        {
          this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
          this.SubPartFlag[index] = true;
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      if (x > 8 & x < this.w - 8 && y < this.h - 24)
        windowReturnClass.NoMouseClickBelow = true;
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }
  }
}
