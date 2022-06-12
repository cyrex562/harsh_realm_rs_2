// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.EditClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.IO;

namespace WindowsApplication1
{
  public class EditClass
  {
    public bool TutMode;
    public bool ButtonLoadMode;
    public int TutOrder;
    public object TutX;
    public object TutY;
    public object TutHis;
    public object TutSubpart;
    public object TutCard;
    public int donequest;
    public bool SubformationListMode;
    public bool inSimpleEditor;
    public bool inSimpleMapEditor;
    public int TutStep;
    public int ranraw;
    public int ranpop;
    public int OfficerHisOverrule;
    public bool CombatTextual;
    public bool SkippedPreSelectPopup;
    public bool GuiDown;
    public bool RightDown;
    public bool LeftDown;
    public int TempRegimeSlot;
    public int TempHisModelUnit;
    public string TipText;
    public string TipTitle;
    public int TipColor;
    public bool TipButton;
    public bool warningshown;
    public bool FindModFile;
    public string ZipFileText;
    public string QuestionText;
    public int QuestionCard;
    public int AnswerCount;
    public string[] AnswerText;
    public string[] AnswerTextMouseOver;
    public int AnswerChosen;
    public int nextEventSlot;
    public string RandomUseMaster;
    public string EditorUseMaster;
    public int AIProgressNow;
    public int AIProgressMax;
    public int SFCompare;
    public bool BattleTimerActive;
    public DateTime BattleTimer;
    public int BattleAnimNr;
    public bool battleTimerInterceptFire;
    public bool battleTimerPopupRefreshDoesntStartIt;
    public int Layout;
    public bool TownInfo;
    public string TextInputString;
    public bool MouseOverVisible;
    public int MouseWheel;
    public int MouseWheelWait;
    public bool MapPopupMode;
    public int PencilType;
    public int PencilData1;
    public int PencilData2;
    public int PencilMode;
    public int RightClickX;
    public int RightCLickY;
    public int RightClickMap;
    public string TempAIString;
    public int LocTypeSelected;
    public int PeopleSelected;
    public int TempRandom;
    public bool TempAIWatch;
    public bool AutoCombat;
    public int Test;
    public int TestEarlyCinematics;
    public MapMatrix2[] TempValue;
    public MapMatrix2[] TempValueSpecial;
    public MapMatrix2[] TempValueSpecial2;
    public MapMatrix2[] TempValue2;
    public MapMatrix2[] TempValue3;
    public MapMatrix2[] TempValue4;
    public MapMatrix2Plus6[] TempAttack;
    public int[,] TempAI;
    public int[,] TempAI2;
    public MapMatrix2[] TempLos;
    public MapMatrix2[] TempObstruct;
    public MapMatrix2[] FuzzyPresumed;
    public MapMatrix2[] FuzzyReal;
    public int[,,] PossiblePull;
    public int[,,] origPossiblePull;
    public int tempGroupMoveCounter;
    public int[] tempGroupMoveUnr;
    public CoordList[] tempGroupMoveCameFrom;
    public CoordList[] tempGroupMovePath;
    public MapMatrix2[] TempSup;
    public MapMatrix2Coordinate[] TempSupCameFrom;
    public bool LayerSupplyOn;
    public int LayerSupplyHQ;
    public int LayerSupplyAP;
    public bool HexRasterOn;
    public bool InsideSlotty;
    public bool HideDetail;
    public bool HideAS;
    public bool CombatSim;
    public bool DoQuit;
    public int[] RemoveReinforce;
    public string LoadGame;
    public bool ShownWelcome;
    public bool ShowInitialMenu;
    public MapMatrix2String[] TempString;
    public MapMatrix2String[] TempString2;
    public string ApTempString;
    public MapMatrix2Coordinate[] TempCameFrom;
    public CoordList SupplyPath;
    public int AirSupplyPts;
    public int AirSupplyCarry;
    public int AirSupplyHq;
    public CoordList TempCoordList;
    public CoordList TempCoordListLastMove;
    public CoordList TempMovePathList;
    public bool mouseOverActive;
    public UnitList TempUnitList;
    public UnitList TempPossibleUnitList;
    public string CurrentDescript;
    public bool MiddleWindow;
    public int PaintShortcut1;
    public int PaintShortcut2;
    public int PaintShortcut3;
    public int EventMap;
    public int OrderType;
    public int OrderSubType;
    public int OrderUnit;
    public int OrderTarget;
    public int OrderData;
    public int OrderX;
    public int OrderY;
    public int OrderMap;
    public int OrderLoc;
    public int orderInt;
    public int TargetX;
    public int TargetY;
    public int TargetMap;
    public int Phase;
    public int MainSub;
    public int OrderBombMode;
    public bool ShortRandomScreen;
    public bool maximumInterfaceSpace;
    public bool AlternateMusic;
    public bool firstroundcheck;
    public MapMatrix2[] HisOwner;
    public MapMatrix2[] HisForce;
    public MapMatrix2[] HisSFType;
    public MapMatrix2[] HisHis;
    public MapMatrix2[] HisDepth;
    public int HisStep;
    public Neighbours HisNeighbour;
    public int HisAttackType;
    public int HisHotX;
    public int HisHotY;
    public int HisLossCounter;
    public int HisRegimeWon;
    public int HisLossAttReg;
    public int HisLossDefReg;
    public int[] HisLossSFType;
    public int[] HisLossAttacker;
    public int[] HisLossOK;
    public int[] HisLossDEAD;
    public int HisLossCounter2;
    public int HisRegimeWon2;
    public int HisLossAttReg2;
    public int HisLossDefReg2;
    public int[] HisLossSFType2;
    public int[] HisLossAttacker2;
    public int[] HisLossOK2;
    public int[] HisLossDEAD2;
    public string HisInfoString;
    public int TempPeopleSlot;
    public int TempItemSlot;
    public int TempSFType;
    public int TempSelected;
    public int TempCopy;
    public int UnitSelected;
    public int SFSelected;
    public int MouseOverX;
    public int MouseOverY;
    public int TransferLostQty;
    public int TransferLostType;
    public int TransferLostTransports;
    public string FeedBackString;
    public CommandClass TempCommand;
    public EventClass TempEvent;
    public string CombatOneSentence;
    public string CombatOneSentenceCustom;
    public string CombatOneSentence2;
    public bool PrefShowFOW;
    public bool PrefCombatLog;
    public bool PrefMinimalistCounter;
    public int CameFrom;
    public int SFTypeSelected;
    public int TempProdList1;
    public int TempProdList2;
    public int TempProdList3;
    public int SetViewMode;
    public int SetViewMode2;
    public int SetSubViewMode;
    public bool SetViewMode3;
    public int SetViewMode4;
    public int SetViewModeExtraNr;
    public bool ShowTransfer;
    public int HideUnit;
    public bool SoundOn;
    public bool ShowLabel;
    public bool ShowBase;
    public bool IntroSoundOn;
    public int LastHistoryStep;
    public MapMatrix2 airRangeTempLos;
    public MapMatrix2 airRangeMaxObstruct;
    public int MessageStyle;
    public string MessageNote;
    public string MessageNote2;
    public string MessageName;
    public int MessageGroup;
    public bool MessageHideFromTab;
    public bool MessageHideFromStart;
    public int CurrentMiniX;
    public int CurrentMiniY;
    public int ranmem;
    public int ranr1;
    public int ranr2;
    public int ranr3;
    public int ranr4;
    public int ranr5;
    public int ranr6;
    public int ranr7;
    public int ranr8;
    public int ran1;
    public int ran2;
    public int ran3;
    public int ran4;
    public int ran5;
    public int ran6;
    public int ran7;
    public int ran8;
    public int ran9;
    public int ran10;
    public int ran11;
    public int ran12;
    public int ranoldkingdom;
    public int randomaploop;
    public int randoallied;
    public int randoshrowd;
    public int randofirsttech;
    public int randomirror;
    public int randoblockcenter;
    public int ranoptimize;
    public string ranmasterfile;
    public int ransinglestart;
    public int ransworldsize;
    public int ransplayer;
    public int ranrawuse;
    public int ranswater;
    public int ransclimate;
    public int ranscrate;
    public int ranstats;
    public string RandomSettingsFromMod;
    public float PassengerDammage;
    public bool AutoSave;
    public bool BlockAdvice;
    public bool TempBlockAdvice;
    public int LastStatWindow;
    public bool StartWithHistory;
    public int FromMessage;
    public int AreaSlot;
    public int AreaValue;
    public int AreaX;
    public int AreaY;
    public int AreaMap;
    public int PopupValue;
    public int DoCardSlot;
    public EditClass.AfterPopUpRefresh MyDelegate;
    public EditClass.AfterPopUpRefresh MyDelegateMap;
    public string TempEventWav;
    public int CampaignRoomBitmap;
    public string CampaignRoomTitle;
    public int HumanPlayer;
    public int Volume;
    public int Volume2;
    public bool AIMoving;
    public bool RegimeColoring;
    public int TempHisUnit;
    public int HandCard;
    public bool TempAIInitialized;
    public int TempAIRegime;
    public int MapSelected;
    public int HisHotMap;
    public bool SpreadUnit;
    public string PbemUserName;
    public string PbemPassword;
    public string PbemSerial;
    public string PbemEmail;
    public string PbemTitle;
    public int PbemChallengeID;
    public int PbemGameInstanceID;
    public string PbemMiscString;
    public string PbemPrivatePassword;
    public string PbemChallengeMiscData;
    public bool PbemSteam;
    public bool PbemAlreadyAccount;
    public ServerCommandType ServerCommand;
    public int ServerCommandStep;
    public int ServerCommandMaxStep;
    public int ServerCommandMaxStepOrig;
    public ServerStatusType ServerStatus;
    public MessageList ServerMessages;
    public DateTime ServerStatusStartTime;
    public bool ServerLostConnect;
    public ServerRegisterReplyType ServerRegisterReply;
    public ServerAuthReplyType ServerAuthReply;
    public ServerSerialReplyType ServerSerialReply;
    public ServerGenericReplyType ServerGenericReply;
    public string ServerRegisterUserNameReply;
    public bool ServerStatusInitializeTried;
    public string ServerCookieValue;
    public byte[] ServerUploadFile;
    public string ServerCrc32;
    public long ServerUploadSize;
    public long ServerUploadDone;
    public long ServerDownloadSize;
    public long ServerDownloadDone;
    public byte[] ServerDownloadFile;
    public ChallengeClass[] ServerChallengeList;
    public RunningGameClass[] ServerRunningGameList;
    public int ServerExactErrorCode;
    public ServerCommandType OrigServerCommand;
    public string ServerTextBuffer;
    public PbemGameSetupPhase PbemGameSetup;
    public int PbemInspectReturnFromID;
    public int PbemGameID;
    public string PbemPlayer1;
    public string PbemPlayer2;
    public string PbemCheckPlayer;
    public int PbemGameOver;
    public bool ShowUnderHQ;
    public bool ShowSameHistorical;
    public bool ShowMouseOver;
    public bool ShowHQPower;
    public bool ShowAirRange;
    public bool ShowLISRange;
    public int OldUnit;
    public bool ServerOrderCancel;
    public bool DoubleSize;
    public int DoubleSizePercentage;
    public bool PurelyOrderRedrawRefresh;
    public string pdfGenerated;
    public bool helpAlreadyOpened;
    public bool systemPopup;
    public bool highGfxSpeedOn;
    public int rightSideBarMode;
    public int leftSideBarMode;
    public int leftSideBarModePage;
    public int debugAiOnlyTillRound;
    public int attackTypeOption;
    public int udsUnitOrderMode;
    public bool udsReturnFromPopup;
    public int udsLastCalledPopupEventNr;
    public string udsOrderBarFeedbackString;
    public int udsOrderBarFeedbackColor;
    public bool udsOrderPossible;
    public int udsManagementTabOverrideId;
    public int udsViewMode2Override;
    public CoordList tempDidInterceptList;
    public bool useLeftRightClickMode;
    public int se1_SelectZoneButton;
    public int se1_SelectUnitButton;
    public int se1_SelectAssetButton;
    public int se1_AssetPage;
    public int se1_UnitPage;
    public int se1_AssetCategory1;
    public int se1_AssetCategory2;
    public int se1_AssetCategory3;
    public int se1_AssetCategory4;
    public int se1_AssetCategory5;
    public int se1_assetMode;
    public int se1_assetSHQ;
    public int se1_assetZone;
    public int se1_assetItem;
    public int se1_assetItemMode1;
    public int se1_assetItemMode2;
    public int se1_assetRightPanel;
    public int se1_assetPage2;
    public int se1_modelSHQ;
    public int se1_modelReinf;
    public int se1_modelSelected;
    public int se1_modelPage;
    public int se1_modelPage2;
    public int se1_modelView;
    public int se1_modelObsoleteHidden;
    public int se1_ExecReturnValue;
    public int se1_CardsCategory;
    public int se1_CardsTarget;
    public int se1_CardsCard;
    public int se1_CardsPage;
    public int se1_CardsViewMode;
    public int se1_CardsSmallCards;
    public int se1_CardsSelectX;
    public int se1_CardsSelectY;
    public int se1_StrategyTab;
    public int se1_StrategySpecial1;
    public int se1_StrategySpecial2;
    public int se1_adviceWindowState;
    public int se1_adviceWindowPage;
    public bool se1_ManagementMode;
    public int se1_ManagementTab;
    public int se1_leaderGroup;
    public int se1_leaderSelected;
    public SimpleList se1_leaderColumns;
    public int se1_leaderPage;
    public string tempRenameString;
    public string tempRenameString2;
    public string tempRenameString3;
    public int statsTab_tab;
    public int statsTab_item;
    public int[] uds_subtab;
    public int[,] uds_page;
    public int RealTurn;
    public int RealRound;
    public int overruleScreenResWidth;
    public int overruleScreenResHeight;
    public bool mouseScreenLock;
    public bool EarlyCinematicsLoggedIn;
    public bool showAdvice;
    public bool dontShowAImoves;
    public bool usePullAssets;
    public bool usePullCities;
    public bool usePullUnits;
    public bool matrixSubPart_BlockMouseUpScroller1time;
    public const int ORDERMOVE = 1;
    public const int ORDERATTACK = 2;
    public const int ORDERUNITHQ = 3;
    public const int ORDERPRODHQ = 4;
    public const int ORDERRECRUIT = 5;
    public const int ORDERPROD = 6;
    public const int ORDERNEWUNIT = 7;
    public const int ORDERNEWSF = 8;
    public const int ORDERTRANSFER = 9;
    public const int ORDERARTATTACK = 11;
    public const int ORDERSEAATTACK = 12;
    public const int ORDERSEAARTATTACK = 13;
    public const int ORDERAIRSTRIKE = 14;
    public const int ORDERBOMB = 15;
    public const int ORDERINTERNALAA = 16;
    public const int ORDERINTERNALDOGFIGHT = 17;
    public const int ORDERSTRATEGIC = 18;
    public const int ORDERPARADROP = 19;
    public const int ORDERLOAD = 20;
    public const int ORDERUNLOAD = 21;
    public const int ORDERPOOL = 22;
    public const int ORDERRESEARCH = 23;
    public const int ORDERDIP = 24;
    public const int ORDERCONSTRUCT = 25;
    public const int ORDERHISTORY = 26;
    public const int ORDERHISTORYACAP = 27;
    public const int ORDERHISTORYACAP2 = 28;
    public const int ORDERHISTORYACAP3 = 29;
    public const int ORDERPREFS = 30;
    public const int ORDERINTERNALREBEL = 31;
    public const int ORDERSTATS = 32;
    public const int ORDERAIRRECON = 33;
    public const int ORDERPEOPLETRANSFER = 34;
    public const int ORDERBLOW = 35;
    public const int ORDERINFRA = 36;
    public const int ORDERBUILD = 37;
    public const int ORDERVIEWSUPPLY = 38;
    public const int ORDERACAP = 39;
    public const int ORDERAIRSUPPLY = 40;
    public const int ORDERSURRENDER = 41;
    public const int ORDERAIRLIFT = 42;
    public const int ORDERAITEST = 43;
    public const int ORDERNEWUNIT2 = 44;
    public const int ORDEROFFICER = 45;
    public const int ORDERCHANGEMODEL = 46;
    public const int ORDERMODELDESIGNER = 47;
    public const int ORDERGROUPMOVE = 48;
    public const int ORDERGROUPSTRATEGIC = 49;
    public const int ORDERNEXT = 50;
    public const int ORDERSUPPLYLAYER = 51;
    public const int ORDERSFDESIGN = 52;
    public const int ORDERTRAFIC = 53;
    public const int ORDERZONEBORDER = 54;
    public const int ORDERAIRBRIDGE = 55;
    public int CounterAlpha;
    public int CounterAlpha2;
    public Bitmap StratMap;
    public Bitmap MiniMap;
    public int MiniMapOffset;
    public bool ProdFlap;
    public bool InEditor;
    public int ScrollDir;
    public int Zoom;
    public bool CombatNumbers;
    public bool Screenshoton;
    public int[] StartRdn;
    public int[] StartXp;
    public int[] StartMor;
    public int[] StartEntr;
    public int OverlayMode;
    public int overlayOffsetX;
    public int overlayOffsetY;
    public string LoadFileName;
    public bool LoadingFinished;
    public LoadType LoadingResult;
    public string LoadString;
    public string LoadCheckSum;
    public bool LoadNoNewEdit;
    public bool NextTurnButtonPress;
    public bool OddsCalcFinished;
    public bool OddsCalcStarted;
    public bool ShowHQ;
    public int SimpleEditWindow;
    public string TempFileName;
    public NewEnums.LibFileType TempFileType;
    public bool allowMetrics;
    public bool askedMetricsPermission;
    public string UDStabText;
    public string UDSbottomText;
    public string UDSpopupText;
    public int UDSpopupMode;
    public int UDSinputCounter;
    public string[] UDSinputKey;
    public string[] UDSinputValue;
    public int TempUDSinputCounter;
    public string[] TempUDSinputKey;
    public string[] TempUDSinputValue;
    public int interfaceCue;
    public int dssLastDominant;
    public int dssLastEngineAction;
    public int dssLastTrackId;
    public int dssLastHighlightId;
    public bool layerLisAvailable;
    public bool layerLisUsed;
    public bool layerLisTotal;
    public bool layerLisBottlenecks;
    public bool layerLisPreview;
    public bool layerLisOnlyAssetId_isSupplyBase;
    public int layerLisOnlyAssetId;
    public int layerLisPreview_LogMode;
    public int layerLis_LogType;
    public int layerLis_TraficWindowOpen;
    public int[,] tempZoneTest;
    public int[] tempOtherTest;
    public string[] tempOtherTestText;
    public bool layerUnits;
    public bool inRandomScreen;
    public string UDSpushedPopupText;
    public bool UdsInsideTabOpenMode;
    public SimpleList udsInsideTabOpenModeList;
    public bool TempFireListCacheSet;
    public bool resourceVpCacheSet;
    public bool WINDOW_DEBUG_MODE;
    public bool AutoDpiCheckDone;
    public bool Dc4_RightWindow_Expand1;
    public bool Dc4_RightWindow_Expand2;
    public bool Dc4_RightWindow_Expand3;
    public bool Dc4_RightWindow_Expand4;
    public bool Dc4_RightWindow_Expand5;
    public bool Dc4_RightWindow_Expand6;
    public bool Dc4_RightWindow_Expand7;
    public bool Dc4_RightWindow_Expand8;
    public bool Dc4_RightWindow_Expand9;
    public string Dc4_Card_Select_Feedback;
    public Color dc4_card_select_feedback_Color;
    public string dc4_card_select_feedback_short;
    public bool Dc4_temp_cardtab_cache;
    public bool dc4_temp_warning1done;
    public bool dc4_temp_warning2done;
    public int dc4_last_supply_x;
    public int dc4_last_supply_y;
    public WindowClass form3windowClass;
    public bool quickInterceptCombat;
    public bool se1_map_data3cache_set;
    public bool skipGfxDetail;

