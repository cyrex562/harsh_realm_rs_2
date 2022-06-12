// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ResourceWindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class ResourceWindowClass2 : WindowClass
  {
    private int Info1Id;
    private int info2id;
    private string ShowString;
    private DateTime ShowTime;
    private int w;
    private int h;
    private bool AskingAboutMetrics;
    private int CurrentView;
    private int tab1;
    private int tab2;
    private int tab3;
    private int tab4;
    private int tab5;
    private int tab6;
    private int tab7;
    private int tab8;
    private int tab9;
    private int tab1a;
    private int tab2a;
    private int tab3a;
    private int tab4a;
    private int tab5a;
    private int tab6a;
    private int tab7a;
    private int tab8a;
    private int tab9a;
    private int tab13;
    private int tab11;
    private int tab12;
    private string tab13name;
    private string tab11name;
    private string tab12name;
    private int butNextTurnId;
    private int butNextTurnId2;
    private int butHistoryId;
    private int butPlayId;
    private int currentPlayerId;
    private int cinButId;
    private int MouseOverWhichTab;
    private int smallAiProgress;
    private int prevAiProgress;
    private bool startedInHistoryMode;
    private bool surrendering;
    private int special1;
    private int special2;
    private int special3;
    private int advice;
    private int adviceB;
    private int screenHis;
    private int screenVid;
    private int screenMan;
    private int screenMap;

    public ResourceWindowClass2(
      ref GameClass tGame,
      ref WindowClass tLowerWindow,
      ref Rectangle tLowerRect)
      : base(ref tGame, tGame.ScreenWidth, 75, 8)
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

    public override WindowReturnClass handleTimer()
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      if (this.game.EditObj.HumanPlayer > -1 && this.game.EditObj.AIMoving && (double) DateAndTime.Now.Subtract(this.ShowTime).Ticks > 2000000.0)
      {
        this.ShowTime = DateAndTime.Now;
        this.dostuff();
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (this.game.EditObj.udsManagementTabOverrideId > 0)
      {
        int mouseCounter = this.MouseCounter;
        for (int index = 0; index <= mouseCounter; ++index)
        {
          if (this.MouseData[index] == this.game.EditObj.SetViewMode2)
          {
            this.game.EditObj.SetViewMode2 = 0;
            WindowReturnClass windowReturnClass2 = this.HandleMouseClick(this.MouseRect[index].X + 1, this.MouseRect[index].Y + 1, 1);
            windowReturnClass2.SetFlag(true);
            return windowReturnClass2;
          }
        }
      }
      if (this.game.EditObj.udsViewMode2Override > 0)
      {
        if (this.game.EditObj.SetViewMode2 != this.game.EditObj.udsViewMode2Override)
        {
          int mouseCounter = this.MouseCounter;
          for (int index = 0; index <= mouseCounter; ++index)
          {
            if (this.MouseData[index] == this.game.EditObj.udsViewMode2Override)
            {
              this.game.EditObj.udsViewMode2Override = -1;
              WindowReturnClass windowReturnClass3 = this.HandleMouseClick(this.MouseRect[index].X + 1, this.MouseRect[index].Y + 1, 1);
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
        ref System.Type local = ref type;
        if (screeny.WindowPresent(ref local))
        {
          string str = "Collecting metrics data on your gameplay really helps with fine-tuning the game.\r\nWill you allow this game to share some metrics data with the developers?";
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

    public override WindowReturnClass HandleMouseMove(int x, int y)
    {
      WindowReturnClass windowReturnClass = base.HandleMouseMove(x, y);
      if (y < 60 && x > 100 & x < this.game.ScreenWidth - 175)
        windowReturnClass.NoMouseClickBelow = true;
      int num = -1;
      for (int mouseCounter = this.MouseCounter; mouseCounter >= 0; mouseCounter += -1)
      {
        if (this.MouseData[mouseCounter] > 0 && x > this.MouseRect[mouseCounter].X & x < this.MouseRect[mouseCounter].X + this.MouseRect[mouseCounter].Width && y > this.MouseRect[mouseCounter].Y & y < this.MouseRect[mouseCounter].Y + this.MouseRect[mouseCounter].Height)
          num = this.MouseData[mouseCounter];
      }
      if (num > 0)
      {
        if (this.MouseOverWhichTab != num)
        {
          if (this.game.EmpireStyle)
            SoundMod.PlayAWave(this.game.AppPath + "sound/interface/mouseover.wav", ref this.game.EditObj);
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

    public override void DoRefresh()
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

    public void dostuff()
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
        this.DrawOpenTab((object) graphics);
      int tx1 = 312;
      bool flag1 = false;
      int width;
      if ((double) this.game.Data.RuleVar[971] > 0.0)
      {
        int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[971]));
        if (stringListById > -1 && this.game.Data.StringListObj[stringListById].Length > -1)
          flag1 = true;
        width = 100;
        if (!flag1)
          ;
      }
      bool flag2 = false;
      int num1 = 68;
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
        this.AddMouse(ref trect1, "", "Inaccesible during the AIs turn.");
        int tx2 = tx1 + num1;
        Rectangle trect2 = this.DrawOneTab(graphics, true, tx2, "HIS", -1) with
        {
          Y = 36
        };
        trect2.Height -= 36;
        this.AddMouse(ref trect2, "", "You are currently in HISTORY mode. While the AI is playing.");
        int tx3 = tx2 + num1;
        trect2 = this.DrawOneTab(graphics, false, tx3, "VID", -1, grayedOut: true) with
        {
          Y = 36
        };
        trect2.Height -= 36;
        this.AddMouse(ref trect2, "", "Inaccesible during the AIs turn.");
        int tx4 = tx3 + num1;
        trect2 = this.DrawOneTab(graphics, false, tx4, "MNG", -1, grayedOut: true) with
        {
          Y = 36
        };
        trect2.Height -= 36;
        this.AddMouse(ref trect2, "", "Inaccesible during the AIs turn.");
      }
      else if ((double) this.game.Data.RuleVar[408] > 1.0)
      {
        if (this.game.EditObj.OrderType == 26 | this.startedInHistoryMode)
        {
          Rectangle trect = this.DrawOneTab(graphics, false, tx1, "MAP", -1, MousingOverNow: (this.MouseOverWhichTab == 2001)) with
          {
            Y = 36
          };
          trect.Height -= 36;
          this.AddMouse(ref trect, "", "Click to got to MAP mode [Shortkey Escape]", 2001);
          this.screenMap = this.MouseCounter;
          int tx5 = tx1 + num1;
          trect = this.DrawOneTab(graphics, true, tx5, "HIS", -1, MousingOverNow: (this.MouseOverWhichTab == 2002)) with
          {
            Y = 36
          };
          trect.Height -= 36;
          this.AddMouse(ref trect, "", "You are currently in HISTORY mode", 2002);
          int tx6 = tx5 + num1;
          int tx7;
          if (flag1)
          {
            trect = this.DrawOneTab(graphics, false, tx6, "VID", -1, MousingOverNow: (this.MouseOverWhichTab == 2003)) with
            {
              Y = 36
            };
            trect.Height -= 36;
            this.AddMouse(ref trect, "", "Click to go to VIDCOM mode [Shortkey V]", 2003);
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
            this.AddMouse(ref trect, "", "There are no VIDCOM messages or reports available");
            tx7 = tx6 + num1;
          }
          trect = this.DrawOneTab(graphics, false, tx7, "MNG", -1, MousingOverNow: (this.MouseOverWhichTab == 2004)) with
          {
            Y = 36
          };
          trect.Height -= 36;
          this.AddMouse(ref trect, "", "Go to MANAGEMENT SCREEN mode  [Shortkey N]", 2004);
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
            this.AddMouse(ref trect, "", "Click to got to MAP mode [Shortkey Escape]", 2001);
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
            this.AddMouse(ref trect, "", "You are currently in MAP mode");
            tx8 = tx1 + num1;
          }
          trect = this.DrawOneTab(graphics, false, tx8, "HIS", -1, MousingOverNow: (this.MouseOverWhichTab == 2002)) with
          {
            Y = 36
          };
          trect.Height -= 36;
          this.AddMouse(ref trect, "", "Click to go to HISTORY mode [Shortkey H]", 2002);
          this.screenHis = this.MouseCounter;
          int tx9 = tx8 + num1;
          int tx10;
          if (flag1)
          {
            trect = this.DrawOneTab(graphics, false, tx9, "VID", -1, MousingOverNow: (this.MouseOverWhichTab == 2003)) with
            {
              Y = 36
            };
            trect.Height -= 36;
            this.AddMouse(ref trect, "", "Click to go to VIDCOM mode [Shortkey V]", 2003);
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
            this.AddMouse(ref trect, "", "There are no VIDCOM messages or reports available");
            tx10 = tx9 + num1;
          }
          if (this.game.EditObj.se1_ManagementMode)
          {
            trect = this.DrawOneTab(graphics, true, tx10, "MNG", -1) with
            {
              Y = 36
            };
            trect.Height -= 36;
            this.AddMouse(ref trect, "", "You are currently in MANAGEMENT SCREEN mode");
            num2 = tx10 + num1;
          }
          else
          {
            trect = this.DrawOneTab(graphics, false, tx10, "MNG", -1, MousingOverNow: (this.MouseOverWhichTab == 2004)) with
            {
              Y = 36
            };
            trect.Height -= 36;
            this.AddMouse(ref trect, "", "Go to MANAGEMENT SCREEN mode [Shortkey N]", 2004);
            this.screenMan = this.MouseCounter;
            num2 = tx10 + num1;
          }
        }
      }
      ref Graphics local1 = ref graphics;
      Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
      ref Bitmap local2 = ref bitmap;
      Rectangle trect3 = new Rectangle(0, 140, 300, 63);
      Rectangle srcrect1 = trect3;
      Rectangle rectangle = new Rectangle(0, 0, 300, 63);
      Rectangle destrect1 = rectangle;
      DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
      if (this.game.ScreenWidth > 2600)
      {
        width = (int) Math.Round((double) this.game.ScreenWidth / 2.0);
        ref Graphics local3 = ref graphics;
        bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
        ref Bitmap local4 = ref bitmap;
        rectangle = new Rectangle(300, 140, width, 32);
        Rectangle srcrect2 = rectangle;
        trect3 = new Rectangle(300, 0, width, 32);
        Rectangle destrect2 = trect3;
        DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
        ref Graphics local5 = ref graphics;
        bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
        ref Bitmap local6 = ref bitmap;
        rectangle = new Rectangle(0, 140, width, 32);
        Rectangle srcrect3 = rectangle;
        trect3 = new Rectangle(300 + width, 0, width, 32);
        Rectangle destrect3 = trect3;
        DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
        if (!flag2)
        {
          ref Graphics local7 = ref graphics;
          bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
          ref Bitmap local8 = ref bitmap;
          rectangle = new Rectangle(this.w - width - 150, 140, 150, 75);
          Rectangle srcrect4 = rectangle;
          trect3 = new Rectangle(this.w - 150, 0, 150, 75);
          Rectangle destrect4 = trect3;
          DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
        }
        if (flag2)
        {
          ref Graphics local9 = ref graphics;
          bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
          ref Bitmap local10 = ref bitmap;
          rectangle = new Rectangle(this.w - width - 150, 140, 150, 32);
          Rectangle srcrect5 = rectangle;
          trect3 = new Rectangle(this.w - 150, 0, 150, 32);
          Rectangle destrect5 = trect3;
          DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
        }
      }
      else
      {
        ref Graphics local11 = ref graphics;
        bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
        ref Bitmap local12 = ref bitmap;
        rectangle = new Rectangle(300, 140, this.w - 440, 32);
        Rectangle srcrect6 = rectangle;
        trect3 = new Rectangle(300, 0, this.w - 440, 32);
        Rectangle destrect6 = trect3;
        DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
        if (!flag2)
        {
          ref Graphics local13 = ref graphics;
          bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
          ref Bitmap local14 = ref bitmap;
          rectangle = new Rectangle(this.w - 150, 140, 150, 75);
          Rectangle srcrect7 = rectangle;
          trect3 = new Rectangle(this.w - 150, 0, 150, 75);
          Rectangle destrect7 = trect3;
          DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect7, destrect7);
        }
        if (flag2)
        {
          ref Graphics local15 = ref graphics;
          bitmap = BitmapStore.GetBitmap(this.game.MARCBOTBAR);
          ref Bitmap local16 = ref bitmap;
          rectangle = new Rectangle(this.w - width - 150, 140, 150, 32);
          Rectangle srcrect8 = rectangle;
          trect3 = new Rectangle(this.w - 150, 0, 150, 32);
          Rectangle destrect8 = trect3;
          DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect8, destrect8);
        }
      }
      int x1 = 290;
      if (flag2)
      {
        for (; x1 < this.game.ScreenWidth; x1 += 50)
        {
          ref Graphics local17 = ref graphics;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_BOTTOM);
          ref Bitmap local18 = ref bitmap;
          rectangle = new Rectangle(15, 22, 50, 20);
          Rectangle srcrect9 = rectangle;
          trect3 = new Rectangle(x1, 22, 50, 20);
          Rectangle destrect9 = trect3;
          DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect9, destrect9);
        }
      }
      else
      {
        for (; x1 < this.game.ScreenWidth - 120; x1 += 50)
        {
          ref Graphics local19 = ref graphics;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_BOTTOM);
          ref Bitmap local20 = ref bitmap;
          rectangle = new Rectangle(15, 22, 50, 20);
          Rectangle srcrect10 = rectangle;
          trect3 = new Rectangle(x1, 22, 50, 20);
          Rectangle destrect10 = trect3;
          DrawMod.DrawSimplePart2(ref local19, ref local20, srcrect10, destrect10);
        }
        ref Graphics local21 = ref graphics;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_BOTTOM);
        ref Bitmap local22 = ref bitmap;
        rectangle = new Rectangle(0, 22, 15, 20);
        Rectangle srcrect11 = rectangle;
        trect3 = new Rectangle(300, 22, 15, 20);
        Rectangle destrect11 = trect3;
        DrawMod.DrawSimplePart2(ref local21, ref local22, srcrect11, destrect11);
        ref Graphics local23 = ref graphics;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_BOTTOM);
        ref Bitmap local24 = ref bitmap;
        rectangle = new Rectangle(65, 22, 15, 20);
        Rectangle srcrect12 = rectangle;
        trect3 = new Rectangle(this.w - 187 - 15, 22, 15, 20);
        Rectangle destrect12 = trect3;
        DrawMod.DrawSimplePart2(ref local23, ref local24, srcrect12, destrect12);
      }
      if (this.game.EditObj.se1_ManagementMode)
        this.DrawTabs_ManagementScreen((object) graphics);
      else
        this.DrawTabs((object) graphics);
      ref Graphics local25 = ref graphics;
      bitmap = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_LEFT);
      ref Bitmap local26 = ref bitmap;
      DrawMod.DrawSimple(ref local25, ref local26, 0, 0);
      bool flag3 = true;
      if ((int) Math.Round(Conversion.Val(this.game.Data.Designer)) >= 43)
      {
        int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Present", 79, 0, 0));
        int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 191, 0, 0));
        if (this.game.Data.StringListObj[stringListById2].Width >= 27)
        {
          for (int length = this.game.Data.StringListObj[stringListById1].Length; length >= 0; length += -1)
          {
            int idValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[length, 11]));
            width = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, idValue, 27)));
            if (width > 0)
              flag3 = false;
          }
        }
      }
      if (!flag2)
      {
        ref Graphics local27 = ref graphics;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_RIGHT);
        ref Bitmap local28 = ref bitmap;
        int x2 = this.w - 190;
        DrawMod.DrawSimple(ref local27, ref local28, x2, 0);
        if (flag3)
        {
          if (this.butNextTurnId == 0)
          {
            SubPartClass tsubpart = (SubPartClass) new SEButtonPartClass(this.game.SE1_ARROW1, "End your turn. Let the other players make their moves.", 54, 39);
            this.butNextTurnId = this.AddSubPart(ref tsubpart, this.w - 190 + 126, 9, 54, 39, 1);
          }
        }
        else if (this.butNextTurnId2 == 0)
        {
          SubPartClass tsubpart = (SubPartClass) new SEButtonPartClass(this.game.CANCELBALL, "You cannot end your move as there is still a Decision left that is OBLIGATORY to make.", 54, 39);
          this.butNextTurnId2 = this.AddSubPart(ref tsubpart, this.w - 190 + 126, 9, 54, 39, 1);
        }
      }
      if (!flag2)
      {
        this.DrawDate(ref graphics);
        this.DrawPP(ref graphics);
      }
      int index = this.game.EditObj.RealTurn;
      bool flag4 = false;
      if (this.game.EditObj.RealTurn == -1)
        width = width;
      if (this.game.EditObj.RealTurn > this.game.Data.RegimeCounter)
        ;
      if (flag2 && this.game.EditObj.RealTurn > -1 & this.game.EditObj.RealTurn != this.game.Data.Turn & this.game.Data.Turn > -1)
      {
        int stringListById = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 275, 0, 0));
        try
        {
          if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData3(0, this.game.Data.RegimeObj[this.game.EditObj.RealTurn].id, 1, this.game.Data.RegimeObj[this.game.Data.Turn].id, 2, "recon", 3))) > 0)
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
      string str = this.game.Data.RegimeObj[index].Name;
      if (flag4)
        str = "Unknown Regime";
      graphics.MeasureString(str, DrawMod.TGame.MarcFont16);
      if (flag2)
      {
        this.smallAiProgress += 5;
        if (this.game.EditObj.AIProgressNow != this.prevAiProgress)
          this.smallAiProgress = 0;
        this.prevAiProgress = this.game.EditObj.AIProgressNow;
        int num3 = (int) Math.Round((double) this.game.EditObj.AIProgressNow / (double) this.game.EditObj.AIProgressMax * 100.0);
        if (num3 > 100)
          num3 = 100;
        int num4 = (int) Math.Round((double) (84 * num3) / 100.0);
        int num5 = this.smallAiProgress;
        if (num5 > 50)
          num5 = (int) Math.Round(Math.Sqrt((double) (num5 - 50))) + 50;
        if (num5 > 70)
          num5 = (int) Math.Round(Math.Sqrt((double) (num5 - 70))) + 70;
        if (num5 > 90)
          num5 = (int) Math.Round(Math.Sqrt((double) (num5 - 70))) + 90;
        if (num5 > 100)
          num5 = 100;
        int w = num4 + (int) Math.Round((double) (83 * num5) / 100.0);
        DrawMod.DrawBlock(ref graphics, 111, 18, w, 16, 200, 0, 0, 150);
      }
      DrawMod.DrawTextColouredConsoleCenter(ref graphics, str, this.game.MarcFont16, 193, 15, this.game.seColWhite);
      if (this.currentPlayerId < 1)
      {
        if (flag2)
        {
          rectangle = new Rectangle(108, 15, 173, 21);
          trect3 = rectangle;
          this.AddMouse(ref trect3, "Current player is " + this.game.Data.RegimeObj[index].Name, "This AI is currently making its moves.");
        }
        else if (this.game.EditObj.se1_ManagementMode)
        {
          rectangle = new Rectangle(108, 15, 173, 21);
          trect3 = rectangle;
          this.AddMouse(ref trect3, "Current player is " + this.game.Data.RegimeObj[index].Name, "Yes, this is you.");
        }
        else
        {
          rectangle = new Rectangle(108, 15, 173, 21);
          trect3 = rectangle;
          this.AddMouse(ref trect3, "Current player is " + this.game.Data.RegimeObj[index].Name, "Click to go to capitol of this regime.", 501);
        }
      }
      int num6 = this.game.Data.RegimeObj[index].Red;
      int num7 = this.game.Data.RegimeObj[index].Green;
      int num8 = this.game.Data.RegimeObj[index].Blue;
      int num9 = this.game.Data.RegimeObj[index].Red2;
      int num10 = this.game.Data.RegimeObj[index].Green2;
      int num11 = this.game.Data.RegimeObj[index].Blue2;
      if (this.MouseOverWhichTab == 501)
      {
        num6 = (int) Math.Round((double) num6 * 1.1);
        num7 = (int) Math.Round((double) num7 * 1.1);
        num8 = (int) Math.Round((double) num8 * 1.1);
        num9 = (int) Math.Round((double) num9 * 1.1);
        num10 = (int) Math.Round((double) num10 * 1.1);
        num11 = (int) Math.Round((double) num11 * 1.1);
        if (num6 > (int) byte.MaxValue)
          num6 = (int) byte.MaxValue;
        if (num7 > (int) byte.MaxValue)
          num7 = (int) byte.MaxValue;
        if (num8 > (int) byte.MaxValue)
          num8 = (int) byte.MaxValue;
        if (num9 > (int) byte.MaxValue)
          num9 = (int) byte.MaxValue;
        if (num10 > (int) byte.MaxValue)
          num10 = (int) byte.MaxValue;
        if (num11 > (int) byte.MaxValue)
          num11 = (int) byte.MaxValue;
      }
      if (flag4)
      {
        num6 = (int) Math.Round((double) num6 / 2.0);
        num7 = (int) Math.Round((double) num7 / 2.0);
        num8 = (int) Math.Round((double) num8 / 2.0);
        num9 = (int) Math.Round((double) num9 / 2.0);
        num10 = (int) Math.Round((double) num10 / 2.0);
        num11 = (int) Math.Round((double) num11 / 2.0);
      }
      int bannerSpriteNr = this.game.Data.RegimeObj[index].BannerSpriteNr;
      ref Graphics local29 = ref graphics;
      bitmap = BitmapStore.GetBitmap(bannerSpriteNr);
      ref Bitmap local30 = ref bitmap;
      double r1 = (double) ((float) num6 / (float) byte.MaxValue);
      double g1 = (double) ((float) num7 / (float) byte.MaxValue);
      double b1 = (double) ((float) num8 / (float) byte.MaxValue);
      DrawMod.DrawScaledColorized2(ref local29, ref local30, 13, 15, 80, 60, 124, 210, (float) r1, (float) g1, (float) b1, 1f);
      int bannerSpriteNr2 = this.game.Data.RegimeObj[index].BannerSpriteNr2;
      if (bannerSpriteNr2 > 0)
      {
        ref Graphics local31 = ref graphics;
        bitmap = BitmapStore.GetBitmap(bannerSpriteNr2);
        ref Bitmap local32 = ref bitmap;
        double r2 = (double) ((float) num9 / (float) byte.MaxValue);
        double g2 = (double) ((float) num10 / (float) byte.MaxValue);
        double b2 = (double) ((float) num11 / (float) byte.MaxValue);
        DrawMod.DrawScaledColorized2(ref local31, ref local32, 13, 15, 80, 60, 124, 210, (float) r2, (float) g2, (float) b2, 1f);
      }
      int hqSpriteNr2 = this.game.Data.RegimeObj[index].HQSpriteNr2;
      if (hqSpriteNr2 > 0)
      {
        ref Graphics local33 = ref graphics;
        bitmap = BitmapStore.GetBitmap(hqSpriteNr2);
        ref Bitmap local34 = ref bitmap;
        double r3 = (double) ((float) this.game.Data.RegimeObj[index].Red3 / (float) byte.MaxValue) - 1.0;
        double g3 = (double) ((float) this.game.Data.RegimeObj[index].Green3 / (float) byte.MaxValue) - 1.0;
        double b3 = (double) ((float) this.game.Data.RegimeObj[index].Blue3 / (float) byte.MaxValue) - 1.0;
        DrawMod.Draw(ref local33, ref local34, 30, 27, (float) r3, (float) g3, (float) b3, 0.95f);
      }
      if (this.currentPlayerId < 1)
      {
        if (flag2)
        {
          if (flag4)
          {
            rectangle = new Rectangle(0, 0, 100, 75);
            trect3 = rectangle;
            this.AddMouse(ref trect3, "Current AI player is unknown. ", "This AI is currently making its moves.");
          }
          else if (this.game.EditObj.se1_ManagementMode)
          {
            rectangle = new Rectangle(0, 0, 100, 75);
            trect3 = rectangle;
            this.AddMouse(ref trect3, "Current player is " + this.game.Data.RegimeObj[index].Name, "Yes, this is you.");
          }
          else
          {
            rectangle = new Rectangle(0, 0, 100, 75);
            trect3 = rectangle;
            this.AddMouse(ref trect3, "Current player is " + this.game.Data.RegimeObj[index].Name, "This AI is currently making its moves.");
          }
        }
        else if (this.game.EditObj.se1_ManagementMode)
        {
          rectangle = new Rectangle(0, 0, 100, 75);
          trect3 = rectangle;
          this.AddMouse(ref trect3, "Current player is " + this.game.Data.RegimeObj[index].Name, "Yes, this is you.");
        }
        else
        {
          rectangle = new Rectangle(0, 0, 100, 75);
          trect3 = rectangle;
          this.AddMouse(ref trect3, "Current player is " + this.game.Data.RegimeObj[this.game.EditObj.RealTurn].Name, "Click to go to capitol of this regime.", 501);
        }
      }
      if (Information.IsNothing((object) graphics))
        return;
      graphics.Dispose();
      graphics = (Graphics) null;
    }

    public Rectangle DrawOneTab(
      Graphics g,
      bool active,
      int tx,
      string s,
      int iconSlot,
      int smallNumber = -1,
      bool grayedOut = false,
      bool MousingOverNow = false)
    {
      int y1 = 0;
      if (!active)
        y1 = -12;
      Bitmap bitmap;
      if (MousingOverNow)
      {
        ref Graphics local1 = ref g;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_TAB);
        ref Bitmap local2 = ref bitmap;
        int x = tx;
        int y2 = y1;
        DrawMod.Draw(ref local1, ref local2, x, y2, 0.05f, 0.05f, 0.05f, 1f);
      }
      else
      {
        ref Graphics local3 = ref g;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_TAB);
        ref Bitmap local4 = ref bitmap;
        int x = tx;
        int y3 = y1;
        DrawMod.DrawSimple(ref local3, ref local4, x, y3);
      }
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (iconSlot > -1)
      {
        if (grayedOut)
        {
          ref Graphics local5 = ref g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
          ref Bitmap local6 = ref bitmap;
          rectangle1 = new Rectangle(iconSlot * 42, 0, 42, 32);
          Rectangle srcrect = rectangle1;
          rectangle2 = new Rectangle(tx + 11, y1 + 20, 42, 32);
          Rectangle destrect = rectangle2;
          DrawMod.DrawSimplePart2Coloured(ref local5, ref local6, srcrect, destrect, 0.5f, 0.5f, 0.5f, 1f);
        }
        else if (MousingOverNow & !active)
        {
          ref Graphics local7 = ref g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
          ref Bitmap local8 = ref bitmap;
          rectangle2 = new Rectangle(iconSlot * 42, 32, 42, 32);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(tx + 11, y1 + 20, 42, 32);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect, destrect);
        }
        else
        {
          if (!active)
          {
            ref Graphics local9 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
            ref Bitmap local10 = ref bitmap;
            rectangle2 = new Rectangle(iconSlot * 42, 0, 42, 32);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(tx + 11, y1 + 20, 42, 32);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect, destrect);
          }
          if (active)
          {
            ref Graphics local11 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
            ref Bitmap local12 = ref bitmap;
            rectangle2 = new Rectangle(iconSlot * 42, 32, 42, 32);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(tx + 11, y1 + 20, 42, 32);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect, destrect);
          }
        }
      }
      Color c;
      if (smallNumber > 0)
      {
        if (!active)
        {
          ref Graphics local13 = ref g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONHIGHLIGHT);
          ref Bitmap local14 = ref bitmap;
          rectangle2 = new Rectangle(0, 0, 42, 32);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(tx + 11, y1 + 20, 42, 32);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect, destrect);
          c = Color.FromArgb((int) byte.MaxValue, 225, 215, 215);
        }
        if (active)
        {
          ref Graphics local15 = ref g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONHIGHLIGHT);
          ref Bitmap local16 = ref bitmap;
          rectangle2 = new Rectangle(0, 32, 42, 32);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(tx + 11, y1 + 20, 42, 32);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect, destrect);
          c = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 245, 245);
        }
        string str = smallNumber.ToString();
        if (smallNumber > 9)
          str = "X";
        SizeF sizeF = g.MeasureString(str, DrawMod.TGame.MarcFont5);
        DrawMod.DrawTextColouredConsole(ref g, str, this.game.MarcFont5, tx + (int) Math.Round((68.0 - (double) sizeF.Width) / 2.0) + 11, y1 + 22, c);
      }
      SizeF sizeF1 = g.MeasureString(s, DrawMod.TGame.MarcFont16);
      if (active)
        c = this.game.seColWhite;
      if (!active)
        c = this.game.seColGray;
      if (grayedOut)
        c = Color.FromArgb((int) byte.MaxValue, 128, 128, 128);
      DrawMod.DrawTextColouredConsole(ref g, s, this.game.MarcFont16, tx + (int) Math.Round((68.0 - (double) sizeF1.Width) / 2.0), y1 + 48, c);
      Rectangle rectangle3 = new Rectangle(tx, y1, 68, 75);
      tx += 68;
      return rectangle3;
    }

    public void DrawOpenTab(object g)
    {
      if (this.CurrentView <= 0)
        return;
      Rectangle rectForTab = DrawMod.GetRectForTab(this.CurrentView);
      Graphics graphics = (Graphics) g;
      ref Graphics local1 = ref graphics;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.MARCTAB);
      ref Bitmap local2 = ref bitmap1;
      Rectangle rectangle1 = new Rectangle(0, 20, 8, 43);
      Rectangle srcrect1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(rectForTab.X, 32, 8, 43);
      Rectangle destrect1 = rectangle2;
      DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
      g = (object) graphics;
      graphics = (Graphics) g;
      ref Graphics local3 = ref graphics;
      Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.MARCTAB);
      ref Bitmap local4 = ref bitmap2;
      rectangle2 = new Rectangle(170, 20, 16, 43);
      Rectangle srcrect2 = rectangle2;
      rectangle1 = new Rectangle(rectForTab.X + rectForTab.Width - 16, 32, 16, 43);
      Rectangle destrect2 = rectangle1;
      DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
      g = (object) graphics;
      int x = rectForTab.X + 8;
      int width = 160;
      for (; x < rectForTab.X + rectForTab.Width; x += 160)
      {
        if (x + width > rectForTab.X + rectForTab.Width - 16)
          width = rectForTab.X + rectForTab.Width - 16 - x;
        graphics = (Graphics) g;
        ref Graphics local5 = ref graphics;
        Bitmap bitmap3 = BitmapStore.GetBitmap(this.game.MARCTAB);
        ref Bitmap local6 = ref bitmap3;
        rectangle2 = new Rectangle(10, 20, width, 43);
        Rectangle srcrect3 = rectangle2;
        rectangle1 = new Rectangle(x, 32, width, 43);
        Rectangle destrect3 = rectangle1;
        DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
        g = (object) graphics;
      }
    }

    public void DrawTabs(object g)
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
        int tx1 = this.game.ScreenWidth - 734;
        Rectangle trect2 = this.DrawOneTab((Graphics) g, this.CurrentView == 8, tx1, "PREFS", 0, MousingOverNow: (this.MouseOverWhichTab == 8));
        this.AddMouse(ref trect2, "PREFERENCES", "Sound and other customizable settings. [F1]", 8);
        this.tab1 = this.MouseCounter;
        int tx2 = tx1 + 68;
        Rectangle trect3 = this.DrawOneTab((Graphics) g, this.CurrentView == 2, tx2, "STATS", 2, MousingOverNow: (this.MouseOverWhichTab == 2));
        this.AddMouse(ref trect3, "STATISTICS", "Review kills, losses and Regime information [F3]", 2);
        this.tab3 = this.MouseCounter;
        int tx3 = tx2 + 68;
        Rectangle trect4 = this.DrawOneTab((Graphics) g, this.CurrentView == 3, tx3, "OOB", 1, MousingOverNow: (this.MouseOverWhichTab == 3));
        this.AddMouse(ref trect4, "ORDER OF BATTLE", "Review all your units. [F4]", 3);
        this.tab4 = this.MouseCounter;
        int tx4 = tx3 + 68;
        Rectangle trect5 = this.DrawOneTab((Graphics) g, this.CurrentView == 6, tx4, "S.MAP", 3, MousingOverNow: (this.MouseOverWhichTab == 6));
        this.AddMouse(ref trect5, "STRATEGIC MAP", "View the strategic situation and send messages. [F7]", 6);
        this.tab7 = this.MouseCounter;
        int tx5 = tx4 + 68;
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
          this.AddMouse(ref trect6, "STRATAGEMS", "View your stratagems and play them. [F6]", 5);
          this.tab6 = this.MouseCounter;
          tx6 = tx5 + 68;
        }
        if (this.tab11name.Length > 1)
        {
          int smanagementTabPageCount = this.game.HandyFunctionsObj.GetUDSmanagementTabPageCount(1);
          if (smanagementTabPageCount > 0)
          {
            trect1 = this.DrawOneTab((Graphics) g, this.CurrentView == 11, tx6, this.tab11name, 5, smanagementTabPageCount, MousingOverNow: (this.MouseOverWhichTab == 11));
            this.AddMouse(ref trect1, this.tab11name, "Make decisions awaiting you", 11);
            this.tab11 = this.MouseCounter;
            tx6 += 68;
          }
          else
          {
            trect1 = this.DrawOneTab((Graphics) g, this.CurrentView == 11, tx6, this.tab11name, 5, grayedOut: true);
            this.AddMouse(ref trect1, this.tab11name, "No decisions to be taken", -2);
            this.tab11 = this.MouseCounter;
            tx6 += 68;
          }
        }
        if (this.tab12name.Length > 1 && this.game.HandyFunctionsObj.GetUDSmanagementTabPageCount(2) > 0)
        {
          trect1 = this.DrawOneTab((Graphics) g, this.CurrentView == 12, tx6, this.tab12name, 6, MousingOverNow: (this.MouseOverWhichTab == 12));
          this.AddMouse(ref trect1, this.tab12name, "Reports and letters received this turn", 12);
          this.tab12 = this.MouseCounter;
          int num = tx6 + 68;
        }
      }
      int tx = this.game.ScreenWidth - 258;
      trect1 = this.DrawOneTab((Graphics) g, this.CurrentView == 7, tx, "MINI", 7, MousingOverNow: (this.MouseOverWhichTab == 7));
      this.AddMouse(ref trect1, "MINIMAP", "View the mini-map. [F8]", 7);
      this.tab8 = this.MouseCounter;
    }

    public void DrawTabs_ManagementScreen(object g)
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
      int tx1 = 650;
      Rectangle trect1 = this.DrawOneTab((Graphics) g, this.game.EditObj.se1_ManagementTab == 54, tx1, "ASSET", 46, MousingOverNow: (this.MouseOverWhichTab == 54));
      this.AddMouse(ref trect1, "ASSET MANAGEMENT WINDOW", "Inspect and give orders to all your Assets", 54);
      this.tab4a = this.MouseCounter;
      int tx2 = tx1 + 68;
      Rectangle trect2 = this.DrawOneTab((Graphics) g, this.game.EditObj.se1_ManagementTab == 55, tx2, "MODEL", 47, MousingOverNow: (this.MouseOverWhichTab == 55));
      this.AddMouse(ref trect2, "MODEL & QUALITY LEVEL MANAGEMENT WINDOW", "Inspect and set Quality Levels for all your Models and Units", 55);
      this.tab5a = this.MouseCounter;
      int tx3 = tx2 + 68;
      Rectangle trect3 = this.DrawOneTab((Graphics) g, this.game.EditObj.se1_ManagementTab == 56, tx3, "LEADER", 43, MousingOverNow: (this.MouseOverWhichTab == 56));
      this.AddMouse(ref trect3, "LEADER MANAGEMENT WINDOW", "Inspect and review all your Leaders", 56);
      this.tab6a = this.MouseCounter;
      int tx4 = tx3 + 68;
      Rectangle trect4 = this.DrawOneTab((Graphics) g, this.game.EditObj.se1_ManagementTab <= 51, tx4, "PROF", 12, MousingOverNow: (this.MouseOverWhichTab <= 51));
      this.AddMouse(ref trect4, "PROFILE INFO", "Inspect your Regime Feats progress", 51);
      this.tab1a = this.MouseCounter;
      int tx5 = tx4 + 68;
      Rectangle trect5 = this.DrawOneTab((Graphics) g, this.game.EditObj.se1_ManagementTab == 52, tx5, "TECH", 1, MousingOverNow: (this.MouseOverWhichTab == 52));
      this.AddMouse(ref trect5, "TECH TREE INFO", "Inspect your Tech tree progress", 52);
      this.tab2a = this.MouseCounter;
      int tx6 = tx5 + 68;
      Rectangle trect6 = this.DrawOneTab((Graphics) g, this.game.EditObj.se1_ManagementTab == 53, tx6, "TYPE", 41, MousingOverNow: (this.MouseOverWhichTab == 53));
      this.AddMouse(ref trect6, "MODEL TYPE INFO", "Inspect your Model Type tree progress", 53);
      this.tab3a = this.MouseCounter;
      int tx7 = tx6 + 68;
      if (!this.game.UserDebugger || !(this.game.HandyFunctionsObj.GetHumanPlayers() <= 1 | (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 156, 0, 0))].GetData(0, 17, 2))) > 0))
        return;
      Rectangle trect7 = this.DrawOneTab((Graphics) g, this.game.EditObj.se1_ManagementTab == 57, tx7, "DEBUG", 6, MousingOverNow: (this.MouseOverWhichTab == 57));
      this.AddMouse(ref trect7, "MODEL TYPE INFO", "Inspect your Model Type tree progress", 57);
      this.tab7a = this.MouseCounter;
      int num = tx7 + 68;
    }

    public void DrawHexStats(ref Graphics g)
    {
      int x1 = (int) Math.Round((double) this.game.ScreenWidth / 2.0 + 158.0);
      if (!(this.game.EditObj.RealRound > 0 & this.game.SelectX > -1))
        return;
      SizeF sizeF1 = new SizeF();
      string str1 = "REC";
      SizeF sizeF2 = g.MeasureString(str1, this.game.MarcFont5);
      int x2 = (int) Math.Round((double) ((float) x1 + (float) (15.0 - (double) sizeF2.Width / 2.0)));
      DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont5, x2, 2, Color.White);
      string str2 = Strings.Trim(Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon));
      Color color = (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon >= (double) this.game.Data.RuleVar[55] ? ((double) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon >= (double) this.game.Data.RuleVar[56] ? Color.FromArgb((int) byte.MaxValue, 0, (int) byte.MaxValue, 0) : Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 0)) : Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, 0);
      SizeF sizeF3 = g.MeasureString(str2, this.game.MarcFont5);
      int x3 = (int) Math.Round((double) ((float) x1 + (float) (15.0 - (double) sizeF3.Width / 2.0)));
      DrawMod.DrawTextColouredMarc(ref g, str2, this.game.MarcFont5, x3, 15, Color.White);
      Rectangle trect1 = new Rectangle(x1, 2, 30, 28);
      this.AddMouse(ref trect1, "RECON POINTS", "How much recon points you have on hex.\r\n" + Strings.Trim(Conversion.Str((object) this.game.Data.RuleVar[55])) + " points needed to spot a unit.\r\n" + Strings.Trim(Conversion.Str((object) this.game.Data.RuleVar[56])) + " points needed for full info on unit.");
      int x4 = x1 + 30;
      DrawMod.DrawBlockGradient2(ref g, x4 - 2, 0, 3, 32, Color.FromArgb(200, 80, 90, 110), Color.FromArgb(50, 80, 90, 110));
      string str3 = "ZOC";
      SizeF sizeF4 = g.MeasureString(str3, this.game.MarcFont5);
      int x5 = (int) Math.Round((double) ((float) x4 + (float) (15.0 - (double) sizeF4.Width / 2.0)));
      DrawMod.DrawTextColouredMarc(ref g, str3, this.game.MarcFont5, x5, 2, Color.White);
      string str4 = Strings.Trim(Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].get_ZocPts(this.game.EditObj.RealTurn)));
      SizeF sizeF5 = g.MeasureString(str4, this.game.MarcFont5);
      int x6 = (int) Math.Round((double) ((float) x4 + (float) (15.0 - (double) sizeF5.Width / 2.0)));
      DrawMod.DrawTextColouredMarc(ref g, str4, this.game.MarcFont5, x6, 15, Color.White);
      trect1 = new Rectangle(x4, 2, 30, 28);
      Rectangle trect2 = trect1;
      this.AddMouse(ref trect2, "ZONE OF CONTROL POINTS", "Shows how many ZOC points you are exerting on the hex.\r\n" + Strings.Trim(Conversion.Str((object) this.game.Data.RuleVar[40])) + "x more ZOC needed then enemy to capture unoccupied hex.");
      int x7 = x4 + 30;
      DrawMod.DrawBlockGradient2(ref g, x7 - 2, 0, 3, 32, Color.FromArgb(200, 80, 90, 110), Color.FromArgb(50, 80, 90, 110));
      string str5 = "AP";
      SizeF sizeF6 = g.MeasureString(str5, this.game.MarcFont5);
      int x8 = (int) Math.Round((double) ((float) x7 + (float) (15.0 - (double) sizeF6.Width / 2.0)));
      DrawMod.DrawTextColouredMarc(ref g, str5, this.game.MarcFont5, x8, 2, Color.White);
      string str6 = Strings.Trim(Conversion.Str((object) (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].get_APPenalty(this.game.EditObj.RealTurn) + this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].get_BattlePenalty(this.game.EditObj.RealTurn))));
      sizeF6 = g.MeasureString(str6, this.game.MarcFont5);
      int x9 = (int) Math.Round((double) ((float) x7 + (float) (15.0 - (double) sizeF6.Width / 2.0)));
      DrawMod.DrawTextColouredMarc(ref g, str6, this.game.MarcFont5, x9, 15, Color.White);
      string ttext = "How much extra AP it costs to move into hex.\r\n" + Strings.Trim(Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].get_APPenalty(this.game.EditObj.RealTurn))) + " points for enemy owned hex rule." + "\r\n" + Strings.Trim(Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].get_BattlePenalty(this.game.EditObj.RealTurn))) + " points for previous battles fought in hex.";
      trect1 = new Rectangle(x7, 2, 30, 28);
      Rectangle trect3 = trect1;
      this.AddMouse(ref trect3, "ACTION POINT PENALTIES", ttext);
      int x10 = x7 + 30;
      DrawMod.DrawBlockGradient2(ref g, x10 - 2, 0, 3, 32, Color.FromArgb(200, 80, 90, 110), Color.FromArgb(50, 80, 90, 110));
      string str7 = "STK";
      sizeF6 = g.MeasureString(str7, this.game.MarcFont5);
      int x11 = (int) Math.Round((double) ((float) x10 + (float) (15.0 - (double) sizeF6.Width / 2.0)));
      DrawMod.DrawTextColouredMarc(ref g, str7, this.game.MarcFont5, x11, 2, Color.White);
      string str8 = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetHexStackPts(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected)));
      if (this.game.Data.FOWOn)
      {
        if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime > -1 && !this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime, this.game.EditObj.RealTurn))
          str8 = "?";
        if (this.game.EditObj.UnitSelected > -1 && !this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.EditObj.RealTurn))
          str8 = "?";
      }
      if (Operators.CompareString(str8, "?", false) == 0)
      {
        int unitCounter = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter;
        int num;
        for (int index = 0; index <= unitCounter; ++index)
        {
          int unit = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitList[index];
          num += this.game.HandyFunctionsObj.GetStackWithFOW(unit, this.game.EditObj.RealTurn);
        }
        if (num > 0)
          str8 = num.ToString();
      }
      sizeF6 = g.MeasureString(str8, this.game.MarcFont5);
      int x12 = (int) Math.Round((double) ((float) x10 + (float) (15.0 - (double) sizeF6.Width / 2.0)));
      DrawMod.DrawTextColouredMarc(ref g, str8, this.game.MarcFont5, x12, 15, Color.White);
      trect1 = new Rectangle(x10, 2, 30, 28);
      Rectangle trect4 = trect1;
      this.AddMouse(ref trect4, "STACK POINTS", "How much stack points are in this hex.\r\nAbove " + Strings.Trim(Conversion.Str((object) this.game.Data.RuleVar[30])) + " points the hex becomes overstacked.");
      int x13 = x10 + 30;
      DrawMod.DrawBlockGradient2(ref g, x13 - 2, 0, 3, 32, Color.FromArgb(200, 80, 90, 110), Color.FromArgb(50, 80, 90, 110));
      string str9 = "VP";
      sizeF6 = g.MeasureString(str9, this.game.MarcFont5);
      int x14 = (int) Math.Round((double) ((float) x13 + (float) (15.0 - (double) sizeF6.Width / 2.0)));
      DrawMod.DrawTextColouredMarc(ref g, str9, this.game.MarcFont5, x14, 2, Color.White);
      string str10 = Strings.Trim(Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].VP));
      sizeF6 = g.MeasureString(str10, this.game.MarcFont5);
      int x15 = (int) Math.Round((double) ((float) x13 + (float) (15.0 - (double) sizeF6.Width / 2.0)));
      DrawMod.DrawTextColouredMarc(ref g, str10, this.game.MarcFont5, x15, 15, Color.White);
      trect1 = new Rectangle(x13, 2, 30, 28);
      Rectangle trect5 = trect1;
      this.AddMouse(ref trect5, "VICTORY POINTS", "How much VP does hex have.");
    }

    public void DrawScope(ref Graphics g)
    {
      int num1 = (int) Math.Round((double) this.game.ScreenWidth / 2.0 - 158.0);
      if (!(this.game.SelectX > -1 & this.game.SelectY > -1))
        return;
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 370, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0));
      int num2 = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 125, 0, 0))].Length + 1;
      int landscapeType = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType;
      int spriteNr = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].SpriteNr;
      DataClass data = DrawMod.TGame.Data;
      string str1 = "Zones";
      ref string local1 = ref str1;
      int libVar = data.FindLibVar(ref local1, "SE_Data");
      int num3 = 0;
      int hexLibVarValue = DrawMod.TGame.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].GetHexLibVarValue(libVar);
      if (hexLibVarValue > 0)
        num3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, hexLibVarValue, 13)));
      int num4 = (int) Math.Round((double) num3 / (double) num2);
      int eventPicOrigSlot1;
      int eventPicOrigSlot2;
      if (stringListById1 > -1)
      {
        eventPicOrigSlot1 = num4 >= 50 ? (num4 >= 500 ? (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, landscapeType, 3))) : (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, landscapeType, 2)))) : (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, landscapeType, 1)));
        eventPicOrigSlot2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, landscapeType, 6)));
      }
      if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon < 1)
        eventPicOrigSlot2 = 61;
      int eventPic1 = this.game.Data.FindEventPic(eventPicOrigSlot1, "SE_Present");
      int num5;
      int num6;
      Rectangle trect;
      Rectangle rectangle;
      if (eventPic1 > -1)
      {
        int nr = this.game.Data.EventPicNr[eventPic1];
        num5 = 256;
        num6 = 80;
        ref Graphics local2 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(nr);
        ref Bitmap local3 = ref bitmap;
        trect = new Rectangle(0, 0, 256, 65);
        Rectangle srcrect = trect;
        rectangle = new Rectangle(num1 + 31, 0, 256, 65);
        Rectangle destrect = rectangle;
        DrawMod.DrawSimplePart2(ref local2, ref local3, srcrect, destrect);
      }
      int eventPic2 = this.game.Data.FindEventPic(eventPicOrigSlot2, "SE_Present");
      if (eventPic2 > -1)
      {
        int nr = this.game.Data.EventPicNr[eventPic2];
        num5 = 256;
        num6 = 80;
        ref Graphics local4 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(nr);
        ref Bitmap local5 = ref bitmap;
        rectangle = new Rectangle(0, 0, 256, 65);
        Rectangle srcrect = rectangle;
        trect = new Rectangle(num1 + 31, 0, 256, 65);
        Rectangle destrect = trect;
        DrawMod.DrawSimplePart2(ref local4, ref local5, srcrect, destrect);
      }
      ref Graphics local6 = ref g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.MARCSCOPE);
      ref Bitmap local7 = ref bitmap1;
      int x1 = num1;
      DrawMod.DrawSimple(ref local6, ref local7, x1, 0);
      if (!(landscapeType > -1 & spriteNr > -1))
        return;
      string str2 = this.game.HandyFunctionsObj.GetHexName(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
      SizeF sizeF1 = new SizeF();
      SizeF sizeF2 = g.MeasureString(str2, this.game.MarcFont5);
      if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Location > -1)
      {
        int pictureLt = this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Location].Type].PictureLT;
        if (pictureLt > -1)
          str2 = this.game.Data.LandscapeTypeObj[pictureLt].Name.Replace("(System)", "");
      }
      string str3 = str2;
      if ((double) sizeF2.Width < 135.0 & this.w >= 1600)
        str2 = str2 + " (" + Strings.Trim(Conversion.Str((object) this.game.SelectX)) + "," + Strings.Trim(Conversion.Str((object) this.game.SelectY)) + ") ";
      str3 + " (" + Strings.Trim(Conversion.Str((object) this.game.SelectX)) + "," + Strings.Trim(Conversion.Str((object) this.game.SelectY)) + ") ";
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
      string landscapeMouseOverText = this.game.HandyFunctionsObj.GetLandscapeMouseOverText();
      if (1600 > this.w)
      {
        string str5 = Strings.UCase(Strings.Left(str2, 1)) + Strings.Mid(str2, 2);
        int x2 = (int) Math.Round((double) this.w / 2.0 - 115.0 - 75.0 - (double) g.MeasureString(str5, this.game.MarcFont5).Width / 2.0);
        DrawMod.DrawTextColouredMarc(ref g, str5, this.game.MarcFont5, x2, 9, Color.White);
        rectangle = new Rectangle((int) Math.Round((double) this.game.ScreenWidth / 2.0 - 130.0), 0, 100, 62);
        trect = rectangle;
        this.AddMouse(ref trect, str5, landscapeMouseOverText);
        string str6 = str4;
        int x3 = (int) Math.Round((double) this.w / 2.0 + 125.0 + 75.0 - (double) g.MeasureString(str6, this.game.MarcFont5).Width / 2.0);
        DrawMod.DrawTextColouredMarc(ref g, str6, this.game.MarcFont5, x3, 9, Color.White);
      }
      else
      {
        string str7 = Strings.UCase(Strings.Left(str2, 1)) + Strings.Mid(str2, 2);
        int x4 = (int) Math.Round((double) this.w / 2.0 - 175.0 - 75.0 - (double) g.MeasureString(str7, this.game.MarcFont4).Width / 2.0);
        DrawMod.DrawTextColouredMarc(ref g, str7, this.game.MarcFont4, x4, 4, Color.White);
        rectangle = new Rectangle((int) Math.Round((double) this.game.ScreenWidth / 2.0 - 130.0), 0, 260, 62);
        trect = rectangle;
        this.AddMouse(ref trect, str7, landscapeMouseOverText);
        string str8 = str4;
        int x5 = (int) Math.Round((double) this.w / 2.0 + 175.0 + 75.0 - (double) g.MeasureString(str8, this.game.MarcFont4).Width / 2.0);
        if (Operators.CompareString(str8, "Unknown", false) != 0 & Operators.CompareString(str8, "Unclear", false) != 0)
        {
          ref Graphics local8 = ref g;
          Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.Data.RegimeObj[regime].SymbolSpriteNr);
          ref Bitmap local9 = ref bitmap2;
          int x6 = x5 - 24;
          int width = BitmapStore.GetWidth(this.game.Data.RegimeObj[regime].SymbolSpriteNr);
          int origh = BitmapStore.Getheight(this.game.Data.RegimeObj[regime].SymbolSpriteNr);
          double r = (double) ((float) this.game.Data.RegimeObj[regime].Red3 / (float) byte.MaxValue);
          double g1 = (double) ((float) this.game.Data.RegimeObj[regime].Green3 / (float) byte.MaxValue);
          double b = (double) ((float) this.game.Data.RegimeObj[regime].Blue3 / (float) byte.MaxValue);
          DrawMod.DrawScaledColorized2(ref local8, ref local9, x6, 0, 24, 24, width, origh, (float) r, (float) g1, (float) b, (float) byte.MaxValue);
        }
        DrawMod.DrawTextColouredMarc(ref g, str8, this.game.MarcFont4, x5, 4, Color.White);
      }
    }

    public void DrawDate(ref Graphics g)
    {
      if (this.game.EditObj.RealTurn <= -1)
        return;
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 156, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 125, 0, 0));
      int num1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, 14, 2)));
      int num2 = this.game.Data.StringListObj[stringListById2].Length + 1;
      int idValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, 12, 2)));
      this.game.Data.StringListObj[stringListById2].GetData(0, idValue, 1);
      int num3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, 47, 2)));
      int Month = (this.game.EditObj.RealRound + 6) % 6 * 2 - 1;
      if (Month < 1)
        Month = 11;
      if (Information.IsNothing((object) this.game.Data.TurnString))
        this.game.Data.TurnString = "";
      SizeF sizeF = new SizeF();
      string[] strArray = this.game.Data.TurnString.Split(new char[1]
      {
        ','
      }, StringSplitOptions.RemoveEmptyEntries);
      if (strArray.GetUpperBound(0) <= 0)
        return;
      int x1 = this.game.ScreenWidth - 190 + 65 - (int) Math.Round((double) (g.MeasureString(strArray[0], this.game.MarcFont16).Width / 2f));
      DrawMod.DrawTextColouredConsole(ref g, strArray[0], this.game.MarcFont16, x1, 11, Color.LightGray);
      int x2 = this.game.ScreenWidth - 190 + 65 - (int) Math.Round((double) (g.MeasureString(strArray[1], this.game.MarcFont16).Width / 2f));
      DrawMod.DrawTextColouredConsole(ref g, strArray[1], this.game.MarcFont16, x2, 27, Color.LightGray);
      Rectangle trect = new Rectangle(x2, 16, 106, 32);
      this.AddMouse(ref trect, "", "This is Round " + this.game.EditObj.RealRound.ToString() + ".\r\nThis is Local Year " + num3.ToString() + " AA, Season " + idValue.ToString() + " of " + num2.ToString() + ".\r\nThis is Earth Year " + num1.ToString() + "-" + DateAndTime.MonthName(Month, true) + ".");
    }

    public void DrawPP(ref Graphics g)
    {
      if (this.game.EditObj.RealTurn <= -1)
        return;
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 210, 0, 0));
      int id = this.game.Data.RegimeObj[this.game.EditObj.RealTurn].id;
      if (this.game.Data.RegimeObj[this.game.EditObj.RealTurn].AI & (double) this.game.Data.RuleVar[976] == 1.0)
        return;
      SizeF sizeF1 = new SizeF();
      SizeF sizeF2 = new SizeF();
      SizeF sizeF3 = new SizeF();
      SizeF sizeF4 = new SizeF();
      SizeF sizeF5 = new SizeF();
      string data2 = this.game.Data.StringListObj[stringListById1].GetData2(0, id, 1, "fp", 2);
      string str1 = this.game.Data.RegimeObj[this.game.EditObj.RealTurn].ResPts.ToString();
      if (this.game.Data.RegimeObj[this.game.EditObj.RealTurn].ResPts > 9999)
        str1 = ((int) Math.Round((double) this.game.Data.RegimeObj[this.game.EditObj.RealTurn].ResPts / 1000.0)).ToString() + "k";
      else if (this.game.Data.RegimeObj[this.game.EditObj.RealTurn].ResPts > 999)
        str1 = Math.Round((double) this.game.Data.RegimeObj[this.game.EditObj.RealTurn].ResPts / 1000.0, 1).ToString() + "k";
      int num1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData2(0, id, 1, "credits", 2)));
      string str2;
      if (num1 > 9999)
      {
        double num2 = Math.Round((double) num1 / 1000.0, 1);
        str2 = num2.ToString() + "k";
        if (num1 >= 100000)
        {
          num2 = Math.Round((double) num1 / 1000.0, 0);
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
      int x1 = 302;
      int y1 = 0;
      ref Graphics local1 = ref g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_VARBOX);
      ref Bitmap local2 = ref bitmap1;
      int x2 = x1;
      int y2 = y1;
      DrawMod.DrawSimple(ref local1, ref local2, x2, y2);
      Rectangle trect1 = new Rectangle(x1, y1, 74, 28);
      this.AddMouse(ref trect1, "Fate Points", "You need FP’s to play powerful Fate Stratagems.");
      int eventPicSlotFor1 = this.game.EventRelatedObj.GetEventPicSlotFor(0, "", "fp");
      ref Graphics local3 = ref g;
      Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[eventPicSlotFor1]);
      ref Bitmap local4 = ref bitmap2;
      int x3 = x1 + 2;
      DrawMod.DrawSimple(ref local3, ref local4, x3, 6);
      DrawMod.DrawTextColouredConsole(ref g, data2, this.game.MarcFont16, x1 + 31, 4, this.game.seColWhite);
      int x4 = x1 + 75;
      ref Graphics local5 = ref g;
      Bitmap bitmap3 = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_VARBOX);
      ref Bitmap local6 = ref bitmap3;
      int x5 = x4;
      int y3 = y1;
      DrawMod.DrawSimple(ref local5, ref local6, x5, y3);
      trect1 = new Rectangle(x4, y1, 74, 28);
      Rectangle trect2 = trect1;
      this.AddMouse(ref trect2, "Political Points", "You need PP’s to play organisation-generated Stratagems and sometimes make Decisions.");
      int eventPicSlotFor2 = this.game.EventRelatedObj.GetEventPicSlotFor(0, "", "pp");
      ref Graphics local7 = ref g;
      Bitmap bitmap4 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[eventPicSlotFor2]);
      ref Bitmap local8 = ref bitmap4;
      int x6 = x4 + 2;
      DrawMod.DrawSimple(ref local7, ref local8, x6, 6);
      DrawMod.DrawTextColouredConsole(ref g, str1, this.game.MarcFont16, x4 + 31, 4, this.game.seColWhite);
      int x7 = x4 + 75;
      ref Graphics local9 = ref g;
      Bitmap bitmap5 = BitmapStore.GetBitmap(this.game.SE1_RESOURCEBAR_VARBOX);
      ref Bitmap local10 = ref bitmap5;
      int x8 = x7;
      int y4 = y1;
      DrawMod.DrawSimple(ref local9, ref local10, x8, y4);
      trect1 = new Rectangle(x7, y1, 74, 28);
      Rectangle trect3 = trect1;
      this.AddMouse(ref trect3, "Credits", "You need credits to buy with traders and to pay leaders, workers and others.");
      int eventPicSlotFor3 = this.game.EventRelatedObj.GetEventPicSlotFor(0, "", "credits");
      ref Graphics local11 = ref g;
      Bitmap bitmap6 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[eventPicSlotFor3]);
      ref Bitmap local12 = ref bitmap6;
      int x9 = x7 + 2;
      DrawMod.DrawSimple(ref local11, ref local12, x9, 6);
      DrawMod.DrawTextColouredConsole(ref g, str2, this.game.MarcFont16, x7 + 31, 4, this.game.seColWhite);
      if (this.game.EditObj.se1_ManagementMode)
        return;
      if (this.game.EditObj.BlockAdvice & this.game.EditObj.showAdvice)
      {
        if (this.game.ScreenWidth >= 1353)
        {
          int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 502, 0, 0));
          int num3 = this.game.Data.StringListObj[stringListById2].Length + 1;
          if (stringListById2 <= -1 || this.game.Data.StringListObj[stringListById2].Length <= -1)
            return;
          int num4 = x7 + 83;
          SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Adv.[" + num3.ToString() + "]", 80, "Click for opening advice window.", ref this.OwnBitmap, num4, y1 + 2, theight: 26);
          this.advice = this.AddSubPart(ref tsubpart, num4, y1 + 2, 80, 26, 1);
        }
        else
        {
          int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 502, 0, 0));
          if (stringListById3 <= -1 || this.game.Data.StringListObj[stringListById3].Length <= -1)
            return;
          int num5 = x7 + 71;
          SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Ad", 25, "Click for opening advice window.", ref this.OwnBitmap, num5, y1 + 2, theight: 26);
          this.advice = this.AddSubPart(ref tsubpart, num5, y1 + 2, 25, 26, 1);
        }
      }
      else
      {
        if (!(!this.game.EditObj.BlockAdvice & this.game.EditObj.showAdvice))
          return;
        int num6 = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 502, 0, 0))].Length + 1;
        if (this.game.ScreenWidth >= 1353)
        {
          if (num6 > 0)
          {
            int num7 = x7 + 83;
            SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Adv.[" + num6.ToString() + "]", 80, "Advice Window is open.", ref this.OwnBitmap, num7, y1 + 2, true, theight: 26, tMarcStyle: true);
            this.adviceB = this.AddSubPart(ref tsubpart, num7, y1 + 2, 80, 26, 0);
          }
          else
          {
            int num8 = x7 + 83;
            SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Adv.[" + num6.ToString() + "]", 80, "No Advice left. Nothing given this round or everything has been dismissed already.", ref this.OwnBitmap, num8, y1 + 2, true, theight: 26, tMarcStyle: true);
            this.adviceB = this.AddSubPart(ref tsubpart, num8, y1 + 2, 80, 26, 0);
          }
        }
        else if (num6 > 0)
        {
          int num9 = x7 + 71;
          SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Ad", 25, "Advice Window is open.", ref this.OwnBitmap, num9, y1 + 2, true, theight: 26, tMarcStyle: true);
          this.adviceB = this.AddSubPart(ref tsubpart, num9, y1 + 2, 25, 26, 0);
        }
        else
        {
          int num10 = x7 + 71;
          SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Ad", 25, "No Advice left. Nothing given this round or everything has been dismissed already.", ref this.OwnBitmap, num10, y1 + 2, true, theight: 26, tMarcStyle: true);
          this.adviceB = this.AddSubPart(ref tsubpart, num10, y1 + 2, 25, 26, 0);
        }
      }
    }

    public void DrawResources(ref Graphics g)
    {
      SizeF sizeF = new SizeF();
      int[] numArray = new int[10];
      int num1 = 3;
      numArray[1] = (int) Math.Round((double) this.game.ScreenWidth / 2.0 + 158.0 + 162.0);
      numArray[2] = (int) Math.Round((double) this.game.ScreenWidth / 2.0 + 158.0 + 162.0 + 75.0 + 5.0);
      numArray[3] = 165;
      int index1 = 0;
      string Right = "oil" + this.game.Data.RuleVar[949].ToString();
      if ((double) this.game.Data.RuleVar[949] < 1.0)
        Right = "1!impossible!!x423121";
      Rectangle trect1;
      if ((double) this.game.Data.RuleVar[411] > 0.0 && this.game.Data.TempString[731].Length > 1)
      {
        ++index1;
        int num2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[411]))].GetData2(0, this.game.Data.RegimeObj[this.game.EditObj.RealTurn].id, 1, this.game.Data.TempString[731], 2)));
        int index2;
        string tstring = num2 <= 9999 ? this.game.Data.TempString[732] + " " + num2.ToString() : this.game.Data.TempString[732] + " " + (Conversion.Int((double) this.game.Data.GameSlot[index2] / 1000.0).ToString() + "k");
        int x1 = 165;
        ref Graphics local1 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCOPTSLOTS);
        ref Bitmap local2 = ref bitmap;
        int x2 = x1;
        DrawMod.DrawSimple(ref local1, ref local2, x2, 2);
        DrawMod.DrawTextColouredMarc(ref g, tstring, this.game.MarcFont8, x1 + 2, 5, Color.White);
        trect1 = new Rectangle(x1, 2, 75, 20);
        this.AddMouse(ref trect1, "", this.game.Data.TempString[733]);
      }
      if (this.game.Data.Product >= 7)
        return;
      int index3 = 0;
      double num3;
      do
      {
        if (this.game.Data.GameSlotShow2[index3] & this.game.Data.GameSlot[index3] > -1)
        {
          ++index1;
          if (index1 <= num1)
          {
            string tstring = Strings.Trim(Conversion.Str((object) this.game.Data.GameSlot[index3]));
            if (this.game.Data.GameSlot[index3] > 9999)
            {
              num3 = Conversion.Int((double) this.game.Data.GameSlot[index3] / 1000.0);
              tstring = num3.ToString() + "k";
            }
            if (this.game.Data.GameSlotSmallGfx[index3] > -1)
            {
              ref Graphics local3 = ref g;
              Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.MARCOPTSLOTS);
              ref Bitmap local4 = ref bitmap1;
              int x3 = numArray[index1];
              DrawMod.DrawSimple(ref local3, ref local4, x3, 2);
              ref Graphics local5 = ref g;
              Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[this.game.Data.GameSlotSmallGfx[index3]]);
              ref Bitmap local6 = ref bitmap2;
              int x4 = numArray[index1];
              DrawMod.DrawSimple(ref local5, ref local6, x4, 2);
              int x5 = numArray[index1] + 24;
              DrawMod.DrawTextColouredMarc(ref g, tstring, this.game.MarcFont8, x5, 5, Color.White);
              trect1 = new Rectangle(numArray[index1], 2, 75, 20);
              Rectangle trect2 = trect1;
              this.AddMouse(ref trect2, "", this.game.Data.GameSlotName[index3]);
            }
            else if (this.game.Data.GameSlotNato[index3] > 0)
            {
              if (this.game.NATO[this.game.Data.GameSlotNato[index3]] > 0)
              {
                ref Graphics local7 = ref g;
                Bitmap bitmap3 = BitmapStore.GetBitmap(this.game.MARCOPTSLOTS);
                ref Bitmap local8 = ref bitmap3;
                int x6 = numArray[index1];
                DrawMod.DrawSimple(ref local7, ref local8, x6, 2);
                ref Graphics local9 = ref g;
                Bitmap bitmap4 = BitmapStore.GetBitmap(this.game.NATO[this.game.Data.GameSlotNato[index3]]);
                ref Bitmap local10 = ref bitmap4;
                int x7 = numArray[index1];
                DrawMod.DrawSimple(ref local9, ref local10, x7, 2);
                int x8 = numArray[index1] + 24;
                DrawMod.DrawTextColouredMarc(ref g, tstring, this.game.MarcFont8, x8, 5, Color.White);
                trect1 = new Rectangle(numArray[index1], 2, 75, 20);
                Rectangle trect3 = trect1;
                this.AddMouse(ref trect3, "", this.game.Data.GameSlotName[index3]);
              }
            }
            else
            {
              ref Graphics local11 = ref g;
              Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCOPTSLOTS);
              ref Bitmap local12 = ref bitmap;
              int x9 = numArray[index1];
              DrawMod.DrawSimple(ref local11, ref local12, x9, 2);
              int x10 = numArray[index1] + 24;
              DrawMod.DrawTextColouredMarc(ref g, tstring, this.game.MarcFont8, x10, 5, Color.White);
              trect1 = new Rectangle(numArray[index1], 2, 75, 20);
              Rectangle trect4 = trect1;
              this.AddMouse(ref trect4, "", this.game.Data.GameSlotName[index3]);
            }
          }
        }
        ++index3;
      }
      while (index3 <= 499);
      int index4 = 0;
      do
      {
        if (this.game.Data.RegimeSlotShow[index4] & (double) this.game.Data.RuleVar[814] < 1.0)
        {
          int index5 = index4;
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
                  num3 = Conversion.Int((double) x11 / 1000.0);
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
            tstring = Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[this.game.EditObj.RealTurn].RegimeSlot[index4]));
            if (this.game.Data.RegimeObj[this.game.EditObj.RealTurn].RegimeSlot[index4] > 9999)
            {
              num3 = Conversion.Int((double) this.game.Data.RegimeObj[this.game.EditObj.RealTurn].RegimeSlot[index4] / 1000.0);
              tstring = num3.ToString() + "k";
            }
          }
          if (index5 > -1 && this.game.Data.RegimeObj[this.game.EditObj.RealTurn].RegimeSlot[index5] > -1)
          {
            ++index1;
            if (index1 <= num1)
            {
              if (this.game.Data.RegimeSlotSmallGfx[index5] > 0)
              {
                ref Graphics local13 = ref g;
                Bitmap bitmap5 = BitmapStore.GetBitmap(this.game.MARCOPTSLOTS);
                ref Bitmap local14 = ref bitmap5;
                int x12 = numArray[index1];
                DrawMod.DrawSimple(ref local13, ref local14, x12, 2);
                ref Graphics local15 = ref g;
                Bitmap bitmap6 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[this.game.Data.RegimeSlotSmallGfx[index5]]);
                ref Bitmap local16 = ref bitmap6;
                int x13 = numArray[index1];
                DrawMod.DrawSimple(ref local15, ref local16, x13, 2);
                x11 = numArray[index1] + 24;
                DrawMod.DrawTextColouredMarc(ref g, tstring, this.game.MarcFont8, x11, 5, Color.White);
                trect1 = new Rectangle(numArray[index1], 2, 75, 20);
                Rectangle trect5 = trect1;
                this.AddMouse(ref trect5, "", this.game.Data.RegimeSlotName[index5]);
              }
              else if (this.game.Data.RegimeSlotNato[index5] > 0)
              {
                ref Graphics local17 = ref g;
                Bitmap bitmap7 = BitmapStore.GetBitmap(this.game.MARCOPTSLOTS);
                ref Bitmap local18 = ref bitmap7;
                int x14 = numArray[index1];
                DrawMod.DrawSimple(ref local17, ref local18, x14, 2);
                ref Graphics local19 = ref g;
                Bitmap bitmap8 = BitmapStore.GetBitmap(this.game.NATO[this.game.Data.RegimeSlotNato[index5]]);
                ref Bitmap local20 = ref bitmap8;
                int x15 = numArray[index1];
                DrawMod.DrawSimple(ref local19, ref local20, x15, 2);
                x11 = numArray[index1] + 24;
                DrawMod.DrawTextColouredMarc(ref g, tstring, this.game.MarcFont8, x11, 5, Color.White);
                trect1 = new Rectangle(numArray[index1], 2, 75, 20);
                Rectangle trect6 = trect1;
                this.AddMouse(ref trect6, "", this.game.Data.RegimeSlotName[index5]);
              }
              else
              {
                ref Graphics local21 = ref g;
                Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCOPTSLOTS);
                ref Bitmap local22 = ref bitmap;
                int x16 = numArray[index1];
                DrawMod.DrawSimple(ref local21, ref local22, x16, 2);
                x11 = numArray[index1] + 24;
                DrawMod.DrawTextColouredMarc(ref g, tstring, this.game.MarcFont8, x11, 5, Color.White);
                trect1 = new Rectangle(numArray[index1], 2, 75, 20);
                Rectangle trect7 = trect1;
                this.AddMouse(ref trect7, "", this.game.Data.RegimeSlotName[index5]);
              }
            }
          }
        }
        ++index4;
      }
      while (index4 <= 499);
    }

    public override void HandleToolTip(int x, int y)
    {
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
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
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
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

    public void PopUpRefresh()
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

    public WindowReturnClass DoEndTurnStuff(int tMouseButPressed)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (!this.game.Data.RegimeObj[this.game.Data.Turn].AI & !this.game.SuperAdminRights)
      {
        int locCounter = this.game.Data.LocCounter;
        int num;
        for (int index = 0; index <= locCounter; ++index)
        {
          if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[index].X, this.game.Data.LocObj[index].Y].Regime == this.game.Data.Turn)
            ++num;
        }
        if (this.game.Data.RegimeObj[this.game.Data.Turn].Sleep)
          num = 0;
        if (num < 1)
        {
          this.surrendering = true;
          windowReturnClass = this.DoSurrenderStuff();
          int regimeCounter = this.game.Data.RegimeCounter;
          for (int index = 0; index <= regimeCounter; ++index)
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
        int integer = Conversions.ToInteger(Interaction.InputBox("Run with AI only for howmany rounds?", "Shadow Empire : Planetary Conquest"));
        if (integer > 0)
          this.game.EditObj.debugAiOnlyTillRound = this.game.Data.Round + integer;
        else
          this.game.EditObj.debugAiOnlyTillRound = 0;
      }
      int humanPlayers = this.game.HandyFunctionsObj.GetHumanPlayers();
      this.game.EditObj.DoCardSlot = -1;
      this.game.EditObj.HandCard = -1;
      this.game.EditObj.se1_ManagementMode = false;
      if (humanPlayers < 1)
      {
        this.game.Data = new DataClass();
        this.game.EditObj = new EditClass(this.game.AppPath + "editobj.txt");
        if (this.game.Data.UseAI == 1 & !Information.IsNothing((object) this.game.NewAIObj))
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
        string str = this.game.AppPath_SAVEGAMES + "autosave_round" + this.game.EditObj.RealRound.ToString() + ".se1";
        this.game.Data.serialize(str);
        this.game.HandyFunctionsObj.ZipFile(str);
        GC.Collect();
        Application.DoEvents();
      }
      if (this.game.EditObj.RealTurn != -1 && !this.game.Data.RegimeObj[this.game.EditObj.RealTurn].AI)
        this.game.EventRelatedObj.DoCheckEvents(5);
      int num1 = 0;
      int index1 = this.game.EditObj.RealTurn + 1;
      if (this.game.EditObj.RealTurn > this.game.Data.RegimeCounter)
        index1 = 0;
      if (!this.game.Data.RegimeObj[index1].AI & !this.game.Data.RegimeObj[index1].Sleep)
        num1 = 1;
      this.game.HandyFunctionsObj.ClearHistory((object) this.game.Data.Turn);
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
        this.game.se1GameLoop = new GameLoopClass2(ref this.game);
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

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.game.EditObj.TutOrder > -1)
        return windowReturnClass;
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            int num = this.SubPartID[index];
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
              this.game.EditObj.TempCoordList = new CoordList();
              windowReturnClass.AddCommand(3, 11);
              this.game.EditObj.OrderType = 0;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
          }
        }
      }
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (this.MouseData[index] > 0)
        {
          if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
          {
            int num = this.MouseData[index];
            switch (num)
            {
              case 2001:
                this.game.EditObj.se1_ManagementMode = false;
                this.game.EditObj.TempCoordList = new CoordList();
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
                      this.game.EditObj.TempCoordList = new CoordList();
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
                    this.game.EditObj.TempCoordList = new CoordList();
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
      if (y < 64 && (double) x > (double) this.w / 2.0 - 158.0 & (double) x < (double) this.w / 2.0 + 158.0)
        windowReturnClass.NoMouseClickBelow = true;
      if (x < 583 & y <= 70)
        windowReturnClass.NoMouseClickBelow = true;
      if (x > this.game.ScreenWidth - 735 & y <= 60)
        windowReturnClass.NoMouseClickBelow = true;
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      if (this.screenVid > -1 & nr == 86)
      {
        WindowReturnClass windowReturnClass2 = this.HandleMouseClick(this.MouseRect[this.screenVid].X + 1, this.MouseRect[this.screenVid].Y + 1, 1);
        windowReturnClass2.SetFlag(true);
        return windowReturnClass2;
      }
      if (this.screenHis > -1 & nr == 72)
      {
        WindowReturnClass windowReturnClass3 = this.HandleMouseClick(this.MouseRect[this.screenHis].X + 1, this.MouseRect[this.screenHis].Y + 1, 1);
        windowReturnClass3.SetFlag(true);
        return windowReturnClass3;
      }
      if (this.screenMan > -1 & nr == 78)
      {
        WindowReturnClass windowReturnClass4 = this.HandleMouseClick(this.MouseRect[this.screenMan].X + 1, this.MouseRect[this.screenMan].Y + 1, 1);
        windowReturnClass4.SetFlag(true);
        return windowReturnClass4;
      }
      if (this.screenMap > -1 & nr == 27)
      {
        WindowReturnClass windowReturnClass5 = this.HandleMouseClick(this.MouseRect[this.screenMap].X + 1, this.MouseRect[this.screenMap].Y + 1, 1);
        windowReturnClass5.SetFlag(true);
        return windowReturnClass5;
      }
      if (this.game.EditObj.OrderType != 26 && this.screenMap < 0 && nr == 67)
      {
        int integer = Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(this.game.SelectX, this.game.SelectY, "SE_Data", "Zones"));
        int stringListById = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0));
        if (integer > 0)
        {
          int id = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(0, integer, 6)));
          if (this.game.EventRelatedObj.CheckRegimeSlot((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(0, integer, 8))), 0, 0, 0) == this.game.Data.Turn)
          {
            int index = -1;
            if (id > 0)
              index = this.game.HandyFunctionsObj.GetLocationByID(id);
            int num = -1;
            if (index > -1)
              num = this.game.Data.LocObj[index].HQ;
            if (num > -1)
            {
              this.game.EditObj.UDSpopupText = "";
              this.formref.Cursor = Cursors.WaitCursor;
              this.game.EditObj.UDSClearInput();
              this.game.EventRelatedObj.SetUDSKey("ZONE", integer);
              int eventByLib = this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 106, 0, 0);
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
        WindowReturnClass windowReturnClass6 = this.HandleMouseClick(this.MouseRect[this.tab1].X + 1, this.MouseRect[this.tab1].Y + 1, 1);
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
        WindowReturnClass windowReturnClass7 = this.HandleMouseClick(this.MouseRect[this.tab3].X + 1, this.MouseRect[this.tab3].Y + 1, 1);
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
        WindowReturnClass windowReturnClass8 = this.HandleMouseClick(this.MouseRect[this.tab4].X + 1, this.MouseRect[this.tab4].Y + 1, 1);
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
        WindowReturnClass windowReturnClass9 = this.HandleMouseClick(this.MouseRect[this.tab7].X + 1, this.MouseRect[this.tab7].Y + 1, 1);
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
        WindowReturnClass windowReturnClass10 = this.HandleMouseClick(this.MouseRect[this.tab6].X + 1, this.MouseRect[this.tab6].Y + 1, 1);
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
        WindowReturnClass windowReturnClass11 = this.HandleMouseClick(this.MouseRect[this.tab11].X + 1, this.MouseRect[this.tab11].Y + 1, 1);
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
        WindowReturnClass windowReturnClass12 = this.HandleMouseClick(this.MouseRect[this.tab12].X + 1, this.MouseRect[this.tab12].Y + 1, 1);
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
        WindowReturnClass windowReturnClass13 = this.HandleMouseClick(this.MouseRect[this.tab8].X + 1, this.MouseRect[this.tab8].Y + 1, 1);
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
        this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 210, 0, 0))].SetData2(0, this.game.Data.RegimeObj[this.game.EditObj.RealTurn].id, 1, Interaction.InputBox("Change which regimekey?"), 2, (int) Math.Round(Conversion.Val(Interaction.InputBox("What new value?"))));
      return windowReturnClass1;
    }

    public WindowReturnClass DoSurrenderStuff()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      this.game.EditObj.UnitSelected = -1;
      this.game.EditObj.OrderUnit = -1;
      this.game.EditObj.OrderTarget = -1;
      this.game.EditObj.OldUnit = -1;
      int humanPlayers = this.game.HandyFunctionsObj.GetHumanPlayers();
      if (!this.game.Data.RegimeObj[this.game.Data.Turn].AI & this.game.Data.RegimeObj[this.game.Data.Turn].Sleep)
        ++humanPlayers;
      if (humanPlayers != 2 && humanPlayers != 1 && this.game.Data.Product < 7 && this.game.Data.PbemGameID < 1)
        this.game.EventRelatedObj.ExecJoinRegime(this.game.Data.Turn, -1, 0, 0, "");
      if (humanPlayers > 2)
      {
        for (int unitCounter = this.game.Data.UnitCounter; unitCounter >= 0; unitCounter += -1)
        {
          if (this.game.Data.UnitObj[unitCounter].Regime == this.game.Data.Turn & this.game.Data.UnitObj[unitCounter].PreDef == -1)
          {
            DataClass data = this.game.Data;
            int nr = unitCounter;
            GameClass gameClass = (GameClass) null;
            ref GameClass local = ref gameClass;
            data.RemoveUnit(nr, ref local);
          }
        }
      }
      if ((double) this.game.Data.RuleVar[978] < 1.0)
      {
        this.game.Data.LastWinner = this.game.Data.Winner;
        if (this.game.Data.PbemGameID < 1)
          this.game.Data.RegimeObj[this.game.Data.Turn].Sleep = true;
      }
      if (humanPlayers > 1 | (double) this.game.Data.RuleVar[978] > 0.0 | this.game.Data.PbemGameID > 0 | this.game.Data.Product == 7 & humanPlayers > 1)
      {
        windowReturnClass.SetFlag(false);
      }
      else
      {
        this.game.Data = new DataClass();
        this.game.EditObj = new EditClass(this.game.AppPath + "editobj.txt");
        if (this.game.Data.UseAI == 1)
        {
          if (Information.IsNothing((object) this.game.NewAIObj))
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
