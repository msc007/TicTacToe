using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// Private Variables
        private MarkType[] mResults;
        private bool mPlayerOneTurn;
        private bool mGameEnded;

        /// Default Constructor
        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }
        /// <summary>
        /// Starts a new game and clear all previous game values
        /// </summary>
        private void NewGame()
        {
            mPlayerOneTurn = true;
            mGameEnded = false;
            // Create a new MarkType array for each cell
            mResults = new MarkType[9];
            // Initialize each cell as Free
            for(var i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Free;
            }

            // Iterate every button on the grid
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

        }

        /// <summary>
        /// Handles a button click event
        /// </summary>
        /// <param name="sender"> The button cliked </param>
        /// <param name="e"> The evenets of the click</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //start a new game if game finished
            if (mGameEnded)
            {
                NewGame();
                return;
            }

            var button = (Button)sender;
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            //get index of a grid
            var index = column + (row * 3); 

            // Nothing happens if cell already has a value
            if(mResults[index] != MarkType.Free)
                return;

            // Set the cell value based on which player
            mResults[index] = mPlayerOneTurn ? MarkType.Cross : MarkType.Nought;

            button.Content = mPlayerOneTurn ? "X" : "O";

            //Change noughts to green
            if (!mPlayerOneTurn)
                button.Foreground = Brushes.Red;

            // Toggle player turns
            if (mPlayerOneTurn)
                mPlayerOneTurn = false;
            else
                mPlayerOneTurn = true;

            CheckForWinner();
        }

        /// <summary>
        /// Checks for the winner with 3 line straight
        /// </summary>
        private void CheckForWinner()
        {      
            // Horizontal Check
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                mGameEnded = true;
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
            }
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                mGameEnded = true;
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
            }
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                mGameEnded = true;
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }
            // Vertical Check
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                mGameEnded = true;
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
            }
            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                mGameEnded = true;
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
            }
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                mGameEnded = true;
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
            }
            // X win
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                mGameEnded = true;
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
            }
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                mGameEnded = true;
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.Green;
            }
    


            //Check for no winner case
            if (mGameEnded != true && !mResults.Any(f => f == MarkType.Free))
            {
                mGameEnded = true;
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;

                });
            }
        }
    }
}