    public void UDSClearInput() => this.UDSinputCounter = -1;

    public void TempUDSClearInput() => this.TempUDSinputCounter = -1;

    public void UDSAddInput(string tkey, string tvalue)
    {
      ++this.UDSinputCounter;
      this.UDSinputKey = (string[]) Utils.CopyArray((Array) this.UDSinputKey, (Array) new string[this.UDSinputCounter + 1 + 1]);
      this.UDSinputValue = (string[]) Utils.CopyArray((Array) this.UDSinputValue, (Array) new string[this.UDSinputCounter + 1 + 1]);
      this.UDSinputKey[this.UDSinputCounter] = tkey;
      this.UDSinputValue[this.UDSinputCounter] = tvalue;
    }

    public void TempUDSAddInput(string tkey, string tvalue)
    {
      ++this.TempUDSinputCounter;
      this.TempUDSinputKey = (string[]) Utils.CopyArray((Array) this.TempUDSinputKey, (Array) new string[this.TempUDSinputCounter + 1 + 1]);
      this.TempUDSinputValue = (string[]) Utils.CopyArray((Array) this.TempUDSinputValue, (Array) new string[this.TempUDSinputCounter + 1 + 1]);
      this.TempUDSinputKey[this.TempUDSinputCounter] = tkey;
      this.TempUDSinputValue[this.TempUDSinputCounter] = tvalue;
    }

