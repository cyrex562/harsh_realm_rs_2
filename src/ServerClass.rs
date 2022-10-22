// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ServerClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

// usingMicrosoft.VisualBasic;
// usingMicrosoft.VisualBasic.CompilerServices;
// usingSystem;
// usingSystem.IO;
// usingSystem.Net;
// usingSystem.Text;
// usingSystem.Threading;
// usingSystem.Web;

namespace WindowsApplication1
{
  pub class ServerClass
  {
     game: GameClass;
     e: EditClass;
     HttpWebRequest wr;
     string url;
     string baseurl;
     string exchangebaseurl;
     string pbempassword;
     bool debug;
     string receive;
     AutoResetEvent auto;
     ManualResetEvent manual;

    pub ServerClass(tgame: GameClass)
    {
      this.baseurl = "defaultURL";
      this.exchangebaseurl = "defaultExchangeURL";
      this.pbempassword = "defaultPass";
      this.debug = true;
      this.game = tgame;
      this.e = this.game.EditObj;
      this.e.ServerLostConnect = false;
      this.e.ServerTextBuffer = "";
      if (this.game.EditObj.donequest != 0)
        return;
      this.game.EditObj.donequest = 1;
      this.game.EditObj.donequest = 2;
    }

     void Response(IAsyncResult ar)
    {
      ServerClass.WebRequestState asyncState = (ServerClass.WebRequestState) ar.AsyncState;
      HttpWebRequest request = (HttpWebRequest) asyncState.Request;
      asyncState.lastRead = DateAndTime.Now;
      if (asyncState.e.ServerOrderCancel)
      {
        if (!Information.IsNothing( asyncState.Response))
          asyncState.Response.Close();
        request.Abort();
        asyncState.e.ServerLostConnect = true;
      }
      else
      {
        try
        {
          asyncState.Response = request.EndGetResponse(ar);
          asyncState.RespStream = asyncState.Response.GetResponseStream();
          asyncState.RespStream.BeginRead(asyncState.buf, 0, 131072, new AsyncCallback(this.ReadResponse),  asyncState);
        }
        catch (WebException ex)
        {
          ProjectData.SetProjectError((Exception) ex);
          asyncState.e.ServerOrderCancel = true;
          if (!Information.IsNothing( asyncState.Response))
            asyncState.Response.Close();
          request.Abort();
          asyncState.e.ServerLostConnect = true;
          ProjectData.ClearProjectError();
        }
      }
    }

