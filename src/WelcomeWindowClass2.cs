// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.WelcomeWindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class WelcomeWindowClass2 : WindowClass
  {
    private int BStartGameID;
    private int BLoadGameID;
    private int BSaveGameID;
    private int BRandomID;
    private int BEditorID;
    private int TempText;
    private int TempText2;
    private int txt1;
    private int txt2;
    private int txt3;
    private int opt1;
    private int opt2;
    private int opt3;
    private int opt4;
    private int opt5;
    private int opt6;
    private int opt7;
    private int opt8;
    private int opt9;
    private int opt10;
    private int opt11;
    private int opt12;
    private int opt13;
    private int opt14;
    private int opt15;
    private int opt16;
    private int opt17;
    private int opt18;
    private int opt19;
    private int opt20;
    private int txt4;
    private int cancelID;
    private ListClass RegimeListObj;
    private int RegimeListId;
    private float tempBlink;
    private int detailnr;
    private int phase;
    private int subphase;
    private bool menudirect;
    private int[] opti;
    private int[] txt;
    private bool flagCallToSSeditor;

    public void PopUpRefresh() => this.DoRefresh();

    public WelcomeWindowClass2(
      ref GameClass tGame,
      bool tmenudirect,
      ScreenClass tscreen,
      bool MarcStyle)
      : base(ref tGame, 1024, 768, BackSprite: tGame.BACKGROUND1MARC2)
    {
      this.opti = new int[2];
      this.txt = new int[2];
      this.flagCallToSSeditor = false;
      this.tempBlink = 0.0f;
      this.detailnr = -1;
      this.game.EditObj.TutStep = 0;
      this.game.EditObj.TutOrder = -1;
      this.game.EditObj.LoadingResult = LoadType.None;
      this.game.AIRunning = false;
      this.game.EditObj.AIMoving = false;
      this.opti = new int[this.game.ModCounter + 1];
      this.txt = new int[this.game.ModCounter + 1];
      this.subphase = 0;
      this.phase = 0;
      if (tmenudirect)
        this.menudirect = true;
      this.game.Data.RuleVar[446] = 0.0f;
      if (this.game.EditObj.IntroSoundOn)
        SoundMod.PlayEventBackground(this.game.AppPath + "sound/" + this.game.ModOpeningSoundtrack, ref this.game.EditObj);
      this.DoStuff2();
    }

    public override void HandleToolTip(int x, int y)
    {
      int subPartCounter = this.SubPartCounter;
      for (int index1 = 0; index1 <= subPartCounter; ++index1)
      {
        if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
        {
          int modCounter = this.game.ModCounter;
          for (int index2 = 0; index2 <= modCounter; ++index2)
          {
            if (this.opti[index2] == this.SubPartID[index1])
            {
              if (this.game.ModButType[index2] == 5)
              {
                this.game.EditObj.TipButton = true;
                this.game.EditObj.TipTitle = "QUIT";
                this.game.EditObj.TipText = "Close the game and return to desktop.";
              }
              if (this.game.ModButType[index2] == 16)
              {
                this.game.EditObj.TipButton = true;
                this.game.EditObj.TipTitle = "PBEM++";
                this.game.EditObj.TipText = "Got the PBEM++ screen to start or continue a PBEM++ game.";
              }
              if (this.game.ModButType[index2] == 6)
              {
                this.game.EditObj.TipButton = true;
                this.game.EditObj.TipTitle = "OPEN WEBSITE";
                this.game.EditObj.TipText = "Will attempt to open:\r\n" + this.game.ModButDatastring[index2];
              }
              if (this.game.ModButType[index2] == 14)
              {
                this.game.EditObj.TipButton = true;
                this.game.EditObj.TipTitle = "SEE CREDITS";
                this.game.EditObj.TipText = "Will show you a list of VR Designs and Matrix Games credits";
              }
              if (this.game.ModButType[index2] == 2)
              {
                this.game.EditObj.TipButton = true;
                this.game.EditObj.TipTitle = "LOAD SPECIFIC TUTORIAL";
                this.game.EditObj.TipText = "Will attempt to load tutorial:\r\n" + this.game.ModButDatastring[index2];
              }
              if (this.game.ModButType[index2] == 1)
              {
                this.game.EditObj.TipButton = true;
                this.game.EditObj.TipTitle = "LOAD SPECIFIC SCENARIO";
                this.game.EditObj.TipText = "Will attempt to load scenario:\r\n" + this.game.ModButDatastring[index2];
              }
              if (this.game.ModButType[index2] == 3)
              {
                this.game.EditObj.TipButton = true;
                this.game.EditObj.TipTitle = "LOAD SCENARIO";
                this.game.EditObj.TipText = "Will allow you to select a scenario to load.";
              }
              if (this.game.ModButType[index2] == 12)
              {
                this.game.EditObj.TipButton = true;
                this.game.EditObj.TipTitle = "ADVANCED EDITOR";
                this.game.EditObj.TipText = "Will open the advanced editor.";
              }
              if (this.game.ModButType[index2] == 19)
              {
                this.game.EditObj.TipButton = true;
                this.game.EditObj.TipTitle = "SIMPLE EDITOR";
                this.game.EditObj.TipText = "Will open the simple editor.";
              }
              if (this.game.ModButType[index2] == 20)
              {
                this.game.EditObj.TipButton = true;
                this.game.EditObj.TipTitle = "TROOPTYPE EDITOR";
                this.game.EditObj.TipText = "Will open the trooptype editor.";
              }
              if (this.game.ModButType[index2] == 21)
              {
                this.game.EditObj.TipButton = true;
                this.game.EditObj.TipTitle = "HISTORICAL EDITOR";
                this.game.EditObj.TipText = "Will open the historical units and models editor.";
              }
              if (this.game.ModButType[index2] == 22)
              {
                this.game.EditObj.TipButton = true;
                this.game.EditObj.TipTitle = "OFFICER EDITOR";
                this.game.EditObj.TipText = "Will open the officer editor.";
              }
              if (this.game.ModButType[index2] == 23)
              {
                this.game.EditObj.TipButton = true;
                this.game.EditObj.TipTitle = "MAP EDITOR";
                this.game.EditObj.TipText = "Will open the map editor.";
              }
              if (this.game.ModButType[index2] == 4)
              {
                this.game.EditObj.TipButton = true;
                this.game.EditObj.TipTitle = "LOAD SAVED GAME";
                this.game.EditObj.TipText = "Will allow you to select a saved game to load and continue.";
              }
            }
          }
        }
      }
    }

    public void DoStuff2()
    {
      SizeF sizeF = new SizeF();
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.TextContrast = 1;
      if (this.game.Data.Product == 6)
      {
        ref Graphics local1 = ref objgraphics;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCINTRO2);
        ref Bitmap local2 = ref bitmap;
        int x = (int) Math.Round((double) (1024 - BitmapStore.GetWidth(this.game.MARCINTRO2)) / 2.0);
        DrawMod.DrawSimple(ref local1, ref local2, x, 50);
      }
      else
      {
        ref Graphics local3 = ref objgraphics;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCINTRO2);
        ref Bitmap local4 = ref bitmap;
        int x = (int) Math.Round((double) (1024 - BitmapStore.GetWidth(this.game.MARCINTRO2)) / 2.0);
        DrawMod.DrawSimple(ref local3, ref local4, x, 50);
      }
      string tstring = "v " + Strings.Trim(Conversion.Str((object) Math.Floor(1.1))) + "." + Strings.Trim(Conversion.Str((object) 10)) + " " + Strings.Trim(".04b") + " Shadow Empire : Planetary Conquest. ";
      if (this.game.SuperAdminRights)
        tstring += " + Super Admin Rights";
      DrawMod.DrawTextColouredMarc(ref objgraphics, tstring, this.game.MarcFont4, 25, 732, Color.White);
      this.dobuttons(0);
    }

    public void dobuttons(int top)
    {
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      int modCounter = this.game.ModCounter;
      for (int index1 = 1; index1 <= modCounter; ++index1)
      {
        if (this.opti[index1] == 0)
        {
          int num1 = 1;
          if (this.game.ModButType[index1] == 11)
            num1 = 0;
          if (this.game.ModButType[index1] == 13)
            num1 = 0;
          if (this.game.EditorBlock & this.game.ModButType[index1] == 12)
            num1 = 0;
          if (this.game.EditorBlockSimple & this.game.ModButType[index1] == 19)
            num1 = 0;
          if (this.game.EditorBlockSimple & this.game.ModButType[index1] == 20)
            num1 = 0;
          if (this.game.EditorBlockSimple & this.game.ModButType[index1] == 21)
            num1 = 0;
          if (this.game.EditorBlockSimple & this.game.ModButType[index1] == 22)
            num1 = 0;
          if (this.game.EditorBlockSimple & this.game.ModButType[index1] == 23)
            num1 = 0;
          if (num1 == 1)
          {
            bool flag1 = true;
            if (this.game.ModButActive[index1] == 0)
              flag1 = false;
            bool flag2 = DrawMod.TGame.ModIntroType != 0;
            if (this.game.ModButSize[index1] == 18)
            {
              Font tfont = this.game.MarcFont4;
              if (!flag2)
                tfont = new Font(this.game.FontCol.Families[1], 14f, FontStyle.Regular, GraphicsUnit.Pixel);
              if (flag2)
              {
                DrawMod.DrawTextColouredMarc(ref graphics, this.game.ModButText[index1], tfont, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]), top + this.game.ModButY[index1], Color.White);
                DrawMod.DrawBlock(ref graphics, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]), top + this.game.ModButY[index1] + 20, 200, 2, (int) byte.MaxValue, 0, 0, 200);
              }
              else
              {
                DrawMod.DrawTextColouredOutline(ref graphics, this.game.ModButText[index1], tfont, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]), top + this.game.ModButY[index1], Color.White);
                DrawMod.DrawBlock(ref graphics, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]) + 1, top + this.game.ModButY[index1] + 21, 200, 2, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 200);
                DrawMod.DrawBlock(ref graphics, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]), top + this.game.ModButY[index1] + 20, 200, 2, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 200);
              }
            }
            else if (this.game.ModButSize[index1] == 9)
            {
              Font usefont = this.game.MarcFont2;
              if (!flag2)
                usefont = (Font) null;
              int[] opti = this.opti;
              int index2 = index1;
              SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass(this.game.ModButText[index1], 200, tBackbitmap: (ref this.BackBitmap), bbx: ((int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1])), bby: (top + this.game.ModButY[index1]), tinactive: (!flag1), theight: 50, usefont: usefont, useshadow: flag2, tMarcStyle: flag2);
              int num2 = this.AddSubPart(ref tsubpart, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]), top + this.game.ModButY[index1], 200, 50, 1);
              opti[index2] = num2;
            }
            else if (this.game.ModButSize[index1] == 8)
            {
              Font usefont = this.game.MarcFont4;
              if (!flag2)
                usefont = (Font) null;
              int[] opti = this.opti;
              int index3 = index1;
              SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass(this.game.ModButText[index1], 200, tBackbitmap: (ref this.BackBitmap), bbx: ((int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1])), bby: (top + this.game.ModButY[index1]), tinactive: (!flag1), theight: 25, usefont: usefont, useshadow: flag2, tMarcStyle: flag2);
              int num3 = this.AddSubPart(ref tsubpart, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]), top + this.game.ModButY[index1], 200, 25, 1);
              opti[index3] = num3;
            }
            else if (this.game.ModButSize[index1] == 7)
            {
              Font usefont = this.game.MarcFont3;
              if (!flag2)
                usefont = (Font) null;
              int[] opti = this.opti;
              int index4 = index1;
              SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass(this.game.ModButText[index1], 200, tBackbitmap: (ref this.BackBitmap), bbx: ((int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1])), bby: (top + this.game.ModButY[index1]), tinactive: (!flag1), theight: 30, usefont: usefont, useshadow: flag2, tMarcStyle: flag2);
              int num4 = this.AddSubPart(ref tsubpart, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]), top + this.game.ModButY[index1], 200, 30, 1);
              opti[index4] = num4;
            }
            else if (this.game.ModButSize[index1] == 6)
            {
              Font usefont = this.game.MarcFont2;
              if (!flag2)
                usefont = (Font) null;
              int[] opti = this.opti;
              int index5 = index1;
              SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass(this.game.ModButText[index1], 250, tBackbitmap: (ref this.BackBitmap), bbx: ((int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1])), bby: (top + this.game.ModButY[index1]), tinactive: (!flag1), theight: 50, usefont: usefont, useshadow: flag2, tMarcStyle: flag2);
              int num5 = this.AddSubPart(ref tsubpart, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]), top + this.game.ModButY[index1], 250, 50, 1);
              opti[index5] = num5;
            }
            else if (this.game.ModButSize[index1] == 5)
            {
              Font usefont = this.game.MarcFont1;
              if (!flag2)
                usefont = (Font) null;
              int[] opti = this.opti;
              int index6 = index1;
              SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass(this.game.ModButText[index1], 250, tBackbitmap: (ref this.BackBitmap), bbx: ((int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1])), bby: (top + this.game.ModButY[index1]), tinactive: (!flag1), theight: 50, usefont: usefont, useshadow: flag2, tMarcStyle: flag2);
              int num6 = this.AddSubPart(ref tsubpart, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]), top + this.game.ModButY[index1], 250, 50, 1);
              opti[index6] = num6;
            }
            else if (this.game.ModButSize[index1] == 4)
            {
              int[] opti = this.opti;
              int index7 = index1;
              SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass(this.game.ModButText[index1], 400, tBackbitmap: (ref this.BackBitmap), bbx: ((int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1])), bby: (top + this.game.ModButY[index1]), tinactive: (!flag1), theight: 50, tfontsize: 16, tMarcStyle: flag2);
              int num7 = this.AddSubPart(ref tsubpart, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]), top + this.game.ModButY[index1], 400, 50, 1);
              opti[index7] = num7;
            }
            else if (this.game.ModButSize[index1] == 3)
            {
              int[] opti = this.opti;
              int index8 = index1;
              SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass(this.game.ModButText[index1], 300, tBackbitmap: (ref this.BackBitmap), bbx: ((int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1])), bby: (top + this.game.ModButY[index1]), tinactive: (!flag1), tfontsize: 14, tMarcStyle: flag2);
              int num8 = this.AddSubPart(ref tsubpart, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]), top + this.game.ModButY[index1], 300, 35, 1);
              opti[index8] = num8;
            }
            else if (this.game.ModButSize[index1] == 2)
            {
              int[] opti = this.opti;
              int index9 = index1;
              SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass(this.game.ModButText[index1], 200, tBackbitmap: (ref this.BackBitmap), bbx: ((int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1])), bby: (top + this.game.ModButY[index1]), tinactive: (!flag1), theight: 25, tfontsize: 12, tMarcStyle: flag2);
              int num9 = this.AddSubPart(ref tsubpart, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]), top + this.game.ModButY[index1], 200, 25, 1);
              opti[index9] = num9;
            }
            else if (this.game.ModButSize[index1] == 1)
            {
              int[] opti = this.opti;
              int index10 = index1;
              SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass(this.game.ModButText[index1], 100, tBackbitmap: (ref this.BackBitmap), bbx: ((int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1])), bby: (top + this.game.ModButY[index1]), tinactive: (!flag1), theight: 15, tfontsize: 10, tMarcStyle: flag2);
              int num10 = this.AddSubPart(ref tsubpart, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]), top + this.game.ModButY[index1], 100, 15, 1);
              opti[index10] = num10;
            }
          }
        }
      }
    }

    public override WindowReturnClass handleTimer()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.game.EditObj.LoadingResult == LoadType.RandomScreen)
      {
        windowReturnClass.AddCommand(3, 23);
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      if (this.flagCallToSSeditor)
      {
        this.flagCallToSSeditor = false;
        windowReturnClass.AddCommand(3, 25);
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      if (this.game.EditObj.LoadingResult == LoadType.FirstScreen)
      {
        this.game.EditObj.LoadingResult = LoadType.None;
        if (".se1map".Length > 0 & Strings.InStr(this.game.EditObj.LoadFileName, ".se1map") > 0)
          windowReturnClass.AddCommand(3, 21);
        else if (".se1evlib".Length > 0 & Strings.InStr(this.game.EditObj.LoadFileName, ".se1evlib") > 0)
        {
          windowReturnClass.AddCommand(3, 12);
          this.game.Data.SimpleEditor = false;
        }
        else if (".se1his".Length > 0 & Strings.InStr(this.game.EditObj.LoadFileName, ".se1his") > 0)
          windowReturnClass.AddCommand(3, 19);
        else if (".se1offcard".Length > 0 & Strings.InStr(this.game.EditObj.LoadFileName, ".se1offcard") > 0)
        {
          windowReturnClass.AddCommand(3, 12);
          this.game.Data.SimpleEditor = false;
        }
        else if (".se1off".Length > 0 & Strings.InStr(this.game.EditObj.LoadFileName, ".se1off") > 0)
          windowReturnClass.AddCommand(3, 20);
        else if (".se1troops".Length > 0 & Strings.InStr(this.game.EditObj.LoadFileName, ".se1troops") > 0)
          windowReturnClass.AddCommand(3, 18);
        else if (".se1master".Length > 0 & Strings.InStr(this.game.EditObj.LoadFileName, ".se1master") > 0)
        {
          windowReturnClass.AddCommand(3, 12);
          this.game.Data.SimpleEditor = false;
        }
        else
          windowReturnClass.AddCommand(3, 12);
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      if (this.game.EditObj.LoadingResult == LoadType.PlayScreen)
      {
        this.game.EditObj.LoadingResult = LoadType.None;
        windowReturnClass.AddCommand(3, 11);
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      if (this.game.EditObj.LoadingResult != LoadType.GameLoop)
        return windowReturnClass;
      this.game.EditObj.LoadingResult = LoadType.None;
      windowReturnClass.AddCommand(3, 13);
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false) => new WindowReturnClass();

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      if (this.SubPartCounter <= -1)
      {
        WindowReturnClass windowReturnClass2;
        return windowReturnClass2;
      }
      int subPartCounter = this.SubPartCounter;
      for (int index1 = 0; index1 <= subPartCounter; ++index1)
      {
        if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
        {
          int modCounter = this.game.ModCounter;
          for (int index2 = 1; index2 <= modCounter; ++index2)
          {
            if (this.opti[index2] == this.SubPartID[index1])
            {
              this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              if (this.game.ModButType[index2] == 5)
              {
                SoundMod.StopWave();
                SoundMod.EndSound();
                this.game = (GameClass) null;
                ProjectData.EndApp();
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.ModButType[index2] == 16)
              {
                int num1 = (int) Interaction.MsgBox((object) "PBEM++ not supported for this game", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                if (this.game.ModButType[index2] == 15)
                {
                  this.ImportSe1Zip();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.game.ModButType[index2] == 14)
                {
                  DrawMod.TGame.EditObj.PopupValue = 9;
                  windowReturnClass1.AddCommand(5, 14);
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.game.ModButType[index2] == 24)
                {
                  DrawMod.TGame.EditObj.PopupValue = 20;
                  windowReturnClass1.AddCommand(5, 14);
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.game.ModButType[index2] == 34)
                {
                  DrawMod.TGame.EditObj.PopupValue = 34;
                  windowReturnClass1.AddCommand(5, 14);
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.game.ModButType[index2] == 6)
                {
                  try
                  {
                    Process.Start(this.game.ModButDatastring[index2]);
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    int num2 = (int) Interaction.MsgBox((object) "Your system does not allow Shadow Empire : Planetary Conquest to open a browser.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    ProjectData.ClearProjectError();
                  }
                  return windowReturnClass1;
                }
                if (this.game.ModButType[index2] != 11 && this.game.ModButType[index2] != 13)
                {
                  if (this.game.ModButType[index2] == 12)
                  {
                    string str1 = Conversions.ToString(Conversion.Val(Interaction.InputBox("Give width of map in hexes (10-200)", "Shadow Empire : Planetary Conquest", "20")));
                    int twidth = Operators.CompareString(Strings.Trim(str1), "", false) == 0 ? 0 : Conversions.ToInteger(str1);
                    string str2 = Conversions.ToString(Conversion.Val(Interaction.InputBox("Give height of map in hexes (10-200)", "Shadow Empire : Planetary Conquest", "20")));
                    int theight = Operators.CompareString(Strings.Trim(str2), "", false) == 0 ? 0 : Conversions.ToInteger(str2);
                    if (twidth < 10 | theight < 10 | twidth > 200 | theight > 200)
                    {
                      int num3 = (int) Interaction.MsgBox((object) "Cannot comply. Width and Height must be between 10 and 200", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      return windowReturnClass1;
                    }
                    this.game.FormRef.Cursor = Cursors.WaitCursor;
                    this.game.EditObj = new EditClass(this.game.AppPath + "editobj.txt");
                    if (Information.IsNothing((object) this.game.NewAIObj))
                      this.game.NewAIObj = new NewAIClass(this.game);
                    if (this.game.Data.UseAI == 1)
                      this.game.NewAIObj.LastRegime = -1;
                    this.game.Data = new DataClass(twidth, theight);
                    this.game.Data.MasterFile = this.game.ModButDatastring[index2];
                    this.game.HandyFunctionsObj.LoadMasterFile(this.game.AppPath + this.game.ModScenarioDir + "/" + this.game.Data.MasterFile);
                    BitmapStore.ReloadSystemGraphics(this.game.Data.SystemGfx);
                    this.game.Data.LoadGraphics((Form1) null);
                    this.game.SelectX = 0;
                    this.game.SelectY = 0;
                    this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, 200, 150, false);
                    this.game.FormRef.Cursor = Cursors.Default;
                    SoundMod.StopWave();
                    windowReturnClass1.AddCommand(3, 2);
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
                  }
                  if (this.game.ModButType[index2] == 19)
                  {
                    this.game.FormRef.Cursor = Cursors.WaitCursor;
                    this.game.EditObj = new EditClass(this.game.AppPath + "editobj.txt");
                    if (this.game.Data.UseAI == 1)
                    {
                      if (Information.IsNothing((object) this.game.NewAIObj))
                        this.game.NewAIObj = new NewAIClass(this.game);
                      this.game.NewAIObj.LastRegime = -1;
                    }
                    this.game.Data = new DataClass(0, 0);
                    this.game.Data.MasterFile = this.game.ModButDatastring[index2];
                    this.game.HandyFunctionsObj.LoadMasterFile(this.game.AppPath + this.game.ModScenarioDir + "/" + this.game.Data.MasterFile);
                    BitmapStore.ReloadSystemGraphics(this.game.Data.SystemGfx);
                    this.game.Data.LoadGraphics((Form1) null);
                    this.game.SelectX = 0;
                    this.game.SelectY = 0;
                    this.game.Data.SimpleEditor = true;
                    this.game.EditObj.inSimpleMapEditor = false;
                    this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, 200, 150, false);
                    this.game.FormRef.Cursor = Cursors.Default;
                    SoundMod.StopWave();
                    windowReturnClass1.AddCommand(3, 17);
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
                  }
                  if (this.game.ModButType[index2] == 31)
                  {
                    string str = this.game.AppPath + this.game.ModScenarioDir + "/" + this.game.ModButDatastring[index2];
                    this.game.FormRef.Cursor = Cursors.WaitCursor;
                    this.game.EditObj.systemPopup = false;
                    this.game.EditObj.TutMode = false;
                    if (File.Exists(str))
                    {
                      this.flagCallToSSeditor = true;
                      this.game.EditObj.LoadFileName = str;
                      this.game.EditObj.PopupValue = 17;
                      windowReturnClass1.AddCommand(5, 14);
                      this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                    if (Strings.Len(str) > 1)
                    {
                      int num4 = (int) Interaction.MsgBox((object) "File could not be found or op. is cancelled.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                    return windowReturnClass1;
                  }
                  if (this.game.ModButType[index2] == 20)
                  {
                    this.game.FormRef.Cursor = Cursors.WaitCursor;
                    this.game.EditObj = new EditClass(this.game.AppPath + "editobj.txt");
                    if (this.game.Data.UseAI == 1)
                    {
                      if (Information.IsNothing((object) this.game.NewAIObj))
                        this.game.NewAIObj = new NewAIClass(this.game);
                      this.game.NewAIObj.LastRegime = -1;
                    }
                    this.game.Data = new DataClass(0, 0);
                    this.game.Data.MasterFile = this.game.ModButDatastring[index2];
                    this.game.HandyFunctionsObj.LoadMasterFile(this.game.AppPath + this.game.ModScenarioDir + "/" + this.game.Data.MasterFile);
                    BitmapStore.ReloadSystemGraphics(this.game.Data.SystemGfx);
                    this.game.Data.LoadGraphics((Form1) null);
                    this.game.SelectX = 0;
                    this.game.SelectY = 0;
                    this.game.Data.SimpleEditor = true;
                    this.game.EditObj.inSimpleMapEditor = false;
                    this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, 200, 150, false);
                    this.game.FormRef.Cursor = Cursors.Default;
                    SoundMod.StopWave();
                    windowReturnClass1.AddCommand(3, 18);
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
                  }
                  if (this.game.ModButType[index2] == 21)
                  {
                    this.game.FormRef.Cursor = Cursors.WaitCursor;
                    this.game.EditObj = new EditClass(this.game.AppPath + "editobj.txt");
                    if (this.game.Data.UseAI == 1)
                    {
                      if (Information.IsNothing((object) this.game.NewAIObj))
                        this.game.NewAIObj = new NewAIClass(this.game);
                      this.game.NewAIObj.LastRegime = -1;
                    }
                    this.game.Data = new DataClass(0, 0);
                    this.game.Data.MasterFile = this.game.ModButDatastring[index2];
                    this.game.HandyFunctionsObj.LoadMasterFile(this.game.AppPath + this.game.ModScenarioDir + "/" + this.game.Data.MasterFile);
                    BitmapStore.ReloadSystemGraphics(this.game.Data.SystemGfx);
                    this.game.Data.LoadGraphics((Form1) null);
                    this.game.SelectX = 0;
                    this.game.SelectY = 0;
                    this.game.Data.SimpleEditor = true;
                    this.game.EditObj.inSimpleMapEditor = false;
                    this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, 200, 150, false);
                    this.game.FormRef.Cursor = Cursors.Default;
                    SoundMod.StopWave();
                    windowReturnClass1.AddCommand(3, 19);
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
                  }
                  if (this.game.ModButType[index2] == 22)
                  {
                    this.game.FormRef.Cursor = Cursors.WaitCursor;
                    this.game.EditObj = new EditClass(this.game.AppPath + "editobj.txt");
                    if (this.game.Data.UseAI == 1)
                    {
                      if (Information.IsNothing((object) this.game.NewAIObj))
                        this.game.NewAIObj = new NewAIClass(this.game);
                      this.game.NewAIObj.LastRegime = -1;
                    }
                    this.game.Data = new DataClass(0, 0);
                    this.game.Data.MasterFile = this.game.ModButDatastring[index2];
                    this.game.HandyFunctionsObj.LoadMasterFile(this.game.AppPath + this.game.ModScenarioDir + "/" + this.game.Data.MasterFile);
                    BitmapStore.ReloadSystemGraphics(this.game.Data.SystemGfx);
                    this.game.Data.LoadGraphics((Form1) null);
                    this.game.SelectX = 0;
                    this.game.SelectY = 0;
                    this.game.Data.SimpleEditor = true;
                    this.game.EditObj.inSimpleMapEditor = false;
                    this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, 200, 150, false);
                    this.game.FormRef.Cursor = Cursors.Default;
                    SoundMod.StopWave();
                    windowReturnClass1.AddCommand(3, 20);
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
                  }
                  if (this.game.ModButType[index2] == 23)
                  {
                    this.game.FormRef.Cursor = Cursors.WaitCursor;
                    this.game.EditObj = new EditClass(this.game.AppPath + "editobj.txt");
                    if (this.game.Data.UseAI == 1)
                    {
                      if (Information.IsNothing((object) this.game.NewAIObj))
                        this.game.NewAIObj = new NewAIClass(this.game);
                      this.game.NewAIObj.LastRegime = -1;
                    }
                    this.game.Data = new DataClass(0, 0);
                    this.game.Data.MasterFile = this.game.ModButDatastring[index2];
                    this.game.HandyFunctionsObj.LoadMasterFile(this.game.AppPath + this.game.ModScenarioDir + "/" + this.game.Data.MasterFile);
                    BitmapStore.ReloadSystemGraphics(this.game.Data.SystemGfx);
                    this.game.Data.LoadGraphics((Form1) null);
                    this.game.SelectX = 0;
                    this.game.SelectY = 0;
                    this.game.Data.SimpleEditor = true;
                    this.game.EditObj.inSimpleMapEditor = true;
                    this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, 200, 150, false);
                    this.game.FormRef.Cursor = Cursors.Default;
                    SoundMod.StopWave();
                    windowReturnClass1.AddCommand(3, 21);
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
                  }
                  if (this.game.ModButType[index2] <= 4)
                  {
                    this.game.EditObj.systemPopup = true;
                    string str;
                    if (this.game.ModButType[index2] <= 2)
                      str = this.game.AppPath + this.game.ModButDatastring[index2];
                    else if (this.game.ModButType[index2] == 3)
                    {
                      if (!this.game.EditorBlock & !this.game.EditorBlockSimple)
                      {
                        string tfilter = "SE1 Scenario file (*.se1)|*.se1|SE1 Map file(*.se1map)|*.se1map|SE1 Master file(*.se1master)|*.se1master|SE1 Event library(*.se1evlib)|*.se1evlib|SE1 Troops&Equipment library(*.se1troops)|*.se1troops|SE1 Historical library(*.se1his)|*.se1his|SE1 Officer Card Library(*.se1offcard)|*.se1offcard|SE1 Officer library(*.se1off)|*.se1off";
                        if (this.game.SuperAdminRights)
                          tfilter += "|Any file(*.*)|*.*";
                        str = this.game.HandyFunctionsObj.LoadSomething(tfilter, "Pick a scenario to load...", this.game.AppPath + this.game.ModButDatastring[index2], false);
                      }
                      else
                        str = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a scenario to load...", this.game.AppPath + this.game.ModButDatastring[index2], false);
                    }
                    else
                      str = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a scenario to load...", this.game.AppPath_SAVEGAMES, false);
                    this.game.EditObj.systemPopup = false;
                    this.game.EditObj.TutMode = false;
                    if (File.Exists(str))
                    {
                      this.game.EditObj.LoadFileName = str;
                      if (this.game.ModButType[index2] == 2)
                        this.game.EditObj.TutMode = true;
                      if (this.game.ModButType[index2] == 1)
                        this.game.EditObj.ButtonLoadMode = true;
                      this.game.EditObj.PopupValue = 17;
                      windowReturnClass1.AddCommand(5, 14);
                      this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                    if (Strings.Len(str) > 1)
                    {
                      int num5 = (int) Interaction.MsgBox((object) "File could not be found or op. is cancelled.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                    return windowReturnClass1;
                  }
                }
              }
            }
          }
          return windowReturnClass1;
        }
      }
      windowReturnClass1.SetFlag(false);
      return windowReturnClass1;
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    public void Import()
    {
      this.game.EditObj.FindModFile = false;
      this.game.EditObj.ZipFileText = Conversions.ToString(false);
      this.game.EditObj.systemPopup = true;
      string str = this.game.HandyFunctionsObj.LoadSomething("All files|*.*", "Pick a zip archive or scenario file to install...", this.game.AppPath, false);
      this.game.EditObj.systemPopup = false;
      if (Information.IsNothing((object) str))
        return;
      if (Strings.InStr(str, ".zip") > 0 | Strings.InStr(str, ".dczip") > 0)
      {
        int num1 = (int) Interaction.MsgBox((object) "Hold on... this can take some time", Title: ((object) "Shadow Empire : Planetary Conquest"));
        this.game.FormRef.Cursor = Cursors.WaitCursor;
        try
        {
          this.game.HandyFunctionsObj.UnzipImport(str);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num2 = (int) Interaction.MsgBox((object) ("Error in unpacking. " + ex.ToString()), Title: ((object) "Shadow Empire : Planetary Conquest"));
          ProjectData.ClearProjectError();
          return;
        }
        this.game.FormRef.Cursor = Cursors.Default;
        int num3 = (int) Interaction.MsgBox((object) "Succesfully unpacked the .zip archive.", Title: ((object) "Shadow Empire : Planetary Conquest"));
        if (this.game.EditObj.ZipFileText.Length > 1)
        {
          int num4 = (int) Interaction.MsgBox((object) ("README INCLUDED IN ZIPFILE:\r\n\r\n" + this.game.EditObj.ZipFileText), Title: ((object) "Shadow Empire : Planetary Conquest"));
        }
        if (this.game.EditObj.FindModFile && Interaction.MsgBox((object) "You are advised to quit now and restart the game. Do you want to do so?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
        {
          SoundMod.StopWave();
          SoundMod.EndSound();
          this.game = (GameClass) null;
          ProjectData.EndApp();
        }
      }
      else if (!Information.IsNothing((object) str))
      {
        string path = this.game.AppPath + this.game.ModScenarioDir + "/DOWNLOADED_SCENARIOS/";
        if (!Directory.Exists(path))
          Directory.CreateDirectory(path);
        string destFileName = path + Path.GetFileName(str);
        File.Copy(str, destFileName);
        int num = (int) Interaction.MsgBox((object) "Succesfully placed the file in the downloaded scenarios directory.", Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
      BitmapStore.ReloadSystemGraphics(this.game.Data.SystemGfx, true);
    }

    public void ImportSe1Zip()
    {
      this.game.EditObj.FindModFile = false;
      this.game.EditObj.ZipFileText = Conversions.ToString(false);
      this.game.EditObj.systemPopup = true;
      string str = this.game.HandyFunctionsObj.LoadSomething("Se1Zip Files|*.se1zip|Normal Zip File|*.zip", "Pick a zip archive or scenario file to install...", this.game.AppPath, false);
      this.game.EditObj.systemPopup = false;
      if (Information.IsNothing((object) str) || !(Strings.InStr(str, ".zip") > 0 | Strings.InStr(str, ".se1zip") > 0))
        return;
      int num1 = (int) Interaction.MsgBox((object) "Hold on... this can take some time", Title: ((object) "Shadow Empire : Planetary Conquest"));
      this.game.FormRef.Cursor = Cursors.WaitCursor;
      try
      {
        this.game.HandyFunctionsObj.UnzipImport(str);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num2 = (int) Interaction.MsgBox((object) ("Error in unpacking. " + ex.ToString()), Title: ((object) "Shadow Empire : Planetary Conquest"));
        ProjectData.ClearProjectError();
        return;
      }
      this.game.modlib_Initialize();
      this.game.modlib_loadPrefs();
      this.game.FormRef.Cursor = Cursors.Default;
      int num3 = (int) Interaction.MsgBox((object) "Succesfully unpacked the archive.", Title: ((object) "Shadow Empire : Planetary Conquest"));
    }
  }
}