    public void UDSAddInput(string tkey, int tvalue)
    {
      int udSinputCounter = this.UDSinputCounter;
      for (int index = 0; index <= udSinputCounter; ++index)
      {
        if (Operators.CompareString(this.UDSinputKey[index].ToLower(), tkey.ToLower(), false) == 0)
        {
          this.UDSinputValue[index] = Conversions.ToString(tvalue);
          return;
        }
      }
      ++this.UDSinputCounter;
      this.UDSinputKey = (string[]) Utils.CopyArray((Array) this.UDSinputKey, (Array) new string[this.UDSinputCounter + 1 + 1]);
      this.UDSinputValue = (string[]) Utils.CopyArray((Array) this.UDSinputValue, (Array) new string[this.UDSinputCounter + 1 + 1]);
      this.UDSinputKey[this.UDSinputCounter] = tkey;
      this.UDSinputValue[this.UDSinputCounter] = tvalue.ToString();
    }

    public EditClass()
    {
      this.AnswerText = new string[10];
      this.AnswerTextMouseOver = new string[10];
      this.TempValue = new MapMatrix2[1];
      this.TempValueSpecial = new MapMatrix2[1];
      this.TempValueSpecial2 = new MapMatrix2[1];
      this.TempValue2 = new MapMatrix2[1];
      this.TempValue3 = new MapMatrix2[1];
      this.TempValue4 = new MapMatrix2[1];
      this.TempAttack = new MapMatrix2Plus6[1];
      this.TempAI = new int[1, 1];
      this.TempAI2 = new int[1, 1];
      this.TempLos = new MapMatrix2[1];
      this.TempObstruct = new MapMatrix2[1];
      this.FuzzyPresumed = new MapMatrix2[1];
      this.FuzzyReal = new MapMatrix2[1];
      this.PossiblePull = new int[1, 1, 7];
      this.origPossiblePull = new int[1, 1, 7];
      this.tempGroupMoveUnr = new int[1];
      this.tempGroupMoveCameFrom = new CoordList[1];
      this.tempGroupMovePath = new CoordList[1];
      this.TempSup = new MapMatrix2[1];
      this.TempSupCameFrom = new MapMatrix2Coordinate[1];
      this.RemoveReinforce = new int[100];
      this.TempString = new MapMatrix2String[1];
      this.TempString2 = new MapMatrix2String[1];
      this.TempCameFrom = new MapMatrix2Coordinate[1];
      this.TempCoordList = new CoordList();
      this.TempCoordListLastMove = new CoordList();
      this.TempMovePathList = new CoordList();
      this.TempUnitList = new UnitList();
      this.HisOwner = new MapMatrix2[1];
      this.HisForce = new MapMatrix2[1];
      this.HisSFType = new MapMatrix2[1];
      this.HisHis = new MapMatrix2[1];
      this.HisDepth = new MapMatrix2[1];
      this.HisLossSFType = new int[1];
      this.HisLossAttacker = new int[1];
      this.HisLossOK = new int[1];
      this.HisLossDEAD = new int[1];
      this.HisLossSFType2 = new int[1];
      this.HisLossAttacker2 = new int[1];
      this.HisLossOK2 = new int[1];
      this.HisLossDEAD2 = new int[1];
      this.ServerCookieValue = "";
      this.PbemGameSetup = PbemGameSetupPhase.None;
      this.helpAlreadyOpened = false;
      this.systemPopup = false;
      this.highGfxSpeedOn = false;
      this.udsUnitOrderMode = 1;
      this.udsReturnFromPopup = false;
      this.udsLastCalledPopupEventNr = -1;
      this.udsManagementTabOverrideId = -1;
      this.udsViewMode2Override = -1;
      this.tempRenameString = "";
      this.tempRenameString2 = "";
      this.tempRenameString3 = "";
      this.uds_subtab = new int[10];
      this.uds_page = new int[10, 20];
      this.MiniMapOffset = 0;
      this.StartRdn = new int[2];
      this.StartXp = new int[2];
      this.StartMor = new int[2];
      this.StartEntr = new int[2];
      this.LoadNoNewEdit = false;
      this.NextTurnButtonPress = false;
      this.UDSinputKey = new string[1];
      this.UDSinputValue = new string[1];
      this.TempUDSinputKey = new string[1];
      this.TempUDSinputValue = new string[1];
      this.tempZoneTest = new int[1, 1];
      this.tempOtherTest = new int[1];
      this.tempOtherTestText = new string[1];
      this.UdsInsideTabOpenMode = false;
      this.TempFireListCacheSet = false;
      this.resourceVpCacheSet = false;
      this.WINDOW_DEBUG_MODE = false;
      this.AutoDpiCheckDone = false;
      this.Dc4_RightWindow_Expand1 = false;
      this.Dc4_RightWindow_Expand2 = false;
      this.Dc4_RightWindow_Expand3 = false;
      this.Dc4_RightWindow_Expand4 = false;
      this.Dc4_RightWindow_Expand5 = false;
      this.Dc4_RightWindow_Expand6 = false;
      this.Dc4_RightWindow_Expand7 = false;
      this.Dc4_RightWindow_Expand8 = false;
      this.Dc4_RightWindow_Expand9 = false;
      this.Dc4_Card_Select_Feedback = "";
      this.Dc4_temp_cardtab_cache = false;
      this.dc4_temp_warning1done = false;
      this.dc4_temp_warning2done = false;
      this.dc4_last_supply_x = -1;
      this.dc4_last_supply_y = -1;
      this.quickInterceptCombat = false;
      this.se1_map_data3cache_set = false;
      this.skipGfxDetail = false;
      this.initialSet();
    }

