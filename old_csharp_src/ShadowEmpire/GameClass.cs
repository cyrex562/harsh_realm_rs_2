// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.GameClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using WindowsApplication1.My;

namespace WindowsApplication1
{
  public class GameClass
  {
    public string AppPath;
    public string AppPath_SAVEGAMES;
    public bool UseSlimDX;
    public int ScreenWidth;
    public int ScreenHeight;
    public int RealScreenWidth;
    public int RealScreenHeight;
    public int StartupScreenWidth;
    public int StartupScreenHeight;
    public bool SuperAdminRights;
    public bool UserTestMode;
    public bool UserDebugger;
    public bool noDrawNoFocus;
    public bool EditorBlock;
    public bool EditorBlockSimple;
    public string MetricsURL;
    public string Metrics2URL;
    public string EditorName;
    public string AlternativeGraphics;
    public int dlc_Counter;
    public int[] dlc_ID;
    public const int dlc_SE_Astro = 1;
    public const int dlc_SE_Navy = 2;
    public int modlib_Counter;
    public string[] modlib_Name;
    public string[] modlib_Designer;
    public string[] modlib_Description;
    public int[] modlib_Version;
    public string[] modlib_Filename;
    public bool[] modlib_Flagged;
    public bool IsWin10;
    public const int MAXROUND = 10;
    public bool theaterThreadBlock;
    public bool AllowHeightMap;
    public const string GAMENAME = "Shadow Empire : Planetary Conquest";
    public bool EmpireStyle;
    public bool HighGraphicsSpeedPossible;
    public bool useModLib;
    public const int REMOVEWINDOW = 1;
    public const int OPENWINDOW = 2;
    public const int REFRESHWINDOW = 4;
    public const int NEWSCREEN = 3;
    public const int NEWPOPUPSCREEN = 5;
    public const int CLOSEPOPUPSCREEN = 6;
    public const int REPAINTWINDOW = 7;
    public const int THEWINDOW = 1;
    public const int LEFTWINDOW = 2;
    public const int RIGHTWINDOW = 3;
    public const int MIDDLEWINDOW = 4;
    public const int DOWNWINDOW = 5;
    public const int EDITMENUWINDOW = 6;
    public const int MIDDOWNWINDOW = 7;
    public const int RESWINDOW = 8;
    public const int TABSWINDOW = 9;
    public const int LANDSCAPETYPEWINDOW = 11;
    public const int MAPWINDOW = 12;
    public const int EDITOPTIONSWINDOW = 13;
    public const int ROADTYPEWINDOW = 14;
    public const int REGIMEWINDOW = 15;
    public const int SFTYPEWINDOW = 16;
    public const int EDITUNITWINDOW = 17;
    public const int PLAYMAINWINDOW = 18;
    public const int MAINLOOPWINDOW = 19;
    public const int PLAYEXTRAWINDOW = 20;
    public const int LOCTYPEWINDOW = 21;
    public const int PEOPLEWINDOW = 22;
    public const int GENERALWINDOW = 23;
    public const int ITEMTYPEWINDOW = 24;
    public const int PRODWINDOW = 25;
    public const int LOCWINDOW = 26;
    public const int NEWSFWINDOW = 27;
    public const int NEWUNITWINDOW = 28;
    public const int INFOWINDOW = 29;
    public const int TRANSFERWINDOW = 30;
    public const int COMBATSTATUSWINDOW = 31;
    public const int COMBATRESULTWINDOW = 32;
    public const int RIVERTYPEWINDOW = 33;
    public const int BRIDGEWINDOW = 34;
    public const int STRATEGICWINDOW = 35;
    public const int RESEARCHWINDOW = 37;
    public const int PLAYRESEARCHWINDOW = 38;
    public const int DIPWINDOW = 39;
    public const int CONSTRUCTWINDOW = 40;
    public const int HISTORYWINDOW = 41;
    public const int EVENTWINDOW = 42;
    public const int SFWINDOW = 43;
    public const int ORDERWINDOW = 44;
    public const int PREFSWINDOW = 45;
    public const int STATSWINDOW = 46;
    public const int PEOPLETRANSFERWINDOW = 47;
    public const int BUILDWINDOW = 48;
    public const int INTROWINDOW = 49;
    public const int RANDOMWINDOW = 50;
    public const int AIRSUPPLYWINDOW = 51;
    public const int PRODFLAPWINDOW = 52;
    public const int BIGMINIMAPWINDOW = 53;
    public const int WELCOMEWINDOW = 54;
    public const int INITIALMENUWINDOW = 55;
    public const int HISTORICWINDOW = 56;
    public const int ACTIONCARDWINDOW = 57;
    public const int CONNECTIONWINDOW = 58;
    public const int NEWUNIT2WINDOW = 59;
    public const int STRINGLISTWINDOW = 60;
    public const int OFFICERPOOLWINDOW = 61;
    public const int OFFICERINFOWINDOW = 62;
    public const int CHANGEMODELWINDOW = 63;
    public const int MODELDESIGNERWINDOW = 64;
    public const int DESIGNSFWINDOW = 65;
    public const int RESOURCEWINDOW = 66;
    public const int RESOURCEWINDOW2 = 67;
    public const int ORDERWINDOW2 = 68;
    public const int PLAYEXTRAWINDOW2 = 69;
    public const int TABBRIEFING2 = 70;
    public const int TABSTATS2 = 71;
    public const int TABOOB2 = 72;
    public const int TABREPORTS2 = 73;
    public const int TABCARDS2 = 74;
    public const int TABSMAP2 = 75;
    public const int TABSMINI = 76;
    public const int STRATEGICWINDOW2 = 76;
    public const int TABSPREFS = 77;
    public const int SYSTEMMESSAGEWINDOW = 78;
    public const int INTROWINDOW2 = 49;
    public const int HISTORYWINDOW2 = 80;
    public const int HISTORYORDERWINDOW = 81;
    public const int COMBATDETAILWINDOW = 82;
    public const int CREDITSWINDOW = 83;
    public const int COMBATWINDOW = 84;
    public const int WELCOMEWINDOW2 = 85;
    public const int EDITHISWINDOW = 86;
    public const int OFFICERPOOLWINDOW2 = 87;
    public const int NEWUNITWINDOW2 = 88;
    public const int NEWUNIT2WINDOW2 = 89;
    public const int CHANGEMODELWINDOW2 = 90;
    public const int COREPBEMWINDOW = 91;
    public const int PBEMINITIALIZEWINDOW = 92;
    public const int LIBRARYWINDOW = 93;
    public const int SIMPLEEDITOPTIONSWINDOW = 94;
    public const int SIMPLEEDITDASHBOARDWINDOW = 95;
    public const int SIMPLEEDITLIBRARYWINDOW = 96;
    public const int SIMPLELIBIMPORTPOPUP = 97;
    public const int SIMPLEEDITMAPWINDOW = 98;
    public const int SIMPLEEDITUNITWINDOW = 99;
    public const int SIMPLEDITREGIMEWINDOW = 100;
    public const int SIMPLEDITTABLEWINDOW = 101;
    public const int SIMPLEMAPWINDOW = 102;
    public const int SIMPLETROOPTYPEWINDOW = 103;
    public const int SIMPLEHISWINDOW = 104;
    public const int SIMPLEOFFICERWINDOW = 105;
    public const int BIGMESSAGEWINDOW = 106;
    public const int SIMPLEMAPDASHBOARDWINDOW = 107;
    public const int SIMPLEMAPOPTIONSWINDOW = 108;
    public const int SIMPLEDEBUGWINDOW = 109;
    public const int TABHELP = 110;
    public const int SIMPLEPREFSWINDOW = 111;
    public const int SIMPLEMAPREPLACEMENTWINDOW = 112;
    public const int TABMANAGEMENT = 113;
    public const int RANDOMTOP = 114;
    public const int RANDOMMIDDLE = 115;
    public const int RANDOMBOTTOM = 116;
    public const int COMBATSELECTWINDOW = 117;
    public const int UDSUNITOPSWINDOW = 118;
    public const int ADVICEWINDOW = 119;
    public const int LISTRAFFICWINDOW = 120;
    public const int SUPPLYLAYERWINDOW = 121;
    public const int SSEVENTPICS = 122;
    public const int SSSMALLGFX = 123;
    public const int FIRSTSCREEN = 1;
    public const int MAINEDITSCREEN = 2;
    public const int PLAYSCREEN = 3;
    public const int MAINLOOPSCREEN = 4;
    public const int BATTLESCREEN = 5;
    public const int HISTORYSCREEN = 6;
    public const int EVENTSCREEN = 7;
    public const int SFSCREEN = 8;
    public const int STATSSCREEN = 9;
    public const int MESSAGEPOPUPSCREEN = 10;
    public const int PLAYSCREEN2 = 11;
    public const int FIRSTSCREEN2 = 12;
    public const int MAINLOOPSCREEN2 = 13;
    public const int MESSAGEPOPUPSCREEN2 = 14;
    public const int SFSCREEN2 = 15;
    public const int HISTORYSCREEN2 = 16;
    public const int SIMPLEEDITSCREEN = 17;
    public const int SIMPLETROOPTYPESCREEN = 18;
    public const int SIMPLEHISSCREEN = 19;
    public const int SIMPLEOFFICERSCREEN = 20;
    public const int SIMPLEMAPSCREEN = 21;
    public const int DYNAMICCINEMATICSSCREEN = 22;
    public const int RANDOMSCREEN2 = 23;
    public const int MANAGEMENTSCREEN = 24;
    public const int SIMPLESSSCREEN = 25;
    public int BUTTON1;
    public int TUTARROW;
    public int BUTTON2;
    public int BUTTON3;
    public int BUTTONUP;
    public int BUTTONDOWN;
    public int BUTTON4;
    public int BUTTON5;
    public int BUTTONBLOCK;
    public int BUTTONCHANGEMODEL;
    public int BUTTONMODELDESIGNER;
    public int BUTTONFLAGGED;
    public int BUTTONUNFLAGGED;
    public int BUTTONPLUS;
    public int BUTTONKILL;
    public int BUTTONDRAW;
    public int BUTTONLONG;
    public int BUTTONLONGHIGH;
    public int TEMP0;
    public int TEMP1;
    public int NOHEX;
    public int SELECTEDHEX;
    public int WHITEHEX;
    public int DEFAULTCOUNTER;
    public int BUTTONMOVE;
    public int BUTTONNEXT;
    public int BUTTONHQPROD;
    public int BUTTONHQUNIT;
    public int BUTTONPROD;
    public int BUTTONRECRUIT;
    public int BUTTONSF;
    public int BUTTONITEMS;
    public int BUTTONNEWSF;
    public int MARCBUTBARFRAME;
    public int BACKGROUND1MARC;
    public int BACKGROUND1MARC2;
    public int BACKTUT;
    public int BUTTONSTATS;
    public int BUTTONGIVEUNIT;
    public int BUTTONGIVEHEX;
    public int BUTTONREPORT;
    public int BUTTONNEWUNIT;
    public int NEUTRAL;
    public int NEUTRALHIGH;
    public int BUTTONTRANSFER;
    public int BUTTONATTACK;
    public int BUTTONARTATTACK;
    public int BUTTONSEAATTACK;
    public int BUTTONSEAARTATTACK;
    public int BUTTONMOVE2;
    public int BUTTONSTRATEGIC2;
    public int BUTTONAIRATTACK;
    public int BUTTONINTERDICT;
    public int BUTTON25;
    public int BUTTON50;
    public int BUTTON75;
    public int BUTTON100;
    public int BUTTONLEFT;
    public int BUTTONRIGHT;
    public int BUTTONLANDCAP;
    public int BUTTONSEACAP;
    public int BUTTONAIRCAP;
    public int BUTTONSTRATEGIC;
    public int BUTTONMAKEHQ;
    public int MAINFRAME;
    public int MAINBACKGROUND;
    public int BUTTONPARADROP;
    public int BUTTONLOAD;
    public int BUTTONHEXUNIT2;
    public int BUTTONUNLOAD;
    public int BUTTONPOOL;
    public int BUTTONNEWUNIT2;
    public int BUTTONREMOVEOFFICER;
    public int BUTTONASSIGNOFFICER;
    public int BUTTONBUYOFFICER;
    public int BUTTONDIP;
    public int BUTTONRESEARCH;
    public int BUTTONCONSTRUCT;
    public int BUTTONBUILDROAD;
    public int BUTTONBLOWBRIDGE;
    public int BUTTONBUILDLOCATION;
    public int BUTTONUPGRADELOCATION;
    public int BUTTONREPAIRLOCATION;
    public int BUTTONHISTORY;
    public int ATTACKART2;
    public int ATTACK0;
    public int ATTACK1;
    public int ATTACK2;
    public int ATTACK3;
    public int ATTACK4;
    public int ATTACK5;
    public int ATTACKART;
    public int ATTACKAMPH;
    public int ATTACKPARADROP;
    public int ATTACKAIR;
    public int SUPPLIESSYMBOL;
    public int BUTTONDISBAND;
    public int BUTTONSAVE;
    public int BUTTONQUIT;
    public int QUICKINFO;
    public int OFFICERINFO;
    public int BUTTONNONO;
    public int BUTTONLANDCAP2;
    public int BUTTONSEACAP2;
    public int PAPER1;
    public int BUTTONAIRCAP2;
    public int BUTTONMARC1;
    public int BUTTONMARC1b;
    public int EXTRABACKGROUND;
    public int MINIMAPBACKGROUND;
    public int HEXINFOBACKGROUND;
    public int OKBALL;
    public int CANCELBALL;
    public int BACKGROUND2MARC;
    public int LISTUP;
    public int LISTDOWN;
    public int LISTBLOCK;
    public int QUESTIONBALL;
    public int BACKGROUND3MARC;
    public int BACKGROUND5MARC;
    public int MARCINTRO1;
    public int MARCINTRO2;
    public int TARGETHEX;
    public int BUTTONPREFS;
    public int WHITEFLAG;
    public int BUTTONGUIUP;
    public int BUTTONGUIDOWN;
    public int PAPERBACK1;
    public int PAPERBACK2;
    public int PAPERBACK3;
    public int SLITHERINE;
    public int BUTTONCOPY;
    public int BUTTONPASTE;
    public int BUTTONSTATISTICS;
    public int BUTTONDISBANDTROOPS;
    public int BUTTONDISBANDITEMS;
    public int BUTTONAIRRECON;
    public int BUTTONPEOPLETRANSFER;
    public int BACKBUTTON;
    public int BUTTONQUITSAVE;
    public int BUTTONSUPPLYON;
    public int BUTTONSUPPLYOFF;
    public int HEXRASTER;
    public int BUYBUTTON;
    public int BLOWLOCATIONBUTTON;
    public int DEFAULTCOUNTERSMALL;
    public int[] PERCENT;
    public int PRODSUPPLY;
    public int PRODPP;
    public int PERCENTX;
    public int SHADEDHEX;
    public int BUTTONAIRSUPPLY;
    public int[] BORDER;
    public int[] MAPBORDER;
    public int[] ZONEBORDER;
    public int[] LIGHTZONEBORDER;
    public int LOGIN;
    public int[] NOBRIDGE;
    public int BUTTONLEFT2;
    public int BUTTONRIGHT2;
    public int BLACKHEX;
    public int FIRSTHEX;
    public int PIN1;
    public int PIN1SHADE;
    public int PIN2;
    public int PIN2SHADE;
    public int PIN3;
    public int PIN3SHADE;
    public int PIN4;
    public int PIN4SHADE;
    public int PIN5;
    public int PIN5SHADE;
    public int PIN6;
    public int PIN6SHADE;
    public int PIN7;
    public int PIN7shade;
    public int BOTTOMRED;
    public int BACKGROUND4;
    public int BOTTOMGREEN;
    public int BOTTOMBLACK;
    public int BUTTONSURRENDER;
    public int REDOVAL;
    public int BLUEOVAL;
    public int BROWNOVAL;
    public int EDITDRAW;
    public int EDITPOINTER;
    public int EDITPAINT;
    public int ADV1;
    public int ADV2;
    public int ADV3;
    public int BUTTONHEXUNIT;
    public int BUTTONHEX;
    public int BUTTONSTEVE1;
    public int BUTTONSTEVE1b;
    public int LONGBUTTON;
    public int LONGBUTTONHIGH;
    public int NONEBUTTON;
    public int ALLBUTTON;
    public int SYSTEM1;
    public int SYSTEM1B;
    public int SYSTEM2;
    public int SYSTEM2B;
    public int EMPTYSLOT;
    public int VSLIDER;
    public int VSLIDERB;
    public int BUTTONHEXINFO;
    public int BUTTONHEXINFO2;
    public int ACTIONCARD;
    public int ACTIONCARD2;
    public int ACTIONFRAME;
    public int BUTTONLEFTB;
    public int BUTTONLEFT2B;
    public int BUTTONRIGHTB;
    public int BUTTONRIGHT2B;
    public int STATSGRADIENT;
    public int REDBUTTON;
    public int COMBATGRADIENT;
    public int SLIDER1;
    public int SLIDER2;
    public int MGSPLASH;
    public int VRSPLASH;
    public int BLACKOVAL;
    public int BLACKBOX;
    public int BUTTONOFFICER;
    public int TEXTCLOUD;
    public int BUTTONZOOMIN;
    public int MINICARD;
    public int MINICARDBIG;
    public int DEFAULTCOUNTERBIG;
    public int BUTTONZOOMOUT;
    public int BUTTONSTACKEDUNIT;
    public int BUTTONSPREADUNIT;
    public int BUTTONDESIGNSF;
    public int FRAME1;
    public int RADIO1;
    public int RADIO2;
    public int RADIO1A;
    public int RADIO2A;
    public int LISTBAR;
    public int LISTBACK;
    public int LOGOFLATTINY;
    public int EXPLOSION;
    public int TUTHEX;
    public int SMALLCHAR1;
    public int SMALLCHAR2;
    public int ICONSUP2;
    public int ICONSTR;
    public int ICONFLAG;
    public int ICONEN1;
    public int ICONEN2;
    public int ICONMO1;
    public int ICONMO2;
    public int ICONEX1;
    public int ICONEX1_VARIED;
    public int ICONEX2;
    public int ICONRD1;
    public int ICONRD2;
    public int ICONSU1;
    public int ICONAP1;
    public int ICONIN1;
    public int FOGSHEET;
    public int SHROWDSHEET;
    public Bitmap NEUTRALREGIMEBACK;
    public Bitmap CARD1;
    public Bitmap CARD2;
    public Bitmap CARD3;
    public Bitmap CARD4;
    public Bitmap CARD5;
    public Bitmap CARD1B;
    public Bitmap CARD2B;
    public Bitmap CARD3B;
    public int MARCOPTSLOTS;
    public int LEATHER;
    public int MARCTAB;
    public int BUTTONSTEVE2;
    public int ORNAMENT1;
    public int BUTTONBLUE;
    public int BUTTONYELLOW;
    public int ORNAMENT2;
    public int ORNAMENT3A;
    public int ORNAMENT3B;
    public int ORNAMENT4;
    public int BUTTONSTEVE2B;
    public int MARCTABBUTTON;
    public int MARCTABBUTTONHIGH;
    public int MARCARROW;
    public int COMBATART1;
    public int COMBATART2;
    public int MARCMESFRAME;
    public int MARCTOPBAR;
    public int MARCOFFICER;
    public int MARCSCOPE;
    public int MARCBUTBAR;
    public int MARCBUTBARHISTORY;
    public int MARCBOTBAR;
    public int MARCLARGETAB;
    public int MARCBIGBOTTOMTAB;
    public int ATTACKREINFORCEMENTS;
    public int MARCBLOCK;
    public int MARCBLOCKHIGH;
    public int MARCBLOCKPRESSED;
    public int MARCBLOCK2;
    public int MARCBLOCKHIGH2;
    public int MARCBLOCKPRESSED2;
    public int BUTTONLEFTBIG;
    public int BUTTONRIGHTBIG;
    public int BUTTONRIGHT2BIG;
    public int BUTTONLEFT2BIG;
    public int VSLIDERBIG;
    public int WARNINGTRIANGLE;
    public int ICONSUPATT;
    public int ICONSUPDEF;
    public int ICONHQPOW;
    public int ICONEP;
    public int ICONVIGOR;
    public int ICON;
    public int HEXMASKBIG;
    public int HEXMASKMEDIUM;
    public int HEXMASKSMALL;
    public int MARCCARD1A;
    public int MARCCARD1B;
    public int MARCCARD1C;
    public int MARCCARD2A;
    public int MARCCARD2B;
    public int MARCCARD2C;
    public int MARCCARD3A;
    public int MARCCARD3B;
    public int MARCCARD3C;
    public int MARCCARD4A;
    public int MARCCARD4B;
    public int MARCCARD4C;
    public int MARCCARD6A;
    public int MARCCARD6B;
    public int MARCCARD6C;
    public int SECARDOUTLINE;
    public int BACKGROUND4MARC;
    public int MARCCARD5A;
    public int MARCCARD5B;
    public int MARCCARD5C;
    public int MARCBACK1;
    public int MARCBACK1B;
    public int MARCBACK2;
    public int MARCBACK2B;
    public int MARCBACK3;
    public int MARCBACK3B;
    public int MARCBACK4;
    public int MARCBACK4B;
    public int SUPPLYBLOCK;
    public int TRAFFIC1;
    public int TRAFFIC2;
    public int TRAFFIC3;
    public int TRAFFIC4;
    public int EYE1;
    public int EYE2;
    public int EYE3;
    public int EYE4;
    public int FIRELISTICONS;
    public int COMBATICONS;
    public int DC4COUNTER;
    public int FRONTLINETILESET;
    public int[] FOG;
    public int[] SHROWD;
    public int ARROWSHEET;
    public int WHITEHEXTRANS;
    public int WHITEHEXTRANS2;
    public int WHITEHEXTRANS3;
    public int LINES;
    public int LINESFRAME;
    public int DOWN20;
    public int UP20;
    public int ROUNDBALL;
    public int RESEARCHOVERPRINT;
    public int[,,,,,] SPRITE64;
    public int[,,,,,] ARROW64;
    public int[] SHEETX;
    public int[] SHEETY;
    public int[] NATO;
    public int HEIGHTMAP_BEACH;
    public int HEIGHTMAP_SHADOW1;
    public int HEIGHTMAP_SHADOW2;
    public int HEIGHTMAP_SHADOW3;
    public int HEIGHTMAP_LINE1;
    public int HEIGHTMAP_LINE2;
    public int HEIGHTMAP_LINE3;
    public int HEIGHTMAP_TRANS_SHADOW;
    public int HEIGHTMAP_TRANS_LINE;
    public int SE1_FLAGPANEL;
    public int SE1_RESOURCEBAR_BOTTOM;
    public int SE1_RESOURCEBAR_LEFT;
    public int SE1_RESOURCEBAR_RIGHT;
    public int SE1_RESOURCEBAR_TAB;
    public int SE1_RESOURCEBAR_VARBOX;
    public int SE1_ICONS;
    public int SE1_ARROW1;
    public int SE1_ARROW2;
    public int SE1_ARROW3;
    public int SE1_ARROW4;
    public int SE1_ARROWBUTTON;
    public int SE1_ARROWBUTTONHIGH;
    public int SE1_ICONHIGHLIGHT;
    public int SE1_MAINFRAME_LEFT;
    public int SE1_MAINFRAME_LEFT2;
    public int SE1_MAINFRAME_RIGHT;
    public int SE1_MAINFRAME_RIGHT2;
    public int SE1_MAINFRAME_MIDDLE;
    public int SE1_ORDERBAR_TAB1LOW;
    public int SE1_ORDERBAR_TAB1HIGH;
    public int SE1_ORDERBAR_TAB2LOW;
    public int SE1_ORDERBAR_TAB2HIGH;
    public int SE1_SIDEBAR_TEXTURE;
    public int SE1_SIDEBAR_TABLEFT;
    public int SE1_SIDEBAR_TABRIGHT;
    public int SE1_SIDEBAR_EXITLEFT;
    public int SE1_SIDEBAR_EXITRIGHT;
    public int SE1_BLACKGRADIENT;
    public int SE1_ZONEFRAME;
    public int SE1_ZONEBUTTONSMALL;
    public int SE1_ZONEBUTTONSMALLHIGH;
    public int SE1_ZONEBUTTON;
    public int SE1_ZONEBUTTONHIGH;
    public int SE1_ZONEPAPERFRAME1;
    public int SE1_ZONEPAPERFRAME1air;
    public int SE1_ZONEPAPERFRAME2;
    public int SE1_ZONEPAPERFRAME3;
    public int SE1_ZONEPAPERFRAME4;
    public int SE1_QUICKHEXFRAME;
    public int SE1_QUICKREGIMEFRAME;
    public int SE1_BOTTOMORNAMENTALLEFT;
    public int SE1_BOTTOMORNAMENTALRIGHT;
    public int SE1_VARBOX2;
    public int SE1_VARBOX3;
    public int SE1_VARBOX4;
    public int SE1_QUICKREGIMEHEADER;
    public int SE1_QUICKREGIMEPAPERFRAME;
    public int SE1_SIDEBAR_TOPSHADOWLEFT;
    public int SE1_SIDEBAR_TOPSHADOWRIGHT;
    public int SE1_UNITFRAME;
    public int SE1_UNITBED;
    public int SE1_UNITBEDHIGH;
    public int SE1_TROOPFRAME;
    public int SE1_BOTTOMPAGEBUTTON;
    public int SE1_BOTTOMPAGEBUTTONHIGH;
    public int SE1_VARBOX5;
    public int SE1_VARBOX5HIGH;
    public int SE1_QUICKUNITFRAME;
    public int SE1_UNITPAPERFRAME1;
    public int SE1_ASSETBACKGROUND;
    public int SE1_ASSETBORDER;
    public int SE1_ASSETBORDERCORNER;
    public int SE1_ASSETBORDERHIGH;
    public int SE1_ASSETFRAME;
    public int SE1_ITEMFRAME;
    public int SE1_ITEMBOX;
    public int SE1_ITEMBOXCLOSED;
    public int SE1_ITEMBACKGROUND;
    public int SE1_ITEMBOXPROBLEM;
    public int SE1_SIDEBARHEADER;
    public int SE1_ORDERBUTTON;
    public int SE1_ORDERBUTTONPRESSED;
    public int SE1_SIDEBAR_VARBOX;
    public int SE1_SIDEBAR_VARBOX_LONG;
    public int SE1_PAPER1;
    public int SE1_PAPER2;
    public int SE1_PAPER3;
    public int SE1_REGIMEFRAME;
    public int SE1_CLOSEDPANEL;
    public int SE1_PORTRAITBACKGROUND;
    public int SE1_PORTRAITPAPER;
    public int SE1_PAPERCLIP;
    public int SE1_PORTRAITPAPER2;
    public int SE1_PORTRAITBACKGROUNDFACTIONLEADER;
    public int SE1_MULTICARD;
    public int SE1_BACKGROUNDLOOP;
    public int SE1_SUPERIMPOSEBACKGROUND;
    public int SE1_COMPLEXFRAME;
    public int SE1_COMBATBAR1;
    public int SE1_COMBATBAR2;
    public int SE1_COMBATBLOCK1;
    public int SE1_COMBATBLOCK2;
    public int SE1_COMBATBLOCK1B;
    public int SE1_COMBATBLOCK2B;
    public int SE1_COMBATBLOCK3;
    public int SE1_COMBAT_DEAD;
    public int SE1_COMBAT_SURRENDER;
    public int SE1_COMBAT_RETREATED;
    public int SE1_COMBAT_RETREATING;
    public Color seColWhite;
    public Color seColYellow;
    public Color seColRed;
    public Color seColGreen;
    public Color seColGray;
    public Color seColDelegated;
    public Color seColBrown;
    public Color seColBlue;
    public Color seColTW;
    public int BUTTONSMALL;
    public int BUTTONSMALLHIGH;
    public int MARCLEFTBAR;
    public int MARCRIGHTBAR;
    public int MARCTOPBARDIGITAL;
    public int UDSBUTLONG;
    public int UDSBUTLONGHIGH;
    public int UDSRADIO;
    public int UDSRADIO2;
    public int UDSRADIOHIGH;
    public int UDSRADIO2HIGH;
    public int UDSSMALLRADIO;
    public int UDSSMALLRADIO2;
    public int UDSSMALLRADIOHIGH;
    public int UDSSMALLRADIO2HIGH;
    public int UDSBUT2LONG;
    public int UDSBUT2LONGHIGH;
    public DataClass Data;
    public CustomBitmapClass CustomBitmapObj;
    public HandyFunctionsclass HandyFunctionsObj;
    public CombatClass TempCombat;
    public ProcessingClass ProcessingObj;
    public AIClass AIObj;
    public NewAIClass NewAIObj;
    public DC2AIClass DC2AIObj;
    public EventRelatedClass EventRelatedObj;
    public EditClass EditObj;
    public int ModIntroType;
    public string ModNatoCounters;
    public string ModScenarioDir;
    public string ModSoundDir;
    public string ModBackgroundScreenName;
    public int ModBackgroundScreenBmp;
    public string ModSystemGraphicsDirectory;
    public string ModOpeningSoundtrack;
    public string ModExtraSound;
    public string ModScenario;
    public int ModCounter;
    public int[] ModButSize;
    public int[] ModButX;
    public int[] ModButY;
    public string[] ModButText;
    public int[] ModButActive;
    public int[] ModButType;
    public string[] ModButDatastring;
    public string[] ModButDatastring2;
    public int ModGfxReplaceCounter;
    public string[] ModGfxReplaceS1;
    public string[] ModGfxReplaceS2;
    public int CornerX;
    public int CornerY;
    public int SelectX;
    public int SelectY;
    public Bitmap MapFrame1;
    public Bitmap MapFrame2;
    public Bitmap MapFrame3;
    public Bitmap MapFrame4;
    public Bitmap LeftFrame1;
    public Bitmap LeftFrame2;
    public Bitmap LeftFrame3;
    public Bitmap LeftFrame4;
    public Color GameCol1;
    public Color GameCol2;
    public Color GameCol3;
    public Color GameCol4;
    public Color GameCol5;
    public Color GameCol6;
    public Color GameCol7;
    public Color GameCol8;
    public Color GameCol9;
    public Color GameColPen1;
    public Font GameFont1;
    public Font GameFont2;
    public Font GameFont3;
    public Font gamefont1b;
    public Font gamefont2b;
    public Font MarcFont1;
    public Font MarcFont2;
    public Font MarcFont3;
    public Font MarcFont4;
    public Font MarcFont4b;
    public Font marcFont18;
    public Font marcFont17;
    public Font MarcFont5;
    public Font MarcFont6;
    public Font MarcFont16;
    public Font seFont1;
    public Font VicFont1;
    public Font VicFont2;
    public Font VicFont3;
    public Font VicFont4;
    public Font VicFont5;
    public Font VicFont6;
    public Font VicFont7;
    public Font VicFont8;
    public Font MarcFont7;
    public Font MarcFont8;
    public Font MarcFont8b;
    public Font MarcFont8c;
    public Font MarcFont9;
    public Font MarcFont10;
    public Font MarcFont11;
    public Font MarcFont11b;
    public Font MarcFont12;
    public Font MarcFont13;
    public Font MarcFont14;
    public Font MarcFont14b;
    public Font MarcFont15;
    public Color MarcCol1;
    public Color MarcCol2;
    public Color MarcCol3;
    public Color MarcCol4;
    public Color MarcCol5;
    public Color MarcCol6;
    public Color MarcCol7;
    public Color VicColor1;
    public Color VicColor2;
    public Color VicColor3;
    public Color VicColor6;
    public Color VicColor4;
    public Color VicColor5;
    public Color VicColor8;
    public Color viccolor7;
    public Color VicColor5Shade;
    public Color VicColor1Shade;
    public Color VicColor2Shade;
    public Color VicColor3Shade;
    public Color VicColor4Shade;
    public Font introFont1;
    public Font introFont2;
    public Font introfont2b;
    public Font introfont1b;
    public Font introfont3;
    public Font shadowFontConsole;
    public Font shadowFontConsole2;
    public Font shadowFontConsole3;
    public Font shadowFontConsole4;
    public Font seFont2;
    public Font se1TypeWriterBig;
    public Font se1TypeWriterBig2;
    public Font se1TypeWriterBig3;
    public Font se1TypeWriterMedium;
    public Font se1TypeWriterSmall;
    public PrivateFontCollection FontCol;
    public PrivateFontCollection FontCol2;
    public PrivateFontCollection[] DynFontCol;
    public Font[] DynFont;
    public int[] DynFontSize;
    public int[] DynFontStyle;
    public string[] DynFontFileName;
    public bool[] DynFontWorld;
    public int DynFontCount;
    public Form1 FormRef;
    public Thread AIThread;
    public bool AIThreadRunning;
    public bool AIRunning;
    public Thread se1Thread;
    public bool se1ThreadRunning;
    public bool se1Running;
    public GameLoopClass2 se1GameLoop;
    public bool se1ThreadBlock;
    public string ModFile;
    public int HelpCounter;
    public string[] HelpDir;
    public string[] HelpFile;
    public string[] HelpText;

