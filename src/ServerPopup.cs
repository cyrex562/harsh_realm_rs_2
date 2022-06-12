// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ServerPopup
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class ServerPopup : WindowClass
  {
    private int okid;
    private int cancelid;
    private int cancel2id;
    private int stateid;
    private int textid;
    private ServerClass Server;
    private bool ServerThRunning;
    private Thread ServerThread;
    private bool doLog;
    private bool Finished;
    private int newWindow;
    private int animTimer;
    private string TextSoFar;
    private bool RequestRefresh;

    public ServerPopup(ref GameClass tGame)
      : base(ref tGame, 600, 400, 8)
    {
      this.doLog = true;
      this.Finished = false;
      this.newWindow = -1;
      this.game.EditObj.OrigServerCommand = this.game.EditObj.ServerCommand;
      this.Ready();
      this.View();
    }

    public void Ready()
    {
      this.game.EditObj.ServerUploadSize = 0L;
      this.game.EditObj.ServerDownloadSize = 0L;
      this.game.EditObj.ServerOrderCancel = false;
      this.game.EditObj.ServerDownloadFile = (byte[]) null;
      this.game.EditObj.ServerCommandMaxStepOrig = 0;
      this.game.EditObj.ServerStatus = ServerStatusType.Sending;
      this.Finished = false;
      this.Server = new ServerClass(this.game);
      this.ServerThread = new Thread(new ThreadStart(this.Server.Go));
      CultureInfo cultureInfo = new CultureInfo("en-US");
      Thread.CurrentThread.CurrentCulture = cultureInfo;
      Thread.CurrentThread.CurrentUICulture = cultureInfo;
      this.ServerThread.Start();
      this.game.FormRef.Cursor = Cursors.WaitCursor;
    }

    public override WindowReturnClass handleTimer()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      ++this.animTimer;
      if (this.game.EditObj.ServerStatus == ServerStatusType.Completed & !this.Finished)
      {
        this.ServerThread.Abort();
        this.ServerThread.Join();
        this.game.FormRef.Cursor = Cursors.Default;
        this.RequestRefresh = false;
        if (this.game.EditObj.ServerCommand == ServerCommandType.Initialize)
        {
          this.ViewInitialize();
          if (this.RequestRefresh)
          {
            this.game.EditObj.ServerCommand = ServerCommandType.Refresh;
            this.Ready();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
        }
        else if (this.game.EditObj.ServerCommand == ServerCommandType.Register)
        {
          this.ViewRegister();
          if (this.RequestRefresh)
          {
            this.game.EditObj.ServerCommand = ServerCommandType.Refresh;
            this.Ready();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
        }
        else if (this.game.EditObj.ServerCommand == ServerCommandType.CheckPlayer)
          this.ViewCheckPlayer();
        else if (this.game.EditObj.ServerCommand == ServerCommandType.Login)
        {
          this.ViewLogin();
          if (this.RequestRefresh)
          {
            this.game.EditObj.ServerCommand = ServerCommandType.Refresh;
            this.Ready();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
        }
        else if (this.game.EditObj.ServerCommand == ServerCommandType.Refresh)
          this.ViewRefresh();
        else if (this.game.EditObj.ServerCommand == ServerCommandType.Challenge)
        {
          this.ViewChallenge();
          if (this.RequestRefresh)
          {
            this.game.EditObj.ServerCommand = ServerCommandType.Refresh;
            this.Ready();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
        }
        else if (this.game.EditObj.ServerCommand == ServerCommandType.UploadInstance)
        {
          this.ViewUploadInstance();
          if (this.RequestRefresh)
          {
            this.game.EditObj.ServerCommand = ServerCommandType.Refresh;
            this.Ready();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
        }
        else if (this.game.EditObj.ServerCommand == ServerCommandType.AcceptChallenge)
        {
          this.ViewAcceptChallenge();
          if (this.RequestRefresh)
          {
            this.game.EditObj.ServerCommand = ServerCommandType.Refresh;
            this.Ready();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
        }
        else if (this.game.EditObj.ServerCommand == ServerCommandType.Logout)
          this.ViewLogOut();
        else if (this.game.EditObj.ServerCommand == ServerCommandType.CancelChallenge)
        {
          this.ViewCancelChallenge();
          if (this.RequestRefresh)
          {
            this.game.EditObj.ServerCommand = ServerCommandType.Refresh;
            this.Ready();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
        }
        else if (this.game.EditObj.ServerCommand == ServerCommandType.Claim)
        {
          this.ViewClaim();
          if (this.RequestRefresh)
          {
            this.game.EditObj.ServerCommand = ServerCommandType.Refresh;
            this.Ready();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
        }
        else if (this.game.EditObj.ServerCommand == ServerCommandType.PlayTurn)
        {
          if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Succes)
            this.game.HandyFunctionsObj.SaveDownloadedFile("savedgames/downloadedfile.se1");
          this.ViewPlayTurn();
        }
        else
        {
          this.RemoveSubPart(this.cancelid);
          SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("OK", 200, tBackbitmap: (ref this.OwnBitmap), bbx: 200, bby: 340, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.okid = this.AddSubPart(ref tsubpart, 200, 340, 200, 36, 1);
          Rectangle trect = new Rectangle(200, 530, 200, 35);
          this.AddMouse(ref trect, "", "Back to main PBEM++ screen");
        }
        windowReturnClass.SetFlag(true);
        this.Finished = true;
      }
      else if (this.game.EditObj.ServerStatus == ServerStatusType.TimeOut & !this.Finished)
      {
        this.ServerThread.Abort();
        this.ServerThread.Join();
        this.game.FormRef.Cursor = Cursors.Default;
        this.ViewTimeOut();
        this.Finished = true;
        windowReturnClass.SetFlag(true);
      }
      else if (!this.Finished)
      {
        this.View();
        windowReturnClass.SetFlag(true);
      }
      return windowReturnClass;
    }

    public void Clear()
    {
    }

    public void View()
    {
      Graphics g;
      this.DoHeader(g);
      if (!this.game.EditObj.ServerOrderCancel)
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Cancel", 200, "Click to break off the current communication with server.\r\nMaybe because the connection seems to have died for instance.", ref this.OwnBitmap, 200, 340, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.cancelid = this.AddSubPart(ref tsubpart, 200, 340, 200, 36, 1);
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Cancel", 200, "You already gave cancel request! Cancellation should be in progress.", ref this.OwnBitmap, 200, 340, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.cancel2id = this.AddSubPart(ref tsubpart, 200, 340, 200, 36, 1);
      }
      if (this.textid > 0)
      {
        this.RemoveSubPart(this.textid);
        this.textid = 0;
      }
      if (this.game.EditObj.ServerTextBuffer.Length > 0)
      {
        this.TextSoFar += this.game.EditObj.ServerTextBuffer;
        this.game.EditObj.ServerTextBuffer = "";
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 440, 7, this.game.MarcFont4, this.TextSoFar, 24, ref this.OwnBitmap, 80, 80);
      this.textid = this.AddSubPart(ref tsubpart1, 80, 80, 440, 192, 0);
    }

    public void ViewRegister()
    {
      Graphics g;
      this.DoHeader(g);
      string str1;
      string str2;
      if (this.game.EditObj.ServerSerialReply == ServerSerialReplyType.SerialNotRegistered)
      {
        str2 = str1 + "Your serial is verified." + "\r\n";
        if (this.game.EditObj.ServerRegisterReply == ServerRegisterReplyType.RegisterationSucces)
        {
          str2 += "You have been succesfully registered.";
          this.RequestRefresh = true;
        }
        else if (this.game.EditObj.ServerRegisterReply == ServerRegisterReplyType.RegisterationFailure)
        {
          string str3 = str2 + "You have not been registered.";
          this.game.EditObj.ServerAuthReply = ServerAuthReplyType.AuthFailure;
          str2 = str3 + this.GetExactErrorString(this.game.EditObj.ServerExactErrorCode);
        }
      }
      else if (this.game.EditObj.ServerSerialReply == ServerSerialReplyType.SerialRegistered)
      {
        str2 = str1 + "You are already registered. Please try to use the login button in the next screen.";
        this.game.EditObj.ServerAuthReply = ServerAuthReplyType.AuthFailure;
      }
      else if (this.game.EditObj.ServerSerialReply == ServerSerialReplyType.SerialFailure)
      {
        string str4 = str1 + "Registration Failed.  \r\n";
        this.game.EditObj.ServerAuthReply = ServerAuthReplyType.AuthFailure;
        str2 = str4 + this.GetExactErrorString(this.game.EditObj.ServerExactErrorCode);
      }
      this.TextSoFar += str2;
      this.TextSoFar += "\r\n";
      if (this.RequestRefresh)
        return;
      if (this.textid > 0)
      {
        this.RemoveSubPart(this.textid);
        this.textid = 0;
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 440, 7, this.game.MarcFont4, this.TextSoFar, 24, ref this.OwnBitmap, 80, 80);
      this.textid = this.AddSubPart(ref tsubpart1, 80, 80, 440, 192, 0);
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("OK", 200, "Back to main PBEM++ screen", ref this.OwnBitmap, 200, 340, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.okid = this.AddSubPart(ref tsubpart2, 200, 340, 200, 36, 1);
    }

    public void ViewInitialize()
    {
      Graphics g;
      this.DoHeader(g);
      string str1;
      string str2;
      if (this.game.EditObj.ServerSerialReply == ServerSerialReplyType.SerialRegistered)
      {
        str2 = (Operators.CompareString(this.game.EditObj.PbemSerial, "0000-0000-0000-0000", false) != 0 ? str1 + "Your serial is verified as registered already." : str1 + "Your still need to login a first time or register to get a serial code.") + "\r\n";
        if (this.game.EditObj.ServerAuthReply == ServerAuthReplyType.AuthSucces)
        {
          str2 += "You have been logged in.";
          this.RequestRefresh = true;
        }
        else if (this.game.EditObj.ServerAuthReply == ServerAuthReplyType.AuthFailure)
          str2 += "You still need to login though.\r\n";
      }
      else if (this.game.EditObj.ServerSerialReply == ServerSerialReplyType.SerialNotRegistered)
      {
        str2 = Operators.CompareString(this.game.EditObj.PbemSerial, "0000-0000-0000-0000", false) != 0 ? str1 + "Your serial is registered already." : str1 + "Your still need to login a first time or register to get a serial code.";
        this.game.EditObj.ServerAuthReply = ServerAuthReplyType.AuthFailure;
      }
      else if (this.game.EditObj.ServerSerialReply == ServerSerialReplyType.NoConnection)
      {
        str2 = str1 + "No (valid) connection with server.";
        this.game.EditObj.ServerAuthReply = ServerAuthReplyType.AuthFailure;
      }
      else if (this.game.EditObj.ServerSerialReply == ServerSerialReplyType.SerialFailure)
      {
        string str3 = Operators.CompareString(this.game.EditObj.PbemSerial, "0000-0000-0000-0000", false) != 0 ? str1 + "Serial verification failed. You'll need to login manually with the correct serial. \r\n" : str1 + "No valid serial present at the moment. You will need to register first. \r\n";
        this.game.EditObj.ServerAuthReply = ServerAuthReplyType.AuthFailure;
        str2 = str3 + this.GetExactErrorString(this.game.EditObj.ServerExactErrorCode);
      }
      this.TextSoFar += str2;
      this.TextSoFar += "\r\n";
      if (this.RequestRefresh)
        return;
      if (this.textid > 0)
      {
        this.RemoveSubPart(this.textid);
        this.textid = 0;
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 440, 7, this.game.MarcFont4, this.TextSoFar, 24, ref this.OwnBitmap, 80, 80);
      this.textid = this.AddSubPart(ref tsubpart1, 80, 80, 440, 192, 0);
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("OK", 200, "Back to main PBEM++ screen", ref this.OwnBitmap, 200, 340, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.okid = this.AddSubPart(ref tsubpart2, 200, 340, 200, 36, 1);
    }

    public void ViewLogin()
    {
      Graphics g;
      this.DoHeader(g);
      string str1;
      string str2;
      if (this.game.EditObj.ServerAuthReply == ServerAuthReplyType.AuthSucces)
      {
        str2 = str1 + "You have been logged in.";
        this.RequestRefresh = true;
      }
      else if (this.game.EditObj.ServerAuthReply == ServerAuthReplyType.AuthFailure)
        str2 = str1 + "You could not be logged in.\r\n" + this.GetExactErrorString(this.game.EditObj.ServerExactErrorCode);
      this.TextSoFar += str2;
      this.TextSoFar += "\r\n";
      if (this.RequestRefresh)
        return;
      if (this.textid > 0)
      {
        this.RemoveSubPart(this.textid);
        this.textid = 0;
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 440, 7, this.game.MarcFont4, this.TextSoFar, 24, ref this.OwnBitmap, 80, 80);
      this.textid = this.AddSubPart(ref tsubpart1, 80, 80, 440, 192, 0);
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("OK", 200, "Back to main PBEM++ screen", ref this.OwnBitmap, 200, 340, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.okid = this.AddSubPart(ref tsubpart2, 200, 340, 200, 36, 1);
    }

    public void ViewTimeOut()
    {
      Graphics g;
      this.DoHeader(g);
      this.TextSoFar += "No connection with Server!";
      this.TextSoFar += "\r\n";
      if (this.textid > 0)
      {
        this.RemoveSubPart(this.textid);
        this.textid = 0;
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 440, 7, this.game.MarcFont4, this.TextSoFar, 24, ref this.OwnBitmap, 80, 80);
      this.textid = this.AddSubPart(ref tsubpart1, 80, 80, 440, 192, 0);
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("OK", 200, "Back to main PBEM++ screen", ref this.OwnBitmap, 200, 340, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.okid = this.AddSubPart(ref tsubpart2, 200, 340, 200, 36, 1);
    }

    public void ViewLogOut()
    {
      Graphics g;
      this.DoHeader(g);
      string str1;
      string str2;
      if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Succes)
        str2 = str1 + "Logout succesfull.";
      else if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Failure)
        str2 = str1 + "Logout did not work.\r\n" + this.GetExactErrorString(this.game.EditObj.ServerExactErrorCode);
      this.TextSoFar += str2;
      this.TextSoFar += "\r\n";
      if (this.textid > 0)
      {
        this.RemoveSubPart(this.textid);
        this.textid = 0;
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 440, 7, this.game.MarcFont4, this.TextSoFar, 24, ref this.OwnBitmap, 80, 80);
      this.textid = this.AddSubPart(ref tsubpart1, 80, 80, 440, 192, 0);
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("OK", 200, "Back to main PBEM++ screen", ref this.OwnBitmap, 200, 340, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.okid = this.AddSubPart(ref tsubpart2, 200, 340, 200, 36, 1);
    }

    public void ViewRefresh()
    {
      Graphics g;
      this.DoHeader(g);
      string str1;
      string str2;
      if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Succes)
        str2 = str1 + "Refresh succesfull.";
      else if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Failure)
        str2 = str1 + "Refresh request did not work.\r\n" + this.GetExactErrorString(this.game.EditObj.ServerExactErrorCode);
      this.TextSoFar += str2;
      this.TextSoFar += "\r\n";
      if (this.textid > 0)
      {
        this.RemoveSubPart(this.textid);
        this.textid = 0;
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 440, 7, this.game.MarcFont4, this.TextSoFar, 24, ref this.OwnBitmap, 80, 80);
      this.textid = this.AddSubPart(ref tsubpart1, 80, 80, 440, 192, 0);
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("OK", 200, "Back to main PBEM++ screen", ref this.OwnBitmap, 200, 340, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.okid = this.AddSubPart(ref tsubpart2, 200, 340, 200, 36, 1);
    }

    public void ViewChallenge()
    {
      Graphics g;
      this.DoHeader(g);
      string str1;
      string str2;
      if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Succes)
      {
        str2 = str1 + "Challenge succesfully issued.";
        this.RequestRefresh = true;
      }
      else if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Failure)
        str2 = str1 + "Challenge request did not work.\r\n" + this.GetExactErrorString(this.game.EditObj.ServerExactErrorCode);
      this.TextSoFar += str2;
      this.TextSoFar += "\r\n";
      if (this.RequestRefresh)
        return;
      if (this.textid > 0)
      {
        this.RemoveSubPart(this.textid);
        this.textid = 0;
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 440, 7, this.game.MarcFont4, this.TextSoFar, 24, ref this.OwnBitmap, 80, 80);
      this.textid = this.AddSubPart(ref tsubpart1, 80, 80, 440, 192, 0);
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("OK", 200, "Back to main PBEM++ screen", ref this.OwnBitmap, 200, 340, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.okid = this.AddSubPart(ref tsubpart2, 200, 340, 200, 36, 1);
    }

    public void ViewUploadInstance()
    {
      Graphics g;
      this.DoHeader(g);
      string str1;
      string str2;
      if (this.game.Data.PbemGameOver == 1)
      {
        if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Succes)
        {
          str2 = str1 + "You have reviewed this finished game. Your opponent already did. This concludes this PBEM++ match.";
          this.RequestRefresh = true;
        }
        else if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Failure)
          str2 = str1 + "Your turn upload/reviewing of finished game has failed.\r\nKeep in mind you can still find your file in 'savedgames/uploadfile.se1'\r\nYou can load the file from the main menu again and retry sending it.\r\n" + this.GetExactErrorString(this.game.EditObj.ServerExactErrorCode);
      }
      else if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Succes)
      {
        str2 = str1 + "Your turn is succesfully uploaded\r\nYour opponent will be notified he can play his/her turn.";
        this.RequestRefresh = true;
      }
      else if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Failure)
        str2 = str1 + "Your turn upload has failed.\r\nKeep in mind you can still find your file in 'savedgames/uploadfile.se1'\r\nYou can load the file from the main menu again and retry sending it.\r\n" + this.GetExactErrorString(this.game.EditObj.ServerExactErrorCode);
      this.TextSoFar += str2;
      this.TextSoFar += "\r\n";
      if (this.RequestRefresh)
        return;
      if (this.textid > 0)
      {
        this.RemoveSubPart(this.textid);
        this.textid = 0;
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 440, 7, this.game.MarcFont4, this.TextSoFar, 24, ref this.OwnBitmap, 80, 80);
      this.textid = this.AddSubPart(ref tsubpart1, 80, 80, 440, 192, 0);
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("OK", 200, "Back to main PBEM++ screen", ref this.OwnBitmap, 200, 340, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.okid = this.AddSubPart(ref tsubpart2, 200, 340, 200, 36, 1);
    }

    public void ViewPlayTurn()
    {
      Graphics g;
      this.DoHeader(g);
      string str1;
      string str2;
      if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Succes)
        str2 = str1 + "Succesfully downloaded your turn.";
      else if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Failure)
        str2 = str1 + "Download did not work.\r\n" + this.GetExactErrorString(this.game.EditObj.ServerExactErrorCode);
      this.TextSoFar += str2;
      this.TextSoFar += "\r\n";
      if (this.textid > 0)
      {
        this.RemoveSubPart(this.textid);
        this.textid = 0;
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 440, 7, this.game.MarcFont4, this.TextSoFar, 24, ref this.OwnBitmap, 80, 80);
      this.textid = this.AddSubPart(ref tsubpart1, 80, 80, 440, 192, 0);
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("OK", 200, "Back to main PBEM++ screen", ref this.OwnBitmap, 200, 340, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.okid = this.AddSubPart(ref tsubpart2, 200, 340, 200, 36, 1);
    }

    public void ViewCancelChallenge()
    {
      Graphics g;
      this.DoHeader(g);
      string str1;
      string str2;
      if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Succes)
      {
        str2 = str1 + "Succesfully cancelled your challenge.";
        this.RequestRefresh = true;
      }
      else if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Failure)
        str2 = str1 + "Cancel challenge did not work.\r\n" + this.GetExactErrorString(this.game.EditObj.ServerExactErrorCode);
      this.TextSoFar += str2;
      this.TextSoFar += "\r\n";
      if (this.RequestRefresh)
        return;
      if (this.textid > 0)
      {
        this.RemoveSubPart(this.textid);
        this.textid = 0;
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 440, 7, this.game.MarcFont4, this.TextSoFar, 24, ref this.OwnBitmap, 80, 80);
      this.textid = this.AddSubPart(ref tsubpart1, 80, 80, 440, 192, 0);
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("OK", 200, "Back to main PBEM++ screen", ref this.OwnBitmap, 200, 340, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.okid = this.AddSubPart(ref tsubpart2, 200, 340, 200, 36, 1);
    }

    public void ViewClaim()
    {
      Graphics g;
      this.DoHeader(g);
      string str1;
      string str2;
      if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Succes)
      {
        str2 = str1 + "Succesfully claimed victory.";
        this.RequestRefresh = true;
      }
      else if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Failure)
        str2 = str1 + "Claim victory did not work.\r\n" + this.GetExactErrorString(this.game.EditObj.ServerExactErrorCode);
      this.TextSoFar += str2;
      this.TextSoFar += "\r\n";
      if (this.RequestRefresh)
        return;
      if (this.textid > 0)
      {
        this.RemoveSubPart(this.textid);
        this.textid = 0;
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 440, 7, this.game.MarcFont4, this.TextSoFar, 24, ref this.OwnBitmap, 80, 80);
      this.textid = this.AddSubPart(ref tsubpart1, 80, 80, 440, 192, 0);
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("OK", 200, "Back to main PBEM++ screen", ref this.OwnBitmap, 200, 340, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.okid = this.AddSubPart(ref tsubpart2, 200, 340, 200, 36, 1);
    }

    public void ViewCheckPlayer()
    {
      Graphics g;
      this.DoHeader(g);
      string str1;
      string str2;
      if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Succes)
      {
        str2 = str1 + "Player info on ";
        this.RequestRefresh = true;
      }
      else if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Failure)
        str2 = str1 + "Requesting player info did not work.\r\n" + this.GetExactErrorString(this.game.EditObj.ServerExactErrorCode);
      this.TextSoFar += str2;
      this.TextSoFar += "\r\n";
      if (this.RequestRefresh)
        return;
      if (this.textid > 0)
      {
        this.RemoveSubPart(this.textid);
        this.textid = 0;
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 440, 7, this.game.MarcFont4, this.TextSoFar, 24, ref this.OwnBitmap, 80, 80);
      this.textid = this.AddSubPart(ref tsubpart1, 80, 80, 440, 192, 0);
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("OK", 200, "Back to main PBEM++ screen", ref this.OwnBitmap, 200, 340, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.okid = this.AddSubPart(ref tsubpart2, 200, 340, 200, 36, 1);
    }

    public void ViewAcceptChallenge()
    {
      Graphics g;
      this.DoHeader(g);
      string str1;
      string str2;
      if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Succes)
      {
        str2 = str1 + "Challenge succesfully accepted.";
        this.RequestRefresh = true;
      }
      else if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Failure)
        str2 = str1 + "Challenge could not be accepted by you.\r\n" + this.GetExactErrorString(this.game.EditObj.ServerExactErrorCode);
      this.TextSoFar += str2;
      this.TextSoFar += "\r\n";
      if (this.RequestRefresh)
        return;
      if (this.textid > 0)
      {
        this.RemoveSubPart(this.textid);
        this.textid = 0;
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 440, 7, this.game.MarcFont4, this.TextSoFar, 24, ref this.OwnBitmap, 80, 80);
      this.textid = this.AddSubPart(ref tsubpart1, 80, 80, 440, 192, 0);
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("OK", 200, "Back to main PBEM++ screen", ref this.OwnBitmap, 200, 340, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.okid = this.AddSubPart(ref tsubpart2, 200, 340, 200, 36, 1);
    }

    public void DoHeader(Graphics g)
    {
      if (this.cancelid > 0)
        this.RemoveSubPart(this.cancelid);
      if (this.okid > 0)
        this.RemoveSubPart(this.okid);
      if (this.cancel2id > 0)
        this.RemoveSubPart(this.cancel2id);
      this.NewBackGroundAndClearAll(600, 400, -1);
      g = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawMessFrame(ref this.OwnBitmap, ref g, 0, 0, 600, 400);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      DrawMod.DrawTextColouredMarcCenter(ref g, "SERVER COMMUNICATION", this.game.MarcFont1, 300, 27, Color.White);
      this.ClearMouse();
      Rectangle trect1;
      if (this.game.EditObj.ServerUploadSize > 0L)
      {
        g = Graphics.FromImage((Image) this.OwnBitmap);
        int num1 = 480;
        int num2 = 20;
        int w = (int) Math.Round(100.0 * ((double) this.game.EditObj.ServerUploadDone / (double) this.game.EditObj.ServerUploadSize));
        int num3 = 100 - w;
        DrawMod.DrawBlock(ref g, num1, num2, 100, 15, 0, 0, 0, 64);
        DrawMod.DrawBlock(ref g, num1, num2, w, 15, 0, (int) byte.MaxValue, 0, 100);
        DrawMod.DrawRectangle(ref g, num1, num2, 100, 15, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 128);
        DrawMod.DrawTextColouredMarc(ref g, Conversion.Str((object) (int) Math.Round((double) this.game.EditObj.ServerUploadDone / 1000.0)) + " KB", this.game.MarcFont14, num1 + 2, num2 + 2, Color.White);
        trect1 = new Rectangle(num1, num2, 100, 15);
        this.AddMouse(ref trect1, "FILE UPLOAD PROGRESS", "Currently uploaded " + this.game.EditObj.ServerUploadDone.ToString() + " bytes of " + this.game.EditObj.ServerUploadSize.ToString());
      }
      if (this.game.EditObj.ServerDownloadDone > 0L)
      {
        g = Graphics.FromImage((Image) this.OwnBitmap);
        int num4 = 480;
        int num5 = 20;
        DrawMod.DrawBlock(ref g, num4, num5, 100, 15, 0, 0, 0, 64);
        DrawMod.DrawRectangle(ref g, num4, num5, 100, 15, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 128);
        DrawMod.DrawTextColouredMarc(ref g, Conversion.Str((object) (int) Math.Round((double) this.game.EditObj.ServerDownloadDone / 1000.0)) + " KB", this.game.MarcFont14, num4 + 2, num5 + 2, Color.White);
        trect1 = new Rectangle(num4, num5, 100, 15);
        Rectangle trect2 = trect1;
        this.AddMouse(ref trect2, "FILE DOWNLOAD PROGRESS", "Currently downloaded " + this.game.EditObj.ServerDownloadDone.ToString() + " bytes.");
      }
      if (this.game.EditObj.ServerCommandMaxStepOrig <= 0)
        return;
      int num = 20;
      int y1 = 360;
      int commandMaxStepOrig = this.game.EditObj.ServerCommandMaxStepOrig;
      for (int index = 1; index <= commandMaxStepOrig; ++index)
      {
        if (index < this.game.EditObj.ServerCommandStep)
          DrawMod.DrawBlock(ref g, num + 40 * (index - 1), y1, 15, 8, 0, (int) byte.MaxValue, 0, 150);
        else if (index == this.game.EditObj.ServerCommandStep)
        {
          if (this.animTimer % 10 < 5)
            DrawMod.DrawBlock(ref g, num + 40 * (index - 1), y1, 15, 8, 0, (int) byte.MaxValue, 0, 150);
          else
            DrawMod.DrawBlock(ref g, num + 40 * (index - 1), y1, 15, 8, 0, 0, 0, 150);
        }
        else
          DrawMod.DrawBlock(ref g, num + 40 * (index - 1), y1, 15, 8, 0, 0, 0, 150);
        DrawMod.DrawRectangle(ref g, num + 40 * (index - 1), y1, 15, 8, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 128);
      }
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
            if (num == this.okid)
            {
              this.game.EditObj.ServerUploadDone = 0L;
              this.game.EditObj.ServerDownloadDone = 0L;
              this.game.EditObj.ServerDownloadSize = 0L;
              if (this.game.EditObj.OrigServerCommand == ServerCommandType.Initialize)
              {
                this.game.EditObj.ServerStatusInitializeTried = true;
                if (this.game.EditObj.ServerSerialReply == ServerSerialReplyType.SerialFailure)
                {
                  windowReturnClass.AddCommand(6, 0);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (this.game.EditObj.ServerSerialReply == ServerSerialReplyType.SerialRegistered & this.game.EditObj.ServerAuthReply == ServerAuthReplyType.AuthFailure)
                {
                  this.game.EditObj.PopupValue = 16;
                  windowReturnClass.AddCommand(5, 14);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (this.game.EditObj.ServerSerialReply == ServerSerialReplyType.SerialNotRegistered | this.game.EditObj.ServerAuthReply == ServerAuthReplyType.AuthFailure)
                {
                  if (this.game.EditObj.PbemAlreadyAccount)
                  {
                    windowReturnClass.AddCommand(6, 0);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  this.game.EditObj.PopupValue = 14;
                  windowReturnClass.AddCommand(5, 14);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                windowReturnClass.AddCommand(6, 0);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.game.EditObj.OrigServerCommand == ServerCommandType.PlayTurn)
              {
                if (this.game.EditObj.ServerGenericReply == ServerGenericReplyType.Succes)
                {
                  this.game.EditObj.LoadNoNewEdit = true;
                  this.game.EditObj.LoadFileName = this.game.AppPath + "savedgames\\downloadedfile.se1";
                  this.game.EditObj.PopupValue = 17;
                  windowReturnClass.AddCommand(5, 14);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                windowReturnClass.AddCommand(6, 0);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              windowReturnClass.AddCommand(6, 0);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.textid)
            {
              this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.cancelid)
            {
              this.game.EditObj.ServerOrderCancel = true;
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

    public string GetExactErrorString(int err)
    {
      string str = "";
      if (err == 900)
        str = "Lost connection with server.";
      if (err == 1)
        str = "Did not transfer enough data. [1]";
      if (err == 2)
        str = "Serial number is blacklisted. [2]";
      if (err == 3)
        str = "Serial number is non-existant. [3]";
      if (err == 4)
        str = "Serial number is registered. [4]";
      if (err == 5)
        str = "Serial number is not registered. [5]";
      if (err == 6)
        str = "User has not logged in. [6]";
      if (err == 7)
        str = "Login name already exists, pick other one please. [7]";
      if (err == 8)
        str = "Login/pass is not correct. Or username is to short or already exists. [8]";
      if (err == 9)
        str = "Login is not activated. [9]";
      if (err == 10)
        str = "Login/pass is wrong for serial number. [10]";
      if (err == 11)
        str = "User has one or more serials. [11]";
      if (err == 12)
        str = "Email already exists with other user. Pick other email please. [12]";
      if (err == 13)
        str = "Email is not correct. [13]";
      if (err == 14)
        str = "Password length is short (5-15 characters). [14]";
      if (err == 15)
        str = "Script/Database error on server [15]";
      if (err == 20)
        str = "Game folder is undefined. [20]";
      if (err == 21)
        str = "Game folder is non-existent. [21]";
      if (err == 22)
        str = "The game is not active for serials-exchange. [22]";
      if (err == 23)
        str = "Wrong Turn! [23]";
      if (err == 24)
        str = "IP adress locked out for 10 minutes. [24]";
      if (err == 25)
        str = "Too many challenges issued already! [25]";
      if (err == 26)
        str = "Too many challenges accepted today! [26]";
      if (err == 27)
        str = "Too many total games or challenges in progress. [27]";
      if (err == 28)
        str = "Game already accepted. [28]";
      if (err == 29)
        str = "You are not in this game [29]";
      if (err == 30)
        str = "Game already finished [30]";
      if (err == 31)
        str = "The game has been updated in the last 30 days [31]";
      if (err == 32)
        str = "Game is not finished yet. [32]";
      if (err == 33)
        str = "Email not sent. [33]";
      if (err == 34)
        str = "Invalid challenge password [34]";
      if (err == 35)
        str = "Password length is too long (5-15 characters). [35]";
      if (err == 36)
        str = "The file-size is different from what client posted to server [36].";
      if (err == 37)
        str = "The Cookie seems to be corrupted [37].";
      if (err == 38)
        str = "The server could not write the file [38].";
      if (err == 39)
        str = "File size limit exceeded [39].";
      if (err == 40)
        str = "User disk-space limit exceeded [40].";
      if (err == 41)
        str = "CRC32 check failed upon upload. [41]";
      if (err == 42)
        str = "CRC32 check failed writing too server. [42]";
      if (err == 43)
        str = "The server could not write the file. [43]";
      if (err == 44)
        str = "CRC32 check failed writing into the server. [44]";
      if (err == 45)
        str = "You are not allowed to see the message [45].";
      if (err == 46)
        str = "Authorization Cookie is missing. [46].";
      if (str.Length < 1)
        str = "Unknown Error [" + err.ToString() + "]";
      return "Error Report: '" + str + "'";
    }
  }
}
