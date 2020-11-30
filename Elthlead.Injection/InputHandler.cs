using System;
using Elthlead.Framework;
using GameCommon;
using UnityEngine;

namespace Elthlead.Injection
{
    public sealed class InputHandler
    {
        public void Update()
        {
            try
            {
                if (Input.GetKeyUp(KeyCode.F5))
                {
                    GameObject gameSoundOBJ = GameObject.Find("GameSound");
                    SoundPlayerCTRL soundCTRL = gameSoundOBJ.GetComponent<SoundPlayerCTRL>();
                    
                    GameObject systemObj = GameObject.Find("_SystemCTRL");
                    _SystemCTRL sysCtrl = systemObj.GetComponent<_SystemCTRL>();
                    
                    UnitManager unitManager = GameObject.FindObjectOfType<UnitManager>();
                    UnitWork[] unitWork = unitManager.GetUnitWork();
                    
                    GameSystemWork gameSystemWork = StWorkProxy.GameSystemWork;
                    Int32 slotNumber = gameSystemWork.gameSelect == 1 ? 2 : 6;
                    
                    if (gameSystemWork.gamePhase != 0 || gameSystemWork.gameMode != 0)
                    {
                        soundCTRL.Audio_PlaySE(7);
                        return;
                    }

                    sysCtrl.Save_SystemBackupData();
                    sysCtrl.Save_GameBackupData(slotNumber, unitWork, gameSystemWork);
                    
                    soundCTRL.Audio_PlaySE(4);
                }
                else if (Input.GetKeyUp(KeyCode.F9))
                {
                    GameObject gameSoundOBJ = GameObject.Find("GameSound");
                    SoundPlayerCTRL soundCTRL = gameSoundOBJ.GetComponent<SoundPlayerCTRL>();

                    GameObject systemObj = GameObject.Find("_SystemCTRL");
                    _SystemCTRL sysCtrl = systemObj.GetComponent<_SystemCTRL>();
                    
                    UnitManager unitManager = GameObject.FindObjectOfType<UnitManager>();
                    MapViewCTRL mapView = GameObject.FindObjectOfType<MapViewCTRL>();
                    
                    GameSystemWork gameSystemWork = StWorkProxy.GameSystemWork;
                    Int32 slotNumber = gameSystemWork.gameSelect == 1 ? 2 : 6;

                    GameBackupData gameData = sysCtrl.Load_GameBackupData(slotNumber);
                    
                    if (gameSystemWork.gamePhase != 0 || gameSystemWork.gameMode != 0 || gameData.gameSystem.scenarioNumber != gameSystemWork.scenarioNumber)
                    {
                        soundCTRL.Audio_PlaySE(7);
                        return;
                    }

                    sysCtrl.Load_SystemBackupData();

                    gameSystemWork.gameSelect = gameData.gameSystem.gameSelect;
                    gameSystemWork.scenarioNumber = gameData.gameSystem.scenarioNumber;
                    gameSystemWork.scenarioRouteIndex = gameData.gameSystem.scenarioRouteIndex;
                    gameSystemWork.scenarioIndex = gameData.gameSystem.scenarioIndex;
                    gameSystemWork.sysData0_USEDLC = gameData.gameSystem.sysData0_USEDLC;
                    gameSystemWork.sysData1 = gameData.gameSystem.sysData1;
                    gameSystemWork.sysData2 = gameData.gameSystem.sysData2;
                    gameSystemWork.sysData3 = gameData.gameSystem.sysData3;
                    gameSystemWork.BGMNumber = gameData.gameSystem.BGMNumber;
                    gameSystemWork.BGMPlayer = gameData.gameSystem.BGMPlayer;
                    gameSystemWork.BGMEnemy = gameData.gameSystem.BGMEnemy;
                    gameSystemWork.money = gameData.gameSystem.money;
                    gameSystemWork.mapCursol_X = gameData.gameSystem.mapCursol_X;
                    gameSystemWork.mapCursol_Y = gameData.gameSystem.mapCursol_Y;
                    gameSystemWork.mapSYSPAD0 = gameData.gameSystem.mapSYSPAD0;
                    gameSystemWork.mapSYSPAD1 = gameData.gameSystem.mapSYSPAD1;
                    gameSystemWork.gameScene = gameData.gameSystem.gameScene;
                    gameSystemWork.gameTurn = gameData.gameSystem.gameTurn;
                    gameSystemWork.gamePhase = gameData.gameSystem.gamePhase;
                    gameSystemWork.gameMode = gameData.gameSystem.gameMode;
                    gameSystemWork.gameMiniMap = gameData.gameSystem.gameMiniMap;
                    gameSystemWork.gameUnitColor = gameData.gameSystem.gameUnitColor;
                    gameSystemWork.gameUnitArea = gameData.gameSystem.gameUnitArea;
                    gameSystemWork.gameCONFIGPAD = gameData.gameSystem.gameCONFIGPAD;
                    gameSystemWork.scriptScene = gameData.gameSystem.scriptScene;
                    gameSystemWork.scriptMode = gameData.gameSystem.scriptMode;
                    gameSystemWork.scriptNumber = gameData.gameSystem.scriptNumber;
                    gameSystemWork.scriptIndex = gameData.gameSystem.scriptIndex;
                    gameSystemWork.scriptTop = gameData.gameSystem.scriptTop;
                    gameSystemWork.scriptMapState = gameData.gameSystem.scriptMapState;
                    gameSystemWork.scriptWinLose = gameData.gameSystem.scriptWinLose;
                    gameSystemWork.scriptPAD = gameData.gameSystem.scriptPAD;
                    gameSystemWork.backLogCount = gameData.gameSystem.backLogCount;
                    gameSystemWork.backLogTop = gameData.gameSystem.backLogTop;
                    gameSystemWork.sysPAD1 = gameData.gameSystem.sysPAD1;
                    gameSystemWork.randomIndex = gameData.gameSystem.randomIndex;
                    gameSystemWork.scenarioClear = gameData.gameSystem.scenarioClear;
                    gameSystemWork.nextScenario = gameData.gameSystem.nextScenario;
                    gameSystemWork.getMoney = gameData.gameSystem.getMoney;
                    gameSystemWork.endingNumber = gameData.gameSystem.endingNumber;
                    gameSystemWork.mercenaryNew = gameData.gameSystem.mercenaryNew;
                    gameSystemWork.magicNew = gameData.gameSystem.magicNew;
                    gameSystemWork.skillNew = gameData.gameSystem.skillNew;
                    gameSystemWork.itemNew = gameData.gameSystem.itemNew;
                    gameSystemWork.backLog = gameData.gameSystem.backLog;
                    gameSystemWork.itemStock = gameData.gameSystem.itemStock;
                    gameSystemWork.itemEquip = gameData.gameSystem.itemEquip;
                    gameSystemWork.eventFlag = gameData.gameSystem.eventFlag;
                    gameSystemWork.scenarioFlag = gameData.gameSystem.scenarioFlag;
                    gameSystemWork.randomPattern = gameData.gameSystem.randomPattern;
                    gameSystemWork.scenarioRoute = gameData.gameSystem.scenarioRoute;

                    unitManager.ReLoadUnitWork(gameData);
                    unitManager.myUpdate();
                    mapView.myUpdate();

                    soundCTRL.Audio_PlaySE(4);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"[{nameof(InputHandler)}] Failed to update.");
            }
        }
    }
}