using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.EventSystems;

public class Launcher_pun : MonoBehaviourPunCallbacks
{
    public static Launcher_pun instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    public GameObject loadingScreen;
    public TMP_Text loadingText;
    public GameObject CreateRoomPanel;
    public TMP_InputField createroom;
    public GameObject menuButtons;
    public GameObject roomScreen;
    public TMP_Text roomNameText;
    public GameObject errorScreen;
    public TMP_Text errorText;
    public GameObject roomBrowserScreen;
    public RoomButton theRoomButton;
    public TMP_Text  playerNameLabel;
    private List<TMP_Text> allPlayerNames = new List<TMP_Text>();
    private List<RoomButton> allRoomButtons = new List<RoomButton>();
    public GameObject nameInputScreen;
    public TMP_InputField nameInput;
    private bool hasSetNick;
    public string levelToPlay;
    public GameObject startButton;
    public GameObject roomTestButton;
    void Start()
    {
        CloseMenus();
        loadingScreen.SetActive(true);
        loadingText.text = "Connecting to Network..";

        PhotonNetwork.ConnectUsingSettings();

#if UNITY_EDITON
          roomTestButton.SetActive(true);
#endif
    }
    void CloseMenus()
    {
        loadingScreen.SetActive(false);
        menuButtons.SetActive(false);
        CreateRoomPanel.SetActive(false);
        roomScreen.SetActive(false);
        roomBrowserScreen.SetActive(false);
        nameInputScreen.SetActive(false);   
    }

    public override void OnConnectedToMaster()
    {

        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
        loadingText.text = "Joining Lobby...";
    }
    public override void OnJoinedLobby()
    {
        PhotonNetwork.NickName = Random.Range(0, 1000).ToString();
        CloseMenus();
        menuButtons.SetActive(true);
        if (!hasSetNick)
        {
            CloseMenus();
            nameInputScreen.SetActive(true);

            if (PlayerPrefs.HasKey("playerName"))
            {
                nameInput.text = PlayerPrefs.GetString("playerName");
            }
        }
        else
        {
            PhotonNetwork.NickName = PlayerPrefs.GetString("playerName");
        }
    }

    public void OncreateRoom_btn()
    {
        CloseMenus();
        CreateRoomPanel.SetActive(true);
    }
    public void CreateRoom()
    {
        if (!string.IsNullOrEmpty(createroom.text))
        {
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = 8;
            PhotonNetwork.CreateRoom(createroom.text);

            CloseMenus();
            loadingText.text = "Creating Room..";
            loadingScreen.SetActive(true);
        }
    }
    public override void OnJoinedRoom()
    {
        CloseMenus();
        ListAllPlayers();
        roomScreen.SetActive(true);
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;
        if (PhotonNetwork.IsMasterClient)
        {
            startButton.SetActive(true);
        }
        else
        {
            startButton.SetActive(false);
        }
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Failed To Create Room: " + message;
        CloseMenus();
        errorScreen.SetActive(true);
    }

    public void CloseErrorScreen()
    {
        CloseMenus();
        menuButtons.SetActive(true);
    }
    // Update is called once per frame
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        CloseMenus();
        loadingText.text = "Leaving Room";
        loadingScreen.SetActive(true);
    }
    public override void OnLeftRoom()
    {
        CloseMenus();
        menuButtons.SetActive(true);
    }
    public void OpenRoomBrowser()
    {
        CloseMenus();
        roomBrowserScreen.SetActive(true);
    }

    public void CloseRoomBrowser()
    {
        CloseMenus();
        menuButtons.SetActive(true);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomButton rb in allRoomButtons)
        {
            Destroy(rb.gameObject);

        }
        allRoomButtons.Clear();

        theRoomButton.gameObject.SetActive(false);

        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].PlayerCount != roomList[i].MaxPlayers && !roomList[i].RemovedFromList)
            {
                RoomButton newButton = Instantiate(theRoomButton, theRoomButton.transform.parent);
                newButton.SetButtonDetails(roomList[i]);
                newButton.gameObject.SetActive(true);

                allRoomButtons.Add(newButton);

            }
        }

    }
    public void JoinRoom(RoomInfo inputInfo)
    {
        PhotonNetwork.JoinRoom(inputInfo.Name);

        CloseMenus();
        loadingText.text = "Joining Room";
        loadingScreen.SetActive(true);

    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        TMP_Text newPlayerLabel = Instantiate(playerNameLabel, playerNameLabel.transform.parent);
        newPlayerLabel.text = newPlayer.NickName;
        newPlayerLabel.gameObject.SetActive(true);

        allPlayerNames.Add(newPlayerLabel);

    }

    public override void OnPlayerLeftRoom(Player newPlayer)
    {
        ListAllPlayers();
    }
    private void ListAllPlayers()
    {
        foreach (TMP_Text player in allPlayerNames)
        {
            Destroy(player.gameObject);
        }
        allPlayerNames.Clear();
        Player[] players = PhotonNetwork.PlayerList;
        for (int i = 0; i < players.Length; i++)
        {
            TMP_Text newPlayerLabel = Instantiate(playerNameLabel, playerNameLabel.transform.parent);
            newPlayerLabel.text = players[i].NickName;
            newPlayerLabel.gameObject.SetActive(true);

            allPlayerNames.Add(newPlayerLabel);

        }
    }
    public void SetNickName()
    {
        if (!string.IsNullOrEmpty(nameInput.text))
        {
            PhotonNetwork.NickName = nameInput.text;

            PlayerPrefs.SetString("playerName", nameInput.text);

            CloseMenus();
            menuButtons.SetActive(true);

            hasSetNick = true;
        }
    }
    public void StartGame()
    {
        PhotonNetwork.LoadLevel(levelToPlay);
    }
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            startButton.SetActive(true);
        }
        else
        {
            startButton.SetActive(false);
        }
    }

    public void QuickJoin()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 8;

        PhotonNetwork.CreateRoom("Test");
        CloseMenus();
        loadingText.text = "Creating Room";
        loadingScreen.SetActive(true);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    //void Update()
    //{

    //}
}