    public void initialSet()
    {
      this.DoCardSlot = -1;
      this.allowMetrics = false;
      this.mouseScreenLock = true;
      this.askedMetricsPermission = false;
      this.AreaSlot = -1;
      this.AreaValue = -1;
      this.TargetX = -1;
      this.TargetY = -1;
      this.AutoCombat = true;
      this.UnitSelected = -1;
      this.HideUnit = 1;
      this.OrderUnit = -1;
      this.TempHisUnit = -1;
      this.Zoom = 0;
      this.HandCard = -1;
      this.MapSelected = 0;
      this.TutOrder = -1;
      this.OldUnit = -1;
      this.TutX = (object) -1;
      this.TutY = (object) -1;
      this.overruleScreenResWidth = -1;
      this.overruleScreenResHeight = -1;
      this.TutMode = false;
      this.ButtonLoadMode = false;
      this.TutStep = 0;
      this.Volume = 50;
      this.Volume2 = 50;
      this.Screenshoton = false;
      this.Layout = 0;
      this.ShowLabel = true;
      this.ShowBase = true;
      this.TextInputString = "";
      this.ServerCookieValue = "";
      this.ShowUnderHQ = true;
      this.ShowSameHistorical = true;
      this.ShowMouseOver = false;
      this.PbemUserName = "";
      this.PbemSerial = "";
      this.PbemPassword = "";
      this.DoubleSize = false;
      this.DoubleSizePercentage = 200;
      this.pdfGenerated = "";
      this.AlternateMusic = false;
      this.UDSinputCounter = -1;
      this.dssLastDominant = -1;
      this.dssLastEngineAction = -1;
      this.dssLastHighlightId = -1;
      this.dssLastTrackId = -1;
      this.highGfxSpeedOn = false;
      this.layerUnits = true;
      this.inRandomScreen = false;
      this.ShowLISRange = false;
      this.useLeftRightClickMode = false;
      this.useLeftRightClickMode = true;
      this.dontShowAImoves = false;
      this.showAdvice = true;
      this.usePullAssets = true;
      this.usePullCities = true;
      this.usePullUnits = true;
      this.AutoDpiCheckDone = false;
      this.quickInterceptCombat = false;
      this.skipGfxDetail = false;
    }

