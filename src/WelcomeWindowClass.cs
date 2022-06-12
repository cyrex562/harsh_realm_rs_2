// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.WelcomeWindowClass
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
  public class WelcomeWindowClass : WindowClass
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

    public void PopUpRefresh() => this.DoRefresh();

    public WelcomeWindowClass(
      ref GameClass tGame,
      bool tmenudirect,
      ScreenClass tscreen,
      bool MarcStyle)
      : base(ref tGame, 1024, 768, BackSprite: tGame.BACKGROUND4MARC)
    {
      this.opti = new int[2];
      this.txt = new int[2];
      this.tempBlink = 0.0f;
      this.detailnr = -1;
      this.game.EditObj.TutMode = false;
      this.game.EditObj.TutStep = 0;
      this.game.EditObj.TutOrder = -1;
      this.game.AIRunning = false;
      this.game.EditObj.AIMoving = false;
      this.opti = new int[this.game.ModCounter + 1];
      this.txt = new int[this.game.ModCounter + 1];
      this.subphase = 0;
      this.phase = 0;
      if (tmenudirect)
        this.menudirect = true;
      if (this.game.EditObj.IntroSoundOn)
        SoundMod.PlayEventBackground(this.game.AppPath + "sound/" + this.game.ModOpeningSoundtrack, ref this.game.EditObj);
      this.DoStuff2();
    }

    public WelcomeWindowClass(ref GameClass tGame, bool tmenudirect, ScreenClass tscreen)
      : base(ref tGame, 1024, 768, BackSprite: tGame.BACKGROUND4MARC)
    {
      this.opti = new int[2];
      this.txt = new int[2];
      this.tempBlink = 0.0f;
      this.detailnr = -1;
      this.game.EditObj.TutMode = false;
      this.game.EditObj.TutStep = 0;
      this.game.EditObj.TutOrder = -1;
      this.opti = new int[this.game.ModCounter + 1];
      this.txt = new int[this.game.ModCounter + 1];
      this.subphase = 0;
      this.phase = 0;
      if (tmenudirect)
        this.menudirect = true;
      if (this.game.EditObj.IntroSoundOn)
        SoundMod.PlayEventBackground(this.game.AppPath + "sound/" + this.game.ModOpeningSoundtrack, ref this.game.EditObj);
      this.DoStuff();
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

    public void DoStuff()
    {
      SizeF sizeF = new SizeF();
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.TextContrast = 1;
      string tstring = "v " + Conversion.Str((object) 110) + Strings.Trim(".04b");
      DrawMod.DrawTextColouredMarc(ref objgraphics, tstring, this.game.GameFont1, 5, 5, Color.White);
      this.dobuttons(0);
    }

    public void DoStuff2()
    {
      SizeF sizeF1 = new SizeF();
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      graphics.TextContrast = 1;
      ref Graphics local1 = ref graphics;
      Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCINTRO2);
      ref Bitmap local2 = ref bitmap;
      int x = (int) Math.Round((double) (1024 - BitmapStore.GetWidth(this.game.MARCINTRO2)) / 2.0);
      DrawMod.DrawSimple(ref local1, ref local2, x, 50);
      string str1 = "v " + Strings.Trim(Conversion.Str((object) 110)) + Strings.Trim(".04b");
      DrawMod.DrawTextColouredMarc(ref graphics, str1, this.game.GameFont1, 5, 5, Color.White);
      SizeF sizeF2 = graphics.MeasureString(str1, this.game.GameFont1);
      DrawMod.DrawBlock(ref graphics, 5, 25, (int) Math.Round((double) sizeF2.Width), (int) Math.Round((double) sizeF2.Height), (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      DrawMod.DrawTextColoured(ref graphics, str1, this.game.GameFont1, 5, 25, Color.Black);
      string str2 = "Please remember: Scenarios saved with this editor can only be loaded in this editor! Distribution has to go through Vic! :)";
      SizeF sizeF3 = graphics.MeasureString(str2, this.game.GameFont1);
      DrawMod.DrawBlock(ref graphics, 5, 50, (int) Math.Round((double) sizeF3.Width), (int) Math.Round((double) sizeF3.Height), 0, 0, 200, (int) byte.MaxValue);
      DrawMod.DrawTextColoured(ref graphics, str2, this.game.GameFont1, 5, 50, Color.White);
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
          bool flag1 = true;
          if (this.game.ModButActive[index1] == 0)
            flag1 = false;
          bool flag2 = DrawMod.TGame.ModIntroType != 0;
          if (this.game.ModButSize[index1] == 18)
          {
            Font tfont = this.game.MarcFont4;
            if (!flag2)
              tfont = new Font("Arial", 14f, FontStyle.Regular, GraphicsUnit.Pixel);
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
          else if (this.game.ModButSize[index1] == 8)
          {
            Font usefont = this.game.MarcFont4;
            if (!flag2)
              usefont = (Font) null;
            int[] opti = this.opti;
            int index2 = index1;
            SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass(this.game.ModButText[index1], 200, tBackbitmap: (ref this.BackBitmap), bbx: ((int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1])), bby: (top + this.game.ModButY[index1]), tinactive: (!flag1), theight: 25, usefont: usefont, useshadow: flag2, tMarcStyle: flag2);
            int num = this.AddSubPart(ref tsubpart, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]), top + this.game.ModButY[index1], 200, 25, 1);
            opti[index2] = num;
          }
          else if (this.game.ModButSize[index1] == 7)
          {
            Font usefont = this.game.MarcFont3;
            if (!flag2)
              usefont = (Font) null;
            int[] opti = this.opti;
            int index3 = index1;
            SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass(this.game.ModButText[index1], 200, tBackbitmap: (ref this.BackBitmap), bbx: ((int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1])), bby: (top + this.game.ModButY[index1]), tinactive: (!flag1), theight: 30, usefont: usefont, useshadow: flag2, tMarcStyle: flag2);
            int num = this.AddSubPart(ref tsubpart, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]), top + this.game.ModButY[index1], 200, 30, 1);
            opti[index3] = num;
          }
          else if (this.game.ModButSize[index1] == 6)
          {
            Font usefont = this.game.MarcFont2;
            if (!flag2)
              usefont = (Font) null;
            int[] opti = this.opti;
            int index4 = index1;
            SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass(this.game.ModButText[index1], 250, tBackbitmap: (ref this.BackBitmap), bbx: ((int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1])), bby: (top + this.game.ModButY[index1]), tinactive: (!flag1), theight: 50, usefont: usefont, useshadow: flag2, tMarcStyle: flag2);
            int num = this.AddSubPart(ref tsubpart, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]), top + this.game.ModButY[index1], 250, 50, 1);
            opti[index4] = num;
          }
          else if (this.game.ModButSize[index1] == 5)
          {
            Font usefont = this.game.MarcFont1;
            if (!flag2)
              usefont = (Font) null;
            int[] opti = this.opti;
            int index5 = index1;
            SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass(this.game.ModButText[index1], 250, tBackbitmap: (ref this.BackBitmap), bbx: ((int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1])), bby: (top + this.game.ModButY[index1]), tinactive: (!flag1), theight: 50, usefont: usefont, useshadow: flag2, tMarcStyle: flag2);
            int num = this.AddSubPart(ref tsubpart, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]), top + this.game.ModButY[index1], 250, 50, 1);
            opti[index5] = num;
          }
          else if (this.game.ModButSize[index1] == 4)
          {
            int[] opti = this.opti;
            int index6 = index1;
            SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass(this.game.ModButText[index1], 400, tBackbitmap: (ref this.BackBitmap), bbx: ((int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1])), bby: (top + this.game.ModButY[index1]), tinactive: (!flag1), theight: 50, tfontsize: 16, tMarcStyle: flag2);
            int num = this.AddSubPart(ref tsubpart, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]), top + this.game.ModButY[index1], 400, 50, 1);
            opti[index6] = num;
          }
          else if (this.game.ModButSize[index1] == 3)
          {
            int[] opti = this.opti;
            int index7 = index1;
            SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass(this.game.ModButText[index1], 300, tBackbitmap: (ref this.BackBitmap), bbx: ((int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1])), bby: (top + this.game.ModButY[index1]), tinactive: (!flag1), tfontsize: 14, tMarcStyle: flag2);
            int num = this.AddSubPart(ref tsubpart, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]), top + this.game.ModButY[index1], 300, 35, 1);
            opti[index7] = num;
          }
          else if (this.game.ModButSize[index1] == 2)
          {
            int[] opti = this.opti;
            int index8 = index1;
            SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass(this.game.ModButText[index1], 200, tBackbitmap: (ref this.BackBitmap), bbx: ((int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1])), bby: (top + this.game.ModButY[index1]), tinactive: (!flag1), theight: 25, tfontsize: 12, tMarcStyle: flag2);
            int num = this.AddSubPart(ref tsubpart, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]), top + this.game.ModButY[index1], 200, 25, 1);
            opti[index8] = num;
          }
          else if (this.game.ModButSize[index1] == 1)
          {
            int[] opti = this.opti;
            int index9 = index1;
            SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass(this.game.ModButText[index1], 100, tBackbitmap: (ref this.BackBitmap), bbx: ((int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1])), bby: (top + this.game.ModButY[index1]), tinactive: (!flag1), theight: 15, tfontsize: 10, tMarcStyle: flag2);
            int num = this.AddSubPart(ref tsubpart, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + (double) this.game.ModButX[index1]), top + this.game.ModButY[index1], 100, 15, 1);
            opti[index9] = num;
          }
        }
      }
    }

    public override WindowReturnClass handleTimer()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.game.ModIntroType == 1)
        return windowReturnClass;
      if (this.subphase < 9999)
      {
        ++this.subphase;
        this.DoStuff();
      }
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
              if (this.game.ModButType[index2] == 5)
              {
                SoundMod.StopWave();
                SoundMod.EndSound();
                this.game = (GameClass) null;
                ProjectData.EndApp();
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.ModButType[index2] == 14)
              {
                DrawMod.TGame.EditObj.PopupValue = 9;
                windowReturnClass1.AddCommand(5, 10);
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
                  int num = (int) Interaction.MsgBox((object) "Your system does not allow Shadow Empire : Planetary Conquest to open a browser.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  ProjectData.ClearProjectError();
                }
                return windowReturnClass1;
              }
              if (this.game.ModButType[index2] == 11)
              {
                this.game.EditObj.RandomUseMaster = this.game.ModButDatastring[index2];
                this.game.EditObj.RandomSettingsFromMod = this.game.ModButDatastring2[index2];
                this.game.EditObj.ShortRandomScreen = false;
                windowReturnClass1.AddCommand(1, 49);
                windowReturnClass1.AddCommand(2, 50);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.ModButType[index2] == 13)
              {
                this.game.EditObj.RandomUseMaster = this.game.ModButDatastring[index2];
                this.game.EditObj.RandomSettingsFromMod = this.game.ModButDatastring2[index2];
                this.game.EditObj.ShortRandomScreen = true;
                windowReturnClass1.AddCommand(1, 49);
                windowReturnClass1.AddCommand(2, 50);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.ModButType[index2] == 15)
              {
                this.Import();
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.ModButType[index2] == 12)
              {
                string str1 = Conversions.ToString(Conversion.Val(Interaction.InputBox("Give width of map in hexes (10-200)", "Shadow Empire : Planetary Conquest", "20")));
                int twidth = Operators.CompareString(Strings.Trim(str1), "", false) == 0 ? 0 : Conversions.ToInteger(str1);
                string str2 = Conversions.ToString(Conversion.Val(Interaction.InputBox("Give height of map in hexes (10-200)", "Shadow Empire : Planetary Conquest", "20")));
                int theight = Operators.CompareString(Strings.Trim(str2), "", false) == 0 ? 0 : Conversions.ToInteger(str2);
                if (twidth < 10 | theight < 10 | twidth > 200 | theight > 200)
                {
                  int num = (int) Interaction.MsgBox((object) "Cannot comply. Width and Height must be between 10 and 200", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  return windowReturnClass1;
                }
                this.game.FormRef.Cursor = Cursors.WaitCursor;
                this.game.EditObj = new EditClass(this.game.AppPath + "editobj.txt");
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
              if (this.game.ModButType[index2] <= 4)
              {
                string str = this.game.ModButType[index2] > 2 ? (this.game.ModButType[index2] != 3 ? this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a scenario to load...", this.game.AppPath_SAVEGAMES, false) : this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a scenario to load...", this.game.AppPath + this.game.ModButDatastring[index2], false)) : this.game.AppPath + this.game.ModButDatastring[index2];
                if (File.Exists(str))
                {
                  this.game.FormRef.Cursor = Cursors.WaitCursor;
                  this.game.EditObj = new EditClass(this.game.AppPath + "editobj.txt");
                  if (this.game.ModButType[index2] == 2)
                    this.game.EditObj.TutMode = true;
                  else
                    this.game.EditObj.TutMode = false;
                  if (this.game.Data.UseAI == 1)
                    this.game.NewAIObj.LastRegime = -1;
                  this.game.SelectX = -1;
                  this.game.SelectY = -1;
                  this.game.Data = new DataClass();
                  GC.Collect();
                  Application.DoEvents();
                  this.game.HandyFunctionsObj.Unzip(str);
                  this.game.Data = DataClass.deserialize(str);
                  this.game.HandyFunctionsObj.ZipFile(str);
                  if (Strings.Len(this.game.Data.MasterFile) > 0 & this.game.Data.Round == 0)
                  {
                    string masterFile = this.game.Data.MasterFile;
                    this.game.HandyFunctionsObj.LoadMasterFile(this.game.HandyFunctionsObj.ReturnLongMaster(str, masterFile));
                  }
                  if ((double) this.game.Data.RuleVar[344] == 1.0 & this.game.EditObj.HideUnit == 0)
                    this.game.EditObj.HideUnit = 2;
                  this.game.EditObj.TempValue = new MapMatrix2[this.game.Data.MapCounter + 1];
                  this.game.EditObj.TempValue2 = new MapMatrix2[this.game.Data.MapCounter + 1];
                  int mapCounter = this.game.Data.MapCounter;
                  for (int index3 = 0; index3 <= mapCounter; ++index3)
                  {
                    this.game.EditObj.TempValue[index3] = new MapMatrix2(this.game.Data.MapObj[index3].MapWidth, this.game.Data.MapObj[index3].MapHeight);
                    this.game.EditObj.TempValue2[index3] = new MapMatrix2(this.game.Data.MapObj[index3].MapWidth, this.game.Data.MapObj[index3].MapHeight);
                  }
                  if (this.game.Data.Round > 0)
                  {
                    BitmapStore.ReloadSystemGraphics(this.game.Data.SystemGfx);
                    this.game.Data.LoadGraphics((Form1) null);
                    this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, 200, 150, false);
                    this.game.EditObj.StratMap = new Bitmap(this.game.ScreenWidth, this.game.ScreenHeight - 305);
                    this.game.EditObj.StratMap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
                    this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.StratMap, this.game.ScreenWidth, this.game.ScreenHeight - 305, false, true, false);
                    SoundMod.StopWave();
                    this.game.FormRef.Cursor = Cursors.Default;
                    if (!this.game.Data.InTurn)
                    {
                      windowReturnClass1.AddCommand(3, 4);
                      this.game.EditObj.Phase = -1;
                    }
                    else
                    {
                      this.game.HandyFunctionsObj.SetInitialXY(this.game.Data.Turn);
                      this.game.FormRef.Cursor = Cursors.Default;
                      this.game.EventRelatedObj.DoCheckEvents(4);
                      this.game.ProcessingObj.LocationProductionPrognosis();
                      if ((double) this.game.Data.RuleVar[839] == 0.0)
                        windowReturnClass1.AddCommand(3, 3);
                      else
                        windowReturnClass1.AddCommand(3, 11);
                    }
                    return windowReturnClass1;
                  }
                  if (Strings.Len(this.game.Data.LoadPass) > 0)
                  {
                    this.game.FormRef.Cursor = Cursors.Default;
                    if (Operators.CompareString(Strings.LCase(Interaction.InputBox("This File is protected by a load password. Please give it in order to load it.", "Shadow Empire : Planetary Conquest")), Strings.LCase(this.game.Data.LoadPass), false) == 0)
                    {
                      int num1 = (int) Interaction.MsgBox((object) "You are cleared.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                    else
                    {
                      int num2 = (int) Interaction.MsgBox((object) "Wrong Password. You cannot Load this file", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      this.game.Data = new DataClass();
                      this.RemoveSubPart(this.TempText);
                      SubPartClass tsubpart = (SubPartClass) new TextPartClass(this.game.Data.Name + " is loaded instead.", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, true);
                      this.TempText = this.AddSubPart(ref tsubpart, 0, 41, 400, 19, 0);
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                  }
                  BitmapStore.ReloadSystemGraphics(this.game.Data.SystemGfx);
                  this.game.Data.LoadGraphics((Form1) null);
                  DrawMod.TGame = this.game;
                  this.game.FormRef.Cursor = Cursors.Default;
                  this.RemoveSubPart(this.TempText);
                  windowReturnClass1.AddCommand(3, 1);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (Strings.Len(str) > 1)
                {
                  int num = (int) Interaction.MsgBox((object) "File could not be found or op. is cancelled.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass1;
              }
            }
          }
          return windowReturnClass1;
        }
      }
      windowReturnClass1.SetFlag(false);
      return windowReturnClass1;
    }

    public void Import()
    {
      string str = this.game.HandyFunctionsObj.LoadSomething("AT Zip Package File (*.atzip)|*.atzip|AT2 file(*.at2)|*.at2|Regular Zip(*.zip)|*.zip", "Pick a zip archive or scenario file to install.", this.game.AppPath, false);
      if (Information.IsNothing((object) str))
        return;
      if (Strings.InStr(str, ".zip") > 0 | Strings.InStr(str, ".atzip") > 0)
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
          int num2 = (int) Interaction.MsgBox((object) "Error in unpacking. ", Title: ((object) "Shadow Empire : Planetary Conquest"));
          ProjectData.ClearProjectError();
          return;
        }
        this.game.FormRef.Cursor = Cursors.Default;
        int num3 = (int) Interaction.MsgBox((object) "Succesfully unpacked the .zip archive.", Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
      else
      {
        if (Information.IsNothing((object) str))
          return;
        string path = this.game.AppPath + this.game.ModScenarioDir + "/DOWNLOADED_SCENARIOS/";
        if (!Directory.Exists(path))
          Directory.CreateDirectory(path);
        string destFileName = path + Path.GetFileName(str);
        File.Copy(str, destFileName, true);
        int num = (int) Interaction.MsgBox((object) "Succesfully placed the file in the downloaded scenarios directory.", Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
    }
  }
}
