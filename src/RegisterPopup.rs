// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.RegisterPopup
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

// usingMicrosoft.VisualBasic;
// usingMicrosoft.VisualBasic.CompilerServices;
// usingSystem;
// usingSystem.Drawing;

namespace WindowsApplication1
{
  pub class RegisterPopup : WindowClass
  {
     okid: i32;
     cancelid: i32;
     userid: i32;
     passid: i32;
     serialid: i32;
     emailid: i32;
     selectedid: i32;

    pub RegisterPopup( tGame: GameClass)
      : base( tGame, 600, 480, 8)
    {
      this.View();
    }

    pub fn HandleToolTip(x: i32, y: i32)
    {
      let mut subPartCounter: i32 = this.SubPartCounter;
      for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
      {
        if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
        {
          let mut num: i32 = this.SubPartID[index];
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
            this.game.EditObj.TipText = "Your serial code. You cannot change this field.";
          }
          else if (num == this.emailid)
          {
            this.game.EditObj.TipButton = true;
            this.game.EditObj.TipTitle = "EMAIL";
            this.game.EditObj.TipText = "Enter your email adress. This will probably be of use to notify you of new PBEM turns.";
          }
        }
      }
    }

    pub fn View()
    {
      this.ClearMouse();
      this.NewBackGroundAndClearAll(600, 480, -1);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawMessFrame( this.OwnBitmap,  graphics, 0, 0, 600, 480);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      DrawMod.DrawTextColouredMarc( graphics, "REGISTER WITH PBEM++ SERVER", this.game.MarcFont1, 98, 27, Color.White);
      DrawMod.DrawTextColouredMarc( graphics, "Username:", this.game.MarcFont4, 80, 75, Color.White);
      let mut tsubpart1: SubPartClass =  new InputTextClass("", this.game.MarcFont4, 440, 36, false, 20, true);
      this.userid = this.AddSubPart( tsubpart1, 80, 100, 440, 36, 0);
      DrawMod.DrawTextColouredMarc( graphics, "Password:", this.game.MarcFont4, 80, 155, Color.White);
      let mut tsubpart2: SubPartClass =  new InputTextClass("", this.game.MarcFont4, 440, 36, false, 20, true);
      this.passid = this.AddSubPart( tsubpart2, 80, 180, 440, 36, 0);
      DrawMod.DrawTextColouredMarc( graphics, "Serial code:", this.game.MarcFont4, 80, 235, Color.White);
      let mut tsubpart3: SubPartClass =  new InputTextClass("", this.game.MarcFont4, 440, 36, true, 19, true);
      this.serialid = this.AddSubPart( tsubpart3, 80, 260, 440, 36, 0);
      DrawMod.DrawTextColouredMarc( graphics, "Email:", this.game.MarcFont4, 80, 315, Color.White);
      let mut tsubpart4: SubPartClass =  new InputTextClass("", this.game.MarcFont4, 440, 36, false, 40, true);
      this.emailid = this.AddSubPart( tsubpart4, 80, 340, 440, 36, 0);
      if (Information.IsNothing( this.game.EditObj.PbemEmail))
        this.game.EditObj.PbemEmail = "";
      if (Information.IsNothing( this.game.EditObj.PbemPassword))
        this.game.EditObj.PbemPassword = "";
      if (Information.IsNothing( this.game.EditObj.PbemUserName))
        this.game.EditObj.PbemUserName = "";
      if (Information.IsNothing( this.game.EditObj.PbemSerial))
        this.game.EditObj.PbemSerial = "";
      this.SubPartList[this.SubpartNr(this.userid)].Refresh(this.game.EditObj.PbemUserName);
      this.SubPartList[this.SubpartNr(this.passid)].Refresh(this.game.EditObj.PbemPassword);
      this.SubPartList[this.SubpartNr(this.serialid)].Refresh(this.game.EditObj.PbemSerial);
      this.SubPartList[this.SubpartNr(this.emailid)].Refresh(this.game.EditObj.PbemEmail);
      let mut tsubpart5: SubPartClass =  new TextButtonPartClass("Already Registered user", 200, "Click to go directly to PBEM++ screen for login with an existing account.",  this.OwnBitmap, 80, 410, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.cancelid = this.AddSubPart( tsubpart5, 80, 410, 200, 36, 1);
      let mut tsubpart6: SubPartClass =  new TextButtonPartClass("Register User", 200, "Register with the PBEM++ server if you do not have an existing user account yet.",  this.OwnBitmap, 320, 410, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.okid = this.AddSubPart( tsubpart6, 320, 410, 200, 36, 1);
    }

    pub HandleKeyPress: WindowReturnClass(nr: i32, bool fromTimer = false)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
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

    pub handleTimer: WindowReturnClass()
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (!Information.IsNothing( this.game.EditObj.TextInputString) && this.game.EditObj.TextInputString.Length > 0)
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
        else if (this.selectedid == this.emailid)
        {
          this.SubPartList[this.SubpartNr(this.emailid)].Refresh(this.game.EditObj.TextInputString);
          this.SubPartFlag[this.SubpartNr(this.emailid)] = true;
        }
        windowReturnClass.SetFlag(true);
      }
      this.game.EditObj.TextInputString = "";
      return windowReturnClass;
    }