    public EditClass(string filename)
    {
      this.AnswerText = new string[10];
      this.AnswerTextMouseOver = new string[10];
      this.TempValue = new MapMatrix2[1];
      this.TempValueSpecial = new MapMatrix2[1];
      this.TempValueSpecial2 = new MapMatrix2[1];
      this.TempValue2 = new MapMatrix2[1];
      this.TempValue3 = new MapMatrix2[1];
      this.TempValue4 = new MapMatrix2[1];
      this.TempAttack = new MapMatrix2Plus6[1];
      this.TempAI = new int[1, 1];
      this.TempAI2 = new int[1, 1];
      this.TempLos = new MapMatrix2[1];
      this.TempObstruct = new MapMatrix2[1];
      this.FuzzyPresumed = new MapMatrix2[1];
      this.FuzzyReal = new MapMatrix2[1];
      this.PossiblePull = new int[1, 1, 7];
      this.origPossiblePull = new int[1, 1, 7];
      this.tempGroupMoveUnr = new int[1];
      this.tempGroupMoveCameFrom = new CoordList[1];
      this.tempGroupMovePath = new CoordList[1];
      this.TempSup = new MapMatrix2[1];
      this.TempSupCameFrom = new MapMatrix2Coordinate[1];
      this.RemoveReinforce = new int[100];
      this.TempString = new MapMatrix2String[1];
      this.TempString2 = new MapMatrix2String[1];
      this.TempCameFrom = new MapMatrix2Coordinate[1];
      this.TempCoordList = new CoordList();
      this.TempCoordListLastMove = new CoordList();
      this.TempMovePathList = new CoordList();
      this.TempUnitList = new UnitList();
      this.HisOwner = new MapMatrix2[1];
      this.HisForce = new MapMatrix2[1];
      this.HisSFType = new MapMatrix2[1];
      this.HisHis = new MapMatrix2[1];
      this.HisDepth = new MapMatrix2[1];
      this.HisLossSFType = new int[1];
      this.HisLossAttacker = new int[1];
      this.HisLossOK = new int[1];
      this.HisLossDEAD = new int[1];
      this.HisLossSFType2 = new int[1];
      this.HisLossAttacker2 = new int[1];
      this.HisLossOK2 = new int[1];
      this.HisLossDEAD2 = new int[1];
      this.ServerCookieValue = "";
      this.PbemGameSetup = PbemGameSetupPhase.None;
      this.helpAlreadyOpened = false;
      this.systemPopup = false;
      this.highGfxSpeedOn = false;
      this.udsUnitOrderMode = 1;
      this.udsReturnFromPopup = false;
      this.udsLastCalledPopupEventNr = -1;
      this.udsManagementTabOverrideId = -1;
      this.udsViewMode2Override = -1;
      this.tempRenameString = "";
      this.tempRenameString2 = "";
      this.tempRenameString3 = "";
      this.uds_subtab = new int[10];
      this.uds_page = new int[10, 20];
      this.MiniMapOffset = 0;
      this.StartRdn = new int[2];
      this.StartXp = new int[2];
      this.StartMor = new int[2];
      this.StartEntr = new int[2];
      this.LoadNoNewEdit = false;
      this.NextTurnButtonPress = false;
      this.UDSinputKey = new string[1];
      this.UDSinputValue = new string[1];
      this.TempUDSinputKey = new string[1];
      this.TempUDSinputValue = new string[1];
      this.tempZoneTest = new int[1, 1];
      this.tempOtherTest = new int[1];
      this.tempOtherTestText = new string[1];
      this.UdsInsideTabOpenMode = false;
      this.TempFireListCacheSet = false;
      this.resourceVpCacheSet = false;
      this.WINDOW_DEBUG_MODE = false;
      this.AutoDpiCheckDone = false;
      this.Dc4_RightWindow_Expand1 = false;
      this.Dc4_RightWindow_Expand2 = false;
      this.Dc4_RightWindow_Expand3 = false;
      this.Dc4_RightWindow_Expand4 = false;
      this.Dc4_RightWindow_Expand5 = false;
      this.Dc4_RightWindow_Expand6 = false;
      this.Dc4_RightWindow_Expand7 = false;
      this.Dc4_RightWindow_Expand8 = false;
      this.Dc4_RightWindow_Expand9 = false;
      this.Dc4_Card_Select_Feedback = "";
      this.Dc4_temp_cardtab_cache = false;
      this.dc4_temp_warning1done = false;
      this.dc4_temp_warning2done = false;
      this.dc4_last_supply_x = -1;
      this.dc4_last_supply_y = -1;
      this.quickInterceptCombat = false;
      this.se1_map_data3cache_set = false;
      this.skipGfxDetail = false;
      this.initialSet();
      this.PencilType = 0;
      this.PrefShowFOW = true;
      this.OrderType = 0;
      this.maximumInterfaceSpace = false;
      this.UnitSelected = -1;
      this.TargetX = -1;
      this.Zoom = 0;
      this.TargetY = -1;
      this.MiniMap = new Bitmap(200, 150);
      this.MiniMap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      this.ShownWelcome = true;
      this.PaintShortcut1 = -1;
      this.PaintShortcut2 = -1;
      this.overruleScreenResWidth = -1;
      this.overruleScreenResHeight = -1;
      this.PaintShortcut3 = -1;
      this.SoundOn = true;
      this.AreaSlot = -1;
      this.OldUnit = -1;
      this.HideUnit = 1;
      this.OrderUnit = -1;
      this.AreaValue = -1;
      this.Volume = 50;
      this.Volume2 = 50;
      this.DoCardSlot = -1;
      this.mouseScreenLock = true;
      this.TutOrder = -1;
      this.TutMode = false;
      this.ButtonLoadMode = false;
      this.TutStep = 0;
      this.TextInputString = "";
      this.TutX = (object) -1;
      this.TutY = (object) -1;
      this.Layout = 0;
      this.TempHisUnit = -1;
      this.HandCard = -1;
      this.MapSelected = 0;
      this.CampaignRoomBitmap = -1;
      this.ServerCookieValue = "";
      this.PbemUserName = "";
      this.PbemSerial = "";
      this.PbemPassword = "";
      this.PbemEmail = "";
      this.allowMetrics = false;
      this.askedMetricsPermission = false;
      this.pdfGenerated = "";
      this.AlternateMusic = false;
      this.UDSinputCounter = -1;
      this.dssLastDominant = -1;
      this.dssLastEngineAction = -1;
      this.dssLastHighlightId = -1;
      this.dssLastTrackId = -1;
      this.layerUnits = true;
      this.inRandomScreen = false;
      this.ShowLISRange = false;
      this.dontShowAImoves = false;
      this.usePullAssets = true;
      this.usePullCities = true;
      this.usePullUnits = true;
      this.showAdvice = true;
      this.AutoDpiCheckDone = false;
      this.quickInterceptCombat = false;
      this.skipGfxDetail = false;
      if (File.Exists(filename))
      {
        StreamReader streamReader;
        try
        {
          streamReader = File.OpenText(filename);
          this.PrefShowFOW = Conversions.ToBoolean(streamReader.ReadLine());
          this.HexRasterOn = Conversions.ToBoolean(streamReader.ReadLine());
          this.HideAS = Conversions.ToBoolean(streamReader.ReadLine());
          try
          {
            this.SoundOn = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.SoundOn = true;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.IntroSoundOn = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.IntroSoundOn = true;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.AutoSave = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.AutoSave = false;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.StartWithHistory = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.StartWithHistory = false;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.Zoom = Conversions.ToInteger(streamReader.ReadLine());
            if (this.Zoom == -1)
              this.Zoom = 0;
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.Zoom = 0;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.SpreadUnit = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.SpreadUnit = false;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.Screenshoton = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.Screenshoton = false;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.CombatNumbers = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.CombatNumbers = false;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.Layout = Conversions.ToInteger(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.Layout = 0;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.RegimeColoring = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.RegimeColoring = false;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.TownInfo = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.TownInfo = true;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.ShowBase = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.ShowBase = true;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.ShowLabel = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.ShowLabel = true;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.PbemUserName = streamReader.ReadLine();
            this.PbemPassword = streamReader.ReadLine();
            this.PbemSerial = streamReader.ReadLine();
            this.PbemEmail = streamReader.ReadLine();
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.PbemUserName = "";
            this.PbemPassword = "";
            this.PbemEmail = "";
            ProjectData.ClearProjectError();
          }
          try
          {
            this.ShowUnderHQ = Conversions.ToBoolean(streamReader.ReadLine());
            this.ShowSameHistorical = Conversions.ToBoolean(streamReader.ReadLine());
            this.ShowMouseOver = Conversions.ToBoolean(streamReader.ReadLine());
            this.ShowHQPower = Conversions.ToBoolean(streamReader.ReadLine());
            this.ShowAirRange = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.ShowUnderHQ = true;
            this.ShowSameHistorical = true;
            this.ShowMouseOver = true;
            this.ShowHQPower = false;
            this.ShowAirRange = false;
            ProjectData.ClearProjectError();
          }
          if (Information.IsNothing((object) this.PbemUserName))
            this.PbemUserName = "";
          if (Information.IsNothing((object) this.PbemPassword))
            this.PbemPassword = "";
          if (Information.IsNothing((object) this.PbemEmail))
            this.PbemEmail = "";
          try
          {
            string str = streamReader.ReadLine();
            this.Volume = !Information.IsNothing((object) str) ? (int) Math.Round(Conversion.Val(str)) : 50;
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.Volume = 50;
            ProjectData.ClearProjectError();
          }
          try
          {
            string str = streamReader.ReadLine();
            this.Volume2 = !Information.IsNothing((object) str) ? (int) Math.Round(Conversion.Val(str)) : 50;
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.Volume2 = 50;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.PrefMinimalistCounter = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.PrefMinimalistCounter = false;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.DoubleSize = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.DoubleSize = false;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.allowMetrics = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.allowMetrics = false;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.HideUnit = Conversions.ToInteger(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.HideUnit = 0;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.AlternateMusic = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.AlternateMusic = false;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.askedMetricsPermission = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.askedMetricsPermission = false;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.DoubleSizePercentage = Conversions.ToInteger(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.DoubleSizePercentage = 200;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.PbemSteam = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.PbemSteam = false;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.highGfxSpeedOn = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.highGfxSpeedOn = false;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.CombatTextual = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.CombatTextual = false;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.ShowLISRange = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.ShowLISRange = false;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.AutoCombat = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.AutoCombat = true;
            ProjectData.ClearProjectError();
          }
          if (this.DoubleSizePercentage < 100)
            this.DoubleSizePercentage = 100;
          if (this.DoubleSize)
          {
            if (this.DoubleSizePercentage < 125)
              this.DoubleSizePercentage = 125;
          }
          try
          {
            this.maximumInterfaceSpace = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.maximumInterfaceSpace = false;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.useLeftRightClickMode = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.useLeftRightClickMode = false;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.overruleScreenResWidth = Conversions.ToInteger(streamReader.ReadLine());
            this.overruleScreenResHeight = Conversions.ToInteger(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.overruleScreenResWidth = -1;
            this.overruleScreenResHeight = -1;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.BlockAdvice = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.BlockAdvice = false;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.mouseScreenLock = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.mouseScreenLock = true;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.showAdvice = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.showAdvice = true;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.dontShowAImoves = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.dontShowAImoves = false;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.usePullAssets = Conversions.ToBoolean(streamReader.ReadLine());
            this.usePullCities = Conversions.ToBoolean(streamReader.ReadLine());
            this.usePullUnits = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.usePullAssets = true;
            this.usePullCities = true;
            this.usePullUnits = true;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.AutoDpiCheckDone = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.AutoDpiCheckDone = false;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.quickInterceptCombat = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.quickInterceptCombat = false;
            ProjectData.ClearProjectError();
          }
          try
          {
            this.skipGfxDetail = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.skipGfxDetail = false;
            ProjectData.ClearProjectError();
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          this.initialSet();
          int num = (int) Interaction.MsgBox((object) ("Prefs loading issue: '" + exception.Message + "'.. you can continue game however"), Title: ((object) "Shadow Empire : Planetary Conquest"));
          ProjectData.ClearProjectError();
        }
        streamReader.Close();
      }
      else
      {
        int num1 = (int) Interaction.MsgBox((object) "Prefs not found and could not be loaded at all. you can continue game however", Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
      if (this.PbemSerial.Length < 19)
        this.PbemSerial = "0000-0000-0000-0000";
      this.PbemSteam = true;
      this.StartWithHistory = false;
      this.useLeftRightClickMode = true;
    }

    public void Save(string filename)
    {
      StreamWriter text = File.CreateText(filename);
      text.WriteLine(this.PrefShowFOW);
      text.WriteLine(this.HexRasterOn);
      text.WriteLine(this.HideAS);
      text.WriteLine(this.SoundOn);
      text.WriteLine(this.IntroSoundOn);
      text.WriteLine(this.AutoSave);
      text.WriteLine(this.StartWithHistory);
      text.WriteLine(this.Zoom);
      text.WriteLine(this.SpreadUnit);
      text.WriteLine(this.Screenshoton);
      text.WriteLine(this.CombatNumbers);
      text.WriteLine(this.Layout);
      text.WriteLine(this.RegimeColoring);
      text.WriteLine(this.TownInfo);
      text.WriteLine(this.ShowBase);
      text.WriteLine(this.ShowLabel);
      text.WriteLine(this.PbemUserName);
      text.WriteLine(this.PbemPassword);
      text.WriteLine(this.PbemSerial);
      text.WriteLine(this.PbemEmail);
      text.WriteLine(this.ShowUnderHQ);
      text.WriteLine(this.ShowSameHistorical);
      text.WriteLine(this.ShowMouseOver);
      text.WriteLine(this.ShowHQPower);
      text.WriteLine(this.ShowAirRange);
      text.WriteLine(this.Volume);
      text.WriteLine(this.Volume2);
      text.WriteLine(this.PrefMinimalistCounter);
      text.WriteLine(this.DoubleSize);
      text.WriteLine(this.allowMetrics);
      text.WriteLine(this.HideUnit);
      text.WriteLine(this.AlternateMusic);
      text.WriteLine(this.askedMetricsPermission);
      text.WriteLine(this.DoubleSizePercentage);
      text.WriteLine(this.PbemSteam);
      text.WriteLine(this.highGfxSpeedOn);
      text.WriteLine(this.CombatTextual);
      text.WriteLine(this.ShowLISRange);
      text.WriteLine(this.AutoCombat);
      text.WriteLine(this.maximumInterfaceSpace);
      text.WriteLine(this.useLeftRightClickMode);
      text.WriteLine(this.overruleScreenResWidth);
      text.WriteLine(this.overruleScreenResHeight);
      text.WriteLine(this.BlockAdvice);
      text.WriteLine(this.mouseScreenLock);
      text.WriteLine(this.showAdvice);
      text.WriteLine(this.dontShowAImoves);
      text.WriteLine(this.usePullAssets);
      text.WriteLine(this.usePullCities);
      text.WriteLine(this.usePullUnits);
      text.WriteLine(this.AutoDpiCheckDone);
      text.WriteLine(this.quickInterceptCombat);
      text.WriteLine(this.skipGfxDetail);
      text.Close();
    }

    public delegate void AfterPopUpRefresh();
  }
}