    public bool CheckDLCpresent(int dlcType)
    {
      int dlcCounter = this.dlc_Counter;
      for (int index = 0; index <= dlcCounter; ++index)
      {
        if (this.dlc_ID[index] == dlcType)
          return true;
      }
      return false;
    }

    public void AddDLC(int dlcType)
    {
      ++this.dlc_Counter;
      this.dlc_ID = (int[]) Utils.CopyArray((Array) this.dlc_ID, (Array) new int[this.dlc_Counter + 1]);
      this.dlc_ID[this.dlc_Counter] = dlcType;
    }

    public int AddDynFont(string name, int size, int style, bool world = false)
    {
      bool flag = false;
      int num1 = -1;
      if (size < 1)
        size = 16;
      if (Information.IsNothing((object) name))
        name = "georgia.ttf";
      if (Operators.CompareString(name, "", false) == 0)
        name = "georgia.ttf";
      int dynFontCount = this.DynFontCount;
      for (int index = 0; index <= dynFontCount; ++index)
      {
        if (Operators.CompareString(this.DynFontFileName[index], name, false) == 0 & this.DynFontSize[index] == size & this.DynFontStyle[index] == style & this.DynFontWorld[index] == world)
        {
          flag = true;
          num1 = index;
          break;
        }
      }
      if (this.DynFontCount >= 99)
      {
        int num2 = (int) Interaction.MsgBox((object) "Max Dynamic Font use (99 slots) exceeded! Creation of font aborted.", Title: ((object) "Shadow Empire : Planetary Conquest"));
        return 0;
      }
      if (!flag)
      {
        ++this.DynFontCount;
        if (Information.IsNothing((object) this.DynFontCol[this.DynFontCount]))
          this.DynFontCol[this.DynFontCount] = new PrivateFontCollection();
        try
        {
          this.DynFontCol[this.DynFontCount].AddFontFile(this.AppPath + "fonts/" + name);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.DynFontCol[this.DynFontCount].AddFontFile(this.AppPath + "fonts/georgia.ttf");
          ProjectData.ClearProjectError();
        }
        this.DynFontFileName[this.DynFontCount] = name;
        this.DynFontSize[this.DynFontCount] = size;
        this.DynFontStyle[this.DynFontCount] = style;
        this.DynFontWorld[this.DynFontCount] = world;
        int num3;
        try
        {
          if (world)
          {
            switch (style)
            {
              case 1:
                this.DynFont[this.DynFontCount] = new Font(this.DynFontCol[this.DynFontCount].Families[0], (float) size, FontStyle.Bold, GraphicsUnit.World);
                break;
              case 2:
                this.DynFont[this.DynFontCount] = new Font(this.DynFontCol[this.DynFontCount].Families[0], (float) size, FontStyle.Italic, GraphicsUnit.World);
                break;
              default:
                this.DynFont[this.DynFontCount] = new Font(this.DynFontCol[this.DynFontCount].Families[0], (float) size, FontStyle.Regular, GraphicsUnit.World);
                break;
            }
          }
          else
          {
            switch (style)
            {
              case 1:
                this.DynFont[this.DynFontCount] = new Font(this.DynFontCol[this.DynFontCount].Families[0], (float) size, FontStyle.Bold, GraphicsUnit.Pixel);
                break;
              case 2:
                this.DynFont[this.DynFontCount] = new Font(this.DynFontCol[this.DynFontCount].Families[0], (float) size, FontStyle.Italic, GraphicsUnit.Pixel);
                break;
              default:
                this.DynFont[this.DynFontCount] = new Font(this.DynFontCol[this.DynFontCount].Families[0], (float) size, FontStyle.Regular, GraphicsUnit.Pixel);
                break;
            }
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num4 = (int) Interaction.MsgBox((object) ("Error creating font: " + ex.Message), Title: ((object) "Shadow Empire : Planetary Conquest"));
          num3 = -1;
          ProjectData.ClearProjectError();
          goto label_31;
        }
        num1 = this.DynFontCount;
        goto label_30;
label_31:
        return num3;
      }
label_30:
      return num1;
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    public GameClass(Form1 tformref)
    {
      this.UserTestMode = false;
      this.UserDebugger = false;
      this.noDrawNoFocus = false;
      this.MetricsURL = "";
      this.Metrics2URL = "";
      this.AlternativeGraphics = "";
      this.dlc_Counter = -1;
      this.dlc_ID = new int[1];
      this.modlib_Counter = -1;
      this.modlib_Name = new string[1];
      this.modlib_Designer = new string[1];
      this.modlib_Description = new string[1];
      this.modlib_Version = new int[1];
      this.modlib_Filename = new string[1];
      this.modlib_Flagged = new bool[1];
      this.theaterThreadBlock = false;
      this.AllowHeightMap = false;
      this.EmpireStyle = true;
      this.HighGraphicsSpeedPossible = true;
      this.useModLib = true;
      this.PERCENT = new int[11];
      this.BORDER = new int[6];
      this.MAPBORDER = new int[11];
      this.ZONEBORDER = new int[6];
      this.LIGHTZONEBORDER = new int[6];
      this.NOBRIDGE = new int[6];
      this.FOG = new int[65];
      this.SHROWD = new int[65];
      this.SPRITE64 = new int[2, 2, 2, 2, 2, 2];
      this.ARROW64 = new int[3, 3, 3, 3, 3, 3];
      this.SHEETX = new int[65];
      this.SHEETY = new int[65];
      this.NATO = new int[2];
      this.seColWhite = new Color();
      this.seColYellow = new Color();
      this.seColRed = new Color();
      this.seColGreen = new Color();
      this.seColGray = new Color();
      this.seColDelegated = new Color();
      this.seColBrown = new Color();
      this.seColBlue = new Color();
      this.seColTW = new Color();
      this.ModButSize = new int[2];
      this.ModButX = new int[2];
      this.ModButY = new int[2];
      this.ModButText = new string[2];
      this.ModButActive = new int[2];
      this.ModButType = new int[2];
      this.ModButDatastring = new string[2];
      this.ModButDatastring2 = new string[2];
      this.ModGfxReplaceS1 = new string[2];
      this.ModGfxReplaceS2 = new string[2];
      this.DynFontCol = new PrivateFontCollection[100];
      this.DynFont = new Font[100];
      this.DynFontSize = new int[100];
      this.DynFontStyle = new int[100];
      this.DynFontFileName = new string[100];
      this.DynFontWorld = new bool[100];
      this.DynFontCount = -1;
      this.se1ThreadBlock = false;
      this.HelpDir = new string[1];
      this.HelpFile = new string[1];
      this.HelpText = new string[1];
      this.AppPath = AppDomain.CurrentDomain.BaseDirectory;
      this.AppPath_SAVEGAMES = this.AppPath + "savedgames\\";
      this.AppPath_SAVEGAMES = MyProject.Computer.FileSystem.SpecialDirectories.MyDocuments + "\\My Games\\Shadow Empire\\";
      if (Directory.Exists(this.AppPath_SAVEGAMES))
      {
        this.AppPath_SAVEGAMES = this.AppPath_SAVEGAMES;
        string path = this.AppPath_SAVEGAMES + "system_test_5001234x.se1";
        FileStream Expression;
        try
        {
          Expression = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
          Expression.Close();
          Expression.Dispose();
          File.Delete(path);
        }
        catch (Exception ex1)
        {
          ProjectData.SetProjectError(ex1);
          if (!Information.IsNothing((object) Expression))
          {
            try
            {
              Expression.Close();
            }
            catch (Exception ex2)
            {
              ProjectData.SetProjectError(ex2);
              ProjectData.ClearProjectError();
            }
            Expression.Dispose();
          }
          this.AppPath_SAVEGAMES = this.AppPath + "savedgames\\";
          ProjectData.ClearProjectError();
        }
      }
      else
        this.AppPath_SAVEGAMES = this.AppPath + "savedgames\\";
      if (Information.IsNothing((object) tformref))
        return;
      string str1;
      try
      {
        this.ModFile = DrawMod.ModFile;
        StreamReader streamReader = File.OpenText(this.AppPath + this.ModFile);
        str1 = streamReader.ReadLine();
        this.ModScenario = streamReader.ReadLine();
        this.ModIntroType = Conversions.ToInteger(streamReader.ReadLine());
        if (!(this.ModIntroType == 1 | this.ModIntroType == 2))
        {
          streamReader.Close();
          int num = (int) Interaction.MsgBox((object) "Faulty Mod File");
          ProjectData.EndApp();
        }
        this.ModSystemGraphicsDirectory = streamReader.ReadLine();
        this.ModScenarioDir = streamReader.ReadLine();
        this.ModSoundDir = streamReader.ReadLine();
        this.ModNatoCounters = streamReader.ReadLine();
        this.ModNatoCounters = "natocounters";
        this.ModOpeningSoundtrack = streamReader.ReadLine();
        this.ModExtraSound = streamReader.ReadLine();
        this.ModCounter = Conversions.ToInteger(streamReader.ReadLine());
        int modCounter = this.ModCounter;
        for (int index = 1; index <= modCounter; ++index)
        {
          this.ModButActive = (int[]) Utils.CopyArray((Array) this.ModButActive, (Array) new int[index + 1]);
          this.ModButSize = (int[]) Utils.CopyArray((Array) this.ModButSize, (Array) new int[index + 1]);
          this.ModButX = (int[]) Utils.CopyArray((Array) this.ModButX, (Array) new int[index + 1]);
          this.ModButY = (int[]) Utils.CopyArray((Array) this.ModButY, (Array) new int[index + 1]);
          this.ModButText = (string[]) Utils.CopyArray((Array) this.ModButText, (Array) new string[index + 1]);
          this.ModButType = (int[]) Utils.CopyArray((Array) this.ModButType, (Array) new int[index + 1]);
          this.ModButDatastring = (string[]) Utils.CopyArray((Array) this.ModButDatastring, (Array) new string[index + 1]);
          this.ModButDatastring2 = (string[]) Utils.CopyArray((Array) this.ModButDatastring2, (Array) new string[index + 1]);
          string[] strArray = Strings.Split(streamReader.ReadLine(), ",");
          this.ModButActive[index] = Conversions.ToInteger(strArray[0]);
          this.ModButSize[index] = Conversions.ToInteger(strArray[1]);
          this.ModButX[index] = Conversions.ToInteger(strArray[2]);
          this.ModButY[index] = Conversions.ToInteger(strArray[3]);
          this.ModButText[index] = strArray[4];
          this.ModButType[index] = Conversions.ToInteger(strArray[5]);
          this.ModButDatastring[index] = strArray[6];
          if (strArray.GetUpperBound(0) > 6)
          {
            try
            {
              this.ModButDatastring2[index] = strArray[7];
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              this.ModButDatastring2[index] = "";
              ProjectData.ClearProjectError();
            }
          }
        }
        this.ModGfxReplaceCounter = 0;
        if (!streamReader.EndOfStream)
        {
          try
          {
            this.ModGfxReplaceCounter = (int) Math.Round(Conversion.Val(streamReader.ReadLine()));
            int gfxReplaceCounter = this.ModGfxReplaceCounter;
            for (int index = 1; index <= gfxReplaceCounter; ++index)
            {
              this.ModGfxReplaceS1 = (string[]) Utils.CopyArray((Array) this.ModGfxReplaceS1, (Array) new string[index + 1]);
              this.ModGfxReplaceS2 = (string[]) Utils.CopyArray((Array) this.ModGfxReplaceS2, (Array) new string[index + 1]);
              string[] strArray = Strings.Split(streamReader.ReadLine(), ",");
              this.ModGfxReplaceS1[index] = strArray[0];
              this.ModGfxReplaceS2[index] = strArray[1];
            }
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            ProjectData.ClearProjectError();
          }
        }
        streamReader.Close();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) "MOD FILE CAUSED AN ERROR", Title: ((object) "Shadow Empire : Planetary Conquest"));
        ProjectData.EndApp();
        ProjectData.ClearProjectError();
      }
      try
      {
        StreamReader streamReader = File.OpenText(this.AppPath + "editorblock.txt");
        try
        {
          this.EditorBlock = false;
          this.EditorBlock = Conversions.ToBoolean(streamReader.ReadLine());
          try
          {
            this.EditorBlockSimple = false;
            this.EditorBlockSimple = Conversions.ToBoolean(streamReader.ReadLine());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            ProjectData.ClearProjectError();
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
        streamReader.Close();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      try
      {
        StreamReader streamReader = File.OpenText(this.AppPath + "metrics.txt");
        try
        {
          this.MetricsURL = streamReader.ReadLine();
          try
          {
            this.Metrics2URL = streamReader.ReadLine();
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.Metrics2URL = "";
            ProjectData.ClearProjectError();
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.MetricsURL = "";
          this.Metrics2URL = "";
          ProjectData.ClearProjectError();
        }
        streamReader.Close();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.MetricsURL = "";
        this.Metrics2URL = "";
        ProjectData.ClearProjectError();
      }
      try
      {
        StreamReader streamReader = File.OpenText(this.AppPath + "supercameron.txt");
        try
        {
          this.SuperAdminRights = Conversions.ToBoolean(streamReader.ReadLine());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.SuperAdminRights = false;
          ProjectData.ClearProjectError();
        }
        streamReader.Close();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.SuperAdminRights = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        StreamReader streamReader = File.OpenText(this.AppPath + "usertestmode.txt");
        try
        {
          this.UserTestMode = Conversions.ToBoolean(streamReader.ReadLine());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.UserTestMode = false;
          ProjectData.ClearProjectError();
        }
        streamReader.Close();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.UserTestMode = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        StreamReader streamReader = File.OpenText(this.AppPath + "userdebugger.txt");
        try
        {
          this.UserDebugger = Conversions.ToBoolean(streamReader.ReadLine());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.UserDebugger = false;
          ProjectData.ClearProjectError();
        }
        streamReader.Close();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.UserDebugger = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        StreamReader streamReader = File.OpenText(this.AppPath + "nodrawnofocus.txt");
        try
        {
          this.noDrawNoFocus = Conversions.ToBoolean(streamReader.ReadLine());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.noDrawNoFocus = false;
          ProjectData.ClearProjectError();
        }
        streamReader.Close();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.noDrawNoFocus = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        StreamReader streamReader = File.OpenText(this.AppPath + "se1dlc1.txt");
        this.AddDLC(1);
        streamReader.Close();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      try
      {
        StreamReader streamReader = File.OpenText(this.AppPath + "se1dlc2.txt");
        this.AddDLC(2);
        streamReader.Close();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      this.AlternativeGraphics = "graphicsAlt";
      this.AllowHeightMap = true;
      if (!this.SuperAdminRights)
      {
        this.EditorBlock = true;
        this.EditorBlockSimple = true;
      }
      this.HandyFunctionsObj = new HandyFunctionsclass(this);
      DrawMod.TGame = this;
      this.UseSlimDX = true;
      Application.DoEvents();
      if (!Information.IsNothing((object) tformref))
        tformref.Label1.Text = "Loading Fonts";
      this.GameCol1 = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.GameCol2 = Color.FromArgb((int) byte.MaxValue, 165, 165, 165);
      this.GameCol3 = Color.FromArgb((int) byte.MaxValue, 225, 215, 205);
      this.GameCol4 = Color.FromArgb((int) byte.MaxValue, 175, 165, 155);
      this.GameCol4 = Color.FromArgb((int) byte.MaxValue, 175, 165, 155);
      this.GameCol4 = Color.FromArgb((int) byte.MaxValue, 145, 135, 125);
      this.GameCol7 = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
      this.GameCol8 = Color.FromArgb((int) byte.MaxValue, 50, 100, 150);
      this.GameCol9 = Color.FromArgb((int) byte.MaxValue, 30, 60, 100);
      this.GameColPen1 = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.VicColor1 = Color.FromArgb((int) byte.MaxValue, 200, 200, 200);
      this.VicColor1Shade = Color.FromArgb(128, 0, 0, 0);
      this.VicColor2 = Color.White;
      this.VicColor2Shade = Color.DarkGray;
      this.VicColor3 = Color.FromArgb(200, 100, 100, 100);
      this.VicColor3Shade = Color.FromArgb(192, 0, 0, 0);
      this.VicColor4 = Color.FromArgb(128, 0, 0, 0);
      this.VicColor5 = Color.FromArgb(192, 0, 0, 0);
      this.VicColor6 = Color.FromArgb((int) byte.MaxValue, 150, 150, 150);
      this.viccolor7 = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, 0);
      this.VicColor8 = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
      this.MarcCol1 = Color.FromArgb(100, 0, 0, 0);
      this.MarcCol2 = Color.FromArgb(100, 120, 140, 150);
      this.MarcCol3 = Color.FromArgb((int) byte.MaxValue, 120, 140, 150);
      this.MarcCol4 = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, 0);
      this.MarcCol5 = Color.FromArgb((int) byte.MaxValue, 212, 70, 60);
      this.IsWin10 = Environment.OSVersion.Version.Major > 6 | Environment.OSVersion.Version.Major == 6 & Environment.OSVersion.Version.Minor >= 3;
      string fullName = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.System)).FullName;
      this.FontCol = new PrivateFontCollection();
      this.FontCol.AddFontFile(this.AppPath + "fonts/ARIALN.TTF");
      this.FontCol.AddFontFile(this.AppPath + "fonts/ARIALNB.TTF");
      try
      {
        this.FontCol.AddFontFile(fullName + "/fonts/georgia.ttf");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.FontCol.AddFontFile(this.AppPath + "fonts/georgia.TTF");
        ProjectData.ClearProjectError();
      }
      this.FontCol.AddFontFile(this.AppPath + "fonts/small5.ttf");
      this.FontCol.AddFontFile(this.AppPath + "fonts/04B_03B_.TTF");
      try
      {
        this.FontCol.AddFontFile(fullName + "/fonts/arial.ttf");
        this.FontCol.AddFontFile(fullName + "/fonts/arialbd.ttf");
        this.FontCol.AddFontFile(fullName + "/fonts/arialbi.ttf");
        this.FontCol.AddFontFile(fullName + "/fonts/ariali.ttf");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.FontCol.AddFontFile(this.AppPath + "fonts/ARIAL.TTF");
        this.FontCol.AddFontFile(this.AppPath + "fonts/ARIALBD.TTF");
        this.FontCol.AddFontFile(this.AppPath + "fonts/ARIALBI.TTF");
        this.FontCol.AddFontFile(this.AppPath + "fonts/ARIALI.TTF");
        ProjectData.ClearProjectError();
      }
      this.FontCol.AddFontFile(this.AppPath + "fonts/bnt.TTF");
      this.FontCol.AddFontFile(this.AppPath + "fonts/bnto.TTF");
      this.MarcFont1 = new Font(this.FontCol.Families[2], 28f, FontStyle.Bold, GraphicsUnit.Pixel);
      this.MarcFont2 = new Font(this.FontCol.Families[2], 28f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.MarcFont3 = new Font(this.FontCol.Families[2], 20f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.MarcFont4 = new Font(this.FontCol.Families[2], 16f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.MarcFont4b = new Font("Courier New", 15f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.MarcFont5 = new Font(this.FontCol.Families[2], 11f, FontStyle.Bold, GraphicsUnit.Pixel);
      this.MarcFont6 = new Font(this.FontCol.Families[4], 16f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.MarcFont7 = new Font(this.FontCol.Families[2], 14f, FontStyle.Bold, GraphicsUnit.Pixel);
      this.MarcFont8 = new Font(this.FontCol.Families[4], 14f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.MarcFont8c = new Font(this.FontCol.Families[4], 13f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.MarcFont9 = new Font(this.FontCol.Families[2], 8f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.MarcFont10 = new Font(this.FontCol.Families[2], 10f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.MarcFont11 = new Font(this.FontCol.Families[2], 9f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.MarcFont11b = new Font(this.FontCol.Families[2], 11f, FontStyle.Bold, GraphicsUnit.Pixel);
      this.MarcFont12 = new Font(this.FontCol.Families[4], 28f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.MarcFont13 = new Font(this.FontCol.Families[4], 11f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.MarcFont14 = new Font(this.FontCol.Families[5], 9f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.MarcFont14b = new Font(this.FontCol.Families[5], 14f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.MarcFont15 = new Font(this.FontCol.Families[5], 8f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.MarcFont16 = new Font(this.FontCol.Families[2], 16f, FontStyle.Bold, GraphicsUnit.Pixel);
      this.MarcFont8b = new Font(this.FontCol.Families[4], 14f, FontStyle.Bold, GraphicsUnit.Pixel);
      this.marcFont17 = new Font(this.FontCol.Families[2], 14f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.marcFont18 = new Font(this.FontCol.Families[2], 12f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.introFont1 = new Font(this.FontCol.Families[3], 36f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.introFont2 = new Font(this.FontCol.Families[3], 48f, FontStyle.Bold, GraphicsUnit.Pixel);
      this.GameFont1 = this.MarcFont4;
      this.gamefont1b = this.MarcFont4;
      this.GameFont2 = this.MarcFont4;
      this.gamefont2b = this.MarcFont4;
      this.GameFont3 = this.MarcFont4;
      this.FontCol.AddFontFile(this.AppPath + "fonts/LMmono-Regular.ttf");
      this.FontCol.AddFontFile(this.AppPath + "fonts/LMmonoCaps-Regular.ttf");
      this.shadowFontConsole = new Font(this.FontCol.Families[6], 13f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.shadowFontConsole2 = new Font(this.FontCol.Families[6], 20f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.shadowFontConsole3 = new Font(this.FontCol.Families[6], 10f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.shadowFontConsole4 = new Font(this.FontCol.Families[6], 8f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.se1TypeWriterBig = new Font(this.FontCol.Families[7], 20f, FontStyle.Bold, GraphicsUnit.Pixel);
      this.se1TypeWriterBig2 = new Font(this.FontCol.Families[7], 16f, FontStyle.Bold, GraphicsUnit.Pixel);
      this.se1TypeWriterBig3 = new Font(this.FontCol.Families[7], 14f, FontStyle.Bold, GraphicsUnit.Pixel);
      this.se1TypeWriterMedium = new Font(this.FontCol.Families[6], 15f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.se1TypeWriterSmall = new Font(this.FontCol.Families[6], 13f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.seFont1 = new Font(this.FontCol.Families[7], 32f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.seFont2 = new Font(this.FontCol.Families[7], 44f, FontStyle.Bold, GraphicsUnit.Pixel);
      this.VicFont1 = this.MarcFont16;
      this.VicFont2 = this.MarcFont4;
      this.VicFont3 = this.MarcFont8c;
      this.VicFont4 = this.MarcFont10;
      this.VicFont5 = this.MarcFont10;
      this.VicFont6 = new Font(this.FontCol.Families[3], 8f, FontStyle.Regular, GraphicsUnit.Pixel);
      this.VicFont7 = this.MarcFont8;
      this.VicFont8 = this.MarcFont12;
      this.GameFont1 = this.MarcFont4;
      this.gamefont1b = this.MarcFont4;
      this.GameFont2 = this.MarcFont4;
      this.gamefont2b = this.MarcFont4;
      this.GameFont3 = this.MarcFont4;
      BitmapStore.GiveGraphicsPath(this.AppPath + "graphics/");
      if (!Information.IsNothing((object) tformref))
        tformref.Label1.Text = "Loading System gfx";
      Application.DoEvents();
      this.REDBUTTON = BitmapStore.AddFile("systemgraphics/wide red normal.png", true);
      this.RESEARCHOVERPRINT = BitmapStore.AddFile("systemgraphics/cat1/cardpanel.png", true);
      this.ZONEBORDER[0] = BitmapStore.AddFile("systemgraphics/border/ZoneBorder1.png", true, true);
      this.ZONEBORDER[1] = BitmapStore.AddFile("systemgraphics/border/ZoneBorder2.png", true, true);
      this.ZONEBORDER[2] = BitmapStore.AddFile("systemgraphics/border/ZoneBorder3.png", true, true);
      this.ZONEBORDER[3] = BitmapStore.AddFile("systemgraphics/border/ZoneBorder4.png", true, true);
      this.ZONEBORDER[4] = BitmapStore.AddFile("systemgraphics/border/ZoneBorder5.png", true, true);
      this.ZONEBORDER[5] = BitmapStore.AddFile("systemgraphics/border/ZoneBorder6.png", true, true);
      this.LIGHTZONEBORDER[0] = BitmapStore.AddFile("systemgraphics/border/LightZoneBorder1.png", true, true);
      this.LIGHTZONEBORDER[1] = BitmapStore.AddFile("systemgraphics/border/LightZoneBorder2.png", true, true);
      this.LIGHTZONEBORDER[2] = BitmapStore.AddFile("systemgraphics/border/LightZoneBorder3.png", true, true);
      this.LIGHTZONEBORDER[3] = BitmapStore.AddFile("systemgraphics/border/LightZoneBorder4.png", true, true);
      this.LIGHTZONEBORDER[4] = BitmapStore.AddFile("systemgraphics/border/LightZoneBorder5.png", true, true);
      this.LIGHTZONEBORDER[5] = BitmapStore.AddFile("systemgraphics/border/LightZoneBorder6.png", true, true);
      this.WHITEHEXTRANS = BitmapStore.AddFile("systemgraphics/whitehextrans.png", true, true);
      this.WHITEHEXTRANS2 = BitmapStore.AddFile("systemgraphics/whitehextrans2.png", true, true);
      this.WHITEHEXTRANS3 = BitmapStore.AddFile("systemgraphics/whitehextrans3.png", true, true);
      this.LINES = BitmapStore.AddFile("systemgraphics/cat1/lines.png", true);
      this.LINESFRAME = BitmapStore.AddFile("systemgraphics/cat1/linesframe.png", true);
      this.MARCBUTBAR = BitmapStore.AddFile("systemgraphics/cat1/ButBarSe1.png", true);
      this.MARCBUTBARHISTORY = BitmapStore.AddFile("systemgraphics/cat1/ButBar.png", true);
      this.UP20 = BitmapStore.AddFile("systemgraphics/up20.png", true);
      this.DOWN20 = BitmapStore.AddFile("systemgraphics/down20.png", true);
      this.SECARDOUTLINE = BitmapStore.AddFile("systemgraphics/cat1/CardMediumOutline.png", true);
      this.ARROWSHEET = BitmapStore.AddFile("systemgraphics/cat4/arrows.png", true, true);
      this.BACKGROUND1MARC2 = BitmapStore.AddFile("systemgraphics/se1/backgroundmarc2.png", true);
      this.BUTTONSMALL = BitmapStore.AddFile("systemgraphics/cat1/Button Small.png", true);
      this.BUTTONSMALLHIGH = BitmapStore.AddFile("systemgraphics/cat1/Button Small Over.png", true);
      this.MARCLEFTBAR = BitmapStore.AddFile("systemgraphics/cat1/sidebarleft.png", true);
      this.MARCTOPBARDIGITAL = BitmapStore.AddFile("systemgraphics/cat1/topbardigital.png", true);
      this.MARCRIGHTBAR = BitmapStore.AddFile("systemgraphics/cat1/sidebarright.png", true);
      this.SE1_SUPERIMPOSEBACKGROUND = BitmapStore.AddFile("systemgraphics/se1/superimposebackground.png", true);
      this.SE1_COMPLEXFRAME = BitmapStore.AddFile("systemgraphics/se1/complexframe.png", true);
      this.SE1_BACKGROUNDLOOP = BitmapStore.AddFile("systemgraphics/se1/backgroundloop.png", true);
      this.SE1_RESOURCEBAR_BOTTOM = BitmapStore.AddFile("systemgraphics/se1/resourcebar_bottom.png", true);
      this.SE1_RESOURCEBAR_LEFT = BitmapStore.AddFile("systemgraphics/se1/resourcebar_left.png", true);
      this.SE1_RESOURCEBAR_RIGHT = BitmapStore.AddFile("systemgraphics/se1/resourcebar_right.png", true);
      this.SE1_RESOURCEBAR_TAB = BitmapStore.AddFile("systemgraphics/se1/resourcebar_tab.png", true);
      this.SE1_RESOURCEBAR_VARBOX = BitmapStore.AddFile("systemgraphics/se1/resourcebar_varbox.png", true);
      this.SE1_ICONS = BitmapStore.AddFile("systemgraphics/se1/icons.png", true);
      this.SE1_ARROW1 = BitmapStore.AddFile("systemgraphics/se1/arrow1.png", true);
      this.SE1_ARROW2 = BitmapStore.AddFile("systemgraphics/se1/arrow2.png", true);
      this.SE1_ARROW3 = BitmapStore.AddFile("systemgraphics/se1/arrow3.png", true);
      this.SE1_ARROW4 = BitmapStore.AddFile("systemgraphics/se1/arrow4.png", true);
      this.SE1_ARROWBUTTON = BitmapStore.AddFile("systemgraphics/se1/arrowbutton.png", true);
      this.SE1_ARROWBUTTONHIGH = BitmapStore.AddFile("systemgraphics/se1/arrowbuttonhigh.png", true);
      this.SE1_ICONHIGHLIGHT = BitmapStore.AddFile("systemgraphics/se1/iconhighlight.png", true);
      this.SE1_MAINFRAME_LEFT = BitmapStore.AddFile("systemgraphics/se1/mainframe_left.png", true);
      this.SE1_MAINFRAME_LEFT2 = BitmapStore.AddFile("systemgraphics/se1/mainframe_left2.png", true);
      this.SE1_MAINFRAME_RIGHT = BitmapStore.AddFile("systemgraphics/se1/mainframe_right.png", true);
      this.SE1_MAINFRAME_RIGHT2 = BitmapStore.AddFile("systemgraphics/se1/mainframe_right2.png", true);
      this.SE1_MAINFRAME_MIDDLE = BitmapStore.AddFile("systemgraphics/se1/mainframe_middle.png", true);
      this.SE1_ORDERBAR_TAB1LOW = BitmapStore.AddFile("systemgraphics/se1/orderbar_tab1low.png", true);
      this.SE1_ORDERBAR_TAB1HIGH = BitmapStore.AddFile("systemgraphics/se1/orderbar_tab1high.png", true);
      this.SE1_ORDERBAR_TAB2LOW = BitmapStore.AddFile("systemgraphics/se1/orderbar_tab2low.png", true);
      this.SE1_ORDERBAR_TAB2HIGH = BitmapStore.AddFile("systemgraphics/se1/orderbar_tab2high.png", true);
      this.SE1_SIDEBAR_TEXTURE = BitmapStore.AddFile("systemgraphics/se1/sidebar_texture.png", true);
      this.SE1_SIDEBAR_TABLEFT = BitmapStore.AddFile("systemgraphics/se1/sidebar_tableft.png", true);
      this.SE1_SIDEBAR_TABRIGHT = BitmapStore.AddFile("systemgraphics/se1/sidebar_tabright.png", true);
      this.SE1_SIDEBAR_EXITLEFT = BitmapStore.AddFile("systemgraphics/se1/sidebar_exitleft.png", true);
      this.SE1_SIDEBAR_EXITRIGHT = BitmapStore.AddFile("systemgraphics/se1/sidebar_exitright.png", true);
      this.SE1_BLACKGRADIENT = BitmapStore.AddFile("systemgraphics/se1/blackgradient.png", true);
      this.SE1_ZONEFRAME = BitmapStore.AddFile("systemgraphics/se1/zoneframe.png", true);
      this.SE1_ZONEBUTTON = BitmapStore.AddFile("systemgraphics/se1/zonebutton.png", true);
      this.SE1_ZONEBUTTONHIGH = BitmapStore.AddFile("systemgraphics/se1/zonebuttonhigh.png", true);
      this.SE1_ZONEBUTTONSMALL = BitmapStore.AddFile("systemgraphics/se1/zonebuttonsmall.png", true);
      this.SE1_ZONEBUTTONSMALLHIGH = BitmapStore.AddFile("systemgraphics/se1/zonebuttonsmallhigh.png", true);
      this.SE1_ZONEPAPERFRAME1air = BitmapStore.AddFile("systemgraphics/se1/zonepaperframe1air.png", true);
      this.SE1_ZONEPAPERFRAME1 = BitmapStore.AddFile("systemgraphics/se1/zonepaperframe1.png", true);
      this.SE1_ZONEPAPERFRAME2 = BitmapStore.AddFile("systemgraphics/se1/zonepaperframe2.png", true);
      this.SE1_ZONEPAPERFRAME3 = BitmapStore.AddFile("systemgraphics/se1/zonepaperframe3.png", true);
      this.SE1_ZONEPAPERFRAME4 = BitmapStore.AddFile("systemgraphics/se1/zonepaperframe4.png", true);
      this.SE1_QUICKHEXFRAME = BitmapStore.AddFile("systemgraphics/se1/quickhexframe.png", true);
      this.SE1_QUICKREGIMEFRAME = BitmapStore.AddFile("systemgraphics/se1/quickregimeframe.png", true);
      this.SE1_BOTTOMORNAMENTALLEFT = BitmapStore.AddFile("systemgraphics/se1/bottomornamentalleft.png", true);
      this.SE1_BOTTOMORNAMENTALRIGHT = BitmapStore.AddFile("systemgraphics/se1/bottomornamentalright.png", true);
      this.SE1_VARBOX2 = BitmapStore.AddFile("systemgraphics/se1/varbox2.png", true);
      this.SE1_VARBOX3 = BitmapStore.AddFile("systemgraphics/se1/varbox3.png", true);
      this.SE1_VARBOX4 = BitmapStore.AddFile("systemgraphics/se1/varbox4.png", true);
      this.SE1_QUICKREGIMEHEADER = BitmapStore.AddFile("systemgraphics/se1/quickregimeheader.png", true);
      this.SE1_QUICKREGIMEPAPERFRAME = BitmapStore.AddFile("systemgraphics/se1/quickregimepaperframe.png", true);
      this.SE1_SIDEBAR_TOPSHADOWLEFT = BitmapStore.AddFile("systemgraphics/se1/sidebar_topshadowleft.png", true);
      this.SE1_SIDEBAR_TOPSHADOWRIGHT = BitmapStore.AddFile("systemgraphics/se1/sidebar_topshadowright.png", true);
      this.SE1_UNITFRAME = BitmapStore.AddFile("systemgraphics/se1/unitframe.png", true);
      this.SE1_UNITBED = BitmapStore.AddFile("systemgraphics/se1/unitbed.png", true);
      this.SE1_UNITBEDHIGH = BitmapStore.AddFile("systemgraphics/se1/unitbedhigh.png", true);
      this.SE1_TROOPFRAME = BitmapStore.AddFile("systemgraphics/se1/troopframe.png", true);
      this.SE1_BOTTOMPAGEBUTTON = BitmapStore.AddFile("systemgraphics/se1/bottompagebutton.png", true);
      this.SE1_BOTTOMPAGEBUTTONHIGH = BitmapStore.AddFile("systemgraphics/se1/bottompagebuttonhigh.png", true);
      this.SE1_VARBOX5 = BitmapStore.AddFile("systemgraphics/se1/varbox5.png", true);
      this.SE1_VARBOX5HIGH = BitmapStore.AddFile("systemgraphics/se1/varbox5high.png", true);
      this.SE1_QUICKUNITFRAME = BitmapStore.AddFile("systemgraphics/se1/quickunitframe.png", true);
      this.SE1_UNITPAPERFRAME1 = BitmapStore.AddFile("systemgraphics/se1/unitpaperframe1.png", true);
      this.SE1_ASSETBACKGROUND = BitmapStore.AddFile("systemgraphics/se1/assetbackground.png", true);
      this.SE1_ASSETBORDER = BitmapStore.AddFile("systemgraphics/se1/assetborder.png", true);
      this.SE1_ASSETBORDERCORNER = BitmapStore.AddFile("systemgraphics/se1/assetbordercorner.png", true);
      this.SE1_ASSETBORDERHIGH = BitmapStore.AddFile("systemgraphics/se1/assetborderhigh.png", true);
      this.SE1_ASSETFRAME = BitmapStore.AddFile("systemgraphics/se1/assetframe.png", true);
      this.SE1_ITEMFRAME = BitmapStore.AddFile("systemgraphics/se1/itemframe.png", true);
      this.SE1_ITEMBOX = BitmapStore.AddFile("systemgraphics/se1/itembox.png", true);
      this.SE1_ITEMBOXPROBLEM = BitmapStore.AddFile("systemgraphics/se1/itemboxproblem.png", true);
      this.SE1_ITEMBOXCLOSED = BitmapStore.AddFile("systemgraphics/se1/itemboxclosed.png", true);
      this.SE1_ITEMBACKGROUND = BitmapStore.AddFile("systemgraphics/se1/itembackground.png", true);
      this.SE1_SIDEBARHEADER = BitmapStore.AddFile("systemgraphics/se1/sidebarheader.png", true);
      this.SE1_ORDERBUTTON = BitmapStore.AddFile("systemgraphics/se1/orderbutton.png", true);
      this.SE1_ORDERBUTTONPRESSED = BitmapStore.AddFile("systemgraphics/se1/orderbuttonpressed.png", true);
      this.SE1_SIDEBAR_VARBOX = BitmapStore.AddFile("systemgraphics/se1/sidebar_varbox.png", true);
      this.SE1_SIDEBAR_VARBOX_LONG = BitmapStore.AddFile("systemgraphics/se1/sidebar_varbox_long.png", true);
      this.SE1_PAPER1 = BitmapStore.AddFile("systemgraphics/se1/paper1.png", true);
      this.SE1_PAPER2 = BitmapStore.AddFile("systemgraphics/se1/paper2.png", true);
      this.SE1_PAPER3 = BitmapStore.AddFile("systemgraphics/se1/paper3.png", true);
      this.SE1_REGIMEFRAME = BitmapStore.AddFile("systemgraphics/se1/regimeframe.png", true);
      this.SE1_CLOSEDPANEL = BitmapStore.AddFile("systemgraphics/se1/closedpanel.png", true);
      this.SE1_PORTRAITBACKGROUND = BitmapStore.AddFile("systemgraphics/se1/portraitbackground.png", true);
      this.SE1_PORTRAITPAPER = BitmapStore.AddFile("systemgraphics/se1/portraitpaper.png", true);
      this.SE1_PORTRAITPAPER2 = BitmapStore.AddFile("systemgraphics/se1/portraitpaper2.png", true);
      this.SE1_PAPERCLIP = BitmapStore.AddFile("systemgraphics/se1/paperclip.png", true);
      this.SE1_PORTRAITBACKGROUNDFACTIONLEADER = BitmapStore.AddFile("systemgraphics/se1/portraitbackgroundfactionleader.png", true);
      this.SE1_MULTICARD = BitmapStore.AddFile("systemgraphics/se1/multicard.png", true);
      this.SE1_COMBATBAR1 = BitmapStore.AddFile("systemgraphics/se1/combatbar1.png", true);
      this.SE1_COMBATBAR2 = BitmapStore.AddFile("systemgraphics/se1/combatbar2.png", true);
      this.SE1_COMBATBLOCK1 = BitmapStore.AddFile("systemgraphics/se1/combatblock1.png", true, true);
      this.SE1_COMBATBLOCK2 = BitmapStore.AddFile("systemgraphics/se1/combatblock2.png", true, true);
      this.SE1_COMBATBLOCK3 = BitmapStore.AddFile("systemgraphics/se1/combatblock3.png", true, true);
      this.SE1_COMBATBLOCK1B = BitmapStore.AddFile("systemgraphics/se1/combatblock1b.png", true, true);
      this.SE1_COMBATBLOCK2B = BitmapStore.AddFile("systemgraphics/se1/combatblock2b.png", true, true);
      this.SE1_COMBAT_DEAD = BitmapStore.AddFile("systemgraphics/se1/combat_dead.png", true, true);
      this.SE1_COMBAT_SURRENDER = BitmapStore.AddFile("systemgraphics/se1/combat_surrender.png", true, true);
      this.SE1_COMBAT_RETREATED = BitmapStore.AddFile("systemgraphics/se1/combat_retreated.png", true, true);
      this.SE1_COMBAT_RETREATING = BitmapStore.AddFile("systemgraphics/se1/combat_retreating.png", true, true);
      this.SE1_FLAGPANEL = BitmapStore.AddFile("systemgraphics/se1/flagpanel.png", true);
      this.seColWhite = Color.White;
      this.seColGray = Color.FromArgb((int) byte.MaxValue, 225, 225, 225);
      this.seColRed = Color.FromArgb((int) byte.MaxValue, 225, 0, 0);
      this.seColGreen = Color.FromArgb((int) byte.MaxValue, 0, 225, 0);
      this.seColBlue = Color.FromArgb((int) byte.MaxValue, 0, 225, 225);
      this.seColYellow = Color.FromArgb((int) byte.MaxValue, 225, 225, 0);
      this.seColBrown = Color.FromArgb((int) byte.MaxValue, 235, 185, 135);
      this.seColDelegated = Color.FromArgb((int) byte.MaxValue, 165, 0, 165);
      this.seColTW = Color.Black;
      try
      {
        this.UDSBUTLONG = BitmapStore.AddFile("systemgraphics/cat1/ButtonUds.png", true);
        this.UDSBUTLONGHIGH = BitmapStore.AddFile("systemgraphics/cat1/ButtonUdsOver.png", true);
        this.UDSBUT2LONG = BitmapStore.AddFile("systemgraphics/cat1/ButtonUds2.png", true);
        this.UDSBUT2LONGHIGH = BitmapStore.AddFile("systemgraphics/cat1/ButtonUds2Over.png", true);
        this.UDSRADIO = BitmapStore.AddFile("systemgraphics/cat1/RadioUds.png", true);
        this.UDSRADIOHIGH = BitmapStore.AddFile("systemgraphics/cat1/RadioUdsOver.png", true);
        this.UDSRADIO2 = BitmapStore.AddFile("systemgraphics/cat1/RadioUds2.png", true);
        this.UDSRADIO2HIGH = BitmapStore.AddFile("systemgraphics/cat1/RadioUds2Over.png", true);
        this.UDSSMALLRADIO = BitmapStore.AddFile("systemgraphics/cat1/RadioSmallUds.png", true);
        this.UDSSMALLRADIOHIGH = BitmapStore.AddFile("systemgraphics/cat1/RadioSmallUdsOver.png", true);
        this.UDSSMALLRADIO2 = BitmapStore.AddFile("systemgraphics/cat1/RadioSmallUds2.png", true);
        this.UDSSMALLRADIO2HIGH = BitmapStore.AddFile("systemgraphics/cat1/RadioSmallUds2Over.png", true);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.UDSBUTLONG = 0;
        this.UDSBUTLONGHIGH = 0;
        this.UDSRADIO = 0;
        this.UDSRADIOHIGH = 0;
        this.UDSRADIO2 = 0;
        this.UDSRADIO2HIGH = 0;
        this.UDSBUT2LONG = 0;
        this.UDSBUT2LONGHIGH = 0;
        ProjectData.ClearProjectError();
      }
      this.REDOVAL = BitmapStore.AddFile("systemgraphics/redoval.bmp", true);
      this.BLUEOVAL = BitmapStore.AddFile("systemgraphics/blueoval.bmp", true);
      this.BROWNOVAL = BitmapStore.AddFile("systemgraphics/brownoval.bmp", true);
      this.SYSTEM1 = BitmapStore.AddFile("systemgraphics/Minimize Button Normal.png", true);
      this.SYSTEM1B = BitmapStore.AddFile("systemgraphics/Minimize Button Mouse Over.png", true);
      this.SYSTEM2 = BitmapStore.AddFile("systemgraphics/Quit Button Normal.png", true);
      this.SYSTEM2B = BitmapStore.AddFile("systemgraphics/Quit Button Mouse Over.png", true);
      this.NONEBUTTON = BitmapStore.AddFile("systemgraphics/buttonnone.png", true);
      this.ALLBUTTON = BitmapStore.AddFile("systemgraphics/buttonall.png", true);
      this.BUTTONHEXINFO = BitmapStore.AddFile("systemgraphics/buttonhexinfo.png", true);
      this.BUTTONHEXINFO2 = BitmapStore.AddFile("systemgraphics/buttonhexinfo2.png", true);
      this.NOBRIDGE[0] = BitmapStore.AddFile("systemgraphics/nobridge/01.png", true, true);
      this.NOBRIDGE[1] = BitmapStore.AddFile("systemgraphics/nobridge/02.png", true, true);
      this.NOBRIDGE[2] = BitmapStore.AddFile("systemgraphics/nobridge/03.png", true, true);
      this.NOBRIDGE[3] = BitmapStore.AddFile("systemgraphics/nobridge/04.png", true, true);
      this.NOBRIDGE[4] = BitmapStore.AddFile("systemgraphics/nobridge/05.png", true, true);
      this.NOBRIDGE[5] = BitmapStore.AddFile("systemgraphics/nobridge/06.png", true, true);
      this.SHADEDHEX = BitmapStore.AddFile("systemgraphics/shadedhex.png", true, true);
      this.BUTTONAIRRECON = BitmapStore.AddFile("systemgraphics/buttonairrecon.png", true);
      this.BACKBUTTON = BitmapStore.AddFile("systemgraphics/buttonback.png", true);
      this.BLACKOVAL = BitmapStore.AddFile("systemgraphics/blackoval.bmp", true);
      this.BLACKBOX = BitmapStore.AddFile("systemgraphics/blackbox.bmp", true);
      this.BUTTONSUPPLYON = BitmapStore.AddFile("systemgraphics/buttonsupplyon.png", true);
      this.BUTTONGIVEUNIT = BitmapStore.AddFile("systemgraphics/buttongiveunit.png", true);
      this.BUTTONMOVE2 = BitmapStore.AddFile("systemgraphics/buttonmove2.png", true);
      this.BUTTONSTRATEGIC2 = BitmapStore.AddFile("systemgraphics/buttonstrategic2.png", true);
      this.BLACKHEX = BitmapStore.AddFile("systemgraphics/blackhex.bmp", true, true);
      this.BORDER[0] = BitmapStore.AddFile("systemgraphics/border/border1.png", true, true);
      this.BORDER[1] = BitmapStore.AddFile("systemgraphics/border/border2.png", true, true);
      this.BORDER[2] = BitmapStore.AddFile("systemgraphics/border/border3.png", true, true);
      this.BORDER[3] = BitmapStore.AddFile("systemgraphics/border/border4.png", true, true);
      this.BORDER[4] = BitmapStore.AddFile("systemgraphics/border/border5.png", true, true);
      this.BORDER[5] = BitmapStore.AddFile("systemgraphics/border/border6.png", true, true);
      this.MAPBORDER[0] = BitmapStore.AddFile("systemgraphics/border/mapborder1.png", true, true);
      this.MAPBORDER[1] = BitmapStore.AddFile("systemgraphics/border/mapborder2.png", true, true);
      this.MAPBORDER[2] = BitmapStore.AddFile("systemgraphics/border/mapborder3.png", true, true);
      this.MAPBORDER[3] = BitmapStore.AddFile("systemgraphics/border/mapborder4.png", true, true);
      this.MAPBORDER[4] = BitmapStore.AddFile("systemgraphics/border/mapborder5.png", true, true);
      this.MAPBORDER[5] = BitmapStore.AddFile("systemgraphics/border/mapborder6.png", true, true);
      this.MAPBORDER[6] = BitmapStore.AddFile("systemgraphics/border/mapborder7.png", true, true);
      this.MAPBORDER[7] = BitmapStore.AddFile("systemgraphics/border/mapborder8.png", true, true);
      this.MAPBORDER[8] = BitmapStore.AddFile("systemgraphics/border/mapborder9.png", true, true);
      this.MAPBORDER[9] = BitmapStore.AddFile("systemgraphics/border/mapborder10.png", true, true);
      this.MAPBORDER[10] = BitmapStore.AddFile("systemgraphics/border/mapborder11.png", true, true);
      this.BUTTONSTRATEGIC = BitmapStore.AddFile("systemgraphics/buttonstrategic.png", true);
      this.BUTTONLEFT = BitmapStore.AddFile("systemgraphics/buttonleft normal.png", true);
      this.BUTTONRIGHT = BitmapStore.AddFile("systemgraphics/buttonright normal.png", true);
      this.BUTTONLEFT2 = BitmapStore.AddFile("systemgraphics/buttonleft2 normal.png", true);
      this.BUTTONRIGHT2 = BitmapStore.AddFile("systemgraphics/buttonright2 normal.png", true);
      this.BUTTONLEFTB = BitmapStore.AddFile("systemgraphics/buttonleft mouseover.png", true);
      this.BUTTONRIGHTB = BitmapStore.AddFile("systemgraphics/buttonright mouseover.png", true);
      this.BUTTONLEFT2B = BitmapStore.AddFile("systemgraphics/buttonleft2 mouseover.png", true);
      this.BUTTONRIGHT2B = BitmapStore.AddFile("systemgraphics/buttonright2 mouseover.png", true);
      this.VSLIDER = BitmapStore.AddFile("systemgraphics/vslider normal.png", true);
      this.VSLIDERB = BitmapStore.AddFile("systemgraphics/vslider mouse over.png", true);
      this.TARGETHEX = BitmapStore.AddFile("systemgraphics/target.png", true, true);
      this.BUTTONHQUNIT = BitmapStore.AddFile("systemgraphics/buttonhqunit.png", true);
      this.BUTTONATTACK = BitmapStore.AddFile("systemgraphics/buttonattack.png", true);
      this.ROUNDBALL = BitmapStore.AddFile("systemgraphics/roundball.bmp", true, true);
      this.BUTTONAIRATTACK = BitmapStore.AddFile("systemgraphics/buttonairattack.png", true);
      this.BUTTONARTATTACK = BitmapStore.AddFile("systemgraphics/buttonartattack.png", true);
      this.BUTTONMOVE = BitmapStore.AddFile("systemgraphics/buttonmove.png", true);
      this.BUTTONNEXT = BitmapStore.AddFile("systemgraphics/buttonnext.png", true);
      this.WHITEHEX = BitmapStore.AddFile("systemgraphics/whitehex.bmp", true, true);
      this.NOHEX = BitmapStore.AddFile("systemgraphics/nohex.bmp", true, true);
      this.SELECTEDHEX = BitmapStore.AddFile("systemgraphics/selected hex.png", true, true);
      this.LISTUP = BitmapStore.AddFile("systemgraphics/listup.png", true);
      this.LISTBLOCK = BitmapStore.AddFile("systemgraphics/ListBlock.png", true);
      this.LISTDOWN = BitmapStore.AddFile("systemgraphics/listdown.png", true);
      this.LISTBACK = BitmapStore.AddFile("systemgraphics/ListBackground.png", true);
      this.OKBALL = BitmapStore.AddFile("systemgraphics/buttonokball.png", true);
      this.CANCELBALL = BitmapStore.AddFile("systemgraphics/buttoncancelball.png", true);
      this.SUPPLIESSYMBOL = BitmapStore.AddFile("systemgraphics/Supply Icon.png", true);
      this.BUTTONSAVE = BitmapStore.AddFile("systemgraphics/buttonsave.png", true);
      this.ATTACK0 = BitmapStore.AddFile("systemgraphics/attack 0.png", true, true);
      this.ATTACK1 = BitmapStore.AddFile("systemgraphics/attack 1.png", true, true);
      this.ATTACK2 = BitmapStore.AddFile("systemgraphics/attack 2.png", true, true);
      this.ATTACK3 = BitmapStore.AddFile("systemgraphics/attack 3.png", true, true);
      this.ATTACK4 = BitmapStore.AddFile("systemgraphics/attack 4.png", true, true);
      this.ATTACK5 = BitmapStore.AddFile("systemgraphics/attack 5.png", true, true);
      this.ATTACKART = BitmapStore.AddFile("systemgraphics/attack art.png", true);
      this.ATTACKAMPH = BitmapStore.AddFile("systemgraphics/attack amphib.png", true);
      this.ATTACKPARADROP = BitmapStore.AddFile("systemgraphics/attack para.png", true);
      this.ATTACKAIR = BitmapStore.AddFile("systemgraphics/attack air.png", true, true);
      this.BUTTONHISTORY = BitmapStore.AddFile("systemgraphics/buttonhistory.png", true);
      this.BUTTONBUILDROAD = BitmapStore.AddFile("systemgraphics/buttonbuildroad.png", true);
      this.BUTTONBLOWBRIDGE = BitmapStore.AddFile("systemgraphics/buttonblowbridge.png", true);
      this.BUTTONHEX = BitmapStore.AddFile("systemgraphics/buttonhex.png", true);
      this.BUTTONHEXUNIT = BitmapStore.AddFile("systemgraphics/buttonhexunit.png", true);
      this.BUTTONHEXUNIT2 = BitmapStore.AddFile("systemgraphics/buttonhexunit2.png", true);
      this.HEXRASTER = BitmapStore.AddFile("systemgraphics/hexraster.png", true, true);
      this.DEFAULTCOUNTER = BitmapStore.AddFile("systemgraphics/defaultcounter.png", true);
      this.DEFAULTCOUNTERBIG = BitmapStore.AddFile("systemgraphics/defaultcounterbig.png", true);
      this.DEFAULTCOUNTERSMALL = BitmapStore.AddFile("systemgraphics/defaultcountersmall.png", true);
      this.MGSPLASH = BitmapStore.AddFile("systemgraphics/MG-splash.png", true);
      this.SLITHERINE = BitmapStore.AddFile("systemgraphics/slitherine.png", true);
      this.VRSPLASH = BitmapStore.AddFile("systemgraphics/VR-splash.png", true);
      this.TUTARROW = BitmapStore.AddFile("systemgraphics/TutArrow.png", true);
      this.TUTHEX = BitmapStore.AddFile("systemgraphics/TutHex.png", true);
      this.BUTTONZOOMIN = BitmapStore.AddFile("systemgraphics/ButtonZoomIn.png", true);
      this.BUTTONZOOMOUT = BitmapStore.AddFile("systemgraphics/ButtonZoomOut.png", true);
      this.BUTTONSTACKEDUNIT = BitmapStore.AddFile("systemgraphics/ButtonStackedUnit.png", true);
      this.BUTTONSPREADUNIT = BitmapStore.AddFile("systemgraphics/ButtonSpreadUnit.png", true);
      if (this.AllowHeightMap)
      {
        this.HEIGHTMAP_BEACH = BitmapStore.AddFile("systemgraphics/Heights/beachShadow.png", true, true);
        this.HEIGHTMAP_SHADOW1 = BitmapStore.AddFile("systemgraphics/Heights/shadowLevel1.png", true, true);
        this.HEIGHTMAP_SHADOW2 = BitmapStore.AddFile("systemgraphics/Heights/shadowLevel2.png", true, true);
        this.HEIGHTMAP_SHADOW3 = BitmapStore.AddFile("systemgraphics/Heights/shadowLevel3.png", true, true);
        this.HEIGHTMAP_LINE1 = BitmapStore.AddFile("systemgraphics/Heights/lineLevel1.png", true, true);
        this.HEIGHTMAP_LINE2 = BitmapStore.AddFile("systemgraphics/Heights/lineLevel2.png", true, true);
        this.HEIGHTMAP_LINE3 = BitmapStore.AddFile("systemgraphics/Heights/lineLevel3.png", true, true);
        this.HEIGHTMAP_TRANS_SHADOW = BitmapStore.AddFile("systemgraphics/Heights/shadowTransitions.png", true, true);
        this.HEIGHTMAP_TRANS_LINE = BitmapStore.AddFile("systemgraphics/Heights/lineTransitions.png", true, true);
      }
      this.ATTACKART2 = BitmapStore.AddFile("systemgraphics/attackart.png", true, true);
      this.SUPPLYBLOCK = BitmapStore.AddFile("systemgraphics/blocksupply.png", true, true);
      this.TRAFFIC1 = BitmapStore.AddFile("systemgraphics/traffic1.png", true, true);
      this.TRAFFIC2 = BitmapStore.AddFile("systemgraphics/traffic2.png", true, true);
      this.TRAFFIC3 = BitmapStore.AddFile("systemgraphics/traffic3.png", true, true);
      this.TRAFFIC4 = BitmapStore.AddFile("systemgraphics/traffic4.png", true, true);
      this.FIRELISTICONS = BitmapStore.AddFile("systemgraphics/firelisticons.png", true, true);
      this.EYE1 = BitmapStore.AddFile("systemgraphics/eye1.png", true, true);
      this.EYE2 = BitmapStore.AddFile("systemgraphics/eye2.png", true, true);
      this.EYE3 = BitmapStore.AddFile("systemgraphics/eye3.png", true, true);
      this.EYE4 = BitmapStore.AddFile("systemgraphics/eye4.png", true, true);
      this.ICONSUP2 = BitmapStore.AddFile("systemgraphics/cat1/SUP2-Icon.png", true);
      this.ICONSTR = BitmapStore.AddFile("systemgraphics/cat1/STR-Icon.png", true);
      this.ICONFLAG = BitmapStore.AddFile("systemgraphics/cat1/FLAG-Icon.png", true);
      this.COMBATICONS = BitmapStore.AddFile("systemgraphics/cat1/combatIcons.png", true);
      this.ICONEX1_VARIED = BitmapStore.AddFile("systemgraphics/cat1/EX-Icon_varied.png", true);
      this.ICONEP = BitmapStore.AddFile("systemgraphics/cat1/EP-Icon.png", true);
      this.ICONVIGOR = BitmapStore.AddFile("systemgraphics/cat1/VIGOR-Icon.png", true);
      if (!Information.IsNothing((object) tformref))
        tformref.Label1.Text = "Loading System cat1";
      Application.DoEvents();
      this.SMALLCHAR1 = BitmapStore.AddFile("systemgraphics/cat1/small1.png", true);
      this.SMALLCHAR2 = BitmapStore.AddFile("systemgraphics/cat1/small2.png", true);
      this.PAPERBACK1 = BitmapStore.AddFile("systemgraphics/cat1/paperBackground1.png", true);
      this.PAPERBACK2 = BitmapStore.AddFile("systemgraphics/cat1/paperBackground2.png", true);
      this.PAPERBACK3 = BitmapStore.AddFile("systemgraphics/cat1/paperBackground3.png", true);
      this.MARCCARD1A = BitmapStore.AddFile("systemgraphics/cat1/ActionCard-Attack-big.png", true);
      this.MARCCARD1B = BitmapStore.AddFile("systemgraphics/cat1/ActionCard-Attack-med.png", true);
      this.MARCCARD1C = BitmapStore.AddFile("systemgraphics/cat1/ActionCard-Attack-small.png", true);
      this.MARCCARD5A = BitmapStore.AddFile("systemgraphics/cat1/ActionCard-Defend-big.png", true);
      this.MARCCARD5B = BitmapStore.AddFile("systemgraphics/cat1/ActionCard-Defend-med.png", true);
      this.MARCCARD5C = BitmapStore.AddFile("systemgraphics/cat1/ActionCard-Defend-small.png", true);
      this.MARCCARD6A = BitmapStore.AddFile("systemgraphics/cat1/ActionCard-Org-big.png", true);
      this.MARCCARD6B = BitmapStore.AddFile("systemgraphics/cat1/ActionCard-Org-med.png", true);
      this.MARCCARD6C = BitmapStore.AddFile("systemgraphics/cat1/ActionCard-Org-small.png", true);
      this.MARCCARD2A = BitmapStore.AddFile("systemgraphics/cat1/ActionCard-Move-big.png", true);
      this.MARCCARD2B = BitmapStore.AddFile("systemgraphics/cat1/ActionCard-Move-med.png", true);
      this.MARCCARD2C = BitmapStore.AddFile("systemgraphics/cat1/ActionCard-Move-small.png", true);
      this.MARCCARD4A = BitmapStore.AddFile("systemgraphics/cat1/ActionCard-HCommand-big.png", true);
      this.MARCCARD4B = BitmapStore.AddFile("systemgraphics/cat1/ActionCard-HCommand-med.png", true);
      this.MARCCARD4C = BitmapStore.AddFile("systemgraphics/cat1/ActionCard-HCommand-small.png", true);
      this.MARCCARD3A = BitmapStore.AddFile("systemgraphics/cat1/ActionCard-Regime-big.png", true);
      this.MARCCARD3B = BitmapStore.AddFile("systemgraphics/cat1/ActionCard-Regime-med.png", true);
      this.MARCCARD3C = BitmapStore.AddFile("systemgraphics/cat1/ActionCard-Regime-small.png", true);
      this.MARCOFFICER = BitmapStore.AddFile("systemgraphics/cat1/OfficerVic.png", true);
      this.MARCLARGETAB = BitmapStore.AddFile("systemgraphics/cat1/LargeTabButton.png", true);
      this.MARCOPTSLOTS = BitmapStore.AddFile("systemgraphics/cat1/OptSlots.png", true);
      this.MARCTAB = BitmapStore.AddFile("systemgraphics/cat1/Tab.png", true);
      this.MARCARROW = BitmapStore.AddFile("systemgraphics/cat1/MarcArrow.png", true);
      this.MARCTABBUTTON = BitmapStore.AddFile("systemgraphics/cat1/TabButton.png", true);
      this.MARCTABBUTTONHIGH = BitmapStore.AddFile("systemgraphics/cat1/TabButtonHigh.png", true);
      this.MARCTOPBAR = BitmapStore.AddFile("systemgraphics/cat1/TopBar.png", true);
      this.MARCSCOPE = BitmapStore.AddFile("systemgraphics/cat1/Scope.png", true);
      this.MARCBOTBAR = BitmapStore.AddFile("systemgraphics/cat1/BotBar.png", true);
      this.MARCBUTBARFRAME = BitmapStore.AddFile("systemgraphics/cat1/ButBarFrame.png", true);
      this.LEATHER = BitmapStore.AddFile("systemgraphics/cat1/LeatherTile.png", true);
      this.COMBATART1 = BitmapStore.AddFile("systemgraphics/cat1/CombatArt1.png", true);
      this.COMBATART2 = BitmapStore.AddFile("systemgraphics/cat1/CombatArt2.png", true);
      this.MARCMESFRAME = BitmapStore.AddFile("systemgraphics/cat1/MessFrame.png", true);
      this.EXPLOSION = BitmapStore.AddFile("systemgraphics/cat1/explosion.png", true, true);
      this.BUTTONMARC1 = BitmapStore.AddFile("systemgraphics/cat1/Button Marc.png", true);
      this.BUTTONMARC1b = BitmapStore.AddFile("systemgraphics/cat1/Button Marc Over.png", true);
      this.ICONAP1 = BitmapStore.AddFile("systemgraphics/cat1/AP-Icon.png", true);
      this.ICONIN1 = BitmapStore.AddFile("systemgraphics/cat1/INT-Icon.png", true);
      this.ICONSU1 = BitmapStore.AddFile("systemgraphics/cat1/SUP-Icon.png", true);
      this.ICONRD1 = BitmapStore.AddFile("systemgraphics/cat1/RND-Icon.png", true);
      this.ICONEN1 = BitmapStore.AddFile("systemgraphics/cat1/EN-Icon.png", true);
      this.ICONEX1 = BitmapStore.AddFile("systemgraphics/cat1/EX-Icon.png", true);
      this.ICONMO1 = BitmapStore.AddFile("systemgraphics/cat1/MOR-Icon.png", true);
      this.ICONMO2 = BitmapStore.AddFile("systemgraphics/cat1/MO-MiniIcon.png", true);
      this.ICONRD2 = BitmapStore.AddFile("systemgraphics/cat1/RD-MiniIcon.png", true);
      this.ICONEN2 = BitmapStore.AddFile("systemgraphics/cat1/EN-MiniIcon.png", true);
      this.ICONEX2 = BitmapStore.AddFile("systemgraphics/cat1/EX-MiniIcon.png", true);
      this.MARCINTRO2 = BitmapStore.AddFile("systemgraphics/cat1/marcintro2.png", true);
      this.MINICARD = BitmapStore.AddFile("systemgraphics/cat1/minicard.png", true);
      this.MINICARDBIG = BitmapStore.AddFile("systemgraphics/cat1/minicardbig.png", true);
      this.FRAME1 = BitmapStore.AddFile("systemgraphics/cat1/framework.png", true);
      this.MARCBACK1 = BitmapStore.AddFile("systemgraphics/cat1/Button-LightRed-normal.png", true);
      this.MARCBACK2 = BitmapStore.AddFile("systemgraphics/cat1/Button-Red-normal.png", true);
      this.MARCBACK3 = BitmapStore.AddFile("systemgraphics/cat1/Button-Blue-normal.png", true);
      this.MARCBACK4 = BitmapStore.AddFile("systemgraphics/cat1/Button-Yellow-normal.png", true);
      this.MARCBACK1B = BitmapStore.AddFile("systemgraphics/cat1/Button-LightRed-over.png", true);
      this.MARCBACK2B = BitmapStore.AddFile("systemgraphics/cat1/Button-Red-over.png", true);
      this.MARCBACK3B = BitmapStore.AddFile("systemgraphics/cat1/Button-Blue-over.png", true);
      this.MARCBACK4B = BitmapStore.AddFile("systemgraphics/cat1/Button-Yellow-over.png", true);
      this.LOGOFLATTINY = BitmapStore.AddFile("systemgraphics/cat1/logo-flat-tiny.png", true);
      this.RADIO1 = BitmapStore.AddFile("systemgraphics/cat1/RadioButton1.png", true);
      this.RADIO1A = BitmapStore.AddFile("systemgraphics/cat1/RadioButton1a.png", true);
      this.RADIO2 = BitmapStore.AddFile("systemgraphics/cat1/RadioButton2.png", true);
      this.RADIO2A = BitmapStore.AddFile("systemgraphics/cat1/RadioButton2a.png", true);
      this.BACKGROUND1MARC = BitmapStore.AddFile("systemgraphics/cat1/backgroundmarc.png", true);
      this.BACKGROUND3MARC = BitmapStore.AddFile("systemgraphics/cat1/background3marc.png", true);
      this.BACKGROUND5MARC = BitmapStore.AddFile("systemgraphics/cat1/background4marc.png", true);
      this.BACKTUT = BitmapStore.AddFile("systemgraphics/cat1/background3tut.png", true);
      this.BUTTONSTEVE1 = this.BUTTONMARC1;
      this.BUTTONSTEVE1b = this.BUTTONMARC1b;
      this.BUTTONLONG = BitmapStore.AddFile("systemgraphics/cat1/marclong.png", true);
      this.BUTTONLONGHIGH = BitmapStore.AddFile("systemgraphics/cat1/marclongb.png", true);
      this.BUTTONGUIUP = BitmapStore.AddFile("systemgraphics/cat1/buttonup.png", true);
      this.BUTTONGUIDOWN = BitmapStore.AddFile("systemgraphics/cat1/buttondown.png", true);
      this.BUTTONSTEVE2 = this.BUTTONMARC1;
      this.BUTTONSTEVE2B = this.BUTTONMARC1b;
      if (!Information.IsNothing((object) tformref))
        tformref.Label1.Text = "Loading System gfx cat3";
      Application.DoEvents();
      this.BUTTONSEAATTACK = BitmapStore.AddFile("systemgraphics/cat3/buttonseaattack.png", true);
      this.BUTTONINTERDICT = BitmapStore.AddFile("systemgraphics/cat3/buttonbomber.png", true);
      this.BUTTONSEAARTATTACK = BitmapStore.AddFile("systemgraphics/cat3/buttonseaartattack.png", true);
      this.BUTTONTRANSFER = BitmapStore.AddFile("systemgraphics/cat3/buttontransfer.png", true);
      this.BUTTONNEWUNIT = BitmapStore.AddFile("systemgraphics/cat3/buttonnewunit.png", true);
      this.BUTTONHQPROD = BitmapStore.AddFile("systemgraphics/cat3/buttonhqprod.png", true);
      this.BUTTONPROD = BitmapStore.AddFile("systemgraphics/cat3/buttonprod.png", true);
      this.BUTTONDRAW = BitmapStore.AddFile("systemgraphics/cat3/buttondraw.bmp", true);
      this.BUTTONUP = BitmapStore.AddFile("systemgraphics/cat3/buttonup.bmp", true);
      this.BUTTONDOWN = BitmapStore.AddFile("systemgraphics/cat3/buttondown.bmp", true);
      this.BUTTONBLOCK = BitmapStore.AddFile("systemgraphics/cat3/buttonblock.bmp", true);
      this.BUTTONBLUE = BitmapStore.AddFile("systemgraphics/cat3/buttonblue.bmp", true);
      this.BUTTONYELLOW = BitmapStore.AddFile("systemgraphics/cat3/buttonyellow.bmp", true);
      this.BUTTONFLAGGED = BitmapStore.AddFile("systemgraphics/cat3/buttonflagged.bmp", true);
      this.BUTTONUNFLAGGED = BitmapStore.AddFile("systemgraphics/cat3/buttonunflagged.bmp", true);
      this.BUTTONPLUS = BitmapStore.AddFile("systemgraphics/cat3/buttonplus.bmp", true);
      this.BUTTONKILL = BitmapStore.AddFile("systemgraphics/cat3/buttonkill.bmp", true);
      this.TEXTCLOUD = BitmapStore.AddFile("systemgraphics/cat3/textcloud.png", true);
      this.EDITDRAW = BitmapStore.AddFile("systemgraphics/cat3/editdraw.bmp", true);
      this.EDITPAINT = BitmapStore.AddFile("systemgraphics/cat3/editpaint.bmp", true);
      this.EDITPOINTER = BitmapStore.AddFile("systemgraphics/cat3/editpointer.bmp", true);
      this.BUTTONDESIGNSF = BitmapStore.AddFile("systemgraphics/cat3/buttondesignsf.png", true);
      this.BUTTONOFFICER = BitmapStore.AddFile("systemgraphics/cat3/buttonofficer.png", true);
      this.SLIDER1 = BitmapStore.AddFile("systemgraphics/cat3/slider normal.png", true);
      this.SLIDER2 = BitmapStore.AddFile("systemgraphics/cat3/slider mouse over.png", true);
      this.BUTTONSUPPLYOFF = BitmapStore.AddFile("systemgraphics/cat3/buttonsupplyoff.png", true);
      this.BUTTONGIVEHEX = BitmapStore.AddFile("systemgraphics/cat3/buttongivehex.png", true);
      this.BLOWLOCATIONBUTTON = BitmapStore.AddFile("systemgraphics/cat3/buttonblowlocation.png", true);
      this.BUTTONAIRSUPPLY = BitmapStore.AddFile("systemgraphics/cat3/buttonairsupply.png", true);
      this.BUTTONSTATISTICS = BitmapStore.AddFile("systemgraphics/cat3/buttonstatistics.png", true);
      this.BUTTONSURRENDER = BitmapStore.AddFile("systemgraphics/cat3/buttonsurrender.png", true);
      this.BUTTONDISBAND = BitmapStore.AddFile("systemgraphics/cat3/buttondisband.png", true);
      this.BUTTONNEWUNIT2 = BitmapStore.AddFile("systemgraphics/cat3/buttonnewunit2.png", true);
      this.BUTTONPASTE = BitmapStore.AddFile("systemgraphics/cat3/buttonpaste.bmp", true);
      this.BUTTONCOPY = BitmapStore.AddFile("systemgraphics/cat3/buttoncopy.bmp", true);
      this.WHITEFLAG = BitmapStore.AddFile("systemgraphics/cat3/whiteflag.bmp", true);
      this.BUTTONPREFS = BitmapStore.AddFile("systemgraphics/cat3/buttonprefs.png", true);
      this.QUESTIONBALL = BitmapStore.AddFile("systemgraphics/cat3/questionball.bmp", true);
      this.BUTTONCHANGEMODEL = BitmapStore.AddFile("systemgraphics/cat3/orderchangemodel.png", true);
      this.BUTTONMODELDESIGNER = BitmapStore.AddFile("systemgraphics/cat3/ordermodeldesigner.png", true);
      this.BUTTONBUILDLOCATION = BitmapStore.AddFile("systemgraphics/cat3/buttonbuildlocation.png", true);
      this.BUTTONQUIT = BitmapStore.AddFile("systemgraphics/cat3/buttonquit.png", true);
      this.BUTTONRESEARCH = BitmapStore.AddFile("systemgraphics/cat3/buttonresearch.png", true);
      this.BUTTONPARADROP = BitmapStore.AddFile("systemgraphics/cat3/buttonparadrop.png", true);
      this.BUTTONLOAD = BitmapStore.AddFile("systemgraphics/cat3/buttonload.png", true);
      this.BUTTONUNLOAD = BitmapStore.AddFile("systemgraphics/cat3/buttonunload.png", true);
      this.BUTTONDIP = BitmapStore.AddFile("systemgraphics/cat3/buttondip.png", true);
      if (!Information.IsNothing((object) tformref))
        tformref.Label1.Text = "Loading Cards";
      if (!Information.IsNothing((object) tformref))
        tformref.Label1.Text = "Loading Fow Gfx";
      Application.DoEvents();
      this.FOGSHEET = BitmapStore.AddFile("systemgraphics/fog/fogofwar.png", true, true);
      this.SHROWDSHEET = BitmapStore.AddFile("systemgraphics/shrowd/shrowd.png", true, true);
      if (!Information.IsNothing((object) tformref))
        tformref.Label1.Text = "Loading 'Nato' Gfx";
      Application.DoEvents();
      str1 = "";
      int num1;
      do
      {
        num1 = 0;
        int Number;
        ++Number;
        if (File.Exists(this.AppPath + "graphics/systemgraphics/" + this.ModNatoCounters + "/" + Strings.Trim(Conversion.Str((object) Number)) + ".png"))
        {
          this.NATO = (int[]) Utils.CopyArray((Array) this.NATO, (Array) new int[Number + 1]);
          num1 = 1;
          this.NATO[Number] = BitmapStore.AddFile("systemgraphics/" + this.ModNatoCounters + "/" + Strings.Trim(Conversion.Str((object) Number)) + ".png", true, true);
        }
        if (num1 == 0)
        {
          if (File.Exists(this.AppPath + "graphics/" + this.ModSystemGraphicsDirectory + "/" + this.ModNatoCounters + "/" + Strings.Trim(Conversion.Str((object) Number)) + ".png"))
          {
            this.NATO = (int[]) Utils.CopyArray((Array) this.NATO, (Array) new int[Number + 1]);
            num1 = 1;
            this.NATO[Number] = BitmapStore.AddFile("systemgraphics/" + this.ModNatoCounters + "/" + Strings.Trim(Conversion.Str((object) Number)) + ".png", true, true);
          }
        }
      }
      while (num1 == 1);
      this.SPRITE64[0, 0, 0, 0, 0, 0] = 1;
      this.SPRITE64[1, 0, 0, 0, 0, 0] = 2;
      this.SPRITE64[0, 1, 0, 0, 0, 0] = 3;
      this.SPRITE64[0, 0, 1, 0, 0, 0] = 4;
      this.SPRITE64[0, 0, 0, 1, 0, 0] = 5;
      this.SPRITE64[0, 0, 0, 0, 1, 0] = 6;
      this.SPRITE64[0, 0, 0, 0, 0, 1] = 7;
      this.SPRITE64[1, 1, 0, 0, 0, 0] = 8;
      this.SPRITE64[0, 1, 1, 0, 0, 0] = 9;
      this.SPRITE64[0, 0, 1, 1, 0, 0] = 10;
      this.SPRITE64[0, 0, 0, 1, 1, 0] = 11;
      this.SPRITE64[0, 0, 0, 0, 1, 1] = 12;
      this.SPRITE64[1, 0, 0, 0, 0, 1] = 13;
      this.SPRITE64[1, 0, 1, 0, 0, 0] = 14;
      this.SPRITE64[0, 1, 0, 1, 0, 0] = 15;
      this.SPRITE64[0, 0, 1, 0, 1, 0] = 16;
      this.SPRITE64[0, 0, 0, 1, 0, 1] = 17;
      this.SPRITE64[1, 0, 0, 0, 1, 0] = 18;
      this.SPRITE64[0, 1, 0, 0, 0, 1] = 19;
      this.SPRITE64[1, 0, 0, 1, 0, 0] = 20;
      this.SPRITE64[0, 1, 0, 0, 1, 0] = 21;
      this.SPRITE64[0, 0, 1, 0, 0, 1] = 22;
      this.SPRITE64[1, 1, 1, 0, 0, 0] = 23;
      this.SPRITE64[0, 1, 1, 1, 0, 0] = 24;
      this.SPRITE64[0, 0, 1, 1, 1, 0] = 25;
      this.SPRITE64[0, 0, 0, 1, 1, 1] = 26;
      this.SPRITE64[1, 0, 0, 0, 1, 1] = 27;
      this.SPRITE64[1, 1, 0, 0, 0, 1] = 28;
      this.SPRITE64[1, 1, 0, 1, 0, 0] = 29;
      this.SPRITE64[0, 1, 1, 0, 1, 0] = 30;
      this.SPRITE64[0, 0, 1, 1, 0, 1] = 31;
      this.SPRITE64[1, 0, 0, 1, 1, 0] = 32;
      this.SPRITE64[0, 1, 0, 0, 1, 1] = 33;
      this.SPRITE64[1, 0, 1, 0, 0, 1] = 34;
      this.SPRITE64[1, 1, 0, 0, 1, 0] = 35;
      this.SPRITE64[0, 1, 1, 0, 0, 1] = 36;
      this.SPRITE64[1, 0, 1, 1, 0, 0] = 37;
      this.SPRITE64[0, 1, 0, 1, 1, 0] = 38;
      this.SPRITE64[0, 0, 1, 0, 1, 1] = 39;
      this.SPRITE64[1, 0, 0, 1, 0, 1] = 40;
      this.SPRITE64[1, 0, 1, 0, 1, 0] = 41;
      this.SPRITE64[0, 1, 0, 1, 0, 1] = 42;
      this.SPRITE64[0, 0, 1, 1, 1, 1] = 43;
      this.SPRITE64[1, 0, 0, 1, 1, 1] = 44;
      this.SPRITE64[1, 1, 0, 0, 1, 1] = 45;
      this.SPRITE64[1, 1, 1, 0, 0, 1] = 46;
      this.SPRITE64[1, 1, 1, 1, 0, 0] = 47;
      this.SPRITE64[0, 1, 1, 1, 1, 0] = 48;
      this.SPRITE64[0, 1, 0, 1, 1, 1] = 49;
      this.SPRITE64[1, 0, 1, 0, 1, 1] = 50;
      this.SPRITE64[1, 1, 0, 1, 0, 1] = 51;
      this.SPRITE64[1, 1, 1, 0, 1, 0] = 52;
      this.SPRITE64[0, 1, 1, 1, 0, 1] = 53;
      this.SPRITE64[1, 0, 1, 1, 1, 0] = 54;
      this.SPRITE64[0, 1, 1, 0, 1, 1] = 55;
      this.SPRITE64[1, 0, 1, 1, 0, 1] = 56;
      this.SPRITE64[1, 1, 0, 1, 1, 0] = 57;
      this.SPRITE64[0, 1, 1, 1, 1, 1] = 58;
      this.SPRITE64[1, 0, 1, 1, 1, 1] = 59;
      this.SPRITE64[1, 1, 0, 1, 1, 1] = 60;
      this.SPRITE64[1, 1, 1, 0, 1, 1] = 61;
      this.SPRITE64[1, 1, 1, 1, 0, 1] = 62;
      this.SPRITE64[1, 1, 1, 1, 1, 0] = 63;
      this.SPRITE64[1, 1, 1, 1, 1, 1] = 64;
      this.SHEETX[1] = 5;
      this.SHEETY[1] = 10;
      this.SHEETX[2] = 0;
      this.SHEETY[2] = 0;
      this.SHEETX[3] = 1;
      this.SHEETY[3] = 0;
      this.SHEETX[4] = 2;
      this.SHEETY[4] = 0;
      this.SHEETX[5] = 3;
      this.SHEETY[5] = 0;
      this.SHEETX[6] = 4;
      this.SHEETY[6] = 0;
      this.SHEETX[7] = 5;
      this.SHEETY[7] = 0;
      this.SHEETX[8] = 0;
      this.SHEETY[8] = 1;
      this.SHEETX[9] = 5;
      this.SHEETY[9] = 1;
      this.SHEETX[10] = 3;
      this.SHEETY[10] = 2;
      this.SHEETX[11] = 0;
      this.SHEETY[11] = 3;
      this.SHEETX[12] = 2;
      this.SHEETY[12] = 3;
      this.SHEETX[13] = 4;
      this.SHEETY[13] = 1;
      this.SHEETX[14] = 1;
      this.SHEETY[14] = 1;
      this.SHEETX[15] = 0;
      this.SHEETY[15] = 2;
      this.SHEETX[16] = 4;
      this.SHEETY[16] = 2;
      this.SHEETX[17] = 1;
      this.SHEETY[17] = 3;
      this.SHEETX[18] = 3;
      this.SHEETY[18] = 1;
      this.SHEETX[19] = 2;
      this.SHEETY[19] = 2;
      this.SHEETX[20] = 2;
      this.SHEETY[20] = 1;
      this.SHEETX[21] = 1;
      this.SHEETY[21] = 2;
      this.SHEETX[22] = 5;
      this.SHEETY[22] = 2;
      this.SHEETX[23] = 3;
      this.SHEETY[23] = 3;
      this.SHEETX[24] = 1;
      this.SHEETY[24] = 5;
      this.SHEETX[25] = 1;
      this.SHEETY[25] = 6;
      this.SHEETX[26] = 4;
      this.SHEETY[26] = 6;
      this.SHEETX[27] = 0;
      this.SHEETY[27] = 5;
      this.SHEETX[28] = 0;
      this.SHEETY[28] = 4;
      this.SHEETX[29] = 4;
      this.SHEETY[29] = 3;
      this.SHEETX[30] = 2;
      this.SHEETY[30] = 5;
      this.SHEETX[31] = 2;
      this.SHEETY[31] = 6;
      this.SHEETX[32] = 4;
      this.SHEETY[32] = 4;
      this.SHEETX[33] = 0;
      this.SHEETY[33] = 6;
      this.SHEETX[34] = 3;
      this.SHEETY[34] = 4;
      this.SHEETX[35] = 5;
      this.SHEETY[35] = 3;
      this.SHEETX[36] = 3;
      this.SHEETY[36] = 5;
      this.SHEETX[37] = 1;
      this.SHEETY[37] = 4;
      this.SHEETX[38] = 4;
      this.SHEETY[38] = 5;
      this.SHEETX[39] = 3;
      this.SHEETY[39] = 6;
      this.SHEETX[40] = 5;
      this.SHEETY[40] = 4;
      this.SHEETX[41] = 2;
      this.SHEETY[41] = 4;
      this.SHEETX[42] = 5;
      this.SHEETY[42] = 5;
      this.SHEETX[43] = 4;
      this.SHEETY[43] = 8;
      this.SHEETX[44] = 1;
      this.SHEETY[44] = 9;
      this.SHEETX[45] = 4;
      this.SHEETY[45] = 7;
      this.SHEETX[46] = 1;
      this.SHEETY[46] = 7;
      this.SHEETX[47] = 5;
      this.SHEETY[47] = 6;
      this.SHEETX[48] = 5;
      this.SHEETY[48] = 7;
      this.SHEETX[49] = 2;
      this.SHEETY[49] = 8;
      this.SHEETX[50] = 0;
      this.SHEETY[50] = 9;
      this.SHEETX[51] = 3;
      this.SHEETY[51] = 7;
      this.SHEETX[52] = 0;
      this.SHEETY[52] = 7;
      this.SHEETX[53] = 0;
      this.SHEETY[53] = 8;
      this.SHEETX[54] = 3;
      this.SHEETY[54] = 8;
      this.SHEETX[55] = 1;
      this.SHEETY[55] = 8;
      this.SHEETX[56] = 5;
      this.SHEETY[56] = 8;
      this.SHEETX[57] = 2;
      this.SHEETY[57] = 7;
      this.SHEETX[58] = 1;
      this.SHEETY[58] = 10;
      this.SHEETX[59] = 0;
      this.SHEETY[59] = 10;
      this.SHEETX[60] = 5;
      this.SHEETY[60] = 9;
      this.SHEETX[61] = 4;
      this.SHEETY[61] = 9;
      this.SHEETX[62] = 3;
      this.SHEETY[62] = 9;
      this.SHEETX[63] = 2;
      this.SHEETY[63] = 9;
      this.SHEETX[64] = 2;
      this.SHEETY[64] = 10;
      this.ARROW64[1, 0, 0, 0, 0, 0] = 1;
      this.ARROW64[0, 1, 0, 0, 0, 0] = 2;
      this.ARROW64[0, 0, 1, 0, 0, 0] = 3;
      this.ARROW64[0, 0, 0, 1, 0, 0] = 4;
      this.ARROW64[0, 0, 0, 0, 1, 0] = 5;
      this.ARROW64[0, 0, 0, 0, 0, 1] = 6;
      this.ARROW64[1, 2, 0, 0, 0, 0] = 7;
      this.ARROW64[1, 0, 2, 0, 0, 0] = 8;
      this.ARROW64[1, 0, 0, 2, 0, 0] = 9;
      this.ARROW64[1, 0, 0, 0, 2, 0] = 10;
      this.ARROW64[1, 0, 0, 0, 0, 2] = 11;
      this.ARROW64[0, 1, 2, 0, 0, 0] = 12;
      this.ARROW64[0, 1, 0, 2, 0, 0] = 13;
      this.ARROW64[0, 1, 0, 0, 2, 0] = 14;
      this.ARROW64[0, 1, 0, 0, 0, 2] = 15;
      this.ARROW64[0, 0, 1, 2, 0, 0] = 16;
      this.ARROW64[0, 0, 1, 0, 2, 0] = 17;
      this.ARROW64[0, 0, 1, 0, 0, 2] = 18;
      this.ARROW64[0, 0, 0, 1, 2, 0] = 19;
      this.ARROW64[0, 0, 0, 1, 0, 2] = 20;
      this.ARROW64[0, 0, 0, 0, 1, 2] = 21;
      this.ARROW64[2, 1, 0, 0, 0, 0] = 7;
      this.ARROW64[2, 0, 1, 0, 0, 0] = 8;
      this.ARROW64[2, 0, 0, 1, 0, 0] = 9;
      this.ARROW64[2, 0, 0, 0, 1, 0] = 10;
      this.ARROW64[2, 0, 0, 0, 0, 1] = 11;
      this.ARROW64[0, 2, 1, 0, 0, 0] = 12;
      this.ARROW64[0, 2, 0, 1, 0, 0] = 13;
      this.ARROW64[0, 2, 0, 0, 1, 0] = 14;
      this.ARROW64[0, 2, 0, 0, 0, 1] = 15;
      this.ARROW64[0, 0, 2, 1, 0, 0] = 16;
      this.ARROW64[0, 0, 2, 0, 1, 0] = 17;
      this.ARROW64[0, 0, 2, 0, 0, 1] = 18;
      this.ARROW64[0, 0, 0, 2, 1, 0] = 19;
      this.ARROW64[0, 0, 0, 2, 0, 1] = 20;
      this.ARROW64[0, 0, 0, 0, 2, 1] = 21;
      this.ARROW64[2, 0, 0, 0, 0, 0] = 25;
      this.ARROW64[0, 2, 0, 0, 0, 0] = 26;
      this.ARROW64[0, 0, 2, 0, 0, 0] = 27;
      this.ARROW64[0, 0, 0, 2, 0, 0] = 28;
      this.ARROW64[0, 0, 0, 0, 2, 0] = 29;
      this.ARROW64[0, 0, 0, 0, 0, 2] = 30;
      Application.DoEvents();
      this.Data = new DataClass();
      Application.DoEvents();
      if (Operators.CompareString(this.ModSystemGraphicsDirectory, "systemgraphics", false) != 0)
        BitmapStore.ReloadSystemGraphics(this.ModSystemGraphicsDirectory);
      else
        BitmapStore.lastreloadsystemgfx = "";
      Application.DoEvents();
      this.CornerX = 0;
      this.CornerY = 0;
      this.SelectX = -1;
      this.SelectY = -1;
      if (this.ModScenario.Length > 1)
      {
        string str2 = this.AppPath + this.ModScenario;
        if (!Information.IsNothing((object) tformref))
          tformref.Label1.Text = "Loading Scn Gfx 1/6";
        Application.DoEvents();
        this.HandyFunctionsObj.Unzip(str2);
        if (!Information.IsNothing((object) tformref))
          tformref.Label1.Text = "Loading Scn Gfx 2/6";
        Application.DoEvents();
        this.Data = DataClass.deserialize(str2);
        if (!Information.IsNothing((object) tformref))
          tformref.Label1.Text = "Loading Scn Gfx 3/6";
        Application.DoEvents();
        this.HandyFunctionsObj.ZipFile(str2);
        this.Data.LoadGraphics(tformref);
      }
      if (!Information.IsNothing((object) tformref))
        tformref.Label1.Text = "Finishing Up";
      Application.DoEvents();
      this.CustomBitmapObj = new CustomBitmapClass(this);
      this.HelpCounter = -1;
      this.ProcessingObj = new ProcessingClass(this);
      this.EventRelatedObj = new EventRelatedClass(this);
      this.EditObj = new EditClass(this.AppPath + "editobj.txt");
      if (this.useModLib)
      {
        this.modlib_Initialize();
        this.modlib_loadPrefs();
      }
      Application.DoEvents();
    }

    public void LoadHelpFiles()
    {
      FileInfo[] files;
      bool flag;
      try
      {
        files = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "help/").GetFiles("*.txt", SearchOption.AllDirectories);
        flag = false;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        flag = true;
        ProjectData.ClearProjectError();
      }
      this.HelpCounter = -1;
      if (flag || files.Length <= 0)
        return;
      foreach (FileInfo fileInfo in files)
      {
        ++this.HelpCounter;
        StreamReader streamReader = File.OpenText(fileInfo.DirectoryName + "\\" + fileInfo.Name);
        string end = streamReader.ReadToEnd();
        streamReader.Close();
        this.HelpFile = (string[]) Utils.CopyArray((Array) this.HelpFile, (Array) new string[this.HelpCounter + 1]);
        this.HelpText = (string[]) Utils.CopyArray((Array) this.HelpText, (Array) new string[this.HelpCounter + 1]);
        this.HelpDir = (string[]) Utils.CopyArray((Array) this.HelpDir, (Array) new string[this.HelpCounter + 1]);
        this.HelpText[this.HelpCounter] = end;
        this.HelpFile[this.HelpCounter] = fileInfo.Name.Replace(".txt", "");
        string str = fileInfo.DirectoryName.Replace("/", "\\").Replace(AppDomain.CurrentDomain.BaseDirectory + "help\\", "").Replace(AppDomain.CurrentDomain.BaseDirectory + "help", "");
        str.Replace("\\", ":");
        this.HelpDir[this.HelpCounter] = str;
      }
    }

    public void modlib_Initialize()
    {
      FileInfo[] files = new DirectoryInfo(this.AppPath + this.ModScenarioDir + "/").GetFiles();
      this.modlib_Counter = -1;
      foreach (FileInfo fileInfo in files)
      {
        if (Strings.InStr(fileInfo.Extension.ToLower(), ".se1evlib") > 0 && Strings.InStr(fileInfo.Name.ToLower(), "_v") < 1 & Strings.InStr(fileInfo.Name.ToLower(), "default") < 1)
        {
          bool flag = false;
          this.EditObj.TempFileName = fileInfo.FullName.ToString();
          DataClass tData;
          this.HandyFunctionsObj.LoadLibrary(ref tData);
          this.EditObj.TempFileName = "";
          if (tData.LibraryCounter > -1)
            flag = true;
          if (flag)
          {
            ++this.modlib_Counter;
            this.modlib_Description = (string[]) Utils.CopyArray((Array) this.modlib_Description, (Array) new string[this.modlib_Counter + 1]);
            this.modlib_Designer = (string[]) Utils.CopyArray((Array) this.modlib_Designer, (Array) new string[this.modlib_Counter + 1]);
            this.modlib_Filename = (string[]) Utils.CopyArray((Array) this.modlib_Filename, (Array) new string[this.modlib_Counter + 1]);
            this.modlib_Flagged = (bool[]) Utils.CopyArray((Array) this.modlib_Flagged, (Array) new bool[this.modlib_Counter + 1]);
            this.modlib_Name = (string[]) Utils.CopyArray((Array) this.modlib_Name, (Array) new string[this.modlib_Counter + 1]);
            this.modlib_Version = (int[]) Utils.CopyArray((Array) this.modlib_Version, (Array) new int[this.modlib_Counter + 1]);
            this.modlib_Filename[this.modlib_Counter] = fileInfo.Name;
            this.modlib_Description[this.modlib_Counter] = tData.LibraryObj[0].information;
            this.modlib_Designer[this.modlib_Counter] = tData.LibraryObj[0].creator;
            this.modlib_Flagged[this.modlib_Counter] = false;
            this.modlib_Name[this.modlib_Counter] = tData.LibraryObj[0].name;
            this.modlib_Version[this.modlib_Counter] = tData.LibraryObj[0].version;
          }
          tData = (DataClass) null;
        }
      }
      int num = num;
    }

    public void modlib_loadPrefs()
    {
      FileInfo fileInfo = new FileInfo(this.AppPath + "modlib.txt");
      if (fileInfo.Exists)
      {
        StreamReader streamReader = fileInfo.OpenText();
        while (!streamReader.EndOfStream)
        {
          try
          {
            string Expression1 = streamReader.ReadLine();
            string Expression2 = streamReader.ReadLine();
            if (!Information.IsNothing((object) Expression1) & !Information.IsNothing((object) Expression2))
            {
              bool boolean = Conversions.ToBoolean(Expression2);
              int modlibCounter = this.modlib_Counter;
              for (int index = 0; index <= modlibCounter; ++index)
              {
                if (Operators.CompareString(this.modlib_Filename[index].ToLower(), Expression1.ToLower(), false) == 0)
                  this.modlib_Flagged[index] = boolean;
              }
            }
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            streamReader.Close();
            ProjectData.ClearProjectError();
            break;
          }
        }
        streamReader.Close();
      }
      this.modlib_savePrefs();
    }

    public void modlib_savePrefs()
    {
      StreamWriter text = File.CreateText(this.AppPath + "modlib.txt");
      int modlibCounter = this.modlib_Counter;
      for (int index = 0; index <= modlibCounter; ++index)
      {
        text.WriteLine(this.modlib_Filename[index]);
        text.WriteLine(this.modlib_Flagged[index]);
      }
      text.Close();
    }
  }
}
