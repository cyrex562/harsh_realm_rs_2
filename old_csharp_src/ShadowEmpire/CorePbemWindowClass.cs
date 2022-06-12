// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.CorePbemWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class CorePbemWindowClass : WindowClass
  {
    private int BackId;
    private int PassId;
    private int PassTextId;
    private int selectedid;
    private int RegisterId;
    private int RegisterId2;
    private int CancelId;
    private int Cancel2Id;
    private int ClaimId;
    private int Claim2Id;
    private int LoginId;
    private int LoginId2;
    private int Refresh2id;
    private int RefreshId;
    private int LogOutId;
    private int LogOut2Id;
    private int challengeId;
    private int challenge2Id;
    private int AcceptChallengeId;
    private int AcceptChallengeId2;
    private int PreviewId;
    private int Preview2Id;
    private int CheckPlayerId;
    private int CheckPlayerId2;
    private int PlayTurnId;
    private int textid;
    private int PlayTurn2id;
    private int ch1;
    private int ch1b;
    private int ch2b;
    private int ch3b;
    private int ch4b;
    private int ch5b;
    private int ch2;
    private int ch3;
    private int ch4;
    private int ch5;
    private int ChallengeListId;
    private ListClass ChallengeListObj;
    private int gamenr;
    private bool AcceptUsePass;
    private int currentTab;

    public CorePbemWindowClass(ref GameClass tGame)
      : base(ref tGame, 1024, 768, BackSprite: tGame.BACKGROUND1MARC)
    {
      this.ChallengeListObj = new ListClass();
      this.gamenr = -1;
      this.selectedid = -1;
      this.currentTab = 1;
      if (this.game.EditObj.PbemInspectReturnFromID > -1 & this.game.EditObj.PbemGameSetup == PbemGameSetupPhase.Inspecting)
      {
        this.gamenr = this.game.EditObj.PbemInspectReturnFromID;
        this.game.EditObj.PbemInspectReturnFromID = -1;
        this.currentTab = 3;
      }
      if (this.game.EditObj.PbemInspectReturnFromID > -1 & this.game.EditObj.PbemGameSetup == PbemGameSetupPhase.CancelPlayTurn)
      {
        this.gamenr = this.game.EditObj.PbemInspectReturnFromID;
        this.game.EditObj.PbemInspectReturnFromID = -1;
        this.currentTab = 1;
      }
      if (this.game.EditObj.PbemGameSetup != PbemGameSetupPhase.Saved)
        ;
      if (this.game.EditObj.IntroSoundOn)
        SoundMod.PlayEventBackground(this.game.AppPath + "sound/" + this.game.ModOpeningSoundtrack, ref this.game.EditObj);
      this.DoStuff();
    }

    public void PopUpRefresh()
    {
      this.gamenr = -1;
      this.DoStuff();
    }

    public void DoStuff()
    {
      SizeF sizeF = new SizeF();
      this.selectedid = -1;
      this.game.EditObj.PbemCheckPlayer = "";
      if (this.PassId > 0)
      {
        this.RemoveSubPart(this.PassId);
        this.PassId = 0;
      }
      if (this.PassTextId > 0)
      {
        this.RemoveSubPart(this.PassTextId);
        this.PassTextId = 0;
      }
      if (this.CancelId > 0)
        this.RemoveSubPart(this.CancelId);
      if (this.ClaimId > 0)
        this.RemoveSubPart(this.ClaimId);
      if (this.CancelId > 0)
        this.RemoveSubPart(this.Cancel2Id);
      if (this.Claim2Id > 0)
        this.RemoveSubPart(this.Claim2Id);
      if (this.BackId > 0)
        this.RemoveSubPart(this.BackId);
      if (this.RegisterId > 0)
        this.RemoveSubPart(this.RegisterId);
      if (this.LoginId > 0)
        this.RemoveSubPart(this.LoginId);
      if (this.RegisterId2 > 0)
        this.RemoveSubPart(this.RegisterId2);
      if (this.LoginId2 > 0)
        this.RemoveSubPart(this.LoginId2);
      if (this.RefreshId > 0)
        this.RemoveSubPart(this.RefreshId);
      if (this.Refresh2id > 0)
        this.RemoveSubPart(this.Refresh2id);
      if (this.LogOutId > 0)
        this.RemoveSubPart(this.LogOutId);
      if (this.LogOut2Id > 0)
        this.RemoveSubPart(this.LogOut2Id);
      if (this.challengeId > 0)
        this.RemoveSubPart(this.challengeId);
      if (this.ch1 > 0)
        this.RemoveSubPart(this.ch1);
      if (this.ch2 > 0)
        this.RemoveSubPart(this.ch2);
      if (this.ch3 > 0)
        this.RemoveSubPart(this.ch3);
      if (this.ch4 > 0)
        this.RemoveSubPart(this.ch4);
      if (this.ch5 > 0)
        this.RemoveSubPart(this.ch5);
      if (this.ch1b > 0)
        this.RemoveSubPart(this.ch1b);
      if (this.ch2b > 0)
        this.RemoveSubPart(this.ch2b);
      if (this.ch3b > 0)
        this.RemoveSubPart(this.ch3b);
      if (this.ch4b > 0)
        this.RemoveSubPart(this.ch4b);
      if (this.ch5b > 0)
        this.RemoveSubPart(this.ch5b);
      if (this.challenge2Id > 0)
        this.RemoveSubPart(this.challenge2Id);
      if (this.PlayTurnId > 0)
        this.RemoveSubPart(this.PlayTurnId);
      if (this.PlayTurn2id > 0)
        this.RemoveSubPart(this.PlayTurn2id);
      if (this.PreviewId > 0)
        this.RemoveSubPart(this.PreviewId);
      if (this.Preview2Id > 0)
        this.RemoveSubPart(this.Preview2Id);
      if (this.CheckPlayerId > 0)
        this.RemoveSubPart(this.CheckPlayerId);
      if (this.CheckPlayerId2 > 0)
        this.RemoveSubPart(this.CheckPlayerId2);
      if (this.textid > 0)
        this.RemoveSubPart(this.textid);
      this.ClearMouse();
      this.NewBackGroundAndClearAll(1024, 768, this.game.BACKGROUND1MARC);
      Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
      g.SmoothingMode = SmoothingMode.AntiAlias;
      g.TextRenderingHint = TextRenderingHint.AntiAlias;
      g.TextContrast = 1;
      DrawMod.DrawTextColouredMarc(ref g, "PBEM++ MAIN MENU", this.game.MarcFont1, 55, 27, Color.White);
      DrawMod.DrawBlock(ref g, 40, 60, 925, 3, (int) this.game.MarcCol4.R, (int) this.game.MarcCol4.G, (int) this.game.MarcCol4.B, (int) this.game.MarcCol4.A);
      SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("EXIT PBEM++", 160, "Go back to the main menu.", ref this.OwnBitmap, 800, 250, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.BackId = this.AddSubPart(ref tsubpart1, 800, 250, 160, 50, 1);
      int num = -1;
      if (this.game.EditObj.ServerLostConnect)
      {
        DrawMod.DrawTextColouredMarc(ref g, "Lost connection", this.game.MarcFont4, 800, 80, Color.White);
        DrawMod.DrawTextColouredMarc(ref g, "with server", this.game.MarcFont4, 800, 105, Color.White);
        SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("REGISTER", 160, "Click to register.", ref this.OwnBitmap, 800, 150, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.RegisterId = this.AddSubPart(ref tsubpart2, 800, 150, 160, 50, 1);
        tsubpart2 = (SubPartClass) new TextButtonPartClass("LOGIN", 160, "Try to log-in with existing username/password.", ref this.OwnBitmap, 800, 200, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.LoginId = this.AddSubPart(ref tsubpart2, 800, 200, 160, 50, 1);
        tsubpart2 = (SubPartClass) new TextButtonPartClass("REFRESH", 160, "cannot refresh because not registered yet.", ref this.OwnBitmap, 800, 300, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.Refresh2id = this.AddSubPart(ref tsubpart2, 800, 300, 160, 50, 1);
        tsubpart2 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Not logged in!", ref this.OwnBitmap, 800, 350, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "open file browser", tfont2: this.game.MarcFont4);
        this.challenge2Id = this.AddSubPart(ref tsubpart2, 800, 350, 160, 50, 1);
        switch (num)
        {
          case 3:
            tsubpart2 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Not logged in!", ref this.OwnBitmap, 800, 400, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "Case Blue Short", tfont2: this.game.MarcFont4);
            this.ch1b = this.AddSubPart(ref tsubpart2, 800, 400, 160, 50, 1);
            tsubpart2 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Not logged in!", ref this.OwnBitmap, 800, 450, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "Op. Uranus Short", tfont2: this.game.MarcFont4);
            this.ch2b = this.AddSubPart(ref tsubpart2, 800, 450, 160, 50, 1);
            tsubpart2 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Not logged in!", ref this.OwnBitmap, 800, 500, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "2nd Kharkov", tfont2: this.game.MarcFont4);
            this.ch3b = this.AddSubPart(ref tsubpart2, 800, 500, 160, 50, 1);
            tsubpart2 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Not logged in!", ref this.OwnBitmap, 800, 550, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "Voronezh", tfont2: this.game.MarcFont4);
            this.ch4b = this.AddSubPart(ref tsubpart2, 800, 550, 160, 50, 1);
            break;
          case 4:
            tsubpart2 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Not logged in!", ref this.OwnBitmap, 800, 400, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "Barbarossa", tfont2: this.game.MarcFont4);
            this.ch1b = this.AddSubPart(ref tsubpart2, 800, 400, 160, 50, 1);
            break;
        }
      }
      else if (this.game.EditObj.ServerAuthReply == ServerAuthReplyType.AuthFailure & this.game.EditObj.ServerSerialReply == ServerSerialReplyType.SerialNotRegistered)
      {
        DrawMod.DrawTextColouredMarc(ref g, "You still have to login", this.game.MarcFont4, 800, 80, Color.White);
        DrawMod.DrawTextColouredMarc(ref g, "or register a user/pass...", this.game.MarcFont4, 800, 105, Color.White);
        SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("REGISTER", 160, "Click to register.", ref this.OwnBitmap, 800, 150, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.RegisterId = this.AddSubPart(ref tsubpart3, 800, 150, 160, 50, 1);
        tsubpart3 = (SubPartClass) new TextButtonPartClass("LOGIN", 160, "Try to log-in with existing username/password.", ref this.OwnBitmap, 800, 200, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.LoginId = this.AddSubPart(ref tsubpart3, 800, 200, 160, 50, 1);
        tsubpart3 = (SubPartClass) new TextButtonPartClass("REFRESH", 160, "cannot refresh because not registered yet.", ref this.OwnBitmap, 800, 300, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.Refresh2id = this.AddSubPart(ref tsubpart3, 800, 300, 160, 50, 1);
        tsubpart3 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Not logged in!", ref this.OwnBitmap, 800, 350, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "open file browser", tfont2: this.game.MarcFont4);
        this.challenge2Id = this.AddSubPart(ref tsubpart3, 800, 350, 160, 50, 1);
        switch (num)
        {
          case 3:
            tsubpart3 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Not logged in!", ref this.OwnBitmap, 800, 400, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "Case Blue Short", tfont2: this.game.MarcFont4);
            this.ch1b = this.AddSubPart(ref tsubpart3, 800, 400, 160, 50, 1);
            tsubpart3 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Not logged in!", ref this.OwnBitmap, 800, 450, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "Op. Uranus Short", tfont2: this.game.MarcFont4);
            this.ch2b = this.AddSubPart(ref tsubpart3, 800, 450, 160, 50, 1);
            tsubpart3 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Not logged in!", ref this.OwnBitmap, 800, 500, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "2nd Kharkov", tfont2: this.game.MarcFont4);
            this.ch3b = this.AddSubPart(ref tsubpart3, 800, 500, 160, 50, 1);
            tsubpart3 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Not logged in!", ref this.OwnBitmap, 800, 550, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "Voronezh", tfont2: this.game.MarcFont4);
            this.ch4b = this.AddSubPart(ref tsubpart3, 800, 550, 160, 50, 1);
            break;
          case 4:
            tsubpart3 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Not logged in!", ref this.OwnBitmap, 800, 400, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "Barbarossa", tfont2: this.game.MarcFont4);
            this.ch1b = this.AddSubPart(ref tsubpart3, 800, 400, 160, 50, 1);
            break;
        }
      }
      else if (this.game.EditObj.ServerAuthReply == ServerAuthReplyType.AuthSucces)
      {
        DrawMod.DrawTextColouredMarc(ref g, "Welcome back,", this.game.MarcFont4, 800, 80, Color.White);
        DrawMod.DrawTextColouredMarc(ref g, this.game.EditObj.PbemUserName, this.game.MarcFont3, 800, 105, Color.White);
        SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("REGISTER", 160, "Cannot register because already logged-in.", ref this.OwnBitmap, 800, 150, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.RegisterId2 = this.AddSubPart(ref tsubpart4, 800, 150, 160, 50, 1);
        SubPartClass tsubpart5 = (SubPartClass) new TextButtonPartClass("LOGIN", 160, "Cannot login because you are already logged-in.", ref this.OwnBitmap, 800, 200, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.LoginId2 = this.AddSubPart(ref tsubpart5, 800, 200, 160, 50, 1);
        SubPartClass tsubpart6 = (SubPartClass) new TextButtonPartClass("REFRESH", 160, "Get new list of challenges and running games from server.", ref this.OwnBitmap, 800, 300, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.RefreshId = this.AddSubPart(ref tsubpart6, 800, 300, 160, 50, 1);
        SubPartClass tsubpart7 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Allows you to choose a scenario from a file browser to issue a challenge for a PBEM++ game. Keep in mind if you select a custom or third party scenario that the other player needs to any possible graphics this scenarios uses as well.\r\nFurther keep in mind that the PBEM++ system only supports 2 player games.", ref this.OwnBitmap, 800, 350, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "open file browser", tfont2: this.game.MarcFont4);
        this.challengeId = this.AddSubPart(ref tsubpart7, 800, 350, 160, 50, 1);
        switch (num)
        {
          case 3:
            SubPartClass tsubpart8 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Start a PBEM++ challenge to play the Case Blue Short campaign scenario.\r\nIt lasts about 30 rounds or less. ", ref this.OwnBitmap, 800, 400, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "Case Blue Short", tfont2: this.game.MarcFont4);
            this.ch1 = this.AddSubPart(ref tsubpart8, 800, 400, 160, 50, 1);
            SubPartClass tsubpart9 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Start a PBEM++ challenge to play the Uranus Short campaign scenario.\r\nIt lasts about 30 rounds or less. ", ref this.OwnBitmap, 800, 450, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "Op. Uranus Short", tfont2: this.game.MarcFont4);
            this.ch2 = this.AddSubPart(ref tsubpart9, 800, 450, 160, 50, 1);
            SubPartClass tsubpart10 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Start a PBEM++ challenge to play the 2nd Kharkov scenario.\r\nIt lasts about 8 rounds.", ref this.OwnBitmap, 800, 500, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "2nd Kharkov", tfont2: this.game.MarcFont4);
            this.ch3 = this.AddSubPart(ref tsubpart10, 800, 500, 160, 50, 1);
            tsubpart10 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Start a PBEM++ challenge to play the Drive on Voronezh scenario.\r\nIt lasts about 8 rounds.", ref this.OwnBitmap, 800, 550, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "Voronezh", tfont2: this.game.MarcFont4);
            this.ch4 = this.AddSubPart(ref tsubpart10, 800, 550, 160, 50, 1);
            break;
          case 4:
            SubPartClass tsubpart11 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Start a PBEM++ challenge to play the regular Barbarossa scenario.", ref this.OwnBitmap, 800, 400, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "Barbarossa", tfont2: this.game.MarcFont4);
            this.ch1 = this.AddSubPart(ref tsubpart11, 800, 400, 160, 50, 1);
            break;
        }
      }
      else
      {
        DrawMod.DrawTextColouredMarc(ref g, "Your not logged in.", this.game.MarcFont4, 800, 80, Color.White);
        SubPartClass tsubpart12 = (SubPartClass) new TextButtonPartClass("REGISTER", 160, "Click to register.", ref this.OwnBitmap, 800, 150, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.RegisterId = this.AddSubPart(ref tsubpart12, 800, 150, 160, 50, 1);
        SubPartClass tsubpart13 = (SubPartClass) new TextButtonPartClass("LOGIN", 160, "Click to login with existing username/password.", ref this.OwnBitmap, 800, 200, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.LoginId = this.AddSubPart(ref tsubpart13, 800, 200, 160, 50, 1);
        SubPartClass tsubpart14 = (SubPartClass) new TextButtonPartClass("REFRESH", 160, "cannot refresh because not logged in yet.", ref this.OwnBitmap, 800, 300, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.Refresh2id = this.AddSubPart(ref tsubpart14, 800, 300, 160, 50, 1);
        tsubpart14 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Not logged in!", ref this.OwnBitmap, 800, 350, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "open file browser", tfont2: this.game.MarcFont4);
        this.challenge2Id = this.AddSubPart(ref tsubpart14, 800, 350, 160, 50, 1);
        switch (num)
        {
          case 3:
            tsubpart14 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Not logged in!", ref this.OwnBitmap, 800, 400, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "Case Blue Short", tfont2: this.game.MarcFont4);
            this.ch1b = this.AddSubPart(ref tsubpart14, 800, 400, 160, 50, 1);
            tsubpart14 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Not logged in!", ref this.OwnBitmap, 800, 450, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "Op. Uranus Short", tfont2: this.game.MarcFont4);
            this.ch2b = this.AddSubPart(ref tsubpart14, 800, 450, 160, 50, 1);
            tsubpart14 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Not logged in!", ref this.OwnBitmap, 800, 500, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "2nd Kharkov", tfont2: this.game.MarcFont4);
            this.ch3b = this.AddSubPart(ref tsubpart14, 800, 500, 160, 50, 1);
            tsubpart14 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Not logged in!", ref this.OwnBitmap, 800, 550, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "Voronezh", tfont2: this.game.MarcFont4);
            this.ch4b = this.AddSubPart(ref tsubpart14, 800, 550, 160, 50, 1);
            break;
          case 4:
            tsubpart14 = (SubPartClass) new TextButtonPartClass("CHALLENGE", 160, "Not logged in!", ref this.OwnBitmap, 800, 400, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true, textras: "Barbarossa", tfont2: this.game.MarcFont4);
            this.ch1b = this.AddSubPart(ref tsubpart14, 800, 400, 160, 50, 1);
            break;
        }
      }
      DrawMod.DrawFrame2(ref this.OwnBitmap, ref g, 40, 104, 720, 600);
      if (this.currentTab == 0)
      {
        this.DrawTab3(g);
        this.DrawTab2(g);
        this.DrawTab1(g);
        this.DrawTab0(g, true);
        this.DrawFinishedGamesTab(g);
      }
      else if (this.currentTab == 1)
      {
        this.DrawTab0(g);
        this.DrawTab3(g);
        this.DrawTab2(g);
        this.DrawTab1(g, true);
        this.DrawCurrentGamesTab(g);
      }
      else if (this.currentTab == 2)
      {
        this.DrawTab0(g);
        this.DrawTab1(g);
        this.DrawTab3(g);
        this.DrawTab2(g, true);
        this.DrawYourChallengesTab(g);
      }
      else
      {
        if (this.currentTab != 3)
          return;
        this.DrawTab0(g);
        this.DrawTab1(g);
        this.DrawTab2(g);
        this.DrawTab3(g, true);
        this.DrawOtherChallengesTab(g);
      }
    }

    public void DrawYourChallengesTab(Graphics g)
    {
      this.game.EditObj.PbemCheckPlayer = "";
      if (this.ChallengeListId > 0)
        this.RemoveSubPart(this.ChallengeListId);
      this.ChallengeListObj = new ListClass();
      int num = -1;
      if (Information.IsNothing((object) this.game.EditObj.ServerChallengeList))
        return;
      int upperBound = this.game.EditObj.ServerChallengeList.GetUpperBound(0);
      for (int index = 0; index <= upperBound; ++index)
      {
        if (Operators.CompareString(Strings.UCase(this.game.EditObj.ServerChallengeList[index].challengerUserName), Strings.UCase(this.game.EditObj.PbemUserName), false) == 0)
        {
          if (this.gamenr == this.game.EditObj.ServerChallengeList[index].challengeID)
          {
            this.game.EditObj.PbemChallengeID = this.game.EditObj.ServerChallengeList[index].challengeID;
            num = index;
          }
          string tvalue3 = " ";
          string str1 = "You";
          string tvalue = this.game.EditObj.ServerChallengeList[index].firstPlayerSide != 1 ? str1 + " (opponent starts)" : str1 + " (you start)";
          if (this.game.EditObj.ServerChallengeList[index].challengePrivate == 1)
            tvalue3 = "PASSWORD REQ";
          string str2 = this.game.EditObj.ServerChallengeList[index].gameName;
          if (str2.Length > 30)
            str2 = Strings.Left(str2, 30) + "...";
          this.ChallengeListObj.add(str2, this.game.EditObj.ServerChallengeList[index].challengeID, tvalue, Conversions.ToString(this.game.EditObj.ServerChallengeList[index].dateIssued), tvalue3);
        }
      }
      ListClass challengeListObj = this.ChallengeListObj;
      int tlistselect = num;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(challengeListObj, 18, 680, tlistselect, game, tHeaderCenter: false, tShowPair: true, tValueWidth: 490, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: 60, bby: 130, tMarcStyle: true, overruleFont: (ref local2));
      this.ChallengeListId = this.AddSubPart(ref tsubpart, 60, 130, 680, 304, 0);
      this.DrawYourChallengesTabRefresh();
    }

    public void DrawYourChallengesTabRefresh()
    {
      this.game.EditObj.PbemCheckPlayer = "";
      if (this.CancelId > 0)
        this.RemoveSubPart(this.CancelId);
      if (this.ClaimId > 0)
        this.RemoveSubPart(this.ClaimId);
      if (this.CancelId > 0)
        this.RemoveSubPart(this.Cancel2Id);
      if (this.Claim2Id > 0)
        this.RemoveSubPart(this.Claim2Id);
      if (this.AcceptChallengeId > 0)
        this.RemoveSubPart(this.AcceptChallengeId);
      if (this.AcceptChallengeId2 > 0)
        this.RemoveSubPart(this.AcceptChallengeId2);
      if (this.PlayTurnId > 0)
        this.RemoveSubPart(this.PlayTurnId);
      if (this.PlayTurn2id > 0)
        this.RemoveSubPart(this.PlayTurn2id);
      if (this.PreviewId > 0)
        this.RemoveSubPart(this.PreviewId);
      if (this.Preview2Id > 0)
        this.RemoveSubPart(this.Preview2Id);
      if (this.textid > 0)
        this.RemoveSubPart(this.textid);
      if (this.PassId > 0)
      {
        this.RemoveSubPart(this.PassId);
        this.PassId = 0;
      }
      if (this.PassTextId > 0)
      {
        this.RemoveSubPart(this.PassTextId);
        this.PassTextId = 0;
      }
      if (this.CheckPlayerId > 0)
        this.RemoveSubPart(this.CheckPlayerId);
      if (this.CheckPlayerId2 > 0)
        this.RemoveSubPart(this.CheckPlayerId2);
      int index1 = -1;
      string tText;
      if (this.gamenr > -1)
      {
        int upperBound = this.game.EditObj.ServerChallengeList.GetUpperBound(0);
        for (int index2 = 0; index2 <= upperBound; ++index2)
        {
          if (this.gamenr == this.game.EditObj.ServerChallengeList[index2].challengeID)
          {
            this.game.EditObj.PbemChallengeID = this.game.EditObj.ServerChallengeList[index2].challengeID;
            index1 = index2;
          }
        }
        tText = "-error with this challenge-";
        if (index1 > -1)
        {
          string InputStr = Strings.Mid(this.game.EditObj.ServerChallengeList[index1].miscData, 33, 8);
          int num;
          try
          {
            num = (int) Math.Round(Conversion.Val(InputStr));
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            num = 0;
            ProjectData.ClearProjectError();
          }
          if (num > 999)
            num = 0;
          tText = "GAME NAME: " + this.game.EditObj.ServerChallengeList[index1].gameName + "\r\n" + "CHALLENGER: " + this.game.EditObj.ServerChallengeList[index1].challengerUserName + "\r\n" + "FILE NAME: " + Strings.Left(this.game.EditObj.ServerChallengeList[index1].miscData, 32) + "\r\n" + "VERSION: " + num.ToString() + "\r\n" + "SETTINGS: " + Strings.Mid(this.game.EditObj.ServerChallengeList[index1].miscData, 41, 4) + "\r\n" + "VARIANTS: " + Strings.Mid(this.game.EditObj.ServerChallengeList[index1].miscData, 45, 12) + "\r\n";
        }
      }
      else
        tText = "-no scenario selected-";
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 680, 7, this.game.MarcFont4, tText, tbackbitmap: (ref this.OwnBitmap), bbx: 60, bby: 450);
      this.textid = this.AddSubPart(ref tsubpart1, 60, 450, 680, 160, 0);
      if (this.gamenr > -1)
      {
        SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("CANCEL CHALLENGE", 240, "Click to cancel this challenge", ref this.OwnBitmap, 60, 620, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.CancelId = this.AddSubPart(ref tsubpart2, 60, 620, 240, 50, 1);
      }
      else
      {
        SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("CANCEL CHALLENGE", 240, "Cannot cancel any challenge because no challenge from the list above has been selected.", ref this.OwnBitmap, 60, 620, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.CancelId = this.AddSubPart(ref tsubpart3, 60, 620, 240, 50, 1);
      }
    }

    public void DrawOtherChallengesTab(Graphics g)
    {
      this.game.EditObj.PbemCheckPlayer = "";
      if (this.ChallengeListId > 0)
        this.RemoveSubPart(this.ChallengeListId);
      if (Information.IsNothing((object) this.game.EditObj.ServerChallengeList))
        return;
      this.ChallengeListObj = new ListClass();
      int num = -1;
      int upperBound = this.game.EditObj.ServerChallengeList.GetUpperBound(0);
      for (int index = 0; index <= upperBound; ++index)
      {
        if (Operators.CompareString(Strings.UCase(this.game.EditObj.ServerChallengeList[index].challengerUserName), Strings.UCase(this.game.EditObj.PbemUserName), false) != 0)
        {
          if (this.gamenr == this.game.EditObj.ServerChallengeList[index].challengeID)
            num = index;
          string tvalue3 = " ";
          if (this.game.EditObj.ServerChallengeList[index].challengePrivate == 1)
            tvalue3 = "PASSWORD REQ";
          string challengerUserName = this.game.EditObj.ServerChallengeList[index].challengerUserName;
          string tvalue = this.game.EditObj.ServerChallengeList[index].firstPlayerSide != 1 ? challengerUserName + " (you start)" : challengerUserName + " (starts)";
          string str = this.game.EditObj.ServerChallengeList[index].gameName;
          if (str.Length > 30)
            str = Strings.Left(str, 30) + "...";
          this.ChallengeListObj.add(str, this.game.EditObj.ServerChallengeList[index].challengeID, tvalue, Conversions.ToString(this.game.EditObj.ServerChallengeList[index].dateIssued), tvalue3);
        }
      }
      ListClass challengeListObj = this.ChallengeListObj;
      int tlistselect = num;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(challengeListObj, 18, 680, tlistselect, game, tHeaderCenter: false, tShowPair: true, tValueWidth: 490, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: 60, bby: 130, tMarcStyle: true, overruleFont: (ref local2));
      this.ChallengeListId = this.AddSubPart(ref tsubpart, 60, 130, 680, 304, 0);
      this.DrawOtherChallengesTabRefresh();
    }

    public void DrawOtherChallengesTabRefresh()
    {
      this.game.EditObj.PbemCheckPlayer = "";
      if (this.AcceptChallengeId > 0)
        this.RemoveSubPart(this.AcceptChallengeId);
      if (this.AcceptChallengeId2 > 0)
        this.RemoveSubPart(this.AcceptChallengeId2);
      if (this.PlayTurnId > 0)
        this.RemoveSubPart(this.PlayTurnId);
      if (this.PlayTurn2id > 0)
        this.RemoveSubPart(this.PlayTurn2id);
      if (this.PreviewId > 0)
        this.RemoveSubPart(this.PreviewId);
      if (this.Preview2Id > 0)
        this.RemoveSubPart(this.Preview2Id);
      if (this.textid > 0)
        this.RemoveSubPart(this.textid);
      if (this.CancelId > 0)
        this.RemoveSubPart(this.CancelId);
      if (this.ClaimId > 0)
        this.RemoveSubPart(this.ClaimId);
      if (this.CancelId > 0)
        this.RemoveSubPart(this.Cancel2Id);
      if (this.Claim2Id > 0)
        this.RemoveSubPart(this.Claim2Id);
      if (this.PassId > 0)
      {
        this.RemoveSubPart(this.PassId);
        this.PassId = 0;
      }
      if (this.PassTextId > 0)
      {
        this.RemoveSubPart(this.PassTextId);
        this.PassTextId = 0;
      }
      if (this.CheckPlayerId > 0)
        this.RemoveSubPart(this.CheckPlayerId);
      if (this.CheckPlayerId2 > 0)
        this.RemoveSubPart(this.CheckPlayerId2);
      int index1 = -1;
      this.selectedid = -1;
      string tText;
      SubPartClass tsubpart1;
      if (this.gamenr > -1)
      {
        int upperBound = this.game.EditObj.ServerChallengeList.GetUpperBound(0);
        for (int index2 = 0; index2 <= upperBound; ++index2)
        {
          if (this.gamenr == this.game.EditObj.ServerChallengeList[index2].challengeID)
            index1 = index2;
        }
        tText = "-error with this challenge-";
        this.game.EditObj.PbemChallengeMiscData = this.game.EditObj.ServerChallengeList[index1].miscData;
        string InputStr = Strings.Mid(this.game.EditObj.PbemChallengeMiscData, 33, 8);
        int num;
        try
        {
          num = (int) Math.Round(Conversion.Val(InputStr));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          num = 0;
          ProjectData.ClearProjectError();
        }
        if (num > 999)
          num = 0;
        string str1;
        if (index1 > -1)
        {
          str1 = "";
          int Start = 32;
          do
          {
            if (Operators.CompareString(Strings.Mid(this.game.EditObj.ServerChallengeList[index1].miscData, Start, 1), " ", false) != 0)
              str1 = Strings.Mid(this.game.EditObj.ServerChallengeList[index1].miscData, Start, 1) + str1;
            Start += -1;
          }
          while (Start >= 1);
          string str2 = "GAME NAME: " + this.game.EditObj.ServerChallengeList[index1].gameName + "\r\n" + "CHALLENGER: " + this.game.EditObj.ServerChallengeList[index1].challengerUserName + "\r\n";
          this.game.EditObj.PbemCheckPlayer = this.game.EditObj.ServerChallengeList[index1].challengerUserName;
          string str3;
          if (File.Exists(this.game.AppPath + this.game.ModScenarioDir + "\\" + str1))
          {
            str3 = str2 + "FILE NAME: " + str1 + " : YOU HAVE THIS FILE AS WELL\r\n";
            if (Operators.CompareString(this.game.HandyFunctionsObj.GetFileCRC(this.game.ModScenarioDir + "\\" + str1), Strings.Mid(this.game.EditObj.ServerChallengeList[index1].miscData, 33, 8), false) != 0)
              ;
          }
          else
            str3 = str2 + "FILE NAME: " + str1 + " : YOU DO NOT HAVE THIS FILE!\r\n";
          tText = (num <= 0 ? str3 + "CHALLENGER GAME VERSION: older\r\n" : str3 + "CHALLENGER GAME VERSION: " + num.ToString() + "\r\n") + "SETTINGS: " + Strings.Mid(this.game.EditObj.ServerChallengeList[index1].miscData, 41, 4) + "\r\n" + "VARIANTS: " + Strings.Mid(this.game.EditObj.ServerChallengeList[index1].miscData, 45, 12) + "\r\n";
        }
        if (num > 110)
        {
          SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("ACCEPT CHALLENGE", 240, "Your game version is to low to play with this oppponent. Please upgrade your game to the latest version. ", ref this.OwnBitmap, 60, 620, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.AcceptChallengeId2 = this.AddSubPart(ref tsubpart2, 60, 620, 240, 50, 1);
        }
        else
        {
          SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("ACCEPT CHALLENGE", 240, "Accept the selected challenge and start up a PBEM++ game with the challenger.", ref this.OwnBitmap, 60, 620, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.AcceptChallengeId = this.AddSubPart(ref tsubpart3, 60, 620, 240, 50, 1);
        }
        this.AcceptUsePass = false;
        if (this.game.EditObj.ServerChallengeList[index1].challengePrivate == 1)
        {
          this.AcceptUsePass = true;
          Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
          if (Information.IsNothing((object) this.game.EditObj.PbemPrivatePassword))
            this.game.EditObj.PbemPrivatePassword = "";
          SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("Private Password:", this.game.MarcFont4, 160, 20, false, tMarc: true);
          this.PassTextId = this.AddSubPart(ref tsubpart4, 580, 620, 160, 20, 0);
          SubPartClass tsubpart5 = (SubPartClass) new InputTextClass(this.game.EditObj.PbemPrivatePassword, this.game.MarcFont4, 160, 36, false, 20, true);
          this.PassId = this.AddSubPart(ref tsubpart5, 580, 643, 160, 36, 0);
          graphics.Dispose();
        }
        if (File.Exists(this.game.AppPath + this.game.ModScenarioDir + "\\" + str1))
        {
          if (num <= 110)
          {
            SubPartClass tsubpart6 = (SubPartClass) new TextButtonPartClass("PREVIEW SCENARIO", 240, "Loads a local copy the challenge with the same filename\r\nand will show it with the challengers configuration.", ref this.OwnBitmap, 320, 620, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
            this.PreviewId = this.AddSubPart(ref tsubpart6, 320, 620, 240, 50, 1);
          }
          else
          {
            SubPartClass tsubpart7 = (SubPartClass) new TextButtonPartClass("PREVIEW SCENARIO", 240, "Your game version is to low to play with this opponent. Please upgrade your game to the latest version.", ref this.OwnBitmap, 320, 620, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
            this.Preview2Id = this.AddSubPart(ref tsubpart7, 320, 620, 240, 50, 1);
          }
        }
        else
        {
          SubPartClass tsubpart8 = (SubPartClass) new TextButtonPartClass("PREVIEW SCENARIO", 240, "You dont have the same file as the challenger used.\r\nMaybe check the forums to find out where to get it.", ref this.OwnBitmap, 320, 620, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.Preview2Id = this.AddSubPart(ref tsubpart8, 320, 620, 240, 50, 1);
        }
      }
      else
      {
        tText = "-no scenario selected-";
        SubPartClass tsubpart9 = (SubPartClass) new TextButtonPartClass("ACCEPT CHALLENGE", 240, "You have to select a challenge in order for you to be able to use this button.", ref this.OwnBitmap, 60, 620, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.AcceptChallengeId2 = this.AddSubPart(ref tsubpart9, 60, 620, 240, 50, 1);
        tsubpart1 = (SubPartClass) new TextButtonPartClass("PREVIEW SCENARIO", 240, "You have to select a challenge in order for you to be able to use this button.", ref this.OwnBitmap, 320, 620, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.Preview2Id = this.AddSubPart(ref tsubpart1, 320, 620, 240, 50, 1);
      }
      tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 680, 7, this.game.MarcFont4, tText, tbackbitmap: (ref this.OwnBitmap), bbx: 60, bby: 450);
      this.textid = this.AddSubPart(ref tsubpart1, 60, 450, 680, 160, 0);
    }

    public void DrawCurrentGamesTab(Graphics g)
    {
      this.game.EditObj.PbemCheckPlayer = "";
      if (this.ChallengeListId > 0)
        this.RemoveSubPart(this.ChallengeListId);
      if (Information.IsNothing((object) this.game.EditObj.ServerChallengeList) || Information.IsNothing((object) this.game.EditObj.ServerRunningGameList))
        return;
      this.ChallengeListObj = new ListClass();
      int num = -1;
      int upperBound = this.game.EditObj.ServerRunningGameList.GetUpperBound(0);
      for (int index = 0; index <= upperBound; ++index)
      {
        if (this.gamenr == this.game.EditObj.ServerRunningGameList[index].gameInstanceID)
        {
          num = index;
          this.game.EditObj.PbemGameID = this.game.EditObj.ServerRunningGameList[index].gameInstanceID;
          this.game.EditObj.PbemPlayer1 = this.game.EditObj.ServerRunningGameList[index].Player1UserName;
          this.game.EditObj.PbemPlayer2 = this.game.EditObj.ServerRunningGameList[index].Player2UserName;
          if (this.game.EditObj.ServerRunningGameList[index].GameOver)
            this.game.EditObj.PbemGameOver = 1;
          else
            this.game.EditObj.PbemGameOver = 0;
          this.game.EditObj.PbemChallengeMiscData = "";
        }
        bool flag = true;
        string str1 = "Round " + Strings.Trim(Conversion.Str((object) this.game.EditObj.ServerRunningGameList[index].TurnNo)) + ", Turn: ";
        string tvalue2 = Operators.CompareString(this.game.EditObj.ServerRunningGameList[index].playerToUserName, this.game.EditObj.ServerRunningGameList[index].Player1UserName, false) != 0 ? str1 + this.game.EditObj.ServerRunningGameList[index].Player2UserName : str1 + this.game.EditObj.ServerRunningGameList[index].Player1UserName;
        string tvalue3 = Conversions.ToString(this.game.EditObj.ServerRunningGameList[index].lastUploaded);
        if (this.game.EditObj.ServerRunningGameList[index].GameOver)
        {
          tvalue3 = (double) this.game.EditObj.ServerRunningGameList[index].Player1Losses != (double) this.game.EditObj.ServerRunningGameList[index].Player2Losses ? ((double) this.game.EditObj.ServerRunningGameList[index].Player1Losses >= (double) this.game.EditObj.ServerRunningGameList[index].Player2Losses ? this.game.EditObj.ServerRunningGameList[index].Player2UserName + " WON GAME " : this.game.EditObj.ServerRunningGameList[index].Player1UserName + " WON GAME ") : "DRAW GAME ";
          if (this.game.EditObj.ServerRunningGameList[index].Viewed == 1)
          {
            flag = false;
            tvalue3 += "(viewed)";
          }
          else if (Operators.CompareString(Strings.UCase(this.game.EditObj.ServerRunningGameList[index].playerToUserName), Strings.UCase(this.game.EditObj.PbemUserName), false) != 0)
          {
            flag = false;
            tvalue3 += "(viewed by you)";
          }
        }
        if (flag)
        {
          string str2 = this.game.EditObj.ServerRunningGameList[index].GameName;
          if (str2.Length > 22)
            str2 = Strings.Left(str2, 22) + "...";
          this.ChallengeListObj.add(str2, this.game.EditObj.ServerRunningGameList[index].gameInstanceID, this.game.EditObj.ServerRunningGameList[index].Player1UserName + " VS " + this.game.EditObj.ServerRunningGameList[index].Player2UserName, tvalue2, tvalue3);
        }
      }
      ListClass challengeListObj = this.ChallengeListObj;
      int tlistselect = num;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(challengeListObj, 18, 680, tlistselect, game, tHeaderCenter: false, tShowPair: true, tValueWidth: 510, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: 60, bby: 130, tMarcStyle: true, overruleFont: (ref local2));
      this.ChallengeListId = this.AddSubPart(ref tsubpart, 60, 130, 680, 304, 0);
      this.DrawCurrentGamesTabRefresh();
    }

    public void DrawCurrentGamesTabRefresh()
    {
      this.game.EditObj.PbemCheckPlayer = "";
      if (this.PlayTurnId > 0)
        this.RemoveSubPart(this.PlayTurnId);
      if (this.PlayTurn2id > 0)
        this.RemoveSubPart(this.PlayTurn2id);
      if (this.AcceptChallengeId > 0)
        this.RemoveSubPart(this.AcceptChallengeId);
      if (this.AcceptChallengeId2 > 0)
        this.RemoveSubPart(this.AcceptChallengeId2);
      if (this.PreviewId > 0)
        this.RemoveSubPart(this.PreviewId);
      if (this.Preview2Id > 0)
        this.RemoveSubPart(this.Preview2Id);
      if (this.textid > 0)
        this.RemoveSubPart(this.textid);
      if (this.CancelId > 0)
        this.RemoveSubPart(this.CancelId);
      if (this.ClaimId > 0)
        this.RemoveSubPart(this.ClaimId);
      if (this.CancelId > 0)
        this.RemoveSubPart(this.Cancel2Id);
      if (this.Claim2Id > 0)
        this.RemoveSubPart(this.Claim2Id);
      if (this.PassId > 0)
      {
        this.RemoveSubPart(this.PassId);
        this.PassId = 0;
      }
      if (this.PassTextId > 0)
      {
        this.RemoveSubPart(this.PassTextId);
        this.PassTextId = 0;
      }
      if (this.CheckPlayerId > 0)
        this.RemoveSubPart(this.CheckPlayerId);
      if (this.CheckPlayerId2 > 0)
        this.RemoveSubPart(this.CheckPlayerId2);
      bool flag1 = false;
      bool flag2;
      bool flag3;
      string tText;
      if (this.gamenr > -1)
      {
        int upperBound = this.game.EditObj.ServerRunningGameList.GetUpperBound(0);
        for (int index = 0; index <= upperBound; ++index)
        {
          if (this.gamenr == this.game.EditObj.ServerRunningGameList[index].gameInstanceID)
          {
            this.game.EditObj.PbemGameID = this.game.EditObj.ServerRunningGameList[index].gameInstanceID;
            this.game.EditObj.PbemPlayer1 = this.game.EditObj.ServerRunningGameList[index].Player1UserName;
            this.game.EditObj.PbemPlayer2 = this.game.EditObj.ServerRunningGameList[index].Player2UserName;
            if (this.game.EditObj.ServerRunningGameList[index].GameOver)
            {
              this.game.EditObj.PbemGameOver = 1;
              flag2 = true;
            }
            else
              this.game.EditObj.PbemGameOver = 0;
            this.game.EditObj.PbemChallengeMiscData = "";
            if (Operators.CompareString(Strings.UCase(this.game.EditObj.ServerRunningGameList[index].playerToUserName), Strings.UCase(this.game.EditObj.PbemUserName), false) != 0)
              flag3 = true;
            int num;
            try
            {
              num = (int) Math.Round(Conversion.Val(Strings.Mid(this.game.EditObj.ServerRunningGameList[index].MiscData, 33, 8)));
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              num = 0;
              ProjectData.ClearProjectError();
            }
            if (num > 999)
              num = 0;
            if (num > 110)
              flag1 = true;
            if (this.gamenr > -1)
            {
              string str1 = "GAME NAME: " + this.game.EditObj.ServerRunningGameList[index].GameName + "\r\n" + "CHALLENGER: " + this.game.EditObj.ServerRunningGameList[index].Player1UserName + "\r\n" + "OPPONENT: " + this.game.EditObj.ServerRunningGameList[index].Player2UserName + "\r\n";
              string str2 = num <= 0 ? str1 + "VERSION: older\r\n" : str1 + "VERSION: " + num.ToString() + "\r\n";
              if (Operators.CompareString(Strings.UCase(this.game.EditObj.PbemUserName), Strings.UCase(this.game.EditObj.ServerRunningGameList[index].Player1UserName), false) == 0)
                this.game.EditObj.PbemCheckPlayer = this.game.EditObj.ServerRunningGameList[index].Player2UserName;
              else
                this.game.EditObj.PbemCheckPlayer = this.game.EditObj.ServerRunningGameList[index].Player1UserName;
              tText = str2 + "CURRENT TURN: " + this.game.EditObj.ServerRunningGameList[index].playerToUserName + "\r\n" + "DATE STARTED: " + Conversions.ToString(this.game.EditObj.ServerRunningGameList[index].DateIssued) + ", DATE LAST TURN: " + Conversions.ToString(this.game.EditObj.ServerRunningGameList[index].lastUploaded) + "\r\n";
              if (this.game.EditObj.ServerRunningGameList[index].GameOver)
              {
                string str3 = tText + "GAME IS OVER. GAME ENDED ON: " + Conversions.ToString(this.game.EditObj.ServerRunningGameList[index].lastTurnUploaded) + "\r\n";
                string str4 = (double) this.game.EditObj.ServerRunningGameList[index].Player1Losses >= (double) this.game.EditObj.ServerRunningGameList[index].Player2Losses ? str3 + "WINNER: " + this.game.EditObj.ServerRunningGameList[index].Player2UserName + " WON GAME " : str3 + "WINNER: " + this.game.EditObj.ServerRunningGameList[index].Player1UserName + " WON GAME ";
                tText = (this.game.EditObj.ServerRunningGameList[index].Viewed != 1 ? str4 + ", VIEWED: NO" : str4 + ", VIEWED: YES") + "\r\n";
              }
            }
          }
        }
      }
      else
        tText = "-no scenario selected-";
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 680, 7, this.game.MarcFont4, tText, tbackbitmap: (ref this.OwnBitmap), bbx: 60, bby: 450);
      this.textid = this.AddSubPart(ref tsubpart1, 60, 450, 680, 160, 0);
      if (this.gamenr > -1)
      {
        if (flag3)
        {
          SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("PLAY TURN", 240, "Cannot play turn because it is not your turn.", ref this.OwnBitmap, 60, 620, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.PlayTurn2id = this.AddSubPart(ref tsubpart2, 60, 620, 240, 50, 1);
        }
        else if (flag1)
        {
          SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("PLAY TURN", 240, "Cannot play turn because your version is lower than that of your opponent. Please upgrade your game to the lowest version. ", ref this.OwnBitmap, 60, 620, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.PlayTurn2id = this.AddSubPart(ref tsubpart3, 60, 620, 240, 50, 1);
        }
        else
        {
          SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("PLAY TURN", 240, "Click to play your turn in this PBEM game.", ref this.OwnBitmap, 60, 620, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.PlayTurnId = this.AddSubPart(ref tsubpart4, 60, 620, 240, 50, 1);
        }
        if (!flag2)
        {
          SubPartClass tsubpart5 = (SubPartClass) new TextButtonPartClass("CLAIM GAME", 240, "If other side has not played its turn for 30 days you can claim victory.\r\nand will show it with the challengers configuration.", ref this.OwnBitmap, 320, 620, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.ClaimId = this.AddSubPart(ref tsubpart5, 320, 620, 240, 50, 1);
        }
        else
        {
          SubPartClass tsubpart6 = (SubPartClass) new TextButtonPartClass("CLAIM GAME", 240, "You cannot attempt to claim a game thats already over.", ref this.OwnBitmap, 320, 620, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.Claim2Id = this.AddSubPart(ref tsubpart6, 320, 620, 240, 50, 1);
        }
        if (this.game.EditObj.PbemCheckPlayer.Length > 0)
          ;
      }
      else
      {
        SubPartClass tsubpart7 = (SubPartClass) new TextButtonPartClass("PLAY TURN", 240, "Cannot play turn because you have not selected a game from the list.", ref this.OwnBitmap, 60, 620, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.PlayTurn2id = this.AddSubPart(ref tsubpart7, 60, 620, 240, 50, 1);
        SubPartClass tsubpart8 = (SubPartClass) new TextButtonPartClass("CLAIM GAME", 240, "Cannot claim because no running game from the list above has been selected.", ref this.OwnBitmap, 320, 620, true, theight: 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.Claim2Id = this.AddSubPart(ref tsubpart8, 320, 620, 240, 50, 1);
      }
    }

    public void DrawFinishedGamesTab(Graphics g)
    {
      this.game.EditObj.PbemCheckPlayer = "";
      if (this.ChallengeListId > 0)
        this.RemoveSubPart(this.ChallengeListId);
      if (Information.IsNothing((object) this.game.EditObj.ServerChallengeList) || Information.IsNothing((object) this.game.EditObj.ServerRunningGameList))
        return;
      this.ChallengeListObj = new ListClass();
      int num = -1;
      int upperBound = this.game.EditObj.ServerRunningGameList.GetUpperBound(0);
      for (int index = 0; index <= upperBound; ++index)
      {
        bool flag = false;
        if (this.gamenr == this.game.EditObj.ServerRunningGameList[index].gameInstanceID)
        {
          num = index;
          this.game.EditObj.PbemGameID = this.game.EditObj.ServerRunningGameList[index].gameInstanceID;
          this.game.EditObj.PbemPlayer1 = this.game.EditObj.ServerRunningGameList[index].Player1UserName;
          this.game.EditObj.PbemPlayer2 = this.game.EditObj.ServerRunningGameList[index].Player2UserName;
          if (this.game.EditObj.ServerRunningGameList[index].GameOver)
            this.game.EditObj.PbemGameOver = 1;
          else
            this.game.EditObj.PbemGameOver = 0;
          this.game.EditObj.PbemChallengeMiscData = "";
        }
        string str1 = "Round " + Strings.Trim(Conversion.Str((object) this.game.EditObj.ServerRunningGameList[index].TurnNo)) + ", Turn: ";
        string tvalue2 = Operators.CompareString(this.game.EditObj.ServerRunningGameList[index].playerToUserName, this.game.EditObj.ServerRunningGameList[index].Player1UserName, false) != 0 ? str1 + this.game.EditObj.ServerRunningGameList[index].Player2UserName : str1 + this.game.EditObj.ServerRunningGameList[index].Player1UserName;
        Conversions.ToString(this.game.EditObj.ServerRunningGameList[index].lastUploaded);
        if (this.game.EditObj.ServerRunningGameList[index].GameOver)
        {
          string tvalue3 = (double) this.game.EditObj.ServerRunningGameList[index].Player1Losses != (double) this.game.EditObj.ServerRunningGameList[index].Player2Losses ? ((double) this.game.EditObj.ServerRunningGameList[index].Player1Losses >= (double) this.game.EditObj.ServerRunningGameList[index].Player2Losses ? this.game.EditObj.ServerRunningGameList[index].Player2UserName + " WON GAME " : this.game.EditObj.ServerRunningGameList[index].Player1UserName + " WON GAME ") : "DRAW GAME ";
          if (this.game.EditObj.ServerRunningGameList[index].Viewed == 1)
          {
            tvalue3 += "(viewed)";
            flag = true;
          }
          else if (Operators.CompareString(Strings.UCase(this.game.EditObj.ServerRunningGameList[index].playerToUserName), Strings.UCase(this.game.EditObj.PbemUserName), false) != 0)
          {
            tvalue3 += "(viewed by you)";
            flag = true;
          }
          if (flag)
          {
            string str2 = this.game.EditObj.ServerRunningGameList[index].GameName;
            if (str2.Length > 22)
              str2 = Strings.Left(str2, 22) + "...";
            this.ChallengeListObj.add(str2, this.game.EditObj.ServerRunningGameList[index].gameInstanceID, this.game.EditObj.ServerRunningGameList[index].Player1UserName + " VS " + this.game.EditObj.ServerRunningGameList[index].Player2UserName, tvalue2, tvalue3);
          }
        }
      }
      ListClass challengeListObj = this.ChallengeListObj;
      int tlistselect = num;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(challengeListObj, 18, 680, tlistselect, game, tHeaderCenter: false, tShowPair: true, tValueWidth: 510, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: 60, bby: 130, tMarcStyle: true, overruleFont: (ref local2));
      this.ChallengeListId = this.AddSubPart(ref tsubpart, 60, 130, 680, 304, 0);
      this.DrawFinishedGamesTabRefresh();
    }

    public void DrawFinishedGamesTabRefresh()
    {
      this.game.EditObj.PbemCheckPlayer = "";
      if (this.PlayTurnId > 0)
        this.RemoveSubPart(this.PlayTurnId);
      if (this.PlayTurn2id > 0)
        this.RemoveSubPart(this.PlayTurn2id);
      if (this.AcceptChallengeId > 0)
        this.RemoveSubPart(this.AcceptChallengeId);
      if (this.AcceptChallengeId2 > 0)
        this.RemoveSubPart(this.AcceptChallengeId2);
      if (this.PreviewId > 0)
        this.RemoveSubPart(this.PreviewId);
      if (this.Preview2Id > 0)
        this.RemoveSubPart(this.Preview2Id);
      if (this.textid > 0)
        this.RemoveSubPart(this.textid);
      if (this.CancelId > 0)
        this.RemoveSubPart(this.CancelId);
      if (this.ClaimId > 0)
        this.RemoveSubPart(this.ClaimId);
      if (this.CancelId > 0)
        this.RemoveSubPart(this.Cancel2Id);
      if (this.Claim2Id > 0)
        this.RemoveSubPart(this.Claim2Id);
      if (this.PassId > 0)
      {
        this.RemoveSubPart(this.PassId);
        this.PassId = 0;
      }
      if (this.PassTextId > 0)
      {
        this.RemoveSubPart(this.PassTextId);
        this.PassTextId = 0;
      }
      if (this.CheckPlayerId > 0)
        this.RemoveSubPart(this.CheckPlayerId);
      if (this.CheckPlayerId2 > 0)
        this.RemoveSubPart(this.CheckPlayerId2);
      string tText;
      if (this.gamenr > -1)
      {
        int upperBound = this.game.EditObj.ServerRunningGameList.GetUpperBound(0);
        for (int index = 0; index <= upperBound; ++index)
        {
          if (this.gamenr == this.game.EditObj.ServerRunningGameList[index].gameInstanceID)
          {
            this.game.EditObj.PbemGameID = this.game.EditObj.ServerRunningGameList[index].gameInstanceID;
            this.game.EditObj.PbemPlayer1 = this.game.EditObj.ServerRunningGameList[index].Player1UserName;
            this.game.EditObj.PbemPlayer2 = this.game.EditObj.ServerRunningGameList[index].Player2UserName;
            if (this.game.EditObj.ServerRunningGameList[index].GameOver)
              this.game.EditObj.PbemGameOver = 1;
            else
              this.game.EditObj.PbemGameOver = 0;
            this.game.EditObj.PbemChallengeMiscData = "";
            if (Operators.CompareString(Strings.UCase(this.game.EditObj.ServerRunningGameList[index].playerToUserName), Strings.UCase(this.game.EditObj.PbemUserName), false) != 0)
              ;
            if (this.gamenr > -1)
            {
              string str1 = "GAME NAME: " + this.game.EditObj.ServerRunningGameList[index].GameName + "\r\n" + "CHALLENGER: " + this.game.EditObj.ServerRunningGameList[index].Player1UserName + "\r\n" + "OPPONENT: " + this.game.EditObj.ServerRunningGameList[index].Player2UserName + "\r\n";
              if (Operators.CompareString(Strings.UCase(this.game.EditObj.PbemUserName), Strings.UCase(this.game.EditObj.ServerRunningGameList[index].Player1UserName), false) == 0)
                this.game.EditObj.PbemCheckPlayer = this.game.EditObj.ServerRunningGameList[index].Player2UserName;
              else
                this.game.EditObj.PbemCheckPlayer = this.game.EditObj.ServerRunningGameList[index].Player1UserName;
              tText = str1 + "CURRENT TURN: " + this.game.EditObj.ServerRunningGameList[index].playerToUserName + "\r\n" + "DATE STARTED: " + Conversions.ToString(this.game.EditObj.ServerRunningGameList[index].DateIssued) + ", DATE LAST TURN: " + Conversions.ToString(this.game.EditObj.ServerRunningGameList[index].lastUploaded) + "\r\n";
              if (this.game.EditObj.ServerRunningGameList[index].GameOver)
              {
                string str2 = tText + "GAME IS OVER. GAME ENDED ON: " + Conversions.ToString(this.game.EditObj.ServerRunningGameList[index].lastTurnUploaded) + "\r\n";
                string str3 = (double) this.game.EditObj.ServerRunningGameList[index].Player1Losses >= (double) this.game.EditObj.ServerRunningGameList[index].Player2Losses ? str2 + "WINNER: " + this.game.EditObj.ServerRunningGameList[index].Player2UserName + " WON GAME " : str2 + "WINNER: " + this.game.EditObj.ServerRunningGameList[index].Player1UserName + " WON GAME ";
                tText = (this.game.EditObj.ServerRunningGameList[index].Viewed != 1 ? str3 + ", VIEWED BY BOTH: NO" : str3 + ", VIEWED BY BOTH: YES") + "\r\n";
              }
            }
          }
        }
      }
      else
        tText = "-no scenario selected-";
      SubPartClass tsubpart = (SubPartClass) new TextAreaClass2(this.game, 680, 7, this.game.MarcFont4, tText, tbackbitmap: (ref this.OwnBitmap), bbx: 60, bby: 450);
      this.textid = this.AddSubPart(ref tsubpart, 60, 450, 680, 160, 0);
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      if (nr != 27)
        return windowReturnClass1;
      WindowReturnClass windowReturnClass2 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.BackId)] + 1, this.SubPartY[this.SubpartNr(this.BackId)] + 1, 1);
      windowReturnClass2.SetFlag(true);
      return windowReturnClass2;
    }

    public void DrawTab0(Graphics g, bool active = false)
    {
      SizeF sizeF1 = new SizeF();
      int x1 = 40;
      int y1 = 80;
      if (active)
      {
        ref Graphics local1 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local2 = ref bitmap;
        int x2 = x1;
        int y2 = y1;
        DrawMod.DrawSimple(ref local1, ref local2, x2, y2);
      }
      else
      {
        ref Graphics local3 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local4 = ref bitmap;
        int x3 = x1;
        int y3 = y1;
        DrawMod.Draw(ref local3, ref local4, x3, y3, -0.1f, -0.1f, -0.1f, 1f);
      }
      string str = "FINISHED GAMES";
      SizeF sizeF2 = g.MeasureString(str, this.game.MarcFont16);
      int x4 = (int) Math.Round((double) ((float) (x1 + 91) - sizeF2.Width / 2f));
      DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, x4, y1 + 4, Color.White);
      Rectangle trect = new Rectangle(x1, y1, 182, 24);
      this.AddMouse(ref trect, "", "See PBEM games you are playing in that are finished.", 100);
    }

    public void DrawTab1(Graphics g, bool active = false)
    {
      SizeF sizeF1 = new SizeF();
      int x1 = 210;
      int y1 = 80;
      if (active)
      {
        ref Graphics local1 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local2 = ref bitmap;
        int x2 = x1;
        int y2 = y1;
        DrawMod.DrawSimple(ref local1, ref local2, x2, y2);
      }
      else
      {
        ref Graphics local3 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local4 = ref bitmap;
        int x3 = x1;
        int y3 = y1;
        DrawMod.Draw(ref local3, ref local4, x3, y3, -0.1f, -0.1f, -0.1f, 1f);
      }
      string str = "RUNNING GAMES";
      SizeF sizeF2 = g.MeasureString(str, this.game.MarcFont16);
      int x4 = (int) Math.Round((double) ((float) (x1 + 91) - sizeF2.Width / 2f));
      DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, x4, y1 + 4, Color.White);
      Rectangle trect = new Rectangle(x1, y1, 182, 24);
      this.AddMouse(ref trect, "", "See PBEM games you are playing in that are currently running.", 101);
    }

    public void DrawTab2(Graphics g, bool active = false)
    {
      SizeF sizeF1 = new SizeF();
      int x1 = 380;
      int y1 = 80;
      if (active)
      {
        ref Graphics local1 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local2 = ref bitmap;
        int x2 = x1;
        int y2 = y1;
        DrawMod.DrawSimple(ref local1, ref local2, x2, y2);
      }
      else
      {
        ref Graphics local3 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local4 = ref bitmap;
        int x3 = x1;
        int y3 = y1;
        DrawMod.Draw(ref local3, ref local4, x3, y3, -0.1f, -0.1f, -0.1f, 1f);
      }
      string str = "YOUR CHALLENGES";
      SizeF sizeF2 = g.MeasureString(str, this.game.MarcFont16);
      int x4 = (int) Math.Round((double) ((float) (x1 + 91) - sizeF2.Width / 2f));
      DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, x4, y1 + 4, Color.White);
      Rectangle trect = new Rectangle(x1, y1, 182, 24);
      this.AddMouse(ref trect, "", "See challenges for PBEM games that you issued..", 102);
    }

    public void DrawTab3(Graphics g, bool active = false)
    {
      SizeF sizeF1 = new SizeF();
      int x1 = 550;
      int y1 = 80;
      if (active)
      {
        ref Graphics local1 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local2 = ref bitmap;
        int x2 = x1;
        int y2 = y1;
        DrawMod.DrawSimple(ref local1, ref local2, x2, y2);
      }
      else
      {
        ref Graphics local3 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local4 = ref bitmap;
        int x3 = x1;
        int y3 = y1;
        DrawMod.Draw(ref local3, ref local4, x3, y3, -0.1f, -0.1f, -0.1f, 1f);
      }
      string str = "OTHER CHALLENGES";
      SizeF sizeF2 = g.MeasureString(str, this.game.MarcFont16);
      int x4 = (int) Math.Round((double) ((float) (x1 + 91) - sizeF2.Width / 2f));
      DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, x4, y1 + 4, Color.White);
      Rectangle trect = new Rectangle(x1, y1, 182, 24);
      this.AddMouse(ref trect, "", "See challenges that other players have issued.", 103);
    }

    public override WindowReturnClass handleTimer()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.game.EditObj.LoadingResult == LoadType.FirstScreen)
      {
        if (this.game.EditObj.ServerCommand == ServerCommandType.PlayTurn)
        {
          this.game.Data.PbemGameID = this.game.EditObj.PbemGameID;
          this.game.Data.PbemPlayer1 = this.game.EditObj.PbemPlayer1;
          this.game.Data.PbemPlayer2 = this.game.EditObj.PbemPlayer2;
          this.game.Data.PbemGameOver = this.game.EditObj.PbemGameOver;
          this.game.EditObj.LoadNoNewEdit = false;
          this.game.EditObj.PbemGameSetup = PbemGameSetupPhase.PlayTurn;
          this.game.EditObj.PbemInspectReturnFromID = this.gamenr;
        }
        this.game.EditObj.LoadingResult = LoadType.None;
        this.game.EditObj.ShownWelcome = true;
        this.game.EditObj.ShowInitialMenu = false;
        windowReturnClass.AddCommand(3, 12);
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      if (this.game.EditObj.LoadingResult == LoadType.PlayScreen)
      {
        if (this.game.EditObj.ServerCommand == ServerCommandType.PlayTurn)
        {
          this.game.Data.PbemGameID = this.game.EditObj.PbemGameID;
          this.game.Data.PbemPlayer1 = this.game.EditObj.PbemPlayer1;
          this.game.Data.PbemPlayer2 = this.game.EditObj.PbemPlayer2;
          this.game.Data.PbemGameOver = this.game.EditObj.PbemGameOver;
          this.game.EditObj.LoadingResult = LoadType.None;
          windowReturnClass.AddCommand(3, 11);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
        this.game.EditObj.LoadingResult = LoadType.None;
        int num = (int) Interaction.MsgBox((object) "You cannot use the selected file for making a challenge since this game has already begun.", Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
      if (this.game.EditObj.LoadingResult == LoadType.GameLoop)
      {
        if (this.game.EditObj.ServerCommand == ServerCommandType.PlayTurn)
        {
          this.game.Data.PbemGameID = this.game.EditObj.PbemGameID;
          this.game.Data.PbemPlayer1 = this.game.EditObj.PbemPlayer1;
          this.game.Data.PbemPlayer2 = this.game.EditObj.PbemPlayer2;
          this.game.Data.PbemGameOver = this.game.EditObj.PbemGameOver;
          this.game.EditObj.LoadingResult = LoadType.None;
          windowReturnClass.AddCommand(3, 13);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
        this.game.EditObj.LoadingResult = LoadType.None;
        int num = (int) Interaction.MsgBox((object) "You cannot use the selected file for making a challenge since this game has already begun.", Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
      if (this.game.EditObj.PbemGameSetup == PbemGameSetupPhase.ChallengeMade)
      {
        this.game.FormRef.Cursor = Cursors.WaitCursor;
        this.game.HandyFunctionsObj.SetPbemMiscString();
        this.game.EditObj.PbemGameSetup = PbemGameSetupPhase.Saving;
        string str = this.game.AppPath + "savedgames\\uploadfile.se1";
        this.game.Data.serialize(str);
        this.game.HandyFunctionsObj.ZipFile(str);
        this.game.FormRef.Cursor = Cursors.Default;
        this.game.EditObj.PbemGameSetup = PbemGameSetupPhase.Saved;
        return windowReturnClass;
      }
      if (this.game.EditObj.PbemGameSetup == PbemGameSetupPhase.Saved)
      {
        this.game.EditObj.PbemGameSetup = PbemGameSetupPhase.None;
        this.game.EditObj.ServerCommand = ServerCommandType.Challenge;
        this.game.HandyFunctionsObj.SetUploadFile("savedgames\\uploadfile.se1");
        this.game.EditObj.PopupValue = 15;
        windowReturnClass.AddCommand(5, 14);
        this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      if (this.game.EditObj.PbemGameSetup == PbemGameSetupPhase.TurnPlayed)
      {
        this.game.EditObj.PbemGameSetup = PbemGameSetupPhase.None;
        this.game.EditObj.ServerCommand = ServerCommandType.UploadInstance;
        this.game.HandyFunctionsObj.SetUploadFile("savedgames\\uploadfile.se1");
        this.game.EditObj.PopupValue = 15;
        windowReturnClass.AddCommand(5, 14);
        this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      if (this.game.EditObj.PbemGameSetup == PbemGameSetupPhase.Cancel)
      {
        this.game.EditObj.PbemGameSetup = PbemGameSetupPhase.None;
        this.game.EditObj.FeedBackString = "Cancelled the setting up of a challenge";
        this.game.EditObj.OrderType = 0;
        DrawMod.TGame.EditObj.PopupValue = 5;
        windowReturnClass.AddCommand(5, 10);
        this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      if (this.game.EditObj.PbemGameSetup == PbemGameSetupPhase.CancelPlayTurn)
      {
        this.game.EditObj.PbemGameSetup = PbemGameSetupPhase.None;
        this.game.EditObj.FeedBackString = "Cancelled the playing of your turn.";
        this.game.EditObj.OrderType = 0;
        DrawMod.TGame.EditObj.PopupValue = 5;
        windowReturnClass.AddCommand(5, 10);
        this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      if (!Information.IsNothing((object) this.game.EditObj.TextInputString) && this.game.EditObj.TextInputString.Length > 0)
      {
        if (this.selectedid == this.PassId)
        {
          this.SubPartList[this.SubpartNr(this.selectedid)].Refresh(this.game.EditObj.TextInputString);
          this.SubPartFlag[this.SubpartNr(this.selectedid)] = true;
        }
        windowReturnClass.SetFlag(true);
      }
      this.game.EditObj.TextInputString = "";
      if (this.PassId > 0)
        this.game.EditObj.PbemPrivatePassword = this.SubPartList[this.SubpartNr(this.PassId)].GetText();
      return windowReturnClass;
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      for (int mouseCounter = this.MouseCounter; mouseCounter >= 0; mouseCounter += -1)
      {
        if (this.MouseData[mouseCounter] > 0 && x > this.MouseRect[mouseCounter].X & x < this.MouseRect[mouseCounter].X + this.MouseRect[mouseCounter].Width && y > this.MouseRect[mouseCounter].Y & y < this.MouseRect[mouseCounter].Y + this.MouseRect[mouseCounter].Height)
        {
          switch (this.MouseData[mouseCounter])
          {
            case 100:
              this.currentTab = 0;
              this.gamenr = -1;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            case 101:
              this.currentTab = 1;
              this.gamenr = -1;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            case 102:
              this.currentTab = 2;
              this.gamenr = -1;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            case 103:
              this.currentTab = 3;
              this.gamenr = -1;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            default:
              continue;
          }
        }
      }
      if (this.SubPartCounter > -1 & b == 1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            int num1 = this.SubPartID[index];
            if (num1 == this.PassId)
            {
              this.selectedid = this.PassId;
              this.SubPartList[this.SubpartNr(this.PassId)].Descript = "select";
              this.SubPartFlag[this.SubpartNr(this.PassId)] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BackId)
            {
              this.game.EditObj.ShowInitialMenu = true;
              windowReturnClass.AddCommand(3, 12);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.RegisterId)
            {
              this.game.EditObj.PopupValue = 14;
              windowReturnClass.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.LoginId)
            {
              this.game.EditObj.PopupValue = 16;
              windowReturnClass.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.RefreshId)
            {
              this.game.EditObj.PopupValue = 15;
              this.game.EditObj.ServerCommand = ServerCommandType.Refresh;
              windowReturnClass.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.LogOutId)
            {
              this.game.EditObj.PopupValue = 15;
              this.game.EditObj.ServerCommand = ServerCommandType.Logout;
              windowReturnClass.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ClaimId)
            {
              this.game.EditObj.PopupValue = 15;
              this.game.EditObj.ServerCommand = ServerCommandType.Claim;
              windowReturnClass.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.CancelId)
            {
              this.game.EditObj.PopupValue = 15;
              this.game.EditObj.ServerCommand = ServerCommandType.CancelChallenge;
              windowReturnClass.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.CheckPlayerId)
            {
              this.game.EditObj.PopupValue = 15;
              this.game.EditObj.ServerCommand = ServerCommandType.CheckPlayer;
              windowReturnClass.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.PreviewId)
            {
              this.game.EditObj.LoadNoNewEdit = true;
              this.game.EditObj.PbemGameSetup = PbemGameSetupPhase.Inspecting;
              this.game.EditObj.PbemInspectReturnFromID = this.gamenr;
              string str = "";
              int Start = 32;
              do
              {
                if (Operators.CompareString(Strings.Mid(this.game.EditObj.PbemChallengeMiscData, Start, 1), " ", false) != 0)
                  str = Strings.Mid(this.game.EditObj.PbemChallengeMiscData, Start, 1) + str;
                Start += -1;
              }
              while (Start >= 1);
              this.game.EditObj.LoadFileName = this.game.AppPath + this.game.ModScenarioDir + "\\" + str;
              this.game.EditObj.PopupValue = 17;
              windowReturnClass.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ch1 || num1 == this.ch2 || num1 == this.ch3 || num1 == this.ch4)
            {
              int num2 = -1;
              string str = this.game.AppPath + this.game.ModScenarioDir + "/";
              switch (num2)
              {
                case 3:
                  if (this.SubPartID[index] == this.ch1)
                    str += "campaign2s.dc2";
                  if (this.SubPartID[index] == this.ch2)
                    str += "campaign3s.dc2";
                  if (this.SubPartID[index] == this.ch3)
                    str += "2ndkharkov.dc2";
                  if (this.SubPartID[index] == this.ch4)
                  {
                    str += "voronezh.dc2";
                    break;
                  }
                  break;
                case 4:
                  if (this.SubPartID[index] == this.ch1)
                  {
                    str += "barbarossa.dc3";
                    break;
                  }
                  break;
                default:
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
              }
              if (File.Exists(str))
              {
                if (str.Replace(this.game.AppPath + this.game.ModScenarioDir + "/", "").Length <= 36)
                {
                  this.game.EditObj.LoadNoNewEdit = true;
                  this.game.EditObj.PbemGameSetup = PbemGameSetupPhase.MakingChallenge;
                  this.game.EditObj.ServerCommand = ServerCommandType.None;
                  this.game.EditObj.LoadFileName = str;
                  this.game.EditObj.PopupValue = 17;
                  windowReturnClass.AddCommand(5, 14);
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                int num3 = (int) Interaction.MsgBox((object) ("The actual scenario name and location must be 36 characters or less. The current path '" + str.Replace(this.game.AppPath + this.game.ModScenarioDir, "") + "' is " + str.Replace(this.game.AppPath + this.game.ModScenarioDir, "").Length.ToString() + " characters long."), Title: ((object) "Shadow Empire : Planetary Conquest"));
                return windowReturnClass;
              }
              if (Strings.Len(str) > 1)
              {
                int num4 = (int) Interaction.MsgBox((object) "File could not be found or op. is cancelled.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.challengeId)
            {
              string str = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a scenario to use for your challenge...", this.game.AppPath + this.game.ModScenarioDir, false);
              if (File.Exists(str))
              {
                if (str.Replace(this.game.AppPath + this.game.ModScenarioDir, "").Length <= 36)
                {
                  this.game.EditObj.LoadNoNewEdit = true;
                  this.game.EditObj.PbemGameSetup = PbemGameSetupPhase.MakingChallenge;
                  this.game.EditObj.ServerCommand = ServerCommandType.None;
                  this.game.EditObj.LoadFileName = str;
                  this.game.EditObj.PopupValue = 17;
                  windowReturnClass.AddCommand(5, 14);
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                int num5 = (int) Interaction.MsgBox((object) ("The actual scenario name and location must be 36 characters or less. The current path '" + str.Replace(this.game.AppPath + this.game.ModScenarioDir, "") + "' is " + str.Replace(this.game.AppPath + this.game.ModScenarioDir, "").Length.ToString() + " characters long."), Title: ((object) "Shadow Empire : Planetary Conquest"));
                return windowReturnClass;
              }
              if (Strings.Len(str) > 1)
              {
                int num6 = (int) Interaction.MsgBox((object) "File could not be found or op. is cancelled.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.AcceptChallengeId)
            {
              if (!this.AcceptUsePass)
                this.game.EditObj.PbemPrivatePassword = "";
              this.game.EditObj.ServerCommand = ServerCommandType.AcceptChallenge;
              this.game.EditObj.PbemChallengeID = this.gamenr;
              this.game.EditObj.PopupValue = 15;
              windowReturnClass.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.PlayTurnId)
            {
              this.game.EditObj.LoadNoNewEdit = true;
              this.game.EditObj.ServerCommand = ServerCommandType.PlayTurn;
              this.game.EditObj.PbemGameID = this.gamenr;
              this.game.EditObj.PopupValue = 15;
              windowReturnClass.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 != this.ChallengeListId)
              return windowReturnClass;
            int num7 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
            if (num7 > -1)
              this.gamenr = num7;
            if (this.currentTab == 0)
              this.DrawFinishedGamesTabRefresh();
            if (this.currentTab == 1)
              this.DrawCurrentGamesTabRefresh();
            if (this.currentTab == 2)
              this.DrawYourChallengesTabRefresh();
            if (this.currentTab == 3)
              this.DrawOtherChallengesTabRefresh();
            this.SubPartFlag[index] = true;
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
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
