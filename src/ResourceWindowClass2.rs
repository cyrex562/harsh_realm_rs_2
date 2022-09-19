// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ResourceWindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

// usingMicrosoft.VisualBasic;
// usingMicrosoft.VisualBasic.CompilerServices;
// usingSystem;
// usingSystem.Drawing;
// usingSystem.Threading;
// usingSystem.Windows.Forms;

namespace WindowsApplication1
{
  pub class ResourceWindowClass2 : WindowClass
  {
     int Info1Id;
     int info2id;
     string ShowString;
     DateTime ShowTime;
     int w;
     int h;
     bool AskingAboutMetrics;
     int CurrentView;
     int tab1;
     int tab2;
     int tab3;
     int tab4;
     int tab5;
     int tab6;
     int tab7;
     int tab8;
     int tab9;
     int tab1a;
     int tab2a;
     int tab3a;
     int tab4a;
     int tab5a;
     int tab6a;
     int tab7a;
     int tab8a;
     int tab9a;
     int tab13;
     int tab11;
     int tab12;
     string tab13name;
     string tab11name;
     string tab12name;
     int butNextTurnId;
     int butNextTurnId2;
     int butHistoryId;
     int butPlayId;
     int currentPlayerId;
     int cinButId;
     int MouseOverWhichTab;
     int smallAiProgress;
     int prevAiProgress;
     bool startedInHistoryMode;
     bool surrendering;
     int special1;
     int special2;
     int special3;
     int advice;
     int adviceB;
     int screenHis;
     int screenVid;
     int screenMan;
     int screenMap;

    pub ResourceWindowClass2(
       GameClass tGame,
       WindowClass tLowerWindow,
       Rectangle tLowerRect)
      : base( tGame, tGame.ScreenWidth, 75, 8)
    {
      this.NewGfx = true;
      this.w = tGame.ScreenWidth;
      this.h = 75;
      this.LowerWindow = tLowerWindow;
      this.LowerRect = tLowerRect;
      this.CurrentView = 0;
      this.startedInHistoryMode = false;
      if (this.game.EditObj.OrderType == 26)
        this.startedInHistoryMode = true;
      if (!this.game.EditObj.AIMoving)
      {
        this.game.EditObj.RealRound = this.game.Data.Round;
        this.game.EditObj.RealTurn = this.game.Data.Turn;
      }
      if (!this.game.AIRunning & !this.game.EditObj.AIMoving & this.game.EditObj.OrderType != 26 && !this.game.EditObj.helpAlreadyOpened & this.game.EditObj.RealRound == 1)
      {
        this.game.EditObj.helpAlreadyOpened = true;
        this.CurrentView = 11;
        this.game.EditObj.SetViewMode2 = 11;
        this.game.EditObj.rightSideBarMode = 2;
        this.game.EditObj.leftSideBarMode = 2;
      }
      this.tab11name = this.game.HandyFunctionsObj.GetUDSmanagementTabName(1);
      this.tab12name = this.game.HandyFunctionsObj.GetUDSmanagementTabName(2);
      this.tab13name = this.game.HandyFunctionsObj.GetUDSmanagementTabName(3);
      if (this.game.EditObj.se1_ManagementTab < 1)
        this.game.EditObj.se1_ManagementTab = 54;
      this.ShowTime = DateAndTime.Now;
      this.dostuff();
    }

