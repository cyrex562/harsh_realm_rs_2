// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.GameLoopMainWindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsApplication1
{
  pub class GameLoopMainWindowClass2 : WindowClass
  {
     int TempText;
     int TempText2;
     int uploadid;
     int login2id;
     int save2id;
     int HeadingText;
     int Heading2Text;
     int Heading3Text;
     int heading4text;
     int EnterTurnId;
     int EnterTurnTextId;
     int LoginId;
     int QuitId;
     int okid;
     int oktextid;
     int Phase;
     int PhaseData;
     int[] TextId;
     int[] ButId;
     int[] ButEvent;
     int Pic1Id;
     int Pic2Id;
     int SaveId;
     bool saved;
     bool loggedin;
     int TAid;
     int refrcount;
     int opt9;
     int opt3;
     ATListClass ListObj;
     ATListClass ListObj2;
     int Listid1;
     int listid2;
     int cloudid;
     int noteid;
     int note2id;
     DateTime showtime;
     string prevs;
     bool DoingSe1GameLoop;
     bool earlyCinematicsLoginBlock;

    pub GameLoopMainWindowClass2( GameClass tGame)
      : base( tGame, 1024, 236, BackSprite: tGame.SE1_BACKGROUNDLOOP)
    {
      this.TextId = new int[21];
      this.ButId = new int[21];
      this.ButEvent = new int[21];
      this.Setup();
    }

    pub GameLoopMainWindowClass2( GameClass tGame, bool NewGfx)
      : base( tGame, 1024, 236, BackSprite: tGame.SE1_BACKGROUNDLOOP)
    {
      this.TextId = new int[21];
      this.ButId = new int[21];
      this.ButEvent = new int[21];
      this.Setup();
    }

    pub void Setup()
    {
      if (this.game.Data.Turn > -1 && !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
      {
        this.game.EditObj.RealRound = this.game.Data.Round;
        this.game.EditObj.RealTurn = this.game.Data.Turn;
      }
      if (this.game.EditObj.TestEarlyCinematics == 1)
      {
        this.game.se1GameLoop = new GameLoopClass2( this.game);
        this.game.se1GameLoop.Setup();
        this.game.EditObj.TestEarlyCinematics = 2;
        this.Phase = this.game.EditObj.Phase;
        this.PhaseData = -1;
        this.saved = false;
        this.showtime = DateAndTime.Now;
        this.game.se1Running = true;
        this.game.se1ThreadRunning = true;
        this.game.se1Thread = new Thread(new ThreadStart(this.game.se1GameLoop.handleTimer));
        this.game.se1Thread.Name = "Game Loop Thread";
        this.game.se1Thread.Start();
      }
      else if (this.game.Data.se1_earlyCinematicsLogin == 1)
      {
        this.game.se1GameLoop = new GameLoopClass2( this.game);
        this.game.se1GameLoop.Setup();
        this.Phase = this.game.EditObj.Phase;
        this.PhaseData = -1;
        this.saved = false;
        this.showtime = DateAndTime.Now;
        this.game.se1Running = true;
        this.game.se1ThreadRunning = true;
        this.game.se1Thread = new Thread(new ThreadStart(this.game.se1GameLoop.handleTimer));
        this.game.se1Thread.Name = "Game Loop Thread";
        this.game.se1Thread.Start();
      }
      else if (this.game.EditObj.Test == 99 | !this.game.Data.InTurn & this.game.EditObj.Phase == -1)
      {
        this.Phase = this.game.EditObj.Phase;
        this.PhaseData = -1;
        this.saved = false;
        this.showtime = DateAndTime.Now;
        this.DoingSe1GameLoop = false;
        this.game.se1ThreadRunning = false;
        this.game.se1Running = false;
      }
      else
      {
        this.Phase = this.game.EditObj.Phase;
        this.PhaseData = -1;
        this.saved = false;
        this.showtime = DateAndTime.Now;
        if (this.game.EditObj.RealRound == 0 & (double) this.game.Data.RuleVar[319] < 1.0)
        {
          int sfTypeCounter = this.game.Data.SFTypeCounter;
          for (int index1 = 0; index1 <= sfTypeCounter; index1 += 1)
          {
            int killPercent = this.game.Data.SFTypeObj[index1].KillPercent;
            if (killPercent > 0)
            {
              int num =  Math.Round((double) Conversion.Int((float) killPercent * this.game.Data.RuleVar[319]));
              SFTypeClass[] sfTypeObj = this.game.Data.SFTypeObj;
              SFTypeClass[] sfTypeClassArray = sfTypeObj;
              int index2 = index1;
              int index3 = index2;
              sfTypeClassArray[index3].RetreatPercent = sfTypeObj[index2].RetreatPercent + (this.game.Data.SFTypeObj[index1].KillPercent - num);
              this.game.Data.SFTypeObj[index1].KillPercent = num;
            }
          }
        }
        this.game.se1GameLoop = new GameLoopClass2( this.game);
        this.game.se1GameLoop.Setup();
        this.game.se1Running = true;
        this.game.se1ThreadRunning = true;
        this.game.se1Thread = new Thread(new ThreadStart(this.game.se1GameLoop.handleTimer));
        this.game.se1Thread.Name = "Game Loop Thread";
        this.game.se1Thread.Start();
      }
    }

    pub handleTimer: WindowReturnClass()
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (!Information.IsNothing((object) this.game.se1Thread))
      {
        if (!this.game.se1Running & this.game.se1ThreadRunning)
        {
          this.game.se1ThreadRunning = false;
          this.game.se1Thread.Abort();
          this.game.se1Thread.Join();
          this.DoingSe1GameLoop = false;
        }
        else if (this.game.se1ThreadRunning)
          this.DoingSe1GameLoop = true;
      }
      if (this.game.Data.PasswordsOn & !this.game.EditObj.EarlyCinematicsLoggedIn & this.game.EditObj.TestEarlyCinematics == 1 & this.game.EditObj.Test == 4)
      {
        if (this.earlyCinematicsLoginBlock)
        {
          windowReturnClass.Flag = false;
          return windowReturnClass;
        }
        this.earlyCinematicsLoginBlock = true;
        this.game.FormRef.Cursor = Cursors.Default;
        this.EnterTurn2();
        windowReturnClass.Flag = true;
        return windowReturnClass;
      }
      this.earlyCinematicsLoginBlock = false;
      if (this.game.EditObj.TestEarlyCinematics == 1 & this.game.EditObj.Test == 4)
      {
        windowReturnClass.Flag = true;
        windowReturnClass.AddCommand(3, 22);
        return windowReturnClass;
      }
      if (!this.DoingSe1GameLoop)
      {
        if (this.Phase == -1)
        {
          this.Phase = 1;
          this.game.EditObj.Phase = 0;
          this.saved = true;
          if (this.game.Data.PbemGameID > 0)
          {
            this.game.EventRelatedObj.DoCheckEvents(8);
            this.game.ProcessingObj.ClearTempUnitVariables();
          }
          this.game.FormRef.Cursor = Cursors.Default;
          this.EnterTurn();
          windowReturnClass.Flag = true;
          return windowReturnClass;
        }
        if (this.Phase > 0)
        {
          windowReturnClass.Flag = false;
          return windowReturnClass;
        }
      }
      if (this.DoingSe1GameLoop)
      {
        if (this.SubPartCounter > 100)
          this.opt3 = this.opt3;
        if (this.opt9 > 0)
        {
          this.RemoveSubPart(this.opt9);
          this.opt9 = 0;
        }
        if (this.opt3 > 0)
        {
          this.RemoveSubPart(this.opt3);
          this.opt3 = 0;
        }
        if (this.TempText > 0)
        {
          this.RemoveSubPart(this.TempText);
          this.TempText = 0;
        }
        if (this.TempText2 > 0)
        {
          this.RemoveSubPart(this.TempText2);
          this.TempText2 = 0;
        }
        if (this.Heading2Text > 0)
        {
          this.RemoveSubPart(this.Heading2Text);
          this.Heading2Text = 0;
        }
        if (DateAndTime.Now.Subtract(this.showtime).Milliseconds > 300)
        {
          this.showtime = DateAndTime.Now;
          this.game.FormRef.Cursor = Cursors.WaitCursor;
          this += 1.refrcount;
          this.NewBackGroundAndClearAll(1024, 236, DrawMod.TGame.SE1_BACKGROUNDLOOP);
          Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
          Font marcFont1_1 = this.game.MarcFont1;
          bool tBlackBack = false;
          this.DrawDateAndRegime( g);
          windowReturnClass.Flag = true;
          g.Dispose();
          g = (Graphics) null;
          if (Information.IsNothing((object) this.game.EditObj.TempAIString))
            this.game.EditObj.TempAIString = "";
          SubPartClass tsubpart1;
          if (this.game.EditObj.TempAIString.Length < 1)
          {
            let mut tsubpart2: SubPartClass =  TextPartClass::new("Configuring Game", marcFont1_1, 800, 40, true, tBlackBack: tBlackBack, tMarc: (!tBlackBack));
            this.TempText = this.AddSubPart( tsubpart2, 120, 80, 800, 40, 0);
          }
          else
          {
            if (this.game.EditObj.RealTurn == this.game.Data.Turn)
              this.game.EditObj.TempAIString = "Preparing your turn for play!";
            tsubpart1 =  TextPartClass::new(this.game.EditObj.TempAIString, marcFont1_1, 800, 40, true, tBlackBack: tBlackBack, tMarc: (!tBlackBack));
            this.TempText = this.AddSubPart( tsubpart1, 120, 80, 800, 40, 0);
            if (this.game.EditObj.AIProgressMax > 0)
            {
              tsubpart1 =  TextPartClass::new(Strings.Trim(Conversion.Str((object)  Math.Round((double) this.game.EditObj.AIProgressNow / (double) this.game.EditObj.AIProgressMax * 100.0))) + "% completed", this.game.MarcFont1, 600, 40, true, tBlackBack: true, tProgress: ( Math.Round((double) this.game.EditObj.AIProgressNow / (double) this.game.EditObj.AIProgressMax * 100.0)), tMarc: true);
              this.TempText2 = this.AddSubPart( tsubpart1, 220, 125, 600, 100, 0);
            }
          }
          Font marcFont1_2 = this.game.MarcFont1;
          bool flag = false;
          txt: String = "";
          if (this.game.EditObj.RealTurn > -1 & this.game.EditObj.RealTurn <= this.game.Data.RegimeCounter)
          {
            txt = this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Name;
            if (this.game.Data.RegimeObj[this.game.EditObj.RealTurn].AI | this.game.EditObj.RealTurn < 1)
              txt = "";
          }
          if (this.game.EditObj.RealTurn > -1 & this.game.EditObj.RealTurn != this.game.Data.Turn & this.game.Data.Turn > -1 & this.game.Data.Turn <= this.game.Data.RegimeCounter)
            txt = !( Math.Round(Conversion.Val(this.game.Data.StringListObj[DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 275, 0, 0))].GetData3(0, this.game.Data.RegimeObj[this.game.EditObj.RealTurn].id, 1, this.game.Data.RegimeObj[this.game.Data.Turn].id, 2, "recon", 3))) > 0 | !this.game.Data.ShrowdOn) ? "Unknown Regime" : this.game.Data.RegimeObj[this.game.Data.Turn].Name;
          tsubpart1 =  TextPartClass::new(txt, marcFont1_2, 724, 40, true, tMarc: (!flag));
          this.Heading2Text = this.AddSubPart( tsubpart1, 150, 20, 724, 40, 0);
        }
        return windowReturnClass;
      }
      this.game.EditObj.TempCoordList = CoordList::new();
      if (this.Phase == -1)
      {
        this.Phase = 1;
        this.game.EditObj.Phase = 0;
        this.saved = true;
        if (this.game.Data.PbemGameID > 0)
        {
          this.game.EventRelatedObj.DoCheckEvents(8);
          this.game.ProcessingObj.ClearTempUnitVariables();
        }
        this.game.FormRef.Cursor = Cursors.Default;
        this.EnterTurn();
        windowReturnClass.Flag = true;
        return windowReturnClass;
      }
      if (this.Phase > 0)
      {
        windowReturnClass.Flag = false;
        return windowReturnClass;
      }
      int phase = this.game.EditObj.Phase;
      this.game.EditObj.FromMessage = -1;
      this.game.EditObj.Phase = 0;
      this.game.EditObj.OrderType = 0;
      if (phase != 0 | this.game.EditObj.Test > 4)
      {
        this.game.EditObj.Test = 0;
        this.EnterTurn();
      }
      windowReturnClass.Flag = true;
      return windowReturnClass;
    }

    pub void DrawDateAndRegime( Graphics g)
    {
      SizeF sizeF = SizeF::new();
      if (this.game.EditObj.RealTurn == -1 | this.game.EditObj.RealTurn > this.game.Data.RegimeCounter | this.game.EditObj.RealRound < 1)
        return;
      GC.Collect();
      int index = this.game.EditObj.RealTurn;
      this.game.Data.ThreadBlock();
      if (this.game.EditObj.RealTurn > -1 & this.game.EditObj.RealTurn != this.game.Data.Turn & this.game.Data.Turn > -1)
        index =  Math.Round(Conversion.Val(this.game.Data.StringListObj[DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 275, 0, 0))].GetData3(0, this.game.Data.RegimeObj[this.game.EditObj.RealTurn].id, 1, this.game.Data.RegimeObj[this.game.Data.Turn].id, 2, "recon", 3))) <= 0 ? -1 : this.game.Data.Turn;
      this.game.Data.ThreadRelease();
      if (index <= -1)
        return;
      int red = this.game.Data.RegimeObj[index].Red;
      int green = this.game.Data.RegimeObj[index].Green;
      int blue = this.game.Data.RegimeObj[index].Blue;
      int red2 = this.game.Data.RegimeObj[index].Red2;
      int green2 = this.game.Data.RegimeObj[index].Green2;
      int blue2 = this.game.Data.RegimeObj[index].Blue2;
      int num1 = 1;
      do
      {
        int bannerSpriteNr = this.game.Data.RegimeObj[index].BannerSpriteNr;
        int num2 = 10;
        int num3 = 10;
        if (num1 == 2)
        {
          num2 = 880;
          num3 = 10;
        }
        int num4 = 124;
        int num5 = 210;
         Graphics local1 =  g;
        Bitmap bitmap1 = BitmapStore.GetBitmap(bannerSpriteNr);
         Bitmap local2 =  bitmap1;
        int x1 = num2;
        int y1 = num3;
        int w1 = num4;
        int h1 = num5;
        int origw1 = num4;
        int origh1 = num5;
        double r1 = (double) ((float) red / (float) byte.MaxValue);
        double g1 = (double) ((float) green / (float) byte.MaxValue);
        double b1 = (double) ((float) blue / (float) byte.MaxValue);
        DrawMod.DrawScaledColorized2( local1,  local2, x1, y1, w1, h1, origw1, origh1, (float) r1, (float) g1, (float) b1, 1f);
        int bannerSpriteNr2 = this.game.Data.RegimeObj[index].BannerSpriteNr2;
        if (bannerSpriteNr2 > 0)
        {
           Graphics local3 =  g;
          Bitmap bitmap2 = BitmapStore.GetBitmap(bannerSpriteNr2);
           Bitmap local4 =  bitmap2;
          int x2 = num2;
          int y2 = num3;
          int w2 = num4;
          int h2 = num5;
          int origw2 = num4;
          int origh2 = num5;
          double r2 = (double) ((float) red2 / (float) byte.MaxValue);
          double g2 = (double) ((float) green2 / (float) byte.MaxValue);
          double b2 = (double) ((float) blue2 / (float) byte.MaxValue);
          DrawMod.DrawScaledColorized2( local3,  local4, x2, y2, w2, h2, origw2, origh2, (float) r2, (float) g2, (float) b2, 1f);
        }
        int hqSpriteNr2 = this.game.Data.RegimeObj[index].HQSpriteNr2;
        if (hqSpriteNr2 > 0)
        {
           Graphics local5 =  g;
          Bitmap bitmap3 = BitmapStore.GetBitmap(hqSpriteNr2, 1);
           Bitmap local6 =  bitmap3;
          int x3 = num2 + 16;
          int y3 = num3 + 60;
          double r3 = (double) ((float) this.game.Data.RegimeObj[index].Red3 / (float) byte.MaxValue) - 1.0;
          double g3 = (double) ((float) this.game.Data.RegimeObj[index].Green3 / (float) byte.MaxValue) - 1.0;
          double b3 = (double) ((float) this.game.Data.RegimeObj[index].Blue3 / (float) byte.MaxValue) - 1.0;
          DrawMod.Draw( local5,  local6, x3, y3, (float) r3, (float) g3, (float) b3, 0.95f);
        }
        num1 += 1;
      }
      while (num1 <= 2);
    }

    pub void EnterTurn()
    {
      SizeF sizeF = SizeF::new();
      if (this.HeadingText > 0)
      {
        this.RemoveSubPart(this.HeadingText);
        this.HeadingText = 0;
      }
      if (this.Heading2Text > 0)
        this.RemoveSubPart(this.Heading2Text);
      if (this.Heading3Text > 0)
        this.RemoveSubPart(this.Heading3Text);
      if (this.heading4text > 0)
        this.RemoveSubPart(this.heading4text);
      if (this.EnterTurnId > 0)
        this.RemoveSubPart(this.EnterTurnId);
      if (this.EnterTurnTextId > 0)
        this.RemoveSubPart(this.EnterTurnTextId);
      if (this.TempText > 0)
      {
        this.RemoveSubPart(this.TempText);
        this.TempText = 0;
      }
      if (this.TempText2 > 0)
      {
        this.RemoveSubPart(this.TempText2);
        this.TempText2 = 0;
      }
      if (this.SaveId > 0)
        this.RemoveSubPart(this.SaveId);
      if (this.save2id > 0)
        this.RemoveSubPart(this.save2id);
      if (this.Listid1 > 0)
        this.RemoveSubPart(this.Listid1);
      if (this.listid2 > 0)
        this.RemoveSubPart(this.listid2);
      if (this.login2id > 0)
      {
        this.RemoveSubPart(this.login2id);
        this.login2id = 0;
      }
      if (this.LoginId > 0)
      {
        this.RemoveSubPart(this.LoginId);
        this.LoginId = 0;
      }
      if (this.QuitId > 0)
        this.RemoveSubPart(this.QuitId);
      if (this.uploadid > 0)
        this.RemoveSubPart(this.uploadid);
      this.game.FormRef.Cursor = Cursors.Default;
      if (this.game.EditObj.TutStep < 1)
        this.game.EditObj.TutStep = 1;
      this.game.Data.se1_earlyCinematicsLogin = 0;
      Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
      this.DrawDateAndRegime( g);
      this.game.Data.PbemPlayer1 = this.game.Data.PbemPlayer1.Replace("\"", "");
      this.game.Data.PbemPlayer2 = this.game.Data.PbemPlayer2.Replace("\"", "");
      string str1;
      if (this.game.Data.PbemGameID > 0)
      {
        if (this.game.Data.RegimeObj[this.game.EditObj.RealTurn].PbemPlayer == 1)
        {
          if (Operators.CompareString(Strings.LCase(this.game.Data.PbemPlayer1), Strings.LCase(this.game.EditObj.PbemUserName), false) == 0)
          {
            this.loggedin = true;
          }
          else
          {
            this.loggedin = false;
            str1 = this.game.Data.PbemPlayer1;
          }
        }
        else if (this.game.Data.RegimeObj[this.game.EditObj.RealTurn].PbemPlayer == 2)
        {
          if (Operators.CompareString(Strings.LCase(this.game.Data.PbemPlayer2), Strings.LCase(this.game.EditObj.PbemUserName), false) == 0)
          {
            this.loggedin = true;
          }
          else
          {
            this.loggedin = false;
            str1 = this.game.Data.PbemPlayer2;
          }
        }
        else
        {
          int num =  Interaction.MsgBox((object) "Strange error. a player with no pbemPlayer set. should not be possible unless scenario uses some unexpected scripting. Continue might be possible since code allows access to turn.", Title: ((object) "Shadow Empire : Planetary Conquest"));
          this.loggedin = true;
        }
      }
      else if (!this.game.Data.PasswordsOn)
        this.loggedin = true;
      if (this.game.EditObj.EarlyCinematicsLoggedIn)
        this.loggedin = true;
      string txt;
      if (!this.loggedin)
        txt = this.game.Data.PbemGameID >= 1 ? "Its now the turn of: " + this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Name + " played by " + str1 : this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Name + ", Its your turn. Please login";
      else if (this.game.Data.PbemDrawGame > 0)
        txt = "Game has ended in a draw game.";
      else if (this.game.Data.VPWin == -1)
        txt = this.game.Data.Winner != -1 ? (!(this.game.Data.Winner == this.game.EditObj.RealTurn | this.game.Data.Winner == this.game.Data.RegimeObj[this.game.EditObj.RealTurn].UberRegime) ? this.game.Data.RegimeObj[this.game.Data.Winner].Name + " has won this game. You have lost!" : this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Name + ", You have won this game!") : this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Name + ", Round " + this.game.EditObj.RealRound.ToString();
      else if (this.game.Data.Winner == -1)
        txt = this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Name + ", You have" + Conversion.Str((object) this.game.HandyFunctionsObj.GetRegimeVP(this.game.EditObj.RealTurn)) + " VP of the" + Conversion.Str((object) this.game.Data.VPWin) + " VP required to win.";
      else
        txt = this.game.Data.Winner != this.game.EditObj.RealTurn ? this.game.Data.RegimeObj[this.game.Data.Winner].Name + " has won this game. You have lost!" : this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Name + ", You have won this game!";
      Font marcFont1 = this.game.MarcFont1;
      bool flag1 = false;
      let mut tsubpart1: SubPartClass =  TextPartClass::new(txt, marcFont1, 724, 40, true, tMarc: (!flag1));
      this.Heading2Text = this.AddSubPart( tsubpart1, 150, 20, 724, 40, 0);
      int[] numArray1 = new int[100];
      int[] numArray2 = new int[100];
      int[] numArray3 = new int[100];
      int stringListById = this.game.HandyFunctionsObj.GetStringListByID( Math.Round((double) this.game.Data.RuleVar[441]));
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      int length = this.game.Data.StringListObj[stringListById].Length;
      for (int index = 0; index <= length; index += 1)
      {
        if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index, 1])) == 3)
        {
          int idValue =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index, 2]));
          if (idValue > 0)
          {
            int num5 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(0, idValue, 2)));
            if (num5 > 0)
            {
              if (num5 == 1)
                num1 += 1;
              if (num5 == 2)
                num2 += 1;
            }
          }
        }
      }
      int sfTypeCounter = this.game.Data.SFTypeCounter;
      for (int index1 = 0; index1 <= sfTypeCounter; index1 += 1)
      {
        if (this.game.Data.RegimeObj[this.game.EditObj.RealTurn].SLoss[index1, this.game.EditObj.RealRound] > 0 | this.game.Data.RegimeObj[this.game.EditObj.RealTurn].SKills[index1, this.game.EditObj.RealRound] > 0 | this.game.Data.RegimeObj[this.game.EditObj.RealTurn].SASKilled[index1] > 0)
        {
          int[] numArray4 = numArray1;
          int[] numArray5 = numArray4;
          int unitGroup1 = this.game.Data.SFTypeObj[index1].UnitGroup;
          int index2 = unitGroup1;
          int num6 = numArray4[unitGroup1] + this.game.Data.RegimeObj[this.game.EditObj.RealTurn].SLoss[index1, this.game.EditObj.RealRound] * this.game.Data.SFTypeObj[index1].Ratio;
          numArray5[index2] = num6;
          int[] numArray6 = numArray2;
          int[] numArray7 = numArray6;
          int unitGroup2 = this.game.Data.SFTypeObj[index1].UnitGroup;
          int index3 = unitGroup2;
          int num7 = numArray6[unitGroup2] + this.game.Data.RegimeObj[this.game.EditObj.RealTurn].SKills[index1, this.game.EditObj.RealRound] * this.game.Data.SFTypeObj[index1].Ratio;
          numArray7[index3] = num7;
          int[] numArray8 = numArray2;
          int[] numArray9 = numArray8;
          int unitGroup3 = this.game.Data.SFTypeObj[index1].UnitGroup;
          int index4 = unitGroup3;
          int num8 = numArray8[unitGroup3] + this.game.Data.RegimeObj[this.game.EditObj.RealTurn].SASKilled[index1] * this.game.Data.SFTypeObj[index1].Ratio;
          numArray9[index4] = num8;
          num3 += this.game.Data.RegimeObj[this.game.EditObj.RealTurn].SLoss[index1, this.game.EditObj.RealRound] * this.game.Data.SFTypeObj[index1].Ratio;
          num4 = num4 + this.game.Data.RegimeObj[this.game.EditObj.RealTurn].SKills[index1, this.game.EditObj.RealRound] * this.game.Data.SFTypeObj[index1].Ratio + this.game.Data.RegimeObj[this.game.EditObj.RealTurn].SASKilled[index1] * this.game.Data.SFTypeObj[index1].Ratio;
        }
      }
      str2: String = "";
      int num9 = 0;
      int num10 = 0;
      if (num4 > 0)
      {
        str2 = "We killed ";
        int index = 0;
        do
        {
          if (numArray2[index] > 0)
          {
            if (num9 > 0)
              str2 += ", ";
            num9 += 1;
            str2 = str2 + numArray2[index].ToString() + " " + this.game.Data.TempString[400 + index];
          }
          index += 1;
        }
        while (index <= 99);
      }
      if (num3 > 0)
      {
        str2 = num9 <= 0 ? "We lost " : str2 + " and we lost ";
        int index = 0;
        do
        {
          if (numArray1[index] > 0)
          {
            if (num10 > 0)
              str2 += ", ";
            num10 += 1;
            str2 = str2 + numArray1[index].ToString() + " " + this.game.Data.TempString[400 + index];
          }
          index += 1;
        }
        while (index <= 99);
      }
      str3: String = !(num4 > 0 | num3 > 0) ? str2 + "We suffered no losses, nor made any kills. " : str2 + ". ";
      if (num1 > 0 & num2 > 0)
        str3 = str3 + "We have " + num1.ToString() + " Decisions and " + num2.ToString() + " Reports waiting for you.";
      else if (num1 > 0)
        str3 = str3 + "We have " + num1.ToString() + " Decisions waiting for you.";
      else if (num2 > 0)
        str3 = str3 + "We have " + num2.ToString() + " Reports waiting for you.";
      if (!this.loggedin & this.game.Data.PbemGameID < 1)
        str3 = "Waiting for player to log-in...";
      Font marcFont4_1 = this.game.MarcFont4;
      bool flag2 = false;
      SubPartClass tsubpart2;
      if (Operators.CompareString(str3, "", false) != 0)
      {
        tsubpart2 =  new TextAreaClass2(this.game, 724, 3, marcFont4_1, str3, tbackbitmap: ( this.BackBitmap), bbx: 140, bby: 60, tWithoutScrollbars: true, tWithoutFrame: true, tcenterit: true);
        this.Heading3Text = this.AddSubPart( tsubpart2, 140, 60, 724, 64, 0);
      }
      Font marcFont4_2 = this.game.MarcFont4;
      if (!this.loggedin & this.game.Data.PbemGameID < 1)
      {
        buttontext: String = (double) this.game.Data.RuleVar[839] != 1.0 ? "Login" : "LOGIN";
        if (!this.saved)
        {
          tsubpart2 =  new TextButtonPartClass(buttontext, 100, "You have to login if playing PBEM and/or using passwords.",  this.OwnBitmap, 400, 173, usefont: marcFont4_2, useshadow: (!flag2), tMarcStyle: (!flag2));
          this.LoginId = this.AddSubPart( tsubpart2, 400, 173, 100, 35, 1);
        }
        else
        {
          tsubpart2 =  new TextButtonPartClass(buttontext, 100, "You have to login if playing PBEM and/or using passwords.",  this.OwnBitmap, 455, 173, usefont: marcFont4_2, useshadow: (!flag2), tMarcStyle: (!flag2));
          this.LoginId = this.AddSubPart(ref tsubpart2, 455, 173, 100, 35, 1);
        }
      }
      if (this.game.Data.PbemGameID < 1)
      {
        buttontext: String = (double) this.game.Data.RuleVar[839] != 1.0 ? "Save & Quit" : "SAVE + QUIT";
        if (!this.loggedin & !this.saved)
        {
          tsubpart2 =  new TextButtonPartClass(buttontext, 100, "If your playing a PBEM and your not playing\r\nthis regime this is a good place to save and quit.", ref this.OwnBitmap, 530, 173, usefont: marcFont4_2, useshadow: (!flag2), tMarcStyle: (!flag2));
          this.SaveId = this.AddSubPart(ref tsubpart2, 530, 173, 100, 35, 1);
        }
      }
      buttontext1: String = (double) this.game.Data.RuleVar[839] != 1.0 ? "Start Turn" : "START TURN";
      if (this.loggedin)
      {
        SoundMod.PlayAWave(this.game.AppPath + "sound/drums/Drum " + DrawMod.RandyNumber.Next(1, 8).ToString() + ".OGG", ref this.game.EditObj, volumeMod: 250);
        tsubpart2 =  new TextButtonPartClass(buttontext1, 140, "Click to start the turn.", ref this.OwnBitmap, 435, 173, usefont: marcFont4_2, useshadow: (!flag2), tMarcStyle: (!flag2));
        this.EnterTurnId = this.AddSubPart(ref tsubpart2, 435, 173, 140, 35, 1);
      }
      else if (this.game.Data.PbemGameID > 0)
      {
        tsubpart2 =  new TextButtonPartClass("UPLOAD", 100, "Click to upload your turn to your opponent on the PBEM++ server.", ref this.OwnBitmap, 455, 173, usefont: marcFont4_2, useshadow: (!flag2), tMarcStyle: (!flag2));
        this.uploadid = this.AddSubPart(ref tsubpart2, 455, 173, 100, 35, 1);
      }
      if (Information.IsNothing((object) g))
        return;
      g.Dispose();
    }

    pub void EnterTurn2()
    {
      SizeF sizeF = SizeF::new();
      if (this.HeadingText > 0)
      {
        this.RemoveSubPart(this.HeadingText);
        this.HeadingText = 0;
      }
      if (this.Heading2Text > 0)
        this.RemoveSubPart(this.Heading2Text);
      if (this.Heading3Text > 0)
        this.RemoveSubPart(this.Heading3Text);
      if (this.heading4text > 0)
        this.RemoveSubPart(this.heading4text);
      if (this.EnterTurnId > 0)
        this.RemoveSubPart(this.EnterTurnId);
      if (this.EnterTurnTextId > 0)
        this.RemoveSubPart(this.EnterTurnTextId);
      if (this.TempText > 0)
      {
        this.RemoveSubPart(this.TempText);
        this.TempText = 0;
      }
      if (this.TempText2 > 0)
      {
        this.RemoveSubPart(this.TempText2);
        this.TempText2 = 0;
      }
      if (this.SaveId > 0)
        this.RemoveSubPart(this.SaveId);
      if (this.save2id > 0)
        this.RemoveSubPart(this.save2id);
      if (this.Listid1 > 0)
        this.RemoveSubPart(this.Listid1);
      if (this.listid2 > 0)
        this.RemoveSubPart(this.listid2);
      if (this.LoginId > 0)
      {
        this.RemoveSubPart(this.LoginId);
        this.LoginId = 0;
      }
      if (this.login2id > 0)
      {
        this.RemoveSubPart(this.login2id);
        this.login2id = 0;
      }
      if (this.QuitId > 0)
        this.RemoveSubPart(this.QuitId);
      if (this.uploadid > 0)
        this.RemoveSubPart(this.uploadid);
      this.game.FormRef.Cursor = Cursors.Default;
      if (this.game.EditObj.TutStep < 1)
        this.game.EditObj.TutStep = 1;
      Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
      this.DrawDateAndRegime(ref g);
      string str1;
      str2: String = this.game.Data.PbemGameID >= 1 ? "Its now the turn of: " + this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Name + " played by " + str1 : this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Name + ", Its your turn. Please login";
      Font marcFont1 = this.game.MarcFont1;
      bool flag1 = false;
      let mut tsubpart1: SubPartClass =  TextPartClass::new(str2, marcFont1, 724, 40, true, tMarc: (!flag1));
      this.Heading2Text = this.AddSubPart(ref tsubpart1, 150, 20, 724, 40, 0);
      if (!this.loggedin & this.game.Data.PbemGameID < 1)
        str2 = "Player log-in needed...";
      Font marcFont4_1 = this.game.MarcFont4;
      bool flag2 = false;
      SubPartClass tsubpart2;
      if (Operators.CompareString(str2, "", false) != 0)
      {
        tsubpart2 =  new TextAreaClass2(this.game, 724, 3, marcFont4_1, str2, tbackbitmap: (ref this.BackBitmap), bbx: 140, bby: 60, tWithoutScrollbars: true, tWithoutFrame: true, tcenterit: true);
        this.Heading3Text = this.AddSubPart(ref tsubpart2, 140, 60, 724, 64, 0);
      }
      Font marcFont4_2 = this.game.MarcFont4;
      if (this.game.Data.se1_earlyCinematicsLogin == 0)
        this.game.Data.se1_earlyCinematicsLogin = 1;
      buttontext1: String = (double) this.game.Data.RuleVar[839] != 1.0 ? "Login" : "LOGIN";
      if (!this.saved)
      {
        tsubpart2 =  new TextButtonPartClass(buttontext1, 100, "You have to login if playing PBEM and/or using passwords.", ref this.OwnBitmap, 400, 173, usefont: marcFont4_2, useshadow: (!flag2), tMarcStyle: (!flag2));
        this.login2id = this.AddSubPart(ref tsubpart2, 400, 173, 100, 35, 1);
      }
      else
      {
        tsubpart2 =  new TextButtonPartClass(buttontext1, 100, "You have to login if playing PBEM and/or using passwords.", ref this.OwnBitmap, 455, 173, usefont: marcFont4_2, useshadow: (!flag2), tMarcStyle: (!flag2));
        this.login2id = this.AddSubPart(ref tsubpart2, 455, 173, 100, 35, 1);
      }
      buttontext2: String = (double) this.game.Data.RuleVar[839] != 1.0 ? "Save & Quit" : "SAVE + QUIT";
      if (!this.loggedin & !this.saved)
      {
        tsubpart2 =  new TextButtonPartClass(buttontext2, 100, "If your playing a PBEM and your not playing\r\nthis regime this is a good place to save and quit.", ref this.OwnBitmap, 530, 173, usefont: marcFont4_2, useshadow: (!flag2), tMarcStyle: (!flag2));
        this.SaveId = this.AddSubPart(ref tsubpart2, 530, 173, 100, 35, 1);
      }
      if (Information.IsNothing((object) g))
        return;
      g.Dispose();
      g = (Graphics) null;
    }

    pub HandleKeyPress: WindowReturnClass(int nr, bool fromTimer = false)
    {
      windowReturnClass1: WindowReturnClass = WindowReturnClass::new();
      if (nr == 32 | nr == 13)
      {
        if (this.LoginId > 0)
        {
          windowReturnClass2: WindowReturnClass = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.LoginId)] + 1, this.SubPartY[this.SubpartNr(this.LoginId)] + 1, 1);
          windowReturnClass2.SetFlag(true);
          return windowReturnClass2;
        }
        if (this.EnterTurnId > 0)
        {
          windowReturnClass3: WindowReturnClass = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.EnterTurnId)] + 1, this.SubPartY[this.SubpartNr(this.EnterTurnId)] + 1, 1);
          windowReturnClass3.SetFlag(true);
          return windowReturnClass3;
        }
        if (this.okid > 0)
        {
          windowReturnClass4: WindowReturnClass = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.okid)] + 1, this.SubPartY[this.SubpartNr(this.okid)] + 1, 1);
          windowReturnClass4.SetFlag(true);
          return windowReturnClass4;
        }
      }
      return windowReturnClass1;
    }

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index1 = 0; index1 <= subPartCounter; index1 += 1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int num1 = this.SubPartID[index1];
            if (num1 == this.Listid1)
            {
              this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.TAid)
            {
              this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.listid2)
            {
              this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.uploadid)
            {
              this.game.FormRef.Cursor = Cursors.WaitCursor;
              str: String = this.game.AppPath_SAVEGAMES + "uploadfile.se1";
              this.game.Data.serialize(str);
              this.game.HandyFunctionsObj.ZipFile(str);
              this.game.FormRef.Cursor = Cursors.Default;
              this.game.EditObj.PbemGameSetup = PbemGameSetupPhase.TurnPlayed;
              windowReturnClass.AddCommand(3, 12);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.QuitId)
            {
              if (Interaction.MsgBox((object) "Are you Sure?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
              {
                this.game.Data = DataClass::new();
                this.game.EditObj = new EditClass(this.game.AppPath + "editobj.txt");
                if (this.game.Data.UseAI == 1)
                  this.game.NewAIObj.LastRegime = -1;
                this.game.EditObj.ShowInitialMenu = true;
                windowReturnClass.AddCommand(3, 12);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
            else
            {
              if (num1 == this.LoginId || num1 == this.login2id)
              {
                if (this.game.Data.PasswordsOn)
                {
                  if (Strings.Len(this.game.Data.RegimeObj[this.game.EditObj.RealTurn].PassWord) == 0)
                    this.game.Data.RegimeObj[this.game.EditObj.RealTurn].PassWord = Interaction.InputBox("First turn for this regime. Please give a password. DON''T FORGET IT!!", "Shadow Empire : Planetary Conquest");
                  else if (Operators.CompareString(Strings.UCase(Interaction.InputBox("Please give your password...", "Shadow Empire : Planetary Conquest")), Strings.UCase(this.game.Data.RegimeObj[this.game.EditObj.RealTurn].PassWord), false) == 0 | this.game.SuperAdminRights)
                  {
                    if (this.SubPartID[index1] == this.login2id)
                      this.game.EditObj.EarlyCinematicsLoggedIn = true;
                    else
                      this.loggedin = true;
                    this.game.EditObj.pdfGenerated = "";
                    this += 1.game.EditObj.TutStep;
                    if (this.game.EditObj.Screenshoton)
                    {
                      this.game.FormRef.Cursor = Cursors.WaitCursor;
                      this.game.HandyFunctionsObj.doscreenshot("a", 0);
                      this.game.FormRef.Cursor = Cursors.Default;
                    }
                  }
                  else
                  {
                    int num2 =  Interaction.MsgBox((object) "Wrong password.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    this.loggedin = false;
                    this.EnterTurn();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                }
                else
                {
                  this.loggedin = true;
                  this.game.EditObj.pdfGenerated = "";
                  this += 1.game.EditObj.TutStep;
                  if (this.game.EditObj.Screenshoton)
                  {
                    this.game.FormRef.Cursor = Cursors.WaitCursor;
                    this.game.HandyFunctionsObj.doscreenshot("a", 0);
                    this.game.FormRef.Cursor = Cursors.Default;
                  }
                }
                if (this.game.Data.PBEM & this.game.Data.PbemGameID < 1 && this.game.Data.GameID > -1)
                {
                  MasterLogClass masterLogClass = MasterLogClass::new();
                  str: String = this.game.AppPath + "masterlog.mlc";
                  DirectoryInfo Expression;
                  if (Directory.Exists(this.game.AppPath + "masterlogdir"))
                  {
                    Directory.CreateDirectory(this.game.AppPath + "masterlogdir");
                    Expression = new DirectoryInfo(this.game.AppPath + "masterlogdir");
                  }
                  else
                    Expression = (DirectoryInfo) null;
                  if (System.IO.File.Exists(str))
                  {
                    this.game.HandyFunctionsObj.Unzip(str);
                    masterLogClass = MasterLogClass.deserialize(str);
                    this.game.HandyFunctionsObj.ZipFile(str);
                  }
                  if (this.game.Data.RegimeObj[this.game.EditObj.RealTurn].FirstRound < 1)
                    this.game.Data.RegimeObj[this.game.EditObj.RealTurn].FirstRound = this.game.EditObj.RealRound;
                  if (this.game.EditObj.RealRound == 1 | this.game.Data.RegimeObj[this.game.EditObj.RealTurn].FirstRound == this.game.EditObj.RealRound)
                  {
                    if (this.game.Data.Round == 1 & this.game.EditObj.RealTurn > 2 & this.game.Data.PasswordsOn && Operators.ConditionalCompareObjectGreater(masterLogClass.ReturnQty(this.game.Data.GameID, this.game.EditObj.RealRound, this.game.EditObj.RealTurn - 1, this.game.Data.RegimeObj[this.game.EditObj.RealTurn - 1].RandomCode), (object) 0, false))
                    {
                      this.loggedin = false;
                      int num3 =  Interaction.MsgBox((object) "We cannot allow you to log into this turn as you have already logged in to the previous turn.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (Operators.ConditionalCompareObjectLess(masterLogClass.ReturnQty(this.game.Data.GameID, this.game.EditObj.RealRound, this.game.EditObj.RealTurn, -1), (object) 1, false))
                    {
                      this.game.Data.RegimeObj[this.game.EditObj.RealTurn].RandomCode =  Math.Round((double) Conversion.Int(VBMath.Rnd() * 9999f));
                      masterLogClass.SetEntry(this.game.Data.GameID, this.game.EditObj.RealRound, this.game.EditObj.RealTurn, this.game.Data.RegimeObj[this.game.EditObj.RealTurn].RandomCode);
                    }
                  }
                  else
                  {
                    int integer1;
                    if (Operators.ConditionalCompareObjectLess(masterLogClass.ReturnQty(this.game.Data.GameID, this.game.EditObj.RealRound - 1, this.game.EditObj.RealTurn, this.game.Data.RegimeObj[this.game.EditObj.RealTurn].RandomCode), (object) 1, false))
                    {
                      if (this.game.Data.TerrorMode)
                      {
                        this.loggedin = false;
                        int num4 =  Interaction.MsgBox((object) "Wiped Logbook. Terror Mode aborts opening this turn.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      int regimeCounter = this.game.Data.RegimeCounter;
                      for (int index2 = 0; index2 <= regimeCounter; index2 += 1)
                      {
                        RegimeClass[] regimeObj = this.game.Data.RegimeObj;
                        RegimeClass[] regimeClassArray = regimeObj;
                        int index3 = index2;
                        int index4 = index3;
                        regimeClassArray[index4].MessCounter = regimeObj[index3].MessCounter + 1;
                        int messCounter = this.game.Data.RegimeObj[index2].MessCounter;
                        this.game.Data.RegimeObj[index2].MessString = (string[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index2].MessString, (Array) new string[messCounter + 1]);
                        this.game.Data.RegimeObj[index2].MessBackPic = (int[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index2].MessBackPic, (Array) new int[messCounter + 1]);
                        this.game.Data.RegimeObj[index2].MessFrontPic = (int[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index2].MessFrontPic, (Array) new int[messCounter + 1]);
                        this.game.Data.RegimeObj[index2].MesStyle = (int[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index2].MesStyle, (Array) new int[messCounter + 1]);
                        this.game.Data.RegimeObj[index2].MesNote = (string[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index2].MesNote, (Array) new string[messCounter + 1]);
                        this.game.Data.RegimeObj[index2].MesNote2 = (string[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index2].MesNote2, (Array) new string[messCounter + 1]);
                        this.game.Data.RegimeObj[index2].MessWav = (string[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index2].MessWav, (Array) new string[messCounter + 1]);
                        this.game.Data.RegimeObj[index2].MesGroup = (int[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index2].MesGroup, (Array) new int[messCounter + 1]);
                        this.game.Data.RegimeObj[index2].MesName = (string[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index2].MesName, (Array) new string[messCounter + 1]);
                        this.game.Data.RegimeObj[index2].MesChosen = (int[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index2].MesChosen, (Array) new int[messCounter + 1]);
                        this.game.Data.RegimeObj[index2].MesHideFromStart = (bool[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index2].MesHideFromStart, (Array) new bool[messCounter + 1]);
                        this.game.Data.RegimeObj[index2].MesHideFromTab = (bool[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index2].MesHideFromTab, (Array) new bool[messCounter + 1]);
                        this.game.Data.RegimeObj[index2].MesStyle[messCounter] = 0;
                        this.game.Data.RegimeObj[index2].MessString[messCounter] = "Possible PBEM cheat\r\n\r\n" + this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Name + " has wiped his pbem logbook.";
                        this.game.Data.RegimeObj[index2].MessBackPic[messCounter] = -2;
                        this.game.Data.RegimeObj[index2].MessFrontPic[messCounter] = -1;
                      }
                    }
                    else if (Operators.ConditionalCompareObjectGreater(masterLogClass.ReturnQty(this.game.Data.GameID, this.game.EditObj.RealRound, this.game.EditObj.RealTurn, -1), (object) 0, false))
                    {
                      int integer2 = Conversions.ToInteger(Operators.AddObject(masterLogClass.ReturnQty(this.game.Data.GameID, this.game.EditObj.RealRound, this.game.EditObj.RealTurn, -1), (object) 1));
                      if (this.game.Data.TerrorMode)
                      {
                        this.loggedin = false;
                        int num5 =  Interaction.MsgBox((object) "Turn has already been opened before. Terror Mode aborts opening this turn.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      int regimeCounter = this.game.Data.RegimeCounter;
                      for (int index5 = 0; index5 <= regimeCounter; index5 += 1)
                      {
                        RegimeClass[] regimeObj = this.game.Data.RegimeObj;
                        RegimeClass[] regimeClassArray = regimeObj;
                        int index6 = index5;
                        int index7 = index6;
                        regimeClassArray[index7].MessCounter = regimeObj[index6].MessCounter + 1;
                        int messCounter = this.game.Data.RegimeObj[index5].MessCounter;
                        this.game.Data.RegimeObj[index5].MessString = (string[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index5].MessString, (Array) new string[messCounter + 1]);
                        this.game.Data.RegimeObj[index5].MessBackPic = (int[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index5].MessBackPic, (Array) new int[messCounter + 1]);
                        this.game.Data.RegimeObj[index5].MessFrontPic = (int[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index5].MessFrontPic, (Array) new int[messCounter + 1]);
                        this.game.Data.RegimeObj[index5].MesStyle = (int[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index5].MesStyle, (Array) new int[messCounter + 1]);
                        this.game.Data.RegimeObj[index5].MesNote = (string[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index5].MesNote, (Array) new string[messCounter + 1]);
                        this.game.Data.RegimeObj[index5].MesNote2 = (string[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index5].MesNote2, (Array) new string[messCounter + 1]);
                        this.game.Data.RegimeObj[index5].MessWav = (string[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index5].MessWav, (Array) new string[messCounter + 1]);
                        this.game.Data.RegimeObj[index5].MesGroup = (int[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index5].MesGroup, (Array) new int[messCounter + 1]);
                        this.game.Data.RegimeObj[index5].MesName = (string[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index5].MesName, (Array) new string[messCounter + 1]);
                        this.game.Data.RegimeObj[index5].MesChosen = (int[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index5].MesChosen, (Array) new int[messCounter + 1]);
                        this.game.Data.RegimeObj[index5].MesHideFromStart = (bool[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index5].MesHideFromStart, (Array) new bool[messCounter + 1]);
                        this.game.Data.RegimeObj[index5].MesHideFromTab = (bool[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index5].MesHideFromTab, (Array) new bool[messCounter + 1]);
                        this.game.Data.RegimeObj[index5].MesStyle[messCounter] = 0;
                        this.game.Data.RegimeObj[index5].MessString[messCounter] = "Possible PBEM cheat\r\n\r\n" + this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Name + " has opened round " + Conversion.Str((object) this.game.EditObj.RealRound) + " for the " + Conversion.Str((object) integer2) + "th time.";
                        this.game.Data.RegimeObj[index5].MessBackPic[messCounter] = -2;
                        this.game.Data.RegimeObj[index5].MessFrontPic[messCounter] = -1;
                      }
                    }
                    else if (Information.IsNothing((object) Expression))
                    {
                      integer1 = Conversions.ToInteger(Operators.AddObject(masterLogClass.ReturnQty(this.game.Data.GameID, this.game.EditObj.RealRound, this.game.EditObj.RealTurn, -1), (object) 1));
                      if (this.game.Data.TerrorMode)
                      {
                        this.loggedin = false;
                        int num6 =  Interaction.MsgBox((object) "Unknown operations done to logfiles by user. Terror Mode aborts opening this turn.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      int regimeCounter = this.game.Data.RegimeCounter;
                      for (int index8 = 0; index8 <= regimeCounter; index8 += 1)
                      {
                        RegimeClass[] regimeObj = this.game.Data.RegimeObj;
                        RegimeClass[] regimeClassArray = regimeObj;
                        int index9 = index8;
                        int index10 = index9;
                        regimeClassArray[index10].MessCounter = regimeObj[index9].MessCounter + 1;
                        int messCounter = this.game.Data.RegimeObj[index8].MessCounter;
                        this.game.Data.RegimeObj[index8].MessString = (string[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index8].MessString, (Array) new string[messCounter + 1]);
                        this.game.Data.RegimeObj[index8].MessBackPic = (int[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index8].MessBackPic, (Array) new int[messCounter + 1]);
                        this.game.Data.RegimeObj[index8].MessFrontPic = (int[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index8].MessFrontPic, (Array) new int[messCounter + 1]);
                        this.game.Data.RegimeObj[index8].MesStyle = (int[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index8].MesStyle, (Array) new int[messCounter + 1]);
                        this.game.Data.RegimeObj[index8].MesNote = (string[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index8].MesNote, (Array) new string[messCounter + 1]);
                        this.game.Data.RegimeObj[index8].MesNote2 = (string[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index8].MesNote2, (Array) new string[messCounter + 1]);
                        this.game.Data.RegimeObj[index8].MessWav = (string[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index8].MessWav, (Array) new string[messCounter + 1]);
                        this.game.Data.RegimeObj[index8].MesGroup = (int[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index8].MesGroup, (Array) new int[messCounter + 1]);
                        this.game.Data.RegimeObj[index8].MesName = (string[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index8].MesName, (Array) new string[messCounter + 1]);
                        this.game.Data.RegimeObj[index8].MesChosen = (int[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index8].MesChosen, (Array) new int[messCounter + 1]);
                        this.game.Data.RegimeObj[index8].MesHideFromStart = (bool[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index8].MesHideFromStart, (Array) new bool[messCounter + 1]);
                        this.game.Data.RegimeObj[index8].MesHideFromTab = (bool[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index8].MesHideFromTab, (Array) new bool[messCounter + 1]);
                        this.game.Data.RegimeObj[index8].MesStyle[messCounter] = 0;
                        this.game.Data.RegimeObj[index8].MessString[messCounter] = "Possible PBEM cheat\r\n\r\n" + this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Name + " has been making changes to log files. He has deleted a directory. ";
                        this.game.Data.RegimeObj[index8].MessBackPic[messCounter] = -2;
                        this.game.Data.RegimeObj[index8].MessFrontPic[messCounter] = -1;
                      }
                    }
                    else if (DateTime.Compare(masterLogClass.LastSave, Expression.CreationTime) != 0)
                    {
                      integer1 = Conversions.ToInteger(Operators.AddObject(masterLogClass.ReturnQty(this.game.Data.GameID, this.game.EditObj.RealRound, this.game.EditObj.RealTurn, -1), (object) 1));
                      if (this.game.Data.TerrorMode)
                      {
                        this.loggedin = false;
                        int num7 =  Interaction.MsgBox((object) "Unknown operations done to logfiles by user. Terror Mode aborts opening this turn.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      int regimeCounter = this.game.Data.RegimeCounter;
                      for (int index11 = 0; index11 <= regimeCounter; index11 += 1)
                      {
                        RegimeClass[] regimeObj = this.game.Data.RegimeObj;
                        RegimeClass[] regimeClassArray = regimeObj;
                        int index12 = index11;
                        int index13 = index12;
                        regimeClassArray[index13].MessCounter = regimeObj[index12].MessCounter + 1;
                        int messCounter = this.game.Data.RegimeObj[index11].MessCounter;
                        this.game.Data.RegimeObj[index11].MessString = (string[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index11].MessString, (Array) new string[messCounter + 1]);
                        this.game.Data.RegimeObj[index11].MessBackPic = (int[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index11].MessBackPic, (Array) new int[messCounter + 1]);
                        this.game.Data.RegimeObj[index11].MessFrontPic = (int[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index11].MessFrontPic, (Array) new int[messCounter + 1]);
                        this.game.Data.RegimeObj[index11].MesStyle = (int[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index11].MesStyle, (Array) new int[messCounter + 1]);
                        this.game.Data.RegimeObj[index11].MesNote = (string[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index11].MesNote, (Array) new string[messCounter + 1]);
                        this.game.Data.RegimeObj[index11].MesNote2 = (string[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index11].MesNote2, (Array) new string[messCounter + 1]);
                        this.game.Data.RegimeObj[index11].MessWav = (string[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index11].MessWav, (Array) new string[messCounter + 1]);
                        this.game.Data.RegimeObj[index11].MesGroup = (int[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index11].MesGroup, (Array) new int[messCounter + 1]);
                        this.game.Data.RegimeObj[index11].MesName = (string[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index11].MesName, (Array) new string[messCounter + 1]);
                        this.game.Data.RegimeObj[index11].MesChosen = (int[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index11].MesChosen, (Array) new int[messCounter + 1]);
                        this.game.Data.RegimeObj[index11].MesHideFromStart = (bool[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index11].MesHideFromStart, (Array) new bool[messCounter + 1]);
                        this.game.Data.RegimeObj[index11].MesHideFromTab = (bool[]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index11].MesHideFromTab, (Array) new bool[messCounter + 1]);
                        this.game.Data.RegimeObj[index11].MesStyle[messCounter] = 0;
                        this.game.Data.RegimeObj[index11].MessString[messCounter] = "Possible PBEM cheat\r\n\r\n" + this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Name + " has been making changes to log files. He has been attempting to copy logs. ";
                        this.game.Data.RegimeObj[index11].MessBackPic[messCounter] = -2;
                        this.game.Data.RegimeObj[index11].MessFrontPic[messCounter] = -1;
                      }
                    }
                    this.game.Data.RegimeObj[this.game.EditObj.RealTurn].RandomCode =  Math.Round((double) Conversion.Int(VBMath.Rnd() * 9999f));
                    masterLogClass.SetEntry(this.game.Data.GameID, this.game.EditObj.RealRound, this.game.EditObj.RealTurn, this.game.Data.RegimeObj[this.game.EditObj.RealTurn].RandomCode);
                  }
                  DirectoryInfo directoryInfo1 = (DirectoryInfo) null;
                  if (Directory.Exists(this.game.AppPath + "masterlogdir"))
                    Directory.Delete(this.game.AppPath + "masterlogdir");
                  Directory.CreateDirectory(this.game.AppPath + "masterlogdir");
                  DirectoryInfo directoryInfo2 = new DirectoryInfo(this.game.AppPath + "masterlogdir");
                  masterLogClass.LastSave = directoryInfo2.CreationTime;
                  directoryInfo1 = (DirectoryInfo) null;
                  if (System.IO.File.Exists(str))
                    System.IO.File.Delete(str);
                  masterLogClass.serialize(str);
                  this.game.HandyFunctionsObj.ZipFile(str);
                }
                if (this.SubPartID[index1] == this.login2id)
                {
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                this.EnterTurn();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.EnterTurnId)
              {
                this.game.EditObj.EarlyCinematicsLoggedIn = false;
                this.game.Data.se1_earlyCinematicsLogin = 0;
                if (this.loggedin & (!this.game.Data.PBEM & !this.game.Data.PasswordsOn | this.game.Data.PbemGameID > 0) && this.game.EditObj.Screenshoton)
                {
                  this.game.FormRef.Cursor = Cursors.WaitCursor;
                  this.game.HandyFunctionsObj.doscreenshot("a", 0);
                  this.game.FormRef.Cursor = Cursors.Default;
                }
                if (this.loggedin)
                {
                  this.game.EditObj.pdfGenerated = "";
                  this.game.EventRelatedObj.DoCheckEvents(4);
                  this.Phase = 2;
                  int stringListById1 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Random", 86, 0, 0));
                  int stringListById2 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 156, 0, 0));
                  int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 210, 0, 0));
                  int stringListById4 = this.game.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 292, 0, 0));
                  int id = this.game.Data.RegimeObj[this.game.Data.Turn].id;
                  bool flag1 = false;
                  if (((!Information.IsNothing((object) this.game.EditObj) & !Information.IsNothing((object) this.game.MetricsURL) ? 1 : 0) & 0) != 0 && this.game.EditObj.allowMetrics & this.game.MetricsURL.Length > 4 & (this.game.Data.Round % 20 == 0 | this.game.Data.Winner > -1) && Strings.InStr(this.game.MetricsURL, "http://") > 0 && this.game.Data.Winner == -1 | this.game.Data.LastWinner != this.game.Data.Winner)
                  {
                    this.game.FormRef.Cursor = Cursors.WaitCursor;
                    try
                    {
                      bool flag2 = true;
                      str1: String = "?" + "t2=" + this.game.HandyFunctionsObj.Encrypt(this.game.EditObj.PbemSerial) + "&t3=" + 110.ToString() + "&t4=" + this.game.Data.Name + "&t5=" + this.game.Data.Designer + "&t6=" + this.game.Data.GameID.ToString() + "&t7=" + this.game.Data.Round.ToString() + "&t8=" + this.game.Data.Turn.ToString() + "&t9=" + this.game.Data.Winner.ToString() + "&t10=" + this.game.Data.StringListObj[stringListById3].GetData2(0, id, 1, "victoryScore", 2) + "&t11=" + this.game.Data.StringListObj[stringListById4].GetData3(3, this.game.Data.Round, 1, this.game.Data.Turn, 2, "Population", 4) + "&t12=" + this.game.Data.StringListObj[stringListById4].GetData3(3, this.game.Data.Round, 1, this.game.Data.Turn, 2, "Workers", 4) + "&t13=" + this.game.Data.StringListObj[stringListById4].GetData3(3, this.game.Data.Round, 1, this.game.Data.Turn, 2, "Soldiers", 4) + "&t14=" + this.game.Data.StringListObj[stringListById1].GetData(0, 79, 2);
                      if (Information.IsNothing((object) this.game.Data.Designer))
                        this.game.Data.Designer = "0";
                      str2: String = str1 + "&t15=.04b" + "&t16=" + this.game.Data.StringListObj[stringListById3].GetData2(0, id, 1, "bp", 2) + "&t17=" + this.game.Data.StringListObj[stringListById3].GetData2(0, id, 1, "pp", 2) + "&t18=" + this.game.Data.StringListObj[stringListById3].GetData2(0, id, 1, "credits", 2) + "&t19=" + this.game.Data.StringListObj[stringListById4].GetData3(3, this.game.Data.Round, 1, this.game.Data.Turn, 2, "sizeHex", 4) + "&t20=" + this.game.Data.StringListObj[stringListById2].GetData(0, 42, 2) + "&t21=0";
                      if (flag2)
                      {
                        WebRequest webRequest = WebRequest.Create(this.game.MetricsURL + str2);
                        string end;
                        try
                        {
                          end = new StreamReader(webRequest.GetResponse().GetResponseStream(), Encoding.ASCII).ReadToEnd();
                        }
                        catch (Exception ex)
                        {
                          ProjectData.SetProjectError(ex);
                          this.game.EditObj.allowMetrics = false;
                          flag1 = true;
                          ProjectData.ClearProjectError();
                        }
                        if (Operators.CompareString(end, "CLOSED", false) == 0)
                        {
                          this.game.EditObj.allowMetrics = false;
                          flag1 = true;
                        }
                      }
                    }
                    catch (Exception ex)
                    {
                      ProjectData.SetProjectError(ex);
                      this.game.EditObj.allowMetrics = false;
                      flag1 = true;
                      ProjectData.ClearProjectError();
                    }
                    this.game.FormRef.Cursor = Cursors.Default;
                  }
                  if (flag1)
                    this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                  this.game.Data.LastWinner = this.game.Data.Winner;
                  this.game.EditObj.HumanPlayer = -1;
                  this += 1.game.EditObj.TutStep;
                  this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Version = 110;
                  this.game.Data.RegimeObj[this.game.EditObj.RealTurn].subVersion = ".04b";
                  int messCounter = this.game.Data.RegimeObj[this.game.EditObj.RealTurn].MessCounter;
                  for (int index14 = 0; index14 <= messCounter; index14 += 1)
                  {
                    if (!this.game.Data.RegimeObj[this.game.EditObj.RealTurn].MesHideFromStart[index14])
                      ;
                  }
                  this.game.Data.InTurn = true;
                  if (Strings.Len(this.game.Data.LoadGame) > 0)
                  {
                    this.game.FormRef.Cursor = Cursors.WaitCursor;
                    this.game.HandyFunctionsObj.LoadGameNow();
                    this.game.FormRef.Cursor = Cursors.Default;
                    windowReturnClass.AddCommand(3, 13);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  this.game.ProcessingObj.LocationProductionPrognosis();
                  this.game.HandyFunctionsObj.SetInitialXY(this.game.EditObj.RealTurn);
                  bool flag3 = false;
                  if ((double) this.game.Data.RuleVar[971] > 0.0)
                  {
                    int stringListById5 = this.game.HandyFunctionsObj.GetStringListByID( Math.Round((double) this.game.Data.RuleVar[971]));
                    if (stringListById5 > -1 && this.game.Data.StringListObj[stringListById5].Length > -1)
                      flag3 = true;
                  }
                  this.FixMiniMaps();
                  if (flag3)
                    windowReturnClass.AddCommand(3, 22);
                  else
                    windowReturnClass.AddCommand(3, 11);
                  windowReturnClass.SetFlag(true);
                }
                return windowReturnClass;
              }
              if (num1 == this.okid)
              {
                this.game.Data.InTurn = true;
                if (Strings.Len(this.game.Data.LoadGame) > 0)
                {
                  this.game.FormRef.Cursor = Cursors.WaitCursor;
                  this.game.HandyFunctionsObj.LoadGameNow();
                  this.game.FormRef.Cursor = Cursors.Default;
                  windowReturnClass.AddCommand(3, 13);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                this.game.HandyFunctionsObj.SetInitialXY(this.game.EditObj.RealTurn);
                this.game.ProcessingObj.LocationProductionPrognosis();
                bool flag = false;
                if ((double) this.game.Data.RuleVar[971] > 0.0)
                {
                  int stringListById = this.game.HandyFunctionsObj.GetStringListByID( Math.Round((double) this.game.Data.RuleVar[971]));
                  if (stringListById > -1 && this.game.Data.StringListObj[stringListById].Length > -1)
                    flag = true;
                }
                this.FixMiniMaps();
                if (flag)
                  windowReturnClass.AddCommand(3, 22);
                else
                  windowReturnClass.AddCommand(3, 11);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.SaveId)
              {
                str: String = this.game.HandyFunctionsObj.SaveSomething("SE1 Scenario file (*.se1)|*.se1", "Give save name...", this.game.AppPath_SAVEGAMES, false);
                if (Strings.Len(str) < 2)
                {
                  int num8 =  Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                else
                {
                  this.game.Data.serialize(str);
                  this.game.HandyFunctionsObj.ZipFile(str);
                  this.saved = true;
                  this.game.Data = DataClass::new();
                  this.game.EditObj.ShowInitialMenu = true;
                  windowReturnClass.AddCommand(3, 1);
                  windowReturnClass.SetFlag(true);
                }
                return windowReturnClass;
              }
            }
            return windowReturnClass;
          }
        }
        windowReturnClass.SetFlag(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    pub void FixMiniMaps()
    {
      if (this.game.Data.RegimeObj[this.game.EditObj.RealTurn].AI)
        return;
      if (!Information.IsNothing((object) this.game.EditObj.MiniMap))
      {
        this.game.EditObj.MiniMap.Dispose();
        this.game.EditObj.MiniMap = (Bitmap) null;
      }
      this.game.EditObj.MiniMap = new Bitmap(205, 110, PixelFormat.Format32bppPArgb);
      this.game.EditObj.MiniMap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, 205, 110, false);
      if (!Information.IsNothing((object) this.game.EditObj.StratMap))
      {
        this.game.EditObj.StratMap.Dispose();
        this.game.EditObj.StratMap = (Bitmap) null;
      }
      this.game.EditObj.StratMap = new Bitmap(this.game.ScreenWidth, this.game.ScreenHeight - 305, PixelFormat.Format32bppPArgb);
      this.game.EditObj.StratMap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.StratMap, this.game.ScreenWidth, this.game.ScreenHeight - 305, false, true, false);
    }

    pub AnyShoweableMessagesLeft: bool()
    {
      int num = this.PhaseData + 1;
      int messCounter = this.game.Data.RegimeObj[this.game.EditObj.RealTurn].MessCounter;
      for (int index = num; index <= messCounter; index += 1)
      {
        if (!this.game.Data.RegimeObj[this.game.EditObj.RealTurn].MesHideFromStart[index])
          return true;
      }
      return false;
    }

    pub void DoPresentStats()
    {
      int regimeCounter = this.game.Data.RegimeCounter;
      for (int index1 = 0; index1 <= regimeCounter; index1 += 1)
      {
        this.game.Data.RegimeObj[index1].SPresent = (int[,]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index1].SPresent, (Array) new int[this.game.Data.SFTypeCounter + 1, this.game.EditObj.RealRound + 1 + 1]);
        int sfTypeCounter = this.game.Data.SFTypeCounter;
        for (int index2 = 0; index2 <= sfTypeCounter; index2 += 1)
        {
          this.game.Data.RegimeObj[index1].SPresent[index2, 0] = 0;
          this.game.Data.RegimeObj[index1].SPresent[index2, this.game.EditObj.RealRound] = 0;
        }
      }
      int unitCounter = this.game.Data.UnitCounter;
      for (int index3 = 0; index3 <= unitCounter; index3 += 1)
      {
        if (this.game.Data.UnitObj[index3].PreDef == -1)
        {
          int regime = this.game.Data.UnitObj[index3].Regime;
          int sfCount = this.game.Data.UnitObj[index3].SFCount;
          for (int index4 = 0; index4 <= sfCount; index4 += 1)
          {
            int sf = this.game.Data.UnitObj[index3].SFList[index4];
            int[,] spresent = this.game.Data.RegimeObj[regime].SPresent;
            int[,] numArray = spresent;
            int type = this.game.Data.SFObj[sf].Type;
            int index5 = type;
            int realRound = this.game.EditObj.RealRound;
            int index6 = realRound;
            int num = spresent[type, realRound] + this.game.Data.SFObj[sf].Qty;
            numArray[index5, index6] = num;
          }
        }
      }
    }

    pub void HandleToolTip(int x, int y)
    {
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; index += 1)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            this.game.EditObj.TipButton = false;
            this.SubPartList[index].HandleToolTip(x - this.SubPartX[index], y - this.SubPartY[index]);
            if (this.game.EditObj.TipButton)
              return;
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
      for (int index = 0; index <= mouseCounter; index += 1)
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
  }
}