    pub HandleMouseClick: WindowReturnClass(x: i32, y: i32, b: i32)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (this.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 = this.SubPartCounter;
        for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            let mut num: i32 = this.SubPartID[index];
            if (num == this.cancelid)
            {
              this.game.EditObj.Save("editobj.txt");
              windowReturnClass.AddCommand(6, 0);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.okid)
            {
              this.game.EditObj.PbemUserName = this.SubPartList[this.SubpartNr(this.userid)].GetText();
              this.game.EditObj.PbemPassword = this.SubPartList[this.SubpartNr(this.passid)].GetText();
              this.game.EditObj.PbemSerial = this.SubPartList[this.SubpartNr(this.serialid)].GetText();
              this.game.EditObj.PbemEmail = this.SubPartList[this.SubpartNr(this.emailid)].GetText();
              this.game.EditObj.ServerCommand = ServerCommandType.Register;
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
              this.SubPartList[this.SubpartNr(this.emailid)].Descript = "";
              this.SubPartFlag[this.SubpartNr(this.userid)] = true;
              this.SubPartFlag[this.SubpartNr(this.serialid)] = true;
              this.SubPartFlag[this.SubpartNr(this.passid)] = true;
              this.SubPartFlag[this.SubpartNr(this.emailid)] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.emailid)
            {
              this.selectedid = this.emailid;
              this.SubPartList[this.SubpartNr(this.emailid)].Descript = "select";
              this.SubPartList[this.SubpartNr(this.userid)].Descript = "";
              this.SubPartList[this.SubpartNr(this.serialid)].Descript = "";
              this.SubPartList[this.SubpartNr(this.passid)].Descript = "";
              this.SubPartFlag[this.SubpartNr(this.userid)] = true;
              this.SubPartFlag[this.SubpartNr(this.serialid)] = true;
              this.SubPartFlag[this.SubpartNr(this.passid)] = true;
              this.SubPartFlag[this.SubpartNr(this.emailid)] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.serialid)
            {
              this.selectedid = this.serialid;
              this.SubPartList[this.SubpartNr(this.emailid)].Descript = "";
              this.SubPartList[this.SubpartNr(this.userid)].Descript = "";
              this.SubPartList[this.SubpartNr(this.serialid)].Descript = "select";
              this.SubPartList[this.SubpartNr(this.passid)].Descript = "";
              this.SubPartFlag[this.SubpartNr(this.userid)] = true;
              this.SubPartFlag[this.SubpartNr(this.serialid)] = true;
              this.SubPartFlag[this.SubpartNr(this.passid)] = true;
              this.SubPartFlag[this.SubpartNr(this.emailid)] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.passid)
            {
              this.selectedid = this.passid;
              this.SubPartList[this.SubpartNr(this.passid)].Descript = "select";
              this.SubPartList[this.SubpartNr(this.serialid)].Descript = "";
              this.SubPartList[this.SubpartNr(this.userid)].Descript = "";
              this.SubPartList[this.SubpartNr(this.emailid)].Descript = "";
              this.SubPartFlag[this.SubpartNr(this.userid)] = true;
              this.SubPartFlag[this.SubpartNr(this.serialid)] = true;
              this.SubPartFlag[this.SubpartNr(this.passid)] = true;
              this.SubPartFlag[this.SubpartNr(this.emailid)] = true;
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
