// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimplePrefsWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class SimplePrefsWindowClass : WindowClass
  {
    private int cancelid;
    private int Info1Id;
    private int info2id;
    private string ShowString;
    private DateTime ShowTime;
    private int w;
    private int h;
    private int CurrentView;
    private int BNameId;
    private int BNameTextId;
    private int B1Id;
    private int B1TextId;
    private int saveid;
    private int quitid;
    private int B2Id;
    private int B2TextId;
    private int B3Id;
    private int B3TextId;
    private int B4Id;
    private int B4TextId;
    private int B5Id;
    private int B5TextId;
    private int B6Id;
    private int B6TextId;
    private int B7Id;
    private int B7TextId;
    private int B8Id;
    private int B8TextId;
    private int B9Id;
    private int B9TextId;
    private int B10Id;
    private int B10TextId;
    private int B11Id;
    private int B11TextId;
    private int B12Id;
    private int B12TextId;
    private int B13Id;
    private int B13TextId;
    private int B14Id;
    private int B14TextId;
    private int B15Id;
    private int B15TextId;
    private int B16Id;
    private int B16TextId;
    private int slider1id;
    private int slider2id;

    public SimplePrefsWindowClass(ref GameClass tGame)
      : base(ref tGame, 480, 250, 8)
    {
      this.View();
    }

    public override void HandleToolTip(int x, int y)
    {
      base.HandleToolTip(x, y);
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            this.SubPartList[index].DescriptInfo(x - this.SubPartX[index], y - this.SubPartY[index]);
            if (Operators.CompareString(this.SubPartList[index].Descript, "", false) > 0)
            {
              this.game.EditObj.TipButton = true;
              this.game.EditObj.TipTitle = "";
              this.game.EditObj.TipText = this.SubPartList[index].Descript;
              return;
            }
          }
        }
      }
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          if (this.MouseData[index] > 0)
            this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = this.MouseTitle[index];
          this.game.EditObj.TipText = this.MouseText[index];
          break;
        }
      }
    }

    public void View()
    {
      if (this.cancelid > 0)
      {
        this.RemoveSubPart(this.cancelid);
        this.cancelid = 0;
      }
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      if (this.B3Id > 0)
        this.RemoveSubPart(this.B3Id);
      if (this.B3TextId > 0)
        this.RemoveSubPart(this.B3TextId);
      if (this.B4Id > 0)
        this.RemoveSubPart(this.B4Id);
      if (this.B4TextId > 0)
        this.RemoveSubPart(this.B4TextId);
      if (this.B5Id > 0)
        this.RemoveSubPart(this.B5Id);
      if (this.B5TextId > 0)
        this.RemoveSubPart(this.B5TextId);
      if (this.B6Id > 0)
        this.RemoveSubPart(this.B6Id);
      if (this.B6TextId > 0)
        this.RemoveSubPart(this.B6TextId);
      if (this.B7Id > 0)
        this.RemoveSubPart(this.B7Id);
      if (this.B7TextId > 0)
        this.RemoveSubPart(this.B7TextId);
      if (this.B8Id > 0)
        this.RemoveSubPart(this.B8Id);
      if (this.B8TextId > 0)
        this.RemoveSubPart(this.B8TextId);
      if (this.B9Id > 0)
        this.RemoveSubPart(this.B9Id);
      if (this.B9TextId > 0)
        this.RemoveSubPart(this.B9TextId);
      if (this.B10Id > 0)
        this.RemoveSubPart(this.B10Id);
      if (this.B10TextId > 0)
        this.RemoveSubPart(this.B10TextId);
      if (this.B11Id > 0)
        this.RemoveSubPart(this.B11Id);
      if (this.B11TextId > 0)
        this.RemoveSubPart(this.B11TextId);
      if (this.B12Id > 0)
        this.RemoveSubPart(this.B12Id);
      if (this.B12TextId > 0)
        this.RemoveSubPart(this.B12TextId);
      if (this.B13Id > 0)
        this.RemoveSubPart(this.B13Id);
      if (this.B13TextId > 0)
        this.RemoveSubPart(this.B13TextId);
      if (this.B14Id > 0)
        this.RemoveSubPart(this.B14Id);
      if (this.B14TextId > 0)
        this.RemoveSubPart(this.B14TextId);
      if (this.B15Id > 0)
        this.RemoveSubPart(this.B15Id);
      if (this.B15TextId > 0)
        this.RemoveSubPart(this.B15TextId);
      if (this.B16Id > 0)
        this.RemoveSubPart(this.B16Id);
      if (this.B16TextId > 0)
        this.RemoveSubPart(this.B16TextId);
      if (this.slider1id > 0)
      {
        this.RemoveSubPart(this.slider1id);
        this.slider1id = 0;
      }
      if (this.slider2id > 0)
      {
        this.RemoveSubPart(this.slider2id);
        this.slider2id = 0;
      }
      this.ClearMouse();
      this.NewBackGroundAndClearAll(480, 250, -1);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
      DrawMod.DrawMessFrame(ref this.OwnBitmap, ref graphics, 0, 0, 480, 250);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      if (!this.game.EditObj.SoundOn)
      {
        SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, false, "Sound effects are currently turned off.", ref this.OwnBitmap, 40, 110);
        this.B1Id = this.AddSubPart(ref tsubpart, 40, 110, 35, 35, 1);
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, true, "Sound effects are  currently turned on.", ref this.OwnBitmap, 40, 110);
        this.B1Id = this.AddSubPart(ref tsubpart, 40, 110, 35, 35, 1);
      }
      DrawMod.DrawTextColouredMarc(ref graphics, "SOUND FX", this.game.MarcFont4, 90, 118, Color.White);
      if (!this.game.EditObj.IntroSoundOn)
      {
        SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, false, "Music is currently turned off.", ref this.OwnBitmap, 40, 40);
        this.B8Id = this.AddSubPart(ref tsubpart, 40, 40, 35, 35, 1);
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, true, "Music is currently turned on.", ref this.OwnBitmap, 40, 40);
        this.B8Id = this.AddSubPart(ref tsubpart, 40, 40, 35, 35, 1);
      }
      DrawMod.DrawTextColouredMarc(ref graphics, "MUSIC", this.game.MarcFont4, 90, 48, Color.White);
      SubPartClass tsubpart1;
      if (this.slider1id < 1)
      {
        tsubpart1 = (SubPartClass) new NumberSliderSubPartClass2(this.game, "Music Volume = ", "%", 200, 0, 100, this.game.EditObj.Volume, tbackbitmap: (ref this.OwnBitmap), bbx: 230, bby: 30, tMarc: true);
        this.slider1id = this.AddSubPart(ref tsubpart1, 230, 30, 200, 40, 0);
      }
      if (this.slider2id < 1)
      {
        tsubpart1 = (SubPartClass) new NumberSliderSubPartClass2(this.game, "SFX Volume = ", "%", 200, 0, 100, this.game.EditObj.Volume2, tbackbitmap: (ref this.OwnBitmap), bbx: 230, bby: 100, tMarc: true);
        this.slider2id = this.AddSubPart(ref tsubpart1, 230, 100, 200, 40, 0);
      }
      tsubpart1 = (SubPartClass) new TextButtonPartClass("OK", 150, "Click to return to main screen. [ESC]", ref this.OwnBitmap, 165, 165, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.cancelid = this.AddSubPart(ref tsubpart1, 165, 165, 150, 40, 1);
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      try
      {
        if (nr == 27 | nr == 32)
        {
          windowReturnClass.AddCommand(6, 0);
          this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      return windowReturnClass;
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            int num = this.SubPartID[index];
            if (num == this.cancelid)
            {
              windowReturnClass.AddCommand(6, 0);
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.slider1id)
            {
              this.game.EditObj.Volume = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              this.SubPartList[index].Scroller = true;
              SoundMod.ChangeEventSoundBg(this.game.EditObj);
              return windowReturnClass;
            }
            if (num == this.slider2id)
            {
              this.game.EditObj.Volume2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              this.SubPartList[index].Scroller = true;
              SoundMod.ChangeEventSound(this.game.EditObj);
              return windowReturnClass;
            }
            if (num == this.B1Id)
            {
              this.game.EditObj.SoundOn = !this.game.EditObj.SoundOn;
              this.View();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.B8Id)
            {
              this.game.EditObj.IntroSoundOn = !this.game.EditObj.IntroSoundOn;
              if (this.game.EditObj.IntroSoundOn)
                SoundMod.PlayEventBackground(this.game.AppPath + "sound/" + this.game.ModOpeningSoundtrack, ref this.game.EditObj);
              if (!this.game.EditObj.IntroSoundOn)
                SoundMod.STopEventBackground();
              Application.DoEvents();
              this.View();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
          }
        }
        windowReturnClass.SetFlag(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    public override WindowReturnClass HandleMouseUp(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      OrderResult orderResult = new OrderResult();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (this.SubPartList[index].Scroller)
          {
            int num = this.SubPartID[index];
            if (num == this.slider1id)
            {
              this.game.EditObj.Volume = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              this.SubPartList[index].Scroller = false;
              this.SubPartList[this.SubpartNr(this.slider2id)].Scroller = false;
              SoundMod.ChangeEventSoundBg(this.game.EditObj);
              return windowReturnClass;
            }
            if (num == this.slider2id)
            {
              this.game.EditObj.Volume2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              this.SubPartList[index].Scroller = false;
              this.SubPartList[this.SubpartNr(this.slider1id)].Scroller = false;
              SoundMod.ChangeEventSound(this.game.EditObj);
              return windowReturnClass;
            }
          }
        }
        windowReturnClass.SetFlag(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }
  }
}
