using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Poker
{
    public partial class Form1 : Form
    {
        #region 列舉

        private enum Side
        {
            None,
            Player,
            AI
        }

        private enum TurnOwner
        {
            Player,
            AI
        }

        private enum GamePhase
        {
            Playing,
            GameOver
        }

        #endregion

        #region 資料結構

        private struct Cell
        {
            public Side Owner;
            public int Value;
        }

        private struct LineScoreDetail
        {
            public int LineIndex;
            public string LineName;
            public int Sum;
            public int[] CellIndices;
        }

        #endregion

        #region 常數與欄位

        private const int BoardSize = 9;
        private const int HandLimit = 3;
        private const int LineCount = 8;
        private const int JokerCard = 0;

        private static readonly int[][] Lines = new int[][]
        {
            new[] { 0, 1, 2 },
            new[] { 3, 4, 5 },
            new[] { 6, 7, 8 },
            new[] { 0, 3, 6 },
            new[] { 1, 4, 7 },
            new[] { 2, 5, 8 },
            new[] { 0, 4, 8 },
            new[] { 2, 4, 6 }
        };

        private static readonly string[] LineNames = new string[]
        {
            "橫列上", "橫列中", "橫列下",
            "直欄左", "直欄中", "直欄右",
            "斜線＼", "斜線／"
        };

        private static readonly Color PlayerCellColor = Color.FromArgb(255, 228, 225);   // 暖紅粉
        private static readonly Color AICellColor = Color.FromArgb(220, 235, 255);       // 冷藍
        private static readonly Color EmptyCellColor = Color.FromArgb(235, 235, 235);    // 中性灰
        private static readonly Color SelectedHandBorderColor = Color.FromArgb(255, 196, 60); // 金黃

        private Panel[] boardCells;
        private PictureBox[] picBoardCards;
        private Label[] lblBoardValues;

        private PictureBox[] picPlayerHand;
        private PictureBox[] picAIHand;

        private readonly Cell[] board = new Cell[BoardSize];
        private readonly List<int> deck = new List<int>();
        private readonly List<int> playerHand = new List<int>();
        private readonly List<int> aiHand = new List<int>();

        private TurnOwner currentTurn = TurnOwner.Player;
        private GamePhase phase = GamePhase.Playing;
        private string statusMessage = string.Empty;
        private bool actionTakenThisTurn;
        private int selectedHandIndex = -1;
        private bool pendingJokerRemove;

        private readonly Random rng = new Random();

        private static bool IsJoker(int card)
        {
            return card == JokerCard;
        }

        private static string FormatHandCardDisplay(int card)
        {
            return IsJoker(card) ? "鬼" : card.ToString();
        }

        #endregion

        public Form1()
        {
            InitializeComponent();
            InitializeControlArrays();
            ApplyCardGameTheme();
            WireBoardCellEvents();
            WireHandCardEvents();
            StartNewGame();
        }

        private void ApplyCardGameTheme()
        {
            Color formBg = Color.FromArgb(245, 242, 235);          // 整體淺米色
            Color statusBg = Color.FromArgb(250, 248, 243);        // 狀態列
            Color boardAreaBg = Color.FromArgb(232, 226, 214);     // 棋盤外框區
            Color playerZoneBg = Color.FromArgb(255, 244, 240);    // 玩家區暖色
            Color aiZoneBg = Color.FromArgb(240, 247, 255);        // AI 區冷色
            Color deckZoneBg = Color.FromArgb(248, 244, 236);      // 牌庫區
            Color actionZoneBg = Color.FromArgb(246, 241, 232);    // 操作區
            Color darkText = Color.FromArgb(45, 45, 45);
            Color mutedText = Color.FromArgb(90, 90, 90);

            Font titleFont = new Font("微軟正黑體", 11F, FontStyle.Bold);
            Font contentFont = new Font("微軟正黑體", 10F, FontStyle.Regular);
            Font buttonFont = new Font("微軟正黑體", 11F, FontStyle.Bold);
            Font statusFont = new Font("微軟正黑體", 10F, FontStyle.Regular);

            this.Text = "卡牌井字對戰";
            this.BackColor = formBg;
            this.ForeColor = darkText;
            this.Font = contentFont;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            grpStatus.Text = "遊戲資訊";
            grpBoard.Text = "對戰棋盤";
            grpDeck.Text = "牌庫";
            grpPlayerHand.Text = "玩家區";
            grpAIHand.Text = "AI 對手區";
            grpActions.Text = "操作區";

            StyleGroupBox(grpStatus, statusBg, titleFont, darkText);
            StyleGroupBox(grpBoard, boardAreaBg, titleFont, darkText);
            StyleGroupBox(grpDeck, deckZoneBg, titleFont, darkText);
            StyleGroupBox(grpPlayerHand, playerZoneBg, titleFont, Color.FromArgb(130, 40, 40));
            StyleGroupBox(grpAIHand, aiZoneBg, titleFont, Color.FromArgb(40, 70, 130));
            StyleGroupBox(grpActions, actionZoneBg, titleFont, darkText);

            lblTurn.Font = new Font("微軟正黑體", 11F, FontStyle.Bold);
            lblTurn.ForeColor = Color.FromArgb(70, 70, 70);

            lblDeckRemain.Font = new Font("微軟正黑體", 11F, FontStyle.Bold);
            lblDeckRemain.ForeColor = Color.FromArgb(70, 70, 70);

            lblMessage.Font = statusFont;
            lblMessage.BackColor = Color.White;
            lblMessage.ForeColor = mutedText;
            lblMessage.BorderStyle = BorderStyle.FixedSingle;
            lblMessage.Padding = new Padding(8, 4, 8, 4);

            lblDeckTitle.Font = new Font("微軟正黑體", 10F, FontStyle.Bold);
            lblDeckTitle.ForeColor = darkText;

            lblDeckCount.Font = new Font("微軟正黑體", 10F, FontStyle.Bold);
            lblDeckCount.ForeColor = darkText;

            lblPlayerHandInfo.Font = new Font("微軟正黑體", 10F, FontStyle.Bold);
            lblPlayerHandInfo.ForeColor = Color.FromArgb(130, 40, 40);

            lblAIHandInfo.Font = new Font("微軟正黑體", 10F, FontStyle.Bold);
            lblAIHandInfo.ForeColor = Color.FromArgb(40, 70, 130);

            btnDrawCard.Text = "抽一張牌";
            btnRestart.Text = "重新開始";

            StyleButton(btnDrawCard, Color.FromArgb(66, 133, 244), Color.White, buttonFont);
            StyleButton(btnRestart, Color.FromArgb(160, 82, 45), Color.White, buttonFont);

            flpPlayerHand.BackColor = Color.Transparent;
            flpAIHand.BackColor = Color.Transparent;
            tblBoard.BackColor = Color.FromArgb(210, 202, 188);

            StylePictureBoxes(picPlayerHand, Color.FromArgb(255, 252, 250));
            StylePictureBoxes(picAIHand, Color.FromArgb(250, 252, 255));
            StyleBoardCells();

            picDeck.BackColor = Color.White;
            picDeck.BorderStyle = BorderStyle.FixedSingle;

            lblMessage.Text = "請先點選手牌，再點選九宮格空格放牌。若選到鬼牌，請點選場上已有牌。";
        }

        private void StyleGroupBox(GroupBox groupBox, Color backColor, Font font, Color foreColor)
        {
            groupBox.BackColor = backColor;
            groupBox.ForeColor = foreColor;
            groupBox.Font = font;
            groupBox.Padding = new Padding(10);
        }

        private void StyleButton(Button button, Color backColor, Color foreColor, Font font)
        {
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.Font = font;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
        }

        private void StylePictureBoxes(PictureBox[] boxes, Color backColor)
        {
            foreach (PictureBox pic in boxes)
            {
                pic.BackColor = backColor;
                pic.BorderStyle = BorderStyle.FixedSingle;
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Margin = new Padding(6);
                pic.Padding = new Padding(2);
            }
        }

        private void StyleBoardCells()
        {
            for (int i = 0; i < boardCells.Length; i++)
            {
                boardCells[i].BackColor = EmptyCellColor;
                boardCells[i].BorderStyle = BorderStyle.FixedSingle;
                boardCells[i].Padding = new Padding(4);

                picBoardCards[i].BackColor = Color.White;
                picBoardCards[i].BorderStyle = BorderStyle.None;
                picBoardCards[i].SizeMode = PictureBoxSizeMode.Zoom;

                lblBoardValues[i].BackColor = Color.FromArgb(245, 245, 245);
                lblBoardValues[i].ForeColor = Color.FromArgb(55, 55, 55);
                lblBoardValues[i].Font = new Font("微軟正黑體", 12F, FontStyle.Bold);
            }
        }

        #region 初始化與新局

        private void InitializeControlArrays()
        {
            boardCells = new Panel[]
            {
                pnlCell0, pnlCell1, pnlCell2,
                pnlCell3, pnlCell4, pnlCell5,
                pnlCell6, pnlCell7, pnlCell8
            };

            picBoardCards = new PictureBox[]
            {
                picCell0, picCell1, picCell2,
                picCell3, picCell4, picCell5,
                picCell6, picCell7, picCell8
            };

            lblBoardValues = new Label[]
            {
                lblCell0, lblCell1, lblCell2,
                lblCell3, lblCell4, lblCell5,
                lblCell6, lblCell7, lblCell8
            };

            picPlayerHand = new PictureBox[] { picPlayer0, picPlayer1, picPlayer2 };
            picAIHand = new PictureBox[] { picAI0, picAI1, picAI2 };
        }

        private void WireBoardCellEvents()
        {
            for (int i = 0; i < boardCells.Length; i++)
            {
                boardCells[i].Click += BoardCell_Click;
                picBoardCards[i].Click += BoardCell_Click;
                lblBoardValues[i].Click += BoardCell_Click;
            }
        }

        private void WireHandCardEvents()
        {
            for (int i = 0; i < picPlayerHand.Length; i++)
            {
                picPlayerHand[i].Click += PlayerHandCard_Click;
            }

            for (int i = 0; i < picAIHand.Length; i++)
            {
                picAIHand[i].Click += AIHandCard_Click;
            }
        }

        private void StartNewGame()
        {
            currentTurn = TurnOwner.Player;
            phase = GamePhase.Playing;
            actionTakenThisTurn = false;
            selectedHandIndex = -1;
            pendingJokerRemove = false;
            statusMessage = "你的回合：請先抽牌，或先點選手牌，再點選九宮格空格放牌";

            ClearBoard();
            playerHand.Clear();
            aiHand.Clear();
            BuildAndShuffleDeck();

            RefreshBoardUI();
            RefreshPlayerHandUI();
            RefreshAIHandUI();
            RefreshDeckUI();
            UpdateStatusBar();
            UpdateActionAvailability();
        }

        private void ClearBoard()
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = new Cell { Owner = Side.None, Value = 0 };
            }
        }

        private void BuildAndShuffleDeck()
        {
            deck.Clear();
            for (int value = 1; value <= 5; value++)
            {
                deck.Add(value);
                deck.Add(value);
            }

            deck.Add(JokerCard);
            ShuffleDeck();
        }

        private void ShuffleDeck()
        {
            for (int i = deck.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                int temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }
        }

        #endregion

        #region 遊戲邏輯

        private List<int> GetHand(TurnOwner owner)
        {
            return owner == TurnOwner.Player ? playerHand : aiHand;
        }

        private bool CanDraw(TurnOwner owner)
        {
            if (phase != GamePhase.Playing)
            {
                return false;
            }

            if (currentTurn != owner)
            {
                return false;
            }

            if (actionTakenThisTurn)
            {
                return false;
            }

            List<int> hand = GetHand(owner);
            return deck.Count > 0 && hand.Count < HandLimit;
        }

        private bool DrawCard(TurnOwner owner)
        {
            if (!CanDraw(owner))
            {
                return false;
            }

            List<int> hand = GetHand(owner);
            int card = deck[0];
            deck.RemoveAt(0);
            hand.Add(card);
            actionTakenThisTurn = true;
            PlayCardPlaySound();

            string who = owner == TurnOwner.Player ? "玩家" : "AI";
            if (owner == TurnOwner.Player && IsJoker(card))
            {
                statusMessage = "玩家抽到了鬼牌！請選鬼牌後點選場上已放置的牌以移除。";
            }
            else
            {
                statusMessage = $"{who}抽到了一張牌（點數僅自己可見）。";
            }

            return true;
        }

        private bool CanPlay(TurnOwner owner, int handIndex, int cellIndex)
        {
            if (phase != GamePhase.Playing || currentTurn != owner || actionTakenThisTurn)
            {
                return false;
            }

            List<int> hand = GetHand(owner);
            if (handIndex < 0 || handIndex >= hand.Count)
            {
                return false;
            }

            if (cellIndex < 0 || cellIndex >= board.Length)
            {
                return false;
            }

            if (IsJoker(hand[handIndex]))
            {
                return false;
            }

            return board[cellIndex].Owner == Side.None;
        }

        private bool CanUseJoker(TurnOwner owner, int handIndex, int cellIndex)
        {
            if (phase != GamePhase.Playing || currentTurn != owner || actionTakenThisTurn)
            {
                return false;
            }

            List<int> hand = GetHand(owner);
            if (handIndex < 0 || handIndex >= hand.Count)
            {
                return false;
            }

            if (!IsJoker(hand[handIndex]))
            {
                return false;
            }

            if (cellIndex < 0 || cellIndex >= board.Length)
            {
                return false;
            }

            if (owner == TurnOwner.AI)
            {
                return board[cellIndex].Owner == Side.Player;
            }

            return board[cellIndex].Owner != Side.None;
        }

        private bool TryUseJoker(TurnOwner owner, int handIndex, int cellIndex)
        {
            if (!CanUseJoker(owner, handIndex, cellIndex))
            {
                return false;
            }

            List<int> hand = GetHand(owner);
            int removedValue = board[cellIndex].Value;
            hand.RemoveAt(handIndex);
            board[cellIndex] = new Cell { Owner = Side.None, Value = 0 };
            actionTakenThisTurn = true;
            PlayCardPlaySound();

            if (owner == TurnOwner.Player)
            {
                pendingJokerRemove = false;
                selectedHandIndex = -1;
                statusMessage = $"玩家使用鬼牌移除了第 {cellIndex + 1} 格的牌。";
            }
            else
            {
                statusMessage = $"AI 使用鬼牌移除了玩家在第 {cellIndex + 1} 格的 {removedValue} 點牌。";
            }

            return true;
        }

        private bool TryUseJoker(int handIndex, int cellIndex)
        {
            return TryUseJoker(TurnOwner.Player, handIndex, cellIndex);
        }

        private bool HasLegalNumberPlay(TurnOwner owner)
        {
            List<int> hand = GetHand(owner);
            if (!hand.Any(card => !IsJoker(card)))
            {
                return false;
            }

            return GetEmptyCellIndices().Count > 0;
        }

        private bool HasLegalJokerPlay(TurnOwner owner)
        {
            if (GetJokerHandIndex(GetHand(owner)) < 0)
            {
                return false;
            }

            for (int i = 0; i < board.Length; i++)
            {
                if (owner == TurnOwner.AI)
                {
                    if (board[i].Owner == Side.Player)
                    {
                        return true;
                    }
                }
                else if (board[i].Owner != Side.None)
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasAnyLegalMove(TurnOwner owner)
        {
            return CanDraw(owner) || HasLegalNumberPlay(owner) || HasLegalJokerPlay(owner);
        }

        /// <summary>
        /// 手牌僅剩無法使用的鬼牌且牌庫也無法再抽時，棄置鬼牌以結束回合。
        /// </summary>
        private bool TryDiscardJokerAsPass(TurnOwner owner)
        {
            if (HasAnyLegalMove(owner))
            {
                return false;
            }

            List<int> hand = GetHand(owner);
            int jokerIndex = GetJokerHandIndex(hand);
            if (jokerIndex < 0)
            {
                return false;
            }

            hand.RemoveAt(jokerIndex);
            actionTakenThisTurn = true;
            pendingJokerRemove = false;
            selectedHandIndex = -1;

            string who = owner == TurnOwner.Player ? "玩家" : "AI";
            statusMessage = $"{who}無其他合法行動，棄置鬼牌並結束回合。";
            return true;
        }

        private void CheckGlobalStalemate()
        {
            if (phase != GamePhase.Playing || IsBoardFull())
            {
                return;
            }

            if (HasAnyLegalMove(TurnOwner.Player) || HasAnyLegalMove(TurnOwner.AI))
            {
                return;
            }

            statusMessage = "雙方皆無法再抽牌或出牌，提前結算。";
            EndGameAndScore();
        }

        private void OnTurnBecamePlayer()
        {
            CheckGlobalStalemate();
            if (phase != GamePhase.Playing)
            {
                return;
            }

            if (!HasAnyLegalMove(TurnOwner.Player))
            {
                statusMessage = "玩家無法抽牌、出牌或使用鬼牌，略過此回合。";
                UpdateStatusBar();
                UpdateActionAvailability();

                EndTurn();
                if (IsBoardFull())
                {
                    EndGameAndScore();
                    return;
                }

                PerformAITurn();
                return;
            }

            statusMessage = "你的回合：抽牌、或出數值牌到空格、或出鬼牌移除場上已有的牌（每回合僅一項）。";
            UpdateStatusBar();
            UpdateActionAvailability();
        }

        private void FinishOwnerTurn(TurnOwner owner)
        {
            RefreshBoardUI();
            RefreshPlayerHandUI();
            RefreshAIHandUI();
            RefreshDeckUI();

            EndTurn();

            if (IsBoardFull())
            {
                EndGameAndScore();
                return;
            }

            if (currentTurn == TurnOwner.AI)
            {
                PerformAITurn();
            }
            else
            {
                OnTurnBecamePlayer();
            }
        }

        private bool TryPlaceCard(TurnOwner owner, int handIndex, int cellIndex)
        {
            if (!CanPlay(owner, handIndex, cellIndex))
            {
                return false;
            }

            List<int> hand = GetHand(owner);
            int value = hand[handIndex];
            hand.RemoveAt(handIndex);

            board[cellIndex] = new Cell
            {
                Owner = owner == TurnOwner.Player ? Side.Player : Side.AI,
                Value = value
            };

            actionTakenThisTurn = true;
            selectedHandIndex = -1;
            PlayCardPlaySound();

            string who = owner == TurnOwner.Player ? "玩家" : "AI";
            statusMessage = $"{who}在棋盤第 {cellIndex + 1} 格放置了 {value} 點。";
            return true;
        }

        private void SelectPlayerHand(int index)
        {
            if (phase != GamePhase.Playing || currentTurn != TurnOwner.Player || actionTakenThisTurn)
            {
                return;
            }

            if (index < 0 || index >= playerHand.Count)
            {
                return;
            }

            selectedHandIndex = index;

            if (IsJoker(playerHand[index]))
            {
                pendingJokerRemove = true;
                if (!HasLegalJokerPlay(TurnOwner.Player))
                {
                    pendingJokerRemove = false;
                    statusMessage = "場上沒有牌可移除；鬼牌不能當數值牌放到空格。請抽牌，或若無法行動將自動略過回合。";
                }
                else
                {
                    statusMessage = "已選擇鬼牌，請點選場上已有牌進行移除。";
                }
            }
            else
            {
                pendingJokerRemove = false;
                statusMessage = $"已選擇手牌 {playerHand[index]} 點，請點選空格。";
            }

            RefreshPlayerHandUI();
            UpdateStatusBar();
        }

        private int GetCellIndexFromSender(object sender)
        {
            if (sender is Panel panel)
            {
                return Array.IndexOf(boardCells, panel);
            }

            if (sender is PictureBox pic)
            {
                return Array.IndexOf(picBoardCards, pic);
            }

            if (sender is Label lbl)
            {
                return Array.IndexOf(lblBoardValues, lbl);
            }

            return -1;
        }

        private void EndTurn()
        {
            actionTakenThisTurn = false;
            selectedHandIndex = -1;
            pendingJokerRemove = false;
            currentTurn = currentTurn == TurnOwner.Player ? TurnOwner.AI : TurnOwner.Player;

            if (currentTurn == TurnOwner.AI)
            {
                statusMessage = "AI 回合中…";
            }
        }

        #region AI 決策

        private const int JokerThreatThreshold = 35;

        private int GetJokerHandIndex(List<int> hand)
        {
            for (int i = 0; i < hand.Count; i++)
            {
                if (IsJoker(hand[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        private bool LineContainsCell(int[] line, int cellIndex)
        {
            return Array.IndexOf(line, cellIndex) >= 0;
        }

        private bool HasTwoInRowThreatForPlayer(int cellIndex)
        {
            for (int i = 0; i < LineCount; i++)
            {
                int[] line = Lines[i];
                if (!LineContainsCell(line, cellIndex))
                {
                    continue;
                }

                int playerCount = 0;
                int emptyCount = 0;
                int aiCount = 0;

                foreach (int index in line)
                {
                    switch (board[index].Owner)
                    {
                        case Side.Player:
                            playerCount++;
                            break;
                        case Side.AI:
                            aiCount++;
                            break;
                        default:
                            emptyCount++;
                            break;
                    }
                }

                if (playerCount == 2 && emptyCount == 1 && aiCount == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private int EvaluatePlayerCellThreat(int cellIndex)
        {
            if (board[cellIndex].Owner != Side.Player)
            {
                return -1;
            }

            int score = board[cellIndex].Value * 10;

            if (cellIndex == 4)
            {
                score += 5;
            }

            for (int i = 0; i < LineCount; i++)
            {
                int[] line = Lines[i];
                if (!LineContainsCell(line, cellIndex))
                {
                    continue;
                }

                int playerCount = 0;
                int emptyCount = 0;
                int aiCount = 0;

                foreach (int index in line)
                {
                    switch (board[index].Owner)
                    {
                        case Side.Player:
                            playerCount++;
                            break;
                        case Side.AI:
                            aiCount++;
                            break;
                        default:
                            emptyCount++;
                            break;
                    }
                }

                if (playerCount == 2 && emptyCount == 1 && aiCount == 0)
                {
                    score += 50;
                }
                else if (playerCount == 1 && emptyCount == 2 && aiCount == 0)
                {
                    score += 10;
                }
            }

            return score;
        }

        private bool IsWorthRemovingWithJoker(int cellIndex, int threatScore)
        {
            if (threatScore >= JokerThreatThreshold)
            {
                return true;
            }

            return board[cellIndex].Value >= 3 && HasTwoInRowThreatForPlayer(cellIndex);
        }

        private bool TryFindBestPlayerCellToRemove(out int cellIndex)
        {
            cellIndex = -1;

            var candidates = new List<int>();
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i].Owner == Side.Player)
                {
                    candidates.Add(i);
                }
            }

            if (candidates.Count == 0)
            {
                return false;
            }

            int bestScore = -1;
            var bestCells = new List<int>();

            foreach (int index in candidates)
            {
                int score = EvaluatePlayerCellThreat(index);
                if (!IsWorthRemovingWithJoker(index, score))
                {
                    continue;
                }

                if (score > bestScore)
                {
                    bestScore = score;
                    bestCells.Clear();
                    bestCells.Add(index);
                }
                else if (score == bestScore)
                {
                    bestCells.Add(index);
                }
            }

            if (bestCells.Count == 0)
            {
                return false;
            }

            cellIndex = PickBestCellFromCandidates(bestCells);
            return true;
        }

        private bool TryFindAIJokerMove(out int handIndex, out int cellIndex)
        {
            handIndex = -1;
            cellIndex = -1;

            handIndex = GetJokerHandIndex(aiHand);
            if (handIndex < 0)
            {
                return false;
            }

            return TryFindBestPlayerCellToRemove(out cellIndex);
        }

        private int GetPositionPriority(int cellIndex)
        {
            if (cellIndex == 4)
            {
                return 0;
            }

            if (cellIndex == 0 || cellIndex == 2 || cellIndex == 6 || cellIndex == 8)
            {
                return 1;
            }

            return 2;
        }

        private int PickBestCellFromCandidates(List<int> candidates)
        {
            return candidates
                .OrderBy(GetPositionPriority)
                .ThenBy(i => i)
                .First();
        }

        private int ChooseBestHandIndexForPlay()
        {
            int bestIndex = -1;
            int bestValue = -1;

            for (int i = 0; i < aiHand.Count; i++)
            {
                if (IsJoker(aiHand[i]))
                {
                    continue;
                }

                if (aiHand[i] > bestValue)
                {
                    bestValue = aiHand[i];
                    bestIndex = i;
                }
            }

            return bestIndex;
        }

        private void CollectOffensiveTargetCells(List<int> targets)
        {
            for (int i = 0; i < LineCount; i++)
            {
                int[] line = Lines[i];
                int aiCount = 0;
                int playerCount = 0;
                int emptyCount = 0;
                int emptyIndex = -1;

                foreach (int index in line)
                {
                    switch (board[index].Owner)
                    {
                        case Side.AI:
                            aiCount++;
                            break;
                        case Side.Player:
                            playerCount++;
                            break;
                        default:
                            emptyCount++;
                            emptyIndex = index;
                            break;
                    }
                }

                if (aiCount == 2 && emptyCount == 1 && playerCount == 0)
                {
                    targets.Add(emptyIndex);
                }
            }
        }

        private void CollectBlockTargetCells(List<int> targets)
        {
            for (int i = 0; i < LineCount; i++)
            {
                int[] line = Lines[i];
                int aiCount = 0;
                int playerCount = 0;
                int emptyCount = 0;
                int emptyIndex = -1;

                foreach (int index in line)
                {
                    switch (board[index].Owner)
                    {
                        case Side.AI:
                            aiCount++;
                            break;
                        case Side.Player:
                            playerCount++;
                            break;
                        default:
                            emptyCount++;
                            emptyIndex = index;
                            break;
                    }
                }

                if (playerCount == 2 && emptyCount == 1 && aiCount == 0)
                {
                    targets.Add(emptyIndex);
                }
            }
        }

        private bool TryFindOffensiveMove(out int handIndex, out int cellIndex)
        {
            handIndex = -1;
            cellIndex = -1;

            if (aiHand.Count == 0)
            {
                return false;
            }

            var targets = new List<int>();
            CollectOffensiveTargetCells(targets);

            if (targets.Count == 0)
            {
                return false;
            }

            handIndex = ChooseBestHandIndexForPlay();
            if (handIndex < 0)
            {
                return false;
            }

            cellIndex = PickBestCellFromCandidates(targets);
            return true;
        }

        private bool TryFindBlockMove(out int handIndex, out int cellIndex)
        {
            handIndex = -1;
            cellIndex = -1;

            if (aiHand.Count == 0)
            {
                return false;
            }

            var targets = new List<int>();
            CollectBlockTargetCells(targets);

            if (targets.Count == 0)
            {
                return false;
            }

            handIndex = ChooseBestHandIndexForPlay();
            if (handIndex < 0)
            {
                return false;
            }

            cellIndex = PickBestCellFromCandidates(targets);
            return true;
        }

        private bool TryFindPositionalMove(out int handIndex, out int cellIndex)
        {
            handIndex = -1;
            cellIndex = -1;

            if (aiHand.Count == 0)
            {
                return false;
            }

            List<int> emptyCells = GetEmptyCellIndices();
            if (emptyCells.Count == 0)
            {
                return false;
            }

            handIndex = ChooseBestHandIndexForPlay();
            if (handIndex < 0)
            {
                return false;
            }

            cellIndex = PickBestCellFromCandidates(emptyCells);
            return true;
        }

        private void PerformAITurn()
        {
            if (phase != GamePhase.Playing || currentTurn != TurnOwner.AI)
            {
                return;
            }

            if (!HasAnyLegalMove(TurnOwner.AI))
            {
                if (TryDiscardJokerAsPass(TurnOwner.AI))
                {
                    FinishOwnerTurn(TurnOwner.AI);
                    return;
                }

                statusMessage = "AI 無合法行動，略過此回合。";
                RefreshBoardUI();
                RefreshAIHandUI();
                RefreshDeckUI();
                EndTurn();

                if (IsBoardFull())
                {
                    EndGameAndScore();
                    return;
                }

                OnTurnBecamePlayer();
                return;
            }

            bool acted = false;
            int handIndex;
            int cellIndex;

            if (TryFindOffensiveMove(out handIndex, out cellIndex))
            {
                acted = TryPlaceCard(TurnOwner.AI, handIndex, cellIndex);
                if (acted)
                {
                    statusMessage = "AI 優先完成自己的連線。";
                }
            }
            else if (TryFindAIJokerMove(out handIndex, out cellIndex))
            {
                acted = TryUseJoker(TurnOwner.AI, handIndex, cellIndex);
            }
            else if (TryFindBlockMove(out handIndex, out cellIndex))
            {
                acted = TryPlaceCard(TurnOwner.AI, handIndex, cellIndex);
                if (acted)
                {
                    statusMessage = "AI 擋住玩家的連線。";
                }
            }
            else if (aiHand.Count >= HandLimit && TryFindPositionalMove(out handIndex, out cellIndex))
            {
                acted = TryPlaceCard(TurnOwner.AI, handIndex, cellIndex);
                if (acted)
                {
                    statusMessage = "AI 手牌已滿，依位置優先出牌。";
                }
            }
            else if (CanDraw(TurnOwner.AI) && aiHand.Count < HandLimit)
            {
                acted = DrawCard(TurnOwner.AI);
                if (acted)
                {
                    statusMessage = "AI 選擇抽牌（尚無成線或擋線時機）。";
                }
            }
            else if (TryFindPositionalMove(out handIndex, out cellIndex))
            {
                acted = TryPlaceCard(TurnOwner.AI, handIndex, cellIndex);
                if (acted)
                {
                    statusMessage = "AI 依位置優先出牌（中 > 角 > 邊）。";
                }
            }
            else if (CanDraw(TurnOwner.AI))
            {
                acted = DrawCard(TurnOwner.AI);
                if (acted)
                {
                    statusMessage = "AI 無法出牌，改為抽牌。";
                }
            }

            if (!acted)
            {
                if (TryDiscardJokerAsPass(TurnOwner.AI))
                {
                    FinishOwnerTurn(TurnOwner.AI);
                    return;
                }

                statusMessage = "AI 本回合無法行動，略過。";
                RefreshBoardUI();
                RefreshAIHandUI();
                RefreshDeckUI();
                EndTurn();

                if (IsBoardFull())
                {
                    EndGameAndScore();
                    return;
                }

                OnTurnBecamePlayer();
                return;
            }

            FinishOwnerTurn(TurnOwner.AI);
        }

        #endregion

        private List<int> GetEmptyCellIndices()
        {
            var list = new List<int>();
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i].Owner == Side.None)
                {
                    list.Add(i);
                }
            }

            return list;
        }

        private bool IsBoardFull()
        {
            return board.All(cell => cell.Owner != Side.None);
        }

        #region 成線判定與結算

        private bool IsLineOwnedBy(int[] line, Side side)
        {
            if (side == Side.None)
            {
                return false;
            }

            foreach (int index in line)
            {
                if (board[index].Owner != side)
                {
                    return false;
                }
            }

            return true;
        }

        private int SumLineValues(int[] line)
        {
            int sum = 0;
            foreach (int index in line)
            {
                sum += board[index].Value;
            }

            return sum;
        }

        private string FormatLineValues(int[] line)
        {
            return string.Join("+", line.Select(i => board[i].Value.ToString()));
        }

        private List<LineScoreDetail> GetValidLines(Side side)
        {
            var details = new List<LineScoreDetail>();

            for (int i = 0; i < LineCount; i++)
            {
                int[] line = Lines[i];
                if (!IsLineOwnedBy(line, side))
                {
                    continue;
                }

                details.Add(new LineScoreDetail
                {
                    LineIndex = i,
                    LineName = LineNames[i],
                    Sum = SumLineValues(line),
                    CellIndices = line
                });
            }

            return details;
        }

        private int CalculateTotalScore(Side side)
        {
            return GetValidLines(side).Sum(d => d.Sum);
        }

        private string GetWinnerText(int playerScore, int aiScore)
        {
            if (playerScore > aiScore)
            {
                return "玩家獲勝！";
            }

            if (aiScore > playerScore)
            {
                return "AI 獲勝！";
            }

            if (playerScore == 0 && aiScore == 0)
            {
                return "平手！（雙方皆無成線）";
            }

            return "平手！";
        }

        private void AppendSideScoreDetail(StringBuilder sb, string sideLabel, List<LineScoreDetail> validLines, int total)
        {
            sb.AppendLine($"{sideLabel}總分：{total}");

            if (validLines.Count == 0)
            {
                sb.AppendLine("  （無有效成線）");
            }
            else
            {
                foreach (LineScoreDetail detail in validLines)
                {
                    string values = FormatLineValues(detail.CellIndices);
                    sb.AppendLine($"  · {detail.LineName}：{values} = {detail.Sum}");
                }
            }

            sb.AppendLine();
        }

        private string BuildScoreReport(int playerScore, int aiScore)
        {
            var playerLines = GetValidLines(Side.Player);
            var aiLines = GetValidLines(Side.AI);
            string result = GetWinnerText(playerScore, aiScore);

            var sb = new StringBuilder();
            sb.AppendLine($"【結算結果】{result}");
            sb.AppendLine();
            AppendSideScoreDetail(sb, "玩家", playerLines, playerScore);
            AppendSideScoreDetail(sb, "AI", aiLines, aiScore);
            sb.AppendLine("規則：檢查 8 條線（3 橫、3 直、2 斜）。");
            sb.AppendLine("三格皆為同一陣營則該線有效，分數為三張牌點數總和；");
            sb.AppendLine("多條有效線分數全部累加。總分高者勝，相同則平手。");

            return sb.ToString();
        }

        private void EndGameAndScore()
        {
            phase = GamePhase.GameOver;

            int playerScore = CalculateTotalScore(Side.Player);
            int aiScore = CalculateTotalScore(Side.AI);
            string result = GetWinnerText(playerScore, aiScore);
            PlayResultSound(playerScore, aiScore);

            statusMessage = $"遊戲結束 — 玩家 {playerScore} 分，AI {aiScore} 分（{result}）";

            RefreshBoardUI();
            RefreshPlayerHandUI();
            RefreshAIHandUI();
            RefreshDeckUI();
            UpdateStatusBar();
            UpdateActionAvailability();

            MessageBox.Show(BuildScoreReport(playerScore, aiScore), "結算", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        private void AfterPlayerAction()
        {
            if (IsBoardFull())
            {
                RefreshBoardUI();
                RefreshPlayerHandUI();
                RefreshDeckUI();
                EndGameAndScore();
                return;
            }

            FinishOwnerTurn(TurnOwner.Player);
        }

        #endregion

        #region UI 刷新

        private void RefreshBoardUI()
        {
            for (int i = 0; i < board.Length; i++)
            {
                Cell cell = board[i];

                if (cell.Owner == Side.None)
                {
                    boardCells[i].BackColor = EmptyCellColor;
                    picBoardCards[i].BackColor = Color.White;
                    picBoardCards[i].Visible = false;
                    lblBoardValues[i].Text = string.Empty;
                    lblBoardValues[i].BackColor = Color.FromArgb(245, 245, 245);
                    lblBoardValues[i].ForeColor = Color.FromArgb(90, 90, 90);
                }
                else if (cell.Owner == Side.Player)
                {
                    boardCells[i].BackColor = PlayerCellColor;
                    picBoardCards[i].BackColor = Color.FromArgb(255, 250, 250);
                    picBoardCards[i].Image = GetBoardImage(cell);
                    picBoardCards[i].Visible = true;
                    lblBoardValues[i].Text = $"玩家 {cell.Value}";
                    lblBoardValues[i].BackColor = Color.FromArgb(210, 88, 88);
                    lblBoardValues[i].ForeColor = Color.White;
                }
                else
                {
                    boardCells[i].BackColor = AICellColor;
                    picBoardCards[i].BackColor = Color.FromArgb(248, 251, 255);
                    picBoardCards[i].Image = GetBoardImage(cell);
                    picBoardCards[i].Visible = true;
                    lblBoardValues[i].Text = $"AI {cell.Value}";
                    lblBoardValues[i].BackColor = Color.FromArgb(75, 120, 200);
                    lblBoardValues[i].ForeColor = Color.White;
                }
            }
        }

        private void RefreshPlayerHandUI()
        {
            for (int i = 0; i < picPlayerHand.Length; i++)
            {
                if (i < playerHand.Count)
                {
                    picPlayerHand[i].Visible = true;
                    picPlayerHand[i].Image = GetPlayerHandImage(playerHand[i]);
                    picPlayerHand[i].BorderStyle = BorderStyle.FixedSingle;

                    if (i == selectedHandIndex)
                    {
                        picPlayerHand[i].BackColor = SelectedHandBorderColor;
                    }
                    else
                    {
                        picPlayerHand[i].BackColor = Color.Transparent;
                    }
                }
                else
                {
                    picPlayerHand[i].Visible = false;
                    picPlayerHand[i].BackColor = Color.Transparent;
                }
            }

            if (playerHand.Count == 0)
            {
                lblPlayerHandInfo.Text = $"手牌：0 / {HandLimit}";
            }
            else
            {
                string cards = string.Join(", ", playerHand.Select(FormatHandCardDisplay));
                lblPlayerHandInfo.Text = $"手牌 ({playerHand.Count}/{HandLimit})：[{cards}]";
            }
        }

        private void RefreshAIHandUI()
        {
            for (int i = 0; i < picAIHand.Length; i++)
            {
                if (i < aiHand.Count)
                {
                    picAIHand[i].Visible = true;
                    picAIHand[i].Image = GetAIHandImage();
                }
                else
                {
                    picAIHand[i].Visible = false;
                }
            }

            lblAIHandInfo.Text = $"AI 手牌：{aiHand.Count} 張";
        }

        private void RefreshDeckUI()
        {
            picDeck.Image = GetBackImage();
            lblDeckCount.Text = $"剩餘：{deck.Count}";
        }

        private void UpdateStatusBar()
        {
            string turnText = currentTurn == TurnOwner.Player ? "玩家" : "AI";
            lblTurn.Text = $"回合：{turnText}";
            lblDeckRemain.Text = $"牌庫：{deck.Count} 張";
            lblMessage.Text = statusMessage;
        }

        private void UpdateActionAvailability()
        {
            bool playerTurn = phase == GamePhase.Playing && currentTurn == TurnOwner.Player;

            btnDrawCard.Enabled = playerTurn && CanDraw(TurnOwner.Player);
            btnRestart.Enabled = true;

            bool canSelectHand = playerTurn && !actionTakenThisTurn;
            for (int i = 0; i < picPlayerHand.Length; i++)
            {
                picPlayerHand[i].Enabled = canSelectHand && i < playerHand.Count;
            }

            bool canClickBoard = playerTurn && !actionTakenThisTurn && selectedHandIndex >= 0;
            bool jokerMode = pendingJokerRemove
                && selectedHandIndex >= 0
                && selectedHandIndex < playerHand.Count
                && IsJoker(playerHand[selectedHandIndex]);

            for (int i = 0; i < boardCells.Length; i++)
            {
                bool empty = board[i].Owner == Side.None;
                bool occupied = !empty;
                bool enabled = canClickBoard && (jokerMode ? occupied : empty);
                boardCells[i].Enabled = enabled;
                picBoardCards[i].Enabled = enabled;
                lblBoardValues[i].Enabled = enabled;
            }
        }

        private Image GetBackImage()
        {
            return Properties.Resources.back;
        }

        private Image GetFaceImageByValue(int cardValue)
        {
            switch (cardValue)
            {
                case 1:
                    return Properties.Resources.card1;
                case 2:
                    return Properties.Resources.card2;
                case 3:
                    return Properties.Resources.card3;
                case 4:
                    return Properties.Resources.card4;
                case 5:
                    return Properties.Resources.card5;
                case JokerCard:
                    return Properties.Resources.joker;
                default:
                    return Properties.Resources.back;
            }
        }

        private Image GetPlayerHandImage(int cardValue)
        {
            return GetFaceImageByValue(cardValue);
        }

        private Image GetAIHandImage()
        {
            return GetBackImage();
        }

        private Image GetBoardImage(Cell cell)
        {
            if (cell.Owner == Side.None)
            {
                return GetBackImage();
            }

            return GetFaceImageByValue(cell.Value);
        }

        #endregion

        #region 事件處理程序

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void BoardCell_Click(object sender, EventArgs e)
        {
            if (phase != GamePhase.Playing || currentTurn != TurnOwner.Player || actionTakenThisTurn)
            {
                return;
            }

            if (selectedHandIndex < 0)
            {
                statusMessage = "請先點選手牌，再點選九宮格空格。";
                UpdateStatusBar();
                return;
            }

            int cellIndex = GetCellIndexFromSender(sender);
            if (cellIndex < 0)
            {
                return;
            }

            if (pendingJokerRemove
                && selectedHandIndex < playerHand.Count
                && IsJoker(playerHand[selectedHandIndex]))
            {
                if (board[cellIndex].Owner == Side.None)
                {
                    statusMessage = "鬼牌只能移除已放置的牌，請點選有牌的格子。";
                    UpdateStatusBar();
                    return;
                }

                if (!TryUseJoker(selectedHandIndex, cellIndex))
                {
                    statusMessage = "無法在此格使用鬼牌。";
                    UpdateStatusBar();
                    return;
                }

                AfterPlayerAction();
                return;
            }

            if (selectedHandIndex < playerHand.Count && IsJoker(playerHand[selectedHandIndex]))
            {
                statusMessage = "鬼牌不能放到空格，請點選場上已放置的牌。";
                UpdateStatusBar();
                return;
            }

            if (!TryPlaceCard(TurnOwner.Player, selectedHandIndex, cellIndex))
            {
                statusMessage = "無法放置到此格，請選擇空格。";
                UpdateStatusBar();
                return;
            }

            AfterPlayerAction();
        }

        private void PlayerHandCard_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic == null || pic.Tag == null)
            {
                return;
            }

            if (!int.TryParse(pic.Tag.ToString(), out int slotIndex))
            {
                return;
            }

            if (slotIndex < 0 || slotIndex >= playerHand.Count)
            {
                return;
            }

            SelectPlayerHand(slotIndex);
            UpdateActionAvailability();
        }

        private void AIHandCard_Click(object sender, EventArgs e)
        {
            if (phase == GamePhase.Playing && currentTurn == TurnOwner.AI)
            {
                statusMessage = "AI 回合中，請稍候。";
                UpdateStatusBar();
            }
        }

        private void btnDrawCard_Click(object sender, EventArgs e)
        {
            if (!DrawCard(TurnOwner.Player))
            {
                statusMessage = "目前無法抽牌（可能手牌已滿、牌庫已空或本回合已行動）。";
                UpdateStatusBar();
                UpdateActionAvailability();
                return;
            }

            AfterPlayerAction();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        #endregion

        #region 音效

        private void PlayCardPlaySound()
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer(Properties.Resources.cardplay))
                {
                    player.Play();
                }
            }
            catch
            {
            }
        }

        private void PlayWinSound()
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer(Properties.Resources.win))
                {
                    player.Play();
                }
            }
            catch
            {
            }
        }

        private void PlayLoseSound()
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer(Properties.Resources.lose))
                {
                    player.Play();
                }
            }
            catch
            {
            }
        }

        private void PlayResultSound(int playerScore, int aiScore)
        {
            if (playerScore > aiScore)
            {
                PlayWinSound();
            }
            else if (playerScore < aiScore)
            {
                PlayLoseSound();
            }
            else
            {
                PlayCardPlaySound();
            }
        }

        #endregion
    }
}