    pub handleTimer: WindowReturnClass()
    {
      windowReturnClass1: WindowReturnClass = WindowReturnClass::new();
      if (this.game.EditObj.HumanPlayer > -1 && this.game.EditObj.AIMoving &&  DateAndTime.Now.Subtract(this.ShowTime).Ticks > 2000000.0)
      {
        this.ShowTime = DateAndTime.Now;
        this.dostuff();
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (this.game.EditObj.udsManagementTabOverrideId > 0)
      {
        let mut mouseCounter: i32 = this.MouseCounter;
        for (let mut index: i32 = 0; index <= mouseCounter; index += 1)
        {
          if (this.MouseData[index] == this.game.EditObj.SetViewMode2)
          {
            this.game.EditObj.SetViewMode2 = 0;
            windowReturnClass2: WindowReturnClass = this.HandleMouseClick(this.MouseRect[index].X + 1, this.MouseRect[index].Y + 1, 1);
            windowReturnClass2.SetFlag(true);
            return windowReturnClass2;
          }
        }
      }
      if (this.game.EditObj.udsViewMode2Override > 0)
      {
        if (this.game.EditObj.SetViewMode2 != this.game.EditObj.udsViewMode2Override)
        {
          let mut mouseCounter: i32 = this.MouseCounter;
          for (let mut index: i32 = 0; index <= mouseCounter; index += 1)
          {
            if (this.MouseData[index] == this.game.EditObj.udsViewMode2Override)
            {
              this.game.EditObj.udsViewMode2Override = -1;
              windowReturnClass3: WindowReturnClass = this.HandleMouseClick(this.MouseRect[index].X + 1, this.MouseRect[index].Y + 1, 1);
              windowReturnClass3.SetFlag(true);
              return windowReturnClass3;
            }
          }
          this.game.EditObj.udsViewMode2Override = -1;
        }
        else
        {
          this.game.EditObj.udsViewMode2Override = -1;
          windowReturnClass1.AddCommand(4, 9);
          windowReturnClass1.SetFlag(true);
          return windowReturnClass1;
        }
      }
      if (this.MouseOverWhichTab > 0 && !this.MouseInThisWindow)
      {
        this.MouseOverWhichTab = 0;
        this.dostuff();
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (!this.game.EditObj.askedMetricsPermission & !this.game.EditObj.allowMetrics & !this.AskingAboutMetrics & this.game.Data.Round >= 2)
      {
        ScreenClass screeny = this.game.FormRef.Screeny;
        System.Type type = typeof (PlayExtraWindowClass2);
         System.Type local =  type;
        if (screeny.WindowPresent( local))
        {
          str: String = "Collecting metrics data on your gameplay really helps with fine-tuning the game.\r\nWill you allow this game to share some metrics data with the developers?";
          this.game.EditObj.PopupValue = 10;
          this.game.EditObj.QuestionText = str;
          this.game.EditObj.AnswerCount = 2;
          this.game.EditObj.AnswerText[1] = "Sure!";
          this.game.EditObj.AnswerTextMouseOver[1] = "This means that now and then the game will use your internet connection to send some minimal quantities (1K or less) of game statistics to our server. You will always remain anonymous. Data is used to improve game balance and provide feedback to the community. ";
          this.game.EditObj.AnswerText[2] = "No thanks";
          this.game.EditObj.AnswerTextMouseOver[2] = "This means the game will not attempt to send any metrics data to the developers.";
          this.AskingAboutMetrics = true;
          windowReturnClass1.AddCommand(5, 10);
          this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
          windowReturnClass1.SetFlag(true);
          return windowReturnClass1;
        }
      }
      return windowReturnClass1;
    }

    pub HandleMouseMove: WindowReturnClass(int x, int y)
    {
      windowReturnClass: WindowReturnClass = base.HandleMouseMove(x, y);
      if (y < 60 && x > 100 & x < this.game.ScreenWidth - 175)
        windowReturnClass.NoMouseClickBelow = true;
      let mut num: i32 = -1;
      for (let mut mouseCounter: i32 = this.MouseCounter; mouseCounter >= 0; mouseCounter += -1)
      {
        if (this.MouseData[mouseCounter] > 0 && x > this.MouseRect[mouseCounter].X & x < this.MouseRect[mouseCounter].X + this.MouseRect[mouseCounter].Width && y > this.MouseRect[mouseCounter].Y & y < this.MouseRect[mouseCounter].Y + this.MouseRect[mouseCounter].Height)
          num = this.MouseData[mouseCounter];
      }
      if (num > 0)
      {
        if (this.MouseOverWhichTab != num)
        {
          if (this.game.EmpireStyle)
            SoundMod.PlayAWave(this.game.AppPath + "sound/interface/mouseover.wav",  this.game.EditObj);
          this.MouseOverWhichTab = num;
          this.dostuff();
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      else if (this.MouseOverWhichTab > 0)
      {
        this.MouseOverWhichTab = -1;
        this.dostuff();
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      return windowReturnClass;
    }

    pub void DoRefresh()
    {
      if (this.cinButId > 0)
      {
        this.RemoveSubPart(this.cinButId);
        this.cinButId = 0;
      }
      if (this.butHistoryId > 0)
      {
        this.RemoveSubPart(this.butHistoryId);
        this.butHistoryId = 0;
      }
      if (this.butPlayId > 0)
      {
        this.RemoveSubPart(this.butPlayId);
        this.butPlayId = 0;
      }
      if (this.butNextTurnId > 0)
      {
        this.RemoveSubPart(this.butNextTurnId);
        this.butNextTurnId = 0;
      }
      if (this.butNextTurnId2 > 0)
      {
        this.RemoveSubPart(this.butNextTurnId2);
        this.butNextTurnId2 = 0;
      }
      if (this.currentPlayerId > 0)
      {
        this.RemoveSubPart(this.currentPlayerId);
        this.currentPlayerId = 0;
      }
      this.dostuff();
    }

    pub void dostuff()
    {
      this.game.Data.DontShowAIMove = this.game.EditObj.dontShowAImoves;
      if (this.butNextTurnId > 0)
      {
        this.RemoveSubPart(this.butNextTurnId);
        this.butNextTurnId = 0;
      }
      if (this.butNextTurnId2 > 0)
      {
        this.RemoveSubPart(this.butNextTurnId2);
        this.butNextTurnId2 = 0;
      }
      if (this.special1 > 0)
      {
        this.RemoveSubPart(this.special1);
        this.special1 = 0;
      }
      if (this.special2 > 0)
      {
        this.RemoveSubPart(this.special2);
        this.special2 = 0;
      }
      if (this.special3 > 0)
      {
        this.RemoveSubPart(this.special3);
        this.special3 = 0;
      }
      if (this.advice > 0)
      {
        this.RemoveSubPart(this.advice);
        this.advice = 0;
      }
      if (this.adviceB > 0)
      {
        this.RemoveSubPart(this.adviceB);
        this.adviceB = 0;
      }
      if (!(!this.game.AIRunning & !this.game.EditObj.AIMoving & this.game.EditObj.OrderType != 26) && this.game.EditObj.SetViewMode2 != 7)
        this.game.EditObj.SetViewMode2 = 0;
      this.CurrentView = this.game.EditObj.SetViewMode2;
      this.ClearMouse();
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      if (!this.game.EditObj.se1_ManagementMode)
        this.DrawOpenTab( graphics);
      let mut tx1: i32 = 312;
      bool flag1 = false;
      int width;
      if ( this.game.Data.RuleVar[971] > 0.0)
      {
        let mut stringListById: i32 = this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[971]));
        if (stringListById > -1 && this.game.Data.StringListObj[stringListById].Length > -1)
          flag1 = true;
        width = 100;
        if (!flag1)
          ;
      }
      bool flag2 = false;
      let mut num1: i32 = 68;
      if (this.game.ScreenWidth <= 1320)
      {
        tx1 -= 10;
        num1 = 58;
      }
      this.screenHis = -1;
      this.screenMan = -1;
      this.screenVid = -1;
      this.screenMap = -1;
      int num2;
      if (this.game.se1Running | this.game.se1ThreadRunning | this.game.se1Running & !this.game.se1ThreadRunning & this.game.EditObj.AIMoving)
      {
        flag2 = true;
        Rectangle trect1 = this.DrawOneTab(graphics, false, tx1, "MAP", -1, grayedOut: true) with
        {
          Y = 36
        };
        trect1.Height -= 36;
        this.AddMouse( trect1, "", "Inaccesible during the AIs turn.");
        let mut tx2: i32 = tx1 + num1;
        Rectangle trect2 = this.DrawOneTab(graphics, true, tx2, "HIS", -1) with
        {
          Y = 36
        };
        trect2.Height -= 36;
        this.AddMouse( trect2, "", "You are currently in HISTORY mode. While the AI is playing.");
        let mut tx3: i32 = tx2 + num1;
        trect2 = this.DrawOneTab(graphics, false, tx3, "VID", -1, grayedOut: true) with
        {
          Y = 36
        };
        trect2.Height -= 36;
        this.AddMouse( trect2, "", "Inaccesible during the AIs turn.");
        let mut tx4: i32 = tx3 + num1;
        trect2 = this.DrawOneTab(graphics, false, tx4, "MNG", -1, grayedOut: true) with
        {
          Y = 36
        };
        trect2.Height -= 36;
        this.AddMouse( trect2, "", "Inaccesible during the AIs turn.");
      }
      else if ( this.game.Data.RuleVar[408] > 1.0)
      {
        if (this.game.EditObj.OrderType == 26 | this.startedInHistoryMode)
        {
          Rectangle trect = this.DrawOneTab(graphics, false, tx1, "MAP", -1, MousingOverNow: (this.MouseOverWhichTab == 2001)) with
          {
            Y = 36
          };
          trect.Height -= 36;
          this.AddMouse( trect, "", "Click to got to MAP mode [Shortkey Escape]", 2001);
          this.screenMap = this.MouseCounter;
          let mut tx5: i32 = tx1 + num1;
          trect = this.DrawOneTab(graphics, true, tx5, "HIS", -1, MousingOverNow: (this.MouseOverWhichTab == 2002)) with
          {
            Y = 36
          };
          trect.Height -= 36;
          this.AddMouse( trect, "", "You are currently in HISTORY mode", 2002);
          let mut tx6: i32 = tx5 + num1;
          int tx7;
          if (flag1)
          {
            trect = this.DrawOneTab(graphics, false, tx6, "VID", -1, MousingOverNow: (this.MouseOverWhichTab == 2003)) with
            {
              Y = 36
            };
            trect.Height -= 36;
            this.AddMouse( trect, "", "Click to go to VIDCOM mode [Shortkey V]", 2003);
            this.screenVid = this.MouseCounter;
            tx7 = tx6 + num1;
          }
          else
          {
            trect = this.DrawOneTab(graphics, false, tx6, "VID", -1) with
            {
              Y = 36
            };
            trect.Height -= 36;
            this.AddMouse( trect, "", "There are no VIDCOM messages or reports available");
            tx7 = tx6 + num1;
          }
          trect = this.DrawOneTab(graphics, false, tx7, "MNG", -1, MousingOverNow: (this.MouseOverWhichTab == 2004)) with
          {
            Y = 36
          };
          trect.Height -= 36;
          this.AddMouse( trect, "", "Go to MANAGEMENT SCREEN mode  [Shortkey N]", 2004);
          this.screenMan = this.MouseCounter;
          num2 = tx7 + num1;
        }
        else
        {
          Rectangle trect;
          int tx8;
          if (this.game.EditObj.se1_ManagementMode)
          {
            trect = this.DrawOneTab(graphics, false, tx1, "MAP", -1, MousingOverNow: (this.MouseOverWhichTab == 2001)) with
            {
              Y = 36
            };
            trect.Height -= 36;
            this.AddMouse( trect, "", "Click to got to MAP mode [Shortkey Escape]", 2001);
            this.screenMap = this.MouseCounter;
            tx8 = tx1 + num1;
          }
          else
          {
            trect = this.DrawOneTab(graphics, true, tx1, "MAP", -1) with
            {
              Y = 36
            };
            trect.Height -= 36;
            this.AddMouse( trect, "", "You are currently in MAP mode");
            tx8 = tx1 + num1;
          }
          trect = this.DrawOneTab(graphics, false, tx8, "HIS", -1, MousingOverNow: (this.MouseOverWhichTab == 2002)) with
          {
            Y = 36
          };
          trect.Height -= 36;
          this.AddMouse( trect, "", "Click to go to HISTORY mode [Shortkey H]", 2002);
          this.screenHis = this.MouseCounter;
          let mut tx9: i32 = tx8 + num1;
          int tx10;
          if (flag1)
          {
            trect = this.DrawOneTab(graphics, false, tx9, "VID", -1, MousingOverNow: (this.MouseOverWhichTab == 2003)) with
            {
              Y = 36
            };
            trect.Height -= 36;
            this.AddMouse( trect, "", "Click to go to VIDCOM mode [Shortkey V]", 2003);
            this.screenVid = this.MouseCounter;
            tx10 = tx9 + num1;
          }
          else
          {
            trect = this.DrawOneTab(graphics, false, tx9, "VID", -1) with
            {
              Y = 36
            };
            trect.Height -= 36;
            this.AddMouse( trect, "", "There are no VIDCOM messages or reports available");
            tx10 = tx9 + num1;
          }
          if (this.game.EditObj.se1_ManagementMode)
          {
            trect = this.DrawOneTab(graphics, true, tx10, "MNG", -1) with
            {
              Y = 36
            };
            trect.Height -= 36;
            this.AddMouse( trect, "", "You are currently in MANAGEMENT SCREEN mode");
            num2 = tx10 + num1;
          }
          else
          {
            trect = this.DrawOneTab(graphics, false, tx10, "MNG", -1, MousingOverNow: (this.MouseOverWhichTab == 2004)) with
            {
              Y = 36
            };
            trect.Height -= 36;
            this.AddMouse( trect, "", "Go to MANAGEMENT SCREEN mode [Shortkey N]", 2004);
            this.screenMan = this.MouseCounter;
            num2 = tx10 + num1;
          }
        }
      }
       let mut local1: &Graphics = &graphics;
      Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
       let mut local2: &Bitmap = &bitmap;
      Rectangle trect3 = Rectangle::new(0, 140, 300, 63);
      let mut srcrect1: &Rectangle = &trect3
      Rectangle rectangle = Rectangle::new(0, 0, 300, 63);
      let mut destrect1: &Rectangle = &rectangle
      DrawMod.DrawSimplePart2( local1,  local2, srcrect1, destrect1);
      if (this.game.ScreenWidth > 2600)
      {
        width =  Math.Round( this.game.ScreenWidth / 2.0);
         let mut local3: &Graphics = &graphics;
        bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
         let mut local4: &Bitmap = &bitmap;
        rectangle = Rectangle::new(300, 140, width, 32);
        let mut srcrect2: &Rectangle = &rectangle
        trect3 = Rectangle::new(300, 0, width, 32);
        let mut destrect2: &Rectangle = &trect3
        DrawMod.DrawSimplePart2( local3,  local4, srcrect2, destrect2);
         let mut local5: &Graphics = &graphics;
        bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
         let mut local6: &Bitmap = &bitmap;
        rectangle = Rectangle::new(0, 140, width, 32);
        let mut srcrect3: &Rectangle = &rectangle
        trect3 = Rectangle::new(300 + width, 0, width, 32);
        let mut destrect3: &Rectangle = &trect3
        DrawMod.DrawSimplePart2( local5,  local6, srcrect3, destrect3);
        if (!flag2)
        {
           let mut local7: &Graphics = &graphics;
          bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
           let mut local8: &Bitmap = &bitmap;
          rectangle = Rectangle::new(this.w - width - 150, 140, 150, 75);
          let mut srcrect4: &Rectangle = &rectangle
          trect3 = Rectangle::new(this.w - 150, 0, 150, 75);
          let mut destrect4: &Rectangle = &trect3
          DrawMod.DrawSimplePart2( local7,  local8, srcrect4, destrect4);
        }
        if (flag2)
        {
           let mut local9: &Graphics = &graphics;
          bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
           let mut local10: &Bitmap = &bitmap;
          rectangle = Rectangle::new(this.w - width - 150, 140, 150, 32);
          let mut srcrect5: &Rectangle = &rectangle
          trect3 = Rectangle::new(this.w - 150, 0, 150, 32);
          let mut destrect5: &Rectangle = &trect3
          DrawMod.DrawSimplePart2( local9,  local10, srcrect5, destrect5);
        }
      }
      else
      {
         let mut local11: &Graphics = &graphics;
        bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
         let mut local12: &Bitmap = &bitmap;
        rectangle = Rectangle::new(300, 140, this.w - 440, 32);
        let mut srcrect6: &Rectangle = &rectangle
        trect3 = Rectangle::new(300, 0, this.w - 440, 32);
        let mut destrect6: &Rectangle = &trect3
        DrawMod.DrawSimplePart2( local11,  local12, srcrect6, destrect6);
        if (!flag2)
        {
           let mut local13: &Graphics = &graphics;
          bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
           let mut local14: &Bitmap = &bitmap;
          rectangle = Rectangle::new(this.w - 150, 140, 150, 75);
          let mut srcrect7: &Rectangle = &rectangle
          trect3 = Rectangle::new(this.w - 150, 0, 150, 75);
          let mut destrect7: &Rectangle = &trect3
          DrawMod.DrawSimplePart2( local13,  local14, srcrect7, destrect7);
        }
        if (flag2)
        {
           let mut local15: &Graphics = &graphics;
          bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
           let mut local16: &Bitmap = &bitmap;
          rectangle = Rectangle::new(this.w - width - 150, 140, 150, 32);
          let mut srcrect8: &Rectangle = &rectangle
          trect3 = Rectangle::new(this.w - 150, 0, 150, 32);
          let mut destrect8: &Rectangle = &trect3
          DrawMod.DrawSimplePart2( local15,  local16, srcrect8, destrect8);
        }
      }
      let mut x1: i32 = 290;
      if (flag2)
      {
        for (; x1 < this.game.ScreenWidth; x1 += 50)
        {
           let mut local17: &Graphics = &graphics;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_BOTTOM);
           let mut local18: &Bitmap = &bitmap;
          rectangle = Rectangle::new(15, 22, 50, 20);
          let mut srcrect9: &Rectangle = &rectangle
          trect3 = Rectangle::new(x1, 22, 50, 20);
          let mut destrect9: &Rectangle = &trect3
          DrawMod.DrawSimplePart2( local17,  local18, srcrect9, destrect9);
        }
      }
      else
      {
        for (; x1 < this.game.ScreenWidth - 120; x1 += 50)
        {
           let mut local19: &Graphics = &graphics;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_BOTTOM);
           let mut local20: &Bitmap = &bitmap;
          rectangle = Rectangle::new(15, 22, 50, 20);
          let mut srcrect10: &Rectangle = &rectangle
          trect3 = Rectangle::new(x1, 22, 50, 20);
          let mut destrect10: &Rectangle = &trect3
          DrawMod.DrawSimplePart2( local19,  local20, srcrect10, destrect10);
        }
         let mut local21: &Graphics = &graphics;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_BOTTOM);
         let mut local22: &Bitmap = &bitmap;
        rectangle = Rectangle::new(0, 22, 15, 20);
        let mut srcrect11: &Rectangle = &rectangle
        trect3 = Rectangle::new(300, 22, 15, 20);
        let mut destrect11: &Rectangle = &trect3
        DrawMod.DrawSimplePart2( local21,  local22, srcrect11, destrect11);
         let mut local23: &Graphics = &graphics;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_BOTTOM);
         let mut local24: &Bitmap = &bitmap;
        rectangle = Rectangle::new(65, 22, 15, 20);
        let mut srcrect12: &Rectangle = &rectangle
        trect3 = Rectangle::new(this.w - 187 - 15, 22, 15, 20);
        let mut destrect12: &Rectangle = &trect3
        DrawMod.DrawSimplePart2( local23,  local24, srcrect12, destrect12);
      }
      if (this.game.EditObj.se1_ManagementMode)
        this.DrawTabs_ManagementScreen( graphics);
      else
        this.DrawTabs( graphics);
       let mut local25: &Graphics = &graphics;
      bitmap = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_LEFT);
       let mut local26: &Bitmap = &bitmap;
      DrawMod.DrawSimple( local25,  local26, 0, 0);
      bool flag3 = true;
      if ( Math.Round(Conversion.Val(this.game.Data.Designer)) >= 43)
      {
        let mut stringListById1: i32 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Present", 79, 0, 0));
        let mut stringListById2: i32 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 191, 0, 0));
        if (this.game.Data.StringListObj[stringListById2].Width >= 27)
        {
          for (let mut length: i32 = this.game.Data.StringListObj[stringListById1].Length; length >= 0; length += -1)
          {
            let mut idValue: i32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[length, 11]));
            width =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, idValue, 27)));
            if (width > 0)
              flag3 = false;
          }
        }
      }
      if (!flag2)
      {
         let mut local27: &Graphics = &graphics;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_RIGHT);
         let mut local28: &Bitmap = &bitmap;
        let mut x2: i32 = this.w - 190;
        DrawMod.DrawSimple( local27,  local28, x2, 0);
        if (flag3)
        {
          if (this.butNextTurnId == 0)
          {
            let mut tsubpart: SubPartClass =  new SEButtonPartClass(this.game.SE1_ARROW1, "End your turn. Let the other players make their moves.", 54, 39);
            this.butNextTurnId = this.AddSubPart( tsubpart, this.w - 190 + 126, 9, 54, 39, 1);
          }
        }
        else if (this.butNextTurnId2 == 0)
        {
          let mut tsubpart: SubPartClass =  new SEButtonPartClass(this.game.CANCELBALL, "You cannot end your move as there is still a Decision left that is OBLIGATORY to make.", 54, 39);
          this.butNextTurnId2 = this.AddSubPart( tsubpart, this.w - 190 + 126, 9, 54, 39, 1);
        }
      }
      if (!flag2)
      {
        this.DrawDate( graphics);
        this.DrawPP( graphics);
      }
      let mut index: i32 = this.game.EditObj.RealTurn;
      bool flag4 = false;
      if (this.game.EditObj.RealTurn == -1)
        width = width;
      if (this.game.EditObj.RealTurn > this.game.Data.RegimeCounter)
        ;
      if (flag2 && this.game.EditObj.RealTurn > -1 & this.game.EditObj.RealTurn != this.game.Data.Turn & this.game.Data.Turn > -1)
      {
        let mut stringListById: i32 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 275, 0, 0));
        try
        {
          if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData3(0, this.game.Data.RegimeObj[this.game.EditObj.RealTurn].id, 1, this.game.Data.RegimeObj[this.game.Data.Turn].id, 2, "recon", 3))) > 0)
          {
            index = this.game.Data.Turn;
          }
          else
          {
            index = this.game.EditObj.RealTurn;
            if (index != this.game.Data.Turn)
              flag4 = true;
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          index = this.game.EditObj.RealTurn;
          flag4 = true;
          ProjectData.ClearProjectError();
        }
      }
      str: String = this.game.Data.RegimeObj[index].Name;
      if (flag4)
        str = "Unknown Regime";
      graphics.MeasureString(str, DrawMod.TGame.MarcFont16);
      if (flag2)
      {
        this.smallAiProgress += 5;
        if (this.game.EditObj.AIProgressNow != this.prevAiProgress)
          this.smallAiProgress = 0;
        this.prevAiProgress = this.game.EditObj.AIProgressNow;
        let mut num3: i32 =  Math.Round( this.game.EditObj.AIProgressNow /  this.game.EditObj.AIProgressMax * 100.0);
        if (num3 > 100)
          num3 = 100;
        let mut num4: i32 =  Math.Round( (84 * num3) / 100.0);
        let mut num5: i32 = this.smallAiProgress;
        if (num5 > 50)
          num5 =  Math.Round(Math.Sqrt( (num5 - 50))) + 50;
        if (num5 > 70)
          num5 =  Math.Round(Math.Sqrt( (num5 - 70))) + 70;
        if (num5 > 90)
          num5 =  Math.Round(Math.Sqrt( (num5 - 70))) + 90;
        if (num5 > 100)
          num5 = 100;
        let mut w: i32 = num4 +  Math.Round( (83 * num5) / 100.0);
        DrawMod.DrawBlock( graphics, 111, 18, w, 16, 200, 0, 0, 150);
      }
      DrawMod.DrawTextColouredConsoleCenter( graphics, str, this.game.MarcFont16, 193, 15, this.game.seColWhite);
      if (this.currentPlayerId < 1)
      {
        if (flag2)
        {
          rectangle = Rectangle::new(108, 15, 173, 21);
          trect3 = rectangle;
          this.AddMouse( trect3, "Current player is " + this.game.Data.RegimeObj[index].Name, "This AI is currently making its moves.");
        }
        else if (this.game.EditObj.se1_ManagementMode)
        {
          rectangle = Rectangle::new(108, 15, 173, 21);
          trect3 = rectangle;
          this.AddMouse( trect3, "Current player is " + this.game.Data.RegimeObj[index].Name, "Yes, this is you.");
        }
        else
        {
          rectangle = Rectangle::new(108, 15, 173, 21);
          trect3 = rectangle;
          this.AddMouse( trect3, "Current player is " + this.game.Data.RegimeObj[index].Name, "Click to go to capitol of this regime.", 501);
        }
      }
      let mut num6: i32 = this.game.Data.RegimeObj[index].Red;
      let mut num7: i32 = this.game.Data.RegimeObj[index].Green;
      let mut num8: i32 = this.game.Data.RegimeObj[index].Blue;
      let mut num9: i32 = this.game.Data.RegimeObj[index].Red2;
      let mut num10: i32 = this.game.Data.RegimeObj[index].Green2;
      let mut num11: i32 = this.game.Data.RegimeObj[index].Blue2;
      if (this.MouseOverWhichTab == 501)
      {
        num6 =  Math.Round( num6 * 1.1);
        num7 =  Math.Round( num7 * 1.1);
        num8 =  Math.Round( num8 * 1.1);
        num9 =  Math.Round( num9 * 1.1);
        num10 =  Math.Round( num10 * 1.1);
        num11 =  Math.Round( num11 * 1.1);
        if (num6 >  byte.MaxValue)
          num6 =  byte.MaxValue;
        if (num7 >  byte.MaxValue)
          num7 =  byte.MaxValue;
        if (num8 >  byte.MaxValue)
          num8 =  byte.MaxValue;
        if (num9 >  byte.MaxValue)
          num9 =  byte.MaxValue;
        if (num10 >  byte.MaxValue)
          num10 =  byte.MaxValue;
        if (num11 >  byte.MaxValue)
          num11 =  byte.MaxValue;
      }
      if (flag4)
      {
        num6 =  Math.Round( num6 / 2.0);
        num7 =  Math.Round( num7 / 2.0);
        num8 =  Math.Round( num8 / 2.0);
        num9 =  Math.Round( num9 / 2.0);
        num10 =  Math.Round( num10 / 2.0);
        num11 =  Math.Round( num11 / 2.0);
      }
      let mut bannerSpriteNr: i32 = this.game.Data.RegimeObj[index].BannerSpriteNr;
       let mut local29: &Graphics = &graphics;
      bitmap = BitmapStore.GetBitmap(bannerSpriteNr);
       let mut local30: &Bitmap = &bitmap;
      double r1 =  ( num6 /  byte.MaxValue);
      double g1 =  ( num7 /  byte.MaxValue);
      double b1 =  ( num8 /  byte.MaxValue);
      DrawMod.DrawScaledColorized2( local29,  local30, 13, 15, 80, 60, 124, 210,  r1,  g1,  b1, 1f);
      let mut bannerSpriteNr2: i32 = this.game.Data.RegimeObj[index].BannerSpriteNr2;
      if (bannerSpriteNr2 > 0)
      {
         let mut local31: &Graphics = &graphics;
        bitmap = BitmapStore.GetBitmap(bannerSpriteNr2);
         let mut local32: &Bitmap = &bitmap;
        double r2 =  ( num9 /  byte.MaxValue);
        double g2 =  ( num10 /  byte.MaxValue);
        double b2 =  ( num11 /  byte.MaxValue);
        DrawMod.DrawScaledColorized2( local31,  local32, 13, 15, 80, 60, 124, 210,  r2,  g2,  b2, 1f);
      }
      let mut hqSpriteNr2: i32 = this.game.Data.RegimeObj[index].HQSpriteNr2;
      if (hqSpriteNr2 > 0)
      {
         let mut local33: &Graphics = &graphics;
        bitmap = BitmapStore.GetBitmap(hqSpriteNr2);
         let mut local34: &Bitmap = &bitmap;
        double r3 =  ( this.game.Data.RegimeObj[index].Red3 /  byte.MaxValue) - 1.0;
        double g3 =  ( this.game.Data.RegimeObj[index].Green3 /  byte.MaxValue) - 1.0;
        double b3 =  ( this.game.Data.RegimeObj[index].Blue3 /  byte.MaxValue) - 1.0;
        DrawMod.Draw( local33,  local34, 30, 27,  r3,  g3,  b3, 0.95f);
      }
      if (this.currentPlayerId < 1)
      {
        if (flag2)
        {
          if (flag4)
          {
            rectangle = Rectangle::new(0, 0, 100, 75);
            trect3 = rectangle;
            this.AddMouse( trect3, "Current AI player is unknown. ", "This AI is currently making its moves.");
          }
          else if (this.game.EditObj.se1_ManagementMode)
          {
            rectangle = Rectangle::new(0, 0, 100, 75);
            trect3 = rectangle;
            this.AddMouse( trect3, "Current player is " + this.game.Data.RegimeObj[index].Name, "Yes, this is you.");
          }
          else
          {
            rectangle = Rectangle::new(0, 0, 100, 75);
            trect3 = rectangle;
            this.AddMouse( trect3, "Current player is " + this.game.Data.RegimeObj[index].Name, "This AI is currently making its moves.");
          }
        }
        else if (this.game.EditObj.se1_ManagementMode)
        {
          rectangle = Rectangle::new(0, 0, 100, 75);
          trect3 = rectangle;
          this.AddMouse( trect3, "Current player is " + this.game.Data.RegimeObj[index].Name, "Yes, this is you.");
        }
        else
        {
          rectangle = Rectangle::new(0, 0, 100, 75);
          trect3 = rectangle;
          this.AddMouse( trect3, "Current player is " + this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Name, "Click to go to capitol of this regime.", 501);
        }
      }
      if (Information.IsNothing( graphics))
        return;
      graphics.Dispose();
      graphics = (Graphics) null;
    }

    pub Rectangle DrawOneTab(
      Graphics g,
      bool active,
      int tx,
      string s,
      int iconSlot,
      let mut smallNumber: i32 = -1,
      bool grayedOut = false,
      bool MousingOverNow = false)
    {
      let mut y1: i32 = 0;
      if (!active)
        y1 = -12;
      Bitmap bitmap;
      if (MousingOverNow)
      {
         let mut local1: &Graphics = &g;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_TAB);
         let mut local2: &Bitmap = &bitmap;
        let mut x: i32 = tx;
        let mut y2: i32 = y1;
        DrawMod.Draw( local1,  local2, x, y2, 0.05f, 0.05f, 0.05f, 1f);
      }
      else
      {
         let mut local3: &Graphics = &g;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_TAB);
         let mut local4: &Bitmap = &bitmap;
        let mut x: i32 = tx;
        let mut y3: i32 = y1;
        DrawMod.DrawSimple( local3,  local4, x, y3);
      }
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (iconSlot > -1)
      {
        if (grayedOut)
        {
           let mut local5: &Graphics = &g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
           let mut local6: &Bitmap = &bitmap;
          rectangle1 = Rectangle::new(iconSlot * 42, 0, 42, 32);
          let mut srcrect: &Rectangle = &rectangle1
          rectangle2 = Rectangle::new(tx + 11, y1 + 20, 42, 32);
          let mut destrect: &Rectangle = &rectangle2
          DrawMod.DrawSimplePart2Coloured( local5,  local6, srcrect, destrect, 0.5f, 0.5f, 0.5f, 1f);
        }
        else if (MousingOverNow & !active)
        {
           let mut local7: &Graphics = &g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
           let mut local8: &Bitmap = &bitmap;
          rectangle2 = Rectangle::new(iconSlot * 42, 32, 42, 32);
          let mut srcrect: &Rectangle = &rectangle2
          rectangle1 = Rectangle::new(tx + 11, y1 + 20, 42, 32);
          let mut destrect: &Rectangle = &rectangle1
          DrawMod.DrawSimplePart2( local7,  local8, srcrect, destrect);
        }
        else
        {
          if (!active)
          {
             let mut local9: &Graphics = &g;
            bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
             let mut local10: &Bitmap = &bitmap;
            rectangle2 = Rectangle::new(iconSlot * 42, 0, 42, 32);
            let mut srcrect: &Rectangle = &rectangle2
            rectangle1 = Rectangle::new(tx + 11, y1 + 20, 42, 32);
            let mut destrect: &Rectangle = &rectangle1
            DrawMod.DrawSimplePart2( local9,  local10, srcrect, destrect);
          }
          if (active)
          {
             let mut local11: &Graphics = &g;
            bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
             let mut local12: &Bitmap = &bitmap;
            rectangle2 = Rectangle::new(iconSlot * 42, 32, 42, 32);
            let mut srcrect: &Rectangle = &rectangle2
            rectangle1 = Rectangle::new(tx + 11, y1 + 20, 42, 32);
            let mut destrect: &Rectangle = &rectangle1
            DrawMod.DrawSimplePart2( local11,  local12, srcrect, destrect);
          }
        }
      }
      Color c;
      if (smallNumber > 0)
      {
        if (!active)
        {
           let mut local13: &Graphics = &g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONHIGHLIGHT);
           let mut local14: &Bitmap = &bitmap;
          rectangle2 = Rectangle::new(0, 0, 42, 32);
          let mut srcrect: &Rectangle = &rectangle2
          rectangle1 = Rectangle::new(tx + 11, y1 + 20, 42, 32);
          let mut destrect: &Rectangle = &rectangle1
          DrawMod.DrawSimplePart2( local13,  local14, srcrect, destrect);
          c = Color.FromArgb( byte.MaxValue, 225, 215, 215);
        }
        if (active)
        {
           let mut local15: &Graphics = &g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONHIGHLIGHT);
           let mut local16: &Bitmap = &bitmap;
          rectangle2 = Rectangle::new(0, 32, 42, 32);
          let mut srcrect: &Rectangle = &rectangle2
          rectangle1 = Rectangle::new(tx + 11, y1 + 20, 42, 32);
          let mut destrect: &Rectangle = &rectangle1
          DrawMod.DrawSimplePart2( local15,  local16, srcrect, destrect);
          c = Color.FromArgb( byte.MaxValue,  byte.MaxValue, 245, 245);
        }
        str: String = smallNumber.ToString();
        if (smallNumber > 9)
          str = "X";
        SizeF sizeF = g.MeasureString(str, DrawMod.TGame.MarcFont5);
        DrawMod.DrawTextColouredConsole( g, str, this.game.MarcFont5, tx +  Math.Round((68.0 -  sizeF.Width) / 2.0) + 11, y1 + 22, c);
      }
      SizeF sizeF1 = g.MeasureString(s, DrawMod.TGame.MarcFont16);
      if (active)
        c = this.game.seColWhite;
      if (!active)
        c = this.game.seColGray;
      if (grayedOut)
        c = Color.FromArgb( byte.MaxValue, 128, 128, 128);
      DrawMod.DrawTextColouredConsole( g, s, this.game.MarcFont16, tx +  Math.Round((68.0 -  sizeF1.Width) / 2.0), y1 + 48, c);
      Rectangle rectangle3 = Rectangle::new(tx, y1, 68, 75);
      tx += 68;
      return rectangle3;
    }

    pub void DrawOpenTab(object g)
    {
      if (this.CurrentView <= 0)
        return;
      Rectangle rectForTab = DrawMod.GetRectForTab(this.CurrentView);
      Graphics graphics = (Graphics) g;
       let mut local1: &Graphics = &graphics;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.MARCTAB);
       let mut local2: &Bitmap = &bitmap1;
      Rectangle rectangle1 = Rectangle::new(0, 20, 8, 43);
      let mut srcrect1: &Rectangle = &rectangle1
      Rectangle rectangle2 = Rectangle::new(rectForTab.X, 32, 8, 43);
      let mut destrect1: &Rectangle = &rectangle2
      DrawMod.DrawSimplePart2( local1,  local2, srcrect1, destrect1);
      g =  graphics;
      graphics = (Graphics) g;
       let mut local3: &Graphics = &graphics;
      Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.MARCTAB);
       let mut local4: &Bitmap = &bitmap2;
      rectangle2 = Rectangle::new(170, 20, 16, 43);
      let mut srcrect2: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(rectForTab.X + rectForTab.Width - 16, 32, 16, 43);
      let mut destrect2: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2( local3,  local4, srcrect2, destrect2);
      g =  graphics;
      let mut x: i32 = rectForTab.X + 8;
      let mut width: i32 = 160;
      for (; x < rectForTab.X + rectForTab.Width; x += 160)
      {
        if (x + width > rectForTab.X + rectForTab.Width - 16)
          width = rectForTab.X + rectForTab.Width - 16 - x;
        graphics = (Graphics) g;
         let mut local5: &Graphics = &graphics;
        Bitmap bitmap3 = BitmapStore.GetBitmap(this.game.MARCTAB);
         let mut local6: &Bitmap = &bitmap3;
        rectangle2 = Rectangle::new(10, 20, width, 43);
        let mut srcrect3: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(x, 32, width, 43);
        let mut destrect3: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2( local5,  local6, srcrect3, destrect3);
        g =  graphics;
      }
    }

    pub void DrawTabs(object g)
    {
      this.tab1 = -1;
      this.tab2 = -1;
      this.tab3 = -1;
      this.tab4 = -1;
      this.tab5 = -1;
      this.tab6 = -1;
      this.tab7 = -1;
      this.tab8 = -1;
      this.tab9 = -1;
      this.tab13 = -1;
      this.tab11 = -1;
      this.tab12 = -1;
      Rectangle trect1;
      if (!this.game.AIRunning & !this.game.EditObj.AIMoving & this.game.EditObj.OrderType != 26)
      {
        let mut tx1: i32 = this.game.ScreenWidth - 734;
        Rectangle trect2 = this.DrawOneTab((Graphics) g, this.CurrentView == 8, tx1, "PREFS", 0, MousingOverNow: (this.MouseOverWhichTab == 8));
        this.AddMouse( trect2, "PREFERENCES", "Sound and other customizable settings. [F1]", 8);
        this.tab1 = this.MouseCounter;
        let mut tx2: i32 = tx1 + 68;
        Rectangle trect3 = this.DrawOneTab((Graphics) g, this.CurrentView == 2, tx2, "STATS", 2, MousingOverNow: (this.MouseOverWhichTab == 2));
        this.AddMouse( trect3, "STATISTICS", "Review kills, losses and Regime information [F3]", 2);
        this.tab3 = this.MouseCounter;
        let mut tx3: i32 = tx2 + 68;
        Rectangle trect4 = this.DrawOneTab((Graphics) g, this.CurrentView == 3, tx3, "OOB", 1, MousingOverNow: (this.MouseOverWhichTab == 3));
        this.AddMouse( trect4, "ORDER OF BATTLE", "Review all your units. [F4]", 3);
        this.tab4 = this.MouseCounter;
        let mut tx4: i32 = tx3 + 68;
        Rectangle trect5 = this.DrawOneTab((Graphics) g, this.CurrentView == 6, tx4, "S.MAP", 3, MousingOverNow: (this.MouseOverWhichTab == 6));
        this.AddMouse( trect5, "STRATEGIC MAP", "View the strategic situation and send messages. [F7]", 6);
        this.tab7 = this.MouseCounter;
        let mut tx5: i32 = tx4 + 68;
        int tx6;
        if (this.game.Data.RegimeObj[this.game.EditObj.RealTurn].ActionCardCounter == -1)
        {
          this.DrawOneTab((Graphics) g, false, tx5, "STRAT.", 4);
          this.tab6 = -1;
          tx6 = tx5 + 68;
        }
        else
        {
          Rectangle trect6 = this.DrawOneTab((Graphics) g, this.CurrentView == 5, tx5, "STRAT.", 4, MousingOverNow: (this.MouseOverWhichTab == 5));
          this.AddMouse( trect6, "STRATAGEMS", "View your stratagems and play them. [F6]", 5);
          this.tab6 = this.MouseCounter;
          tx6 = tx5 + 68;
        }
        if (this.tab11name.Length > 1)
        {
          let mut smanagementTabPageCount: i32 = this.game.HandyFunctionsObj.GetUDSmanagementTabPageCount(1);
          if (smanagementTabPageCount > 0)
          {
            trect1 = this.DrawOneTab((Graphics) g, this.CurrentView == 11, tx6, this.tab11name, 5, smanagementTabPageCount, MousingOverNow: (this.MouseOverWhichTab == 11));
            this.AddMouse( trect1, this.tab11name, "Make decisions awaiting you", 11);
            this.tab11 = this.MouseCounter;
            tx6 += 68;
          }
          else
          {
            trect1 = this.DrawOneTab((Graphics) g, this.CurrentView == 11, tx6, this.tab11name, 5, grayedOut: true);
            this.AddMouse( trect1, this.tab11name, "No decisions to be taken", -2);
            this.tab11 = this.MouseCounter;
            tx6 += 68;
          }
        }
        if (this.tab12name.Length > 1 && this.game.HandyFunctionsObj.GetUDSmanagementTabPageCount(2) > 0)
        {
          trect1 = this.DrawOneTab((Graphics) g, this.CurrentView == 12, tx6, this.tab12name, 6, MousingOverNow: (this.MouseOverWhichTab == 12));
          this.AddMouse( trect1, this.tab12name, "Reports and letters received this turn", 12);
          this.tab12 = this.MouseCounter;
          let mut num: i32 = tx6 + 68;
        }
      }
      let mut tx: i32 = this.game.ScreenWidth - 258;
      trect1 = this.DrawOneTab((Graphics) g, this.CurrentView == 7, tx, "MINI", 7, MousingOverNow: (this.MouseOverWhichTab == 7));
      this.AddMouse( trect1, "MINIMAP", "View the mini-map. [F8]", 7);
      this.tab8 = this.MouseCounter;
    }

    pub void DrawTabs_ManagementScreen(object g)
    {
      this.tab1a = -1;
      this.tab2a = -1;
      this.tab3a = -1;
      this.tab4a = -1;
      this.tab5a = -1;
      this.tab6a = -1;
      this.tab7a = -1;
      this.tab8a = -1;
      this.tab9a = -1;
      let mut tx1: i32 = 650;
      Rectangle trect1 = this.DrawOneTab((Graphics) g, this.game.EditObj.se1_ManagementTab == 54, tx1, "ASSET", 46, MousingOverNow: (this.MouseOverWhichTab == 54));
      this.AddMouse( trect1, "ASSET MANAGEMENT WINDOW", "Inspect and give orders to all your Assets", 54);
      this.tab4a = this.MouseCounter;
      let mut tx2: i32 = tx1 + 68;
      Rectangle trect2 = this.DrawOneTab((Graphics) g, this.game.EditObj.se1_ManagementTab == 55, tx2, "MODEL", 47, MousingOverNow: (this.MouseOverWhichTab == 55));
      this.AddMouse( trect2, "MODEL & QUALITY LEVEL MANAGEMENT WINDOW", "Inspect and set Quality Levels for all your Models and Units", 55);
      this.tab5a = this.MouseCounter;
      let mut tx3: i32 = tx2 + 68;
      Rectangle trect3 = this.DrawOneTab((Graphics) g, this.game.EditObj.se1_ManagementTab == 56, tx3, "LEADER", 43, MousingOverNow: (this.MouseOverWhichTab == 56));
      this.AddMouse( trect3, "LEADER MANAGEMENT WINDOW", "Inspect and review all your Leaders", 56);
      this.tab6a = this.MouseCounter;
      let mut tx4: i32 = tx3 + 68;
      Rectangle trect4 = this.DrawOneTab((Graphics) g, this.game.EditObj.se1_ManagementTab <= 51, tx4, "PROF", 12, MousingOverNow: (this.MouseOverWhichTab <= 51));
      this.AddMouse( trect4, "PROFILE INFO", "Inspect your Regime Feats progress", 51);
      this.tab1a = this.MouseCounter;
      let mut tx5: i32 = tx4 + 68;
      Rectangle trect5 = this.DrawOneTab((Graphics) g, this.game.EditObj.se1_ManagementTab == 52, tx5, "TECH", 1, MousingOverNow: (this.MouseOverWhichTab == 52));
      this.AddMouse( trect5, "TECH TREE INFO", "Inspect your Tech tree progress", 52);
      this.tab2a = this.MouseCounter;
      let mut tx6: i32 = tx5 + 68;
      Rectangle trect6 = this.DrawOneTab((Graphics) g, this.game.EditObj.se1_ManagementTab == 53, tx6, "TYPE", 41, MousingOverNow: (this.MouseOverWhichTab == 53));
      this.AddMouse( trect6, "MODEL TYPE INFO", "Inspect your Model Type tree progress", 53);
      this.tab3a = this.MouseCounter;
      let mut tx7: i32 = tx6 + 68;
      if (!this.game.UserDebugger || !(this.game.HandyFunctionsObj.GetHumanPlayers() <= 1 |  Math.Round(Conversion.Val(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 156, 0, 0))].GetData(0, 17, 2))) > 0))
        return;
      Rectangle trect7 = this.DrawOneTab((Graphics) g, this.game.EditObj.se1_ManagementTab == 57, tx7, "DEBUG", 6, MousingOverNow: (this.MouseOverWhichTab == 57));
      this.AddMouse( trect7, "MODEL TYPE INFO", "Inspect your Model Type tree progress", 57);
      this.tab7a = this.MouseCounter;
      let mut num: i32 = tx7 + 68;
    }

    pub void DrawHexStats( Graphics g)
    {
      let mut x1: i32 =  Math.Round( this.game.ScreenWidth / 2.0 + 158.0);
      if (!(this.game.EditObj.RealRound > 0 & this.game.SelectX > -1))
        return;
      SizeF sizeF1 = SizeF::new();
      str1: String = "REC";
      SizeF sizeF2 = g.MeasureString(str1, this.game.MarcFont5);
      let mut x2: i32 =  Math.Round( ( x1 +  (15.0 -  sizeF2.Width / 2.0)));
      DrawMod.DrawTextColouredMarc( g, str1, this.game.MarcFont5, x2, 2, Color.White);
      str2: String = Strings.Trim(Conversion.Str( this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon));
      Color color =  this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon >=  this.game.Data.RuleVar[55] ? ( this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon >=  this.game.Data.RuleVar[56] ? Color.FromArgb( byte.MaxValue, 0,  byte.MaxValue, 0) : Color.FromArgb( byte.MaxValue,  byte.MaxValue,  byte.MaxValue, 0)) : Color.FromArgb( byte.MaxValue,  byte.MaxValue, 0, 0);
      SizeF sizeF3 = g.MeasureString(str2, this.game.MarcFont5);
      let mut x3: i32 =  Math.Round( ( x1 +  (15.0 -  sizeF3.Width / 2.0)));
      DrawMod.DrawTextColouredMarc( g, str2, this.game.MarcFont5, x3, 15, Color.White);
      Rectangle trect1 = Rectangle::new(x1, 2, 30, 28);
      this.AddMouse( trect1, "RECON POINTS", "How much recon points you have on hex.\r\n" + Strings.Trim(Conversion.Str( this.game.Data.RuleVar[55])) + " points needed to spot a unit.\r\n" + Strings.Trim(Conversion.Str( this.game.Data.RuleVar[56])) + " points needed for full info on unit.");
      let mut x4: i32 = x1 + 30;
      DrawMod.DrawBlockGradient2( g, x4 - 2, 0, 3, 32, Color.FromArgb(200, 80, 90, 110), Color.FromArgb(50, 80, 90, 110));
      str3: String = "ZOC";
      SizeF sizeF4 = g.MeasureString(str3, this.game.MarcFont5);
      let mut x5: i32 =  Math.Round( ( x4 +  (15.0 -  sizeF4.Width / 2.0)));
      DrawMod.DrawTextColouredMarc( g, str3, this.game.MarcFont5, x5, 2, Color.White);
      str4: String = Strings.Trim(Conversion.Str( this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].get_ZocPts(this.game.EditObj.RealTurn)));
      SizeF sizeF5 = g.MeasureString(str4, this.game.MarcFont5);
      let mut x6: i32 =  Math.Round( ( x4 +  (15.0 -  sizeF5.Width / 2.0)));
      DrawMod.DrawTextColouredMarc( g, str4, this.game.MarcFont5, x6, 15, Color.White);
      trect1 = Rectangle::new(x4, 2, 30, 28);
      let mut trect2: &Rectangle = &trect1
      this.AddMouse( trect2, "ZONE OF CONTROL POINTS", "Shows how many ZOC points you are exerting on the hex.\r\n" + Strings.Trim(Conversion.Str( this.game.Data.RuleVar[40])) + "x more ZOC needed then enemy to capture unoccupied hex.");
      let mut x7: i32 = x4 + 30;
      DrawMod.DrawBlockGradient2( g, x7 - 2, 0, 3, 32, Color.FromArgb(200, 80, 90, 110), Color.FromArgb(50, 80, 90, 110));
      str5: String = "AP";
      SizeF sizeF6 = g.MeasureString(str5, this.game.MarcFont5);
      let mut x8: i32 =  Math.Round( ( x7 +  (15.0 -  sizeF6.Width / 2.0)));
      DrawMod.DrawTextColouredMarc( g, str5, this.game.MarcFont5, x8, 2, Color.White);
      str6: String = Strings.Trim(Conversion.Str( (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].get_APPenalty(this.game.EditObj.RealTurn) + this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].get_BattlePenalty(this.game.EditObj.RealTurn))));
      sizeF6 = g.MeasureString(str6, this.game.MarcFont5);
      let mut x9: i32 =  Math.Round( ( x7 +  (15.0 -  sizeF6.Width / 2.0)));
      DrawMod.DrawTextColouredMarc( g, str6, this.game.MarcFont5, x9, 15, Color.White);
      ttext: String = "How much extra AP it costs to move into hex.\r\n" + Strings.Trim(Conversion.Str( this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].get_APPenalty(this.game.EditObj.RealTurn))) + " points for enemy owned hex rule." + "\r\n" + Strings.Trim(Conversion.Str( this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].get_BattlePenalty(this.game.EditObj.RealTurn))) + " points for previous battles fought in hex.";
      trect1 = Rectangle::new(x7, 2, 30, 28);
      let mut trect3: &Rectangle = &trect1
      this.AddMouse( trect3, "ACTION POINT PENALTIES", ttext);
      let mut x10: i32 = x7 + 30;
      DrawMod.DrawBlockGradient2( g, x10 - 2, 0, 3, 32, Color.FromArgb(200, 80, 90, 110), Color.FromArgb(50, 80, 90, 110));
      str7: String = "STK";
      sizeF6 = g.MeasureString(str7, this.game.MarcFont5);
      let mut x11: i32 =  Math.Round( ( x10 +  (15.0 -  sizeF6.Width / 2.0)));
      DrawMod.DrawTextColouredMarc( g, str7, this.game.MarcFont5, x11, 2, Color.White);
      str8: String = Strings.Trim(Conversion.Str( this.game.HandyFunctionsObj.GetHexStackPts(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected)));
      if (this.game.Data.FOWOn)
      {
        if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime > -1 && !this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime, this.game.EditObj.RealTurn))
          str8 = "?";
        if (this.game.EditObj.UnitSelected > -1 && !this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.EditObj.RealTurn))
          str8 = "?";
      }
      if (Operators.CompareString(str8, "?", false) == 0)
      {
        let mut unitCounter: i32 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter;
        int num;
        for (let mut index: i32 = 0; index <= unitCounter; index += 1)
        {
          let mut unit: i32 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitList[index];
          num += this.game.HandyFunctionsObj.GetStackWithFOW(unit, this.game.EditObj.RealTurn);
        }
        if (num > 0)
          str8 = num.ToString();
      }
      sizeF6 = g.MeasureString(str8, this.game.MarcFont5);
      let mut x12: i32 =  Math.Round( ( x10 +  (15.0 -  sizeF6.Width / 2.0)));
      DrawMod.DrawTextColouredMarc( g, str8, this.game.MarcFont5, x12, 15, Color.White);
      trect1 = Rectangle::new(x10, 2, 30, 28);
      let mut trect4: &Rectangle = &trect1
      this.AddMouse( trect4, "STACK POINTS", "How much stack points are in this hex.\r\nAbove " + Strings.Trim(Conversion.Str( this.game.Data.RuleVar[30])) + " points the hex becomes overstacked.");
      let mut x13: i32 = x10 + 30;
      DrawMod.DrawBlockGradient2( g, x13 - 2, 0, 3, 32, Color.FromArgb(200, 80, 90, 110), Color.FromArgb(50, 80, 90, 110));
      str9: String = "VP";
      sizeF6 = g.MeasureString(str9, this.game.MarcFont5);
      let mut x14: i32 =  Math.Round( ( x13 +  (15.0 -  sizeF6.Width / 2.0)));
      DrawMod.DrawTextColouredMarc( g, str9, this.game.MarcFont5, x14, 2, Color.White);
      str10: String = Strings.Trim(Conversion.Str( this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].VP));
      sizeF6 = g.MeasureString(str10, this.game.MarcFont5);
      let mut x15: i32 =  Math.Round( ( x13 +  (15.0 -  sizeF6.Width / 2.0)));
      DrawMod.DrawTextColouredMarc( g, str10, this.game.MarcFont5, x15, 15, Color.White);
      trect1 = Rectangle::new(x13, 2, 30, 28);
      let mut trect5: &Rectangle = &trect1
      this.AddMouse( trect5, "VICTORY POINTS", "How much VP does hex have.");
    }

    pub void DrawScope( Graphics g)
    {
      let mut num1: i32 =  Math.Round( this.game.ScreenWidth / 2.0 - 158.0);
      if (!(this.game.SelectX > -1 & this.game.SelectY > -1))
        return;
      let mut stringListById1: i32 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 370, 0, 0));
      let mut stringListById2: i32 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0));
      let mut num2: i32 = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 125, 0, 0))].Length + 1;
      let mut landscapeType: i32 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType;
      let mut spriteNr: i32 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].SpriteNr;
      data: DataClass = DrawMod.TGame.Data;
      str1: String = "Zones";
       local1: String =  str1;
      let mut libVar: i32 = data.FindLibVar( local1, "SE_Data");
      let mut num3: i32 = 0;
      let mut hexLibVarValue: i32 = DrawMod.TGame.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].GetHexLibVarValue(libVar);
      if (hexLibVarValue > 0)
        num3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, hexLibVarValue, 13)));
      let mut num4: i32 =  Math.Round( num3 /  num2);
      int eventPicOrigSlot1;
      int eventPicOrigSlot2;
      if (stringListById1 > -1)
      {
        eventPicOrigSlot1 = num4 >= 50 ? (num4 >= 500 ?  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, landscapeType, 3))) :  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, landscapeType, 2)))) :  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, landscapeType, 1)));
        eventPicOrigSlot2 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, landscapeType, 6)));
      }
      if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon < 1)
        eventPicOrigSlot2 = 61;
      let mut eventPic1: i32 = this.game.Data.FindEventPic(eventPicOrigSlot1, "SE_Present");
      int num5;
      int num6;
      Rectangle trect;
      Rectangle rectangle;
      if (eventPic1 > -1)
      {
        let mut nr: i32 = this.game.Data.EventPicNr[eventPic1];
        num5 = 256;
        num6 = 80;
         let mut local2: &Graphics = &g;
        Bitmap bitmap = BitmapStore.GetBitmap(nr);
         let mut local3: &Bitmap = &bitmap;
        trect = Rectangle::new(0, 0, 256, 65);
        let mut srcrect: &Rectangle = &trect
        rectangle = Rectangle::new(num1 + 31, 0, 256, 65);
        let mut destrect: &Rectangle = &rectangle
        DrawMod.DrawSimplePart2( local2,  local3, srcrect, destrect);
      }
      let mut eventPic2: i32 = this.game.Data.FindEventPic(eventPicOrigSlot2, "SE_Present");
      if (eventPic2 > -1)
      {
        let mut nr: i32 = this.game.Data.EventPicNr[eventPic2];
        num5 = 256;
        num6 = 80;
         let mut local4: &Graphics = &g;
        Bitmap bitmap = BitmapStore.GetBitmap(nr);
         let mut local5: &Bitmap = &bitmap;
        rectangle = Rectangle::new(0, 0, 256, 65);
        let mut srcrect: &Rectangle = &rectangle
        trect = Rectangle::new(num1 + 31, 0, 256, 65);
        let mut destrect: &Rectangle = &trect
        DrawMod.DrawSimplePart2( local4,  local5, srcrect, destrect);
      }
       let mut local6: &Graphics = &g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.MARCSCOPE);
       let mut local7: &Bitmap = &bitmap1;
      let mut x1: i32 = num1;
      DrawMod.DrawSimple( local6,  local7, x1, 0);
      if (!(landscapeType > -1 & spriteNr > -1))
        return;
      str2: String = this.game.HandyFunctionsObj.GetHexName(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
      SizeF sizeF1 = SizeF::new();
      SizeF sizeF2 = g.MeasureString(str2, this.game.MarcFont5);
      if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Location > -1)
      {
        let mut pictureLt: i32 = this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Location].Type].PictureLT;
        if (pictureLt > -1)
          str2 = this.game.Data.LandscapeTypeObj[pictureLt].Name.Replace("(System)", "");
      }
      str3: String = str2;
      if ( sizeF2.Width < 135.0 & this.w >= 1600)
        str2 = str2 + " (" + Strings.Trim(Conversion.Str( this.game.SelectX)) + "," + Strings.Trim(Conversion.Str( this.game.SelectY)) + ") ";
      str3 + " (" + Strings.Trim(Conversion.Str( this.game.SelectX)) + "," + Strings.Trim(Conversion.Str( this.game.SelectY)) + ") ";
      sizeF1 = g.MeasureString(str2, this.game.MarcFont5);
      string str4;
      int regime;
      if (this.game.EditObj.OrderType == 26)
      {
        if (this.game.EditObj.HisOwner[this.game.EditObj.MapSelected].Value[this.game.SelectX, this.game.SelectY] > -1)
        {
          str4 = this.game.Data.RegimeObj[this.game.EditObj.HisOwner[this.game.EditObj.MapSelected].Value[this.game.SelectX, this.game.SelectY]].Name;
          regime = this.game.EditObj.HisOwner[this.game.EditObj.MapSelected].Value[this.game.SelectX, this.game.SelectY];
        }
      }
      else if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime > -1)
      {
        str4 = this.game.EventRelatedObj.Helper_GetOwnerNameForGuiDisplay(this.game.SelectX, this.game.SelectY);
        regime = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime;
      }
      landscapeMouseOverText: String = this.game.HandyFunctionsObj.GetLandscapeMouseOverText();
      if (1600 > this.w)
      {
        str5: String = Strings.UCase(Strings.Left(str2, 1)) + Strings.Mid(str2, 2);
        let mut x2: i32 =  Math.Round( this.w / 2.0 - 115.0 - 75.0 -  g.MeasureString(str5, this.game.MarcFont5).Width / 2.0);
        DrawMod.DrawTextColouredMarc( g, str5, this.game.MarcFont5, x2, 9, Color.White);
        rectangle = Rectangle::new( Math.Round( this.game.ScreenWidth / 2.0 - 130.0), 0, 100, 62);
        trect = rectangle;
        this.AddMouse( trect, str5, landscapeMouseOverText);
        str6: String = str4;
        let mut x3: i32 =  Math.Round( this.w / 2.0 + 125.0 + 75.0 -  g.MeasureString(str6, this.game.MarcFont5).Width / 2.0);
        DrawMod.DrawTextColouredMarc( g, str6, this.game.MarcFont5, x3, 9, Color.White);
      }
      else
      {
        str7: String = Strings.UCase(Strings.Left(str2, 1)) + Strings.Mid(str2, 2);
        let mut x4: i32 =  Math.Round( this.w / 2.0 - 175.0 - 75.0 -  g.MeasureString(str7, this.game.MarcFont4).Width / 2.0);
        DrawMod.DrawTextColouredMarc( g, str7, this.game.MarcFont4, x4, 4, Color.White);
        rectangle = Rectangle::new( Math.Round( this.game.ScreenWidth / 2.0 - 130.0), 0, 260, 62);
        trect = rectangle;
        this.AddMouse( trect, str7, landscapeMouseOverText);
        str8: String = str4;
        let mut x5: i32 =  Math.Round( this.w / 2.0 + 175.0 + 75.0 -  g.MeasureString(str8, this.game.MarcFont4).Width / 2.0);
        if (Operators.CompareString(str8, "Unknown", false) != 0 & Operators.CompareString(str8, "Unclear", false) != 0)
        {
           let mut local8: &Graphics = &g;
          Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.Data.RegimeObj[regime].SymbolSpriteNr);
           let mut local9: &Bitmap = &bitmap2;
          let mut x6: i32 = x5 - 24;
          let mut width: i32 = BitmapStore.GetWidth(this.game.Data.RegimeObj[regime].SymbolSpriteNr);
          let mut origh: i32 = BitmapStore.Getheight(this.game.Data.RegimeObj[regime].SymbolSpriteNr);
          double r =  ( this.game.Data.RegimeObj[regime].Red3 /  byte.MaxValue);
          double g1 =  ( this.game.Data.RegimeObj[regime].Green3 /  byte.MaxValue);
          double b =  ( this.game.Data.RegimeObj[regime].Blue3 /  byte.MaxValue);
          DrawMod.DrawScaledColorized2( local8,  local9, x6, 0, 24, 24, width, origh,  r,  g1,  b,  byte.MaxValue);
        }
        DrawMod.DrawTextColouredMarc( g, str8, this.game.MarcFont4, x5, 4, Color.White);
      }
    }

    pub void DrawDate( Graphics g)
    {
      if (this.game.EditObj.RealTurn <= -1)
        return;
      let mut stringListById1: i32 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 156, 0, 0));
      let mut stringListById2: i32 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 125, 0, 0));
      let mut num1: i32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, 14, 2)));
      let mut num2: i32 = this.game.Data.StringListObj[stringListById2].Length + 1;
      let mut idValue: i32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, 12, 2)));
      this.game.Data.StringListObj[stringListById2].GetData(0, idValue, 1);
      let mut num3: i32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, 47, 2)));
      let mut Month: i32 = (this.game.EditObj.RealRound + 6) % 6 * 2 - 1;
      if (Month < 1)
        Month = 11;
      if (Information.IsNothing( this.game.Data.TurnString))
        this.game.Data.TurnString = "";
      SizeF sizeF = SizeF::new();
      string[] strArray = this.game.Data.TurnString.Split(new char[1]
      {
        ','
      }, StringSplitOptions.RemoveEmptyEntries);
      if (strArray.GetUpperBound(0) <= 0)
        return;
      let mut x1: i32 = this.game.ScreenWidth - 190 + 65 -  Math.Round( (g.MeasureString(strArray[0], this.game.MarcFont16).Width / 2f));
      DrawMod.DrawTextColouredConsole( g, strArray[0], this.game.MarcFont16, x1, 11, Color.LightGray);
      let mut x2: i32 = this.game.ScreenWidth - 190 + 65 -  Math.Round( (g.MeasureString(strArray[1], this.game.MarcFont16).Width / 2f));
      DrawMod.DrawTextColouredConsole( g, strArray[1], this.game.MarcFont16, x2, 27, Color.LightGray);
      Rectangle trect = Rectangle::new(x2, 16, 106, 32);
      this.AddMouse( trect, "", "This is Round " + this.game.EditObj.RealRound.ToString() + ".\r\nThis is Local Year " + num3.ToString() + " AA, Season " + idValue.ToString() + " of " + num2.ToString() + ".\r\nThis is Earth Year " + num1.ToString() + "-" + DateAndTime.MonthName(Month, true) + ".");
    }

    pub void DrawPP( Graphics g)
    {
      if (this.game.EditObj.RealTurn <= -1)
        return;
      let mut stringListById1: i32 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 210, 0, 0));
      let mut id: i32 = this.game.Data.RegimeObj[this.game.EditObj.RealTurn].id;
      if (this.game.Data.RegimeObj[this.game.EditObj.RealTurn].AI &  this.game.Data.RuleVar[976] == 1.0)
        return;
      SizeF sizeF1 = SizeF::new();
      SizeF sizeF2 = SizeF::new();
      SizeF sizeF3 = SizeF::new();
      SizeF sizeF4 = SizeF::new();
      SizeF sizeF5 = SizeF::new();
      data2: String = this.game.Data.StringListObj[stringListById1].GetData2(0, id, 1, "fp", 2);
      str1: String = this.game.Data.RegimeObj[this.game.EditObj.RealTurn].ResPts.ToString();
      if (this.game.Data.RegimeObj[this.game.EditObj.RealTurn].ResPts > 9999)
        str1 = ( Math.Round( this.game.Data.RegimeObj[this.game.EditObj.RealTurn].ResPts / 1000.0)).ToString() + "k";
      else if (this.game.Data.RegimeObj[this.game.EditObj.RealTurn].ResPts > 999)
        str1 = Math.Round( this.game.Data.RegimeObj[this.game.EditObj.RealTurn].ResPts / 1000.0, 1).ToString() + "k";
      let mut num1: i32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData2(0, id, 1, "credits", 2)));
      string str2;
      if (num1 > 9999)
      {
        double num2 = Math.Round( num1 / 1000.0, 1);
        str2 = num2.ToString() + "k";
        if (num1 >= 100000)
        {
          num2 = Math.Round( num1 / 1000.0, 0);
          str2 = num2.ToString() + "k";
        }
        if (num1 == 0)
          str2 = "0";
      }
      else
        str2 = num1.ToString();
      sizeF1 = g.MeasureString(data2, this.game.shadowFontConsole);
      sizeF2 = g.MeasureString(str1, this.game.shadowFontConsole);
      sizeF3 = g.MeasureString(str2, this.game.shadowFontConsole);
      let mut x1: i32 = 302;
      let mut y1: i32 = 0;
       let mut local1: &Graphics = &g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_VARBOX);
       let mut local2: &Bitmap = &bitmap1;
      let mut x2: i32 = x1;
      let mut y2: i32 = y1;
      DrawMod.DrawSimple( local1,  local2, x2, y2);
      Rectangle trect1 = Rectangle::new(x1, y1, 74, 28);
      this.AddMouse( trect1, "Fate Points", "You need FP’s to play powerful Fate Stratagems.");
      let mut eventPicSlotFor1: i32 = this.game.EventRelatedObj.GetEventPicSlotFor(0, "", "fp");
       let mut local3: &Graphics = &g;
      Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[eventPicSlotFor1]);
       let mut local4: &Bitmap = &bitmap2;
      let mut x3: i32 = x1 + 2;
      DrawMod.DrawSimple( local3,  local4, x3, 6);
      DrawMod.DrawTextColouredConsole( g, data2, this.game.MarcFont16, x1 + 31, 4, this.game.seColWhite);
      let mut x4: i32 = x1 + 75;
       let mut local5: &Graphics = &g;
      Bitmap bitmap3 = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_VARBOX);
       let mut local6: &Bitmap = &bitmap3;
      let mut x5: i32 = x4;
      let mut y3: i32 = y1;
      DrawMod.DrawSimple( local5,  local6, x5, y3);
      trect1 = Rectangle::new(x4, y1, 74, 28);
      let mut trect2: &Rectangle = &trect1
      this.AddMouse( trect2, "Political Points", "You need PP’s to play organisation-generated Stratagems and sometimes make Decisions.");
      let mut eventPicSlotFor2: i32 = this.game.EventRelatedObj.GetEventPicSlotFor(0, "", "pp");
       let mut local7: &Graphics = &g;
      Bitmap bitmap4 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[eventPicSlotFor2]);
       let mut local8: &Bitmap = &bitmap4;
      let mut x6: i32 = x4 + 2;
      DrawMod.DrawSimple( local7,  local8, x6, 6);
      DrawMod.DrawTextColouredConsole( g, str1, this.game.MarcFont16, x4 + 31, 4, this.game.seColWhite);
      let mut x7: i32 = x4 + 75;
       let mut local9: &Graphics = &g;
      Bitmap bitmap5 = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_VARBOX);
       let mut local10: &Bitmap = &bitmap5;
      let mut x8: i32 = x7;
      let mut y4: i32 = y1;
      DrawMod.DrawSimple( local9,  local10, x8, y4);
      trect1 = Rectangle::new(x7, y1, 74, 28);
      let mut trect3: &Rectangle = &trect1
      this.AddMouse( trect3, "Credits", "You need credits to buy with traders and to pay leaders, workers and others.");
      let mut eventPicSlotFor3: i32 = this.game.EventRelatedObj.GetEventPicSlotFor(0, "", "credits");
       let mut local11: &Graphics = &g;
      Bitmap bitmap6 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[eventPicSlotFor3]);
       let mut local12: &Bitmap = &bitmap6;
      let mut x9: i32 = x7 + 2;
      DrawMod.DrawSimple( local11,  local12, x9, 6);
      DrawMod.DrawTextColouredConsole( g, str2, this.game.MarcFont16, x7 + 31, 4, this.game.seColWhite);
      if (this.game.EditObj.se1_ManagementMode)
        return;
      if (this.game.EditObj.BlockAdvice & this.game.EditObj.showAdvice)
      {
        if (this.game.ScreenWidth >= 1353)
        {
          let mut stringListById2: i32 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 502, 0, 0));
          let mut num3: i32 = this.game.Data.StringListObj[stringListById2].Length + 1;
          if (stringListById2 <= -1 || this.game.Data.StringListObj[stringListById2].Length <= -1)
            return;
          let mut num4: i32 = x7 + 83;
          let mut tsubpart: SubPartClass =  new TextButtonPartClass("Adv.[" + num3.ToString() + "]", 80, "Click for opening advice window.",  this.OwnBitmap, num4, y1 + 2, theight: 26);
          this.advice = this.AddSubPart( tsubpart, num4, y1 + 2, 80, 26, 1);
        }
        else
        {
          let mut stringListById3: i32 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 502, 0, 0));
          if (stringListById3 <= -1 || this.game.Data.StringListObj[stringListById3].Length <= -1)
            return;
          let mut num5: i32 = x7 + 71;
          let mut tsubpart: SubPartClass =  new TextButtonPartClass("Ad", 25, "Click for opening advice window.",  this.OwnBitmap, num5, y1 + 2, theight: 26);
          this.advice = this.AddSubPart( tsubpart, num5, y1 + 2, 25, 26, 1);
        }
      }
      else
      {
        if (!(!this.game.EditObj.BlockAdvice & this.game.EditObj.showAdvice))
          return;
        let mut num6: i32 = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 502, 0, 0))].Length + 1;
        if (this.game.ScreenWidth >= 1353)
        {
          if (num6 > 0)
          {
            let mut num7: i32 = x7 + 83;
            let mut tsubpart: SubPartClass =  new TextButtonPartClass("Adv.[" + num6.ToString() + "]", 80, "Advice Window is open.",  this.OwnBitmap, num7, y1 + 2, true, theight: 26, tMarcStyle: true);
            this.adviceB = this.AddSubPart( tsubpart, num7, y1 + 2, 80, 26, 0);
          }
          else
          {
            let mut num8: i32 = x7 + 83;
            let mut tsubpart: SubPartClass =  new TextButtonPartClass("Adv.[" + num6.ToString() + "]", 80, "No Advice left. Nothing given this round or everything has been dismissed already.",  this.OwnBitmap, num8, y1 + 2, true, theight: 26, tMarcStyle: true);
            this.adviceB = this.AddSubPart( tsubpart, num8, y1 + 2, 80, 26, 0);
          }
        }
        else if (num6 > 0)
        {
          let mut num9: i32 = x7 + 71;
          let mut tsubpart: SubPartClass =  new TextButtonPartClass("Ad", 25, "Advice Window is open.",  this.OwnBitmap, num9, y1 + 2, true, theight: 26, tMarcStyle: true);
          this.adviceB = this.AddSubPart( tsubpart, num9, y1 + 2, 25, 26, 0);
        }
        else
        {
          let mut num10: i32 = x7 + 71;
          let mut tsubpart: SubPartClass =  new TextButtonPartClass("Ad", 25, "No Advice left. Nothing given this round or everything has been dismissed already.",  this.OwnBitmap, num10, y1 + 2, true, theight: 26, tMarcStyle: true);
          this.adviceB = this.AddSubPart( tsubpart, num10, y1 + 2, 25, 26, 0);
        }
      }
    }

    pub void DrawResources( Graphics g)
    {
      SizeF sizeF = SizeF::new();
      int[] numArray = new int[10];
      let mut num1: i32 = 3;
      numArray[1] =  Math.Round( this.game.ScreenWidth / 2.0 + 158.0 + 162.0);
      numArray[2] =  Math.Round( this.game.ScreenWidth / 2.0 + 158.0 + 162.0 + 75.0 + 5.0);
      numArray[3] = 165;
      let mut index1: i32 = 0;
      Right: String = "oil" + this.game.Data.RuleVar[949].ToString();
      if ( this.game.Data.RuleVar[949] < 1.0)
        Right = "1!impossible!!x423121";
      Rectangle trect1;
      if ( this.game.Data.RuleVar[411] > 0.0 && this.game.Data.TempString[731].Length > 1)
      {
        index1 += 1;
        let mut num2: i32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[411]))].GetData2(0, this.game.Data.RegimeObj[this.game.EditObj.RealTurn].id, 1, this.game.Data.TempString[731], 2)));
        int index2;
        tstring: String = num2 <= 9999 ? this.game.Data.TempString[732] + " " + num2.ToString() : this.game.Data.TempString[732] + " " + (Conversion.Int( this.game.Data.GameSlot[index2] / 1000.0).ToString() + "k");
        let mut x1: i32 = 165;
         let mut local1: &Graphics = &g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCOPTSLOTS);
         let mut local2: &Bitmap = &bitmap;
        let mut x2: i32 = x1;
        DrawMod.DrawSimple( local1,  local2, x2, 2);
        DrawMod.DrawTextColouredMarc( g, tstring, this.game.MarcFont8, x1 + 2, 5, Color.White);
        trect1 = Rectangle::new(x1, 2, 75, 20);
        this.AddMouse( trect1, "", this.game.Data.TempString[733]);
      }
      if (this.game.Data.Product >= 7)
        return;
      let mut index3: i32 = 0;
      double num3;
      do
      {
        if (this.game.Data.GameSlotShow2[index3] & this.game.Data.GameSlot[index3] > -1)
        {
          index1 += 1;
          if (index1 <= num1)
          {
            tstring: String = Strings.Trim(Conversion.Str( this.game.Data.GameSlot[index3]));
            if (this.game.Data.GameSlot[index3] > 9999)
            {
              num3 = Conversion.Int( this.game.Data.GameSlot[index3] / 1000.0);
              tstring = num3.ToString() + "k";
            }
            if (this.game.Data.GameSlotSmallGfx[index3] > -1)
            {
               let mut local3: &Graphics = &g;
              Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.MARCOPTSLOTS);
               let mut local4: &Bitmap = &bitmap1;
              let mut x3: i32 = numArray[index1];
              DrawMod.DrawSimple( local3,  local4, x3, 2);
               let mut local5: &Graphics = &g;
              Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[this.game.Data.GameSlotSmallGfx[index3]]);
               let mut local6: &Bitmap = &bitmap2;
              let mut x4: i32 = numArray[index1];
              DrawMod.DrawSimple( local5,  local6, x4, 2);
              let mut x5: i32 = numArray[index1] + 24;
              DrawMod.DrawTextColouredMarc( g, tstring, this.game.MarcFont8, x5, 5, Color.White);
              trect1 = Rectangle::new(numArray[index1], 2, 75, 20);
              let mut trect2: &Rectangle = &trect1
              this.AddMouse( trect2, "", this.game.Data.GameSlotName[index3]);
            }
            else if (this.game.Data.GameSlotNato[index3] > 0)
            {
              if (this.game.NATO[this.game.Data.GameSlotNato[index3]] > 0)
              {
                 let mut local7: &Graphics = &g;
                Bitmap bitmap3 = BitmapStore.GetBitmap(this.game.MARCOPTSLOTS);
                 let mut local8: &Bitmap = &bitmap3;
                let mut x6: i32 = numArray[index1];
                DrawMod.DrawSimple( local7,  local8, x6, 2);
                 let mut local9: &Graphics = &g;
                Bitmap bitmap4 = BitmapStore.GetBitmap(this.game.NATO[this.game.Data.GameSlotNato[index3]]);
                 let mut local10: &Bitmap = &bitmap4;
                let mut x7: i32 = numArray[index1];
                DrawMod.DrawSimple( local9,  local10, x7, 2);
                let mut x8: i32 = numArray[index1] + 24;
                DrawMod.DrawTextColouredMarc( g, tstring, this.game.MarcFont8, x8, 5, Color.White);
                trect1 = Rectangle::new(numArray[index1], 2, 75, 20);
                let mut trect3: &Rectangle = &trect1
                this.AddMouse( trect3, "", this.game.Data.GameSlotName[index3]);
              }
            }
            else
            {
               let mut local11: &Graphics = &g;
              Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCOPTSLOTS);
               let mut local12: &Bitmap = &bitmap;
              let mut x9: i32 = numArray[index1];
              DrawMod.DrawSimple( local11,  local12, x9, 2);
              let mut x10: i32 = numArray[index1] + 24;
              DrawMod.DrawTextColouredMarc( g, tstring, this.game.MarcFont8, x10, 5, Color.White);
              trect1 = Rectangle::new(numArray[index1], 2, 75, 20);
              let mut trect4: &Rectangle = &trect1
              this.AddMouse( trect4, "", this.game.Data.GameSlotName[index3]);
            }
          }
        }
        index3 += 1;
      }
      while (index3 <= 499);
      let mut index4: i32 = 0;
      do
      {
        if (this.game.Data.RegimeSlotShow[index4] &  this.game.Data.RuleVar[814] < 1.0)
        {
          let mut index5: i32 = index4;
          int x11;
          string tstring;
          if (Operators.CompareString(this.game.Data.RegimeSlotName[index4], Right, false) == 0)
          {
            if (this.game.SelectX > -1 & this.game.SelectY > -1)
            {
              x11 = this.game.HandyFunctionsObj.GetFuelSlot949(-1, this.game.SelectX, this.game.SelectY);
              index5 = x11;
              if (x11 > -1)
              {
                x11 = this.game.Data.RegimeObj[this.game.EditObj.RealTurn].RegimeSlot[x11];
                tstring = x11.ToString();
                if (x11 > 9999)
                {
                  num3 = Conversion.Int( x11 / 1000.0);
                  tstring = num3.ToString() + "k";
                }
              }
              else
                tstring = "N/A";
            }
            else
              tstring = "N/A";
          }
          else
          {
            tstring = Strings.Trim(Conversion.Str( this.game.Data.RegimeObj[this.game.EditObj.RealTurn].RegimeSlot[index4]));
            if (this.game.Data.RegimeObj[this.game.EditObj.RealTurn].RegimeSlot[index4] > 9999)
            {
              num3 = Conversion.Int( this.game.Data.RegimeObj[this.game.EditObj.RealTurn].RegimeSlot[index4] / 1000.0);
              tstring = num3.ToString() + "k";
            }
          }
          if (index5 > -1 && this.game.Data.RegimeObj[this.game.EditObj.RealTurn].RegimeSlot[index5] > -1)
          {
            index1 += 1;
            if (index1 <= num1)
            {
              if (this.game.Data.RegimeSlotSmallGfx[index5] > 0)
              {
                 let mut local13: &Graphics = &g;
                Bitmap bitmap5 = BitmapStore.GetBitmap(this.game.MARCOPTSLOTS);
                 let mut local14: &Bitmap = &bitmap5;
                let mut x12: i32 = numArray[index1];
                DrawMod.DrawSimple( local13,  local14, x12, 2);
                 let mut local15: &Graphics = &g;
                Bitmap bitmap6 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[this.game.Data.RegimeSlotSmallGfx[index5]]);
                 let mut local16: &Bitmap = &bitmap6;
                let mut x13: i32 = numArray[index1];
                DrawMod.DrawSimple( local15,  local16, x13, 2);
                x11 = numArray[index1] + 24;
                DrawMod.DrawTextColouredMarc( g, tstring, this.game.MarcFont8, x11, 5, Color.White);
                trect1 = Rectangle::new(numArray[index1], 2, 75, 20);
                let mut trect5: &Rectangle = &trect1
                this.AddMouse( trect5, "", this.game.Data.RegimeSlotName[index5]);
              }
              else if (this.game.Data.RegimeSlotNato[index5] > 0)
              {
                 let mut local17: &Graphics = &g;
                Bitmap bitmap7 = BitmapStore.GetBitmap(this.game.MARCOPTSLOTS);
                 let mut local18: &Bitmap = &bitmap7;
                let mut x14: i32 = numArray[index1];
                DrawMod.DrawSimple( local17,  local18, x14, 2);
                 let mut local19: &Graphics = &g;
                Bitmap bitmap8 = BitmapStore.GetBitmap(this.game.NATO[this.game.Data.RegimeSlotNato[index5]]);
                 let mut local20: &Bitmap = &bitmap8;
                let mut x15: i32 = numArray[index1];
                DrawMod.DrawSimple( local19,  local20, x15, 2);
                x11 = numArray[index1] + 24;
                DrawMod.DrawTextColouredMarc( g, tstring, this.game.MarcFont8, x11, 5, Color.White);
                trect1 = Rectangle::new(numArray[index1], 2, 75, 20);
                let mut trect6: &Rectangle = &trect1
                this.AddMouse( trect6, "", this.game.Data.RegimeSlotName[index5]);
              }
              else
              {
                 let mut local21: &Graphics = &g;
                Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCOPTSLOTS);
                 let mut local22: &Bitmap = &bitmap;
                let mut x16: i32 = numArray[index1];
                DrawMod.DrawSimple( local21,  local22, x16, 2);
                x11 = numArray[index1] + 24;
                DrawMod.DrawTextColouredMarc( g, tstring, this.game.MarcFont8, x11, 5, Color.White);
                trect1 = Rectangle::new(numArray[index1], 2, 75, 20);
                let mut trect7: &Rectangle = &trect1
                this.AddMouse( trect7, "", this.game.Data.RegimeSlotName[index5]);
              }
            }
          }
        }
        index4 += 1;
      }
      while (index4 <= 499);
    }

    pub void HandleToolTip(int x, int y)
    {
      let mut mouseCounter: i32 = this.MouseCounter;
      for (let mut index: i32 = 0; index <= mouseCounter; index += 1)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          if (this.MouseData[index] > 0)
            this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = this.MouseTitle[index];
          this.game.EditObj.TipText = this.MouseText[index];
          if (Strings.InStr(this.game.EditObj.TipText, "MX-ENTR") <= 0)
            return;
          this.game.EditObj.TipTitle += "<FIXEDSYS>";
          return;
        }
      }
      if (this.SubPartCounter <= -1)
        return;
      let mut subPartCounter: i32 = this.SubPartCounter;
      for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
      {
        if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
        {
          this.game.EditObj.TipButton = false;
          this.SubPartList[index].HandleToolTip(x - this.SubPartX[index], y - this.SubPartY[index]);
          if (this.game.EditObj.TipButton)
            break;
          if (Operators.CompareString(this.SubPartList[index].Descript, "", false) > 0)
          {
            this.game.EditObj.TipButton = true;
            this.game.EditObj.TipTitle = "";
            this.game.EditObj.TipText = this.SubPartList[index].Descript;
            break;
          }
        }
      }
    }

    pub void PopUpRefresh()
    {
      this.surrendering &= this.game.EditObj.AnswerChosen == 1;
      if (this.AskingAboutMetrics)
      {
        if (this.game.EditObj.AnswerChosen == 1)
          this.game.EditObj.allowMetrics = true;
        else
          this.game.EditObj.allowMetrics = false;
        this.game.EditObj.askedMetricsPermission = true;
        this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
      }
      this.DoRefresh();
    }

    pub DoEndTurnStuff: WindowReturnClass(int tMouseButPressed)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (!this.game.Data.RegimeObj[this.game.Data.Turn].AI & !this.game.SuperAdminRights)
      {
        let mut locCounter: i32 = this.game.Data.LocCounter;
        int num;
        for (let mut index: i32 = 0; index <= locCounter; index += 1)
        {
          if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[index].X, this.game.Data.LocObj[index].Y].Regime == this.game.Data.Turn)
            num += 1;
        }
        if (this.game.Data.RegimeObj[this.game.Data.Turn].Sleep)
          num = 0;
        if (num < 1)
        {
          this.surrendering = true;
          windowReturnClass = this.DoSurrenderStuff();
          let mut regimeCounter: i32 = this.game.Data.RegimeCounter;
          for (let mut index: i32 = 0; index <= regimeCounter; index += 1)
          {
            if (!this.game.Data.RegimeObj[index].Sleep & !this.game.Data.RegimeObj[index].AI)
              this.game.EventRelatedObj.Helper_AddDetailedReport(DetailType.ForeignAffairs, this.game.Data.RegimeObj[this.game.Data.Turn].id, this.game.Data.RegimeObj[this.game.Data.Turn].Name + " has been eliminated from the game.", this.game.Data.RegimeObj[index].id);
          }
          if (windowReturnClass.Flag)
            return windowReturnClass;
        }
      }
      if (this.game.EventRelatedObj.Helper_IsDebug() & tMouseButPressed == 2)
      {
        let mut integer: i32 = Conversions.ToInteger(Interaction.InputBox("Run with AI only for howmany rounds?", "Shadow Empire : Planetary Conquest"));
        if (integer > 0)
          this.game.EditObj.debugAiOnlyTillRound = this.game.Data.Round + integer;
        else
          this.game.EditObj.debugAiOnlyTillRound = 0;
      }
      let mut humanPlayers: i32 = this.game.HandyFunctionsObj.GetHumanPlayers();
      this.game.EditObj.DoCardSlot = -1;
      this.game.EditObj.HandCard = -1;
      this.game.EditObj.se1_ManagementMode = false;
      if (humanPlayers < 1)
      {
        this.game.Data = DataClass::new();
        this.game.EditObj = new EditClass(this.game.AppPath + "editobj.txt");
        if (this.game.Data.UseAI == 1 & !Information.IsNothing( this.game.NewAIObj))
          this.game.NewAIObj.LastRegime = -1;
        this.game.EditObj.ShowInitialMenu = true;
        windowReturnClass.AddCommand(3, 12);
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      this.game.FormRef.Cursor = Cursors.WaitCursor;
      if (this.game.EditObj.Screenshoton)
        this.game.HandyFunctionsObj.doscreenshot("b", 0);
      if (this.game.EditObj.AutoSave & !this.game.Data.PBEM)
      {
        this.game.EventRelatedObj.ExecSuperImposeMessage("Ending Turn", "Making an Auto-Save first", 0, 0, "");
        str: String = this.game.AppPath_SAVEGAMES + "autosave_round" + this.game.EditObj.RealRound.ToString() + ".se1";
        this.game.Data.serialize(str);
        this.game.HandyFunctionsObj.ZipFile(str);
        GC.Collect();
        Application.DoEvents();
      }
      if (this.game.EditObj.RealTurn != -1 && !this.game.Data.RegimeObj[this.game.EditObj.RealTurn].AI)
        this.game.EventRelatedObj.DoCheckEvents(5);
      let mut num1: i32 = 0;
      let mut index1: i32 = this.game.EditObj.RealTurn + 1;
      if (this.game.EditObj.RealTurn > this.game.Data.RegimeCounter)
        index1 = 0;
      if (!this.game.Data.RegimeObj[index1].AI & !this.game.Data.RegimeObj[index1].Sleep)
        num1 = 1;
      this.game.HandyFunctionsObj.ClearHistory( this.game.Data.Turn);
      if (num1 > 0 | this.game.EventRelatedObj.Helper_IsDebug() & this.game.EditObj.debugAiOnlyTillRound >= this.game.Data.Round | this.game.Data.DontShowAIMove)
      {
        this.game.EditObj.Test = -1;
        this.game.Data.DontShowAIMove = true;
        this.game.EditObj.HumanPlayer = -1;
        windowReturnClass.AddCommand(3, 13);
      }
      else
      {
        this.game.EditObj.TempAIWatch = true;
        this.game.EditObj.HumanPlayer = this.game.EditObj.RealTurn;
        this.game.se1GameLoop = new GameLoopClass2( this.game);
        this.game.se1GameLoop.Setup();
        this.game.se1Running = true;
        this.game.se1ThreadRunning = true;
        this.game.se1Thread = new Thread(new ThreadStart(this.game.se1GameLoop.handleTimer));
        this.game.se1Thread.Name = "Game Loop Thread";
        this.game.se1Thread.Start();
        windowReturnClass.AddCommand(3, 16);
      }
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
    }

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (this.game.EditObj.TutOrder > -1)
        return windowReturnClass;
      if (this.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 = this.SubPartCounter;
        for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            let mut num: i32 = this.SubPartID[index];
            if (num == this.cinButId)
            {
              windowReturnClass.AddCommand(3, 22);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.advice)
            {
              this.game.EditObj.BlockAdvice = false;
              this.game.EditObj.TempBlockAdvice = false;
              if (this.game.EditObj.SetViewMode2 > 0)
              {
                this.game.EditObj.SetViewMode2 = 0;
                windowReturnClass.AddCommand(1, 9);
                windowReturnClass.AddCommand(7, 12);
                windowReturnClass.SetFlag(true);
              }
              this.dostuff();
              windowReturnClass.AddCommand(2, 119);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.special1)
            {
              this.game.EditObj.PopupValue = 23;
              windowReturnClass.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.special2)
            {
              this.game.EditObj.PopupValue = 24;
              windowReturnClass.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.special3)
            {
              this.game.EditObj.PopupValue = 25;
              windowReturnClass.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.butNextTurnId)
            {
              this.game.Data.DontShowAIMove = this.game.EditObj.dontShowAImoves;
              this.game.EditObj.se1_ManagementMode = false;
              this.game.Data.RegimeObj[this.game.Data.Turn].Version = 110;
              this.game.Data.RegimeObj[this.game.Data.Turn].subVersion = ".04b";
              if (this.game.EventRelatedObj.Helper_IsDebug())
                this.game.Data.DontShowAIMove = true;
              return this.DoEndTurnStuff(b);
            }
            if (num == this.butNextTurnId2)
            {
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.butHistoryId)
            {
              this.game.EditObj.LayerSupplyOn = false;
              this.game.EditObj.OrderType = 26;
              windowReturnClass.AddCommand(3, 16);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.butPlayId)
            {
              this.game.EditObj.TempCoordList = CoordList::new();
              windowReturnClass.AddCommand(3, 11);
              this.game.EditObj.OrderType = 0;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
          }
        }
      }
      let mut mouseCounter: i32 = this.MouseCounter;
      for (let mut index: i32 = 0; index <= mouseCounter; index += 1)
      {
        if (this.MouseData[index] > 0)
        {
          if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
          {
            let mut num: i32 = this.MouseData[index];
            switch (num)
            {
              case 2001:
                this.game.EditObj.se1_ManagementMode = false;
                this.game.EditObj.TempCoordList = CoordList::new();
                this.game.EditObj.OrderType = 0;
                windowReturnClass.AddCommand(3, 11);
                this.game.EditObj.OrderType = 0;
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              case 2002:
                this.game.EditObj.se1_ManagementMode = false;
                this.game.EditObj.LayerSupplyOn = false;
                this.game.EditObj.OrderType = 26;
                windowReturnClass.AddCommand(3, 16);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              case 2003:
                this.game.EditObj.OrderType = 0;
                windowReturnClass.AddCommand(3, 22);
                this.game.EditObj.se1_ManagementMode = false;
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              case 2004:
                this.game.EditObj.se1_ManagementMode = true;
                windowReturnClass.AddCommand(3, 24);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              default:
                if (num == this.game.EditObj.SetViewMode2)
                {
                  if (this.game.EditObj.GuiDown | this.game.EditObj.RightDown)
                  {
                    this.game.EditObj.GuiDown = false;
                    this.game.EditObj.RightDown = false;
                    this.game.EditObj.SetViewMode2 = 0;
                    windowReturnClass.SetFlag(true);
                    windowReturnClass.AddCommand(3, 11);
                    return windowReturnClass;
                  }
                  this.game.EditObj.SetViewMode2 = 0;
                  this.dostuff();
                  windowReturnClass.AddCommand(1, 9);
                  windowReturnClass.AddCommand(7, 12);
                  windowReturnClass.SetFlag(true);
                  windowReturnClass.NoMouseClickBelow = true;
                  return windowReturnClass;
                }
                switch (num)
                {
                  case 1:
                    if (this.game.EditObj.SetViewMode2 == 1)
                    {
                      this.game.EditObj.SetViewMode2 = 0;
                      this.dostuff();
                      windowReturnClass.AddCommand(1, 9);
                      windowReturnClass.AddCommand(7, 12);
                      windowReturnClass.SetFlag(true);
                      windowReturnClass.NoMouseClickBelow = true;
                      return windowReturnClass;
                    }
                    this.game.EditObj.SetViewMode2 = 1;
                    this.DoRefresh();
                    windowReturnClass.AddCommand(1, 9);
                    windowReturnClass.AddCommand(7, 12);
                    windowReturnClass.AddCommand(2, 70);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  case 2:
                    if (this.game.EditObj.SetViewMode2 == 2)
                    {
                      this.game.EditObj.SetViewMode2 = 0;
                      this.dostuff();
                      windowReturnClass.AddCommand(1, 9);
                      windowReturnClass.AddCommand(7, 12);
                      windowReturnClass.SetFlag(true);
                      windowReturnClass.NoMouseClickBelow = true;
                      return windowReturnClass;
                    }
                    this.game.EditObj.SetViewMode2 = 2;
                    this.DoRefresh();
                    windowReturnClass.AddCommand(1, 9);
                    windowReturnClass.AddCommand(7, 12);
                    windowReturnClass.AddCommand(2, 71);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  case 3:
                    if (this.game.EditObj.SetViewMode2 == 3)
                    {
                      this.game.EditObj.SetViewMode2 = 0;
                      this.dostuff();
                      windowReturnClass.AddCommand(1, 9);
                      windowReturnClass.AddCommand(7, 12);
                      windowReturnClass.SetFlag(true);
                      windowReturnClass.NoMouseClickBelow = true;
                      return windowReturnClass;
                    }
                    this.game.EditObj.SetViewMode2 = 3;
                    this.DoRefresh();
                    windowReturnClass.AddCommand(1, 9);
                    windowReturnClass.AddCommand(7, 12);
                    windowReturnClass.AddCommand(2, 72);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  case 4:
                    if (this.game.EditObj.SetViewMode2 == 4)
                    {
                      this.game.EditObj.SetViewMode2 = 0;
                      this.dostuff();
                      windowReturnClass.AddCommand(1, 9);
                      windowReturnClass.AddCommand(7, 12);
                      windowReturnClass.SetFlag(true);
                      windowReturnClass.NoMouseClickBelow = true;
                      return windowReturnClass;
                    }
                    this.game.EditObj.SetViewMode2 = 4;
                    this.DoRefresh();
                    windowReturnClass.AddCommand(1, 9);
                    windowReturnClass.AddCommand(7, 12);
                    windowReturnClass.AddCommand(2, 73);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  case 5:
                    if (this.game.EditObj.SetViewMode2 == 5)
                    {
                      this.game.EditObj.SetViewMode2 = 0;
                      this.dostuff();
                      windowReturnClass.AddCommand(1, 9);
                      windowReturnClass.AddCommand(7, 12);
                      windowReturnClass.SetFlag(true);
                      windowReturnClass.NoMouseClickBelow = true;
                      return windowReturnClass;
                    }
                    this.game.EditObj.SetViewMode2 = 5;
                    this.DoRefresh();
                    if (this.game.ScreenHeight < 920)
                    {
                      this.game.EditObj.GuiDown = true;
                      windowReturnClass.AddCommand(3, 11);
                    }
                    else
                    {
                      windowReturnClass.AddCommand(1, 9);
                      windowReturnClass.AddCommand(7, 12);
                      windowReturnClass.AddCommand(2, 74);
                    }
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  case 6:
                    if (this.game.EditObj.SetViewMode2 == 6)
                    {
                      this.game.EditObj.SetViewMode2 = 0;
                      this.dostuff();
                      windowReturnClass.AddCommand(1, 9);
                      windowReturnClass.AddCommand(7, 12);
                      windowReturnClass.SetFlag(true);
                      windowReturnClass.NoMouseClickBelow = true;
                      return windowReturnClass;
                    }
                    this.game.EditObj.SetViewMode2 = 6;
                    this.DoRefresh();
                    windowReturnClass.AddCommand(1, 9);
                    windowReturnClass.AddCommand(7, 12);
                    windowReturnClass.AddCommand(2, 75);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  case 7:
                    if (this.game.EditObj.SetViewMode2 == 7)
                    {
                      this.game.EditObj.SetViewMode2 = 0;
                      this.dostuff();
                      windowReturnClass.AddCommand(1, 9);
                      windowReturnClass.AddCommand(7, 12);
                      windowReturnClass.SetFlag(true);
                      windowReturnClass.NoMouseClickBelow = true;
                      return windowReturnClass;
                    }
                    this.game.EditObj.SetViewMode2 = 7;
                    this.DoRefresh();
                    windowReturnClass.AddCommand(1, 9);
                    windowReturnClass.AddCommand(7, 12);
                    windowReturnClass.AddCommand(2, 76);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  case 8:
                    if (this.game.EditObj.SetViewMode2 == 8)
                    {
                      this.game.EditObj.SetViewMode2 = 0;
                      this.dostuff();
                      windowReturnClass.AddCommand(1, 9);
                      windowReturnClass.AddCommand(7, 12);
                      windowReturnClass.SetFlag(true);
                      windowReturnClass.NoMouseClickBelow = true;
                      return windowReturnClass;
                    }
                    this.game.EditObj.SetViewMode2 = 8;
                    this.DoRefresh();
                    windowReturnClass.AddCommand(1, 9);
                    windowReturnClass.AddCommand(7, 12);
                    windowReturnClass.AddCommand(2, 77);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  case 9:
                    if (this.game.EditObj.SetViewMode2 == 9)
                    {
                      this.game.EditObj.SetViewMode2 = 0;
                      this.dostuff();
                      windowReturnClass.AddCommand(1, 9);
                      windowReturnClass.AddCommand(7, 12);
                      windowReturnClass.SetFlag(true);
                      windowReturnClass.NoMouseClickBelow = true;
                      return windowReturnClass;
                    }
                    this.game.EditObj.SetViewMode2 = 9;
                    this.DoRefresh();
                    windowReturnClass.AddCommand(1, 9);
                    windowReturnClass.AddCommand(7, 12);
                    windowReturnClass.AddCommand(2, 110);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  case 11:
                    if (this.game.EditObj.SetViewMode2 == 11)
                    {
                      this.game.EditObj.SetViewMode2 = 0;
                      this.dostuff();
                      windowReturnClass.AddCommand(1, 9);
                      windowReturnClass.AddCommand(7, 12);
                      windowReturnClass.SetFlag(true);
                      windowReturnClass.NoMouseClickBelow = true;
                      return windowReturnClass;
                    }
                    this.game.EditObj.SetViewMode2 = 11;
                    this.DoRefresh();
                    if (this.game.ScreenHeight < 920 & this.game.ScreenWidth < 1465)
                    {
                      this.game.EditObj.GuiDown = true;
                      this.game.EditObj.RightDown = true;
                      windowReturnClass.AddCommand(3, 11);
                    }
                    else if (this.game.ScreenHeight < 920)
                    {
                      this.game.EditObj.GuiDown = true;
                      windowReturnClass.AddCommand(3, 11);
                    }
                    else if (this.game.ScreenWidth < 1465)
                    {
                      this.game.EditObj.RightDown = true;
                      windowReturnClass.AddCommand(3, 11);
                    }
                    else
                    {
                      windowReturnClass.AddCommand(1, 9);
                      windowReturnClass.AddCommand(7, 12);
                      windowReturnClass.AddCommand(2, 113);
                    }
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  case 12:
                    if (this.game.EditObj.SetViewMode2 == 12)
                    {
                      this.game.EditObj.SetViewMode2 = 0;
                      this.dostuff();
                      windowReturnClass.AddCommand(1, 9);
                      windowReturnClass.AddCommand(7, 12);
                      windowReturnClass.SetFlag(true);
                      windowReturnClass.NoMouseClickBelow = true;
                      return windowReturnClass;
                    }
                    this.game.EditObj.SetViewMode2 = 12;
                    this.DoRefresh();
                    if (this.game.ScreenHeight < 920 & this.game.ScreenWidth < 1465)
                    {
                      this.game.EditObj.GuiDown = true;
                      this.game.EditObj.RightDown = true;
                      windowReturnClass.AddCommand(3, 11);
                    }
                    else if (this.game.ScreenHeight < 920)
                    {
                      this.game.EditObj.GuiDown = true;
                      windowReturnClass.AddCommand(3, 11);
                    }
                    else if (this.game.ScreenWidth < 1465)
                    {
                      this.game.EditObj.RightDown = true;
                      windowReturnClass.AddCommand(3, 11);
                    }
                    else
                    {
                      windowReturnClass.AddCommand(1, 9);
                      windowReturnClass.AddCommand(7, 12);
                      windowReturnClass.AddCommand(2, 113);
                    }
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  case 13:
                    if (this.game.EditObj.SetViewMode2 == 13)
                    {
                      this.game.EditObj.SetViewMode2 = 0;
                      this.dostuff();
                      windowReturnClass.AddCommand(1, 9);
                      windowReturnClass.AddCommand(7, 12);
                      windowReturnClass.SetFlag(true);
                      windowReturnClass.NoMouseClickBelow = true;
                      return windowReturnClass;
                    }
                    this.game.EditObj.SetViewMode2 = 13;
                    this.DoRefresh();
                    if (this.game.ScreenHeight < 920 & this.game.ScreenWidth < 1465)
                    {
                      this.game.EditObj.GuiDown = true;
                      this.game.EditObj.RightDown = true;
                      windowReturnClass.AddCommand(3, 11);
                    }
                    else if (this.game.ScreenHeight < 920)
                    {
                      this.game.EditObj.GuiDown = true;
                      windowReturnClass.AddCommand(3, 11);
                    }
                    else if (this.game.ScreenWidth < 1465)
                    {
                      this.game.EditObj.RightDown = true;
                      windowReturnClass.AddCommand(3, 11);
                    }
                    else
                    {
                      windowReturnClass.AddCommand(1, 9);
                      windowReturnClass.AddCommand(7, 12);
                      windowReturnClass.AddCommand(2, 113);
                    }
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  case 51:
                    this.game.EditObj.se1_ManagementTab = 51;
                    windowReturnClass.AddCommand(1, 12);
                    windowReturnClass.AddCommand(1, 67);
                    windowReturnClass.AddCommand(2, 12);
                    windowReturnClass.AddCommand(2, 67);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  case 52:
                    this.game.EditObj.se1_ManagementTab = 52;
                    windowReturnClass.AddCommand(1, 12);
                    windowReturnClass.AddCommand(1, 67);
                    windowReturnClass.AddCommand(2, 12);
                    windowReturnClass.AddCommand(2, 67);
                    windowReturnClass.AddCommand(7, 67);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  case 53:
                    this.game.EditObj.se1_ManagementTab = 53;
                    windowReturnClass.AddCommand(1, 12);
                    windowReturnClass.AddCommand(1, 67);
                    windowReturnClass.AddCommand(2, 12);
                    windowReturnClass.AddCommand(2, 67);
                    windowReturnClass.AddCommand(7, 67);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  case 54:
                    this.game.EditObj.se1_ManagementTab = 54;
                    windowReturnClass.AddCommand(1, 12);
                    windowReturnClass.AddCommand(1, 67);
                    windowReturnClass.AddCommand(2, 12);
                    windowReturnClass.AddCommand(2, 67);
                    windowReturnClass.AddCommand(7, 67);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  case 55:
                    this.game.EditObj.se1_ManagementTab = 55;
                    windowReturnClass.AddCommand(1, 12);
                    windowReturnClass.AddCommand(1, 67);
                    windowReturnClass.AddCommand(2, 12);
                    windowReturnClass.AddCommand(2, 67);
                    windowReturnClass.AddCommand(7, 67);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  case 56:
                    this.game.EditObj.se1_ManagementTab = 56;
                    windowReturnClass.AddCommand(1, 12);
                    windowReturnClass.AddCommand(1, 67);
                    windowReturnClass.AddCommand(2, 12);
                    windowReturnClass.AddCommand(2, 67);
                    windowReturnClass.AddCommand(7, 67);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  case 57:
                    this.game.EditObj.se1_ManagementTab = 57;
                    windowReturnClass.AddCommand(1, 12);
                    windowReturnClass.AddCommand(1, 67);
                    windowReturnClass.AddCommand(2, 12);
                    windowReturnClass.AddCommand(2, 67);
                    windowReturnClass.AddCommand(7, 67);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  case 501:
                    if (this.game.EditObj.OrderType == 26)
                    {
                      this.game.EditObj.TempCoordList = CoordList::new();
                      this.game.HandyFunctionsObj.SetInitialXY(this.game.EditObj.RealTurn);
                      this.game.EditObj.UnitSelected = -1;
                      if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter > -1)
                        this.game.EditObj.UnitSelected = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitList[0];
                      windowReturnClass.AddCommand(4, 12);
                      windowReturnClass.AddCommand(4, 80);
                      windowReturnClass.AddCommand(4, 67);
                      windowReturnClass.AddCommand(4, 81);
                      windowReturnClass.AddCommand(4, 9);
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    this.game.EditObj.TempCoordList = CoordList::new();
                    this.game.HandyFunctionsObj.SetInitialXY(this.game.EditObj.RealTurn);
                    this.game.EditObj.UnitSelected = -1;
                    if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter > -1)
                      this.game.EditObj.UnitSelected = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitList[0];
                    windowReturnClass.AddCommand(3, 11);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  default:
                    continue;
                }
            }
          }
        }
        else if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height && this.MouseData[index] == -2)
        {
          if (this.game.EditObj.SetViewMode2 > 0)
          {
            this.game.EditObj.SetViewMode2 = 0;
            this.dostuff();
            windowReturnClass.AddCommand(1, 9);
            windowReturnClass.AddCommand(7, 12);
            windowReturnClass.SetFlag(true);
          }
          windowReturnClass.NoMouseClickBelow = true;
          return windowReturnClass;
        }
      }
      if (y < 32)
      {
        if (this.game.EditObj.SetViewMode2 > 0)
        {
          this.game.EditObj.SetViewMode2 = 0;
          this.dostuff();
          windowReturnClass.AddCommand(1, 9);
          windowReturnClass.AddCommand(7, 12);
          windowReturnClass.SetFlag(true);
        }
        windowReturnClass.NoMouseClickBelow = true;
        return windowReturnClass;
      }
      if (y < 64 &&  x >  this.w / 2.0 - 158.0 &  x <  this.w / 2.0 + 158.0)
        windowReturnClass.NoMouseClickBelow = true;
      if (x < 583 & y <= 70)
        windowReturnClass.NoMouseClickBelow = true;
      if (x > this.game.ScreenWidth - 735 & y <= 60)
        windowReturnClass.NoMouseClickBelow = true;
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    pub HandleKeyPress: WindowReturnClass(int nr, bool fromTimer = false)
    {
      windowReturnClass1: WindowReturnClass = WindowReturnClass::new();
      if (this.screenVid > -1 & nr == 86)
      {
        windowReturnClass2: WindowReturnClass = this.HandleMouseClick(this.MouseRect[this.screenVid].X + 1, this.MouseRect[this.screenVid].Y + 1, 1);
        windowReturnClass2.SetFlag(true);
        return windowReturnClass2;
      }
      if (this.screenHis > -1 & nr == 72)
      {
        windowReturnClass3: WindowReturnClass = this.HandleMouseClick(this.MouseRect[this.screenHis].X + 1, this.MouseRect[this.screenHis].Y + 1, 1);
        windowReturnClass3.SetFlag(true);
        return windowReturnClass3;
      }
      if (this.screenMan > -1 & nr == 78)
      {
        windowReturnClass4: WindowReturnClass = this.HandleMouseClick(this.MouseRect[this.screenMan].X + 1, this.MouseRect[this.screenMan].Y + 1, 1);
        windowReturnClass4.SetFlag(true);
        return windowReturnClass4;
      }
      if (this.screenMap > -1 & nr == 27)
      {
        windowReturnClass5: WindowReturnClass = this.HandleMouseClick(this.MouseRect[this.screenMap].X + 1, this.MouseRect[this.screenMap].Y + 1, 1);
        windowReturnClass5.SetFlag(true);
        return windowReturnClass5;
      }
      if (this.game.EditObj.OrderType != 26 && this.screenMap < 0 && nr == 67)
      {
        let mut integer: i32 = Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(this.game.SelectX, this.game.SelectY, "SE_Data", "Zones"));
        let mut stringListById: i32 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0));
        if (integer > 0)
        {
          let mut id: i32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(0, integer, 6)));
          if (this.game.EventRelatedObj.CheckRegimeSlot( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(0, integer, 8))), 0, 0, 0) == this.game.Data.Turn)
          {
            let mut index: i32 = -1;
            if (id > 0)
              index = this.game.HandyFunctionsObj.GetLocationByID(id);
            let mut num: i32 = -1;
            if (index > -1)
              num = this.game.Data.LocObj[index].HQ;
            if (num > -1)
            {
              this.game.EditObj.UDSpopupText = "";
              this.formref.Cursor = Cursors.WaitCursor;
              this.game.EditObj.UDSClearInput();
              this.game.EventRelatedObj.SetUDSKey("ZONE", integer);
              let mut eventByLib: i32 = this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 106, 0, 0);
              this.game.EventRelatedObj.DoCheckSpecificEvent(eventByLib);
              this.game.EditObj.udsLastCalledPopupEventNr = eventByLib;
              this.formref.Cursor = Cursors.Default;
              this.game.EditObj.PopupValue = 21;
              windowReturnClass1.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
          }
        }
      }
      if (nr == 112 & this.tab1 > -1)
      {
        windowReturnClass6: WindowReturnClass = this.HandleMouseClick(this.MouseRect[this.tab1].X + 1, this.MouseRect[this.tab1].Y + 1, 1);
        windowReturnClass6.SetFlag(true);
        return windowReturnClass6;
      }
      if (nr == 112 & this.game.EditObj.SetViewMode2 > 0)
      {
        this.game.EditObj.SetViewMode2 = 0;
        this.dostuff();
        windowReturnClass1.AddCommand(1, 9);
        windowReturnClass1.AddCommand(7, 12);
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (nr == 113 & this.tab3 > -1)
      {
        windowReturnClass7: WindowReturnClass = this.HandleMouseClick(this.MouseRect[this.tab3].X + 1, this.MouseRect[this.tab3].Y + 1, 1);
        windowReturnClass7.SetFlag(true);
        return windowReturnClass7;
      }
      if (nr == 113 & this.game.EditObj.SetViewMode2 > 0)
      {
        this.game.EditObj.SetViewMode2 = 0;
        this.dostuff();
        windowReturnClass1.AddCommand(1, 9);
        windowReturnClass1.AddCommand(7, 12);
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (nr == 114 & this.tab4 > -1)
      {
        windowReturnClass8: WindowReturnClass = this.HandleMouseClick(this.MouseRect[this.tab4].X + 1, this.MouseRect[this.tab4].Y + 1, 1);
        windowReturnClass8.SetFlag(true);
        return windowReturnClass8;
      }
      if (nr == 114 & this.game.EditObj.SetViewMode2 > 0)
      {
        this.game.EditObj.SetViewMode2 = 0;
        this.dostuff();
        windowReturnClass1.AddCommand(1, 9);
        windowReturnClass1.AddCommand(7, 12);
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (nr == 115 & this.tab7 > -1)
      {
        windowReturnClass9: WindowReturnClass = this.HandleMouseClick(this.MouseRect[this.tab7].X + 1, this.MouseRect[this.tab7].Y + 1, 1);
        windowReturnClass9.SetFlag(true);
        return windowReturnClass9;
      }
      if (nr == 115 & this.game.EditObj.SetViewMode2 > 0)
      {
        this.game.EditObj.SetViewMode2 = 0;
        this.dostuff();
        windowReturnClass1.AddCommand(1, 9);
        windowReturnClass1.AddCommand(7, 12);
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (nr == 116 & this.tab6 > -1)
      {
        windowReturnClass10: WindowReturnClass = this.HandleMouseClick(this.MouseRect[this.tab6].X + 1, this.MouseRect[this.tab6].Y + 1, 1);
        windowReturnClass10.SetFlag(true);
        return windowReturnClass10;
      }
      if (nr == 116 & this.game.EditObj.SetViewMode2 > 0)
      {
        this.game.EditObj.SetViewMode2 = 0;
        this.dostuff();
        windowReturnClass1.AddCommand(1, 9);
        windowReturnClass1.AddCommand(7, 12);
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (nr == 117 & this.tab11 > -1)
      {
        windowReturnClass11: WindowReturnClass = this.HandleMouseClick(this.MouseRect[this.tab11].X + 1, this.MouseRect[this.tab11].Y + 1, 1);
        windowReturnClass11.SetFlag(true);
        return windowReturnClass11;
      }
      if (nr == 117 & this.game.EditObj.SetViewMode2 > 0)
      {
        this.game.EditObj.SetViewMode2 = 0;
        this.dostuff();
        windowReturnClass1.AddCommand(1, 9);
        windowReturnClass1.AddCommand(7, 12);
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (nr == 118 & this.tab12 > -1)
      {
        windowReturnClass12: WindowReturnClass = this.HandleMouseClick(this.MouseRect[this.tab12].X + 1, this.MouseRect[this.tab12].Y + 1, 1);
        windowReturnClass12.SetFlag(true);
        return windowReturnClass12;
      }
      if (nr == 118 & this.game.EditObj.SetViewMode2 > 0)
      {
        this.game.EditObj.SetViewMode2 = 0;
        this.dostuff();
        windowReturnClass1.AddCommand(1, 9);
        windowReturnClass1.AddCommand(7, 12);
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (nr == 119 & this.tab8 > -1)
      {
        windowReturnClass13: WindowReturnClass = this.HandleMouseClick(this.MouseRect[this.tab8].X + 1, this.MouseRect[this.tab8].Y + 1, 1);
        windowReturnClass13.SetFlag(true);
        return windowReturnClass13;
      }
      if (nr == 119 & this.game.EditObj.SetViewMode2 > 0)
      {
        this.game.EditObj.SetViewMode2 = 0;
        this.dostuff();
        windowReturnClass1.AddCommand(1, 9);
        windowReturnClass1.AddCommand(7, 12);
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (nr == 27 & this.game.EditObj.SetViewMode2 > 0 && this.game.EditObj.OrderType != 26)
      {
        this.game.EditObj.SetViewMode2 = 0;
        if (this.game.EditObj.GuiDown | this.game.EditObj.RightDown)
        {
          this.game.EditObj.GuiDown = false;
          this.game.EditObj.RightDown = false;
          this.game.EditObj.SetViewMode2 = 0;
          windowReturnClass1.AddCommand(3, 11);
        }
        else
        {
          this.dostuff();
          windowReturnClass1.AddCommand(1, 9);
          windowReturnClass1.AddCommand(7, 12);
        }
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (this.game.EventRelatedObj.Helper_IsDebug() && nr == 68)
        this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 210, 0, 0))].SetData2(0, this.game.Data.RegimeObj[this.game.EditObj.RealTurn].id, 1, Interaction.InputBox("Change which regimekey?"), 2,  Math.Round(Conversion.Val(Interaction.InputBox("What new value?"))));
      return windowReturnClass1;
    }

    pub DoSurrenderStuff: WindowReturnClass()
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      this.game.EditObj.UnitSelected = -1;
      this.game.EditObj.OrderUnit = -1;
      this.game.EditObj.OrderTarget = -1;
      this.game.EditObj.OldUnit = -1;
      let mut humanPlayers: i32 = this.game.HandyFunctionsObj.GetHumanPlayers();
      if (!this.game.Data.RegimeObj[this.game.Data.Turn].AI & this.game.Data.RegimeObj[this.game.Data.Turn].Sleep)
        humanPlayers += 1;
      if (humanPlayers != 2 && humanPlayers != 1 && this.game.Data.Product < 7 && this.game.Data.PbemGameID < 1)
        this.game.EventRelatedObj.ExecJoinRegime(this.game.Data.Turn, -1, 0, 0, "");
      if (humanPlayers > 2)
      {
        for (let mut unitCounter: i32 = this.game.Data.UnitCounter; unitCounter >= 0; unitCounter += -1)
        {
          if (this.game.Data.UnitObj[unitCounter].Regime == this.game.Data.Turn & this.game.Data.UnitObj[unitCounter].PreDef == -1)
          {
            data: DataClass = this.game.Data;
            let mut nr: i32 = unitCounter;
            let mut gameClass: GameClass = (GameClass) null;
             let mut local: GameClass =  gameClass;
            data.RemoveUnit(nr,  local);
          }
        }
      }
      if ( this.game.Data.RuleVar[978] < 1.0)
      {
        this.game.Data.LastWinner = this.game.Data.Winner;
        if (this.game.Data.PbemGameID < 1)
          this.game.Data.RegimeObj[this.game.Data.Turn].Sleep = true;
      }
      if (humanPlayers > 1 |  this.game.Data.RuleVar[978] > 0.0 | this.game.Data.PbemGameID > 0 | this.game.Data.Product == 7 & humanPlayers > 1)
      {
        windowReturnClass.SetFlag(false);
      }
      else
      {
        this.game.Data = DataClass::new();
        this.game.EditObj = new EditClass(this.game.AppPath + "editobj.txt");
        if (this.game.Data.UseAI == 1)
        {
          if (Information.IsNothing( this.game.NewAIObj))
            this.game.NewAIObj = new NewAIClass(this.game);
          this.game.NewAIObj.LastRegime = -1;
        }
        this.game.EditObj.ShowInitialMenu = true;
        windowReturnClass.AddCommand(3, 12);
        windowReturnClass.SetFlag(true);
      }
      return windowReturnClass;
    }
  }
}
