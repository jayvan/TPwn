/*
 * User: Justin Vanderheide
 * Date: 10/23/2011
 * Time: 1:55 PM
 * 
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace tPwn
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		int[,] board;
		char nextPiece;
		const int BOARD_WIDTH = 10;
		const int BOARD_HEIGHT = 19;
		const int BLOCK_SIZE = 18;
		const int KEY_DURATION = 50; // How long the keys are held down
		const int KEY_DELAY = 55;		// How long the bot waits between keys
		int grid_x = 0;
		int grid_y = 0;
		
		
		Dictionary<char, Tetromino> pieces;
		
		public MainForm() {
			nextPiece = 'x';
			board = new int[BOARD_WIDTH, BOARD_HEIGHT];
			pieces = new Dictionary<char, Tetromino>();
			AutoX.AU3_Opt("SendAttachMode", 0);
			AutoX.AU3_Opt("SendKeyDelay", KEY_DELAY);
			AutoX.AU3_Opt("SendKeyDownDelay", KEY_DURATION);
			readData();
			InitializeComponent();
		}
		
		void readData() {
			StreamReader reader = new StreamReader("data");
			int numPieces = int.Parse(reader.ReadLine());
			for (int i = 0; i < numPieces; i++) {
				char pieceName = reader.ReadLine()[0];
				Tetromino piece = new Tetromino();
				piece.orientations = new Orientation[4];
				for (int j = 0; j < 4; j++) {
					string[] data = reader.ReadLine().Split(' ');
					piece.orientations[j].offset = int.Parse(data[0]);
					piece.orientations[j].width = int.Parse(data[1]);
					piece.orientations[j].blocks = readPiece(reader);
				}
				pieces.Add(pieceName, piece);
			}
		}
		
		bool[,] readPiece(StreamReader reader) {
			bool[,] blocks = new bool[4,4];
			for (int y = 3; y >= 0; y--) {
				string line = reader.ReadLine();
				for (int x = 0; x < 4; x++) {
					blocks[x,y] = line[x] == '1';
				}
			}
			return blocks;
		}
		
		// Take in a board, and a piece. Return an array with two indices.
		// The first dictates the number of clockwise rotations, the second
		// dictates the column of the leftmost block (0 is the far left)
		int[] bestMove() {
			Tetromino piece = pieces[nextPiece];
			int rotation = 0;
			int offset = 0;
			int score = int.MinValue;
			
			for (int rot = 0; rot < 4; rot++) {
				for (int col = 0; col <= BOARD_WIDTH - piece.orientations[rot].width; col++ ) {
					DropResult result = dropPiece(piece.orientations[rot], col);
					int tScore = scoreBoardTwo(result);
					if (tScore > score) {
						score = tScore;
						rotation = rot;
						offset = col - piece.orientations[rot].offset;
					}
				}
			}
			lblScore.Text = score.ToString();
			return new int[] {rotation, offset};
		}
		
		int[,] clearLine(int[,] grid, int row) {
			for (int y = row; y < BOARD_HEIGHT - 1; y++) {
				for (int x = 0; x < BOARD_WIDTH; x++) {
					grid[x,y] = grid[x,y+1];
				}
			}
			
			return grid;
		}
		
		DropResult dropPiece(Orientation piece, int column) {
			DropResult dr = new DropResult();
			
			int[,] grid = (int[,])board.Clone();
			int depth = 3;
			bool collision = false;
			
			while(!collision) {
				depth++;
				for (int y = 0; y < 4; y++) {
					for (int x = 0; x < piece.width; x++) {
						if (BOARD_HEIGHT - depth + y < 0 || (grid[column + x, BOARD_HEIGHT - depth + y] != 0 && piece.blocks[x, y])) {
							collision = true;
							break;
						}
					}
					if (collision) break;
				}
			}
			
			depth--; //Return to last acceptable depth
			
			//TODO: FIX THIS FRIGGEN EXCEPTION!!!
			try {
				// Move the piece into the board
				for (int y = 0; y < 4; y++) {
					for (int x = 0; x < piece.width; x++) {
						if (piece.blocks[x, y])
							grid[column + x, BOARD_HEIGHT - depth + y] = 2;
					}
				}
			} catch {
				dr.grid = new int[BOARD_WIDTH, BOARD_HEIGHT];
				dr.clears = -100;
				return dr;
			}
			
			for (int y = 0; y < 4; y++) {
				if (BOARD_HEIGHT - depth + 3 - y >= BOARD_HEIGHT) continue;
				bool clear = true;
					for (int x = 0; x < BOARD_WIDTH; x++) {
						
						if (grid[x, BOARD_HEIGHT - depth + 3 - y] == 0) {
							clear = false;
							break;
						}
					}
					
					if (clear) {
						dr.clears++;
						clearLine(grid, BOARD_HEIGHT - depth + 3 - y);
					}
				}
			dr.grid = grid;
			return dr;
		}
		
		int scoreBoardTwo(DropResult result) {
			int score = result.clears * 4;
			int height = 0;
			for (int y = 0; y < BOARD_HEIGHT; y++) {
				for (int x = 0 ; x < BOARD_WIDTH; x++) {
					if (result.grid[x,y] == 2) {
						if (old(result.grid, x - 1, y)) score++;
						if (old(result.grid, x + 1, y)) score++;
						if (old(result.grid, x, y - 1)) score++;
						if (old(result.grid, x, y + 1)) score++;
						if (!filled(result.grid, x, y - 1)) score -= 5;;
						height = y;
					}
				}
			}
			
			return score - height;
    }
		
		// Determine the "score" of a board so that more desireable
		// outcomes are moved towards
		// covered square = -25
		// height = -1
		int scoreBoard(int[,] grid) {
			int score = 0;
			for (int y = 0; y < BOARD_HEIGHT; y++) {
				for (int x = 0; x < BOARD_WIDTH; x++) {
					// If a square is empty and the space above is filled penalize
					if (grid[x,y] == 0 && filled(grid,x,y+1)) score -= 2500;
					if (grid[x,y] != 0) score -= y;
				}
			}
			return score;
		}
		
		bool filled(int[,] grid, int x, int y) {
			return y >= BOARD_HEIGHT || y < 0 || x < 0 || x >= BOARD_WIDTH || grid[x,y] != 0;
		}
		
		bool old(int[,] grid, int x, int y) {
			return y >= BOARD_HEIGHT || y < 0 || x < 0 || x >= BOARD_WIDTH || grid[x,y] == 1;
		}
		
		void readBoard()
		{
			grid_x = this.Left + 15;
			grid_y = this.Top - 15;
			for (int y = 0; y < BOARD_HEIGHT; y++) {
				for (int x = 0; x < BOARD_WIDTH; x++) {
					int tmp = AutoX.AU3_PixelGetColor(grid_x + x * BLOCK_SIZE, grid_y - y * BLOCK_SIZE);
					int a = tmp / 0x010000;
					tmp %= 0x010000;
					int b = tmp / 0x0100;
					tmp %= 0x0100;
					int c = tmp;
					board[x,y] = !(a == b && b == c) ? 1 : 0;
				}
			}
		}
		
		void readPiece() {
			int color = AutoX.AU3_PixelGetColor(this.Left + 83, this.Top - 353);
			switch(color) {
				case 0xffc225:
					nextPiece = 'o';
					break;
				case 0xfa325a:
					nextPiece = 'z';
					break;
				case 0xff7e25:
					nextPiece = 'l';
					break;
				case 0xd24cad:
					nextPiece = 't';
					break;
				case 0x4464e9:
					nextPiece = 'j';
					break;
				case 0x32befa:
					nextPiece = 'i';
					break;
				case 0x7cd424:
					nextPiece = 's';
					break;
				default:
					nextPiece = '?';
					break;
			}
			lblNext.Text = nextPiece.ToString().ToUpper();
			lblColor.Text = color.ToString("X");
		}
		
		void BtnStartClick(object sender, EventArgs e)
		{
			tmrRun.Start();
		}
		
		void BtnMoveClick(object sender, EventArgs e)
		{
			AutoX.AU3_MouseMove(this.Left + int.Parse(txtX.Text), this.Top + int.Parse(txtY.Text), 5);
		}
		
		void BtnKeysClick(object sender, EventArgs e)
		{
			AutoX.AU3_Sleep(5000);
			AutoX.AU3_Send("{LEFT}",0);
		}
		
		void TmrRunTick(object sender, EventArgs e)
		{
			readPiece();
			if (nextPiece == '?') return;
			tmrRun.Stop();
			readBoard();
			dropPiece();
		}
		
		void dropPiece() {
			string keys = "";
			int[] data = bestMove();
			lblRotate.Text = data[0].ToString();
			lblOffset.Text = data[1].ToString();
			this.Refresh();
			// Press UP data[0] times
			switch (data[0]) {
					case 1:
						keys = "x";
						break;
					case 2:
						keys = "xx";
						break;
					case 3:
						keys = "z";
						break;
			}
			
			bool left = data[1] < 0;
			data[1] = Math.Abs(data[1]);
			string key = left ? "{LEFT}" : "{RIGHT}";
			// PRESS LEFT OR RIGHT data[1] TIMES HERE
			for (int i = 0; i < data[1]; i++) {
				keys = keys + key;
			}
			keys = keys + " ";
			AutoX.AU3_Send(keys, 0);
			tmrRun.Start();
		}
	}
}