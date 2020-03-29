using AM_Spades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public enum Suit : int { Spades = 0, Hearts, Diamonds, Clubs };
    public enum Value : int { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };
    public enum GameState : int { Start, Waiting, Playing };

    public partial class Form1 : Form
    {
        GameModel currentGameState;
        GameState state;
        Player comp1, comp2, comp3, human;
        bool isMyTurn = false;
        int token = 0;

        public Form1(GameModel receivedGameState)
        {
            /*Testing enums:
            Card someCard = new Card((int)Suit.Spades, (int)Value.Three, false);
            Suit someSuit = (Suit)someCard.getSuit();
            MessageBox.Show(someSuit.ToString());*/

            /*
            List<Card> myHand = new List<Card>();
            myHand.Add(new Card("somethingMagical", 5, false));
            MessageBox.Show(myHand[0].getSuit());
            */

            currentGameState = receivedGameState;
            state = GameState.Start;

            comp1 = currentGameState.GetPlayers().Find(somePlayer => somePlayer.GetName().Equals("ComputerPlayer1"));
            comp2 = currentGameState.GetPlayers().Find(somePlayer => somePlayer.GetName().Equals("ComputerPlayer2"));
            comp3 = currentGameState.GetPlayers().Find(somePlayer => somePlayer.GetName().Equals("ComputerPlayer3"));
            human = currentGameState.GetPlayers().Find(somePlayer => somePlayer.GetName().Equals("JOHN"));

            InitializeComponent();

            displayCards();

            lblc1_rtrick.Text = comp1.GetBid().ToString();
            lblc2_rtrick.Text = comp2.GetBid().ToString();
            lblc3_rtrick.Text = comp3.GetBid().ToString();

            token = OnlineGameAdapter.getToken();
            lblPlayerNo.Text = "Welcome player: " + token.ToString();
        }

        private void placeBid(object sender, EventArgs e)
        {
            if (state == GameState.Start)
            {
                try
                {
                    gbBids.Visible = false;
                    Button btnBid = (Button)sender;
                    String bid = btnBid.Text;
                    MessageBox.Show("You just bid: " + bid);

                    currentGameState.GetPlayers().Find(somePlayer => somePlayer.GetName().Equals("JOHN")).SetBid(Int32.Parse(bid == "NIL" ? "0" : bid));

                    lblh_rtrick.Text = human.GetBid().ToString();

                    state = GameState.Playing;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("A fatal exception occurred: " + ex);
                }
            }
        }

        private void playRound(object sender, EventArgs e)
        {
            try
            {
                if (isMyTurn)
                {
                    if (state == GameState.Playing)
                    {
                        PictureBox pbCard = (PictureBox)sender;


                        //play computer player card and show cards in the middle
                        pbHplay.Image = pbCard.Image;
                        pbC1play.ImageLocation = Card.GetImageLocationOfCard(comp1.PlayRound());
                        pbC2play.ImageLocation = Card.GetImageLocationOfCard(comp2.PlayRound());
                        pbC3play.ImageLocation = Card.GetImageLocationOfCard(comp3.PlayRound());

                        //TODO update scores

                        //TODO update remaining and current trick


                        state = GameState.Waiting;
                        pbCard.Image = null;
                        pbCard.Enabled = false;
                        refreshCards();

                    }
                }
            }
            catch (Exception ex) { }
        }

        private void continueRound(object sender, EventArgs e)
        {
            PictureBox pbCard = (PictureBox)sender;
            if (state == GameState.Waiting)
            {
                //Hide cards
                pbHplay.Image = null;
                pbC1play.Image = null;
                pbC2play.Image = null;
                pbC3play.Image = null;
                state = GameState.Playing;
            }
        }

        private void displayCards()
        {
            //Start dealing cards to PLAYER 1
            String sControlName;
            PictureBox pCard;
            int iCard;

            //Card counter from 0 to 51
            //int iCardPointer = 0;

            //New display of cards
            //TODO: Consider enclosing this in a foreach loop iterating through list currentGameState.currentPlayers ...after someone explains p1_/PictureBox
            sControlName = "p1_";
            iCard = 0;
            foreach (Card currCard in currentGameState.GetPlayers().ElementAt<Player>(0).GetHand())
            {
                pCard = (PictureBox)this.Controls.Find(sControlName + (iCard + 1).ToString(), true)[0];
                pCard.SizeMode = PictureBoxSizeMode.Zoom;

                pCard.ImageLocation = Card.GetImageLocationOfCard(currCard);

                iCard++;
            }

            sControlName = "p2_";
            iCard = 0;
            foreach (Card currCard in currentGameState.GetPlayers().ElementAt<Player>(1).GetHand())
            {
                pCard = (PictureBox)this.Controls.Find(sControlName + (iCard + 1).ToString(), true)[0];
                pCard.SizeMode = PictureBoxSizeMode.Zoom;
                if (currCard.GetIsHidden())
                {
                    pCard.ImageLocation = Card.GetImageLocationOfCard(currCard);
                }
                else { pCard.ImageLocation = null; }
                iCard++;
                Console.WriteLine(currCard);
            }

            sControlName = "p3_";
            iCard = 0;
            foreach (Card currCard in currentGameState.GetPlayers().ElementAt<Player>(2).GetHand())
            {
                pCard = (PictureBox)this.Controls.Find(sControlName + (iCard + 1).ToString(), true)[0];
                pCard.SizeMode = PictureBoxSizeMode.Zoom;
                if (currCard.GetIsHidden())
                {
                    pCard.ImageLocation = Card.GetImageLocationOfCard(currCard);
                }
                else { pCard.ImageLocation = null; }
                iCard++;
            }

            sControlName = "p4_";
            iCard = 0;
            foreach (Card currCard in currentGameState.GetPlayers().ElementAt<Player>(3).GetHand())
            {
                pCard = (PictureBox)this.Controls.Find(sControlName + (iCard + 1).ToString(), true)[0];
                pCard.SizeMode = PictureBoxSizeMode.Zoom;
                if (currCard.GetIsHidden())
                {
                    pCard.ImageLocation = Card.GetImageLocationOfCard(currCard);
                }
                else { pCard.ImageLocation = null; }
                iCard++;
            }

            //Old display of cards
            //Hieu: I think these are basically presenting sections of the deck as our placeholder. I expect to replace this with code reading from the model
            /*
            for (int iCard = 0; iCard < 13; iCard++)
            {
                pCard = (PictureBox)this.Controls.Find(sControlName + (iCard + 1).ToString(), true)[0];
                pCard.SizeMode = PictureBoxSizeMode.Zoom;
                //pCard.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "\\cards\\" + Char.ToLower(cards[iCardPointer].GetSuit()[0]) + cards[iCardPointer].GetValue() + ".png"; //gets first char of getSuit()
                pCard.ImageLocation = Card.GetImageLocationOfCard(cards[iCardPointer]);
                iCardPointer++;
            }

            sControlName = "p2_";
            for (int iCard = 0; iCard < 13; iCard++)
            {
                pCard = (PictureBox)this.Controls.Find(sControlName + (iCard + 1).ToString(), true)[0];
                pCard.SizeMode = PictureBoxSizeMode.Zoom;
                pCard.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "\\cards\\" + Char.ToLower(cards[iCardPointer].GetSuit()[0]) + cards[iCardPointer].GetValue() + ".png"; //TODO 
                iCardPointer++;
            }

            sControlName = "p3_";
            for (int iCard = 0; iCard < 13; iCard++)
            {
                pCard = (PictureBox)this.Controls.Find(sControlName + (iCard + 1).ToString(), true)[0];
                pCard.SizeMode = PictureBoxSizeMode.Zoom;
                pCard.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "\\cards\\" + Char.ToLower(cards[iCardPointer].GetSuit()[0]) + cards[iCardPointer].GetValue() + ".png";
                iCardPointer++;
            }

            sControlName = "p4_";
            for (int iCard = 0; iCard < 13; iCard++)
            {
                pCard = (PictureBox)this.Controls.Find(sControlName + (iCard + 1).ToString(), true)[0];
                pCard.SizeMode = PictureBoxSizeMode.Zoom;
                pCard.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "\\cards\\" + Char.ToLower(cards[iCardPointer].GetSuit()[0]) + cards[iCardPointer].GetValue() + ".png";
                iCardPointer++;
            }
            */
            displayScore();
        }

        private void refreshCards()
        {
            String sControlName;
            PictureBox pCard;
            int iCard;

            sControlName = "p2_";
            iCard = 0;
            foreach (Card currCard in currentGameState.GetPlayers().ElementAt<Player>(1).GetHand())
            {
                pCard = (PictureBox)this.Controls.Find(sControlName + (iCard + 1).ToString(), true)[0];
                pCard.SizeMode = PictureBoxSizeMode.Zoom;
                if (currCard.GetIsHidden())
                {
                    pCard.ImageLocation = Card.GetImageLocationOfCard(currCard);
                }
                else { pCard.ImageLocation = null; }
                iCard++;
                Console.WriteLine(currCard);
            }

            sControlName = "p3_";
            iCard = 0;
            foreach (Card currCard in currentGameState.GetPlayers().ElementAt<Player>(2).GetHand())
            {
                pCard = (PictureBox)this.Controls.Find(sControlName + (iCard + 1).ToString(), true)[0];
                pCard.SizeMode = PictureBoxSizeMode.Zoom;
                if (currCard.GetIsHidden())
                {
                    pCard.ImageLocation = Card.GetImageLocationOfCard(currCard);
                }
                else { pCard.ImageLocation = null; }
                iCard++;
            }

            sControlName = "p4_";
            iCard = 0;
            foreach (Card currCard in currentGameState.GetPlayers().ElementAt<Player>(3).GetHand())
            {
                pCard = (PictureBox)this.Controls.Find(sControlName + (iCard + 1).ToString(), true)[0];
                pCard.SizeMode = PictureBoxSizeMode.Zoom;
                if (currCard.GetIsHidden())
                {
                    pCard.ImageLocation = Card.GetImageLocationOfCard(currCard);
                }
                else { pCard.ImageLocation = null; }
                iCard++;
            }
        }

        private void displayScore()
        {
            int ScoreNum = 5;
            String ScoreNumD = ScoreNum.ToString();
            label14.Text = ScoreNumD;
            label13.Text = ScoreNumD;
            label12.Text = ScoreNumD;
            label11.Text = ScoreNumD;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            isMyTurn = OnlineGameAdapter.isMyTurn(token.ToString());
        }



    }
}
