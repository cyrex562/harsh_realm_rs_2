// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.LoginPopup
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class LoginPopup : WindowClass
  {
    private int okid;
    private int cancelid;
    private int userid;
    private int passid;
    private int serialid;
    private int selectedid;

    public LoginPopup(ref GameClass tGame)
      : base(ref tGame, 600, 480, 8)
    {
      this.View();
    }

    public void View()
    {
      this.ClearMouse();
      this.NewBackGroundAndClearAll(600, 480, -1);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawMessFrame(ref this.OwnBitmap, ref graphics, 0, 0, 600, 480);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      DrawMod.DrawTextColouredMarc(ref graphics, "LOGIN WITH PBEM++ SERVER", this.game.MarcFont1, 98, 27, Color.White);
      DrawMod.DrawTextColouredMarc(ref graphics, "Username:", this.game.MarcFont4, 80, 75, Color.White);
      SubPartClass tsubpart1 = (SubPartClass) new InputTextClass("", this.game.MarcFont4, 440, 36, false, 20, true);
      this.userid = this.AddSubPart(ref tsubpart1, 80, 100, 440, 36, 0);
      DrawMod.DrawTextColouredMarc(ref graphics, "Password:", this.game.MarcFont4, 80, 155, Color.White);
      SubPartClass tsubpart2 = (SubPartClass) new InputTextClass("", this.game.MarcFont4, 440, 36, false, 20, true);
      this.passid = this.AddSubPart(ref tsubpart2, 80, 180, 440, 36, 0);
      DrawMod.DrawTextColouredMarc(ref graphics, "Serial code:", this.game.MarcFont4, 80, 235, Color.White);
      SubPartClass tsubpart3 = (SubPartClass) new InputTextClass("", this.game.MarcFont4, 440, 36, true, 19, true);
      this.serialid = this.AddSubPart(ref tsubpart3, 80, 260, 440, 36, 0);
      this.SubPartList[this.SubpartNr(this.userid)].Refresh(this.game.EditObj.PbemUserName);
      this.SubPartList[this.SubpartNr(this.passid)].Refresh(this.game.EditObj.PbemPassword);
      this.SubPartList[this.SubpartNr(this.serialid)].Refresh(this.game.EditObj.PbemSerial);
      SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("Cancel", 200, "Click to return to PBEM+= screen", ref this.OwnBitmap, 80, 410, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.cancelid = this.AddSubPart(ref tsubpart4, 80, 410, 200, 36, 1);
      SubPartClass tsubpart5 = (SubPartClass) new TextButtonPartClass("LOG IN", 200, "Login with the PBEM++ server", ref this.OwnBitmap, 320, 410, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.okid = this.AddSubPart(ref tsubpart5, 320, 410, 200, 36, 1);
    }

    public override void HandleToolTip(int x, int y)
    {
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
      {
        if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
        {
          int num = this.SubPartID[index];
          if (num == this.userid)
          {
            this.game.EditObj.TipButton = true;
            this.game.EditObj.TipTitle = "USERNAME";
            this.game.EditObj.TipText = "Enter a username of choice here.";
          }
          else if (num == this.passid)
          {
            this.game.EditObj.TipButton = true;
            this.game.EditObj.TipTitle = "PASSWORD";
            this.game.EditObj.TipText = "Enter a password of choice here.";
          }
          else if (num == this.serialid)
          {
            this.game.EditObj.TipButton = true;
            this.game.EditObj.TipTitle = "SERIAL CODE";
            this.game.EditObj.TipText = "You cannot change your serial code. But this is it.";
          }
        }
      }
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      try
      {
        if (nr == 27)
        {
          windowReturnClass = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.cancelid)] + 1, this.SubPartY[this.SubpartNr(this.cancelid)] + 1, 1);
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

    public override WindowReturnClass handleTimer()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (!Information.IsNothing((object) this.game.EditObj.TextInputString) && this.game.EditObj.TextInputString.Length > 0)
      {
        if (this.selectedid == this.userid)
        {
          this.SubPartList[this.SubpartNr(this.selectedid)].Refresh(this.game.EditObj.TextInputString);
          this.SubPartFlag[this.SubpartNr(this.selectedid)] = true;
        }
        else if (this.selectedid == this.passid)
        {
          this.SubPartList[this.SubpartNr(this.passid)].Refresh(this.game.EditObj.TextInputString);
          this.SubPartFlag[this.SubpartNr(this.passid)] = true;
        }
        windowReturnClass.SetFlag(true);
      }
      this.game.EditObj.TextInputString = "";
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
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.okid)
            {
              this.game.EditObj.PbemUserName = this.SubPartList[this.SubpartNr(this.userid)].GetText();
              this.game.EditObj.PbemPassword = this.SubPartList[this.SubpartNr(this.passid)].GetText();
              this.game.EditObj.PbemSerial = this.SubPartList[this.SubpartNr(this.serialid)].GetText();
              this.game.EditObj.ServerCommand = ServerCommandType.Login;
              this.game.EditObj.Save("editobj.txt");
              this.game.EditObj.PopupValue = 15;
              windowReturnClass.AddCommand(5, 14);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.userid)
            {
              this.selectedid = this.userid;
              this.SubPartList[this.SubpartNr(this.userid)].Descript = "select";
              this.SubPartList[this.SubpartNr(this.serialid)].Descript = "";
              this.SubPartList[this.SubpartNr(this.passid)].Descript = "";
              this.SubPartFlag[this.SubpartNr(this.userid)] = true;
              this.SubPartFlag[this.SubpartNr(this.serialid)] = true;
              this.SubPartFlag[this.SubpartNr(this.passid)] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.serialid)
            {
              this.selectedid = this.serialid;
              this.SubPartList[this.SubpartNr(this.userid)].Descript = "";
              this.SubPartList[this.SubpartNr(this.serialid)].Descript = "select";
              this.SubPartList[this.SubpartNr(this.passid)].Descript = "";
              this.SubPartFlag[this.SubpartNr(this.userid)] = true;
              this.SubPartFlag[this.SubpartNr(this.serialid)] = true;
              this.SubPartFlag[this.SubpartNr(this.passid)] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.passid)
            {
              this.selectedid = this.passid;
              this.SubPartList[this.SubpartNr(this.passid)].Descript = "select";
              this.SubPartList[this.SubpartNr(this.serialid)].Descript = "";
              this.SubPartList[this.SubpartNr(this.userid)].Descript = "";
              this.SubPartFlag[this.SubpartNr(this.userid)] = true;
              this.SubPartFlag[this.SubpartNr(this.serialid)] = true;
              this.SubPartFlag[this.SubpartNr(this.passid)] = true;
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
  }
}