     void ReadResponse(IAsyncResult ar)
    {
      this.receive = "";
      ServerClass.WebRequestState asyncState = (ServerClass.WebRequestState) ar.AsyncState;
      HttpWebRequest request = (HttpWebRequest) asyncState.Request;
      WebResponse response = asyncState.Response;
      Stream respStream = asyncState.RespStream;
      try
      {
        asyncState.lastRead = DateAndTime.Now;
        let mut count: i32 = respStream.EndRead(ar);
        if (count > 0 & !asyncState.completed)
        {
          this.auto.WaitOne();
          if (this.e.ServerCommand == ServerCommandType.PlayTurn)
          {
            if (!asyncState.responseStarted)
            {
              asyncState.e.ServerDownloadDone = 0L;
              asyncState.uploaddone = 0L;
              asyncState.upload = new byte[1];
              asyncState.responseStarted = true;
            }
            if (asyncState.uploaddone + (long) count + 32368L > (long) asyncState.upload.GetUpperBound(0))
              asyncState.upload = (byte[]) Utils.CopyArray((Array) asyncState.upload, (Array) new byte[asyncState.upload.GetUpperBound(0) + 1045876 + 1]);
            asyncState.e.ServerStatus = ServerStatusType.Receiving;
            let mut num: i32 = count - 1;
            for (let mut index: i32 = 0; index <= num; index += 1)
              asyncState.upload[ (asyncState.uploaddone + (long) index)] = asyncState.buf[index];
            asyncState.uploaddone += (long) count;
            asyncState.e.ServerDownloadDone += (long) count;
          }
          else if (count > 0)
          {
            this.e.ServerStatus = ServerStatusType.Receiving;
            asyncState.tempreceive += Encoding.ASCII.GetString(asyncState.buf, 0, count);
            this.e = this.e;
          }
          while (!respStream.CanRead)
            Thread.Sleep(1);
          this.auto.Set();
          respStream.BeginRead(asyncState.buf, 0, 131072, new AsyncCallback(this.ReadResponse),  asyncState);
          if (this.e.ServerOrderCancel)
          {
            asyncState.e.ServerLostConnect = true;
            respStream.Close();
            request.Abort();
          }
          if (this.e.ServerCommand == ServerCommandType.PlayTurn)
          {
            if (!this.e.ServerOrderCancel)
              return;
            respStream.Close();
            asyncState.completed = true;
            asyncState.Response = response;
            asyncState.e.ServerLostConnect = true;
          }
          else
          {
            if (!(response.ContentLength <= (long) asyncState.tempreceive.Length | this.e.ServerOrderCancel))
              return;
            respStream.Close();
            asyncState.completed = true;
            asyncState.Response = response;
          }
        }
        else
        {
          respStream.Close();
          request.Abort();
          asyncState.completed = true;
          asyncState.Response = response;
          asyncState.e.ServerLostConnect = true;
          this.auto.Set();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.e.ServerOrderCancel = true;
        if (!Information.IsNothing( respStream))
          respStream.Close();
        request.Abort();
        asyncState.completed = true;
        asyncState.Response = response;
        this.auto.Set();
        ProjectData.ClearProjectError();
      }
    }

    pub fn Go()
    {
      this.e.ServerMessages = MessageList::new();
      this.e.ServerCommandMaxStep = 1;
      if (this.e.ServerCommand == ServerCommandType.Refresh)
        this.e.ServerCommandMaxStep = 2;
      if (this.e.ServerCommand == ServerCommandType.UploadInstance)
        this.e.ServerCommandMaxStep = 3;
      if (this.e.ServerCommand == ServerCommandType.Initialize)
        this.e.ServerCommandMaxStep = 2;
      if (this.e.ServerCommand == ServerCommandType.Register)
        this.e.ServerCommandMaxStep = 3;
      this.e.ServerCommandMaxStepOrig = this.e.ServerCommandMaxStep;
      e: EditClass = this.e;
      let mut serverCommandMaxStep: i32 = this.e.ServerCommandMaxStep;
      for (e.ServerCommandStep = 1; this.e.ServerCommandStep <= serverCommandMaxStep; this += 1.e.ServerCommandStep)
      {
        if (this.e.ServerCommandStep <= this.e.ServerCommandMaxStep)
        {
          this.receive = "";
          this.e.ServerStatus = ServerStatusType.Sending;
          this.SetUrl();
          if (this.debug)
            this.WriteLog("SEND: " + this.url);
          this.e.ServerStatus = ServerStatusType.Sending;
          this.e.ServerStatusStartTime = DateTime.Now;
          this.wr = (HttpWebRequest) WebRequest.Create(this.url);
          this.wr.Timeout = 9000;
          if (Operators.CompareString(this.e.ServerCookieValue, "", false) != 0)
            this.wr.Headers.Add(HttpRequestHeader.Cookie, this.e.ServerCookieValue);
          DateTime now;
          if (this.e.ServerCommand == ServerCommandType.Challenge | this.e.ServerCommand == ServerCommandType.UploadInstance & this.e.ServerCommandStep == 3 && !Information.IsNothing( this.e.ServerUploadFile))
          {
            now = DateTime.Now;
            str: String = "----------------------------" + now.Ticks.ToString("x");
            this.wr.Method = "POST";
            this.wr.ContentType = "myHttpWebRequest.ContentType = \"application/x-www-form-urlencoded\"";
            this.wr.Timeout = 320000;
            this.wr.ContentLength = (long) (this.e.ServerUploadFile.GetUpperBound(0) + 1);
            this.e.ServerUploadSize = this.wr.ContentLength;
            Stream requestStream = this.wr.GetRequestStream();
            byte[] buffer = new byte[1025];
            num1: i32;
            while (num1 < this.e.ServerUploadFile.GetUpperBound(0) + 1)
            {
              let mut count: i32 = 0;
              let mut num2: i32 = num1;
              let mut num3: i32 = num1 + 1023;
              for (let mut index: i32 = num2; index <= num3; index += 1)
              {
                if (num1 + count <= this.e.ServerUploadFile.GetUpperBound(0))
                {
                  buffer[count] = this.e.ServerUploadFile[index];
                  count += 1;
                }
                else
                  count = count;
              }
              requestStream.Write(buffer, 0, count);
              num1 += count;
              this.e.ServerUploadDone = (long) num1;
              if (this.e.ServerOrderCancel)
              {
                this.wr.Abort();
                break;
              }
            }
            if (!this.e.ServerOrderCancel)
              requestStream.Close();
          }
          this.receive = "";
          byte[] numArray = new byte[8193];
          ServerClass.WebRequestState state = new ServerClass.WebRequestState((WebRequest) this.wr);
          state.e = this.e;
          if (!this.e.ServerOrderCancel)
          {
            this.auto = new AutoResetEvent(true);
            this.wr.BeginGetResponse(new AsyncCallback(this.Response),  state);
            state.lastRead = DateAndTime.Now;
            while (!state.completed)
            {
              Thread.Sleep(1);
              if (this.e.ServerOrderCancel)
              {
                now = DateAndTime.Now;
                if (now.Ticks - 20000000L > state.lastRead.Ticks)
                {
                  state.Request.Abort();
                  state.completed = true;
                }
              }
            }
            this.receive = state.tempreceive;
            if (this.e.ServerCommand == ServerCommandType.PlayTurn & this.e.ServerCommandStep == 1)
            {
              if (state.uploaddone < 99L)
              {
                this.receive = Encoding.ASCII.GetString(state.upload, 0,  state.uploaddone);
              }
              else
              {
                this.e.ServerDownloadFile = new byte[ (state.uploaddone - 1L) + 1];
                let mut num: i32 =  (state.uploaddone - 1L);
                for (let mut index: i32 = 0; index <= num; index += 1)
                  this.e.ServerDownloadFile[index] = state.upload[index];
              }
            }
            if (!this.e.ServerOrderCancel)
            {
              HttpWebResponse response = (HttpWebResponse) state.Response;
              if (response.Headers.Count > 0)
              {
                let mut num: i32 = response.Headers.Count - 1;
                for (let mut index: i32 = 0; index <= num; index += 1)
                {
                  if (Operators.CompareString(response.Headers.Keys[index], "Set-Cookie", false) == 0)
                  {
                    header: String = response.Headers[index];
                    this.e.ServerCookieValue = Strings.Mid(header, 1, header.IndexOf(';') + 1);
                  }
                }
              }
            }
            else
              this.receive = "99 ***CANCELLED BY CLIENT***";
          }
          else
            this.receive = "99 ***CANCELLED BY CLIENT***";
          this.e.ServerStatus = ServerStatusType.Received;
          if (this.debug)
            this.WriteLog("RECV: " + this.receive);
          this.ReadReceive();
        }
      }
      this.e.ServerUploadFile = (byte[]) null;
      this.e.ServerStatus = ServerStatusType.Completed;
    }

     void ScanTimeoutCallback( object state, bool timedOut)
    {
      if (!timedOut)
        return;
      ServerClass.WebRequestState Expression = (ServerClass.WebRequestState) state;
      if (Information.IsNothing( Expression))
        return;
      Expression.Request.Abort();
    }

    pub fn SetUrl()
    {
      if (this.game.EditObj.PbemSteam)
      {
        if (this.e.ServerCommand == ServerCommandType.Initialize)
        {
          this.url = this.baseurl;
          if (this.e.ServerCommandStep == 1)
          {
            this.e.ServerTextBuffer += "Checking username+password...\r\n";
            this.e.ServerAuthReply = ServerAuthReplyType.AuthFailure;
            if (Operators.CompareString(this.game.EditObj.PbemSerial, "0000-0000-0000-0000", false) == 0)
              this.url = this.url + "auth_steam.php?client_serial=new&login=" + HttpUtility.UrlEncode(this.game.EditObj.PbemUserName) + "&password=" + HttpUtility.UrlEncode(this.game.EditObj.PbemPassword);
            else
              this.url = this.url + "auth_steam.php?client_serial=" + HttpUtility.UrlEncode(this.game.EditObj.PbemSerial) + "&login=" + HttpUtility.UrlEncode(this.game.EditObj.PbemUserName) + "&password=" + HttpUtility.UrlEncode(this.game.EditObj.PbemPassword);
          }
        }
      }
      else if (!this.game.EditObj.PbemSteam && this.e.ServerCommand == ServerCommandType.Initialize)
      {
        this.url = this.baseurl;
        if (this.e.ServerCommandStep == 1)
        {
          this.e.ServerTextBuffer += "Checking serial number...\r\n";
          this.e.ServerSerialReply = ServerSerialReplyType.SerialFailure;
          this.url = this.url + "serial_information.php?serial_num=" + HttpUtility.UrlEncode(this.game.EditObj.PbemSerial) + "&password=" + this.pbempassword;
        }
        if (this.e.ServerCommandStep == 2)
        {
          this.e.ServerTextBuffer += "Checking username+password...\r\n";
          this.e.ServerAuthReply = ServerAuthReplyType.AuthFailure;
          this.url = this.url + "auth_steam.php?client_serial=" + HttpUtility.UrlEncode(this.game.EditObj.PbemSerial) + "&login=" + HttpUtility.UrlEncode(this.game.EditObj.PbemUserName) + "&password=" + HttpUtility.UrlEncode(this.game.EditObj.PbemPassword);
        }
      }
      if (this.game.EditObj.PbemSteam)
      {
        if (this.e.ServerCommand == ServerCommandType.Register)
        {
          this.url = this.baseurl;
          if (this.e.ServerCommandStep == 1)
          {
            this.e.ServerTextBuffer += "Registering serial number...\r\n";
            this.e.ServerRegisterReply = ServerRegisterReplyType.RegisterationFailure;
            this.url = this.url + "register_steam.php?login=" + HttpUtility.UrlEncode(this.game.EditObj.PbemUserName) + "&password=" + HttpUtility.UrlEncode(this.game.EditObj.PbemPassword) + "&email=" + HttpUtility.UrlEncode(this.game.EditObj.PbemEmail);
          }
          else if (this.e.ServerCommandStep == 2)
          {
            this.e.ServerTextBuffer += "Checking user/pass...\r\n";
            this.e.ServerAuthReply = ServerAuthReplyType.AuthFailure;
            this.url = this.url + "auth_steam.php?client_serial=new&login=" + HttpUtility.UrlEncode(this.game.EditObj.PbemUserName) + "&password=" + HttpUtility.UrlEncode(this.game.EditObj.PbemPassword);
          }
        }
      }
      else if (!this.game.EditObj.PbemSteam && this.e.ServerCommand == ServerCommandType.Register)
      {
        this.url = this.baseurl;
        if (this.e.ServerCommandStep == 1)
        {
          this.e.ServerTextBuffer += "Checking serial number...\r\n";
          this.e.ServerSerialReply = ServerSerialReplyType.SerialFailure;
          this.url = this.url + "serial_information.php?serial_num=" + HttpUtility.UrlEncode(this.game.EditObj.PbemSerial) + "&password=" + this.pbempassword;
        }
        else if (this.e.ServerCommandStep == 2)
        {
          this.e.ServerTextBuffer += "Registering serial number...\r\n";
          this.e.ServerRegisterReply = ServerRegisterReplyType.RegisterationFailure;
          this.url = this.url + "register.php?serial_num=" + HttpUtility.UrlEncode(this.game.EditObj.PbemSerial) + "&login=" + HttpUtility.UrlEncode(this.game.EditObj.PbemUserName) + "&password=" + HttpUtility.UrlEncode(this.game.EditObj.PbemPassword) + "&email=" + HttpUtility.UrlEncode(this.game.EditObj.PbemEmail);
        }
        else if (this.e.ServerCommandStep == 3)
        {
          this.e.ServerTextBuffer += "Checking user/pass...\r\n";
          this.e.ServerAuthReply = ServerAuthReplyType.AuthFailure;
          this.url = this.url + "auth_steam.php?client_serial=" + HttpUtility.UrlEncode(this.game.EditObj.PbemSerial) + "&login=" + HttpUtility.UrlEncode(this.game.EditObj.PbemUserName) + "&password=" + HttpUtility.UrlEncode(this.game.EditObj.PbemPassword);
        }
      }
      if (this.game.EditObj.PbemSteam)
      {
        if (this.e.ServerCommand == ServerCommandType.Login)
        {
          this.url = this.baseurl;
          if (this.e.ServerCommandStep == 1)
          {
            this.e.ServerTextBuffer += "Checking user/pass...\r\n";
            this.e.ServerAuthReply = ServerAuthReplyType.AuthFailure;
            if (Operators.CompareString(this.game.EditObj.PbemSerial, "0000-0000-0000-0000", false) == 0)
              this.url = this.url + "auth_steam.php?client_serial=new&login=" + HttpUtility.UrlEncode(this.game.EditObj.PbemUserName) + "&password=" + HttpUtility.UrlEncode(this.game.EditObj.PbemPassword);
            else
              this.url = this.url + "auth_steam.php?client_serial=" + HttpUtility.UrlEncode(this.game.EditObj.PbemSerial) + "&login=" + HttpUtility.UrlEncode(this.game.EditObj.PbemUserName) + "&password=" + HttpUtility.UrlEncode(this.game.EditObj.PbemPassword);
          }
        }
      }
      else if (this.e.ServerCommand == ServerCommandType.Login)
      {
        this.url = this.baseurl;
        if (this.e.ServerCommandStep == 1)
        {
          this.e.ServerTextBuffer += "Checking user/pass...\r\n";
          this.e.ServerAuthReply = ServerAuthReplyType.AuthFailure;
          this.url = this.url + "auth.php?serial_num=" + HttpUtility.UrlEncode(this.game.EditObj.PbemSerial) + "&login=" + HttpUtility.UrlEncode(this.game.EditObj.PbemUserName) + "&password=" + HttpUtility.UrlEncode(this.game.EditObj.PbemPassword);
        }
      }
      if (this.e.ServerCommand == ServerCommandType.CheckPlayer)
      {
        this.url = this.exchangebaseurl;
        if (this.e.ServerCommandStep == 1)
        {
          this.e.ServerTextBuffer += "Checking info on a player...\r\n";
          this.e.ServerGenericReply = ServerGenericReplyType.Failure;
          this.url = this.url + "rankings.php?login=" + HttpUtility.UrlEncode(this.game.EditObj.PbemCheckPlayer);
        }
      }
      if (this.e.ServerCommand == ServerCommandType.Refresh)
      {
        this.url = this.baseurl;
        if (this.e.ServerCommandStep == 1)
        {
          this.e.ServerTextBuffer += "Updating challenges...\r\n";
          this.e.ServerGenericReply = ServerGenericReplyType.Failure;
          this.url += "list_challenges.php";
        }
        if (this.e.ServerCommandStep == 2)
        {
          this.e.ServerTextBuffer += "Updating running games...\r\n";
          this.e.ServerGenericReply = ServerGenericReplyType.Failure;
          this.url += "games_list.php";
        }
      }
      if (this.e.ServerCommand == ServerCommandType.Logout)
      {
        this.url = this.baseurl;
        if (this.e.ServerCommandStep == 1)
        {
          this.e.ServerTextBuffer += "Logging out...\r\n";
          this.e.ServerGenericReply = ServerGenericReplyType.Failure;
          this.url = this.url + "logout.php?password=" + this.pbempassword + "&serial_num=" + HttpUtility.UrlEncode(this.game.EditObj.PbemSerial);
        }
      }
      if (this.e.ServerCommand == ServerCommandType.AcceptChallenge)
      {
        this.url = this.baseurl;
        if (this.e.ServerCommandStep == 1)
        {
          this.e.ServerTextBuffer += "Accepting a challenge...\r\n";
          this.e.ServerGenericReply = ServerGenericReplyType.Failure;
          if (this.game.EditObj.PbemPrivatePassword.Length > 0)
            this.url = this.url + "accept_challenge.php?ChallengeID=" + HttpUtility.UrlEncode(Conversions.ToString(this.game.EditObj.PbemChallengeID)) + "&ChallengePassword=" + HttpUtility.UrlEncode(this.game.EditObj.PbemPrivatePassword);
          else
            this.url = this.url + "accept_challenge.php?ChallengeID=" + HttpUtility.UrlEncode(Conversions.ToString(this.game.EditObj.PbemChallengeID));
        }
      }
      if (this.e.ServerCommand == ServerCommandType.CancelChallenge)
      {
        this.url = this.baseurl;
        if (this.e.ServerCommandStep == 1)
        {
          this.e.ServerTextBuffer += "Cancelling a challenge...\r\n";
          this.e.ServerGenericReply = ServerGenericReplyType.Failure;
          this.url = this.url + "cancel_challenge.php?ChallengeID=" + HttpUtility.UrlEncode(Conversions.ToString(this.game.EditObj.PbemChallengeID));
        }
      }
      if (this.e.ServerCommand == ServerCommandType.PlayTurn)
      {
        this.url = this.baseurl;
        if (this.e.ServerCommandStep == 1)
        {
          this.e.ServerTextBuffer += "Playing a turn (downloading game file)...\r\n";
          this.e.ServerGenericReply = ServerGenericReplyType.Failure;
          this.url = this.url + "download_instance.php?InstanceID=" + HttpUtility.UrlEncode(Conversions.ToString(this.game.EditObj.PbemGameID));
        }
      }
      if (this.e.ServerCommand == ServerCommandType.Claim)
      {
        this.url = this.baseurl;
        if (this.e.ServerCommandStep == 1)
        {
          this.e.ServerTextBuffer += "Claiming a game...\r\n";
          this.e.ServerGenericReply = ServerGenericReplyType.Failure;
          this.url = this.url + "claim_old_game.php?InstanceID=" + HttpUtility.UrlEncode(Conversions.ToString(this.e.PbemGameID));
        }
      }
      if (this.e.ServerCommand == ServerCommandType.Challenge)
      {
        this.url = this.baseurl;
        if (this.e.ServerCommandStep == 1)
        {
          let mut num1: i32 = 1;
          let mut num2: i32 = 1;
          let mut regimeCounter: i32 = this.game.Data.RegimeCounter;
          for (let mut index: i32 = 0; index <= regimeCounter; index += 1)
          {
            if (!this.game.Data.RegimeObj[index].Sleep & !this.game.Data.RegimeObj[index].AI)
            {
              if (this.game.Data.RegimeObj[index].PbemPlayer == 1)
              {
                num1 = 1;
                num2 = 1;
                break;
              }
              if (this.game.Data.RegimeObj[index].PbemPlayer == 2)
              {
                num1 = 1;
                num2 = 2;
                break;
              }
            }
          }
          this.e.ServerTextBuffer += "Issuing a challenge...\r\n";
          this.e.ServerGenericReply = ServerGenericReplyType.Failure;
          this.url += "issue_challenge.php?";
          this.url = this.url + "GameName=" + HttpUtility.UrlEncode(this.game.EditObj.PbemTitle);
          if (this.game.EditObj.PbemPrivatePassword.Length > 0)
            this.url = this.url + "&ChallengePassword=" + HttpUtility.UrlEncode(this.game.EditObj.PbemPrivatePassword);
          this.url = this.url + "&ChallengerSide=" + HttpUtility.UrlEncode(Conversions.ToString(num1));
          this.url = this.url + "&FirstPlayerSide=" + HttpUtility.UrlEncode(Conversions.ToString(num2));
          this.url = this.url + "&ProductID=" + HttpUtility.UrlEncode("0");
          this.url = this.url + "&ArmyName=" + HttpUtility.UrlEncode(this.game.Data.RegimeObj[0].Name);
          this.url = this.url + "&ArmyPoints=" + HttpUtility.UrlEncode("0");
          this.url = this.url + "&ShowName=" + HttpUtility.UrlEncode("1");
          this.url = this.url + "&MiscData=" + HttpUtility.UrlEncode(this.game.EditObj.PbemMiscString);
          this.url = this.url + "&FileSize=" + HttpUtility.UrlEncode(Strings.Trim(Conversion.Str( (this.game.EditObj.ServerUploadFile.GetUpperBound(0) + 1))));
        }
      }
      if (this.e.ServerCommand == ServerCommandType.UploadInstance)
      {
        this.url = this.baseurl;
        let mut num: i32 = 0;
        if (this.e.ServerCommandStep + num == 1)
        {
          this.e.ServerTextBuffer += "Checking serial number...\r\n";
          this.e.ServerSerialReply = ServerSerialReplyType.SerialFailure;
          this.url = this.url + "serial_information.php?serial_num=" + HttpUtility.UrlEncode(this.game.EditObj.PbemSerial) + "&password=slith_exchange";
        }
        if (this.e.ServerCommandStep + num == 2)
        {
          this.e.ServerTextBuffer += "Checking username+password...\r\n";
          this.e.ServerAuthReply = ServerAuthReplyType.AuthFailure;
          if (this.game.EditObj.PbemSteam)
            this.url = this.url + "auth_steam.php?client_serial=" + HttpUtility.UrlEncode(this.game.EditObj.PbemSerial) + "&login=" + HttpUtility.UrlEncode(this.game.EditObj.PbemUserName) + "&password=" + HttpUtility.UrlEncode(this.game.EditObj.PbemPassword);
          else
            this.url = this.url + "auth_steam.php?client_serial=" + HttpUtility.UrlEncode(this.game.EditObj.PbemSerial) + "&login=" + HttpUtility.UrlEncode(this.game.EditObj.PbemUserName) + "&password=" + HttpUtility.UrlEncode(this.game.EditObj.PbemPassword);
        }
        if (this.e.ServerCommandStep + num == 3)
        {
          this.e.ServerGenericReply = ServerGenericReplyType.Failure;
          if (this.game.Data.PbemGameOver == 1)
          {
            this.e.ServerTextBuffer += "Marking finished game as viewed...\r\n";
            this.url += "mark_game_viewed.php?";
            this.url = this.url + "InstanceID=" + HttpUtility.UrlEncode(Conversions.ToString(this.game.Data.PbemGameID));
            this.url = this.url + "&Viewed=" + HttpUtility.UrlEncode("1");
            this.e.ServerUploadFile = (byte[]) null;
          }
          else
          {
            this.e.ServerTextBuffer += "Uploading turn...\r\n";
            this.url += "upload_instance.php?";
            this.url = this.url + "GameInstanceID=" + HttpUtility.UrlEncode(Conversions.ToString(this.game.Data.PbemGameID));
            this.url = this.game.Data.RegimeObj[this.game.Data.Turn].PbemPlayer != 1 ? this.url + "&PlayerToUserName=" + HttpUtility.UrlEncode(this.game.Data.PbemPlayer2) : this.url + "&PlayerToUserName=" + HttpUtility.UrlEncode(this.game.Data.PbemPlayer1);
            this.url = this.url + "&TurnNo=" + HttpUtility.UrlEncode(Conversions.ToString(this.game.Data.Round));
            this.url = !(this.game.Data.LastWinner > -1 | this.game.Data.PbemDrawGame == 1) ? this.url + "&GameOver=" + HttpUtility.UrlEncode("0") : this.url + "&GameOver=" + HttpUtility.UrlEncode("1");
            this.url = this.url + "&AccepterArmyName=" + HttpUtility.UrlEncode("n/a");
            this.url = this.url + "&FileSize=" + HttpUtility.UrlEncode(Strings.Trim(Conversion.Str( (this.game.EditObj.ServerUploadFile.GetUpperBound(0) + 1))));
            if (this.game.Data.LastWinner > -1 | this.game.Data.PbemDrawGame == 1)
            {
              if (this.game.Data.PbemDrawGame == 1)
              {
                this.url = this.url + "&Player1Losses=" + HttpUtility.UrlEncode("1");
                this.url = this.url + "&Player2Losses=" + HttpUtility.UrlEncode("1");
              }
              else if (this.game.Data.RegimeObj[this.game.Data.LastWinner].PbemPlayer == 1)
              {
                this.url = this.url + "&Player1Losses=" + HttpUtility.UrlEncode("0");
                this.url = this.url + "&Player2Losses=" + HttpUtility.UrlEncode("1");
              }
              else
              {
                this.url = this.url + "&Player1Losses=" + HttpUtility.UrlEncode("1");
                this.url = this.url + "&Player2Losses=" + HttpUtility.UrlEncode("0");
              }
              this.url = this.url + "&Resigned=" + HttpUtility.UrlEncode("0");
              this.url = this.url + "&ScorePlayer1" + HttpUtility.UrlEncode("0");
            }
          }
        }
      }
      if (!this.e.ServerOrderCancel)
        return;
      this.url = this.baseurl;
      this.e.ServerCommandMaxStep = 0;
    }

    pub fn ReadReceive()
    {
      this.WriteLog("READING");
      if (Information.IsNothing( this.receive))
      {
        this.receive = "99 ***ZERO LENGTH STRING RETURNED BY PBEM++ SERVER***";
        if (this.e.ServerCommand == ServerCommandType.PlayTurn)
          this.receive = "";
      }
      if (this.e.ServerCommand == ServerCommandType.PlayTurn & Operators.CompareString(this.receive, "", false) == 0)
      {
        this.e.ServerStatus = ServerStatusType.Completed;
        this.e.ServerGenericReply = ServerGenericReplyType.Succes;
      }
      else
      {
        strArray1: Vec<String> = this.receive.Split('\n');
        str: String = strArray1[0];
        let mut num1: i32 = !(Strings.AscW(Strings.Left(str, 1)) < 48 | Strings.AscW(Strings.Left(str, 1)) > 57) ?  Math.Round(Conversion.Val(Strings.Left(str, 2))) : 900;
        if (num1 == 99)
          num1 = 900;
        this.e.ServerExactErrorCode = num1;
        let mut upperBound: i32 = strArray1.GetUpperBound(0);
        while (strArray1[upperBound].Length == 0)
          --upperBound;
        this.WriteLog("READING: CODE: " + num1.ToString() + ", MAXLINE: " + upperBound.ToString() + ", SERVERCOMMAND: " + this.e.ServerCommand.ToString() + ", SERVERCOMMANDSTEP: " + this.e.ServerCommandStep.ToString());
        this.e.ServerLostConnect = false;
        if (this.e.ServerCommand == ServerCommandType.Initialize)
        {
          if (this.game.EditObj.PbemSteam & !this.game.EditObj.PbemAlreadyAccount)
          {
            if (this.e.ServerCommandStep == 1)
            {
              if (num1 == 0)
              {
                this.e.ServerAuthReply = ServerAuthReplyType.AuthSucces;
                this.e.ServerSerialReply = ServerSerialReplyType.SerialRegistered;
                this.game.EditObj.PbemSerial = Strings.Mid(strArray1[0], 3);
                this.game.EditObj.Save("editobj.txt");
              }
              else
              {
                this.e.ServerAuthReply = ServerAuthReplyType.AuthFailure;
                this.e.ServerSerialReply = ServerSerialReplyType.SerialNotRegistered;
              }
            }
            this.e.ServerCommandMaxStep = 1;
          }
          else if (this.e.ServerCommandStep == 1)
          {
            switch (num1)
            {
              case 0:
                this.e.ServerSerialReply = ServerSerialReplyType.SerialRegistered;
                this.e.ServerRegisterUserNameReply = Strings.Mid(strArray1[0], 3);
                break;
              case 5:
                this.e.ServerSerialReply = ServerSerialReplyType.SerialNotRegistered;
                this.e.ServerCommandMaxStep = 1;
                break;
              case 900:
                this.e.ServerSerialReply = ServerSerialReplyType.NoConnection;
                this.e.ServerLostConnect = true;
                this.e.ServerCommandMaxStep = 1;
                break;
              default:
                this.e.ServerSerialReply = !this.game.EditObj.PbemSteam ? ServerSerialReplyType.SerialFailure : ServerSerialReplyType.SerialNotRegistered;
                this.e.ServerCommandMaxStep = 1;
                break;
            }
          }
          else if (this.e.ServerCommandStep == 2)
            this.e.ServerAuthReply = num1 != 0 ? ServerAuthReplyType.AuthFailure : ServerAuthReplyType.AuthSucces;
        }
        if (this.e.ServerCommand == ServerCommandType.Register)
        {
          if (this.game.EditObj.PbemSteam)
          {
            if (this.e.ServerCommandStep == 1)
            {
              if (num1 == 0)
              {
                this.e.ServerRegisterReply = ServerRegisterReplyType.RegisterationSucces;
              }
              else
              {
                this.e.ServerRegisterReply = ServerRegisterReplyType.RegisterationFailure;
                this.e.ServerAuthReply = ServerAuthReplyType.AuthFailure;
                this.e.ServerCommandMaxStep = 1;
              }
            }
            else if (this.e.ServerCommandStep == 2)
            {
              if (num1 == 0)
              {
                this.e.ServerAuthReply = ServerAuthReplyType.AuthSucces;
                this.game.EditObj.PbemSerial = Strings.Mid(strArray1[0], 3);
                this.game.EditObj.Save("editobj.txt");
              }
              else
                this.e.ServerAuthReply = ServerAuthReplyType.AuthFailure;
              this.e.ServerCommandMaxStep = 2;
            }
          }
          else if (!this.game.EditObj.PbemSteam)
          {
            if (this.e.ServerCommandStep == 1)
            {
              switch (num1)
              {
                case 0:
                  this.e.ServerSerialReply = ServerSerialReplyType.SerialRegistered;
                  this.e.ServerRegisterUserNameReply = Strings.Mid(strArray1[0], 3);
                  this.e.ServerCommandMaxStep = 1;
                  break;
                case 5:
                  this.e.ServerSerialReply = ServerSerialReplyType.SerialNotRegistered;
                  break;
                default:
                  this.e.ServerSerialReply = ServerSerialReplyType.SerialFailure;
                  this.e.ServerCommandMaxStep = 1;
                  break;
              }
            }
            else if (this.e.ServerCommandStep == 2)
            {
              if (num1 == 0)
              {
                this.e.ServerRegisterReply = ServerRegisterReplyType.RegisterationSucces;
              }
              else
              {
                this.e.ServerRegisterReply = ServerRegisterReplyType.RegisterationFailure;
                this.e.ServerAuthReply = ServerAuthReplyType.AuthFailure;
                this.e.ServerCommandMaxStep = 1;
              }
            }
            else if (this.e.ServerCommandStep == 3)
              this.e.ServerAuthReply = num1 != 0 ? ServerAuthReplyType.AuthFailure : ServerAuthReplyType.AuthSucces;
          }
        }
        if (this.e.ServerCommand == ServerCommandType.Login && this.e.ServerCommandStep == 1)
        {
          if (num1 == 0)
          {
            this.e.ServerAuthReply = ServerAuthReplyType.AuthSucces;
            if (this.game.EditObj.PbemSteam)
            {
              this.game.EditObj.PbemSerial = Strings.Mid(strArray1[0], 3);
              this.game.EditObj.Save("editobj.txt");
            }
          }
          else
            this.e.ServerAuthReply = ServerAuthReplyType.AuthFailure;
        }
        if (this.e.ServerCommand == ServerCommandType.Logout && this.e.ServerCommandStep == 1)
        {
          if (num1 == 0)
          {
            this.e.ServerGenericReply = ServerGenericReplyType.Succes;
            this.e.ServerAuthReply = ServerAuthReplyType.AuthFailure;
            this.e.ServerRunningGameList = (RunningGameClass[]) null;
            this.e.ServerChallengeList = (ChallengeClass[]) null;
          }
          else
            this.e.ServerGenericReply = ServerGenericReplyType.Failure;
        }
        if (this.e.ServerCommand == ServerCommandType.CheckPlayer && this.e.ServerCommandStep == 1)
        {
          if (num1 == 0)
          {
            this.e.ServerGenericReply = ServerGenericReplyType.Succes;
          }
          else
          {
            this.e.ServerGenericReply = ServerGenericReplyType.Failure;
            this.e.ServerCommandMaxStep = 1;
          }
        }
        if (this.e.ServerCommand == ServerCommandType.Refresh)
        {
          if (this.e.ServerCommandStep == 1)
          {
            if (num1 == 0)
            {
              this.e.ServerGenericReply = ServerGenericReplyType.Succes;
              this.e.ServerChallengeList = new ChallengeClass[upperBound - 1 + 1];
              let mut num2: i32 = upperBound;
              for (let mut index: i32 = 1; index <= num2; index += 1)
              {
                this.e.ServerChallengeList[index - 1] = ChallengeClass::new();
                strArray2: Vec<String> = strArray1[index].Split(',');
                this.e.ServerChallengeList[index - 1].challengeID = Conversions.ToInteger(strArray2[0]);
                this.e.ServerChallengeList[index - 1].challengerUserName = Strings.Mid(strArray2[1], 2, Strings.Len(strArray2[1]) - 2);
                this.e.ServerChallengeList[index - 1].challengerSide = Conversions.ToInteger(strArray2[2]);
                this.e.ServerChallengeList[index - 1].firstPlayerSide = Conversions.ToInteger(strArray2[3]);
                this.e.ServerChallengeList[index - 1].gameName = Strings.Mid(strArray2[4], 2, Strings.Len(strArray2[4]) - 2);
                this.e.ServerChallengeList[index - 1].dateIssued = Conversions.ToDate(strArray2[5]);
                this.e.ServerChallengeList[index - 1].challengePrivate = Conversions.ToInteger(strArray2[6]);
                this.e.ServerChallengeList[index - 1].productID = Conversions.ToInteger(strArray2[7]);
                this.e.ServerChallengeList[index - 1].armyName = Strings.Mid(strArray2[8], 2, Strings.Len(strArray2[8]) - 2);
                this.e.ServerChallengeList[index - 1].armyPoints = Conversions.ToInteger(strArray2[9]);
                this.e.ServerChallengeList[index - 1].showName = Conversions.ToInteger(strArray2[10]);
                this.e.ServerChallengeList[index - 1].miscData = Strings.Mid(strArray2[11], 1, Strings.Len(strArray2[11]) - 0);
              }
            }
            else
            {
              this.e.ServerGenericReply = ServerGenericReplyType.Failure;
              this.e.ServerCommandMaxStep = 1;
            }
          }
          if (this.e.ServerCommandStep == 2)
          {
            if (num1 == 0)
            {
              this.e.ServerRunningGameList = new RunningGameClass[upperBound - 1 + 1];
              try
              {
                let mut num3: i32 = upperBound;
                for (let mut index: i32 = 1; index <= num3; index += 1)
                {
                  this.WriteLog("READING LINE " + index.ToString());
                  this.e.ServerRunningGameList[index - 1] = RunningGameClass::new();
                  strArray3: Vec<String> = strArray1[index].Split(',');
                  this.e.ServerRunningGameList[index - 1].gameInstanceID = Conversions.ToInteger(strArray3[0]);
                  this.e.ServerRunningGameList[index - 1].pairedGameID = Conversions.ToInteger(strArray3[1]);
                  this.e.ServerRunningGameList[index - 1].playerToUserName = Strings.Mid(strArray3[2], 2, Strings.Len(strArray3[2]) - 2);
                  this.e.ServerRunningGameList[index - 1].Player1UserName = Strings.Mid(strArray3[3], 2, Strings.Len(strArray3[3]) - 2);
                  this.e.ServerRunningGameList[index - 1].Player2UserName = Strings.Mid(strArray3[4], 2, Strings.Len(strArray3[4]) - 2);
                  this.e.ServerRunningGameList[index - 1].TurnNo = Conversions.ToInteger(strArray3[5]);
                  this.e.ServerRunningGameList[index - 1].GameName = strArray3[6];
                  this.e.ServerRunningGameList[index - 1].DateIssued = Conversions.ToDate(strArray3[7]);
                  this.e.ServerRunningGameList[index - 1].lastUploaded = Conversions.ToDate(strArray3[8]);
                  this.e.ServerRunningGameList[index - 1].GameOver = Conversions.ToBoolean(strArray3[9]);
                  this.e.ServerRunningGameList[index - 1].MiscData = strArray3[15];
                  this.WriteLog("." + index.ToString());
                  if (this.e.ServerRunningGameList[index - 1].GameOver)
                  {
                    this.WriteLog(".." + index.ToString());
                    this.e.ServerRunningGameList[index - 1].Player1Losses = Operators.CompareString(Strings.Left(strArray3[10], 1), "1", false) != 0 ? 0.0f : 1f;
                    this.e.ServerRunningGameList[index - 1].Player2Losses = Operators.CompareString(Strings.Left(strArray3[11], 1), "1", false) != 0 ? 0.0f : 1f;
                    this.e.ServerRunningGameList[index - 1].Viewed = Conversions.ToInteger(strArray3[12]);
                    this.e.ServerRunningGameList[index - 1].lastTurnUploaded = Conversions.ToDate(strArray3[16]);
                  }
                  this.WriteLog("..." + index.ToString());
                }
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                this.WriteLog("Error: " + ex.Message);
                ProjectData.ClearProjectError();
              }
              this.e.ServerGenericReply = ServerGenericReplyType.Succes;
            }
            else
              this.e.ServerGenericReply = ServerGenericReplyType.Failure;
            this.WriteLog("....");
          }
        }
        if (this.e.ServerCommand == ServerCommandType.Challenge && this.e.ServerCommandStep == 1)
          this.e.ServerGenericReply = num1 != 0 ? ServerGenericReplyType.Failure : ServerGenericReplyType.Succes;
        if (this.e.ServerCommand == ServerCommandType.CancelChallenge && this.e.ServerCommandStep == 1)
          this.e.ServerGenericReply = num1 != 0 ? ServerGenericReplyType.Failure : ServerGenericReplyType.Succes;
        if (this.e.ServerCommand == ServerCommandType.UploadInstance)
        {
          let mut num4: i32 = 0;
          if (this.e.ServerCommandStep + num4 == 1)
          {
            switch (num1)
            {
              case 0:
                this.e.ServerSerialReply = ServerSerialReplyType.SerialRegistered;
                this.e.ServerRegisterUserNameReply = Strings.Mid(strArray1[0], 3);
                break;
              case 5:
                this.e.ServerSerialReply = ServerSerialReplyType.SerialNotRegistered;
                this.e.ServerCommandMaxStep = 1;
                break;
              case 900:
                this.e.ServerSerialReply = ServerSerialReplyType.NoConnection;
                this.e.ServerLostConnect = true;
                this.e.ServerCommandMaxStep = 1;
                break;
              default:
                this.e.ServerSerialReply = ServerSerialReplyType.SerialFailure;
                this.e.ServerCommandMaxStep = 1;
                break;
            }
          }
          else if (this.e.ServerCommandStep + num4 == 2)
          {
            if (num1 == 0)
            {
              this.e.ServerAuthReply = ServerAuthReplyType.AuthSucces;
            }
            else
            {
              this.e.ServerAuthReply = ServerAuthReplyType.AuthFailure;
              this.e.ServerCommandMaxStep = 1;
            }
          }
          else if (this.e.ServerCommandStep + num4 == 3)
          {
            this.e.ServerGenericReply = num1 != 0 ? ServerGenericReplyType.Failure : ServerGenericReplyType.Succes;
            if (this.game.EditObj.PbemSteam)
              this.e.ServerCommandMaxStep = 2;
          }
        }
        if (this.e.ServerCommand == ServerCommandType.Claim && this.e.ServerCommandStep == 1)
          this.e.ServerGenericReply = num1 != 0 ? ServerGenericReplyType.Failure : ServerGenericReplyType.Succes;
        if (this.e.ServerCommand == ServerCommandType.AcceptChallenge && this.e.ServerCommandStep == 1)
          this.e.ServerGenericReply = num1 != 0 ? ServerGenericReplyType.Failure : ServerGenericReplyType.Succes;
        if (this.e.ServerCommand == ServerCommandType.PlayTurn && this.e.ServerCommandStep == 1)
          this.e.ServerGenericReply = num1 != 0 ? ServerGenericReplyType.Failure : ServerGenericReplyType.Succes;
        this.WriteLog("END READING. GENERICSERVERREPLY=" + this.e.ServerGenericReply.ToString());
      }
    }

    pub fn WriteLog(string s)
    {
      if (Strings.InStr(s, "SEND:") > 0)
      {
        try
        {
          if (Strings.InStr(s, "serial_num=") <= 0)
            ;
          if (Strings.InStr(s, "password") <= 0)
            ;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
      }
      StreamWriter streamWriter = System.IO.File.AppendText(this.game.AppPath + "logs/ServerLog.txt");
      streamWriter.WriteLine(DateTime.Now.ToString());
      streamWriter.WriteLine(s);
      streamWriter.Close();
    }

     class WebRequestState
    {
      pub WebRequest Request;
      pub WebResponse Response;
      pub Stream RespStream;
      pub byte[] buf;
      pub headerRead: bool;
      pub completed: bool;
      pub tempreceive: String;
      pub byte[] upload;
      pub long uploaddone;
      pub e: EditClass;
      pub responseStarted: bool;
      pub DateTime lastRead;

      pub WebRequestState(WebRequest newRequest)
      {
        this.buf = new byte[131073];
        this.upload = new byte[4194305];
        this.Request = newRequest;
        this.responseStarted = false;
      }
    }
  }
}
