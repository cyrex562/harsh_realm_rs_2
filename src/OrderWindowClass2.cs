// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.OrderWindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class OrderWindowClass2 : WindowClass
  {
    private bool TimerUsed;
    private int w;
    private int h;
    private int CurrentView;
    private bool EndingTurn;
    private bool Surrendering;
    private bool RealSurrendering;
    private bool JustAMessage;
    private bool AskingAboutMetrics;
    private int Info1Id;
    private int Cancelid;
    private int OkId;
    private int BattleId;
    private int LeftId;
    private int RightId;
    private int KillId;
    private int AllId;
    private int NoneId;
    private int Ok2Id;
    private int Battle2Id;
    private int Kill2Id;
    private int All2Id;
    private int None2Id;
    private string NotOkText;
    private int tab1;
    private int tab2;
    private int tab3;
    private int tab4;
    private int tab51;
    private int tab52;
    private int tab53;
    private int tab6;
    private int tab101;
    private int lastorderx;
    private int lastordery;
    private int LastAirSupplyNeed;
    private int LastAirSupplyMax;
    private int LastAirSupplyTarget;
    private int MoveButtonId;
    private int StatisticsButtonId;
    private int GroupMoveButtonId;
    private int NextButtonId;
    private int PopupButtonId;
    private int NewUnitButtonId;
    private int HqUnitButtonId;
    private int NewUnitButton2Id;
    private int AttackButtonId;
    private int seaAttackButtonId;
    private int PrefsButtonId;
    private int ArtAttackButtonId;
    private int SeaArtAttackButtonId;
    private int TransferButtonId;
    private int AirAttackButtonId;
    private int InterdictButtonId;
    private int StrategicButtonId;
    private int GroupStrategicButtonId;
    private int MakeHQButtonID;
    private int AirReconButtonId;
    private int ParadropButtonId;
    private int LoadButtonId;
    private int UnLoadButtonID;
    private int ResearchId;
    private int DipId;
    private int HistoryId;
    private int SaveId;
    private int QuitID;
    private int HqProdButtonId;
    private int PeopleTransferButtonId;
    private int ProdButtonId;
    private int RecruitButtonId;
    private int SupplyLayerButtonId;
    private int AirSupplyButtonId;
    private int OfficerId;
    private int BlowBridgeButtonId;
    private int BlowLocationButtonId;
    private int ACapButtonId;
    private int InfraButtonId;
    private int BuildButtonId;
    private int HexUnitButtonId;
    private int HexUnitButtonId2;
    private int GiveUnitId;
    private int GiveHexId;
    private int ShowAsId;
    private int ShowAsId2;
    private int FakeBackButtonId;
    private int ChangeModelId;
    private int ChangeModelId2;
    private int ModelDesignerId;
    private int ModelDesignerId2;
    private int SFDesignButtonId;
    private int GuiDownId;
    private int MoveButtonId2;
    private int GroupMoveButtonId2;
    private int StatisticsButtonId2;
    private int NextButtonId2;
    private int NewUnitButtonId2;
    private int HqUnitButtonId2;
    private int AttackButtonId2;
    private int seaAttackButtonId2;
    private int PrefsButtonId2;
    private int NewUnitButton2Id2;
    private int ArtAttackButtonId2;
    private int SeaArtAttackButtonId2;
    private int TransferButtonId2;
    private int AirAttackButtonId2;
    private int InterdictButtonId2;
    private int StrategicButtonId2;
    private int GroupStrategicButtonId2;
    private int MakeHQButtonID2;
    private int AirReconButtonId2;
    private int ParadropButtonId2;
    private int LoadButtonId2;
    private int UnLoadButtonID2;
    private int ResearchId2;
    private int DipId2;
    private int HistoryId2;
    private int SaveId2;
    private int QuitID2;
    private int HqProdButtonId2;
    private int OfficerId2;
    private int PeopleTransferButtonId2;
    private int ProdButtonId2;
    private int RecruitButtonId2;
    private int SupplyLayerButtonId2;
    private int AirSupplyButtonId2;
    private int OrderSurrenderButtonId;
    private int ButtonZoomInId;
    private int ButtonZoomOutId;
    private int ButtonStackedUnitId;
    private int OrderSurrenderButtonId2;
    private int ButtonZoomInId2;
    private int ButtonZoomOutId2;
    private int ButtonStackedUnitId2;
    private int BlowBridgeButtonId2;
    private int BlowLocationButtonId2;
    private int GiveUnitId2;
    private int GiveHexId2;
    private int ACapButtonId2;
    private int InfraButtonId2;
    private int BuildButtonId2;
    private int TransportButtonId;
    private int TransportButtonId2;
    private int BattleGroupButtonId;
    private int BattleGroupButtonId2;
    private string SFDesignButtonText;
    private string MoveButtonText;
    private string ButtonZoomInText;
    private string ButtonZoomOutText;
    private string ButtonStackedUnitText;
    private string GroupMoveButtonText;
    private string StatisticsButtonText;
    private string NextButtonText;
    private string GiveUnitText;
    private string GiveHexText;
    private string NewUnitButtonText;
    private string HqUnitButtonText;
    private string AttackButtonText;
    private string ChangeModelText;
    private string OfficerText;
    private string SeaAttackButtonText;
    private string PrefsButtonText;
    private string ArtAttackButtonText;
    private string SeaArtAttackButtonText;
    private string TransferButtonText;
    private string AirAttackButtonText;
    private string AirReconButtonText;
    private string newunitbutton2text;
    private string paradropbuttontext;
    private string loadbuttontext;
    private string unloadbuttontext;
    private string researchbuttontext;
    private string diptext;
    private string constructtext;
    private string historytext;
    private string savetext;
    private string quittext;
    private string hqprodbuttontext;
    private string ordersurrendertext;
    private string battlegroupText;
    private string transportButtonText;
    private string supplylayerbuttontext;
    private string blowlocationtext;
    private string disbandtext;
    private string interdictbuttontext;
    private string prodbuttontext;
    private string researchtext;
    private string groupstrategictext;
    private string strategicbuttontext;
    private string airsupplybuttontext;
    private string blowbridgebuttontext;
    private string infrabuttontext;
    private string buildbuttontext;
    private int[] ActionButtonId;
    private int[] ActionButtonId2;
    private int[] ActionButtonCardSlot;
    private int disbandid;
    private int disbandid2;
    private bool pdfAsked;
    private int lastHideUnit;

    public OrderWindowClass2(
      ref GameClass tGame,
      ref WindowClass tLowerWindow,
      ref Rectangle tLowerRect)
      : base(ref tGame, tGame.ScreenWidth, 90)
    {
      this.ActionButtonId = new int[11];
      this.ActionButtonId2 = new int[11];
      this.ActionButtonCardSlot = new int[11];
      this.pdfAsked = false;
      this.NewGfx = true;
      this.w = tGame.ScreenWidth;
      this.h = 90;
      this.LowerWindow = tLowerWindow;
      this.LowerRect = tLowerRect;
      this.lastorderx = -1;
      this.lastordery = -1;
      this.lastHideUnit = -1;
      if (this.game.SelectX > -1 && this.game.EditObj.UnitSelected == -1 & this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter > -1 && this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime))
        this.game.EditObj.UnitSelected = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitList[0];
      this.game.EditObj.PurelyOrderRedrawRefresh = false;
      this.dostuff();
    }

    public override void DoRefresh()
    {
      if (this.game.EditObj.OrderType == 0)
      {
        this.lastorderx = -1;
        this.lastordery = -1;
      }
      this.dostuff();
    }

    public override WindowReturnClass handleTimerWheel(int x, int y)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      windowReturnClass.Flag = false;
      if (this.game.EditObj.MouseWheel > 0 & this.ButtonZoomInId > 0 & this.game.EditObj.Zoom < 1 & this.game.EditObj.TutOrder == -1)
      {
        if (this.game.EditObj.MouseOverX > -1 & this.game.EditObj.MouseOverY > -1)
          this.game.HandyFunctionsObj.CenterOnXY(this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY, true);
        this.game.EditObj.MouseWheel = 0;
        this.game.EditObj.MouseWheelWait = 4;
        return this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.ButtonZoomInId)] + 1, this.SubPartY[this.SubpartNr(this.ButtonZoomInId)] + 1, 1);
      }
      if (this.game.EditObj.MouseWheel < 0 & this.ButtonZoomOutId > 0 & this.game.EditObj.Zoom > -1 & this.game.EditObj.TutOrder == -1)
      {
        if (this.game.EditObj.MouseOverX > -1 & this.game.EditObj.MouseOverY > -1)
          this.game.HandyFunctionsObj.CenterOnXY(this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY, true);
        this.game.EditObj.MouseWheel = 0;
        this.game.EditObj.MouseWheelWait = 4;
        return this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.ButtonZoomOutId)] + 1, this.SubPartY[this.SubpartNr(this.ButtonZoomOutId)] + 1, 1);
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    public override WindowReturnClass handleTimer()
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      if (Information.IsNothing((object) this.game.EditObj.pdfGenerated))
        this.game.EditObj.pdfGenerated = "";
      if (this.EndingTurn)
        return this.DoEndTurnStuff();
      if (!this.pdfAsked && this.game.EditObj.pdfGenerated.Length > 2)
      {
        string str = "REPORT GENERATED\r\n" + "A PDF document has been generated. Open it?";
        this.pdfAsked = true;
        this.game.EditObj.PopupValue = 10;
        this.game.EditObj.QuestionText = str;
        this.game.EditObj.AnswerCount = 2;
        this.game.EditObj.AnswerText[1] = "Yes";
        this.game.EditObj.AnswerTextMouseOver[1] = "Try to open the PDF: ''documentation/" + this.game.EditObj.pdfGenerated + "'. ";
        this.game.EditObj.AnswerText[2] = "No";
        this.game.EditObj.AnswerTextMouseOver[2] = "Stay in the game. You can always look up the PDF later";
        this.game.EditObj.warningshown = true;
        windowReturnClass1.AddCommand(5, 10);
        this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (this.pdfAsked & this.game.EditObj.pdfGenerated.Length > 2)
      {
        string str = "documentation/" + this.game.EditObj.pdfGenerated;
        this.game.EditObj.pdfGenerated = "";
        if (this.game.EditObj.AnswerChosen == 1)
        {
          WindowReturnClass windowReturnClass2;
          try
          {
            Process.Start(AppDomain.CurrentDomain.BaseDirectory + str);
            this.game.FormRef.SendToBack();
            goto label_10;
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            int num = (int) Interaction.MsgBox((object) "PROBLEM", Title: ((object) "Sadly there was a problem trying to let your Windows system open this PDF. Please check the game forums for possible causes."));
            this.dostuff();
            windowReturnClass2 = windowReturnClass1;
            ProjectData.ClearProjectError();
          }
          return windowReturnClass2;
        }
      }
label_10:
      if (this.Surrendering)
      {
        if ((double) this.game.Data.RuleVar[950] > 0.0)
        {
          this.game.EventRelatedObj.DoCheckSpecificEvent((int) Math.Round((double) this.game.Data.RuleVar[950]));
          this.RealSurrendering = true;
          this.Surrendering = false;
          DrawMod.TGame.EditObj.PopupValue = 0;
          this.game.EditObj.FromMessage = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
          windowReturnClass1.AddCommand(5, 14);
          this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
          windowReturnClass1.SetFlag(true);
          return windowReturnClass1;
        }
        this.RealSurrendering = false;
        return this.DoSurrenderStuff();
      }
      if (this.RealSurrendering)
      {
        this.RealSurrendering = false;
        return this.DoSurrenderStuff();
      }
      if (!this.TimerUsed && this.game.EditObj.OrderType == 18 | this.game.EditObj.OrderType == 49 && this.game.EditObj.OrderTarget > -1)
      {
        this.game.EditObj.TempCoordList = new CoordList();
        this.game.EditObj.TargetX = this.game.EditObj.OrderX;
        this.game.EditObj.TargetY = this.game.EditObj.OrderY;
        this.game.SelectX = this.game.EditObj.OrderX;
        this.game.SelectY = this.game.EditObj.OrderY;
        this.game.EditObj.TempCoordList.AddCoord(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap);
        this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectX, this.game.EditObj.MapSelected);
        windowReturnClass1.AddCommand(1, 5);
        windowReturnClass1.AddCommand(2, 35);
        windowReturnClass1.AddCommand(4, 12);
        this.TimerUsed = true;
        windowReturnClass1.SetFlag(true);
      }
      return windowReturnClass1;
    }

    public void dostuff()
    {
      this.CurrentView = this.game.EditObj.SetViewMode;
      this.ClearMouse();
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
      if (!this.game.EditObj.useLeftRightClickMode | (double) this.game.Data.RuleVar[701] < 1.0 | this.game.EditObj.OrderType == 26)
      {
        int num1 = (int) Math.Round((double) this.game.ScreenWidth / 116.0);
        Bitmap bitmap;
        for (int index = 0; index <= num1; ++index)
        {
          ref Graphics local1 = ref g;
          bitmap = BitmapStore.GetBitmap(this.game.MARCBUTBARFRAME);
          ref Bitmap local2 = ref bitmap;
          int x = index * 116;
          DrawMod.DrawSimple(ref local1, ref local2, x, 87);
        }
        int num2 = 0;
        if (this.game.EditObj.OrderType == 26)
        {
          int num3 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
          ref Graphics local3 = ref g;
          bitmap = BitmapStore.GetBitmap(this.game.MARCBUTBARHISTORY);
          ref Bitmap local4 = ref bitmap;
          int x = num3;
          int y = num2;
          DrawMod.DrawSimple(ref local3, ref local4, x, y);
        }
        else
        {
          int num4 = (int) Math.Round((double) (this.game.ScreenWidth - BitmapStore.GetWidth(this.game.MARCBUTBAR)) / 2.0);
          ref Graphics local5 = ref g;
          bitmap = BitmapStore.GetBitmap(this.game.MARCBUTBAR);
          ref Bitmap local6 = ref bitmap;
          int x = num4;
          int y = num2;
          DrawMod.DrawSimple(ref local5, ref local6, x, y);
        }
      }
      else
      {
        DrawMod.DrawBlock(ref g, this.w - 290, 0, 290, 15, 0, 0, 0, 128);
        DrawMod.DrawBlock(ref g, 0, 15, this.w, 20, 0, 0, 0, 128);
        DrawMod.DrawBlock(ref g, 0, 33, this.w, this.h - 33, 0, 0, 0, (int) byte.MaxValue);
        int num = (int) Math.Round((double) this.game.ScreenWidth / 116.0);
        for (int index = 0; index <= num; ++index)
        {
          ref Graphics local7 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCBUTBARFRAME);
          ref Bitmap local8 = ref bitmap;
          int x = index * 116;
          DrawMod.DrawSimple(ref local7, ref local8, x, 87);
        }
      }
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      if (Information.IsNothing((object) this.game.EditObj.TempUnitList))
        this.game.EditObj.TempUnitList = new UnitList();
      this.DoTabs(ref g);
      if (!this.game.EditObj.PurelyOrderRedrawRefresh)
      {
        this.dostuff2(g);
      }
      else
      {
        this.game.EditObj.PurelyOrderRedrawRefresh = false;
        if ((double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode)
          this.dostuff2(g);
        this.FlagAll();
      }
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      if (this.game.EditObj.BattleTimerActive)
        return windowReturnClass1;
      int num1 = 0;
      if (this.game.EditObj.TutMode)
        num1 = 1;
      if (this.game.EditObj.OrderType == 1 & this.game.EditObj.OrderUnit > -1 && nr == 71 & this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical > -1 & this.GroupMoveButtonId > 0)
      {
        WindowReturnClass windowReturnClass2;
        if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical].StartSize > 1)
        {
          this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
          windowReturnClass2 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.Cancelid)] + 1, this.SubPartY[this.SubpartNr(this.Cancelid)] + 1, 1);
          WindowReturnClass windowReturnClass3 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.GroupMoveButtonId)] + 1, this.SubPartY[this.SubpartNr(this.GroupMoveButtonId)] + 1, 1);
          this.game.EditObj.TempCoordList = new CoordList();
          windowReturnClass3.SetFlag(true);
          return windowReturnClass3;
        }
        this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
        windowReturnClass2 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.Cancelid)] + 1, this.SubPartY[this.SubpartNr(this.Cancelid)] + 1, 1);
        WindowReturnClass windowReturnClass4 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.MoveButtonId)] + 1, this.SubPartY[this.SubpartNr(this.MoveButtonId)] + 1, 1);
        this.game.EditObj.TempCoordList = new CoordList();
        windowReturnClass4.SetFlag(true);
        return windowReturnClass4;
      }
      if (nr == 121 & this.tab1 > -1)
      {
        WindowReturnClass windowReturnClass5 = this.HandleMouseClick(this.MouseRect[this.tab1].X + 66, this.MouseRect[this.tab1].Y + 1, 1);
        windowReturnClass5.SetFlag(true);
        return windowReturnClass5;
      }
      if (nr == 122 & this.tab2 > -1)
      {
        WindowReturnClass windowReturnClass6 = this.HandleMouseClick(this.MouseRect[this.tab2].X + 66, this.MouseRect[this.tab2].Y + 1, 1);
        windowReturnClass6.SetFlag(true);
        return windowReturnClass6;
      }
      if (nr == 123 & this.tab3 > -1)
      {
        WindowReturnClass windowReturnClass7 = this.HandleMouseClick(this.MouseRect[this.tab3].X + 66, this.MouseRect[this.tab3].Y + 1, 1);
        windowReturnClass7.SetFlag(true);
        return windowReturnClass7;
      }
      if (nr == 120 & this.tab4 > -1)
      {
        WindowReturnClass windowReturnClass8 = this.HandleMouseClick(this.MouseRect[this.tab4].X + 66, this.MouseRect[this.tab4].Y + 1, 1);
        windowReturnClass8.SetFlag(true);
        return windowReturnClass8;
      }
      if ((nr == 97 | nr == 49) & this.HexUnitButtonId > 0 + num1 & this.game.EditObj.TutOrder == -1)
      {
        this.game.EditObj.HideUnit = 0;
        WindowReturnClass windowReturnClass9 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.HexUnitButtonId)] + 1, this.SubPartY[this.SubpartNr(this.HexUnitButtonId)] + 1, 1);
        windowReturnClass9.SetFlag(true);
        return windowReturnClass9;
      }
      if (nr == 34 & !this.game.EditObj.GuiDown & this.GuiDownId > 0 + num1)
      {
        WindowReturnClass windowReturnClass10 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.GuiDownId)] + 1, this.SubPartY[this.SubpartNr(this.GuiDownId)] + 1, 1);
        windowReturnClass10.SetFlag(true);
        return windowReturnClass10;
      }
      if (nr == 33 & this.game.EditObj.GuiDown & this.GuiDownId > 0)
      {
        WindowReturnClass windowReturnClass11 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.GuiDownId)] + 1, this.SubPartY[this.SubpartNr(this.GuiDownId)] + 1, 1);
        windowReturnClass11.SetFlag(true);
        return windowReturnClass11;
      }
      if ((nr == 98 | nr == 50) & this.HexUnitButtonId > 0 + num1 & (double) this.game.Data.RuleVar[344] > (double) (0 + num1) & this.game.EditObj.TutOrder == -1)
      {
        this.game.EditObj.HideUnit = 1;
        WindowReturnClass windowReturnClass12 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.HexUnitButtonId)] + 1, this.SubPartY[this.SubpartNr(this.HexUnitButtonId)] + 1, 1);
        windowReturnClass12.SetFlag(true);
        return windowReturnClass12;
      }
      if ((nr == 96 | nr == 48) & this.HexUnitButtonId > 0 + num1 & this.game.EditObj.TutOrder == -1)
      {
        int num2 = 0;
        if ((double) this.game.Data.RuleVar[344] > (double) (0 + num1))
          num2 = 0;
        if (this.lastHideUnit > -1 & this.lastHideUnit != num2)
        {
          this.game.EditObj.HideUnit = this.lastHideUnit;
          this.lastHideUnit = -1;
        }
        else
        {
          this.lastHideUnit = this.game.EditObj.HideUnit;
          if (this.lastHideUnit == 0)
            this.lastHideUnit = 1;
          this.game.EditObj.HideUnit = num2;
        }
        this.game.EditObj.TempCoordList = new CoordList();
        windowReturnClass1.AddCommand(4, 12);
        windowReturnClass1.AddCommand(4, 9);
        windowReturnClass1.AddCommand(4, 67);
        windowReturnClass1.AddCommand(4, 68);
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if ((nr == 99 | nr == 51) & this.ButtonStackedUnitId > 0 + num1 & this.game.EditObj.TutOrder == -1)
      {
        WindowReturnClass windowReturnClass13 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.ButtonStackedUnitId)] + 1, this.SubPartY[this.SubpartNr(this.ButtonStackedUnitId)] + 1, 1);
        windowReturnClass13.SetFlag(true);
        return windowReturnClass13;
      }
      if ((nr == 100 | nr == 52) & this.ShowAsId > 0 + num1 & this.game.EditObj.TutOrder == -1)
      {
        WindowReturnClass windowReturnClass14 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.ShowAsId)] + 1, this.SubPartY[this.SubpartNr(this.ShowAsId)] + 1, 1);
        windowReturnClass14.SetFlag(true);
        return windowReturnClass14;
      }
      if ((nr == 101 | nr == 53) & this.ShowAsId > 0 + num1 & this.game.EditObj.TutOrder == -1)
      {
        this.game.EditObj.ShowHQPower = !this.game.EditObj.ShowHQPower;
        this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
        windowReturnClass1.AddCommand(4, 12);
        windowReturnClass1.AddCommand(4, 67);
        windowReturnClass1.AddCommand(4, 68);
        windowReturnClass1.AddCommand(4, 9);
        return windowReturnClass1;
      }
      if ((nr == 102 | nr == 54) & this.ShowAsId > 0 + num1 & this.game.EditObj.TutOrder == -1)
      {
        this.game.EditObj.ShowAirRange = !this.game.EditObj.ShowAirRange;
        this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
        windowReturnClass1.AddCommand(4, 12);
        windowReturnClass1.AddCommand(4, 67);
        windowReturnClass1.AddCommand(4, 68);
        windowReturnClass1.AddCommand(4, 9);
        return windowReturnClass1;
      }
      if (this.game.EditObj.OrderType == 48 & this.Cancelid > 0 && nr == 77)
      {
        this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
        WindowReturnClass windowReturnClass15 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.Cancelid)] + 1, this.SubPartY[this.SubpartNr(this.Cancelid)] + 1, 1);
        if (this.MoveButtonId > 0 + num1)
          windowReturnClass15 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.MoveButtonId)] + 1, this.SubPartY[this.SubpartNr(this.MoveButtonId)] + 1, 1);
        this.game.EditObj.TempCoordList = new CoordList();
        windowReturnClass15.SetFlag(true);
        return windowReturnClass15;
      }
      if (nr == 67 & this.game.EditObj.UnitSelected > -1 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X > -1)
      {
        this.game.HandyFunctionsObj.CenterOnXY(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y);
        this.game.EditObj.TempCoordList = new CoordList();
        windowReturnClass1.AddCommand(4, 12);
        windowReturnClass1.AddCommand(4, 9);
        windowReturnClass1.AddCommand(4, 67);
        windowReturnClass1.AddCommand(4, 68);
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      int num3 = 0;
      if (this.game.EditObj.GuiDown)
        num3 = 222;
      if ((nr == 187 | nr == 191 | nr == 107) & this.game.EditObj.Zoom < 1 & this.game.EditObj.TutOrder == -1)
      {
        if (this.ButtonZoomInId > 0 + num1)
        {
          windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.ButtonZoomInId)] + 1, this.SubPartY[this.SubpartNr(this.ButtonZoomInId)] + 1, 1);
          windowReturnClass1.SetFlag(true);
        }
        else
        {
          int num4 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 53.0));
          int num5 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 106.0));
          int num6 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num3)) / 53.0));
          int num7 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num3)) / 106.0));
          int num8;
          int num9;
          if (this.game.EditObj.Zoom == 0)
          {
            this.game.EditObj.Zoom = 1;
            this.game.CornerX += (int) Math.Round(Conversion.Int((double) num5 / 2.0));
            this.game.CornerY += (int) Math.Round(Conversion.Int((double) num7 / 2.0));
            num8 = 106;
            num9 = 96;
          }
          else
          {
            this.game.EditObj.Zoom = 0;
            this.game.CornerX += (int) Math.Round(Conversion.Int((double) num4 / 2.0));
            this.game.CornerY += (int) Math.Round(Conversion.Int((double) num6 / 2.0));
            num8 = 53;
            num9 = 48;
          }
          if ((double) this.game.CornerX + (double) this.game.ScreenWidth / (double) num8 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
            this.game.CornerX = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth) - (double) (this.game.ScreenWidth - 200) / (double) num8);
          if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num3)) / (double) num9 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
            this.game.CornerY = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num3)) / (double) num9);
          if (this.game.CornerX < 0)
            this.game.CornerX = 0;
          if (this.game.CornerY < 0)
            this.game.CornerY = 0;
          this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
          this.game.EditObj.TempCoordList = new CoordList();
          windowReturnClass1.AddCommand(1, 12);
          windowReturnClass1.AddCommand(2, 12);
          windowReturnClass1.AddCommand(4, 9);
          windowReturnClass1.AddCommand(4, 67);
          windowReturnClass1.AddCommand(4, 68);
          windowReturnClass1.SetFlag(true);
          return windowReturnClass1;
        }
      }
      if ((nr == 189 | nr == 219 | nr == 109) & this.game.EditObj.Zoom > -1 & this.game.EditObj.TutOrder == -1)
      {
        if (this.ButtonZoomOutId > 0 + num1)
        {
          windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.ButtonZoomOutId)] + 1, this.SubPartY[this.SubpartNr(this.ButtonZoomOutId)] + 1, 1);
          windowReturnClass1.SetFlag(true);
        }
        else
        {
          int num10 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 53.0));
          int num11 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 106.0));
          int num12 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num3)) / 53.0));
          int num13 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num3)) / 106.0));
          int num14;
          int num15;
          if (this.game.EditObj.Zoom == 0)
          {
            this.game.EditObj.Zoom = -1;
            this.game.CornerX -= (int) Math.Round(Conversion.Int((double) num10 / 2.0));
            this.game.CornerY -= (int) Math.Round(Conversion.Int((double) num12 / 2.0));
            num14 = 27;
            num15 = 24;
          }
          else
          {
            this.game.EditObj.Zoom = 0;
            this.game.CornerX -= (int) Math.Round(Conversion.Int((double) num11 / 2.0));
            this.game.CornerY -= (int) Math.Round(Conversion.Int((double) num13 / 2.0));
            num14 = 53;
            num15 = 48;
          }
          if ((double) this.game.CornerX + (double) this.game.ScreenWidth / (double) num14 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
            this.game.CornerX = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth) - (double) (this.game.ScreenWidth - 200) / (double) num14);
          if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num3)) / (double) num15 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
            this.game.CornerY = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num3)) / (double) num15);
          if (this.game.CornerX < 0)
            this.game.CornerX = 0;
          if (this.game.CornerY < 0)
            this.game.CornerY = 0;
          this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
          this.game.EditObj.TempCoordList = new CoordList();
          windowReturnClass1.AddCommand(1, 12);
          windowReturnClass1.AddCommand(2, 12);
          windowReturnClass1.AddCommand(4, 9);
          windowReturnClass1.AddCommand(4, 67);
          windowReturnClass1.AddCommand(4, 68);
          windowReturnClass1.SetFlag(true);
          return windowReturnClass1;
        }
      }
      if (this.game.EditObj.OrderType == 0)
      {
        if (nr == 190 & this.game.EditObj.UnitSelected > -1)
        {
          this.game.HandyFunctionsObj.NextUnit();
          this.game.HandyFunctionsObj.CenterOnXY(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y);
          this.game.EditObj.TempCoordList = new CoordList();
          windowReturnClass1.AddCommand(4, 12);
          windowReturnClass1.AddCommand(4, 9);
          windowReturnClass1.AddCommand(4, 67);
          windowReturnClass1.AddCommand(4, 68);
          windowReturnClass1.AddCommand(4, 69);
          windowReturnClass1.SetFlag(true);
          return windowReturnClass1;
        }
        if (nr == 188 & this.game.EditObj.UnitSelected > -1)
        {
          this.game.HandyFunctionsObj.NextUnit2();
          this.game.HandyFunctionsObj.CenterOnXY(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y);
          this.game.EditObj.TempCoordList = new CoordList();
          windowReturnClass1.AddCommand(4, 12);
          windowReturnClass1.AddCommand(4, 9);
          windowReturnClass1.AddCommand(4, 67);
          windowReturnClass1.AddCommand(4, 68);
          windowReturnClass1.AddCommand(4, 69);
          windowReturnClass1.SetFlag(true);
          return windowReturnClass1;
        }
        if (nr == 77 & this.MoveButtonId > 1 + num1)
        {
          windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.MoveButtonId)] + 1, this.SubPartY[this.SubpartNr(this.MoveButtonId)] + 1, 1);
          windowReturnClass1.SetFlag(true);
        }
        else if (nr == 77 & (double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode)
        {
          int mouseCounter = this.MouseCounter;
          for (int index = 0; index <= mouseCounter; ++index)
          {
            if (this.MouseData[index] == 201)
            {
              WindowReturnClass windowReturnClass16 = this.HandleMouseClick(this.MouseRect[index].X + 1, this.MouseRect[index].Y + 1, 1);
              windowReturnClass16.SetFlag(true);
              return windowReturnClass16;
            }
          }
        }
        if (nr == 71)
        {
          if (this.GroupMoveButtonId > 1 + num1)
          {
            windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.GroupMoveButtonId)] + 1, this.SubPartY[this.SubpartNr(this.GroupMoveButtonId)] + 1, 1);
            windowReturnClass1.SetFlag(true);
          }
          else if (this.MoveButtonId > 1 + num1)
          {
            windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.MoveButtonId)] + 1, this.SubPartY[this.SubpartNr(this.MoveButtonId)] + 1, 1);
            windowReturnClass1.SetFlag(true);
          }
          else if ((double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode)
          {
            int mouseCounter = this.MouseCounter;
            for (int index = 0; index <= mouseCounter; ++index)
            {
              if (this.MouseData[index] == 202)
              {
                WindowReturnClass windowReturnClass17 = this.HandleMouseClick(this.MouseRect[index].X + 1, this.MouseRect[index].Y + 1, 1);
                windowReturnClass17.SetFlag(true);
                return windowReturnClass17;
              }
            }
          }
        }
        if (nr == 83 & this.StrategicButtonId > 1 + num1 & (double) this.game.Data.RuleVar[520] == 0.0)
        {
          windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.StrategicButtonId)] + 1, this.SubPartY[this.SubpartNr(this.StrategicButtonId)] + 1, 1);
          windowReturnClass1.SetFlag(true);
        }
        if (nr == 72 & this.HqUnitButtonId > 1 + num1)
        {
          windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.HqUnitButtonId)] + 1, this.SubPartY[this.SubpartNr(this.HqUnitButtonId)] + 1, 1);
          windowReturnClass1.SetFlag(true);
        }
        if (nr == 78 & this.NewUnitButtonId > 1 + num1)
        {
          windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.NewUnitButtonId)] + 1, this.SubPartY[this.SubpartNr(this.NewUnitButtonId)] + 1, 1);
          windowReturnClass1.SetFlag(true);
        }
        if (nr == 79 & this.HqProdButtonId > 1 + num1)
        {
          windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.HqProdButtonId)] + 1, this.SubPartY[this.SubpartNr(this.HqProdButtonId)] + 1, 1);
          windowReturnClass1.SetFlag(true);
        }
        if (nr == 80 & this.ProdButtonId > 1 + num1)
        {
          windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.ProdButtonId)] + 1, this.SubPartY[this.SubpartNr(this.ProdButtonId)] + 1, 1);
          windowReturnClass1.SetFlag(true);
        }
        if (this.game.SelectX > -1)
        {
          if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType].IsSea)
          {
            if (nr == 65 & this.AttackButtonId > 1 + num1 && this.SubpartNr(this.AttackButtonId) > -1)
            {
              windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.AttackButtonId)] + 1, this.SubPartY[this.SubpartNr(this.AttackButtonId)] + 1, 1);
              windowReturnClass1.SetFlag(true);
            }
            if (nr == 66 & this.ArtAttackButtonId > 1 + num1)
            {
              windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.ArtAttackButtonId)] + 1, this.SubPartY[this.SubpartNr(this.ArtAttackButtonId)] + 1, 1);
              windowReturnClass1.SetFlag(true);
            }
          }
          else
          {
            if (nr == 65 & this.seaAttackButtonId > 1 + num1)
            {
              windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.seaAttackButtonId)] + 1, this.SubPartY[this.SubpartNr(this.seaAttackButtonId)] + 1, 1);
              windowReturnClass1.SetFlag(true);
            }
            if (nr == 66 & this.ArtAttackButtonId > 1 + num1)
            {
              windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.ArtAttackButtonId)] + 1, this.SubPartY[this.SubpartNr(this.ArtAttackButtonId)] + 1, 1);
              windowReturnClass1.SetFlag(true);
            }
          }
          if (nr == 90 & this.AirAttackButtonId > 1 + num1)
          {
            windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.AirAttackButtonId)] + 1, this.SubPartY[this.SubpartNr(this.AirAttackButtonId)] + 1, 1);
            windowReturnClass1.SetFlag(true);
          }
        }
        if (nr == 76 & this.LoadButtonId > 1 + num1)
        {
          windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.LoadButtonId)] + 1, this.SubPartY[this.SubpartNr(this.LoadButtonId)] + 1, 1);
          windowReturnClass1.SetFlag(true);
        }
        if (nr == 85 & this.UnLoadButtonID > 1 + num1)
        {
          windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.UnLoadButtonID)] + 1, this.SubPartY[this.SubpartNr(this.UnLoadButtonID)] + 1, 1);
          windowReturnClass1.SetFlag(true);
        }
        if (nr == 82 & this.InfraButtonId > 1 + num1)
        {
          windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.InfraButtonId)] + 1, this.SubPartY[this.SubpartNr(this.InfraButtonId)] + 1, 1);
          windowReturnClass1.SetFlag(true);
        }
        if (nr == 27 & this.game.EditObj.LayerSupplyOn)
        {
          windowReturnClass1.AddCommand(4, 12);
          windowReturnClass1.AddCommand(4, 9);
          windowReturnClass1.AddCommand(4, 67);
          windowReturnClass1.AddCommand(4, 68);
          this.game.EditObj.LayerSupplyOn = false;
          windowReturnClass1.SetFlag(true);
          return windowReturnClass1;
        }
      }
      if (this.game.EditObj.OrderType > 0)
      {
        if (nr == 77 & (double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode)
        {
          int mouseCounter = this.MouseCounter;
          for (int index = 0; index <= mouseCounter; ++index)
          {
            if (this.MouseData[index] == 201)
            {
              WindowReturnClass windowReturnClass18 = this.HandleMouseClick(this.MouseRect[index].X + 1, this.MouseRect[index].Y + 1, 1);
              windowReturnClass18.SetFlag(true);
              return windowReturnClass18;
            }
          }
        }
        if (nr == 71 & (double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode)
        {
          int mouseCounter = this.MouseCounter;
          for (int index = 0; index <= mouseCounter; ++index)
          {
            if (this.MouseData[index] == 202)
            {
              WindowReturnClass windowReturnClass19 = this.HandleMouseClick(this.MouseRect[index].X + 1, this.MouseRect[index].Y + 1, 1);
              windowReturnClass19.SetFlag(true);
              return windowReturnClass19;
            }
          }
        }
      }
      if (this.game.EditObj.OrderType > 0 & this.Cancelid > 0 + num1)
      {
        if (nr == 27)
        {
          windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.Cancelid)] + 1, this.SubPartY[this.SubpartNr(this.Cancelid)] + 1, 1);
          windowReturnClass1.SetFlag(true);
        }
      }
      else if (this.game.EditObj.OrderType > 0 & (nr == 27 | nr == 32) & (double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode & this.game.EditObj.udsUnitOrderMode > 0)
      {
        int mouseCounter = this.MouseCounter;
        for (int index = 0; index <= mouseCounter; ++index)
        {
          if (this.MouseData[index] == 203)
          {
            WindowReturnClass windowReturnClass20 = this.HandleMouseClick(this.MouseRect[index].X + 1, this.MouseRect[index].Y + 1, 1);
            windowReturnClass20.SetFlag(true);
            return windowReturnClass20;
          }
        }
      }
      if (this.game.EditObj.OrderType > 0 & this.OkId > 0 + num1 && nr == 32)
      {
        windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.OkId)] + 1, this.SubPartY[this.SubpartNr(this.OkId)] + 1, 1);
        windowReturnClass1.SetFlag(true);
      }
      if (this.game.EditObj.OrderType > 0 & this.OkId == 0 & this.BattleId > 0 + num1)
      {
        if (this.game.SelectX == this.game.EditObj.TargetX & this.game.SelectY == this.game.EditObj.TargetY && nr == 32)
        {
          windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.BattleId)] + 1, this.SubPartY[this.SubpartNr(this.BattleId)] + 1, 1);
          windowReturnClass1.SetFlag(true);
        }
        if (nr == 65)
        {
          windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.BattleId)] + 1, this.SubPartY[this.SubpartNr(this.BattleId)] + 1, 1);
          windowReturnClass1.SetFlag(true);
        }
      }
      if (this.game.EditObj.OrderType == 1 & this.Cancelid > 0 && nr == 32)
      {
        windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.Cancelid)] + 1, this.SubPartY[this.SubpartNr(this.Cancelid)] + 1, 1);
        windowReturnClass1.SetFlag(true);
      }
      if (this.game.EditObj.OrderType == 48 & this.Cancelid > 0 && nr == 32)
      {
        windowReturnClass1 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.Cancelid)] + 1, this.SubPartY[this.SubpartNr(this.Cancelid)] + 1, 1);
        windowReturnClass1.SetFlag(true);
      }
      return windowReturnClass1;
    }

    public void dostuff2(Graphics g)
    {
      SizeF sizeF1 = new SizeF();
      int num1 = 31;
      int num2 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      if ((double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode)
      {
        num2 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0 - 128.0) + 240;
        num1 += 16;
      }
      if (this.Info1Id > 0)
        this.RemoveSubPart(this.Info1Id);
      if (this.Cancelid > 0)
      {
        this.RemoveSubPart(this.Cancelid);
        this.Cancelid = 0;
      }
      if (this.OkId > 0)
      {
        this.RemoveSubPart(this.OkId);
        this.OkId = 0;
      }
      if (this.KillId > 0)
      {
        this.RemoveSubPart(this.KillId);
        this.KillId = 0;
      }
      if (this.Ok2Id > 0)
      {
        this.RemoveSubPart(this.Ok2Id);
        this.Ok2Id = 0;
      }
      if (this.Kill2Id > 0)
      {
        this.RemoveSubPart(this.Kill2Id);
        this.Kill2Id = 0;
      }
      if (this.GuiDownId > 0)
      {
        this.RemoveSubPart(this.GuiDownId);
        this.GuiDownId = 0;
      }
      if (this.PopupButtonId > 0)
      {
        this.RemoveSubPart(this.PopupButtonId);
        this.PopupButtonId = 0;
      }
      if (this.SupplyLayerButtonId > 0)
      {
        this.RemoveSubPart(this.SupplyLayerButtonId);
        this.SupplyLayerButtonId = 0;
      }
      if (this.BlowBridgeButtonId > 0)
      {
        this.RemoveSubPart(this.BlowBridgeButtonId);
        this.BlowBridgeButtonId = 0;
      }
      if (this.TransportButtonId > 0)
      {
        this.RemoveSubPart(this.TransportButtonId);
        this.TransportButtonId = 0;
      }
      if (this.TransportButtonId2 > 0)
      {
        this.RemoveSubPart(this.TransportButtonId2);
        this.TransportButtonId2 = 0;
      }
      if (this.BattleGroupButtonId > 0)
      {
        this.RemoveSubPart(this.BattleGroupButtonId);
        this.BattleGroupButtonId = 0;
      }
      if (this.BattleGroupButtonId2 > 0)
      {
        this.RemoveSubPart(this.BattleGroupButtonId2);
        this.BattleGroupButtonId2 = 0;
      }
      if (this.InfraButtonId > 0)
      {
        this.RemoveSubPart(this.InfraButtonId);
        this.InfraButtonId = 0;
      }
      if (this.BuildButtonId > 0)
      {
        this.RemoveSubPart(this.BuildButtonId);
        this.BuildButtonId = 0;
      }
      if (this.AirReconButtonId > 0)
      {
        this.RemoveSubPart(this.AirReconButtonId);
        this.AirReconButtonId = 0;
      }
      if (this.MoveButtonId > 0)
      {
        this.RemoveSubPart(this.MoveButtonId);
        this.MoveButtonId = 0;
      }
      if (this.GroupMoveButtonId > 0)
      {
        this.RemoveSubPart(this.GroupMoveButtonId);
        this.GroupMoveButtonId = 0;
      }
      if (this.NextButtonId > 0)
      {
        this.RemoveSubPart(this.NextButtonId);
        this.NextButtonId = 0;
      }
      if (this.HqUnitButtonId > 0)
      {
        this.RemoveSubPart(this.HqUnitButtonId);
        this.HqUnitButtonId = 0;
      }
      if (this.NewUnitButtonId > 0)
      {
        this.RemoveSubPart(this.NewUnitButtonId);
        this.NewUnitButtonId = 0;
      }
      if (this.NewUnitButtonId2 > 0)
      {
        this.RemoveSubPart(this.NewUnitButtonId2);
        this.NewUnitButtonId2 = 0;
      }
      if (this.NewUnitButton2Id2 > 0)
      {
        this.RemoveSubPart(this.NewUnitButton2Id2);
        this.NewUnitButton2Id2 = 0;
      }
      if (this.NewUnitButton2Id > 0)
      {
        this.RemoveSubPart(this.NewUnitButton2Id);
        this.NewUnitButton2Id = 0;
      }
      if (this.TransferButtonId > 0)
      {
        this.RemoveSubPart(this.TransferButtonId);
        this.TransferButtonId = 0;
      }
      if (this.AttackButtonId > 0)
      {
        this.RemoveSubPart(this.AttackButtonId);
        this.AttackButtonId = 0;
      }
      if (this.seaAttackButtonId > 0)
      {
        this.RemoveSubPart(this.seaAttackButtonId);
        this.seaAttackButtonId = 0;
      }
      if (this.ArtAttackButtonId > 0)
      {
        this.RemoveSubPart(this.ArtAttackButtonId);
        this.ArtAttackButtonId = 0;
      }
      if (this.SeaArtAttackButtonId > 0)
      {
        this.RemoveSubPart(this.SeaArtAttackButtonId);
        this.SeaArtAttackButtonId = 0;
      }
      if (this.AirAttackButtonId > 0)
      {
        this.RemoveSubPart(this.AirAttackButtonId);
        this.AirAttackButtonId = 0;
      }
      if (this.InterdictButtonId > 0)
      {
        this.RemoveSubPart(this.InterdictButtonId);
        this.InterdictButtonId = 0;
      }
      if (this.StrategicButtonId > 0)
      {
        this.RemoveSubPart(this.StrategicButtonId);
        this.StrategicButtonId = 0;
      }
      if (this.GroupStrategicButtonId > 0)
      {
        this.RemoveSubPart(this.GroupStrategicButtonId);
        this.GroupStrategicButtonId = 0;
      }
      if (this.ParadropButtonId > 0)
      {
        this.RemoveSubPart(this.ParadropButtonId);
        this.ParadropButtonId = 0;
      }
      if (this.LoadButtonId > 0)
      {
        this.RemoveSubPart(this.LoadButtonId);
        this.LoadButtonId = 0;
      }
      if (this.UnLoadButtonID > 0)
      {
        this.RemoveSubPart(this.UnLoadButtonID);
        this.UnLoadButtonID = 0;
      }
      if (this.ResearchId > 0)
      {
        this.RemoveSubPart(this.ResearchId);
        this.ResearchId = 0;
      }
      if (this.DipId > 0)
      {
        this.RemoveSubPart(this.DipId);
        this.DipId = 0;
      }
      if (this.HistoryId > 0)
      {
        this.RemoveSubPart(this.HistoryId);
        this.HistoryId = 0;
      }
      if (this.SaveId > 0)
      {
        this.RemoveSubPart(this.SaveId);
        this.SaveId = 0;
      }
      if (this.QuitID > 0)
      {
        this.RemoveSubPart(this.QuitID);
        this.QuitID = 0;
      }
      if (this.HqProdButtonId > 0)
      {
        this.RemoveSubPart(this.HqProdButtonId);
        this.HqProdButtonId = 0;
      }
      if (this.ProdButtonId > 0)
      {
        this.RemoveSubPart(this.ProdButtonId);
        this.ProdButtonId = 0;
      }
      if (this.disbandid > 0)
      {
        this.RemoveSubPart(this.disbandid);
        this.disbandid = 0;
      }
      if (this.PrefsButtonId > 0)
      {
        this.RemoveSubPart(this.PrefsButtonId);
        this.PrefsButtonId = 0;
      }
      if (this.AirSupplyButtonId > 0)
      {
        this.RemoveSubPart(this.AirSupplyButtonId);
        this.AirSupplyButtonId = 0;
      }
      if (this.StatisticsButtonId > 0)
      {
        this.RemoveSubPart(this.StatisticsButtonId);
        this.StatisticsButtonId = 0;
      }
      if (this.BlowLocationButtonId > 0)
      {
        this.RemoveSubPart(this.BlowLocationButtonId);
        this.BlowLocationButtonId = 0;
      }
      if (this.OrderSurrenderButtonId > 0)
      {
        this.RemoveSubPart(this.OrderSurrenderButtonId);
        this.OrderSurrenderButtonId = 0;
      }
      if (this.HexUnitButtonId2 > 0)
      {
        this.RemoveSubPart(this.HexUnitButtonId2);
        this.HexUnitButtonId2 = 0;
      }
      if (this.HexUnitButtonId > 0)
      {
        this.RemoveSubPart(this.HexUnitButtonId);
        this.HexUnitButtonId = 0;
      }
      if (this.ShowAsId2 > 0)
      {
        this.RemoveSubPart(this.ShowAsId2);
        this.ShowAsId2 = 0;
      }
      if (this.ShowAsId > 0)
      {
        this.RemoveSubPart(this.ShowAsId);
        this.ShowAsId = 0;
      }
      if (this.NewUnitButton2Id > 0)
      {
        this.RemoveSubPart(this.NewUnitButton2Id);
        this.NewUnitButton2Id = 0;
      }
      if (this.NewUnitButton2Id2 > 0)
      {
        this.RemoveSubPart(this.NewUnitButton2Id2);
        this.NewUnitButton2Id2 = 0;
      }
      if (this.GiveUnitId > 0)
      {
        this.RemoveSubPart(this.GiveUnitId);
        this.GiveUnitId = 0;
      }
      if (this.GiveHexId > 0)
      {
        this.RemoveSubPart(this.GiveHexId);
        this.GiveHexId = 0;
      }
      if (this.SFDesignButtonId > 0)
      {
        this.RemoveSubPart(this.SFDesignButtonId);
        this.SFDesignButtonId = 0;
      }
      if (this.OfficerId > 0)
      {
        this.RemoveSubPart(this.OfficerId);
        this.OfficerId = 0;
      }
      if (this.OfficerId2 > 0)
      {
        this.RemoveSubPart(this.OfficerId2);
        this.OfficerId2 = 0;
      }
      if (this.ButtonZoomInId > 0)
      {
        this.RemoveSubPart(this.ButtonZoomInId);
        this.ButtonZoomInId = 0;
      }
      if (this.ButtonZoomInId2 > 0)
      {
        this.RemoveSubPart(this.ButtonZoomInId2);
        this.ButtonZoomInId2 = 0;
      }
      if (this.ButtonZoomOutId > 0)
      {
        this.RemoveSubPart(this.ButtonZoomOutId);
        this.ButtonZoomOutId = 0;
      }
      if (this.ButtonZoomOutId2 > 0)
      {
        this.RemoveSubPart(this.ButtonZoomOutId2);
        this.ButtonZoomOutId2 = 0;
      }
      if (this.ButtonStackedUnitId > 0)
      {
        this.RemoveSubPart(this.ButtonStackedUnitId);
        this.ButtonStackedUnitId = 0;
      }
      if (this.ButtonStackedUnitId2 > 0)
      {
        this.RemoveSubPart(this.ButtonStackedUnitId2);
        this.ButtonStackedUnitId2 = 0;
      }
      if (this.SupplyLayerButtonId2 > 0)
      {
        this.RemoveSubPart(this.SupplyLayerButtonId2);
        this.SupplyLayerButtonId2 = 0;
      }
      if (this.BlowBridgeButtonId2 > 0)
      {
        this.RemoveSubPart(this.BlowBridgeButtonId2);
        this.BlowBridgeButtonId2 = 0;
      }
      if (this.InfraButtonId2 > 0)
      {
        this.RemoveSubPart(this.InfraButtonId2);
        this.InfraButtonId2 = 0;
      }
      if (this.BuildButtonId2 > 0)
      {
        this.RemoveSubPart(this.BuildButtonId2);
        this.BuildButtonId2 = 0;
      }
      if (this.AirReconButtonId2 > 0)
      {
        this.RemoveSubPart(this.AirReconButtonId2);
        this.AirReconButtonId2 = 0;
      }
      if (this.MoveButtonId2 > 0)
      {
        this.RemoveSubPart(this.MoveButtonId2);
        this.MoveButtonId2 = 0;
      }
      if (this.GroupMoveButtonId2 > 0)
      {
        this.RemoveSubPart(this.GroupMoveButtonId2);
        this.GroupMoveButtonId2 = 0;
      }
      if (this.NextButtonId2 > 0)
      {
        this.RemoveSubPart(this.NextButtonId2);
        this.NextButtonId2 = 0;
      }
      if (this.HqUnitButtonId2 > 0)
      {
        this.RemoveSubPart(this.HqUnitButtonId2);
        this.HqUnitButtonId2 = 0;
      }
      if (this.NewUnitButtonId > 0)
      {
        this.RemoveSubPart(this.NewUnitButtonId2);
        this.NewUnitButtonId2 = 0;
      }
      if (this.NewUnitButtonId2 > 0)
      {
        this.RemoveSubPart(this.NewUnitButtonId2);
        this.NewUnitButtonId2 = 0;
      }
      if (this.TransferButtonId2 > 0)
      {
        this.RemoveSubPart(this.TransferButtonId2);
        this.TransferButtonId2 = 0;
      }
      if (this.AttackButtonId2 > 0)
      {
        this.RemoveSubPart(this.AttackButtonId2);
        this.AttackButtonId2 = 0;
      }
      if (this.seaAttackButtonId2 > 0)
      {
        this.RemoveSubPart(this.seaAttackButtonId2);
        this.seaAttackButtonId2 = 0;
      }
      if (this.ArtAttackButtonId2 > 0)
      {
        this.RemoveSubPart(this.ArtAttackButtonId2);
        this.ArtAttackButtonId2 = 0;
      }
      if (this.SeaArtAttackButtonId2 > 0)
      {
        this.RemoveSubPart(this.SeaArtAttackButtonId2);
        this.SeaArtAttackButtonId2 = 0;
      }
      if (this.AirAttackButtonId2 > 0)
      {
        this.RemoveSubPart(this.AirAttackButtonId2);
        this.AirAttackButtonId2 = 0;
      }
      if (this.InterdictButtonId2 > 0)
      {
        this.RemoveSubPart(this.InterdictButtonId2);
        this.InterdictButtonId2 = 0;
      }
      if (this.StrategicButtonId2 > 0)
      {
        this.RemoveSubPart(this.StrategicButtonId2);
        this.StrategicButtonId2 = 0;
      }
      if (this.GroupStrategicButtonId2 > 0)
      {
        this.RemoveSubPart(this.GroupStrategicButtonId2);
        this.GroupStrategicButtonId2 = 0;
      }
      if (this.ParadropButtonId2 > 0)
      {
        this.RemoveSubPart(this.ParadropButtonId2);
        this.ParadropButtonId2 = 0;
      }
      if (this.LoadButtonId2 > 0)
      {
        this.RemoveSubPart(this.LoadButtonId2);
        this.LoadButtonId2 = 0;
      }
      if (this.UnLoadButtonID2 > 0)
      {
        this.RemoveSubPart(this.UnLoadButtonID2);
        this.UnLoadButtonID2 = 0;
      }
      if (this.ResearchId2 > 0)
      {
        this.RemoveSubPart(this.ResearchId2);
        this.ResearchId2 = 0;
      }
      if (this.DipId2 > 0)
      {
        this.RemoveSubPart(this.DipId2);
        this.DipId2 = 0;
      }
      if (this.HistoryId2 > 0)
      {
        this.RemoveSubPart(this.HistoryId2);
        this.HistoryId2 = 0;
      }
      if (this.SaveId2 > 0)
      {
        this.RemoveSubPart(this.SaveId2);
        this.SaveId2 = 0;
      }
      if (this.QuitID2 > 0)
      {
        this.RemoveSubPart(this.QuitID2);
        this.QuitID2 = 0;
      }
      if (this.HqProdButtonId2 > 0)
      {
        this.RemoveSubPart(this.HqProdButtonId2);
        this.HqProdButtonId2 = 0;
      }
      if (this.ProdButtonId2 > 0)
      {
        this.RemoveSubPart(this.ProdButtonId2);
        this.ProdButtonId2 = 0;
      }
      if (this.disbandid2 > 0)
      {
        this.RemoveSubPart(this.disbandid2);
        this.disbandid2 = 0;
      }
      if (this.PrefsButtonId2 > 0)
      {
        this.RemoveSubPart(this.PrefsButtonId2);
        this.PrefsButtonId2 = 0;
      }
      if (this.AirSupplyButtonId2 > 0)
      {
        this.RemoveSubPart(this.AirSupplyButtonId2);
        this.AirSupplyButtonId2 = 0;
      }
      if (this.StatisticsButtonId2 > 0)
      {
        this.RemoveSubPart(this.StatisticsButtonId2);
        this.StatisticsButtonId2 = 0;
      }
      if (this.BlowLocationButtonId2 > 0)
      {
        this.RemoveSubPart(this.BlowLocationButtonId2);
        this.BlowLocationButtonId2 = 0;
      }
      if (this.OrderSurrenderButtonId2 > 0)
      {
        this.RemoveSubPart(this.OrderSurrenderButtonId2);
        this.OrderSurrenderButtonId2 = 0;
      }
      if (this.GiveUnitId2 > 0)
      {
        this.RemoveSubPart(this.GiveUnitId2);
        this.GiveUnitId2 = 0;
      }
      if (this.GiveHexId2 > 0)
      {
        this.RemoveSubPart(this.GiveHexId2);
        this.GiveHexId2 = 0;
      }
      if (this.ChangeModelId > 0)
      {
        this.RemoveSubPart(this.ChangeModelId);
        this.ChangeModelId = 0;
      }
      if (this.ChangeModelId2 > 0)
      {
        this.RemoveSubPart(this.ChangeModelId2);
        this.ChangeModelId = 0;
      }
      if (this.ModelDesignerId > 0)
      {
        this.RemoveSubPart(this.ModelDesignerId);
        this.ChangeModelId = 0;
      }
      if (this.NewUnitButtonId > 0)
      {
        this.RemoveSubPart(this.NewUnitButtonId);
        this.NewUnitButtonId = 0;
      }
      if (this.NewUnitButton2Id > 0)
      {
        this.RemoveSubPart(this.NewUnitButton2Id);
        this.NewUnitButton2Id = 0;
      }
      if (this.NewUnitButton2Id2 > 0)
      {
        this.RemoveSubPart(this.NewUnitButton2Id2);
        this.NewUnitButton2Id2 = 0;
      }
      int index1 = 0;
      do
      {
        if (this.ActionButtonId[index1] > 0)
        {
          this.RemoveSubPart(this.ActionButtonId[index1]);
          this.ActionButtonId[index1] = 0;
        }
        if (this.ActionButtonId2[index1] > 0)
        {
          this.RemoveSubPart(this.ActionButtonId2[index1]);
          this.ActionButtonId2[index1] = 0;
        }
        ++index1;
      }
      while (index1 <= 10);
      if (this.FakeBackButtonId > 0)
      {
        this.RemoveSubPart(this.FakeBackButtonId);
        this.FakeBackButtonId = 0;
      }
      if (this.BattleId > 0)
      {
        this.RemoveSubPart(this.BattleId);
        this.BattleId = 0;
      }
      if (this.LeftId > 0)
      {
        this.RemoveSubPart(this.LeftId);
        this.LeftId = 0;
      }
      if (this.RightId > 0)
      {
        this.RemoveSubPart(this.RightId);
        this.RightId = 0;
      }
      if (this.AllId > 0)
      {
        this.RemoveSubPart(this.AllId);
        this.AllId = 0;
      }
      if (this.NoneId > 0)
      {
        this.RemoveSubPart(this.NoneId);
        this.NoneId = 0;
      }
      if (this.BattleId > 0)
      {
        this.RemoveSubPart(this.BattleId);
        this.BattleId = 0;
      }
      if (this.All2Id > 0)
      {
        this.RemoveSubPart(this.All2Id);
        this.All2Id = 0;
      }
      if (this.None2Id > 0)
      {
        this.RemoveSubPart(this.None2Id);
        this.None2Id = 0;
      }
      if (this.Battle2Id > 0)
      {
        this.RemoveSubPart(this.Battle2Id);
        this.Battle2Id = 0;
      }
      if (Information.IsNothing((object) this.game.EditObj.TempUnitList))
        this.game.EditObj.TempUnitList = new UnitList();
      if ((double) this.game.Data.RuleVar[701] < 1.0 | !this.game.EditObj.useLeftRightClickMode)
        this.game.EditObj.udsUnitOrderMode = 0;
      Rectangle rectangle;
      Rectangle trect1;
      string str1;
      if ((double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode)
      {
        int width = 75;
        int num3 = num2 - 200 + 12;
        int height = 70;
        int x = num3;
        if (this.game.EditObj.udsUnitOrderMode == 1)
        {
          ref Graphics local1 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCBIGBOTTOMTAB);
          ref Bitmap local2 = ref bitmap;
          Rectangle srcrect = new Rectangle(0, 0, 75, height - 3);
          rectangle = new Rectangle(x, 20, 75, height - 3);
          Rectangle destrect = rectangle;
          DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
          rectangle = new Rectangle(x, 20 + (70 - height), width, height);
          trect1 = rectangle;
          this.AddMouse(ref trect1, "", "Currently in Move Mode");
        }
        else
        {
          height = 40;
          ref Graphics local3 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCBIGBOTTOMTAB);
          ref Bitmap local4 = ref bitmap;
          rectangle = new Rectangle(0, 0, 75, height - 3);
          Rectangle srcrect = rectangle;
          Rectangle destrect = new Rectangle(x, 50, 75, height - 3);
          DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect, destrect);
          rectangle = new Rectangle(x, 20 + (70 - height), width, height);
          trect1 = rectangle;
          this.AddMouse(ref trect1, "", "Switch to Move Mode [M]", 201);
        }
        str1 = "MOVE";
        SizeF sizeF2 = g.MeasureString(str1, this.game.MarcFont16);
        DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont16, (int) Math.Round((double) x + (double) width / 2.0 - (double) sizeF2.Width / 2.0 - 2.0), 37 + (int) Math.Round((double) (90 - height) / 2.0), Color.White);
      }
      if ((double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode)
      {
        int width = 75;
        int num4 = num2 - 200 + 12;
        int height = 70;
        int x = num4 + 75;
        if (this.game.EditObj.udsUnitOrderMode == 48)
        {
          ref Graphics local5 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCBIGBOTTOMTAB);
          ref Bitmap local6 = ref bitmap;
          rectangle = new Rectangle(0, 0, 75, height - 3);
          Rectangle srcrect = rectangle;
          trect1 = new Rectangle(x, 20, 75, height - 3);
          Rectangle destrect = trect1;
          DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect, destrect);
          rectangle = new Rectangle(x, 20 + (70 - height), width, height);
          trect1 = rectangle;
          this.AddMouse(ref trect1, "", "Currently in Group Move Mode", 202);
        }
        else
        {
          height = 40;
          ref Graphics local7 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCBIGBOTTOMTAB);
          ref Bitmap local8 = ref bitmap;
          rectangle = new Rectangle(0, 0, 75, height - 3);
          Rectangle srcrect = rectangle;
          trect1 = new Rectangle(x, 50, 75, height - 3);
          Rectangle destrect = trect1;
          DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect, destrect);
          rectangle = new Rectangle(x, 20 + (70 - height), width, height);
          trect1 = rectangle;
          this.AddMouse(ref trect1, "", "Switch to Group Move Mode [G]", 202);
        }
        str1 = "GROUP";
        SizeF sizeF3 = g.MeasureString(str1, this.game.MarcFont16);
        DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont16, (int) Math.Round((double) x + (double) width / 2.0 - (double) sizeF3.Width / 2.0 - 2.0), 37 + (int) Math.Round((double) (90 - height) / 2.0), Color.White);
      }
      if ((double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode)
      {
        int width = 75;
        int num5 = num2 - 200 + 12;
        int height = 70;
        int x = num5 + 150;
        if (this.game.EditObj.udsUnitOrderMode < 1)
        {
          ref Graphics local9 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCBIGBOTTOMTAB);
          ref Bitmap local10 = ref bitmap;
          rectangle = new Rectangle(0, 0, 75, height - 3);
          Rectangle srcrect = rectangle;
          trect1 = new Rectangle(x, 20, 75, height - 3);
          Rectangle destrect = trect1;
          DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect, destrect);
          rectangle = new Rectangle(x, 20 + (70 - height), width, height);
          Rectangle trect2 = rectangle;
          this.AddMouse(ref trect2, "", "Currently in Order Mode", 203);
        }
        else
        {
          height = 40;
          ref Graphics local11 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCBIGBOTTOMTAB);
          ref Bitmap local12 = ref bitmap;
          rectangle = new Rectangle(0, 0, 75, height - 3);
          Rectangle srcrect = rectangle;
          trect1 = new Rectangle(x, 50, 75, height - 3);
          Rectangle destrect = trect1;
          DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect, destrect);
          rectangle = new Rectangle(x, 20 + (70 - height), width, height);
          Rectangle trect3 = rectangle;
          this.AddMouse(ref trect3, "", "Switch to Order Mode [Space/Escape]", 203);
        }
        str1 = "ORDER";
        SizeF sizeF4 = g.MeasureString(str1, this.game.MarcFont16);
        DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont16, (int) Math.Round((double) x + (double) width / 2.0 - (double) sizeF4.Width / 2.0 - 2.0), 37 + (int) Math.Round((double) (90 - height) / 2.0), Color.White);
      }
      SubPartClass tsubpart;
      if ((double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode & this.game.EditObj.OrderType == 0 & this.game.EditObj.udsUnitOrderMode == 0)
      {
        this.GuiDownId = 1;
        if (this.game.Data.Round == 0)
          this.GuiDownId = 0;
        int num6 = 5;
        if (this.GuiDownId > 0)
        {
          if (!this.game.EditObj.GuiDown)
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONGUIDOWN, tDescript: "Move Bottom GUI down & Get Larger Map [PgDown]", tBackbitmap: (ref this.OwnBitmap), bbx: num6, bby: num1, totherback: 1, tsize: 29);
            this.GuiDownId = this.AddSubPart(ref tsubpart, num6, num1, 29, 29, 1);
          }
          else
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONGUIUP, tDescript: "Move Bottm GUI up & Get unit info", tBackbitmap: (ref this.OwnBitmap), bbx: num6, bby: num1, totherback: 1, tsize: 29);
            this.GuiDownId = this.AddSubPart(ref tsubpart, num6, num1, 29, 29, 1);
          }
        }
      }
      if ((double) this.game.Data.RuleVar[419] > 0.0 & this.game.Data.Product >= 6 & this.game.EditObj.MouseOverX > -1 & !Information.IsNothing((object) this.game.EditObj.airRangeTempLos))
      {
        if (this.game.EditObj.UnitSelected > -1)
        {
          int num7 = this.game.EditObj.airRangeTempLos.Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY];
          int num8 = this.game.EditObj.airRangeMaxObstruct.Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY];
          int num9 = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, 0, this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY, 0, 19);
          float num10 = this.game.Data.RuleVar[420];
          int num11 = num9;
          for (int index2 = 2; index2 <= num11; ++index2)
          {
            if ((double) index2 > (double) this.game.Data.RuleVar[422])
              num10 = 0.0f;
            else
              num10 *= this.game.Data.RuleVar[421];
          }
          int num12 = this.game.ScreenWidth - 290;
          string str2;
          if (num7 > 0)
          {
            string str3 = this.game.EditObj.MouseOverX.ToString() + "," + this.game.EditObj.MouseOverY.ToString() + " - Los:" + num7.ToString() + " - Obs:" + num8.ToString();
            str2 = (double) num10 <= 0.0 ? str3 + " - To far" : str3 + " - Dis: /" + num10.ToString();
          }
          else
            str2 = this.game.EditObj.MouseOverX.ToString() + "," + this.game.EditObj.MouseOverY.ToString() + " - No Los";
          str1 = str2 + " - Hid: " + Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY].LandscapeType].HidePts));
          SizeF sizeF5 = g.MeasureString(str1, this.game.MarcFont16);
          DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont4, (int) Math.Round((double) (num12 + 150) - (double) sizeF5.Width / 2.0 - 2.0), 8, Color.LightGray);
        }
        else
        {
          int num13 = this.game.ScreenWidth - 290;
          str1 = "No Unit selected";
          SizeF sizeF6 = g.MeasureString(str1, this.game.MarcFont16);
          DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont4, (int) Math.Round((double) (num13 + 150) - (double) sizeF6.Width / 2.0 - 2.0), 8, Color.LightGray);
        }
      }
      if (this.game.EditObj.OrderType == 0 & this.game.EditObj.udsUnitOrderMode < 1 & !this.game.EditObj.LayerSupplyOn)
      {
        if (!((double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode))
        {
          this.GuiDownId = 1;
          if (this.game.Data.Round == 0)
            this.GuiDownId = 0;
          int num14 = num2 + 40;
          if (this.GuiDownId > 0)
          {
            if (!this.game.EditObj.GuiDown)
            {
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONGUIDOWN, tDescript: "Move Bottom GUI down & Get Larger Map [PgDown]", tBackbitmap: (ref this.OwnBitmap), bbx: num14, bby: num1, totherback: 1, tsize: 29);
              this.GuiDownId = this.AddSubPart(ref tsubpart, num14, num1, 29, 29, 1);
            }
            else
            {
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONGUIUP, tDescript: "Move Bottm GUI up & Get unit info", tBackbitmap: (ref this.OwnBitmap), bbx: num14, bby: num1, totherback: 1, tsize: 29);
              this.GuiDownId = this.AddSubPart(ref tsubpart, num14, num1, 29, 29, 1);
            }
          }
        }
        this.PrefsButtonId = 1;
        if (this.game.Data.Round > 0)
        {
          this.ResearchId = 1;
          this.SFDesignButtonId = 1;
          if (this.game.Data.Turn > -1 && this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == -1 && (double) this.game.Data.RuleVar[531] == 1.0)
            this.ModelDesignerId = 1;
          this.DipId = 1;
          if (this.game.Data.RegimeObj[this.game.Data.Turn].HistoryStepCounter > -1)
            this.HistoryId = 1;
          else
            this.historytext = "No history records to report!";
          this.NextButtonId = 1;
          if (this.game.Data.Winner == -1)
          {
            if (this.game.Data.RegimeObj[this.game.Data.Turn].Sleep)
              this.ordersurrendertext = "You already surrendered.";
            else
              this.OrderSurrenderButtonId = 1;
          }
          else
            this.ordersurrendertext = "Somebody already won the game.";
          this.StatisticsButtonId = 1;
        }
        this.ButtonStackedUnitId = 0;
        if (this.game.EditObj.Zoom == 1)
          this.ButtonStackedUnitId = 1;
        if (this.game.SelectX > -1 & this.game.SelectY > -1)
        {
          this.HexUnitButtonId = 1;
          this.ShowAsId = 1;
          this.ButtonZoomInId = 1;
          this.ButtonZoomOutId = 1;
          this.OfficerId = 0;
          if (this.game.Data.Round > 0 && (double) this.game.Data.RuleVar[343] == 1.0)
            this.OfficerId = 1;
          if (this.game.SelectX <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth && this.game.SelectY <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
          {
            if (!this.game.Data.ShrowdOn)
            {
              if (this.game.EditObj.UnitSelected > -1)
              {
                if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.Turn) && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ | (double) this.game.Data.RuleVar[887] == 1.0)
                  this.SupplyLayerButtonId = 1;
              }
              else if ((double) this.game.Data.RuleVar[887] == 1.0)
                this.SupplyLayerButtonId = 1;
              if ((double) this.game.Data.RuleVar[887] == 1.0)
                this.SupplyLayerButtonId = 1;
            }
            else if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter > -1 && this.game.Data.UnitObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitList[0]].Regime == this.game.Data.Turn && this.game.Data.Round > 0)
              this.SupplyLayerButtonId = 1;
          }
        }
        if (this.game.SelectX > -1 && this.game.Data.Round == 0 & this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime > -1 && (double) this.game.Data.RuleVar[512] == 0.0)
          this.NewUnitButtonId = 1;
        if (this.game.EditObj.UnitSelected > -1)
        {
          if (this.game.Data.RegimeObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime].UberRegime == this.game.Data.Turn && !this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].ModelMaster > -1)
          {
            if (!this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].ModelMaster].Fixed)
            {
              if ((double) this.game.Data.RuleVar[531] == 1.0)
                this.ChangeModelId = 1;
            }
            else
              this.ChangeModelText = "This unit has a fixed model. You cannot change it.";
          }
          if (this.game.Data.Round == 0)
            this.ChangeModelId = 0;
          if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime == this.game.Data.Turn | this.game.Data.Round == 0)
          {
            if (this.game.Data.Turn > -1 && (double) this.game.Data.RuleVar[528] == 1.0 && this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == -1)
            {
              if (this.game.HandyFunctionsObj.HasAllies(this.game.Data.Turn, true))
                this.GiveUnitId = 1;
              else
                this.GiveUnitText = "You have no allies.";
            }
            if (this.game.Data.Round == 0)
              this.MoveButtonId = 1;
            else if (this.game.HandyFunctionsObj.CanUnitMove(this.game.EditObj.UnitSelected))
            {
              this.MoveButtonId = 1;
              if ((double) this.game.Data.RuleVar[954] == 1.0 | this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical > -1)
                this.GroupMoveButtonId = 1;
            }
            else
            {
              this.MoveButtonId = 0;
              this.MoveButtonText = "Unit does not have enough Action Points to move.";
              this.GroupMoveButtonId = 0;
              this.GroupMoveButtonText = "Unit does not have enough Action Points to move.";
            }
            if (this.game.Data.Round > 0 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].Type > 7 && (double) this.game.Data.RuleVar[894] > 0.0)
            {
              this.MoveButtonId = 0;
              this.MoveButtonText = "High command cannot move";
              this.GroupMoveButtonId = 0;
              this.GroupMoveButtonText = "High command cannot move";
            }
            if ((double) this.game.Data.RuleVar[521] == 0.0)
              this.HqUnitButtonId = 1;
            if (this.game.Data.Turn > -1 && this.game.HandyFunctionsObj.ExtraHQSwitchPPCost(this.game.EditObj.UnitSelected, false) > this.game.Data.RegimeObj[this.game.Data.Turn].ResPts & !this.game.EditObj.TutMode)
            {
              this.HqUnitButtonId = 0;
              this.HqUnitButtonText = "You dont have the required " + Conversion.Str((object) this.game.HandyFunctionsObj.ExtraHQSwitchPPCost(this.game.EditObj.UnitSelected, false)) + " PP to switch the HQ of this unit.";
            }
            if (!this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
            {
              if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].ModelMaster > -1)
              {
                if (!this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].ModelMaster].Fixed)
                {
                  if ((double) this.game.Data.RuleVar[531] == 1.0)
                    this.ChangeModelId = 1;
                }
                else
                  this.ChangeModelText = "This unit has a fixed model. You cannot change it.";
              }
            }
            else
              this.ChangeModelText = "You cannot change Model of a HQ unit.";
            if (this.game.Data.Round == 0)
              this.ChangeModelId = 0;
            if (this.game.Data.Round > 0)
            {
              if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SFCount == -1)
              {
                this.disbandid = 1;
                if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical > -1 && this.game.Data.RegimeObj[this.game.Data.Turn].ResPts + this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].PP < 0)
                {
                  this.disbandid = 0;
                  this.disbandtext = "You do not have the PP to disband the unit.";
                }
              }
              else
              {
                this.disbandid = 0;
                this.disbandtext = "You can only disband a unit with no subformations in it.";
              }
            }
            if (this.game.Data.Round > 0 & this.game.SelectX > -1)
            {
              int num15 = 0;
              if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location > -1 && this.game.Data.LocObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location].StructuralPts < this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location].Type].StructuralPts && this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location].Type].EPCost > 0)
                num15 = 1;
              if (this.game.HandyFunctionsObj.CanUnitBuild(this.game.EditObj.UnitSelected) | num15 == 1)
              {
                if (this.game.HandyFunctionsObj.GetLowestAp(this.game.EditObj.UnitSelected) > 0)
                  this.BuildButtonId = 1;
                else
                  this.buildbuttontext = "You cannot build/repair something if you have zero action points.";
              }
              else if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location > -1)
              {
                this.BuildButtonId = 0;
                this.buildbuttontext = "Location is not damaged / Unit cannot repair this location";
              }
              else
              {
                this.BuildButtonId = 1;
                this.buildbuttontext = "Not enough Engineer Pts to build a location.";
              }
            }
            if (this.game.Data.Round > 0)
            {
              if (this.game.HandyFunctionsObj.GetUnitEP(this.game.EditObj.UnitSelected) > 0)
              {
                if (this.game.HandyFunctionsObj.CanUnitInfra(this.game.EditObj.UnitSelected))
                {
                  if (this.game.HandyFunctionsObj.GetLowestAp(this.game.EditObj.UnitSelected) > 0)
                  {
                    this.InfraButtonId = 1;
                  }
                  else
                  {
                    this.InfraButtonId = 0;
                    this.infrabuttontext = "Unit has 0 action points.";
                  }
                }
                else
                {
                  this.InfraButtonId = 0;
                  this.infrabuttontext = !((double) this.game.Data.RuleVar[483] > 0.0 & this.game.Data.Product >= 6) ? "Unit does not have EP required or other side of river is enemy hex." : "Unit does not have the EP required.";
                }
              }
              else
              {
                this.InfraButtonId = 0;
                this.infrabuttontext = "Unit has no engineer points.";
              }
            }
            if (this.game.Data.Round > 0 & this.game.SelectX > -1 && (double) this.game.Data.RuleVar[474] > 0.0 & this.game.Data.Product >= 6)
            {
              if (this.game.HandyFunctionsObj.CanTransport(this.game.EditObj.UnitSelected))
                this.TransportButtonId = 1;
              else
                this.transportButtonText = "Unit is not capable of Transporting other Units.";
            }
            if (this.game.Data.Round > 0 & this.game.SelectX > -1 && (double) this.game.Data.RuleVar[475] > 0.0 & this.game.Data.Product >= 6)
              this.BattleGroupButtonId = 1;
            if (this.game.Data.Round > 0 & this.game.SelectX > -1)
            {
              if (this.game.HandyFunctionsObj.CanWeBlowBridge(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected))
              {
                if (this.game.HandyFunctionsObj.GetBlowBridgePts(this.game.EditObj.UnitSelected) > 0)
                {
                  if (this.game.HandyFunctionsObj.GetLowestAp(this.game.EditObj.UnitSelected) > 49)
                  {
                    this.BlowBridgeButtonId = 1;
                  }
                  else
                  {
                    this.BlowBridgeButtonId = 0;
                    this.blowbridgebuttontext = "You need at least 50 Action Pts for an attempt.";
                  }
                }
                else
                {
                  this.BlowBridgeButtonId = 0;
                  this.blowbridgebuttontext = "Unit does not have capability to blow bridge.";
                }
              }
              else
              {
                this.BlowBridgeButtonId = 0;
                this.blowbridgebuttontext = "No bridge is present in this hex.";
              }
              if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location > -1)
              {
                if (!this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location].Type].Invincible)
                {
                  if (this.game.HandyFunctionsObj.GetBlowBridgePts(this.game.EditObj.UnitSelected) > 0)
                  {
                    if (this.game.HandyFunctionsObj.GetLowestAp(this.game.EditObj.UnitSelected) > 49)
                    {
                      this.BlowLocationButtonId = 1;
                    }
                    else
                    {
                      this.blowlocationtext = "You need at least 50 Action Pts for an attempt.";
                      this.BlowLocationButtonId = 0;
                    }
                  }
                  else
                  {
                    this.blowlocationtext = "Unit does not have capability to raze location.";
                    this.BlowLocationButtonId = 0;
                  }
                }
                else
                {
                  this.blowlocationtext = "This locationtype cannot be damaged.";
                  this.BlowLocationButtonId = 0;
                }
              }
              else
              {
                this.blowlocationtext = "No Location in hex.";
                this.BlowLocationButtonId = 0;
              }
            }
            if (this.game.Data.Round > 0)
            {
              if (this.game.EditObj.UnitSelected > -1 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X == -1)
                this.game.EditObj.UnitSelected = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].OnBoard;
              if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].PassengerCounter == -1)
              {
                if ((double) this.game.Data.RuleVar[315] == 1.0 & !this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
                {
                  this.TransferButtonId = 0;
                  this.TransferButtonText = "You can only transfer from a HQ.";
                }
                else
                  this.TransferButtonId = 1;
                if (!this.game.HandyFunctionsObj.HasUnitAirSF(this.game.EditObj.UnitSelected) & !this.game.HandyFunctionsObj.HasUnitNavySF(this.game.EditObj.UnitSelected))
                {
                  if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y].get_APPenalty(this.game.Data.Turn) > 0)
                  {
                    this.strategicbuttontext = "You cant strategically transfer a unit from a hex you conquered in this turn.";
                    this.groupstrategictext = "You cant strategically transfer a unit from a hex you conquered in this turn.";
                  }
                  else if (!this.game.Data.UnitObj[this.game.EditObj.UnitSelected].DidAttack)
                  {
                    this.StrategicButtonId = 1;
                    if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].StartSize > -1)
                    {
                      int num16 = 1;
                      int unitCounter = this.game.Data.UnitCounter;
                      for (int index3 = 0; index3 <= unitCounter; ++index3)
                      {
                        if (this.game.Data.UnitObj[index3].Historical == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical & this.game.Data.UnitObj[index3].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index3].DidAttack)
                          num16 = 0;
                      }
                      if (num16 == 1)
                        this.GroupStrategicButtonId = 1;
                    }
                  }
                  else
                  {
                    this.strategicbuttontext = "You cannot strategic transfer a unit that participated in an attack.";
                    this.groupstrategictext = "You cannot strategic transfer a unit that participated in an attack.";
                  }
                }
                else
                {
                  this.groupstrategictext = "You cannot strategic transfer units with air or navy subformations.";
                  this.strategicbuttontext = "You cannot strategic transfer units with air or navy subformations.";
                }
              }
              else
              {
                this.TransferButtonText = "You cannot transfer while carrying passengers.";
                this.strategicbuttontext = "You cannot strategicly transfer a unit carrying passengers.";
                this.groupstrategictext = "You cannot strategicly transfer a unit carrying passengers.";
              }
            }
            if (this.game.Data.Round > 0)
            {
              if (this.game.HandyFunctionsObj.HasUnitAirSF(this.game.EditObj.UnitSelected))
              {
                if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location > -1)
                {
                  if (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location].Type].IsAirfield)
                  {
                    if (this.game.HandyFunctionsObj.GetUnitCarryCap(this.game.EditObj.UnitSelected, 2) > 0)
                      this.ParadropButtonId = 1;
                    else
                      this.paradropbuttontext = "Unit has no aircraft that can carry paratroopers.";
                    this.AirReconButtonId = 1;
                    if (this.game.HandyFunctionsObj.GetCarryCapPts(this.game.EditObj.UnitSelected, 2) > 0)
                    {
                      if (this.game.HandyFunctionsObj.GetLowestAirAp(this.game.EditObj.UnitSelected) >= 40)
                        this.AirSupplyButtonId = 1;
                      else
                        this.airsupplybuttontext = "You need a minimum of 40 ap for an airsupply mission.";
                    }
                    else
                      this.airsupplybuttontext = "Units air subformations have no carry points.";
                  }
                  else
                  {
                    this.paradropbuttontext = "Action must start from airfield. No airfield in this hex.";
                    this.AirReconButtonText = "Action must start from airfield. No airfield in this hex.";
                    this.airsupplybuttontext = "Action must start from airfield. No airfield in this hex.";
                  }
                }
                else
                {
                  this.paradropbuttontext = "Action must start from airfield. No airfield in this hex.";
                  this.AirReconButtonText = "Action must start from airfield. No airfield in this hex.";
                  this.airsupplybuttontext = "Action must start from airfield. No airfield in this hex.";
                }
                if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType].IsSea)
                  this.AirReconButtonId = 1;
              }
              else
              {
                this.paradropbuttontext = "Unit has no aircraft.";
                this.AirReconButtonText = "Unit has no aircraft.";
                this.airsupplybuttontext = "Unit has no aircraft";
              }
            }
            if (this.game.HandyFunctionsObj.HasUnitNavySF(this.game.EditObj.UnitSelected))
            {
              if (this.game.HandyFunctionsObj.GetUnitCarryCap(this.game.EditObj.UnitSelected, 1) > 0)
              {
                if (this.game.HandyFunctionsObj.CanUnitLoadaUnit(this.game.EditObj.UnitSelected))
                  this.LoadButtonId = 1;
                else
                  this.loadbuttontext = "No unit around to be loaded by this unit.";
              }
              else
                this.loadbuttontext = "Unit has no ships that can carry cargo.";
              if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].PassengerCounter > -1)
              {
                if (this.game.EditObj.SFSelected > this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SFCount)
                {
                  if (this.game.HandyFunctionsObj.GetLowestAp(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].PassengerList[this.game.EditObj.SFSelected - (1 + this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SFCount)]) > 0 | this.game.Data.Round == 0)
                    this.UnLoadButtonID = 1;
                  else if ((double) this.game.Data.RuleVar[880] > 0.0)
                  {
                    if (this.game.HandyFunctionsObj.IsHexPort(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, 0))
                      this.UnLoadButtonID = 1;
                    else
                      this.unloadbuttontext = "Passenger must have more then 0 ap to unload outside a port";
                  }
                  else
                    this.unloadbuttontext = "Passenger must have more then 0 ap to unload.";
                }
                else
                  this.unloadbuttontext = "Unit has passengers, but no unit is selected to unload";
              }
              else
                this.unloadbuttontext = "Unit has no passenger(s).";
            }
            else
            {
              this.loadbuttontext = "Unit has no navy subformations.";
              this.unloadbuttontext = "Unit has no navy subformations.";
            }
          }
          else
          {
            this.HqUnitButtonText = "Not a friendly unit.";
            if (this.game.Data.Turn > -1 && this.game.Data.RegimeObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime].UberRegime == this.game.Data.Turn)
            {
              this.HqUnitButtonId = 1;
              if (this.game.HandyFunctionsObj.ExtraHQSwitchPPCost(this.game.EditObj.UnitSelected, false) > this.game.Data.RegimeObj[this.game.Data.Turn].ResPts)
              {
                this.HqUnitButtonId = 0;
                this.HqUnitButtonText = "You dont have the required " + Conversion.Str((object) this.game.HandyFunctionsObj.ExtraHQSwitchPPCost(this.game.EditObj.UnitSelected, false)) + " PP to switch the HQ of this unit.";
              }
            }
            this.supplylayerbuttontext = "Not a friendly unit.";
            this.MoveButtonText = "Not a friendly unit.";
            this.GroupMoveButtonText = "Not a friendly unit.";
            this.disbandtext = "Not a friendly unit.";
            this.buildbuttontext = "Not a friendly unit.";
            this.infrabuttontext = "Not a friendly unit.";
            this.blowbridgebuttontext = "Not a friendly unit.";
            this.transportButtonText = "Not a friendly unit.";
            this.battlegroupText = "Not a friendly unit.";
            this.blowlocationtext = "Not a friendly unit.";
            this.TransferButtonText = "Not a friendly unit.";
            this.strategicbuttontext = "Not a friendly unit.";
            this.groupstrategictext = "Not a friendly unit.";
            this.paradropbuttontext = "Not a friendly unit.";
            this.AirReconButtonText = "Not a friendly unit.";
            this.airsupplybuttontext = "Not a friendly unit.";
            this.loadbuttontext = "Not a friendly unit.";
            this.unloadbuttontext = "Not a friendly unit.";
            this.GiveUnitText = "Not a friendly unit.";
            this.OfficerText = "Not a friendly unit.";
            this.ChangeModelText = "Not a friendly unit.";
          }
        }
        else
        {
          this.groupstrategictext = "No unit selected.";
          this.supplylayerbuttontext = "You must select a friendly HQ first.";
          this.MoveButtonText = "No unit selected.";
          this.GroupMoveButtonText = "No unit selected.";
          this.HqUnitButtonText = "No unit selected.";
          this.disbandtext = "No unit selected.";
          this.buildbuttontext = "No unit selected.";
          this.infrabuttontext = "No unit selected.";
          this.blowbridgebuttontext = "No unit selected.";
          this.transportButtonText = "No unit selected.";
          this.battlegroupText = "No unit selected.";
          this.blowlocationtext = "No unit selected.";
          this.TransferButtonText = "No unit selected.";
          this.strategicbuttontext = "No unit selected.";
          this.paradropbuttontext = "No unit selected.";
          this.AirReconButtonText = "No unit selected.";
          this.airsupplybuttontext = "No unit selected.";
          this.loadbuttontext = "No unit selected.";
          this.unloadbuttontext = "No unit selected.";
          this.GiveUnitText = "Not a friendly unit.";
          this.OfficerText = "Not a friendly unit.";
          this.ChangeModelText = "Not a friendly unit.";
          if (this.game.SelectX > -1 && this.game.Data.Round > 0 & this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location == -1)
          {
            int locTypeCounter = this.game.Data.LocTypeCounter;
            for (int index4 = 0; index4 <= locTypeCounter; ++index4)
            {
              if (this.game.Data.LocTypeObj[index4].Buildable && this.game.Data.LocTypeObj[index4].HumanCanBuild)
                this.BuildButtonId = 1;
            }
          }
        }
        if (this.game.SelectX > -1 & this.game.SelectY > -1 && this.game.Data.Turn > -1 && (double) this.game.Data.RuleVar[529] == 1.0)
        {
          if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime == this.game.Data.Turn)
          {
            if (this.game.HandyFunctionsObj.HasAllies(this.game.Data.Turn, false))
              this.GiveHexId = 1;
            else
              this.GiveHexText = "You have no allies.";
          }
          else
            this.GiveHexText = !this.game.HandyFunctionsObj.HasAllies(this.game.Data.Turn, false) ? "You have no allies." : "Not a friendly hex.";
        }
        if (this.game.EditObj.LayerSupplyOn)
          this.SupplyLayerButtonId = 1;
        if (this.game.Data.Round > 0)
        {
          if (this.game.SelectX > -1 & this.game.SelectY > -1)
          {
            if (this.game.EditObj.UnitSelected > -1)
            {
              if (this.game.Data.RegimeObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime].UberRegime == this.game.Data.Turn)
                this.HqUnitButtonId = 1;
              if (this.game.Data.Turn > -1)
              {
                if ((double) this.game.Data.RuleVar[528] == 1.0 && this.game.Data.RegimeObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime].UberRegime == this.game.Data.Turn)
                  this.GiveUnitId = 1;
                if (this.game.Data.RegimeObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime].UberRegime == this.game.Data.Turn)
                {
                  if (!this.game.HandyFunctionsObj.HasUnitAirSF(this.game.EditObj.UnitSelected) & !this.game.HandyFunctionsObj.HasUnitNavySF(this.game.EditObj.UnitSelected))
                  {
                    if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y].get_APPenalty(this.game.Data.Turn) > 0)
                    {
                      this.strategicbuttontext = "You cant strategically transfer a unit from a hex you conquered in this turn.";
                      this.groupstrategictext = "You cant strategically transfer a unit from a hex you conquered in this turn.";
                    }
                    else if (!this.game.Data.UnitObj[this.game.EditObj.UnitSelected].DidAttack)
                    {
                      this.StrategicButtonId = 1;
                      if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].StartSize > -1)
                      {
                        int num17 = 1;
                        int unitCounter = this.game.Data.UnitCounter;
                        for (int index5 = 0; index5 <= unitCounter; ++index5)
                        {
                          if (this.game.Data.UnitObj[index5].Historical == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical & this.game.Data.UnitObj[index5].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index5].DidAttack)
                            num17 = 0;
                        }
                        if (num17 == 1)
                          this.GroupStrategicButtonId = 1;
                      }
                    }
                    else
                    {
                      this.strategicbuttontext = "You cannot strategic transfer a unit that participated in an attack.";
                      this.groupstrategictext = "You cannot strategic transfer a unit that participated in an attack.";
                    }
                  }
                  else
                  {
                    this.groupstrategictext = "You cannot strategic transfer units with air or navy subformations.";
                    this.strategicbuttontext = "You cannot strategic transfer units with air or navy subformations.";
                  }
                }
              }
              if ((double) this.game.Data.RuleVar[894] > 0.0 && this.game.EditObj.UnitSelected > -1 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].Type == 8)
              {
                this.StrategicButtonId = 0;
                this.GroupStrategicButtonId = 0;
                this.strategicbuttontext = "High command cannot move";
                this.groupstrategictext = "High command cannot move";
              }
            }
            if (this.game.HandyFunctionsObj.VisibleEnemyUnitsInHex(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, this.game.Data.Turn, testingforattack: true) & this.game.Data.Round > 0)
            {
              this.AttackButtonId = 1;
              this.ArtAttackButtonId = 1;
              if (this.game.HandyFunctionsObj.IsHexHarbourOrSea(this.game.SelectX, this.game.SelectY, 0))
              {
                this.seaAttackButtonId = 1;
              }
              else
              {
                this.seaAttackButtonId = 0;
                this.SeaAttackButtonText = "Only enemy vessels on sea hexes or enemy ports can be targetted.";
              }
              this.SeaArtAttackButtonId = 1;
              this.AirAttackButtonId = 1;
              if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType].IsSea)
              {
                this.SeaArtAttackButtonId = 0;
                this.SeaArtAttackButtonText = "You can only shore bombardment land hexes.";
              }
            }
            else
            {
              string str4 = "No enemy unit in hex.";
              if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime > -1 && this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime] >= 1)
                str4 = "Cannot attack. You need to declare war before you can attack";
              this.AttackButtonText = str4;
              this.ArtAttackButtonText = str4;
              this.SeaAttackButtonText = str4;
              this.SeaArtAttackButtonText = str4;
              this.AirAttackButtonText = str4;
              if ((double) this.game.Data.RuleVar[318] > 0.0 && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime > -1 && this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime] == 0 && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime != this.game.Data.Turn)
                this.AirAttackButtonId = 1;
            }
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location > -1 & this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime > -1 && this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime] == 0)
            {
              this.ArtAttackButtonId = 1;
              this.SeaArtAttackButtonId = 1;
            }
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].get_SeeNow(this.game.Data.Turn) > 0)
            {
              if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime != this.game.Data.Turn)
              {
                if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location > -1 | this.game.HandyFunctionsObj.HasHexBridge(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected))
                {
                  if (this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime))
                    this.InterdictButtonId = 1;
                  else
                    this.interdictbuttontext = "You are not at war with this regime. So you cannot bomb.";
                }
                else
                  this.interdictbuttontext = "No location or bridge in this hex to bomb.";
              }
              else
                this.interdictbuttontext = "You cannot bomb your own territory.";
            }
            else
              this.InterdictButtonId = 1;
          }
          else
          {
            this.AttackButtonText = "No hex selected.";
            this.ArtAttackButtonText = "No hex selected.";
            this.SeaAttackButtonText = "No hex selected.";
            this.SeaArtAttackButtonText = "No hex selected.";
            this.AirAttackButtonText = "No hex selected.";
            this.interdictbuttontext = "No hex selected.";
          }
        }
        if (this.game.SelectX > -1 & this.game.SelectY > -1)
        {
          if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime, this.game.Data.Turn) & this.game.Data.Round != 0)
          {
            if ((double) this.game.Data.RuleVar[512] == 0.0)
              this.NewUnitButtonId = 1;
            if ((double) this.game.Data.RuleVar[527] > 0.0)
              this.NewUnitButton2Id = 1;
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime != this.game.Data.Turn & this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].get_ReconPts(this.game.Data.Turn) < 1)
            {
              this.NewUnitButtonId = 0;
              this.NewUnitButton2Id = 0;
              this.NewUnitButtonText = "You must have recon on the hex you want to create a unit.";
              this.newunitbutton2text = "You must have recon on the hex you want to create a unit.";
            }
          }
          else
          {
            this.NewUnitButtonText = "You can only make a new unit on a friendly hex.";
            this.newunitbutton2text = "You can only make a new unit on a friendly hex.";
          }
        }
        else
        {
          this.NewUnitButtonText = "No hex selected";
          this.newunitbutton2text = "No hex selected";
        }
        if (this.game.Data.Round == 0)
        {
          this.NewUnitButtonId = 0;
          this.NewUnitButton2Id = 0;
        }
        if ((double) this.game.Data.RuleVar[527] == 0.0)
        {
          this.newunitbutton2text = "";
          this.NewUnitButton2Id = 0;
        }
        if (this.game.Data.Round > 0)
          this.QuitID = 1;
        this.SaveId = 1;
        if (this.game.SelectX > -1 & this.game.SelectY > -1 && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location > -1 && this.game.SelectX > -1 & this.game.SelectY > -1 && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location > -1 && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime == this.game.Data.Turn | this.game.Data.Round == 0 && this.game.HandyFunctionsObj.CanLocProduce(this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location, this.game.Data.Turn))
        {
          this.HqProdButtonId = 1;
          this.ProdButtonId = 1;
        }
        if (this.HqProdButtonId == 0)
          this.hqprodbuttontext = "You have to select a friendly location that can produce stuff.";
        if (this.ProdButtonId == 0)
          this.prodbuttontext = "You have to select a friendly location that can produce stuff.";
        int num18;
        if (this.game.Data.Round > 0 && this.game.SelectX > -1 & this.game.SelectY > -1)
        {
          if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter == -1)
          {
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime != this.game.Data.Turn)
            {
              num18 = 1;
              if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime > -1 && this.game.Data.RegimeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime].UberRegime == this.game.Data.Turn)
                num18 = 2;
            }
          }
          else if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter > -1 & this.game.EditObj.UnitSelected > -1)
          {
            if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime == this.game.Data.Turn)
            {
              num18 = 0;
            }
            else
            {
              num18 = 1;
              if (this.game.Data.RegimeObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime].UberRegime == this.game.Data.Turn)
                num18 = 2;
            }
          }
          else if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime != this.game.Data.Turn)
          {
            num18 = 1;
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime > -1 && this.game.Data.RegimeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime].UberRegime == this.game.Data.Turn)
              num18 = 2;
          }
        }
        if (this.game.EditObj.GuiDown)
        {
          if (this.StrategicButtonId > 0)
          {
            this.StrategicButtonId = 0;
            this.StrategicButtonId2 = 1;
            this.strategicbuttontext = "Cannot use this order with the Gui down.";
          }
          if (this.GroupStrategicButtonId > 0)
          {
            this.GroupStrategicButtonId = 0;
            this.GroupStrategicButtonId2 = 1;
            this.groupstrategictext = "Cannot use this order with the Gui down.";
          }
          if (this.NewUnitButtonId > 0)
          {
            this.NewUnitButtonId = 0;
            this.NewUnitButtonId2 = 1;
            this.NewUnitButtonText = "Cannot use this order with the Gui down.";
          }
          if (this.NewUnitButton2Id > 0)
          {
            this.NewUnitButton2Id = 0;
            this.NewUnitButton2Id2 = 1;
            this.newunitbutton2text = "Cannot use this order with the Gui down.";
          }
          if (this.ChangeModelId > 0)
          {
            this.ChangeModelId = 0;
            this.ChangeModelId2 = 1;
            this.ChangeModelText = "Cannot use this order with the Gui down.";
          }
          if (this.OfficerId > 0)
          {
            this.OfficerId = 0;
            this.OfficerId2 = 1;
            this.OfficerText = "Cannot use this order with the Gui down.";
          }
        }
        if ((double) this.game.Data.RuleVar[814] == 1.0)
        {
          this.OfficerId = 0;
          this.OfficerId2 = 1;
          this.OfficerText = "Cannot use this order in free movement phase.";
          this.NewUnitButtonId = 0;
          this.NewUnitButtonId2 = 1;
          this.NewUnitButtonText = "Cannot use this order in free movement phase.";
          this.NewUnitButton2Id = 0;
          this.NewUnitButton2Id2 = 1;
          this.newunitbutton2text = "Cannot use this order in free movement phase.";
          this.ChangeModelId = 0;
          this.ChangeModelId2 = 1;
          this.ChangeModelText = "Cannot use this order in free movement phase.";
        }
        int num19 = 800 + num2;
        int num20;
        int num21;
        if ((double) this.game.Data.RuleVar[343] == 1.0)
        {
          if (this.OfficerId > 0)
          {
            num21 = num20 + 1;
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONOFFICER, tDescript: "Click to go to officerpool", tBackbitmap: (ref this.OwnBitmap), bbx: (num19 + num21 * 33), bby: num1, totherback: 4, tsize: 29);
            this.OfficerId = this.AddSubPart(ref tsubpart, num19 + num21 * 33, num1, 29, 29, 1);
          }
          else
          {
            num21 = num20 + 1;
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONOFFICER, 1, this.OfficerText, ref this.OwnBitmap, num19 + num21 * 33, num1, 4, 29);
            this.OfficerId2 = this.AddSubPart(ref tsubpart, num19 + num21 * 33, num1, 29, 29, 0);
          }
        }
        int num22;
        if (this.HistoryId > 0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 26))
        {
          num22 = num21 + 1;
          tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONHISTORY, tDescript: "History", tBackbitmap: (ref this.OwnBitmap), bbx: (num19 + num22 * 33), bby: num1, totherback: 4, tsize: 29);
          this.HistoryId = this.AddSubPart(ref tsubpart, num19 + num22 * 33, num1, 29, 29, 1);
        }
        else
        {
          num22 = num21 + 1;
          if (this.game.EditObj.TutOrder > -1)
            this.historytext = "";
          tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONHISTORY, 1, this.historytext, ref this.OwnBitmap, num19 + num22 * 33, num1, 4, 29);
          this.HistoryId2 = this.AddSubPart(ref tsubpart, num19 + num22 * 33, num1, 29, 29, 0);
        }
        int num23;
        if (this.OrderSurrenderButtonId > 0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 41))
        {
          num23 = num22 + 1;
          tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONSURRENDER, tDescript: "Surrender", tBackbitmap: (ref this.OwnBitmap), bbx: (num19 + num23 * 33), bby: num1, totherback: 4, tsize: 29);
          this.OrderSurrenderButtonId = this.AddSubPart(ref tsubpart, num19 + num23 * 33, num1, 29, 29, 1);
        }
        else
        {
          num23 = num22 + 1;
          if (this.game.EditObj.TutOrder > -1)
            this.historytext = "";
          tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONSURRENDER, 1, this.ordersurrendertext, ref this.OwnBitmap, num19 + num23 * 33, num1, 4, 29);
          this.OrderSurrenderButtonId2 = this.AddSubPart(ref tsubpart, num19 + num23 * 33, num1, 29, 29, 0);
        }
        int num24;
        if (this.SaveId > 0 & !this.game.Data.PBEM & this.game.EditObj.TutOrder == -1)
        {
          num24 = num23 + 1;
          tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONSAVE, tDescript: "Save", tBackbitmap: (ref this.OwnBitmap), bbx: (num19 + num24 * 33), bby: num1, totherback: 4, tsize: 29);
          this.SaveId = this.AddSubPart(ref tsubpart, num19 + num24 * 33, num1, 29, 29, 1);
        }
        else
        {
          num24 = num23 + 1;
          tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONSAVE, 1, tBackbitmap: (ref this.OwnBitmap), bbx: (num19 + num24 * 33), bby: num1, totherback: 4, tsize: 29);
          this.SaveId2 = this.AddSubPart(ref tsubpart, num19 + num24 * 33, num1, 29, 29, 0);
        }
        if (this.NextButtonId > 0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 50))
        {
          int num25 = num24 + 1;
          tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONNEXT, tDescript: "End your Turn", tBackbitmap: (ref this.OwnBitmap), bbx: (num19 + num25 * 33), bby: num1, totherback: 4, tsize: 29);
          this.NextButtonId = this.AddSubPart(ref tsubpart, num19 + num25 * 33, num1, 29, 29, 1);
        }
        else
        {
          int num26 = num24 + 1;
          tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONNEXT, 1, tBackbitmap: (ref this.OwnBitmap), bbx: (num19 + num26 * 33), bby: num1, totherback: 4, tsize: 29);
          this.NextButtonId = this.AddSubPart(ref tsubpart, num19 + num26 * 33, num1, 29, 29, 0);
        }
        int num27 = 40 + num2;
        int num28;
        int num29;
        if ((double) this.game.Data.RuleVar[701] < 1.0 | !this.game.EditObj.useLeftRightClickMode)
        {
          if ((double) this.game.Data.RuleVar[458] > 0.0 & this.game.Data.Product >= 6)
          {
            int num30 = (int) Math.Round(Conversion.Val((object) this.game.Data.RuleVar[458]));
            if (num30 > 3)
              num30 = 3;
            int num31 = num30 * 33;
            if (num18 == 0)
            {
              if (this.MoveButtonId > 0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 1))
              {
                int num32 = num28 + 1;
                tsubpart = (SubPartClass) new MarcButtonFlexPartClass(this.game.BUTTONMOVE, "Move Unit", tDescript: "Move Unit [M]", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num32 * 33), bby: num1, totherback: 1, tWidth: (29 + num31), tHeight: 29);
                this.MoveButtonId = this.AddSubPart(ref tsubpart, num27 + num32 * 33, num1, 29 + num31, 29, 1);
                num29 = num32 + num30;
              }
              else
              {
                int num33 = num28 + 1;
                if (this.game.EditObj.TutOrder > -1)
                  this.MoveButtonText = "";
                tsubpart = (SubPartClass) new MarcButtonFlexPartClass(this.game.BUTTONMOVE, "Move Unit", 1, this.MoveButtonText, ref this.OwnBitmap, num27 + num33 * 33, num1, 1, 29 + num31, 29);
                this.MoveButtonId2 = this.AddSubPart(ref tsubpart, num27 + num33 * 33, num1, 29 + num31, 29, 0);
                num29 = num33 + num30;
              }
              if ((double) this.game.Data.RuleVar[533] == 0.0 & (double) this.game.Data.RuleVar[344] > 0.0)
              {
                if ((double) this.game.Data.RuleVar[344] > 0.0 & this.GroupMoveButtonId > 0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 48))
                {
                  int num34 = num29 + 1;
                  tsubpart = (SubPartClass) new MarcButtonFlexPartClass(this.game.BUTTONMOVE2, "Group Move", tDescript: "Group Move [G]", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num34 * 33), bby: num1, totherback: 1, tWidth: (29 + num31), tHeight: 29);
                  this.GroupMoveButtonId = this.AddSubPart(ref tsubpart, num27 + num34 * 33, num1, 29 + num31, 29, 1);
                  num29 = num34 + num30;
                }
                else
                {
                  int num35 = num29 + 1;
                  if (this.game.EditObj.TutOrder > -1)
                    this.GroupMoveButtonText = "";
                  tsubpart = (SubPartClass) new MarcButtonFlexPartClass(this.game.BUTTONMOVE2, "Group Move", 1, this.GroupMoveButtonText, ref this.OwnBitmap, num27 + num35 * 33, num1, 1, 29 + num31, 29);
                  this.GroupMoveButtonId2 = this.AddSubPart(ref tsubpart, num27 + num35 * 33, num1, 29 + num31, 29, 0);
                  num29 = num35 + num30;
                }
              }
            }
          }
          else if (num18 == 0)
          {
            if (this.MoveButtonId > 0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 1))
            {
              num29 = num28 + 1;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONMOVE, tDescript: "Move Unit [M]", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num29 * 33), bby: num1, totherback: 1, tsize: 29);
              this.MoveButtonId = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 1);
            }
            else
            {
              num29 = num28 + 1;
              if (this.game.EditObj.TutOrder > -1)
                this.MoveButtonText = "";
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONMOVE, 1, this.MoveButtonText, ref this.OwnBitmap, num27 + num29 * 33, num1, 1, 29);
              this.MoveButtonId2 = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 0);
            }
            if ((double) this.game.Data.RuleVar[533] == 0.0 & (double) this.game.Data.RuleVar[344] > 0.0)
            {
              if ((double) this.game.Data.RuleVar[344] > 0.0 & this.GroupMoveButtonId > 0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 48))
              {
                ++num29;
                tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONMOVE2, tDescript: "Group Move Unit [G]", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num29 * 33), bby: num1, totherback: 1, tsize: 29);
                this.GroupMoveButtonId = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 1);
              }
              else
              {
                ++num29;
                if (this.game.EditObj.TutOrder > -1)
                  this.GroupMoveButtonText = "";
                tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONMOVE2, 1, this.GroupMoveButtonText, ref this.OwnBitmap, num27 + num29 * 33, num1, 1, 29);
                this.GroupMoveButtonId2 = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 0);
              }
            }
          }
        }
        if (num18 == 0 | num18 == 2)
        {
          if ((double) this.game.Data.RuleVar[458] > 0.0 & this.game.Data.Product >= 6)
          {
            int num36 = (int) Math.Round(Conversion.Val((object) this.game.Data.RuleVar[458]));
            if (((double) this.game.Data.RuleVar[701] < 1.0 | !this.game.EditObj.useLeftRightClickMode) & num36 > 1)
              num36 = 1;
            if (num36 > 2)
              num36 = 2;
            int num37 = num36 * 33;
            if ((double) this.game.Data.RuleVar[521] == 0.0 | this.game.Data.Round == 0)
            {
              if (this.HqUnitButtonId > 0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 3))
              {
                int num38 = num29 + 1;
                tsubpart = (SubPartClass) new MarcButtonFlexPartClass(this.game.BUTTONHQUNIT, "HQ", tDescript: "Set Units HQ [H]", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num38 * 33), bby: num1, totherback: 1, tWidth: (29 + num37), tHeight: 29);
                this.HqUnitButtonId = this.AddSubPart(ref tsubpart, num27 + num38 * 33, num1, 29 + num37, 29, 1);
                num29 = num38 + num36;
              }
              else
              {
                int num39 = num29 + 1;
                if (this.game.EditObj.TutOrder > -1)
                  this.HqUnitButtonText = "";
                tsubpart = (SubPartClass) new MarcButtonFlexPartClass(this.game.BUTTONHQUNIT, "HQ", 1, this.HqUnitButtonText, ref this.OwnBitmap, num27 + num39 * 33, num1, 1, 29 + num37, 29);
                this.HqUnitButtonId2 = this.AddSubPart(ref tsubpart, num27 + num39 * 33, num1, 29 + num37, 29, 0);
                num29 = num39 + num36;
              }
            }
            else
            {
              this.HqUnitButtonId = 0;
              this.HqUnitButtonId2 = 0;
            }
          }
          else if ((double) this.game.Data.RuleVar[521] == 0.0 | this.game.Data.Round == 0)
          {
            if (this.HqUnitButtonId > 0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 3))
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONHQUNIT, tDescript: "Set Units HQ [H]", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num29 * 33), bby: num1, totherback: 1, tsize: 29);
              this.HqUnitButtonId = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 1);
            }
            else
            {
              ++num29;
              if (this.game.EditObj.TutOrder > -1)
                this.HqUnitButtonText = "";
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONHQUNIT, 1, this.HqUnitButtonText, ref this.OwnBitmap, num27 + num29 * 33, num1, 1, 29);
              this.HqUnitButtonId2 = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 0);
            }
          }
          else
          {
            this.HqUnitButtonId = 0;
            this.HqUnitButtonId2 = 0;
          }
          if ((double) this.game.Data.RuleVar[520] == 0.0)
          {
            if (this.StrategicButtonId > 0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 18))
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONSTRATEGIC, tDescript: "Strategic Transfer [S]", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num29 * 33), bby: num1, totherback: 1, tsize: 29);
              this.StrategicButtonId = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 1);
            }
            else
            {
              ++num29;
              if (this.game.EditObj.TutOrder > -1)
                this.strategicbuttontext = "";
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONSTRATEGIC, 1, this.strategicbuttontext, ref this.OwnBitmap, num27 + num29 * 33, num1, 1, 29);
              this.StrategicButtonId2 = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 0);
            }
            if ((double) this.game.Data.RuleVar[533] == 0.0 & (double) this.game.Data.RuleVar[344] > 0.0)
            {
              if (this.GroupStrategicButtonId > 0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 49))
              {
                ++num29;
                tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONSTRATEGIC2, tDescript: "Group Strategic Transfer", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num29 * 33), bby: num1, totherback: 1, tsize: 29);
                this.GroupStrategicButtonId = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 1);
              }
              else
              {
                ++num29;
                if (this.game.EditObj.TutOrder > -1)
                  this.groupstrategictext = "";
                tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONSTRATEGIC2, 1, this.groupstrategictext, ref this.OwnBitmap, num27 + num29 * 33, num1, 1, 29);
                this.GroupStrategicButtonId2 = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 0);
              }
            }
          }
          else
          {
            this.StrategicButtonId = 0;
            this.StrategicButtonId2 = 0;
            this.GroupStrategicButtonId = 0;
            this.GroupStrategicButtonId2 = 0;
          }
          if ((double) this.game.Data.RuleVar[528] == 1.0)
          {
            if (this.GiveUnitId > 0)
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONGIVEUNIT, tDescript: "Click to give a unit to an ally (or whole HQ group)", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num29 * 33), bby: num1, totherback: 1, tsize: 29);
              this.GiveUnitId = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 1);
            }
            else
            {
              ++num29;
              if (this.game.EditObj.TutMode)
                this.GiveUnitText = "";
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONGIVEUNIT, 1, this.GiveUnitText, ref this.OwnBitmap, num27 + num29 * 33, num1, 1, 29);
              this.GiveUnitId2 = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 0);
            }
          }
          else
          {
            this.GiveUnitId = 0;
            this.GiveUnitId2 = 0;
          }
          if ((double) this.game.Data.RuleVar[512] == 0.0)
          {
            if (this.NewUnitButtonId > 0)
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONNEWUNIT, tDescript: "Make New Unit [N]", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num29 * 33), bby: num1, totherback: 1, tsize: 29);
              this.NewUnitButtonId = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 1);
            }
            else
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONNEWUNIT, 1, this.NewUnitButtonText, ref this.OwnBitmap, num27 + num29 * 33, num1, 1, 29);
              this.NewUnitButtonId2 = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 0);
            }
          }
          else
          {
            this.NewUnitButtonId = 0;
            this.NewUnitButtonId2 = 0;
          }
          if ((double) this.game.Data.RuleVar[527] > 0.0)
          {
            if (this.NewUnitButton2Id > 0)
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONNEWUNIT2, tDescript: "Sub Unit Options (add)", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num29 * 33), bby: num1, totherback: 1, tsize: 29);
              this.NewUnitButton2Id = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 1);
            }
            else
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONNEWUNIT2, 1, this.NewUnitButtonText, ref this.OwnBitmap, num27 + num29 * 33, num1, 1, 29);
              this.NewUnitButton2Id2 = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 0);
            }
          }
          if ((double) this.game.Data.RuleVar[531] == 1.0)
          {
            if (this.ChangeModelId > 0)
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONCHANGEMODEL, tDescript: "Click to change model of this unit", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num29 * 33), bby: num1, totherback: 1, tsize: 29);
              this.ChangeModelId = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 1);
            }
            else
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONCHANGEMODEL, 1, this.ChangeModelText, ref this.OwnBitmap, num27 + num29 * 33, num1, 1, 29);
              this.ChangeModelId2 = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 0);
            }
          }
        }
        if (num18 == 0)
        {
          if ((double) this.game.Data.RuleVar[522] == 0.0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 33))
          {
            if (this.AirReconButtonId > 0)
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONAIRRECON, tDescript: "Click to do an Air Recon Mission", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num29 * 33), bby: num1, totherback: 1, tsize: 29);
              this.AirReconButtonId = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 1);
            }
            else
            {
              ++num29;
              if (this.game.EditObj.TutOrder > -1)
                this.AirReconButtonText = "";
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONAIRRECON, 1, this.AirReconButtonText, ref this.OwnBitmap, num27 + num29 * 33, num1, 1, 29);
              this.AirReconButtonId2 = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 0);
            }
          }
          if ((double) this.game.Data.RuleVar[505] == 0.0)
          {
            if ((double) this.game.Data.RuleVar[458] > 0.0 & this.game.Data.Product >= 6)
            {
              int num40 = (int) Math.Round(Conversion.Val((object) this.game.Data.RuleVar[458]));
              if (num40 > 2)
                num40 = 2;
              if (((double) this.game.Data.RuleVar[701] < 1.0 | !this.game.EditObj.useLeftRightClickMode) & num40 > 1)
                num40 = 1;
              int num41 = num40 * 33;
              if (this.BlowBridgeButtonId > 0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 35))
              {
                int num42 = num29 + 1;
                tsubpart = (SubPartClass) new MarcButtonFlexPartClass(this.game.BUTTONBLOWBRIDGE, "Blow", tDescript: "Click to blow a bridge", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num42 * 33), bby: num1, totherback: 1, tWidth: (29 + num41), tHeight: 29);
                this.BlowBridgeButtonId = this.AddSubPart(ref tsubpart, num27 + num42 * 33, num1, 29 + num41, 29, 1);
                num29 = num42 + num40;
              }
              else
              {
                int num43 = num29 + 1;
                if (this.game.EditObj.TutOrder > -1)
                  this.blowbridgebuttontext = "";
                tsubpart = (SubPartClass) new MarcButtonFlexPartClass(this.game.BUTTONBLOWBRIDGE, "Blow", 1, this.blowbridgebuttontext, ref this.OwnBitmap, num27 + num43 * 33, num1, 1, 29 + num41, 29);
                this.BlowBridgeButtonId2 = this.AddSubPart(ref tsubpart, num27 + num43 * 33, num1, 29 + num41, 29, 0);
                num29 = num43 + num40;
              }
              if ((double) this.game.Data.RuleVar[474] > 0.0)
              {
                if (this.TransportButtonId > 0)
                {
                  int num44 = num29 + 1;
                  tsubpart = (SubPartClass) new MarcButtonFlexPartClass(this.game.BUTTONLOAD, "Trnp", tDescript: "Click to attach Units for Transport", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num44 * 33), bby: num1, totherback: 1, tWidth: (29 + num41), tHeight: 29);
                  this.TransportButtonId = this.AddSubPart(ref tsubpart, num27 + num44 * 33, num1, 29 + num41, 29, 1);
                  num29 = num44 + num40;
                }
                else
                {
                  int num45 = num29 + 1;
                  tsubpart = (SubPartClass) new MarcButtonFlexPartClass(this.game.BUTTONLOAD, "Trnp", 1, this.transportButtonText, ref this.OwnBitmap, num27 + num45 * 33, num1, 1, 29 + num41, 29);
                  this.TransportButtonId2 = this.AddSubPart(ref tsubpart, num27 + num45 * 33, num1, 29 + num41, 29, 0);
                  num29 = num45 + num40;
                }
              }
              if ((double) this.game.Data.RuleVar[475] > 0.0)
              {
                if (this.BattleGroupButtonId > 0)
                {
                  int num46 = num29 + 1;
                  tsubpart = (SubPartClass) new MarcButtonFlexPartClass(this.game.BUTTONTRANSFER, "Trnf", tDescript: "Click to create Battlegroup or Transfer", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num46 * 33), bby: num1, totherback: 1, tWidth: (29 + num41), tHeight: 29);
                  this.BattleGroupButtonId = this.AddSubPart(ref tsubpart, num27 + num46 * 33, num1, 29 + num41, 29, 1);
                  num29 = num46 + num40;
                }
                else
                {
                  int num47 = num29 + 1;
                  tsubpart = (SubPartClass) new MarcButtonFlexPartClass(this.game.BUTTONTRANSFER, "Trnf", 1, this.transportButtonText, ref this.OwnBitmap, num27 + num47 * 33, num1, 1, 29 + num41, 29);
                  this.BattleGroupButtonId2 = this.AddSubPart(ref tsubpart, num27 + num47 * 33, num1, 29 + num41, 29, 0);
                  num29 = num47 + num40;
                }
              }
            }
            else if (this.BlowBridgeButtonId > 0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 35))
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONBLOWBRIDGE, tDescript: "Click to blow a bridge", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num29 * 33), bby: num1, totherback: 1, tsize: 29);
              this.BlowBridgeButtonId = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 1);
            }
            else
            {
              ++num29;
              if (this.game.EditObj.TutOrder > -1)
                this.blowbridgebuttontext = "";
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONBLOWBRIDGE, 1, this.blowbridgebuttontext, ref this.OwnBitmap, num27 + num29 * 33, num1, 1, 29);
              this.BlowBridgeButtonId2 = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 0);
            }
          }
          if ((double) this.game.Data.RuleVar[503] == 0.0)
          {
            if ((double) this.game.Data.RuleVar[458] > 0.0 & this.game.Data.Product >= 6)
            {
              int num48 = (int) Math.Round(Conversion.Val((object) this.game.Data.RuleVar[458]));
              if (num48 > 2)
                num48 = 2;
              if (((double) this.game.Data.RuleVar[701] < 1.0 | !this.game.EditObj.useLeftRightClickMode) & num48 > 1)
                num48 = 1;
              int num49 = num48 * 33;
              if (this.InfraButtonId > 0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 37))
              {
                int num50 = num29 + 1;
                tsubpart = (SubPartClass) new MarcButtonFlexPartClass(this.game.BUTTONBUILDROAD, "Repair", tDescript: "Click to build bridge [R]", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num50 * 33), bby: num1, totherback: 1, tWidth: (29 + num49), tHeight: 29);
                this.InfraButtonId = this.AddSubPart(ref tsubpart, num27 + num50 * 33, num1, 29 + num49, 29, 1);
                num29 = num50 + num48;
              }
              else
              {
                int num51 = num29 + 1;
                if (this.game.EditObj.TutMode)
                  this.infrabuttontext = "";
                tsubpart = (SubPartClass) new MarcButtonFlexPartClass(this.game.BUTTONBUILDROAD, "Repair", 1, this.infrabuttontext, ref this.OwnBitmap, num27 + num51 * 33, num1, 1, 29 + num49, 29);
                this.InfraButtonId2 = this.AddSubPart(ref tsubpart, num27 + num51 * 33, num1, 29 + num49, 29, 0);
                num29 = num51 + num48;
              }
            }
            else if (this.InfraButtonId > 0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 37))
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONBUILDROAD, tDescript: "Click to build bridge [R]", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num29 * 33), bby: num1, totherback: 1, tsize: 29);
              this.InfraButtonId = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 1);
            }
            else
            {
              ++num29;
              if (this.game.EditObj.TutMode)
                this.infrabuttontext = "";
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONBUILDROAD, 1, this.infrabuttontext, ref this.OwnBitmap, num27 + num29 * 33, num1, 1, 29);
              this.InfraButtonId2 = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 0);
            }
          }
          if ((double) this.game.Data.RuleVar[515] == 0.0)
          {
            if (this.ParadropButtonId > 0 & this.game.EditObj.TutOrder == -1)
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONPARADROP, tDescript: "Use this Air Unit to do a paradrop", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num29 * 33), bby: num1, totherback: 1, tsize: 29);
              this.ParadropButtonId = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 1);
            }
            else
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONPARADROP, 1, this.paradropbuttontext, ref this.OwnBitmap, num27 + num29 * 33, num1, 1, 29);
              this.ParadropButtonId2 = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 0);
            }
          }
          if ((double) this.game.Data.RuleVar[516] == 0.0)
          {
            if (this.AirSupplyButtonId > 0 & this.game.EditObj.TutOrder == -1)
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONAIRSUPPLY, tDescript: "Use this Air Unit to do an airsupply", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num29 * 33), bby: num1, totherback: 1, tsize: 29);
              this.AirSupplyButtonId = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 1);
            }
            else
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONAIRSUPPLY, 1, this.airsupplybuttontext, ref this.OwnBitmap, num27 + num29 * 33, num1, 1, 29);
              this.AirSupplyButtonId2 = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 0);
            }
          }
          if ((double) this.game.Data.RuleVar[507] == 0.0)
          {
            if (this.LoadButtonId > 0 & this.game.EditObj.TutOrder == -1)
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONLOAD, tDescript: "Load Unit aboard this Naval Unit [L]", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num29 * 33), bby: num1, totherback: 1, tsize: 29);
              this.LoadButtonId = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 1);
            }
            else
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONLOAD, 1, this.loadbuttontext, ref this.OwnBitmap, num27 + num29 * 33, num1, 1, 29);
              this.LoadButtonId2 = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 0);
            }
          }
          if ((double) this.game.Data.RuleVar[507] == 0.0)
          {
            if (this.UnLoadButtonID > 0 & this.game.EditObj.TutOrder == -1)
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONUNLOAD, tDescript: "Unload this Unit [U]", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num29 * 33), bby: num1, totherback: 1, tsize: 29);
              this.UnLoadButtonID = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 1);
            }
            else
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONUNLOAD, 1, this.unloadbuttontext, ref this.OwnBitmap, num27 + num29 * 33, num1, 1, 29);
              this.UnLoadButtonID2 = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 0);
            }
          }
        }
        if (num18 == 1)
        {
          if ((double) this.game.Data.RuleVar[458] > 0.0 & this.game.Data.Product >= 6)
          {
            int num52 = (int) Math.Round(Conversion.Val((object) this.game.Data.RuleVar[458]));
            if (num52 > 3)
              num52 = 3;
            int num53 = num52 * 33;
            if (this.AttackButtonId > 0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 2))
            {
              int num54 = num29 + 1;
              tsubpart = (SubPartClass) new MarcButtonFlexPartClass(this.game.BUTTONATTACK, "Regular Attack", tDescript: "Do a Land Attack on this Hex [A]", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num54 * 33), bby: num1, totherback: 2, tWidth: (29 + num53), tHeight: 29);
              this.AttackButtonId = this.AddSubPart(ref tsubpart, num27 + num54 * 33, num1, 29 + num53, 29, 1);
              num29 = num54 + num52;
            }
            else
            {
              int num55 = num29 + 1;
              if (this.game.EditObj.TutOrder > -1)
                this.AttackButtonText = "";
              tsubpart = (SubPartClass) new MarcButtonFlexPartClass(this.game.BUTTONATTACK, "Regular Attack", 1, this.AttackButtonText, ref this.OwnBitmap, num27 + num55 * 33, num1, 2, 29 + num53, 29);
              this.AttackButtonId2 = this.AddSubPart(ref tsubpart, num27 + num55 * 33, num1, 29 + num53, 29, 0);
              num29 = num55 + num52;
            }
            if ((double) this.game.Data.RuleVar[953] == 0.0)
            {
              if (this.ArtAttackButtonId > 0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 11))
              {
                int num56 = num29 + 1;
                tsubpart = (SubPartClass) new MarcButtonFlexPartClass(this.game.BUTTONARTATTACK, "Ranged Attack", tDescript: "Do an Artillery Barrage on this Hex [B]", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num56 * 33), bby: num1, totherback: 2, tWidth: (29 + num53), tHeight: 29);
                this.ArtAttackButtonId = this.AddSubPart(ref tsubpart, num27 + num56 * 33, num1, 29 + num53, 29, 1);
                num29 = num56 + num52;
              }
              else
              {
                int num57 = num29 + 1;
                if (this.game.EditObj.TutOrder > -1)
                  this.ArtAttackButtonText = "";
                tsubpart = (SubPartClass) new MarcButtonFlexPartClass(this.game.BUTTONARTATTACK, "Ranged Attack", 1, this.ArtAttackButtonText, ref this.OwnBitmap, num27 + num57 * 33, num1, 2, 29 + num53, 29);
                this.ArtAttackButtonId2 = this.AddSubPart(ref tsubpart, num27 + num57 * 33, num1, 29 + num53, 29, 0);
                num29 = num57 + num52;
              }
            }
            else
            {
              this.ArtAttackButtonId = 0;
              this.ArtAttackButtonId2 = 0;
            }
          }
          else
          {
            if (this.AttackButtonId > 0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 2))
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONATTACK, tDescript: "Do a Land Attack on this Hex [A]", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num29 * 33), bby: num1, totherback: 2, tsize: 29);
              this.AttackButtonId = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 1);
            }
            else
            {
              ++num29;
              if (this.game.EditObj.TutOrder > -1)
                this.AttackButtonText = "";
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONATTACK, 1, this.AttackButtonText, ref this.OwnBitmap, num27 + num29 * 33, num1, 2, 29);
              this.AttackButtonId2 = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 0);
            }
            if ((double) this.game.Data.RuleVar[953] == 0.0)
            {
              if (this.ArtAttackButtonId > 0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 11))
              {
                ++num29;
                tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONARTATTACK, tDescript: "Do an Artillery Barrage on this Hex [B]", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num29 * 33), bby: num1, totherback: 2, tsize: 29);
                this.ArtAttackButtonId = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 1);
              }
              else
              {
                ++num29;
                if (this.game.EditObj.TutOrder > -1)
                  this.ArtAttackButtonText = "";
                tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONARTATTACK, 1, this.ArtAttackButtonText, ref this.OwnBitmap, num27 + num29 * 33, num1, 2, 29);
                this.ArtAttackButtonId2 = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 0);
              }
            }
            else
            {
              this.ArtAttackButtonId = 0;
              this.ArtAttackButtonId2 = 0;
            }
          }
          if ((double) this.game.Data.RuleVar[952] == 0.0)
          {
            if (this.AirAttackButtonId > 0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 14))
            {
              ++num29;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONAIRATTACK, tDescript: "Do an Airstrike on this Hex [Z]", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num29 * 33), bby: num1, totherback: 2, tsize: 29);
              this.AirAttackButtonId = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 1);
            }
            else
            {
              ++num29;
              if (this.game.EditObj.TutOrder > -1)
                this.AirAttackButtonText = "";
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONAIRATTACK, 1, this.AirAttackButtonText, ref this.OwnBitmap, num27 + num29 * 33, num1, 2, 29);
              this.AirAttackButtonId2 = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 0);
            }
          }
          else
          {
            this.AirAttackButtonId = 0;
            this.AirAttackButtonId2 = 0;
          }
          if ((double) this.game.Data.RuleVar[511] == 0.0)
          {
            int num58;
            if (this.seaAttackButtonId > 0 & this.game.EditObj.TutOrder == -1)
            {
              num58 = num29 + 1;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONSEAATTACK, tDescript: "Do a Sea Attack on this Hex [A]", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num58 * 33), bby: num1, totherback: 2, tsize: 29);
              this.seaAttackButtonId = this.AddSubPart(ref tsubpart, num27 + num58 * 33, num1, 29, 29, 1);
            }
            else
            {
              num58 = num29 + 1;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONSEAATTACK, 1, this.SeaAttackButtonText, ref this.OwnBitmap, num27 + num58 * 33, num1, 2, 29);
              this.seaAttackButtonId2 = this.AddSubPart(ref tsubpart, num27 + num58 * 33, num1, 29, 29, 0);
            }
            if (this.SeaArtAttackButtonId > 0 & this.game.EditObj.TutOrder == -1)
            {
              num29 = num58 + 1;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONSEAARTATTACK, tDescript: "Do Shorebombardment on this Hex", tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num29 * 33), bby: num1, totherback: 2, tsize: 29);
              this.SeaArtAttackButtonId = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 1);
            }
            else
            {
              num29 = num58 + 1;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONSEAARTATTACK, 1, this.SeaArtAttackButtonText, ref this.OwnBitmap, num27 + num29 * 33, num1, 2, 29);
              this.SeaArtAttackButtonId2 = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 0);
            }
          }
          else
          {
            this.SeaArtAttackButtonId = 0;
            this.SeaArtAttackButtonId2 = 0;
            this.seaAttackButtonId = 0;
            this.SeaArtAttackButtonId2 = 0;
          }
        }
        int index6 = 0;
        int actionCardCounter = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter;
        for (int index7 = 0; index7 <= actionCardCounter; ++index7)
        {
          int index8 = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[index7];
          if (index6 < 10 && this.game.Data.ActionCardObj[index8].quickButton > 0 & this.game.Data.Round > 0)
          {
            bool flag = false;
            this.game.EditObj.AreaX = this.game.SelectX;
            this.game.EditObj.AreaY = this.game.SelectY;
            if (this.game.Data.ActionCardObj[index8].PPCost <= this.game.Data.RegimeObj[this.game.Data.Turn].ResPts)
            {
              if (this.game.Data.ActionCardObj[index8].PreExecuteEvent > -1)
              {
                this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.Data.ActionCardObj[index8].PreExecuteEvent, this.game.Data.ActionCardObj[index8].TempVar0, this.game.Data.ActionCardObj[index8].TempVar1, tv3: this.game.EditObj.UnitSelected);
                if (this.game.Data.ActionCardObj[index8].UnitSelect)
                {
                  if (this.game.EditObj.UnitSelected > -1 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].TempUnitSelectable)
                    flag = true;
                }
                else if (this.game.Data.ActionCardObj[index8].AreaValue > 0 && this.game.SelectX > -1 && this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].AreaCode[this.game.Data.ActionCardObj[index8].AreaSlot] == this.game.Data.ActionCardObj[index8].AreaValue)
                  flag = true;
              }
              else
                flag = true;
            }
            if (flag)
            {
              ++index6;
              if (index6 == 1 & num29 < 3)
                ++num29;
              this.ActionButtonCardSlot[index6] = index7;
              ++num29;
              int[] actionButtonId = this.ActionButtonId;
              int index9 = index6;
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.Data.SmallPicNr[this.game.Data.ActionCardObj[index8].quickSmall], tDescript: this.game.Data.ActionCardObj[index8].Title, tBackbitmap: (ref this.OwnBitmap), bbx: (num27 + num29 * 33), bby: num1, totherback: 2, tsize: 29);
              int num59 = this.AddSubPart(ref tsubpart, num27 + num29 * 33, num1, 29, 29, 1);
              actionButtonId[index9] = num59;
            }
            this.game.EditObj.AreaX = -1;
            this.game.EditObj.AreaY = -1;
            int unitCounter = this.game.Data.UnitCounter;
            for (int index10 = 0; index10 <= unitCounter; ++index10)
              this.game.Data.UnitObj[index10].TempUnitSelectable = false;
          }
        }
        int num60 = num2 + 600;
        int num61 = -1;
        int num62;
        if (this.HexUnitButtonId > 0 & this.game.EditObj.TutOrder == -1)
        {
          num62 = num61 + 1;
          if (this.game.EditObj.HideUnit == 0)
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONHEX, tDescript: "Click to show siluet counters [1]", tBackbitmap: (ref this.OwnBitmap), bbx: (num60 + num62 * 33), bby: num1, totherback: 3, tsize: 29);
            this.HexUnitButtonId = this.AddSubPart(ref tsubpart, num60 + 36 * num62, num1, 29, 29, 1);
          }
          else if (this.game.EditObj.HideUnit == 1)
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONHEXUNIT, tDescript: "Click to show nato counters [2]", tBackbitmap: (ref this.OwnBitmap), bbx: (num60 + num62 * 33), bby: num1, totherback: 3, tsize: 29);
            this.HexUnitButtonId = this.AddSubPart(ref tsubpart, num60 + 36 * num62, num1, 29, 29, 1);
          }
          else
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONHEXUNIT2, tDescript: "Click to hide units [0]", tBackbitmap: (ref this.OwnBitmap), bbx: (num60 + num62 * 33), bby: num1, totherback: 3, tsize: 29);
            this.HexUnitButtonId = this.AddSubPart(ref tsubpart, num60 + 36 * num62, num1, 29, 29, 1);
          }
        }
        else
        {
          num62 = num61 + 1;
          tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONHEX, 1, tBackbitmap: (ref this.OwnBitmap), bbx: (num60 + num62 * 33), bby: num1, totherback: 3, tsize: 29);
          this.HexUnitButtonId2 = this.AddSubPart(ref tsubpart, num60 + 36 * num62, num1, 29, 29, 0);
        }
        int num63;
        if (this.ShowAsId > 0 & this.game.EditObj.TutOrder == -1)
        {
          num63 = num62 + 1;
          if (this.game.EditObj.HideAS)
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONHEXINFO2, tDescript: "Click to show extra hex info [4]", tBackbitmap: (ref this.OwnBitmap), bbx: (num60 + num63 * 33), bby: num1, totherback: 3, tsize: 29);
            this.ShowAsId = this.AddSubPart(ref tsubpart, num60 + 36 * num63, num1, 29, 29, 1);
          }
          else
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONHEXINFO, tDescript: "Click to hide extra hex info [4]", tBackbitmap: (ref this.OwnBitmap), bbx: (num60 + num63 * 33), bby: num1, totherback: 3, tsize: 29);
            this.ShowAsId = this.AddSubPart(ref tsubpart, num60 + 36 * num63, num1, 29, 29, 1);
          }
        }
        else
        {
          num63 = num62 + 1;
          tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONHEXINFO, 1, tBackbitmap: (ref this.OwnBitmap), bbx: (num60 + num63 * 33), bby: num1, totherback: 3, tsize: 29);
          this.ShowAsId2 = this.AddSubPart(ref tsubpart, num60 + 36 * num63, num1, 29, 29, 0);
        }
        int num64;
        if (this.ButtonZoomOutId > 0 & this.game.EditObj.TutOrder == -1)
        {
          num64 = num63 + 1;
          if (this.game.EditObj.Zoom > -1)
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONZOOMOUT, tDescript: "Click to zoom out [-]", tBackbitmap: (ref this.OwnBitmap), bbx: (num60 + num64 * 33), bby: num1, totherback: 3, tsize: 29);
            this.ButtonZoomOutId = this.AddSubPart(ref tsubpart, num60 + 36 * num64, num1, 29, 29, 1);
          }
          else if (this.game.EditObj.Zoom == -1)
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONZOOMOUT, 1, tBackbitmap: (ref this.OwnBitmap), bbx: (num60 + num64 * 33), bby: num1, totherback: 3, tsize: 29);
            this.ButtonZoomOutId2 = this.AddSubPart(ref tsubpart, num60 + 36 * num64, num1, 29, 29, 0);
          }
        }
        else
        {
          num64 = num63 + 1;
          tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONZOOMOUT, 1, tBackbitmap: (ref this.OwnBitmap), bbx: (num60 + num64 * 33), bby: num1, totherback: 3, tsize: 29);
          this.ButtonZoomOutId2 = this.AddSubPart(ref tsubpart, num60 + 36 * num64, num1, 29, 29, 0);
        }
        int num65;
        if (this.ButtonZoomInId > 0 & this.game.EditObj.TutOrder == -1)
        {
          num65 = num64 + 1;
          if (this.game.EditObj.Zoom < 1)
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONZOOMIN, tDescript: "Click to zoom in [+]", tBackbitmap: (ref this.OwnBitmap), bbx: (num60 + num65 * 33), bby: num1, totherback: 3, tsize: 29);
            this.ButtonZoomInId = this.AddSubPart(ref tsubpart, num60 + 36 * num65, num1, 29, 29, 1);
          }
          else if (this.game.EditObj.Zoom == 1)
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONZOOMIN, 1, tBackbitmap: (ref this.OwnBitmap), bbx: (num60 + num65 * 33), bby: num1, totherback: 3, tsize: 29);
            this.ButtonZoomInId2 = this.AddSubPart(ref tsubpart, num60 + 36 * num65, num1, 29, 29, 0);
          }
        }
        else
        {
          num65 = num64 + 1;
          tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONZOOMIN, 1, tBackbitmap: (ref this.OwnBitmap), bbx: (num60 + num65 * 33), bby: num1, totherback: 3, tsize: 29);
          this.ButtonZoomInId2 = this.AddSubPart(ref tsubpart, num60 + 36 * num65, num1, 29, 29, 0);
        }
        int num66;
        if (this.ButtonStackedUnitId > 0 & this.game.EditObj.TutOrder == -1 & this.game.EditObj.Zoom == 1)
        {
          num66 = num65 + 1;
          if (!this.game.EditObj.SpreadUnit)
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONSPREADUNIT, tDescript: "Click to spread out units in zoomed in mode [3]", tBackbitmap: (ref this.OwnBitmap), bbx: (num60 + num66 * 33), bby: num1, totherback: 3, tsize: 29);
            this.ButtonStackedUnitId = this.AddSubPart(ref tsubpart, num60 + 36 * num66, num1, 29, 29, 1);
          }
          else
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONSTACKEDUNIT, tDescript: "Click to stack units in zoomed in mode [3]", tBackbitmap: (ref this.OwnBitmap), bbx: (num60 + num66 * 33), bby: num1, totherback: 3, tsize: 29);
            this.ButtonStackedUnitId = this.AddSubPart(ref tsubpart, num60 + 36 * num66, num1, 29, 29, 1);
          }
        }
        else
        {
          num66 = num65 + 1;
          tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONSPREADUNIT, 1, tBackbitmap: (ref this.OwnBitmap), bbx: (num60 + num66 * 33), bby: num1, totherback: 3, tsize: 29);
          this.ButtonStackedUnitId2 = this.AddSubPart(ref tsubpart, num60 + 36 * num66, num1, 29, 29, 0);
        }
        if ((double) this.game.Data.RuleVar[523] != 0.0)
          return;
        if (this.SupplyLayerButtonId > 0 & (this.game.EditObj.TutOrder == -1 | this.game.EditObj.TutOrder == 51))
        {
          int num67 = num66 + 1;
          if (this.game.EditObj.LayerSupplyOn)
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONSUPPLYON, tDescript: "Click to turn off Supply layer", tBackbitmap: (ref this.OwnBitmap), bbx: (num60 + num67 * 33), bby: num1, totherback: 3, tsize: 29);
            this.SupplyLayerButtonId = this.AddSubPart(ref tsubpart, num60 + 36 * num67, num1, 29, 29, 1);
          }
          else
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONSUPPLYON, tDescript: "Click to turn on supply layer", tBackbitmap: (ref this.OwnBitmap), bbx: (num60 + num67 * 33), bby: num1, totherback: 3, tsize: 29);
            this.SupplyLayerButtonId = this.AddSubPart(ref tsubpart, num60 + 36 * num67, num1, 29, 29, 1);
          }
        }
        else
        {
          int num68 = num66 + 1;
          if (this.game.EditObj.TutOrder > -1)
            this.supplylayerbuttontext = "";
          tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONSUPPLYON, 1, this.supplylayerbuttontext, ref this.OwnBitmap, num60 + num68 * 33, num1, 3, 29);
          this.SupplyLayerButtonId2 = this.AddSubPart(ref tsubpart, num60 + 36 * num68, num1, 29, 29, 0);
        }
      }
      else
      {
        if (this.game.EditObj.udsUnitOrderMode > 0 & !this.game.EditObj.BattleTimerActive)
          this.game.EditObj.OrderType = this.game.EditObj.udsUnitOrderMode;
        if (this.game.EditObj.OrderType == 1)
          str1 = "Movement";
        if (this.game.EditObj.OrderType == 48)
          str1 = "Group Movement";
        if (this.game.EditObj.OrderType == 14)
          str1 = "Airstrike";
        if (this.game.EditObj.OrderType == 11)
          str1 = "Land Artillery Attack";
        if (this.game.EditObj.OrderType == 2)
          str1 = "Land Attack";
        if (this.game.EditObj.OrderType == 15)
          str1 = "Bombing Raid";
        if (this.game.EditObj.OrderType == 25)
          str1 = "Construction Menu";
        if (this.game.EditObj.OrderType == 24)
          str1 = "Strategic Information";
        if (this.game.EditObj.OrderType == 26)
          str1 = "History";
        if (this.game.EditObj.OrderType == 20)
          str1 = "Embark Unit";
        if (this.game.EditObj.OrderType == 8)
          str1 = "Create new Subformation/HQ";
        if (this.game.EditObj.OrderType == 7)
          str1 = "New Unit";
        if (this.game.EditObj.OrderType == 19)
          str1 = "Paradrop/Airlift";
        if (this.game.EditObj.OrderType == 22)
          str1 = "Officerpool";
        if (this.game.EditObj.OrderType == 6)
          str1 = "Production";
        if (this.game.EditObj.OrderType == 4)
          str1 = "Locations HQ";
        if (this.game.EditObj.OrderType == 5)
          str1 = "Recruitment";
        if (this.game.EditObj.OrderType == 23)
          str1 = "Decision Room";
        if (this.game.EditObj.OrderType == 52)
          str1 = "Subformation Model Design";
        if (this.game.EditObj.OrderType == 13)
          str1 = "Shore Bombardment";
        if (this.game.EditObj.OrderType == 12)
          str1 = "Sea Attack";
        if (this.game.EditObj.OrderType == 18)
          str1 = "Strategic Transfer";
        if (this.game.EditObj.OrderType == 49)
          str1 = "Group Strategic Transfer";
        if (this.game.EditObj.OrderType == 9)
          str1 = "Transfer";
        if (this.game.EditObj.OrderType == 3)
          str1 = "Set Unit's HQ";
        if (this.game.EditObj.OrderType == 21)
          str1 = "Disembark Unit";
        if (this.game.EditObj.OrderType == 30)
          str1 = "System Options";
        if (this.game.EditObj.OrderType == 33)
          str1 = "Air Recon";
        if (this.game.EditObj.OrderType == 35)
          str1 = "Blow Bridge";
        if (this.game.EditObj.OrderType == 36)
          str1 = "Build Road/Bridge";
        if (this.game.EditObj.OrderType == 37)
          str1 = "Build/Repair Location";
        if (this.game.EditObj.OrderType == 39)
          str1 = "Select Anti-Supply Target";
        if (this.game.EditObj.OrderType == 40)
          str1 = "Air Supply";
        if (this.game.EditObj.OrderType == 43)
          str1 = "AI Testing, Pick Marker for unit";
        if (this.game.EditObj.OrderType == 44)
          str1 = "Make new subunit";
        if (this.game.EditObj.OrderType == 45)
          str1 = "Officer Pool";
        if (this.game.EditObj.OrderType == 46)
          str1 = "Change Model";
        if (this.game.EditObj.OrderType == 47)
          str1 = "Model Designer";
        if (this.game.EditObj.LayerSupplyOn)
        {
          int layerSupplyAp = this.game.EditObj.LayerSupplyAP;
          if ((double) this.game.Data.RuleVar[471] > 0.0 & this.game.Data.Product >= 6)
          {
            int location2 = this.game.Data.MapObj[0].HexObj[this.game.EditObj.OrderX, this.game.EditObj.OrderY].Location2;
            string str5;
            if (location2 > -1)
            {
              if (this.game.Data.LocTypeObj[this.game.Data.LocObj[location2].Type].isSupplySource)
                str5 = "Supply flow from Supply Source (" + this.game.EditObj.OrderX.ToString() + "," + this.game.EditObj.OrderY.ToString() + "). ";
              else if (this.game.Data.LocTypeObj[this.game.Data.LocObj[location2].Type].isSupplyBase)
                str5 = "If 'Deplete' the flow from Supply Base (" + this.game.EditObj.OrderX.ToString() + "," + this.game.EditObj.OrderY.ToString() + "). ";
              else
                str5 = "Cumulative supply flow from all Supply Sources. ";
            }
            else
              str5 = "Cumulative supply flow from all Supply Sources. ";
            str1 = str5 + "Click a hex for path. Selected Hex: " + Strings.Trim(Conversion.Str((object) this.game.EditObj.TempSup[this.game.EditObj.MapSelected].Value[this.game.SelectX, this.game.SelectY])) + "ap/" + Strings.Trim(Conversion.Str((object) layerSupplyAp)) + "ap";
          }
          else
            str1 = "Viewing Supply layer. Click a hex to see path from HQ. Selected Hex: " + Strings.Trim(Conversion.Str((object) this.game.EditObj.TempSup[this.game.EditObj.MapSelected].Value[this.game.SelectX, this.game.SelectY])) + "ap/" + Strings.Trim(Conversion.Str((object) layerSupplyAp)) + "ap";
        }
        if (this.game.EditObj.udsUnitOrderMode == 1)
          str1 = "Movement Mode";
        if (this.game.EditObj.udsUnitOrderMode == 48)
          str1 = "Group Movement Mode";
        bool flag1 = true;
        this.NotOkText = "Option not available";
        int num69 = this.game.EditObj.LayerSupplyOn ? 1 : 0;
        if (this.game.EditObj.OrderType == 6)
        {
          int Number = this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.EditObj.OrderLoc].Type].MaxProd;
          if (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.EditObj.OrderLoc].Type].StructuralPts > 0)
            Number = (int) Math.Round(Conversion.Int((double) Number * ((double) this.game.Data.LocObj[this.game.EditObj.OrderLoc].StructuralPts / (double) this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.EditObj.OrderLoc].Type].StructuralPts)));
          if (this.game.Data.Round <= 0)
            ;
          str1 = "Production for " + this.game.Data.LocObj[this.game.EditObj.OrderLoc].Name + " (" + Strings.Trim(Conversion.Str((object) Number)) + "points)";
          if (this.game.Data.Round != 0)
            str1 = str1 + " (" + Conversion.Str((object) Conversion.Int(this.game.Data.PeopleObj[this.game.Data.LocObj[this.game.EditObj.OrderLoc].People].ProdMod[this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.Turn].People].PeopleGroup] * 100f)) + "%)";
          if (this.game.HandyFunctionsObj.GetProdTotalPercent(this.game.EditObj.OrderLoc) > 100)
            flag1 = false;
        }
        if (this.game.EditObj.OrderType == 9)
          str1 = this.game.EditObj.OrderTarget != -1 ? "Transfer subformations" : "Select target for transfers";
        bool flag2;
        if (this.game.EditObj.OrderType == 18 | this.game.EditObj.OrderType == 49)
        {
          if (this.game.EditObj.OrderTarget == -1)
          {
            this.PopupButtonId = 1;
            str1 = "Strategic Transfer. Select HQ to provide Movement Capacity";
            if (this.game.EditObj.UnitSelected > -1 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ && this.game.EditObj.UnitSelected != this.game.EditObj.OrderUnit && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime == this.game.Data.Turn)
              flag2 = true;
          }
          else
            str1 = "Strategic Transfer. Select destination Hex";
        }
        string tDescript;
        if (this.game.EditObj.OrderType == 3)
        {
          this.PopupButtonId = 1;
          str1 = "Select HQ for Unit";
          if (this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical > -1)
          {
            if (this.game.HandyFunctionsObj.ExtraHQSwitchPPCost(this.game.EditObj.OrderUnit, true) > 0)
              str1 = str1 + ". Costs " + Conversion.Str((object) this.game.HandyFunctionsObj.ExtraHQSwitchPPCost(this.game.EditObj.OrderUnit, false)) + " PP - " + Conversion.Str((object) this.game.HandyFunctionsObj.ExtraHQSwitchPPCost(this.game.EditObj.OrderUnit, true)) + " PP to switch due to current commander.";
          }
          else if (this.game.HandyFunctionsObj.ExtraHQSwitchPPCost(this.game.EditObj.OrderUnit, false) > 0)
            str1 = str1 + ". Costs " + Conversion.Str((object) this.game.HandyFunctionsObj.ExtraHQSwitchPPCost(this.game.EditObj.OrderUnit, false)) + " PP due to current commander.";
          if (this.game.EditObj.UnitSelected > -1)
          {
            this.NotOkText = "Unit is not a HQ";
            if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
            {
              this.NotOkText = "You cannot select self as HQ";
              if (this.game.EditObj.UnitSelected != this.game.EditObj.OrderUnit)
              {
                this.NotOkText = "That is already the HQ";
                if (this.game.Data.UnitObj[this.game.EditObj.OrderUnit].HQ != this.game.EditObj.UnitSelected)
                {
                  this.NotOkText = "Unit is not a HQ";
                  if (this.game.EditObj.UnitSelected != this.game.EditObj.OrderUnit | this.game.Data.UnitObj[this.game.EditObj.OrderUnit].IsHQ)
                  {
                    this.NotOkText = "Unit cannot be set as HQ";
                    if (this.game.HandyFunctionsObj.CanUnitBecomeHQfor(this.game.EditObj.UnitSelected, this.game.EditObj.OrderUnit))
                    {
                      flag2 = true;
                      if ((double) this.game.Data.RuleVar[304] > 0.0)
                      {
                        int num70 = 0;
                        if (this.game.Data.UnitObj[this.game.EditObj.OrderUnit].IsHQ)
                          num70 = 1;
                        if ((double) (this.game.HandyFunctionsObj.HowmanyHQsAbove(this.game.EditObj.UnitSelected) + this.game.HandyFunctionsObj.HowmanyHQsBelow(this.game.EditObj.OrderUnit) + 1 + num70) > (double) this.game.Data.RuleVar[304])
                        {
                          this.NotOkText = "Cannot select as HQ because it would exceed the maximum amount of HQs in HQ chain.";
                          flag2 = false;
                        }
                      }
                    }
                  }
                }
              }
            }
          }
          this.KillId = 1;
          tDescript = "Set Unit to No HQ";
        }
        if (this.game.EditObj.OrderType == 35)
        {
          str1 = "Select Bridge Direction to blow";
          if (this.game.EditObj.TempValue[this.game.EditObj.MapSelected].Value[this.game.SelectX, this.game.SelectY] == 0)
            flag2 = true;
        }
        if (this.game.EditObj.OrderType == 36)
        {
          str1 = !(this.game.SelectX == this.game.EditObj.OrderX & this.game.SelectY == this.game.EditObj.OrderY) ? this.game.HandyFunctionsObj.GetRoadOrBridgeBuildCostString(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap, this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected) : "Select Direction to build road/bridge";
          if (this.game.EditObj.TempValue[this.game.EditObj.MapSelected].Value[this.game.SelectX, this.game.SelectY] == 0)
            flag2 = true;
        }
        if (this.game.EditObj.OrderType == 19 | this.game.EditObj.OrderType == 42)
        {
          if (this.game.EditObj.OrderTarget == -1)
          {
            str1 = "Select Unit to paradrop or airlift";
            if (this.game.EditObj.UnitSelected > -1 & this.game.EditObj.UnitSelected != this.game.EditObj.OrderUnit)
            {
              this.NotOkText = "Unit is empty";
              if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SFCount > -1)
              {
                this.NotOkText = "Unit is a HQ. Only non-HQs can be dropped.";
                if (!this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
                {
                  this.NotOkText = "Unit must have at least 50ap";
                  if (this.game.HandyFunctionsObj.GetLowestAp(this.game.EditObj.UnitSelected) >= 50)
                  {
                    this.NotOkText = "Unit must be in same hex.";
                    if (this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X == this.game.SelectX & this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y == this.game.SelectY)
                    {
                      this.NotOkText = "Unit is not yours.";
                      if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime == this.game.Data.Turn)
                      {
                        this.NotOkText = "Unit may only have land theater subformations";
                        if (!this.game.HandyFunctionsObj.HasUnitAirSF(this.game.EditObj.UnitSelected) & !this.game.HandyFunctionsObj.HasUnitNavySF(this.game.EditObj.UnitSelected))
                        {
                          this.NotOkText = "Unit is to heavy to be carried.";
                          if (this.game.HandyFunctionsObj.GetCarryCapPts(this.game.EditObj.OrderUnit, 2) >= this.game.HandyFunctionsObj.GetUnitWeight(this.game.EditObj.UnitSelected))
                            flag2 = true;
                        }
                      }
                    }
                  }
                }
              }
            }
          }
          else if (this.game.EditObj.TargetX == -1)
          {
            str1 = this.game.EditObj.OrderType != 19 ? "Select airfield to airlift too" : "Select Hex to paradrop on";
            if (!(this.game.EditObj.OrderX == this.game.SelectX & this.game.EditObj.OrderY == this.game.SelectY & this.game.EditObj.OrderMap == this.game.EditObj.MapSelected))
            {
              this.NotOkText = "Hex cannot be reached.";
              if (this.game.EditObj.TempValue[this.game.EditObj.MapSelected].Value[this.game.SelectX, this.game.SelectY] <= this.game.HandyFunctionsObj.GetLowestAirAp(this.game.EditObj.OrderUnit))
              {
                this.NotOkText = "Option not available..";
                if (this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime))
                {
                  this.NotOkText = "Unit needs at least " + Conversion.Str((object) this.game.Data.RuleVar[307]) + " power points to capture enemy territory.";
                  if ((double) this.game.Data.RuleVar[307] <= (double) this.game.HandyFunctionsObj.GetPowerPtsAbsolute(this.game.EditObj.OrderTarget))
                  {
                    this.NotOkText = "Unit does not only have paratroopers.";
                    if (this.game.HandyFunctionsObj.HasUnitOnlyParaLandSF(this.game.EditObj.OrderTarget))
                      flag2 = true;
                  }
                }
                else
                {
                  this.NotOkText = "Not on sea";
                  if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType].IsSea)
                  {
                    if (!this.game.HandyFunctionsObj.HasUnitOnlyParaLandSF(this.game.EditObj.OrderTarget))
                    {
                      this.NotOkText = "Must have location";
                      if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location > -1)
                      {
                        this.NotOkText = "Must have location with airfield";
                        if (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location].Type].IsAirfield)
                          flag2 = true;
                      }
                    }
                    else
                      flag2 = true;
                  }
                }
              }
            }
          }
        }
        if (this.game.EditObj.OrderType == 33)
        {
          str1 = "Select target hex for recon mission";
          if (!(this.game.EditObj.OrderX == this.game.SelectX & this.game.EditObj.OrderY == this.game.SelectY & this.game.EditObj.MapSelected == this.game.EditObj.OrderMap) && this.game.EditObj.TempValue[this.game.EditObj.MapSelected].Value[this.game.SelectX, this.game.SelectY] <= this.game.HandyFunctionsObj.GetLowestAirAp(this.game.EditObj.OrderUnit))
            flag2 = true;
        }
        if (this.game.EditObj.OrderType != 40)
          this.LastAirSupplyTarget = -1;
        if (this.game.EditObj.OrderType == 40)
        {
          str1 = "Select target unit for air supply.";
          if (this.game.Data.UnitObj[this.game.EditObj.OrderUnit].HQ > -1 & this.game.HandyFunctionsObj.GetLowestAirAp(this.game.EditObj.OrderUnit) >= 40)
          {
            int supply = this.game.Data.UnitObj[this.game.Data.UnitObj[this.game.EditObj.OrderUnit].HQ].Supply;
            int Number1 = (int) Math.Round((double) Conversion.Int((float) this.game.HandyFunctionsObj.GetCarryCapPts(this.game.EditObj.OrderUnit, 2) / this.game.Data.RuleVar[33]));
            if (Number1 > supply)
              Number1 = supply;
            string str6 = (this.game.EditObj.TempValue2[0].Value[this.game.SelectX, this.game.SelectY] >= 9999 ? str1 + " Ap: out of range" : str1 + " Ap: " + this.game.EditObj.TempValue2[0].Value[this.game.SelectX, this.game.SelectY].ToString()) + ", Max: " + Strings.Trim(Conversion.Str((object) Number1)) + ".";
            if (this.game.EditObj.UnitSelected > -1)
            {
              if (this.LastAirSupplyTarget == this.game.EditObj.UnitSelected)
              {
                str1 = str6 + ", target area needs: " + Strings.Trim(Conversion.Str((object) this.LastAirSupplyNeed));
                int mapWidth = this.game.Data.MapObj[0].MapWidth;
                for (int index11 = 0; index11 <= mapWidth; ++index11)
                {
                  int mapHeight = this.game.Data.MapObj[0].MapHeight;
                  for (int index12 = 0; index12 <= mapHeight; ++index12)
                    this.game.EditObj.TempValue[0].Value[index11, index12] = this.game.EditObj.TempValue2[0].Value[index11, index12];
                }
              }
              else
              {
                this.game.HandyFunctionsObj.RedimTempValue3(9999);
                int Number2 = this.game.HandyFunctionsObj.AirSupplyNeeded(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, 0);
                int mapWidth = this.game.Data.MapObj[0].MapWidth;
                for (int index13 = 0; index13 <= mapWidth; ++index13)
                {
                  int mapHeight = this.game.Data.MapObj[0].MapHeight;
                  for (int index14 = 0; index14 <= mapHeight; ++index14)
                    this.game.EditObj.TempValue[0].Value[index13, index14] = this.game.EditObj.TempValue2[0].Value[index13, index14];
                }
                str1 = str6 + ", target area needs: " + Strings.Trim(Conversion.Str((object) Number2));
                this.LastAirSupplyMax = Number1;
                this.LastAirSupplyNeed = Number2;
                this.LastAirSupplyTarget = this.game.EditObj.UnitSelected;
              }
            }
            else
            {
              str1 = str6 + ", no target unit selected";
              this.LastAirSupplyTarget = -1;
              this.game.HandyFunctionsObj.RedimTempValue3(9999);
            }
          }
          else
          {
            this.LastAirSupplyTarget = -1;
            this.game.HandyFunctionsObj.RedimTempValue3(9999);
          }
          if (!(this.game.EditObj.OrderX == this.game.SelectX & this.game.EditObj.OrderY == this.game.SelectY & this.game.EditObj.MapSelected == this.game.EditObj.OrderMap) && this.game.EditObj.TempValue2[this.game.EditObj.MapSelected].Value[this.game.SelectX, this.game.SelectY] <= this.game.HandyFunctionsObj.GetLowestAirAp(this.game.EditObj.OrderUnit) && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType].IsSea && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime == this.game.Data.Turn && this.game.EditObj.TargetX == -1 & this.LastAirSupplyMax > 0 & this.LastAirSupplyNeed > 0)
            flag2 = true;
          this.game.EditObj.TempCoordList = new CoordList();
        }
        Coordinate target;
        bool flag3;
        if (this.game.EditObj.OrderType == 2)
        {
          this.PopupButtonId = 1;
          int unitCounter = this.game.Data.MapObj[0].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].UnitCounter;
          int num71;
          for (int index15 = 0; index15 <= unitCounter; ++index15)
          {
            int unit = this.game.Data.MapObj[0].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].UnitList[index15];
            num71 += this.game.HandyFunctionsObj.GetStackWithFOW(unit, this.game.Data.Turn);
          }
          string str7 = "Select attackers. Stack: " + Conversion.Str((object) (this.game.HandyFunctionsObj.CurrentAttackStack() + this.game.Data.MapObj[this.game.EditObj.TargetMap].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].get_BattleStack(this.game.Data.Turn))) + " /" + Conversion.Str((object) this.game.HandyFunctionsObj.maxAttackStack());
          if (num71 > 0)
            str7 = str7 + " vs " + num71.ToString();
          str1 = str7 + ". Concentric: +" + Conversion.Str((object) Conversion.Int((float) (((double) this.game.HandyFunctionsObj.GetConcentricBonus2() - 1.0) * 100.0))) + "%";
          int divBonusForAttack = this.game.HandyFunctionsObj.GetDivBonusForAttack(this.game.EditObj.TargetX, this.game.EditObj.TargetY, this.game.EditObj.TargetMap);
          if (divBonusForAttack > 0)
            str1 = str1 + ". Divisional: +" + Conversion.Str((object) Conversion.Int(divBonusForAttack)) + "%";
          if (this.game.EditObj.UnitSelected > -1)
          {
            target = new Coordinate();
            target.x = this.game.EditObj.TargetX;
            target.y = this.game.EditObj.TargetY;
            target.map = this.game.EditObj.MapSelected;
            this.NotOkText = "Unit needs at least " + Conversion.Str((object) this.game.Data.RuleVar[307]) + " power points to join in attack.";
            if ((double) this.game.Data.RuleVar[307] <= (double) this.game.HandyFunctionsObj.GetPowerPtsAbsolute(this.game.EditObj.UnitSelected))
            {
              this.NotOkText = "Unit does not have enough AP to join in attack.";
              if (this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, target.x, target.y, target.map) <= 1)
              {
                int x = this.game.HandyFunctionsObj.MoveApCostPreview(this.game.EditObj.UnitSelected, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, target.x, target.y, target.map, true).x;
                this.NotOkText = x < 9999 ? "Unit does not have the " + x.ToString() + " AP needed to join in attack." : "Unit can never join in this attack. Landscape or river might be impassible for it.";
              }
              if (this.game.HandyFunctionsObj.CanDoLandAttack(this.game.EditObj.UnitSelected, target))
                flag2 = true;
            }
          }
          this.AllId = 1;
          if (this.game.EditObj.TempUnitList.counter > -1)
          {
            flag3 = true;
            this.NoneId = 1;
          }
        }
        if (this.game.EditObj.OrderType == 14)
        {
          this.PopupButtonId = 1;
          str1 = "Preparing Air Strike. Select attackers. ";
          if ((double) this.game.Data.RuleVar[833] > 0.0)
            str1 = str1 + "Stack:" + Conversion.Str((object) (this.game.HandyFunctionsObj.CurrentAttackStackAir() + this.game.Data.MapObj[this.game.EditObj.TargetMap].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].get_BattleStackAir(this.game.Data.Turn))) + "/" + Conversion.Str((object) this.game.Data.RuleVar[833]);
          if (this.game.EditObj.UnitSelected > -1)
          {
            target = new Coordinate();
            target.x = this.game.EditObj.TargetX;
            target.y = this.game.EditObj.TargetY;
            if (this.game.HandyFunctionsObj.CanDoAirStrike(this.game.EditObj.UnitSelected, target))
              flag2 = true;
          }
          this.AllId = 1;
          if (this.game.EditObj.TempUnitList.counter > -1)
          {
            flag3 = true;
            this.NoneId = 1;
          }
        }
        if (this.game.EditObj.OrderType == 1 | this.game.EditObj.OrderType == 48)
        {
          if (this.game.EditObj.OrderUnit == -1)
            str1 += " - Please select a Unit";
          else if ((double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.udsUnitOrderMode > 0 & this.game.EditObj.useLeftRightClickMode)
          {
            bool flag4 = false;
            bool flag5 = false;
            if (this.game.EditObj.MouseOverX > -1)
            {
              int index16 = 0;
              do
              {
                if (this.game.EditObj.TempAttack[0].Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY, index16])
                {
                  flag4 = true;
                  Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY, 0, index16 + 1);
                  if (!this.game.EditObj.TempCameFrom[0].Value[coordinate.x, coordinate.y].onmap)
                    flag5 = true;
                }
                ++index16;
              }
              while (index16 <= 5);
              str1 = !flag4 ? ((double) this.game.Data.RuleVar[419] <= 0.0 ? str1 + " - AP Cost: " + this.game.EditObj.CurrentDescript : (this.game.EditObj.TempLos[0].Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY] <= 0 ? str1 + " - AP Cost: " + this.game.EditObj.CurrentDescript : str1 + " - Right Click to do Ranged Attack")) : (!flag5 ? (!((double) this.game.Data.RuleVar[419] > 0.0 & this.game.EditObj.TempLos[0].Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY] > 0) ? str1 + " - Move next to target todo Regular Attack" : str1 + " - Right Click to do Ranged Attack") : str1 + " - Right Click to Attack");
              if (this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y, 0, this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY, 0) == 1 && Strings.InStr(str1, "AP") < 1)
              {
                Coordinate coordinate = this.game.HandyFunctionsObj.MoveApCostPreview(this.game.EditObj.OrderUnit, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y, 0, this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY, 0, true, ismove: true);
                str1 = str1 + " - AP Cost: " + coordinate.x.ToString();
              }
            }
          }
          else
            str1 = str1 + " - AP Cost: " + this.game.EditObj.CurrentDescript;
        }
        if (this.game.EditObj.OrderType == 15)
        {
          this.PopupButtonId = 1;
          str1 = "Preparing Bombing Run. Select participants." + Conversion.Str((object) (this.game.HandyFunctionsObj.CurrentAttackStackAir() + this.game.Data.MapObj[this.game.EditObj.TargetMap].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].get_BattleStackAir(this.game.Data.Turn))) + "/" + Conversion.Str((object) this.game.Data.RuleVar[833]);
          if (this.game.EditObj.UnitSelected > -1)
          {
            target = new Coordinate();
            target.x = this.game.EditObj.TargetX;
            target.y = this.game.EditObj.TargetY;
            if (this.game.HandyFunctionsObj.CanDoAirStrike(this.game.EditObj.UnitSelected, target))
              flag2 = true;
          }
          this.AllId = 1;
          if (this.game.EditObj.TempUnitList.counter > -1)
          {
            flag3 = true;
            this.NoneId = 1;
          }
        }
        if (this.game.EditObj.OrderType == 11)
        {
          str1 = "Preparing Art Attack. Select attackers. ";
          this.PopupButtonId = 1;
          if ((double) this.game.Data.RuleVar[834] > 0.0)
            str1 = str1 + "Stack" + Conversion.Str((object) (this.game.HandyFunctionsObj.CurrentAttackStackart() + this.game.Data.MapObj[this.game.EditObj.TargetMap].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].get_BattleStackArt(this.game.Data.Turn))) + "/" + Conversion.Str((object) this.game.Data.RuleVar[834]);
          if (this.game.EditObj.UnitSelected > -1)
          {
            target = new Coordinate();
            target.x = this.game.EditObj.TargetX;
            target.y = this.game.EditObj.TargetY;
            if (this.game.HandyFunctionsObj.CanDoArtAttack(this.game.EditObj.UnitSelected, target, false))
              flag2 = true;
            else if ((double) this.game.Data.RuleVar[419] > 0.0 && this.game.HandyFunctionsObj.CanDoDirectAttack(this.game.EditObj.UnitSelected, target, false))
              flag2 = true;
          }
          this.AllId = 1;
          if (this.game.EditObj.TempUnitList.counter > -1)
          {
            flag3 = true;
            this.NoneId = 1;
          }
        }
        if (this.game.EditObj.OrderType == 13)
        {
          str1 = "Preparing Shore Bombardment. Select participants. " + Conversion.Str((object) (this.game.HandyFunctionsObj.CurrentAttackStackart() + this.game.Data.MapObj[this.game.EditObj.TargetMap].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].get_BattleStackArt(this.game.Data.Turn))) + "/" + Conversion.Str((object) this.game.Data.RuleVar[834]);
          if (this.game.EditObj.UnitSelected > -1)
          {
            target = new Coordinate();
            target.x = this.game.EditObj.TargetX;
            target.y = this.game.EditObj.TargetY;
            if (this.game.HandyFunctionsObj.CanDoSeaArtAttack(this.game.EditObj.UnitSelected, target))
              flag2 = true;
          }
          this.AllId = 1;
          if (this.game.EditObj.TempUnitList.counter > -1)
          {
            flag3 = true;
            this.NoneId = 1;
          }
        }
        if (this.game.EditObj.OrderType == 12)
        {
          str1 = "Preparing Sea Attack. Select participants.";
          if (this.game.EditObj.UnitSelected > -1)
          {
            target = new Coordinate();
            target.x = this.game.EditObj.TargetX;
            target.y = this.game.EditObj.TargetY;
            if (this.game.HandyFunctionsObj.CanDoSeaAttack(this.game.EditObj.UnitSelected, target))
              flag2 = true;
          }
          this.AllId = 1;
          if (this.game.EditObj.TempUnitList.counter > -1)
          {
            flag3 = true;
            this.NoneId = 1;
          }
        }
        if (this.game.EditObj.OrderType == 4)
        {
          str1 = "Select a HQ for " + this.game.Data.LocObj[this.game.EditObj.OrderLoc].Name;
          if (this.game.EditObj.UnitSelected > -1 && this.game.HandyFunctionsObj.CanUnitBecomeHQforLoc(this.game.EditObj.UnitSelected, this.game.EditObj.OrderLoc))
            flag2 = true;
        }
        if (this.game.EditObj.OrderType == 20)
        {
          str1 = "Select cargo for " + this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Name;
          if (this.game.EditObj.UnitSelected > -1 && this.game.EditObj.UnitSelected != this.game.EditObj.OrderUnit)
          {
            this.NotOkText = "Unit already has 8 subformations.";
            if (this.game.Data.UnitObj[this.game.EditObj.OrderUnit].SFCount + this.game.Data.UnitObj[this.game.EditObj.OrderUnit].PassengerCounter + 1 < 7)
            {
              this.NotOkText = "Unit is empty.";
              if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SFCount > -1)
              {
                this.NotOkText = "Unit is not yours";
                if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime == this.game.Data.Turn | this.game.Data.Round == 0)
                {
                  int num72 = 0;
                  if (this.game.HandyFunctionsObj.IsHexPort(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap))
                  {
                    if (this.game.HandyFunctionsObj.Distance(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap, this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected) > 0)
                    {
                      num72 = 1;
                      this.NotOkText = "Unit is not in port.";
                    }
                  }
                  else
                  {
                    if (this.game.HandyFunctionsObj.Distance(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap, this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected) > 1)
                    {
                      num72 = 1;
                      this.NotOkText = "Unit is not next to naval unit.";
                    }
                    if (((ulong) -(this.game.HandyFunctionsObj.GetLowestAp(this.game.EditObj.UnitSelected) <= 0 ? 1 : 0) & (ulong) (long) Math.Round((double) this.game.Data.RuleVar[882])) > 0UL)
                    {
                      num72 = 1;
                      this.NotOkText = "Unit needs more then 0 ap in order to be able to get of the beaches.";
                    }
                  }
                  if (num72 == 0)
                  {
                    this.NotOkText = "Unit may not have naval or aerial subformations.";
                    if (!this.game.HandyFunctionsObj.HasUnitNavySF(this.game.EditObj.UnitSelected) & !this.game.HandyFunctionsObj.HasUnitAirSF(this.game.EditObj.UnitSelected))
                    {
                      this.NotOkText = "Unit is to heavy.";
                      if (this.game.HandyFunctionsObj.GetUnitWeight(this.game.EditObj.UnitSelected, true) <= this.game.HandyFunctionsObj.GetUnitCarryCap(this.game.EditObj.OrderUnit, 1, true))
                        flag2 = true;
                    }
                  }
                }
              }
            }
          }
        }
        if (this.game.EditObj.OrderType == 21)
        {
          str1 = "Select disembark hex for " + this.game.Data.UnitObj[this.game.EditObj.OrderTarget].Name;
          if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType].IsSea)
          {
            if (this.game.HandyFunctionsObj.Distance(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap, this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected) == 0)
            {
              if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter < 15)
                flag2 = true;
            }
            else if (this.game.HandyFunctionsObj.Distance(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap, this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected) <= 1)
            {
              this.NotOkText = "Landscape not suitable";
              if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType].CanAmph && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.OrderMap].HexObj[this.game.EditObj.OrderX, this.game.EditObj.OrderY].LandscapeType].IsSea)
              {
                if (this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime))
                {
                  this.NotOkText = "Unit needs at least " + Conversion.Str((object) this.game.Data.RuleVar[307]) + " power points to do amphibious invasion.";
                  if ((double) this.game.Data.RuleVar[307] <= (double) this.game.HandyFunctionsObj.GetPowerPtsAbsolute(this.game.EditObj.OrderTarget))
                    flag2 = true;
                }
                else if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime, this.game.Data.Turn) && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter < 15)
                  flag2 = true;
              }
            }
          }
        }
        if (!this.game.AIThreadRunning && this.game.EditObj.BattleTimerActive)
        {
          string tstring = "BATTLE IS COMMENCING!!";
          DrawMod.DrawTextColouredMarc(ref g, tstring, this.game.MarcFont3, num2 + 82, num1 + 3, Color.White);
        }
        else if (this.game.EditObj.udsUnitOrderMode > 0)
        {
          int num73 = 0;
          if (!((double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode))
          {
            if ((double) this.game.Data.RuleVar[458] > 0.0 & this.game.Data.Product >= 6)
            {
              int num74 = (int) Math.Round(Conversion.Val((object) this.game.Data.RuleVar[458]));
              if (num74 > 3)
                num74 = 3;
              num73 = (num74 + 1) * 33;
              if (this.game.EditObj.udsUnitOrderMode == 1)
              {
                if (flag1)
                {
                  tsubpart = (SubPartClass) new MarcButtonFlexPartClass(this.game.BACKBUTTON, "Exit Move Mode", tDescript: "Exit Move Mode [Esc]", tBackbitmap: (ref this.OwnBitmap), bbx: (num2 + 42), bby: (num1 - 3), tWidth: (35 + num73));
                  this.Cancelid = this.AddSubPart(ref tsubpart, num2 + 42, num1 - 3, 35 + num73, 35, 1);
                }
              }
              else if (this.game.EditObj.udsUnitOrderMode == 48 && flag1)
              {
                tsubpart = (SubPartClass) new MarcButtonFlexPartClass(this.game.BACKBUTTON, "Exit Group Move", tDescript: "Exit Group Move Mode [Esc]", tBackbitmap: (ref this.OwnBitmap), bbx: (num2 + 42), bby: (num1 - 3), tWidth: (35 + num73));
                this.Cancelid = this.AddSubPart(ref tsubpart, num2 + 42, num1 - 3, 35 + num73, 35, 1);
              }
            }
            else if (flag1)
            {
              tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BACKBUTTON, tDescript: "Exit Move Mode", tBackbitmap: (ref this.OwnBitmap), bbx: (num2 + 42), bby: num1);
              this.Cancelid = this.AddSubPart(ref tsubpart, num2 + 42, num1, 32, 32, 1);
            }
          }
          DrawMod.DrawTextColouredMarcCenter(ref g, str1, this.game.MarcFont3, (int) Math.Round((double) num73 / 2.0) + (int) Math.Round((double) this.w / 2.0), num1 + 3, Color.White);
        }
        else
        {
          if (this.game.EditObj.udsUnitOrderMode >= 1)
            return;
          if (this.AllId > 0 & this.lastorderx == this.game.EditObj.OrderX & this.lastordery == this.game.EditObj.OrderY)
            this.AllId = 0;
          int num75 = num2 + 1024 - 300;
          if (flag1)
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.BACKBUTTON, tDescript: "Back to Main Menu [ESC]", tBackbitmap: (ref this.OwnBitmap), bbx: (num2 + 42), bby: num1);
            this.Cancelid = this.AddSubPart(ref tsubpart, num2 + 42, num1, 32, 32, 1);
          }
          DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont3, num2 + 82, num1 + 3, Color.White);
          if (flag2)
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.OKBALL, tDescript: "Select / Deselect [SPACE]", tBackbitmap: (ref this.OwnBitmap), bbx: num75, bby: num1);
            this.OkId = this.AddSubPart(ref tsubpart, num75, num1, 32, 32, 1);
          }
          else if (!this.game.EditObj.LayerSupplyOn)
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.OKBALL, 1, this.NotOkText, ref this.OwnBitmap, num75, num1);
            this.Ok2Id = this.AddSubPart(ref tsubpart, num75, num1, 32, 32, 0);
          }
          int num76 = num75 + 40;
          if (this.PopupButtonId > 0)
          {
            tsubpart = (SubPartClass) new TextButtonPartClass("LIST", 48, "Select from list", ref this.OwnBitmap, num76, num1, tMarcStyle: true);
            this.PopupButtonId = this.AddSubPart(ref tsubpart, num76, num1, 48, 32, 1);
            num76 += 50;
          }
          if (this.KillId == 1)
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.CANCELBALL, tDescript: tDescript, tBackbitmap: (ref this.OwnBitmap), bbx: num76, bby: num1, totherback: 3);
            this.KillId = this.AddSubPart(ref tsubpart, num76, num1, 32, 32, 1);
            num76 += 50;
          }
          if (!(this.game.EditObj.OrderType == 2 | this.game.EditObj.OrderType == 11 | this.game.EditObj.OrderType == 14 | this.game.EditObj.OrderType == 13 | this.game.EditObj.OrderType == 12 | this.game.EditObj.OrderType == 15))
            return;
          if (flag3)
          {
            tsubpart = (SubPartClass) new TextButtonPartClass("ATTACK", 96, "Start Battle!!", ref this.OwnBitmap, num76, num1, tMarcStyle: true);
            this.BattleId = this.AddSubPart(ref tsubpart, num76, num1, 96, 32, 1);
          }
          else
          {
            tsubpart = (SubPartClass) new TextButtonPartClass("ATTACK", 96, "You cannot start a battle", ref this.OwnBitmap, num76, num1, true, tMarcStyle: true);
            this.Battle2Id = this.AddSubPart(ref tsubpart, num76, num1, 96, 32, 1);
          }
          int num77 = num76 + 104;
          if (this.NoneId == 1)
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.NONEBUTTON, tDescript: "Remove all selected units from attack", tBackbitmap: (ref this.OwnBitmap), bbx: num77, bby: (num1 + 2), totherback: 3);
            this.NoneId = this.AddSubPart(ref tsubpart, num77, num1 + 2, 32, 32, 1);
          }
          else
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.NONEBUTTON, 1, "Option not available", ref this.OwnBitmap, num77, num1 + 2, 3);
            this.None2Id = this.AddSubPart(ref tsubpart, num77, num1 + 2, 32, 32, 0);
          }
          int num78 = num77 + 40;
          if (this.AllId == 1)
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.ALLBUTTON, tDescript: "Select all eligble units to join attack", tBackbitmap: (ref this.OwnBitmap), bbx: num78, bby: (num1 + 2), totherback: 3);
            this.AllId = this.AddSubPart(ref tsubpart, num78, num1 + 2, 32, 32, 1);
          }
          else
          {
            tsubpart = (SubPartClass) new MarcButtonPartClass(this.game.ALLBUTTON, 1, "Option not available", ref this.OwnBitmap, num78, num1 + 2, 3);
            this.All2Id = this.AddSubPart(ref tsubpart, num78, num1 + 2, 32, 32, 0);
          }
        }
      }
    }

    public void DoTabs(ref Graphics g)
    {
      if ((double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode)
        return;
      SizeF sizeF1 = new SizeF();
      bool flag1 = false;
      if (this.game.Data.Product > 5 && (double) this.game.Data.RuleVar[461] > 0.0 && this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Location2 > -1)
      {
        if (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Location2].Type].isSupplyBase)
          flag1 = true;
        if (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Location2].Type].isSupplySource)
          flag1 = true;
      }
      this.tab1 = -1;
      this.tab2 = -1;
      this.tab3 = -1;
      this.tab4 = -1;
      this.tab51 = -1;
      this.tab52 = -1;
      this.tab53 = -1;
      this.tab6 = -1;
      this.tab101 = -1;
      if (this.game.EditObj.GuiDown)
        return;
      int num1;
      if (this.game.EditObj.UnitSelected == -1)
      {
        if (flag1)
        {
          int width = 182;
          int num2 = 180;
          if ((double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode)
            num2 += 240;
          int x1 = (int) Math.Round((double) num2 + (double) this.game.ScreenWidth / 2.0 - 480.0) - (width - 0);
          ref Graphics local1 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
          ref Bitmap local2 = ref bitmap;
          int x2 = x1;
          int w = width;
          DrawMod.DrawScaledColorized(ref local1, ref local2, x2, 66, w, 24, 182, 24, 0.0f, 0.0f, 0.0f, 1f);
          string str = "SUPPLY BASE";
          SizeF sizeF2 = g.MeasureString(str, this.game.MarcFont16);
          DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, (int) Math.Round((double) x1 + (double) width / 2.0 - (double) sizeF2.Width / 2.0), 70, Color.White);
          Rectangle trect = new Rectangle(x1, 66, width, 24);
          this.AddMouse(ref trect, "", "Information on the Supply Base in this Hex");
        }
        else
        {
          if (this.game.Data.ExtraTabName.Length <= 0)
            return;
          int width = 182;
          int num3 = 180;
          int num4 = 1;
          if (this.game.Data.ExtraTabName2.Length > 0)
          {
            width = 140;
            num3 = 260;
            num4 = 2;
          }
          if (this.game.Data.ExtraTabName3.Length > 0)
          {
            width = 112;
            num3 = 300;
            num4 = 3;
          }
          if ((double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode)
            num3 += 240;
          int num5 = num3 - width;
          if (this.game.EditObj.SetViewModeExtraNr == 0)
          {
            int x3 = (int) Math.Round((double) num5 + (double) this.game.ScreenWidth / 2.0 - 480.0) + (width - 12);
            Bitmap bitmap;
            Rectangle rectangle;
            if (this.game.Data.ExtraTabName3.Length > 0)
            {
              x3 -= width - 12;
              ref Graphics local3 = ref g;
              bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
              ref Bitmap local4 = ref bitmap;
              int x4 = x3;
              int w = width;
              DrawMod.DrawScaledColorized(ref local3, ref local4, x4, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
              string upper = this.game.Data.ExtraTabName3.ToUpper();
              SizeF sizeF3 = g.MeasureString(upper, this.game.MarcFont16);
              DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x3 + (double) width / 2.0 - (double) sizeF3.Width / 2.0), 70, Color.White);
              rectangle = new Rectangle(x3, 66, width, 24);
              Rectangle trect = rectangle;
              this.AddMouse(ref trect, "", "Extra data sheet.", 53);
              this.tab53 = this.MouseCounter;
            }
            if (this.game.Data.ExtraTabName2.Length > 0)
            {
              x3 -= width - 12;
              ref Graphics local5 = ref g;
              bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
              ref Bitmap local6 = ref bitmap;
              int x5 = x3;
              int w = width;
              DrawMod.DrawScaledColorized(ref local5, ref local6, x5, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
              string upper = this.game.Data.ExtraTabName2.ToUpper();
              SizeF sizeF4 = g.MeasureString(upper, this.game.MarcFont16);
              DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x3 + (double) width / 2.0 - (double) sizeF4.Width / 2.0), 70, Color.White);
              rectangle = new Rectangle(x3, 66, width, 24);
              Rectangle trect = rectangle;
              this.AddMouse(ref trect, "", "Extra data sheet.", 52);
              this.tab52 = this.MouseCounter;
            }
            int x6 = x3 - (width - 12);
            ref Graphics local7 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
            ref Bitmap local8 = ref bitmap;
            int x7 = x6;
            int w1 = width;
            DrawMod.DrawScaledColorized(ref local7, ref local8, x7, 66, w1, 24, 182, 24, 0.0f, 0.0f, 0.0f, 1f);
            string upper1 = this.game.Data.ExtraTabName.ToUpper();
            SizeF sizeF5 = g.MeasureString(upper1, this.game.MarcFont16);
            DrawMod.DrawTextColouredMarc(ref g, upper1, this.game.MarcFont16, (int) Math.Round((double) x6 + (double) width / 2.0 - (double) sizeF5.Width / 2.0), 70, Color.White);
            rectangle = new Rectangle(x6, 66, width, 24);
            Rectangle trect1 = rectangle;
            this.AddMouse(ref trect1, "", "Extra data sheet.", 51);
            this.tab51 = this.MouseCounter;
          }
          else
          {
            int x8 = (int) Math.Round((double) num5 + (double) this.game.ScreenWidth / 2.0 - 480.0) + (width - 12);
            Bitmap bitmap;
            string upper;
            Rectangle rectangle;
            if (this.game.Data.ExtraTabName3.Length > 0 & this.game.EditObj.SetViewModeExtraNr != 3)
            {
              x8 -= width - 12;
              ref Graphics local9 = ref g;
              bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
              ref Bitmap local10 = ref bitmap;
              int x9 = x8;
              int w = width;
              DrawMod.DrawScaledColorized(ref local9, ref local10, x9, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
              upper = this.game.Data.ExtraTabName3.ToUpper();
              SizeF sizeF6 = g.MeasureString(upper, this.game.MarcFont16);
              DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x8 + (double) width / 2.0 - (double) sizeF6.Width / 2.0), 70, Color.White);
              rectangle = new Rectangle(x8, 66, width, 24);
              Rectangle trect = rectangle;
              this.AddMouse(ref trect, "", "Extra data sheet.", 53);
              this.tab53 = this.MouseCounter;
            }
            else if (this.game.Data.ExtraTabName3.Length > 0)
              x8 -= width - 12;
            if (this.game.Data.ExtraTabName2.Length > 0 & this.game.EditObj.SetViewModeExtraNr != 2)
            {
              x8 -= width - 12;
              ref Graphics local11 = ref g;
              bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
              ref Bitmap local12 = ref bitmap;
              int x10 = x8;
              int w = width;
              DrawMod.DrawScaledColorized(ref local11, ref local12, x10, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
              upper = this.game.Data.ExtraTabName2.ToUpper();
              SizeF sizeF7 = g.MeasureString(upper, this.game.MarcFont16);
              DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x8 + (double) width / 2.0 - (double) sizeF7.Width / 2.0), 70, Color.White);
              rectangle = new Rectangle(x8, 66, width, 24);
              Rectangle trect = rectangle;
              this.AddMouse(ref trect, "", "Extra data sheet.", 52);
              this.tab52 = this.MouseCounter;
            }
            else if (this.game.Data.ExtraTabName2.Length > 0)
              x8 -= width - 12;
            if (this.game.Data.ExtraTabName.Length > 0 & this.game.EditObj.SetViewModeExtraNr != 1)
            {
              int x11 = x8 - (width - 12);
              ref Graphics local13 = ref g;
              bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
              ref Bitmap local14 = ref bitmap;
              int x12 = x11;
              int w = width;
              DrawMod.DrawScaledColorized(ref local13, ref local14, x12, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
              upper = this.game.Data.ExtraTabName.ToUpper();
              SizeF sizeF8 = g.MeasureString(upper, this.game.MarcFont16);
              DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x11 + (double) width / 2.0 - (double) sizeF8.Width / 2.0), 70, Color.White);
              rectangle = new Rectangle(x11, 66, width, 24);
              Rectangle trect = rectangle;
              this.AddMouse(ref trect, "", "Extra data sheet.", 51);
              this.tab51 = this.MouseCounter;
            }
            else if (this.game.Data.ExtraTabName.Length > 0)
              num1 = x8 - (width - 12);
            int x13 = (int) Math.Round((double) num5 + (double) this.game.ScreenWidth / 2.0 - 480.0) + (width - 12);
            if (this.game.EditObj.SetViewModeExtraNr == 1)
            {
              upper = this.game.Data.ExtraTabName.ToUpper();
              x13 -= (width - 12) * (num4 - 0);
            }
            if (this.game.EditObj.SetViewModeExtraNr == 2)
            {
              upper = this.game.Data.ExtraTabName2.ToUpper();
              x13 -= (width - 12) * (num4 - 1);
            }
            if (this.game.EditObj.SetViewModeExtraNr == 3)
            {
              upper = this.game.Data.ExtraTabName3.ToUpper();
              x13 -= (width - 12) * (num4 - 2);
            }
            ref Graphics local15 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
            ref Bitmap local16 = ref bitmap;
            int x14 = x13;
            int w2 = width;
            DrawMod.DrawScaledColorized(ref local15, ref local16, x14, 66, w2, 24, 182, 24, 0.0f, 0.0f, 0.0f, 1f);
            SizeF sizeF9 = g.MeasureString(upper, this.game.MarcFont16);
            DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x13 + (double) width / 2.0 - (double) sizeF9.Width / 2.0), 70, Color.White);
            rectangle = new Rectangle(x13, 66, width, 24);
            Rectangle trect2 = rectangle;
            this.AddMouse(ref trect2, "", "Extra data sheet.", 50 + this.game.EditObj.SetViewModeExtraNr);
            if (this.game.EditObj.SetViewModeExtraNr == 1)
              this.tab51 = this.MouseCounter;
            if (this.game.EditObj.SetViewModeExtraNr == 2)
              this.tab52 = this.MouseCounter;
            if (this.game.EditObj.SetViewModeExtraNr != 3)
              return;
            this.tab53 = this.MouseCounter;
          }
        }
      }
      else
      {
        if (this.game.EditObj.UnitSelected <= -1)
          return;
        object obj = (object) true;
        if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical > -1)
        {
          if (Information.IsNothing((object) this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].CommanderName))
            obj = (object) false;
          else if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].CommanderName.Length < 1)
            obj = (object) false;
          if (!this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
            ;
        }
        else
          obj = (object) false;
        if (this.game.EditObj.OrderType == 18 || this.game.EditObj.OrderType == 7 || this.game.EditObj.OrderType == 44 || this.game.EditObj.OrderType == 45 || this.game.EditObj.OrderType == 46 || this.game.EditObj.OrderType == 49)
          return;
        if (flag1)
        {
          int width = 182;
          int num6 = 180;
          if ((double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode)
            num6 += 120;
          int num7 = (int) Math.Round((double) num6 + (double) this.game.ScreenWidth / 2.0 - 480.0);
          if (this.game.EditObj.SetViewModeExtraNr == 0)
          {
            int x15 = num7 + (width - 34) - (width - 24);
            ref Graphics local17 = ref g;
            Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
            ref Bitmap local18 = ref bitmap1;
            int x16 = x15;
            int w3 = width;
            DrawMod.DrawScaledColorized(ref local17, ref local18, x16, 66, w3, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
            string str1 = "SUPPLY BASE";
            SizeF sizeF10 = g.MeasureString(str1, this.game.MarcFont16);
            DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont16, (int) Math.Round((double) x15 + (double) width / 2.0 - (double) sizeF10.Width / 2.0), 70, Color.White);
            Rectangle rectangle = new Rectangle(x15, 66, width, 24);
            Rectangle trect3 = rectangle;
            this.AddMouse(ref trect3, "", "Information on the Supply Base in this Hex", 101);
            this.tab101 = this.MouseCounter;
            int x17 = x15 - (width - 12);
            ref Graphics local19 = ref g;
            Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
            ref Bitmap local20 = ref bitmap2;
            int x18 = x17;
            int w4 = width;
            DrawMod.DrawScaledColorized(ref local19, ref local20, x18, 66, w4, 24, 182, 24, 0.0f, 0.0f, 0.0f, 1f);
            string str2 = "UNIT BASE INFO";
            SizeF sizeF11 = g.MeasureString(str2, this.game.MarcFont16);
            DrawMod.DrawTextColouredMarc(ref g, str2, this.game.MarcFont16, (int) Math.Round((double) x17 + (double) width / 2.0 - (double) sizeF11.Width / 2.0), 70, Color.White);
            rectangle = new Rectangle(x17, 66, width, 24);
            Rectangle trect4 = rectangle;
            this.AddMouse(ref trect4, "", "The base info of the unit is always shown.");
          }
          else
          {
            int x19 = num7 - (width - 0);
            ref Graphics local21 = ref g;
            Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
            ref Bitmap local22 = ref bitmap;
            int x20 = x19;
            int w5 = width;
            DrawMod.DrawScaledColorized(ref local21, ref local22, x20, 66, w5, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
            string str3 = "UNIT BASE INFO";
            SizeF sizeF12 = g.MeasureString(str3, this.game.MarcFont16);
            DrawMod.DrawTextColouredMarc(ref g, str3, this.game.MarcFont16, (int) Math.Round((double) x19 + (double) width / 2.0 - (double) sizeF12.Width / 2.0), 70, Color.White);
            Rectangle rectangle = new Rectangle(x19, 66, width, 24);
            Rectangle trect5 = rectangle;
            this.AddMouse(ref trect5, "", "The base info of the unit is always shown.", 6);
            this.tab6 = this.MouseCounter;
            int x21 = x19 + (width - 12);
            ref Graphics local23 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
            ref Bitmap local24 = ref bitmap;
            int x22 = x21;
            int w6 = width;
            DrawMod.DrawScaledColorized(ref local23, ref local24, x22, 66, w6, 24, 182, 24, 0.0f, 0.0f, 0.0f, 1f);
            string str4 = "SUPPLY BASE";
            SizeF sizeF13 = g.MeasureString(str4, this.game.MarcFont16);
            DrawMod.DrawTextColouredMarc(ref g, str4, this.game.MarcFont16, (int) Math.Round((double) x21 + (double) width / 2.0 - (double) sizeF13.Width / 2.0), 70, Color.White);
            rectangle = new Rectangle(x21, 66, width, 24);
            Rectangle trect6 = rectangle;
            this.AddMouse(ref trect6, "", "Information on the Supply Base in this Hex");
          }
        }
        else if (this.game.Data.ExtraTabName.Length > 0)
        {
          int width = 182;
          int num8 = 180;
          int num9 = 1;
          if (this.game.Data.ExtraTabName2.Length > 0)
          {
            width = 140;
            num8 = 260;
            num9 = 2;
          }
          if (this.game.Data.ExtraTabName3.Length > 0)
          {
            width = 112;
            num8 = 300;
            num9 = 3;
          }
          if ((double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode)
            num8 += 120;
          if (this.game.EditObj.SetViewModeExtraNr == 0)
          {
            int x23 = (int) Math.Round((double) num8 + (double) this.game.ScreenWidth / 2.0 - 480.0) + (width - 12);
            Bitmap bitmap;
            Rectangle rectangle;
            if (this.game.Data.ExtraTabName3.Length > 0)
            {
              x23 -= width - 12;
              ref Graphics local25 = ref g;
              bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
              ref Bitmap local26 = ref bitmap;
              int x24 = x23;
              int w = width;
              DrawMod.DrawScaledColorized(ref local25, ref local26, x24, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
              string upper = this.game.Data.ExtraTabName3.ToUpper();
              SizeF sizeF14 = g.MeasureString(upper, this.game.MarcFont16);
              DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x23 + (double) width / 2.0 - (double) sizeF14.Width / 2.0), 70, Color.White);
              rectangle = new Rectangle(x23, 66, width, 24);
              Rectangle trect = rectangle;
              this.AddMouse(ref trect, "", "Extra data sheet.", 53);
              this.tab53 = this.MouseCounter;
            }
            if (this.game.Data.ExtraTabName2.Length > 0)
            {
              x23 -= width - 12;
              ref Graphics local27 = ref g;
              bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
              ref Bitmap local28 = ref bitmap;
              int x25 = x23;
              int w = width;
              DrawMod.DrawScaledColorized(ref local27, ref local28, x25, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
              string upper = this.game.Data.ExtraTabName2.ToUpper();
              SizeF sizeF15 = g.MeasureString(upper, this.game.MarcFont16);
              DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x23 + (double) width / 2.0 - (double) sizeF15.Width / 2.0), 70, Color.White);
              rectangle = new Rectangle(x23, 66, width, 24);
              Rectangle trect = rectangle;
              this.AddMouse(ref trect, "", "Extra data sheet.", 52);
              this.tab52 = this.MouseCounter;
            }
            int x26 = x23 - (width - 12);
            ref Graphics local29 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
            ref Bitmap local30 = ref bitmap;
            int x27 = x26;
            int w7 = width;
            DrawMod.DrawScaledColorized(ref local29, ref local30, x27, 66, w7, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
            string upper2 = this.game.Data.ExtraTabName.ToUpper();
            SizeF sizeF16 = g.MeasureString(upper2, this.game.MarcFont16);
            DrawMod.DrawTextColouredMarc(ref g, upper2, this.game.MarcFont16, (int) Math.Round((double) x26 + (double) width / 2.0 - (double) sizeF16.Width / 2.0), 70, Color.White);
            rectangle = new Rectangle(x26, 66, width, 24);
            Rectangle trect7 = rectangle;
            this.AddMouse(ref trect7, "", "Extra data sheet.", 51);
            this.tab51 = this.MouseCounter;
            int x28 = x26 - (width - 12);
            ref Graphics local31 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
            ref Bitmap local32 = ref bitmap;
            int x29 = x28;
            int w8 = width;
            DrawMod.DrawScaledColorized(ref local31, ref local32, x29, 66, w8, 24, 182, 24, 0.0f, 0.0f, 0.0f, 1f);
            string str = "UNIT INFO";
            SizeF sizeF17 = g.MeasureString(str, this.game.MarcFont16);
            DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, (int) Math.Round((double) x28 + (double) width / 2.0 - (double) sizeF17.Width / 2.0), 70, Color.White);
            rectangle = new Rectangle(x28, 66, width, 24);
            Rectangle trect8 = rectangle;
            this.AddMouse(ref trect8, "", "The base info of the unit is always shown.");
          }
          else
          {
            int x30 = (int) Math.Round((double) num8 + (double) this.game.ScreenWidth / 2.0 - 480.0) + (width - 12);
            Bitmap bitmap;
            Rectangle rectangle;
            if (this.game.Data.ExtraTabName3.Length > 0 & this.game.EditObj.SetViewModeExtraNr != 3)
            {
              x30 -= width - 12;
              ref Graphics local33 = ref g;
              bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
              ref Bitmap local34 = ref bitmap;
              int x31 = x30;
              int w = width;
              DrawMod.DrawScaledColorized(ref local33, ref local34, x31, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
              string upper = this.game.Data.ExtraTabName3.ToUpper();
              SizeF sizeF18 = g.MeasureString(upper, this.game.MarcFont16);
              DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x30 + (double) width / 2.0 - (double) sizeF18.Width / 2.0), 70, Color.White);
              rectangle = new Rectangle(x30, 66, width, 24);
              Rectangle trect = rectangle;
              this.AddMouse(ref trect, "", "Extra data sheet.", 53);
              this.tab53 = this.MouseCounter;
            }
            else if (this.game.Data.ExtraTabName3.Length > 0)
              x30 -= width - 12;
            if (this.game.Data.ExtraTabName2.Length > 0 & this.game.EditObj.SetViewModeExtraNr != 2)
            {
              x30 -= width - 12;
              ref Graphics local35 = ref g;
              bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
              ref Bitmap local36 = ref bitmap;
              int x32 = x30;
              int w = width;
              DrawMod.DrawScaledColorized(ref local35, ref local36, x32, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
              string upper = this.game.Data.ExtraTabName2.ToUpper();
              SizeF sizeF19 = g.MeasureString(upper, this.game.MarcFont16);
              DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x30 + (double) width / 2.0 - (double) sizeF19.Width / 2.0), 70, Color.White);
              rectangle = new Rectangle(x30, 66, width, 24);
              Rectangle trect = rectangle;
              this.AddMouse(ref trect, "", "Extra data sheet.", 52);
              this.tab52 = this.MouseCounter;
            }
            else if (this.game.Data.ExtraTabName2.Length > 0)
              x30 -= width - 12;
            if (this.game.Data.ExtraTabName.Length > 0 & this.game.EditObj.SetViewModeExtraNr != 1)
            {
              int x33 = x30 - (width - 12);
              ref Graphics local37 = ref g;
              bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
              ref Bitmap local38 = ref bitmap;
              int x34 = x33;
              int w = width;
              DrawMod.DrawScaledColorized(ref local37, ref local38, x34, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
              string upper = this.game.Data.ExtraTabName.ToUpper();
              SizeF sizeF20 = g.MeasureString(upper, this.game.MarcFont16);
              DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x33 + (double) width / 2.0 - (double) sizeF20.Width / 2.0), 70, Color.White);
              rectangle = new Rectangle(x33, 66, width, 24);
              Rectangle trect = rectangle;
              this.AddMouse(ref trect, "", "Extra data sheet.", 51);
              this.tab51 = this.MouseCounter;
            }
            else if (this.game.Data.ExtraTabName.Length > 0)
              num1 = x30 - (width - 12);
            int num10 = (int) Math.Round((double) num8 + (double) this.game.ScreenWidth / 2.0 - 480.0) + (width - 12);
            if (this.game.Data.ExtraTabName3.Length > 0)
              num10 -= width - 12;
            if (this.game.Data.ExtraTabName2.Length > 0)
              num10 -= width - 12;
            if (this.game.Data.ExtraTabName.Length > 0)
              num10 -= width - 12;
            int x35 = num10 - (width - 12);
            ref Graphics local39 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
            ref Bitmap local40 = ref bitmap;
            int x36 = x35;
            int w9 = width;
            DrawMod.DrawScaledColorized(ref local39, ref local40, x36, 66, w9, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
            string str = "UNIT INFO";
            SizeF sizeF21 = g.MeasureString(str, this.game.MarcFont16);
            DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, (int) Math.Round((double) x35 + (double) width / 2.0 - (double) sizeF21.Width / 2.0), 70, Color.White);
            rectangle = new Rectangle(x35, 66, width, 24);
            Rectangle trect9 = rectangle;
            this.AddMouse(ref trect9, "", "The base info of the unit is always shown.", 6);
            this.tab6 = this.MouseCounter;
            int x37 = (int) Math.Round((double) num8 + (double) this.game.ScreenWidth / 2.0 - 480.0) + (width - 12);
            if (this.game.EditObj.SetViewModeExtraNr == 1)
            {
              str = this.game.Data.ExtraTabName.ToUpper();
              x37 -= (width - 12) * (num9 - 0);
            }
            if (this.game.EditObj.SetViewModeExtraNr == 2)
            {
              str = this.game.Data.ExtraTabName2.ToUpper();
              x37 -= (width - 12) * (num9 - 1);
            }
            if (this.game.EditObj.SetViewModeExtraNr == 3)
            {
              str = this.game.Data.ExtraTabName3.ToUpper();
              x37 -= (width - 12) * (num9 - 2);
            }
            ref Graphics local41 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
            ref Bitmap local42 = ref bitmap;
            int x38 = x37;
            int w10 = width;
            DrawMod.DrawScaledColorized(ref local41, ref local42, x38, 66, w10, 24, 182, 24, 0.0f, 0.0f, 0.0f, 1f);
            SizeF sizeF22 = g.MeasureString(str, this.game.MarcFont16);
            DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, (int) Math.Round((double) x37 + (double) width / 2.0 - (double) sizeF22.Width / 2.0), 70, Color.White);
            rectangle = new Rectangle(x37, 66, width, 24);
            Rectangle trect10 = rectangle;
            this.AddMouse(ref trect10, "", "Extra data sheet.", 50 + this.game.EditObj.SetViewModeExtraNr);
            if (this.game.EditObj.SetViewModeExtraNr == 1)
              this.tab51 = this.MouseCounter;
            if (this.game.EditObj.SetViewModeExtraNr == 2)
              this.tab52 = this.MouseCounter;
            if (this.game.EditObj.SetViewModeExtraNr == 3)
              this.tab53 = this.MouseCounter;
          }
        }
        else
        {
          int num11 = 0;
          if ((double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode)
            num11 += 120;
          int x39 = (int) Math.Round((double) num11 + (double) this.game.ScreenWidth / 2.0 - 480.0);
          ref Graphics local43 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
          ref Bitmap local44 = ref bitmap;
          int x40 = x39;
          DrawMod.DrawSimple(ref local43, ref local44, x40, 66);
          string str = "UNIT BASE INFO";
          SizeF sizeF23 = g.MeasureString(str, this.game.MarcFont16);
          DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, (int) Math.Round((double) ((float) (x39 + 91) - sizeF23.Width / 2f)), 70, Color.White);
          Rectangle trect = new Rectangle(x39, 66, BitmapStore.GetWidth(this.game.MARCLARGETAB), 24);
          this.AddMouse(ref trect, "", "The base info of the unit is always shown.");
        }
        if (!(this.game.EditObj.SetViewModeExtraNr == 0 | !flag1 & this.game.EditObj.SetViewModeExtraNr == 101))
          return;
        bool flag2;
        if (this.game.EditObj.OrderType == 14)
          flag2 = true;
        if (this.game.EditObj.OrderType == 15)
          flag2 = true;
        if (this.game.EditObj.OrderType == 2)
          flag2 = true;
        if (this.game.EditObj.OrderType == 12)
          flag2 = true;
        if (this.game.EditObj.OrderType == 11)
          flag2 = true;
        if (this.game.EditObj.OrderType == 13)
          flag2 = true;
        if (this.CurrentView == 2 & !flag2)
        {
          this.CurrentView = 0;
          this.game.EditObj.SetViewMode = 0;
        }
        if (Conversions.ToBoolean(Operators.AndObject((object) (this.CurrentView == 3), Operators.OrObject((object) !this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ, Operators.CompareObjectEqual(obj, (object) false, false)))))
        {
          this.CurrentView = 0;
          this.game.EditObj.SetViewMode = 0;
          this.game.EditObj.SetViewMode3 = false;
        }
        if (Conversions.ToBoolean(Operators.AndObject((object) (this.CurrentView == 0), Operators.AndObject((object) this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ, obj))) && !this.game.EditObj.SetViewMode3)
        {
          this.CurrentView = 3;
          this.game.EditObj.SetViewMode = 3;
          this.game.EditObj.SetViewMode3 = true;
        }
        if (Conversions.ToBoolean(Operators.AndObject((object) this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ, Operators.CompareObjectEqual(obj, (object) true, false))))
        {
          if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.Turn) | !this.game.Data.FOWOn)
          {
            if (this.CurrentView == 3)
            {
              if (flag2)
                this.DoTabs3(ref g);
              else
                this.DoTabs2B(ref g);
              this.DoTabs1B(ref g);
              this.DoTabs4(ref g, true);
            }
            else if (this.CurrentView == 0)
            {
              if (flag2)
                this.DoTabs3(ref g);
              else
                this.DoTabs2B(ref g);
              this.DoTabs4(ref g);
              this.DoTabs1B(ref g, true);
            }
            else if (this.CurrentView == 1)
            {
              this.DoTabs4(ref g);
              this.DoTabs1B(ref g);
              if (flag2)
                this.DoTabs3(ref g, true);
              else
                this.DoTabs2B(ref g, true);
            }
            else
            {
              if (this.CurrentView != 2)
                return;
              this.DoTabs4(ref g);
              if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.Turn))
                this.DoTabs1B(ref g);
              if (flag2)
                this.DoTabs3(ref g, true);
              else
                this.DoTabs2B(ref g, true);
            }
          }
          else if (this.CurrentView != 3)
          {
            this.DoTabs4(ref g);
            this.DoTabs1B(ref g, true);
          }
          else
          {
            this.DoTabs1B(ref g);
            this.DoTabs4(ref g, true);
          }
        }
        else if (this.CurrentView == 0)
        {
          if (flag2)
            this.DoTabs3(ref g);
          if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.Turn) | !this.game.Data.FOWOn)
            this.DoTabs2(ref g);
          this.DoTabs1(ref g, true);
        }
        else if (this.CurrentView == 1)
        {
          if (flag2)
            this.DoTabs3(ref g);
          this.DoTabs1(ref g);
          if (!(this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.Turn) | !this.game.Data.FOWOn))
            return;
          this.DoTabs2(ref g, true);
        }
        else
        {
          if (this.CurrentView != 2)
            return;
          this.DoTabs1(ref g);
          if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.Turn) | !this.game.Data.FOWOn)
            this.DoTabs2(ref g);
          if (!flag2)
            return;
          this.DoTabs3(ref g, true);
        }
      }
    }

    public void DoTabs1(ref Graphics g, bool Active = false)
    {
      SizeF sizeF1 = new SizeF();
      int num = (int) Math.Round((double) this.game.ScreenWidth / 2.0 - 480.0);
      if (!Active)
      {
        ref Graphics local1 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local2 = ref bitmap;
        int x = num + 420;
        DrawMod.Draw(ref local1, ref local2, x, 66, -0.1f, -0.1f, -0.1f, 1f);
      }
      else
      {
        ref Graphics local3 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local4 = ref bitmap;
        int x = num + 420;
        DrawMod.DrawSimple(ref local3, ref local4, x, 66);
      }
      string str = "UNIT TROOPS";
      SizeF sizeF2 = g.MeasureString(str, this.game.MarcFont16);
      int x1 = (int) Math.Round((double) ((float) (num + 420 + 91) - sizeF2.Width / 2f));
      int y = 66;
      DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, x1, y + 4, Color.White);
      if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SFCount + 1 + this.game.Data.UnitObj[this.game.EditObj.UnitSelected].PassengerCounter > 7)
      {
        DrawMod.DrawBlock(ref g, (int) Math.Round((double) x1 + (double) sizeF2.Width + 1.0 + 2.0), y + 8 + 2, 9, 9, 0, 0, 0, 196);
        DrawMod.DrawBlock(ref g, (int) Math.Round((double) x1 + (double) sizeF2.Width + 1.0), y + 8, 9, 9, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      }
      Rectangle trect = new Rectangle(num + 420, y, 182, 24);
      this.AddMouse(ref trect, "", "Click to get more stats on selected unit. [F10]", 1);
      this.tab1 = this.MouseCounter;
    }

    public void DoTabs1B(ref Graphics g, bool Active = false)
    {
      SizeF sizeF1 = new SizeF();
      int num = (int) Math.Round((double) this.game.ScreenWidth / 2.0 - 480.0);
      if (!Active)
      {
        ref Graphics local1 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local2 = ref bitmap;
        int x = num + 420 + 170;
        DrawMod.Draw(ref local1, ref local2, x, 66, -0.1f, -0.1f, -0.1f, 1f);
      }
      else
      {
        ref Graphics local3 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local4 = ref bitmap;
        int x = num + 420 + 170;
        DrawMod.DrawSimple(ref local3, ref local4, x, 66);
      }
      string str = "UNIT TROOPS";
      SizeF sizeF2 = g.MeasureString(str, this.game.MarcFont16);
      int x1 = (int) Math.Round((double) ((float) (num + 420 + 170 + 91) - sizeF2.Width / 2f));
      int y = 66;
      DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, x1, y + 4, Color.White);
      if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SFCount + 1 + this.game.Data.UnitObj[this.game.EditObj.UnitSelected].PassengerCounter > 7)
      {
        DrawMod.DrawBlock(ref g, (int) Math.Round((double) x1 + (double) sizeF2.Width + 1.0 + 2.0), y + 8 + 2, 9, 9, 0, 0, 0, 196);
        DrawMod.DrawBlock(ref g, (int) Math.Round((double) x1 + (double) sizeF2.Width + 1.0), y + 8, 9, 9, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      }
      Rectangle trect = new Rectangle(num + 420 + 170, y, 182, 24);
      this.AddMouse(ref trect, "", "Click to get more stats on selected unit. [F10]", 1);
      this.tab1 = this.MouseCounter;
    }

    public void DoTabs2(ref Graphics g, bool Active = false)
    {
      SizeF sizeF1 = new SizeF();
      if (this.game.Data.Round == 0)
        return;
      int num = (int) Math.Round((double) this.game.ScreenWidth / 2.0 - 480.0);
      if (!Active)
      {
        ref Graphics local1 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local2 = ref bitmap;
        int x = num + 170 + 420;
        DrawMod.Draw(ref local1, ref local2, x, 66, -0.1f, -0.1f, -0.1f, 1f);
      }
      else
      {
        ref Graphics local3 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local4 = ref bitmap;
        int x = num + 170 + 420;
        DrawMod.DrawSimple(ref local3, ref local4, x, 66);
      }
      string str = "UNIT DETAILS";
      SizeF sizeF2 = g.MeasureString(str, this.game.MarcFont16);
      int x1 = (int) Math.Round((double) ((float) (num + 420 + 170 + 91) - sizeF2.Width / 2f));
      int y = 66;
      DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, x1, y + 4, Color.White);
      Rectangle trect = new Rectangle(num + 170 + 420, y, 182, 24);
      this.AddMouse(ref trect, "", "Click to see detailed stats on the unit. [F11]", 2);
      this.tab2 = this.MouseCounter;
    }

    public void DoTabs2B(ref Graphics g, bool Active = false)
    {
      SizeF sizeF1 = new SizeF();
      if (this.game.Data.Round == 0)
        return;
      int num = (int) Math.Round((double) this.game.ScreenWidth / 2.0 - 480.0);
      if (!Active)
      {
        ref Graphics local1 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local2 = ref bitmap;
        int x = num + 340 + 420;
        DrawMod.Draw(ref local1, ref local2, x, 66, -0.1f, -0.1f, -0.1f, 1f);
      }
      else
      {
        ref Graphics local3 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local4 = ref bitmap;
        int x = num + 340 + 420;
        DrawMod.DrawSimple(ref local3, ref local4, x, 66);
      }
      string str = "UNIT DETAILS";
      SizeF sizeF2 = g.MeasureString(str, this.game.MarcFont16);
      int x1 = (int) Math.Round((double) ((float) (num + 420 + 340 + 91) - sizeF2.Width / 2f));
      int y = 66;
      DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, x1, y + 4, Color.White);
      Rectangle trect = new Rectangle(num + 340 + 420, y, 182, 24);
      this.AddMouse(ref trect, "", "Click to see detailed stats on the unit. [F11]", 2);
      this.tab2 = this.MouseCounter;
    }

    public void DoTabs3(ref Graphics g, bool Active = false)
    {
      SizeF sizeF1 = new SizeF();
      if (this.game.Data.Round == 0)
        return;
      int num = (int) Math.Round((double) this.game.ScreenWidth / 2.0 - 480.0);
      if (!Active)
      {
        ref Graphics local1 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local2 = ref bitmap;
        int x = num + 340 + 420;
        DrawMod.Draw(ref local1, ref local2, x, 66, -0.1f, -0.1f, -0.1f, 1f);
      }
      else
      {
        ref Graphics local3 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local4 = ref bitmap;
        int x = num + 340 + 420;
        DrawMod.DrawSimple(ref local3, ref local4, x, 66);
      }
      string str = "COMBAT SETUP";
      SizeF sizeF2 = g.MeasureString(str, this.game.MarcFont16);
      int x1 = (int) Math.Round((double) ((float) (num + 420 + 340 + 91) - sizeF2.Width / 2f));
      int y = 66;
      DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, x1, y + 4, Color.White);
      Rectangle trect = new Rectangle(num + 340 + 420, y, 182, 24);
      this.AddMouse(ref trect, "", "Click to see the combat setup. [F12]", 3);
      this.tab3 = this.MouseCounter;
    }

    public void DoTabs4(ref Graphics g, bool Active = false)
    {
      SizeF sizeF1 = new SizeF();
      int num = (int) Math.Round((double) this.game.ScreenWidth / 2.0 - 480.0);
      if (!Active)
      {
        ref Graphics local1 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local2 = ref bitmap;
        int x = num + 0 + 420;
        DrawMod.Draw(ref local1, ref local2, x, 66, -0.1f, -0.1f, -0.1f, 1f);
      }
      else
      {
        ref Graphics local3 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local4 = ref bitmap;
        int x = num + 0 + 420;
        DrawMod.DrawSimple(ref local3, ref local4, x, 66);
      }
      string str = "OFFICER INFO";
      SizeF sizeF2 = g.MeasureString(str, this.game.MarcFont16);
      int x1 = (int) Math.Round((double) ((float) (num + 420 + 0 + 91) - sizeF2.Width / 2f));
      int y = 66;
      DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, x1, y + 4, Color.White);
      Rectangle trect = new Rectangle(num + 0 + 420, y, 182, 24);
      this.AddMouse(ref trect, "", "Click to see the info on the officer with this unit. [F9]", 4);
      this.tab4 = this.MouseCounter;
    }

    public void DoTabs4B(ref Graphics g, bool Active = false)
    {
      SizeF sizeF1 = new SizeF();
      int num = (int) Math.Round((double) this.game.ScreenWidth / 2.0 - 480.0);
      if (!Active)
      {
        ref Graphics local1 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local2 = ref bitmap;
        int x = num + 170 + 420;
        DrawMod.Draw(ref local1, ref local2, x, 66, -0.1f, -0.1f, -0.1f, 1f);
      }
      else
      {
        ref Graphics local3 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local4 = ref bitmap;
        int x = num + 170 + 420;
        DrawMod.DrawSimple(ref local3, ref local4, x, 66);
      }
      string str = "OFFICER INFO";
      SizeF sizeF2 = g.MeasureString(str, this.game.MarcFont16);
      int x1 = (int) Math.Round((double) ((float) (num + 420 + 170 + 91) - sizeF2.Width / 2f));
      int y = 66;
      DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, x1, y + 4, Color.White);
      Rectangle trect = new Rectangle(num + 170 + 420, y, 182, 24);
      this.AddMouse(ref trect, "", "Click to see the info on the officer with this unit. [F9]", 4);
      this.tab4 = this.MouseCounter;
    }

    public override void HandleToolTip(int x, int y)
    {
      base.HandleToolTip(x, y);
      if (this.SubPartCounter <= -1)
        return;
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
      {
        if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index] && Operators.CompareString(this.SubPartList[index].Descript, "", false) > 0)
        {
          this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = "";
          this.game.EditObj.TipText = this.SubPartList[index].Descript;
          break;
        }
      }
    }

    public override WindowReturnClass HandleMouseMove(int x, int y)
    {
      WindowReturnClass windowReturnClass = base.HandleMouseMove(x, y);
      if (y > 18 && (double) this.w / 2.0 - 500.0 < (double) x & (double) x < (double) this.w / 2.0 + 500.0)
        windowReturnClass.NoMouseClickBelow = true;
      if ((double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode && y > 0 && (double) this.w / 2.0 - 640.0 < (double) x & (double) x < (double) this.w / 2.0 + 640.0)
        windowReturnClass.NoMouseClickBelow = true;
      return windowReturnClass;
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      int[,] numArray = new int[this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1, this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1];
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      if (this.game.EditObj.BattleTimerActive)
        return windowReturnClass1;
      if (y > 18 && (double) this.w / 2.0 - 500.0 < (double) x & (double) x < (double) this.w / 2.0 + 500.0)
        windowReturnClass1.NoMouseClickBelow = true;
      for (int mouseCounter = this.MouseCounter; mouseCounter >= 0; mouseCounter += -1)
      {
        if (this.MouseData[mouseCounter] > 0 && x > this.MouseRect[mouseCounter].X & x < this.MouseRect[mouseCounter].X + this.MouseRect[mouseCounter].Width && y > this.MouseRect[mouseCounter].Y & y < this.MouseRect[mouseCounter].Y + this.MouseRect[mouseCounter].Height)
        {
          switch (this.MouseData[mouseCounter])
          {
            case 1:
              if (this.game.EditObj.SetViewMode == 0)
                this.game.EditObj.SubformationListMode = !this.game.EditObj.SubformationListMode;
              this.game.EditObj.SetViewMode = 0;
              this.dostuff();
              windowReturnClass1.AddCommand(4, 69);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            case 2:
              this.game.EditObj.SetViewMode = 1;
              this.dostuff();
              windowReturnClass1.AddCommand(4, 69);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            case 3:
              this.game.EditObj.SetViewMode = 2;
              this.dostuff();
              windowReturnClass1.AddCommand(4, 69);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            case 4:
              this.game.EditObj.SetViewMode = 3;
              this.dostuff();
              windowReturnClass1.AddCommand(4, 69);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            case 6:
              this.game.EditObj.SetViewModeExtraNr = 0;
              this.dostuff();
              windowReturnClass1.AddCommand(4, 69);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            case 51:
              this.game.EditObj.SetViewModeExtraNr = 1;
              this.dostuff();
              windowReturnClass1.AddCommand(4, 69);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            case 52:
              this.game.EditObj.SetViewModeExtraNr = 2;
              this.dostuff();
              windowReturnClass1.AddCommand(4, 69);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            case 53:
              this.game.EditObj.SetViewModeExtraNr = 3;
              this.dostuff();
              windowReturnClass1.AddCommand(4, 69);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            case 101:
              this.game.EditObj.SetViewModeExtraNr = 101;
              this.dostuff();
              windowReturnClass1.AddCommand(4, 69);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            case 201:
              if (this.Cancelid > 0)
                this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.Cancelid)] + 1, this.SubPartY[this.SubpartNr(this.Cancelid)] + 1, 1);
              this.game.EditObj.udsUnitOrderMode = 1;
              ScreenClass screeny1 = this.formref.Screeny;
              System.Type type1 = typeof (MapWindowClass2);
              ref System.Type local1 = ref type1;
              MapWindowClass2 window1 = (MapWindowClass2) screeny1.GetWindow(ref local1);
              if (!Information.IsNothing((object) window1))
              {
                this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                if (this.game.EditObj.UnitSelected > -1)
                  window1.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                else
                  window1.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
              }
              if (this.Cancelid > 0)
                this.game.EditObj.TempCoordList = new CoordList();
              windowReturnClass1.AddCommand(4, 12);
              windowReturnClass1.AddCommand(4, 9);
              windowReturnClass1.AddCommand(4, 67);
              windowReturnClass1.AddCommand(4, 68);
              windowReturnClass1.AddCommand(4, 69);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            case 202:
              if (this.Cancelid > 0)
                this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.Cancelid)] + 1, this.SubPartY[this.SubpartNr(this.Cancelid)] + 1, 1);
              this.game.EditObj.udsUnitOrderMode = 48;
              ScreenClass screeny2 = this.formref.Screeny;
              System.Type type2 = typeof (MapWindowClass2);
              ref System.Type local2 = ref type2;
              MapWindowClass2 window2 = (MapWindowClass2) screeny2.GetWindow(ref local2);
              if (!Information.IsNothing((object) window2))
              {
                this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                if (this.game.EditObj.UnitSelected > -1)
                  window2.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                else
                  window2.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
              }
              if (this.Cancelid > 0)
                this.game.EditObj.TempCoordList = new CoordList();
              windowReturnClass1.AddCommand(4, 12);
              windowReturnClass1.AddCommand(4, 9);
              windowReturnClass1.AddCommand(4, 67);
              windowReturnClass1.AddCommand(4, 68);
              windowReturnClass1.AddCommand(4, 69);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            case 203:
              if (this.Cancelid > 0)
                this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.Cancelid)] + 1, this.SubPartY[this.SubpartNr(this.Cancelid)] + 1, 1);
              this.game.EditObj.OrderType = 0;
              if ((double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode)
              {
                this.game.EditObj.udsUnitOrderMode = 0;
                ScreenClass screeny3 = this.formref.Screeny;
                System.Type type3 = typeof (MapWindowClass2);
                ref System.Type local3 = ref type3;
                MapWindowClass2 window3 = (MapWindowClass2) screeny3.GetWindow(ref local3);
                if (!Information.IsNothing((object) window3))
                {
                  this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                  if (this.game.EditObj.UnitSelected > -1)
                    window3.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                  else
                    window3.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                }
              }
              else
              {
                this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                this.game.SelectX = this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X;
                this.game.SelectY = this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y;
                this.game.EditObj.MapSelected = this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Map;
              }
              if (this.Cancelid > 0)
                this.game.EditObj.TempCoordList = new CoordList();
              windowReturnClass1.AddCommand(4, 12);
              windowReturnClass1.AddCommand(4, 67);
              windowReturnClass1.AddCommand(4, 69);
              windowReturnClass1.AddCommand(4, 68);
              windowReturnClass1.AddCommand(4, 9);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            default:
              continue;
          }
        }
      }
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index1 = 0; index1 <= subPartCounter; ++index1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int index2 = 1;
            while (this.ActionButtonId[index2] != this.SubPartID[index1])
            {
              ++index2;
              if (index2 > 10)
              {
                int num1 = this.SubPartID[index1];
                if (num1 == this.GuiDownId)
                {
                  if (!this.game.EditObj.GuiDown)
                    this.game.EditObj.GuiDown = true;
                  else
                    this.game.EditObj.GuiDown = false;
                  windowReturnClass1.AddCommand(3, 11);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (num1 == this.SaveId)
                {
                  string str1;
                  if (this.game.Data.Round == 0)
                  {
                    string str2 = this.game.AppPath + "scenarios\\";
                    if (!Information.IsNothing((object) this.game.Data.ScenarioDir))
                    {
                      if (this.game.Data.ScenarioDir.Length > 1)
                        str1 = str2.Replace("scenarios", this.game.Data.ScenarioDir);
                      else if (this.game.ModScenarioDir.Length > 1)
                        str1 = str2.Replace("scenarios", this.game.ModScenarioDir);
                    }
                    else if (this.game.ModScenarioDir.Length > 1)
                      str1 = str2.Replace("scenarios", this.game.ModScenarioDir);
                  }
                  else
                    str1 = "savedgames";
                  string str3 = this.game.Data.Round != 0 ? this.game.HandyFunctionsObj.SaveSomething("SE1 Scenario file (*.se1)|*.se1", "Give save name...", this.game.AppPath_SAVEGAMES, false) : this.game.HandyFunctionsObj.SaveSomething("SE1 Scenario file (*.se1)|*.se1", "Give save name...", this.game.AppPath_SAVEGAMES, false);
                  if (Strings.Len(str3) >= 2)
                  {
                    this.game.FormRef.Cursor = Cursors.WaitCursor;
                    this.game.Data.serialize(str3);
                    this.game.HandyFunctionsObj.ZipFile(str3);
                    windowReturnClass1.SetFlag(true);
                    this.game.FormRef.Cursor = Cursors.Default;
                  }
                }
                else if (num1 == this.BattleId)
                {
                  if (this.game.Data.Product >= 6 & (double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode)
                  {
                    this.game.EditObj.PopupValue = 22;
                    windowReturnClass1.AddCommand(5, 14);
                    this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                    windowReturnClass1.SetFlag(true);
                  }
                  else
                  {
                    this.game.EditObj.BattleTimerActive = true;
                    this.game.EditObj.BattleTimer = DateTime.Now + new TimeSpan(0, 0, 0, 0, 1000);
                  }
                }
                else if (num1 == this.PopupButtonId)
                {
                  switch (this.game.EditObj.OrderType)
                  {
                    case 2:
                      this.TimerUsed = false;
                      this.game.EditObj.PopupValue = 18;
                      windowReturnClass1.AddCommand(5, 14);
                      this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    case 3:
                      this.TimerUsed = false;
                      new Form3((Form) this.formref).Initialize(this.game.Data, 82, this.game.EditObj.OrderUnit, tGame: this.game);
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    case 11:
                      this.TimerUsed = false;
                      this.game.EditObj.PopupValue = 12;
                      windowReturnClass1.AddCommand(5, 14);
                      this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    case 14:
                    case 15:
                      this.TimerUsed = false;
                      this.game.EditObj.PopupValue = 11;
                      windowReturnClass1.AddCommand(5, 14);
                      this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    case 18:
                    case 49:
                      this.TimerUsed = false;
                      new Form3((Form) this.formref).Initialize(this.game.Data, 60, this.game.EditObj.UnitSelected, tGame: this.game);
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                  }
                }
                else if (num1 == this.KillId)
                {
                  if (this.game.EditObj.OrderType == 3)
                  {
                    if (this.game.ProcessingObj.SetUnitHq(this.game.EditObj.OrderUnit, -1).OK)
                    {
                      this.game.EditObj.OrderType = 0;
                      this.game.EditObj.TempCoordList = new CoordList();
                      this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                      this.game.EditObj.TempCoordList.AddCoord(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap);
                      windowReturnClass1.AddCommand(4, 12);
                      windowReturnClass1.AddCommand(4, 67);
                      windowReturnClass1.AddCommand(4, 69);
                      windowReturnClass1.AddCommand(4, 68);
                      windowReturnClass1.AddCommand(4, 9);
                      this.game.SelectX = this.game.EditObj.OrderX;
                      this.game.SelectY = this.game.EditObj.OrderY;
                      this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                    }
                    this.dostuff();
                    windowReturnClass1.SetFlag(true);
                  }
                }
                else if (num1 == this.NoneId)
                {
                  this.game.EditObj.TempCoordList = new CoordList();
                  this.lastorderx = -1;
                  this.lastordery = -1;
                  int counter = this.game.EditObj.TempUnitList.counter;
                  for (int index3 = 0; index3 <= counter; ++index3)
                    this.game.EditObj.TempCoordList.AddCoord(this.game.Data.UnitObj[this.game.EditObj.TempUnitList.unr[index3]].X, this.game.Data.UnitObj[this.game.EditObj.TempUnitList.unr[index3]].Y, this.game.Data.UnitObj[this.game.EditObj.TempUnitList.unr[index3]].Map);
                  this.game.EditObj.TempUnitList = new UnitList();
                  windowReturnClass1.AddCommand(4, 12);
                  windowReturnClass1.AddCommand(4, 67);
                  windowReturnClass1.AddCommand(4, 9);
                  windowReturnClass1.AddCommand(4, 69);
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                }
                else if (num1 == this.AllId)
                {
                  Coordinate target;
                  target.x = this.game.EditObj.OrderX;
                  target.y = this.game.EditObj.OrderY;
                  this.lastorderx = target.x;
                  this.lastordery = target.y;
                  target.onmap = true;
                  this.game.EditObj.TempCoordList = new CoordList();
                  this.game.EditObj.TempUnitList = new UnitList();
                  if (this.game.EditObj.OrderType == 11 | this.game.EditObj.OrderType == 13 | this.game.EditObj.OrderType == 14 | this.game.EditObj.OrderType == 15)
                  {
                    int mapCounter = this.game.Data.MapCounter;
                    for (int index4 = 0; index4 <= mapCounter; ++index4)
                    {
                      int mapWidth = this.game.Data.MapObj[index4].MapWidth;
                      for (int index5 = 0; index5 <= mapWidth; ++index5)
                      {
                        int mapHeight = this.game.Data.MapObj[index4].MapHeight;
                        for (int index6 = 0; index6 <= mapHeight; ++index6)
                        {
                          Coordinate coordinate;
                          coordinate.x = index5;
                          coordinate.y = index6;
                          coordinate.map = index4;
                          coordinate.onmap = true;
                          if (this.game.Data.MapObj[coordinate.map].HexObj[coordinate.x, coordinate.y].UnitCounter > -1 && this.game.Data.UnitObj[this.game.Data.MapObj[coordinate.map].HexObj[coordinate.x, coordinate.y].UnitList[0]].Regime == this.game.Data.Turn)
                          {
                            int unitCounter = this.game.Data.MapObj[coordinate.map].HexObj[coordinate.x, coordinate.y].UnitCounter;
                            for (int index7 = 0; index7 <= unitCounter; ++index7)
                            {
                              int unit = this.game.Data.MapObj[coordinate.map].HexObj[coordinate.x, coordinate.y].UnitList[index7];
                              if (this.game.EditObj.TempCoordList.counter < 15)
                              {
                                if (this.game.EditObj.OrderType == 11)
                                {
                                  if (this.game.HandyFunctionsObj.CanDoArtAttack(unit, target, false))
                                  {
                                    if ((double) this.game.Data.RuleVar[899] < 1.0)
                                    {
                                      this.game.EditObj.TempCoordList.AddCoord(coordinate.x, coordinate.y, coordinate.map);
                                      this.game.EditObj.TempUnitList.add(unit);
                                    }
                                    else if ((double) this.game.HandyFunctionsObj.GetArtPercent(unit, true) >= (double) this.game.Data.RuleVar[899])
                                    {
                                      this.game.EditObj.TempCoordList.AddCoord(coordinate.x, coordinate.y, coordinate.map);
                                      this.game.EditObj.TempUnitList.add(unit);
                                    }
                                  }
                                  else if ((double) this.game.Data.RuleVar[419] > 0.0 && this.game.HandyFunctionsObj.CanDoDirectAttack(unit, target, false))
                                  {
                                    if ((double) this.game.Data.RuleVar[899] < 1.0)
                                    {
                                      this.game.EditObj.TempCoordList.AddCoord(coordinate.x, coordinate.y, coordinate.map);
                                      this.game.EditObj.TempUnitList.add(unit);
                                    }
                                    else if ((double) this.game.HandyFunctionsObj.GetDirectPercent(unit, true) >= (double) this.game.Data.RuleVar[899])
                                    {
                                      this.game.EditObj.TempCoordList.AddCoord(coordinate.x, coordinate.y, coordinate.map);
                                      this.game.EditObj.TempUnitList.add(unit);
                                    }
                                  }
                                }
                                else if (this.game.EditObj.OrderType == 13)
                                {
                                  if (this.game.HandyFunctionsObj.CanDoSeaArtAttack(unit, target))
                                  {
                                    this.game.EditObj.TempCoordList.AddCoord(coordinate.x, coordinate.y, coordinate.map);
                                    this.game.EditObj.TempUnitList.add(unit);
                                  }
                                }
                                else if (this.game.HandyFunctionsObj.CanDoAirStrike(unit, target))
                                {
                                  this.game.EditObj.TempCoordList.AddCoord(coordinate.x, coordinate.y, coordinate.map);
                                  this.game.EditObj.TempUnitList.add(unit);
                                }
                              }
                            }
                          }
                        }
                      }
                    }
                  }
                  else
                  {
                    int num2 = this.game.HandyFunctionsObj.HexNeighbourCount(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap);
                    for (int tfacing = 1; tfacing <= num2; ++tfacing)
                    {
                      Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap, tfacing);
                      if (coordinate.onmap && this.game.Data.MapObj[coordinate.map].HexObj[coordinate.x, coordinate.y].UnitCounter > -1 && this.game.Data.UnitObj[this.game.Data.MapObj[coordinate.map].HexObj[coordinate.x, coordinate.y].UnitList[0]].Regime == this.game.Data.Turn)
                      {
                        int unitCounter = this.game.Data.MapObj[coordinate.map].HexObj[coordinate.x, coordinate.y].UnitCounter;
                        for (int index8 = 0; index8 <= unitCounter; ++index8)
                        {
                          if (this.game.EditObj.TempCoordList.counter < 15)
                          {
                            int unit = this.game.Data.MapObj[coordinate.map].HexObj[coordinate.x, coordinate.y].UnitList[index8];
                            if (this.game.EditObj.OrderType == 2)
                            {
                              if (this.game.HandyFunctionsObj.CanDoLandAttack(unit, target))
                              {
                                this.game.EditObj.TempCoordList.AddCoord(coordinate.x, coordinate.y, coordinate.map);
                                this.game.EditObj.TempUnitList.add(unit);
                              }
                            }
                            else if (this.game.HandyFunctionsObj.CanDoSeaAttack(unit, target))
                            {
                              this.game.EditObj.TempCoordList.AddCoord(coordinate.x, coordinate.y, coordinate.map);
                              this.game.EditObj.TempUnitList.add(unit);
                            }
                          }
                        }
                      }
                    }
                  }
                  windowReturnClass1.AddCommand(4, 12);
                  windowReturnClass1.AddCommand(4, 9);
                  windowReturnClass1.AddCommand(4, 69);
                  windowReturnClass1.AddCommand(4, 67);
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                }
                else if (num1 == this.OkId)
                {
                  switch (this.game.EditObj.OrderType)
                  {
                    case 2:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                      if (this.game.EditObj.TempUnitList.CheckIfPresent(this.game.EditObj.UnitSelected))
                        this.game.EditObj.TempUnitList.remove(this.game.EditObj.UnitSelected);
                      else
                        this.game.EditObj.TempUnitList.add(this.game.EditObj.UnitSelected);
                      this.game.EditObj.TempCoordList = new CoordList();
                      this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                      windowReturnClass1.AddCommand(4, 12);
                      windowReturnClass1.AddCommand(4, 67);
                      windowReturnClass1.AddCommand(4, 9);
                      windowReturnClass1.AddCommand(4, 69);
                      this.dostuff();
                      windowReturnClass1.SetFlag(true);
                      break;
                    case 3:
                      int historical = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical;
                      if (historical > -1 && this.game.Data.HistoricalUnitObj[historical].HandCardCounter > -1 & (double) this.game.Data.RuleVar[897] == 0.0 && Interaction.MsgBox((object) "This action will cause the HQ to lose all handcards. Are you sure?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.No)
                      {
                        this.game.EditObj.OrderType = 0;
                        this.game.EditObj.TempCoordList = new CoordList();
                        this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                        this.game.EditObj.TempCoordList.AddCoord(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap);
                        windowReturnClass1.AddCommand(4, 12);
                        windowReturnClass1.AddCommand(4, 67);
                        windowReturnClass1.AddCommand(4, 69);
                        windowReturnClass1.AddCommand(4, 68);
                        windowReturnClass1.AddCommand(4, 9);
                        this.game.SelectX = this.game.EditObj.OrderX;
                        this.game.SelectY = this.game.EditObj.OrderY;
                        this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                        this.dostuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      OrderResult orderResult1 = this.game.ProcessingObj.SetUnitHq(this.game.EditObj.OrderUnit, this.game.EditObj.UnitSelected);
                      if (this.game.EditObj.SoundOn)
                        SoundMod.PlayAWave(this.game.AppPath + "sound/radio.wav", ref this.game.EditObj);
                      if (orderResult1.OK)
                      {
                        this.game.EditObj.OrderType = 0;
                        this.game.EditObj.TempCoordList = new CoordList();
                        windowReturnClass1.AddCommand(4, 12);
                        windowReturnClass1.AddCommand(4, 69);
                        windowReturnClass1.AddCommand(4, 67);
                        windowReturnClass1.AddCommand(4, 9);
                        this.game.SelectX = this.game.EditObj.OrderX;
                        this.game.SelectY = this.game.EditObj.OrderY;
                        this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                      }
                      this.dostuff();
                      windowReturnClass1.SetFlag(true);
                      break;
                    case 18:
                    case 49:
                      if (this.game.EditObj.OrderTarget == -1)
                      {
                        this.game.EditObj.OrderTarget = this.game.EditObj.UnitSelected;
                        this.game.EditObj.TempCoordList = new CoordList();
                        this.game.EditObj.OrderX = this.game.SelectX;
                        this.game.EditObj.OrderY = this.game.SelectY;
                        windowReturnClass1.AddCommand(4, 12);
                        windowReturnClass1.AddCommand(1, 69);
                        windowReturnClass1.AddCommand(2, 35);
                        windowReturnClass1.AddCommand(4, 67);
                        windowReturnClass1.AddCommand(4, 9);
                      }
                      this.dostuff();
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    case 19:
                    case 42:
                      if (this.game.EditObj.OrderTarget == -1)
                      {
                        this.game.EditObj.OrderTarget = this.game.EditObj.UnitSelected;
                        if (this.game.HandyFunctionsObj.HasUnitOnlyParaLandSF(this.game.EditObj.OrderTarget))
                        {
                          if (Interaction.MsgBox((object) "Do you want to paradrop?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                          {
                            this.game.EditObj.OrderType = 19;
                            this.game.EditObj.TempCoordList = this.game.HandyFunctionsObj.MakeMovePrediction(this.game.EditObj.OrderUnit, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Map, false, PredictAirOnly: true, ClearSea: true, attack: true, isparadrop: true);
                          }
                          else
                          {
                            this.game.EditObj.OrderType = 42;
                            this.game.EditObj.TempCoordList = this.game.HandyFunctionsObj.MakeMovePrediction(this.game.EditObj.OrderUnit, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Map, PredictAirOnly: true, ClearSea: true, ismove: true);
                          }
                        }
                        else
                        {
                          this.game.EditObj.OrderType = 42;
                          this.game.EditObj.TempCoordList = this.game.HandyFunctionsObj.MakeMovePrediction(this.game.EditObj.OrderUnit, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Map, PredictAirOnly: true, ClearSea: true, ismove: true);
                        }
                        windowReturnClass1.AddCommand(4, 12);
                        windowReturnClass1.AddCommand(4, 68);
                        windowReturnClass1.AddCommand(4, 69);
                        windowReturnClass1.AddCommand(4, 9);
                        windowReturnClass1.AddCommand(4, 67);
                        this.dostuff();
                        windowReturnClass1.SetFlag(true);
                        break;
                      }
                      int num3 = 0;
                      if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime == this.game.Data.Turn)
                      {
                        if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter > 14)
                        {
                          num3 = 1;
                          int num4 = (int) Interaction.MsgBox((object) "Already 16 units in that hex.");
                          this.game.EditObj.OrderType = 0;
                          windowReturnClass1.AddCommand(4, 12);
                          windowReturnClass1.AddCommand(4, 68);
                          windowReturnClass1.AddCommand(4, 69);
                          windowReturnClass1.AddCommand(4, 9);
                          windowReturnClass1.AddCommand(4, 67);
                          this.game.SelectX = this.game.EditObj.OrderX;
                          this.game.SelectY = this.game.EditObj.OrderY;
                          this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                          this.dostuff();
                          windowReturnClass1.SetFlag(true);
                        }
                        this.game.HandyFunctionsObj.IsHexAirfield(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                      }
                      if (num3 == 0)
                      {
                        this.game.EditObj.TargetX = this.game.SelectX;
                        this.game.EditObj.TargetY = this.game.SelectY;
                        this.game.TempCombat = new CombatClass(this.game);
                        Coordinate Target = new Coordinate();
                        Target.x = this.game.EditObj.TargetX;
                        Target.y = this.game.EditObj.TargetY;
                        this.game.SelectX = this.game.EditObj.TargetX;
                        this.game.SelectY = this.game.EditObj.TargetY;
                        this.game.EditObj.TempUnitList = new UnitList();
                        this.game.EditObj.TempUnitList.add(this.game.EditObj.OrderUnit);
                        if (this.game.EditObj.OrderType != 42)
                          this.game.EditObj.TempUnitList.add(this.game.EditObj.OrderTarget, 1);
                        if (this.game.TempCombat.Init(Target, 1, this.game.EditObj.TempUnitList, this.game.EditObj.OrderType).OK)
                        {
                          this.game.EditObj.PopupValue = 7;
                          windowReturnClass1.AddCommand(5, 14);
                          this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                          windowReturnClass1.SetFlag(true);
                          return windowReturnClass1;
                        }
                        windowReturnClass1.SetFlag(true);
                        break;
                      }
                      break;
                    case 20:
                      OrderResult orderResult2 = this.game.ProcessingObj.LoadUnit(this.game.EditObj.UnitSelected, this.game.EditObj.OrderUnit);
                      if (this.game.EditObj.SoundOn)
                        SoundMod.PlayAWave(this.game.AppPath + "sound/load.wav", ref this.game.EditObj);
                      if (orderResult2.OK)
                      {
                        this.game.EditObj.OrderType = 0;
                        this.game.EditObj.TempCoordList = new CoordList();
                        windowReturnClass1.AddCommand(4, 12);
                        windowReturnClass1.AddCommand(4, 68);
                        windowReturnClass1.AddCommand(4, 69);
                        windowReturnClass1.AddCommand(4, 9);
                        if (this.game.SelectX == this.game.EditObj.OrderX & this.game.SelectY == this.game.EditObj.OrderY)
                        {
                          int num5 = 0;
                          while (this.game.EditObj.OrderUnit != this.game.HandyFunctionsObj.ClickOnHexGivesUnit(this.game.SelectX, this.game.SelectY, 0, false, 1))
                          {
                            ++num5;
                            if (num5 > 99)
                              break;
                          }
                        }
                        this.game.SelectX = this.game.EditObj.OrderX;
                        this.game.SelectY = this.game.EditObj.OrderY;
                        if (this.game.EditObj.MapSelected != this.game.EditObj.OrderMap)
                        {
                          this.game.EditObj.MapSelected = this.game.EditObj.OrderMap;
                          this.game.EditObj.TempCoordList = new CoordList();
                        }
                        else
                          this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                        this.game.EditObj.TempCoordList = new CoordList();
                        this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                      }
                      this.dostuff();
                      windowReturnClass1.SetFlag(true);
                      break;
                    case 21:
                      OrderResult orderResult3 = this.game.ProcessingObj.unLoadUnit(this.game.EditObj.OrderTarget, this.game.EditObj.OrderUnit, this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                      if (this.game.EditObj.SoundOn)
                        SoundMod.PlayAWave(this.game.AppPath + "sound/unload.wav", ref this.game.EditObj);
                      if (orderResult3.OK)
                      {
                        if (!this.game.HandyFunctionsObj.VisibleEnemyUnitsInHex(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, this.game.Data.Turn, true) & this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].CardUponConquest == -1)
                        {
                          this.game.EditObj.OrderType = 0;
                          windowReturnClass1.AddCommand(4, 12);
                          windowReturnClass1.AddCommand(4, 68);
                          windowReturnClass1.AddCommand(4, 69);
                          windowReturnClass1.AddCommand(4, 9);
                          this.game.EditObj.TempCoordList = new CoordList();
                          this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                          this.game.SelectX = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X;
                          this.game.SelectY = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y;
                          this.game.EditObj.OrderType = 0;
                          this.game.EditObj.TempCoordList = new CoordList();
                          this.dostuff();
                          windowReturnClass1.SetFlag(true);
                          break;
                        }
                        this.game.EditObj.TargetX = this.game.SelectX;
                        this.game.EditObj.TargetY = this.game.SelectY;
                        this.game.EditObj.TargetMap = this.game.EditObj.MapSelected;
                        this.game.TempCombat = new CombatClass(this.game);
                        Coordinate Target = new Coordinate();
                        Target.x = this.game.EditObj.TargetX;
                        Target.y = this.game.EditObj.TargetY;
                        Target.map = this.game.EditObj.TargetMap;
                        this.game.EditObj.TempUnitList = new UnitList();
                        this.game.EditObj.TempUnitList.add(this.game.EditObj.OrderTarget);
                        if (this.game.TempCombat.Init(Target, 1, this.game.EditObj.TempUnitList, this.game.EditObj.OrderType).OK)
                        {
                          this.game.EditObj.BattleTimerActive = true;
                          this.game.EditObj.BattleTimer = DateTime.Now + new TimeSpan(0, 0, 0, 0, 1000);
                        }
                        windowReturnClass1.SetFlag(true);
                        break;
                      }
                      this.dostuff();
                      windowReturnClass1.SetFlag(true);
                      break;
                    case 33:
                      this.game.TempCombat = new CombatClass(this.game);
                      Coordinate Target1 = new Coordinate();
                      Target1.x = this.game.SelectX;
                      Target1.y = this.game.SelectY;
                      this.game.EditObj.TempUnitList = new UnitList();
                      this.game.EditObj.TempUnitList.add(this.game.EditObj.OrderUnit);
                      if (this.game.TempCombat.Init(Target1, 1, this.game.EditObj.TempUnitList, this.game.EditObj.OrderType).OK)
                      {
                        if ((double) this.game.Data.RuleVar[839] == 1.0)
                        {
                          this.game.EditObj.PopupValue = 7;
                          windowReturnClass1.AddCommand(5, 14);
                          this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                          windowReturnClass1.SetFlag(true);
                          return windowReturnClass1;
                        }
                        windowReturnClass1.AddCommand(3, 5);
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      this.dostuff();
                      windowReturnClass1.SetFlag(true);
                      break;
                    case 35:
                      if (this.game.ProcessingObj.BlowBridge(this.game.EditObj.OrderUnit, this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap, this.game.HandyFunctionsObj.HexFacing(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap, this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected) - 1).OK)
                      {
                        SoundMod.PlayAWave(this.game.AppPath + "sound/blow.wav", ref this.game.EditObj);
                        this.game.EditObj.OrderType = 0;
                        DrawMod.TGame.EditObj.PopupValue = 5;
                        windowReturnClass1.AddCommand(5, 14);
                        this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                        this.game.SelectX = this.game.EditObj.OrderX;
                        this.game.SelectY = this.game.EditObj.OrderY;
                        this.game.EditObj.MapSelected = this.game.EditObj.OrderMap;
                        this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.OrderMap);
                        this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                      }
                      else
                      {
                        this.game.EditObj.OrderType = 0;
                        DrawMod.TGame.EditObj.PopupValue = 5;
                        windowReturnClass1.AddCommand(5, 14);
                        this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                        this.game.SelectX = this.game.EditObj.OrderX;
                        this.game.SelectY = this.game.EditObj.OrderY;
                        this.game.EditObj.MapSelected = this.game.EditObj.OrderMap;
                        this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                        this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                      }
                      windowReturnClass1.SetFlag(true);
                      break;
                    case 36:
                      OrderResult orderResult4 = this.game.ProcessingObj.BuildInfra(this.game.EditObj.OrderUnit, this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap, this.game.HandyFunctionsObj.HexFacing(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap, this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected) - 1);
                      if (this.game.EditObj.SoundOn)
                        SoundMod.PlayAWave(this.game.AppPath + "sound/building.wav", ref this.game.EditObj);
                      if (orderResult4.OK)
                      {
                        this.game.EditObj.OrderType = 0;
                        this.game.EditObj.TempCoordList = new CoordList();
                        this.game.ProcessingObj.LocationProductionPrognosis();
                        DrawMod.TGame.EditObj.PopupValue = 5;
                        windowReturnClass1.AddCommand(5, 14);
                        this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                        this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                      }
                      this.dostuff();
                      windowReturnClass1.SetFlag(true);
                      break;
                    case 40:
                      this.game.EditObj.TempUnitList = new UnitList();
                      this.game.EditObj.TempUnitList.add(this.game.EditObj.OrderUnit);
                      Coordinate Target2;
                      Target2.x = this.game.SelectX;
                      Target2.y = this.game.SelectY;
                      this.game.EditObj.AirSupplyPts = Math.Min(this.LastAirSupplyMax, this.LastAirSupplyNeed);
                      this.game.EditObj.AirSupplyHq = this.game.Data.UnitObj[this.game.EditObj.OrderUnit].HQ;
                      this.game.EditObj.TargetX = this.game.SelectX;
                      this.game.EditObj.TargetY = this.game.SelectY;
                      this.game.EditObj.AirSupplyCarry = this.game.HandyFunctionsObj.GetCarryCapPts(this.game.EditObj.OrderUnit, 2);
                      Target2.onmap = true;
                      this.game.TempCombat = new CombatClass(this.game);
                      if (!this.game.TempCombat.Init(Target2, 1, this.game.EditObj.TempUnitList, this.game.EditObj.OrderType).OK)
                        return windowReturnClass1;
                      this.game.EditObj.PopupValue = 7;
                      windowReturnClass1.AddCommand(5, 14);
                      this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                  }
                }
                else if (num1 == this.ChangeModelId)
                {
                  this.game.EditObj.OrderType = 46;
                  this.game.EditObj.OrderUnit = this.game.EditObj.UnitSelected;
                  this.game.EditObj.OrderX = this.game.SelectX;
                  this.game.EditObj.OrderY = this.game.SelectY;
                  this.game.EditObj.OrderMap = this.game.EditObj.MapSelected;
                  windowReturnClass1.AddCommand(1, 5);
                  windowReturnClass1.AddCommand(2, 90);
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                }
                else if (num1 == this.NewUnitButtonId)
                {
                  this.game.EditObj.OrderType = 7;
                  this.game.EditObj.OrderUnit = this.game.EditObj.UnitSelected;
                  this.game.EditObj.OrderX = this.game.SelectX;
                  this.game.EditObj.OrderY = this.game.SelectY;
                  this.game.EditObj.OrderMap = this.game.EditObj.MapSelected;
                  windowReturnClass1.AddCommand(1, 5);
                  windowReturnClass1.AddCommand(2, 88);
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                }
                else if (num1 == this.NewUnitButton2Id)
                {
                  this.game.EditObj.OrderType = 44;
                  this.game.EditObj.OrderUnit = this.game.EditObj.UnitSelected;
                  this.game.EditObj.OrderX = this.game.SelectX;
                  this.game.EditObj.OrderY = this.game.SelectY;
                  this.game.EditObj.OrderMap = this.game.EditObj.MapSelected;
                  windowReturnClass1.AddCommand(1, 5);
                  windowReturnClass1.AddCommand(2, 89);
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                }
                else if (num1 == this.UnLoadButtonID)
                {
                  this.game.EditObj.OrderTarget = -1;
                  this.game.EditObj.OrderType = 21;
                  this.game.EditObj.OrderUnit = this.game.EditObj.UnitSelected;
                  this.game.EditObj.OrderTarget = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].PassengerList[this.game.EditObj.SFSelected - (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SFCount + 1)];
                  this.game.EditObj.OrderX = this.game.SelectX;
                  this.game.EditObj.OrderY = this.game.SelectY;
                  this.game.EditObj.OrderMap = this.game.EditObj.MapSelected;
                  this.game.EditObj.TempCoordList = new CoordList();
                  this.game.EditObj.TempValue = new MapMatrix2[this.game.Data.MapCounter + 1];
                  int mapCounter1 = this.game.Data.MapCounter;
                  for (int index9 = 0; index9 <= mapCounter1; ++index9)
                    this.game.EditObj.TempValue[index9] = new MapMatrix2(this.game.Data.MapObj[index9].MapWidth, this.game.Data.MapObj[index9].MapHeight);
                  int mapCounter2 = this.game.Data.MapCounter;
                  for (int index10 = 0; index10 <= mapCounter2; ++index10)
                  {
                    int mapWidth = this.game.Data.MapObj[index10].MapWidth;
                    for (int index11 = 0; index11 <= mapWidth; ++index11)
                    {
                      int mapHeight = this.game.Data.MapObj[index10].MapHeight;
                      for (int index12 = 0; index12 <= mapHeight; ++index12)
                        this.game.EditObj.TempValue[index10].Value[index11, index12] = 9999;
                    }
                  }
                  int num6 = this.game.HandyFunctionsObj.HexNeighbourCount(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                  for (int tfacing = 1; tfacing <= num6; ++tfacing)
                  {
                    Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, tfacing);
                    if (coordinate.onmap && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[coordinate.map].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                    {
                      if (this.game.HandyFunctionsObj.Distance(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap, coordinate.x, coordinate.y, coordinate.map) == 0)
                      {
                        if (this.game.Data.MapObj[coordinate.map].HexObj[coordinate.x, coordinate.y].UnitCounter < 15)
                        {
                          this.game.EditObj.TempCoordList.AddCoord(coordinate.x, coordinate.y, coordinate.map);
                          this.game.EditObj.TempValue[coordinate.map].Value[coordinate.x, coordinate.y] = 0;
                        }
                      }
                      else if (this.game.HandyFunctionsObj.Distance(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap, coordinate.x, coordinate.y, coordinate.map) <= 1 && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[coordinate.map].HexObj[coordinate.x, coordinate.y].LandscapeType].CanAmph && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.OrderX, this.game.EditObj.OrderY].LandscapeType].IsSea)
                      {
                        if (this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.MapObj[coordinate.map].HexObj[coordinate.x, coordinate.y].Regime))
                        {
                          this.game.EditObj.TempCoordList.AddCoord(coordinate.x, coordinate.y, coordinate.map);
                          this.game.EditObj.TempValue[coordinate.map].Value[coordinate.x, coordinate.y] = 0;
                        }
                        else if (this.game.Data.MapObj[coordinate.map].HexObj[coordinate.x, coordinate.y].Regime == this.game.Data.Turn && this.game.Data.MapObj[coordinate.map].HexObj[coordinate.x, coordinate.y].UnitCounter < 15)
                        {
                          this.game.EditObj.TempCoordList.AddCoord(coordinate.x, coordinate.y, coordinate.map);
                          this.game.EditObj.TempValue[coordinate.map].Value[coordinate.x, coordinate.y] = 0;
                        }
                      }
                    }
                  }
                  Coordinate coordinate1 = this.game.HandyFunctionsObj.SetTempCanSee(this.game.EditObj.TempCoordList);
                  if (coordinate1.onmap)
                  {
                    this.game.EditObj.MapSelected = coordinate1.map;
                    this.game.SelectX = coordinate1.x;
                    this.game.SelectY = coordinate1.y;
                    this.game.EditObj.TempCoordList = new CoordList();
                    this.game.EditObj.UnitSelected = this.game.HandyFunctionsObj.ClickOnHexGivesUnit(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, true, 0);
                    windowReturnClass1.AddCommand(4, 18);
                  }
                  windowReturnClass1.AddCommand(4, 12);
                  windowReturnClass1.AddCommand(4, 29);
                  windowReturnClass1.AddCommand(4, 20);
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                }
                else if (num1 == this.LoadButtonId)
                {
                  this.game.EditObj.OrderTarget = -1;
                  this.game.EditObj.OrderType = 20;
                  this.game.EditObj.OrderUnit = this.game.EditObj.UnitSelected;
                  this.game.EditObj.OrderX = this.game.SelectX;
                  this.game.EditObj.OrderY = this.game.SelectY;
                  this.game.EditObj.OrderMap = this.game.EditObj.MapSelected;
                  this.game.EditObj.TempCoordList = new CoordList();
                  this.game.EditObj.TempValue = new MapMatrix2[this.game.Data.MapCounter + 1];
                  int mapCounter3 = this.game.Data.MapCounter;
                  for (int index13 = 0; index13 <= mapCounter3; ++index13)
                    this.game.EditObj.TempValue[index13] = new MapMatrix2(this.game.Data.MapObj[index13].MapWidth, this.game.Data.MapObj[index13].MapHeight);
                  int mapCounter4 = this.game.Data.MapCounter;
                  for (int index14 = 0; index14 <= mapCounter4; ++index14)
                  {
                    int mapWidth = this.game.Data.MapObj[index14].MapWidth;
                    for (int index15 = 0; index15 <= mapWidth; ++index15)
                    {
                      int mapHeight = this.game.Data.MapObj[index14].MapHeight;
                      for (int index16 = 0; index16 <= mapHeight; ++index16)
                        this.game.EditObj.TempValue[index14].Value[index15, index16] = 9999;
                    }
                  }
                  int num7 = this.game.HandyFunctionsObj.HexNeighbourCount(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                  for (int tfacing = 1; tfacing <= num7; ++tfacing)
                  {
                    Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, tfacing);
                    if (coordinate.onmap && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[coordinate.map].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                    {
                      if (this.game.HandyFunctionsObj.Distance(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap, coordinate.x, coordinate.y, coordinate.map) == 0)
                      {
                        if (this.game.Data.MapObj[coordinate.map].HexObj[coordinate.x, coordinate.y].UnitCounter < 15)
                        {
                          this.game.EditObj.TempCoordList.AddCoord(coordinate.x, coordinate.y, coordinate.map);
                          this.game.EditObj.TempValue[coordinate.map].Value[coordinate.x, coordinate.y] = 0;
                        }
                      }
                      else if (this.game.HandyFunctionsObj.Distance(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap, coordinate.x, coordinate.y, coordinate.map) <= 1 && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[coordinate.map].HexObj[coordinate.x, coordinate.y].LandscapeType].CanAmph && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.OrderX, this.game.EditObj.OrderY].LandscapeType].IsSea)
                      {
                        if (this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.MapObj[coordinate.map].HexObj[coordinate.x, coordinate.y].Regime))
                        {
                          this.game.EditObj.TempCoordList.AddCoord(coordinate.x, coordinate.y, coordinate.map);
                          this.game.EditObj.TempValue[coordinate.map].Value[coordinate.x, coordinate.y] = 0;
                        }
                        else if (this.game.Data.MapObj[coordinate.map].HexObj[coordinate.x, coordinate.y].Regime == this.game.Data.Turn && this.game.Data.MapObj[coordinate.map].HexObj[coordinate.x, coordinate.y].UnitCounter < 15)
                        {
                          this.game.EditObj.TempCoordList.AddCoord(coordinate.x, coordinate.y, coordinate.map);
                          this.game.EditObj.TempValue[coordinate.map].Value[coordinate.x, coordinate.y] = 0;
                        }
                      }
                    }
                  }
                  Coordinate coordinate2 = this.game.HandyFunctionsObj.SetTempCanSee(this.game.EditObj.TempCoordList);
                  if (coordinate2.onmap)
                  {
                    this.game.EditObj.MapSelected = coordinate2.map;
                    this.game.SelectX = coordinate2.x;
                    this.game.SelectY = coordinate2.y;
                    this.game.EditObj.TempCoordList = new CoordList();
                    this.game.EditObj.UnitSelected = this.game.HandyFunctionsObj.ClickOnHexGivesUnit(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, true, 0);
                  }
                  this.game.EditObj.TempCoordList = new CoordList();
                  windowReturnClass1.AddCommand(4, 12);
                  windowReturnClass1.AddCommand(4, 68);
                  windowReturnClass1.AddCommand(4, 69);
                  windowReturnClass1.SetFlag(true);
                }
                else if (num1 == this.AirSupplyButtonId)
                {
                  this.game.EditObj.OrderTarget = -1;
                  this.game.EditObj.TargetX = -1;
                  this.game.EditObj.TargetY = -1;
                  this.game.EditObj.OrderType = 40;
                  this.game.EditObj.OrderUnit = this.game.EditObj.UnitSelected;
                  this.game.EditObj.OrderX = this.game.SelectX;
                  this.game.EditObj.OrderY = this.game.SelectY;
                  this.game.EditObj.OrderMap = this.game.EditObj.MapSelected;
                  this.game.EditObj.TempCoordList = this.game.HandyFunctionsObj.MakeMovePrediction(this.game.EditObj.OrderUnit, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Map, false, PredictAirOnly: true, attack: true);
                  int mapWidth = this.game.Data.MapObj[0].MapWidth;
                  for (int index17 = 0; index17 <= mapWidth; ++index17)
                  {
                    int mapHeight = this.game.Data.MapObj[0].MapHeight;
                    for (int index18 = 0; index18 <= mapHeight; ++index18)
                      this.game.EditObj.TempValue2[0].Value[index17, index18] = this.game.EditObj.TempValue[0].Value[index17, index18];
                  }
                  this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                  windowReturnClass1.AddCommand(4, 12);
                  windowReturnClass1.AddCommand(4, 68);
                  windowReturnClass1.AddCommand(4, 69);
                  windowReturnClass1.AddCommand(4, 9);
                  windowReturnClass1.AddCommand(4, 67);
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                }
                else if (num1 == this.seaAttackButtonId)
                {
                  this.game.EditObj.OrderTarget = -1;
                  this.game.EditObj.TempUnitList = new UnitList();
                  this.game.EditObj.OrderType = 12;
                  this.game.EditObj.OrderX = this.game.SelectX;
                  this.game.EditObj.OrderY = this.game.SelectY;
                  this.game.EditObj.OrderMap = this.game.EditObj.MapSelected;
                  this.game.EditObj.TargetX = this.game.SelectX;
                  this.game.EditObj.TargetY = this.game.SelectY;
                  this.game.EditObj.TargetMap = this.game.EditObj.MapSelected;
                  this.game.EditObj.TempCoordList = new CoordList();
                  this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                  this.game.EditObj.SetViewMode = 2;
                  windowReturnClass1.AddCommand(4, 12);
                  windowReturnClass1.AddCommand(4, 69);
                  windowReturnClass1.AddCommand(4, 67);
                  windowReturnClass1.AddCommand(4, 9);
                  windowReturnClass1.AddCommand(4, 68);
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                }
                else if (num1 == this.SeaArtAttackButtonId)
                {
                  this.game.EditObj.OrderTarget = -1;
                  this.game.EditObj.TempUnitList = new UnitList();
                  this.game.EditObj.OrderType = 13;
                  this.game.EditObj.OrderX = this.game.SelectX;
                  this.game.EditObj.OrderY = this.game.SelectY;
                  this.game.EditObj.OrderMap = this.game.EditObj.MapSelected;
                  this.game.EditObj.TargetX = this.game.SelectX;
                  this.game.EditObj.TargetY = this.game.SelectY;
                  this.game.EditObj.TargetMap = this.game.EditObj.MapSelected;
                  this.game.EditObj.TempCoordList = new CoordList();
                  this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                  this.game.EditObj.SetViewMode = 2;
                  windowReturnClass1.AddCommand(4, 12);
                  windowReturnClass1.AddCommand(4, 69);
                  windowReturnClass1.AddCommand(4, 67);
                  windowReturnClass1.AddCommand(4, 9);
                  windowReturnClass1.AddCommand(4, 68);
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                }
                else if (num1 == this.ParadropButtonId)
                {
                  this.game.EditObj.OrderTarget = -1;
                  this.game.EditObj.TargetX = -1;
                  this.game.EditObj.TargetY = -1;
                  this.game.EditObj.OrderType = 19;
                  this.game.EditObj.OrderUnit = this.game.EditObj.UnitSelected;
                  this.game.EditObj.OrderX = this.game.SelectX;
                  this.game.EditObj.OrderY = this.game.SelectY;
                  this.game.EditObj.OrderMap = this.game.EditObj.MapSelected;
                  this.game.EditObj.TempCoordList = new CoordList();
                  this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                  windowReturnClass1.AddCommand(4, 12);
                  windowReturnClass1.AddCommand(4, 20);
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                }
                else
                {
                  if (num1 == this.NextButtonId)
                  {
                    if (this.game.Data.Round == 0)
                    {
                      WindowReturnClass windowReturnClass2;
                      return windowReturnClass2;
                    }
                    int messCounter1 = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
                    int num8;
                    for (int index19 = 0; index19 <= messCounter1; ++index19)
                    {
                      if (Strings.InStr(this.game.Data.RegimeObj[this.game.Data.Turn].MessString[index19], "YOUR MESSAGE TO") > 0)
                        ++num8;
                    }
                    if (num8 == 0 & !this.game.EditObj.NextTurnButtonPress & this.game.Data.PbemGameID > 0 & this.game.Data.Round == 1)
                    {
                      this.game.EditObj.NextTurnButtonPress = true;
                      this.game.EditObj.OrderType = 0;
                      this.game.EditObj.QuestionText = "It is a good custom to send a friendly in-game text message to your opponent. You can do this with the 'message' button in the strategic map tab.";
                      this.game.EditObj.AnswerCount = 2;
                      this.game.EditObj.AnswerText[1] = "End turn";
                      this.game.EditObj.AnswerText[2] = "Good idea";
                      this.game.EditObj.AnswerTextMouseOver[1] = "End your turn.";
                      this.game.EditObj.AnswerTextMouseOver[2] = "Continue your turn.";
                      DrawMod.TGame.EditObj.PopupValue = 10;
                      windowReturnClass1.AddCommand(5, 14);
                      this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                      this.EndingTurn = true;
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                    this.game.EditObj.OrderType = 0;
                    bool flag1 = false;
                    int num9 = 0;
                    int messCounter2 = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
                    for (int index20 = 0; index20 <= messCounter2; ++index20)
                    {
                      bool flag2 = false;
                      if (this.game.Data.RegimeObj[this.game.Data.Turn].MesStyle[index20] == 3)
                      {
                        DynamicData dynamicData = new DynamicData(this.game.Data.RegimeObj[this.game.Data.Turn].MessString[index20]);
                        int elementCounter = dynamicData.elementCounter;
                        for (int index21 = 0; index21 <= elementCounter; ++index21)
                        {
                          if (dynamicData.element[index21].type == DynamicType.OptionField)
                            flag2 = true;
                        }
                      }
                      if (flag2 && this.game.Data.RegimeObj[this.game.Data.Turn].MesChosen[index20] == 0)
                      {
                        flag1 = true;
                        ++num9;
                      }
                    }
                    this.game.EditObj.QuestionText = "Are you sure you want to end your turn?";
                    if (flag1)
                      this.game.EditObj.QuestionText = "You have delegated " + num9.ToString() + " decisions. " + this.game.EditObj.QuestionText;
                    this.game.EditObj.AnswerCount = 2;
                    this.game.EditObj.AnswerText[1] = "Yes";
                    this.game.EditObj.AnswerText[2] = "No";
                    this.game.EditObj.AnswerTextMouseOver[1] = "End your turn.";
                    this.game.EditObj.AnswerTextMouseOver[2] = "Continue your turn.";
                    DrawMod.TGame.EditObj.PopupValue = 10;
                    windowReturnClass1.AddCommand(5, 14);
                    this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                    this.EndingTurn = true;
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
                  }
                  if (num1 == this.ShowAsId)
                  {
                    if (this.game.EditObj.HideAS)
                      this.game.EditObj.HideAS = false;
                    else
                      this.game.EditObj.HideAS = true;
                    this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                    this.game.EditObj.TempCoordList = new CoordList();
                    windowReturnClass1.AddCommand(4, 12);
                    windowReturnClass1.AddCommand(4, 9);
                    windowReturnClass1.AddCommand(4, 67);
                    windowReturnClass1.AddCommand(4, 68);
                    windowReturnClass1.SetFlag(true);
                  }
                  else if (num1 == this.HexUnitButtonId)
                  {
                    if (this.game.EditObj.HideUnit == 0)
                      this.game.EditObj.HideUnit = 1;
                    else if (this.game.EditObj.HideUnit == 1)
                    {
                      if ((double) this.game.Data.RuleVar[344] == 1.0)
                        this.game.EditObj.HideUnit = 2;
                      else
                        this.game.EditObj.HideUnit = 0;
                    }
                    else
                      this.game.EditObj.HideUnit = 0;
                    this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                    this.game.EditObj.TempCoordList = new CoordList();
                    windowReturnClass1.AddCommand(4, 12);
                    windowReturnClass1.AddCommand(4, 9);
                    windowReturnClass1.AddCommand(4, 67);
                    windowReturnClass1.AddCommand(4, 68);
                    windowReturnClass1.SetFlag(true);
                  }
                  else if (num1 == this.ButtonZoomOutId)
                  {
                    int num10 = 0;
                    if (this.game.EditObj.GuiDown)
                      num10 = 222;
                    int num11 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 53.0));
                    int num12 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 106.0));
                    int num13 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num10)) / 53.0));
                    int num14 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num10)) / 106.0));
                    int num15;
                    int num16;
                    if (this.game.EditObj.Zoom == 0)
                    {
                      this.game.EditObj.Zoom = -1;
                      this.game.CornerX -= (int) Math.Round(Conversion.Int((double) num11 / 2.0));
                      this.game.CornerY -= (int) Math.Round(Conversion.Int((double) num13 / 2.0));
                      num15 = 27;
                      num16 = 24;
                    }
                    else
                    {
                      this.game.EditObj.Zoom = 0;
                      this.game.CornerX -= (int) Math.Round(Conversion.Int((double) num12 / 2.0));
                      this.game.CornerY -= (int) Math.Round(Conversion.Int((double) num14 / 2.0));
                      num15 = 53;
                      num16 = 48;
                    }
                    if ((double) this.game.CornerX + (double) this.game.ScreenWidth / (double) num15 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
                      this.game.CornerX = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth) - (double) (this.game.ScreenWidth - 200) / (double) num15);
                    if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num10)) / (double) num16 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
                      this.game.CornerY = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num10)) / (double) num16);
                    if (this.game.CornerX < 0)
                      this.game.CornerX = 0;
                    if (this.game.CornerY < 0)
                      this.game.CornerY = 0;
                    this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                    this.game.EditObj.TempCoordList = new CoordList();
                    windowReturnClass1.AddCommand(1, 12);
                    windowReturnClass1.AddCommand(2, 12);
                    windowReturnClass1.AddCommand(4, 9);
                    windowReturnClass1.AddCommand(4, 67);
                    windowReturnClass1.AddCommand(4, 68);
                    windowReturnClass1.SetFlag(true);
                  }
                  else if (num1 == this.ButtonZoomInId)
                  {
                    int num17 = 0;
                    if (this.game.EditObj.GuiDown)
                      num17 = 222;
                    int num18 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 53.0));
                    int num19 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 106.0));
                    int num20 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num17)) / 53.0));
                    int num21 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num17)) / 106.0));
                    int num22;
                    int num23;
                    if (this.game.EditObj.Zoom == 0)
                    {
                      this.game.EditObj.Zoom = 1;
                      this.game.CornerX += (int) Math.Round(Conversion.Int((double) num19 / 2.0));
                      this.game.CornerY += (int) Math.Round(Conversion.Int((double) num21 / 2.0));
                      num22 = 106;
                      num23 = 96;
                    }
                    else
                    {
                      this.game.EditObj.Zoom = 0;
                      this.game.CornerX += (int) Math.Round(Conversion.Int((double) num18 / 2.0));
                      this.game.CornerY += (int) Math.Round(Conversion.Int((double) num20 / 2.0));
                      num22 = 53;
                      num23 = 48;
                    }
                    if ((double) this.game.CornerX + (double) this.game.ScreenWidth / (double) num22 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
                      this.game.CornerX = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth) - (double) (this.game.ScreenWidth - 200) / (double) num22);
                    if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num17)) / (double) num23 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
                      this.game.CornerY = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num17)) / (double) num23);
                    if (this.game.CornerX < 0)
                      this.game.CornerX = 0;
                    if (this.game.CornerY < 0)
                      this.game.CornerY = 0;
                    this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                    this.game.EditObj.TempCoordList = new CoordList();
                    windowReturnClass1.AddCommand(1, 12);
                    windowReturnClass1.AddCommand(2, 12);
                    windowReturnClass1.AddCommand(4, 9);
                    windowReturnClass1.AddCommand(4, 67);
                    windowReturnClass1.AddCommand(4, 68);
                    windowReturnClass1.SetFlag(true);
                  }
                  else if (num1 == this.ButtonStackedUnitId)
                  {
                    this.game.EditObj.SpreadUnit = !this.game.EditObj.SpreadUnit;
                    this.game.EditObj.TempCoordList = new CoordList();
                    windowReturnClass1.AddCommand(4, 12);
                    windowReturnClass1.AddCommand(4, 9);
                    windowReturnClass1.AddCommand(4, 67);
                    windowReturnClass1.AddCommand(4, 68);
                    windowReturnClass1.SetFlag(true);
                  }
                  else if (num1 == this.SupplyLayerButtonId)
                  {
                    if (this.game.EditObj.LayerSupplyOn)
                    {
                      this.game.EditObj.LayerSupplyOn = false;
                    }
                    else
                    {
                      this.game.EditObj.LayerSupplyOn = true;
                      int unr = this.game.EditObj.UnitSelected;
                      if (this.game.Data.Product >= 6 & (double) this.game.Data.RuleVar[471] > 0.0)
                      {
                        int index22 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Location2;
                        if (index22 > -1)
                        {
                          if (this.game.Data.LocTypeObj[this.game.Data.LocObj[index22].Type].isSupplySource | this.game.Data.LocTypeObj[this.game.Data.LocObj[index22].Type].isSupplyBase)
                            this.game.HandyFunctionsObj.MakeSupplyLayer2(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                          else
                            index22 = -1;
                        }
                        if (index22 == -1)
                          this.game.HandyFunctionsObj.MakeSupplyLayer3(this.game.SelectX, this.game.SelectY, 0);
                        this.game.EditObj.OrderX = this.game.SelectX;
                        this.game.EditObj.OrderY = this.game.SelectY;
                      }
                      else
                      {
                        if (unr != -1)
                        {
                          if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime == this.game.Data.Turn)
                          {
                            if (!this.game.Data.UnitObj[unr].IsHQ)
                              unr = this.game.Data.UnitObj[unr].HQ;
                            this.game.EditObj.LayerSupplyHQ = unr;
                            if ((double) this.game.Data.RuleVar[887] == 1.0)
                            {
                              this.game.EditObj.LayerSupplyHQ = this.game.HandyFunctionsObj.GetTopHQ(unr);
                              unr = this.game.EditObj.LayerSupplyHQ;
                            }
                          }
                          else
                            this.game.EditObj.LayerSupplyHQ = -1;
                        }
                        else
                        {
                          int unitCounter = this.game.Data.UnitCounter;
                          for (int index23 = 0; index23 <= unitCounter; ++index23)
                          {
                            if (this.game.Data.UnitObj[index23].Historical > -1 & this.game.Data.UnitObj[index23].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index23].X > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index23].Historical].Type == 8)
                            {
                              this.game.EditObj.LayerSupplyHQ = index23;
                              break;
                            }
                          }
                          this.game.EditObj.LayerSupplyHQ = -1;
                        }
                        if ((double) this.game.Data.RuleVar[462] > 0.0 && this.game.EditObj.UnitSelected > -1 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime == this.game.Data.Turn && !this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ && this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y].Location > -1 && this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y].Location].Type].isSupplyBase)
                          this.game.EditObj.LayerSupplyHQ = -1;
                        if (this.game.EditObj.LayerSupplyHQ == -1)
                          this.game.HandyFunctionsObj.MakeSupplyLayer2(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                        else
                          this.game.HandyFunctionsObj.MakeSupplyLayer(unr);
                      }
                    }
                    windowReturnClass1.AddCommand(4, 12);
                    windowReturnClass1.AddCommand(4, 9);
                    windowReturnClass1.AddCommand(4, 67);
                    windowReturnClass1.AddCommand(4, 68);
                    windowReturnClass1.SetFlag(true);
                  }
                  else if (num1 == this.OfficerId)
                  {
                    this.game.EditObj.OrderType = 45;
                    this.game.EditObj.OrderUnit = this.game.EditObj.UnitSelected;
                    this.game.EditObj.OrderX = this.game.SelectX;
                    this.game.EditObj.OrderY = this.game.SelectY;
                    this.game.EditObj.OrderMap = this.game.EditObj.MapSelected;
                    windowReturnClass1.AddCommand(1, 5);
                    windowReturnClass1.AddCommand(2, 87);
                    this.dostuff();
                    windowReturnClass1.SetFlag(true);
                  }
                  else if (num1 == this.GroupMoveButtonId)
                  {
                    if ((double) this.game.Data.RuleVar[701] < 1.0 | !this.game.EditObj.useLeftRightClickMode)
                    {
                      this.game.EditObj.OrderType = 48;
                      this.game.EditObj.TempCoordList = this.game.HandyFunctionsObj.MakeMovePredictionGroup(this.game.EditObj.UnitSelected, this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, attackoptions: true, ismove: true);
                      this.game.EditObj.TempCoordList.RemoveCoord(0);
                      this.game.EditObj.OrderUnit = this.game.EditObj.UnitSelected;
                      Coordinate coordinate = this.game.HandyFunctionsObj.SetTempCanSee(this.game.EditObj.TempCoordList);
                      if (coordinate.onmap)
                      {
                        this.game.EditObj.MapSelected = coordinate.map;
                        this.game.SelectX = coordinate.x;
                        this.game.SelectY = coordinate.y;
                        this.game.EditObj.TempCoordList = new CoordList();
                        this.game.EditObj.UnitSelected = this.game.HandyFunctionsObj.ClickOnHexGivesUnit(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, true, 0);
                        windowReturnClass1.AddCommand(4, 20);
                      }
                      this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                    }
                    else
                    {
                      this.game.EditObj.udsUnitOrderMode = 48;
                      ScreenClass screeny = this.formref.Screeny;
                      System.Type type = typeof (MapWindowClass2);
                      ref System.Type local = ref type;
                      MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow(ref local);
                      if (!Information.IsNothing((object) window))
                      {
                        this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                        if (this.game.EditObj.UnitSelected > -1)
                          window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                        else
                          window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                      }
                    }
                    windowReturnClass1.AddCommand(4, 12);
                    windowReturnClass1.AddCommand(4, 9);
                    windowReturnClass1.AddCommand(4, 67);
                    windowReturnClass1.AddCommand(4, 68);
                    windowReturnClass1.SetFlag(true);
                  }
                  else
                  {
                    if (num1 == this.MoveButtonId)
                    {
                      if ((double) this.game.Data.RuleVar[701] < 1.0 | !this.game.EditObj.useLeftRightClickMode)
                      {
                        if (this.game.EditObj.UnitSelected == -1)
                          return windowReturnClass1;
                        this.game.EditObj.OrderType = 1;
                        this.game.EditObj.TempCoordList = this.game.HandyFunctionsObj.MakeMovePrediction(this.game.EditObj.UnitSelected, this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, attackoptions: true, ismove: true);
                        this.game.EditObj.TempCoordList.RemoveCoord(0);
                        this.game.EditObj.OrderUnit = this.game.EditObj.UnitSelected;
                        this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                      }
                      else
                      {
                        this.game.EditObj.udsUnitOrderMode = 1;
                        ScreenClass screeny = this.formref.Screeny;
                        System.Type type = typeof (MapWindowClass2);
                        ref System.Type local = ref type;
                        MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow(ref local);
                        if (!Information.IsNothing((object) window))
                        {
                          this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                          if (this.game.EditObj.UnitSelected > -1)
                            window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                          else
                            window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                        }
                      }
                      windowReturnClass1.AddCommand(4, 12);
                      windowReturnClass1.AddCommand(4, 9);
                      windowReturnClass1.AddCommand(4, 67);
                      windowReturnClass1.AddCommand(4, 68);
                      windowReturnClass1.AddCommand(4, 69);
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                    if (num1 == this.StrategicButtonId)
                    {
                      this.game.EditObj.OrderTarget = -1;
                      this.game.EditObj.TargetX = -1;
                      this.game.EditObj.TargetY = -1;
                      this.game.EditObj.OrderType = 18;
                      this.game.EditObj.OrderUnit = this.game.EditObj.UnitSelected;
                      this.game.EditObj.OrderX = this.game.SelectX;
                      this.game.EditObj.OrderY = this.game.SelectY;
                      this.game.EditObj.OrderMap = this.game.EditObj.MapSelected;
                      int singleCapHq = this.game.HandyFunctionsObj.GetSingleCapHQ();
                      if (singleCapHq > -1)
                      {
                        this.game.EditObj.OrderTarget = singleCapHq;
                        this.game.EditObj.TempCoordList = new CoordList();
                        this.game.EditObj.OrderX = this.game.SelectX;
                        this.game.EditObj.OrderY = this.game.SelectY;
                        windowReturnClass1.AddCommand(1, 69);
                        windowReturnClass1.AddCommand(2, 35);
                        windowReturnClass1.AddCommand(4, 12);
                        windowReturnClass1.AddCommand(4, 67);
                        windowReturnClass1.AddCommand(4, 68);
                        windowReturnClass1.AddCommand(4, 9);
                      }
                      this.dostuff();
                      windowReturnClass1.SetFlag(true);
                    }
                    else if (num1 == this.GroupStrategicButtonId)
                    {
                      this.game.EditObj.OrderTarget = -1;
                      this.game.EditObj.TargetX = -1;
                      this.game.EditObj.TargetY = -1;
                      this.game.EditObj.OrderType = 49;
                      this.game.EditObj.OrderUnit = this.game.EditObj.UnitSelected;
                      this.game.EditObj.OrderX = this.game.SelectX;
                      this.game.EditObj.OrderY = this.game.SelectY;
                      this.game.EditObj.OrderMap = this.game.EditObj.MapSelected;
                      int singleCapHq = this.game.HandyFunctionsObj.GetSingleCapHQ();
                      if (singleCapHq > -1)
                      {
                        this.game.EditObj.OrderTarget = singleCapHq;
                        this.game.EditObj.TempCoordList = new CoordList();
                        this.game.EditObj.OrderX = this.game.SelectX;
                        this.game.EditObj.OrderY = this.game.SelectY;
                        windowReturnClass1.AddCommand(1, 69);
                        windowReturnClass1.AddCommand(2, 35);
                        windowReturnClass1.AddCommand(4, 12);
                        windowReturnClass1.AddCommand(4, 67);
                        windowReturnClass1.AddCommand(4, 9);
                        windowReturnClass1.AddCommand(4, 68);
                        windowReturnClass1.SetFlag(true);
                      }
                      this.dostuff();
                      windowReturnClass1.SetFlag(true);
                    }
                    else if (num1 == this.HqUnitButtonId)
                    {
                      this.game.EditObj.OrderType = 3;
                      this.game.EditObj.OrderUnit = this.game.EditObj.UnitSelected;
                      this.game.EditObj.OrderX = this.game.SelectX;
                      this.game.EditObj.OrderY = this.game.SelectY;
                      this.game.EditObj.OrderMap = this.game.EditObj.MapSelected;
                      this.game.EditObj.TempCoordList = new CoordList();
                      windowReturnClass1.AddCommand(4, 12);
                      windowReturnClass1.AddCommand(4, 67);
                      windowReturnClass1.AddCommand(4, 9);
                      windowReturnClass1.AddCommand(4, 68);
                      windowReturnClass1.SetFlag(true);
                      this.game.HandyFunctionsObj.AllHQToTopOutside(this.game.SelectX, this.game.SelectY);
                    }
                    else if (num1 == this.BlowBridgeButtonId)
                    {
                      this.game.EditObj.OrderType = 35;
                      this.game.EditObj.OrderUnit = this.game.EditObj.UnitSelected;
                      this.game.EditObj.OrderX = this.game.SelectX;
                      this.game.EditObj.OrderY = this.game.SelectY;
                      this.game.EditObj.OrderMap = this.game.EditObj.MapSelected;
                      this.game.EditObj.TempCoordList = new CoordList();
                      this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                      this.game.HandyFunctionsObj.BlowBridgeHexHighlight(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                      windowReturnClass1.AddCommand(4, 12);
                      windowReturnClass1.AddCommand(4, 67);
                      windowReturnClass1.AddCommand(4, 9);
                      windowReturnClass1.AddCommand(4, 68);
                      windowReturnClass1.SetFlag(true);
                    }
                    else if (num1 == this.InfraButtonId)
                    {
                      this.game.EditObj.OrderType = 36;
                      this.game.EditObj.OrderUnit = this.game.EditObj.UnitSelected;
                      this.game.EditObj.OrderX = this.game.SelectX;
                      this.game.EditObj.OrderY = this.game.SelectY;
                      this.game.EditObj.TempCoordList = new CoordList();
                      this.game.HandyFunctionsObj.InfraHexHighlight(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, this.game.EditObj.UnitSelected);
                      windowReturnClass1.AddCommand(4, 12);
                      windowReturnClass1.AddCommand(4, 67);
                      windowReturnClass1.AddCommand(4, 9);
                      windowReturnClass1.AddCommand(4, 68);
                      windowReturnClass1.SetFlag(true);
                    }
                    else if (num1 == this.AirReconButtonId)
                    {
                      this.game.EditObj.OrderTarget = -1;
                      this.game.EditObj.TargetX = -1;
                      this.game.EditObj.TargetY = -1;
                      this.game.EditObj.OrderType = 33;
                      this.game.EditObj.OrderUnit = this.game.EditObj.UnitSelected;
                      this.game.EditObj.OrderX = this.game.SelectX;
                      this.game.EditObj.OrderY = this.game.SelectY;
                      this.game.EditObj.OrderMap = this.game.EditObj.MapSelected;
                      this.game.HandyFunctionsObj.MakeMovePrediction(this.game.EditObj.OrderUnit, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Map, false, PredictAirOnly: true, attack: true, OnlyFrontline: true);
                      this.game.EditObj.TempValue3 = (MapMatrix2[]) this.game.EditObj.TempValue.Clone();
                      this.game.EditObj.TempCoordList = this.game.HandyFunctionsObj.MakeMovePrediction(this.game.EditObj.OrderUnit, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Map, false, PredictAirOnly: true, attack: true);
                      this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                      windowReturnClass1.AddCommand(4, 12);
                      windowReturnClass1.AddCommand(4, 69);
                      windowReturnClass1.AddCommand(4, 67);
                      windowReturnClass1.AddCommand(4, 9);
                      windowReturnClass1.AddCommand(4, 68);
                      windowReturnClass1.SetFlag(true);
                    }
                    else if (num1 == this.AirAttackButtonId)
                    {
                      this.game.EditObj.OrderTarget = -1;
                      this.game.EditObj.SetViewMode = 2;
                      this.game.EditObj.TempUnitList = new UnitList();
                      this.game.EditObj.OrderType = 14;
                      this.game.EditObj.OrderX = this.game.SelectX;
                      this.game.EditObj.OrderY = this.game.SelectY;
                      this.game.EditObj.OrderMap = this.game.EditObj.MapSelected;
                      this.game.EditObj.TargetX = this.game.SelectX;
                      this.game.EditObj.TargetY = this.game.SelectY;
                      this.game.EditObj.TargetMap = this.game.EditObj.MapSelected;
                      this.game.EditObj.TempCoordList = new CoordList();
                      this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                      this.game.EditObj.SetViewMode = 2;
                      windowReturnClass1.AddCommand(4, 12);
                      windowReturnClass1.AddCommand(4, 69);
                      windowReturnClass1.AddCommand(4, 67);
                      windowReturnClass1.AddCommand(4, 9);
                      windowReturnClass1.AddCommand(4, 68);
                      windowReturnClass1.SetFlag(true);
                    }
                    else
                    {
                      if (num1 == this.OrderSurrenderButtonId)
                      {
                        this.game.EditObj.OrderType = 0;
                        this.game.EditObj.QuestionText = "Are you sure you want to surrender?";
                        this.game.EditObj.AnswerCount = 2;
                        this.game.EditObj.AnswerText[1] = "Yes";
                        this.game.EditObj.AnswerText[2] = "No";
                        this.game.EditObj.AnswerTextMouseOver[1] = "Surrender now.";
                        this.game.EditObj.AnswerTextMouseOver[2] = "No don't! Continue turn.";
                        DrawMod.TGame.EditObj.PopupValue = 10;
                        windowReturnClass1.AddCommand(5, 14);
                        this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                        this.Surrendering = true;
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (num1 == this.TransportButtonId)
                      {
                        DrawMod.TGame.EditObj.PopupValue = 26;
                        windowReturnClass1.AddCommand(5, 14);
                        this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (num1 == this.BattleGroupButtonId)
                      {
                        DrawMod.TGame.EditObj.PopupValue = 27;
                        windowReturnClass1.AddCommand(5, 14);
                        this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (num1 == this.AttackButtonId)
                      {
                        this.game.EditObj.OrderTarget = -1;
                        this.game.EditObj.SetViewMode = 2;
                        this.game.EditObj.TempUnitList = new UnitList();
                        this.game.EditObj.OrderType = 2;
                        this.game.EditObj.OrderX = this.game.SelectX;
                        this.game.EditObj.OrderY = this.game.SelectY;
                        this.game.EditObj.OrderMap = this.game.EditObj.MapSelected;
                        this.game.EditObj.TargetX = this.game.SelectX;
                        this.game.EditObj.TargetY = this.game.SelectY;
                        this.game.EditObj.TargetMap = this.game.EditObj.MapSelected;
                        this.game.EditObj.TempCoordList = new CoordList();
                        this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                        windowReturnClass1.AddCommand(4, 12);
                        windowReturnClass1.AddCommand(4, 69);
                        windowReturnClass1.AddCommand(4, 67);
                        windowReturnClass1.AddCommand(4, 9);
                        windowReturnClass1.AddCommand(4, 68);
                        windowReturnClass1.SetFlag(true);
                      }
                      else if (num1 == this.ArtAttackButtonId)
                      {
                        this.game.EditObj.OrderTarget = -1;
                        this.game.EditObj.SetViewMode = 2;
                        this.game.EditObj.OrderType = 11;
                        this.game.EditObj.TempUnitList = new UnitList();
                        this.game.EditObj.OrderX = this.game.SelectX;
                        this.game.EditObj.OrderY = this.game.SelectY;
                        this.game.EditObj.OrderMap = this.game.EditObj.MapSelected;
                        this.game.EditObj.TargetX = this.game.SelectX;
                        this.game.EditObj.TargetY = this.game.SelectY;
                        this.game.EditObj.TargetMap = this.game.EditObj.MapSelected;
                        this.game.EditObj.TempCoordList = new CoordList();
                        this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                        windowReturnClass1.AddCommand(4, 12);
                        windowReturnClass1.AddCommand(4, 69);
                        windowReturnClass1.AddCommand(4, 67);
                        windowReturnClass1.AddCommand(4, 9);
                        windowReturnClass1.AddCommand(4, 68);
                        windowReturnClass1.SetFlag(true);
                      }
                      else
                      {
                        if (num1 == this.GiveUnitId)
                        {
                          new Form3((Form) this.formref).Initialize(this.game.Data, 52, this.game.EditObj.UnitSelected);
                          windowReturnClass1.SetFlag(true);
                          return windowReturnClass1;
                        }
                        if (num1 == this.HistoryId)
                        {
                          this.game.EditObj.LayerSupplyOn = false;
                          this.game.EditObj.OrderType = 26;
                          windowReturnClass1.AddCommand(3, 16);
                          windowReturnClass1.SetFlag(true);
                          return windowReturnClass1;
                        }
                        if (num1 == this.Cancelid)
                        {
                          this.game.HandyFunctionsObj.RedimTempValue(9999);
                          if (this.game.EditObj.LayerSupplyOn)
                          {
                            this.game.EditObj.LayerSupplyOn = false;
                            windowReturnClass1.AddCommand(4, 12);
                            windowReturnClass1.AddCommand(4, 9);
                            windowReturnClass1.AddCommand(4, 67);
                            windowReturnClass1.AddCommand(4, 68);
                            windowReturnClass1.SetFlag(true);
                          }
                          switch (this.game.EditObj.OrderType)
                          {
                            case 1:
                            case 43:
                            case 48:
                              this.game.EditObj.OrderType = 0;
                              if ((double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode)
                              {
                                this.game.EditObj.udsUnitOrderMode = 0;
                                ScreenClass screeny = this.formref.Screeny;
                                System.Type type = typeof (MapWindowClass2);
                                ref System.Type local = ref type;
                                MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow(ref local);
                                if (!Information.IsNothing((object) window))
                                {
                                  this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                                  if (this.game.EditObj.UnitSelected > -1)
                                    window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                                  else
                                    window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                                }
                              }
                              else
                              {
                                this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                                this.game.SelectX = this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X;
                                this.game.SelectY = this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y;
                                this.game.EditObj.MapSelected = this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Map;
                              }
                              windowReturnClass1.AddCommand(4, 12);
                              windowReturnClass1.AddCommand(4, 67);
                              windowReturnClass1.AddCommand(4, 69);
                              windowReturnClass1.AddCommand(4, 68);
                              windowReturnClass1.AddCommand(4, 9);
                              windowReturnClass1.SetFlag(true);
                              break;
                            case 2:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                              this.game.EditObj.OrderType = 0;
                              this.lastorderx = -1;
                              this.lastordery = -1;
                              this.game.EditObj.TempCoordList = new CoordList();
                              this.game.EditObj.TempCoordList.AddCoord(this.game.EditObj.TargetX, this.game.EditObj.TargetY, this.game.EditObj.MapSelected);
                              if (this.game.EditObj.TempUnitList.counter > -1)
                              {
                                int counter = this.game.EditObj.TempUnitList.counter;
                                for (int index24 = 0; index24 <= counter; ++index24)
                                  this.game.EditObj.TempCoordList.AddCoord(this.game.Data.UnitObj[this.game.EditObj.TempUnitList.unr[index24]].X, this.game.Data.UnitObj[this.game.EditObj.TempUnitList.unr[index24]].Y, this.game.Data.UnitObj[this.game.EditObj.TempUnitList.unr[index24]].Map);
                              }
                              this.game.EditObj.TargetX = -1;
                              this.game.EditObj.TargetY = -1;
                              windowReturnClass1.AddCommand(4, 12);
                              windowReturnClass1.AddCommand(4, 67);
                              windowReturnClass1.AddCommand(4, 69);
                              windowReturnClass1.AddCommand(4, 68);
                              windowReturnClass1.AddCommand(4, 9);
                              windowReturnClass1.SetFlag(true);
                              break;
                            case 3:
                            case 4:
                            case 5:
                              this.game.EditObj.OrderType = 0;
                              this.game.EditObj.TempCoordList = new CoordList();
                              this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                              this.game.EditObj.TempCoordList.AddCoord(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap);
                              windowReturnClass1.AddCommand(4, 12);
                              windowReturnClass1.AddCommand(4, 67);
                              windowReturnClass1.AddCommand(4, 69);
                              windowReturnClass1.AddCommand(4, 68);
                              windowReturnClass1.AddCommand(4, 9);
                              this.game.SelectX = this.game.EditObj.OrderX;
                              this.game.SelectY = this.game.EditObj.OrderY;
                              this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                              if (this.game.Data.Round == 0)
                                this.game.Data.Turn = -1;
                              windowReturnClass1.SetFlag(true);
                              break;
                            case 7:
                            case 18:
                            case 44:
                            case 45:
                            case 46:
                            case 49:
                              this.game.EditObj.ShowTransfer = false;
                              this.game.EditObj.TempCoordList = new CoordList();
                              windowReturnClass1.AddCommand(4, 12);
                              windowReturnClass1.AddCommand(1, 5);
                              windowReturnClass1.AddCommand(4, 67);
                              windowReturnClass1.AddCommand(2, 69);
                              windowReturnClass1.AddCommand(4, 68);
                              windowReturnClass1.AddCommand(4, 9);
                              this.game.EditObj.OrderType = 0;
                              this.game.EditObj.TargetX = -1;
                              this.game.EditObj.TargetY = -1;
                              this.game.SelectX = this.game.EditObj.OrderX;
                              this.game.SelectY = this.game.EditObj.OrderY;
                              this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                              this.dostuff();
                              windowReturnClass1.SetFlag(true);
                              break;
                            case 19:
                            case 42:
                              this.game.EditObj.OrderType = 0;
                              windowReturnClass1.AddCommand(4, 12);
                              windowReturnClass1.AddCommand(4, 18);
                              windowReturnClass1.AddCommand(4, 20);
                              this.game.SelectX = this.game.EditObj.OrderX;
                              this.game.SelectY = this.game.EditObj.OrderY;
                              this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                              this.dostuff();
                              windowReturnClass1.SetFlag(true);
                              break;
                            case 20:
                            case 21:
                              this.game.EditObj.TempCoordList = new CoordList();
                              int mapCounter = this.game.Data.MapCounter;
                              for (int index25 = 0; index25 <= mapCounter; ++index25)
                              {
                                int mapWidth = this.game.Data.MapObj[index25].MapWidth;
                                for (int index26 = 0; index26 <= mapWidth; ++index26)
                                {
                                  int mapHeight = this.game.Data.MapObj[index25].MapHeight;
                                  for (int index27 = 0; index27 <= mapHeight; ++index27)
                                    this.game.EditObj.TempValue[index25].Value[index26, index27] = 9999;
                                }
                              }
                              this.game.EditObj.OrderType = 0;
                              windowReturnClass1.AddCommand(4, 12);
                              windowReturnClass1.AddCommand(4, 67);
                              windowReturnClass1.AddCommand(4, 9);
                              windowReturnClass1.AddCommand(4, 69);
                              this.game.SelectX = this.game.EditObj.OrderX;
                              this.game.SelectY = this.game.EditObj.OrderY;
                              this.game.EditObj.MapSelected = this.game.EditObj.OrderMap;
                              this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                              this.dostuff();
                              windowReturnClass1.SetFlag(true);
                              break;
                            case 33:
                            case 35:
                            case 36:
                            case 39:
                              windowReturnClass1.AddCommand(4, 12);
                              windowReturnClass1.AddCommand(4, 67);
                              windowReturnClass1.AddCommand(4, 69);
                              windowReturnClass1.AddCommand(4, 68);
                              windowReturnClass1.AddCommand(4, 9);
                              this.game.EditObj.OrderType = 0;
                              this.game.EditObj.TargetX = -1;
                              this.game.EditObj.TargetY = -1;
                              this.game.SelectX = this.game.EditObj.OrderX;
                              this.game.SelectY = this.game.EditObj.OrderY;
                              this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                              windowReturnClass1.SetFlag(true);
                              break;
                            case 40:
                              this.game.EditObj.OrderType = 0;
                              windowReturnClass1.AddCommand(4, 12);
                              windowReturnClass1.AddCommand(4, 68);
                              windowReturnClass1.AddCommand(4, 69);
                              windowReturnClass1.AddCommand(4, 67);
                              windowReturnClass1.AddCommand(4, 9);
                              this.game.SelectX = this.game.EditObj.OrderX;
                              this.game.SelectY = this.game.EditObj.OrderY;
                              this.game.EditObj.TargetX = -1;
                              this.game.EditObj.TargetY = -1;
                              this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                              this.game.EditObj.TempCoordList = new CoordList();
                              this.dostuff();
                              windowReturnClass1.SetFlag(true);
                              break;
                          }
                        }
                      }
                    }
                  }
                }
                return windowReturnClass1;
              }
            }
            int cardinhandnr = this.ActionButtonCardSlot[index2];
            this.game.EditObj.AreaX = this.game.SelectX;
            this.game.EditObj.AreaY = this.game.SelectY;
            int messCounter = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
            this.game.ProcessingObj.PlayCard(this.game.Data.Turn, cardinhandnr);
            this.game.EditObj.AreaX = -1;
            this.game.EditObj.AreaY = -1;
            this.game.EditObj.TempCoordList = new CoordList();
            windowReturnClass1.AddCommand(4, 12);
            windowReturnClass1.AddCommand(4, 69);
            if (this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter > messCounter)
            {
              this.JustAMessage = true;
              this.game.EditObj.PopupValue = 0;
              this.game.EditObj.FromMessage = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass1.AddCommand(5, 14);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
        }
        windowReturnClass1.SetFlag(false);
        return windowReturnClass1;
      }
      windowReturnClass1.SetFlag(false);
      return windowReturnClass1;
    }

    public void PopUpRefresh()
    {
      if (this.game.Data.Product >= 6 & (double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode && !this.game.EditObj.battleTimerPopupRefreshDoesntStartIt)
      {
        if (this.game.EditObj.OrderType == 2)
        {
          if (this.game.EditObj.TempUnitList.counter > -1)
          {
            this.game.EditObj.BattleTimerActive = true;
            this.game.EditObj.battleTimerInterceptFire = false;
            this.game.EditObj.BattleAnimNr = 0;
            this.game.EditObj.BattleTimer = DateTime.Now + new TimeSpan(0, 0, 0, 0, 1000);
            return;
          }
          this.game.EditObj.TempUnitList = new UnitList();
          this.game.EditObj.OrderType = 0;
          this.game.EditObj.OrderX = -1;
          this.game.EditObj.OrderY = -1;
          this.game.EditObj.TargetX = -1;
          this.game.EditObj.TargetY = -1;
          this.game.EditObj.TempCoordList = new CoordList();
        }
        if (this.game.EditObj.OrderType == 11)
        {
          if (this.game.EditObj.TempUnitList.counter > -1)
          {
            this.game.EditObj.BattleTimerActive = true;
            this.game.EditObj.battleTimerInterceptFire = false;
            this.game.EditObj.BattleAnimNr = 0;
            this.game.EditObj.BattleTimer = DateTime.Now + new TimeSpan(0, 0, 0, 0, 1000);
            return;
          }
          this.game.EditObj.TempUnitList = new UnitList();
          this.game.EditObj.OrderType = 0;
          this.game.EditObj.OrderX = -1;
          this.game.EditObj.OrderY = -1;
          this.game.EditObj.TargetX = -1;
          this.game.EditObj.TargetY = -1;
          this.game.EditObj.TempCoordList = new CoordList();
        }
      }
      this.game.EditObj.battleTimerPopupRefreshDoesntStartIt = false;
      if (this.JustAMessage)
      {
        this.JustAMessage = false;
        this.DoRefresh();
      }
      else
      {
        this.game.EditObj.HandCard = -1;
        this.EndingTurn &= this.game.EditObj.AnswerChosen == 1;
        this.Surrendering &= this.game.EditObj.AnswerChosen == 1;
        if (this.AskingAboutMetrics)
        {
          if (this.game.EditObj.AnswerChosen == 1)
            this.game.EditObj.allowMetrics = true;
          else
            this.game.EditObj.allowMetrics = false;
          this.game.EditObj.askedMetricsPermission = true;
          this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
        }
        this.lastorderx = -1;
        this.lastordery = -1;
        this.DoRefresh();
      }
    }

    public WindowReturnClass DoSurrenderStuff()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      this.game.EditObj.UnitSelected = -1;
      this.game.EditObj.OrderUnit = -1;
      this.game.EditObj.OrderTarget = -1;
      this.game.EditObj.OldUnit = -1;
      int humanPlayers = this.game.HandyFunctionsObj.GetHumanPlayers();
      switch (humanPlayers)
      {
        case 1:
          this.game.Data.Winner = this.game.HandyFunctionsObj.FindAIPlayer();
          break;
        case 2:
          this.game.Data.Winner = this.game.HandyFunctionsObj.FindOtherHumanPlayer(this.game.Data.Turn);
          break;
        default:
          if (this.game.Data.PbemGameID < 1)
          {
            this.game.EventRelatedObj.ExecJoinRegime(this.game.Data.Turn, -1, 0, 0, "");
            break;
          }
          break;
      }
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
      this.game.EventRelatedObj.ExecMessage2(-1, -1, -1, -1, this.game.Data.RegimeObj[this.game.Data.Turn].Name + " has surrendered.");
      if ((double) this.game.Data.RuleVar[978] < 1.0)
      {
        this.game.Data.LastWinner = this.game.Data.Winner;
        if (this.game.Data.PbemGameID < 1)
          this.game.Data.RegimeObj[this.game.Data.Turn].Sleep = true;
      }
      this.EndingTurn = true;
      this.dostuff();
      windowReturnClass.SetFlag(true);
      if (humanPlayers > 1 | (double) this.game.Data.RuleVar[978] > 0.0 | this.game.Data.PbemGameID > 0)
      {
        windowReturnClass.AddCommand(3, 13);
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
      }
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
    }

    public WindowReturnClass DoEndTurnStuff()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      int regimeCounter = this.game.Data.RegimeCounter;
      for (int regnr = 0; regnr <= regimeCounter; ++regnr)
      {
        if (this.game.Data.RegimeObj[regnr].Sleep | this.game.Data.RegimeObj[regnr].AI)
          this.game.HandyFunctionsObj.ClearHistory((object) regnr);
      }
      int humanPlayers = this.game.HandyFunctionsObj.GetHumanPlayers();
      this.game.EditObj.DoCardSlot = -1;
      this.game.EditObj.HandCard = -1;
      if (this.game.Data.UseAI == 1 && Information.IsNothing((object) this.game.NewAIObj))
        this.game.NewAIObj = new NewAIClass(this.game);
      if (humanPlayers < 1)
      {
        this.game.Data = new DataClass();
        this.game.EditObj = new EditClass(this.game.AppPath + "editobj.txt");
        if (this.game.Data.UseAI == 1)
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
        string str = this.game.AppPath_SAVEGAMES + "autosave.se1";
        this.game.Data.serialize(str);
        this.game.HandyFunctionsObj.ZipFile(str);
      }
      if (this.game.Data.Turn != -1 && !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
        this.game.EventRelatedObj.DoCheckEvents(5);
      windowReturnClass.AddCommand(3, 13);
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
    }

    public void HighLightAItest()
    {
      int unitSelected = this.game.EditObj.UnitSelected;
      this.game.EditObj.TempCoordList = new CoordList();
      int num = -1;
      int moveMatrixCounter = this.game.NewAIObj.MoveMatrixCounter;
      for (int index = 0; index <= moveMatrixCounter; ++index)
      {
        if (this.game.NewAIObj.MoveMatrixUnit[index] == unitSelected)
        {
          num = index;
          break;
        }
      }
      this.game.HandyFunctionsObj.RedimTempValue(9999);
      if (num <= -1)
        return;
      if (this.game.Data.UnitObj[unitSelected].TempCategory == 1)
      {
        int counter = this.game.NewAIObj.MarkerList.Counter;
        for (int index = 0; index <= counter; ++index)
          this.game.EditObj.TempValue[0].Value[this.game.NewAIObj.MarkerList.Data1[index], this.game.NewAIObj.MarkerList.Data2[index]] = 0;
      }
      else if (this.game.Data.UnitObj[unitSelected].TempCategory == 2)
      {
        int counter = this.game.NewAIObj.ArtMarkerList.Counter;
        for (int index = 0; index <= counter; ++index)
          this.game.EditObj.TempValue[0].Value[this.game.NewAIObj.ArtMarkerList.Data1[index], this.game.NewAIObj.ArtMarkerList.Data2[index]] = 0;
      }
      else if (this.game.Data.UnitObj[unitSelected].TempCategory == 3)
      {
        int counter = this.game.NewAIObj.AirMarkerList.Counter;
        for (int index = 0; index <= counter; ++index)
          this.game.EditObj.TempValue[0].Value[this.game.NewAIObj.AirMarkerList.Data1[index], this.game.NewAIObj.AirMarkerList.Data2[index]] = 0;
      }
      else
      {
        if (this.game.Data.UnitObj[unitSelected].TempCategory != 4)
          return;
        if (this.game.NewAIObj.EngineerMarkerList.Counter > -1)
        {
          int counter = this.game.NewAIObj.EngineerMarkerList.Counter;
          for (int index = 0; index <= counter; ++index)
            this.game.EditObj.TempValue[0].Value[this.game.NewAIObj.EngineerMarkerList.Data1[index], this.game.NewAIObj.EngineerMarkerList.Data2[index]] = 0;
        }
        else
        {
          int counter = this.game.NewAIObj.MarkerList.Counter;
          for (int index = 0; index <= counter; ++index)
            this.game.EditObj.TempValue[0].Value[this.game.NewAIObj.MarkerList.Data1[index], this.game.NewAIObj.MarkerList.Data2[index]] = 0;
        }
      }
    }
  }
}
